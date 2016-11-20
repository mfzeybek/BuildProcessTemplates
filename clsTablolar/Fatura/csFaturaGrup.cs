using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Fatura
{
 public class csFaturaGrup:IDisposable
  {
   DataTable dt_FaturaGrup;
   SqlDataAdapter da_FaturaGrup;

   public DataTable FaturaGrup(SqlConnection Baglanti, SqlTransaction Tr)
   {
     da_FaturaGrup = new SqlDataAdapter();
     da_FaturaGrup.SelectCommand = new SqlCommand("select FaturaGrupID, FaturaGrupAdi, Aciklama from FaturaGrup", Baglanti, Tr);
     dt_FaturaGrup = new DataTable();
     da_FaturaGrup.Fill(dt_FaturaGrup);
     return dt_FaturaGrup;
   }
   public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
