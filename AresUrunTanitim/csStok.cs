using System;
using System.Data.SqlClient;
using System.Data;

namespace AresUrunTanitim
{
    public class csStok : IDisposable
    {
        private SqlDataAdapter da;
        public DataTable dtStok;

        private string _Arama;
        public string Arama
        {
            get { return _Arama; }
            set { _Arama = value; }
        }



        public csStok(SqlConnection Baglanti)
        {
            da = new SqlDataAdapter("select * from Stok", Baglanti);
            dtStok = new DataTable();
            da.Fill(dtStok);
        }

        public DataTable StokAra(SqlConnection Baglanti)
        {
            using (da = new SqlDataAdapter("select * from Stok where StokAdi like @StokAdi or Barkod like @Barkod", Baglanti))
            {
                da.SelectCommand.Parameters.Add("@StokAdi", SqlDbType.NVarChar).Value = "%" + _Arama + "%";
                da.SelectCommand.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = "%" + _Arama + "%";
                using (dtStok = new DataTable())
                {
                    da.Fill(dtStok);
                    return dtStok;
                }
            }
        }





        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

