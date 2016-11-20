using System;
using System.Data.SqlClient;

namespace clsTablolar.TeraziSatisClaslari
{
    public class csTeraziAyarlari : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        //public static string MusteriBarkodNumarasiOnEki = "24";
        public static string PersonelBarkodNumarasiOnEki = "28";
        public static string FaturaBarkodIcinKullanilacakOnEk = "24";
        public static int YeniSiparisDurumID = 2;
        public static int TeraziSatisVarsayilanCariID = 2;
        public static string SiparisBarkodNumarasiOnEki = "29";
        //public static string Fa


        public void AyarlariGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {



        }

        public string FaturaBarkodIcinKullanilacakOnEk_Getir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            SqlCommand cmd = new SqlCommand("select onek from barkodayar with(nolock) where BarkodunKullanildigiYer = 2", Baglanti, Tr);
            FaturaBarkodIcinKullanilacakOnEk = cmd.ExecuteScalar().ToString();
            return FaturaBarkodIcinKullanilacakOnEk;
        }
    }
}
