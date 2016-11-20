using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.Terazi
{
    public class csTeraziArama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;

        public void TeraziGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (da = new SqlDataAdapter("select * from Teraziler", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;

                using (dt = new DataTable())
                {
                    da.Fill(dt);
                }
            }
        }
    }
}
