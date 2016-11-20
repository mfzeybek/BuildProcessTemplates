using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
  public class csTelefonTipi : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    #region Genel Tanımlar
    SqlCommand cmdGenel;
    SqlDataReader drGenel;
    #endregion

    private SqlDataAdapter da;
    private DataTable dt;

    /// <summary>
    /// dt deki verileri update eder.
    /// </summary>
    /// <param name="Baglanti"></param>
    /// <param name="CariID"></param>
    public void TelefonTipiUpdate(SqlConnection Baglanti)
    {
      da.UpdateCommand = new SqlCommand("update TelefonTipi set TelefonTipi = @TelefonTipi where TelefonTipiID = @TelefonTipiID", Baglanti);
      da.UpdateCommand.Parameters.Add("@TelefonTipiID", SqlDbType.Int, 10, "TelefonTipiID");
      da.UpdateCommand.Parameters.Add("@TelefonTipi", SqlDbType.NVarChar, 100, "TelefonTipi");

      da.InsertCommand = new SqlCommand("insert into TelefonTipi (TelefonTipi) values (@TelefonTipi)", Baglanti);
      da.InsertCommand.Parameters.Add("@TelefonTipi", SqlDbType.NVarChar, 100, "TelefonTipi");

      da.DeleteCommand = new SqlCommand("delete from Telefon where TelefonTipiID = @TelefonTipiID", Baglanti);
      da.DeleteCommand.Parameters.Add("@TelefonTipiID", SqlDbType.Int, 10, "TelefonTipiID");

      dt.EndInit();
      da.Update(dt);
    }
    public DataTable TelefonTipiDoldur(SqlConnection Baglanti)
    {
      da = new SqlDataAdapter();
      da.SelectCommand = new SqlCommand("select TelefonTipiID, TelefonTipi from TelefonTipi", Baglanti);

      dt = new DataTable();
      da.Fill(dt);
      return dt;
    }
  }
}
