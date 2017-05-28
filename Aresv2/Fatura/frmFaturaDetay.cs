using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;


namespace Aresv2.Fatura
{
    public partial class frmFaturaDetay : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Yeni Bir Fatura açılıyorsa Fatura Tipi ve Cari ID bildir
        /// </summary>
        /// <param name="FaturaTipi">Faturanın Tipi:  Satis Fatura = 1, Alis Fatura = 2, Satis Iade = 3, Alis Iade = 4</param>
        /// <param name="CariID">Eğer hangi cariye kesileceği belli ise CariID belli değilse -1 ver</param>
        public frmFaturaDetay(clsTablolar.IslemTipi FaturaTipi, int CariID)
        {
            InitializeComponent();
            _FaturaTipi = FaturaTipi;
            _CariID = CariID;
        }
        /// <summary>
        /// Kaydedilmiş bir fatura ise FaturaID ver, Yeni Fatura için kullanılmaz!!!
        /// </summary>
        /// <param name="FaturaID"></param>
        public frmFaturaDetay(int FaturaID)
        {
            InitializeComponent();
            _FaturaID = FaturaID;
        }

        int _CariID = -1;
        int _FaturaID = -1; // burası önemli kalsın
        clsTablolar.IslemTipi _FaturaTipi;


        #region CLSTablolardan gelenler

        clsTablolar.Fatura.csFatura Fatura;
        public clsTablolar.Fatura.csFaturaHareket FaturaHareket;

        csFiyatTanim FiyatTanimlari = new csFiyatTanim();
        clsTablolar.Stok.csStokunBirimleri StokunBirimleri;
        csNumaraVer NumaraVer;
        clsTablolar.Stok.csStokBirimTanimlari BirimTanimlari = new clsTablolar.Stok.csStokBirimTanimlari();
        clsTablolar.cari.csCariv2 _Cari;
        clsTablolar.Stok.csStok YeniStok;
        clsTablolar.Fatura.csFaturaGrup FaturaGrup = new clsTablolar.Fatura.csFaturaGrup();

        #endregion

        SqlTransaction trGenel;

        Stok.frmStokFiyatKarsilastirma FiyatKarsilastirma;
        clsTablolar.csFatura_Irsaliye_Teklif_Hesapla Hesaplamalar;

        clsTablolar.EvrakIliski.csEvrakIliski EvrakIliskileri = new clsTablolar.EvrakIliski.csEvrakIliski();

        #region Cari Bul

        // Nereden bulur bu cari bilgileri carilisteden, dahası cari listenin içindeki delegeye gönderilir cari listede tamam a tıklanınca bu kodlar çalışır.
        void CariAktar(int CariID)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                _Cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), trGenel, CariID);
                // Burada sadece CariID yi Fatura class ına yazıyoruzki carinin ID si clasa yazılsın diğerlerini textbox lardan
                Fatura.CariID = CariID;
                txtVergiNo.EditValue = _Cari.VergiNumarasi;
                txtVergiDairesi.EditValue = _Cari.VergiDairesi;

                txtUnvan.EditValue = _Cari.CariTanim;

                //txtIlce.EditValue = row["IlceAdi"].ToString();
                //txtIl.EditValue = row["SehirAdi"].ToString();

                txtCariKodu.EditValue = _Cari.CariKod;
                txtVergiDairesi.EditValue = _Cari.VergiDairesi;
                txtVergiNo.EditValue = _Cari.VergiNumarasi;
                if (Fatura.FaturaTipi == IslemTipi.SatisFaturasi) // caride sadece satış faturası için fiyat tanımı var.
                    Fatura.KullanilanFiyatTanimID = _Cari.CariFiyatTanimID;


                this.BindingContext[Fatura].EndCurrentEdit();

                //Fatura.Cari_Isk_Orani_4 = Convert.ToDecimal(row["iskOrani1"]); // Caride iskonto oranı 4 diye bişi yok bu iskonto yu iler de başka bir yerden getireceksin şimdilik 0 olarak bırak Aynı zamanda iskontoların bağlı olduğu bütün textbox ların null değerlerini 0 olacak şekilde ayarla.
                AdresGetirVarsayilan(CariID);
                trGenel.Commit();

            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void BtnCariBul_Click(object sender, EventArgs e)
        {
            frmCariListe frmCariListe = new frmCariListe();
            frmCariListe.Text = "Cari Seçim";
            frmCariListe._CariIDVer = CariAktar; // delegeye Cari Bul u atıyoruz.
            frmCariListe.ShowDialog();
        }

        private void btnCariKartAc_Click(object sender, EventArgs e)
        {
            Cari.frmCariDetay CariKart = new Cari.frmCariDetay(Fatura.CariID);
            CariKart.MdiParent = this.MdiParent;
            CariKart.Show();
        }

        #endregion

        private void frmFaturaKarti_Load(object sender, EventArgs e)
        {
            //splitContainerControl1.SplitterPosition = xtraTabControl1.Size.Height; // farklı ekran çözünürlüğü için
            //splitContainerControl2.SplitterPosition = xtraTabControl2.Size.Height;

            try
            {
                FaturayiYukle();
                #region FORM BAŞLIĞI AYARLANIYOR. // bu başlık ayaarla ne hamısına bunu değiştir.
                clsTablolar.FormBaslik BaslikAyarla = new clsTablolar.FormBaslik();

                this.Text = BaslikAyarla.FormBaslikDon(Convert.ToInt32(Fatura.FaturaTipi));


                #endregion

                //KdvDetayHesapla();
                GridArayuzIslemleri(enGridArayuzIslemleri.Get);
                GridIcinOzelAyarlar();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
            NesneleriBinleHamisina();
            KapaliFaturaHareketleriniGetir();

            for (int i = 0; i < xtraTabControl1item.TabPages.Count; i++)
            {
                xtraTabControl1item.SelectedTabPage = xtraTabControl1item.TabPages[i];
            }
            xtraTabControl1item.SelectedTabPage = xtraTabControl1item.TabPages[0];

            Kaydet_Vazgec_Sil_Enable(false);
        }

        private void GridIcinOzelAyarlar()
        {
            // amk ayarların bir kısmını burada bir kısmın gridten yaptın ilerde basit bir hata için çok uğraşıcaksın

            // Kullanıcının göremiyeceği alanlar
            colKatSayi.Visible = false;
            colBirim2ID.Visible = false;
            colStokID.Visible = false;
            colDepoID.Visible = false;
            colStokAnaBirimID.Visible = false;
            colFaturaHareketID.Visible = false;
            colFaturaID.Visible = false;

            colSatirNo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void FaturayiYukle()
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                if (_FaturaID == -1) // yeni fatura ise
                {
                    deFaturaTarihi.DateTime = DateTime.Now;
                    deFaturaVadesi.DateTime = DateTime.Now;
                    deDuzenlemeTarihi.DateTime = DateTime.Now;
                    Fatura = new clsTablolar.Fatura.csFatura(SqlConnections.GetBaglanti(), trGenel, _FaturaTipi, _CariID);


                    // bunları yeni fatura ise yapıcak eski fatura ise bu ayarlar kendisinde mevcut
                    if (Fatura.FaturaTipi == IslemTipi.AlisFaturasi)
                    {
                        lkpDepo.EditValue = clsTablolar.Ayarlar.csAyarlar.AlisFaturasiDepoID;
                        Fatura.DepoID = clsTablolar.Ayarlar.csAyarlar.AlisFaturasiDepoID;
                        Fatura.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.AlisFaturasiFiyatTanimID;
                    }
                    else if (Fatura.FaturaTipi == IslemTipi.SatisFaturasi)
                    {
                        lkpDepo.EditValue = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiDepoID;
                        Fatura.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID;
                        Fatura.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID;
                    }
                    else if (Fatura.FaturaTipi == IslemTipi.AlisIadeFaturasi)
                    {
                        lkpDepo.EditValue = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiDepoID;
                        Fatura.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID;
                        Fatura.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID;
                    }
                    else if (Fatura.FaturaTipi == IslemTipi.SatisIadeFaturasi)
                    {
                        lkpDepo.EditValue = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiDepoID;
                        Fatura.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID;
                        Fatura.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID;
                    }

                }
                else // kayıtlı fatura ise
                {
                    Fatura = new clsTablolar.Fatura.csFatura(SqlConnections.GetBaglanti(), trGenel, _FaturaID);
                }

                lkpFaturaGrubu.Properties.DataSource = FaturaGrup.FaturaGrup(SqlConnections.GetBaglanti(), trGenel);

                lkpFaturaGrubu.Properties.DisplayMember = "FaturaGrupAdi";
                lkpFaturaGrubu.Properties.ValueMember = "FaturaGrupID";





                EvrakiliskileriniGetir();
                FaturaHareket = new clsTablolar.Fatura.csFaturaHareket();
                FaturaHareket.FaturaHareketleriniGetir(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaID);

                Hesaplamalar = new clsTablolar.csFatura_Irsaliye_Teklif_Hesapla(FaturaHareket.dt_FaturaHareketleri, gvFaturaHareket);
                Hesaplamalar.AltToplamlarDegisti = AltToplamlariAl;

                gcFaturaHareket.DataSource = FaturaHareket.dt_FaturaHareketleri;

                gcKdvDetaylari.DataSource = Hesaplamalar.dt_kdv;
                gcIskontoDetaylari.DataSource = Hesaplamalar.dt_IskontoDetay;


                // TODO: Burada satış faturasına göre veya alış faturasına göre ayarlar gelecek bitane
                // if konarak alış mı satış mı olduğu saptanmalı

                lkpKullanilanFiyatTanimi.Properties.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), trGenel, false);
                lkpKullanilanFiyatTanimi.Properties.DisplayMember = "FiyatTanimAdi";
                lkpKullanilanFiyatTanimi.Properties.ValueMember = "FiyatTanimID";



                Kaydet_Vazgec_Sil_Enable(true);
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void NesneleriBinleHamisina()
        {
            try
            {
                // yukarıda 2 farklı şekilde türetme imkanın olan faturayı burada alanlara al
                #region DataBindings.Clear()
                deFaturaTarihi.DataBindings.Clear();
                deDuzenlemeTarihi.DataBindings.Clear();
                txtFaturaNo.DataBindings.Clear();

                txtUnvan.DataBindings.Clear();
                txtCariKodu.DataBindings.Clear();

                memoAdres.DataBindings.Clear();

                txtIl.DataBindings.Clear();
                txtIlce.DataBindings.Clear();

                deFaturaVadesi.DataBindings.Clear();

                txtVergiDairesi.DataBindings.Clear();
                txtVergiNo.DataBindings.Clear();

                txtToplamIndirim.DataBindings.Clear();
                txtToplamKDV.DataBindings.Clear();
                txtToplam_Iskontosuz_Kdvsiz.DataBindings.Clear();

                memoNot.DataBindings.Clear();
                lkpDepo.DataBindings.Clear();
                lkpSatisElemani.DataBindings.Clear();

                txtToplamKDV.DataBindings.Clear();
                txtToplam_Iskontosuz_Kdvsiz.DataBindings.Clear();
                txtFaturaTutari.DataBindings.Clear();
                txtStokIskontoToplami.DataBindings.Clear();
                txtCariIskontoToplami.DataBindings.Clear();
                txtAraToplam.DataBindings.Clear();
                lkpKullanilanFiyatTanimi.DataBindings.Clear();
                lkpFaturaGrubu.DataBindings.Clear();
                txtFaturaBarkodu.DataBindings.Clear();
                checkEdit1.DataBindings.Clear();
                checkEdit2.DataBindings.Clear();
                txtFaturaBarkod.DataBindings.Clear();
                #endregion



                deFaturaTarihi.DataBindings.Add("DateTime", Fatura, "FaturaTarihi", false, DataSourceUpdateMode.OnPropertyChanged);
                deDuzenlemeTarihi.DataBindings.Add("DateTime", Fatura, "DuzenlemeTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
                txtFaturaNo.DataBindings.Add("EditValue", Fatura, "FaturaNo", true, DataSourceUpdateMode.OnPropertyChanged);

                txtUnvan.DataBindings.Add("EditValue", Fatura, "CariTanim", true, DataSourceUpdateMode.OnPropertyChanged);
                txtCariKodu.DataBindings.Add("EditValue", Fatura, "CariKod", true, DataSourceUpdateMode.OnPropertyChanged);

                memoAdres.DataBindings.Add("EditValue", Fatura, "Adres", true, DataSourceUpdateMode.OnPropertyChanged);
                txtIl.DataBindings.Add("EditValue", Fatura, "Il", true, DataSourceUpdateMode.OnPropertyChanged);
                txtIlce.DataBindings.Add("EditValue", Fatura, "Ilce", true, DataSourceUpdateMode.OnPropertyChanged);

                deFaturaVadesi.DataBindings.Add("DateTime", Fatura, "Vadesi", true, DataSourceUpdateMode.OnPropertyChanged);

                txtVergiDairesi.DataBindings.Add("EditValue", Fatura, "VergiDairesi", true, DataSourceUpdateMode.OnPropertyChanged);
                txtVergiNo.DataBindings.Add("EditValue", Fatura, "VergiNo", true, DataSourceUpdateMode.OnPropertyChanged);

                txtToplamIndirim.DataBindings.Add("EditValue", Fatura, "ToplamIndirim", true, DataSourceUpdateMode.OnPropertyChanged);
                txtToplamKDV.DataBindings.Add("EditValue", Fatura, "ToplamKdv", true, DataSourceUpdateMode.OnPropertyChanged);
                txtToplam_Iskontosuz_Kdvsiz.DataBindings.Add("EditValue", Fatura, "Toplam_Iskontosuz_Kdvsiz", true, DataSourceUpdateMode.OnPropertyChanged);
                txtStokIskontoToplami.DataBindings.Add("EditValue", Fatura, "StokIskontoToplami", true, DataSourceUpdateMode.OnPropertyChanged);
                txtCariIskontoToplami.DataBindings.Add("EditValue", Fatura, "CariIskontoToplami", true, DataSourceUpdateMode.OnPropertyChanged);
                txtFaturaTutari.DataBindings.Add("EditValue", Fatura, "FaturaTutari", true, DataSourceUpdateMode.OnPropertyChanged);
                txtAraToplam.DataBindings.Add("EditValue", Fatura, "IskontoluToplam", true, DataSourceUpdateMode.OnPropertyChanged);

                memoNot.DataBindings.Add("EditValue", Fatura, "Aciklama", true, DataSourceUpdateMode.OnPropertyChanged);

                lkpDepo.DataBindings.Add("EditValue", Fatura, "DepoID", true, DataSourceUpdateMode.OnPropertyChanged);
                lkpDepo.Properties.DataSource = Fatura.Depo.dt_Depo;
                lkpDepo.Properties.PopulateColumns();
                lkpDepo.Properties.ValueMember = "DepoID";
                lkpDepo.Properties.DisplayMember = "DepoAdi";

                lkpSatisElemani.DataBindings.Add("EditValue", Fatura, "SatisElemaniID", true, DataSourceUpdateMode.OnPropertyChanged);

                lkpSatisElemani.Properties.DataSource = Fatura.SatisPersoneli.SatistaGorevliPersonelListesi(SqlConnections.GetBaglanti());
                lkpSatisElemani.Properties.PopulateColumns();
                lkpSatisElemani.Properties.ValueMember = "PersonelID";
                lkpSatisElemani.Properties.DisplayMember = "CariTanim";

                lkpKullanilanFiyatTanimi.DataBindings.Add("EditValue", Fatura, "KullanilanFiyatTanimID", true, DataSourceUpdateMode.OnPropertyChanged);
                lkpFaturaGrubu.DataBindings.Add("EditValue", Fatura, "FaturaGrupID", true, DataSourceUpdateMode.OnPropertyChanged);

                txtFaturaBarkodu.DataBindings.Add("EditValue", Fatura, "FaturaBarkod", true, DataSourceUpdateMode.OnPropertyChanged);
                checkEdit1.DataBindings.Add("Checked", Fatura, "HizliSatistaGozukecekMi", true, DataSourceUpdateMode.OnPropertyChanged);
                checkEdit2.DataBindings.Add("Checked", Fatura, "HizliSatistaDegisiklikYapilmasinaIzniVarMi", true, DataSourceUpdateMode.OnPropertyChanged);

                txtFaturaBarkod.DataBindings.Add("EditValue", Fatura, "FaturaBarkod", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void EvrakiliskileriniGetir()
        {
            if (Fatura.FaturaID == -1) return;

            EvrakIliskileri.FaturadanEvrakIliskiGetir(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaID);
            gcEvrakIiski.DataSource = EvrakIliskileri.dt;
        }

        private void lkpBirim2_Doldur(string stokID)
        {
            try
            {
                //csStok üstünde sen güncelleme yaptığın için şimdilik buraya yazıyorum. birleştirirken, istersek class a taşıyabiliriz.
                using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT SB.BirimID, SB.BirimAdi FROM dbo.StokBirimCevrim AS SBC INNER JOIN dbo.Stok AS S ON SBC.StokID = S.StokID INNER JOIN dbo.StokBirim AS SB ON SBC.BirimID = SB.BirimID WHERE     (S.StokID = @StokID)", SqlConnections.GetBaglanti()))
                {
                    da.SelectCommand.Transaction = trGenel;
                    da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = stokID;
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    //lkpBirim2.Properties.DataSource = dt;
                    //lkpBirim2.Properties.PopulateColumns();
                    //lkpBirim2.Properties.ValueMember = "BirimID";
                    //lkpBirim2.Properties.DisplayMember = "BirimAdi";
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        void AdresGetirVarsayilan(int CariIDD)
        {
            clsTablolar.cari.csAdresVarsayilanGetir AdresVarsayilan = new clsTablolar.cari.csAdresVarsayilanGetir(SqlConnections.GetBaglanti(), trGenel, CariIDD);
            memoAdres.Text = AdresVarsayilan.Adres;
            txtIl.Text = AdresVarsayilan.IlceAdi;
            txtIlce.Text = AdresVarsayilan.SehirAdi;
        }

        private void cbtnNumaraGetir_Click(object sender, EventArgs e)
        {
            //NumaraSablon.frmNumaraSablonListesi frmNumaraSablonListesi = new NumaraSablon.frmNumaraSablonListesi();
            //frmNumaraSablonListesi.ShowDialog();
        }




        # region Stok Ekleme Degistirme İşlemleri


        // TODO: Stok ekle ve stok değiştir için birleşik bişiler karala anladın inşallah hamısına
        /// <summary>
        /// Başka bir formdan veya entegrasyondan buraya stok eklenebilmesi için lazım
        /// </summary>
        /// <param name="StokID"></param>
        /// <param name="Miktar"></param>
        public void StokEkle(int StokID, decimal Miktar)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, StokID);

                FaturaHareket.dt_FaturaHareketleri.Rows.Add(FaturaHareket.dt_FaturaHareketleri.NewRow());
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokID"] = YeniStok.StokID;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokAnaBirimID"] = YeniStok.StokBirimID;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokAnaBirimAdi"] = YeniStok.StokAnaBirimAdi;

                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokAdi"] = YeniStok.StokAdi;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokKodu"] = YeniStok.StokKodu;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["FaturaHareketStokAdi"] = YeniStok.StokAdi;

                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = Miktar;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["Kdv"] = YeniStok.SatisKdv;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["DepoID"] = lkpDepo.EditValue.ToString();

                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto1"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto2"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto3"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto1"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto2"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto3"] = 0;


                // Alt Birim İle İlgili Ayarları Koyuyoruz hamısına
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["KatSayi"] = 1;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["Birim2ID"] = YeniStok.StokBirimID;

                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokAltBirimAdi"] = YeniStok.StokAnaBirimAdi;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["BirlesikUrunHareketID"] = -2; // -2 olunca ne oluyrdu bunu yaz


                decimal Fiyat = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), trGenel, Fatura.KullanilanFiyatTanimID, YeniStok.StokID);
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1][colAnaBirimFiyat.FieldName] = Fiyat;

                lkpBirim2_Doldur(YeniStok.StokID.ToString());
                gvFaturaHareket.BestFitColumns();
                Hesaplamalar.SatirHesaplamasi(FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]);
                SatirNumaralariniOlustur();
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void StokDegistir(DataRow Stok, decimal Miktar)
        {
            try
            {
                //FaturaHareket.dt_FaturaHareketleri.Rows.Add(FaturaHareket.dt_FaturaHareketleri.NewRow());
                FaturaHareket.dt_FaturaHareketleri.Rows[gvFaturaHareket.FocusedRowHandle]["StokID"] = Stok["StokID"];
                FaturaHareket.dt_FaturaHareketleri.Rows[gvFaturaHareket.FocusedRowHandle]["Birim1ID"] = Stok["StokBirimID"];
                FaturaHareket.dt_FaturaHareketleri.Rows[gvFaturaHareket.FocusedRowHandle]["StokAdi"] = Stok["StokAdi"];
                FaturaHareket.dt_FaturaHareketleri.Rows[gvFaturaHareket.FocusedRowHandle]["Birim1"] = Stok["BirimAdi"];
                FaturaHareket.dt_FaturaHareketleri.Rows[gvFaturaHareket.FocusedRowHandle]["Miktar1"] = Miktar;
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            Stok.frmStokListesi StokArama = new Stok.frmStokListesi(true);
            StokArama.Stok_Sec = StokEkle;
            StokArama.ShowDialog();
            gvFaturaHareket.FocusedRowHandle = gvFaturaHareket.RowCount - 1;
            gvFaturaHareket.FocusedColumn = colMiktar;
            gvFaturaHareket.ShowEditor();
        }

        private void btnStokCikar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvFaturaHareket.RowCount == 0) return;
                if (XtraMessageBox.Show("satırı silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                //gvFaturaHareket.DeleteSelectedRows();
                //FaturaHareket.dt_FaturaHareketleri.Rows.RemoveAt(gvFaturaHareket.FocusedRowHandle);
                gvFaturaHareket.DeleteSelectedRows();
                //FaturaHareket.dt_FaturaHareketleri.Rows[gvFaturaHareket.FocusedRowHandle].Delete();
                //SatirNumaralariniOlustur();
                Hesaplamalar.AltToplamlariHesapla();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        #endregion

        #region Kaydet Vazgeç Sil

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                #region BOŞ ALAN KONTROLÜ
                foreach (DataRow row in FaturaHareket.dt_FaturaHareketleri.AsEnumerable())
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (row["AnaBirimFiyat"].ToString() == "")
                        {
                            XtraMessageBox.Show("Birim Fiyat girişi yapılmamış satır var.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                if (gvFaturaHareket.RowCount == 0)
                {
                    XtraMessageBox.Show("Stok seçiniz.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFaturaNo.Focus();
                    return;
                }
                //if (txtFaturaNo.Text == "")
                //{
                //  XtraMessageBox.Show("Fatura Numarasını giriniz.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  txtFaturaNo.Focus();
                //  return;
                //}
                if (txtUnvan.Text == "" || Fatura.CariID == -1)
                {
                    XtraMessageBox.Show("Cari seçiniz.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUnvan.Focus();
                    return;
                }
                if (lkpDepo.EditValue == null || lkpDepo.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Depo seçiniz", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lkpDepo.Focus();
                    return;
                }

                #endregion

                #region Fiyat Analiz e gönder - Fiyat Karşılaştırma

                if (Fatura.FaturaTipi == IslemTipi.AlisFaturasi)
                {
                    if (DialogResult.Yes == MessageBox.Show("Fiyatları Karşılaştırması yapmak istiyor musunuz??", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        FiyatKarsilastirma = new Stok.frmStokFiyatKarsilastirma(Stok.frmStokFiyatKarsilastirma.NeIcin.Faturadan);
                        FiyatKarsilastirma.MdiParent = this.MdiParent;
                        FiyatKarsilastirma.Show();
                        foreach (var item in FaturaHareket.dt_FaturaHareketleri.AsEnumerable())
                        {
                            FiyatKarsilastirma.StokEkleFaturadan((int)item["StokID"], (decimal)item["IskontoluFiyat"]);
                        }
                    }
                }
                #endregion

                this.BindingContext[gcFaturaHareket.DataSource].EndCurrentEdit();
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                #region FATURA TABLOSUNA KAYDEDİLİYOR.

                if (Fatura.FaturaID == -1 && Fatura.FaturaNo == "")
                {
                    NumaraVer = new csNumaraVer();
                    txtFaturaNo.EditValue = NumaraVer.VarsayilanNumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaTipi);
                }

                #region Fatura No daha önce kaydedilmiş mi kontrolü yapılıyor.
                bool cevap = false;
                using (SqlCommand cmd = new SqlCommand("Select  FaturaID From Fatura Where FaturaNo = @FaturaNo AND FaturaID <> @FaturaID and FaturaTipi = @FaturaTipi and CariID = @CariID", SqlConnections.GetBaglanti(), trGenel))
                {
                    cmd.Parameters.Add("@FaturaNo", SqlDbType.NVarChar).Value = txtFaturaNo.Text;
                    cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = Fatura.FaturaID;
                    cmd.Parameters.Add("@FaturaTipi", SqlDbType.Int).Value = Fatura.FaturaTipi;
                    cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = Fatura.CariID;

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                        cevap = dr.Read();
                }
                if (cevap)
                {
                    MessageBox.Show("Fatura No zaten kullanılıyor.");
                    trGenel.Rollback();
                    txtFaturaNo.Focus();
                    return;
                }
                #endregion

                //int TempFaturaID = Fatura.FaturaID;

                if (Fatura.FaturaID == -1)
                {

                }
                _FaturaID = Fatura.FaturaKaydet(SqlConnections.GetBaglanti(), trGenel);
                FaturaHareket.FaturaHareketleriniKaydet(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaID);

                EvrakIliskileri.FaturaIcinEvrakIliskiKaydet(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaID);
                #endregion


                // TODO
                if (Fatura.FaturaTipi == IslemTipi.AlisFaturasi) // alış faturası ise alış fiyatını guncellemek için fiyat
                {
                    YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, -1);
                    for (int i = 0; i < gvFaturaHareket.RowCount; i++)
                    {
                        if (FaturaHareket.dt_FaturaHareketleri.Rows[gvFaturaHareket.GetDataSourceRowIndex(i)].RowState != DataRowState.Deleted)
                            YeniStok.StokAlisFiyatiGuncelle(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(gvFaturaHareket.GetRowCellValue(i, colStokID)), Convert.ToDecimal(gvFaturaHareket.GetRowCellValue(i, colIskontoluFiyat)));
                    }
                }

                trGenel.Commit();
                //FaturayiYukle();
                Kaydet_Vazgec_Sil_Enable(false);
            }
            catch (Exception hata)
            {
                try
                {
                    trGenel.Rollback();
                }
                catch (Exception) { }
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("değişiklikleri geri almak istediğine emin misin??!!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                frmFaturaKarti_Load(null, null);
                Kaydet_Vazgec_Sil_Enable(false);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gvOdemeleri.RowCount != 0)
            {
                MessageBox.Show("Odemesi Olan Fatura silinemez.");
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("Dikkat silerim hamısına", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Fatura.SilindiMi = true;
                    Fatura.FaturaKaydet(SqlConnections.GetBaglanti(), trGenel);
                    trGenel.Commit();
                    Close();
                }
                catch (Exception hata)
                {
                    trGenel.Rollback();
                    frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                    frmHataBildir.ShowDialog();
                }
            }
        }

        #endregion


        /// <summary>
        /// Gridde bulunan SatirNo alanının 
        /// </summary>
        /// 
        void SatirNumaralariniOlustur()
        {
            int satirSayisi = 1;
            foreach (DataRow row in FaturaHareket.dt_FaturaHareketleri.AsEnumerable())
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    row["SatirNo"] = satirSayisi.ToString();
                    satirSayisi++;
                }
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

        private void lkpDepo_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpDepo.EditValue != null)
            {
                foreach (DataRow row in (gcFaturaHareket.DataSource as DataTable).AsEnumerable()) row["DepoID"] = lkpDepo.EditValue.ToString();
            }
        }
        private void txtFaturaNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            NumaraSablon.frmNumaraSablonListesi NumaraSablonListesi = new NumaraSablon.frmNumaraSablonListesi((int)Fatura.FaturaTipi);
            if (NumaraSablonListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // txtFaturaNo.Text = NumaraSablon.frmNumaraSablonListesi.Numara;
                // NumaraVer = new csNumaraVer(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaTipi);

                txtFaturaNo.Text = NumaraSablonListesi._KullanilacakNumara;
                Fatura.FaturaNo = NumaraSablonListesi._KullanilacakNumara;
            }
        }

        private void frmFaturaDetay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    BtnCariBul_Click(null, null);
                    break;
                case Keys.F6:
                    btnStokEkle_Click(null, null);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F12:
                    Hesaplamalar.FiyattanKdvCikar(gvFaturaHareket.GetFocusedDataRow());
                    break;
            }
        }

        private void textDegisirse_EditValueChanged(object sender, EventArgs e)
        {
            Kaydet_Vazgec_Sil_Enable(true);
        }

        #region IskontoIslemleri

        private void btnStokIskontoBirinciYuzdeGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.IskontoUgula(colStokIskonto1.FieldName);
        }

        private void btnStokIskontoIkinciYuzdeGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.IskontoUgula(colStokIskonto2.FieldName);
        }

        private void btnStokIskontoUcuncuYuzdeGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.IskontoUgula(colStokIskonto3.FieldName);
        }

        private void btnStokIskontoBirTutarGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.StokIskonto1TutarGir();
        }

        private void btnStokIskontoIkiTutarGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.StokIskonto2TutarGir();
        }

        private void btnStokIskontoUcTutarGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.StokIskonto3TutarGir();
        }

        private void btnCariIskontoBirGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.IskontoUgula(colCariIskonto1.FieldName);
        }

        private void btnCariIskontoUcYuzdeGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.IskontoUgula(colCariIskonto3.FieldName);
        }

        private void btnCariIskontoIkiYuzdeGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.IskontoUgula(colCariIskonto2.FieldName);
        }

        private void btnCariIskontoBirTutarGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.CariIskonto1TutarGir();
        }

        private void btnCariIskontoIkiTutarGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.CariIskonto2TutarGir();
        }

        private void btnCariIskontoUcTutarGir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.CariIskonto3TutarGir();
        }

        #endregion

        void AltToplamlariAl() // bunu hesaplama daki delegeye attık alt toplamları hesapladığında bunu da tetiklesin
        {
            txtToplam_Iskontosuz_Kdvsiz.EditValue = Hesaplamalar.Toplam_Iskontosuz_Kdvsiz;
            txtToplamIndirim.EditValue = Hesaplamalar.ToplamIndirim;
            txtCariIskontoToplami.EditValue = Hesaplamalar.CariIskontoToplami;
            txtStokIskontoToplami.EditValue = Hesaplamalar.StokIskontoToplami;
            txtToplamKDV.EditValue = Hesaplamalar.ToplamKdv;
            txtAraToplam.EditValue = Hesaplamalar.IskontoluToplam;

            txtFaturaTutari.EditValue = Hesaplamalar.FaturaTutari;

            Kaydet_Vazgec_Sil_Enable(true);

            //colKdvDetay_KdvTutari
        }

        private void btnStokKartiAc_Click(object sender, EventArgs e)
        {
            if (gvFaturaHareket.RowCount == 0) return;
            Stok.frmStokDetay StokKarti = new Stok.frmStokDetay(Convert.ToInt32(gvFaturaHareket.GetFocusedRowCellValue(colStokID)));
            StokKarti.MdiParent = this.MdiParent;
            StokKarti.Show();
        }

        void Kaydet_Vazgec_Sil_Enable(bool true_false)
        {
            if (true_false == true)
                Tag = 0;
            else
                Tag = 1;

            btnKaydet.Enabled = true_false;
            btnVazgec.Enabled = true_false;
            btnSil.Enabled = !true_false;
        }

        private void frmFaturaDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                MessageBox.Show("Kayıt Tamamlanmadı");
                e.Cancel = true;
            }
        }

        private void frmFaturaDetay_FormClosed(object sender, FormClosedEventArgs e)
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

        #region Yazdırma işlemleri

        clsTablolar.Yazdirma.csYazdir yazdir;
        clsTablolar.Rapor.csRaporVarsayilanYolu varsayilanyol;
        /// <summary>
        /// bütün butonlardan önce bunu çalıştır sonra istediğin işlemi yap
        /// </summary>
        private void YazdirmakicinVerileriHazirla()
        {
            if (Fatura.FaturaID == -1)
            {
                MessageBox.Show("Önce Kaydı tamamlayın");
                return;
            }

            yazdir = new clsTablolar.Yazdirma.csYazdir();

            yazdir.dt_ekle("Fatura Ust Bilgi");
            yazdir.DtyaYeniSatirEkle("Fatura Ust Bilgi");

            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Ticari Adi", Fatura.CariTanim, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Cari Kodu", Fatura.CariKod, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Adresi", Fatura.Adres, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Vergi Dairesi", Fatura.VergiDairesi, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Vergi Numarası", Fatura.VergiNo, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Fatura Tarihi", Fatura.FaturaTarihi, System.Type.GetType("System.DateTime"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "İli", Fatura.Il, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "İlçesi", Fatura.Ilce, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "İrsaliye No", Fatura.Ilce, System.Type.GetType("System.String"));
            //yazdir.dtyaAlanVeVeriEkle("FaturaUstBilgi", "İrsaliye Tarihi", );
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Ara Toplam", Fatura.Toplam_Iskontosuz_Kdvsiz, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Toplam Iskonto", Fatura.ToplamIndirim, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Iskontolu Toplam", Fatura.IskontoluToplam, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Toplam Kdv", Fatura.ToplamKdv, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Genel Toplam", Fatura.FaturaTutari, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Yazı İle", yazdir.yaziyaCevir(Fatura.FaturaTutari), System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Barkodu", Fatura.FaturaBarkod, System.Type.GetType("System.String"));


            //yazdir.classtandsyeDtekle("Fatura Alt Bilgi");
            //yazdir.DtyaYeniSatirEkle("Fatura Alt Bilgi");



            //yazdir.ds.Tables[]

            yazdir.dt_ekle(FaturaHareket.dt_FaturaHareketleri.Copy());
            yazdir.dt_ekle(Hesaplamalar.dt_kdv.Copy());
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), (clsTablolar.csRaporDizayn.RaporModul)Fatura.FaturaTipi);
                yazdir.YaziciAdi = varsayilanyol.YaziciAdi;
                yazdir.KagitKaynagiIndex = varsayilanyol.KagitKaynagiIndex;

                yazdir.Yazdirr(varsayilanyol.RaporDizaynYolu, clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir);
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), (clsTablolar.csRaporDizayn.RaporModul)Fatura.FaturaTipi);
                yazdir.YaziciAdi = varsayilanyol.YaziciAdi;
                yazdir.KagitKaynagiIndex = varsayilanyol.KagitKaynagiIndex;
                yazdir.Yazdirr(varsayilanyol.RaporDizaynYolu, clsTablolar.Yazdirma.csYazdir.Nasil.Goster);
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(yazdir, (csRaporDizayn.RaporModul)Fatura.FaturaTipi);
            frm.ShowDialog();
        }

        #endregion

        Stok.frmStokEtiket StokEtiketYazdir;
        // etikete gönderiyor
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StokEtiketYazdir = new Stok.frmStokEtiket();

            StokEtiketYazdir.MdiParent = this.MdiParent;
            StokEtiketYazdir.Show();
            for (int i = 0; i < gvFaturaHareket.RowCount; i++)
            {
                StokEtiketYazdir.StokEkle(Convert.ToInt32(gvFaturaHareket.GetRowCellValue(i, colStokID)), Convert.ToDecimal(gvFaturaHareket.GetRowCellValue(i, colMiktar)));
            }
        }

        #region FiyatAktarma Tab ı

        private void btnFiyatYukselt_Click(object sender, EventArgs e)
        {
            Hesaplamalar.FiyatYukselt();
        }

        private void btnFiyatDusur_Click(object sender, EventArgs e)
        {
            Hesaplamalar.FiyatDusur();
        }
        private void btnKdvDegistir_Click(object sender, EventArgs e)
        {
            Hesaplamalar.KDVDegistir();
        }

        private void btnFiyatDegistir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvFaturaHareket.RowCount; i++)
            {
                int ID = (int)gvFaturaHareket.GetRowCellValue(i, colStokID);
                decimal Fiyat = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(lkpKullanilanFiyatTanimi.EditValue), ID);
                gvFaturaHareket.SetRowCellValue(i, colAnaBirimFiyat, Fiyat);
            }
        }

        #endregion

        private void btnFiyatListesiniAc_Click(object sender, EventArgs e)
        {
            Stok.frmStokFiyatlari Fiyatlari;
            if (Fatura.FaturaTipi == IslemTipi.SatisFaturasi)
            {
                Fiyatlari = new Stok.frmStokFiyatlari(Stok.frmStokFiyatlari.NeFiyati.Satis, (int)gvFaturaHareket.GetFocusedRowCellValue(colStokID), Fatura.CariID);
            }
            else
            {
                Fiyatlari = new Stok.frmStokFiyatlari(Stok.frmStokFiyatlari.NeFiyati.Alis, (int)gvFaturaHareket.GetFocusedRowCellValue(colStokID), Fatura.CariID);
            }
            Fiyatlari.lblStokAdi.Text = gvFaturaHareket.GetFocusedRowCellValue(colFaturaHareketStokAdi).ToString();
            Fiyatlari.lblStokKodu.Text = gvFaturaHareket.GetFocusedRowCellValue(colStokKodu).ToString();
            Fiyatlari.FiyatVer = FiyatDegistir;
            Fiyatlari.ShowDialog();
        }

        void FiyatDegistir(decimal Fiyat)
        {
            gvFaturaHareket.SetFocusedRowCellValue(colAnaBirimFiyat, Fiyat);
        }

        public void SiparisEvrakEkle(int SiparisID)
        {
            EvrakIliskileri.dt.Rows.Add(EvrakIliskileri.dt.NewRow());
            EvrakIliskileri.dt.Rows[EvrakIliskileri.dt.Rows.Count - 1]["SiparisID"] = SiparisID;
        }

        private void lkpFaturaGrubu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                lkpFaturaGrubu.EditValue = -1;
        }


        #region AltBirimİşlemleri

        private void txtBirim2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Stok.frmStokBirim Birimler = new Stok.frmStokBirim(Convert.ToInt32(gvFaturaHareket.GetFocusedRowCellValue("StokID")));


            if (Birimler.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                gvFaturaHareket.SetFocusedRowCellValue(colBirim2ID, Birimler.AltBirimID);
                gvFaturaHareket.SetFocusedRowCellValue(colStokAltBirimAdi, Birimler.AltBirimAdi);
                gvFaturaHareket.SetFocusedRowCellValue(colKatSayi, Birimler.AltBirimKatsayi);

            }
        }


        #endregion

        private void gvFaturaHareket_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //label2.Text = gvFaturaHareket.GetVisibleIndex(e.RowHandle).ToString();


        }

        private void btnUrunlariBirlestir_Click(object sender, EventArgs e)
        {
            try
            {
                //trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                //YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, StokID);

                FaturaHareket.dt_FaturaHareketleri.Rows.Add(FaturaHareket.dt_FaturaHareketleri.NewRow());
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokID"] = -2;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokAnaBirimID"] = -1;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokAnaBirimAdi"] = "";

                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokAdi"] = "";
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokKodu"] = "";
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["FaturaHareketStokAdi"] = "";

                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = 1;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["Kdv"] = 1;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["DepoID"] = -1;

                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto1"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto2"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto3"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto1"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto2"] = 0;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto3"] = 0;


                // Alt Birim İle İlgili Ayarları Koyuyoruz hamısına
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["KatSayi"] = 1;
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]["StokAltBirimAdi"] = "";



                //decimal Fiyat = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), trGenel, Fatura.KullanilanFiyatTanimID, YeniStok.StokID);
                FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1][colAnaBirimFiyat.FieldName] = 1;

                //lkpBirim2_Doldur(YeniStok.StokID.ToString());
                //gvFaturaHareket.BestFitColumns();
                Hesaplamalar.SatirHesaplamasi(FaturaHareket.dt_FaturaHareketleri.Rows[FaturaHareket.dt_FaturaHareketleri.Rows.Count - 1]);
                SatirNumaralariniOlustur();
                //trGenel.Commit();
            }
            catch (Exception hata)
            {
                //trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        //clsTablolar.Fatura.csKapaliFatura KapaliFaturaBilgileri = new clsTablolar.Fatura.csKapaliFatura();

        private void btnNakitOdemeGir_Click(object sender, EventArgs e)
        {
            if (Fatura.CariID != -1 && Fatura.FaturaID != -1) // Faturadan Cari Seçilmiş olması gerekli hatta faturanın da kaydedilmiş olması koşulu olsun
            {
                Cari.CariHr.frmCariHrKarti frm = new Cari.CariHr.frmCariHrKarti((Cari.CariHr.frmCariHrKarti.VerilenID_Nerenin)Fatura.FaturaTipi, Fatura.FaturaID, Fatura.CariID);
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    KapaliFaturaHareketleriniGetir();
                    // Bu işlemler CariKarttanYapılacak, Tabi kasadan sıcak satışta nasıl yapılacak acaba
                    //KapaliFaturaBilgileri.YeniOdeme(Fatura.FaturaID, frm._CariHrID, IslemTipi.CariHareket);
                }
            }
        }

        //clsTablolar.Fatura.csKapaliFatura FaturaOdemeleri;
        clsTablolar.cari.CariHr.csCariHr FAturanainOdemeleri = new clsTablolar.cari.CariHr.csCariHr();

        void KapaliFaturaHareketleriniGetir()
        {
            if (Fatura.FaturaID == -1) return;
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                gcOdemeleri.DataSource = FAturanainOdemeleri.FaturaninOdemeleriniGetir(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaID);
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                try { trGenel.Rollback(); } catch (Exception) { }

                MessageBox.Show(hata.Message);
            }

            //FaturaOdemeleri = new clsTablolar.Fatura.csKapaliFatura();
            //trGenel = SqlConnections.GetBaglanti().BeginTransaction();
            //FaturaOdemeleri.Getir(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaID);
            //trGenel.Commit();

        }

        private void dropDownButton_Yazdir_Click(object sender, EventArgs e)
        {

        }

        private void btnUrunlerinSonHareketininIskontosuzFiyatlariniGetir_Click(object sender, EventArgs e)
        {
            //trGenel = SqlConnections.GetBaglanti().BeginTransaction(); // alış faturası için faturaTİpi lazım
            using (SqlCommand cmd = new SqlCommand(@"select top 1 AnaBirimFiyat, StokIskonto1, StokIskonto2, StokIskonto3, CariIskonto1, CariIskonto2, CariIskonto3 from FaturaHareket
inner join fatura on fatura.FaturaID = FaturaHareket.FaturaID
where 
stokID = @StokID and 
fatura.SilindiMi = 0 and 
fatura.Iptal = 0 and 
fatura.FaturaTipi = @FaturaTipi
and FaturaHareket.FaturaID <> @FaturaID
order by fatura.FaturaTarihi desc", SqlConnections.GetBaglanti()))
            {

                cmd.Parameters.Add("@StokID", SqlDbType.Int, 0);
                cmd.Parameters.Add("@FaturaTipi", SqlDbType.TinyInt, 0).Value = 2;
                cmd.Parameters.Add("@FaturaID", SqlDbType.Int, 0).Value = Fatura.FaturaID;


                for (int i = 0; i < gvFaturaHareket.RowCount; i++)
                {
                    cmd.Parameters[0].Value = gvFaturaHareket.GetRowCellValue(i, colStokID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            gvFaturaHareket.SetRowCellValue(i, colAnaBirimFiyat, Convert.ToDecimal(dr["AnaBirimFiyat"]));
                            gvFaturaHareket.SetRowCellValue(i, colStokIskonto1, Convert.ToDecimal(dr["StokIskonto1"]));
                            gvFaturaHareket.SetRowCellValue(i, colStokIskonto2, Convert.ToDecimal(dr["StokIskonto2"]));
                            gvFaturaHareket.SetRowCellValue(i, colStokIskonto3, Convert.ToDecimal(dr["StokIskonto3"]));
                            gvFaturaHareket.SetRowCellValue(i, colCariIskonto1, Convert.ToDecimal(dr["CariIskonto1"]));
                            gvFaturaHareket.SetRowCellValue(i, colCariIskonto2, Convert.ToDecimal(dr["CariISkonto2"]));
                            gvFaturaHareket.SetRowCellValue(i, colCariIskonto3, Convert.ToDecimal(dr["CariIskonto3"]));
                        }
                    }
                }
            }
            //trGenel.Commit();
        }

        private void deFaturaTarihi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                deFaturaTarihi.DoValidate();
                deFaturaVadesi.EditValue = deFaturaTarihi.EditValue;
                deDuzenlemeTarihi.EditValue = deFaturaTarihi.EditValue;
            }
        }

        private void btnSatirAciklama_Click(object sender, EventArgs e)
        {
            using (clsTablolar.TeraziSatisClaslari.frmYaziGirisi frm = new clsTablolar.TeraziSatisClaslari.frmYaziGirisi())
            {
                frm.memoEdit1.EditValue = gvFaturaHareket.GetFocusedRowCellValue(colSatirAciklama);
                if (frm.ShowDialog() == DialogResult.Yes)
                    gvFaturaHareket.SetFocusedRowCellValue(colSatirAciklama, frm.memoEdit1.EditValue);
            }
        }

        private void gvFaturaHareket_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {



            DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle >= 0)
            {
                if (!string.IsNullOrEmpty(View.GetRowCellValue(e.RowHandle, colSatirAciklama).ToString()))
                {
                    e.HighPriority = true;
                    e.Appearance.BackColor = System.Drawing.Color.CadetBlue;
                }
                else
                {

                }
            }
        }

        private void frmFaturaDetay_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void gcFaturaHareket_Click(object sender, EventArgs e)
        {

        }

        private void textDegisirse_EditValueChanged(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void layoutControlGroup7_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (layoutControlGroup7.Expanded)
            {
                layoutControlGroup7.Expanded = false;
            }
            else
                layoutControlGroup7.Expanded = true;
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            using (Cari.CariHr.frmCariHrKarti frm = new Cari.CariHr.frmCariHrKarti(Convert.ToInt32(gvOdemeleri.GetFocusedRowCellValue("CariHrID"))))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                    KapaliFaturaHareketleriniGetir();
            }
        }

        private void gvFaturaHareket_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colAnaBirimFiyat)
            {
                if (e.Value == DBNull.Value || e.Value.ToString() == "")
                {
                    gvFaturaHareket.SetFocusedRowCellValue(e.Column, 0);

                }

                //gvFaturaHareket.SetFocusedRowCellValue(e.Column, e.Value);
                gvFaturaHareket.PostEditor();
            }
        }

        private void gvFaturaHareket_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }
    }
}