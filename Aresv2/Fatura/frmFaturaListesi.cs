using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace Aresv2.Fatura
{
    public partial class frmFaturaListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmFaturaListesi(AcmaYontemi _NasilAcsin)
        {
            NasilAcsin = _NasilAcsin;
            InitializeComponent();
        }

        AcmaYontemi NasilAcsin;
        public enum AcmaYontemi
        {
            FaturaListe,
            FaturaArama
        }
        SqlTransaction trGenel;
        clsTablolar.Fatura.csFaturaArama FaturaArama;
        //clsTablolar.Fatura.csFaturaTipi FaturaTipi = new clsTablolar.Fatura.csFaturaTipi();
        clsTablolar.Fatura.csFaturaGrup FaturaGrubu = new clsTablolar.Fatura.csFaturaGrup();

        enum ReportAction { Print, Preview, Dizayn }

        private void frmFaturaListesi_Load(object sender, EventArgs e)
        {
            try
            {
                FaturaArama = new clsTablolar.Fatura.csFaturaArama(SqlConnections.GetBaglanti(), trGenel, -1);

                txtCariAdi.DataBindings.Add("EditValue", FaturaArama, "CariTanimi", true, DataSourceUpdateMode.OnPropertyChanged);
                //lkpFaturaTipi.Properties.DataSource = FaturaTipi.FaturaTipleri();
                lkpFaturaTipi.Properties.PopulateColumns();
                lkpFaturaTipi.Properties.ValueMember = "TipiID";
                lkpFaturaTipi.Properties.DisplayMember = "Adi";

                //txtFaturaBarkod.DataBindings.Add("EditValue", FaturaArama, "FaturaBarkod", true, DataSourceUpdateMode.OnPropertyChanged);
                lkpFaturaTipi.DataBindings.Add("EditValue", FaturaArama, "FaturaTipi", true, DataSourceUpdateMode.OnPropertyChanged);

                if (NasilAcsin == AcmaYontemi.FaturaListe)
                {
                    btnKaydiAc.Visible = true;
                    btnSec.Visible = false;
                    barCheckItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    btnKaydiAc.Visible = false;
                    btnSec.Visible = true;
                    barCheckItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            FaturaArama.FaturaBarkod = txtFaturaBarkod.Text;
            FaturaArama.GirisCikis = cmbGirisCikis.SelectedIndex;
            FaturaArama.FaturadakiCariTanim = txtFaturadakiCariTanim.Text;
            FaturaArama.CariKodu = txtCariKodu.Text;
            FaturaArama.Tarih1 = deTarih1.DateTime;
            FaturaArama.Tarih2 = deTarih2.DateTime;
            gcFatura.DataSource = FaturaArama.FaturaAraListe(SqlConnections.GetBaglanti(), trGenel);
            gvFatura.BestFitColumns();
            GridArayuzIslemleri(enGridArayuzIslemleri.Get);
        }
        private void btnKaydiAc_Click(object sender, EventArgs e)
        {
            //aslında gridde seçili satır yoksa işlem yapmasın demek için "FocusedRowHandle" yeterdi ama
            //elimizde farklı kod olsun diye "SelectedRowsCount" u da yazdık. :)
            if (gvFatura.FocusedRowHandle < 0 || gvFatura.SelectedRowsCount <= 0) return;

            Fatura.frmFaturaDetay FaturaKarti = new Fatura.frmFaturaDetay(Convert.ToInt32(gvFatura.GetFocusedRowCellValue("FaturaID")));
            FaturaKarti.MdiParent = this.MdiParent;
            FaturaKarti.Show();
        }
        private void lkpFaturaTipi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                lkpFaturaTipi.EditValue = -1;
        }
        private void frmFaturaListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                GridArayuzIslemleri(enGridArayuzIslemleri.Set);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }
        }
        #region Gird Arayüz İşlemleri
        enum enGridArayuzIslemleri { Set, Get };
        void GridArayuzIslemleri(enGridArayuzIslemleri islem)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                FormdakiGridleriBul(this, islem);
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
            }
        }
        private void FormdakiGridleriBul(Control nesne, enGridArayuzIslemleri islem)
        {
            if (nesne is DevExpress.XtraGrid.GridControl)
            {
                if (islem == enGridArayuzIslemleri.Set)
                    GridArayuzleriKaydet(nesne);
                else
                    GridArayuzleriYukle(nesne);
            }

            foreach (Control altnesne in nesne.Controls)
                FormdakiGridleriBul(altnesne, islem);
        }
        void GridArayuzleriKaydet(Control ctrl)
        {
            DevExpress.XtraGrid.GridControl gc = new GridControl();
            gc = ctrl as DevExpress.XtraGrid.GridControl;
            DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

            string Layout = "";
            using (var ms = new MemoryStream())
            {
                gv.SaveLayoutToStream(ms);
                ms.Position = 0;
                using (var reader = new StreamReader(ms))
                    Layout = reader.ReadToEnd();
            }
            cs.csGridLayout.InsertLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, Layout, SqlConnections.GetBaglanti(), trGenel);
        }
        void GridArayuzleriYukle(Control ctrl)
        {
            DevExpress.XtraGrid.GridControl gc = new GridControl();
            gc = ctrl as DevExpress.XtraGrid.GridControl;
            DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

            MemoryStream ms = cs.csGridLayout.GetLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, SqlConnections.GetBaglanti(), trGenel);
            if (ms.Length > 0)
                gv.RestoreLayoutFromStream(ms);
        }
        #endregion
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvFatura.FocusedRowHandle < 0) return;
                if (XtraMessageBox.Show("Seçili Transfer İşlemini silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
                System.Collections.Generic.List<Int32> hareketler = new System.Collections.Generic.List<int>();
                using (SqlCommand cmdHareketler = new SqlCommand("Select FaturaHareketID From FaturaHareket Where FaturaID=@FaturaID", SqlConnections.GetBaglanti()))
                {
                    cmdHareketler.Parameters.Add("@FaturaID", SqlDbType.Int).Value = Convert.ToInt32(gvFatura.GetFocusedRowCellValue("FaturaID").ToString());
                    using (SqlDataReader drHareketler = cmdHareketler.ExecuteReader())
                    {
                        while (drHareketler.Read()) hareketler.Add(Convert.ToInt32(drHareketler["FaturaHareketID"].ToString()));
                    }
                }
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                foreach (Int32 ID in hareketler)
                {
                    using (SqlCommand cmdHareketDelete = new SqlCommand("Delete From FaturaHareket Where FaturaHareketID=@FaturaHareketID", SqlConnections.GetBaglanti()))
                    {
                        cmdHareketDelete.Transaction = trGenel;
                        cmdHareketDelete.Parameters.Add("@FaturaHareketID", SqlDbType.Int).Value = ID;
                        cmdHareketDelete.ExecuteNonQuery();
                    }
                }
                using (SqlCommand cmdFaturaDelete = new SqlCommand("Delete From Fatura Where FaturaID=@FaturaID", SqlConnections.GetBaglanti()))
                {
                    cmdFaturaDelete.Transaction = trGenel;
                    cmdFaturaDelete.Parameters.Add("@FaturaID", SqlDbType.Int).Value = gvFatura.GetFocusedRowCellValue("FaturaID").ToString();
                    cmdFaturaDelete.ExecuteNonQuery();
                }
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        #region YAZDIRMA İŞLEMLERİ
        private void mbtnYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void mbtnOnizleme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ProcessReport(ReportAction.Preview);
            //clsTablolar.csYazdirma Yazdirma = new clsTablolar.csYazdirma();

            cs.csYazdir dizayn = new cs.csYazdir();
            //dizayn.faturaYazdir(SqlConnections.GetBaglanti(),(int)gvFatura.GetFocusedRowCellValue("FaturaID"), Application.StartupPath + "\\ReportDesigners\\Fatura\\rptFatura.repx", cs.csYazdir.Nasil.dizayn);

        }
        private void mbtnDizayn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XRDesignFormEx XrDesigner = new XRDesignFormEx();

            XrDesigner.FileName = Application.StartupPath + "\\ReportDesigners\\Fatura\\rptFatura.repx";
            XrDesigner.OpenReport(RaporStokGiris());

            XrDesigner.Show();
        }

        private XtraReport RaporStokGiris()
        {
            XtraReport xr_Master = new XtraReport();
            xr_Master.LoadLayout(Application.StartupPath + "\\ReportDesigners\\Fatura\\rptFatura.repx");
            //clsTablolar.csYazdirma Yazdirma = new clsTablolar.csYazdirma();

            //xr_Master.DataSource = Yazdirma.fa (SqlConnections.GetBaglanti(),(int)gvFatura.GetFocusedRowCellValue("FaturaID"));

            return xr_Master;
        }
        #endregion
        private void btnYazdir_Click(object sender, EventArgs e)
        {

        }

        private void frmFaturaListesi_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2: btnFiltrele_Click(null, null);
                    break;
                case Keys.Escape: Close();
                    break;
            }
        }

        public int SeciliFaturaID = -1;
        public int SeciliFaturaCariID = -1;

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (Fatura_Sec == null)
            {
                SeciliFaturaID = (int)gvFatura.GetFocusedRowCellValue("FaturaID");
                SeciliFaturaCariID = (int)gvFatura.GetFocusedRowCellValue("CariID");
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                this.Close();
            }
            else
            {
                if (gvFatura.IsMultiSelect)
                {
                    foreach (int item in gvFatura.GetSelectedRows())
                    {
                        Fatura_Sec((int)gvFatura.GetRowCellValue(item, "FaturaID"));
                    }
                }
                else
                {
                    Fatura_Sec((int)gvFatura.GetFocusedRowCellValue("FaturaID"));
                }
            }
        }
        public delegate void dlg_FaturaSec(int StokID);
        public dlg_FaturaSec Fatura_Sec;

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void deTarih2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBugun_Click(object sender, EventArgs e)
        {
            deTarih1.DateTime = DateTime.Today;
            deTarih2.DateTime = DateTime.Today;
        }

        private void barButtonItem_RaporListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barCheckItem1.Checked == true)
            {
                gvFatura.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                gvFatura.OptionsSelection.MultiSelect = true;
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                gvFatura.OptionsSelection.MultiSelect = false;
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvFatura.SelectAll();
        }

        private void deTarih1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void gvFatura_RowCountChanged(object sender, EventArgs e)
        {
            txtFaturaSayisi.EditValue = gvFatura.RowCount;
        }

        private void btnIslemler_Click(object sender, EventArgs e)
        {

        }

        private void btnCariHareketleri_Click(object sender, EventArgs e)
        {

        }
    }
}
