using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.IsBasvurulari
{
  public class csIsBasvurulariGrup : IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }
    SqlDataAdapter da;
    DataTable dt;
    public DataTable IsBasvurulariGrupGetir(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (da = new SqlDataAdapter("select * from IsBasvurulariGrup", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        dt = new DataTable();
        da.Fill(dt);
        return dt;
      }
    }



  }
}
