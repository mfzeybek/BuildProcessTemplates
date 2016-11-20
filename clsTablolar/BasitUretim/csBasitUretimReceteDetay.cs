using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.BasitUretim
{
  public class csBasitUretimReceteDetay : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
    SqlDataAdapter da;
    public DataTable dt;

    private decimal _Maliyet;

    public decimal Maliyet
    {
      get { return _Maliyet; }
      set { _Maliyet = value; }
    }

    public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int BUReceteID)
    {
      using (da = new SqlDataAdapter(@"select BasitUretimReceteDetayi.*, Stok.StokKodu ,Stok.StokAdi, 0.00000 as 'MaliyetFiyati', 0.00000 as 'MaliyetTutari' from BasitUretimReceteDetayi 
inner join Stok on Stok.StokID = BasitUretimReceteDetayi.MalzemeStokID
where BUReceteID = @BUReceteID ", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        da.SelectCommand.Parameters.Add("@BUReceteID", SqlDbType.Int).Value = BUReceteID;

        using (dt = new DataTable())
        {
          da.Fill(dt);
        }
      }
    }

    public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int BUReceteID)
    {
      da.UpdateCommand = new SqlCommand(@"update BasitUretimReceteDetayi set BUReceteID = @BUReceteID, 
                                          MalzemeStokID = @MalzemeStokID, GerekliMiktar = @GerekliMiktar, MaliyetFiyatTanimID = @MaliyetFiyatTanimID where BUReceteDetayID = @BUReceteDetayID ", Baglanti, Tr);

      da.UpdateCommand.Parameters.Add("@BUReceteID", SqlDbType.Int).Value = BUReceteID;
      da.UpdateCommand.Parameters.Add("@BUReceteDetayID", SqlDbType.Int, 0, "BUReceteDetayID");
      da.UpdateCommand.Parameters.Add("@MalzemeStokID", SqlDbType.Int, 0, "MalzemeStokID");
      da.UpdateCommand.Parameters.Add("@GerekliMiktar", SqlDbType.Decimal, 0, "GerekliMiktar");
      da.UpdateCommand.Parameters.Add("@MaliyetFiyatTanimID", SqlDbType.Int, 0, "MaliyetFiyatTanimID");

      da.InsertCommand = new SqlCommand(@"insert into BasitUretimReceteDetayi
                                      ( BUReceteID, MalzemeStokID, GerekliMiktar, MaliyetFiyatTanimID ) 
                                      values 
                                      ( @BUReceteID, @MalzemeStokID, @GerekliMiktar, @MaliyetFiyatTanimID )   set @YeniID = SCOPE_IDENTITY() ", Baglanti, Tr);

      da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
      da.InsertCommand.Parameters.Add("@BUReceteID", SqlDbType.Int).Value = BUReceteID;
      da.InsertCommand.Parameters.Add("@MalzemeStokID", SqlDbType.Int, 0, "MalzemeStokID");
      da.InsertCommand.Parameters.Add("@GerekliMiktar", SqlDbType.Decimal, 0, "GerekliMiktar");
      da.InsertCommand.Parameters.Add("@MaliyetFiyatTanimID", SqlDbType.Int, 0, "MaliyetFiyatTanimID");


      da.DeleteCommand = new SqlCommand(@"delete from BasitUretimReceteDetayi where BUReceteDetayID = @BUReceteDetayID ", Baglanti, Tr);
      da.DeleteCommand.Parameters.Add("@BUReceteDetayID", SqlDbType.Int, 0, "BUReceteDetayID");

      da.RowUpdated += da_RowUpdated;

      da.Update(dt);


    }

    void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
    {
      if (e.StatementType == StatementType.Insert)
        e.Row["BUReceteDetayID"] = da.InsertCommand.Parameters["@YeniID"].Value;
    }


  }
}
