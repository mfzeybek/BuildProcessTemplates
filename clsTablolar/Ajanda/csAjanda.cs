using System;
using System.Data;
using System.Data.SqlClient;



namespace clsTablolar.Ajanda
{
  public class csAjanda : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    public DataTable dt_Takvim;

    public DataTable dt_resources;

    SqlDataAdapter da;


    // Veri Tabanındaki Grup 0 ise Ajanda kaydı
    // 1 ise İş başvurusu
    public void dt_getir(SqlConnection Baglanti, SqlTransaction Tr)
    {
        da = new SqlDataAdapter(@"select AjandaID, Baslik, Yer, StartTime, EndTime, Grup, Kaynak, Hatirlat, Aciklama, ButunGun, RecurrenceInfo, 
        ReminderInfo, EventType, KullaniciID, Status from Ajanda where EndTime > DATEADD( day,-30, GETDATE()) 
        union 
select IsBasvuruID, Adi +' '+Soyadi + ' Mulakat' , '',MulakatTarihi, MulakatTarihi ,22 -- işlem tipinden geliyor
, null, MulakatTarihi ,Aciklama, 0, null, '',0,null, 0  from IsBasvurulari
where MulakatTarihi is not null and MulakatTarihi > DATEADD( day,-30, GETDATE()) 

union
select CekHrID,CariTanim + ' '+ convert(nvarchar(50), CekHr.Tutari) + ' Çek', '', CekHr.EvrakTarihi,'' ,CekHr.EvrakTipi, null, CekHr.EvrakTarihi, 'Cek Ödemesi', 1, null, '', 0, null, 0   from CekHr 
inner join Cari on Cari.CariID = CekHr.CariID
where CekHr.SilindiMi = 0  and  EvrakTarihi > DATEADD( day,-30, GETDATE()) 


union 
select SiparisID, Siparis.CariTanim, '', SiparisTarihi, Siparis.TeslimTarihi, SiparisTipi, null, Siparis.TeslimTarihi, '' , 1, null, '', 0 , null, 0  from siparis
inner join Cari on Siparis.CariID = Cari.CariID where Siparis.SilindiMi = 0 and Siparis.TeslimTarihi > DATEADD( day,-30, GETDATE()) 
", Baglanti);
      da.SelectCommand.Transaction = Tr;

      dt_Takvim = new DataTable();


      da.Fill(dt_Takvim);
    }






    public int dt_Guncelle(SqlConnection Baglanti, SqlTransaction Tr, DataRow Dr)
    {
      SqlCommand cmdd = new SqlCommand("", Baglanti, Tr);
      if ((int)Dr["AjandaID"] != 0)
      {
        cmdd.CommandText = @"update Ajanda set 
Baslik = @Baslik, Yer = @Yer, StartTime = @StartTime, EndTime = @EndTime, Grup = @Grup, Kaynak = @Kaynak, 
Hatirlat = @Hatirlat, Aciklama = @Aciklama, ButunGun = @ButunGun, RecurrenceInfo = @RecurrenceInfo, ReminderInfo = @ReminderInfo, 
EventType = @EventType, KullaniciID = @KullaniciID, Status = @Status where AjandaID = @AjandaID";

        cmdd.Parameters.Add("@AjandaID", SqlDbType.Int).Value = Dr["AjandaID"];

      }
      else
      {

        cmdd.CommandText = @"insert into Ajanda 
      ( Baslik, Yer, StartTime, EndTime, Grup, Kaynak, Hatirlat, Aciklama, ButunGun, RecurrenceInfo, ReminderInfo, EventType, 
      KullaniciID, Status ) 
      values 
      (  @Baslik, @Yer, @StartTime, @EndTime, @Grup, @Kaynak, @Hatirlat, @Aciklama, @ButunGun, @RecurrenceInfo, @ReminderInfo, @EventType, 
      @KullaniciID, @Status ) set @YeniID = SCOPE_IDENTITY() ";

        cmdd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
      }

      cmdd.Parameters.Add("@Baslik", SqlDbType.NVarChar).Value = Dr["Baslik"];
      cmdd.Parameters.Add("@Yer", SqlDbType.NVarChar).Value = Dr["Yer"];
      cmdd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = Dr["StartTime"];
      cmdd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = Dr["EndTime"];
      cmdd.Parameters.Add("@Grup", SqlDbType.Int).Value = Dr["Grup"];

      cmdd.Parameters.Add("@Kaynak", SqlDbType.Int).Value = Dr["Kaynak"];
      cmdd.Parameters.Add("@Hatirlat", SqlDbType.DateTime).Value = DateTime.Now; // bu hatalı kullanılmayan bişi
      cmdd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Dr["Aciklama"];
      cmdd.Parameters.Add("@ButunGun", SqlDbType.Bit).Value = Dr["ButunGun"];
      cmdd.Parameters.Add("@RecurrenceInfo", SqlDbType.NVarChar).Value = Dr["RecurrenceInfo"];
      cmdd.Parameters.Add("@ReminderInfo", SqlDbType.NVarChar).Value = Dr["ReminderInfo"];
      cmdd.Parameters.Add("@EventType", SqlDbType.Int).Value = Dr["EventType"];
      cmdd.Parameters.Add("@KullaniciID", SqlDbType.Int).Value = Dr["KullaniciID"];
      cmdd.Parameters.Add("@Status", SqlDbType.Int).Value = Dr["Status"];

      cmdd.ExecuteNonQuery();
      if ((int)Dr["AjandaID"] == 0)
      {
        Dr["AjandaID"] = cmdd.Parameters["@YeniID"].Value;
      }
      return Convert.ToInt32(Dr["AjandaID"]);

    }

    public void Sil(SqlConnection Baglanti, SqlTransaction Tr, DataRow Dr)
    {
      SqlCommand cmdd = new SqlCommand("", Baglanti, Tr);

      cmdd.CommandText = "delete from Ajanda where AjandaID = @AjandaID";
      cmdd.Parameters.Add("@AjandaID", SqlDbType.Int).Value = Dr["AjandaID"];

      cmdd.ExecuteNonQuery();
    }


    public void getir_resourcesBS(SqlConnection baglanti, SqlTransaction Tr)
    {
      SqlDataAdapter daa = new SqlDataAdapter("SELECT * FROM resources", baglanti);
      daa.SelectCommand.Transaction = Tr;

      dt_resources = new DataTable();

      daa.Fill(dt_resources);
    }




  }
}
