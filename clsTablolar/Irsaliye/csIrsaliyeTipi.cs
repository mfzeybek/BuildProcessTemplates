using System;
using System.Data;

namespace clsTablolar.Irsaliye
{
	public class csIrsaliyeTipi : IDisposable
	{
		public DataTable IrsaliyeTipleri()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("TipiID");
			dt.Columns[0].AutoIncrement = true;
			dt.Columns.Add("Adi");
			dt.Rows.Add(dt.NewRow());
			dt.Rows.Add(dt.NewRow());
			dt.Rows.Add(dt.NewRow());
			dt.Rows.Add(dt.NewRow());

			dt.Rows[0]["TipiID"] = "6";
			dt.Rows[0]["Adi"] = "SATIŞ İRSALİYESİ";

			dt.Rows[1]["TipiID"] = "7";
			dt.Rows[1]["Adi"] = "ALIŞ İRSALİYESİ";

			dt.Rows[2]["TipiID"] = "8";
			dt.Rows[2]["Adi"] = "SATIŞTAN İADE";

			dt.Rows[3]["TipiID"] = "9";
			dt.Rows[3]["Adi"] = "ALIŞTAN İADE";
			return dt;
		}
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
