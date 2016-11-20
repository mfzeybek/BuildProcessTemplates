using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Ayarlar
{
  public class csBarkodAyar : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    SqlDataAdapter da;
    public DataTable dt;

    public void Getir(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (da = new SqlDataAdapter("select * from BarkodAyar", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;

        dt = new DataTable();
        da.Fill(dt);
        da.RowUpdated += da_RowUpdated;
      }
    }

    void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
    {
      if (e.StatementType == StatementType.Insert)
        e.Row["BarkodAyarID"] = e.Command.Parameters["@YeniID"].Value;
    }

    public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
    {
      da.InsertCommand = new SqlCommand(@"
      insert into BarkodAyar 
      (OnEk, BarkodTipi, KontrolNoOlsunMu, MiktarOlacakMi, KacHaneMiktar, KacHaneKod, Aciklama, ToplamKarakterSayisi, SiradakiKod)
      values 
      (@OnEk, @BarkodTipi, @KontrolNoOlsunMu, @MiktarOlacakMi, @KacHaneMiktar, @KacHaneKod, @Aciklama, @ToplamKarakterSayisi, @SiradakiKod)
      set @YeniID = SCOPE_IDENTITY() ", Baglanti, Tr);

      da.InsertCommand.Parameters.Add("@OnEk", SqlDbType.NVarChar, 50, "OnEk");
      da.InsertCommand.Parameters.Add("@BarkodTipi", SqlDbType.TinyInt, 0, "BarkodTipi");
      da.InsertCommand.Parameters.Add("@KontrolNoOlsunMu", SqlDbType.Bit, 0, "KontrolNoOlsunMu");
      da.InsertCommand.Parameters.Add("@MiktarOlacakMi", SqlDbType.Bit, 0, "MiktarOlacakMi");
      da.InsertCommand.Parameters.Add("@KacHaneMiktar", SqlDbType.TinyInt, 0, "KacHaneMiktar");
      da.InsertCommand.Parameters.Add("@KacHaneKod", SqlDbType.TinyInt, 0, "KacHaneKod");
      da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 250, "Aciklama");
      da.InsertCommand.Parameters.Add("@ToplamKarakterSayisi", SqlDbType.TinyInt, 0, "ToplamKarakterSayisi");
      da.InsertCommand.Parameters.Add("@SiradakiKod", SqlDbType.NVarChar, 250, "SiradakiKod");

      da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;


      da.UpdateCommand = new SqlCommand(@"Update BarkodAyar set 
      OnEk = @OnEk, BarkodTipi = @BarkodTipi, KontrolNoOlsunMu = @KontrolNoOlsunMu, MiktarOlacakMi = @MiktarOlacakMi, KacHaneMiktar = @KacHaneMiktar, KacHaneKod = @KacHaneKod, 
      Aciklama = @Aciklama, ToplamKarakterSayisi = @ToplamKarakterSayisi, SiradakiKod = @SiradakiKod where BarkodAyarID = @BarkodAyarID ", Baglanti, Tr);

      da.UpdateCommand.Parameters.Add("@OnEk", SqlDbType.NVarChar, 50, "OnEk");
      da.UpdateCommand.Parameters.Add("@BarkodTipi", SqlDbType.TinyInt, 0, "BarkodTipi");
      da.UpdateCommand.Parameters.Add("@KontrolNoOlsunMu", SqlDbType.Bit, 0, "KontrolNoOlsunMu");
      da.UpdateCommand.Parameters.Add("@MiktarOlacakMi", SqlDbType.Bit, 0, "MiktarOlacakMi");
      da.UpdateCommand.Parameters.Add("@KacHaneMiktar", SqlDbType.TinyInt, 0, "KacHaneMiktar");
      da.UpdateCommand.Parameters.Add("@KacHaneKod", SqlDbType.TinyInt, 0, "KacHaneKod");
      da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 250, "Aciklama");
      da.UpdateCommand.Parameters.Add("@ToplamKarakterSayisi", SqlDbType.TinyInt, 0, "ToplamKarakterSayisi");
      da.UpdateCommand.Parameters.Add("@SiradakiKod", SqlDbType.NVarChar, 250, "SiradakiKod");
      
      da.UpdateCommand.Parameters.Add(@"BarkodAyarID", SqlDbType.Int, 0, "BarkodAyarID");

      da.Update(dt);
    }
  }
}
