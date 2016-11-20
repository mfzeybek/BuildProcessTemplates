using System;
using System.Data.SqlClient;

namespace PDKS
{
	public class SqlConnections : IDisposable
	{
		private static SqlConnection Baglanti;
		public static string _Server = "", _DB = "", _ConStr = "";

		public SqlConnections()
		{
			_ConStr = Properties.Settings.Default.DBConStr; // Programın propertisinden okunanacak connection string değeri
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
			return Baglanti;
		}
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
