using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PDKS
{
    public class csYerler : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DataTable Dt;
        SqlDataAdapter da;

        public void YerleriGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (da = new SqlDataAdapter("select * from yerler", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;

                Dt = new DataTable();
                da.Fill(Dt);
            }
        }
    }
}
