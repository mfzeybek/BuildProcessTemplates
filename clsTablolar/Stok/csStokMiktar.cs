using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public class csStokMiktar : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        SqlCommand cmdGenel;
        public decimal StokMiktari = 0;

        public decimal StokMiktariGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (cmdGenel = new SqlCommand(@"select [dbo].[StokMiktari] (@StokID)", Baglanti, Tr))
            {
                //cmdGenel.CommandType = CommandType.StoredProcedure;
                cmdGenel.Parameters.Add("@StokID", SqlDbType.Decimal).Value = StokID;
                return Convert.ToDecimal(cmdGenel.ExecuteScalar());
            }
        }

        public decimal MinimumMiktarGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (cmdGenel = new SqlCommand(@"select isnull(MinumumMiktar, 0) from stok where StokID = @StokID", Baglanti, Tr))
            {
                cmdGenel.Parameters.Add("@StokID", SqlDbType.Decimal).Value = StokID;
                return Convert.ToDecimal(cmdGenel.ExecuteScalar());
            }
        }

        public decimal OlmasiGerekenMiktariGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (cmdGenel = new SqlCommand(@"select isnull(OlmasiGerekenMiktar,0) from stok where StokID = @StokID", Baglanti, Tr))
            {
                cmdGenel.Parameters.Add("@StokID", SqlDbType.Decimal).Value = StokID;
                return Convert.ToDecimal(cmdGenel.ExecuteScalar());
            }
        }
    }
}
