using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csSehir : IDisposable
  {
    private DataTable dt;
    private SqlDataAdapter da;

    public void SehirGuncelle(SqlConnection Baglanti)
    {
      da.UpdateCommand = new SqlCommand("Update Sehir set SehirAdi = @SehirAdi, UlkeID = @UlkeID where SehirID = @SehirID", Baglanti);
      da.UpdateCommand.Parameters.Add("@UlkeID", SqlDbType.Int, 10, "UlkeID");
      da.UpdateCommand.Parameters.Add("@SehirID", SqlDbType.Int, 10, "SehirID");
      da.UpdateCommand.Parameters.Add("@SehirAdi", SqlDbType.NVarChar, 50, "SehirAdi");

      da.InsertCommand = new SqlCommand("insert into Sehir (SehirAdi, UlkeID) values (@SehirAdi, @UlkeID)", Baglanti);
      da.InsertCommand.Parameters.Add("@UlkeID", SqlDbType.NVarChar, 10, "UlkeID");
      da.InsertCommand.Parameters.Add("@SehirAdi", SqlDbType.NVarChar, 10, "SehirAdi");

      da.DeleteCommand = new SqlCommand("delete Sehir where SehirID = @SehirID", Baglanti);
      da.DeleteCommand.Parameters.Add("@SehirID", SqlDbType.Int, 10, "SehirID");

      da.Update(dt);
    }
    public DataTable SehirDoldur(SqlConnection Baglanti, int UlkeID)
    {
      string sql = "SELECT SehirID, SehirAdi from Sehir ";
      string where = "  where UlkeID = @UlkeID ";
      if (UlkeID != -1)
        sql += where;

      using (da = new SqlDataAdapter())
      {
        da.SelectCommand = new SqlCommand(sql, Baglanti);
        if (UlkeID != -1)
          da.SelectCommand.Parameters.Add("@UlkeID", SqlDbType.Int).Value = UlkeID;
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
