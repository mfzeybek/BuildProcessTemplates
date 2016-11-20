using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
	public class csStokAraGrup : IDisposable
	{
		private DataTable dt;
		private SqlDataAdapter da;

		#region Değişkenler
		private int _StokAraGrupID;
		private int _StokGrupID;
		private string _StokGrupAdi;
		private string _StokAraGrupAdi;
		private int _KaydedenID;
		private DateTime _KayitTarihi;
		private int _DegistirenID;
		private DateTime _DegismeTarihi;
		#endregion

		#region Methodlar
		public int StokAraGrupID
		{
			get { return _StokAraGrupID; }
			set { _StokAraGrupID = value; }
		}
		public int StokGrupID
		{
			get { return _StokGrupID; }
			set { _StokGrupID = value; }
		}
		public string StokGrupAdi
		{
			get { return _StokGrupAdi; }
			set { _StokGrupAdi = value; }
		}
		public string StokAraGrupAdi
		{
			get { return _StokAraGrupAdi; }
			set { _StokAraGrupAdi = value; }
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

		public csStokAraGrup(SqlConnection Baglanti, SqlTransaction trGenel, int stokAraGrupID)
		{
			if (stokAraGrupID == -1)
			{
				_StokAraGrupID = -1;
				_StokGrupID = -1;
				_StokGrupAdi = "";
				_StokAraGrupAdi = "";
				_KaydedenID = -1;
				_KayitTarihi = DateTime.Now;
				_DegistirenID = -1;
				_DegismeTarihi = DateTime.MinValue;
			}
			else
			{
				StokAraGrupGetir(Baglanti, trGenel, stokAraGrupID);
			}
		}
		private void StokAraGrupGetir(SqlConnection Baglanti, SqlTransaction trGenel, int stokAraGrupID)
		{
			using (cmdGenel = new SqlCommand())
			{
				cmdGenel.Connection = Baglanti;
				cmdGenel.Transaction = trGenel;
				cmdGenel.CommandText = @"SELECT StokAraGrupID,StokGrupID, StokAraGrupAdi,KaydedenID, KayitTarihi FROM dbo.StokAraGrup WHERE (StokAraGrupID = @StokAraGrupID)";
				cmdGenel.Parameters.Add("@StokAraGrupID", SqlDbType.Int).Value = stokAraGrupID;
				using (drGenel = cmdGenel.ExecuteReader())
				{
					if (drGenel.Read())
					{
						_StokAraGrupID = Convert.ToInt32(drGenel["StokAraGrupID"].ToString());
						_StokGrupID = Convert.ToInt32(drGenel["StokGrupID"].ToString());
						_StokAraGrupAdi = drGenel["StokAraGrupAdi"].ToString();
						_KaydedenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["KaydedenID"]));
            //_KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
            //_DegistirenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["DegistirenID"]));
            //_DegismeTarihi = TarihBossaMinTarihVer(drGenel["DegismeTarihi"]);
					}
				}
			}
		}
		public void StokAraGrupKaydetHemenAl(SqlConnection Baglanti, SqlTransaction trGenel)
		{
			if (_StokGrupID == -1)
			{
				bool KayitVar = false;
				cmdGenel = new SqlCommand(@" SELECT StokAraGrupID From StokAraGrup Where StokAraGrupAdi=@StokAraGrupAdi", Baglanti, trGenel);
				cmdGenel.Parameters.Add("@StokAraGrupAdi", SqlDbType.NVarChar).Value = _StokAraGrupAdi;

				using (SqlDataReader dr = cmdGenel.ExecuteReader(CommandBehavior.SingleResult))
				{
					if (dr.Read())
						KayitVar = true;
				}
				if (KayitVar)
					return;
				cmdGenel.Dispose();
				cmdGenel = new SqlCommand(@"insert into StokAraGrup(StokGrupID,StokAraGrupAdi,KaydedenID,KayitTarihi)
Values((Select StokGrupID From StokGrup Where StokGrupAdi='" + _StokGrupAdi + @"'),@StokAraGrupAdi,@KaydedenID,@KayitTarihi) 
				set @YeniID = SCOPE_IDENTITY()", Baglanti, trGenel);
				//cmdGenel.Parameters.Add("@StokGrupAdi", SqlDbType.NVarChar).Value = _StokGrupAdi;
				cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
				cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
				cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
			}
			else
			{
				cmdGenel = new SqlCommand(@"update StokAraGrup set StokGrupID=@StokGrupID, StokAraGrupAdi=@StokAraGrupAdi,DegistirenID=@DegistirenID, DegismeTarihi=@DegismeTarihi
where StokAraGrupID = @StokAraGrupID", Baglanti, trGenel);

				cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
				cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
				cmdGenel.Parameters.Add("@StokAraGrupID", SqlDbType.Int).Value = _StokAraGrupID;
			}

			cmdGenel.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = _StokAraGrupID;
			cmdGenel.Parameters.Add("@StokAraGrupAdi", SqlDbType.NVarChar).Value = _StokAraGrupAdi;
			try
			{
				cmdGenel.ExecuteNonQuery();
				if (_StokAraGrupID == -1)
					_StokAraGrupID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
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
		public void StokAraGrupGuncelle(SqlConnection Baglanti, int StokGrupID)
		{
			da.UpdateCommand = new SqlCommand("Update StokAraGrup set StokAraGrupAdi = @StokAraGrupAdi, StokGrupID =@StokGrupID  where StokAraGrupID = @StokAraGrupID", Baglanti);
			da.UpdateCommand.Parameters.Add("@StokAraGrupAdi", SqlDbType.NVarChar, 50, "StokAraGrupAdi");
			da.UpdateCommand.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = StokGrupID;
			da.UpdateCommand.Parameters.Add("@StokAraGrupID", SqlDbType.Int, 10, "StokAraGrupID");

			da.InsertCommand = new SqlCommand("insert into StokAraGrup (StokAraGrupAdi, StokAraGrupAdi) values (@StokGrupAdi, @StokGrupID)", Baglanti);
			da.InsertCommand.Parameters.Add("@StokGrupAdi", SqlDbType.NVarChar, 10, "StokGrupAdi");
			da.InsertCommand.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = StokGrupID;

			da.DeleteCommand = new SqlCommand("delete StokAraGrup where StokAraGrupID = @StokAraGrupID", Baglanti);
			da.DeleteCommand.Parameters.Add("@StokAraGrupID", SqlDbType.Int, 10, "StokAraGrupID");

			da.Update(dt);
		}
		public DataTable StokAraGrupDoldur(SqlConnection Baglanti, SqlTransaction tr, int StokGrupID)
		{
			using (da = new SqlDataAdapter())
			{
				da.SelectCommand = new SqlCommand("SELECT StokAraGrupID, StokAraGrupAdi, StokGrupID from StokAraGrup where StokGrupID = @StokGrupID", Baglanti);
				da.SelectCommand.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = StokGrupID;
				da.SelectCommand.Transaction = tr;
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
