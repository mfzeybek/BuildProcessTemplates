using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.Personel
{
    public partial class frmPdksKart : DevExpress.XtraEditors.XtraForm
    {
        public frmPdksKart(int PDKSHRID)
        {
            _PDKSHRID = PDKSHRID;
            InitializeComponent();
        }
        int _PDKSHRID;


        frmPersonelListesi personeller = new frmPersonelListesi(frmPersonelListesi.AramamiListeMi.Arama);
        clsTablolar.Personel.PDKS.csPersonel Personel;
        clsTablolar.Personel.PDKS.csPdksV2 PDKSHr;
        clsTablolar.Personel.PDKS.csPDKSYerler Yerler;
        //clsTablolar.Personel.PDKS.csPDKSAciklama Aciklamalar = new clsTablolar.Personel.PDKS.csPDKSAciklama(); // bu sanırım artık gerekli değil daha sonra kontrol et
        SqlTransaction Trgenel;

        // mesai başlangıcı olarak işaretlenirse
        // veri tabanında o günün o personel için ilk kayıt olması gerekir
        //

        private void frmPdksKart_Load(object sender, EventArgs e)
        {
            try
            {
                Trgenel = PDKSSqlconnection.GetBaglanti().BeginTransaction();

                PDKSHr = new clsTablolar.Personel.PDKS.csPdksV2(PDKSSqlconnection.GetBaglanti(), Trgenel, _PDKSHRID);
                //btnPersonel_Click(null, null);
                Personel = new clsTablolar.Personel.PDKS.csPersonel(PDKSSqlconnection.GetBaglanti(), Trgenel, PDKSHr.PersonelID);

                lblPersonelAdi.Text = Personel.PersonelAdi;
                YeriDoldur();
                NesneleriBinle(get_set.get);
                Trgenel.Commit();
            }
            catch (Exception hata)
            {
                Trgenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        enum get_set { get, Set }

        void NesneleriBinle(get_set getmisetmi)
        {
            if (getmisetmi == get_set.get)
            {
                txtZaman1.EditValue = PDKSHr.Zaman;
                lkpYer.EditValue = PDKSHr.YerID;
            }
            else
            {
                PDKSHr.Zaman = Convert.ToDateTime(txtZaman1.EditValue);
                PDKSHr.YerID = Convert.ToInt32(lkpYer.EditValue);
            }
        }

        void YeriDoldur()
        {
            Yerler = new clsTablolar.Personel.PDKS.csPDKSYerler();
            Yerler.YerleriGetir(PDKSSqlconnection.GetBaglanti(), Trgenel);
            lkpYer.Properties.DataSource = Yerler.dt;
            lkpYer.Properties.ValueMember = "YerID";
            lkpYer.Properties.DisplayMember = "YerAdi";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                NesneleriBinle(get_set.Set);
                Trgenel = PDKSSqlconnection.GetBaglanti().BeginTransaction();
                PDKSHr.Kaydet(PDKSSqlconnection.GetBaglanti(), Trgenel, PDKSHr.ID);
                Trgenel.Commit();
            }
            catch (Exception hata)
            {
                Trgenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            personeller.ShowDialog();
            int PersonelID = Convert.ToInt32(personeller.Tag);
            PDKSHr.PersonelID = Personel.PersonelID;
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}