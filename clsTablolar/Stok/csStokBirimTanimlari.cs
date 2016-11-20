using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
	public class csStokBirimTanimlari : IDisposable
	{
		public DataTable dt;
		private SqlDataAdapter da;

		public void BirimGuncelle(SqlConnection Baglanti, SqlTransaction Tr)
		{
			da.UpdateCommand = new SqlCommand("Update StokBirim set BirimAdi = @BirimAdi where BirimID = @BirimID", Baglanti, Tr);
			da.UpdateCommand.Parameters.Add("@BirimID", SqlDbType.Int, 10, "BirimID");
			da.UpdateCommand.Parameters.Add("@BirimAdi", SqlDbType.NVarChar, 10, "BirimAdi");

			da.InsertCommand = new SqlCommand("insert into StokBirim (BirimAdi) values (@BirimAdi)", Baglanti, Tr);
			da.InsertCommand.Parameters.Add("@BirimAdi", SqlDbType.NVarChar, 10, "BirimAdi");

			da.DeleteCommand = new SqlCommand("delete StokBirim where BirimID = @BirimID", Baglanti, Tr);
			da.DeleteCommand.Parameters.Add("@BirimID", SqlDbType.Int, 10, "BirimID");

			da.Update(dt);
		}

		public DataTable BirimDoldur(SqlConnection Baglanti, SqlTransaction Tr)
		{
			using (da = new SqlDataAdapter())
			{
				da.SelectCommand = new SqlCommand("SELECT BirimID, BirimAdi from StokBirim", Baglanti, Tr);
				using (dt = new DataTable())
				{
					da.Fill(dt);
					return dt;
				}
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
