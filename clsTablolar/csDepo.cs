using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
	public class csDepo : IDisposable
	{
		public DataTable dt_Depo;
		private SqlDataAdapter da;

		public void DepoGuncelle(SqlConnection Baglanti)
		{
			da.UpdateCommand = new SqlCommand("Update Depo set DepoAdi = @DepoAdi where DepoID = @DepoID", Baglanti);
			da.UpdateCommand.Parameters.Add("@DepoID", SqlDbType.Int, 10, "DepoID");
			da.UpdateCommand.Parameters.Add("@DepoAdi", SqlDbType.NVarChar, 10, "DepoAdi");

			da.InsertCommand = new SqlCommand("insert into StokBirim (DepoAdi) values (@DepoAdi)", Baglanti);
			da.InsertCommand.Parameters.Add("@DepoAdi", SqlDbType.NVarChar, 10, "DepoAdi");

			da.DeleteCommand = new SqlCommand("delete StokBirim where DepoID = @DepoID", Baglanti);
			da.DeleteCommand.Parameters.Add("@DepoID", SqlDbType.Int, 10, "DepoID");

			da.Update(dt_Depo);
		}

		public csDepo(SqlConnection Baglanti, SqlTransaction Tr, int DepoID) // bunda böyle yapmanın mantığı yok neden boş bir depo tablosu isteyelim ki 
		//sonuçta depoid yi her yerde kullanıcam ve depo olmak zorunda
		{// ha tek bir Id den tek bir depo ismi getirilmek istenebilir ancak o zaman da bunu datatable a atmanın mantığı yok
			//bence csDepo Clası türetilir türetilmez
			if (DepoID == -1)
			{
				//dt_Depo = new DataTable();
				//dt_Depo.Columns.Add("DepoID");
				//dt_Depo.Columns[0].DataType = System.Type.GetType("System.Int32");
				//dt_Depo.Columns[0].AutoIncrement = true;
				//dt_Depo.Columns[0].AutoIncrementSeed = 1;
				//dt_Depo.Columns[0].AutoIncrementStep = 1;
				//dt_Depo.Columns[0].ReadOnly = true;

				dt_Depo.Columns.Add("DepoAdi");
				dt_Depo.Columns["DepoAdi"].DataType = System.Type.GetType("System.String");
			}
			else
			{
				DepoDoldur(Baglanti, Tr);
			}

		}


		/// <summary>
		/// dt_Depo ya bütün depoları doldurur;
		/// </summary>
		/// <param name="Baglanti"></param>
		public csDepo(SqlConnection Baglanti, SqlTransaction Tr)
		{
			DepoDoldur(Baglanti, Tr);
		}
		private void DepoDoldur(SqlConnection Baglanti, SqlTransaction Tr) // 
		{
			using (da = new SqlDataAdapter())
			{
				da.SelectCommand = new SqlCommand("SELECT DepoID, DepoAdi from Depo", Baglanti, Tr);
				using (dt_Depo = new DataTable())
				{
					da.Fill(dt_Depo);
				}
			}
		}
		public void Dispose()
		{
            GC.SuppressFinalize(this);
		}
	}
}
