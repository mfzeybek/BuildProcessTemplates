using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public class csStok : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region Değişken
        private int _StokID;
        private bool _Aktif;
        private string _StokKodu;
        private string _StokAdi;
        private string _OzelKod1;
        private string _OzelKod2;
        private string _OzelKod3;
        private int _StokGrupID;
        private int _StokAraGrupID;
        private int _StokAltGrupID;
        private string _KisaAciklama;
        private string _Aciklama;
        private string _DetayliUrunBilgisi;
        private int _KaydedenID;
        private DateTime _KayitTarihi;
        private int _DegistirenID;
        private DateTime _DegismeTarihi;
        private int _StokBirimID;
        private decimal _iskOrani1;
        private decimal _iskOrani2;
        private decimal _iskOrani3;
        private decimal _MinumumMiktar;
        private decimal _OlmasiGerekenMiktar;
        private decimal _MaksimumMiktar;
        private string _EtiketAdi;
        private decimal _AlisKdv;
        private decimal _SatisKdv;
        private string _Barkod;
        private bool _Silindi;
        private bool _UrunTanitimdaGoster;
        private int _RafYeriID;
        private string _RafYeriAciklama;
        private int _Garanti;
        private bool _EMagazaErisimi;
        private decimal _Desi;

        private int _HemenAlKategoriID;

        private int _HemenAlID;

        private bool _HemenAlKategoriGuncellenmesin;

        /// <summary>
        /// StokTipi
        /// 1 Hazır Stok (Hazır alınıp satılıyor)
        /// 2 Mamül(Üretilen Stok, bu sadece üretiliyor neredeyse hiç satın alınmıyor)
        /// 3 Hammade(Mamül üretirken Kullanılıyor)
        /// </summary>
        private int _StokTipi;





        /// <summary>
        /// Boş geldiğinde ürün yoksa eklenir varsa güncellenir.
        /// P gönderilirse ürün pasif edilir.
        /// A gönderilirse ürün aktif edilir.
        /// D gönderilirse ürün silinir.
        /// S gönderilirse sadece stok güncellenir.
        /// F gönderilirse sadece fiyat güncellenir.
        /// </summary>
        private string _HemenAlDrum;

        private int _HemenAlSira;
        private int _StokSayimGrubuID;


        private string _HemenAlAnahtarKelime;
        private string _StokWebLink;

        private int _EticaretStokDurumID_StoktaVarsa;


        private int _EticaretStokDurumID_StoktaYoksa;
        private decimal _Agirligi;

        public decimal Agirligi
        {
            get { return _Agirligi; }
            set { _Agirligi = value; }
        }




        #endregion

        #region MyRegion
        public int StokID
        {
            get { return _StokID; }
            set { _StokID = value; }
        }
        public bool Aktif
        {
            get { return _Aktif; }
            set { _Aktif = value; }
        }
        public string StokKodu
        {
            get { return _StokKodu; }
            set { _StokKodu = value; }
        }
        public string StokAdi
        {
            get { return _StokAdi; }
            set { _StokAdi = value; }
        }
        public string OzelKod1
        {
            get { return _OzelKod1; }
            set { _OzelKod1 = value; }
        }
        public string OzelKod2
        {
            get { return _OzelKod2; }
            set { _OzelKod2 = value; }
        }
        public string OzelKod3
        {
            get { return _OzelKod3; }
            set { _OzelKod3 = value; }
        }
        public int StokGrupID
        {
            get { return _StokGrupID; }
            set { _StokGrupID = value; }
        }
        public int StokAraGrupID
        {
            get { return _StokAraGrupID; }
            set { _StokAraGrupID = value; }
        }
        public int StokAltGrupID
        {
            get { return _StokAltGrupID; }
            set { _StokAltGrupID = value; }
        }
        public string KisaAciklama
        {
            get { return _KisaAciklama; }
            set { _KisaAciklama = value; }
        }
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }
        public string DetayliUrunBilgisi
        {
            get { return _DetayliUrunBilgisi; }
            set { _DetayliUrunBilgisi = value; }
        }
        public int KaydedenID
        {
            get { return _KaydedenID; }
            set { _KaydedenID = value; }
        }
        public DateTime KayitTarihi
        {
            get { return _KayitTarihi; }
            set { _KayitTarihi = value; }
        }
        public int DegistirenID
        {
            get { return _DegistirenID; }
            set { _DegistirenID = value; }
        }
        public DateTime DegismeTarihi
        {
            get { return _DegismeTarihi; }
            set { _DegismeTarihi = value; }
        }
        public int StokBirimID
        {
            get { return _StokBirimID; }
            set { _StokBirimID = value; }
        }
        public decimal iskOrani1
        {
            get { return _iskOrani1; }
            set { _iskOrani1 = value; }
        }
        public decimal iskOrani2
        {
            get { return _iskOrani2; }
            set { _iskOrani2 = value; }
        }
        public decimal iskOrani3
        {
            get { return _iskOrani3; }
            set { _iskOrani3 = value; }
        }
        public decimal MinumumMiktar
        {
            get { return _MinumumMiktar; }
            set { _MinumumMiktar = value; }
        }
        public decimal OlmasiGerekenMiktar
        {
            get { return _OlmasiGerekenMiktar; }
            set { _OlmasiGerekenMiktar = value; }
        }
        public decimal MaksimumMiktar
        {
            get { return _MaksimumMiktar; }
            set { _MaksimumMiktar = value; }
        }
        public string EtiketAdi
        {
            get { return _EtiketAdi; }
            set { _EtiketAdi = value; }
        }
        public decimal AlisKdv
        {
            get { return _AlisKdv; }
            set { _AlisKdv = value; }
        }
        public decimal SatisKdv
        {
            get { return _SatisKdv; }
            set { _SatisKdv = value; }
        }
        public string Barkod
        {
            get { return _Barkod; }
            set { _Barkod = value; }
        }
        public bool Silindi
        {
            get { return _Silindi; }
            set { _Silindi = value; }
        }
        public bool UrunTanitimdaGoster
        {
            get { return _UrunTanitimdaGoster; }
            set { _UrunTanitimdaGoster = value; }
        }
        public int RafYeriID
        {
            get { return _RafYeriID; }
            set { _RafYeriID = value; }
        }
        public string RafYeriAciklama
        {
            get { return _RafYeriAciklama; }
            set { _RafYeriAciklama = value; }
        }
        public int Garanti
        {
            get { return _Garanti; }
            set { _Garanti = value; }
        }
        public bool EMagazaErisimi
        {
            get { return _EMagazaErisimi; }
            set { _EMagazaErisimi = value; }
        }
        public int HemenAlID
        {
            get { return _HemenAlID; }
            set { _HemenAlID = value; }
        }
        public bool HemenAlKategoriGuncellenmesin
        {
            get { return _HemenAlKategoriGuncellenmesin; }
            set { _HemenAlKategoriGuncellenmesin = value; }
        }
        public decimal Desi
        {
            get { return _Desi; }
            set { _Desi = value; }
        }
        public int HemenAlKategoriID
        {
            get { return _HemenAlKategoriID; }
            set { _HemenAlKategoriID = value; }
        }
        /// <summary>
        /// Boş geldiğinde ürün yoksa eklenir varsa güncellenir.
        /// P gönderilirse ürün pasif edilir.
        /// A gönderilirse ürün aktif edilir.
        /// D gönderilirse ürün silinir.
        /// S gönderilirse sadece stok güncellenir.
        /// F gönderilirse sadece fiyat güncellenir.
        /// </summary>
        public string HemenAlDrum
        {
            get { return _HemenAlDrum; }
            set { _HemenAlDrum = value; }
        }
        public int HemenAlSira
        {
            get { return _HemenAlSira; }
            set { _HemenAlSira = value; }
        }
        public int StokSayimGrubuID
        {
            get { return _StokSayimGrubuID; }
            set { _StokSayimGrubuID = value; }
        }
        public string HemenAlAnahtarKelime
        {
            get { return _HemenAlAnahtarKelime; }
            set { _HemenAlAnahtarKelime = value; }
        }
        public string StokWebLink
        {
            get { return _StokWebLink; }
            set { _StokWebLink = value; }
        }
        public int EticaretStokDurumID_StoktaVarsa
        {
            get { return _EticaretStokDurumID_StoktaVarsa; }
            set { _EticaretStokDurumID_StoktaVarsa = value; }
        }
        public int EticaretStokDurumID_StoktaYoksa
        {
            get { return _EticaretStokDurumID_StoktaYoksa; }
            set { _EticaretStokDurumID_StoktaYoksa = value; }
        }

        public int StokTipi
        {
            get
            {
                return _StokTipi;
            }

            set
            {
                _StokTipi = value;
            }
        }




        #endregion

        public string StokAnaBirimAdi; // Veritabanındaki Stok Tablosunda Yok Sadece Burada var


        #region Genel DeğişkEnler
        SqlCommand cmdGenel;
        SqlDataReader drGenel;
        #endregion

        /// <summary>
        /// İlk değerlerini atar;
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="StokID"></param>
        public csStok(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            if (StokID == -1)
            {
                _StokID = -1;
                _Aktif = true;
                _StokKodu = "";
                _StokAdi = "";
                _OzelKod1 = "";
                _OzelKod2 = "";
                _OzelKod3 = "";
                _StokGrupID = -1;
                _StokAraGrupID = -1;
                _StokAltGrupID = -1;
                _KisaAciklama = "";
                _Aciklama = "";
                _DetayliUrunBilgisi = "";
                //Burada aslında hangi kullanıcı açmışsa  formu onun ID si yazılacak
                _KaydedenID = -1;
                _KayitTarihi = DateTime.Now;
                _StokBirimID = -1;
                _iskOrani1 = 0;
                _iskOrani2 = 0;
                _iskOrani3 = 0;
                _MinumumMiktar = 0;
                _OlmasiGerekenMiktar = 0;
                _MaksimumMiktar = 0;
                _EtiketAdi = "";
                _AlisKdv = 8;
                _SatisKdv = 8;
                _Barkod = "";
                _UrunTanitimdaGoster = false;
                _RafYeriAciklama = "";
                _RafYeriID = -1;
                _Garanti = 0;
                _EMagazaErisimi = false;
                _HemenAlID = -1;
                _HemenAlKategoriGuncellenmesin = false;
                _Desi = 0;
                _HemenAlKategoriID = -1;
                _HemenAlDrum = "";
                _HemenAlSira = 0;
                _StokSayimGrubuID = -1;
                _HemenAlAnahtarKelime = "";
                _StokWebLink = "";
                _EticaretStokDurumID_StoktaVarsa = -1;
                _EticaretStokDurumID_StoktaYoksa = -1;
                _Agirligi = 0;
                _StokTipi = -1;
            }
            else
            {
                StokGetir(Baglanti, Tr, StokID);
            }
        }
        private Int32 IDBossaEksiBirVer(object ID)
        {
            int ID2;
            if (ID == null || ID.ToString() == "" || ID == DBNull.Value)
            {
                ID2 = -1;
            }
            else
            {
                ID2 = Convert.ToInt32(ID.ToString());
            }
            return ID2;
        }
        private DateTime TarihBossaMinTarihVer(Object Tarih)
        {
            DateTime Tarihh;
            if (DateTime.TryParse(Tarih.ToString(), out Tarihh) == false)
                Tarihh = DateTime.MinValue;

            return Tarihh;
        }
        public void StokGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (cmdGenel = new SqlCommand())
            {
                cmdGenel.Connection = Baglanti;
                cmdGenel.Transaction = Tr;
                cmdGenel.CommandText = @"
SELECT     dbo.Stok.StokID, dbo.Stok.Aktif, dbo.Stok.StokKodu, dbo.Stok.StokAdi, dbo.Stok.OzelKod1, dbo.Stok.OzelKod2, dbo.Stok.OzelKod3, dbo.Stok.StokGrupID, 
                      dbo.Stok.StokAraGrupID, dbo.Stok.StokAltGrupID, dbo.Stok.KisaAciklama, dbo.Stok.Aciklama, dbo.Stok.DetayliUrunBilgisi,dbo.Stok.KaydedenID, dbo.Stok.KayitTarihi, dbo.Stok.DegistirenID, dbo.Stok.DegismeTarihi, 
                      dbo.Stok.StokBirimID, dbo.Stok.iskOrani1, dbo.Stok.iskOrani2, dbo.Stok.iskOrani3, MinumumMiktar, OlmasiGerekenMiktar ,MaksimumMiktar, EtiketAdi, AlisKdv, SatisKdv, Barkod, 
                      UrunTanitimdaGoster, RafYeriID, RafYeriAciklama, ISNULL(Garanti, 0) Garanti, EMagazaErisimi, Desi, HemenAlKategoriID, HemenAlID, HemenAlKategoriGuncellenmesin, HemenAlDrum, HemenAlSira, StokSayimGrubuID, HemenAlAnahtarKelime, StokWebLink, EticaretStokDurumID_StoktaVarsa, EticaretStokDurumID_StoktaYoksa, StokBirim.BirimAdi, ISNULL(Stok.Agirligi, 0) Agirligi , StokTipi

FROM         dbo.Stok WITH (NOLOCK)
left join StokBirim on StokBirim.BirimID = Stok.StokBirimID

WHERE     (dbo.Stok.StokID = @StokID)
";
                cmdGenel.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                using (drGenel = cmdGenel.ExecuteReader())
                {
                    drGenel.Read();
                    _StokID = Convert.ToInt32(drGenel["StokID"].ToString());
                    _Aktif = Convert.ToBoolean(drGenel["Aktif"]);
                    _StokKodu = drGenel["StokKodu"].ToString();
                    _StokAdi = drGenel["StokAdi"].ToString();
                    _OzelKod1 = drGenel["OzelKod1"].ToString();
                    _OzelKod2 = drGenel["OzelKod2"].ToString();
                    _OzelKod3 = drGenel["OzelKod3"].ToString();
                    _StokGrupID = IDBossaEksiBirVer(drGenel["StokGrupID"]);
                    _StokAraGrupID = IDBossaEksiBirVer(drGenel["StokAraGrupID"]);
                    _StokAltGrupID = IDBossaEksiBirVer(drGenel["StokAltGrupID"]);
                    _KisaAciklama = drGenel["KisaAciklama"].ToString();
                    _Aciklama = drGenel["Aciklama"].ToString();
                    _DetayliUrunBilgisi = drGenel["DetayliUrunBilgisi"].ToString();
                    //Burada aslında hangi kullanıcı açmışsa  formu onun ID si yazılacak
                    _KaydedenID = IDBossaEksiBirVer(drGenel["KaydedenID"]);
                    _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
                    _DegistirenID = IDBossaEksiBirVer(drGenel["DegistirenID"]);
                    _DegismeTarihi = TarihBossaMinTarihVer(drGenel["DegismeTarihi"]);
                    _StokBirimID = IDBossaEksiBirVer(drGenel["StokBirimID"]);
                    _iskOrani1 = Convert.ToDecimal(drGenel["İskOrani1"]);
                    _iskOrani2 = Convert.ToDecimal(drGenel["İskOrani2"]);
                    _iskOrani3 = Convert.ToDecimal(drGenel["İskOrani3"]);
                    _MinumumMiktar = Convert.ToDecimal(drGenel["MinumumMiktar"]);
                    _OlmasiGerekenMiktar = Convert.ToDecimal(drGenel["OlmasiGerekenMiktar"]);
                    _MaksimumMiktar = Convert.ToDecimal(drGenel["MaksimumMiktar"]);
                    _EtiketAdi = drGenel["EtiketAdi"].ToString();
                    _AlisKdv = Convert.ToDecimal(drGenel["AlisKdv"]);
                    _SatisKdv = Convert.ToDecimal(drGenel["SatisKdv"]);
                    _Barkod = Convert.ToString(drGenel["Barkod"]);
                    _RafYeriID = Convert.ToInt32(drGenel["RafYeriID"]);
                    _RafYeriAciklama = Convert.ToString(drGenel["RafYeriAciklama"]);
                    _UrunTanitimdaGoster = Convert.ToBoolean(drGenel["UrunTanitimdaGoster"]);
                    _Garanti = Convert.ToInt32(drGenel["Garanti"].ToString());
                    _EMagazaErisimi = Convert.ToBoolean(drGenel["EMagazaErisimi"].ToString());
                    _Desi = Convert.ToDecimal(drGenel["Desi"]);
                    _HemenAlKategoriID = Convert.ToInt32(drGenel["HemenAlKategoriID"]);
                    _HemenAlID = Convert.ToInt32(drGenel["HemenAlID"]);
                    _HemenAlKategoriGuncellenmesin = Convert.ToBoolean(drGenel["HemenAlKategoriGuncellenmesin"]);
                    _HemenAlDrum = drGenel["HemenAlDrum"].ToString();
                    _HemenAlSira = Convert.ToInt32(drGenel["HemenAlSira"]);
                    _StokSayimGrubuID = Convert.ToInt32(drGenel["StokSayimGrubuID"]);
                    _HemenAlAnahtarKelime = drGenel["HemenAlAnahtarKelime"].ToString();
                    _StokWebLink = drGenel["StokWebLink"].ToString();
                    StokAnaBirimAdi = drGenel["BirimAdi"].ToString();
                    _EticaretStokDurumID_StoktaVarsa = Convert.ToInt32(drGenel["EticaretStokDurumID_StoktaVarsa"]);
                    _EticaretStokDurumID_StoktaYoksa = Convert.ToInt32(drGenel["EticaretStokDurumID_StoktaYoksa"]);
                    _Agirligi = Convert.ToDecimal(drGenel["Agirligi"]);
                    _StokTipi = Convert.ToInt32(drGenel["StokTipi"]);
                }
            }
        }
        /// <summary>
        /// Karttaki Alanları veritabanına yazar
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// 
        public String StokGuncelle(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (cmdGenel = new SqlCommand())
            {
                cmdGenel.Connection = Baglanti;
                cmdGenel.Transaction = Tr;
                // StokID -1 ise yeni kayıt demektir yeni kaydı insert eder
                if (StokID == -1)  // insert eder
                {
                    cmdGenel.CommandText = @"insert into Stok
(Aktif, StokKodu, StokAdi, OzelKod1, OzelKod2, OzelKod3, StokGrupID, StokAraGrupID, StokAltGrupID, KisaAciklama, Aciklama, DetayliUrunBilgisi, KaydedenID, KayitTarihi, 
StokBirimID, iskOrani1, iskOrani2, iskOrani3, MinumumMiktar, OlmasiGerekenMiktar ,MaksimumMiktar, EtiketAdi, AlisKdv, SatisKdv, Barkod, Silindi, UrunTanitimdaGoster, 
RafYeriID, RafYeriAciklama, Garanti, EMagazaErisimi, Desi, HemenAlKategoriID, HemenAlID, HemenAlKategoriGuncellenmesin, HemenAlDrum, HemenAlSira, StokSayimGrubuID, HemenAlAnahtarKelime, StokWebLink, EticaretStokDurumID_StoktaVarsa, EticaretStokDurumID_StoktaYoksa, Agirligi, StokTipi)
values 
(@Aktif, @StokKodu, @StokAdi, @OzelKod1, @OzelKod2, @OzelKod3, @StokGrupID, @StokAraGrupID, @StokAltGrupID, @KisaAciklama, @Aciklama, @DetayliUrunBilgisi, @KaydedenID, @KayitTarihi, 
@StokBirimID, @iskOrani1, @iskOrani2, @iskOrani3,  @MinumumMiktar, @OlmasiGerekenMiktar, @MaksimumMiktar, @EtiketAdi, @AlisKdv, @SatisKdv, @Barkod, 0, @UrunTanitimdaGoster, 
@RafYeriID, @RafYeriAciklama, @Garanti, @EMagazaErisimi, @Desi, @HemenAlKategoriID, @HemenAlID, @HemenAlKategoriGuncellenmesin, @HemenAlDrum, @HemenAlSira, @StokSayimGrubuID, @HemenAlAnahtarKelime, @StokWebLink, @EticaretStokDurumID_StoktaVarsa, @EticaretStokDurumID_StoktaYoksa, @Agirligi, @StokTipi) set @YeniID = SCOPE_IDENTITY()";
                    // bu iki parametre sadece insertte var.
                    cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                    cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = IDBossaEksiBirVer(_KaydedenID);
                    cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

                }
                else  // Update eder
                {
                    cmdGenel.CommandText = @"Update Stok set  Aktif = @Aktif, StokKodu=@StokKodu, StokAdi = @StokAdi, OzelKod1=@OzelKod1, OzelKod2=@OzelKod2 , OzelKod3=@OzelKod3, 
StokGrupID = @StokGrupID, StokAraGrupID=@StokAraGrupID, StokAltGrupID = @StokAltGrupID, KisaAciklama=@KisaAciklama, Aciklama=@Aciklama, DetayliUrunBilgisi=@DetayliUrunBilgisi, DegistirenID=@DegistirenID, DegismeTarihi=@DegismeTarihi, StokBirimID=@StokBirimID, 
iskOrani1=@iskOrani1, iskOrani2=@iskOrani2, iskOrani3=@iskOrani3, MinumumMiktar = @MinumumMiktar, OlmasiGerekenMiktar = @OlmasiGerekenMiktar, MaksimumMiktar = @MaksimumMiktar, EtiketAdi = @EtiketAdi ,AlisKdv = @AlisKdv, SatisKdv = @SatisKdv, 
Barkod = @Barkod, RafYeriID = @RafYeriID, RafYeriAciklama = @RafYeriAciklama, UrunTanitimdaGoster = @UrunTanitimdaGoster,
Garanti=@Garanti, EMagazaErisimi=@EMagazaErisimi, Desi = @Desi, HemenAlKategoriID = @HemenAlKategoriID, HemenAlID = @HemenAlID, HemenAlKategoriGuncellenmesin = @HemenAlKategoriGuncellenmesin, HemenAlDrum = @HemenAlDrum, HemenAlSira = @HemenAlSira ,
StokSayimGrubuID = @StokSayimGrubuID , HemenAlAnahtarKelime = @HemenAlAnahtarKelime, StokWebLink = @StokWebLink, EticaretStokDurumID_StoktaVarsa = @EticaretStokDurumID_StoktaVarsa, EticaretStokDurumID_StoktaYoksa = @EticaretStokDurumID_StoktaYoksa, Agirligi = @Agirligi, StokTipi = @StokTipi
where StokID =@StokID";
                    cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                    cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = IDBossaEksiBirVer(_DegistirenID);
                    cmdGenel.Parameters.Add("@StokID", SqlDbType.Int).Value = _StokID;
                }
                cmdGenel.Parameters.Add("@Aktif", SqlDbType.Bit).Value = _Aktif;
                cmdGenel.Parameters.Add("@StokKodu", SqlDbType.NVarChar).Value = _StokKodu;
                cmdGenel.Parameters.Add("@StokAdi", SqlDbType.NVarChar).Value = _StokAdi;
                cmdGenel.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
                cmdGenel.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
                cmdGenel.Parameters.Add("@OzelKod3", SqlDbType.NVarChar).Value = _OzelKod3;
                cmdGenel.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = IDBossaEksiBirVer(_StokGrupID);
                cmdGenel.Parameters.Add("@StokAraGrupID", SqlDbType.Int).Value = IDBossaEksiBirVer(_StokAraGrupID);
                cmdGenel.Parameters.Add("@StokAltGrupID", SqlDbType.Int).Value = IDBossaEksiBirVer(_StokAltGrupID);
                cmdGenel.Parameters.Add("@KisaAciklama", SqlDbType.NVarChar).Value = _KisaAciklama;
                cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
                cmdGenel.Parameters.Add("@DetayliUrunBilgisi", SqlDbType.NVarChar).Value = _DetayliUrunBilgisi;
                cmdGenel.Parameters.Add("@StokBirimID", SqlDbType.Int).Value = IDBossaEksiBirVer(_StokBirimID);
                cmdGenel.Parameters.Add("@iskOrani1", SqlDbType.Decimal).Value = _iskOrani1;
                cmdGenel.Parameters.Add("@iskOrani2", SqlDbType.Decimal).Value = _iskOrani2;
                cmdGenel.Parameters.Add("@iskOrani3", SqlDbType.Decimal).Value = _iskOrani3;
                cmdGenel.Parameters.Add("@MinumumMiktar", SqlDbType.Decimal).Value = _MinumumMiktar;
                cmdGenel.Parameters.Add("@OlmasiGerekenMiktar", SqlDbType.Decimal).Value = _OlmasiGerekenMiktar;
                cmdGenel.Parameters.Add("@MaksimumMiktar", SqlDbType.Decimal).Value = _MaksimumMiktar;
                cmdGenel.Parameters.Add("@EtiketAdi", SqlDbType.NVarChar).Value = _EtiketAdi;
                cmdGenel.Parameters.Add("@AlisKdv", SqlDbType.Decimal).Value = _AlisKdv;
                cmdGenel.Parameters.Add("@SatisKdv", SqlDbType.Decimal).Value = _SatisKdv;
                cmdGenel.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = _Barkod;
                cmdGenel.Parameters.Add("@RafYeriID", SqlDbType.Int).Value = _RafYeriID;
                cmdGenel.Parameters.Add("@RafYeriAciklama", SqlDbType.NVarChar).Value = _RafYeriAciklama;
                cmdGenel.Parameters.Add("@UrunTanitimdaGoster", SqlDbType.Bit).Value = _UrunTanitimdaGoster;
                cmdGenel.Parameters.Add("@Garanti", SqlDbType.Int).Value = _Garanti;
                cmdGenel.Parameters.Add("@EMagazaErisimi", SqlDbType.Bit).Value = _EMagazaErisimi;
                cmdGenel.Parameters.Add("@Desi", SqlDbType.Decimal).Value = _Desi;
                cmdGenel.Parameters.Add("@HemenAlKategoriID", SqlDbType.Int).Value = _HemenAlKategoriID;
                cmdGenel.Parameters.Add("@HemenAlID", SqlDbType.Int).Value = _HemenAlID;
                cmdGenel.Parameters.Add("@HemenAlKategoriGuncellenmesin", SqlDbType.Bit).Value = _HemenAlKategoriGuncellenmesin;
                cmdGenel.Parameters.Add("@HemenAlDrum", SqlDbType.NVarChar).Value = _HemenAlDrum;
                cmdGenel.Parameters.Add("@HemenAlSira", SqlDbType.Int).Value = _HemenAlSira;
                cmdGenel.Parameters.Add("@StokSayimGrubuID", SqlDbType.Int).Value = _StokSayimGrubuID;
                cmdGenel.Parameters.Add("@HemenAlAnahtarKelime", SqlDbType.NVarChar).Value = _HemenAlAnahtarKelime;
                cmdGenel.Parameters.Add("@StokWebLink", SqlDbType.NChar).Value = _StokWebLink;
                cmdGenel.Parameters.Add("@EticaretStokDurumID_StoktaVarsa", SqlDbType.Int).Value = _EticaretStokDurumID_StoktaVarsa;
                cmdGenel.Parameters.Add("@EticaretStokDurumID_StoktaYoksa", SqlDbType.Int).Value = _EticaretStokDurumID_StoktaYoksa;
                cmdGenel.Parameters.Add("@Agirligi", SqlDbType.Decimal).Value = _Agirligi;
                cmdGenel.Parameters.Add("@StokTipi", SqlDbType.Int).Value = _StokTipi;
                try
                {
                    cmdGenel.ExecuteNonQuery();
                    if (_StokID == -1)
                        _StokID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
                }
                catch (Exception e)
                {
                    if (e is SqlException && ((SqlException)e).Number == 2601)  //Aynı kayıttan var hatasıymışşşşşşşş
                        return ((SqlException)e).Number.ToString();
                    else
                        return e.Message;
                }
            }
            return "OK ," + _StokID.ToString();
        }

        // TODO: burası da buradan Fiyat Bölümüne alınacak
        public void StokAlisFiyatiGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID, decimal Fiyat)
        {
            using (cmdGenel = new SqlCommand(@"
if (( select StokFiyat.StokID from dbo.StokFiyat where StokID = @StokID  and (select Ayarlar.StokAlisFiyatTanimID from Ayarlar) = StokFiyat.FiyatTanimID) =	@StokID)
update StokFiyat set Fiyat = @Fiyat where StokID= @StokID and (select Ayarlar.StokAlisFiyatTanimID from Ayarlar) = StokFiyat.FiyatTanimID
else
insert into StokFiyat (FiyatTanimID, Fiyat, StokID, AlisMiSatisMi) values ((select Ayarlar.StokAlisFiyatTanimID from Ayarlar), @Fiyat, @StokID, 'Alis')", Baglanti, Tr))
            {
                cmdGenel.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                cmdGenel.Parameters.Add("@Fiyat", SqlDbType.Decimal).Value = Fiyat;

                cmdGenel.ExecuteNonQuery();
            }
        }

        public void StokSil(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (cmdGenel = new SqlCommand(@"update Stok set Silindi = 1 where StokID = @StokID", Baglanti, Tr))
            {
                cmdGenel.Parameters.Add("@StokID", SqlDbType.Int).Value = _StokID;
                cmdGenel.ExecuteNonQuery();
            }
        }




        // bu silinecek
        public void StokUrunTanitimGuncelle(SqlConnection Baglanti, SqlTransaction Tr, bool Goster, int StokID)
        {
            using (cmdGenel = new SqlCommand("update Stok set stok.UrunTanitimdaGoster = @UrunTanitimdaGoster where StokID = @StokID", Baglanti, Tr))
            {
                cmdGenel.Parameters.Add("@UrunTanitimdaGoster", SqlDbType.Bit).Value = Goster;
                cmdGenel.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                cmdGenel.ExecuteNonQuery();
            }
        }
    }
}

