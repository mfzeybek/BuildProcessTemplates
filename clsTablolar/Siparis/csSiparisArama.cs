using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Siparis
{
    public class csSiparisArama : IDisposable
    {
        private int _SiparisAramaID;
        private string _CariTanimi;
        private int _GrubuID;
        private int _SiparisTipi;
        private object[] _MuhasebelenmeDrumu;
        private Int16 _HizliSatistaGozukecekMi;


        private Int16 _HizliSatistaDegisiklikYapmaIzniVarMi;

        private int[] _SiparisDurumTanimID;
        private string _SiparisBarkodNu;

        private DateTime _IlkFaturaTarihi;
        private DateTime _SiparisTarihiIlk;
        private DateTime _SiparisTarihiIkinci;
        private DateTime _TeslimTarihiIlk;
        private DateTime _TeslimTarihiIkinci;


        public DateTime IlkFaturaTarihi
        {
            get { return _IlkFaturaTarihi; }
            set { _IlkFaturaTarihi = value; }
        }

        public string SiparisBarkodNu
        {
            get { return _SiparisBarkodNu; }
            set { _SiparisBarkodNu = value; }
        }

        public int[] SiparisDurumTanimID
        {
            get { return _SiparisDurumTanimID; }
            set { _SiparisDurumTanimID = value; }
        }


        public object[] MuhasebelenmeDrumu
        {
            get { return _MuhasebelenmeDrumu; }
            set { _MuhasebelenmeDrumu = value; }
        }


        public int SiparisAramaID
        {
            get { return _SiparisAramaID; }
            set { _SiparisAramaID = value; }
        }
        public string CariTanimi
        {
            get { return _CariTanimi; }
            set { _CariTanimi = value; }
        }
        public int GrubuID
        {
            get { return _GrubuID; }
            set { _GrubuID = value; }
        }
        public int SiparisTipi
        {
            get { return _SiparisTipi; }
            set { _SiparisTipi = value; }
        }
        public Int16 HizliSatistaGozukecekMi
        {
            get { return _HizliSatistaGozukecekMi; }
            set { _HizliSatistaGozukecekMi = value; }
        }
        public Int16 HizliSatistaDegisiklikYapmaIzniVarMi
        {
            get { return _HizliSatistaDegisiklikYapmaIzniVarMi; }
            set { _HizliSatistaDegisiklikYapmaIzniVarMi = value; }
        }

        public DateTime SiparisTarihiIlk
        {
            get
            {
                return _SiparisTarihiIlk;
            }

            set
            {
                _SiparisTarihiIlk = value;
            }
        }

        public DateTime SiparisTarihiIkinci
        {
            get
            {
                return _SiparisTarihiIkinci;
            }

            set
            {
                _SiparisTarihiIkinci = value;
            }
        }

        public DateTime TeslimTarihiIlk
        {
            get
            {
                return _TeslimTarihiIlk;
            }

            set
            {
                _TeslimTarihiIlk = value;
            }
        }

        public DateTime TeslimTarihiIkinci
        {
            get
            {
                return _TeslimTarihiIkinci;
            }

            set
            {
                _TeslimTarihiIkinci = value;
            }
        }

        public DataTable dt_SiparisListesi;
        SqlDataAdapter da_SiparisListesi;

        public csSiparisArama(SqlConnection Baglanti, SqlTransaction Tr, int SiparisAramaID)
        {
            if (SiparisAramaID == -1)
            {
                _CariTanimi = string.Empty; // string alanlar için "" (boş) gelmişse oralarda arama yapmayacak
                _GrubuID = -1; // int için olan alanlar yani ID gerektiren alanlarda -1 gelmişse oralarda arama yapmaycak
                _SiparisTipi = -1;
                _HizliSatistaDegisiklikYapmaIzniVarMi = -1;
                _HizliSatistaGozukecekMi = -1;
                //_SiparisDurumTanimID = ;
                _SiparisBarkodNu = string.Empty;
                _MuhasebelenmeDrumu = new object[0];
                _IlkFaturaTarihi = DateTime.MinValue;
                _SiparisDurumTanimID = null;
                _SiparisTarihiIlk = DateTime.MinValue;
                _SiparisTarihiIkinci = DateTime.MinValue;
                _TeslimTarihiIlk = DateTime.MinValue;
                _TeslimTarihiIkinci = DateTime.MinValue;

                dt_SiparisListesi = new DataTable();
            }
        }

        string MuhasebelendimiSorgusu;

        public DataTable SiparisAraListe(SqlConnection Baglanti, SqlTransaction Tr)
        {
            try
            {
                da_SiparisListesi = new SqlDataAdapter();

                string WhereCumlesi =
                  @"
-- önce Sipariş İrsaliyeye mi Faturaya mı aktarılmış o tespit ediyoruz  30 olan yerlere @SiparisID Yazılacak

SELECT  Distinct
CASE WHEN Siparis.Faturalandi = 1 THEN 'F' ELSE '' END AS F, 
dbo.Siparis.SiparisID, dbo.Siparis.SiparisNo, 
CASE 
WHEN SiparisTipi = 10 THEN 'VERİLEN SİPARİŞ' 
WHEN SiparisTipi = 11 THEN 'ALINAN SİPARİŞ'
END AS SiparisTipi, 
dbo.Siparis.SiparisTipi, dbo.Siparis.CariID, dbo.Siparis.CariKod, dbo.Siparis.CariTanim, Fatura.FaturaID,
                      dbo.Siparis.SiparisTarihi, dbo.Siparis.DuzenlemeTarihi, dbo.Siparis.ToplamIndirim, dbo.Siparis.ToplamKdv, Siparis.SiparisTutari, Siparis.TeslimTarihi,
                      dbo.Siparis.Vadesi, PerseonelCarisi.CariTanim as PersonelAdi,SiparisDurumTanimlari.SiparisDurumTanimAdi,
					  CASE WHEN dbo.Siparis.Iptal = 1 THEN 'İPTAL EDİLDİ' ELSE '' END AS Iptal, 
                      CASE WHEN dbo.Siparis.SilindiMi = 1 THEN 'SİLİNDİ' ELSE '' END AS SilindiMi, dbo.Siparis.Aciklama
					  ,CASE dbo.SiparisMuhasebelendiMi(siparis.SiparisID)
					  WHEN 1 THEN 'Faturalandı' 
					  when 2 then 'Faturalanmadı'
					  when 3 then 'Siparis Faturalanmiş Fatura Silinmiş'
					  ELSE '' END AS 'Muhasebe Durumu'
FROM         dbo.Siparis LEFT OUTER JOIN
                      dbo.Cari ON dbo.Siparis.CariID = dbo.Cari.CariID
					  left Join Personel on Personel.PersonelID = Siparis.SatisElemaniID
					  left join Cari as PerseonelCarisi on PerseonelCarisi.CariID = Personel.CariID
					  left join EvrakIsliski on EvrakIsliski.SiparisID = Siparis.SiparisID and EvrakIsliski.FaturaID <> -1 
					  left join Fatura on Fatura.FaturaID = EvrakIsliski.FaturaID and Fatura.SilindiMi = 0	
                      left join SiparisDurumTanimlari on SiparisDurumTanimlari.SiparisDurumTanimID = Siparis.SiparisDurumTanimID
WHERE     (Siparis.SilindiMi = 0) and (Fatura.SilindiMi = 0 or Fatura.SilindiMi is Null)
";

                da_SiparisListesi.SelectCommand = new SqlCommand("", Baglanti, Tr);


                if (!string.IsNullOrEmpty(_CariTanimi))
                {
                    WhereCumlesi += " and Siparis.CariTanimi like @CariTanimi";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@CariTanimi", SqlDbType.NVarChar).Value = _CariTanimi + "%";
                }
                if (_GrubuID != -1)
                {
                    WhereCumlesi += " and GrubuID = @GrubuID";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@GrubuID", SqlDbType.Int).Value = _GrubuID;
                }
                if (_SiparisTipi != -1)
                {
                    WhereCumlesi += " and SiparisTipi = @SiparisTipi";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@SiparisTipi", SqlDbType.Int).Value = _SiparisTipi;
                }
                if (_HizliSatistaGozukecekMi != -1)
                {
                    WhereCumlesi += " and Siparis.HizliSatistaGozukecekMi = @HizliSatistaGozukecekMi ";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@HizliSatistaGozukecekMi", SqlDbType.Bit).Value = _HizliSatistaGozukecekMi; // bu değişken integer olmasına rağmen bool
                }
                if (_HizliSatistaDegisiklikYapmaIzniVarMi != -1)
                {
                    WhereCumlesi += " and Siparis.HizliSatistaDegisiklikYapmaIzniVarMi = @HizliSatistaDegisiklikYapmaIzniVarMi ";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@HizliSatistaDegisiklikYapmaIzniVarMi", SqlDbType.Bit).Value = _HizliSatistaDegisiklikYapmaIzniVarMi; // bu değişken integer olmasına rağmen bool
                }
                if (_SiparisDurumTanimID != null)
                {
                    if (Array.IndexOf(_SiparisDurumTanimID, -1) != -1)
                    {

                    }
                    else
                        if (_SiparisDurumTanimID.Length > 0)
                    {
                        WhereCumlesi += " and ( 1 = 2 ";
                        for (int i = 0; i < _SiparisDurumTanimID.Length; i++)
                        {
                            WhereCumlesi += " or Siparis.SiparisDurumTanimID = @SiparisDurumTanimID" + i.ToString();
                            da_SiparisListesi.SelectCommand.Parameters.Add("@SiparisDurumTanimID" + i.ToString(), SqlDbType.Int).Value = _SiparisDurumTanimID[i];
                        }
                        WhereCumlesi += " ) ";
                    }
                }
                if (!string.IsNullOrEmpty(_SiparisBarkodNu))
                {
                    WhereCumlesi += " and SiparisBarkodNu = @SiparisBarkodNu ";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@SiparisBarkodNu", SqlDbType.NVarChar).Value = _SiparisBarkodNu;
                }

                if (_IlkFaturaTarihi != DateTime.MinValue)
                {
                    WhereCumlesi += " and Fatura.FaturaTarihi >= @FaturaTarihi ";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@FaturaTarihi", SqlDbType.DateTime).Value = _IlkFaturaTarihi;
                }

                foreach (object item in _MuhasebelenmeDrumu)
                {
                    if (Convert.ToInt16(item) == 1) // muhasebelenmedi
                    {
                        WhereCumlesi += @" and dbo.SiparisMuhasebelendiMi(siparis.SiparisID) = 2 ";

                        //                        WhereCumlesi += @" and (select Top 1 EvrakIsliski.IrsaliyeID from EvrakIsliski where SiparisID = Siparis.SiparisID) is null 
                        //                             and 
                        //                             (select Top 1 EvrakIsliski.FaturaID from EvrakIsliski where SiparisID = Siparis.SiparisID) is null ";
                    }
                    if (Convert.ToInt16(item) == 2)// muhasebelendi (4 gelirse hem muhasebelenenler hem kısmi muahsebelenenler)
                    {
                        WhereCumlesi += @" and dbo.SiparisMuhasebelendiMi(siparis.SiparisID) in (1, 4)  ";
                    }
                    if (Convert.ToInt16(item) == 3) // kısmi muhasebelendi (4 gelirse hem muhasebelenenler hem kısmi muahsebelenenler)
                    {
                        WhereCumlesi += @" ";
                    }

                    if (Convert.ToInt16(item) == 4) // kısmi faturalandı veya faturalandı ise
                    { 
                        WhereCumlesi += @" and dbo.SiparisMuhasebelendiMi(siparis.SiparisID) = 4 "; // burası düzeltilecek vertabanındaki fonksiyona kısmi faturandı sonucu eklenmesi lazım ("SiparisMuhasebelendiMi" bu fonkdiyon da kısmi faturalandı sonucu eklenecek)
                    }
            
                }

                if (_SiparisTarihiIlk != DateTime.MinValue)
                {
                    WhereCumlesi += @" and CONVERT(datetime, convert(varchar, Siparis.SiparisTarihi, 101)) >=  @SiparisTarihiIlk ";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@SiparisTarihiIlk", SqlDbType.DateTime).Value = _SiparisTarihiIlk;
                }
                if (_SiparisTarihiIkinci != DateTime.MinValue)
                {
                    WhereCumlesi += @" and CONVERT(datetime, convert(varchar, Siparis.SiparisTarihi, 101)) <=  @SiparisTarihiIkinci ";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@SiparisTarihiIkinci", SqlDbType.DateTime).Value = _SiparisTarihiIkinci;

                }
                if (_TeslimTarihiIlk != DateTime.MinValue)
                {
                    WhereCumlesi += @" and CONVERT(datetime, convert(varchar, Siparis.TeslimTarihi, 101)) >=  @TeslimTarihiIlk  ";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@TeslimTarihiIlk", SqlDbType.DateTime).Value = _TeslimTarihiIlk;
                }
                if (_TeslimTarihiIkinci != DateTime.MinValue)
                {
                    WhereCumlesi += @" and CONVERT(datetime, convert(varchar, Siparis.TeslimTarihi, 101)) <=  @TeslimTarihiIkinci  ";
                    da_SiparisListesi.SelectCommand.Parameters.Add("@TeslimTarihiIkinci", SqlDbType.DateTime).Value = _TeslimTarihiIkinci;
                }



                da_SiparisListesi.SelectCommand.CommandText = WhereCumlesi;

                dt_SiparisListesi.Clear();
                da_SiparisListesi.Fill(dt_SiparisListesi);
                //dt_SiparisListesi.Columns.Add("Secim", typeof(System.Boolean));
                return dt_SiparisListesi;
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
