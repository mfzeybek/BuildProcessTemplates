using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Fatura
{
  public class csFaturaHareketIDdenFaturaIDVer : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }


      // lan bu hiç bir yerde lazım değil ki
    public int FaturaHareketIDdenFaturaIDVer(int FaturaHareketID, SqlConnection Baglanti, SqlTransaction Trgenel)
    {
      SqlCommand cmd = new SqlCommand(@"select FaturaHareket.FaturaID from FaturaHareket where FaturaHareket.FaturaHareketID = @FaturaHareketID", Baglanti, Trgenel);
      cmd.Parameters.Add("@FaturaHareketID", SqlDbType.Int).Value = FaturaHareketID;

      return (int)cmd.ExecuteScalar();
    }
  }
}
