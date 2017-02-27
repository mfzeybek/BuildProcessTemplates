using System;
using System.Data;
using System.Data.SqlClient;



namespace clsTablolar.Fatura
{
    public class csFatura : IDisposable
    {

        #region Değişkenler


        private int _FaturaID;
        private IslemTipi _FaturaTipi;
        private DateTime _FaturaTarihi;
        private DateTime _DuzenlemeTarihi;
        private string _FaturaNo;
        private int _CariID;
        private string _CariKod;
        private string _CariTanim;
        private string _VergiDairesi;
        private string _VergiNo;
        private string _Adres;
        private string _Il;
        private string _Ilce;
        private DateTime _Vadesi;
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
        private decimal _FaturaTutari;
        private int _KullanilanFiyatTanimID;
        private int _FaturaGrupID;
        private bool _OdendiMi; // bu silinecek odendi mi diye bir kolon olmayacak artık
        private string _FaturaBarkod;

        private bool _HizliSatistaGozukecekMi;
        private bool _HizliSatistaDegisiklikYapilmasinaIzniVarMi;






        #endregion

        #region Methodlar

        public int FaturaID
        {
            get { return _FaturaID; }
            set { _FaturaID = value; }
        }
        public IslemTipi FaturaTipi
        {
            get { return _FaturaTipi; }
            set { _FaturaTipi = value; }
        }
        public DateTime FaturaTarihi
        {
            get { return _FaturaTarihi; }
            set { _FaturaTarihi = value; }
        }
        public DateTime DuzenlemeTarihi
        {
            get { return _DuzenlemeTarihi; }
            set { _DuzenlemeTarihi = value; }
        }
        public string FaturaNo
        {
            get { return _FaturaNo; }
            set { _FaturaNo = value; }
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
        public string Adres //  burada değişiklik var
        {
            get
            {
                if (_Adres == null)
                    return "";
                return _Adres;
            }
            set { _Adres = value; }
        }
        public string Il//  burada değişiklik var
        {
            get
            {
                if (_Il == null)
                    return "";
                return _Il;
            }
            set
            {
                if (_Il == null)
                    _Il = "";
                _Il = value;
            }
        }
        public string Ilce//  burada değişiklik var
        {
            get
            {
                if (_Ilce == null)
                    return "";
                return _Ilce;
            }
            set { _Ilce = value; }
        }
        public DateTime Vadesi
        {
            get { return _Vadesi; }
            set { _Vadesi = value; }
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
        public decimal FaturaTutari
        {
            get { return _FaturaTutari; }
            set { _FaturaTutari = value; }
        }
        public int KullanilanFiyatTanimID
        {
            get { return _KullanilanFiyatTanimID; }
            set { _KullanilanFiyatTanimID = value; }
        }
        public int FaturaGrupID
        {
            get { return _FaturaGrupID; }
            set { _FaturaGrupID = value; }
        }

        public bool OdendiMi
        {
            get { return _OdendiMi; }
            set { _OdendiMi = value; }
        }

        public string FaturaBarkod
        {
            get
            {
                return _FaturaBarkod;
            }

            set
            {
                _FaturaBarkod = value;
            }
        }

        public bool HizliSatistaGozukecekMi
        {
            get
            {
                return _HizliSatistaGozukecekMi;
            }

            set
            {
                _HizliSatistaGozukecekMi = value;
            }
        }

        public bool HizliSatistaDegisiklikYapilmasinaIzniVarMi
        {
            get
            {
                return _HizliSatistaDegisiklikYapilmasinaIzniVarMi;
            }

            set
            {
                _HizliSatistaDegisiklikYapilmasinaIzniVarMi = value;
            }
        }



        #endregion

        #region Genel DeğişkEnler
        SqlCommand cmdGenel;
        SqlDataReader drGenel;

        #endregion





        public cari.csCariv2 Cari;
        public csDepo Depo;
        public Personel.csSatistaGorevliPersonel SatisPersoneli;
        /// <summary>
        /// Burada SAdece FaturaID yi gir sana Faturayı getirsin hamısına koyim...
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="FaturaID"></param>
        public csFatura(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            FaturaGetir(Baglanti, Tr, FaturaID);
            Depo = new csDepo(Baglanti, Tr);
            SatisPersoneli = new Personel.csSatistaGorevliPersonel();
        }
        /// <summary>
        /// Yani Fatura oluşturuyorsa sadece Fatura Tipi Ve Cari ID lazım
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="FaturaTipi"></param>
        /// <param name="CariID"></param>
        public csFatura(SqlConnection Baglanti, SqlTransaction Tr, IslemTipi IslemTipi, int CariID)
        {
            _FaturaID = -1;
            _FaturaTipi = IslemTipi;
            Cari = new cari.csCariv2(Baglanti, Tr, CariID);
            _CariID = Cari.CariID;
            _CariTanim = Cari.CariTanim;
            _CariKod = Cari.CariKod;
            _FaturaTarihi = DateTime.Now;
            _Vadesi = DateTime.Now;
            _DuzenlemeTarihi = DateTime.Now;
            _Iptal = false;
            _SilindiMi = false;
            _KayitTarihi = DateTime.Now;
            _KaydedenID = -1;
            _Aciklama = string.Empty;
            _VergiDairesi = string.Empty;
            _VergiNo = string.Empty;
            _Adres = string.Empty;
            _DepoID = -1;
            _SatisElemaniID = -1;
            _KullanilanFiyatTanimID = -1;
            _FaturaGrupID = -1;
            _FaturaBarkod = string.Empty;
            _OdendiMi = false;
            _HizliSatistaGozukecekMi = false;
            _HizliSatistaDegisiklikYapilmasinaIzniVarMi = false;

            Depo = new csDepo(Baglanti, Tr);
            SatisPersoneli = new Personel.csSatistaGorevliPersonel();
            if (_FaturaTipi == IslemTipi.SatisFaturasi) // 1 SATIŞ FATURASI ayarlardan sabit bişiler getiriyor hamısına
            {
                _DepoID = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiDepoID;
                _SatisElemaniID = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiSatisElemaniID;
            }
        }


        string selectcomtxt = @"SELECT dbo.Fatura.FaturaID, dbo.Fatura.FaturaTipi, dbo.Fatura.CariID, dbo.Fatura.CariKod,Fatura.CariTanim ,dbo.Fatura.VergiDairesi, dbo.Fatura.VergiNo, dbo.Fatura.Adres, dbo.Fatura.Il, 
               dbo.Fatura.Ilce, dbo.Fatura.FaturaNo, dbo.Fatura.FaturaTarihi, dbo.Fatura.Vadesi, dbo.Fatura.Iptal, dbo.Fatura.SilindiMi, dbo.Fatura.KayitTarihi, 
               dbo.Fatura.KaydedenID, dbo.Fatura.DegismeTarihi, dbo.Fatura.DegistirenID, dbo.Fatura.Aciklama,  dbo.Fatura.ToplamIndirim, 
               dbo.Fatura.ToplamKdv, dbo.Fatura.DuzenlemeTarihi, dbo.Fatura.DepoID, dbo.Fatura.SatisElemaniID, dbo.Fatura.CariIskontoToplami, 
               dbo.Fatura.StokIskontoToplami, dbo.Fatura.Toplam_Iskontosuz_Kdvsiz, dbo.Fatura.FaturaTutari, dbo.Fatura.IskontoluToplam, dbo.Fatura.KullanilanFiyatTanimID, Fatura.FaturaGrupID, Fatura.FaturaBarkod, Fatura.HizliSatistaGozukecekMi, Fatura.HizliSatistaDegisiklikYapilmasinaIzniVarMi
FROM  dbo.Fatura INNER JOIN
               dbo.Cari ON dbo.Fatura.CariID = dbo.Cari.CariID
WHERE     (dbo.Fatura.FaturaID = @FaturaID) ";

        private void FaturaGetir(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID) // ilerde burasını da ayırmak gerekiyor
        { // neden mi çünkü aşağıdaki sql e başka yerlerde de ihtiyaç olabiliyor
            try
            {
                using (cmdGenel = new SqlCommand())
                {
                    cmdGenel.Connection = Baglanti;
                    cmdGenel.Transaction = Tr;
                    cmdGenel.CommandText = selectcomtxt;
                    cmdGenel.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;



                    using (drGenel = cmdGenel.ExecuteReader())
                    {
                        drGenel.Read();


                        _FaturaID = Convert.ToInt32(drGenel["FaturaID"]);

                        _FaturaTipi = (IslemTipi)Enum.Parse(typeof(IslemTipi), drGenel["FaturaTipi"].ToString());
                        _CariID = Convert.ToInt32(drGenel["CariID"]);
                        _CariKod = drGenel["CariKod"].ToString();
                        _CariTanim = drGenel["CariTanim"].ToString();
                        _VergiDairesi = drGenel["VergiDairesi"].ToString();
                        _VergiNo = drGenel["VergiNo"].ToString();
                        _Adres = drGenel["Adres"].ToString();
                        _Il = drGenel["Il"].ToString();
                        _Ilce = drGenel["Ilce"].ToString();
                        _FaturaNo = drGenel["FaturaNo"].ToString();
                        _FaturaTarihi = Convert.ToDateTime(drGenel["FaturaTarihi"]);
                        _Vadesi = Convert.ToDateTime(drGenel["Vadesi"]);
                        _Iptal = Convert.ToBoolean(drGenel["Iptal"]);
                        _SilindiMi = Convert.ToBoolean(drGenel["SilindiMi"]);
                        _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"]);
                        _KaydedenID = Convert.ToInt32(drGenel["KaydedenID"]);
                        DateTime.TryParse(drGenel["DegismeTarihi"].ToString(), out _DegismeTarihi);
                        //_DegismeTarihi = Convert.ToDateTime(drGenel["DegismeTarihi"]);
                        int.TryParse(drGenel["DegistirenID"].ToString(), out _DegistirenID);
                        //_DegistirenID = Convert.ToInt32(drGenel["DegistirenID"]);
                        _Aciklama = drGenel["Aciklama"].ToString();
                        _ToplamIndirim = Convert.ToDecimal(drGenel["ToplamIndirim"]);
                        _ToplamKdv = Convert.ToDecimal(drGenel["ToplamKdv"]);

                        if (!int.TryParse(drGenel["KullanilanFiyatTanimID"].ToString(), out _KullanilanFiyatTanimID))
                            _KullanilanFiyatTanimID = -1;



                        _DuzenlemeTarihi = Convert.ToDateTime(drGenel["DuzenlemeTarihi"]);

                        if (drGenel["DepoID"].ToString() != "") // bunları get set ile ayarlamak gerek aslında
                            _DepoID = Convert.ToInt32(drGenel["DepoID"]);

                        if (drGenel["SatisElemaniID"].ToString() != "")
                            _SatisElemaniID = Convert.ToInt32(drGenel["SatisElemaniID"]);

                        CariIskontoToplami = Convert.ToDecimal(drGenel["CariIskontoToplami"]);
                        StokIskontoToplami = Convert.ToDecimal(drGenel["StokIskontoToplami"]);

                        _Toplam_Iskontosuz_Kdvsiz = Convert.ToDecimal(drGenel["Toplam_Iskontosuz_Kdvsiz"]);
                        _FaturaTutari = Convert.ToDecimal(drGenel["FaturaTutari"]);

                        _FaturaGrupID = Convert.ToInt32(drGenel["FaturaGrupID"]);
                        _FaturaBarkod = drGenel["FaturaBarkod"].ToString();
                        _HizliSatistaGozukecekMi = (bool)drGenel["HizliSatistaGozukecekMi"];
                        _HizliSatistaDegisiklikYapilmasinaIzniVarMi = (bool)drGenel["HizliSatistaDegisiklikYapilmasinaIzniVarMi"];
                    }
                }
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }
        /// <summary>
        /// Geriye FaturaID döndürüyor;
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <returns></returns>
        public int FaturaKaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            if (_FaturaID == -1)
            {
                cmdGenel = new SqlCommand(@"

set @FaturaBarkod = (select [dbo].[YeniBarkodNumarasiVer]())

insert into Fatura 
( FaturaTipi, FaturaTarihi, DuzenlemeTarihi, FaturaNo, CariID, CariKod, CariTanim, VergiDairesi, VergiNo, Adres, Il, Ilce, Vadesi,
Iptal, SilindiMi, Aciklama, KaydedenID, KayitTarihi, DepoID, SatisElemaniID, Toplam_Iskontosuz_Kdvsiz, 
CariIskontoToplami, StokIskontoToplami, ToplamIndirim, ToplamKdv, IskontoluToplam, FaturaTutari, KullanilanFiyatTanimID, FaturaGrupID, OdendiMi, FaturaBarkod, HizliSatistaGozukecekMi , HizliSatistaDegisiklikYapilmasinaIzniVarMi)
values 
( @FaturaTipi, @FaturaTarihi, @DuzenlemeTarihi, @FaturaNo, @CariID, @CariKod, @CariTanim, @VergiDairesi, @VergiNo, @Adres, 
@Il, @Ilce, @Vadesi, @Iptal, @SilindiMi, @Aciklama, @KaydedenID, @KayitTarihi, @DepoID, @SatisElemaniID, 
@Toplam_Iskontosuz_Kdvsiz, @CariIskontoToplami, @StokIskontoToplami, @ToplamIndirim, @ToplamKdv, @IskontoluToplam, @FaturaTutari, @KullanilanFiyatTanimID, @FaturaGrupID, @OdendiMi, @FaturaBarkod, @HizliSatistaGozukecekMi , @HizliSatistaDegisiklikYapilmasinaIzniVarMi) 
set @YeniID = SCOPE_IDENTITY()

update BarkodAyar set BarkodAyar.SiradakiKod += 1 where BarkodAyar.BarkodunKullanildigiYer = 2

", Baglanti, Tr);

                cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;

                cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmdGenel.Parameters.Add("@FaturaBarkod", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
            }
            else
            {
                cmdGenel = new SqlCommand(@"update Fatura set FaturaTipi = @FaturaTipi, FaturaTarihi = @FaturaTarihi, 
DuzenlemeTarihi = @DuzenlemeTarihi, FaturaNo = @FaturaNo, CariID = @CariID, CariKod = @CariKod, CariTanim = @CariTanim, 
VergiDairesi = @VergiDairesi, VergiNo = @VergiNo, Adres = @Adres, Il = @Il, Ilce = @Ilce, Vadesi = @Vadesi, Iptal = @Iptal, 
SilindiMi = @SilindiMi, Aciklama = @Aciklama, DegistirenID = @DegistirenID,
DegismeTarihi = @DegismeTarihi, DepoID = @DepoID, SatisElemaniID = @SatisElemaniID, Toplam_Iskontosuz_Kdvsiz = @Toplam_Iskontosuz_Kdvsiz, 
CariIskontoToplami = @CariIskontoToplami, StokIskontoToplami = @StokIskontoToplami, ToplamIndirim = @ToplamIndirim, ToplamKdv = @ToplamKdv, 
IskontoluToplam = @IskontoluToplam, FaturaTutari = @FaturaTutari, KullanilanFiyatTanimID = @KullanilanFiyatTanimID, FaturaGrupID = @FaturaGrupID , OdendiMi = @OdendiMi, HizliSatistaGozukecekMi = @HizliSatistaGozukecekMi, HizliSatistaDegisiklikYapilmasinaIzniVarMi = @HizliSatistaDegisiklikYapilmasinaIzniVarMi
where FaturaID = @FaturaID ", Baglanti, Tr);

                cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
                cmdGenel.Parameters.Add("@FaturaID", SqlDbType.Int).Value = _FaturaID;
            }

            cmdGenel.Parameters.Add("@FaturaTipi", SqlDbType.Int).Value = _FaturaTipi;
            cmdGenel.Parameters.Add("@FaturaTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(_FaturaTarihi);
            cmdGenel.Parameters.Add("@DuzenlemeTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(_DuzenlemeTarihi);
            cmdGenel.Parameters.Add("@FaturaNo", SqlDbType.NVarChar).Value = _FaturaNo;
            cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
            cmdGenel.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKod;
            cmdGenel.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanim;
            cmdGenel.Parameters.Add("@VergiDairesi", SqlDbType.NVarChar).Value = _VergiDairesi;
            cmdGenel.Parameters.Add("@VergiNo", SqlDbType.NVarChar).Value = _VergiNo;
            cmdGenel.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = Adres;
            cmdGenel.Parameters.Add("@Il", SqlDbType.NVarChar).Value = Il;
            cmdGenel.Parameters.Add("@Ilce", SqlDbType.NVarChar).Value = Ilce;
            cmdGenel.Parameters.Add("@Vadesi", SqlDbType.DateTime).Value = Convert.ToDateTime(_Vadesi);
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
            cmdGenel.Parameters.Add("@FaturaTutari", SqlDbType.Decimal).Value = _FaturaTutari;
            cmdGenel.Parameters.Add("@KullanilanFiyatTanimID", SqlDbType.Int).Value = _KullanilanFiyatTanimID;
            cmdGenel.Parameters.Add("@FaturaGrupID", SqlDbType.Int).Value = _FaturaGrupID;
            cmdGenel.Parameters.Add("@OdendiMi", SqlDbType.Bit).Value = 0;
            //cmdGenel.Parameters.Add("@FaturaBarkod", SqlDbType.NVarChar).Value = _FaturaBarkod;
            cmdGenel.Parameters.Add("@HizliSatistaGozukecekMi", SqlDbType.Bit).Value = _HizliSatistaGozukecekMi;
            cmdGenel.Parameters.Add("@HizliSatistaDegisiklikYapilmasinaIzniVarMi", SqlDbType.Bit).Value = _HizliSatistaDegisiklikYapilmasinaIzniVarMi;


            try
            {
                cmdGenel.ExecuteNonQuery();
                if (_FaturaID == -1)
                {
                    _FaturaID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
                    _FaturaBarkod = cmdGenel.Parameters["@FaturaBarkod"].Value.ToString();
                }
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
            return _FaturaID;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
