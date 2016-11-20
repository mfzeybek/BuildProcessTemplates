using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
  public class csStokFiyatKarsilastirma : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    DataTable dt_Fiyat1 = new DataTable();
    DataTable dt_Fiyat2 = new DataTable();

    SqlDataAdapter da;

    public void fiyat1Doldur(SqlConnection Baglanti, SqlTransaction Tr, int StokID, int FiyatTanimID_1, int FiyatTanimID_2)
    {
      using (da = new SqlDataAdapter(@"select s.StokID, s.StokKodu, s.StokAdi, Fiyat1.Fiyat, Fiyat2.Fiyat from stok as s
left join StokFiyat as Fiyat1 on Fiyat1.StokID = s.StokID
left join StokFiyat as Fiyat2 on Fiyat2.StokID = s.StokID
where s.StokID = @StokID and Fiyat1.FiyatTanimID = @FiyatTanimID_1 and Fiyat2.FiyatTanimID = @FiyatTanimID_2", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;

        da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        da.SelectCommand.Parameters.Add("@FiyatTanimID_1", SqlDbType.Int).Value = FiyatTanimID_1;
        da.SelectCommand.Parameters.Add("@FiyatTanimID_2", SqlDbType.Int).Value = FiyatTanimID_2;




        da.Fill(dt_Fiyat1);
      }

    }


  }
}
