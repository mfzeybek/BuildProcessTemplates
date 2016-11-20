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
    public partial class frmPersonelKarti : DevExpress.XtraEditors.XtraForm
    {
        public frmPersonelKarti(int PersonelID)
        {
            _PersonelID = PersonelID;
            InitializeComponent();
        }
        int _PersonelID = -1;

        clsTablolar.Personel.csPersonel Personel;
        clsTablolar.cari.csCariv2 PersonelCarisi;
        clsTablolar.Personel.csPersonelGorevIliski PersonelGorevleri;
        clsTablolar.Personel.csPersonelGorevTanim GorevTanimlari;

        SqlTransaction tr_genel;
        private void frmPersonelKarti_Load(object sender, EventArgs e)
        {
            try
            {
                Personel = new clsTablolar.Personel.csPersonel(SqlConnections.GetBaglanti(), _PersonelID);
                PersonelGorevleri = new clsTablolar.Personel.csPersonelGorevIliski(SqlConnections.GetBaglanti(), _PersonelID);
                tr_genel = SqlConnections.GetBaglanti().BeginTransaction();
                GorevTanimlari = new clsTablolar.Personel.csPersonelGorevTanim(SqlConnections.GetBaglanti(), tr_genel);
                GorevleriYukle();
                BinleHamisina();
                tr_genel.Commit();
            }
            catch (Exception)
            {
                tr_genel.Rollback();
                MessageBox.Show("hata oldu hamisina");
            }
        }

        private void BinleHamisina()
        {
            txtPersonelAdi.DataBindings.Add("EditValue", Personel, "PersonelAdi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaasi.DataBindings.Add("EditValue", Personel, "Maasi", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void GorevleriYukle()
        {
            gcGorevleri.DataSource = PersonelGorevleri.dt_PersonelGorevIliski;
            repositoryItemLookUpEdit_GorevTanimlari.DataSource = GorevTanimlari.dt_PersonelGorev;
            repositoryItemLookUpEdit_GorevTanimlari.DisplayMember = "GorevAdi";
            repositoryItemLookUpEdit_GorevTanimlari.ValueMember = "PersonelGorevID";
        }

        private void txtPersonelAdi_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmCariListe frm = new frmCariListe();
            frm.Text = "Cari Arama";

            frm._CariIDVer = CaridenIDyiAl;
            frm._Veriver = BunusilsonraAnladinsenonu;
            frm.ShowDialog();
        }

        private void CaridenIDyiAl(int CariID)
        {
            try
            {
                tr_genel = SqlConnections.GetBaglanti().BeginTransaction();

                PersonelCarisi = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), tr_genel, CariID);
                Personel.CariID = PersonelCarisi.CariID;
                txtPersonelAdi.EditValue = PersonelCarisi.CariTanim;
                tr_genel.Commit();
            }
            catch (Exception)
            {
                tr_genel.Rollback();
            }

        }
        private void BunusilsonraAnladinsenonu(DataRow Dr)
        {
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                tr_genel = SqlConnections.GetBaglanti().BeginTransaction();
                Personel.PersonelKaydet(SqlConnections.GetBaglanti(), tr_genel, _PersonelID);
                tr_genel.Commit();
            }
            catch (Exception)
            {
                tr_genel.Rollback();
            }
            
        }

    }
}