using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Uretim
{
	/// <summary>
	/// 1. ReceteMaster tablosunu datatble olarak geri döner. 
	/// 2. İstenilen Recete bilgisini, ReceteMaster ve ReceteDetail tablolarından siler.
	/// </summary>
	public class csRecete : IDisposable
	{
		public DataTable dt;
		private SqlDataAdapter da;

		/// <summary>
		/// ReceteMaster bilgilerini global tanımlanan "dt" ye atar.
		/// </summary>
		/// <param name="Baglanti"></param>
		public csRecete(SqlConnection Baglanti)
		{
			using (da = new SqlDataAdapter("SELECT ReceteMasterID, ReceteKod, Aciklama, OzelKod1, OzelKod2 FROM dbo.ReceteMaster ORDER BY ReceteMasterID DESC ", Baglanti))
				using (dt = new DataTable())
					da.Fill(dt);
		}
		/// <summary>
		/// Silinmek istenilen Reçete bilgilerini ReceteMaster ve ReceteDetail tablolarından siler.
		/// Eğer ReceteMaster, UretimEmri tablosunda kullanılıyorsa, silme yapılmazç
		/// </summary>
		/// <param name="Baglanti"></param>
		/// <param name="trGenel"></param>
		/// <param name="ReceteMasterID">Silinmek istenen ReceteMasterID</param>
		/// <returns></returns>
		public static string ReceteSil(SqlConnection Baglanti, SqlTransaction trGenel, string ReceteMasterID)
		{
			string cevap = "";
			try
			{
				#region Reçete Üretim Emrinde Kullanılmış mı?
				using (SqlCommand cmd = new SqlCommand("Select UretimEmriID From UretimEmri Where ReceteMasterID=@ReceteMasterID", Baglanti, trGenel))
				{
					cmd.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = ReceteMasterID;
					using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
						if (dr.Read())
							cevap = "Reçete Kullanılıyor.";
				}
				if (cevap != "")
					return cevap;
				#endregion

				using (SqlCommand cmd = new SqlCommand(@"Delete From ReceteMaster Where ReceteMasterID=@ReceteMasterID; 
Delete From ReceteDetail Where ReceteMasterID=@ReceteMasterID; ", Baglanti, trGenel))
				{
					cmd.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = ReceteMasterID;
					cmd.ExecuteNonQuery();
				}
				return "ok";
			}
			catch (Exception hata)
			{
				throw new Exception(hata.Message);
			}
		}
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
