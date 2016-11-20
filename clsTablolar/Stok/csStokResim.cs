using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar
{
  public class csStokResim : IDisposable
  {
    public DataTable dt_StokResimleri;
    SqlDataAdapter da;
    public byte[] VarsayilanFoto;

    public csStokResim(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      if (StokID == -1)
      {
        dt_StokResimleri = new DataTable();
        dt_StokResimleri.Columns.Add("StokResimID");
        dt_StokResimleri.Columns[0].DataType = System.Type.GetType("System.Int32");
        dt_StokResimleri.Columns[0].AutoIncrement = true;
        dt_StokResimleri.Columns[0].AutoIncrementSeed = 1;
        dt_StokResimleri.Columns[0].AutoIncrementStep = 1;
        dt_StokResimleri.Columns[0].ReadOnly = true;

        dt_StokResimleri.Columns.Add("StokID");
        dt_StokResimleri.Columns["StokID"].DataType = System.Type.GetType("System.Int32");


        dt_StokResimleri.Columns.Add("Resim");
        dt_StokResimleri.Columns["Resim"].DataType = System.Type.GetType("System.Byte[]");

        dt_StokResimleri.Columns.Add("ResimAciklama");
        dt_StokResimleri.Columns["ResimAciklama"].DataType = System.Type.GetType("System.String");

        dt_StokResimleri.Columns.Add("Varsayilan");
        dt_StokResimleri.Columns["Varsayilan"].DataType = System.Type.GetType("System.Boolean");

        dt_StokResimleri.Columns.Add("Ftp");
        dt_StokResimleri.Columns["Ftp"].DataType = System.Type.GetType("System.String");

        dt_StokResimleri.Columns.Add("TeraziButonFotosu");
        dt_StokResimleri.Columns["TeraziButonFotosu"].DataType = System.Type.GetType("System.Boolean");
      }
      else
      {
        StokResimDoldur(Baglanti, Tr, StokID);
      }
    }

    private void StokResimDoldur(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      using (da = new SqlDataAdapter())
      {
          da.SelectCommand = new SqlCommand(@" SELECT StokResimID, StokID, ResimAciklama,Resim , Varsayilan, TeraziButonFotosu, Ftp FROM StokResim WHERE  (StokID = @StokID) order by Varsayilan desc ", Baglanti, Tr);
        da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        using (dt_StokResimleri = new DataTable())
        {
          da.Fill(dt_StokResimleri);
          if (dt_StokResimleri.Rows.Count > 0) //Eğer stokta foto yoksa Varsayilan fotoya atmayua çalışmasın (public byte[] VarsayilanFoto yukarda).
            VarsayilanFoto = (byte[])dt_StokResimleri.Rows[0]["Resim"]; // ilk foto varsayilan foto olarak geçiyormuş
        }
      }
    }

    public string ResimleriGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      da = new SqlDataAdapter();
      da.InsertCommand = new SqlCommand(@"insert into StokResim (StokID, ResimAciklama, Varsayilan, Resim, Ftp, TeraziButonFotosu) values (@StokID, @ResimAciklama, @Varsayilan,
            @Resim, @Ftp, @TeraziButonFotosu)", Baglanti, Tr);
      da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
      da.InsertCommand.Parameters.Add("@ResimAciklama", SqlDbType.NVarChar, 100, "ResimAciklama");
      da.InsertCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 1, "Varsayilan");
      da.InsertCommand.Parameters.Add("@Resim", SqlDbType.Image, 0, "Resim");
      da.InsertCommand.Parameters.Add("@Ftp", SqlDbType.NVarChar, 200, "Ftp");
      da.InsertCommand.Parameters.Add("@TeraziButonFotosu", SqlDbType.Bit, 0, "TeraziButonFotosu");


      da.UpdateCommand = new SqlCommand(@"update  StokResim set StokID = @StokID, 
ResimAciklama = @ResimAciklama, Varsayilan = @Varsayilan, Resim = @Resim , Ftp = @Ftp, TeraziButonFotosu = @TeraziButonFotosu where StokResimID = @StokResimID ", Baglanti, Tr);
      da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
      da.UpdateCommand.Parameters.Add("@ResimAciklama", SqlDbType.NVarChar, 100, "ResimAciklama");
      da.UpdateCommand.Parameters.Add("@Varsayilan", SqlDbType.Bit, 1, "Varsayilan");
      da.UpdateCommand.Parameters.Add("@Resim", SqlDbType.Image, 0, "Resim");
      da.UpdateCommand.Parameters.Add("@StokResimID", SqlDbType.Int, 0, "StokResimID");
      da.UpdateCommand.Parameters.Add("@Ftp", SqlDbType.NVarChar, 200, "Ftp");
      da.UpdateCommand.Parameters.Add("@TeraziButonFotosu", SqlDbType.Bit, 1, "TeraziButonFotosu");



      da.DeleteCommand = new SqlCommand(@"delete from StokResim where StokResimID = @StokResimID", Baglanti, Tr);
      da.DeleteCommand.Parameters.Add("@StokResimID", SqlDbType.Int, 0, "StokResimID");

      try
      {
        da.Update(dt_StokResimleri);
      }
      catch
      {
        return "Foto Kaydetmede Hata";
      }
      return "ok";
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
