using System;
using System.Data.SqlClient;

namespace TeraziSatis.cls
{
    public class csBarkodNumarasiVer:IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        SqlCommand cmd;

        public csBarkodNumarasiVer(int ID, SqlTransaction TR, SqlConnection Baglanti)
        {
            cmd = new SqlCommand("update fatura set ")

        }
    }
}
