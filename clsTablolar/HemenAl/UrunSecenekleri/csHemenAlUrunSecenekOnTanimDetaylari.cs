using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.HemenAl.UrunSecenekleri
{
public   class csHemenAlUrunSecenekOnTanimDetaylari:IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    DataTable dt_SecenekDetaylari;
    SqlDataAdapter da;

    public DataTable DetaylariGetir(SqlConnection Baglanti, SqlTransaction Tr, int HemenAlUrunSecenekOnTanimID)
    {
      try
      {
        da = new SqlDataAdapter("select * from HemenAlUrunSecenekOnTanimDetaylari where HemenAlUrunSecenekOnTanimID = @HemenAlUrunSecenekOnTanimID", Baglanti);
        da.SelectCommand.Transaction = Tr;

        da.SelectCommand.Parameters.Add("@HemenAlUrunSecenekOnTanimID", SqlDbType.Int).Value = HemenAlUrunSecenekOnTanimID;

        dt_SecenekDetaylari = new DataTable();
        da.Fill(dt_SecenekDetaylari);

        return dt_SecenekDetaylari;
      }
      catch (Exception)
      {
        
        throw;
      }


    }
    //SatisFiyatiHesaplamaIslemi  ==>  1 Topla, 2 Çıkar, 3 Çarp, 4 Böl

    public void Guncelle(SqlConnection Baglanti, SqlTransaction Tr, int HemenAlUrunSecenekOnTanimID)
    {
      da.InsertCommand = new SqlCommand(@"insert into HemenAlUrunSecenekOnTanimDetaylari
(HemenAlUrunSecenekOnTanimID, SecenekGrubu, SatirSecenek, SutunSecenek, Kavala, Sira, SatisFiyatiHesaplamaIslemi,
SatisFiyatiHesaplamaSayisi, SatisFiyat, StokMiktar, GoruntulemeSekli, StokKontrol, UrunFiyatiYerineGecsin, SeciliGelsin, 
SecimZorunlu, SecenekAktif, Aciklama ) 
values 
( @HemenAlUrunSecenekOnTanimID, @SecenekGrubu, @SatirSecenek, @SutunSecenek, @Kavala, @Sira, @SatisFiyatiHesaplamaIslemi,
@SatisFiyatiHesaplamaSayisi, @SatisFiyat, @StokMiktar, @GoruntulemeSekli, @StokKontrol, @UrunFiyatiYerineGecsin, @SeciliGelsin, 
@SecimZorunlu, @SecenekAktif, @Aciklama ) ", Baglanti, Tr);

      da.InsertCommand.Parameters.Add("@HemenAlUrunSecenekOnTanimID", SqlDbType.Int).Value = HemenAlUrunSecenekOnTanimID;
      da.InsertCommand.Parameters.Add("@SecenekGrubu", SqlDbType.NVarChar, 50, "SecenekGrubu");
      da.InsertCommand.Parameters.Add("@SatirSecenek", SqlDbType.NVarChar, 50, "SatirSecenek");
      da.InsertCommand.Parameters.Add("@SutunSecenek", SqlDbType.NVarChar, 50, "SutunSecenek");
      da.InsertCommand.Parameters.Add("@Kavala", SqlDbType.NVarChar, 50, "Kavala");
      da.InsertCommand.Parameters.Add("@Sira", SqlDbType.Int, 0, "Sira");

      da.InsertCommand.Parameters.Add("@SatisFiyatiHesaplamaIslemi", SqlDbType.TinyInt, 0, "SatisFiyatiHesaplamaIslemi");

      da.InsertCommand.Parameters.Add("@SatisFiyatiHesaplamaSayisi", SqlDbType.Decimal, 0, "SatisFiyatiHesaplamaSayisi");
      da.InsertCommand.Parameters.Add("@SatisFiyat", SqlDbType.Decimal, 0, "SatisFiyat");

      da.InsertCommand.Parameters.Add("@StokMiktar", SqlDbType.Int, 0, "StokMiktar");
      da.InsertCommand.Parameters.Add("@GoruntulemeSekli", SqlDbType.Int, 0, "GoruntulemeSekli");
      da.InsertCommand.Parameters.Add("@StokKontrol", SqlDbType.Int, 0, "StokKontrol");
      da.InsertCommand.Parameters.Add("@UrunFiyatiYerineGecsin", SqlDbType.Int, 0, "UrunFiyatiYerineGecsin");
      da.InsertCommand.Parameters.Add("@SeciliGelsin", SqlDbType.Int, 0, "SeciliGelsin");

      da.InsertCommand.Parameters.Add("@SecimZorunlu", SqlDbType.Int, 0, "SecimZorunlu");

      da.InsertCommand.Parameters.Add("@SecenekAktif", SqlDbType.Int, 0, "SecenekAktif");
      da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 250, "Aciklama");

      da.UpdateCommand = new SqlCommand(@"update HemenAlUrunSecenekOnTanimDetaylari set 
      HemenAlUrunSecenekOnTanimID = @HemenAlUrunSecenekOnTanimID, 
SecenekGrubu = @SecenekGrubu, SatirSecenek = @SatirSecenek, SutunSecenek = @SutunSecenek, Kavala = @Kavala, Sira = @Sira, 
SatisFiyatiHesaplamaIslemi = @SatisFiyatiHesaplamaIslemi ,
SatisFiyatiHesaplamaSayisi = @SatisFiyatiHesaplamaSayisi, SatisFiyat = @SatisFiyat, StokMiktar = @StokMiktar, 
GoruntulemeSekli = @GoruntulemeSekli, StokKontrol = @StokKontrol, UrunFiyatiYerineGecsin = @UrunFiyatiYerineGecsin, 
SeciliGelsin = @SeciliGelsin, SecimZorunlu = @SecimZorunlu, SecenekAktif = @SecenekAktif, Aciklama = @Aciklama where HemenAlUrunSecenekOnTanimDetayID = @HemenAlUrunSecenekOnTanimDetayID ", Baglanti, Tr);

      da.UpdateCommand.Parameters.Add("@HemenAlUrunSecenekOnTanimDetayID", SqlDbType.Int, 0, "HemenAlUrunSecenekOnTanimDetayID");

      da.UpdateCommand.Parameters.Add("@HemenAlUrunSecenekOnTanimID", SqlDbType.Int).Value = HemenAlUrunSecenekOnTanimID;
      da.UpdateCommand.Parameters.Add("@SecenekGrubu", SqlDbType.NVarChar, 50, "SecenekGrubu");
      da.UpdateCommand.Parameters.Add("@SatirSecenek", SqlDbType.NVarChar, 50, "SatirSecenek");
      da.UpdateCommand.Parameters.Add("@SutunSecenek", SqlDbType.NVarChar, 50, "SutunSecenek");
      da.UpdateCommand.Parameters.Add("@Kavala", SqlDbType.NVarChar, 50, "Kavala");
      da.UpdateCommand.Parameters.Add("@Sira", SqlDbType.Int, 0, "Sira");

      da.UpdateCommand.Parameters.Add("@SatisFiyatiHesaplamaIslemi", SqlDbType.TinyInt, 0, "SatisFiyatiHesaplamaIslemi");

      da.UpdateCommand.Parameters.Add("@SatisFiyatiHesaplamaSayisi", SqlDbType.Decimal, 0, "SatisFiyatiHesaplamaSayisi");
      da.UpdateCommand.Parameters.Add("@SatisFiyat", SqlDbType.Decimal, 0, "SatisFiyat");

      da.UpdateCommand.Parameters.Add("@StokMiktar", SqlDbType.Int, 0, "StokMiktar");
      da.UpdateCommand.Parameters.Add("@GoruntulemeSekli", SqlDbType.Int, 0, "GoruntulemeSekli");
      da.UpdateCommand.Parameters.Add("@StokKontrol", SqlDbType.Int, 0, "StokKontrol");
      da.UpdateCommand.Parameters.Add("@UrunFiyatiYerineGecsin", SqlDbType.Int, 0, "UrunFiyatiYerineGecsin");
      da.UpdateCommand.Parameters.Add("@SeciliGelsin", SqlDbType.Int, 0, "SeciliGelsin");
      da.UpdateCommand.Parameters.Add("@SecimZorunlu", SqlDbType.Int, 0, "SecimZorunlu");
      da.UpdateCommand.Parameters.Add("@SecenekAktif", SqlDbType.Int, 0, "SecenekAktif");
      da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 250, "Aciklama");

      da.DeleteCommand = new SqlCommand("delete from HemenAlUrunSecenekOnTanimDetaylari where HemenAlUrunSecenekOnTanimDetayID = @HemenAlUrunSecenekOnTanimDetayID", Baglanti, Tr);
      da.DeleteCommand.Parameters.Add("@HemenAlUrunSecenekOnTanimDetayID", SqlDbType.Int, 0, "HemenAlUrunSecenekOnTanimDetayID");

      da.Update(dt_SecenekDetaylari);
    }

    public DataTable SatisFiyatiHesaplamaIslemi()
    {
      DataTable dt_SatisFiyatiHesaplamaIslemi = new DataTable();

      dt_SatisFiyatiHesaplamaIslemi.Columns.Add("SatisFiyatiHesaplamaIslemiKodu");
      dt_SatisFiyatiHesaplamaIslemi.Columns.Add("SatisFiyatiHesaplamaIslemiAdi");
      dt_SatisFiyatiHesaplamaIslemi.Rows.Add(dt_SatisFiyatiHesaplamaIslemi.NewRow());
      dt_SatisFiyatiHesaplamaIslemi.Rows.Add(dt_SatisFiyatiHesaplamaIslemi.NewRow());
      dt_SatisFiyatiHesaplamaIslemi.Rows.Add(dt_SatisFiyatiHesaplamaIslemi.NewRow());
      dt_SatisFiyatiHesaplamaIslemi.Rows.Add(dt_SatisFiyatiHesaplamaIslemi.NewRow());


      dt_SatisFiyatiHesaplamaIslemi.Rows[0]["SatisFiyatiHesaplamaIslemiKodu"] = "1";
      dt_SatisFiyatiHesaplamaIslemi.Rows[0]["SatisFiyatiHesaplamaIslemiAdi"] = "Topla";

      dt_SatisFiyatiHesaplamaIslemi.Rows[1]["SatisFiyatiHesaplamaIslemiKodu"] = "2";
      dt_SatisFiyatiHesaplamaIslemi.Rows[1]["SatisFiyatiHesaplamaIslemiAdi"] = "Çıkar";

      dt_SatisFiyatiHesaplamaIslemi.Rows[2]["SatisFiyatiHesaplamaIslemiKodu"] = "3";
      dt_SatisFiyatiHesaplamaIslemi.Rows[2]["SatisFiyatiHesaplamaIslemiAdi"] = "Çarp";

      dt_SatisFiyatiHesaplamaIslemi.Rows[3]["SatisFiyatiHesaplamaIslemiKodu"] = "4";
      dt_SatisFiyatiHesaplamaIslemi.Rows[3]["SatisFiyatiHesaplamaIslemiAdi"] = "Böl";
      

      return dt_SatisFiyatiHesaplamaIslemi;
    }

    /// <summary>
    /// GoruntulemeSekli -> 0 ListBox halindedir. 1 ise option box 2 ise matris olarak görüntülenir.
    /// </summary>
    /// <returns></returns>
    public DataTable GoruntulemeSekli()
    {
      DataTable dt_goruntulenmeSekli = new DataTable();

      dt_goruntulenmeSekli.Columns.Add("GoruntulemeSekliKodu");
      dt_goruntulenmeSekli.Columns.Add("GoruntulemeSekliAdi");
      dt_goruntulenmeSekli.Rows.Add(dt_goruntulenmeSekli.NewRow());
      dt_goruntulenmeSekli.Rows.Add(dt_goruntulenmeSekli.NewRow());
      dt_goruntulenmeSekli.Rows.Add(dt_goruntulenmeSekli.NewRow());


      dt_goruntulenmeSekli.Rows[0]["GoruntulemeSekliKodu"] = "0";
      dt_goruntulenmeSekli.Rows[0]["GoruntulemeSekliAdi"] = "ListBox";

      dt_goruntulenmeSekli.Rows[1]["GoruntulemeSekliKodu"] = "1";
      dt_goruntulenmeSekli.Rows[1]["GoruntulemeSekliAdi"] = "option box";

      dt_goruntulenmeSekli.Rows[2]["GoruntulemeSekliKodu"] = "2";
      dt_goruntulenmeSekli.Rows[2]["GoruntulemeSekliAdi"] = "matris";

      return dt_goruntulenmeSekli;
    }

    /// <summary>
    /// StokKontrol -> 0 ise stok kontrolü yapılmaz 1 ise stok kontrolü yapılır bitmiş ise listede gösterilmez.
    /// </summary>
    /// <returns></returns>
    public DataTable StokKontrol()
    {
      DataTable dt_StokKontrol = new DataTable();

      dt_StokKontrol.Columns.Add("StokKontrolKodu");
      dt_StokKontrol.Columns.Add("StokKontrolAdi");
      dt_StokKontrol.Rows.Add(dt_StokKontrol.NewRow());
      dt_StokKontrol.Rows.Add(dt_StokKontrol.NewRow());


      dt_StokKontrol.Rows[0]["StokKontrolKodu"] = "0";
      dt_StokKontrol.Rows[0]["StokKontrolAdi"] = "stok kontrolü yapılmaz";

      dt_StokKontrol.Rows[1]["StokKontrolKodu"] = "1";
      dt_StokKontrol.Rows[1]["StokKontrolAdi"] = "stok kontrolü yapılır";

      return dt_StokKontrol;
    }

    /// <summary>
    /// UrunFiyatiYerineGecsin -> 0 ise buradaki fiyat ürünün  fiyatına ilave edilir 1 ise ürünün fiyatı yerine geçer.
    /// </summary>
    /// <returns></returns>
    public DataTable UrunFiyatiYerineGecsin()
    {
      DataTable dt = new DataTable();

      dt.Columns.Add("UrunFiyatiYerineGecsinKodu");
      dt.Columns.Add("UrunFiyatiYerineGecsinAdi");
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["UrunFiyatiYerineGecsinKodu"] = "0";
      dt.Rows[0]["UrunFiyatiYerineGecsinAdi"] = "Ürün Fiyatına İlava Et";

      dt.Rows[1]["UrunFiyatiYerineGecsinKodu"] = "1";
      dt.Rows[1]["UrunFiyatiYerineGecsinAdi"] = "Ürün Fiyatının Yerine Geçsin";

      return dt;
    }

    /// <summary>
    /// SeciliGelsin -> 1 ise default bu seçenek seçili olarak gelir.
    /// </summary>
    /// <returns></returns>
    public DataTable SeciliGelsin()
    {
      DataTable dt = new DataTable();

      dt.Columns.Add("SeciliGelsinKodu");
      dt.Columns.Add("SeciliGelsinAdi");
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["SeciliGelsinKodu"] = "0";
      dt.Rows[0]["SeciliGelsinAdi"] = "Seçili Gelmesin";

      dt.Rows[1]["SeciliGelsinKodu"] = "1";
      dt.Rows[1]["SeciliGelsinAdi"] = "Seçili Gelsin";

      return dt;

    }

    /// <summary>
    ///SecimZorunlu -> 1 ise bu gruptaki seçeneklerden bir tanesinin seçimini zorunlu hale getirilir seçilmeden sepete eklenemez. 
    /// </summary>
    /// <returns></returns>
    public DataTable SecimZorunlu()
    {
      DataTable dt = new DataTable();

      dt.Columns.Add("SecimZorunluKodu");
      dt.Columns.Add("SecimZorunluAdi");
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["SecimZorunluKodu"] = "1";
      dt.Rows[0]["SecimZorunluAdi"] = "seçim zorunlu";

      dt.Rows[1]["SecimZorunluKodu"] = "0";
      dt.Rows[1]["SecimZorunluAdi"] = "seçim zorunlu değil";

      return dt;

    }

    /// <summary>
    /// SecenekAktif -> 1 ise seçenek aktif 0 ise seçenek pasiftir.
    /// </summary>
    /// <returns></returns>
    public DataTable SecenekAktif()
    {
      DataTable dt = new DataTable();

      dt.Columns.Add("SecenekAktifKodu");
      dt.Columns.Add("SecenekAktifAdi");
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["SecenekAktifKodu"] = "1";
      dt.Rows[0]["SecenekAktifAdi"] = "Aktif";

      dt.Rows[1]["SecenekAktifKodu"] = "0";
      dt.Rows[1]["SecenekAktifAdi"] = "Pasif";

      return dt;
    }
  }
}

