using System;
using System.Data.SqlClient;

namespace KasaSatis
{
  public class SqlConnections : IDisposable
  {
    private static SqlConnection Baglanti;
    private static SqlConnection BaglantiIki;
    public static string _Server = "", _DB = "", _ConStr = "";

    KasaSatis.Properties.Settings set = new Properties.Settings();

    public SqlConnections()
    {
        _ConStr = KasaSatis.Properties.Settings.Default.connstr; // Programın propertisinden okunanacak connection string değeri
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

    public static SqlConnection GetBaglantiIki()
    {
        if (BaglantiIki == null)
        {
            BaglantiIki = new SqlConnection(_ConStr);
            if (BaglantiIki.State == System.Data.ConnectionState.Closed)
                BaglantiIki.Open();
            _Server = BaglantiIki.DataSource;
            _DB = BaglantiIki.Database;
        }
        if (BaglantiIki.State == System.Data.ConnectionState.Broken)
        {
            BaglantiIki.Open();
        }
        if (BaglantiIki.State == System.Data.ConnectionState.Closed)
        {
            BaglantiIki.Open();
        }
        return BaglantiIki;
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
