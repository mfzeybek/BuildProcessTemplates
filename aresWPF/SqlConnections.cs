using System;
using System.Data.SqlClient;

namespace aresWPF
{
  public class SqlConnections : IDisposable
  {
    private static SqlConnection Baglanti;
    public static string _Server = "", _DB = "", _ConStr = "";

        aresWPF.Properties.Settings set = new Properties.Settings();

    public SqlConnections()
    {
      _ConStr = aresWPF.Properties.Settings.Default.DBConStr; // Programın propertisinden okunanacak connection string değeri
    }
    public static SqlConnection GetBaglanti()
    {
      if (Baglanti == null)
      {
        Baglanti = new SqlConnection(_ConStr);
        if (Baglanti.State == System.Data.ConnectionState.Closed)
          Baglanti.Open();
        _Server = Baglanti.DataSource;
        _DB = Baglanti.Database;
      }
      if (Baglanti.State == System.Data.ConnectionState.Broken)
      {
          Baglanti.Open();
      }
      if (Baglanti.State == System.Data.ConnectionState.Closed)
      {
          Baglanti.Open();
      }
      return Baglanti;
    }

      public static void BaglantiyiKapat()
      {
          Baglanti.Close();
      }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
