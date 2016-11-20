using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Uretim
{
	/// <summary>
	/// DataAdapter ile, ReceteDetail tablosuna insert,update,delete işlemlerini uygular.
	/// </summary>
	public class csReceteDetail : IDisposable
	{
		#region Genel Tanımlar
		SqlCommand cmdGenel;
		SqlDataReader drGenel;
		#endregion

		private SqlDataAdapter da;
		public DataTable dt;

		public void ReceteDetailUpdate(SqlConnection Baglanti)
		{
			da.InsertCommand = new SqlCommand(@"Insert Into ReceteDetail(ReceteMasterID, SatirTur, StokID, Miktar, UretimMiktar, Seviye, SatirAciklama, KaydedenID, KayitTarihi)
																					Values(@ReceteMasterID, @SatirTur, @StokID, @Miktar, @UretimMiktar, @Seviye, @SatirAciklama, @KaydedenID, @KayitTarihi)", Baglanti);
			da.InsertCommand.Parameters.Add("@ReceteMasterID", SqlDbType.Int, 0, "ReceteMasterID");
			da.InsertCommand.Parameters.Add("@SatirTur", SqlDbType.Int, 0, "SatirTur");
			da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
			da.InsertCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
			da.InsertCommand.Parameters.Add("@UretimMiktar", SqlDbType.Decimal, 0, "UretimMiktar");
			da.InsertCommand.Parameters.Add("@Seviye", SqlDbType.Int, 0, "Seviye");
			da.InsertCommand.Parameters.Add("@SatirAciklama", SqlDbType.NVarChar, 0, "SatirAciklama");
			da.InsertCommand.Parameters.Add("@KaydedenID", SqlDbType.Int, 0, "KaydedenID");
			da.InsertCommand.Parameters.Add("@KayitTarihi", SqlDbType.DateTime, 0, "KayitTarihi");

			da.UpdateCommand = new SqlCommand(@"Update ReceteDetail SET
ReceteMasterID=@ReceteMasterID, SatirTur=@SatirTur,StokID=@StokID, Miktar=@Miktar,UretimMiktar=@UretimMiktar, Seviye=@Seviye, 
SatirAciklama=@SatirAciklama, GuncelleyenID=@GuncelleyenID, GuncellemeTarihi=@GuncellemeTarihi Where ReceteDetailID=@ReceteDetailID", Baglanti);
			da.UpdateCommand.Parameters.Add("@ReceteMasterID", SqlDbType.Int, 0, "ReceteMasterID");
			da.UpdateCommand.Parameters.Add("@SatirTur", SqlDbType.Int, 0, "SatirTur");
			da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
			da.UpdateCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
			da.UpdateCommand.Parameters.Add("@UretimMiktar", SqlDbType.Decimal, 0, "UretimMiktar");
			da.UpdateCommand.Parameters.Add("@Seviye", SqlDbType.Int, 0, "Seviye");
			da.UpdateCommand.Parameters.Add("@SatirAciklama", SqlDbType.NVarChar, 0, "SatirAciklama");
			da.UpdateCommand.Parameters.Add("@GuncelleyenID", SqlDbType.Int, 0, "GuncelleyenID");
			da.UpdateCommand.Parameters.Add("@GuncellemeTarihi", SqlDbType.DateTime, 0, "GuncellemeTarihi");
			da.UpdateCommand.Parameters.Add("@ReceteDetailID", SqlDbType.Int, 0, "ReceteDetailID");

			da.DeleteCommand = new SqlCommand("Delete From ReceteDetail Where ReceteDetailID=@ReceteDetailID ", Baglanti);
			da.DeleteCommand.Parameters.Add("@ReceteDetailID", SqlDbType.Int, 0, "ReceteDetailID");

			dt.EndInit();
			da.Update(dt);
		}
		/// <summary>
		/// ReceteMasterID ya bağlı olan ReceteDetail deki kayıtları datatble a toplar.
		/// </summary>
		/// <param name="baglanti"></param>
		/// <param name="trGenel"></param>
		/// <param name="receteMasterID">Detayıan ulaşmak istediğiniz, ReceteMasterID</param>
		/// <returns></returns>
		public DataTable ReceteDetailDoldur(SqlConnection baglanti, SqlTransaction trGenel, string receteMasterID)
		{
			da = new SqlDataAdapter();
			da.SelectCommand = new SqlCommand(@"
SELECT RD.ReceteDetailID, RD.ReceteMasterID, RD.SatirTur, 
CASE RD.SatirTur WHEN 1 THEN 'Çıktı' WHEN 2 THEN 'Hammadde' END AS SatirTuru, RD.StokID, RD.Miktar, RD.UretimMiktar, RD.Seviye, 
RD.SatirAciklama, RD.KaydedenID, RD.KayitTarihi, RD.GuncelleyenID, RD.GuncellemeTarihi, dbo.Stok.StokKodu, dbo.Stok.StokAdi
FROM dbo.ReceteDetail AS RD LEFT OUTER JOIN dbo.Stok ON RD.StokID = dbo.Stok.StokID WHERE (RD.ReceteMasterID = @ReceteMasterID)
ORDER BY RD.SatirTur", baglanti, trGenel);
			da.SelectCommand.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = receteMasterID;

			dt = new DataTable();
			da.Fill(dt);
			return dt;
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
