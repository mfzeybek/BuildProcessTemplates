using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
  public class csFiyatTanim : IDisposable
  {
    private SqlDataAdapter da_AlisTanimlari;
    private DataTable dt_AlisTanimlari;

    private SqlDataAdapter da_SatisTAnimlari;
    public DataTable dt_SatisTanimlari;

    private SqlDataAdapter da_ButunFiyatTanimlari;
    private DataTable dt_ButunFiyatTanimlari;

    public DataTable FiyatTanimGetir(SqlConnection baglanti, SqlTransaction trGenel)
    {
      DataTable dt_ = new DataTable();
      using (SqlDataAdapter da_ = new SqlDataAdapter("select FiyatTanimID,FiyatTanimAdi From FiyatTanim", baglanti))
      {
        da_.SelectCommand.Transaction = trGenel;
        da_.Fill(dt_);
      }
      return dt_;
    }

    public void FiyatTanimGuncelle(SqlConnection Baglanti, SqlTransaction Tr)
    {
      #region AlisFiyatTanimlari
      da_AlisTanimlari.UpdateCommand = new SqlCommand("update FiyatTanim set FiyatTanimAdi = @FiyatTanimAdi where FiyatTanimID = @FiyatTanimID", Baglanti, Tr);
      da_AlisTanimlari.UpdateCommand.Parameters.Add("@FiyatTanimAdi", SqlDbType.NVarChar, 50, "FiyatTanimAdi");
      da_AlisTanimlari.UpdateCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");

      da_AlisTanimlari.InsertCommand.CommandText = "insert into FiyatTanim (FiyatTanimAdi, AlismiSatisMi) values (@FiyatTanimAdi, @AlismiSatisMi)";
      da_AlisTanimlari.InsertCommand.Parameters.Add("@FiyatTanimAdi", SqlDbType.NVarChar, 50, "FiyatTanimAdi");
      da_AlisTanimlari.InsertCommand.Parameters.Add("@AlismiSatisMi", SqlDbType.NVarChar).Value = "Alis";

      da_AlisTanimlari.DeleteCommand.CommandText = "Delete FiyatTanim where FiyatTanimID = @FiyatTanimID";
      da_AlisTanimlari.DeleteCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");

      da_AlisTanimlari.Update(dt_AlisTanimlari);
      #endregion

      #region Satış Fiyat tanımları
      da_AlisTanimlari.UpdateCommand = new SqlCommand("update FiyatTanim set FiyatTanimAdi = @FiyatTanimAdi where FiyatTanimID = @FiyatTanimID", Baglanti, Tr);
      da_AlisTanimlari.UpdateCommand.Parameters.Add("@FiyatTanimAdi", SqlDbType.NVarChar, 50, "FiyatTanimAdi");
      da_AlisTanimlari.UpdateCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");

      da_AlisTanimlari.InsertCommand.CommandText = "insert into FiyatTanim (FiyatTanimAdi, @AlismiSatisMi) values (@FiyatTanimAdi, @AlismiSatisMi)";
      da_AlisTanimlari.InsertCommand.Parameters.Add("@FiyatTanimAdi", SqlDbType.NVarChar, 50, "FiyatTanimAdi");
      da_AlisTanimlari.InsertCommand.Parameters.Add("@AlismiSatisMi", SqlDbType.NVarChar).Value = "Satis";

      da_AlisTanimlari.DeleteCommand.CommandText = "Delete FiyatTanim where FiyatTanimID = @FiyatTanimID";
      da_AlisTanimlari.DeleteCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");

      da_AlisTanimlari.Update(dt_AlisTanimlari);
      #endregion
    }

    public DataTable AlisTanimlariniGetir(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (da_AlisTanimlari = new SqlDataAdapter())
      {
        da_AlisTanimlari.SelectCommand = new SqlCommand();
        da_AlisTanimlari.SelectCommand.CommandText = "select FiyatTanimID, AlisMiSatisMi FiyatTanimAdi from FiyatTanim where AlisMiSatisMi = 'Alis'";
        da_AlisTanimlari.SelectCommand.Connection = Baglanti;
        da_AlisTanimlari.SelectCommand.Transaction = Tr;
        dt_AlisTanimlari = new DataTable();
        da_AlisTanimlari.Fill(dt_AlisTanimlari);
        return dt_AlisTanimlari;
      }
    }

    public DataTable SatisTanimlariniGetir(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (da_SatisTAnimlari = new SqlDataAdapter())
      {
        da_SatisTAnimlari.SelectCommand = new SqlCommand();
        da_SatisTAnimlari.SelectCommand.CommandText = "select FiyatTanimID, FiyatTanimAdi, AlisMiSatisMi from FiyatTanim Where AlisMiSatisMi = 'Satis'";
        da_SatisTAnimlari.SelectCommand.Connection = Baglanti;
        da_SatisTAnimlari.SelectCommand.Transaction = Tr;
        dt_SatisTanimlari = new DataTable();
        da_SatisTAnimlari.Fill(dt_SatisTanimlari);
        return dt_SatisTanimlari;
      }
    }

    public DataTable TumFiyatTanimlariniGetir(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (da_ButunFiyatTanimlari = new SqlDataAdapter())
      {
        da_ButunFiyatTanimlari.SelectCommand = new SqlCommand();
        da_ButunFiyatTanimlari.SelectCommand.CommandText = "select FiyatTanimID, FiyatTanimAdi, AlisMiSatisMi from FiyatTanim";
        da_ButunFiyatTanimlari.SelectCommand.Connection = Baglanti;
        da_ButunFiyatTanimlari.SelectCommand.Transaction = Tr;
        dt_ButunFiyatTanimlari = new DataTable();
        da_ButunFiyatTanimlari.Fill(dt_ButunFiyatTanimlari);
        return dt_ButunFiyatTanimlari;
      }
    }

    public string TanimIDdenTanimAdiGetir(SqlConnection Baglanti, SqlTransaction Tr, int FiyatTanimID)
    {
      SqlCommand cmd = new SqlCommand("select FiyatTanimAdi from FiyatTanim where FiyatTanimID = @FiyatTanimID", Baglanti, Tr);
      cmd.Parameters.Add("@FiyatTanimID", SqlDbType.Int).Value = FiyatTanimID;
      return cmd.ExecuteScalar().ToString();
    }

    /// <summary>
    /// Cari Karttaki Fiyat Tanim ID den Stok Fiyatini verir
    /// </summary>
    /// <param name="Baglanti"></param>
    /// <param name="Tr"></param>
    /// <param name="FiyatTanimi"></param>
    /// <returns></returns>
    public decimal FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnection Baglanti, SqlTransaction Tr, int FiyatTanimID, int StokID)
    {
      SqlCommand cmd = new SqlCommand("select Fiyat from StokFiyat where FiyatTanimID = @FiyatTanimID and StokID = @StokID", Baglanti, Tr);
      cmd.Parameters.Add("@FiyatTanimID", SqlDbType.Int).Value = FiyatTanimID;
      cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

      decimal Fiyat = 0;
      if (cmd.ExecuteScalar() != null)
        decimal.TryParse(cmd.ExecuteScalar().ToString(), out Fiyat);

      return Fiyat;
    }

    public decimal SonAlisFiyatiniGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      using (SqlCommand cmd = new SqlCommand(@"select Top 1 ISNULL(FaturaHareket.IskontoluFiyat, 0) from FATURAHAREKET
inner join Fatura on fatura.FaturaID = FaturaHareket.FaturaID

where Fatura.FaturaTipi = 2 
and FaturaHareket.StokID = @StokID
order by Fatura.FaturaTarihi desc", Baglanti, Tr))
      {

        cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

        return Convert.ToDecimal(cmd.ExecuteScalar());
      }
    }

    public void FiyatKaydet(SqlConnection Baglanti, SqlTransaction Tr, int StokID, int FiyatTanimID, decimal Fiyat)
    {
      using (SqlCommand cmdGenel = new SqlCommand(@"
if (( select StokFiyat.StokID from dbo.StokFiyat where StokID = @StokID  and  StokFiyat.FiyatTanimID = @FiyatTanimID) =	@StokID)
update StokFiyat set Fiyat = @Fiyat where StokID= @StokID and StokFiyat.FiyatTanimID = @FiyatTanimID
else
insert into StokFiyat (FiyatTanimID, Fiyat, StokID, AlisMiSatisMi) values (@FiyatTanimID, @Fiyat, @StokID, 'Satis')", Baglanti, Tr))
      {
        cmdGenel.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        cmdGenel.Parameters.Add("@Fiyat", SqlDbType.Decimal).Value = Fiyat;
        cmdGenel.Parameters.Add("@FiyatTanimID", SqlDbType.Int).Value = FiyatTanimID;

        cmdGenel.ExecuteNonQuery();
      }
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
