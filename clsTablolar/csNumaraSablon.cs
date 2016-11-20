using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
  public class csNumaraSablon : IDisposable
  {
    public DataTable dt;
    private SqlDataAdapter da;

    public void NumaraGuncelle(SqlConnection Baglanti)
    {
      try
      {
        da.UpdateCommand = new SqlCommand(@"Update NumaraSablon set ModulID=@ModulID, IlkKarakter=@IlkKarakter, KarakterSayisi=@KarakterSayisi, Numara=@Numara, Varsayilan=@Varsayilan 
where NumaraSablonID=@NumaraSablonID", Baglanti);
        da.UpdateCommand.Parameters.Add("@ModulID", SqlDbType.Int, 0, "ModulID");
        da.UpdateCommand.Parameters.Add("@IlkKarakter", SqlDbType.NVarChar, 10, "IlkKarakter");
        da.UpdateCommand.Parameters.Add("@KarakterSayisi", SqlDbType.Int, 0, "KarakterSayisi");
        da.UpdateCommand.Parameters.Add("@Numara", SqlDbType.NVarChar, 50, "Numara");
        da.UpdateCommand.Parameters.Add("@NumaraSablonID", SqlDbType.Int, 0, "NumaraSablonID");
        da.UpdateCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 0, "Varsayilan");

        da.InsertCommand = new SqlCommand("insert into NumaraSablon (ModulID, IlkKarakter, KarakterSayisi,Numara,Varsayilan) values (@ModulID, @IlkKarakter, @KarakterSayisi,@Numara, @Varsayilan)", Baglanti);
        da.InsertCommand.Parameters.Add("@ModulID", SqlDbType.Int, 0, "ModulID");
        da.InsertCommand.Parameters.Add("@IlkKarakter", SqlDbType.NVarChar, 10, "IlkKarakter");
        da.InsertCommand.Parameters.Add("@KarakterSayisi", SqlDbType.Int, 0, "KarakterSayisi");
        da.InsertCommand.Parameters.Add("@Numara", SqlDbType.NVarChar, 50, "Numara");
        da.InsertCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 0, "Varsayilan");

        da.DeleteCommand = new SqlCommand("delete NumaraSablon where NumaraSablonID = @NumaraSablonID", Baglanti);
        da.DeleteCommand.Parameters.Add("@NumaraSablonID", SqlDbType.Int, 0, "NumaraSablonID");

        da.Update(dt);
      }
      catch (Exception hata)
      {
        throw new Exception(hata.Message);
      }
    }

    public DataTable NumaraDoldur(SqlConnection Baglanti, int ModulID)
    {
      using (da = new SqlDataAdapter())
      {
        da.SelectCommand = new SqlCommand(@"SELECT NumaraSablonID, ModulID, IlkKarakter, KarakterSayisi, Numara, Varsayilan FROM dbo.NumaraSablon AS NS WHERE (ModulID = @ModulID)", Baglanti);

        da.SelectCommand.Parameters.Add("@ModulID", SqlDbType.Int).Value = ModulID;
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
