using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csIlce : IDisposable
  {
    private DataTable dt;
    private SqlDataAdapter da;

    public void IlceGuncelle(SqlConnection Baglanti)
    {
      da.UpdateCommand = new SqlCommand("Update Ilce set IlceAdi = @IlceAdi, SehirID = @SehirID where IlceID = @IlceID", Baglanti);
      da.UpdateCommand.Parameters.Add("@IlceAdi", SqlDbType.Int, 10, "IlceAdi");
      da.UpdateCommand.Parameters.Add("@SehirID", SqlDbType.Int, 10, "SehirID");
      da.UpdateCommand.Parameters.Add("@IlceID", SqlDbType.NVarChar, 50, "IlceID");

      da.InsertCommand = new SqlCommand("insert into Sehir (SehirAdi, UlkeID) values (@SehirAdi, @UlkeID)", Baglanti);
      da.InsertCommand.Parameters.Add("@SehirID", SqlDbType.NVarChar, 10, "SehirID");
      da.InsertCommand.Parameters.Add("@IlceAdi", SqlDbType.NVarChar, 10, "IlceAdi");

      da.DeleteCommand = new SqlCommand("delete Sehir where SehirID = @IlceID", Baglanti);
      da.DeleteCommand.Parameters.Add("@IlceID", SqlDbType.Int, 10, "IlceID");

      da.Update(dt);
    }
    /// <summary>
    /// ilce bilgilerini datatable olarak geri döner.
    /// </summary>
    /// <param name="Baglanti"></param>
    /// <param name="SehirID">ilçelerini istediğimiz şehir ID si. 
    /// -1: Tüm ilçeler demek.</param>
    /// <returns></returns>
    public DataTable IlceDoldur(SqlConnection Baglanti, int SehirID)
    {
      string sql = "SELECT IlceID, IlceAdi from Ilce ";
      string where = "  where SehirID = @SehirID ";
      if (SehirID != -1)
        sql += where;

      using (da = new SqlDataAdapter())
      {
        da.SelectCommand = new SqlCommand(sql, Baglanti);
        if (SehirID != -1)
          da.SelectCommand.Parameters.Add("@SehirID", SqlDbType.Int).Value = SehirID;
        using (dt = new DataTable())
        {
          da.Fill(dt);
          return dt;
        }
      }
    }
    void IDisposable.Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
