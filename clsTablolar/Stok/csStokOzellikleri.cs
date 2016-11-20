using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
  public class csStokOzellikleri : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    SqlDataAdapter da;
    public DataTable dt;

    public csStokOzellikleri(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      using (da = new SqlDataAdapter("select * from StokOzellikleri where StokID = @StokID", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        dt = new DataTable();
        da.Fill(dt);
      }
    }

    public DataTable dt_OzellikTanimlari;
    public DataTable OzellikTanimlariniGetir(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (da = new SqlDataAdapter("select * from StokOzellikTanimlari", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        
         dt_OzellikTanimlari = new DataTable();
        da.Fill(dt_OzellikTanimlari);
        return dt_OzellikTanimlari;
      }
    }

    SqlCommand cmd;

    public void Guncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {

      foreach (DataRow Row in dt.Rows)
      {
        if (Row.RowState == DataRowState.Modified)
        {
          using (cmd = new SqlCommand("update StokOzellikleri set  StokOzellikTanimID = @StokOzellikTanimID, StokID = @StokID, Deger = @Deger where StokOzellikID = @StokOzellikID", Baglanti, Tr))
          {

            cmd.Parameters.Add("@StokOzellikTanimID", SqlDbType.Int).Value = Row["StokOzellikTanimID"];
            cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            cmd.Parameters.Add("@Deger", SqlDbType.NVarChar).Value = Row["Deger"];
            cmd.Parameters.Add("@StokOzellikID", SqlDbType.Int).Value = Row["StokOzellikID"];
            cmd.ExecuteNonQuery();
          }
        }
        else if (Row.RowState == DataRowState.Added)
        {
          using (cmd = new SqlCommand(@"insert into StokOzellikleri 
                                      ( StokOzellikTanimID, StokID, Deger ) values ( @StokOzellikTanimID, @StokID, @Deger ) set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr))
          {
            cmd.Parameters.Add("@StokOzellikTanimID", SqlDbType.Int).Value = Row["StokOzellikTanimID"];
            cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            cmd.Parameters.Add("@Deger", SqlDbType.NVarChar).Value = Row["Deger"];
            cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            Row["StokOzellikID"] = cmd.Parameters["@YeniID"].Value;
          }
        }
        else if (Row.RowState == DataRowState.Deleted)
        {
          using (cmd = new SqlCommand("delete from StokOzellikleri where StokOzellikID = @StokOzellikID", Baglanti, Tr))
          {
            cmd.Parameters.Add("@StokOzellikID", SqlDbType.Int, 0, "StokOzellikID");

            cmd.ExecuteNonQuery();
          }
        }
      }

    }


  }
}
