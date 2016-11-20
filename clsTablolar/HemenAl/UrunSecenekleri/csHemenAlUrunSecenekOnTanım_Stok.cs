using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace clsTablolar.HemenAl.UrunSecenekleri
{
  public class csHemenAlUrunSecenekOnTanım_Stok : IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public DataTable dt;
    SqlDataAdapter da;


    public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      using (da = new SqlDataAdapter(@"select HemenAlUrunSecenekOnTanimDetaylari.HemenAlUrunSecenekOnTanimID , Sira, SecenekGrubu, SatirSecenek, SutunSecenek, Kavala, SatisFiyatiHesaplamaSayisi, StokMiktar,
GoruntulemeSekli = case GoruntulemeSekli
when 0 then 'ListBox'
when 1 then 'option box'
when 2 then 'matris'
end, 
StokKontrol = case StokKontrol
when 0 then 'Yapılmaz'
when 1 then 'Yapılır'
end, UrunFiyatiYerineGecsin = case UrunFiyatiYerineGecsin
when 0 then 'İlave et'
when 1 then 'Yerine Geçsin'
end, SeciliGelsin = case SeciliGelsin
when 0 then 'Seçili Gelmesin'
when 1 then 'Seçili Gelsin'
end, SecimZorunlu = case SecimZorunlu
when 0 then 'Zorunlu değil'
when 1 then 'Zorunlu'
end, SecenekAktif = case SecenekAktif
when 0 then 'Pasif'
when 1 then 'Aktif'
end, 'Satis Fiyati' = case SatisFiyatiHesaplamaIslemi
when 1 then  'Topla' --((SonkullanicFiyati.Fiyat + SatisFiyatiHesaplamaSayisi)/((100 + Stok.SatisKdv) / 100))
when 2 then  'Çıkar' --((SonkullanicFiyati.Fiyat + SatisFiyatiHesaplamaSayisi)/((100 + Stok.SatisKdv) / 100))
when 3 then  'Çarp' --((SonkullanicFiyati.Fiyat + SatisFiyatiHesaplamaSayisi)/((100 + Stok.SatisKdv) / 100))
when 4 then  'Böl' --((SonkullanicFiyati.Fiyat + SatisFiyatiHesaplamaSayisi)/((100 + Stok.SatisKdv) / 100))
end from HemenAlUrunSecenekOnTanimDetaylari
inner join HemenAlUrunSecenekOnTanım_Stok on HemenAlUrunSecenekOnTanım_Stok.HemenAlUrunSecenekOnTanimID = HemenAlUrunSecenekOnTanimDetaylari.HemenAlUrunSecenekOnTanimID



where HemenAlUrunSecenekOnTanım_Stok.StokID = @StokID", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        using ( dt = new DataTable())
        {
          da.Fill(dt);
        }
      }
    }
    
    public void Guncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      try
      {
        da.InsertCommand = new SqlCommand(@"insert into HemenAlUrunSecenekOnTanım_Stok 
( StokID, HemenAlUrunSecenekOnTanimID ) 
values 
( @StokID, @HemenAlUrunSecenekOnTanimID ) ", Baglanti, Tr);

        da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        da.InsertCommand.Parameters.Add("@HemenAlUrunSecenekOnTanimID", SqlDbType.Int, 0, "HemenAlUrunSecenekOnTanimID");

        da.UpdateCommand = new SqlCommand(@"update HemenAlUrunSecenekOnTanım_Stok set StokID = @StokID, 
HemenAlUrunSecenekOnTanimID = @HemenAlUrunSecenekOnTanimID where HemenAlUrunSecenekOnTanım_StokID = @HemenAlUrunSecenekOnTanım_StokID", Baglanti, Tr);
        da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
        da.UpdateCommand.Parameters.Add("@HemenAlUrunSecenekOnTanimID", SqlDbType.Int, 0, "HemenAlUrunSecenekOnTanimID");
        da.UpdateCommand.Parameters.Add("@HemenAlUrunSecenekOnTanım_StokID", SqlDbType.Int, 0, "HemenAlUrunSecenekOnTanım_StokID");

        da.DeleteCommand = new SqlCommand(@"delete  from HemenAlUrunSecenekOnTanım_Stok where HemenAlUrunSecenekOnTanım_StokID = @HemenAlUrunSecenekOnTanım_StokID", Baglanti, Tr);
        da.DeleteCommand.Parameters.Add("@HemenAlUrunSecenekOnTanım_StokID", SqlDbType.Int, 0, "HemenAlUrunSecenekOnTanım_StokID");

        da.Update(dt);                                           
      }
      catch (Exception)
      {
        
      }
      
    }


  }
}
