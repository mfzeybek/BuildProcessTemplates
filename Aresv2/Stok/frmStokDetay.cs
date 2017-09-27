using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraEditors;
using System.IO;
using System.Data;
using DevExpress.XtraGrid;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Aresv2.Stok
{ // la oğlum böüle olmaz
    public partial class frmStokDetay : DevExpress.XtraEditors.XtraForm
    {
        public frmStokDetay(int StokID)
        {
            InitializeComponent();
            _StokID = StokID;
        }
        public frmStokDetay(int StokID, Int16 FocuslanacakXtraTab)
        {
            _FocuslanacakXtraTab = FocuslanacakXtraTab;
            InitializeComponent();
            _StokID = StokID;
        }

        Int16 _FocuslanacakXtraTab = 0; // Hızlı Stok kartı güncellemesi yapmak istendiğinde xtraTabControl1 in hangi tab ı açılacak onu belirtiyor

        int _StokID = -1;

        SqlTransaction trGenel;
        #region GridUzerindekiler
        //DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkpAlisFiyatTanimlari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
        #endregion

        #region clsTablolardan Gelenler
        clsTablolar.Stok.csStokBirimTanimlari BirimTanimlari = new clsTablolar.Stok.csStokBirimTanimlari(); // Eğer bir gride bağlıyorsam burada türettim. Çünkü bunları önce veya sonra türetmenin bir farkı yok
        clsTablolar.Stok.csStokunBirimleri BirimCevirme;
        public clsTablolar.Stok.csStok Stok; // bunun gibi alanları olanları da load da veya sonradan türettim.
        clsTablolar.Stok.csStokGrup Grup;
        clsTablolar.Stok.csStokAraGrup AraGrup;
        clsTablolar.Stok.csStokAltGrup AltGrup = new clsTablolar.Stok.csStokAltGrup();
        csFiyatTanim FiyatTanimlari = new csFiyatTanim();
        clsTablolar.Stok.csStokFiyat StokFiyati = new clsTablolar.Stok.csStokFiyat();
        csStokResim StokResim;

        clsTablolar.Stok.csIlgiliStok IlgiliStoklar;

        clsTablolar.HemenAl.csHemenAlKategori HemenAlKategori = new clsTablolar.HemenAl.csHemenAlKategori();
        clsTablolar.HemenAl.HemenAlUrunSecenek HemenAlUrunSecenekleri;
        clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanım_Stok Ontanim_Stok;

        clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanım_Stok HemenAlUrunSecenekOnTanim_Stok = new clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanım_Stok();

        clsTablolar.Stok.csStokSayimGrubu SayimGrubu = new clsTablolar.Stok.csStokSayimGrubu();

        clsTablolar.Stok.csStokOzellikleri StokOzellikleri;
        #endregion

        /// <summary>
        /// TRUE veya FALSE
        /// True ise Kaydet butonu enable
        /// </summary>
        private void frmStokDetay_Load(object sender, EventArgs e)
        {

            try
            {
                ButunVerileriYukle();

                GridArayuzIslemleri(enGridArayuzIslemleri.Get);
                //lkpGrup.EditValueChanged += new EventHandler(lkpGrup_EditValueChanged);
                lkpAraGrup.EditValueChanged += new EventHandler(lkpAraGrup_EditValueChanged);
                StokResim.dt_StokResimleri.RowChanged += new DataRowChangeEventHandler(dt_StokResimleri_RowChanged);
                ButonlariAktifPasifYap(false);


                txtStokTanim.Focus();
                txtStokTanim.Select();

                if (Aresv2.Properties.Settings.Default.GelistiriciModu == false)
                {
                    xtraTabPage7.PageVisible = false;
                    xtraTabPage9.PageVisible = false;

                }

            }
            catch (Exception hata)
            {
                try
                { trGenel.Rollback(); }
                catch (Exception) { }

                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        clsTablolar.HemenAl.csEticaretDurumTanimlari EticaretDurumTanimlari = new clsTablolar.HemenAl.csEticaretDurumTanimlari();

        clsTablolar.Stok.csStokGrupV2 YeniGruplama;

        private void ButunVerileriYukle()
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();

                Stok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, _StokID);

                AraGrup = new clsTablolar.Stok.csStokAraGrup(SqlConnections.GetBaglanti(), trGenel, Stok.StokAraGrupID);
                YeniGruplama = new clsTablolar.Stok.csStokGrupV2();
                YeniGruplama.Getir(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);

                //listBoxControl1.DataSource = YeniGruplama.dt;

                ucStokGruplari1.listBoxControl1.DataSource = YeniGruplama.dt;
                ucStokGruplari1.YeniGruplama = YeniGruplama;

                ResimleriGetir();
                GrupDoldur();
                AlisSatisFiyatlariniDoldur();
                SayimGrubuDoldur();

                HemenAlKategoriDoldur();
                lkpTanimliBirim.EditValue = Stok.StokBirimID;

                #region BirimGridi
                BirimCevirme = new clsTablolar.Stok.csStokunBirimleri(SqlConnections.GetBaglanti(), trGenel, Stok.StokID, false);
                gcAltBirim.DataSource = BirimCevirme.dt;
                #endregion


                IlgiliStokLariYukle();

                HemenAlUrunSecenekleriniDoldur();
                StokOzellikleriniYukle();
                BirimTanimlariniDoldur();
                HemenAlDurumTanimlariniDoldur();
                AraGrupYukle();
                HemenAlUrunSecenekOntanimliDoldur();

                EticaretDurumTanimlari.Getir(SqlConnections.GetBaglanti(), trGenel);
                lkpStokVarsaStokDurumu.Properties.DataSource = EticaretDurumTanimlari.dt;
                lkpStokVarsaStokDurumu.Properties.ValueMember = "ID";
                lkpStokVarsaStokDurumu.Properties.DisplayMember = "Aciklama";

                lkpStokYoksaStokDurumu.Properties.DataSource = EticaretDurumTanimlari.dt;
                lkpStokYoksaStokDurumu.Properties.ValueMember = "ID";
                lkpStokYoksaStokDurumu.Properties.DisplayMember = "Aciklama";


                lkpAraGrup_EditValueChanged(null, null);

                StokAlanlariniBindle();


                //stok ilk açıldığında tablar arasında geçerken kontrollerin editvaluechanged olayı tetikleniyor
                // ve değişiklik yapmamana rağman kaydet butonu aktif oluyor
                // bunu yaparak bütün controlllere verileri yüklemiş oluyorsun böylece editvaluechanged olayı değişiklik yapana kadar tetiklenmiyor;
                for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                }
                xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[_FocuslanacakXtraTab];

                ButonlariAktifPasifYap(false);

                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }

        }


        private void AlisSatisFiyatlariniDoldur()
        {
            try
            {
                #region Alis Fiyatları  -   Satış Fiytları
                repositoryItemLookUpEdit_AlisFiyatTanim.DataSource = FiyatTanimlari.AlisTanimlariniGetir(SqlConnections.GetBaglanti(), trGenel);
                repositoryItemLookUpEdit_AlisFiyatTanim.DisplayMember = "FiyatTanimAdi";
                repositoryItemLookUpEdit_AlisFiyatTanim.ValueMember = "FiyatTanimID";

                repositoryItemLookUpEdit_SatisFiyatTanim.DataSource = FiyatTanimlari.SatisTanimlariniGetir(SqlConnections.GetBaglanti(), trGenel);
                repositoryItemLookUpEdit_SatisFiyatTanim.DisplayMember = "FiyatTanimAdi";
                repositoryItemLookUpEdit_SatisFiyatTanim.ValueMember = "FiyatTanimID";

                gcAlisFiyatlari.DataSource = StokFiyati.AlisFiyatiGetir(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);

                gcSatisFiyatlari.DataSource = StokFiyati.SatisFiyatiGetir(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
                #endregion
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void ResimleriGetir()
        {
            try
            {
                StokResim = new csStokResim(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
                peVarsayilanStokResim.EditValue = StokResim.VarsayilanFoto;
                gcResim.DataSource = StokResim.dt_StokResimleri;
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        public void SayimGrubuDoldur()
        {

            lkpSayimGrubu.Properties.DataSource = SayimGrubu.SayimGrubuGetir(SqlConnections.GetBaglanti(), trGenel);
            lkpSayimGrubu.Properties.DisplayMember = "SayimAdi";
            lkpSayimGrubu.Properties.ValueMember = "StokSayimGrubuID";

        }

        private void StokAlanlariniBindle()
        {
            try
            {
                txtStokTanim.DataBindings.Clear();
                txtOzelKod1.DataBindings.Clear();
                txtOzelKod2.DataBindings.Clear();
                txtOzelKod3.DataBindings.Clear();
                txtStokKodu.DataBindings.Clear();
                txtIskonto1.DataBindings.Clear();
                txtIskonto2.DataBindings.Clear();
                txtIskonto3.DataBindings.Clear();
                txtBarkod.DataBindings.Clear();
                memoAciklama.DataBindings.Clear();
                lkpTanimliBirim.DataBindings.Clear();
                lblAnaBirim.DataBindings.Clear();
                pictureEdit1.DataBindings.Clear();
                txtKdvAlis.DataBindings.Clear();
                txtKdvSatis.DataBindings.Clear();
                lkpGrup.DataBindings.Clear();
                lkpAraGrup.DataBindings.Clear();
                lkpAltGrup.DataBindings.Clear();
                txtMinimumMiktar.DataBindings.Clear();
                txtMaksimumMiktar.DataBindings.Clear();
                ceUrunTanitimdaGoster.DataBindings.Clear();
                txtRafYeriAciklama.DataBindings.Clear();
                txtGaranti.DataBindings.Clear();
                ceEMagazaErisimi.DataBindings.Clear();
                memoKisaAciklama.DataBindings.Clear();
                webBrowser2.DataBindings.Clear();
                txtDesi.DataBindings.Clear();
                lkpHemenAlKategori.DataBindings.Clear();
                txtHemenAlID.DataBindings.Clear();
                ceKategoriGuncellenmesin.DataBindings.Clear();
                lkpHemenAlDrumu.DataBindings.Clear();
                txtHemenAlSira.DataBindings.Clear();
                lkpSayimGrubu.DataBindings.Clear();
                memoEdit_AnahtarKelime.DataBindings.Clear();
                txtOlmasiGerekenMiktar.DataBindings.Clear();
                txtEtiketAdi.DataBindings.Clear();
                hyperLinkEdit_WebLink.DataBindings.Clear();
                lkpStokVarsaStokDurumu.DataBindings.Clear();
                lkpStokYoksaStokDurumu.DataBindings.Clear();
                ceAktif.DataBindings.Clear();
                txtAgirligi.DataBindings.Clear();
                cmbStokTipi.DataBindings.Clear();


                txtStokTanim.DataBindings.Add("EditValue", Stok, "StokAdi", false, DataSourceUpdateMode.OnPropertyChanged);
                txtOzelKod1.DataBindings.Add("EditValue", Stok, "OzelKod1", false, DataSourceUpdateMode.OnPropertyChanged);
                txtOzelKod2.DataBindings.Add("EditValue", Stok, "OzelKod2", false, DataSourceUpdateMode.OnPropertyChanged);
                txtOzelKod3.DataBindings.Add("EditValue", Stok, "OzelKod3", false, DataSourceUpdateMode.OnPropertyChanged);
                txtStokKodu.DataBindings.Add("Editvalue", Stok, "StokKodu", false, DataSourceUpdateMode.OnPropertyChanged);
                txtIskonto1.DataBindings.Add("EditValue", Stok, "IskOrani1", false, DataSourceUpdateMode.OnPropertyChanged);
                txtIskonto2.DataBindings.Add("EditValue", Stok, "IskOrani2", false, DataSourceUpdateMode.OnPropertyChanged);
                txtIskonto3.DataBindings.Add("EditValue", Stok, "IskOrani3", false, DataSourceUpdateMode.OnPropertyChanged);
                txtBarkod.DataBindings.Add("EditValue", Stok, "Barkod", false, DataSourceUpdateMode.OnPropertyChanged);
                memoAciklama.DataBindings.Add("EditValue", Stok, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);

                lkpTanimliBirim.DataBindings.Add("EditValue", Stok, "StokBirimID", false, DataSourceUpdateMode.OnPropertyChanged);
                lblAnaBirim.DataBindings.Add("Text", lkpTanimliBirim, "Text", false, DataSourceUpdateMode.OnPropertyChanged);

                pictureEdit1.DataBindings.Add("EditValue", StokResim.dt_StokResimleri, "Resim");


                txtKdvAlis.DataBindings.Add("EditValue", Stok, "AlisKdv", false, DataSourceUpdateMode.OnPropertyChanged);
                txtKdvSatis.DataBindings.Add("EditValue", Stok, "SatisKdv", false, DataSourceUpdateMode.OnPropertyChanged);

                lkpGrup.DataBindings.Add("EditValue", Stok, "StokGrupID", false, DataSourceUpdateMode.OnPropertyChanged);
                lkpAraGrup.DataBindings.Add("EditValue", Stok, "StokAraGrupID", false, DataSourceUpdateMode.OnPropertyChanged);
                lkpAltGrup.DataBindings.Add("EditValue", Stok, "StokAltGrupID", false, DataSourceUpdateMode.OnPropertyChanged);

                txtMinimumMiktar.DataBindings.Add("EditValue", Stok, "MinumumMiktar", false, DataSourceUpdateMode.OnPropertyChanged);
                txtMaksimumMiktar.DataBindings.Add("EditValue", Stok, "MaksimumMiktar", false, DataSourceUpdateMode.OnPropertyChanged);

                ceUrunTanitimdaGoster.DataBindings.Add("EditValue", Stok, "UrunTanitimdaGoster", false, DataSourceUpdateMode.OnPropertyChanged);


                txtRafYeriAciklama.DataBindings.Add("EditValue", Stok, "RafYeriAciklama", false, DataSourceUpdateMode.OnPropertyChanged);

                txtGaranti.DataBindings.Add("Text", Stok, "Garanti", false, DataSourceUpdateMode.OnPropertyChanged);
                ceEMagazaErisimi.DataBindings.Add("EditValue", Stok, "EMagazaErisimi", false, DataSourceUpdateMode.OnPropertyChanged);

                memoKisaAciklama.DataBindings.Add("Text", Stok, "KisaAciklama", false, DataSourceUpdateMode.OnPropertyChanged);

                //webBrowser2.DataBindings.Add("DocumentText", Stok, "DetayliUrunBilgisi", true, DataSourceUpdateMode.OnPropertyChanged);

                webBrowser2.DocumentText = Stok.DetayliUrunBilgisi.ToString();

                txtDesi.DataBindings.Add("EditValue", Stok, "Desi", false, DataSourceUpdateMode.OnPropertyChanged);
                lkpHemenAlKategori.DataBindings.Add("EditValue", Stok, "HemenAlKategoriID", false, DataSourceUpdateMode.OnPropertyChanged);
                txtHemenAlID.DataBindings.Add("EditValue", Stok, "HemenAlID", false, DataSourceUpdateMode.OnPropertyChanged);

                ceKategoriGuncellenmesin.DataBindings.Add("EditValue", Stok, "HemenAlKategoriGuncellenmesin", false, DataSourceUpdateMode.OnPropertyChanged);

                lkpHemenAlDrumu.DataBindings.Add("EditValue", Stok, "HemenAlDrum", false, DataSourceUpdateMode.OnPropertyChanged);
                txtHemenAlSira.DataBindings.Add("EditValue", Stok, "HemenAlSira", false, DataSourceUpdateMode.OnPropertyChanged);
                lkpSayimGrubu.DataBindings.Add("EditValue", Stok, "StokSayimGrubuID", false, DataSourceUpdateMode.OnPropertyChanged);

                memoEdit_AnahtarKelime.DataBindings.Add("EditValue", Stok, "HemenAlAnahtarKelime", false, DataSourceUpdateMode.OnPropertyChanged);
                txtOlmasiGerekenMiktar.DataBindings.Add("EditValue", Stok, "OlmasiGerekenMiktar", false, DataSourceUpdateMode.OnPropertyChanged);
                txtEtiketAdi.DataBindings.Add("EditValue", Stok, "EtiketAdi", false, DataSourceUpdateMode.OnPropertyChanged);
                hyperLinkEdit_WebLink.DataBindings.Add("EditValue", Stok, "StokWebLink", false, DataSourceUpdateMode.OnPropertyChanged);

                lkpStokVarsaStokDurumu.DataBindings.Add("EditValue", Stok, "EticaretStokDurumID_StoktaVarsa");
                lkpStokYoksaStokDurumu.DataBindings.Add("EditValue", Stok, "EticaretStokDurumID_StoktaYoksa");
                ceAktif.DataBindings.Add("EditValue", Stok, "Aktif", false, DataSourceUpdateMode.OnPropertyChanged);

                txtAgirligi.DataBindings.Add("EditValue", Stok, "Agirligi", false, DataSourceUpdateMode.OnPropertyChanged);
                cmbStokTipi.DataBindings.Add("SelectedIndex", Stok, "StokTipi", false, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        #region İlgili Stok İşlemleri

        private void IlgiliStokLariYukle()
        {
            IlgiliStoklar = new clsTablolar.Stok.csIlgiliStok();
            IlgiliStoklar.IlgiliStoklariGetir(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
            gcIlgiliStok.DataSource = IlgiliStoklar.dt_IlgiliStok;
            //gcIlgiliStok2.DataSource = IlgiliStoklar.StokunEklendigiIlgiliStoklariGetir(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
        }
        private void btnIlgiliStokEkle_Click(object sender, EventArgs e)
        {
            frmStokListesi StokArama = new frmStokListesi(true);
            StokArama.Stok_Sec = IlgiliStokEkle_delegeyeAtilacak;
            StokArama.ceBarkoddanMiktarAl.Visible = false;
            StokArama.ceMiktariElleGir.Visible = false;
            StokArama.ShowDialog();
        }
        private void IlgiliStokEkle_delegeyeAtilacak(int SecilenStokID, decimal Miktar)
        {
            clsTablolar.Stok.csStok YeniIlgiliStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, SecilenStokID);

            IlgiliStoklar.dt_IlgiliStok.Rows.Add(IlgiliStoklar.dt_IlgiliStok.NewRow());
            IlgiliStoklar.dt_IlgiliStok.Rows[IlgiliStoklar.dt_IlgiliStok.Rows.Count - 1]["StokID2"] = YeniIlgiliStok.StokID;
            IlgiliStoklar.dt_IlgiliStok.Rows[IlgiliStoklar.dt_IlgiliStok.Rows.Count - 1]["StokAdi"] = YeniIlgiliStok.StokAdi;
        }

        private void btnIlgiliStokuAc_Click(object sender, EventArgs e)
        {
            frmStokDetay frm = new frmStokDetay(Convert.ToInt32(gvIlgiliStok.GetFocusedRowCellValue(colIlgiliStok1StokID2)));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnIlgiliStokSil_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(gvIlgiliStok.GetFocusedRowCellValue(colIlgiliStok1StokAdi).ToString(), "Sil", MessageBoxButtons.YesNo))
                gvIlgiliStok.DeleteSelectedRows();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmStokDetay frm = new frmStokDetay(Convert.ToInt32(gvIlgiliStok2.GetFocusedRowCellValue(colIlgiliStok2StokID1)));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        #endregion

        void GrupDoldur()
        {
            Grup = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), trGenel, 0);
            lkpGrup.Properties.DataSource = Grup.StokGrupDoldur(SqlConnections.GetBaglanti(), trGenel);
            lkpGrup.Properties.DisplayMember = "StokGrupAdi";
            lkpGrup.Properties.ValueMember = "StokGrupID";

            //treeList1.DataSource = Grup.dt;
        }

        private void AraGrupYukle()
        {
            lkpAraGrup.Properties.DataSource = AraGrup.StokAraGrupDoldur(SqlConnections.GetBaglanti(), trGenel, Stok.StokGrupID);
            lkpAraGrup.Properties.DisplayMember = "StokAraGrupAdi";
            lkpAraGrup.Properties.ValueMember = "StokAraGrupID";
        }

        void lkpAraGrup_EditValueChanged(object sender, EventArgs e)
        {
            lkpAltGrup.Properties.DataSource = AltGrup.StokAltGrupDoldur(SqlConnections.GetBaglanti(), trGenel, csGenelKodlar.IDBossaEksiBirVer(lkpAraGrup.EditValue));
            lkpAltGrup.Properties.ValueMember = "StokAltGrupID";
            lkpAltGrup.Properties.DisplayMember = "StokAltGrupAdi";
        }

        private void lkpTanimliBirim_EditValueChanged(object sender, EventArgs e)
        {
            lblTanimliBirim.Text = lkpTanimliBirim.Text;
        }

        void BirimTanimlariniDoldur()
        {
            lkpTanimliBirim.Properties.DataSource = BirimTanimlari.BirimDoldur(SqlConnections.GetBaglanti(), trGenel);
            lkpTanimliBirim.Properties.ValueMember = "BirimID";
            lkpTanimliBirim.Properties.DisplayMember = "BirimAdi";

            repositoryItemLookUpEdit1.DataSource = BirimTanimlari.BirimDoldur(SqlConnections.GetBaglanti(), trGenel);
            repositoryItemLookUpEdit1.ValueMember = "BirimID";
            repositoryItemLookUpEdit1.DisplayMember = "BirimAdi";
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                #region STOK ANA BARKODU VE BİRİM BARKODLARI BAŞKA BİR STOKTA KULLANILIYOR MU TESTİ
                #region Barkod Tablosu kontrolü
                using (SqlCommand cmd = new SqlCommand(@"select [dbo].[StokBarkoduAra](@Barkod)", SqlConnections.GetBaglanti(), trGenel))
                {
                    cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar);
                    if (!string.IsNullOrEmpty(txtBarkod.Text))
                    {
                        cmd.Parameters[0].Value = txtBarkod.Text;
                        int ID = (int)cmd.ExecuteScalar();
                        if (ID != -1)
                        {
                            if (Stok.StokID != ID) // Stok Yeni açıldığında ID olarak -1 değerini alıyor
                            {
                                XtraMessageBox.Show("Girilen Barkod başka bir Stokta kullanılıyor.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    for (int i = 0; i < gvAltBirim.RowCount; i++)
                    {
                        if (!string.IsNullOrEmpty(gvAltBirim.GetRowCellValue(i, "Barkodu").ToString()))
                        {
                            cmd.Parameters[0].Value = gvAltBirim.GetRowCellValue(i, "Barkodu");
                            int ID = (int)cmd.ExecuteScalar();
                            if (ID != -1)
                            {
                                if (Stok.StokID != ID) // Stok Yeni açıldığında ID olarak -1 değerini alıyor
                                {
                                    XtraMessageBox.Show("Girilen Barkod başka bir Stokta kullanılıyor.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return;
                                }
                            }
                        }
                    }
                }
                #endregion

                //#region StokBirimCevrim Tablosu kontrolü
                //using (SqlCommand cmd = new SqlCommand(@"select StokBirimCevirmeID From StokBirimCevrim Where Barkodu=@Barkod AND StokID<>@StokID", SqlConnections.GetBaglanti(), trGenel))
                //{
                //  cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = Stok.Barkod;
                //  cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = Stok.StokID;
                //  using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                //  {
                //    if (dr.Read())
                //      BarkodKullaniliyor = true;
                //    else
                //      BarkodKullaniliyor = false;
                //  }
                //}
                //if (BarkodKullaniliyor)
                //{
                //  XtraMessageBox.Show("Girilen Barkod başka bir Stokta kullanılıyor.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  txtBarkod.Focus();
                //  return;
                //}
                //#endregion
                #endregion
                #region Kontroller
                gvSatisFiyatlari.PostEditor();
                for (int i = 0; i < gvSatisFiyatlari.RowCount; i++)
                {
                    if (gvSatisFiyatlari.GetRowCellValue(i, "FiyatTanimID") == DBNull.Value)
                    {
                        MessageBox.Show("Fiyat girerken fiyat tanımını unutma");
                        xtraTabPage3.Select();

                        xtraTabControl1.SelectedTabPage = xtraTabPage3;
                        gvSatisFiyatlari.FocusedRowHandle = i;
                        gvSatisFiyatlari.FocusedColumn = colfiyatTanimID;
                        return;
                    }
                }

                for (int i = 0; i < gvAltBirim.RowCount; i++)
                {
                    if (gvAltBirim.GetRowCellValue(i, colBirimID) == DBNull.Value || gvAltBirim.GetRowCellValue(i, colKatSayi) == DBNull.Value)
                    {
                        MessageBox.Show("Birim girdiğinde Birim Tanımını ve Katsayıyı boş geçme");

                        //xtraTabPage3.Select();

                        //xtraTabControl1.SelectedTabPage = xtraTabPage3;
                        //gvSatisFiyatlari.FocusedRowHandle = i;
                        //gvSatisFiyatlari.FocusedColumn = colfiyatTanimID;

                        return;
                    }
                }



                #endregion
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();

                if (Stok.StokID == -1 || Stok.StokKodu == "")
                {
                    clsTablolar.csNumaraVer numver = new csNumaraVer();
                    txtStokKodu.EditValue = numver.VarsayilanNumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel, IslemTipi.StokKarti);
                }



                Stok.StokGuncelle(SqlConnections.GetBaglanti(), trGenel);
                _StokID = Stok.StokID;

                YeniGruplama.Kaydet(SqlConnections.GetBaglanti(), trGenel, _StokID);

                BirimCevirme.StokBirimCevrimGuncelle(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);




                StokFiyati.StokFiyatGuncelle(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);



                IlgiliStoklar.IlgiliStoklariGuncelle(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);

                ButonlariAktifPasifYap(false);
                StokResim.ResimleriGuncelle(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);


                HemenAlUrunSecenekleri.SecenekleriGuncelle(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);

                //this.BindingContext[gvHemenAlSecenekOnTanimli.DataSource].EndCurrentEdit();

                gvHemenAlSecenekOnTanimli.PostEditor();
                BindingContext[gcAltBirim.DataSource].EndCurrentEdit();
                //gvHemenAlSecenekOnTanimli.

                HemenAlUrunSecenekOnTanim_Stok.Guncelle(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);

                gridView1.PostEditor();
                StokOzellikleri.Guncelle(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);

                trGenel.Commit();

                ButunVerileriYukle();

                if (Stok.EMagazaErisimi == true) // BURADA HATA VAR HAMISINA
                {
                    if (DialogResult.Yes == MessageBox.Show("Değişiklik e ticarete gönderilsin mi", "E- Ticaret", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        csHemenAlGetSet csHemenAlEntrgrasyon = new csHemenAlGetSet();
                        csHemenAlEntrgrasyon.HememAl_SetUrun(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
                        csHemenAlEntrgrasyon.HemenAl_SetSecenek(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
                        string OzellikBaslik;
                        foreach (DataRow Row in StokOzellikleri.dt.AsEnumerable())
                        {
                            OzellikBaslik = StokOzellikleri.dt_OzellikTanimlari.Select("StokOzellikTanimID = " + Row["StokOzellikTanimID"].ToString())[0]["OzellikAdi"].ToString();
                            string cevap = csHemenAlEntrgrasyon.Get_Set_Fonksiyonlari.SetOzellik("Ares", Row["StokOzellikID"].ToString(), Stok.StokKodu, Stok.HemenAlKategoriID.ToString(), OzellikBaslik, Row["Deger"].ToString(), "1");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    trGenel.Rollback();
                }
                catch (Exception) { }

                MessageBox.Show("Kayıtta hata");
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            ButonlariAktifPasifYap(false);
        }

        #region TextColorChange
        private void PasifTextBackColorChange(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.TextEdit AktifText = (TextEdit)sender;
            //AktifText.BackColor = Color.White;
        }

        private void AktifTextBackColorChange(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.TextEdit AktifText = (TextEdit)sender;
            //AktifText.BackColor = Color.AntiqueWhite;
        }

        #endregion

        #region Foto_Ekle_Sil_Cikar __ vb foto işlemleri

        private void btnYeniFotoEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdDokuman.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileStream fs = new FileStream(ofdDokuman.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] resim = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    FotoEkle(resim);
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog(this);
            }
        }
        private void FotoEkle(byte[] Foto)
        {
            StokResim.dt_StokResimleri.Rows.Add(StokResim.dt_StokResimleri.NewRow());
            StokResim.dt_StokResimleri.Rows[StokResim.dt_StokResimleri.Rows.Count - 1]["Resim"] = Foto;
            StokResim.dt_StokResimleri.Rows[StokResim.dt_StokResimleri.Rows.Count - 1]["TeraziButonFotosu"] = false;

            if (StokResim.dt_StokResimleri.Rows.Count == 1) // eğer yeni ve ilk defa foto ekleniyors varsayilanını true yapıyor
                StokResim.dt_StokResimleri.Rows[0]["Varsayilan"] = true;
            else
                StokResim.dt_StokResimleri.Rows[StokResim.dt_StokResimleri.Rows.Count - 1]["Varsayilan"] = false;
        }
        private void btnFotoSil_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("1", "2", MessageBoxButtons.YesNo))
                gvResim.DeleteSelectedRows();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Kayıt silinsin mi?", "Silinecek", MessageBoxButtons.YesNo))
            {
                Stok.StokSil(SqlConnections.GetBaglanti(), trGenel);
                this.Close();
            }
        }

        private void repositoryItemCheckEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            for (int i = 0; i < gvResim.RowCount; i++)
                gvResim.SetRowCellValue(i, Varsayilan, false);
        }


        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            //System.Drawing.Graphics grafikNesnesi = null;
            //grafikNesnesi.DrawImage()


            //gvResim.SetFocusedRowCellValue("Resim", ImageToByte(ResizeImage(byteArrayToImage((byte[])gvResim.GetFocusedRowCellValue("Resim")), 10, 10)));
            decimal yudee = ((100 * pictureEdit1.Image.Height) - (100 * 70)) / pictureEdit1.Image.Height;
            YuzdeOlarakFotoKucult(yudee);
            //try
            //{
            //    using (frmBuyukFoto bfoto = new frmBuyukFoto(ImageToByte(ResizeImage(byteArrayToImage((byte[])gvResim.GetFocusedRowCellValue("Resim")), pictureEdit1.Image.Size.Width, pictureEdit1.Image.Size.Height))))
            //    {
            //        bfoto.ShowDialog();
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("aha aha");
            //}
        }

        void YuzdeOlarakFotoKucult(decimal Yuzde)
        {
            try
            {
                FotoEkle(ImageToByte2(ResizeImage(byteArrayToImage((byte[])gvResim.GetFocusedRowCellValue("Resim")), (int)(pictureEdit1.Image.Size.Width - (pictureEdit1.Image.Size.Width * Yuzde / 100)), (int)(pictureEdit1.Image.Size.Height - (pictureEdit1.Image.Size.Height * Yuzde / 100)))));
                //using (frmBuyukFoto bfoto = new frmBuyukFoto(ImageToByte(ResizeImage(byteArrayToImage((byte[])gvResim.GetFocusedRowCellValue("Resim")), pictureEdit1.Image.Size.Width - (pictureEdit1.Image.Size.Width / Yuzde), pictureEdit1.Image.Size.Height - (pictureEdit1.Image.Size.Height / Yuzde)))))
                //{
                //    bfoto.ShowDialog();
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("aha aha");
            }
        }


        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage;

            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            returnImage = Image.FromStream(ms, true);
            return returnImage;
        }

        public void GoruntuAl(int ahandaa)
        {
            Bitmap Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GFX = Graphics.FromImage(Screenshot);
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
        }


        public static byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();
                byteArray = stream.ToArray();
            }
            return byteArray;
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void gvResim_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (pictureEdit1.Image == null)
                return;
            try
            {
                lblFotoBilgileri.Text = BytesToString(((byte[])(gvResim.GetFocusedRowCellValue("Resim"))).LongLength);
                lblFotoBilgileri.Text += "\n" + pictureEdit1.Image.Size.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void btnBuyukFoto_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmBuyukFoto bfoto = new frmBuyukFoto((byte[])gvResim.GetFocusedRowCellValue("Resim")))
                {
                    bfoto.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("aha aha");
            }
        }

        private void peVarsayilanStokResim_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                using (frmBuyukFoto bfoto = new frmBuyukFoto((byte[])peVarsayilanStokResim.EditValue))
                {
                    bfoto.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("aha aha");
            }
        }
        #endregion




        #region Buton aktif pasif olayları

        void dt_StokResimleri_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            ButonlariAktifPasifYap(true);
        }

        private void ButunControllerIcin_EditValueChanged(object sender, EventArgs e)
        {
            ButonlariAktifPasifYap(true);
        }

        private void GridlerIcinButonlarinAktifPasifOlayi(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ButonlariAktifPasifYap(true);
        }

        private void ButonlariAktifPasifYap(bool A)
        {
            btnKaydet.Enabled = A;
            btnVazgec.Enabled = A;
            btnSil.Enabled = !A;

        }
        #endregion


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
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
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

        #region Closing_Closed_Keydown
        private void frmStokDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                e.Cancel = true;
                MessageBox.Show("Kayıt tamamlanmadı !!");
            }
        }

        private void frmStokDetay_FormClosed(object sender, FormClosedEventArgs e)
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

        private void frmStokDetay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        btnKaydet_Click(null, null);
                        break;
                    case Keys.Y:
                        xtraTabPage4.Select();
                        txtRafYeriAciklama.Focus();
                        break;
                    case Keys.OemQuestion:
                        xtraTabPage10.Select();
                        //gridView1.SelectRow(1);
                        gridView1.FocusedRowHandle = -2147483647;
                        gridView1.FocusedColumn = colOzellikID;
                        gridView1.Focus();

                        break;
                }
            }
            if (e.Control && e.KeyCode == Keys.K)
            {
                //if (e.KeyData == Keys.K && )
                {
                    xtraTabControl1.SelectedTabPage = xtraTabPage4;
                    txtAgirligi.Focus();
                    txtAgirligi.SelectAll();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        #endregion

        #region HemenAl - Kategori - detayli aciklama -durumtanimlari

        private void btnDetayliAcilamaDuzenle_Click(object sender, EventArgs e)
        {
            using (frmhtmlEditor htmm = new frmhtmlEditor())
            {
                htmm.richEditControl1.HtmlText = Stok.DetayliUrunBilgisi;
                htmm.ShowDialog();
                webBrowser2.DocumentText = htmm.richEditControl1.HtmlText;
                Stok.DetayliUrunBilgisi = htmm.richEditControl1.HtmlText;
                ButonlariAktifPasifYap(true);
            }
        }

        private void HemenAlKategoriDoldur()
        {

            //if (trGenel != null)
            //{
            //  trGenel = SqlConnections.GetBaglanti().BeginTransaction();
            //}
            HemenAlKategori.KategoriGetir(SqlConnections.GetBaglanti(), trGenel);
            lkpHemenAlKategori.Properties.DataSource = HemenAlKategori.dt_Kategoriler;
            lkpHemenAlKategori.Properties.DisplayMember = "KategoriAdi";
            lkpHemenAlKategori.Properties.ValueMember = "HemanAlKategoriID";
        }

        private void HemenAlDurumTanimlariniDoldur()
        {
            clsTablolar.HemenAl.csHemenAlUrunDurum HemenAlUrunDurumlari = new clsTablolar.HemenAl.csHemenAlUrunDurum();
            lkpHemenAlDrumu.Properties.DataSource = HemenAlUrunDurumlari.Dt_UrunDurumlari;
            lkpHemenAlDrumu.Properties.DisplayMember = "DurumAdi";
            lkpHemenAlDrumu.Properties.ValueMember = "DurumKodu";
        }

        #endregion

        #region HemenAlUrunSecenek ile ilgili
        private void HemenAlUrunSecenekleriniDoldur()
        {
            HemenAlUrunSecenekleri = new clsTablolar.HemenAl.HemenAlUrunSecenek();

            HemenAlUrunSecenekleri.SecenekleriYukle(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
            gcHemenAlSecenek.DataSource = HemenAlUrunSecenekleri.dt_HemenAlUrunSecenekleri;

            repositoryItemLookUpEdit_GoruntulemeSekli.DataSource = HemenAlUrunSecenekleri.GoruntulemeSekli();
            repositoryItemLookUpEdit_GoruntulemeSekli.ValueMember = "GoruntulemeSekliKodu";
            repositoryItemLookUpEdit_GoruntulemeSekli.DisplayMember = "GoruntulemeSekliAdi";

            repositoryItemLookUpEdit_SecenekAktif.DataSource = HemenAlUrunSecenekleri.SecenekAktif();
            repositoryItemLookUpEdit_SecenekAktif.ValueMember = "SecenekAktifKodu";
            repositoryItemLookUpEdit_SecenekAktif.DisplayMember = "SecenekAktifAdi";

            repositoryItemLookUpEdit_SeciliGelsin.DataSource = HemenAlUrunSecenekleri.SeciliGelsin();
            repositoryItemLookUpEdit_SeciliGelsin.ValueMember = "SeciliGelsinKodu";
            repositoryItemLookUpEdit_SeciliGelsin.DisplayMember = "SeciliGelsinAdi";

            repositoryItemLookUpEdit_SecimZorunlu.DataSource = HemenAlUrunSecenekleri.SecimZorunlu();
            repositoryItemLookUpEdit_SecimZorunlu.ValueMember = "SecimZorunluKodu";
            repositoryItemLookUpEdit_SecimZorunlu.DisplayMember = "SecimZorunluAdi";

            repositoryItemLookUpEdit_StokKontrol.DataSource = HemenAlUrunSecenekleri.StokKontrol();
            repositoryItemLookUpEdit_StokKontrol.ValueMember = "StokKontrolKodu";
            repositoryItemLookUpEdit_StokKontrol.DisplayMember = "StokKontrolAdi";

            repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.DataSource = HemenAlUrunSecenekleri.UrunFiyatiYerineGecsin();
            repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.ValueMember = "UrunFiyatiYerineGecsinKodu";
            repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.DisplayMember = "UrunFiyatiYerineGecsinAdi";



        }




        private void HemenAlUrunSecenekOntanimliDoldur()
        {
            HemenAlUrunSecenekOnTanim_Stok.Getir(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
            gcHemenAlSecenekOnTanimli.DataSource = HemenAlUrunSecenekOnTanim_Stok.dt;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            HemenAl.HemenAlUrunSecenekOnTanimlari ontanimlar = new HemenAl.HemenAlUrunSecenekOnTanimlari(HemenAl.HemenAlUrunSecenekOnTanimlari.NasinAcsin.StokaEklemekIcin);

            ontanimlar.ShowDialog();

            if (ontanimlar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                HemenAlUrunSecenekOnTanim_Stok.dt.Rows.Add(HemenAlUrunSecenekOnTanim_Stok.dt.NewRow());
                HemenAlUrunSecenekOnTanim_Stok.dt.Rows[HemenAlUrunSecenekOnTanim_Stok.dt.Rows.Count - 1]["HemenAlUrunSecenekOnTanimID"] = ontanimlar.gridView1.GetFocusedRowCellValue("HemenAlUrunSecenekOnTanimID");
            }
        }

        private void btnSecenekSil_Click(object sender, EventArgs e)
        {
            if (gvHemenAlSecenek.RowCount == 0) return;
            if (DialogResult.Yes == MessageBox.Show(gvHemenAlSecenek.GetFocusedRowCellValue(colHemenAlSecenekSatirSecenek).ToString() + "\nSilinecek", "Siliim mi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                gvHemenAlSecenek.DeleteSelectedRows();
        }


        #endregion

        clsTablolar.Stok.csStokMiktar StokMiktari = new clsTablolar.Stok.csStokMiktar();

        private void btnMiktariGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                txtStokMiktari.EditValue = StokMiktari.StokMiktariGetir(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStokDetay KopyaStok = new frmStokDetay(-1);
            KopyaStok.MdiParent = this.MdiParent;

            KopyaStok.Show();

            KopyaStok.Stok.StokAdi = Stok.StokAdi;
            KopyaStok.Stok.StokSayimGrubuID = Stok.StokSayimGrubuID;
            KopyaStok.Stok.UrunTanitimdaGoster = Stok.UrunTanitimdaGoster;
            KopyaStok.Stok.Aciklama = Stok.Aciklama;
            KopyaStok.Stok.AlisKdv = Stok.AlisKdv;
            KopyaStok.Stok.SatisKdv = Stok.SatisKdv;

            KopyaStok.Stok.StokGrupID = Stok.StokGrupID;
            KopyaStok.Stok.StokAraGrupID = Stok.StokAraGrupID;
            KopyaStok.Stok.StokAltGrupID = Stok.StokAltGrupID;

            KopyaStok.Stok.StokBirimID = Stok.StokBirimID;

            KopyaStok.Stok.HemenAlKategoriID = Stok.HemenAlKategoriID;
            KopyaStok.Stok.HemenAlKategoriGuncellenmesin = Stok.HemenAlKategoriGuncellenmesin;
            KopyaStok.Stok.EMagazaErisimi = Stok.EMagazaErisimi;
            KopyaStok.Stok.KisaAciklama = Stok.KisaAciklama;
            KopyaStok.Stok.DetayliUrunBilgisi = Stok.DetayliUrunBilgisi;

            KopyaStok.Stok.HemenAlDrum = Stok.HemenAlDrum;
            KopyaStok.Stok.HemenAlAnahtarKelime = Stok.HemenAlAnahtarKelime;


            KopyaStok.txtStokTanim.Text = Stok.StokAdi;

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            csHemenAlGetSet hemenAlma = new csHemenAlGetSet();
            hemenAlma.Get_Set_Fonksiyonlari.SetUrun("Ares", "", Stok.StokKodu, Stok.StokKodu, "", "", "", "", "", gvResim.GetFocusedRowCellValue("Ftp").ToString(), "", "", "", "", "", "", "", "99", "", "", "", "", "");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            HemenAl.csFtpYeGonder ftpp = new HemenAl.csFtpYeGonder();




            string dosyaAdi = ftpp.Gonder(Stok.StokAdi, (byte[])(gvResim.GetFocusedRowCellValue("Resim")));

            gvResim.SetFocusedRowCellValue("Ftp", dosyaAdi);
            gvResim.PostEditor();
            this.BindingContext[gvResim.DataSource].EndCurrentEdit();

        }

        private void StokOzellikleriniYukle()
        {
            StokOzellikleri = new clsTablolar.Stok.csStokOzellikleri(SqlConnections.GetBaglanti(), trGenel, Stok.StokID);

            gridControl1.DataSource = StokOzellikleri.dt;

            repositoryItemGridLookUpEdit_OzellikTanimlari.DataSource = StokOzellikleri.OzellikTanimlariniGetir(SqlConnections.GetBaglanti(), trGenel);

            repositoryItemGridLookUpEdit_OzellikTanimlari.DisplayMember = "OzellikAdi";
            repositoryItemGridLookUpEdit_OzellikTanimlari.ValueMember = "StokOzellikTanimID";

            repositoryItemGridLookUpEdit_OzellikTanimlari.PopulateViewColumns();

            repositoryItemGridLookUpEdit_OzellikTanimlari.View.Columns["StokOzellikTanimID"].Visible = false;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            using (cs.frmWebCam frm = new cs.frmWebCam())
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                //ImageConverter hasoo = new ImageConverter();
                {
                    FotoEkle(frm.ftotoo);
                    MessageBox.Show(BytesToString(frm.ftotoo.LongLength));
                }
            }
        }

        static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        private void barButtonItem_Hareketleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStokHrListesi frmHareket = new frmStokHrListesi();
            frmHareket.MdiParent = this.MdiParent;
            frmHareket.Show();
            frmHareket.txtStokKodu.EditValue = Stok.StokKodu;
            frmHareket.btnFiltrele_Click(null, null);
        }

        private void labelControl60_Click(object sender, EventArgs e)
        {

        }

        private void BaziControllerIcin_EditValueChanged(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            ButonlariAktifPasifYap(true);
        }

        private void btnFiyatSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(gvSatisFiyatlari.GetFocusedRowCellDisplayText(colfiyatTanimID), "Silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                gvSatisFiyatlari.DeleteSelectedRows();
        }

        private void btnBirimSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(gvAltBirim.GetFocusedRowCellDisplayText(colBirimID), "Silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                gvAltBirim.DeleteSelectedRows();
        }

        private void btnBarkodNuOlustur_Click(object sender, EventArgs e)
        {
            Ayarlar.frmBarkodAyar frm = new Ayarlar.frmBarkodAyar(Ayarlar.frmBarkodAyar.NasilAcsin.StokaBarkodEklemekIcin);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {

                //BirimCevirme.dt.Rows[gvAltBirim.GetFocusedDataSourceRowIndex()]["Barkodu"] = frm.BarkodNumarasi;
                gvAltBirim.SetFocusedRowCellValue("Barkodu", frm.BarkodNumarasi);
                //gvAltBirim.SetFocusedRowCellValue("Barkodu", frm.BarkodNumarasi);

                gvAltBirim.UpdateCurrentRow();
                gvAltBirim.PostEditor();
                gvAltBirim.RefreshData();


                GridlerIcinButonlarinAktifPasifOlayi(null, null);

                //gvAltBirim.
            }
        }

        private void gridlerIcin_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {

        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FotoKEs_Click(object sender, EventArgs e)
        {
            FotoEkle(ImageToByte2(Kes((Image)pictureEdit1.Image.Clone())));
        }



        int cropX;
        int cropY;
        int cropWidth;

        int cropHeight;
        int oCropX;
        int oCropY;
        public Pen cropPen;


        // Let the user select an area.
        private bool Drawing = false;
        private Point StartPoint, EndPoint;

        public DashStyle cropDashStyle = DashStyle.DashDot;





        Image Kes(Image img)
        {

            System.Drawing.Image resim = cropImage(img, new Rectangle(0, 0, 200, 200));
            return resim;
        }



        // The original image.
        private Bitmap OriginalImage;

        // The currently cropped image.
        private Bitmap CroppedImage;

        // The cropped image with the selection rectangle.
        private Bitmap DisplayImage;
        private Graphics DisplayGraphics;





        private void btnAsagidanKes_Click(object sender, EventArgs e)
        {
            System.Drawing.Image resim = cropImage(pictureEdit1.Image, new Rectangle(0, 0, pictureEdit1.Image.Width, FotografinYuzdeBesiniVer(pictureEdit1.Image.Height)));
            StokResim.dt_StokResimleri.Rows[gvResim.GetFocusedDataSourceRowIndex()]["Resim"] = ImageToByte2(resim);
        }

        private void btnYukaridanKes_Click(object sender, EventArgs e)
        {
            System.Drawing.Image resim = cropImage(pictureEdit1.Image, new Rectangle(0, pictureEdit1.Image.Height - FotografinYuzdeBesiniVer(pictureEdit1.Image.Height), pictureEdit1.Image.Width, FotografinYuzdeBesiniVer(pictureEdit1.Image.Height)));
            StokResim.dt_StokResimleri.Rows[gvResim.GetFocusedDataSourceRowIndex()]["Resim"] = ImageToByte2(resim);
        }

        private void btnSoldanKes_Click(object sender, EventArgs e)
        {
            System.Drawing.Image resim = cropImage(pictureEdit1.Image, new Rectangle(pictureEdit1.Image.Width - FotografinYuzdeBesiniVer(pictureEdit1.Image.Width), 0, FotografinYuzdeBesiniVer(pictureEdit1.Image.Width), pictureEdit1.Image.Height));
            StokResim.dt_StokResimleri.Rows[gvResim.GetFocusedDataSourceRowIndex()]["Resim"] = ImageToByte2(resim);
        }

        private void btnSagdanKes_Click(object sender, EventArgs e)
        {
            System.Drawing.Image resim = cropImage(pictureEdit1.Image, new Rectangle(0, 0, FotografinYuzdeBesiniVer(pictureEdit1.Image.Width), pictureEdit1.Image.Height));
            StokResim.dt_StokResimleri.Rows[gvResim.GetFocusedDataSourceRowIndex()]["Resim"] = ImageToByte2(resim);
        }

        int FotografinYuzdeBesiniVer(int Sayi)
        {
            return Sayi - (Sayi * 5 / 100);
        }

        private void frmStokDetay_Shown(object sender, EventArgs e)
        {
            if (clsTablolar.Ayarlar.csYetkiler.StokKartGorme == false)
            {
                this.Close();
                return;
            }
        }



        private void gvSatisFiyatlari_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (gvSatisFiyatlari.GetRowCellValue(e.RowHandle, "KdvDahil") == DBNull.Value)
                gvSatisFiyatlari.SetRowCellValue(e.RowHandle, "KdvDahil", true);
        }

        private void xtraTabControl_Fiyat_Click(object sender, EventArgs e)
        {

        }

        private void gvAltBirim_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (string.IsNullOrEmpty(gvAltBirim.GetRowCellValue(e.RowHandle, colKatSayi).ToString()))
                gvAltBirim.SetRowCellValue(e.RowHandle, colKatSayi, 1);
        }

        private void gvSatisFiyatlari_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        private void gvSatisFiyatlari_HideCustomizationForm(object sender, EventArgs e)
        {

        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            FotoEkle(ImageToByte2(Clipboard.GetImage()));
            Clipboard.Clear();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            n11.frmN11Urun frm = new n11.frmN11Urun(Stok.StokID);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnGrupSec_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmStokGruplari frm = new frmStokGruplari(frmStokGruplari.NasilAcsin.AramaIcin))
                {
                    frm.treeList1.OptionsBehavior.Editable = false;
                    if (YeniGruplama.dt.Rows.Count != 0)
                    {
                        frm.SeciliStokGruplari = new System.Collections.Generic.List<clsTablolar.Stok.csStokGrubuField>();
                        foreach (var item in YeniGruplama.dt.AsEnumerable())
                        {
                            if (item.RowState != DataRowState.Deleted)
                                frm.SeciliStokGruplari.Add(new clsTablolar.Stok.csStokGrubuField() { StokGrupID = (int)item["StokGrupID"] });
                        }
                    }

                    if (frm.ShowDialog() == DialogResult.Yes)

                        foreach (var item in frm.SeciliStokGruplari)
                        {
                            if (YeniGruplama.dt.Rows.Find(item.StokGrupID) == null)
                            {
                                DataRow dr = YeniGruplama.dt.NewRow();

                                dr["ID"] = -1;
                                dr["StokGrupID"] = item.StokGrupID;
                                dr["StokGrupAdi"] = item.StokGrupAdi;
                                YeniGruplama.dt.Rows.Add(dr);
                                ButonlariAktifPasifYap(true);
                            }
                        }
                }
            }
            catch (Exception EX)
            {
                //throw EX;
            }

        }

        private void ucStokGruplari1_VeriDegisti(object sender, EventArgs e)
        {
            ButonlariAktifPasifYap(true);
        }

        public System.Drawing.Image cropImage(System.Drawing.Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return (System.Drawing.Image)(bmpCrop);
        }
    }
}