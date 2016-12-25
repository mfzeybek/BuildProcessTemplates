
namespace clsTablolar
{
    /// <summary>
    /// Program içindeki bütün Kartlarda kullanılan Kod değerlerini tutar.
    /// </summary>
    public enum IslemTipi // pekçok yerde kullanılıyor
    {
        SatisFaturasi = 1,
        AlisFaturasi = 2,
        SatisIadeFaturasi = 3,
        AlisIadeFaturasi = 4,

        StokKarti = 5,

        SatisIrsaliyesi = 6,
        AlisIrsaliyesi = 7,
        SatisIadeIrsaliyesi = 8,
        AlisIadeIrsaliyesi = 9,

        VerilenSiparis = 10,
        AlinanSiparis = 11,

        StokDevir = 12,

        CariKart = 13,
        // 14 boşta
        BankaHareketi = 15,
        StokGirisi = 16,
        StokCikisi = 17,

        AlinanCek = 18,
        VerilenCek = 19,
        StokSayim = 20,

        StokEtiket = 21,

        IsBasvuruFormlari = 22,
        CariListe = 23,
        CariHareket = 24, // CariHr nakit ödemeler burada
        SiparisVerme = 25,
        BasitUretimRecetesi = 26,
        BasitUretim = 27,
        BasitUretimDetay = 28
    }

    public class FormBaslik
    {
        /// <summary>
        /// Form Başlıklarını değiştirmek için kullanacağımız fonksiyon
        /// </summary>
        /// <param name="IslemTipi">enum olarak tanımladığımız işlem tipidir.</param>
        /// <returns>string olarak Form başlığını döner</returns>
        public string FormBaslikDon(int IslemTipi)
        {
            string Baslik = "";
            switch (IslemTipi.GetHashCode())
            {
                case 1:
                    Baslik = "SATIŞ FATURASI";
                    break;
                case 2:
                    Baslik = "ALIŞ FATURASI";
                    break;
                case 3:
                    Baslik = "SATIŞ İADE FATURASI";
                    break;
                case 4:
                    Baslik = "ALIŞ İADE FATURASI";
                    break;
                case 5:
                    Baslik = "STOK KARTI";
                    break;
                case 6:
                    Baslik = "SATIŞ İRSALİYESİ";
                    break;
                case 7:
                    Baslik = "ALIŞ İRSALİYESİ";
                    break;
                case 8:
                    Baslik = "SATIŞ İADE İRSALİYESİ";
                    break;
                case 9:
                    Baslik = "ALIŞ İADE İRSALİYESİ";
                    break;
                case 10:
                    Baslik = "VERİLEN SİPARİŞ";
                    break;
                case 11:
                    Baslik = "ALINAN SİPARİŞ";
                    break;
                default:
                    break;
            }
            return Baslik;
        }
    }
}
