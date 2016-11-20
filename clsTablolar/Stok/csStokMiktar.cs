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


        public decimal StokMiktariGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (cmdGenel = new SqlCommand(@"declare @ArtiMiktar decimal(18,8), @EksiMiktar decimal(18,8)

set @ArtiMiktar = (select sum (StokHr.Miktar) from StokHr where StokHr.GirisMiCikisMi = 1 and StokHr.SilindiMi = 0 and StokHr.StokID = @StokID)
set @EksiMiktar = (select sum (StokHr.Miktar) from StokHr where StokHr.GirisMiCikisMi = 2 and StokHr.SilindiMi = 0 and StokHr.StokID = @StokID)

select isnull(@ArtiMiktar, 0) - isnull(@EksiMiktar ,0) as Miktar", Baglanti, Tr))
            {
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
