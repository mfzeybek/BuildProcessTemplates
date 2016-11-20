using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csCariOzelBilgi : IDisposable
  {
    private DataTable dt;
    private SqlDataAdapter da;

    public void OzelBilgiGuncelle(SqlConnection Baglanti)
    {
      da.UpdateCommand = new SqlCommand("update CariOzelBilgiTanimlari set OzelBilgiAdi = @OzelBilgiAdi where CariOzelBilgiID = @CariOzelBilgiID", Baglanti);

      da.UpdateCommand.Parameters.Add("@OzelBilgiAdi", SqlDbType.NVarChar, 50, "CariOzelBilgiAdi");
      da.UpdateCommand.Parameters.Add("@OzelBilgiID", SqlDbType.Int, 10, "CariOzelBilgiID");

      da.InsertCommand = new SqlCommand("insert into CariOzelBilgiTanimlari (OzelBilgiAdi) values (@OzelBilgiAdi)", Baglanti);
      da.InsertCommand.Parameters.Add("@OzelBilgiAdi", SqlDbType.NVarChar, 50, "OzelBilgiAdi");

      da.DeleteCommand = new SqlCommand("delete CariOzelBilgiTanimlari where CariOzelBilgiID = @CariOzelBilgiID");
      da.DeleteCommand.Parameters.Add("@CariOzelBilgiID", SqlDbType.Int, 10, "CariOzelBilgiID");

      da.Update(dt);
    }
    public DataTable OzelBilgiGetir(SqlConnection Baglanti)
    {
      da = new SqlDataAdapter();
      da = new SqlDataAdapter("Select CariOzelBilgiID,  OzelBilgiAdi from CariOzelBilgiTanimlari", Baglanti);
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
