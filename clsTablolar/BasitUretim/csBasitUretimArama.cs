using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.BasitUretim
{
    public class csBasitUretimArama : IDisposable
    { // aahdan git hub düzgün çalışıyor
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;

        public void Getir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da = new SqlDataAdapter(@"select BasitUretim.*, Stok.StokAdi, Stok.StokKodu from BasitUretim
left join Stok on Stok.StokID = BasitUretim.UretilenStokID", Baglanti);
            da.SelectCommand.Transaction = Tr;
            using (dt = new DataTable())
            {
                da.Fill(dt);
            }
        }
    }
}
