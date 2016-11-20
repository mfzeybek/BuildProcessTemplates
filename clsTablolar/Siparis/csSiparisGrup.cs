using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Siparis
{
  public class csSiparisGrup:IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    SqlDataAdapter da;
    DataTable dt;

    public DataTable SiparisGrupGetir(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (da = new SqlDataAdapter("select SiparisGrupID, SiparisGrupAdi, Aciklama from SiparisGrub", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        dt = new DataTable();
        da.Fill(dt);

        return dt;
      }
    }

  }
}
