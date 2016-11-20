using System;
using System.Data.SqlClient;
using System.Data;

namespace clsTablolar.cari
{
  public class csUlke : IDisposable
  {
    private DataTable dt;
    private SqlDataAdapter da;

    public void UlkeGuncelle(SqlConnection Baglanti)
    {
      da.UpdateCommand = new SqlCommand("Update Ulke set UlkeAdi = @UlkeAdi where UlkeID = @UlkeID ", Baglanti);
      da.UpdateCommand.Parameters.Add("@UlkeID", SqlDbType.Int, 10, "UlkeID");
      da.UpdateCommand.Parameters.Add("@UlkeAdi", SqlDbType.NVarChar, 50, "UlkeAdi");

      da.InsertCommand = new SqlCommand("insert into Ulke (UlkeAdi) values (@UlkeAdi)", Baglanti);
      da.InsertCommand.Parameters.Add("@UlkeAdi", SqlDbType.NVarChar, 10, "UlkeAdi");

      da.DeleteCommand = new SqlCommand("delete Ulke where UlkeID = @UlkeID", Baglanti);
      da.DeleteCommand.Parameters.Add("@UlkeID", SqlDbType.Int, 10, "UlkeID");

      da.Update(dt);
    }
    public DataTable UlkeDoldur(SqlConnection Baglanti)
    {
      using (da = new SqlDataAdapter())
      {
        da.SelectCommand = new SqlCommand("SELECT UlkeID, UlkeAdi from Ulke", Baglanti);
        using (dt = new DataTable())
        {
          da.Fill(dt);
          return dt;
        }
      }
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
