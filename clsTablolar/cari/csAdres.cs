using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
	public class csAdres : IDisposable
	{
		public DataTable dt;
		private SqlDataAdapter da;

		public void AdresGuncelle(SqlConnection Baglanti,SqlTransaction TrGenel ,int CariID)
		{
			da = new SqlDataAdapter();
			da.UpdateCommand = new SqlCommand(@"
Update Adres set CariID = @CariID, Adres = @Adres, PostaKodu=@PostaKodu, 
UlkeID = @UlkeID, SehirID = @SehirID, IlceID = @IlceID ,AdresTipID=@AdresTipID,
Aciklama = @Aciklama ,Varsayilan = @Varsayilan where AdresID = @AdresID", Baglanti, TrGenel);
			da.UpdateCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
			da.UpdateCommand.Parameters.Add("@Adres", SqlDbType.NVarChar, 200, "Adres");
			da.UpdateCommand.Parameters.Add("@PostaKodu", SqlDbType.NVarChar, 200, "PostaKodu");
			da.UpdateCommand.Parameters.Add("@UlkeID", SqlDbType.Int, 0, "UlkeID");
			da.UpdateCommand.Parameters.Add("@SehirID", SqlDbType.Int, 0, "SehirID");
			da.UpdateCommand.Parameters.Add("@IlceID", SqlDbType.Int, 0, "IlceID");
			da.UpdateCommand.Parameters.Add("@AdresTipID", SqlDbType.Int, 0, "AdresTipID");
			da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 100, "Aciklama");
			da.UpdateCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 0, "Varsayilan");
			da.UpdateCommand.Parameters.Add("@AdresID", SqlDbType.Int, 0, "AdresID");

			da.InsertCommand = new SqlCommand(@"insert into Adres 
(CariID,Adres,PostaKodu,UlkeID,SehirID,IlceID,AdresTipID,Aciklama,Varsayilan) 
values (@CariID,@Adres,@PostaKodu,@UlkeID,@SehirID,@IlceID,@AdresTipID,@Aciklama,@Varsayilan) set @YeniID = SCOPE_IDENTITY() ", Baglanti, TrGenel);
			da.InsertCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
			da.InsertCommand.Parameters.Add("@Adres", SqlDbType.NVarChar, 200, "Adres");
			da.InsertCommand.Parameters.Add("@PostaKodu", SqlDbType.NVarChar, 200, "PostaKodu");
			da.InsertCommand.Parameters.Add("@UlkeID", SqlDbType.Int, 0, "UlkeID");
			da.InsertCommand.Parameters.Add("@SehirID", SqlDbType.Int, 0, "SehirID");
			da.InsertCommand.Parameters.Add("@IlceID", SqlDbType.Int, 0, "IlceID");
			da.InsertCommand.Parameters.Add("@AdresTipID", SqlDbType.Int, 0, "AdresTipID");
			da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 100, "Aciklama");
			da.InsertCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 0, "Varsayilan");
			da.InsertCommand.Parameters.Add("@AdresID", SqlDbType.Int, 0, "AdresID");
      da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

			da.DeleteCommand = new SqlCommand("delete from Adres where AdresID = @AdresID", Baglanti, TrGenel);
			da.DeleteCommand.Parameters.Add("@AdresID", SqlDbType.Int, 0, "AdresID");


      
			da.Update(dt);
		}

    void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
    {
      if (e.StatementType == StatementType.Insert)
        e.Row["AdresID"] = e.Command.Parameters["@YeniID"].Value;
    }

		public csAdres(SqlConnection Baglanti, int CariID)
		{
			da = new SqlDataAdapter();
			da.SelectCommand = new SqlCommand(@"
SELECT     dbo.Adres.AdresID, dbo.Adres.CariID, dbo.Adres.Adres, dbo.Adres.PostaKodu, dbo.Adres.UlkeID, dbo.Ulke.UlkeAdi, dbo.Adres.SehirID, dbo.Sehir.SehirAdi, 
                      dbo.Adres.IlceID, dbo.Ilce.IlceAdi, dbo.Adres.AdresTipID, dbo.AdresTip.AdresTip, dbo.Adres.Aciklama, dbo.Adres.Varsayilan, dbo.Adres.KaydedenID, 
                      dbo.Adres.KayitTarihi, dbo.Adres.GuncelleyenID, dbo.Adres.GuncellemeTarihi
FROM         dbo.Adres LEFT OUTER JOIN
                      dbo.AdresTip ON dbo.Adres.AdresTipID = dbo.AdresTip.AdresTipID LEFT OUTER JOIN
                      dbo.Ulke ON dbo.Adres.UlkeID = dbo.Ulke.UlkeID LEFT OUTER JOIN
                      dbo.Ilce ON dbo.Adres.IlceID = dbo.Ilce.IlceID LEFT OUTER JOIN
                      dbo.Sehir ON dbo.Adres.SehirID = dbo.Sehir.SehirID 
WHERE     (dbo.Adres.CariID = @CariID)", Baglanti);
			da.SelectCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;


			dt = new DataTable();
			da.Fill(dt);

      da.RowUpdated += da_RowUpdated;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
