using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csAdresv2 : IDisposable
  {
    private SqlDataAdapter da = new SqlDataAdapter();
    public DataTable dt = new DataTable();

    public void AdresBind(SqlConnection Baglanti, int CariID)
    {
      try
      {
        da.SelectCommand = new SqlCommand(@"SELECT     dbo.Adres.AdresID, dbo.Adres.CariID, dbo.Adres.Adres, dbo.Adres.PostaKodu, dbo.Adres.UlkeID, dbo.Ulke.UlkeAdi, 
dbo.Adres.SehirID, dbo.Sehir.SehirAdi, dbo.Adres.IlceID, dbo.Ilce.IlceAdi, dbo.Adres.AdresTipID, dbo.AdresTip.AdresTip, dbo.Adres.Aciklama, dbo.Adres.Varsayilan,
dbo.Adres.KaydedenID, dbo.Adres.KayitTarihi, dbo.Adres.GuncelleyenID, dbo.Adres.GuncellemeTarihi
FROM         dbo.Adres LEFT OUTER JOIN
                      dbo.AdresTip ON dbo.Adres.AdresTipID = dbo.AdresTip.AdresTipID LEFT OUTER JOIN
                      dbo.Ulke ON dbo.Adres.UlkeID = dbo.Ulke.UlkeID LEFT OUTER JOIN
                      dbo.Ilce ON dbo.Adres.IlceID = dbo.Ilce.IlceID LEFT OUTER JOIN
                      dbo.Sehir ON dbo.Adres.SehirID = dbo.Sehir.SehirID 
WHERE     (dbo.Adres.CariID = @CariID) ", Baglanti);
        da.SelectCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;

        da.UpdateCommand = new SqlCommand("Update Adres set CariID = @CariID, UlkeID = @UlkeID, SehirID = @SehirID, IlceID = @IlceID ,Adres = @Adres, PostaKodu=@PostaKodu, Aciklama = @Aciklama ,Varsayilan = @Varsayilan where AdresID = @AdresID", Baglanti);
        da.UpdateCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
        da.UpdateCommand.Parameters.Add("@UlkeID", SqlDbType.Int, 0, "UlkeID");
        da.UpdateCommand.Parameters.Add("@SehirID", SqlDbType.Int, 0, "SehirID");
        da.UpdateCommand.Parameters.Add("@IlceID", SqlDbType.Int, 0, "IlceID");
        da.UpdateCommand.Parameters.Add("@Adres", SqlDbType.NVarChar, 200, "Adres");
        da.UpdateCommand.Parameters.Add("@PostaKodu", SqlDbType.NVarChar, 200, "PostaKodu");
        da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 100, "Aciklama");
        da.UpdateCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 0, "Varsayilan");
        da.UpdateCommand.Parameters.Add("@AdresID", SqlDbType.Int, 0, "AdresID");

        da.InsertCommand = new SqlCommand(
@"insert into Adres (CariID, UlkeID, SehirID, IlceID ,Adres , PostaKodu, Aciklama ,Varsayilan)
values (@CariID, @UlkeID, @SehirID,@IlceID ,@Adres ,@PostaKodu,@Aciklama ,@Varsayilan)", Baglanti);
        da.InsertCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
        da.InsertCommand.Parameters.Add("@UlkeID", SqlDbType.Int, 0, "UlkeID");
        da.InsertCommand.Parameters.Add("@SehirID", SqlDbType.Int, 0, "SehirID");
        da.InsertCommand.Parameters.Add("@IlceID", SqlDbType.Int, 0, "IlceID");
        da.InsertCommand.Parameters.Add("@Adres", SqlDbType.NVarChar, 200, "Adres");
        da.InsertCommand.Parameters.Add("@PostaKodu", SqlDbType.NVarChar, 200, "PostaKodu");
        da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 100, "Aciklama");
        da.InsertCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 0, "Varsayilan");

        da.DeleteCommand = new SqlCommand("delete from Adres where AdresID = @AdresID", Baglanti);
        da.DeleteCommand.Parameters.Add("@AdresID", SqlDbType.Int, 0, "AdresID");

        dt.Clear();
        da.Fill(dt);
      }
      catch (Exception hata)
      {
        throw new Exception(hata.Message);
      }
    }
    public void AdresDtGuncelle()
    {
      da.Update(dt);
    }
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
