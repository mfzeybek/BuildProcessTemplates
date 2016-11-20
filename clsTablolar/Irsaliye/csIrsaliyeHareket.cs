using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Irsaliye
{
	public class csIrsaliyeHareket : IDisposable
	{
		public DataTable dt_IrsaliyeHareketleri = new DataTable();
		private SqlDataAdapter da_IrsaliyeHareketleri = new SqlDataAdapter();

		public csIrsaliyeHareket(SqlConnection Baglanti, SqlTransaction trGenel, int IrsaliyeID)
		{
			if (IrsaliyeID == -1)
				IrsaliyeHareketleriniGetir(Baglanti, trGenel, IrsaliyeID);
			else
				IrsaliyeHareketleriniGetir(Baglanti, trGenel, IrsaliyeID);
		}
		public void IrsaliyeHareketleriniKaydet(SqlConnection Baglanti, SqlTransaction trGenel, int IrsaliyeID)
		{
			try
			{
				foreach (DataRow row in dt_IrsaliyeHareketleri.AsEnumerable())
					row["IrsaliyeID"] = IrsaliyeID.ToString();

				da_IrsaliyeHareketleri.InsertCommand.Transaction = trGenel;
				da_IrsaliyeHareketleri.UpdateCommand.Transaction = trGenel;
				da_IrsaliyeHareketleri.DeleteCommand.Transaction = trGenel;

				da_IrsaliyeHareketleri.Update(dt_IrsaliyeHareketleri);
			}
			catch (Exception hata)
			{
				throw new Exception(hata.Message);
			}
		}
		private void IrsaliyeHareketleriniGetir(SqlConnection Baglanti, SqlTransaction trGenel, int IrsaliyeID)
		{
			try
			{
				da_IrsaliyeHareketleri.SelectCommand = new SqlCommand(@"SELECT     FH.IrsaliyeHareketID, FH.IrsaliyeID, FH.SatirNo, FH.StokID, FH.Miktar, FH.StokAnaBirimID, FH.AnaBirimFiyat, FH.Birim2ID, FH.KatSayi, FH.Birim2Fiyat, FH.Kdv, 
                      FH.Toplam, FH.KdvToplam, FH.Net, FH.StokIskonto1, FH.StokIskonto2, FH.StokIskonto3, FH.CariIskonto1, FH.CariIskonto2, FH.CariIskonto3, FH.IndirimYuzdesi1, 
                      FH.IndirimYuzdesi, FH.Indirim, FH.SatirIndirimliBirimFiyat, FH.SatirIndirimliKDVTutar, FH.SatirIndirimliToplam, FH.AltIndirimBirimFiyat, FH.AltIndirimKDVTutar, 
                      FH.AltIndirimToplamTutar, FH.SatirToplamIndirim, FH.SatirToplamTutar, FH.SatirAciklama, dbo.Stok.StokAdi, SAB.BirimAdi AS StokAnaBirim,DepoID
FROM         dbo.IrsaliyeHareket AS FH INNER JOIN dbo.Stok ON FH.StokID = dbo.Stok.StokID INNER JOIN dbo.StokBirim AS SAB ON FH.StokAnaBirimID = SAB.BirimID
WHERE     (FH.IrsaliyeID = @IrsaliyeID)", Baglanti, trGenel);

				da_IrsaliyeHareketleri.SelectCommand.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = IrsaliyeID;

				da_IrsaliyeHareketleri.InsertCommand = new SqlCommand(@"
Insert Into IrsaliyeHareket(
 IrsaliyeID, SatirNo, StokID, Miktar, StokAnaBirimID, AnaBirimFiyat, Birim2ID, KatSayi, Birim2Fiyat, Kdv, Toplam, KdvToplam, Net, StokIskonto1, StokIskonto2, 
StokIskonto3, CariIskonto1, CariIskonto2, CariIskonto3, IndirimYuzdesi1, IndirimYuzdesi, Indirim, SatirIndirimliBirimFiyat, SatirIndirimliKDVTutar,SatirIndirimliToplam, 
AltIndirimBirimFiyat, AltIndirimKDVTutar, AltIndirimToplamTutar, SatirToplamIndirim, SatirToplamTutar, SatirAciklama,DepoID)
Values(
@IrsaliyeID, @SatirNo, @StokID, @Miktar, @StokAnaBirimID, @AnaBirimFiyat, @Birim2ID, @KatSayi, @Birim2Fiyat, @Kdv, @Toplam, @KdvToplam, @Net, @StokIskonto1, @StokIskonto2, 
@StokIskonto3, @CariIskonto1, @CariIskonto2, @CariIskonto3, @IndirimYuzdesi1, @IndirimYuzdesi, @Indirim, @SatirIndirimliBirimFiyat, @SatirIndirimliKDVTutar,@SatirIndirimliToplam, 
@AltIndirimBirimFiyat, @AltIndirimKDVTutar, @AltIndirimToplamTutar, @SatirToplamIndirim, @SatirToplamTutar, @SatirAciklama,@DepoID
)", Baglanti, trGenel);
				#region İNSERT PARAMETRELERİ
				//da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = IrsaliyeID;
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@IrsaliyeID", SqlDbType.Int, 0, "IrsaliyeID");//.Value = IrsaliyeID;
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@SatirNo", SqlDbType.Int, 0, "SatirNo");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@StokAnaBirimID", SqlDbType.Int, 0, "StokAnaBirimID");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@AnaBirimFiyat", SqlDbType.Decimal, 0, "AnaBirimFiyat");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@Birim2ID", SqlDbType.Int, 0, "Birim2ID");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@Birim2Fiyat", SqlDbType.Decimal, 0, "Birim2Fiyat");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@Kdv", SqlDbType.Decimal, 0, "Kdv");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@Toplam", SqlDbType.Decimal, 0, "Toplam");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@KdvToplam", SqlDbType.Decimal, 0, "KdvToplam");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@Net", SqlDbType.Decimal, 0, "Net");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@StokIskonto1", SqlDbType.Decimal, 0, "StokIskonto1");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@StokIskonto2", SqlDbType.Decimal, 0, "StokIskonto2");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@StokIskonto3", SqlDbType.Decimal, 0, "StokIskonto3");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@CariIskonto1", SqlDbType.Decimal, 0, "CariIskonto1");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@CariIskonto2", SqlDbType.Decimal, 0, "CariIskonto2");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@CariIskonto3", SqlDbType.Decimal, 0, "CariIskonto3");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@IndirimYuzdesi1", SqlDbType.Decimal, 0, "IndirimYuzdesi1");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@IndirimYuzdesi", SqlDbType.Decimal, 0, "IndirimYuzdesi");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@Indirim", SqlDbType.Decimal, 0, "Indirim");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@SatirIndirimliBirimFiyat", SqlDbType.Decimal, 0, "SatirIndirimliBirimFiyat");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@SatirIndirimliKDVTutar", SqlDbType.Decimal, 0, "SatirIndirimliKDVTutar");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@SatirIndirimliToplam", SqlDbType.Decimal, 0, "SatirIndirimliToplam");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@AltIndirimBirimFiyat", SqlDbType.Decimal, 0, "AltIndirimBirimFiyat");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@AltIndirimKDVTutar", SqlDbType.Decimal, 0, "AltIndirimKDVTutar");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@AltIndirimToplamTutar", SqlDbType.Decimal, 0, "AltIndirimToplamTutar");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@SatirToplamIndirim", SqlDbType.Decimal, 0, "SatirToplamIndirim");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@SatirToplamTutar", SqlDbType.Decimal, 0, "SatirToplamTutar");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@SatirAciklama", SqlDbType.NVarChar, 250, "SatirAciklama");
				da_IrsaliyeHareketleri.InsertCommand.Parameters.Add("@DepoID", SqlDbType.Int, 0, "DepoID");

				#endregion

				da_IrsaliyeHareketleri.UpdateCommand = new SqlCommand(@"update IrsaliyeHareket set 
 IrsaliyeID=@IrsaliyeID,  SatirNo=@SatirNo,  StokID=@StokID,  Miktar=@Miktar,  StokAnaBirimID=@StokAnaBirimID,  AnaBirimFiyat=@AnaBirimFiyat,  Birim2ID=@Birim2ID,  KatSayi=@KatSayi, 
Birim2Fiyat=@Birim2Fiyat,  Kdv=@Kdv,  Toplam=@Toplam,  KdvToplam=@KdvToplam,  Net=@Net,  StokIskonto1=@StokIskonto1,  StokIskonto2=@StokIskonto2,
StokIskonto3=@StokIskonto3,  CariIskonto1=@CariIskonto1,  CariIskonto2=@CariIskonto2,  CariIskonto3=@CariIskonto3,  IndirimYuzdesi1=@IndirimYuzdesi1, 
IndirimYuzdesi=@IndirimYuzdesi,  Indirim=@Indirim,  SatirIndirimliBirimFiyat=@SatirIndirimliBirimFiyat,  SatirIndirimliKDVTutar=@SatirIndirimliKDVTutar,
SatirIndirimliToplam=@SatirIndirimliToplam, AltIndirimBirimFiyat=@AltIndirimBirimFiyat,  AltIndirimKDVTutar=@AltIndirimKDVTutar,  AltIndirimToplamTutar=@AltIndirimToplamTutar, 
SatirToplamIndirim=@SatirToplamIndirim,  SatirToplamTutar=@SatirToplamTutar,  SatirAciklama=@SatirAciklama,DepoID=@DepoID
where IrsaliyeHareketID = @IrsaliyeHareketID", Baglanti, trGenel);
				#region UPDATE PARAMETRELERİ
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@IrsaliyeHareketID", SqlDbType.Int, 15, "IrsaliyeHareketID");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@IrsaliyeID", SqlDbType.Int, 0, "IrsaliyeID");//.Value = IrsaliyeID;
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@SatirNo", SqlDbType.Int, 0, "SatirNo");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@StokAnaBirimID", SqlDbType.Int, 0, "StokAnaBirimID");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@AnaBirimFiyat", SqlDbType.Decimal, 0, "AnaBirimFiyat");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@Birim2ID", SqlDbType.Int, 0, "Birim2ID");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@Birim2Fiyat", SqlDbType.Decimal, 0, "Birim2Fiyat");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@Kdv", SqlDbType.Decimal, 0, "Kdv");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@Toplam", SqlDbType.Decimal, 0, "Toplam");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@KdvToplam", SqlDbType.Decimal, 0, "KdvToplam");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@Net", SqlDbType.Decimal, 0, "Net");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@StokIskonto1", SqlDbType.Decimal, 0, "StokIskonto1");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@StokIskonto2", SqlDbType.Decimal, 0, "StokIskonto2");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@StokIskonto3", SqlDbType.Decimal, 0, "StokIskonto3");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@CariIskonto1", SqlDbType.Decimal, 0, "CariIskonto1");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@CariIskonto2", SqlDbType.Decimal, 0, "CariIskonto2");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@CariIskonto3", SqlDbType.Decimal, 0, "CariIskonto3");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@IndirimYuzdesi1", SqlDbType.Decimal, 0, "IndirimYuzdesi1");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@IndirimYuzdesi", SqlDbType.Decimal, 0, "IndirimYuzdesi");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@Indirim", SqlDbType.Decimal, 0, "Indirim");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@SatirIndirimliBirimFiyat", SqlDbType.Decimal, 0, "SatirIndirimliBirimFiyat");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@SatirIndirimliKDVTutar", SqlDbType.Decimal, 0, "SatirIndirimliKDVTutar");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@SatirIndirimliToplam", SqlDbType.Decimal, 0, "SatirIndirimliToplam");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@AltIndirimBirimFiyat", SqlDbType.Decimal, 0, "AltIndirimBirimFiyat");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@AltIndirimKDVTutar", SqlDbType.Decimal, 0, "AltIndirimKDVTutar");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@AltIndirimToplamTutar", SqlDbType.Decimal, 0, "AltIndirimToplamTutar");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@SatirToplamIndirim", SqlDbType.Decimal, 0, "SatirToplamIndirim");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@SatirToplamTutar", SqlDbType.Decimal, 0, "SatirToplamTutar");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@SatirAciklama", SqlDbType.NVarChar, 250, "SatirAciklama");
				da_IrsaliyeHareketleri.UpdateCommand.Parameters.Add("@DepoID", SqlDbType.Int, 0, "DepoID");
				#endregion

				da_IrsaliyeHareketleri.DeleteCommand = new SqlCommand("delete IrsaliyeHareket where IrsaliyeHareketID = @IrsaliyeHareketID", Baglanti, trGenel);
				da_IrsaliyeHareketleri.DeleteCommand.Parameters.Add("@IrsaliyeHareketID", SqlDbType.Int, 20, "IrsaliyeHareketID");
				da_IrsaliyeHareketleri.Fill(dt_IrsaliyeHareketleri);
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
