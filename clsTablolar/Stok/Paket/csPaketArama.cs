using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok.Paket
{
    public class csPaketArama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        DataTable dt;

        public DataTable Getir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (da = new SqlDataAdapter("select * from Paket", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                using (dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }

    }
}
