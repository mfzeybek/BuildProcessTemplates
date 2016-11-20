using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace clsTablolar.Ayarlar
{
    public class csYetkiler : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        #region Alanlar
        public int YetkiID { get; set; }



        public int KullaniciID { get; set; }

        #region Cari ile ilgili Yetkilendirmeler

        public static bool CariKartGorme { get; set; }
        public static bool CariKartEkleme { get; set; }
        public static bool CariKartDuzenleme { get; set; }
        public static bool CariKartSilme { get; set; }

        #endregion

        #region Stok Kart ile İlgili Yetkilendirmeler

        public static bool StokKartGorme { get; set; }
        public static bool StokKartEkleme { get; set; }
        public static bool StokKartDuzenleme { get; set; }
        public static bool StokKartSilme { get; set; }

        #endregion

        public static bool SatisFaturasiGorme { get; set; }
        public static bool SatisFaturasiEkleme { get; set; }
        public static bool SatisFaturasiDuzenleme { get; set; }
        public static bool SatisFaturasiSilme { get; set; }

        public static bool AlisFaturasiGorme { get; set; }
        public static bool AlisFaturasiEkleme { get; set; }
        public static bool AlisFaturasiDuzenleme { get; set; }
        public static bool AlisFaturasiSilme { get; set; }
        public static bool SatisIrsaliyesiGorme { get; set; }
        public static bool SatisIrsaliyesiEkleme { get; set; }
        public static bool SatisIrsaliyesiDuzenleme { get; set; }
        public static bool SatisIrsaliyesiSilme { get; set; }
        public static bool AlisIrsaliyesiGorme { get; set; }
        public static bool AlisIrsaliyesiEkleme { get; set; }
        public static bool AlisIrsaliyesiDuzenleme { get; set; }
        public static bool AlisIrsaliyesiSilme { get; set; }
        public static bool AlinanSiparisGorme { get; set; }
        public static bool AlinanSiparisEkleme { get; set; }
        public static bool AlinanSiparisDuzenleme { get; set; }
        public static bool AlinanSiparisSilme { get; set; }
        public static bool VerilenSiparisGorme { get; set; }
        public static bool VerilenSiparisEklme { get; set; }
        public static bool VerilenSiparisDuzenleme { get; set; }
        public static bool VerilenSiparisSilme { get; set; }
        public static bool BasitUretimReceteGosterme { get; set; }
        public static bool BasitUretimReceteEkleme { get; set; }
        public static bool BasitUretimReceteDuzenleme { get; set; }
        public static bool BasitUretimReceteSilme { get; set; }
        public static bool VerilenCekGosterme { get; set; }
        public static bool VerilenCekEkleme { get; set; }
        public static bool VerilenCekDuzenleme { get; set; }
        public static bool VerilenCekSilme { get; set; }
        public static bool AlinanCekGosterme { get; set; }
        public static bool AlinanCekEkleme { get; set; }
        public static bool AlinanCekDuzenleme { get; set; }
        public static bool AlinanCekSilme { get; set; }
        public static bool IsBasvuruGosterme { get; set; }
        public static bool IsBasvuruEkleme { get; set; }
        public static bool IsBasvuruDuzenleme { get; set; }
        public static bool IsBasvuruSilme { get; set; }




        public static bool CariHareketleriGorme { get; set; }
        public static bool CariHareketEkleme { get; set; }
        public static bool CariHareketDuzeltme { get; set; }
        public static bool CariHareketSilme { get; set; }

        public static bool HemenAlIslemleri { get; set; } // Sonra Ayrıntılandırılacak
        public static bool PersonelIslemleri { get; set; }// Sonra Ayrıntılandırılacak

        public static bool Ayarlar { get; set; } // Sonra Ayrıntılandırılacak

        public static bool StokEtiket { get; set; }

        public static bool FiyatAnaliz { get; set; }

        public static bool AlisFaturasindanIadeGorme { get; set; }
        public static bool AlisFaturasindanIadeEkleme { get; set; }
        public static bool AlisFaturasindanIadeDuzeltme { get; set; }
        public static bool AlisFaturasindanIadeSilme { get; set; }
        public static bool SatisFaturasindanIadeGorme { get; set; }
        public static bool SatisFaturasindanIadeEkleme { get; set; }
        public static bool SatisFaturasindanIadeDuzeltme { get; set; }
        public static bool SatisFaturasindanIadeSilme { get; set; }

        public static bool StokHareketleri { get; set; } // sonra Ayrıntılandırılacak

        public static bool StokSayim { get; set; } // sonra Ayrıntılandırılacak
        public static bool AjandaGorme { get; set; }

        public static bool YazdirmaAyarlariDuzenleme { get; set; }


        // Veritabanına son eklenen yetkiler buraya işlenmedi sanırım


        #endregion

        private uint _PropertyName;
        SqlCommand cmd;
        SqlDataReader dr;

        // Alanları program içinde kullanılacak gibi public static yaptık
        //
        // kullanıcının Yetkilendirmesi Değiştirilmek istendiğinde
        //


        /// <summary>
        /// Aktif kullanıcının yetkilerini getirir ve yukarıdaki değişkenlere atar
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        public csYetkiler(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (cmd = new SqlCommand("select * from Yetkiler where KullaniciID = @KullaniciID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@KullaniciID", SqlDbType.Int).Value = csKullanici.KullaniciID;

                using (dr = cmd.ExecuteReader())
                {
                    try
                    {
                        dr.Read();
                        //_YetkiID 
                        KullaniciID = (int)dr["KullaniciID"];
                        CariKartGorme = (bool)dr["CariKartGorme"];
                        CariKartEkleme = (bool)dr["CariKartEkleme"];
                        CariKartDuzenleme = (bool)dr["CariKartDuzenleme"];
                        CariKartSilme = (bool)dr["CariKartSilme"];
                        StokKartGorme = (bool)dr["StokKartGorme"];
                        StokKartEkleme = (bool)dr["StokKartEkleme"];
                        StokKartDuzenleme = (bool)dr["StokKartDuzenleme"];
                        StokKartSilme = (bool)dr["StokKartSilme"];
                        SatisFaturasiGorme = (bool)dr["SatisFaturasiGorme"];
                        SatisFaturasiEkleme = (bool)dr["SatisFaturasiEkleme"];
                        SatisFaturasiDuzenleme = (bool)dr["SatisFaturasiDuzenleme"];
                        SatisFaturasiSilme = (bool)dr["SatisFaturasiSilme"];
                        AlisFaturasiGorme = (bool)dr["AlisFaturasiGorme"];
                        AlisFaturasiEkleme = (bool)dr["AlisFaturasiEkleme"];
                        AlisFaturasiDuzenleme = (bool)dr["AlisFaturasiDuzenleme"];
                        AlisFaturasiSilme = (bool)dr["AlisFaturasiSilme"];
                        SatisIrsaliyesiGorme = (bool)dr["SatisIrsaliyesiGorme"];
                        SatisIrsaliyesiEkleme = (bool)dr["SatisIrsaliyesiEkleme"];
                        SatisIrsaliyesiDuzenleme = (bool)dr["SatisIrsaliyesiDuzenleme"];
                        SatisIrsaliyesiSilme = (bool)dr["SatisIrsaliyesiSilme"];
                        AlisIrsaliyesiGorme = (bool)dr["AlisIrsaliyesiGorme"];
                        AlisIrsaliyesiEkleme = (bool)dr["AlisIrsaliyesiEkleme"];
                        AlisIrsaliyesiDuzenleme = (bool)dr["AlisIrsaliyesiDuzenleme"];
                        AlisIrsaliyesiSilme = (bool)dr["AlisIrsaliyesiSilme"];
                        AlinanSiparisGorme = (bool)dr["AlinanSiparisGorme"];
                        AlinanSiparisEkleme = (bool)dr["AlinanSiparisEkleme"];
                        AlinanSiparisDuzenleme = (bool)dr["AlinanSiparisDuzenleme"];
                        AlinanSiparisSilme = (bool)dr["AlinanSiparisSilme"];
                        VerilenSiparisGorme = (bool)dr["VerilenSiparisGorme"];
                        VerilenSiparisEklme = (bool)dr["VerilenSiparisEklme"];
                        VerilenSiparisDuzenleme = (bool)dr["VerilenSiparisDuzenleme"];
                        VerilenSiparisSilme = (bool)dr["VerilenSiparisSilme"];
                        BasitUretimReceteGosterme = (bool)dr["BasitUretimReceteGosterme"];
                        BasitUretimReceteEkleme = (bool)dr["BasitUretimReceteEkleme"];
                        BasitUretimReceteDuzenleme = (bool)dr["BasitUretimReceteDuzenleme"];
                        BasitUretimReceteSilme = (bool)dr["BasitUretimReceteSilme"];
                        VerilenCekGosterme = (bool)dr["VerilenCekGosterme"];
                        VerilenCekEkleme = (bool)dr["VerilenCekEkleme"];
                        VerilenCekDuzenleme = (bool)dr["VerilenCekDuzenleme"];
                        VerilenCekSilme = (bool)dr["VerilenCekSilme"];
                        AlinanCekGosterme = (bool)dr["AlinanCekGosterme"];
                        AlinanCekEkleme = (bool)dr["AlinanCekEkleme"];
                        AlinanCekDuzenleme = (bool)dr["AlinanCekDuzenleme"];
                        AlinanCekSilme = (bool)dr["AlinanCekSilme"];
                        IsBasvuruGosterme = (bool)dr["IsBasvuruGosterme"];
                        IsBasvuruEkleme = (bool)dr["IsBasvuruEkleme"];
                        IsBasvuruDuzenleme = (bool)dr["IsBasvuruDuzenleme"];
                        IsBasvuruSilme = (bool)dr["IsBasvuruSilme"];


                        CariHareketleriGorme = (bool)dr["CariHareketleriGorme"];
                        CariHareketEkleme = (bool)dr["CariHareketEkleme"];
                        CariHareketDuzeltme = (bool)dr["CariHareketDuzeltme"];
                        CariHareketSilme = (bool)dr["CariHareketSilme"];

                        HemenAlIslemleri = (bool)dr["HemenAlIslemleri"];
                        PersonelIslemleri = (bool)dr["PersonelIslemleri"];

                        Ayarlar = (bool)dr["Ayarlar"];

                        StokEtiket = (bool)dr["StokEtiket"];

                        FiyatAnaliz = (bool)dr["FiyatAnaliz"];

                        AlisFaturasindanIadeGorme = (bool)dr["AlisFaturasindanIadeGorme"];
                        AlisFaturasindanIadeEkleme = (bool)dr["AlisFaturasindanIadeEkleme"];
                        AlisFaturasindanIadeDuzeltme = (bool)dr["AlisFaturasindanIadeDuzeltme"];
                        AlisFaturasindanIadeSilme = (bool)dr["AlisFaturasindanIadeSilme"];
                        SatisFaturasindanIadeGorme = (bool)dr["SatisFaturasindanIadeGorme"];
                        SatisFaturasindanIadeEkleme = (bool)dr["SatisFaturasindanIadeEkleme"];
                        SatisFaturasindanIadeDuzeltme = (bool)dr["SatisFaturasindanIadeDuzeltme"];
                        SatisFaturasindanIadeSilme = (bool)dr["SatisFaturasindanIadeSilme"];

                        StokHareketleri = (bool)dr["StokHareketleri"];

                        StokSayim = (bool)dr["StokSayim"];

                        AjandaGorme = (bool)dr["AjandaGorme"];
                        YazdirmaAyarlariDuzenleme = (bool)dr["YazdirmaAyarlariDuzenleme"];
                    }
                    catch (Exception)
                    {

                    }

                }
            }
        }


        // csYetkiler diye 2 defa şekilde türete biliyoruz çünkü
        // 1ncisi program açılırken kullanıcının yetkilerini getirsin diye
        // 2ncisi Programdan aktif kullanıcının veya farklı bir kullanıcının yetkilerini değiştirebilmek içinx

        /// <summary>
        /// Yetkilendirme formunda çağırabilmek için
        /// bunu bu şekilde türettikten sonra YetkilerGetir() i çağırmak gerekiyor
        /// </summary>
        public csYetkiler()
        {

        }


        DataTable dt;
        SqlDataAdapter da;

        /// <summary>
        /// Yetkileri Düzenlemek için
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable YetkilerGetir(SqlConnection Baglanti, SqlTransaction Tr, int UserID)
        {
            using (da = new SqlDataAdapter(@"select Yetkiler.* from yetkiler where KullaniciID = @KullaniciID", Baglanti))
            {
                try
                {
                    da.SelectCommand.Transaction = Tr;
                    da.SelectCommand.Parameters.Add("@KullaniciID", SqlDbType.Int).Value = UserID;

                    dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    return dt;
                }
            }
        }

        public void YetkileriKaydet(SqlConnection Baglanti, SqlTransaction Tr, int UserID)
        {
            using (da.UpdateCommand = new SqlCommand(@"
update Yetkiler set  KullaniciID = @KullaniciID, 
CariKartGorme = @CariKartGorme, CariKartEkleme = @CariKartEkleme, CariKartDuzenleme = @CariKartDuzenleme, CariKartSilme = @CariKartSilme, 
StokKartGorme = @StokKartGorme, StokKartEkleme = @StokKartEkleme, StokKartDuzenleme = @StokKartDuzenleme, StokKartSilme = @StokKartSilme, 
SatisFaturasiGorme = @SatisFaturasiGorme, SatisFaturasiEkleme = @SatisFaturasiEkleme, SatisFaturasiDuzenleme = @SatisFaturasiDuzenleme, SatisFaturasiSilme = @SatisFaturasiSilme, 
AlisFaturasiGorme = @AlisFaturasiGorme, AlisFaturasiEkleme = @AlisFaturasiEkleme, AlisFaturasiDuzenleme = @AlisFaturasiDuzenleme, AlisFaturasiSilme = @AlisFaturasiSilme, 
SatisIrsaliyesiGorme = @SatisIrsaliyesiGorme, SatisIrsaliyesiEkleme = @SatisIrsaliyesiEkleme, SatisIrsaliyesiDuzenleme = @SatisIrsaliyesiDuzenleme, SatisIrsaliyesiSilme = @SatisIrsaliyesiSilme, 
AlisIrsaliyesiGorme = @AlisIrsaliyesiGorme, AlisIrsaliyesiEkleme = @AlisIrsaliyesiEkleme, AlisIrsaliyesiDuzenleme = @AlisIrsaliyesiDuzenleme, AlisIrsaliyesiSilme = @AlisIrsaliyesiSilme, 
AlinanSiparisGorme = @AlinanSiparisGorme, AlinanSiparisEkleme = @AlinanSiparisEkleme, AlinanSiparisDuzenleme = @AlinanSiparisDuzenleme, AlinanSiparisSilme = @AlinanSiparisSilme, 
VerilenSiparisGorme = @VerilenSiparisGorme, VerilenSiparisEklme = @VerilenSiparisEklme, VerilenSiparisDuzenleme = @VerilenSiparisDuzenleme, VerilenSiparisSilme = @VerilenSiparisSilme, 
BasitUretimReceteGosterme = @BasitUretimReceteGosterme, BasitUretimReceteEkleme = @BasitUretimReceteEkleme, BasitUretimReceteDuzenleme = @BasitUretimReceteDuzenleme, BasitUretimReceteSilme = @BasitUretimReceteSilme, 
VerilenCekGosterme = @VerilenCekGosterme, VerilenCekEkleme = @VerilenCekEkleme, VerilenCekDuzenleme = @VerilenCekDuzenleme, VerilenCekSilme = @VerilenCekSilme, 
AlinanCekGosterme = @AlinanCekGosterme, AlinanCekEkleme = @AlinanCekEkleme, AlinanCekDuzenleme = @AlinanCekDuzenleme, AlinanCekSilme = @AlinanCekSilme, 
IsBasvuruGosterme = @IsBasvuruGosterme, IsBasvuruEkleme = @IsBasvuruEkleme, IsBasvuruDuzenleme = @IsBasvuruDuzenleme, IsBasvuruSilme = @IsBasvuruSilme,
CariHareketleriGorme = @CariHareketleriGorme, CariHareketEkleme = @CariHareketEkleme, CariHareketDuzeltme = @CariHareketDuzeltme, CariHareketSilme = @CariHareketSilme,
HemenAlIslemleri = @HemenAlIslemleri, PersonelIslemleri = @PersonelIslemleri, Ayarlar = @Ayarlar, StokEtiket = @StokEtiket, FiyatAnaliz = @FiyatAnaliz, 
AlisFaturasindanIadeGorme = @AlisFaturasindanIadeGorme, AlisFaturasindanIadeEkleme = @AlisFaturasindanIadeEkleme, AlisFaturasindanIadeDuzeltme = @AlisFaturasindanIadeDuzeltme, AlisFaturasindanIadeSilme = @AlisFaturasindanIadeSilme,
SatisFaturasindanIadeGorme = @SatisFaturasindanIadeGorme, SatisFaturasindanIadeEkleme = @SatisFaturasindanIadeEkleme, SatisFaturasindanIadeDuzeltme = @SatisFaturasindanIadeDuzeltme, SatisFaturasindanIadeSilme = @SatisFaturasindanIadeSilme,
StokHareketleri = @StokHareketleri, StokSayim = @StokSayim

where YetkiID = @YetkiID", Baglanti, Tr))
            {


                da.UpdateCommand.Parameters.AddWithValue("@KullaniciID", UserID);

                da.UpdateCommand.Parameters.Add("@CariKartGorme", SqlDbType.Bit, 1, "CariKartGorme");
                da.UpdateCommand.Parameters.Add("@CariKartEkleme", SqlDbType.Bit, 1, "CariKartEkleme");
                da.UpdateCommand.Parameters.Add("@CariKartDuzenleme", SqlDbType.Bit, 1, "CariKartDuzenleme");
                da.UpdateCommand.Parameters.Add("@CariKartSilme", SqlDbType.Bit, 1, "CariKartSilme");
                da.UpdateCommand.Parameters.Add("@StokKartGorme", SqlDbType.Bit, 1, "StokKartGorme");
                da.UpdateCommand.Parameters.Add("@StokKartEkleme", SqlDbType.Bit, 1, "StokKartEkleme");
                da.UpdateCommand.Parameters.Add("@StokKartDuzenleme", SqlDbType.Bit, 1, "StokKartDuzenleme");
                da.UpdateCommand.Parameters.Add("@StokKartSilme", SqlDbType.Bit, 1, "StokKartSilme");
                da.UpdateCommand.Parameters.Add("@SatisFaturasiGorme", SqlDbType.Bit, 1, "SatisFaturasiGorme");
                da.UpdateCommand.Parameters.Add("@SatisFaturasiEkleme", SqlDbType.Bit, 1, "SatisFaturasiEkleme");
                da.UpdateCommand.Parameters.Add("@SatisFaturasiDuzenleme", SqlDbType.Bit, 1, "SatisFaturasiDuzenleme");
                da.UpdateCommand.Parameters.Add("@SatisFaturasiSilme", SqlDbType.Bit, 1, "SatisFaturasiSilme");
                da.UpdateCommand.Parameters.Add("@AlisFaturasiGorme", SqlDbType.Bit, 1, "AlisFaturasiGorme");
                da.UpdateCommand.Parameters.Add("@AlisFaturasiEkleme", SqlDbType.Bit, 1, "AlisFaturasiEkleme");
                da.UpdateCommand.Parameters.Add("@AlisFaturasiDuzenleme", SqlDbType.Bit, 1, "AlisFaturasiDuzenleme");
                da.UpdateCommand.Parameters.Add("@AlisFaturasiSilme", SqlDbType.Bit, 1, "AlisFaturasiSilme");
                da.UpdateCommand.Parameters.Add("@SatisIrsaliyesiGorme ", SqlDbType.Bit, 1, "SatisIrsaliyesiGorme");
                da.UpdateCommand.Parameters.Add("@SatisIrsaliyesiEkleme", SqlDbType.Bit, 1, "SatisIrsaliyesiEkleme");
                da.UpdateCommand.Parameters.Add("@SatisIrsaliyesiDuzenleme", SqlDbType.Bit, 1, "SatisIrsaliyesiDuzenleme");
                da.UpdateCommand.Parameters.Add("@SatisIrsaliyesiSilme", SqlDbType.Bit, 1, "SatisIrsaliyesiSilme");
                da.UpdateCommand.Parameters.Add("@AlisIrsaliyesiGorme", SqlDbType.Bit, 1, "AlisIrsaliyesiGorme");
                da.UpdateCommand.Parameters.Add("@AlisIrsaliyesiEkleme", SqlDbType.Bit, 1, "AlisIrsaliyesiEkleme");
                da.UpdateCommand.Parameters.Add("@AlisIrsaliyesiDuzenleme", SqlDbType.Bit, 1, "AlisIrsaliyesiDuzenleme");
                da.UpdateCommand.Parameters.Add("@AlisIrsaliyesiSilme", SqlDbType.Bit, 1, "AlisIrsaliyesiSilme");
                da.UpdateCommand.Parameters.Add("@AlinanSiparisGorme", SqlDbType.Bit, 1, "AlinanSiparisGorme");
                da.UpdateCommand.Parameters.Add("@AlinanSiparisEkleme", SqlDbType.Bit, 1, "AlinanSiparisEkleme");
                da.UpdateCommand.Parameters.Add("@AlinanSiparisDuzenleme", SqlDbType.Bit, 1, "AlinanSiparisDuzenleme");
                da.UpdateCommand.Parameters.Add("@AlinanSiparisSilme", SqlDbType.Bit, 1, "AlinanSiparisSilme");
                da.UpdateCommand.Parameters.Add("@VerilenSiparisGorme", SqlDbType.Bit, 1, "VerilenSiparisGorme");
                da.UpdateCommand.Parameters.Add("@VerilenSiparisEklme", SqlDbType.Bit, 1, "VerilenSiparisEklme");
                da.UpdateCommand.Parameters.Add("@VerilenSiparisDuzenleme", SqlDbType.Bit, 1, "VerilenSiparisDuzenleme");
                da.UpdateCommand.Parameters.Add("@VerilenSiparisSilme", SqlDbType.Bit, 1, "VerilenSiparisSilme");
                da.UpdateCommand.Parameters.Add("@BasitUretimReceteGosterme", SqlDbType.Bit, 1, "BasitUretimReceteGosterme");
                da.UpdateCommand.Parameters.Add("@BasitUretimReceteEkleme", SqlDbType.Bit, 1, "BasitUretimReceteEkleme");
                da.UpdateCommand.Parameters.Add("@BasitUretimReceteDuzenleme", SqlDbType.Bit, 1, "BasitUretimReceteDuzenleme");
                da.UpdateCommand.Parameters.Add("@BasitUretimReceteSilme", SqlDbType.Bit, 1, "BasitUretimReceteSilme");
                da.UpdateCommand.Parameters.Add("@VerilenCekGosterme", SqlDbType.Bit, 1, "VerilenCekGosterme");
                da.UpdateCommand.Parameters.Add("@VerilenCekEkleme", SqlDbType.Bit, 1, "VerilenCekEkleme");
                da.UpdateCommand.Parameters.Add("@VerilenCekDuzenleme", SqlDbType.Bit, 1, "VerilenCekDuzenleme");
                da.UpdateCommand.Parameters.Add("@VerilenCekSilme", SqlDbType.Bit, 1, "VerilenCekSilme");
                da.UpdateCommand.Parameters.Add("@AlinanCekGosterme", SqlDbType.Bit, 1, "AlinanCekGosterme");
                da.UpdateCommand.Parameters.Add("@AlinanCekEkleme", SqlDbType.Bit, 1, "AlinanCekEkleme");
                da.UpdateCommand.Parameters.Add("@AlinanCekDuzenleme", SqlDbType.Bit, 1, "AlinanCekDuzenleme");
                da.UpdateCommand.Parameters.Add("@AlinanCekSilme", SqlDbType.Bit, 1, "AlinanCekSilme");
                da.UpdateCommand.Parameters.Add("@IsBasvuruGosterme", SqlDbType.Bit, 1, "IsBasvuruGosterme");
                da.UpdateCommand.Parameters.Add("@IsBasvuruEkleme", SqlDbType.Bit, 1, "IsBasvuruEkleme");
                da.UpdateCommand.Parameters.Add("@IsBasvuruDuzenleme", SqlDbType.Bit, 1, "IsBasvuruDuzenleme");
                da.UpdateCommand.Parameters.Add("@IsBasvuruSilme", SqlDbType.Bit, 1, "IsBasvuruSilme");


                da.UpdateCommand.Parameters.Add("@CariHareketleriGorme", SqlDbType.Bit, 1, "CariHareketleriGorme");
                da.UpdateCommand.Parameters.Add("@CariHareketEkleme", SqlDbType.Bit, 1, "CariHareketEkleme");
                da.UpdateCommand.Parameters.Add("@CariHareketDuzeltme", SqlDbType.Bit, 1, "CariHareketDuzeltme");
                da.UpdateCommand.Parameters.Add("@CariHareketSilme", SqlDbType.Bit, 1, "CariHareketSilme");

                da.UpdateCommand.Parameters.Add("@HemenAlIslemleri", SqlDbType.Bit, 1, "HemenAlIslemleri");
                da.UpdateCommand.Parameters.Add("@PersonelIslemleri", SqlDbType.Bit, 1, "PersonelIslemleri");
                da.UpdateCommand.Parameters.Add("@Ayarlar", SqlDbType.Bit, 1, "Ayarlar");

                da.UpdateCommand.Parameters.Add("@StokEtiket", SqlDbType.Bit, 1, "StokEtiket");


                da.UpdateCommand.Parameters.Add("@FiyatAnaliz", SqlDbType.Bit, 1, "FiyatAnaliz");
                da.UpdateCommand.Parameters.Add("@AlisFaturasindanIadeGorme", SqlDbType.Bit, 1, "AlisFaturasindanIadeGorme");
                da.UpdateCommand.Parameters.Add("@AlisFaturasindanIadeEkleme", SqlDbType.Bit, 1, "AlisFaturasindanIadeEkleme");
                da.UpdateCommand.Parameters.Add("@AlisFaturasindanIadeDuzeltme", SqlDbType.Bit, 1, "AlisFaturasindanIadeDuzeltme");
                da.UpdateCommand.Parameters.Add("@AlisFaturasindanIadeSilme", SqlDbType.Bit, 1, "AlisFaturasindanIadeSilme");
                da.UpdateCommand.Parameters.Add("@SatisFaturasindanIadeGorme", SqlDbType.Bit, 1, "SatisFaturasindanIadeGorme");
                da.UpdateCommand.Parameters.Add("@SatisFaturasindanIadeEkleme", SqlDbType.Bit, 1, "SatisFaturasindanIadeEkleme");
                da.UpdateCommand.Parameters.Add("@SatisFaturasindanIadeDuzeltme", SqlDbType.Bit, 1, "SatisFaturasindanIadeDuzeltme");

                da.UpdateCommand.Parameters.Add("@SatisFaturasindanIadeSilme", SqlDbType.Bit, 1, "SatisFaturasindanIadeSilme");
                da.UpdateCommand.Parameters.Add("@StokHareketleri", SqlDbType.Bit, 1, "StokHareketleri");
                da.UpdateCommand.Parameters.Add("@StokSayim", SqlDbType.Bit, 1, "StokSayim");

                da.UpdateCommand.Parameters.Add("@YetkiID", SqlDbType.Int, 1, "YetkiID");






                da.Update(dt);
            }

        }

        // yeni bir kullanıcı kaydedildiğinde yapılcak işlemler yapılmadı
    }
}
