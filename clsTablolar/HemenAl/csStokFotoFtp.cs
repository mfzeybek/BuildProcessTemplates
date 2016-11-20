using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.HemenAl
{
  public class csStokFotoFtp : IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    SqlDataAdapter da;
    DataTable dt_Fotolar;

    public void FotolariGetir(SqlConnection BAglanti, SqlTransaction TrGenel)
    {
      da = new SqlDataAdapter("", BAglanti);
      da.SelectCommand.Transaction = TrGenel;
      

    }




  }
}
