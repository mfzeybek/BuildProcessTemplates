using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraGrid;
using System.IO;
using System.Linq;
using System.Data;


namespace Aresv2
{
    public partial class frmCariListe : DevExpress.XtraEditors.XtraForm
    {
        public frmCariListe()
        {
            InitializeComponent();
        }

        //SqlConnections Baglanti = new SqlConnections(); // bunu türetir türetmez SqlConnections class ında falan filan işte
        SqlTransaction trGenel;
        clsTablolar.cari.csCariArama CariArama = new clsTablolar.cari.csCariArama();
        public static string CariID = string.Empty, CariTanim = string.Empty;

        clsTablolar.Yazdirma.csYazdir yazdir;

        private void frmCariListe_Load(object sender, EventArgs e)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                CariGrubuGetir();
                trGenel.Commit();


                NesneleriBinle();
                //gvCari.CustomizationForm.ControlBox = true;
                //gvCari.CustomizationForm.ContextMenuStrip.ShowCheckMargin = true;


                txtCariAdi.Select();
                txtCariAdi.Focus();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        void NesneleriBinle()
        {
            txtCariKodu.DataBindings.Add("EditValue", CariArama, "CariKod", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCariAdi.DataBindings.Add("EditValue", CariArama, "CariTanim", false, DataSourceUpdateMode.OnPropertyChanged);

            lkpGrubu.DataBindings.Add("EditValue", CariArama, "CariGrupID", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            try
            {
                CariArama.BuTariheKadarOlanBakiyeBilgisi = dateEdit1.DateTime;
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                gcCari.DataSource = CariArama.CariListesi(SqlConnections.GetBaglanti(), trGenel);

                gvCari.RestoreLayoutFromStream(cs.csGridLayout.GetLayout(1, this.Name, gvCari.Name, SqlConnections.GetBaglanti(), trGenel));


                trGenel.Commit(); // tr kapatılır.

                ToplamlariHesapla();
                //GridArayuzIslemleri(enGridArayuzIslemleri.Get);

                //gvCari.Columns["SehirID"].OptionsColumn.ShowInCustomizationForm = false;
                //gvCari.Columns["SehirID"].OptionsColumn.AllowShowHide = false;  // gösterme gizlemeyi iptal ediyor
                //gvCari.RestoreLayoutFromXml(Application.StartupPath + "\\GridLayout\\KullanıcıID_frmCariListe.xml");

            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        void ToplamlariHesapla()
        {
            try
            {

                var BakiyeToplamlari =
    from row in CariArama.dt.AsEnumerable()
    //where row.Field<string>("BakiyeTuru") == "Alacak Bakiye" // Silinen Satırları ve Birleşik Ürünlerin alt detaylarını hesaba katmıyoruz
    group row by new
    {
        //StokIskonto1 = row["StokIskonto1"],
        //StokIskonto2 = row["StokIskonto2"],
        //StokIskonto3 = row["StokIskonto3"],
        //CariIskonto1 = row["CariIskonto1"],
        //CariIskonto2 = row["CariIskonto2"],
        //CariIskonto3 = row["CariIskonto3"],
        BakiyeTuru = row["BakiyeTuru"],
        //BorcTutar = row["Borç Bakiye"]
    } into g
    select new
    {

        //StokIskonto1 = g.Key.StokIskonto1,
        //StokIskonto2 = g.Key.StokIskonto2,
        //StokIskonto3 = g.Key.StokIskonto3,
        //CariIskonto1 = g.Key.CariIskonto1,
        //CariIskonto2 = g.Key.CariIskonto2,
        //CariIskonto3 = g.Key.CariIskonto3,
        ////CariToplamIskonto
        //StokIskontoTutari = g.Sum(p => Convert.ToDecimal(p["StokToplamIskonto"].ToString())),
        //CariToplamIskonto = g.Sum(p => Convert.ToDecimal((p["CariToplamIskonto"]).ToString())),
        //ToplamIskonto = g.Sum(p => Convert.ToDecimal((p["ToplamIskonto"]).ToString())),
        //bakiyy = g.Sum(p => Convert.ToDecimal(g.Key.AlacakTutar)),
        //BakiyeToplamlari ,
        BakiyeTuru = g.Key.BakiyeTuru,
        BakiyeToplami = g.Sum(p => Convert.ToDecimal((p["BakiyeTutari"]).ToString()))
    };
                //lblVerilenCeklerinToplami.Text = categories.

                txtToplamAlacakBakiye.Text = string.Empty;
                txtToplamBorcBakiye.Text = string.Empty;

                foreach (var item in BakiyeToplamlari)
                {
                    if (item.BakiyeTuru.ToString() == "Borç Bakiye")
                        txtToplamBorcBakiye.Text = item.BakiyeToplami.ToString();
                    else if (item.BakiyeTuru.ToString() == "Alacak Bakiye")
                        txtToplamAlacakBakiye.Text = item.BakiyeToplami.ToString();
                    //txtToplamBorcBakiye.Text = item.bakiyy.ToString();
                }
            }
            catch { }



        }


        private void deDegistirmeTarihi1_Popup(object sender, EventArgs e)
        {
            //if (deDegistirmeTarihi1.DateTime == Convert.ToDateTime(deDegistirmeTarihi1.Properties.NullDate))
            //  deDegistirmeTarihi1.
        }
        private void lkpCariTip_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                lkpCariTip.EditValue = DBNull.Value;
        }
        //public delegate void Veriver(DataRow CariBilgi);
        //public Veriver _Veriver;

        public delegate void Inttipinde(int cariId);
        public Inttipinde _CariIDVer;

        private void btnKaydiAc_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCari.FocusedRowHandle < 0) return;

                if (this.Text == "Cari Kartlar Listesi")
                {
                    Cari.frmCariDetay frmCariv2 = new Cari.frmCariDetay(Convert.ToInt32(gvCari.GetFocusedRowCellValue("CariID")));
                    frmCariv2.MdiParent = this.MdiParent;
                    frmCariv2.Show();
                }
                else
                {
                    //_Veriver(gvCari.GetFocusedDataRow()); // veri ver neydi delege kullandığın zaman çok iyi açıklama yaz

                    // hepsi buraya göre olacak
                    _CariIDVer(Convert.ToInt32(gvCari.GetFocusedRowCellValue("CariID").ToString()));
                    this.Close();
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void lkpSektoru_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)  // sektörü lokup un x butonununa basılırsa  (tıklanan butonun indexi 1 ise)
                lkpGrubu.EditValue = -1;  // edit value sini -1 yap
        }
        private void gvCari_DoubleClick(object sender, EventArgs e)
        {
            btnKaydiAc_Click(null, null);
        }
        private void btnTabloyuKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                cs.csGridLayout.InsertLayout(1, this.Name, gvCari, SqlConnections.GetBaglanti(), trGenel);
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void frmCariListe_FormClosed(object sender, FormClosedEventArgs e)
        {

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

        private void btnCariHareketleri_Click(object sender, EventArgs e)
        {
            Cari.CariHr.frmCariHrListesiv3 HareketListesi = new Cari.CariHr.frmCariHrListesiv3(Cari.CariHr.frmCariHrListesiv3.NasilAcicak.Liste);
            HareketListesi.MdiParent = this.MdiParent;
            HareketListesi.Show();

            HareketListesi.txtCariKodu.Text = gvCari.GetFocusedRowCellValue("CariKod").ToString();
            HareketListesi.btnFiltrele_Click(null, null);

        }

        private void frmCariListe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnFiltrele_Click(null, null);
            }
        }

        private void btnCariHrEkle_Click(object sender, EventArgs e)
        {
            if (gvCari.RowCount == 0) return;
            Cari.CariHr.frmCariHrKarti CariHareket = new Cari.CariHr.frmCariHrKarti(-1, Convert.ToInt32(gvCari.GetFocusedRowCellValue("CariID")));
            CariHareket.MdiParent = this.MdiParent;
            CariHareket.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GridArayuzIslemleri(enGridArayuzIslemleri.Set);
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }




        #region Yazdırma İşlemleri




        private void YazdirmakicinVerileriHazirla()
        {
            if (gvCari.RowCount == 0) return;

            yazdir = new clsTablolar.Yazdirma.csYazdir();

            //yazdir.classtandsyeDtekle("Fatura Alt Bilgi");
            //yazdir.DtyaYeniSatirEkle("Fatura Alt Bilgi");



            //yazdir.ds.Tables[]

            yazdir.dt_ekle(CariArama.dt.Copy());
        }

        private void barBtnItemYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //YazdirmakicinVerileriHazirla();
            //using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            //{
            //  yazdir.Yazdirr(varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), (clsTablolar.csRaporDizayn.RaporModul)Siparis.SiparisTipi), cs.csYazdir.Nasil.Yazdir);
            //}
        }

        private void barBtnItemOnizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //YazdirmakicinVerileriHazirla();
            //using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            //{
            //  yazdir.Yazdirr(varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), (clsTablolar.csRaporDizayn.RaporModul)Siparis.SiparisTipi), cs.csYazdir.Nasil.Goster);
            //}
        }

        private void barBtnItemFormSecerekYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(yazdir, csRaporDizayn.RaporModul.CarliListe);
            frm.ShowDialog();
        }
        #endregion

        private void dropDownButtonYazdir_Click(object sender, EventArgs e)
        {

        }

        public void CariGrubuGetir()
        {
            clsTablolar.cari.csCariGrup Grup = new clsTablolar.cari.csCariGrup();

            lkpGrubu.Properties.DataSource = Grup.CariGrupListesi(SqlConnections.GetBaglanti(), trGenel);

            lkpGrubu.Properties.DisplayMember = "CariGrup";
            lkpGrubu.Properties.ValueMember = "CariGrupID";


        }
    }
}