using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Fatura
{
    public class csFaturaArama : IDisposable
    {
        private int _FaturaAramaID;
        private string _CariTanimi;
        private int _GrubuID;
        private int _FaturaTipi;
        private string _FaturaBarkod;
        private int _GirisCikis;
        private string _FaturadakiCariTanim;
        private string _CariKodu;
        private DateTime _Tarih1;
        private DateTime _Tarih2;
        /// <summary>
        /// 0 Hepsi \n
        /// 1 Odenmedi \n
        /// 2 Odendi
        /// </summary>
        private OdememisMi _OdendiMi;
        private HizliSatistaGozukme _HizliSatistaGozukecekMi;

        public enum HizliSatistaGozukme
        {
            Hepsi = 1,
            Gozukenler = 2,
            Gozukmeyenler = 3
        }


        public enum OdememisMi
        {
            Hepsi = -1,
            Odenmedi = 0,
            Odendi = 1,
            KismiOdeme = 2
        }

        public int FaturaAramaID
        {
            get { return _FaturaAramaID; }
            set { _FaturaAramaID = value; }
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
        public int FaturaTipi
        {
            get { return _FaturaTipi; }
            set { _FaturaTipi = value; }
        }
        public int GirisCikis
        {
            get { return _GirisCikis; }
            set { _GirisCikis = value; }
        }

        public string FaturaBarkod
        {
            get { return _FaturaBarkod; }
            set { _FaturaBarkod = value; }
        }
        public string FaturadakiCariTanim
        {
            get { return _FaturadakiCariTanim; }
            set { _FaturadakiCariTanim = value; }
        }
        public DateTime Tarih1
        {
            get { return _Tarih1; }
            set { _Tarih1 = value; }
        }
        public DateTime Tarih2
        {
            get { return _Tarih2; }
            set { _Tarih2 = value; }
        }



        public string CariKodu
        {
            get { return _CariKodu; }
            set { _CariKodu = value; }
        }

        /// <summary>
        /// 0 Hepsi
        /// 1 Odenmedi
        /// 2 Odendi
        /// </summary>
        public OdememisMi OdendiMi
        {
            get
            {
                return _OdendiMi;
            }

            set
            {
                _OdendiMi = value;
            }
        }

        public HizliSatistaGozukme HizliSatistaGozukecekMi
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

        DataTable dt_FaturaListesi;
        SqlDataAdapter da_FaturaListesi;

        public csFaturaArama(SqlConnection Baglanti, SqlTransaction Tr, int FaturaAramaID)
        {
            if (FaturaAramaID == -1)
            {
                _CariTanimi = string.Empty; // string alanlar için "" (boş) gelmişse oralarda arama yapmayacak
                _GrubuID = -1; // int için olan alanlar yani ID gerektiren alanlarda -1 gelmişse oralarda arama yapmaycak
                _FaturaTipi = -1;
                _FaturaBarkod = string.Empty;
                _GirisCikis = 0; //0 sa hepsi olsum mk.
                _FaturadakiCariTanim = string.Empty;
                _CariKodu = string.Empty;
                _Tarih1 = DateTime.MinValue;
                _Tarih2 = DateTime.MinValue;
                _OdendiMi = OdememisMi.Hepsi;
                _HizliSatistaGozukecekMi = HizliSatistaGozukme.Hepsi;
            }
        }
        public DataTable FaturaAraListe(SqlConnection Baglanti, SqlTransaction Tr)
        {
            try
            {
                da_FaturaListesi = new SqlDataAdapter();
                string WhereCumlesi =
          @" SELECT dbo.Fatura.FaturaID, dbo.Fatura.FaturaNo, 
 CASE 
WHEN FaturaTipi = 1 THEN 'SATIŞ FATURASI' 
WHEN FaturaTipi = 2 THEN 'ALIŞ FATURASI' 
WHEN FaturaTipi = 3 THEN 'SATIŞTAN İADE FATURASI' 
WHEN FaturaTipi = 4 THEN 'ALIŞTAN İADE FATURASI' 
WHEN FaturaTipi = 6 THEN 'SATIŞ İRSALİYESİ' 
WHEN FaturaTipi = 7 THEN 'ALIŞ İRSALİYESİ' 
WHEN FaturaTipi = 8 THEN 'SATIŞ İADE İRSALİYESİ' 
WHEN FaturaTipi = 9 THEN 'ALIŞ İADE İRSALİYESİ' 
END AS FaturaTipi, dbo.Fatura.CariID, dbo.Cari.CariKod, dbo.Cari.CariTanim, dbo.Fatura.FaturaTarihi, dbo.Fatura.DuzenlemeTarihi, dbo.Fatura.ToplamIndirim, fatura.FaturaTutari,
dbo.Fatura.ToplamKdv, dbo.Fatura.Vadesi, fatura.CariTanim as FaturaCariTanim, 
CASE WHEN dbo.Fatura.Iptal =1 THEN 'İPTAL EDİLDİ' ELSE '' end AS Iptal , CASE WHEN dbo.Fatura.SilindiMi =1 THEN 'SİLİNDİ' ELSE '' END AS SilindiMi, dbo.Fatura.Aciklama
, OkcZNo, OkcFisNo
FROM         dbo.Fatura 
INNER JOIN dbo.Cari ON dbo.Fatura.CariID = dbo.Cari.CariID
WHERE     (1 = 1 and Fatura.SilindiMi = 0)
";

                da_FaturaListesi.SelectCommand = new SqlCommand("", Baglanti, Tr);

                if (!string.IsNullOrEmpty(_CariTanimi))
                {
                    WhereCumlesi += " and Cari.CariTanim like @CariTanim";
                    da_FaturaListesi.SelectCommand.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanimi + "%";
                }
                if (_GrubuID != -1)
                {
                    WhereCumlesi += " and GrubuID = @GrubuID";
                    da_FaturaListesi.SelectCommand.Parameters.Add("@GrubuID", SqlDbType.Int).Value = _GrubuID;
                }
                if (_FaturaTipi != -1)
                {
                    WhereCumlesi += " and FaturaTipi = @FaturaTipi";
                    da_FaturaListesi.SelectCommand.Parameters.Add("@FaturaTipi", SqlDbType.Int).Value = _FaturaTipi;
                }
                if (!string.IsNullOrEmpty(_FaturaBarkod))
                {
                    WhereCumlesi += " and FaturaBarkod = @FaturaBarkod";
                    da_FaturaListesi.SelectCommand.Parameters.Add("@FaturaBarkod", SqlDbType.NVarChar).Value = _FaturaBarkod;
                }
                if (_GirisCikis != 0)
                {
                    if (_GirisCikis == 1) // girişse
                    {
                        WhereCumlesi += " and (FaturaTipi = " + ((int)clsTablolar.IslemTipi.AlisFaturasi).ToString();
                        WhereCumlesi += " or FaturaTipi = " + ((int)clsTablolar.IslemTipi.SatisIadeFaturasi).ToString() + ")";
                    }
                    else if (_GirisCikis == 2) // Çıkışsa
                    {
                        WhereCumlesi += " and (FaturaTipi = " + ((int)clsTablolar.IslemTipi.SatisFaturasi).ToString();
                        WhereCumlesi += " or FaturaTipi = " + ((int)clsTablolar.IslemTipi.AlisIadeFaturasi).ToString() + ")";
                    }
                }
                if (!string.IsNullOrEmpty(_FaturadakiCariTanim))
                {
                    WhereCumlesi += " and fatura.CariTanim like @FaturadakiCariTanim";
                    da_FaturaListesi.SelectCommand.Parameters.Add("@FaturadakiCariTanim", SqlDbType.NVarChar).Value = "%" + _FaturadakiCariTanim + "%";
                }

                if (!string.IsNullOrEmpty(_CariKodu))
                {
                    WhereCumlesi += " and Cari.CariKod = @CariKod";
                    da_FaturaListesi.SelectCommand.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKodu;
                }

                if (_Tarih1 != DateTime.MinValue)
                {
                    WhereCumlesi += " and Fatura.FaturaTarihi >= @Tarih1";
                    da_FaturaListesi.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = _Tarih1;
                }

                if (_Tarih2 != DateTime.MinValue)
                {
                    WhereCumlesi += " and Fatura.FaturaTarihi <= @Tarih2";
                    da_FaturaListesi.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = _Tarih2.AddDays(1);
                }
                if (_OdendiMi != OdememisMi.Hepsi)
                {
                    switch (_OdendiMi)
                    {
                        case OdememisMi.Odenmedi:
                            WhereCumlesi += " and (Fatura.FaturaTutari = [dbo].FaturaBakiyesiniGetir(Fatura.FaturaID)) ";
                            break;
                        case OdememisMi.Odendi:
                            WhereCumlesi += " and ([dbo].FaturaBakiyesiniGetir(Fatura.FaturaID) = 0 )";
                            break;
                        case OdememisMi.KismiOdeme:
                            WhereCumlesi += " and (Fatura.FaturaTutari > [dbo].FaturaBakiyesiniGetir(Fatura.FaturaID))  and ([dbo].FaturaBakiyesiniGetir(Fatura.FaturaID) != 0)";
                            break;
                        default:
                            break;
                    }
                }

                if (_HizliSatistaGozukecekMi != HizliSatistaGozukme.Hepsi)
                {
                    switch (_HizliSatistaGozukecekMi)
                    {
                        case HizliSatistaGozukme.Gozukenler:
                            WhereCumlesi += " and fatura.HizliSatistaGozukecekMi = 1 ";
                            break;
                        case HizliSatistaGozukme.Gozukmeyenler:
                            WhereCumlesi += " and fatura.HizliSatistaGozukecekMi = 0 ";
                            break;
                        default:
                            break;
                    }
                }




                da_FaturaListesi.SelectCommand.CommandText = WhereCumlesi;

                dt_FaturaListesi = new DataTable();
                da_FaturaListesi.Fill(dt_FaturaListesi);
                return dt_FaturaListesi;
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
