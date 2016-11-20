using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
  public class csStokunBirimleri : IDisposable
  {
    public decimal BarkoddanGelenMiktar;

    public DataTable dt;
    private SqlDataAdapter da;

    public csStokunBirimleri(SqlConnection Baglanti, SqlTransaction Tr, int StokID, bool AnaBirimdeGelsinMi) // buralara açıklama lazım
    {
      if (AnaBirimdeGelsinMi == true)
      {
        StokBirimCevrimAnaBirimIleDoldur(Baglanti, Tr, StokID);
      }
      else
      {
        StokBirimCevrimDoldur(Baglanti, Tr, StokID);
      }

    }

    /// <summary>
    /// Stok Bağlı bütün AltBirimleri dt ye atar
    /// </summary>
    /// <param name="Baglanti"></param>
    /// <param name="StokID"></param>
    private void StokBirimCevrimDoldur(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      using (da = new SqlDataAdapter())
      {
          da.SelectCommand = new SqlCommand(@"SELECT  Distinct   dbo.StokBirimCevrim.StokBirimCevirmeID, dbo.StokBirimCevrim.Aciklama, dbo.StokBirimCevrim.StokID, 
dbo.StokBirimCevrim.BirimID, dbo.StokBirimCevrim.KatSayi, dbo.StokBirimCevrim.Barkodu, dbo.StokBirim.BirimAdi, isnull(BarkodAyar.MiktarOlacakMi, 0) as MiktarOlacakMi
FROM         dbo.StokBirimCevrim 
LEFT OUTER JOIN dbo.StokBirim ON dbo.StokBirimCevrim.BirimID = dbo.StokBirim.BirimID
left join BarkodAyar on left(StokBirimCevrim.Barkodu, 2) = BarkodAyar.OnEk -- ilk iki kodtan hangi barkod tipine uyduğuna bakıyor
WHERE     (dbo.StokBirimCevrim.StokID = @StokID)
", Baglanti, Tr);
        da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        using (dt = new DataTable())
        {
          da.Fill(dt);
        }
      }
    }

    private void StokBirimCevrimAnaBirimIleDoldur(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      using (da = new SqlDataAdapter())
      {
        da.SelectCommand = new SqlCommand(@"
SELECT     dbo.StokBirimCevrim.StokBirimCevirmeID, dbo.StokBirimCevrim.Aciklama, dbo.StokBirimCevrim.StokID, 
dbo.StokBirimCevrim.BirimID, dbo.StokBirimCevrim.KatSayi, dbo.StokBirimCevrim.Barkodu, dbo.StokBirim.BirimAdi, BarkodAyar.MiktarOlacakMi
FROM         dbo.StokBirimCevrim 
LEFT OUTER JOIN dbo.StokBirim ON dbo.StokBirimCevrim.BirimID = dbo.StokBirim.BirimID
left join BarkodAyar on left(StokBirimCevrim.Barkodu, 2) = BarkodAyar.OnEk
WHERE     (dbo.StokBirimCevrim.StokID = @StokID)
union
select -1, 'AnaBirimi', StokID, Stok.StokBirimID, 1, Barkod, StokBirim.BirimAdi, 0  from Stok
LEFT OUTER JOIN dbo.StokBirim ON stok.StokBirimID= dbo.StokBirim.BirimID
WHERE     (StokID = @StokID)", Baglanti, Tr);
        da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        using (dt = new DataTable())
        {
          da.Fill(dt);
        }
      }
    }

    public void StokBirimCevrimGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      da.UpdateCommand = new SqlCommand("Update StokBirimCevrim set Aciklama = @Aciklama, StokID = @StokID, BirimID = @BirimID, KatSayi= @KatSayi, Barkodu = @Barkodu  where StokBirimCevirmeID = @StokBirimCevirmeID", Baglanti, Tr);
      da.UpdateCommand.Parameters.Add("@StokBirimCevirmeID", SqlDbType.Int, 0, "StokBirimCevirmeID");
      da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 50, "Aciklama");
      da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
      da.UpdateCommand.Parameters.Add("@BirimID", SqlDbType.Int, 0, "BirimID");
      da.UpdateCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
      da.UpdateCommand.Parameters.Add("@Barkodu", SqlDbType.NVarChar, 0, "Barkodu");

      da.InsertCommand = new SqlCommand("insert into StokBirimCevrim (Aciklama, StokID, BirimID, KatSayi, Barkodu) values (@Aciklama, @StokID, @BirimID, @KatSayi, @Barkodu)", Baglanti, Tr);
      da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 50, "Aciklama");
      da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
      da.InsertCommand.Parameters.Add("@BirimID", SqlDbType.Int, 0, "BirimID");
      da.InsertCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
      da.InsertCommand.Parameters.Add("@Barkodu", SqlDbType.NVarChar, 0, "Barkodu");

      da.DeleteCommand = new SqlCommand("delete StokBirimCevrim where StokBirimCevirmeID = @StokBirimCevirmeID", Baglanti, Tr);
      da.DeleteCommand.Parameters.Add("@StokBirimCevirmeID", SqlDbType.Int, 0, "StokBirimCevirmeID");

      da.Update(dt);
    }

    // buraya ana miktari veren bişi yaz

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
