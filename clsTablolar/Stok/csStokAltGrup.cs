using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
 public  class csStokAltGrup:IDisposable
  {
    private DataTable dt;
    private SqlDataAdapter da;

    public void StokAltGrupGuncelle(SqlConnection Baglanti, int StokAraGrupID)
    {
      da.UpdateCommand = new SqlCommand("Update StokAltGrup set StokAltGrupAdi = @StokAltGrupAdi, StokAraGrupID =@StokAraGrupID  where StokAltGrupID = @StokAltGrupID", Baglanti);
      da.UpdateCommand.Parameters.Add("@StokAltGrupAdi", SqlDbType.NVarChar, 50, "StokAltGrupAdi");
      da.UpdateCommand.Parameters.Add("@StokAraGrupID", SqlDbType.Int).Value = StokAraGrupID;
      da.UpdateCommand.Parameters.Add("@StokAltGrupID", SqlDbType.Int, 10, "StokAltGrupID");

      da.InsertCommand = new SqlCommand("insert into StokAltGrup (StokAltGrupAdi, StokAraGrupID) values (@StokAltGrupAdi, @StokAraGrupID)", Baglanti);
      da.InsertCommand.Parameters.Add("@StokAltGrupAdi", SqlDbType.NVarChar, 10, "StokAltGrupAdi");
      da.InsertCommand.Parameters.Add("@StokAraGrupID", SqlDbType.Int).Value = StokAraGrupID;

      da.DeleteCommand = new SqlCommand("delete StokAltGrup where StokAltGrupID = @StokAltGrupID", Baglanti);
      da.DeleteCommand.Parameters.Add("@StokAltGrupID", SqlDbType.Int, 10, "StokAltGrupID");

      da.Update(dt);
    }
    public DataTable StokAltGrupDoldur(SqlConnection Baglanti, SqlTransaction Tr, int StokAraGrupID)
    {
      using (da = new SqlDataAdapter())
      {
        da.SelectCommand = new SqlCommand("SELECT StokAltGrupID, StokAltGrupAdi, StokAraGrupID  from StokAltGrup where StokAraGrupID = @StokAraGrupID", Baglanti, Tr);
        da.SelectCommand.Parameters.Add("@StokAraGrupID", SqlDbType.Int).Value = StokAraGrupID;
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
