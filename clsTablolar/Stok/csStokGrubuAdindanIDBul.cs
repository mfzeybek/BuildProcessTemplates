using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
  public class csStokGrubuAdindanIDBul : IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }
    SqlCommand cmd;

    /// <summary>
    /// GrupAdından bulamazsa -1 döndürür
    /// </summary>
    /// <param name="Baglanti"></param>
    /// <param name="Tr"></param>
    /// <param name="GrupAdi"></param>
    /// <returns></returns>
    public int GrubAdiverIDAl(SqlConnection Baglanti, SqlTransaction Tr, string GrupAdi)
    {
      cmd = new SqlCommand("select StokGrupID from StokGrup where StokGrup.StokGrupAdi = @StokGrupAdi ", Baglanti, Tr);
      cmd.Parameters.Add("@StokGrupAdi", SqlDbType.NVarChar).Value = GrupAdi;


      int ID = -1;
      Int32.TryParse(cmd.ExecuteScalar().ToString(), out ID);
      return ID;
    }
  }
}
