using System;
using System.Data;

namespace clsTablolar.Siparis
{
	public class csSiparisTipi : IDisposable
	{
		public DataTable SiparisTipleri()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("TipiID");
			dt.Columns[0].AutoIncrement = true;
			dt.Columns.Add("Adi");
			dt.Rows.Add(dt.NewRow());
			dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["TipiID"] = Convert.ToInt32(IslemTipi.AlinanSiparis);
			dt.Rows[0]["Adi"] = "ALINAN SİPARİŞ";

      dt.Rows[1]["TipiID"] = Convert.ToInt32(IslemTipi.VerilenSiparis);
			dt.Rows[1]["Adi"] = "VERİLEN SİPARİŞ";
			return dt;
		}
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
