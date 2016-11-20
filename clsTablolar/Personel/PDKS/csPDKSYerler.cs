using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel.PDKS
{
    public class csPDKSYerler : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DataTable dt;
        SqlDataAdapter da;

        public void YerleriGetir(SqlConnection PDKSBaglanti, SqlTransaction Tr)
        {
            using (da = new SqlDataAdapter("select * from Yerler", PDKSBaglanti))
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
