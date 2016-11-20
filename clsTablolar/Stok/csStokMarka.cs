using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
	public class csStokMarka : IDisposable
	{
		private DataTable dt;
		private SqlDataAdapter da;

		#region Değişkenler
		private int _StokMarkaID;
		private string _StokMarka;
		private int _KaydedenID;
		private DateTime _KayitTarihi;
		private int _DegistirenID;
		private DateTime _DegismeTarihi;
		#endregion

		#region Methodlar
		public int StokMarkaID
		{
			get { return _StokMarkaID; }
			set { _StokMarkaID = value; }
		}
		public string StokMarka
		{
			get { return _StokMarka; }
			set { _StokMarka = value; }
		}
		public int KaydedenID
		{
			get { return _KaydedenID; }
			set { _KaydedenID = value; }
		}
		public DateTime KayitTarihi
		{
			get { return _KayitTarihi; }
			set { _KayitTarihi = value; }
		}
		public int DegistirenID
		{
			get { return _DegistirenID; }
			set { _DegistirenID = value; }
		}
		public DateTime DegismeTarihi
		{
			get { return _DegismeTarihi; }
			set { _DegismeTarihi = value; }
		}
		#endregion

		#region Genel DeğişkEnler
		SqlCommand cmdGenel;
		SqlDataReader drGenel;
		#endregion

		public csStokMarka(SqlConnection Baglanti, SqlTransaction trGenel, int StokMarkaID)
		{
			if (StokMarkaID == -1)
			{
				_StokMarkaID = -1;
				_StokMarka = "";
				_KaydedenID = -1;
				_KayitTarihi = DateTime.Now;
				_DegistirenID = -1;
				_DegismeTarihi = DateTime.MinValue;
			}
			else
			{
				StokMarkaGetir(Baglanti, trGenel, StokMarkaID);
			}
		}
		private void StokMarkaGetir(SqlConnection Baglanti, SqlTransaction trGenel, int stokMarkaID)
		{
			using (cmdGenel = new SqlCommand())
			{
				cmdGenel.Connection = Baglanti;
				cmdGenel.Transaction = trGenel;
				cmdGenel.CommandText = @"SELECT StokMarkaID, StokMarka,KaydedenID, KayitTarihi, DegistirenID, DegismeTarihi FROM dbo.StokMarka WHERE (StokMarkaID = @StokMarkaID)";
				cmdGenel.Parameters.Add("@StokMarkaID", SqlDbType.Int).Value = StokMarkaID;
				using (drGenel = cmdGenel.ExecuteReader())
				{
					if (drGenel.Read())
					{
						_StokMarkaID = Convert.ToInt32(drGenel["StokMarkaID"].ToString());
						_StokMarka = drGenel["StokMarka"].ToString();
						_KaydedenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["KaydedenID"]));
						_KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
						_DegistirenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["DegistirenID"]));
						_DegismeTarihi = TarihBossaMinTarihVer(drGenel["DegismeTarihi"]);
					}
				}
			}
		}
		public void StokMarkaKAydet(SqlConnection Baglanti, SqlTransaction trGenel)
		{
			if (_StokMarkaID == -1)
			{
				bool KayitVar = false;
				cmdGenel = new SqlCommand(@" SELECT StokMarkaID From StokMarka Where StokMarka=@StokMarka", Baglanti, trGenel);
				cmdGenel.Parameters.Add("@StokMarka", SqlDbType.NVarChar).Value = _StokMarka;

				using (SqlDataReader dr = cmdGenel.ExecuteReader(CommandBehavior.SingleResult))
				{
					if (dr.Read())
						KayitVar = true;
				}
				if (KayitVar)
					return;
				cmdGenel.Dispose();
				cmdGenel = new SqlCommand(@"
insert into StokMarka(StokMarka,KaydedenID,KayitTarihi)
Values(@StokMarka,@KaydedenID,@KayitTarihi) set @YeniID = SCOPE_IDENTITY() ", Baglanti, trGenel);
				cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
				cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
				cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
			}
			else
			{
				cmdGenel = new SqlCommand(@"update StokMarka set StokMarka=@StokMarka,DegistirenID=@DegistirenID, DegismeTarihi=@DegismeTarihi
where StokMarkaID = @StokMarkaID", Baglanti, trGenel);

				cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
				cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
				cmdGenel.Parameters.Add("@StokMarkaID", SqlDbType.Int).Value = _StokMarkaID;
			}

			cmdGenel.Parameters.Add("@StokMarka", SqlDbType.NVarChar).Value = _StokMarka;
			try
			{
				cmdGenel.ExecuteNonQuery();
				if (_StokMarkaID == -1)
					_StokMarkaID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
			}
			catch (Exception hata)
			{
				throw new Exception(hata.Message);
			}
		}
		private DateTime TarihBossaMinTarihVer(Object Tarih)
		{
			DateTime Tarihh;
			if (DateTime.TryParse(Tarih.ToString(), out Tarihh) == false)
				Tarihh = DateTime.MinValue;

			return Tarihh;
		}
		private string IDBossaEksiBirVer(object ID)
		{
			string ID2 = "";
			if (ID == null || ID.ToString() == "" || ID == DBNull.Value)
			{
				ID2 = "-1";
			}
			else
			{
				ID2 = ID.ToString();
			}
			return ID2;
		}
		public void StokMarkaGuncelle(SqlConnection Baglanti)
		{
			da.UpdateCommand = new SqlCommand("Update StokMarka set StokMarka = @StokMarka where StokMarkaID = @StokMarkaID", Baglanti);
			da.UpdateCommand.Parameters.Add("@StokMarkaID", SqlDbType.Int, 10, "StokMarkaID");
			da.UpdateCommand.Parameters.Add("@StokMarka", SqlDbType.NVarChar, 10, "BirimAdi");

			da.InsertCommand = new SqlCommand("insert into StokMarka (StokMarka) values (@StokMarka)", Baglanti);
			da.InsertCommand.Parameters.Add("@StokMarka", SqlDbType.NVarChar, 10, "StokMarka");

			da.DeleteCommand = new SqlCommand("delete StokMarka where StokMarkaID = @StokMarkaID", Baglanti);
			da.DeleteCommand.Parameters.Add("@StokMarkaID", SqlDbType.Int, 10, "StokMarkaID");

			da.Update(dt);
		}
		public DataTable StokMarkaDoldur(SqlConnection Baglanti, SqlTransaction trGenel)
		{	
			using (da = new SqlDataAdapter())
			{
				da.SelectCommand = new SqlCommand("SELECT StokMarkaID, StokMarka from StokMarka", Baglanti);
				da.SelectCommand.Transaction = trGenel;				
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
