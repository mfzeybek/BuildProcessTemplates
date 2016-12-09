using System;
using System.Data.SqlClient;

namespace Aresv2.BasitUretim
{
    public partial class frmBasitUretimRecetesiListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmBasitUretimRecetesiListesi()
        {
            InitializeComponent();
        }


        SqlTransaction TrGenel;
        public int ReceteID;

        private void btnFiltrele_Click(object sender, EventArgs e)
        {

            AramaKriterleriniGonder();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            gridControl1.DataSource = UretimRecetesiArama.GetirHamisina(SqlConnections.GetBaglanti(), TrGenel);

            try
            {
                //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                gridView1.RestoreLayoutFromStream(cs.csGridLayout.GetLayout(-1, this.Name, gridView1.Name, SqlConnections.GetBaglanti(), TrGenel));
                //TrGenel.Commit();
            }
            catch (Exception)
            {


            }
            TrGenel.Commit();
        }

        private void btnKaydiAc_Click(object sender, EventArgs e)
        {
            Aresv2.BasitUretim.frmBasitUretimRecetesi recete = new frmBasitUretimRecetesi((int)gridView1.GetFocusedRowCellValue("BUReceteID"));
            recete.MdiParent = this.MdiParent;
            recete.Show();
        }

        private void frmBasitUretimRecetesiListesi_Load(object sender, EventArgs e)
        {
            AramaKriterleriniAl();

            try
            {
                //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                //gridView1.RestoreLayoutFromStream(cs.csGridLayout.GetLayout(-1, this.Name, gridView1.Name, SqlConnections.GetBaglanti(), TrGenel));
                //TrGenel.Commit();
            }
            catch (Exception)
            {


            }

        }
        clsTablolar.BasitUretim.csBasitUretimReceteArama UretimRecetesiArama = new clsTablolar.BasitUretim.csBasitUretimReceteArama();
        void AramaKriterleriniGonder()
        {
            UretimRecetesiArama.UretilenStokAdi = txtUretilenStokAdi.EditValue.ToString();
            UretimRecetesiArama.UretilenStokKodu = txtStokKodu.EditValue.ToString();
            UretimRecetesiArama.UretilenStokBarkodu = txtStokBarkod.EditValue.ToString();
            UretimRecetesiArama.UretilenStokAciklama = txtAciklama.Text;

            UretimRecetesiArama.StokGrupID = Convert.ToInt32(lkpStokGrup.EditValue);
            UretimRecetesiArama.StokAraGrupID = Convert.ToInt32(lkpStokAraGrup.EditValue);
            UretimRecetesiArama.StokAltGrupID = Convert.ToInt32(lkpStokAltGrup.EditValue);

            UretimRecetesiArama.HammaddeStokAdi = txtHammaddeStokAdi.Text;
            UretimRecetesiArama.HammaddeStokKoodu = txtHammaddeStokKodu.Text;
            UretimRecetesiArama.HammaddeStokBarkodu = txtHammaddeStokBarkodu.Text;
            UretimRecetesiArama.HammaddeStokAciklama = txtHammaddeStokAciklama.Text;

            UretimRecetesiArama.HammaddeStokGrupID = (int)lkpHammaddeStokGrubu.EditValue;
            UretimRecetesiArama.HammaddeStokAraGrupID = (int)lkpHammaddeStokAraGrubu.EditValue;
            UretimRecetesiArama.HammaddeStokAltGrupID = (int)lkpHammaddeStokAltGrubu.EditValue;
        }

        void AramaKriterleriniAl()
        {
            txtUretilenStokAdi.EditValue = UretimRecetesiArama.UretilenStokAdi;
            txtStokKodu.EditValue = UretimRecetesiArama.UretilenStokKodu;
            txtStokBarkod.EditValue = UretimRecetesiArama.UretilenStokBarkodu;


            StokGrupYukle();

            StokAraGrupYukle(-1);

            StokAltGrupYukle(-1);

            lkpStokGrup.EditValue = UretimRecetesiArama.StokGrupID;
            lkpStokAraGrup.EditValue = UretimRecetesiArama.StokAraGrupID;
            lkpStokAltGrup.EditValue = UretimRecetesiArama.StokAltGrupID;

            txtHammaddeStokAdi.Text = UretimRecetesiArama.HammaddeStokAdi;
            txtHammaddeStokKodu.Text = UretimRecetesiArama.HammaddeStokKoodu;
            txtHammaddeStokBarkodu.Text = UretimRecetesiArama.HammaddeStokBarkodu;
            txtHammaddeStokAciklama.Text = UretimRecetesiArama.HammaddeStokAciklama;

            lkpHammaddeStokGrubu.EditValue = UretimRecetesiArama.HammaddeStokGrupID;
            lkpHammaddeStokAraGrubu.EditValue = UretimRecetesiArama.HammaddeStokAraGrupID;
            lkpHammaddeStokAltGrubu.EditValue = UretimRecetesiArama.HammaddeStokGrupID;
        }

        private void barButtonItemYerlesimiKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                cs.csGridLayout.InsertLayout(-1, this.Name, gridView1, SqlConnections.GetBaglanti(), TrGenel);
                TrGenel.Commit();
            }
            catch (Exception)
            {

            }
        }

        clsTablolar.Stok.csStokGrup StokGrup;
        clsTablolar.Stok.csStokAraGrup StokAraGrup;
        clsTablolar.Stok.csStokAltGrup StokAltGrup;

        void StokGrupYukle()
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            StokGrup = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), TrGenel, -1);
            lkpStokGrup.Properties.DataSource = StokGrup.StokGrupDoldur(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();
            lkpStokGrup.Properties.DisplayMember = "StokGrupAdi";
            lkpStokGrup.Properties.ValueMember = "StokGrupID";

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            StokGrup = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), TrGenel, -1);
            lkpHammaddeStokGrubu.Properties.DataSource = StokGrup.StokGrupDoldur(SqlConnections.GetBaglanti(), TrGenel);
            lkpHammaddeStokGrubu.Properties.DisplayMember = "StokGrupAdi";
            lkpHammaddeStokGrubu.Properties.ValueMember = "StokGrupID";
            TrGenel.Commit();

        }
        void StokAraGrupYukle(int GrupID)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            StokAraGrup = new clsTablolar.Stok.csStokAraGrup(SqlConnections.GetBaglanti(), TrGenel, -1);

            lkpStokAraGrup.Properties.DataSource = StokAraGrup.StokAraGrupDoldur(SqlConnections.GetBaglanti(), TrGenel, GrupID);
            lkpStokAraGrup.Properties.DisplayMember = "StokAraGrupAdi";
            lkpStokAraGrup.Properties.ValueMember = "StokAraGrupID";
            TrGenel.Commit();


        }

        void HammaddeStokAraGrubu_Yukle(int HammaddeStokGrupID)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            StokAraGrup = new clsTablolar.Stok.csStokAraGrup(SqlConnections.GetBaglanti(), TrGenel, -1);
            lkpHammaddeStokAraGrubu.Properties.DataSource = StokAraGrup.StokAraGrupDoldur(SqlConnections.GetBaglanti(), TrGenel, HammaddeStokGrupID);
            TrGenel.Commit();
            lkpHammaddeStokAraGrubu.Properties.DisplayMember = "StokAraGrupAdi";
            lkpHammaddeStokAraGrubu.Properties.ValueMember = "StokAraGrupID";

        }
        void HammaddeStokAltGrubu_Yukle(int HammaddeAraGrupID)
        {
            StokAltGrup = new clsTablolar.Stok.csStokAltGrup();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            StokAltGrup.StokAltGrupDoldur(SqlConnections.GetBaglanti(), TrGenel, HammaddeAraGrupID);
            TrGenel.Commit();

            lkpHammaddeStokAltGrubu.Properties.DisplayMember = "StokAltGrupAdi";
            lkpHammaddeStokAltGrubu.Properties.ValueMember = "StokAltGrupID";
        }
        void StokAltGrupYukle(int AraGrupID)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            StokAltGrup = new clsTablolar.Stok.csStokAltGrup();
            StokAltGrup.StokAltGrupDoldur(SqlConnections.GetBaglanti(), TrGenel, AraGrupID);
            TrGenel.Commit();
        }

        private void lkpStokGrup_EditValueChanged(object sender, EventArgs e)
        {
            StokAraGrupYukle(Convert.ToInt32(lkpStokGrup.EditValue));
        }

        private void lkpStokAraGrup_EditValueChanged(object sender, EventArgs e)
        {
            StokAltGrupYukle(Convert.ToInt32(lkpStokAraGrup.EditValue));
        }

        private void lkpStokGrup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                ((sender) as DevExpress.XtraEditors.LookUpEdit).EditValue = -1;
                lkpStokAraGrup.EditValue = -1;
                lkpStokAltGrup.EditValue = -1;
            }
        }

        private void lkpStokAraGrup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                ((sender) as DevExpress.XtraEditors.LookUpEdit).EditValue = -1;
                lkpStokAltGrup.EditValue = -1;
            }
        }

        private void lkpStokAltGrup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                ((sender) as DevExpress.XtraEditors.LookUpEdit).EditValue = -1;
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void lkpHammaddeStokGrubu_EditValueChanged(object sender, EventArgs e)
        {
            HammaddeStokAraGrubu_Yukle(Convert.ToInt32(lkpHammaddeStokGrubu.EditValue));
        }

        private void lkpHammaddeStokAraGrubu_EditValueChanged(object sender, EventArgs e)
        {
            HammaddeStokAltGrubu_Yukle(Convert.ToInt32(lkpHammaddeStokAraGrubu.EditValue));
        }

        private void lkpHammaddeStokGrubu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                ((sender) as DevExpress.XtraEditors.LookUpEdit).EditValue = -1;
                lkpHammaddeStokGrubu.EditValue = -1;
                lkpHammaddeStokAraGrubu.EditValue = -1;
                lkpHammaddeStokAltGrubu.EditValue = -1;
            }
        }

        private void lkpHammaddeStokAraGrubu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                ((sender) as DevExpress.XtraEditors.LookUpEdit).EditValue = -1;
                lkpHammaddeStokAraGrubu.EditValue = -1;
                lkpHammaddeStokAltGrubu.EditValue = -1;
            }
        }

        private void lkpHammaddeStokAltGrubu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                ((sender) as DevExpress.XtraEditors.LookUpEdit).EditValue = -1;
                lkpHammaddeStokAltGrubu.EditValue = -1;
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            ReceteID = (int)gridView1.GetFocusedRowCellValue("BUReceteID");
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }
    }
}