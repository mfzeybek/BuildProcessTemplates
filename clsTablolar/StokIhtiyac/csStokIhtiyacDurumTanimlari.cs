using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.StokIhtiyac
{
  public class csStokIhtiyacDurumTanimlari:IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public DataTable dt_IhtiyacTanimlari;
    SqlDataAdapter da;


    public DataTable TanimlariGetir(SqlConnection Baglanti, SqlTransaction TrGenel)
    {
      da = new SqlDataAdapter("select * from StokIhtiyacDurumTanimlari", Baglanti);
      da.SelectCommand.Transaction = TrGenel;

      dt_IhtiyacTanimlari = new DataTable();

      da.Fill(dt_IhtiyacTanimlari);

      return dt_IhtiyacTanimlari;
    }
  } 
}
