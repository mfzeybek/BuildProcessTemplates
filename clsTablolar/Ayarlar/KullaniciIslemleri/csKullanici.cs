using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
	public class csKullanici : IDisposable
	{
		#region Alanlar
        private static int _KullaniciID;
        private static string _KullaniciAdi;
        private static string _KullaniciSifre;
        private static int _AyarlarVOIPID;
        private static bool _AramaYapabilsin;
        private static int _KaydedenID;
        private static DateTime _KayitTarihi;
        private static int _GuncelleyenID;
        private static DateTime _GuncellemeTarihi;
		#endregion

		#region  Property ler
		public static int KullaniciID
		{
			get { return _KullaniciID; }
			set { _KullaniciID = value; }
		}
		public static string KullaniciAdi
		{
			get { return _KullaniciAdi; }
			set { _KullaniciAdi = value; }
		}
		public string KullaniciSifre
		{
			get { return _KullaniciSifre; }
			set { _KullaniciSifre = value; }
		}
		public int AyarlarVOIPID
		{
			get { return _AyarlarVOIPID; }
			set { _AyarlarVOIPID = value; }
		}
		public bool AramaYapabilsin
		{
			get { return _AramaYapabilsin; }
			set { _AramaYapabilsin = value; }
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
		public int GuncelleyenID
		{
			get { return _GuncelleyenID; }
			set { _GuncelleyenID = value; }
		}
		public DateTime GuncellemeTarihi
		{
			get { return _GuncellemeTarihi; }
			set { _GuncellemeTarihi = value; }
		}
		#endregion

		#region Genel Değişkenler
		SqlCommand cmdGenel;
		SqlDataReader drGenel;
		private SqlConnection sqlConnection;
		private SqlTransaction trGenel;
		private int p;
		#endregion

		public csKullanici(SqlConnection Baglanti, SqlTransaction Tr, int KullaniciID)
		{
			if (KullaniciID == -1)
			{
				_KullaniciID = -1;
				_KullaniciAdi = "";
				_KullaniciSifre = "";
				_AyarlarVOIPID = -1;
				_AramaYapabilsin = false;
				_KaydedenID = -1;
				_KayitTarihi = Convert.ToDateTime("01.01.1888");
				_GuncelleyenID = -1;
				_GuncellemeTarihi = Convert.ToDateTime("01.01.1888");
			}
			else
				KullaniciGetir(Baglanti, Tr, KullaniciID);
		}

		private void KullaniciGetir(SqlConnection Baglanti, SqlTransaction Tr, int KullaniciID)
		{
			using (cmdGenel = new SqlCommand("select KullaniciID ,KullaniciAdi ,KullaniciSifre,AyarlarVOIPID,AramaYapabilsin FROM Kullanici where KullaniciID = @KullaniciID ", Baglanti, Tr))
			{
				cmdGenel.Parameters.Add("@KullaniciID", SqlDbType.Int).Value = KullaniciID;
				using (drGenel = cmdGenel.ExecuteReader())
				{
					if (drGenel.Read())
					{
						_KullaniciID = Convert.ToInt32(drGenel["KullaniciID"].ToString());
						_KullaniciAdi = drGenel["KullaniciAdi"].ToString();
						_KullaniciSifre = drGenel["KullaniciSifre"].ToString();
						_AyarlarVOIPID = Convert.ToInt32(drGenel["AyarlarVOIPID"].ToString());
						_AramaYapabilsin = Convert.ToBoolean(drGenel["AramaYapabilsin"].ToString());
					}
				}
			}
		}

		public string KullaniciKontrol(SqlConnection Baglanti, SqlTransaction Tr, string KullaniciAdi, string KullaniciSifre)
		{
			using (cmdGenel = new SqlCommand("select KullaniciID ,KullaniciAdi ,KullaniciSifre,AramaYapabilsin FROM Kullanici where KullaniciAdi = @KullaniciAdi and KullaniciSifre=@KullaniciSifre", Baglanti, Tr))
			{
				cmdGenel.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = KullaniciAdi;
				cmdGenel.Parameters.Add("@KullaniciSifre", SqlDbType.NVarChar).Value = KullaniciSifre;

				using (drGenel = cmdGenel.ExecuteReader())
				{
					if (drGenel.Read())
					{
						_KullaniciID = Convert.ToInt32(drGenel["KullaniciID"].ToString());
						_KullaniciAdi = drGenel["KullaniciAdi"].ToString();
						_KullaniciSifre = drGenel["KullaniciSifre"].ToString();
						_AramaYapabilsin = (bool)drGenel["AramaYapabilsin"]; // bunun kontrolünü buradan yapmayacaksın nereden yapacaksın yetkilerden tabiki hamısına
						return _KullaniciID.ToString();
					}
					else
						return "-1";
				}
			}
		}

		public static DataTable KullaniciListesi(SqlConnection baglanti, SqlTransaction trGenel)
		{
			SqlDataAdapter da = new SqlDataAdapter(@"SELECT  KullaniciID, KullaniciAdi, KullaniciSifre,AyarlarVOIPID,AramaYapabilsin,KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi FROM  dbo.Kullanici ", baglanti);

			da.SelectCommand.Transaction = trGenel;
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}

		public string KullaniciInsert(SqlConnection baglanti, SqlTransaction trGenel)
		{
			try
			{
				cmdGenel = new SqlCommand(@"Insert Into Kullanici (KullaniciAdi, KullaniciSifre, AyarlarVOIPID,AramaYapabilsin,KaydedenID, KayitTarihi)
Values (@KullaniciAdi, @KullaniciSifre, -1,0,@KaydedenID, @KayitTarihi) SET @SonID=SCOPE_IDENTITY() ", baglanti);
				cmdGenel.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = _KullaniciAdi;
				cmdGenel.Parameters.Add("@KullaniciSifre", SqlDbType.NVarChar).Value = _KullaniciSifre;
				cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
				cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = _KayitTarihi;
				cmdGenel.Parameters.Add("@SonID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmdGenel.Transaction = trGenel;
				cmdGenel.ExecuteNonQuery();

				return cmdGenel.Parameters["@SonID"].Value.ToString();
			}
			catch (Exception hata)
			{
				throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
			}
		}

		public void KullaniciUpdate(SqlConnection baglanti, SqlTransaction tr)
		{
			try
			{
				cmdGenel = new SqlCommand(@"Update Kullanici SET 
KullaniciAdi=@KullaniciAdi, KullaniciSifre=@KullaniciSifre, AyarlarVOIPID=@AyarlarVOIPID,AramaYapabilsin=@AramaYapabilsin, GuncelleyenID=@GuncelleyenID, GuncellemeTarihi=@GuncellemeTarihi Where KullaniciID=@KullaniciID ", baglanti);
				cmdGenel.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = _KullaniciAdi;
				cmdGenel.Parameters.Add("@KullaniciSifre", SqlDbType.NVarChar).Value = _KullaniciSifre;
				cmdGenel.Parameters.Add("@AyarlarVOIPID", SqlDbType.Int).Value = _AyarlarVOIPID;
				cmdGenel.Parameters.Add("@AramaYapabilsin", SqlDbType.Bit).Value = _AramaYapabilsin;
				cmdGenel.Parameters.Add("@GuncelleyenID", SqlDbType.Int).Value = _GuncelleyenID;
				cmdGenel.Parameters.Add("@GuncellemeTarihi", SqlDbType.DateTime).Value = _GuncellemeTarihi;

				cmdGenel.Parameters.Add("@KullaniciID", SqlDbType.Int).Value = _KullaniciID;
				cmdGenel.Transaction = tr;
				cmdGenel.ExecuteNonQuery();
			}
			catch (Exception hata)
			{
				throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
			}
		}

		public static void KullaniciDelete(SqlConnection baglanti, SqlTransaction trGenel, int kullaniciID)
		{
			try
			{
				SqlCommand cmdGenel = new SqlCommand("Delete From Kullanici Where KullaniciID=@KullaniciID", baglanti);
				cmdGenel.Transaction = trGenel;
				cmdGenel.Parameters.Add("@KullaniciID", SqlDbType.Int).Value = kullaniciID;
				cmdGenel.ExecuteNonQuery();
			}
			catch (Exception hata)
			{
				throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
