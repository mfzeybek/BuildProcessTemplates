using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csTelefon : IDisposable
  {
    public DataTable dt;
		private SqlDataAdapter da;

    public void TelefonGuncelle(SqlConnection Baglanti, SqlTransaction TrGenel ,int CariID)
    {
      try
      {
        da.UpdateCommand = new SqlCommand(
@"update Telefon set CariID = @CariID, TelefonTipID = @TelefonTipID, Numara = @Numara, Aciklama = @Aciklama, Varsayilan=@Varsayilan
where TelefonID = @TelefonID", Baglanti, TrGenel);
        da.UpdateCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
        da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 100, "Aciklama");
        da.UpdateCommand.Parameters.Add("@Numara", SqlDbType.NVarChar, 30, "Numara");
				da.UpdateCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 0, "Varsayilan");
        da.UpdateCommand.Parameters.Add("@TelefonID", SqlDbType.Int, 0, "TelefonID");
        da.UpdateCommand.Parameters.Add("@TelefonTipID", SqlDbType.Int, 0, "TelefonTipID");

        da.InsertCommand = new SqlCommand("insert into Telefon (CariID, TelefonTipID, Numara, Aciklama,Varsayilan) values (@CariID, @TelefonTipID, @Numara, @Aciklama,@Varsayilan)  set @YeniID = SCOPE_IDENTITY() ", Baglanti, TrGenel);
        da.InsertCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
        da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 100, "Aciklama");
        da.InsertCommand.Parameters.Add("@Numara", SqlDbType.NVarChar, 30, "Numara");
				da.InsertCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 0, "Varsayilan");
        da.InsertCommand.Parameters.Add("@TelefonTipID", SqlDbType.Int, 0, "TelefonTipID");

        da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;


        da.DeleteCommand = new SqlCommand("delete from Telefon where TelefonID = @TelefonID", Baglanti, TrGenel);
        da.DeleteCommand.Parameters.Add("@TelefonID", SqlDbType.Int, 10, "TelefonID");

        

				da.Update(dt);
      }
      catch (Exception hata)
      {
        throw new Exception(hata.Message);
      }
    }

		public csTelefon(SqlConnection Baglanti, int CariID)
    {
			da = new SqlDataAdapter();
			da.SelectCommand = new SqlCommand(@"
SELECT     dbo.Telefon.TelefonID, dbo.Telefon.CariID, dbo.Telefon.TelefonTipID, dbo.TelefonTipi.TelefonTipi, dbo.Telefon.Numara, dbo.Telefon.Aciklama, dbo.Telefon.Varsayilan, 
                      dbo.Telefon.KaydedenID, dbo.Telefon.KayitTarihi, dbo.Telefon.GuncelleyenID, dbo.Telefon.GuncellemeTarihi
FROM         dbo.Telefon LEFT OUTER JOIN
                      dbo.TelefonTipi ON dbo.Telefon.TelefonTipID = dbo.TelefonTipi.TelefonTipiID
WHERE     (dbo.Telefon.CariID = @CariID)", Baglanti);
			da.SelectCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;

			dt = new DataTable();
			da.Fill(dt);

      da.RowUpdated += da_RowUpdated;
    }

    void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
    {
      if (e.StatementType == StatementType.Insert)
        e.Row["TelefonID"] = e.Command.Parameters["@YeniID"].Value;
      
    }
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
