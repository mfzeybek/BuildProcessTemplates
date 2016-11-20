using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Sayim
{
public   class csSayimKarsilastirma:IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
    public DataTable SayimKarsilastir(SqlConnection Baglanti, SqlTransaction Tr, int BirinciSayimID, int IkinciSayimID)
    {
      using (SqlDataAdapter da = new SqlDataAdapter(@"  select 
BirinciSayim.StokID, Stok.StokAdi, BirinciSayim.Miktar1 as BirinciSayimMiktari, 0 as IkinciSayimMiktari, 'Sadece İlk Sayimda Var' as Aciklama from sayimdetay as BirinciSayim
  inner join Stok on Stok.StokID = BirinciSayim.StokID
  where not EXISTS 
  (select SayimDetay.SayimDetayID from SayimDetay where SayimDetay.SayimID = @IkinciSayimID and BirinciSayim.StokID = SayimDetay.StokID) and BirinciSayim.SayimID = @BirinciSayimID
  union all
  select IkinciSayim.StokID, Stok.StokAdi, 0 ,IkinciSayim.Miktar1 as IkinciSayimMiktari , 'Sadece İkinci Sayimda Var' from sayimdetay as IkinciSayim
  inner join Stok on Stok.StokID = IkinciSayim.StokID
  where not EXISTS 
  (select SayimDetay.SayimDetayID from SayimDetay where SayimDetay.SayimID = @BirinciSayimID and IkinciSayim.StokID = SayimDetay.StokID) and IkinciSayim.SayimID = @IkinciSayimID
 
 union all
 
   select distinct SayimDetay.StokID, stok.StokAdi, SayimDetay.Miktar1, SayimDetay2.Miktar1, 'İki sayımdada var' from SayimDetay
inner join Stok on stok.StokID = SayimDetay.StokID
inner join SayimDetay as SayimDetay2 on SayimDetay.StokID = SayimDetay2.StokID 
where SayimDetay.SayimID = @BirinciSayimID and SayimDetay2.SayimID = @IkinciSayimID
order by StokID
", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        da.SelectCommand.Parameters.Add("@BirinciSayimID", SqlDbType.Int).Value = BirinciSayimID;
        da.SelectCommand.Parameters.Add("@IkinciSayimID", SqlDbType.Int).Value = IkinciSayimID;

        DataTable dt_SayimKarsilastirmasi = new DataTable();
        da.Fill(dt_SayimKarsilastirmasi);
        return dt_SayimKarsilastirmasi;
      }
    }

  }
}
