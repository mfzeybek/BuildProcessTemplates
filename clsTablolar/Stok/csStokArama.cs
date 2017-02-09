using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace clsTablolar.Stok
{
    public class csStokArama : IDisposable
    {

        #region propertyler hamısına

        private int _StokAramaID;
        private bool _Aktif;
        private string _StokKodu;
        private string _StokAdi;
        private string _StokFiyatTanimIDleri;
        private string _StokFiyatTanimAdlari;
        private string _OzelKod1;
        private string _OzelKod2;
        private string _OzelKod3;
        private int _StokGrupID;
        private int _StokAraGrupID;
        private int _StokAltGrupID;
        private string _Aciklama;
        private string _Barkod;
        private int _StokBirimID;
        private string _RafYeriAciklama;
        /// <summary>
        /// 0 sa hepsi, 1 se evet, 2 ise hayır
        /// </summary>
        private int _UrunTanitimdaGoster;
        /// <summary>
        /// 0 sa farketmiyor, 1 ise web te gözükenler, 2 ise gözükmeyenler
        /// </summary>
        private int _EMagazaErisimi;
        private string _Garanti;
        private string _Desi;
        private string _KisaAciklama;
        private string _DetayliUrunBilgisi;
        private int _HemenAlKategoriID;
        private string _HemenAlID;
        /// <summary>
        /// 0 sa farketmiyor, 1 ise güncellensin, 2 ise güncellenmeyenler
        /// </summary>
        private int _HemenAlKategoriGuncellenmesin;
        /// <summary>
        /// Boş geldiğinde ürün yoksa eklenir varsa güncellenir. (Güncelle veya Ekle)
        /// P gönderilirse ürün pasif edilir. (Pasif)
        /// A gönderilirse ürün aktif edilir. (Aktif)
        /// D gönderilirse ürün silinir. (Sil)
        /// S gönderilirse sadece stok güncellenir. (Stok Güncelle)
        /// F gönderilirse sadece fiyat güncellenir. (Fiyat Güncelle)
        /// </summary>
        private string _HemenAlDrum;
        private string _HemenAlSira;
        /// <summary>
        /// (0 hepsi) -  (1 Miktarlı olanlar) - (2 Miktarı Olmayanlar)
        /// </summary>
        private Int16 _MiktariOlanlar;
        private bool _MinMiktarinAltindaOlanlar;
        private enumFotoOzellikleri _FotoOzellikleri;
        private int _StokSayimGrubuID;
        private bool _SadeceFiyatiOlanlar; // bu true olursa seçilen fiyatlar gelirken fiyatları olmayanlar veya fiyatı sıfır olanlar gelmez

        private bool _OlmasiGerekenMiktardanAzOlanlar;
        /// <summary>
        /// StokTipi
        /// 1 Hazır Stok (Hazır alınıp satılıyor)
        /// 2 Mamül(Üretilen Stok, bu sadece üretiliyor neredeyse hiç satın alınmıyor)
        /// 3 Hammade(Mamül üretirken Kullanılıyor)
        /// </summary>
        private int _StokTipi;
        private int _SayimID;
        private Int16 _N11Entegrasyonu;


        public bool SadeceFiyatiOlanlar
        {
            get { return _SadeceFiyatiOlanlar; }
            set { _SadeceFiyatiOlanlar = value; }
        }


        public int StokAramaID
        {
            get { return _StokAramaID; }
            set { _StokAramaID = value; }
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
        public string StokFiyatTanimIDleri
        {
            get { return _StokFiyatTanimIDleri; }
            set { _StokFiyatTanimIDleri = value; }
        }
        public string StokFiyatTanimAdlari
        {
            get { return _StokFiyatTanimAdlari; }
            set { _StokFiyatTanimAdlari = value; }
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
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }
        public string Barkod
        {
            get { return _Barkod; }
            set { _Barkod = value; }
        }
        public int StokBirimID
        {
            get { return _StokBirimID; }
            set { _StokBirimID = value; }
        }
        public string RafYeriAciklama
        {
            get { return _RafYeriAciklama; }
            set { _RafYeriAciklama = value; }
        }
        public int UrunTanitimdaGoster
        {
            get { return _UrunTanitimdaGoster; }
            set { _UrunTanitimdaGoster = value; }
        }

        /// <summary>
        /// 0 sa farketmiyor, 1 ise web te gözükenler, 2 ise gözükmeyenler
        /// </summary>
        public int EMagazaErisimi
        {
            get { return _EMagazaErisimi; }
            set { _EMagazaErisimi = value; }
        }
        public string Garanti
        {
            get { return _Garanti; }
            set { _Garanti = value; }
        }
        public string Desi
        {
            get { return _Desi; }
            set { _Desi = value; }
        }
        public string KisaAciklama
        {
            get { return _KisaAciklama; }
            set { _KisaAciklama = value; }
        }
        public string DetayliUrunBilgisi
        {
            get { return _DetayliUrunBilgisi; }
            set { _DetayliUrunBilgisi = value; }
        }
        public int HemenAlKategoriID
        {
            get { return _HemenAlKategoriID; }
            set { _HemenAlKategoriID = value; }
        }
        public string HemenAlID
        {
            get { return _HemenAlID; }
            set { _HemenAlID = value; }
        }
        /// <summary>
        /// 0 sa farketmiyor, 1 ise güncellensin, 2 ise güncellenmeyenler
        /// </summary>
        public int HemenAlKategoriGuncellenmesin
        {
            get { return _HemenAlKategoriGuncellenmesin; }
            set { _HemenAlKategoriGuncellenmesin = value; }
        }

        /// <summary>
        /// Boş geldiğinde ürün yoksa eklenir varsa güncellenir. (Güncelle veya Ekle)
        /// P gönderilirse ürün pasif edilir. (Pasif)
        /// A gönderilirse ürün aktif edilir. (Aktif)
        /// D gönderilirse ürün silinir. (Sil)
        /// S gönderilirse sadece stok güncellenir. (Stok Güncelle)
        /// F gönderilirse sadece fiyat güncellenir. (Fiyat Güncelle)
        /// </summary>
        public string HemenAlDrum
        {
            get { return _HemenAlDrum; }
            set { _HemenAlDrum = value; }
        }
        public string HemenAlSira
        {
            get { return _HemenAlSira; }
            set { _HemenAlSira = value; }
        }

        /// <summary>
        ///  (0 hepsi) -  (1 Miktarlı olanlar) - (2 Miktarı Olmayanlar)
        /// </summary>
        public Int16 MiktariOlanlar
        {
            get { return _MiktariOlanlar; }
            set { _MiktariOlanlar = value; }
        }


        public bool MinMiktarinAltindaOlanlar
        {
            get { return _MinMiktarinAltindaOlanlar; }
            set { _MinMiktarinAltindaOlanlar = value; }
        }
        public enumFotoOzellikleri FotoOzellikleri
        {
            get { return _FotoOzellikleri; }
            set { _FotoOzellikleri = value; }
        }
        public int StokSayimGrubuID
        {
            get { return _StokSayimGrubuID; }
            set { _StokSayimGrubuID = value; }
        }

        public bool OlmasiGerekenMiktardanAzOlanlar
        {
            get
            {
                return _OlmasiGerekenMiktardanAzOlanlar;
            }

            set
            {
                _OlmasiGerekenMiktardanAzOlanlar = value;
            }
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

        public int SayimID
        {
            get
            {
                return _SayimID;
            }

            set
            {
                _SayimID = value;
            }
        }

        public short N11Entegrasyonu
        {
            get
            {
                return _N11Entegrasyonu;
            }

            set
            {
                _N11Entegrasyonu = value;
            }
        }


        #endregion


        public csStokArama()
        {
            _StokAramaID = -1;
            _Aktif = true;
            _StokKodu = string.Empty;
            _StokAdi = string.Empty;
            _StokFiyatTanimIDleri = string.Empty;
            _StokFiyatTanimAdlari = string.Empty;
            _OzelKod1 = string.Empty;
            _OzelKod2 = string.Empty;
            _OzelKod3 = string.Empty;
            _StokGrupID = -1;
            _StokAraGrupID = -1;
            _StokAltGrupID = -1;
            _Aciklama = string.Empty;
            _Barkod = string.Empty;
            _StokBirimID = -1;
            _RafYeriAciklama = string.Empty;
            _UrunTanitimdaGoster = 0; // sıfır stok listede hepsi manasına geliyor

            _EMagazaErisimi = 0;
            _Garanti = string.Empty;
            _Desi = string.Empty;
            _KisaAciklama = string.Empty;
            _DetayliUrunBilgisi = string.Empty;
            _HemenAlKategoriID = -1;
            _HemenAlID = string.Empty;
            _HemenAlKategoriGuncellenmesin = 0;

            _HemenAlDrum = string.Empty;
            _HemenAlSira = string.Empty;
            _FotoOzellikleri = enumFotoOzellikleri.Hepsi;
            _StokSayimGrubuID = -1;
            _OlmasiGerekenMiktardanAzOlanlar = false;
            _StokTipi = -1;
            _SayimID = -1;
        }

        public enum enumFotoOzellikleri
        {
            Hepsi = 1,
            FotografiOlanlar = 2,
            Olmayanlar = 3,
            VarsayilanFotosuFtpYeGonderilmemisOlanlar = 4,
            FotografiFtpYeGonderilmemisOlanlar = 5
        }


        public SqlDataAdapter da;
        SqlCommand cmb;
        public DataTable dt_StokListesi;
        public DataTable dt_FiyatListesi;

        public DataTable StokListeGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();



            // buraya bi açıklama lazım neden sql i ikiye böldük
            da.SelectCommand.CommandText = @"SELECT DISTINCT s.StokID, s.Aktif, s.StokKodu, s.StokAdi, s.OzelKod1, s.OzelKod2, s.OzelKod3, s.Aciklama, s.KayitTarihi, s.DegismeTarihi, s.iskOrani1, s.iskOrani2, s.iskOrani3, s.MinumumMiktar, s.MaksimumMiktar, s.EtiketAdi,
s.AlisKdv, s.SatisKdv, s.Barkod, sb.BirimAdi, s.RafYeriAciklama, s.UrunTanitimdaGoster, s.Garanti, s.EMagazaErisimi, s.Desi, s.KisaAciklama, 
s.HemenAlID, s.HemenAlSira, s.StokSayimGrubuID, s.OlmasiGerekenMiktar, s.StokTipi
, isnull(Girisler.Girisler, 0.0000) GirenMiktar , isnull(Cikislar.Cikislar, 0.000) CikanMiktar, isnull(Girisler,0.0000) - isnull(Cikislar, 0.000) as KalanMiktar  ";


            //for (int i = 0; i < FiyatTanimlariID().Count(); i++)
            //{//-- top 1 denmesinin amacı gerçi program aynı stok a aynı fiyat tanımını 2 kez verdirttirmeyecek ama top 1 verilirsede top 1 ile sadece tek bir fiyat gelmesini sağlamış olucaz
            //    da.SelectCommand.CommandText += @",(select Top 1 stokFiyat.Fiyat from StokFiyat where stokfiyat.StokID = s.StokID and 
            //                                          stokFiyat.FiyatTanimID = @FiyatTanimID" + i.ToString() + ") as [" + FiyatTanimlariAdlari()[i] + "]";
            //    da.SelectCommand.Parameters.Add("@FiyatTanimID" + i.ToString(), SqlDbType.Int).Value = FiyatTanimlariID()[i];
            //}

            da.SelectCommand.CommandText += @" FROM         dbo.StokFiyat  ";



            da.SelectCommand.CommandText += @"  RIGHT OUTER  JOIN
                      dbo.Stok AS s ON dbo.StokFiyat.StokID = s.StokID LEFT OUTER JOIN
                      dbo.StokMarka ON s.StokMarkaID = dbo.StokMarka.StokMarkaID LEFT OUTER JOIN
                      dbo.StokBirim AS sb ON s.StokBirimID = sb.BirimID LEFT OUTER JOIN
                      dbo.StokBirimCevrim AS stkbrm ON stkbrm.StokID = s.StokID
                      left outer join
                      StokResim on StokResim.StokID = s.StokID

                      left join
                      (select Stokhr.StokID, isnull(SUM(StokHr.Miktar),0) as Girisler from StokHr
					  where StokHr.GirisMiCikisMi = 1 and StokHr.SilindiMi = 0
					  group by StokHr.StokID) Girisler on  Girisler.StokID = s.StokID
					  left join
					  (select Stokhr.StokID, ISNULL(SUM(StokHr.Miktar), 0) as Cikislar from StokHr
				      where StokHr.GirisMiCikisMi = 2 and StokHr.SilindiMi = 0
				      group by StokHr.StokID) Cikislar on Cikislar.StokID = s.StokID
                      --left join SayimDetay on SayimDetay.StokID = s.StokID
WHERE     (s.Silindi = 'false') ";

            da.SelectCommand.Connection = Baglanti;
            da.SelectCommand.Transaction = Tr;

            da.SelectCommand.CommandText += " and s.Aktif = @Aktif";
            da.SelectCommand.Parameters.Add("@Aktif", SqlDbType.Bit).Value = _Aktif;

            if (!string.IsNullOrEmpty(_StokKodu))
            {
                da.SelectCommand.CommandText += " and s.StokKodu = @StokKodu ";
                da.SelectCommand.Parameters.Add("@StokKodu", SqlDbType.NVarChar).Value = _StokKodu;
            }
            if (!string.IsNullOrEmpty(_StokAdi))
            {
                da.SelectCommand.CommandText += " and s.StokAdi like @StokAdi ";
                da.SelectCommand.Parameters.Add("@StokAdi", SqlDbType.NVarChar).Value = _StokAdi + "%";
            }
            if (!string.IsNullOrEmpty(_OzelKod1))
            {
                da.SelectCommand.CommandText += " and s.OzelKod1 = @OzelKod1 ";
                da.SelectCommand.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
            }
            if (!string.IsNullOrEmpty(_OzelKod2))
            {
                da.SelectCommand.CommandText += " and s.OzelKod2 = @OzelKod2 ";
                da.SelectCommand.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
            }
            if (!string.IsNullOrEmpty(_OzelKod3))
            {
                da.SelectCommand.CommandText += " and s.OzelKod3 = @OzelKod3 ";
                da.SelectCommand.Parameters.Add("@OzelKod3", SqlDbType.NVarChar).Value = _OzelKod3;
            }
            if (_StokGrupID != -1) //Tabi stok arama formunda Gruplar eğer boşsa her zaman -1 değerini göndermesi gerekiyor
            {
                da.SelectCommand.CommandText += " and s.StokGrupID = @StokGrupID ";
                da.SelectCommand.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = _StokGrupID;
            }
            if (_StokAraGrupID != -1)
            {
                da.SelectCommand.CommandText += " and s.StokAraGrupID = @StokAraGrupID ";
                da.SelectCommand.Parameters.Add("@StokAraGrupID", SqlDbType.Int).Value = _StokAraGrupID;
            }
            if (_StokAltGrupID != -1)
            {
                da.SelectCommand.CommandText += " and s.StokAltGrupID = @StokAltGrupID ";
                da.SelectCommand.Parameters.Add("@StokAltGrupID", SqlDbType.Int).Value = _StokAltGrupID;
            }
            if (!string.IsNullOrEmpty(_Aciklama))
            {
                da.SelectCommand.CommandText += " and s.Aciklama like @Aciklama ";
                da.SelectCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = "%" + _Aciklama + "%";
            }
            if (!string.IsNullOrEmpty(_Barkod))
            {
                da.SelectCommand.CommandText += @" and
                                          (stkbrm.Barkodu like 
                                          case
                                          when (select  1 from BarkodAyar where CONVERT(nvarchar, OnEk,0) = LEFT(@Barkodu, 2)  and BarkodAyar.MiktarOlacakMi = 1) = 1  -- Eğer Barkod Miktarlı Barkod İse
                                          then left(@Barkodu, (select  BarkodAyar.KacHaneKod + 2  from BarkodAyar where CONVERT(nvarchar, OnEk,0) = LEFT(@Barkodu, 2)  and BarkodAyar.MiktarOlacakMi = 1))
                                          when 1 = 1
                                          then @Barkodu
                                          end
                                           or 
                                          s.Barkod like @Barkodu )";

                da.SelectCommand.Parameters.Add("@Barkodu", SqlDbType.NVarChar).Value = _Barkod;
            }

            if (_StokBirimID != -1)
            {
                da.SelectCommand.CommandText += " and s.StokBirimID = @StokBirimID";
                da.SelectCommand.Parameters.Add("@StokBirimID", SqlDbType.Int).Value = _StokBirimID;
            }
            if (!string.IsNullOrEmpty(_RafYeriAciklama))
            {
                da.SelectCommand.CommandText += " and s.RafYeriAciklama = @RafYeriAciklama ";
                da.SelectCommand.Parameters.Add("@RafYeriAciklama", SqlDbType.NVarChar).Value = _RafYeriAciklama;
            }
            if (_UrunTanitimdaGoster != 0)
            {
                da.SelectCommand.CommandText += " and s.UrunTanitimdaGoster = @UrunTanitimdaGoster ";
                switch (_UrunTanitimdaGoster)
                {
                    case 1:
                        da.SelectCommand.Parameters.Add("@UrunTanitimdaGoster", SqlDbType.Bit).Value = true;
                        break;
                    case 2:
                        da.SelectCommand.Parameters.Add("@UrunTanitimdaGoster", SqlDbType.Bit).Value = false;
                        break;
                }
            }
            if (_EMagazaErisimi == 1)
            {
                da.SelectCommand.CommandText += " and s.EMagazaErisimi = @EMagazaErisimi ";
                da.SelectCommand.Parameters.Add("@EMagazaErisimi", SqlDbType.Bit).Value = 1;
            }
            if (_EMagazaErisimi == 2)
            {
                da.SelectCommand.CommandText += " and s.EMagazaErisimi = @EMagazaErisimi ";
                da.SelectCommand.Parameters.Add("@EMagazaErisimi", SqlDbType.Bit).Value = 0;
            }
            if (!string.IsNullOrEmpty(_Desi))
            {
                da.SelectCommand.CommandText += " and s.Desi = @Desi ";
                da.SelectCommand.Parameters.Add("@Desi", SqlDbType.Decimal).Value = _Desi;
            }
            if (!string.IsNullOrEmpty(_KisaAciklama))
            {
                da.SelectCommand.CommandText += " and s.KisaAciklama = @KisaAciklama ";
                da.SelectCommand.Parameters.Add("@KisaAciklama", SqlDbType.NVarChar).Value = _KisaAciklama;
            }
            if (!string.IsNullOrEmpty(_DetayliUrunBilgisi))
            {
                da.SelectCommand.CommandText += " and s.DetayliUrunBilgisi = @DetayliUrunBilgisi ";
                da.SelectCommand.Parameters.Add("@DetayliUrunBilgisi", SqlDbType.NVarChar).Value = _DetayliUrunBilgisi;
            }
            if (_HemenAlKategoriID != -1)
            {
                da.SelectCommand.CommandText += " and s.HemenAlKategoriID = @HemenAlKategoriID ";
                da.SelectCommand.Parameters.Add("@HemenAlKategoriID", SqlDbType.Int).Value = _HemenAlKategoriID;
            }
            if (!string.IsNullOrEmpty(_HemenAlID))
            {
                da.SelectCommand.CommandText += " and s.HemenAlID = @HemenAlID ";
                da.SelectCommand.Parameters.Add("@HemenAlID", SqlDbType.Int).Value = _HemenAlID;
            }
            if (_HemenAlKategoriGuncellenmesin == 2)
            {
                da.SelectCommand.CommandText += " and s.HemenAlKategoriGuncellenmesin = @HemenAlKategoriGuncellenmesin ";
                da.SelectCommand.Parameters.Add("@HemenAlKategoriGuncellenmesin", SqlDbType.Bit).Value = 1;
            }
            if (_HemenAlKategoriGuncellenmesin == 1)
            {
                da.SelectCommand.CommandText += " and s.HemenAlKategoriGuncellenmesin = @HemenAlKategoriGuncellenmesin ";
                da.SelectCommand.Parameters.Add("@HemenAlKategoriGuncellenmesin", SqlDbType.Bit).Value = 0;
            }
            if (_HemenAlDrum != "Güncelle veya Ekle")
            {
                //da.SelectCommand.CommandText += " and s.HemenAlDrum = @HemenAlDrum ";
                //da.SelectCommand.Parameters.Add("@HemenAlDrum", SqlDbType.NVarChar).Value = 0;
            }
            if (_HemenAlDrum == "Pasif")
            {
                da.SelectCommand.CommandText += " and s.HemenAlDrum = @HemenAlDrum ";
                da.SelectCommand.Parameters.Add("@HemenAlDrum", SqlDbType.Bit).Value = "P";
            }
            if (_HemenAlDrum == "Aktif")
            {
                da.SelectCommand.CommandText += " and s.HemenAlDrum = @HemenAlDrum ";
                da.SelectCommand.Parameters.Add("@HemenAlDrum", SqlDbType.Bit).Value = "A";
            }
            if (_HemenAlDrum == "Sil")
            {
                da.SelectCommand.CommandText += " and s.HemenAlDrum = @HemenAlDrum ";
                da.SelectCommand.Parameters.Add("@HemenAlDrum", SqlDbType.Bit).Value = "D";
            }
            if (_HemenAlDrum == "Stok Güncelle")
            {
                da.SelectCommand.CommandText += " and s.HemenAlDrum = @HemenAlDrum ";
                da.SelectCommand.Parameters.Add("@HemenAlDrum", SqlDbType.Bit).Value = "S";
            }
            if (_HemenAlDrum == "Güncelle veya Ekle")
            {
                //da.SelectCommand.CommandText += " and s.HemenAlDrum = @HemenAlDrum ";
                //da.SelectCommand.Parameters.Add("@HemenAlDrum", SqlDbType.NVarChar).Value = 0;
            }
            if (_HemenAlDrum == "Fiyat Guncelle")
            {
                da.SelectCommand.CommandText += " and s.HemenAlDrum = @HemenAlDrum ";
                da.SelectCommand.Parameters.Add("@HemenAlDrum", SqlDbType.NVarChar).Value = "F";
            }
            if (!string.IsNullOrEmpty(_HemenAlSira))
            {
                da.SelectCommand.CommandText += " and s.HemenAlSira = @HemenAlSira ";
                da.SelectCommand.Parameters.Add("@HemenAlSira", SqlDbType.Int).Value = _HemenAlSira;
            }
            if (_MiktariOlanlar == 0) // 0 sa hepsi
            {
                //da.SelectCommand.CommandText += " and KalanMiktar > 0";
            }
            else if (_MiktariOlanlar == 1) // 1
            {
                da.SelectCommand.CommandText += " and isnull(Girisler,0.0000) - isnull(Cikislar, 0.000) > 0";
            }
            else if (_MiktariOlanlar == 2)
            {
                da.SelectCommand.CommandText += " and isnull(Girisler,0.0000) - isnull(Cikislar, 0.000) < 0 or isnull(Girisler,0.0000) - isnull(Cikislar, 0.000) = 0 ";
            }

            if (_MinMiktarinAltindaOlanlar == true)
            {
                da.SelectCommand.CommandText += " and isnull(Girisler,0.0000) - isnull(Cikislar, 0.000) < s.MinumumMiktar ";
            }
            if (_OlmasiGerekenMiktardanAzOlanlar == true)
            {
                da.SelectCommand.CommandText += " and isnull(Girisler,0.0000) - isnull(Cikislar, 0.000) < s.OlmasiGerekenMiktar ";
            }

            if (_FotoOzellikleri != enumFotoOzellikleri.Hepsi)
            {
                switch (_FotoOzellikleri)
                {
                    case enumFotoOzellikleri.FotografiOlanlar:
                        da.SelectCommand.CommandText += " and StokResim.Resim is not null ";
                        break;
                    case enumFotoOzellikleri.Olmayanlar:
                        da.SelectCommand.CommandText += " and StokResim.Resim is null ";
                        break;
                    case enumFotoOzellikleri.VarsayilanFotosuFtpYeGonderilmemisOlanlar:
                        da.SelectCommand.CommandText += " and (StokResim.Ftp is null and StokResim.Varsayilan = 1) ";
                        break;
                    case enumFotoOzellikleri.FotografiFtpYeGonderilmemisOlanlar:
                        da.SelectCommand.CommandText += " and (StokResim.Ftp is null) ";
                        break;
                }
            }
            if (_StokSayimGrubuID != -1)
            {
                da.SelectCommand.CommandText += " and s.StokSayimGrubuID = @StokSayimGrubuID ";
                da.SelectCommand.Parameters.Add("@StokSayimGrubuID", SqlDbType.Int).Value = _StokSayimGrubuID;
            }

            if (_SadeceFiyatiOlanlar == true)
            {
                for (int i = 0; i < FiyatTanimlariID().Count(); i++) // buraya açıkla lazım
                {
                    da.SelectCommand.CommandText += @" and (select Top 1 stokFiyat.Fiyat from StokFiyat where stokfiyat.StokID = s.StokID and 
                                                      stokFiyat.FiyatTanimID = @FiyatTanimID" + i.ToString() + " ) > 0";
                }
            }
            if (_StokTipi != -1)
            {
                da.SelectCommand.CommandText += " and s.StokTipi = @StokTipi ";
                da.SelectCommand.Parameters.Add("@StokTipi", SqlDbType.Int).Value = _StokTipi;
            }
            if (_SayimID != -1)
            {
                //da.SelectCommand.CommandText += " and SayimDetay.SayimID = @SayimID ";
                //da.SelectCommand.Parameters.Add("@SayimID", SqlDbType.Int).Value = _SayimID;
            }
            if (_N11Entegrasyonu != -1)
            {
                da.SelectCommand.CommandText += " and s.StokID in (select StokID from n11Product) ";
            }

            dt_StokListesi = new DataTable();

            da.Fill(dt_StokListesi);

            //StokFiyatTanimIDver_TabloAl(Baglanti, Tr, 2);

            #region Silinecek linq Bilgi olsun diye bırak
            /*
      var query = from Stoklar in dt_StokListesi.AsEnumerable()
                  join Fiyatlar in dt_FiyatListesi.AsEnumerable()
                                   on Stoklar.Field<int>("StokID") equals Fiyatlar.Field<int>("StokID")
                  into fii
                  from LeftJoinliFiyatlar in fii.DefaultIfEmpty()
                  select new
                  {
                    //Stoklar, LeftJoinliFiyatlar
                    StokID = Stoklar["StokID"],
                    Aktif = Stoklar["Aktif"],
                    StokKodu = Stoklar["StokKodu"],
                    StokAdi = Stoklar["StokAdi"],
                    OzelKod1 = Stoklar["OzelKod1"],
                    OzelKod2 = Stoklar["OzelKod2"],
                    OzelKod3 = Stoklar["OzelKod3"],
                    StokGrupID = Stoklar["StokGrupID"],
                    StokAraGrupID = Stoklar["StokAraGrupID"],
                    StokAltGrupID = Stoklar["StokAltGrupID"],
                    Aciklama = Stoklar["Aciklama"],
                    KaydedenID = Stoklar["KaydedenID"],
                    KayitTarihi = Stoklar["KayitTarihi"],
                    DegistirenID = Stoklar["DegistirenID"],
                    DegismeTarihi = Stoklar["DegismeTarihi"],
                    StokBirimID = Stoklar["StokBirimID"],
                    iskOrani1 = Stoklar["iskOrani1"],
                    iskOrani2 = Stoklar["iskOrani2"],
                    iskOrani3 = Stoklar["iskOrani3"],
                    MinumumMiktar = Stoklar["MinumumMiktar"],
                    MaksimumMiktar = Stoklar["MaksimumMiktar"],
                    EtiketAdi = Stoklar["EtiketAdi"],
                    AlisKdv = Stoklar["AlisKdv"],
                    SatisKdv = Stoklar["SatisKdv"],
                    Barkod = Stoklar["Barkod"],
                    BirimAdi = Stoklar["BirimAdi"],
                    RafYeriAciklama = Stoklar["RafYeriAciklama"],
                    UrunTanitimdaGoster = Stoklar["UrunTanitimdaGoster"],
                    Garanti = Stoklar["Garanti"],
                    EMagazaErisimi = Stoklar["EMagazaErisimi"],
                    Desi = Stoklar["Desi"],
                    KisaAciklama = Stoklar["KisaAciklama"],
                    DetayliUrunBilgisi = Stoklar["DetayliUrunBilgisi"],
                    HemenAlKategoriID = Stoklar["HemenAlKategoriID"],
                    HemenAlID = Stoklar["HemenAlID"],
                    HemenAlKategoriGuncellenmesin = Stoklar["HemenAlKategoriGuncellenmesin"],
                    HemenAlDrum = Stoklar["HemenAlDrum"],
                    HemenAlSira = Stoklar["HemenAlSira"],
                    //Fiyat = LeftJoinliFiyatlar[0]


                    Fiyat = (LeftJoinliFiyatlar == null) ? 0 : LeftJoinliFiyatlar[1]
                  };
       */
            #endregion


            return dt_StokListesi;
        }

        private string[] FiyatTanimlariID()
        {
            string[] Degerler = { };
            if (!string.IsNullOrEmpty(_StokFiyatTanimIDleri))
                Degerler = _StokFiyatTanimIDleri.Split(',');
            return Degerler;
        }

        private string[] FiyatTanimlariAdlari()
        {
            string[] Degerler = { };
            if (!string.IsNullOrEmpty(_StokFiyatTanimAdlari))
                Degerler = _StokFiyatTanimAdlari.Split(',');
            return Degerler;
        }

        public decimal BarkdundanMiktarVer(SqlConnection Baglanti, SqlTransaction Tr, string Barkoduu)
        {
            using (Ayarlar.csBarkodNuVer nuver = new Ayarlar.csBarkodNuVer())
            {
                return nuver.BarkodtanMiktarVer(Baglanti, Tr, Barkoduu);
            }
        }

        public byte[] StokIDverVarsayilanFotoAl(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            cmb = new SqlCommand(@"select Resim from StokResim where Varsayilan = 1 and StokID = @StokID", Baglanti, Tr);
            cmb.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

            return (byte[])cmb.ExecuteScalar();
        }

        public DataTable dt_Fotolistesi;

        // TODO bu alanı csResim de alacak normalde
        public void FotoListesiVer(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (da = new SqlDataAdapter(@"select StokResimID, StokID, ResimAciklama, Varsayilan, ftp , StokResim.Resim  from StokResim 
                                      where StokID = @StokID", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

                dt_Fotolistesi = new DataTable();
                da.Fill(dt_Fotolistesi);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DataTable StokFiyatTanimIDver_TabloAl(SqlConnection Baglanti, SqlTransaction Tr, int StokFiyatTanimID)
        {
            da = new SqlDataAdapter(@"select StokID, Fiyat from StokFiyat where FiyatTanimID = @FiyatTanimID ", Baglanti);
            da.SelectCommand.Transaction = Tr;
            da.SelectCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int).Value = StokFiyatTanimID;

            dt_FiyatListesi = new DataTable();
            da.Fill(dt_FiyatListesi);

            cmb = new SqlCommand("select FiyatTanim.FiyatTanimAdi from FiyatTanim where  FiyatTanim.FiyatTanimID = @FiyatTanimID", Baglanti, Tr);
            cmb.Parameters.Add("@FiyatTanimID", SqlDbType.Int).Value = StokFiyatTanimID;

            dt_FiyatListesi.Columns["Fiyat"].ColumnName = cmb.ExecuteScalar().ToString();

            return dt_FiyatListesi;
        }
    }
}

