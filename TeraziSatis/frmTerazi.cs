using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Reflection;
using System.IO;


namespace TeraziSatis
{
    public partial class frmTerazi : DevExpress.XtraEditors.XtraForm
    {
        public frmTerazi()
        {
            InitializeComponent();
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
        }

        public clsTablolar.TeraziSatisClaslari.csStokAramaIslemleri StokArama;
        public clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama BarkodtanStokArma;
        clsTablolar.cari.csCariv2 CariKart;
        clsTablolar.TeraziSatisClaslari.csStok Stok = new clsTablolar.TeraziSatisClaslari.csStok();
        SqlTransaction TrGenel;

        //clsTablolar.TeraziSatisClaslari.csSatislar Satis = new clsTablolar.TeraziSatisClaslari.csSatislar(); // Faturanın Hareketleri clstablolardan gelmesine rağman fatura tablosuna kayıt satıştan yapılıyor
        public clsTablolar.Fatura.csFaturaHareket Hareketler = new clsTablolar.Fatura.csFaturaHareket();
        public clsTablolar.csFatura_Irsaliye_Teklif_Hesapla Hesapla;

        clsTablolar.csNumaraVer NumaraVer = new clsTablolar.csNumaraVer();

        public bool KarisikUrunFormuAcik = false;

        public bool KaydedileBilirMi = true; // Birlesik Urun formunda toplu bir hesap yapılması gereken bir yer var orada her yapılan anında değilde işlem bitiminde kaydedilmesi gerekiyor



        clsTablolar.TeraziSatisClaslari.csSatislarV2 Satislarv2;

        bool MikTarAlmaDurmu = true;

        public clsTablolar.TeraziSatisClaslari.csTerazidenMiktarAl MiktarAl;

        public FormState formState = new FormState();
        public frmIkinciEkran IkinciEkran;
        bool IkinciEkranAcik = false;

        public void MesajGoster(string str)
        {

            //if (KarisikUrunFormuAcik == true)
            //    MessageBox.Show(KarisikUrunFormu, str);
            //else
            if (Application.OpenForms[Application.OpenForms.Count - 1].Name != "frmIkinciEkran")
                MessageBox.Show(Application.OpenForms[Application.OpenForms.Count - 1], str);
            else
                MessageBox.Show(Application.OpenForms[Application.OpenForms.Count - 2], str);
        }

        //public static System.Diagnostics.PerformanceCounter counterper = new System.Diagnostics.PerformanceCounter();

        void ResetExceptionState(Control control)
        {
            typeof(Control).InvokeMember("SetState", BindingFlags.NonPublic |
              BindingFlags.InvokeMethod | BindingFlags.Instance, null,
              control, new object[] { 0x400000, false });
        }
        public static string VersiyonNo = "Test - 102";
        System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
        csTeraziLogs LogLar;


        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.Name = "TeraziFormuAnaThread";

            LogLar = new csTeraziLogs();

            bool locktajen = false;
            try
            {
                Monitor.Enter(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit, ref locktajen);


                SqlConnections sqlll = new SqlConnections(); //bir kere bunu hala türetiyoruz hamısına


                #region Projenin 1 defa açılması için

                foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("TeraziSatis"))
                {
                    if (System.Diagnostics.Process.GetProcessesByName("TeraziSatis").Length > 1)
                    {
                        proc.Kill();
                    }
                }
                if (System.Diagnostics.Process.GetProcessesByName("TeraziSatisBaslat2").Length == 0)
                {
                    if (File.Exists(Application.StartupPath + @"\TeraziSatisBaslat2.exe") == true)
                        System.Diagnostics.Process.Start(Application.StartupPath + @"\TeraziSatisBaslat2.exe");
                    else
                    { MesajGoster("Terazi Satis Başlat yüklenmemiş sistem yöneticisine haber ver."); }
                }


                #endregion

                #region VerilenIDde Terazi Kartı Var mı Kontrolü



                #endregion

                formState.Maximize(this);
                if (barCheckItem_ArkaPlanaDussun.Checked == true)
                    this.TopMost = true;
                else
                    this.TopMost = false;

                CheckForIllegalCrossThreadCalls = false;
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;


                #region Birleşik Ürünün Alt Ürünlerini Göstermemesi için filtreliyoruz - birleşik ürün formunu açarken bu filtrelemeyi işlemlerde hata yapmaması için gizliyoruz


                gvSatisHareketleri.Columns["BirlesikUrunHareketID"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                DevExpress.Data.Filtering.CriteriaOperatorCollection kriter = new DevExpress.Data.Filtering.CriteriaOperatorCollection();
                gvSatisHareketleri.ActiveFilterEnabled = true;
                gvSatisHareketleri.ActiveFilterString = "[BirlesikUrunHareketID] < " + 0;
                #endregion



                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

                //GrupButonlariniLayoutaYukle();

                stokButonGrupVeStokButonlari1.AhandaBudur(SqlConnections.GetBaglanti(), TrGenel, Properties.Settings.Default.TeraziID);
                stokButonGrupVeStokButonlari1.StokButonuTikildatiginda = StokButonuTiklandiginda;

                stokButonGrupVeStokButonlari1.StokButonuSagClick = StokButonuSagCliccc;

                TrGenel.Commit();
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Hesapla = new clsTablolar.csFatura_Irsaliye_Teklif_Hesapla(Hareketler.dt_FaturaHareketleri, gvSatisHareketleri) { AltToplamlarDegisti = AltToplamHesaplamalariniAl };
                //sp1.Open();



                clsTablolar.Ayarlar.csAyarlar ayarhamisina = new clsTablolar.Ayarlar.csAyarlar(SqlConnections.GetBaglanti(), TrGenel);
                TrGenel.Commit();



                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Satislarv2 = new clsTablolar.TeraziSatisClaslari.csSatislarV2(SqlConnections.GetBaglanti(), TrGenel, Properties.Settings.Default.TeraziID);
                TrGenel.Commit();


                Satislarv2.BaglantiDurmu = TerazidenVeriTabaniIleBaglantiKurupSurekliGuncelSatislariGetirebiliyorsa;


                BirimleriGetir();
                repositoryItemLookUpEdit_AltBirim.DataSource = dtBirimler;
                repositoryItemLookUpEdit_AltBirim.DisplayMember = "BirimAdi";
                repositoryItemLookUpEdit_AltBirim.ValueMember = "BirimID";

                CariGetir(clsTablolar.Ayarlar.csAyarlar.TeraziVarsayilanCariID);


                //Satislarv2.ThreadiBaslat(SqlConnections.GetBaglantiIki(), 3000);
                gcSatislar.DataSource = Satislarv2.dt_threadSatislar;
                HareketleriGetir(-1);
                gcSatisHareketleri.DataSource = Hareketler.dt_FaturaHareketleri;
                gvSatislar_FocusedRowChanged(null, null);

                cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;

                YazdirmaIslemiIcinHazirlik();

                using (clsTablolar.TeraziSatisClaslari.csTeraziAyarlari AyarlariGetir = new clsTablolar.TeraziSatisClaslari.csTeraziAyarlari())
                {
                    //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    //FaturaBarkodIcinKullanilacakOnEk = AyarlariGetir.FaturaBarkodIcinKullanilacakOnEk_Getir(SqlConnections.GetBaglanti(), TrGenel);
                    //TrGenel.Commit();
                }


                //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki kilite bağlıydı önceki sürümde


                #region Ikinc iEkran
                if (Screen.AllScreens.Length > 1) // iki tane ekran varsa ikinci ekran açılsın
                {
                    IkinciEkran = new frmIkinciEkran(this);
                    IkinciEkran.Show();
                    IkinciEkranAcik = true;
                }
                #endregion

                BindleHamisina();

                Satislarv2.dt_threadSatislar.RowDeleted += dt_threadSatislar_RowDeleted;

                MiktarAl = new clsTablolar.TeraziSatisClaslari.csTerazidenMiktarAl();
                MiktarAl.MesajGonder = MesajGoster;
                MiktarAl.BaglantiDurmu = TeraziMiktarAliniyorsa;
                TerazidenMiktarAlmayaBasla();

                //TerazidenSabitMiktariAl(MiktarAl.OkunanSabitMiktar);
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Program Düzgün Bi şekilde Açıldı");
            }
            catch (SqlException hata2)
            {
                MesajGoster("Bağlantı hatası ana bilgisayar ile bağlantı kurulamnıyor");
                btnCikis_Click(null, null);
            }
            catch (Exception hata)
            {
                MesajGoster("hata mk \n" + hata.StackTrace);
                btnCikis_Click(null, null);
            }
            finally
            {
                if (locktajen)
                    Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
                else
                {
                    MesajGoster("vay mk");
                }
            }
        }

        void TerazidenVeriTabaniIleBaglantiKurupSurekliGuncelSatislariGetirebiliyorsa(clsTablolar.TeraziSatisClaslari.csSatislarV2.VeriTabaniBaglantiDurumu durum)
        {
            labelControl8.Appearance.Image.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
            labelControl8.Refresh();
        }

        static void w_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Exception exxx = new Exception();
        }
        static void w_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //todo
            }
            Exception exxx = new Exception();
        }

        public void SiparisiSatisaAktarma(int SiparisID)
        {
            clsTablolar.EvrakIliski.csEvrakIliski evrakIliski = new clsTablolar.EvrakIliski.csEvrakIliski();

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            if (evrakIliski.SiparisFaturayaAktarilmisMi(SqlConnections.GetBaglanti(), TrGenel, SiparisID) == clsTablolar.EvrakIliski.csEvrakIliski.SiparisinFaturayaAktarilmaDurumu.Faturalandi)
            {
                TrGenel.Commit();
                MesajGoster("Daha Önce Satışa Aktarılmış");
                return;
            }
            else
                TrGenel.Commit();

            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
            {
                using (clsTablolar.Siparis.csSiparis Siparis = new clsTablolar.Siparis.csSiparis(SqlConnections.GetBaglanti(), TrGenel, SiparisID))
                {

                    //CariGetir(Siparis.CariID);
                    Satislarv2.YeniKayitAc(CariKart);

                    gvSatislar.MoveLast();
                    gvSatislar.FocusedRowHandle = gvSatislar.RowCount - 1;

                    int SonIndexNo = Satislarv2.dt_threadSatislar.Rows.Count - 1;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["CariID"] = Siparis.CariID;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["CariKod"] = Siparis.CariKod;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["CariTanim"] = Siparis.CariTanim;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["VergiDairesi"] = Siparis.VergiDairesi;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["VergiNo"] = Siparis.VergiNo;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["Adres"] = Siparis.Adres;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["Il"] = Siparis.Il;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["Ilce"] = Siparis.Ilce;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["Aciklama"] = Siparis.Aciklama;


                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["Aciklama"] = Siparis.Aciklama;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["SatisElemaniID"] = Siparis.SatisElemaniID;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["Toplam_Iskontosuz_Kdvsiz"] = Siparis.Toplam_Iskontosuz_Kdvsiz;

                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["CariIskontoToplami"] = Siparis.CariIskontoToplami;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["StokIskontoToplami"] = Siparis.StokIskontoToplami;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["ToplamIndirim"] = Siparis.ToplamIndirim;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["ToplamKdv"] = Siparis.ToplamKdv;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["IskontoluToplam"] = Siparis.IskontoluToplam;
                    Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["FaturaTutari"] = Siparis.SiparisTutari;

                    clsTablolar.Siparis.csSiparisHareket SiparisHareketi = new clsTablolar.Siparis.csSiparisHareket(SqlConnections.GetBaglanti(), TrGenel, SiparisID);
                    for (int i = 0; i < SiparisHareketi.dt_SiparisHareketleri.Rows.Count; i++)
                    {
                        if (StokEkle((int)SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokID"]))
                        {
                            int HareketSonIndexNo = Hareketler.dt_FaturaHareketleri.Rows.Count - 1;
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["FaturaHareketStokAdi"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["SiparisHareketStokAdi"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Miktar"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Miktar"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokAnaBirimID"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokAnaBirimID"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["AnaBirimFiyat"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["AnaBirimFiyat"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Birim2ID"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Birim2ID"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["KatSayi"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["KatSayi"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Birim2Fiyat"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Birim2Fiyat"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Kdv"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Kdv"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Toplam"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Toplam"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokIskonto1"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokIskonto1"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokIskonto2"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokIskonto2"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokIskonto3"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokIskonto3"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["CariIskonto1"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["CariIskonto1"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["CariIskonto2"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["CariIskonto2"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["CariIskonto3"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["CariIskonto3"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["IskontoluFiyat"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["IskontoluFiyat"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["SatirIndirimliToplam"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["SatirIndirimliToplam"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["SatirAciklama"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["SatirAciklama"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["DepoID"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["DepoID"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["CariToplamIskonto"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["CariToplamIskonto"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokToplamIskonto"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokToplamIskonto"];


                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["ToplamIskonto"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["ToplamIskonto"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["KdvTutari"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["KdvTutari"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["AltBirimMiktar"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["AltBirimMiktar"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["FireMiktari"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["FireMiktari"];
                            Hareketler.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["BirlesikUrunHareketID"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["BirlesikUrunHareketID"];
                        }
                    }

                    Hesapla.AltToplamlariHesapla();

                    evrakIliski.FaturaEvrakIlıski_BosSatirEkle();
                    //evrakIliski.dt.Rows[0][""] = 
                    //evrakIliski.FaturadanEvrakIliskiGetir(SqlConnections.GetBaglanti(), TrGenel, (int)Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["FaturaID"]);
                    evrakIliski.dt.Rows[0]["SiparisID"] = SiparisID;
                    evrakIliski.FaturaIcinEvrakIliskiKaydet(SqlConnections.GetBaglanti(), TrGenel, (int)Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["FaturaID"]);
                }
                cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;
            }
        }

        DataTable dtBirimler;
        public void BirimleriGetir()
        {

            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                clsTablolar.Stok.csStokBirimTanimlari BirimTanimlari = new clsTablolar.Stok.csStokBirimTanimlari();
                BirimTanimlari.BirimDoldur(SqlConnections.GetBaglanti(), TrGenel);
                dtBirimler = BirimTanimlari.dt;
                TrGenel.Commit();
            }
            catch (Exception)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }
            }

        }
        void TeraziMiktarAliniyorsa(clsTablolar.TeraziSatisClaslari.csTerazidenMiktarAl.TeraziBaglantiDurumu Durum)
        {
            try
            {
                if (Durum == clsTablolar.TeraziSatisClaslari.csTerazidenMiktarAl.TeraziBaglantiDurumu.BagliVeMiktarlarAliniyor)
                {
                    labelControl13.Appearance.Image.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                    labelControl13.Refresh();
                }
            }
            catch (Exception)
            {

            }
        }

        void SatislarinGuncelligiKontrolEdilebiliyorsa()
        {
            //if
        }

        public void StokButonuTiklandiginda(clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi BTipi, int StokID)
        {
            try
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Bir Stok Butonuna Tıklandı");


                if (gvSatisHareketleri.RowCount == 0 || (gvSatisHareketleri.GetFocusedRowCellValue(colMiktar) != DBNull.Value && Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue("Miktar")) > 0)) // bu şunun içindi daha sonra yazarsın mk
                {

                }
                else
                {
                    gvSatisHareketleri.DeleteSelectedRows();
                }
                if (BTipi == clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi.StokButonu)
                {
                    StokEkle(StokID);
                }
                else if (BTipi == clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi.PaketButonu)
                {
                    PaketEkle(StokID);
                }
            }
            catch (Exception hata)
            {
                MesajGoster("ahanda dıklatma hatası mk");
            }
        }

        public void StokButonuSagCliccc(clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi BTipi, int StokID)
        {

            clsTablolar.frmStokBilgileri stokBilgileri = new clsTablolar.frmStokBilgileri(SqlConnections.GetBaglanti());
            stokBilgileri.ShowDialog(this);
            stokBilgileri.StokGetirIDden(1, StokID);
        }

        void PaketEkle(int PaketID)
        {
            try
            {
                KaydedileBilirMi = false;
                clsTablolar.Stok.Paket.csPaketDetay PkaetDetay = new clsTablolar.Stok.Paket.csPaketDetay();

                PkaetDetay.Getir(SqlConnections.GetBaglanti(), TrGenel, PaketID);

                foreach (DataRow item in PkaetDetay.dt.AsEnumerable())
                {
                    StokEkle((int)item["StokID"]);
                    Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["KatSayi"] = item["KatSayi"];
                    Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Birim2ID"] = item["AltBirimID"];
                    gvSatisHareketleri.SetFocusedRowCellValue("Miktar", item["Miktar"]); // Bu AltBirim Aslında altbirimMiktar
                }
            }
            catch (Exception ex)
            {
                MesajGoster(ex.Message);
            }
            finally
            {
                KaydedileBilirMi = true;
                btnKaydet_Click(null, null);
            }
        }

        void dt_threadSatislar_RowDeleted(object sender, DataRowChangeEventArgs e) // bu nedendi ??
        {
            //Hesapla.AltToplamlariHesapla();
        }

        void BindleHamisina()
        {
            txtStokAdi.DataBindings.Clear();
            txtMiktari.DataBindings.Clear();
            txtKdvDahilFiyati.DataBindings.Clear();
            txtTutari.DataBindings.Clear();
            txtFireMiktari.DataBindings.Clear();

            txtFaturaNo.DataBindings.Clear();
            txtFaturaTutari.DataBindings.Clear();
            txtIndirimMiktari.DataBindings.Clear();



            txtStokAdi.DataBindings.Add("EditValue", gcSatisHareketleri.DataSource, "FaturaHareketStokAdi");
            txtMiktari.DataBindings.Add("EditValue", gcSatisHareketleri.DataSource, "Miktar", false, DataSourceUpdateMode.OnValidation);
            txtKdvDahilFiyati.DataBindings.Add("EditValue", gcSatisHareketleri.DataSource, "KdvDahilFiyat");
            txtTutari.DataBindings.Add("EditValue", gcSatisHareketleri.DataSource, "KdvDahilToplam");
            txtFireMiktari.DataBindings.Add("EditValue", gcSatisHareketleri.DataSource, "FireMiktari");
            //txtIndirimMiktari.DataBindings.Add("EditVAlue", )



            #region Satişlarin
            txtFaturaNo.DataBindings.Add("EditValue", gcSatislar.DataSource, "FaturaNo");



            txtFaturaTutari.DataBindings.Add("EditValue", gcSatislar.DataSource, "FaturaTutari");

            #endregion
        }

        #region Stok Ekleme vb İşlemleri


        public bool StokEkle(int StokID) // ama nereye ekliyecek mevcut müşteriye mi yeni müşteriye mi
        {
            //bool locktaken = false;
            try
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Stok Ekleme Bloğuna Girdi");
                //Monitor.Enter(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit, ref locktaken);
                //Monitor.Enter(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit, ref locktaken);

                //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    csTeraziLogs.LogYaz(csTeraziLogs.Grup.ThreadKilit, "Stok Ekleme Bloğundaki Girdi, - lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) bunun altına da girdi");
                    if (gvSatislar.RowCount == 0) // hiç aktif satış yoksa yeni satış için yeni müşteri butonuna bas
                    {
                        btnYeniMusteri_Click(null, null);
                    }

                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    clsTablolar.TeraziSatisClaslari.csStok.StokDonenBilgi DonenBilgi = Stok.GetirHamisina(SqlConnections.GetBaglanti(), TrGenel, StokID);
                    TrGenel.Commit();
                    if (clsTablolar.TeraziSatisClaslari.csStok.StokDonenBilgi.StokBulunamadi != DonenBilgi)
                    {
                        Hareketler.dt_FaturaHareketleri.Rows.Add(Hareketler.dt_FaturaHareketleri.NewRow());

                        gvSatisHareketleri.PostEditor();
                        //gvSatisHareketleri.get

                        //gvSatisHareketleri.UpdateCurrentRow();
                        //Hareketler.dt_FaturaHareketleri.Rows.IndexOf()
                        int SonSatirIndex = Hareketler.dt_FaturaHareketleri.Rows.Count - 1; // table da kullanılıyor
                        int SonSatirRowHandle = gvSatisHareketleri.RowCount - 1; // GridView de kullanılıyor


                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["FaturaID"] = gvSatislar.GetFocusedRowCellValue("FaturaID");
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["FaturaHareketStokAdi"] = Stok.StokAdi;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["StokID"] = Stok.StokID;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["StokAnaBirimAdi"] = Stok.StokAnaBirimAdi;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["AnaBirimFiyat"] = Stok.KdvHaricFiyat; // ana Birime Her zaman kdv hariç Fiyatı atıyoruz hamısına çünkü hesaplamaları öyle
                        //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["KdvDahilFiyat"] = Stok.KdvDahilFiyat; // ana Birime Her zaman kdv hariç Fiyatı atıyoruz hamısına çünkü hesaplamaları öyle

                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["Kdv"] = Stok.Kdv;

                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["StokIskonto1"] = 0;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["StokIskonto2"] = 0;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["StokIskonto3"] = 0;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["CariIskonto1"] = 0;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["CariIskonto2"] = 0;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["CariIskonto3"] = 0;


                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["StokAnaBirimID"] = Stok.AnaBirimID;

                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["KatSayi"] = 1;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["Birim2ID"] = Stok.AnaBirimID;
                        //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = MiktarAl.OkunanSabitMiktar;
                        //TerazidenSabitMiktariAl(MiktarAl.OkunanSabitMiktar);
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["FireMiktari"] = 0;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["FireVarMi"] = 0;
                        //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = 0;
                        Hareketler.dt_FaturaHareketleri.Rows[SonSatirIndex]["BirlesikUrunHareketID"] = -2; // -2 verildiği zaman ne birleşik ürün veya birleşik ürünün alt ürünleri değil manasına gelsin


                        if (Stok.AnaBirimID == 2)
                        {
                            //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                            gvSatisHareketleri.SetRowCellValue(SonSatirRowHandle, colAltBirimMiktar, 0);
                        }
                        else
                            //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                            gvSatisHareketleri.SetRowCellValue(SonSatirRowHandle, colAltBirimMiktar, 1);


                        if (Stok.AnaBirimID == 2) // TODO: Burayı daha sonra ayarlardan alıcak. Eğer anabirimi kg ise terazide tartılan ürün için sabit miktar aktarmaya izin ver
                            cbtnTerazidekiSabitMiktariStokaAktar.Checked = true;
                        else
                        {
                            //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki sürüme bağlıydı önceki sürümde
                            //gvSatisHareketleri.SetRowCellValue(SonSatirRowHandle, "Miktar", 1); // ana birim kg değilse ilk miktarı 1 olarak veriyoruz
                        }
                        return true;
                    }
                    else
                    {
                        csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Ürün bulunamadı\nVeya fiyatı yok");
                        MesajGoster("Ürün bulunamadı\nVeya fiyatı yok");
                        return false;
                    }
                }
            }
            catch (Exception hata)
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Hata, "StokEkle fonksiyonunda hata oldu");
                MesajGoster(hata.StackTrace);
                return false;
            }
            finally
            {
                if (TrGenel.Connection != null)
                    try
                    {
                        TrGenel.Rollback();
                    }
                    catch (Exception ex)
                    {
                        MesajGoster(ex.Message);
                    }
                    finally
                    {
                        csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Buraya Hiç Gelemiyor olması lazım eğer buraya gelmişse deadlock a düşmüş olma ihtimali var");
                    }
                //if (locktaken)
                //{
                //    Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
                //    LogLar.LogYaz(csTeraziLogs.Grup.ThreadKilit, "StokEkledeki threadten çıktı");
                //}
            }
        }





        #endregion


        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {// yeni satış demek yeni müşteri demek yeni fatura demek yeni fatura hareketi demek
            csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Yeni Müşteri Ye Tıklatıldı");
            lock (Satislarv2.SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle)
            {
                Satislarv2.YeniKayitAc(CariKart);
            }
            gvSatislar.MoveLast();
            gvSatislar.FocusedRowHandle = gvSatislar.RowCount - 1;
        }

        void CariGetir(int CariID)
        {
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                CariKart = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), TrGenel, CariID);
                memoCariTanim.EditValue = CariKart.CariTanim;
                TrGenel.Commit();
            }
        }

        //bool SatislarV2Kilitleme_lockTaken = false;

        private void gvSatislar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (chckbtnIskontoIslemleri.Checked != false)
                {
                    chckbtnIskontoIslemleri.Checked = false;
                }
                if (gvSatislar.RowCount > 0)
                {
                    HareketleriGetir((int)gvSatislar.GetFocusedRowCellValue("FaturaID"));
                }
                else
                { HareketleriGetir(-1); }
            }
            catch (Exception hata)
            {
                MesajGoster("gvSatislar_FocusedRowChanged burada hata var hamısına");
            }
            finally
            {

            }
        }

        void HareketleriGetir(int FaturaID)
        {
            if (FaturaHareketleriniGetir == true)
            {
                try
                {
                    lock (Satislarv2.SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle)
                    {
                        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

                        Hareketler.FaturaHareketleriniGetir(SqlConnections.GetBaglanti(), TrGenel, FaturaID);

                        TrGenel.Commit();
                    }
                    IndirimVarsaIskontoKolonunuGosterYoksaGosterme();
                }
                catch (Exception hata)
                {
                    try { TrGenel.Rollback(); }
                    catch (Exception) { }
                    csTeraziLogs.LogYaz(csTeraziLogs.Grup.Hata, "Hareketleri Getirirken hata oldu");
                    MesajGoster("Hareketleri Getirirken Hata");
                }
            }
        }

        //public string FaturaBarkodIcinKullanilacakOnEk = "";


        bool FaturaHareketleriniGetir = true; // bu ne içindi önemli bişiydi ama ne??

        public void btnUrunMusteriAra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarkodu.Text)) // barkoda bişi yazılı değilse yazması için düğmeleri çıkar
            {
                clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Yazi);
                if (DialogResult.Yes == frm.ShowDialog() && !string.IsNullOrEmpty(frm.textEdit1.Text)) //textboxın doluluk uğunu sorgulamazsam sonsuz döngüye girer
                {
                    txtBarkodu.Text = frm.textEdit1.Text;
                    btnUrunMusteriAra_Click(null, null);
                }
                return;
            }
            try
            {
                //Monitor.IsEntered(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
                // en son bunu kaldırdın buradan ötürü bir hata olur mu diye kontrol et
                //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) 
                {

                    if (txtBarkodu.EditValue.ToString().StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.FaturaBarkodIcinKullanilacakOnEk))
                    // okutunlan barkod fatura için olan bir barkodsa
                    {
                        if (Satislarv2.dt_threadSatislar.Select(string.Format("FaturaBarkod = '{0}'", txtBarkodu.EditValue)).Length > 0) // Bu tereaziye yüklü olan bir fatura var demekmtir sanırım
                        {
                            for (int i = 0; i < gvSatislar.RowCount; i++)
                            {
                                if (gvSatislar.GetRowCellValue(i, colFaturaBarkod).ToString() == txtBarkodu.EditValue.ToString())
                                {
                                    if (gvSatislar.FocusedRowHandle == i) // eğer zaten bulunan satır aranan satırsa
                                        HareketleriGetir((int)gvSatislar.GetRowCellValue(i, "FaturaID"));
                                    else
                                        gvSatislar.FocusedRowHandle = i;

                                    //btnYenile_Click(null, null);
                                    Hesapla.AltToplamlariHesapla();
                                    break;
                                }
                            }
                            txtBarkodu.EditValue = string.Empty;
                        }
                        else // eğer o nki aktif satışlarda yoksa
                        {
                            try
                            {
                                FaturaHareketleriniGetir = false; // bunu neden yapmıştın düşün ve açıklama yaz
                                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                                int EtkilenenSatirSayisi = Satislarv2.FaturaBarkodtanSatisiGetir(SqlConnections.GetBaglanti(), TrGenel, txtBarkodu.Text);
                                TrGenel.Commit();
                                if (1 != EtkilenenSatirSayisi)
                                {
                                    MesajGoster("Müşteri Bulunamadı");
                                }
                                else
                                {
                                    gvSatislar.MoveLast();
                                    gvSatislar.FocusedRowHandle = gvSatislar.RowCount - 1;
                                    FaturaHareketleriniGetir = true;
                                    HareketleriGetir((int)gvSatislar.GetFocusedRowCellValue("FaturaID"));
                                    Hesapla.AltToplamlariHesapla(); // aha bu ne oli ki
                                }
                            }
                            catch (Exception hata)
                            {
                                MesajGoster("hata mk");
                            }
                            finally
                            {
                                FaturaHareketleriniGetir = true;
                            }
                        }
                        txtBarkodu.EditValue = string.Empty;
                    }
                    else if (txtBarkodu.EditValue.ToString().StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.SiparisBarkodNumarasiOnEki))
                    {
                        //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                        {
                            using (clsTablolar.Siparis.csBarkodtanSiparisIDGetir barkodtanGetir = new clsTablolar.Siparis.csBarkodtanSiparisIDGetir())
                            {
                                clsTablolar.Siparis.csBarkodtanSiparisIDGetir.SiparisOdeme SipBilgisi = barkodtanGetir.BarkodtaSiparisIDGetir(SqlConnections.GetBaglanti(), TrGenel, txtBarkodu.Text);

                                if (SipBilgisi.SipariID != -1) // Sipariş Varsa
                                {
                                    if (SipBilgisi.FaturaID != -1) // Sipariş Faturaya Aktarılmışsa (sipariş Satışa aktarılmışsa)
                                    {
                                        if (SipBilgisi.OdemesiTamamlandiMi == false) // Siparişin Faturaya Aktarılmış ve ödemesi tamamlanmamışsa
                                        {
                                            txtBarkodu.EditValue = SipBilgisi.FaturaBarkod;
                                            btnUrunMusteriAra_Click(null, null);
                                            return;
                                        }
                                        else
                                        { MesajGoster("Bu sipariş Satışa aktarılmış ve ödemesi tamamlanmış!"); }
                                    }
                                    else // faturaya aktarılmamışsa
                                    {
                                        using (frmSiparis sip = new frmSiparis(SipBilgisi.SipariID))
                                        {
                                            sip.SiparisiSatisaAktarma = SiparisiSatisaAktarma;
                                            sip.ShowDialog();
                                        }
                                    }
                                }
                                else  // faturaID gelirse fatura aktarılmıştır.
                                {
                                    MesajGoster("Sipariş Yok");
                                }
                            }
                        }
                    }
                    else // okutulan barkod ürünün barkodu ise
                    {
                        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                        BarkodtanStokArma = new clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama();
                        clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama.StokIDMiktarBirim IdveMiktar = BarkodtanStokArma.StokBarkodundanStokIDVer(SqlConnections.GetBaglanti(), TrGenel, txtBarkodu.EditValue.ToString());
                        TrGenel.Commit();

                        if (IdveMiktar.StokID != -1)
                        {
                            try
                            {
                                //KaydedileBilirMi = false;
                                KaydedileBilirMi = false;
                                StokEkle(IdveMiktar.StokID);

                                //if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colStokAnaBirimID) == 2 && IdveMiktar.Miktar ) // TODO : Ayarlardan alıcak
                                //{
                                //    Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["FireVarMi"] = 1;
                                //}

                                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["KatSayi"] = IdveMiktar.Katsayi;
                                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Birim2ID"] = IdveMiktar.AltBirimID;
                                gvSatisHareketleri.SetFocusedRowCellValue("Miktar", IdveMiktar.Miktar); // Bu AltBirim Aslında

                            }
                            catch (Exception hata)
                            {
                                MesajGoster("hatadır 92");
                            }
                            finally
                            {
                                KaydedileBilirMi = true;
                                btnKaydet_Click(null, null); // ürün eklediğimiz için kaydettik // normalde altttoplalam falana dlidl
                            }
                        }
                        else
                            MesajGoster("Ürün Bulunamadı");
                    }
                }
            }

            catch (Exception hata2)
            {
                try { TrGenel.Rollback(); }
                catch (Exception) { }
            }
            finally
            {
                if (SatislarV2Kilitleme_lockTaken)
                {
                    Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
                    SatislarV2Kilitleme_lockTaken = false;
                }
                txtBarkodu.EditValue = string.Empty;
            }
        }

        private void txtBarkodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnUrunMusteriAra_Click(null, null);
        }

        #region Miktar Alma İşlemleri

        bool MiktarAlma_lockTaken = false;

        void TerazidenMiktarAlmayaBasla()
        {
            //th1 = new Thread(new ThreadStart(TerazidenMiktarAl));
            //th1.Start();
            try
            {
                {
                    MiktarAl.TerazidekiMiktarAl = TerazidenMiktarAl; // Miktar Geldikçe Tetiklenir
                    MiktarAl.SabitMiktarAl = TerazidenSabitMiktariAl; // SadeceSabit Miktar Geldiğinde Tetiklenir
                    MiktarAl.MiktarAlamayaBasla(TeraziSatis.Properties.Settings.Default.TeraziBagNok, TeraziSatis.Properties.Settings.Default.TeraziModel);
                }
            }
            catch (Exception hata)
            {
                MesajGoster(hata.Message);
            }
            finally
            {
            }

        }

        // bu csTerazidenMiktarAl daki delegeye atılacak oradan sürekli bu çalıştırılacak falan filan hamısına 
        void TerazidenMiktarAl(decimal AnlikMiktar)
        { // sabit miktarın değişip değişmediğini class ta değil burada kontrol etmemiz lazım
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // heee burasını aslında
            {
                try
                {// terazideki kilite bağlıydı önceki sürümde
                    txtTerazidekiMiktari.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.Red;
                    txtTerazidekiMiktari.EditValue = AnlikMiktar - DaraMiktari;
                }
                catch (Exception hata)
                {
                    if (hata.HResult != -2147023901)
                    {
                        MesajGoster("Hata hamısına  Miktar alma hatası 123456 \n" + hata.StackTrace);
                    }
                }
            }
        }

        bool SatislarV2Kilitleme_lockTaken = false; // bu bu kodları yazdığın thread te kilitlediyese



        private bool TerazidenSabitMiktariAl(decimal TerazidenGelenSabitMiktar)
        {

            try
            {
                TerazidenGelenSabitMiktar = TerazidenGelenSabitMiktar - DaraMiktari;
                txtTerazidekiMiktari.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.Lime;

                //if (Convert.ToDecimal(MiktarAl.OkunanSabitMiktar) + DaraMiktari > TerazidenGelenSabitMiktar && TerazidenGelenSabitMiktar + DaraMiktari == 0) // bu aynı zamanda ürünlerin teraziden kaltığını söylüyor.
                if (TerazidenGelenSabitMiktar + DaraMiktari == 0) // bu aynı zamanda ürünlerin teraziden kaltığını söylüyor.
                //if (TerazidenGelenSabitMiktar == 0)
                { //ürün teraziden kalkmış demektir. sadece TerazidenGelenSabitMiktar == 0 kontrolü yapmak iyi olmuyor neden ki yazsaydın keşke
                    lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki kilite bağlıydı önceki sürümde
                        cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;
                    if (checkEdit2.Checked == true && TerazidenGelenSabitMiktar + DaraMiktari == 0 && DaraMiktari != 0)
                    {// daramiktarının 0 olamama durumu şartını koymazsam sonsuz bir döngüye giriyor
                        btnDaraIptal_Click(null, null);
                        //break;
                        return false; // sanırım bu önemli
                    }
                }


                //txtTerazidenGelenSabitMiktar.EditValue = TerazidenGelenSabitMiktar;


                if (((cbtnTerazidekiSabitMiktariStokaAktar.Checked && (TerazidenGelenSabitMiktar + DaraMiktari) != (decimal)1 / 500 // Okunan sabit miktarın 2 gramdan fazla olması koşulunu (MiktarAl.OkunanSabitMiktar != 1/500) da ekledik bazen ürünü kaldırırken 2 gr için sabitleyip sonra 0 olıuyor
                    && TerazidenGelenSabitMiktar != 0 && TerazidenGelenSabitMiktar > 0 && gvSatisHareketleri.RowCount != 0)
                    || gvSatisHareketleri.GetFocusedRowCellValue(colMiktar) == DBNull.Value) && (int)gvSatisHareketleri.GetFocusedRowCellValue(colBirim2ID) == 2 && MiktarAl.OkunanSabitMiktar != (decimal)1 / 500) // Ayarlara eklenecek
                {
                    if (Convert.ToInt32(gvSatisHareketleri.GetFocusedRowCellValue("BirlesikUrunHareketID")) == -2 || KarisikUrunFormuAcik)

                        if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colFireVarMi) == 0) // Fire Yoksa
                        {

                            //if (Monitor.TryEnter(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit, 1000))
                            {
                                try
                                {
                                    lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki kilite bağlıydı önceki sürümde
                                        //gvSatisHareketleri.
                                        gvSatisHareketleri.SetFocusedRowCellValue(colMiktar, TerazidenGelenSabitMiktar);
                                    return true;
                                }
                                finally
                                {
                                    //Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
                                }
                            }
                            //else return false;
                        }
                        else // Fire miktatrı varsa miktar fire miktarına ekllenecek
                        {
                            //if (Monitor.TryEnter(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit, 1000))
                            {
                                try
                                {
                                    lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki kilite bağlıydı önceki sürümde
                                        gvSatisHareketleri.SetFocusedRowCellValue("FireMiktari", TerazidenGelenSabitMiktar - Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colMiktar)));
                                    return true;
                                }
                                finally
                                {

                                    //Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
                                }
                            }
                            //else return false;
                        }
                }
                return false;
            }
            catch (Exception hata)
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Hata, "Teraziden Sabit miktarı Alırken hata oldu");
                MesajGoster(hata.StackTrace);
                return false;
            }
            finally
            {
                textBox1.Text = txtTerazidekiMiktari.EditValue.ToString();

            }
        }


        decimal DaraMiktari = 0;

        #endregion


        object KAydederkenKullanilacakLock = new object();
        Thread thKaydet;

        /// <summary>
        /// Normalde sadece satır hesaplaması değiştiğinde kaydetmesi gerekiyor ama bazen ard arda fazla kaydı engellemek için son yapılan değişikliği kaydetmesini isteyebiliyoruz
        /// Bunun için bool KaydedileBilirMi değişkenine ihtiyaç duyduk eğer hemen kaydolmasın istiyorsak bunu false yap. en son kayıt yaptığında true yaparak
        /// btnKaydet_Click(null,null); yap. Tabi değişkeninn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "btnKaydet_Click Basıldı");

                if (gvSatislar.RowCount == 0)
                {
                    return;
                }
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "if (thKaydet.Join(TimeSpan.FromSeconds(4)))  Buranın hemen sonunda şimdi");
                //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Hemen sonraki lock a da girdi");
                    gvSatislar.UpdateCurrentRow();
                    //thKaydet = new Thread(() => { Kaydet(gvSatislar.GetFocusedDataRow(), Hareketler.dt_FaturaHareketleri); });
                    //thKaydet.Start();
                    Kaydet(gvSatislar.GetFocusedDataRow(), Hareketler.dt_FaturaHareketleri);
                }
            }
            catch (Exception exx)
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "btnKaydet_Click te hata oldu");
                //Mesagg("düşme ihtimali varmış de anlar herhalde");
            }
            // satışa hiç hareket eklemeden hemen kaydetmeli            
        }
        //DataTable

        void Kaydet(DataRow Fatura, DataTable FaturaHareket)
        {
            bool YeniKayitMi = false;
            csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Kaydet Fonsiyonu çalıştırıldı");
            bool MonitorKilit = false;
            try
            {
                //Çalıştırılacak olan kodlar buraya yazılacaktır…

                //lock (Satislarv2.SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle)
                //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                if (KaydedileBilirMi)
                {
                    //Stopwatch sw = new Stopwatch();
                    //sw.Start();
                    Monitor.Enter(Satislarv2.SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle, ref MonitorKilit);
                    csTeraziLogs.LogYaz(csTeraziLogs.Grup.ThreadKilit, "Kaydet fonksiyonundaki thread kilitledi kilit nessesi : Satislarv2.SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle");
                    //LogLar.LogYaz("", "Kaydet Fonksiyonu çalıştırıldı ve Lock a girdi");
                    try
                    {
                        //int SatislarRowHandle = gvSatislar.FocusedRowHandle;
                        if ((int)Fatura["FaturaID"] == -1) // yeni kayıtsa fatura numarası verdiriyoruz
                        {
                            //LogLar.LogYaz(csTeraziLogs.Grup.Grupsuz, "FaturaID si (-1) geldi ve FaturaNo Verilecek");
                            //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                            //Fatura["FaturaNo"] = NumaraVer.NumaraVerveKaydet(5, SqlConnections.GetBaglanti(), TrGenel); //TODO: Varsayılan numara diye bir alan oluştur ilerde hamısına; // bu nereden alıcak hamısına
                            //TrGenel.Commit();
                            //LogLar.LogYaz(csTeraziLogs.Grup.Grupsuz, "FaturaNo Verildi");
                            YeniKayitMi = true;
                        }

                        int FaturaID = 0;
                        //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)

                        {

                            //SqlConnections.GetBaglanti().ConnectionTimeout
                            //Satislarv2.dt_threadSatislar.GetChanges(DataRowState.Unchanged);

                            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                            FaturaID = Satislarv2.SatisiKaydet(SqlConnections.GetBaglanti(), TrGenel, Fatura, TeraziSatis.Properties.Settings.Default.TeraziID);
                            TrGenel.Commit();
                            if (FaturaID == -5)
                            {
                                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "ödemesi Yapılan bir kayıt Güncellenmek istendi");
                                MesajGoster(string.Format("kayıtta hata veya {0} BÜYÜK İHTİMALLE ÖDEMESİ TAMAMLANMIŞTIR{0}YENİ MÜŞTERİYE BAKIYORSAN \"YENİ MÜŞTERİ\" BUTONUNA BASMADIN{0}BASTIYSAN KASA ÖDEMESİNİ KAPATMIŞ DEMEKTİR KASADAKİ ARKADAŞI UYAR", Environment.NewLine));
                                try
                                {
                                    //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                                    {// Buraya gelmesinin Sebebi Satışın Ödemesi yapıldığı halde güncelleme yapılması istendiğinde

                                        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                                        Satislarv2.SatisinAltToplamHesaplamalariniServerdanHesaplaveKaydet(SqlConnections.GetBaglanti(), TrGenel, FaturaID);
                                        // alt toplamları serverdan da hesaplattırarak aynı anda iki müşteriye bakıldığında bile fatura tutarının doğru olmasını sağladık
                                        // Böylece aynı anda iki müşteriye bakarken fatura tutarı kasaya direk doğru olarak gidecek
                                        TrGenel.Commit();

                                        AktifSatisiGuncelle(); // bu geçiçi bir çözüm sanırım
                                        KaydedileBilirMi = false;
                                        Hesapla.AltToplamlariHesapla();
                                        AltToplamHesaplamalariniAl();
                                        return;
                                    }
                                }
                                catch (Exception hataa)
                                {
                                    csTeraziLogs.LogYaz(csTeraziLogs.Grup.Hata, "ödemesi Yapılan bir kayıt Güncellenmek istendi ve hata oluştu");
                                    return;
                                }
                            }
                        }

                        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                        Hareketler.FaturaHareketleriniKaydet(SqlConnections.GetBaglanti(), TrGenel, FaturaID, FaturaHareket);
                        TrGenel.Commit();



                        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                        Satislarv2.SatisinAltToplamHesaplamalariniServerdanHesaplaveKaydet(SqlConnections.GetBaglanti(), TrGenel, FaturaID);
                        // alt toplamları serverdan da hesaplattırarak aynı anda iki müşteriye bakıldığında bile fatura tutarının doğru olmasını sağladık
                        // Böylece aynı anda iki müşteriye bakarken fatura tutarı kasaya direk doğru olarak gidecek

                        TrGenel.Commit();
                        //sw.Stop();
                        //MessageBox.Show(sw.ElapsedMilliseconds.ToString());

                        if (YeniKayitMi && YeniMusterininFisiniYaziciIkidenOtomatikYazdir)
                            btnYazici2_Click(null, null);
                        if (YeniKayitMi && YeniMusterininFisiniYaziciBirdenOtomatikYazdir)
                            btnYaziciBir_Click(null, null);
                        //btnKaydet.Enabled = false;
                        csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Sorunsuz Bi şekilde Kayıt Tamamlandi");
                    }
                    catch (Exception hata)
                    {
                        try
                        {
                            TrGenel.Rollback();
                        }
                        catch (Exception) { }
                        csTeraziLogs.LogYaz(csTeraziLogs.Grup.Hata, "Kayıtta hata oluştu");
                        MesajGoster("Kayıtta HAta");
                    }
                    finally
                    {
                        KaydedileBilirMi = true;
                    }
                }
            }
            finally
            {
                if (MonitorKilit)
                {
                    Monitor.Exit(Satislarv2.SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle);
                    csTeraziLogs.LogYaz(csTeraziLogs.Grup.ThreadKilit, "Kaydet fonksiyonundaki thread kilitten çıktı kilit Nesnesi : Satislarv2.SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle");
                }
            }

        }
        void AltToplamHesaplamalariniAl()
        {
            try
            {
                //if (SatislarV2Kilitleme_lockTaken == false)
                //    Monitor.TryEnter(Satislarv2.KilitHamisina, TimeSpan.FromSeconds(2), ref SatislarV2Kilitleme_lockTaken);
                //Monitor.Enter(Satislarv2.KilitHamisina, ref SatislarV2Kilitleme_lockTaken);


                //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // en son bunu çıkarttık bakalım nasıl olacak
                {

                    gvSatislar.SetFocusedRowCellValue("Toplam_Iskontosuz_Kdvsiz", Hesapla.Toplam_Iskontosuz_Kdvsiz);
                    gvSatislar.SetFocusedRowCellValue("CariIskontoToplami", Hesapla.CariIskontoToplami);
                    gvSatislar.SetFocusedRowCellValue("StokIskontoToplami", Hesapla.StokIskontoToplami);
                    gvSatislar.SetFocusedRowCellValue("ToplamIndirim", Hesapla.ToplamIndirim);
                    gvSatislar.SetFocusedRowCellValue("ToplamKdv", Hesapla.ToplamKdv);
                    gvSatislar.SetFocusedRowCellValue("IskontoluToplam", Hesapla.IskontoluToplam);
                    gvSatislar.SetFocusedRowCellValue("FaturaTutari", Hesapla.FaturaTutari);

                    txtIndirimMiktari.EditValue = Hesapla.ToplamKdvDahilIndirimMiktari;

                    txtIndirimsizSatisTutari.EditValue = Hesapla.ToplamKdvDahilIndirimsizSatisTutari;
                    txtIndirimYuzdesi.EditValue = Hesapla.ToplamOrtalamIndirimYuzdesi;


                    //txtToplam_Iskontosuz_Kdvsiz.EditValue = Hesaplamalar.Toplam_Iskontosuz_Kdvsiz;
                    //txtToplamIndirim.EditValue = Hesaplamalar.ToplamIndirim;
                    //txtCariIskontoToplami.EditValue = Hesaplamalar.CariIskontoToplami;
                    //txtStokIskontoToplami.EditValue = Hesaplamalar.StokIskontoToplami;
                    //txtToplamKDV.EditValue = Hesaplamalar.ToplamKdv;
                    //txtAraToplam.EditValue = Hesaplamalar.IskontoluToplam;

                    //txtFaturaTutari.EditValue = Hesaplamalar.FaturaTutari;

                    //Satislarv2.dt_threadSatislar.Rows[gvSatislar.GetFocusedDataSourceRowIndex()]["Toplam_Iskontosuz_Kdvsiz"] = Hesapla.Toplam_Iskontosuz_Kdvsiz;
                    //Satislarv2.dt_threadSatislar.Rows[gvSatislar.GetFocusedDataSourceRowIndex()]["CariIskontoToplami"] = Hesapla.CariIskontoToplami;
                    //Satislarv2.dt_threadSatislar.Rows[gvSatislar.GetFocusedDataSourceRowIndex()]["StokIskontoToplami"] = Hesapla.StokIskontoToplami;
                    //Satislarv2.dt_threadSatislar.Rows[gvSatislar.GetFocusedDataSourceRowIndex()]["ToplamIndirim"] = Hesapla.ToplamIndirim;
                    //Satislarv2.dt_threadSatislar.Rows[gvSatislar.GetFocusedDataSourceRowIndex()]["ToplamKdv"] = Hesapla.ToplamKdv;
                    //Satislarv2.dt_threadSatislar.Rows[gvSatislar.GetFocusedDataSourceRowIndex()]["IskontoluToplam"] = Hesapla.IskontoluToplam;
                    //Satislarv2.dt_threadSatislar.Rows[gvSatislar.GetFocusedDataSourceRowIndex()]["FaturaTutari"] = Hesapla.FaturaTutari;

                    //txtFaturaTutari.EditValue = Hesapla.FaturaTutari;
                }
                //BindleHamisina();
            }
            catch (Exception hata)
            {
                MesajGoster(@"Hata hamısına bu hatayı bildir 
ne hatısı diye sorarsam hamısına hatası de
");
            }
            finally
            {
                if (KaydedileBilirMi == true)
                    if (gvSatislar.RowCount != 0)
                        btnKaydet_Click(null, null);

                //if (SatislarV2Kilitleme_lockTaken)
                //{
                //    Monitor.Exit(Satislarv2.KilitHamisina);
                //    SatislarV2Kilitleme_lockTaken = false;
                //}
            }
        }

        public void gvSatisHareketleri_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                gvSatisHareketleri.UpdateCurrentRow();
                gvSatislar_CellValueChanged(null, null);
            }
            catch (Exception hata)
            {
                MesajGoster("bu hatayı bildir hata 1 diye");
            }
        }

        public void gvSatislar_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                gvSatislar.UpdateCurrentRow();
            }
            catch (Exception hata)
            {
                MesajGoster("bu hatayı bildir hata 2 diye");
            }
        }

        #region Sabit Miktar Veya fiyat girme işlemleri

        public void btnMiktarGir_Click(object sender, EventArgs e)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            if (cbtnTerazidekiSabitMiktariStokaAktar.Checked == false)
            {
                MesajGoster("Miktar Değiştirmek İçin Önce Miktar Guncelleme İzinini Ver");
                return;
            }
            if (gvSatisHareketleri.RowCount == 0)
            {
                MesajGoster("Ürün yok");
                return;
            }
            if ((gvSatisHareketleri.GetFocusedRowCellValue(colBirlesikUrunHareketID).ToString() != "-2" || KarisikUrunFormuAcik) && (int)gvSatisHareketleri.GetFocusedRowCellValue(colStokAnaBirimID) != 2)
            {// Birleşik ürün veya birleşik ürünün alt ürün olmayacak ve ürün kg olacak
                MesajGoster("Bu ürünün Miktarı Değiştirilemez");
                return;
            }
            if (Convert.ToInt32(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(gvSatisHareketleri.GetFocusedDataSourceRowIndex()), colBirim2ID)) != 2)
            {
                using (clsTablolar.frmMiktarGir MiktarFormu = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.TamSayi))
                {
                    MiktarFormu.labelControl1.Text = "Seçili Ürün İçin Tam Sayı Miktar Girin";
                    if (MiktarFormu.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
                    {
                        MiktarGir(gvSatisHareketleri.GetFocusedDataSourceRowIndex(), Convert.ToDecimal(MiktarFormu.textEdit1.EditValue), true);
                    }
                }
            }
            else
                using (clsTablolar.frmMiktarGir MiktarFormu = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                {
                    MiktarFormu.labelControl1.Text = "Seçili Ürün İçin Miktar Girin";
                    if (MiktarFormu.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
                    {
                        MiktarGir(gvSatisHareketleri.GetFocusedDataSourceRowIndex(), Convert.ToDecimal(MiktarFormu.textEdit1.EditValue), true);
                    }
                }
            //sw.Stop();
            //MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        }
        clsTablolar.frmMiktarGir MiktarFormu = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);


        public void MiktarGir(int datasourceindexx, decimal Miktar, bool IsleminSonundaHemenKaydetsinMi)
        {
            try
            {
                //if (MiktarAlma_lockTaken == false)
                //    Monitor.TryEnter(MiktarAl.MiktarAlmayiKilitle, TimeSpan.FromSeconds(2), ref MiktarAlma_lockTaken);
                KaydedileBilirMi = false;
                lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {

                    // önce daha önce sabit miktar veya fiyat girilmişse bunları sıfırlıyoruz


                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colMiktar, Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colMiktar)) + Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colFireMiktari))); // bunu yaparak en başa alıyoruz
                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colFireMiktari, 0); // bunu yaparak ta en başa alıyoruz
                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colFireVarMi, 0);


                    if (Miktar != 0) // diğer fire işlemlerini yaptırmıyoruz
                    {
                        decimal SimdikiMiktar = Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "Miktar"));

                        gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "FireMiktari", SimdikiMiktar - Miktar);
                        gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "Miktar", Miktar);
                        gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "FireVarMi", 1);
                    }
                }
            }
            catch (Exception hata)
            {
                MesajGoster("Miktar Gir Hatasi");
            }
            finally
            {
                if (IsleminSonundaHemenKaydetsinMi)
                {
                    KaydedileBilirMi = true;
                    btnKaydet_Click(null, null);
                }
            }
        }

        public void btnTutarGir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbtnTerazidekiSabitMiktariStokaAktar.Checked == false)
                {
                    MesajGoster("Miktar Değiştirmek İçin Önce Miktar Guncelleme İzinini Ver");
                    return;
                }
                //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    try
                    {
                        if (gvSatisHareketleri.RowCount == 0)
                        {
                            MesajGoster("Ürün yok");
                            return;
                        }
                        if ((gvSatisHareketleri.GetFocusedRowCellValue(colBirlesikUrunHareketID).ToString() != "-2" || KarisikUrunFormuAcik) && (int)gvSatisHareketleri.GetFocusedRowCellValue(colStokAnaBirimID) != 2)
                        {
                            MesajGoster("Bu ürünün Tutarı Değiştirilemez");
                            return;
                        }
                    }
                    catch (Exception hata)
                    {
                        MesajGoster("hatadır 99");
                    }
                    finally
                    {

                    }
                    if (Convert.ToInt32(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(gvSatisHareketleri.GetFocusedDataSourceRowIndex()), colBirim2ID)) == 2)
                        using (MiktarFormu = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                        {
                            MiktarFormu.labelControl1.Text = "Seçili Ürün İçin Tutar Girin";
                            if (MiktarFormu.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
                            {
                                // istenilen tutarı kdvdahil fiyatına bölerek IstenilenMiktar ı buluyoruz


                                if (Convert.ToDecimal(MiktarFormu.textEdit1.EditValue) != 0) // eğer 0 gelmediyse işlemleri yaptır 0 geliyorsa işlemi yapmasın ve yukarıdaki kod sayesinde daha önce yapılan bir sabitleme işlemi de varsa silsin hamısına
                                {
                                    TutarGir(gvSatisHareketleri.GetFocusedDataSourceRowIndex(), Convert.ToDecimal(MiktarFormu.textEdit1.EditValue), true);
                                }
                                else //miktar olarak 0 verildiğinde fireyi silmesi lazım
                                {
                                    MiktarGir(gvSatisHareketleri.GetFocusedDataSourceRowIndex(), 0, true);
                                }
                            }
                        }
                    else
                        MesajGoster("adetli satılanlara tutar girmeyin bi süre ondalıklı satışyapıyorsunuz çikolatayı ortadan 2 yemi bölüyonuz napıyonuz ama miktar girebilirsiniz");
                }
            }
            catch (Exception hata)
            {
                MesajGoster("hatadır 98");
            }
            finally
            {

            }
        }

        public void TutarGir(int datasourceindexx, decimal Tutar, bool Kaydetsinsin)
        {
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
            {
                try
                {
                    KaydedileBilirMi = false;
                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colMiktar, Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colMiktar)) + Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colFireMiktari))); // bunu yaparak en başa alıyoruz
                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colFireMiktari, 0); // bunu yaparak ta en başa alıyoruz
                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colFireVarMi, 0); // bunu yaparak ta en başa alıyoruz

                    decimal SimdikiMiktar = Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "Miktar"));

                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "Miktar", Tutar / Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), colKdvDahilFiyat)));
                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "FireMiktari", SimdikiMiktar - Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "Miktar")));
                    gvSatisHareketleri.SetRowCellValue(gvSatisHareketleri.GetRowHandle(datasourceindexx), "FireVarMi", 1);
                }
                catch (Exception hata)
                {
                    MesajGoster("hatadır 97");
                }
                finally
                {
                    if (Kaydetsinsin)
                    {
                        KaydedileBilirMi = true;
                        btnKaydet_Click(null, null);
                    }
                }

            }
        }

        #endregion

        frmKarisikUrun KarisikUrunFormu;

        private void btnBirlesikUrunEkle_Click(object sender, EventArgs e)
        {
            bool lockTaken = false;
            try
            {
                Monitor.Enter(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit, ref lockTaken);

                if (gvSatislar.RowCount == 0) // hiç aktif satış yoksa yeni satış için yeni müşteri butonuna bas
                {
                    btnYeniMusteri_Click(null, null);
                } // satışta müşteri varsa o aktif müşteridir o müşteriye ürünü sat
                KarisikUrunFormu = new frmKarisikUrun(this, -1);
                KarisikUrunFormuAcik = true;
                KarisikUrunFormu.ShowDialog(this);
            }
            catch (Exception hata)
            {
                KarisikUrunFormuAcik = false;
                MesajGoster(hata.StackTrace);
            }
            finally
            {
                try
                {
                    KarisikUrunFormuAcik = false;
                    if (lockTaken)
                        Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
                }
                catch (Exception ex)
                {
                    MesajGoster(ex.Message);
                }
            }
        }

        public void btnUrunCikar_Click(object sender, EventArgs e)
        {
            if (gvSatisHareketleri.RowCount == 0)
            {
                MesajGoster("Silinecek Satır yok");
                return;
            }

            if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colBirlesikUrunHareketID) != -2 && !KarisikUrunFormuAcik)
            {
                MesajGoster("Birlşik Ürün Silinemez");
                return;
            }

            try
            {
                lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    if (DialogResult.Yes == MessageBox.Show(this, "Seçili ürünü silmek istediğinden emin misin hamısna", "Dikkat Hamısına", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                    {
                        gvSatisHareketleri.DeleteSelectedRows();
                        Hesapla.AltToplamlariHesapla();
                    }
                }
            }
            catch (Exception hata)
            {
                MesajGoster(hata.Message);
            }
            finally
            {
                KaydedileBilirMi = true;
                btnKaydet_Click(null, null);
            }
        }

        private void gcSatisHareketleri_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvSatisHareketleri.RowCount == 0) return;

                if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colBirlesikUrunHareketID) == -1) // HAREKET BİRLEŞİK ÜRÜNSE
                {
                    frmKarisikUrun frm = new frmKarisikUrun(this, (int)gvSatisHareketleri.GetFocusedRowCellValue(colFaturaHareketID)) { BirlesikUrunDatarowIndex = gvSatisHareketleri.GetFocusedDataSourceRowIndex() };
                    frm.ShowDialog(this);
                }
            }
            catch (Exception hata)
            {
                MesajGoster("gene hata mk");
            }
            finally
            {

            }
        }

        private void cbtnTerazidekiSabitMiktariStokaAktar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbtnTerazidekiSabitMiktariStokaAktar.Checked == true)
                {
                    if (gvSatisHareketleri.RowCount == 0)
                        return;
                    if ((int)(gvSatisHareketleri.GetFocusedRowCellValue(colBirim2ID)) != 2) //TODO : bunuda ayarlardan alıcak sonra
                    {
                        //cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;
                        //return;
                    }
                    if (MiktarAl.OkunanSabitMiktar + DaraMiktari != 0)
                    //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki kilite bağlıydı önceki sürümde
                    {
                        txtTerazidekiMiktari_EditValueChanged(null, null);
                        TerazidenSabitMiktariAl(MiktarAl.OkunanSabitMiktar);
                    }
                }
            }
            catch (Exception hata)
            {
                MesajGoster(hata.Message);
            }
            finally
            {
            }
        }

        #region dara İşlemleri
        public void btnDaraAl_Click(object sender, EventArgs e)
        {
            decimal DARA;
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki kilite bağlıydı önceki sürümde
                DARA = MiktarAl.OkunanSabitMiktar;
            DaraAl(DARA);
        }

        public void DaraAl(decimal daraaaaMik)
        {
            try
            {
                lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki kilite bağlıydı önceki sürümde
                {
                    DaraMiktari = daraaaaMik;
                    txtDaraMiktari.EditValue = DaraMiktari;
                    TerazidenMiktarAl(MiktarAl.OkunanAnlikMiktar);
                    TerazidenSabitMiktariAl(MiktarAl.OkunanSabitMiktar);
                }
            }
            catch (Exception hata)
            {
                MesajGoster("hatadır 96");
            }
            finally
            {
                cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;
            }
        }

        public void btnDaraIptal_Click(object sender, EventArgs e)
        {
            try
            {
                lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) //  terazideki kilide bağlıydı önceki sürümde
                    DaraMiktari = 0;
                txtDaraMiktari.EditValue = DaraMiktari;
                TerazidenMiktarAl(MiktarAl.OkunanAnlikMiktar);
                TerazidenSabitMiktariAl(MiktarAl.OkunanSabitMiktar);

            }
            catch (Exception hata)
            {
                MesajGoster("hatadır 95");
            }
            finally
            {
            }
        }

        #endregion

        private void frmTerazi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                txtBarkodu.Focus();
                txtBarkodu.SelectAll();
            }
            else if (txtBarkodu.ContainsFocus == false)
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
        (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
        e.KeyCode == Keys.Decimal)
                {
                    txtBarkodu.Focus();
                    txtBarkodu.Select(txtBarkodu.Text.Length, 0);
                    switch (e.KeyCode)
                    {
                        case Keys.NumPad0:
                            txtBarkodu.Text = txtBarkodu.Text + "0";
                            break;
                        case Keys.NumPad1:
                            txtBarkodu.Text = txtBarkodu.Text + "1";
                            break;
                        case Keys.NumPad2:
                            txtBarkodu.Text = txtBarkodu.Text + "2";
                            break;
                        case Keys.NumPad3:
                            txtBarkodu.Text = txtBarkodu.Text + "3";
                            break;
                        case Keys.NumPad4:
                            txtBarkodu.Text = txtBarkodu.Text + "4";
                            break;
                        case Keys.NumPad5:
                            txtBarkodu.Text = txtBarkodu.Text + "5";
                            break;
                        case Keys.NumPad6:
                            txtBarkodu.Text = txtBarkodu.Text + "6";
                            break;
                        case Keys.NumPad7:
                            txtBarkodu.Text = txtBarkodu.Text + "7";
                            break;
                        case Keys.NumPad8:
                            txtBarkodu.Text = txtBarkodu.Text + "8";
                            break;
                        case Keys.NumPad9:
                            txtBarkodu.Text = txtBarkodu.Text + "9";
                            break;
                        default:
                            txtBarkodu.Text = txtBarkodu.Text + Convert.ToChar((int)e.KeyValue).ToString();
                            break;
                    }
                    txtBarkodu.Select(txtBarkodu.Text.Length, 0);
                }
        }

        #region Yazdırma İşlemleri
        clsTablolar.Yazdirma.csYazdir yazdirrr = new clsTablolar.Yazdirma.csYazdir();
        DataTable dt_yazdirma = new DataTable();

        string YaziciAdi1 = string.Empty;
        string YaziciAdi2 = string.Empty;

        void YazdirmaIslemiIcinHazirlik()
        {
            yazdirrr.dt_ekle("Fatura");
            yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaBarkod", string.Empty, System.Type.GetType("System.String"));
            yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaTarihi", DBNull.Value, System.Type.GetType("System.DateTime"));
            yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaTutari", DBNull.Value, System.Type.GetType("System.Decimal"));

            YaziciAdi1 = TeraziSatis.Properties.Settings.Default.Yazici1;
            YaziciAdi2 = TeraziSatis.Properties.Settings.Default.Yazici2;


            btnYazici2.Text = YaziciAdi2;
            btnYaziciBir.Text = YaziciAdi1;

            FisBilgleri = new csMusteriFisBilgileri();

            //MusteriFisi = new DevExpress.XtraReports.UI.XtraReport();
            //MusteriFisi.LoadLayout(Application.StartupPath + @"\Raporlar\MusteriNumarasi.repx");

            yazdirrr.DosyayaiArabellegeAl(Application.StartupPath + @"\Raporlar\MusteriNumarasi.repx");
        }
        //DevExpress.XtraReports.UI.XtraReport MusteriFisi;
        csMusteriFisBilgileri FisBilgleri;

        Thread th_Yazdir;


        private void btnYaziciBir_Click(object sender, EventArgs e)
        {
            if (gvSatislar.RowCount == 0)
            {
                return;
            }

            FisBilgleri.Barkod = gvSatislar.GetFocusedRowCellValue(colFaturaBarkod).ToString();
            FisBilgleri.Tarih = Convert.ToDateTime(gvSatislar.GetFocusedRowCellValue(colFaturaTarihi));
            FisBilgleri.Tutar = Convert.ToDecimal(gvSatislar.GetFocusedRowCellValue(colFaturaTutari));
            FisBilgleri.YaziciAdi = YaziciAdi1;
            th_Yazdir = new Thread(new ParameterizedThreadStart(YazdirThreadi));

            th_Yazdir.Start(FisBilgleri);
        }
        private void btnYazici2_Click(object sender, EventArgs e)
        {
            if (gvSatislar.RowCount == 0)
            {
                return;
            }

            FisBilgleri.Barkod = gvSatislar.GetFocusedRowCellValue(colFaturaBarkod).ToString();
            FisBilgleri.Tarih = Convert.ToDateTime(gvSatislar.GetFocusedRowCellValue(colFaturaTarihi));
            FisBilgleri.Tutar = Convert.ToDecimal(gvSatislar.GetFocusedRowCellValue(colFaturaTutari));
            FisBilgleri.YaziciAdi = YaziciAdi2;
            th_Yazdir = new Thread(new ParameterizedThreadStart(YazdirThreadi));

            th_Yazdir.Start(FisBilgleri);


            //this.TopMost = true;
            //this.TopMost = false;

            //this.Show();
            //this.Activate();
        }
        public class csMusteriFisBilgileri
        {
            public string Barkod { get; set; }
            public DateTime Tarih { get; set; }
            public decimal Tutar { get; set; }
            public string YaziciAdi { get; set; }
            csMusteriFisBilgileri(string _Barkod, DateTime _Tarih, decimal _Tutar)
            {
                Barkod = _Barkod;
                Tarih = _Tarih;
                Tutar = _Tutar;
            }
            public csMusteriFisBilgileri()
            { }
        }
        object YazdirmaThreadiIcin = new object();

        public void YazdirThreadi(object FisBilgileri)
        {
            lock (YazdirmaThreadiIcin)
            {
                //yazdirrr.ds = new DataSet();

                //yazdirrr.dt_ekle("Fatura");
                //yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaBarkod", ((csMusteriFisBilgileri)FisBilgileri).Barkod, System.Type.GetType("System.String"));
                //yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaTarihi", ((csMusteriFisBilgileri)FisBilgileri).Tarih, System.Type.GetType("System.DateTime"));
                //yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaTutari", ((csMusteriFisBilgileri)FisBilgileri).Tutar, System.Type.GetType("System.Decimal"));

                //BindingContext[yazdirrr.ds].EndCurrentEdit();
                yazdirrr.ds.Tables[0].Rows[0]["FaturaBarkod"] = ((csMusteriFisBilgileri)FisBilgileri).Barkod;
                yazdirrr.ds.Tables[0].Rows[0]["FaturaTarihi"] = ((csMusteriFisBilgileri)FisBilgileri).Tarih;
                yazdirrr.ds.Tables[0].Rows[0]["FaturaTutari"] = ((csMusteriFisBilgileri)FisBilgileri).Tutar;


                yazdirrr.Yazdirr(clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir, ((csMusteriFisBilgileri)FisBilgileri).YaziciAdi, 1);

                //if (System.Diagnostics.Process.GetProcessesByName("TeraziSatis").Length > 0)
                //    Application.OpenForms["TeraziSatis"].Activate();
                this.BringToFront();
                this.Focus();
            }
        }


        #endregion

        private void btnHakkinda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmHakkinda frm = new frmHakkinda())
            {
                frm.ShowDialog(this);
            }
        }

        private void barBtnStokBilgileri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clsTablolar.frmStokBilgileri stokBilgileri = new clsTablolar.frmStokBilgileri(SqlConnections.GetBaglanti());
            stokBilgileri.ShowDialog(this);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            try
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Çıkışa Basıldı");
                if (IkinciEkranAcik == true)
                    IkinciEkran.Close();
                formState.Restore(this);

                MikTarAlmaDurmu = false;

                //Satislarv2.SatislariGetirmeyiDurdur();
                //Satislarv2.th1.Join();
                Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private void frmTerazi_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MiktarAl.portuDurdurhamisina();
            }
            catch (Exception)
            {
                //MessageBox.Show("Kapanırken hata hamısına");
            }



            //th1.Suspend();
            //th1.DisableComObjectEagerCleanup();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {

        }

        private void gvSatisHareketleri_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;
        }

        frmPaketleme Paketleme;

        #region  MEnu Butonları
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;
                if (Paketleme == null || Paketleme.IsDisposed)
                {
                    Paketleme = new frmPaketleme(this);
                    Paketleme.ShowDialog(this);
                }
                else
                {
                    Paketleme.Visible = true;
                }
            }
            catch (Exception hata)
            {
                MesajGoster(hata.Message);
            }
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barCheckItem_ArkaPlanaDussun.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }

        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            formState.Restore(this);
        }

        private void btnSeciliUruneIndirim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // o anki aktif satış değişmemesi lazım
            {
                try
                {
                    if (gvSatisHareketleri.RowCount == 0)
                        return;
                    using (frmIndirim frm = new frmIndirim())
                    {
                        // DİREK KDV DAHİL FİYATI VEREMEYİZ ÇÜNKÜ BİR KERE İNDİRİM YAPILDIKTAN SONRA TEKRAR İNDİRİM DEĞİŞTİRMEK İSTENDİĞİNDE NORMAL FİYAT OLARAK KDVDAHİL FİYATI YANİ İNDİRİMLİ KDV DAİL FİYATI VERİRİ.
                        frm.txtNormalFiyat.EditValue = Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colAnaBirimFiyat)) + (Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colAnaBirimFiyat)) * Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colKdv)) / 100);
                        frm.txtIndirimYuzdesi.EditValue = Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colStokIskonto1));

                        frm.lblStokBilgileri.Text = gvSatisHareketleri.GetFocusedRowCellValue(colStokAdi).ToString();

                        if (DialogResult.Yes == frm.ShowDialog(this))
                        {
                            decimal IndirimYuzdesi = Convert.ToDecimal(frm.txtIndirimYuzdesi.EditValue);
                            gvSatisHareketleri.SetFocusedRowCellValue(colStokIskonto1, IndirimYuzdesi);
                        }
                    }
                    IndirimVarsaIskontoKolonunuGosterYoksaGosterme();
                }
                catch (Exception ex)
                {
                    MesajGoster(ex.Message);
                }
                finally
                {
                    KaydedileBilirMi = true;
                    btnKaydet_Click(null, null);
                }
            }
        }

        private void btnButunUrunlereIndirimUygula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
            {
                try
                {
                    if (gvSatisHareketleri.RowCount == 0)
                        return;
                    using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                    {
                        frm.labelControl1.Text = "Aktif satışın tüm ürünlerine indirim uygula \nDaha Sonra eklenen Stokları etkilemez.\nİndirimi iptal etmek için 0 girin";
                        if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
                            for (int i = 0; i < gvSatisHareketleri.RowCount; i++)
                            {
                                gvSatisHareketleri.SetRowCellValue(i, colStokIskonto1, Convert.ToDecimal(frm.textEdit1.EditValue));
                            }
                    }
                    IndirimVarsaIskontoKolonunuGosterYoksaGosterme();
                }
                catch (Exception ex)
                {
                    MesajGoster(ex.Message);
                }
                finally
                {
                    KaydedileBilirMi = true;
                    btnKaydet_Click(null, null);
                }

            }
        }

        private void btnButunUrunlereIndirimUygulaTutar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
            {
                try
                {
                    if (gvSatisHareketleri.RowCount == 0)
                        return;
                    using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                    {
                        frm.labelControl1.Text = "Aktif satışın tüm Istenilen Satis Tutarına ulaşması için indirim uygula \nDaha Sonra eklenen Stokları etkilemez.\n0 Girilirse Tüm Ürünlere %100 iskonto uygulanmış olur\n";
                        if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
                        {
                            decimal TumSatirlarinToplam_KdvDahilIndirimUygulanmamis = 0;
                            decimal ToplamMiktar = 0;
                            for (int i = 0; i < gvSatisHareketleri.RowCount; i++)
                            {
                                TumSatirlarinToplam_KdvDahilIndirimUygulanmamis +=
    (Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(i, colAnaBirimFiyat)) + (Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(i, colAnaBirimFiyat)) * Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(i, colKdv)) / 100)) * Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(i, colMiktar));

                                ToplamMiktar += Convert.ToDecimal(gvSatisHareketleri.GetRowCellValue(i, colMiktar));
                            }
                            decimal IndirimYuzdesi = ((100 * (TumSatirlarinToplam_KdvDahilIndirimUygulanmamis - Convert.ToDecimal(frm.textEdit1.EditValue))) / TumSatirlarinToplam_KdvDahilIndirimUygulanmamis);
                            for (int i = 0; i < gvSatisHareketleri.RowCount; i++)
                            {
                                gvSatisHareketleri.SetRowCellValue(i, colStokIskonto1, IndirimYuzdesi);
                            }
                        }
                    }
                    IndirimVarsaIskontoKolonunuGosterYoksaGosterme();
                }
                catch (Exception ex)
                {
                    MesajGoster(ex.Message);
                }
                finally
                {
                    KaydedileBilirMi = true;
                    btnKaydet_Click(null, null);
                }
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            satislaribirlestir(string.Empty);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.BackColor == System.Drawing.Color.Ivory)
            {
                System.Diagnostics.Process.Start("shutdown", "-s -f -t 1200");
                this.BackColor = System.Drawing.Color.HotPink;
                barButtonItem2.Caption = "Kapatmayı İptal Et";
            }
            else
            {
                System.Diagnostics.Process.Start("shutdown", "-a");
                this.BackColor = System.Drawing.Color.Ivory;
                barButtonItem2.Caption = "Bilgisayari 20 dk Sonra Kapat";
            }
        }

        private void barBtnCpuKullanimi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MesajGoster(string.Empty);
        }

        private void barBtnSatisiSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
            {
                if (gvSatisHareketleri.RowCount != 0)
                {
                    MesajGoster("satışın hareketleri varken satış silinemez");
                    return;
                }
                try
                {
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Satislarv2.SatisiSil(SqlConnections.GetBaglanti(), TrGenel, (int)gvSatislar.GetFocusedRowCellValue(colFaturaID));
                    TrGenel.Commit();
                    btnSatislariYenile_Click(null, null);
                }
                catch (Exception hata)
                {
                    try { TrGenel.Rollback(); }
                    catch (Exception) { }
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
            //bool Kilitlimi = false;
            //Monitor.Enter(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit, ref Kilitlimi);

            //{
            try
            {
                frmSiparis frm = new frmSiparis(-1);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MesajGoster(ex.Message);
            }
            finally
            {
                //if (Kilitlimi)
                //    Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
            }
        }

        private void barBtnSiparisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSiparisListesi frm = new frmSiparisListesi())
            {
                frm.SiparisiSatisaAktarma = SiparisiSatisaAktarma;
                frm.ShowDialog();
            }
        }

        private void barBtnSatisUstBilgisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barBtnProgramGuncelleme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("TeraziSatisBaslat2"))
                {
                    proc.Kill();
                }

                if (!Directory.Exists(Application.StartupPath + @"\TeraziGuncelleme"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\TeraziGuncelleme");
                }

                File.Copy(Application.StartupPath + @"\TeraziSatisGuncelleme.exe", Application.StartupPath + @"\TeraziGuncelleme\TeraziSatisGuncelleme.exe", true);
                File.Copy(Application.StartupPath + @"\TeraziSatisGuncelleme.pdb", Application.StartupPath + @"\TeraziGuncelleme\TeraziSatisGuncelleme.pdb", true);



                System.Diagnostics.Process.Start(Application.StartupPath + @"\TeraziGuncelleme\TeraziSatisGuncelleme.exe");
                Application.Exit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MiktarAl.Sifirla(); // bu teraziye komut göndermek içindi sanırım daha bununla ilgili bi çalışma yapomadın
        }
        #endregion
        private void gvSatisHareketleri_RowCountChanged(object sender, EventArgs e)
        {
            lblHareketSayisi.Text = gvSatisHareketleri.RowCount.ToString();
        }

        private void satislaribirlestir(string barkodNumarasi1)
        {
            bool locktaken = false;
            try
            {
                Monitor.Enter(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit, ref locktaken);

                clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Yazi);
                //frm.labelControl1.Text = "Aktif satışa eklenecek satışın barkod num arasını girin" + Environment.NewLine + "Barkod okuyucu ile giriş yapılabilir";
                frm.labelControl1.Text = string.Format("Aktif satışa eklenecek satışın barkod num arasını girin{0}Barkod okuyucu ile giriş yapılabilir", Environment.NewLine);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Satislarv2.SatislariBirlestir(SqlConnections.GetBaglanti(), TrGenel, gvSatislar.GetFocusedRowCellValue(colFaturaBarkod).ToString(), frm.textEdit1.Text);
                    TrGenel.Commit();


                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Satislarv2.SatisinAltToplamHesaplamalariniServerdanHesaplaveKaydet(SqlConnections.GetBaglanti(), TrGenel, (int)gvSatislar.GetFocusedRowCellValue(colFaturaID));
                    TrGenel.Commit();

                    AktifSatisiGuncelle();
                    Hesapla.AltToplamlariHesapla();
                }
            }
            catch (Exception hata)
            {
                MesajGoster("hatadır 93");
            }
            finally
            {
                if (locktaken)
                {
                    Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
                    SatislarV2Kilitleme_lockTaken = false;
                }
            }
        }

        private void btnAktifSatisaDigerSatisinHareketleriniEkle_Click(object sender, EventArgs e)
        {
            try
            {
                lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    if (gvSatislar.RowCount == 0)
                        return;

                    satislaribirlestir(gvSatislar.GetFocusedRowCellValue(colFaturaBarkod).ToString());


                }
            }
            catch (Exception hata)
            {
                try
                { TrGenel.Rollback(); }
                catch (Exception) { }
            }
        }

        private void btnSonrakiSayfa_Click(object sender, EventArgs e)
        {
            gvSatislar.MoveNextPage();
        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            gvSatislar.MovePrevPage();
        }

        clsTablolar.TeraziSatisClaslari.frmSatislar frmSatislar;

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            MiktarAl.MiktarAlmaDurumu = false;
            lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // burada hepsini kilitleyebiliriz hem teraziyi hem satışların gelmesini
            {
                try
                {
                    cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;
                    using (frmSatislar = new clsTablolar.TeraziSatisClaslari.frmSatislar(SqlConnections.GetBaglanti()))
                    {

                        formState.Maximize(frmSatislar);
                        frmSatislar.WindowState = FormWindowState.Maximized;
                        if (frmSatislar.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
                        {
                            KaydedileBilirMi = false;
                            if (!string.IsNullOrEmpty(frmSatislar.FaturaBarkod))
                            {
                                txtBarkodu.Text = frmSatislar.FaturaBarkod;
                                btnUrunMusteriAra_Click(null, null);
                            }
                            else
                            {
                                MesajGoster("Satışın Barkodu Yok");
                            }
                        }
                    }
                }
                catch (Exception hata)
                {
                    MesajGoster("btnMusteriler_Click burada hata oldu");
                }
                finally
                {
                    KaydedileBilirMi = true;
                    MiktarAl.MiktarAlmaDurumu = true;

                    //if (Satislarv2.th1.ThreadState != ThreadState.Running)
                    //    Satislarv2.ThreadiBaslat(SqlConnections.GetBaglantiIki());
                }
            }
        }

        private void gvSatislar_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {

        }

        void IndirimVarsaIskontoKolonunuGosterYoksaGosterme()
        {
            try
            {
                if (gvSatisHareketleri.RowCount != 0)
                    if (Hareketler.dt_FaturaHareketleri.Select("StokIskonto1 > 0", "StokIskonto1", DataViewRowState.CurrentRows).Length > 0)
                        colStokIskonto1.Visible = true;
                    else
                        colStokIskonto1.Visible = false;
            }
            catch (Exception hata)
            {
                MesajGoster("İlginç bir hata sittir et");
            }
        }


        private void gcSatisHareketleri_Click(object sender, EventArgs e)
        {

        }

        private void ceSatislariOtomatikYenile_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (checkEdit3.Checked == true)
            //    {
            //        SatislariGetirmeyeBasla();
            //        btnSatislariYenile.Enabled = false;
            //    }
            //    else
            //    {
            //        Satislarv2.SatislariGetirmeyiDurdur();
            //        btnSatislariYenile.Enabled = true;
            //    }
            //}
            //catch (Exception hata)
            //{
            //    HataDosyasiOlusturma("", hata);
            //    Mesagg("hatadır looooğ");
            //}
        }
        // bu hamısınıa dır lo
        private void btnSatislariYenile_Click(object sender, EventArgs e)
        {
            try
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "SatislariYenileyeTiklandi");
                KaydedileBilirMi = false;
                lock (Satislarv2.SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle)
                {
                    csTeraziLogs.LogYaz(csTeraziLogs.Grup.ThreadKilit, "SatislariYenileyeTiklandi Lock un içine girdi");
                    FaturaHareketleriniGetir = false; // burada bunu koyduk çünkü kontrol işlemi tamamlanana kadar satışın hareketlerini getirmesin
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Satislarv2.YeniEklenenVeDegisenSatislariGetirV2_OdemesiTamamlananVeyaSilinenSatislariCikar(SqlConnections.GetBaglanti(), TrGenel, Properties.Settings.Default.TeraziID);
                    TrGenel.Commit();
                    csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Satislari Sorunsuz Yeniledi");
                }
            }
            catch (Exception hata)
            {
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Hata, "Satışları yenilemeye çalışırken hata oldu");
                MesajGoster("Yenilenemedi");
            }
            finally
            {
                KaydedileBilirMi = true;
                FaturaHareketleriniGetir = true;
                AktifSatisiGuncelle();
                csTeraziLogs.LogYaz(csTeraziLogs.Grup.Grupsuz, "Satislari Yenile Finally bloğu da sorunsuz çalıştı");
            }
        }

        void AktifSatisiGuncelle()
        {
            if (gvSatislar.RowCount != 0) // bu hareketleri yeniler
            {
                KaydedileBilirMi = false; // sadece yenilediği için bişi kaydetmesine gerek yok hamısına
                HareketleriGetir((int)gvSatislar.GetFocusedRowCellValue(colFaturaID));
                gvSatislar_FocusedRowChanged(null, null);
                gvSatisHareketleri_CellValueChanged(null, null);
            }
            else
                HareketleriGetir(-1);
        }


        private void barBtnAyrintiYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //yazdirrr.ds.Tables. = Hareketler.dt_FaturaHareketleri.Copy();
            try
            {
                if (gvSatislar.RowCount == 0)
                    return;

                using (clsTablolar.Yazdirma.csYazdir YazdirDetay = new clsTablolar.Yazdirma.csYazdir())
                {
                    YazdirDetay.dt_ekle("Fatura");

                    YazdirDetay.dtAlanEkleVeriEkle("Fatura", "FaturaBarkod", string.Empty, System.Type.GetType("System.String"));
                    YazdirDetay.dtAlanEkleVeriEkle("Fatura", "FaturaTarihi", DBNull.Value, System.Type.GetType("System.DateTime"));
                    YazdirDetay.dtAlanEkleVeriEkle("Fatura", "FaturaTutari", DBNull.Value, System.Type.GetType("System.Decimal"));

                    YazdirDetay.ds.Tables[0].Rows[0]["FaturaBarkod"] = gvSatislar.GetFocusedRowCellValue(colFaturaBarkod);
                    YazdirDetay.ds.Tables[0].Rows[0]["FaturaTarihi"] = gvSatislar.GetFocusedRowCellValue(colFaturaTarihi);
                    YazdirDetay.ds.Tables[0].Rows[0]["FaturaTutari"] = gvSatislar.GetFocusedRowCellValue(colFaturaTutari);



                    YazdirDetay.dt_ekle("FaturaHareket");

                    YazdirDetay.dtAlanEkleVeriEkle("FaturaHareket", colKdvDahilToplam.FieldName, DBNull.Value, System.Type.GetType("System.Decimal"));
                    YazdirDetay.dtAlanEkleVeriEkle("FaturaHareket", colAltBirimKdvDahilFiyat.FieldName, DBNull.Value, System.Type.GetType("System.Decimal"));
                    YazdirDetay.dtAlanEkleVeriEkle("FaturaHareket", colAltBirimMiktar.FieldName, DBNull.Value, System.Type.GetType("System.Decimal"));
                    YazdirDetay.dtAlanEkleVeriEkle("FaturaHareket", colStokAltBirimAdi.FieldName, DBNull.Value, System.Type.GetType("System.String"));
                    YazdirDetay.dtAlanEkleVeriEkle("FaturaHareket", colFaturaHareketStokAdi.FieldName, DBNull.Value, System.Type.GetType("System.String"));
                    YazdirDetay.dtAlanEkleVeriEkle("FaturaHareket", colKdvDahilFiyat.FieldName, DBNull.Value, System.Type.GetType("System.Decimal"));


                    this.BindingContext[gcSatisHareketleri.DataSource].EndCurrentEdit();
                    //gvSatisHareketleri.UpdateCurrentRow();

                    foreach (var item in Hareketler.dt_FaturaHareketleri.Copy().AsEnumerable().Where(k => k.RowState != DataRowState.Deleted))
                    {
                        YazdirDetay.DtyaYeniSatirEkle("FaturaHareket");

                        int SonSatirIndex = YazdirDetay.ds.Tables["FaturaHareket"].Rows.Count - 1;

                        YazdirDetay.ds.Tables["FaturaHareket"].Rows[SonSatirIndex][colKdvDahilToplam.FieldName] = item[colKdvDahilToplam.FieldName];
                        YazdirDetay.ds.Tables["FaturaHareket"].Rows[SonSatirIndex][colAltBirimKdvDahilFiyat.FieldName] = item[colAltBirimKdvDahilFiyat.FieldName];
                        YazdirDetay.ds.Tables["FaturaHareket"].Rows[SonSatirIndex][colAltBirimMiktar.FieldName] = item[colAltBirimMiktar.FieldName];
                        YazdirDetay.ds.Tables["FaturaHareket"].Rows[SonSatirIndex][colStokAltBirimAdi.FieldName] = item[colStokAltBirimAdi.FieldName];
                        YazdirDetay.ds.Tables["FaturaHareket"].Rows[SonSatirIndex][colFaturaHareketStokAdi.FieldName] = item[colFaturaHareketStokAdi.FieldName];
                        YazdirDetay.ds.Tables["FaturaHareket"].Rows[SonSatirIndex][colKdvDahilFiyat.FieldName] = item[colKdvDahilFiyat.FieldName];
                    }
                    YazdirDetay.Yazdirr(Application.StartupPath + @"\Raporlar\FaturaDetayi.repx", clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir, YaziciAdi1);
                }
            }
            catch (Exception hata)
            {
                MesajGoster(hata.Message);
            }
        }

        private void btnOtomatikSabitTutarGir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cbtnTerazidekiSabitMiktariStokaAktar.Checked || (int)gvSatisHareketleri.GetFocusedRowCellValue(colBirim2ID) != 2)
                    return;

                lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    decimal OncekiTutar = Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colKdvDahilToplam));

                    decimal YeniTutar = 0;
                    if (OncekiTutar != 0)
                    {
                        if (OncekiTutar % (decimal.Parse("0,25")) != 0) // 1/100 10 gr ma denk gelir
                            YeniTutar = OncekiTutar - (OncekiTutar % (decimal.Parse("0,25")));
                        else
                            YeniTutar = OncekiTutar - (decimal.Parse("0,25"));

                        TutarGir(gvSatisHareketleri.GetFocusedDataSourceRowIndex(), YeniTutar, true);
                    }
                }
            }
            catch (Exception hata)
            {
                MesajGoster(hata.Message);
            }
        }

        private void btnOtomatikSabitMiktarGir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cbtnTerazidekiSabitMiktariStokaAktar.Checked || (int)gvSatisHareketleri.GetFocusedRowCellValue(colBirim2ID) != 2)
                    return;

                lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    decimal OncekiMiktar = Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colMiktar));

                    decimal YeniMiktar = 0;
                    if (OncekiMiktar != 0)
                    {
                        if (OncekiMiktar % (decimal.Parse("0,01")) != 0) // 1/100 10 gr ma denk gelir
                            YeniMiktar = OncekiMiktar - (OncekiMiktar % (decimal.Parse("0,01")));
                        else
                            YeniMiktar = OncekiMiktar - (decimal.Parse("0,01"));

                        MiktarGir(gvSatisHareketleri.GetFocusedDataSourceRowIndex(), YeniMiktar, true);
                    }
                }
            }
            catch (Exception hata)
            {
                MesajGoster(hata.Message);
            }
        }

        private void gvSatislar_RowCountChanged(object sender, EventArgs e)
        {
            if (gvSatislar.RowCount == 0)
            {
                HareketleriGetir(-1);
            }
        }

        private void txtTerazidekiMiktari_EditValueChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtKdvDahilFiyati.Text)))//  && cbtnTerazidekiSabitMiktariStokaAktar.Checked)
                txtAnlikTutar.EditValue = Convert.ToDecimal(txtTerazidekiMiktari.EditValue) * Convert.ToDecimal(txtKdvDahilFiyati.EditValue);
            else
                txtAnlikTutar.Text = string.Empty;
        }

        private void barBtnTeraziAyar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmTeraziAyar frm = new frmTeraziAyar())
            {
                frm.ShowDialog();
            }
        }

        private void btnDaraYonetimi_Click(object sender, EventArgs e)
        {
            clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);

            if (DialogResult.Yes == frm.ShowDialog())
            {
                DaraAl(Convert.ToDecimal(frm.textEdit1.EditValue));
            }
        }


        private void txtAnlikTutar_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void gvSatisHareketleri_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (chckbtnIskontoIslemleri.Checked)
            {

                switch (gvSatisHareketleri.FocusedColumn.FieldName)
                {
                    case "StokIskonto1":
                        {
                            colStokIskonto1.AppearanceCell.Options.HighPriority = false;
                            colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = true;
                            gvSatisHareketleri.Appearance.FocusedCell.BackColor = System.Drawing.Color.Green;
                        }
                        break;
                    case "AltBirimKdvDahilFiyat":
                        {
                            colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = false;
                            colStokIskonto1.AppearanceCell.Options.HighPriority = true;
                            gvSatisHareketleri.Appearance.FocusedCell.BackColor = System.Drawing.Color.Green;
                        }
                        break;
                    default:
                        colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = true;
                        colStokIskonto1.AppearanceCell.Options.HighPriority = true;
                        gvSatisHareketleri.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
                        //gvSatisHareketleri.Appearance.FocusedCell.BackColor = System.Drawing.Color.PaleGreen;
                        break;
                }
                //e.HighPriority = true

                //else
                //{
                //    colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = true;
                //    colStokIskonto1.AppearanceCell.Options.HighPriority = true;

                //    gvSatisHareketleri.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
                //}
            }
            else
            {
                gvSatisHareketleri.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
            }
        }

        private void chckbtnIskontoIslemleri_CheckedChanged(object sender, EventArgs e)
        {
            if (gvSatisHareketleri.RowCount == 0)
            {
                chckbtnIskontoIslemleri.Checked = false;
                return;
            }

            if (chckbtnIskontoIslemleri.Checked)
            {
                //Hesapla.AltToplamlariHesapla();
                colStokIskonto1.Visible = true;
                colKdvDahilStokIskonto1IndirimMiktari.Visible = true;
                colAltBirimKdvDahilIndirimHaricFiyat.Visible = true;
                splitContainerControl2.SplitterPosition = splitContainerControl2.Width;
                pcontrol_IskontoAyrintilari.Visible = true;
                txtFaturaTutari.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.PaleGreen;
                colAltBirimKdvDahilFiyat.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceCell.Options.HighPriority = true;
                colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = true;
            }
            else
            {
                colAltBirimKdvDahilIndirimHaricFiyat.Visible = false;
                colKdvDahilStokIskonto1IndirimMiktari.Visible = false;
                splitContainerControl2.SplitterPosition = 425;
                pcontrol_IskontoAyrintilari.Visible = false;
                txtFaturaTutari.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                colAltBirimKdvDahilFiyat.AppearanceCell.BackColor = System.Drawing.Color.White;
                colStokIskonto1.AppearanceCell.BackColor = System.Drawing.Color.White;
                colStokIskonto1.AppearanceCell.Options.HighPriority = false;
                colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = false;
            }
        }



        private void txtFaturaTutari_Click(object sender, EventArgs e)
        {
            if (chckbtnIskontoIslemleri.Checked)
            {
                lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    try
                    {
                        if (gvSatisHareketleri.RowCount == 0)
                            return;
                        KaydedileBilirMi = false;
                        Hesapla.ToplamFaturaTutariGirerekISkontoUygula(this);
                        IndirimVarsaIskontoKolonunuGosterYoksaGosterme();
                    }
                    catch (Exception ex)
                    {
                        MesajGoster(ex.Message);
                    }
                    finally
                    {
                        KaydedileBilirMi = true;
                        btnKaydet_Click(null, null);
                    }
                }
            }
        }

        private void txtIndirimMiktari_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtIndirimMiktari_Click(object sender, EventArgs e)
        {
            if (chckbtnIskontoIslemleri.Checked && gvSatisHareketleri.RowCount != 0)
            {
                try
                {
                    lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // o anki aktif satış değişmemesi lazım
                    {
                        using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(Convert.ToDecimal(txtIndirimMiktari.EditValue), clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                        {
                            frm.labelControl1.Text = "İstenilen Toplam İndirim Miktarı";
                            if (frm.ShowDialog() == DialogResult.Yes)
                            {
                                decimal IndirimMiktari = Convert.ToDecimal(frm.textEdit1.EditValue);
                                //decimal IndirimYuzdesi = IndirimMiktari / KdvDahilIndirimUygulanmamisFaturaTutari() * 100;
                                decimal IndirimYuzdesi = IndirimMiktari / Hesapla.ToplamKdvDahilIndirimsizSatisTutari * 100;

                                KaydedileBilirMi = false;

                                for (int i = 0; i < gvSatisHareketleri.RowCount; i++)
                                {
                                    gvSatisHareketleri.SetRowCellValue(i, colStokIskonto1, IndirimYuzdesi);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    KaydedileBilirMi = true;
                    btnKaydet_Click(null, null);
                }
            }
        }

        private void txtIndirimYuzdesi_Click(object sender, EventArgs e)
        {
            if (chckbtnIskontoIslemleri.Checked && gvSatisHareketleri.RowCount != 0)
            {

                try
                {
                    lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // o anki aktif satış değişmemesi lazım
                    {
                        using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(Convert.ToDecimal(txtIndirimYuzdesi.EditValue), clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                        {
                            frm.labelControl1.Text = "Tüm satış için indirim Yuzdesi";
                            if (frm.ShowDialog() == DialogResult.Yes)
                            {
                                decimal IndirimYuzdesi = Convert.ToDecimal(frm.textEdit1.EditValue);

                                KaydedileBilirMi = false;

                                for (int i = 0; i < gvSatisHareketleri.RowCount; i++)
                                {
                                    gvSatisHareketleri.SetRowCellValue(i, colStokIskonto1, IndirimYuzdesi);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    KaydedileBilirMi = true;
                    btnKaydet_Click(null, null);
                }
            }
        }

        private void gvSatisHareketleri_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (chckbtnIskontoIslemleri.Checked)
            {
                if (e.Column == colStokIskonto1)
                {
                    try
                    {
                        lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // o anki aktif satış değişmemesi lazım
                        {
                            using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colStokIskonto1)), clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                            {
                                frm.labelControl1.Text = gvSatisHareketleri.GetFocusedRowCellValue(colStokAdi).ToString() + "\nürüne yüzde indirim uygular";
                                if (frm.ShowDialog() == DialogResult.Yes)
                                {
                                    decimal IndirimYuzdesi = Convert.ToDecimal(frm.textEdit1.EditValue);

                                    KaydedileBilirMi = false;
                                    gvSatisHareketleri.SetFocusedRowCellValue(colStokIskonto1, IndirimYuzdesi);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        KaydedileBilirMi = true;
                        btnKaydet_Click(null, null);
                    }
                }
                else if (e.Column == colAltBirimKdvDahilFiyat)
                {
                    try
                    {
                        lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // o anki aktif satış değişmemesi lazım
                        {
                            using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colAltBirimKdvDahilFiyat)), clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                            {
                                frm.labelControl1.Text = gvSatisHareketleri.GetFocusedRowCellValue(colStokAdi).ToString() + "\nstokun olmasını istediğin fiyatını yaz";
                                if (frm.ShowDialog() == DialogResult.Yes)
                                {
                                    decimal IndirimliFiyat = Convert.ToDecimal(frm.textEdit1.EditValue);
                                    decimal AltBirimKdvDahilIndirimHaricFiyat = Convert.ToDecimal(gvSatisHareketleri.GetFocusedRowCellValue(colAltBirimKdvDahilIndirimHaricFiyat));
                                    decimal IndirimYuzdesi = 100 * ((AltBirimKdvDahilIndirimHaricFiyat - IndirimliFiyat) / AltBirimKdvDahilIndirimHaricFiyat);
                                    KaydedileBilirMi = false;
                                    gvSatisHareketleri.SetFocusedRowCellValue(colStokIskonto1, IndirimYuzdesi);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        KaydedileBilirMi = true;
                        btnKaydet_Click(null, null);
                    }

                }
            }
        }

        private void btnYazici2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (YeniMusterininFisiniYaziciIkidenOtomatikYazdir == false)
                {
                    btnYazici2.Image = TeraziSatis.Properties.Resources.defaultprinter_32x32;
                    YeniMusterininFisiniYaziciIkidenOtomatikYazdir = true;
                }
                else
                {
                    btnYazici2.Image = TeraziSatis.Properties.Resources.printer_32x32;
                    YeniMusterininFisiniYaziciIkidenOtomatikYazdir = false;
                }
            }
        }


        bool YeniMusterininFisiniYaziciBirdenOtomatikYazdir = false;
        bool YeniMusterininFisiniYaziciIkidenOtomatikYazdir = false;

        private void btnYazici2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnYaziciBir_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnYaziciBir_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (YeniMusterininFisiniYaziciBirdenOtomatikYazdir == false)
                {
                    btnYaziciBir.Image = TeraziSatis.Properties.Resources.defaultprinter_32x32;
                    YeniMusterininFisiniYaziciBirdenOtomatikYazdir = true;
                }
                else
                {
                    btnYaziciBir.Image = TeraziSatis.Properties.Resources.printer_32x32;
                    YeniMusterininFisiniYaziciBirdenOtomatikYazdir = false;
                }
            }
        }

        private void gvSatisHareketleri_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
