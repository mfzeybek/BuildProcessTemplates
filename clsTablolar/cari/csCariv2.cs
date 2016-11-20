using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
    public class csCariv2 : IDisposable
    {
        #region Değişkenler
        private int _CariID;
        private bool _Aktif;
        private string _CariKod;
        private string _CariTanim;
        private string _OzelKod1;
        private string _OzelKod2;
        private string _OzelKod3;
        private string _VergiDairesi;
        private string _VergiNumarasi;
        private int _CariGrupID;
        private int _CariAltGrupID;
        private string _WebSayfasi;
        private string _Aciklama;
        private int _KaydedenID;
        private DateTime _KayitTarihi;
        private int _DegistirenID;
        private DateTime _DegismeTarihi;
        private int _CariFiyatTanimID;
        private decimal _iskOrani1;
        private decimal _iskOrani2;
        private decimal _iskOrani3;
        private bool _SilindiMi;


        private string _BankaAdi;
        private string _BankaSubeAdi;
        private string _BankaSubeKodu;
        private string _BankaHesapNo;
        private string _BankaIbanNo;
        private string _BankaAciklama;


        #endregion

        #region Methodlar
        public int CariID
        {
            get { return _CariID; }
            set { _CariID = value; }
        }
        public bool Aktif
        {
            get { return _Aktif; }
            set { _Aktif = value; }
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
        public string VergiDairesi
        {
            get { return _VergiDairesi; }
            set { _VergiDairesi = value; }
        }
        public string VergiNumarasi
        {
            get { return _VergiNumarasi; }
            set { _VergiNumarasi = value; }
        }
        public int CariGrupID
        {
            get { return _CariGrupID; }
            set { _CariGrupID = value; }
        }
        public int CariAltGrupID
        {
            get { return _CariAltGrupID; }
            set { _CariAltGrupID = value; }
        }

        public string WebSayfasi
        {
            get { return _WebSayfasi; }
            set { _WebSayfasi = value; }
        }
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }
        public bool SilindiMi
        {
            get { return _SilindiMi; }
            set { _SilindiMi = value; }
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
        public int CariFiyatTanimID
        {
            get { return _CariFiyatTanimID; }
            set { _CariFiyatTanimID = value; }
        }
        public decimal IskOrani1
        {
            get { return _iskOrani1; }
            set { _iskOrani1 = value; }
        }
        public decimal IskOrani2
        {
            get { return _iskOrani2; }
            set { _iskOrani2 = value; }
        }
        public decimal IskOrani3
        {
            get { return _iskOrani3; }
            set { _iskOrani3 = value; }
        }

        public string BankaAdi
        {
            get { return _BankaAdi; }
            set { _BankaAdi = value; }
        }
        public string BankaSubeAdi
        {
            get { return _BankaSubeAdi; }
            set { _BankaSubeAdi = value; }
        }
        public string BankaSubeKodu
        {
            get { return _BankaSubeKodu; }
            set { _BankaSubeKodu = value; }
        }
        public string BankaHesapNo
        {
            get { return _BankaHesapNo; }
            set { _BankaHesapNo = value; }
        }
        public string BankaIbanNo
        {
            get { return _BankaIbanNo; }
            set { _BankaIbanNo = value; }
        }
        public string BankaAciklama
        {
            get { return _BankaAciklama; }
            set { _BankaAciklama = value; }
        }

        #endregion

        #region Genel DeğişkEnler
        SqlCommand cmdGenel;
        SqlDataReader drGenel;
        #endregion

        public csCariv2(SqlConnection Baglanti, SqlTransaction Tr, int CariID)
        {
            if (CariID == -1)
            {
                _CariID = -1;
                _Aktif = true;
                _CariKod = string.Empty;
                _CariTanim = string.Empty;
                _OzelKod1 = string.Empty;
                _OzelKod2 = string.Empty;
                _OzelKod3 = string.Empty;
                _VergiDairesi = string.Empty;
                _VergiNumarasi = string.Empty;
                _CariGrupID = -1;
                _CariAltGrupID = -1;
                _WebSayfasi = string.Empty;
                _Aciklama = string.Empty;
                _SilindiMi = false;
                _KaydedenID = -1;
                _KayitTarihi = DateTime.Now;
                _DegistirenID = -1;
                _DegismeTarihi = DateTime.MinValue;
                _iskOrani1 = 0;
                _iskOrani1 = 0;
                _iskOrani1 = 0;

                _CariFiyatTanimID = -1;


                _BankaAdi = string.Empty;
                _BankaSubeAdi = string.Empty;
                _BankaSubeKodu = string.Empty;
                _BankaHesapNo = string.Empty;
                _BankaIbanNo = string.Empty;
                _BankaAciklama = string.Empty;

            }
            else
            {
                CariGetir(Baglanti, Tr, CariID);
            }
        }
        private string IDBossaEksiBirVer(object ID)
        {
            string ID2 = "";
            if (ID == null || ID.ToString() == "" || ID == DBNull.Value)
            {
                ID2 = "-1";
            }
            else
            {
                ID2 = ID.ToString();
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
        private void CariGetir(SqlConnection Baglanti, SqlTransaction Tr, int CariID)
        {
            using (cmdGenel = new SqlCommand())
            {
                cmdGenel.Connection = Baglanti;
                cmdGenel.Transaction = Tr;
                cmdGenel.CommandText = @"SELECT CariID, Aktif, CariKod, CariTanim, OzelKod1, OzelKod2, OzelKod3, VergiDairesi, 
 VergiNumarasi, CariGrupID,CariAltGrupID, WebSayfasi, Aciklama, SilindiMi, KaydedenID, KayitTarihi, DegistirenID, 
DegismeTarihi, iskOrani1, iskOrani2, iskOrani3, CariFiyatTanimID, BankaAdi, BankaSubeAdi, BankaSubeKodu, BankaHesapNo, BankaIbanNo, BankaAciklama
FROM         dbo.Cari with(nolock)
WHERE     (CariID = @CariID)";
                cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
                using (drGenel = cmdGenel.ExecuteReader())
                {
                    drGenel.Read();

                    _CariID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["CariID"]));
                    _CariKod = drGenel["CariKod"].ToString();
                    _CariTanim = drGenel["CariTanim"].ToString();
                    _OzelKod1 = drGenel["OzelKod1"].ToString();
                    _OzelKod2 = drGenel["OzelKod2"].ToString();
                    _OzelKod3 = drGenel["OzelKod3"].ToString();
                    _VergiDairesi = drGenel["VergiDairesi"].ToString();
                    _VergiNumarasi = drGenel["VergiNumarasi"].ToString();
                    _CariGrupID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["CariGrupID"].ToString()));
                    _CariAltGrupID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["CariAltGrupID"].ToString()));
                    _WebSayfasi = drGenel["WebSayfasi"].ToString();
                    _Aciklama = drGenel["Aciklama"].ToString();
                    _KaydedenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["KaydedenID"]));
                    _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
                    _DegistirenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["DegistirenID"]));
                    _DegismeTarihi = TarihBossaMinTarihVer(drGenel["DegismeTarihi"]);
                    _iskOrani1 = Convert.ToDecimal(drGenel["iskOrani1"].ToString());
                    _iskOrani2 = Convert.ToDecimal(drGenel["iskOrani2"].ToString());
                    _iskOrani3 = Convert.ToDecimal(drGenel["iskOrani3"].ToString());
                    _CariFiyatTanimID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["CariFiyatTanimID"].ToString()));

                    _BankaAdi = drGenel["BankaAdi"].ToString();
                    _BankaSubeAdi = drGenel["BankaSubeAdi"].ToString();
                    _BankaSubeKodu = drGenel["BankaSubeKodu"].ToString();
                    _BankaHesapNo = drGenel["BankaHesapNo"].ToString();
                    _BankaIbanNo = drGenel["BankaIbanNo"].ToString();
                    _BankaAciklama = drGenel["BankaAciklama"].ToString();


                    if (Convert.ToBoolean(drGenel["SilindiMi"].ToString()))
                        _SilindiMi = true;
                    else
                        _SilindiMi = false;

                    if (Convert.ToBoolean(drGenel["Aktif"].ToString()))
                        _Aktif = true;
                    else
                        _Aktif = false;
                }
            }
        }

        /// <summary>
        /// Bu değiştirilip Cari arama yapılacak
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <returns></returns> 
        public string CariGuncelle(SqlConnection Baglanti, SqlTransaction Tr)
        {
            cmdGenel = new SqlCommand();
            cmdGenel.Connection = Baglanti;
            cmdGenel.Transaction = Tr;
            if (_CariID == -1)
            {
                cmdGenel.CommandText = @"insert into Cari 
(Aktif, CariKod, CariTanim, OzelKod1, OzelKod2, OzelKod3, VergiDairesi, VergiNumarasi, CariGrupID, CariAltGrupID, WebSayfasi, 
 Aciklama, KaydedenID, KayitTarihi, CariFiyatTanimID, iskOrani1, iskOrani2, iskOrani3, SilindiMi, BankaAdi, BankaSubeAdi, BankaSubeKodu, BankaHesapNo, BankaIbanNo, BankaAciklama)
values 
(@Aktif, @CariKod, @CariTanim, @OzelKod1, @OzelKod2, @OzelKod3, @VergiDairesi, @VergiNumarasi, @CariGrupID, @CariAltGrupID, @WebSayfasi, 
@Aciklama, @KaydedenID, @KayitTarihi, @CariFiyatTanimID, @iskOrani1, @iskOrani2, @iskOrani3, @SilindiMi, @BankaAdi, @BankaSubeAdi, @BankaSubeKodu, @BankaHesapNo, @BankaIbanNo, @BankaAciklama )  set @YeniID = SCOPE_IDENTITY()";
                cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
                cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
            }
            if (_CariID != -1)
            {
                cmdGenel.CommandText = @"Update Cari set Aktif=@Aktif, CariKod=@CariKod, CariTanim=@CariTanim, OzelKod1=@OzelKod1, OzelKod2=@OzelKod2, 
OzelKod3=@OzelKod3, VergiDairesi=@VergiDairesi, VergiNumarasi=@VergiNumarasi, CariGrupID=@CariGrupID, CariAltGrupID=@CariAltGrupID, WebSayfasi=@WebSayfasi, Aciklama=@Aciklama, SilindiMi = @SilindiMi, 
CariFiyatTanimID = @CariFiyatTanimID, iskOrani1=@iskOrani1, iskOrani2=@iskOrani2, iskOrani3=@iskOrani3,
DegistirenID = @DegistirenID, DegismeTarihi = @DegismeTarihi, BankaAdi = @BankaAdi, BankaSubeAdi = @BankaSubeAdi, BankaSubeKodu = @BankaSubeKodu, BankaHesapNo = @BankaHesapNo, BankaIbanNo = @BankaIbanNo, BankaAciklama = @BankaAciklama   where CariID = @CariID";

                cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
                cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
            }
            try
            {
                cmdGenel.Parameters.Add("@Aktif", SqlDbType.Bit).Value = _Aktif;
                cmdGenel.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKod;
                cmdGenel.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanim;
                cmdGenel.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
                cmdGenel.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
                cmdGenel.Parameters.Add("@OzelKod3", SqlDbType.NVarChar).Value = _OzelKod3;
                cmdGenel.Parameters.Add("@VergiDairesi", SqlDbType.NVarChar).Value = _VergiDairesi;
                cmdGenel.Parameters.Add("@VergiNumarasi", SqlDbType.NVarChar).Value = _VergiNumarasi;
                cmdGenel.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = _CariGrupID;
                cmdGenel.Parameters.Add("@CariAltGrupID", SqlDbType.Int).Value = _CariAltGrupID;
                cmdGenel.Parameters.Add("@WebSayfasi", SqlDbType.NVarChar).Value = _WebSayfasi;
                cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
                cmdGenel.Parameters.Add("@iskOrani1", SqlDbType.Decimal).Value = _iskOrani1;
                cmdGenel.Parameters.Add("@iskOrani2", SqlDbType.Decimal).Value = _iskOrani2;
                cmdGenel.Parameters.Add("@iskOrani3", SqlDbType.Decimal).Value = _iskOrani3;
                cmdGenel.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;
                cmdGenel.Parameters.Add("@CariFiyatTanimID", SqlDbType.Int).Value = _CariFiyatTanimID;
                cmdGenel.Parameters.Add("@BankaAdi", SqlDbType.NVarChar).Value = _BankaAdi;
                cmdGenel.Parameters.Add("@BankaSubeAdi", SqlDbType.NVarChar).Value = _BankaSubeAdi;
                cmdGenel.Parameters.Add("@BankaSubeKodu", SqlDbType.NVarChar).Value = _BankaSubeKodu;
                cmdGenel.Parameters.Add("@BankaHesapNo", SqlDbType.NVarChar).Value = _BankaHesapNo;
                cmdGenel.Parameters.Add("@BankaIbanNo", SqlDbType.NVarChar).Value = _BankaIbanNo;
                cmdGenel.Parameters.Add("@BankaAciklama", SqlDbType.NVarChar).Value = _BankaAciklama;


                cmdGenel.ExecuteNonQuery();
                if (_CariID == -1)
                    _CariID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
            }
            catch (Exception e)
            {
                if (e is SqlException && ((SqlException)e).Number == 2601)
                    return ((SqlException)e).Number.ToString();
                else
                    return e.Message;
            }
            finally
            {
                cmdGenel.Dispose();
            }
            return "OK ," + _CariID.ToString();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
