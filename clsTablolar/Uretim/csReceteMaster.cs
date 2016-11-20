using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Uretim
{
	public class csReceteMaster : IDisposable
	{
		#region Alanlar
		private int _ReceteMasterID;
		private string _ReceteKod;
		private string _Aciklama;
		private string _OzelKod1;
		private string _OzelKod2;
		private int _KaydedenID;
		private DateTime _KayitTarihi;
		private int _GuncelleyenID;
		private DateTime _GuncellemeTarihi;
		#endregion
		#region  Property ler
		public int ReceteMasterID
		{
			get { return _ReceteMasterID; }
			set { _ReceteMasterID = value; }
		}
		public string ReceteKod
		{
			get { return _ReceteKod; }
			set { _ReceteKod = value; }
		}
		public string Aciklama
		{
			get { return _Aciklama; }
			set { _Aciklama = value; }
		}
		public string OzelKod1
		{
			get { return _OzelKod1; }
			set { _OzelKod1 = value; }
		}
		public string OzelKod2
		{
			get { return _OzelKod2; }
			set { _OzelKod2 = value; }
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
		#endregion

		/// <summary>
		/// ReceteMaster bilgilerini getiren class. 
		/// </summary>
		/// <param name="Baglanti"></param>
		/// <param name="trGenel"></param>
		/// <param name="receteMasterID"> -1 : Yeni Kayıt, -1 den farklı değer : Kayıt güncelleme işlemi yapılacak.-></param>
		public csReceteMaster(SqlConnection Baglanti, SqlTransaction trGenel, int receteMasterID)
    {
			if (receteMasterID == -1)
      {
				_ReceteMasterID = -1;
				_ReceteKod = "";
				_Aciklama = "";
				_OzelKod1 = "";
				_OzelKod2 = "";
        _KaydedenID = -1;
        _KayitTarihi = Convert.ToDateTime("01.01.1888");
        _GuncelleyenID = -1;
        _GuncellemeTarihi = Convert.ToDateTime("01.01.1888");
      }
      else
				ReceteMasterGetir(Baglanti, trGenel, receteMasterID);
    }
		/// <summary>
		/// Parametre olarak gönderilen "ReceteMasterID" ye göresatır bilgileri class değişkenlerine aktarılacak.
		/// </summary>
		/// <param name="Baglanti"></param>
		/// <param name="trGenel"></param>
		/// <param name="receteMasterID"> Çağrılmak istenen satırın Referans Numarası(ReceteMasterID)</param>
		private void ReceteMasterGetir(SqlConnection Baglanti, SqlTransaction trGenel, int receteMasterID)
		{
			using (cmdGenel = new SqlCommand(" Select ReceteMasterID, ReceteKod, Aciklama, OzelKod1, OzelKod2 From ReceteMaster Where ReceteMasterID=@ReceteMasterID ", Baglanti, trGenel))
			{
				cmdGenel.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = receteMasterID;
				using (drGenel = cmdGenel.ExecuteReader())
				{
					if (drGenel.Read())
					{
						_ReceteMasterID = Convert.ToInt32(drGenel["ReceteMasterID"].ToString());
						_ReceteKod = drGenel["ReceteKod"].ToString();
						_Aciklama = drGenel["Aciklama"].ToString();
						_OzelKod1 = drGenel["OzelKod1"].ToString();
						_OzelKod2 = drGenel["OzelKod2"].ToString();
					}
				}
			}
		}
		/// <summary>
		/// class ın doldurulan parametleri il ReceteMaster tablosuna yeni kayıt eklenir.
		/// </summary>
		/// <param name="baglanti"></param>
		/// <param name="trGenel"></param>
		/// <returns>Kaydı gerçekleştirilen bilginin ID sini string olarak geri döner</returns>
		public string ReceteMasterInsert(SqlConnection baglanti, SqlTransaction trGenel)
		{
			try
			{
				cmdGenel = new SqlCommand(@"Insert Into ReceteMaster (ReceteKod,Aciklama,OzelKod1,OzelKod2,KaydedenID,KayitTarihi) 
Values (@ReceteKod,@Aciklama,@OzelKod1,@OzelKod2,@KaydedenID,@KayitTarihi) SET @SonKayitID = SCOPE_IDENTITY()  ", baglanti);
				cmdGenel.Parameters.Add("@ReceteKod", SqlDbType.NVarChar).Value = _ReceteKod;
				cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
				cmdGenel.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
				cmdGenel.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
				cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
				cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
				cmdGenel.Parameters.Add("@SonKayitID", SqlDbType.Int).Direction = ParameterDirection.Output;

				cmdGenel.ExecuteNonQuery();

				return cmdGenel.Parameters["@SonKayitID"].Value.ToString();
			}
			catch (Exception hata)
			{
				throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
			}
		}
		/// <summary>
		/// class ın doldurulan parametreleri ile ReceteMaster tablosundaki kayıt güncelleniyor.
		/// </summary>
		/// <param name="baglanti"></param>
		/// <param name="trGenel"></param>
		public void ReceteMasterUpdate(SqlConnection baglanti, SqlTransaction trGenel)
		{
			try
			{
				cmdGenel = new SqlCommand(@"Update ReceteMaster SET ReceteKod=@ReceteKod,Aciklama=@Aciklama,OzelKod1=@OzelKod1,OzelKod2=@OzelKod2, GuncelleyenID=@GuncelleyenID, GuncellemeTarihi=@GuncellemeTarihi  Where ReceteMasterID=@ReceteMasterID  ", baglanti);
				cmdGenel.Parameters.Add("@ReceteKod", SqlDbType.NVarChar).Value = _ReceteKod;
				cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
				cmdGenel.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
				cmdGenel.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
				cmdGenel.Parameters.Add("@GuncelleyenID", SqlDbType.Int).Value = _KaydedenID;
				cmdGenel.Parameters.Add("@GuncellemeTarihi", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
				cmdGenel.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = _ReceteMasterID;
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
