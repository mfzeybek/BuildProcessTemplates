using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.Ajanda
{
  public class csNotGuruplari : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    SqlDataAdapter da;

    public DataTable dt_NotGruplari;

    public void GruplariDoldur(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (da = new SqlDataAdapter(@"select * from dbo.NotGuruplari", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        if (dt_NotGruplari == null)
          dt_NotGruplari = new DataTable();
        else
          dt_NotGruplari.Rows.Clear();
        da.Fill(dt_NotGruplari);
      }
    }

    SqlCommand cmd;

    public void GrupGuncelle(SqlConnection Baglanti, SqlTransaction Tr, DataRowView Dr)
    {
      using (cmd)
      {

        if (Dr["NotGurupID"] == null || Dr["NotGurupID"].ToString() == "")
        {

          cmd = new SqlCommand(@"insert into NotGuruplari 
      ( GrupAdi, Aciklama, UstGurupID ) 
      values 
      ( @GrupAdi, @Aciklama, @UstGurupID ) set @YeniID = SCOPE_IDENTITY() ", Baglanti, Tr);

          cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
        }
        else
        {
          cmd = new SqlCommand(@"update NotGuruplari set  
       GrupAdi = @GrupAdi, Aciklama = @Aciklama, UstGurupID = @UstGurupID where NotGurupID = @NotGurupID ", Baglanti, Tr);


          cmd.Parameters.Add("@NotGurupID", SqlDbType.Int).Value = Dr["NotGurupID"];
        }


        cmd.Parameters.Add("@GrupAdi", SqlDbType.NVarChar).Value = Dr["GrupAdi"];
        cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Dr["Aciklama"];
        cmd.Parameters.Add("@UstGurupID", SqlDbType.Int).Value = Dr["UstGurupID"];


        cmd.ExecuteNonQuery();
        if (Dr["NotGurupID"] == null)
        {
          Dr["NotGurupID"] = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);
        }
      }
    }

    public void GrupSil(SqlConnection Baglanti, SqlTransaction Tr, int NotGurupID)
    {
      cmd = new SqlCommand("delete from NotGuruplari where NotGurupID = @NotGurupID ", Baglanti, Tr);
      cmd.Parameters.Add("@NotGurupID", SqlDbType.Int).Value = NotGurupID;
      cmd.ExecuteNonQuery();
    }


  }
}
