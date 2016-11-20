using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace Aresv2.Siparis
{
    public partial class frmSiparisListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmSiparisListesi()
        {
            InitializeComponent();
        }
        SqlTransaction trGenel;
        clsTablolar.Siparis.csSiparisArama SiparisArama;
        clsTablolar.Siparis.csSiparisTipi SiparisTipi = new clsTablolar.Siparis.csSiparisTipi();
        //csSiparisGrubu SiparisGrubu = new csSiparisGrubu();
        DataTable dtSiparis = new DataTable();
        clsTablolar.Siparis.csSiparisDurumTanimlari Tanimlar = new clsTablolar.Siparis.csSiparisDurumTanimlari();
        enum ReportAction { Print, Preview, Dizayn }

        private void frmSiparisListesi_Load(object sender, EventArgs e)
        {
            try
            {
                SiparisArama = new clsTablolar.Siparis.csSiparisArama(SqlConnections.GetBaglanti(), trGenel, -1);


                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                checkedListBoxControl1.DataSource = Tanimlar.Dt_Getir_HepsiSatiriIleBirlikte(SqlConnections.GetBaglanti(), trGenel);
                trGenel.Commit();

                checkedListBoxControl1.ValueMember = "SiparisDurumTanimID";
                checkedListBoxControl1.DisplayMember = "SiparisDurumTanimAdi";


                txtCariAdi.DataBindings.Add("EditValue", SiparisArama, "CariTanimi");
                lkpSiparisTipi.Properties.DataSource = SiparisTipi.SiparisTipleri();
                lkpSiparisTipi.Properties.PopulateColumns();
                lkpSiparisTipi.Properties.ValueMember = "TipiID";
                lkpSiparisTipi.Properties.DisplayMember = "Adi";

                lkpSiparisTipi.DataBindings.Add("EditValue", SiparisArama, "SiparisTipi");
                deSiparisTarihi1.DataBindings.Add("EditValue", SiparisArama, "SiparisTarihiIlk", false, DataSourceUpdateMode.OnPropertyChanged);
                deSiparisTarihi2.DataBindings.Add("EditValue", SiparisArama, "SiparisTarihiIkinci", false, DataSourceUpdateMode.OnPropertyChanged);
                txtBarkodu.DataBindings.Add("EditValue", SiparisArama, "SiparisBarkodNu", false, DataSourceUpdateMode.OnPropertyChanged);

                deTeslimTarihiIlk.DataBindings.Add("EditValue", SiparisArama, "TeslimTarihiIlk", false, DataSourceUpdateMode.OnPropertyChanged);
                deTeslimTarihiIkinci.DataBindings.Add("EditValue", SiparisArama, "TeslimTarihiIkinci", false, DataSourceUpdateMode.OnPropertyChanged);

                // eğer alınan veya verilen siparişlerden görme yetkisinde kısıtlama varsa
                // alınan siparişin gözükmesine izin yoksa sadece verilen sipariş gözükecek
                // verilen siparişin gözükmesine izin verilmemişse sadece alınan sipariş gözükecek
                // iki sipariş tipinin de gözükmesin

                deSiparisTarihi2.Properties.NullDate = DateTime.MinValue;
                deSiparisTarihi1.Properties.NullDate = DateTime.MinValue;
                deTeslimTarihiIlk.Properties.NullDate = DateTime.MinValue;
                deTeslimTarihiIkinci.Properties.NullDate = DateTime.MinValue;

                if (clsTablolar.Ayarlar.csYetkiler.AlinanSiparisGorme == false)
                {
                    SiparisArama.SiparisTipi = (int)clsTablolar.IslemTipi.VerilenSiparis;
                    lkpSiparisTipi.Enabled = false;
                }
                else if (clsTablolar.Ayarlar.csYetkiler.VerilenSiparisGorme == false)
                {
                    //lkpSiparisTipi.EditValue = (int)clsTablolar.IslemTipi.AlinanSiparis;
                    SiparisArama.SiparisTipi = (int)clsTablolar.IslemTipi.AlinanSiparis;
                    lkpSiparisTipi.Enabled = false;
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
            try
            {
                SiparisArama.SiparisDurumTanimID = new int[checkedListBoxControl1.CheckedItems.Count];
                for (int i = 0; i < checkedListBoxControl1.CheckedItems.Count; i++)
                {
                    SiparisArama.SiparisDurumTanimID[i] = (int)checkedListBoxControl1.CheckedItems[i]
                        ;
                }
                SiparisArama.MuhasebelenmeDrumu = checkedListBox_Muhasebelenme.Items.GetCheckedValues().ToArray();

                switch (cmbHizliSatis.SelectedIndex)
                {
                    case 1:
                        SiparisArama.HizliSatistaGozukecekMi = 1;
                        break;
                    case 2:
                        SiparisArama.HizliSatistaGozukecekMi = 0;
                        break;
                    default:
                        SiparisArama.HizliSatistaGozukecekMi = -1;
                        break;
                }
                //SiparisArama.HizliSatistaGozukecekMi

                dtSiparis = SiparisArama.SiparisAraListe(SqlConnections.GetBaglanti(), trGenel);
                gcSiparis.DataSource = dtSiparis;
                GridArayuzIslemleri(enGridArayuzIslemleri.Get);
            }
            catch (Exception ex)
            {


            }
        }
        private void btnKaydiAc_Click(object sender, EventArgs e)
        {
            //aslında gridde seçili satır yoksa işlem yapmasın demek için "FocusedRowHandle" yeterdi ama
            //elimizde farklı kod olsun diye "SelectedRowsCount" u da yazdık. :)
            if (gvSiparis.FocusedRowHandle < 0 || gvSiparis.SelectedRowsCount <= 0) return;

            Siparis.frmSiparisDetay SiparisKarti = new Siparis.frmSiparisDetay(Convert.ToInt32(gvSiparis.GetFocusedRowCellValue("SiparisID")));
            SiparisKarti.MdiParent = this.MdiParent;
            SiparisKarti.Show();
        }
        private void lkpSiparisTipi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                lkpSiparisTipi.EditValue = -1;
        }
        private void frmSiparisListesi_FormClosed(object sender, FormClosedEventArgs e)
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


        #region YAZDIRMA İŞLEMLERİ
        private void mbtnYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcessReport(ReportAction.Print);
        }
        private void mbtnOnizleme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcessReport(ReportAction.Preview);
        }
        private void mbtnDizayn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcessReport(ReportAction.Dizayn);
        }
        private void ProcessReport(ReportAction action)
        {
            switch (action)
            {
                case ReportAction.Print:
                    RaporStokGiris().PrintDialog();
                    break;
                case ReportAction.Preview:
                    RaporStokGiris().ShowPreview();
                    break;
                case ReportAction.Dizayn:
                    XRDesignFormEx XrDesigner = new XRDesignFormEx();

                    XrDesigner.FileName = Application.StartupPath + "\\ReportDesigners\\Siparis\\rptSiparis.repx";
                    XrDesigner.OpenReport(RaporStokGiris());

                    XrDesigner.Show();
                    break;
            }
        }
        private XtraReport RaporStokGiris()
        {
            XtraReport xr_Master = new XtraReport();
            xr_Master.LoadLayout(Application.StartupPath + "\\ReportDesigners\\Siparis\\rptSiparis.repx");

            SqlDataAdapter da = new SqlDataAdapter(
                 @"SELECT     dbo.SiparisHareket.SiparisHareketID, dbo.SiparisHareket.SiparisID, dbo.SiparisHareket.SatirNo, dbo.SiparisHareket.StokID, dbo.Stok.StokKodu, dbo.Stok.StokAdi, 
                      dbo.SiparisHareket.Miktar, dbo.SiparisHareket.StokAnaBirimID, dbo.StokBirim.BirimAdi, dbo.SiparisHareket.AnaBirimFiyat, dbo.SiparisHareket.Kdv, 
                      dbo.SiparisHareket.Toplam, dbo.SiparisHareket.KdvToplam, dbo.SiparisHareket.Net, dbo.SiparisHareket.StokIskonto1, dbo.SiparisHareket.StokIskonto2, 
                      dbo.SiparisHareket.StokIskonto3, dbo.SiparisHareket.CariIskonto1, dbo.SiparisHareket.CariIskonto2, dbo.SiparisHareket.CariIskonto3, 
                      dbo.SiparisHareket.IndirimYuzdesi1, dbo.SiparisHareket.IndirimYuzdesi, dbo.SiparisHareket.Indirim, dbo.SiparisHareket.SatirIndirimliBirimFiyat, 
                      dbo.SiparisHareket.SatirIndirimliKDVTutar, dbo.SiparisHareket.SatirIndirimliToplam, dbo.SiparisHareket.AltIndirimBirimFiyat, dbo.SiparisHareket.AltIndirimKDVTutar, 
                      dbo.SiparisHareket.AltIndirimToplamTutar, dbo.SiparisHareket.SatirToplamIndirim, dbo.SiparisHareket.SatirToplamTutar, dbo.SiparisHareket.SatirAciklama
FROM         dbo.SiparisHareket LEFT OUTER JOIN
                      dbo.Stok ON dbo.SiparisHareket.StokID = dbo.Stok.StokID LEFT OUTER JOIN
                      dbo.StokBirim ON dbo.SiparisHareket.StokAnaBirimID = dbo.StokBirim.BirimID WHERE (SiparisID= @SiparisID)", SqlConnections.GetBaglanti());

            da.SelectCommand.Parameters.Add("@SiparisID", SqlDbType.Int).Value = gvSiparis.GetFocusedRowCellValue("SiparisID").ToString();

            DataTable dt = new DataTable();
            da.Fill(dt);
            xr_Master.DataSource = dt;
            return xr_Master;
        }
        #endregion
        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (gvSiparis.FocusedRowHandle < 0) return;
            //frmRaporDizaynListesiv2 frmRaporDizaynListesi = new frmRaporDizaynListesiv2(cs.RaporModul.Siparis, gvSiparis.GetFocusedRowCellValue("CariID").ToString(), gvSiparis.GetFocusedRowCellValue("SiparisID").ToString());
            //if (frmRaporDizaynListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //XRDesignFormEx XrDesigner = new XRDesignFormEx();

                //XrDesigner.FileName = Application.StartupPath + "\\ReportDesigners\\Siparis\\" + frmRaporDizaynListesi.RaporDizaynAdi + ".repx";
                //XrDesigner.OpenReport(RaporStokGiris());

                //XrDesigner.Show();
            }
        }

        private void btnSiparisTarihiBugun_Click(object sender, EventArgs e)
        {
            deSiparisTarihi1.EditValue = DateTime.Today;
            deSiparisTarihi2.EditValue = DateTime.Today;


        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void btnTeslimTarihiBugun_Click(object sender, EventArgs e)
        {
            deTeslimTarihiIlk.EditValue = DateTime.Today;
            deTeslimTarihiIkinci.EditValue = DateTime.Today;
        }

        private void splitContainerControl1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deTeslimTarihiIlk.EditValue = DateTime.Today;
            deTeslimTarihiIkinci.EditValue = DateTime.Today.AddDays(7);
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deTeslimTarihiIlk.EditValue = DateTime.Today;
            deTeslimTarihiIkinci.EditValue = DateTime.Today;
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}