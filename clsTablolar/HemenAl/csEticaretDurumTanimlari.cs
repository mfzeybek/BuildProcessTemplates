using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.HemenAl
{
    public class csEticaretDurumTanimlari : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        SqlDataAdapter da;
        public DataTable dt;
        public void Getir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (da = new SqlDataAdapter("select ID, EticaretStokDurumTanimID, Aciklama from EticaretStokDurumTanimlari", Baglanti))
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
