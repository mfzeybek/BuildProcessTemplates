using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Drawing;
using System.Linq;


namespace Aresv2.Stok
{
    public partial class frmStokListesi : DevExpress.XtraEditors.XtraForm
    {

        /// <summary>
        /// false yaparsan arama ile ilgili alanları gizler
        /// \nYani heehangi bir yere stok eklemek istiyorsan true yapacaksın
        /// \nAna formdan çaığırıyorsan false yapacaksın.
        /// \n true = Arama  - - false = Liste
        /// </summary>
        /// <param name="_StokAramaYap"> </param>
        public frmStokListesi(bool _AramaiListemi)
        {
            InitializeComponent();
            AramamiListemi(_AramaiListemi);

            // burası ile formun load ı arasında ne fark var??

            // programı test ederken  yukarı yazdığını formun loadına alırsın belki
        }

        public frmStokListesi()
        {
            InitializeComponent();
        }

        void AramamiListemi(bool _StokAramaYap)
        {
            if (_StokAramaYap == true)
            {
                this.Text = "Stok Arama";
                labelControl15.Text = "STOK ARAMA";
                barButtonItem_HepsiniSec.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                this.Text = "Stok Liste";
                labelControl15.Text = "STOK LİSTE";
                btnSec.Click -= btnSec_Click; // bunu niye çıkarttık
                barButtonItem_HepsiniSec.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            ceCokluSecim.Visible = _StokAramaYap;

            ceArdArdaEkle.Visible = _StokAramaYap;
            ceBarkoddanMiktarAl.Visible = _StokAramaYap;
            ceMiktariElleGir.Visible = _StokAramaYap;
            btnSec.Visible = _StokAramaYap;
            btnSec.Enabled = _StokAramaYap;
            btnKaydiAc.Visible = !_StokAramaYap;
            barButtonItem2.Enabled = !_StokAramaYap;
        }

        public static string StokID = "", StokAdi = "";
        SqlTransaction trGenel;
        public clsTablolar.Stok.csStokArama StokArama = new clsTablolar.Stok.csStokArama();

        csFiyatTanim FiyatTanimlari = new csFiyatTanim();
        clsTablolar.Stok.csStokGrup Grubu;
        clsTablolar.Stok.csStokAraGrup AraGrubu;
        clsTablolar.Stok.csStokAltGrup AltGrubu = new clsTablolar.Stok.csStokAltGrup();

        string MiktarliBarkod; // buraya açıklama lazım

        void FiltreKriterleriniBindleHamisina()
        {
            for (int i = 0; i < xtraTabPage1.Controls.Count; i++)
            {

                this.xtraTabPage1.Controls[i].DataBindings.Clear();
            }
            for (int i = 0; i < xtraTabPage2.Controls.Count; i++)
            {

                this.xtraTabPage2.Controls[i].DataBindings.Clear();
            }
            for (int i = 0; i < xtraTabPage3.Controls.Count; i++)
            {
                this.xtraTabPage3.Controls[i].DataBindings.Clear();
            }

            txtStokKodu.DataBindings.Add("EditValue", StokArama, "StokKodu", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpGrup.Properties.DataSource = Grubu.StokGrupDoldur(SqlConnections.GetBaglanti(), trGenel);
            lkpGrup.Properties.ValueMember = "StokGrupID";
            lkpGrup.Properties.DisplayMember = "StokGrupAdi";
            txtStokAdi.DataBindings.Add("EditValue", StokArama, "StokAdi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtBarkodu.DataBindings.Add("EditValue", StokArama, "Barkod", false, DataSourceUpdateMode.OnPropertyChanged);
            checkEdit_SadeceSeciliFiyatiOlanlar.DataBindings.Add("EditValue", StokArama, "SadeceFiyatiOlanlar", false, DataSourceUpdateMode.OnPropertyChanged);
            SeciliFiyatTanimlariniAl();


            //checkedComboBoxFiyatTanimlari.DataBindings.Add("EditValue", StokArama, "StokFiyatTanimIDleri", true, DataSourceUpdateMode.OnPropertyChanged);
            //checkedComboBoxFiyatTanimlari.DataBindings.Add("Text", StokArama, "StokFiyatTanimAdlari", true, DataSourceUpdateMode.OnPropertyChanged);

            //checkedComboBoxFiyatTanimlari.

            txtAciklama.DataBindings.Add("EditValue", StokArama, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpGrup.DataBindings.Add("EditValue", StokArama, "StokGrupID", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbAktifmi.DataBindings.Add("EditValue", StokArama, "Aktif", false, DataSourceUpdateMode.OnPropertyChanged);


            cmbUrunTanitim.DataBindings.Add("SelectedIndex", StokArama, "UrunTanitimdaGoster", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpGrup.EditValueChanged += new EventHandler(lkpGrup_EditValueChanged);
            cmbEMagazaErisimi.DataBindings.Add("SelectedIndex", StokArama, "EMagazaErisimi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtGaranti.DataBindings.Add("EditValue", StokArama, "Garanti", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDesi.DataBindings.Add("EditValue", StokArama, "Desi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtKisaAciklama.DataBindings.Add("EditValue", StokArama, "KisaAciklama", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDetayliAciklama.DataBindings.Add("EditValue", StokArama, "DetayliUrunBilgisi", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpHemenAlKategori.DataBindings.Add("EditValue", StokArama, "HemenAlKategoriID", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbHemenAlKategoriGuncellenmesin.DataBindings.Add("SelectedIndex", StokArama, "HemenAlKategoriGuncellenmesin", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpHemanAlDurum.DataBindings.Add("EditValue", StokArama, "HemenAlDrum", false, DataSourceUpdateMode.OnPropertyChanged);
            txtHemenAlSira.DataBindings.Add("EditValue", StokArama, "HemenAlSira", false, DataSourceUpdateMode.OnPropertyChanged);
            txtHemenAlID.DataBindings.Add("EditValue", StokArama, "HemenAlID", false, DataSourceUpdateMode.OnPropertyChanged);

            lkpAraGrup.DataBindings.Add("EditValue", StokArama, "StokAraGrupID", false, DataSourceUpdateMode.OnPropertyChanged);

            lkpAltGrup.DataBindings.Add("EditValue", StokArama, "StokAltGrupID", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbMiktarGetir.DataBindings.Add("SelectedIndex", StokArama, "MiktariOlanlar", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBox_MinMikAltındaolanlar.DataBindings.Add("Checked", StokArama, "MinMiktarinAltindaOlanlar", false, DataSourceUpdateMode.OnPropertyChanged);
            checkEdit_OlmasiGerekenMiktardanAzOlanlar.DataBindings.Add("Checked", StokArama, "OlmasiGerekenMiktardanAzOlanlar", false, DataSourceUpdateMode.OnPropertyChanged);

            lkpStokSayimGrubu.DataBindings.Add("EditValue", StokArama, "StokSayimGrubuID", false, DataSourceUpdateMode.OnPropertyChanged);

            txtOzelKodu1.DataBindings.Add("EditValue", StokArama, "OzelKod1", false, DataSourceUpdateMode.OnPropertyChanged);
            txtOzelKodu2.DataBindings.Add("EditValue", StokArama, "OzelKod2", false, DataSourceUpdateMode.OnPropertyChanged);
            txtOzelKodu3.DataBindings.Add("EditValue", StokArama, "OzelKod3", false, DataSourceUpdateMode.OnPropertyChanged);

            cmbStokTipi.DataBindings.Add("SelectedIndex", StokArama, "StokTipi", false, DataSourceUpdateMode.OnPropertyChanged);

            txtStokAdi.Focus();
        }

        clsTablolar.csComPorttanBarkodOku barkodoku = new csComPorttanBarkodOku(); // bunula ilgili çalışmıyorsun artıkın

        string BarkodOlmaIhtimaliOlanYazi = string.Empty;


        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Grubu = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), trGenel, -1);
                AraGrubu = new clsTablolar.Stok.csStokAraGrup(SqlConnections.GetBaglanti(), trGenel, -1);
                //StokArama = new clsTablolar.Stok.csStokArama();

                FiltreKriterleriniBindleHamisina();

                //barkodoku.BarkoduOku();

                txtStokAdi.Focus();
                trGenel.Commit();
                HemenAlKategoriYukle();

                clsTablolar.HemenAl.csHemenAlUrunDurum HemenAlUrunDurumu = new clsTablolar.HemenAl.csHemenAlUrunDurum();
                lkpHemanAlDurum.Properties.DataSource = HemenAlUrunDurumu.Dt_UrunDurumlari;
                lkpHemanAlDurum.Properties.DisplayMember = "DurumAdi";
                lkpHemanAlDurum.Properties.ValueMember = "DurumKodu";



                clsTablolar.csEnumDanDtVer enumdanVerHamisina = new csEnumDanDtVer();

                lookUpEdit1.Properties.DataSource = enumdanVerHamisina.ToDataTable(typeof(clsTablolar.Stok.csStokArama.enumFotoOzellikleri));
                lookUpEdit1.Properties.DisplayMember = "name";
                lookUpEdit1.Properties.ValueMember = "value";

                lookUpEdit1.EditValue = 1;
                //lookUpEdit1.Properties.PopulateColumns();

                //lookUpEdit1.Properties.Columns[1].Visible = false;
                clsTablolar.Stok.csStokSayimGrubu SayimGrubu = new clsTablolar.Stok.csStokSayimGrubu();
                lkpStokSayimGrubu.Properties.DataSource = SayimGrubu.SayimGrubuGetir(SqlConnections.GetBaglanti(), trGenel);

                lkpStokSayimGrubu.Properties.DisplayMember = "SayimAdi";
                lkpStokSayimGrubu.Properties.ValueMember = "StokSayimGrubuID";

                //checkedListBox_FiyatTanimlari.Text = clsTablolar.Ayarlar.csAyarlar.StokListeFiyatTanimlari;

                panelControl1.Select();
                panelControl1.Focus();
                panelControl1.Select();

                xtraTabPage1.Select();
                xtraTabPage1.Focus();
                xtraTabPage1.Select();

                txtStokAdi.SelectAll();
                txtStokAdi.Focus();
                txtStokAdi.Select();
                secilenKontrol = txtStokAdi;
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
            //txtStokKodu.FindForm();
            txtStokAdi.Focus();
        }

        clsTablolar.HemenAl.csHemenAlKategori HemenAlKategori;

        void HemenAlKategoriYukle()
        {
            HemenAlKategori = new clsTablolar.HemenAl.csHemenAlKategori();
            trGenel = SqlConnections.GetBaglanti().BeginTransaction();
            HemenAlKategori.KategoriGetir(SqlConnections.GetBaglanti(), trGenel);
            trGenel.Commit();
            lkpHemenAlKategori.Properties.DataSource = HemenAlKategori.dt_Kategoriler;
            lkpHemenAlKategori.Properties.DisplayMember = "KategoriAdi";
            lkpHemenAlKategori.Properties.ValueMember = "HemanAlKategoriID";
        }

        void lkpGrup_EditValueChanged(object sender, EventArgs e)
        {
            lkpAraGrup.Properties.DataSource = AraGrubu.StokAraGrupDoldur(SqlConnections.GetBaglanti(), trGenel, csGenelKodlar.IDBossaEksiBirVer(lkpGrup.EditValue));
            lkpAraGrup.Properties.ValueMember = "StokAraGrupID";
            lkpAraGrup.Properties.DisplayMember = "StokAraGrupAdi";
        }

        private void StokAltGrupGuncelle()
        {
            lkpAltGrup.Properties.DataSource = AltGrubu.StokAltGrupDoldur(SqlConnections.GetBaglanti(), trGenel, StokArama.StokAraGrupID);
            lkpAltGrup.Properties.ValueMember = "StokAltGrupID";
            lkpAltGrup.Properties.DisplayMember = "StokAltGrupAdi";
        }
        clsTablolar.frmMiktarGir frmMiktarGirr;
        void SeciliFiyatTanimlariniAl()
        {
            checkedListBox_FiyatTanimlari.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), trGenel, false);
            checkedListBox_FiyatTanimlari.DisplayMember = "FiyatTanimAdi";
            checkedListBox_FiyatTanimlari.ValueMember = "FiyatTanimID";

            //checkedListBox_FiyatTanimlari.SetItemChecked(1, true);

            clsTablolar.Ayarlar.csAyarlar.StokListeFiyatTanimlari.Split(',');

            for (int i = 0; i < checkedListBox_FiyatTanimlari.ItemCount; i++)
            {
                if (clsTablolar.Ayarlar.csAyarlar.StokListeFiyatTanimlari.Split(',').Contains(checkedListBox_FiyatTanimlari.GetItemValue(i).ToString()))
                {
                    checkedListBox_FiyatTanimlari.SetItemChecked(i, true);
                }
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            try
            {
                StokArama.FotoOzellikleri = (clsTablolar.Stok.csStokArama.enumFotoOzellikleri)Convert.ToInt32(lookUpEdit1.EditValue);

                // buraları biraz karışık açıklama lazım
                // stok arama yalada oldukça alakalı

                StokArama.StokFiyatTanimAdlari = "";
                StokArama.StokFiyatTanimIDleri = "";


                for (int i = 0, b = 0; i < checkedListBox_FiyatTanimlari.ItemCount; i++)
                {
                    if (checkedListBox_FiyatTanimlari.GetItemChecked(i) == true)
                    {
                        if (b > 0) // virgülü koyma ile alaklı bişi sanırım
                        {
                            StokArama.StokFiyatTanimAdlari += " ," + checkedListBox_FiyatTanimlari.GetDisplayItemValue(i);
                            StokArama.StokFiyatTanimIDleri += " ," + checkedListBox_FiyatTanimlari.GetItemValue(i);
                        }
                        else
                        {
                            StokArama.StokFiyatTanimAdlari += checkedListBox_FiyatTanimlari.GetDisplayItemValue(i);
                            StokArama.StokFiyatTanimIDleri += checkedListBox_FiyatTanimlari.GetItemValue(i);
                        }
                        b++;
                    }
                }

                if (cmbN11.SelectedIndex == 1)
                {
                    StokArama.N11Entegrasyonu = 1;
                }
                else
                { StokArama.N11Entegrasyonu = -1; }

                gvStokListesi.Columns.Clear();
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                gcStokListesi.DataSource = StokArama.StokListeGetir(SqlConnections.GetBaglanti(), trGenel);
                //= StokArama.dt_StokListesi;

                trGenel.Commit();
                GridArayuzIslemleri(enGridArayuzIslemleri.Get);

                MiktarliBarkod = txtBarkodu.Text; // bunu neden buna eşitlemiştik
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnKaydiAc_Click(object sender, EventArgs e)
        {
            if (gvStokListesi.FocusedRowHandle < 0) return;
            if (this.Text == "Stok Listesi")
            {
                frmStokDetay StokKarti = new frmStokDetay(Convert.ToInt32(gvStokListesi.GetFocusedRowCellValue("StokID").ToString()));
                StokKarti.MdiParent = this.MdiParent;
                StokKarti.Show();
            }
        }

        private void barButtonItemYerlesimiKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridArayuzIslemleri(enGridArayuzIslemleri.Set);
        }

        public delegate void dlg_StokSec(int StokID, decimal Miktar);
        public dlg_StokSec Stok_Sec;
        public string GeriDonenAciklamaYazisi = "";
        private void btnSec_Click(object sender, EventArgs e)
        {
            if (gvStokListesi.RowCount == 0) return;

            decimal Miktarr = 1;
            if (ceBarkoddanMiktarAl.Checked == true)
            {
                try
                {
                    trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Miktarr = StokArama.BarkdundanMiktarVer(SqlConnections.GetBaglanti(), trGenel, MiktarliBarkod);
                    trGenel.Commit();
                }
                catch (Exception hata)
                {
                    trGenel.Rollback();
                    frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                    frmHataBildir.ShowDialog();
                }

            }
            if (ceMiktariElleGir.Checked == true && !gvStokListesi.IsMultiSelect) // eğer çoklu seçim ise aşağıda çağıracak bu satırları
            {

                frmMiktarGirr = new clsTablolar.frmMiktarGir(Miktarr, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);
                frmMiktarGirr.labelControl1.Text = gvStokListesi.GetFocusedRowCellValue("StokAdi").ToString() + "\n Eklenecek Miktarı Girin";
                frmMiktarGirr.ShowDialog();
                Miktarr = Convert.ToDecimal(frmMiktarGirr.textEdit1.EditValue);
            }


            // bunu böyle yaptık çünkü birden fazla satır seçilme işlemindede çalışsın ve s
            // ve bşrden fazla satır seçildiğinde ilk önce seçimin ilk satırını versin
            if (ceCokluSecim.CheckState == CheckState.Checked && gvStokListesi.IsMultiSelect)
            {
                for (int i = 0; i < gvStokListesi.GetSelectedRows().Length; i++)
                {
                    if (ceMiktariElleGir.Checked == true)
                    {
                        frmMiktarGirr = new clsTablolar.frmMiktarGir(Miktarr);
                        frmMiktarGirr.labelControl1.Text = gvStokListesi.GetFocusedRowCellValue("StokAdi").ToString() + "\n Eklenecek Miktarı Girin";
                        frmMiktarGirr.ShowDialog();
                        Miktarr = Convert.ToDecimal(frmMiktarGirr.textEdit1.EditValue);
                    }
                    //if ((int)btnEdit_SayimAciklama.EditValue != -1)

                    Stok_Sec((int)(gvStokListesi.GetRowCellValue(gvStokListesi.GetSelectedRows()[i], "StokID")), Miktarr);
                }
            }
            else
                Stok_Sec((int)(gvStokListesi.GetFocusedRowCellValue("StokID")), Miktarr);

            if (secilenKontrol != null)
                secilenKontrol.SelectAll();

            if (ceArdArdaEkle.Checked == false)
                Close();
        }
        TextEdit secilenKontrol; // açıklama lazım

        private void ButunTextler_Enter(object sender, EventArgs e)
        {
            secilenKontrol = (TextEdit)sender;
        }
        private void frmStokListesi_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (gcStokListesi.Focused == true)
                    {
                        if (btnSec.Visible == false)
                            btnKaydiAc_Click(null, null);
                        else
                            btnSec_Click(null, null);
                        return;
                    }
                    else
                    {
                        btnFiltrele_Click(null, null);
                    }

                    if (gvStokListesi.RowCount == 1) // bir adet satır varsa
                        if (btnSec.Visible == false)
                            btnKaydiAc_Click(null, null);
                        else
                            btnSec_Click(null, null);
                    break;
                case Keys.F10:
                    if (ceBarkoddanMiktarAl.Checked == true)
                        ceBarkoddanMiktarAl.CheckState = CheckState.Unchecked;
                    else
                        ceBarkoddanMiktarAl.Checked = true;
                    break;
                case Keys.F2:
                    btnFiltrele_Click(null, null);
                    break;
                case Keys.F3:
                    //btnTemizle_Click(null, null);
                    break;
                case Keys.F8:
                    if (ceMiktariElleGir.Checked == true)
                        ceMiktariElleGir.Checked = false;
                    else
                        ceMiktariElleGir.Checked = true;
                    break;
                case Keys.F9:
                    if (ceArdArdaEkle.Checked == true)
                        ceArdArdaEkle.Checked = false;
                    else
                        ceArdArdaEkle.Checked = true;
                    break;
                case Keys.Escape:
                    Close();
                    break;

                default:
                    break;
            }

            if (e.Control && e.KeyCode == Keys.D1)
            {
                if (gvStokListesi.IsFocusedView)
                    secilenKontrol.Focus();
                else
                    gvStokListesi.Focus();
            }
            if (e.Control && e.KeyCode == Keys.B)
            {
                txtBarkodu.Focus();
                txtBarkodu.SelectAll();
            }

        }
        private void frmStokListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (gvStokListesi.RowCount > 0)
                {

                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
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

        private void ceBarkoddanMiktarAl_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void barBtnExceleAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExceleAktar frm = new frmExceleAktar(gcStokListesi);
            frm.ShowDialog();
        }

        private void gvStokListesi_DoubleClick(object sender, EventArgs e)
        {
            if (btnSec.Visible == true)
                btnSec_Click(null, null);
            else
                btnKaydiAc_Click(null, null);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            //// genel

            //txtStokKodu.EditValue = "";
            //txtStokAdi.EditValue = "";
            //txtAciklama.EditValue = "";
            //txtBarkodu.EditValue = "";
            //lkpGrup.EditValue = -1;
            //lkpAraGrup.EditValue = -1;
            //lkpAltGrup.EditValue = -1;
            //cmbAktifmi.EditValue = -1;
            //txtOzelKodu1.EditValue = "";
            //txtOzelKodu2.EditValue = "";
            //txtOzelKodu3.EditValue = "";
            //checkedComboBoxFiyatTanimlari.EditValue = "";
            //txtRafYeriAciklama.EditValue = "";
            //cmbUrunTanitim.EditValue = -1;


            ////HemenAl

            //cmbEMagazaErisimi.EditValue = -1;
            //txtGaranti.EditValue = "";
            //txtDesi.EditValue = "";
            //txtKisaAciklama.EditValue = "";
            //txtDetayliAciklama.EditValue = "";
            //lkpHemenAlKategori.EditValue = -1;
            //cmbHemenAlKategoriGuncellenmesin.EditValue = -1;

            StokArama = new clsTablolar.Stok.csStokArama();

            FiltreKriterleriniBindleHamisina();


        }

        #region Yazdırma İşlemleri

        private void barbtnYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void barBtnOnizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void barBtnListedenYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //using (frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(Yazdirma.csYazdirmaIslemiIcinDatasetVer.YazdirmaVerileri(StokArama.dt_StokListesi), csRaporDizayn.RaporModul.Stok))
            //{
            //  frm.ShowDialog();
            //}
        }


        #endregion

        private void btnXmlOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                /* BURAYA DATATABLE AÇ
                 * SELECT DISTINCT 
                              s.StokID, s.Aktif, s.StokKodu, s.StokAdi, s.OzelKod1, s.OzelKod2, s.OzelKod3, s.StokGrupID, s.StokAraGrupID, s.StokAltGrupID, s.Aciklama, s.KaydedenID, 
                              s.KayitTarihi, s.DegistirenID, s.DegismeTarihi, s.StokBirimID, s.iskOrani1, s.iskOrani2, s.iskOrani3, s.MinumumMiktar, s.MaksimumMiktar, s.EtiketAdi, s.AlisKdv, 
                              s.SatisKdv, s.Barkod, sb.BirimAdi, s.RafYeriAciklama, s.UrunTanitimdaGoster, s.Garanti, s.StokMarkaID, dbo.StokMarka.StokMarka, ISNULL(dbo.StokFiyat.Fiyat, 0) 
                              AS Expr1
        FROM         dbo.StokFiyat RIGHT OUTER JOIN
                              dbo.Stok AS s ON dbo.StokFiyat.StokID = s.StokID LEFT OUTER JOIN
                              dbo.StokMarka ON s.StokMarkaID = dbo.StokMarka.StokMarkaID LEFT OUTER JOIN
                              dbo.StokBirim AS sb ON s.StokBirimID = sb.BirimID LEFT OUTER JOIN
                              dbo.StokBirimCevrim AS stkbrm ON stkbrm.StokID = s.StokID
        WHERE     (s.Silindi = 'false') AND (dbo.StokFiyat.FiyatTanimID = 2) AND (dbo.StokFiyat.StokID IN (268, 269))
                 * 
                 * BU SQL İLE FOR ÇEVİR
                 */
                sb.Append(@"<?xml version='1.0' encoding='utf-8'?> <Urunler>");

                for (int i = 0; i < gvStokListesi.DataRowCount; i++)
                {
                    sb.Append(@"	<Urun>
<Urun0></Urun0>
<Urun1>" + gvStokListesi.GetFocusedRowCellValue("StokMarka") + @"</Urun1>
<Urun2>" + gvStokListesi.GetFocusedRowCellValue("StokKodu") + @"</Urun2>
<Urun3>" + gvStokListesi.GetFocusedRowCellValue("StokAdi") + @"</Urun3>
<Urun4>" + gvStokListesi.GetFocusedRowCellValue("Aciklama") + @"</Urun4>
<Urun5>" + gvStokListesi.GetFocusedRowCellValue("Garanti") + @"</Urun5>
<Urun6>" + gvStokListesi.GetFocusedRowCellValue("Fiyat") + @"</Urun6>
<Urun7>" + gvStokListesi.GetFocusedRowCellValue("Fiyat") + @"</Urun7>
<Urun8>" + gvStokListesi.GetFocusedRowCellValue("DovizTur") + @"</Urun8>
<Urun9>" + gvStokListesi.GetFocusedRowCellValue("SatisKdv") + @"</Urun9>
<Urun10>0</Urun10>
<Urun11>155</Urun11>
<Urun12></Urun12>
<Urun13>496</Urun13>
<Urun14>0</Urun14>
<Urun15>0</Urun15>
<Urun16>0</Urun16>
<UrunCari>CC12</UrunCari>
</Urun>");
                }
                sb.Append(@"</Urunler>");
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        public static System.ServiceModel.Channels.Binding CreateDefaultBinding()
        {
            System.ServiceModel.Channels.CustomBinding binding = new System.ServiceModel.Channels.CustomBinding();
            binding.Elements.Add(new System.ServiceModel.Channels.TextMessageEncodingBindingElement(System.ServiceModel.Channels.MessageVersion.Soap11, System.Text.Encoding.UTF8));
            System.ServiceModel.Channels.HttpTransportBindingElement http = new System.ServiceModel.Channels.HttpTransportBindingElement();
            http.MaxBufferPoolSize = Int32.MaxValue;
            http.MaxBufferSize = Int32.MaxValue;
            http.MaxReceivedMessageSize = Int32.MaxValue;
            http.TransferMode = System.ServiceModel.TransferMode.Buffered;
            binding.Elements.Add(http);
            return binding;
        }

        private void btnHemenAlUrunleriGetir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////HemenAlServis.hemenalserviceSoapClient a = new HemenAlServis.hemenalserviceSoapClient();

            //CustomBinding binding = (CustomBinding)CreateDefaultBinding();
            //HemenAlServis.hemenalserviceSoapClient HemenAl = new HemenAlServis.hemenalserviceSoapClient
            //  (binding, new EndpointAddress("http://test.hemenal.com/service/hemenal.asmx"));

            //if (HemenAl.Auth("Test*+/314", "test", "123456").ToString() != "True")
            //{
            //  XtraMessageBox.Show("Servise Bağlanamadı.");
            //  return;
            //}

            //XmlDocument GelenTumveri = new XmlDocument();
            //GelenTumveri.LoadXml(HemenAl.GetUrun().ToString());
            //XmlReader xmlReader = new XmlNodeReader(GelenTumveri);
            //DataSet dsGelen = new DataSet();
            //DataTable dtGelen = new DataTable();
            //dsGelen.ReadXml(xmlReader);
            //dtGelen = dsGelen.Tables[0];
        }

        private void lkpGrup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lkpGrup.EditValue = -1;
            }
        }

        private void lkpAraGrup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lkpAraGrup.EditValue = -1;
            }
        }

        private void lkpAltGrup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lkpAraGrup.EditValue = -1;
            }
        }

        private void cmbUrunTanitim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                cmbUrunTanitim.SelectedIndex = 0;
            }
        }

        private void lkpHemenAlKategori_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lkpHemenAlKategori.EditValue = -1;
            }
        }

        private void lkpHemanAlDurum_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lkpHemanAlDurum.EditValue = "";
            }
        }

        private void checkButton_fotoGoster_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (gvStokListesi.RowCount == 0) { return; }

                if (checkButton_fotoGoster.Checked == true)
                {
                    pictureEdit1.Visible = true;
                    pictureEdit1.EditValue = StokArama.StokIDverVarsayilanFotoAl(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(gvStokListesi.GetFocusedRowCellValue("StokID")));
                }
                else
                {
                    pictureEdit1.Visible = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void gvStokListesi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            checkButton_fotoGoster_CheckedChanged(null, null);
        }



        #region Fotoyu Hareket Ettirenler

        bool Suruklenme = false;
        Point IlkKonum;

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            Suruklenme = true;
            IlkKonum = e.Location;
        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Suruklenme == true)
            {
                pictureEdit1.Left = e.X + pictureEdit1.Left - (IlkKonum.X);
                pictureEdit1.Top = e.Y + pictureEdit1.Top - (IlkKonum.Y);
            }
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            Suruklenme = false;
        }



        #endregion


        private void checkedComboBoxFiyatTanimlari_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxFiyatTanimlari_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTopluStokGuncelleme frm = new frmTopluStokGuncelleme(this);
            frm.ShowDialog();
        }

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ceCokluSecim_CheckedChanged(object sender, EventArgs e)
        {
            if (ceCokluSecim.CheckState == CheckState.Checked)
            {
                gvStokListesi.OptionsSelection.MultiSelect = true;
                gvStokListesi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                barButtonItem_HepsiniSec.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                gvStokListesi.OptionsSelection.MultiSelect = false;
                barButtonItem_HepsiniSec.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //gvStokListesi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            }
        }

        private void btnbtnStokHareketleriHareketleri_Click(object sender, EventArgs e)
        {
            frmStokHrListesi frm = new frmStokHrListesi();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            frm.txtStokKodu.EditValue = gvStokListesi.GetFocusedRowCellValue("StokKodu").ToString();
            frm.btnFiltrele_Click(null, null);
        }

        private void barButtonItem_HepsiniSec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvStokListesi.SelectRange(0, gvStokListesi.RowCount - 1);
        }

        private void lkpStokSayimGrubu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lkpStokSayimGrubu.EditValue = -1;
            }
        }

        private void gvStokListesi_RowCountChanged(object sender, EventArgs e)
        {
            lblListelenenSayisi.Text = gvStokListesi.RowCount.ToString();
        }

        private void gvStokListesi_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            lblSecilenStokSayisi.Text = gvStokListesi.SelectedRowsCount.ToString();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbStokTipi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                cmbStokTipi.EditValue = -1;
            }
        }


        /// <summary>
        /// harf basildigi anda boşaltılır
        /// 13 karakteri geçerken baştan itibaren boşaltılır
        /// 
        /// </summary>
        string ArkaPlandaBasilanNumaralar;


        private void frmStokListesi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar))
            //{
            //    if (KontrolNumarasiTutuyorMU(e.KeyChar.ToString()))
            //    {
            //        for (int i = 0; i < BarkodOlmaIhtimaliOlanYazi.Length; i++)
            //        {
            //            SendKeys.Send("{BS}");
            //        }
            //        txtBarkodu.Text = BarkodOlmaIhtimaliOlanYazi;
            //        BarkodOlmaIhtimaliOlanYazi = string.Empty;
            //    }
            //}
            //else
            //{
            //    BarkodOlmaIhtimaliOlanYazi = string.Empty;
            //}


            if (char.IsDigit(e.KeyChar) && false)
            {
                BarkodOlmaIhtimaliOlanYazi += e.KeyChar.ToString();
                if (BarkodOlmaIhtimaliOlanYazi.Length > 13)
                {
                    BarkodOlmaIhtimaliOlanYazi = BarkodOlmaIhtimaliOlanYazi.Substring(1, BarkodOlmaIhtimaliOlanYazi.Length - 1);
                }

                if ((BarkodOlmaIhtimaliOlanYazi.Length == 13 || BarkodOlmaIhtimaliOlanYazi.Length == 8) && KontrolNumarasiTutuyorMU(BarkodOlmaIhtimaliOlanYazi))
                {
                    MessageBox.Show("");
                    BarkodOlmaIhtimaliOlanYazi = string.Empty;
                }
            }
            else
            {
                BarkodOlmaIhtimaliOlanYazi = string.Empty;
            }
        }

        private void buttonEdit1_Properties_Click(object sender, EventArgs e)
        {

        }

        private void cmbStokTipi_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void btnEdit_SayimAciklama_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                using (Stok.frmStokSayim SayimHamisina = new Stok.frmStokSayim(Stok.frmStokSayim.NasilAcsin.Arama))
                    if (SayimHamisina.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        clsTablolar.Sayim.csSayim SayimBir = new clsTablolar.Sayim.csSayim(SqlConnections.GetBaglanti(), trGenel, SayimHamisina.SecilenSayimID);
                        btnEdit_SayimAciklama.Text = SayimBir.Aciklama;
                        btnEdit_SayimAciklama.EditValue = SayimBir.SayimID;
                        MessageBox.Show(btnEdit_SayimAciklama.EditValue.ToString());
                        StokArama.SayimID = SayimBir.SayimID;
                    }
            }
            else
            {
                StokArama.SayimID = -1;
                btnEdit_SayimAciklama.Text = string.Empty;
            }
        }

        private void checkBox_MinMikAltındaolanlar_CheckedChanged(object sender, EventArgs e)
        {

        }



        bool KontrolNumarasiTutuyorMU(string BarkodNumarasiOlmaIhtimaliOlanNumara) //şimdilik sadece ean 13 ve ean 8 de kontrol etsin hatta her ihtimale karşı bu kontrolü kapatmada olsun
        {
            string numara = BarkodNumarasiOlmaIhtimaliOlanNumara.Substring(0, BarkodNumarasiOlmaIhtimaliOlanNumara.Length - 1);

            int Tekler = 0;
            int Ciftler = 0;
            int KontrolNu = 0;
            for (int i = 1; i <= numara.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Ciftler += Convert.ToInt32(numara[numara.Length - i].ToString());
                }
                else
                {
                    Tekler += Convert.ToInt32(numara[numara.Length - i].ToString());
                }
            }
            KontrolNu = 10 - (((Tekler * 3) + Ciftler) % 10);
            if (KontrolNu == 10)
                KontrolNu = 0;

            if (KontrolNu.ToString() == BarkodNumarasiOlmaIhtimaliOlanNumara.Substring(BarkodNumarasiOlmaIhtimaliOlanNumara.Length - 1, 1))
                return true;
            else
                return false;
        }

    }
}