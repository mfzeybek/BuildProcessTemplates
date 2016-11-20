using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csCariOzelBilgileri : IDisposable
  {
    private DataTable dt;
    private SqlDataAdapter da;

    public void CariOzelBilgileriniGuncelle(SqlConnection Baglanti, int CariID)
    {
      da.UpdateCommand = new SqlCommand("update CariOzelBilgisi set Aciklama = @Aciklama, CariOzelBilgiID =@CariOzelBilgiID  ,CariID = @CariID  where CariOzelBilgisiID = @CariOzelBilgisiID", Baglanti);

      da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 50, "Aciklama");
      da.UpdateCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
      da.UpdateCommand.Parameters.Add("@CariOzelBilgiID", SqlDbType.Int, 10, "CariOzelBilgiID"); // CariTanımları tablosunda
      da.UpdateCommand.Parameters.Add("@CariOzelBilgisiID", SqlDbType.Int, 10, "CariOzelBilgisiID");
      
      da.InsertCommand = new SqlCommand("insert into CariOzelBilgisi (Aciklama, CariID) values (@Aciklama, @CariID)", Baglanti);
      da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 50, "Aciklama");
      da.InsertCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
      da.InsertCommand.Parameters.Add("@CariOzelBilgiID", SqlDbType.Int, 10, "CariOzelBilgiID");

      da.DeleteCommand = new SqlCommand("delete CariOzelBilgisi where CariOzelBilgisiID = @CariOzelBilgisiID", Baglanti);
      da.DeleteCommand.Parameters.Add("@CariOzelBilgisiID", SqlDbType.Int, 10, "CariOzelBilgisiID");

      da.Update(dt);
    }
    public DataTable CarininOzelBilgileriniListele(SqlConnection Baglanti, int CariID)
    {
      da = new SqlDataAdapter();
      da.SelectCommand = new SqlCommand("Select CariOzelBilgisiID, CariOzelBilgiID, Aciklama, CariID from CariOzelBilgisi where CariID = @CariID", Baglanti);
      da.SelectCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
      dt = new DataTable();
      da.Fill(dt);
      return dt;
    }
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
