using System;
using System.Data.SqlClient;

namespace clsTablolar.TeraziSatisClaslari
{
    public class csFaturaBarkodKullanilacakOnEk : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public string FaturaBarkodIcinKullanilacakOnEk_Getir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            SqlCommand cmd = new SqlCommand("select onek from barkodayar with(nolock) where BarkodunKullanildigiYer = 2", Baglanti, Tr);
            return cmd.ExecuteScalar().ToString();
        }
    }
}
