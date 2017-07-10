using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Siparis
{
    public class csSiparis : IDisposable
    {
        #region Değişkenler

        private int _SiparisID;
        private SiparisTip _SiparisTipi;
        private DateTime _SiparisTarihi;
        private DateTime _DuzenlemeTarihi;
        private DateTime _Vadesi;
        private DateTime _TeslimTarihi;
        private string _SiparisNo;
        private int _CariID;
        private string _CariKod;
        private string _CariTanim;
        private string _VergiDairesi;
        private string _VergiNo;
        private string _Adres;
        private string _Il;
        private string _Ilce;
        private bool _Iptal;
        private bool _SilindiMi;
        private string _Aciklama;
        private int _KaydedenID;
        private DateTime _KayitTarihi;
        private int _DegistirenID;
        private DateTime _DegismeTarihi;
        private int _DepoID;
        private int _SatisElemaniID;
        private decimal _Toplam_Iskontosuz_Kdvsiz;
        private decimal _CariIskontoToplami;
        private decimal _StokIskontoToplami;
        private decimal _ToplamIndirim;
        private decimal _ToplamKdv;
        private decimal _IskontoluToplam;
        private decimal _SiparisTutari;
        private int _KullanilanFiyatTanimID;
        private FaturalandiMi _Faturalandi;
        private int _SiparisGrupID;
        private int _SiparisDurumTanimID;
        private string _SiparisBarkodNu;
        private bool _HizliSatistaGozukecekMi;
        private string _PersonelAdi;

        public string PersonelAdi
        {
            get { return _PersonelAdi; }
            set { _PersonelAdi = value; }
        }

        public bool HizliSatistaGozukecekMi
        {
            get { return _HizliSatistaGozukecekMi; }
            set { _HizliSatistaGozukecekMi = value; }
        }
        private bool _HizliSatistaDegisiklikYapmaIzniVarMi;

        public bool HizliSatistaDegisiklikYapmaIzniVarMi
        {
            get { return _HizliSatistaDegisiklikYapmaIzniVarMi; }
            set { _HizliSatistaDegisiklikYapmaIzniVarMi = value; }
        }






        #endregion

        #region Methodlar
        public int SiparisID
        {
            get { return _SiparisID; }
            set { _SiparisID = value; }
        }
        public SiparisTip SiparisTipi
        {
            get { return _SiparisTipi; }
            set { _SiparisTipi = value; }
        }
        public DateTime SiparisTarihi
        {
            get { return _SiparisTarihi; }
            set { _SiparisTarihi = value; }
        }
        public DateTime DuzenlemeTarihi
        {
            get { return _DuzenlemeTarihi; }
            set { _DuzenlemeTarihi = value; }
        }
        public DateTime Vadesi
        {
            get { return _Vadesi; }
            set { _Vadesi = value; }
        }
        public DateTime TeslimTarihi
        {
            get { return _TeslimTarihi; }
            set { _TeslimTarihi = value; }
        }
        public string SiparisNo
        {
            get { return _SiparisNo; }
            set { _SiparisNo = value; }
        }
        public int CariID
        {
            get { return _CariID; }
            set { _CariID = value; }
        }
        public string CariKod
        {
            get { return _CariKod; }
            set { _CariKod = value; }
        }
        public string CariTanim
        {
            get { return _CariTanim; }
            set { _CariTanim = value; }
        }
        public string VergiDairesi
        {
            get { return _VergiDairesi; }
            set { _VergiDairesi = value; }
        }
        public string VergiNo
        {
            get { return _VergiNo; }
            set { _VergiNo = value; }
        }
        public string Adres
        {
            get { return _Adres; }
            set { _Adres = value; }
        }
        public string Il
        {
            get { return _Il; }
            set { _Il = value; }
        }
        public string Ilce
        {
            get { return _Ilce; }
            set { _Ilce = value; }
        }
        public bool Iptal
        {
            get { return _Iptal; }
            set { _Iptal = value; }
        }
        public bool SilindiMi
        {
            get { return _SilindiMi; }
            set { _SilindiMi = value; }
        }
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
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
        public int DepoID
        {
            get { return _DepoID; }
            set { _DepoID = value; }
        }
        public int SatisElemaniID
        {
            get { return _SatisElemaniID; }
            set { _SatisElemaniID = value; }
        }
        public decimal Toplam_Iskontosuz_Kdvsiz
        {
            get { return _Toplam_Iskontosuz_Kdvsiz; }
            set { _Toplam_Iskontosuz_Kdvsiz = value; }
        }
        public decimal CariIskontoToplami
        {
            get { return _CariIskontoToplami; }
            set { _CariIskontoToplami = value; }
        }
        public decimal StokIskontoToplami
        {
            get { return _StokIskontoToplami; }
            set { _StokIskontoToplami = value; }
        }
        public decimal ToplamIndirim
        {
            get { return _ToplamIndirim; }
            set { _ToplamIndirim = value; }
        }
        public decimal ToplamKdv
        {
            get { return _ToplamKdv; }
            set { _ToplamKdv = value; }
        }
        public decimal IskontoluToplam
        {
            get { return _IskontoluToplam; }
            set { _IskontoluToplam = value; }
        }
        public decimal SiparisTutari
        {
            get { return _SiparisTutari; }
            set { _SiparisTutari = value; }
        }
        public int KullanilanFiyatTanimID
        {
            get { return _KullanilanFiyatTanimID; }
            set { _KullanilanFiyatTanimID = value; }
        }
        public FaturalandiMi Faturalandi
        {
            get { return _Faturalandi; }
            set { _Faturalandi = value; }
        }
        public int SiparisGrupID
        {
            get { return _SiparisGrupID; }
            set { _SiparisGrupID = value; }
        }

        public int SiparisDurumTanimID
        {
            get { return _SiparisDurumTanimID; }
            set { _SiparisDurumTanimID = value; }
        }
        public string SiparisBarkodNu
        {
            get { return _SiparisBarkodNu; }
            set { _SiparisBarkodNu = value; }
        }
        #endregion

        #region Genel DeğişkEnler
        SqlCommand cmdGenel;
        SqlDataReader drGenel;
        #endregion

        public enum SiparisTip
        {
            AlinanSiparis = IslemTipi.AlinanSiparis,
            VerilenSiparis = IslemTipi.VerilenSiparis
        }

        cari.csCariv2 Cari;
        /// <summary>
        /// Burada SAdece SiparisID yi gir sana Siparisyı getirsin hamısına koyim...
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="SiparisID"></param>
        public csSiparis(SqlConnection Baglanti, SqlTransaction Tr, int SiparisID)
        {
            SiparisGetir(Baglanti, Tr, SiparisID);
        }
        /// <summary>
        /// Yani Siparis oluşturuyorsa sadece Siparis Tipi Ve Cari ID lazım
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="SiparisTipi"></param>
        /// <param name="CariID"></param>
        public csSiparis(SqlConnection Baglanti, SqlTransaction Tr, SiparisTip SiparisTipi, int CariID)
        {

            _SiparisID = -1;
            _SiparisTipi = SiparisTipi;
            _SiparisTarihi = DateTime.Now;
            _DuzenlemeTarihi = DateTime.Now;
            _Vadesi = DateTime.Now;
            _TeslimTarihi = DateTime.Now;
            _SiparisNo = string.Empty;
            _CariID = CariID;
            _CariKod = string.Empty;
            _CariTanim = string.Empty;
            _VergiDairesi = string.Empty;
            _VergiNo = string.Empty;
            _Adres = string.Empty;
            _Il = string.Empty;
            _Ilce = string.Empty;
            _Iptal = false;
            _SilindiMi = false;
            _Aciklama = string.Empty;
            _KaydedenID = -1;
            _KayitTarihi = DateTime.Now;
            _DegistirenID = -1;
            _DegismeTarihi = DateTime.Now;
            _DepoID = -1;
            _SatisElemaniID = -1;
            _Toplam_Iskontosuz_Kdvsiz = 0;
            _CariIskontoToplami = 0;
            _StokIskontoToplami = 0;
            _ToplamIndirim = 0;
            _ToplamKdv = 0;
            _IskontoluToplam = 0;
            _SiparisTutari = 0;
            _KullanilanFiyatTanimID = -1;
            _Faturalandi = FaturalandiMi.Faturalanmadi;
            _SiparisGrupID = -1;
            _SiparisDurumTanimID = -1;
            _SiparisBarkodNu = string.Empty;
            _HizliSatistaGozukecekMi = false;
            _HizliSatistaDegisiklikYapmaIzniVarMi = false;
            _PersonelAdi = string.Empty;
        }

        public enum FaturalandiMi
        {
            Faturalanmadi = 1,
            Faturalandi = 2,
            KismiFaturalandi = 3
        }
        /// <summary>
        /// İlk değerleri atamaz sadece SiparisListeGetir için kullanılır! hamısına
        /// </summary>
        public csSiparis()
        {

        }
        private void SiparisGetir(SqlConnection Baglanti, SqlTransaction Tr, int SiparisID)
        {
            try
            {
                using (cmdGenel = new SqlCommand())
                {
                    cmdGenel.Connection = Baglanti;
                    cmdGenel.Transaction = Tr;
                    cmdGenel.CommandText = @"
select SiparisID, SiparisTipi, SiparisTarihi, DuzenlemeTarihi, Vadesi, TeslimTarihi, SiparisNo, s.CariID, s.CariKod, s.CariTanim, s.VergiDairesi, VergiNo, Adres, Il, Ilce, Iptal, 
s.SilindiMi, s.Aciklama, s.KaydedenID, s.KayitTarihi, s.DegistirenID, s.DegismeTarihi, DepoID, SatisElemaniID, Toplam_Iskontosuz_Kdvsiz, CariIskontoToplami, StokIskontoToplami, 
ToplamIndirim, ToplamKdv, IskontoluToplam, SiparisTutari, KullanilanFiyatTanimID, SiparisGrupID, Faturalandi, SiparisDurumTanimID, SiparisBarkodNu,HizliSatistaGozukecekMi , HizliSatistaDegisiklikYapmaIzniVarMi, PersonelCarisi.CariTanim as PersonelAdi from Siparis as S
left join Personel on PersonelID = SatisElemaniID
left join cari as PersonelCarisi on PersonelCarisi.CariID = Personel.CariID
WHERE     (s.SiparisID = @SiparisID)";
                    cmdGenel.Parameters.Add("@SiparisID", SqlDbType.Int).Value = SiparisID;
                    using (drGenel = cmdGenel.ExecuteReader())
                    {
                        drGenel.Read();
                        _SiparisID = Convert.ToInt32(drGenel["SiparisID"]);
                        _SiparisTipi = (SiparisTip)(Convert.ToInt32(drGenel["SiparisTipi"]));
                        _SiparisTarihi = Convert.ToDateTime(drGenel["SiparisTarihi"]);
                        _DuzenlemeTarihi = Convert.ToDateTime(drGenel["DuzenlemeTarihi"]);
                        _Vadesi = Convert.ToDateTime(drGenel["Vadesi"]);
                        _TeslimTarihi = Convert.ToDateTime(drGenel["TeslimTarihi"]);
                        _SiparisNo = drGenel["SiparisNo"].ToString();
                        _CariID = Convert.ToInt32(drGenel["CariID"]);
                        _CariKod = drGenel["CariKod"].ToString();
                        _CariTanim = drGenel["CariTanim"].ToString();
                        _VergiDairesi = drGenel["VergiDairesi"].ToString();
                        _VergiNo = drGenel["VergiNo"].ToString();
                        _Adres = drGenel["Adres"].ToString();
                        _Il = drGenel["Il"].ToString();
                        _Ilce = drGenel["Ilce"].ToString();
                        _Iptal = Convert.ToBoolean(drGenel["Iptal"]);
                        _SilindiMi = Convert.ToBoolean(drGenel["SilindiMi"]);
                        _Aciklama = drGenel["Aciklama"].ToString();
                        _KaydedenID = Convert.ToInt32(drGenel["KaydedenID"]);
                        _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"]);

                        int.TryParse(drGenel["DegistirenID"].ToString(), out _DegistirenID);

                        DateTime.TryParse(drGenel["DegismeTarihi"].ToString(), out _DegismeTarihi);

                        _DepoID = Convert.ToInt32(drGenel["DepoID"]);
                        _SatisElemaniID = Convert.ToInt32(drGenel["SatisElemaniID"]);
                        _Toplam_Iskontosuz_Kdvsiz = Convert.ToDecimal(drGenel["Toplam_Iskontosuz_Kdvsiz"]);
                        _CariIskontoToplami = Convert.ToDecimal(drGenel["CariIskontoToplami"]);
                        _StokIskontoToplami = Convert.ToDecimal(drGenel["StokIskontoToplami"]);
                        _ToplamIndirim = Convert.ToDecimal(drGenel["ToplamIndirim"]);
                        _ToplamKdv = Convert.ToDecimal(drGenel["ToplamKdv"]);
                        _IskontoluToplam = Convert.ToDecimal(drGenel["IskontoluToplam"]);
                        _SiparisTutari = Convert.ToDecimal(drGenel["SiparisTutari"]);
                        _KullanilanFiyatTanimID = Convert.ToInt32(drGenel["KullanilanFiyatTanimID"]);
                        _Faturalandi = (FaturalandiMi)drGenel["Faturalandi"];
                        _SiparisGrupID = Convert.ToInt32(drGenel["SiparisGrupID"]);
                        _SiparisDurumTanimID = Convert.ToInt32(drGenel["SiparisDurumTanimID"]);
                        _SiparisBarkodNu = drGenel["SiparisBarkodNu"].ToString();
                        _HizliSatistaGozukecekMi = Convert.ToBoolean(drGenel["HizliSatistaGozukecekMi"]);
                        _HizliSatistaDegisiklikYapmaIzniVarMi = Convert.ToBoolean(drGenel["HizliSatistaDegisiklikYapmaIzniVarMi"]);
                        _PersonelAdi = drGenel["PersonelAdi"].ToString();
                    }
                }
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }
        public void SiparisKAydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            if (_SiparisID == -1)
            {
                cmdGenel = new SqlCommand(@"insert into Siparis 
( SiparisTipi, SiparisTarihi, DuzenlemeTarihi, Vadesi, TeslimTarihi, SiparisNo, CariID, CariKod, CariTanim, VergiDairesi, VergiNo, Adres, Il, 
Ilce, Iptal, SilindiMi, Aciklama, KaydedenID, KayitTarihi, DepoID, SatisElemaniID, Toplam_Iskontosuz_Kdvsiz, 
CariIskontoToplami, StokIskontoToplami, ToplamIndirim, ToplamKdv, IskontoluToplam, SiparisTutari, KullanilanFiyatTanimID, Faturalandi , SiparisGrupID, SiparisDurumTanimID, SiparisBarkodNu, HizliSatistaGozukecekMi, HizliSatistaDegisiklikYapmaIzniVarMi) 
values 
( @SiparisTipi, @SiparisTarihi, @DuzenlemeTarihi, @Vadesi, @TeslimTarihi, @SiparisNo, @CariID, @CariKod, @CariTanim, @VergiDairesi, @VergiNo, @Adres, @Il, 
@Ilce, @Iptal, @SilindiMi, @Aciklama, @KaydedenID, @KayitTarihi, @DepoID, @SatisElemaniID, @Toplam_Iskontosuz_Kdvsiz, 
@CariIskontoToplami, @StokIskontoToplami, @ToplamIndirim, @ToplamKdv, @IskontoluToplam, @SiparisTutari, @KullanilanFiyatTanimID, @Faturalandi, @SiparisGrupID, @SiparisDurumTanimID, @SiparisBarkodNu, @HizliSatistaGozukecekMi, @HizliSatistaDegisiklikYapmaIzniVarMi)  
set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);

                // bu iki parametre sadece insertte var.
                cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
                cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
            }
            else
            {
                cmdGenel = new SqlCommand(@"update Siparis set 
SiparisTipi = @SiparisTipi, SiparisTarihi = @SiparisTarihi, DuzenlemeTarihi = @DuzenlemeTarihi, Vadesi = @Vadesi, TeslimTarihi = @TeslimTarihi ,SiparisNo = @SiparisNo, 
CariID = @CariID, CariKod = @CariKod, CariTanim = @CariTanim, VergiDairesi = @VergiDairesi, VergiNo = @VergiNo, Adres = @Adres, Il = @Il, Ilce = @Ilce, 
Iptal = @Iptal, SilindiMi = @SilindiMi, Aciklama = @Aciklama, DegistirenID = @DegistirenID, DegismeTarihi = @DegismeTarihi, DepoID = @DepoID, SatisElemaniID = @SatisElemaniID, 
Toplam_Iskontosuz_Kdvsiz = @Toplam_Iskontosuz_Kdvsiz, CariIskontoToplami = @CariIskontoToplami, StokIskontoToplami = @StokIskontoToplami, 
ToplamIndirim = @ToplamIndirim, ToplamKdv = @ToplamKdv, IskontoluToplam = @IskontoluToplam, SiparisTutari = @SiparisTutari, 
KullanilanFiyatTanimID = @KullanilanFiyatTanimID, Faturalandi = @Faturalandi, SiparisGrupID = @SiparisGrupID, SiparisDurumTanimID = @SiparisDurumTanimID, SiparisBarkodNu = @SiparisBarkodNu, HizliSatistaGozukecekMi = @HizliSatistaGozukecekMi, HizliSatistaDegisiklikYapmaIzniVarMi = @HizliSatistaDegisiklikYapmaIzniVarMi
where SiparisID = @SiparisID", Baglanti, Tr);

                // bu üç parametre sadece Update te var.
                cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
                cmdGenel.Parameters.Add("@SiparisID", SqlDbType.Int).Value = _SiparisID;
            }

            cmdGenel.Parameters.Add("@SiparisTipi", SqlDbType.Int).Value = _SiparisTipi;
            cmdGenel.Parameters.Add("@SiparisTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(_SiparisTarihi);
            cmdGenel.Parameters.Add("@DuzenlemeTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(_DuzenlemeTarihi);
            cmdGenel.Parameters.Add("@Vadesi", SqlDbType.DateTime).Value = Convert.ToDateTime(_Vadesi);
            cmdGenel.Parameters.Add("@TeslimTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(_TeslimTarihi);
            cmdGenel.Parameters.Add("@SiparisNo", SqlDbType.NVarChar).Value = _SiparisNo;
            cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
            cmdGenel.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKod;
            cmdGenel.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanim;
            cmdGenel.Parameters.Add("@VergiDairesi", SqlDbType.NVarChar).Value = _VergiDairesi;
            cmdGenel.Parameters.Add("@VergiNo", SqlDbType.NVarChar).Value = _VergiNo;
            cmdGenel.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = _Adres;
            cmdGenel.Parameters.Add("@Il", SqlDbType.NVarChar).Value = _Il.ToString();
            cmdGenel.Parameters.Add("@Ilce", SqlDbType.NVarChar).Value = _Ilce.ToString();
            cmdGenel.Parameters.Add("@Iptal", SqlDbType.Bit).Value = _Iptal;
            cmdGenel.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;
            cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
            cmdGenel.Parameters.Add("@DepoID", SqlDbType.Int).Value = _DepoID;
            cmdGenel.Parameters.Add("@SatisElemaniID", SqlDbType.Int).Value = _SatisElemaniID;
            cmdGenel.Parameters.Add("@Toplam_Iskontosuz_Kdvsiz", SqlDbType.Decimal).Value = _Toplam_Iskontosuz_Kdvsiz;
            cmdGenel.Parameters.Add("@CariIskontoToplami", SqlDbType.Decimal).Value = _CariIskontoToplami;
            cmdGenel.Parameters.Add("@StokIskontoToplami", SqlDbType.Decimal).Value = _StokIskontoToplami;
            cmdGenel.Parameters.Add("@ToplamIndirim", SqlDbType.Decimal).Value = _ToplamIndirim;
            cmdGenel.Parameters.Add("@ToplamKdv", SqlDbType.Decimal).Value = _ToplamKdv;
            cmdGenel.Parameters.Add("@IskontoluToplam", SqlDbType.Decimal).Value = _IskontoluToplam;
            cmdGenel.Parameters.Add("@SiparisTutari", SqlDbType.Decimal).Value = _SiparisTutari;
            cmdGenel.Parameters.Add("@KullanilanFiyatTanimID", SqlDbType.Int).Value = _KullanilanFiyatTanimID;
            cmdGenel.Parameters.Add("@Faturalandi", SqlDbType.Int).Value = _Faturalandi;
            cmdGenel.Parameters.Add("@SiparisGrupID", SqlDbType.Int).Value = _SiparisGrupID;
            cmdGenel.Parameters.Add("@SiparisDurumTanimID", SqlDbType.Int).Value = _SiparisDurumTanimID;
            cmdGenel.Parameters.Add("@SiparisBarkodNu", SqlDbType.NVarChar).Value = _SiparisBarkodNu;
            cmdGenel.Parameters.Add("@HizliSatistaGozukecekMi", SqlDbType.Bit).Value = _HizliSatistaGozukecekMi;
            cmdGenel.Parameters.Add("@HizliSatistaDegisiklikYapmaIzniVarMi", SqlDbType.Bit).Value = HizliSatistaDegisiklikYapmaIzniVarMi;


            try
            {
                cmdGenel.ExecuteNonQuery();
                if (_SiparisID == -1)
                    _SiparisID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }

        public void SiparisSil(SqlConnection Baglanti, SqlTransaction Tr, int SiparisID) // hem siparişi hem hareketlerini siliyoruz
        {
            using (cmdGenel = new SqlCommand(@"update Siparis set SilindiMi = 1 where SiparisID  = @SiparisID 
            update SiparisHareket set Silindi = 1 where SiparisID  = @SiparisID", Baglanti, Tr))
            {
                cmdGenel.Parameters.Add("@SiparisID", SqlDbType.Int).Value = SiparisID;
                cmdGenel.ExecuteNonQuery();
            }
        }
        clsTablolar.EvrakIliski.csEvrakIliski evrakIliski = new EvrakIliski.csEvrakIliski();

        public string SiparisiSatisaAktar(SqlConnection Baglanti, SqlTransaction Tr, int SiparisID, int SiparisiFaturayaAktaranPersonelID)
        {
            if (evrakIliski.SiparisFaturayaAktarilmisMi(Baglanti, Tr, SiparisID) == clsTablolar.EvrakIliski.csEvrakIliski.SiparisinFaturayaAktarilmaDurumu.Faturalandi)
            {
                //TrGenel.Commit();
                //MesajGoster("Daha Önce Satışa Aktarılmış");
                return "";
            }

            using (SqlCommand cmd = new SqlCommand("SiparisiFaturayaAktar", Baglanti, Tr))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SiparisID", SqlDbType.Int).Value = SiparisID;
                cmd.Parameters.Add("@SiparisiFaturayaAktaranPersonelID", SqlDbType.Int).Value = SiparisiFaturayaAktaranPersonelID;

                cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return cmd.Parameters["@Barkod"].Value.ToString();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
