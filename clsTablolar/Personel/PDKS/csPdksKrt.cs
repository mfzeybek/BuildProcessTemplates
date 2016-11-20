using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel.PDKS
{
  public class csPdksKrt : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    //    CariID
    //PersonelID
    //PDKSsifre
    //CariTanim



    // sadece bu classın içinde kullanılacaklar

    private int _BirOncekiKaydinTurID;
    private int _SimdikiTurID;

    public int SimdikiTurID
    {
      get { return _SimdikiTurID; }
      set { _SimdikiTurID = value; }
    }


    private DateTime _Zaman1; // bunları kaydederken kullanıyorsun
    private DateTime _Zaman2; // bunları kaydederken kullanıyorsun




    private int _PdksHrID;
    private int _PersonelID;
    private int _CariID;
    private string _PDKSsifre;
    private string _CariTanim;
    private int _AciklamaID;
    private string _GosterilecekTurAdi;
    private string _GosterilecekAciklama;



    public int PdksHrID
    {
      get { return _PdksHrID; }
      set { _PdksHrID = value; }
    }
    public int PersonelID
    {
      get { return _PersonelID; }
      set { _PersonelID = value; }
    }
    public int CariID
    {
      get { return _CariID; }
      set { _CariID = value; }
    }
    public string PDKSsifre
    {
      get { return _PDKSsifre; }
      set { _PDKSsifre = value; }
    }
    public string CariTanim
    {
      get { return _CariTanim; }
      set { _CariTanim = value; }
    }
    public int AciklamaID
    {
      get { return _AciklamaID; }
      set { _AciklamaID = value; }
    }
    public string GosterilecekTurAdi
    {
      get { return _GosterilecekTurAdi; }
      set { _GosterilecekTurAdi = value; }
    }
    public string GosterilecekAciklama
    {
      get { return _GosterilecekAciklama; }
      set { _GosterilecekAciklama = value; }
    }



    public void PerosnelinGunlukHareketleriniGetir(SqlConnection Baglanti, SqlTransaction Tr, DateTime Tarih, int PerosnelID)
    {


    }

    SqlCommand cmd;
    SqlDataReader dr;

    public void SifredenBilgileriGetir(SqlConnection Baglanti, SqlTransaction Tr, string Sifre)
    {
      // burası hareket kaydı olmasa bile personelin bilgilerini getirmesi gerekiyor
      using (cmd = new SqlCommand(@"select Personel.* , Cari.CariTanim from Personel
inner join Cari on Cari.CariID =  Personel.CariID where PDKSsifre = @PDKSsifre", Baglanti, Tr))
      {
        cmd.Parameters.Add("@PDKSsifre", SqlDbType.NVarChar).Value = Sifre;
        using (dr = cmd.ExecuteReader())
        {
          if (dr.Read())
          {
            _PersonelID = int.Parse(dr["PersonelID"].ToString());
            _CariID = int.Parse(dr["CariID"].ToString());
            _PDKSsifre = dr["PDKSsifre"].ToString();
            _CariTanim = dr["CariTanim"].ToString();
            //_Zaman1 = Convert.ToDateTime(dr["Zaman1"]);
            //_BirOncekiKaydinTurID = Convert.ToInt32(dr["TurID"]);
          }
          else
          {
            _PersonelID = -1;
            _CariID = -1;
            _PDKSsifre = "";
            _CariTanim = "Böyle bir kayıt yok";
            return;
          }
        }
        HareketiniGetir(Baglanti, Tr, Sifre); // eğer kayıt varsa hareketlerini gözlemlemek için hareketlerini getir
      }
    }

    public void HareketiniGetir(SqlConnection Baglanti, SqlTransaction Tr, string Sifre)
    {
      // bu sql son hareketi getirir son hareket bulamazsa günün ilk kaydıdır
      using (cmd = new SqlCommand(@"select top 1 Zaman1, PdksHrID ,PdksHr.TurID, AciklamaID, Aciklama from PdksHr
      inner join Personel on Personel.PersonelID = PdksHr.PersonelID
      left join  PDKSAciklama on PDKSAciklamaID = PdksHr.AciklamaID
      where Zaman1 between @ZamanIlk and @ZamanSon
      and Personel.PDKSsifre = @PDKSsifre 
      order by Zaman1 desc ", Baglanti, Tr))
      {
        cmd.Parameters.Add("@ZamanIlk", SqlDbType.DateTime).Value = DateTime.Today;
        cmd.Parameters.Add("@ZamanSon", SqlDbType.DateTime).Value = DateTime.Now;

        cmd.Parameters.Add("@PDKSsifre", SqlDbType.Int).Value = Sifre;

        using (dr = cmd.ExecuteReader())
        {
          if (dr.Read()) // bu okunursa kayıt var okunmazsa kayıt yok , kayıt yoksa günün ilk kaydı nın yapılması lazım
          {
            _BirOncekiKaydinTurID = Convert.ToInt32(dr["TurID"]);
            if (_BirOncekiKaydinTurID == 1 || _BirOncekiKaydinTurID == 3) // gelen tür ID 1 ise daha önce mesai başlangıcı yapmış şimdi çıkıcak demektir.
            {// gelen tür ID 3 ise en son giriş yapmış yani gene çıkış yapacak demektir
              _GosterilecekTurAdi = "Çıkış";
              _Zaman1 = DateTime.Now; // zaman 1 e şimdiki zamanı veriyoruz
              _Zaman2 = DateTime.MinValue; // zaman iki yi ise aslında kaydetmicez
              _SimdikiTurID = 2; // çıkış tür IDsini verdik
            }
            else if (_BirOncekiKaydinTurID == 2) // Daha önce çıkmış şimdi girişi yapıyor
            {
              SimdikiTurID = 3;
              _GosterilecekTurAdi = "Giriş";
              _Zaman2 = DateTime.Now;
              _GosterilecekAciklama = dr["Aciklama"].ToString();
            }
            _PdksHrID = Convert.ToInt32(dr["PdksHrID"]);
          }
          else // günün ilk kaydıysa mesai başlangıcı
          {
            _Zaman1 = DateTime.Now;

            //_BirOncekiKaydinTurID = -1; // Mesai Başlangıcı
            SimdikiTurID = 1; // Mesai Başlangıcı
            _GosterilecekTurAdi = "Mesai Başlangıcı";
          }
        }
      }
    }


    DataTable dt_Aciklama;
    SqlDataAdapter da;




    public DataTable AciklamalariGetir(SqlConnection Baglanti, SqlTransaction Tr)
    {
      if (SimdikiTurID == 1 || SimdikiTurID == 3) // eğer mesai başlangıcı ise açıklama getirmesine gerek yok
      {
        using (da = new SqlDataAdapter("select PDKSAciklamaID, Aciklama, AciklamaUzun from PDKSAciklama where 1 = 2", Baglanti))
        {
          da.SelectCommand.Transaction = Tr;

          using (dt_Aciklama = new DataTable())
          {
            da.Fill(dt_Aciklama);
            return dt_Aciklama;
          }
        }
      }
      else
      {
        using (da = new SqlDataAdapter("select PDKSAciklamaID, Aciklama, AciklamaUzun from PDKSAciklama", Baglanti))
        {
          da.SelectCommand.Transaction = Tr;

          using (dt_Aciklama = new DataTable())
          {
            da.Fill(dt_Aciklama);
            return dt_Aciklama;
          }
        }
      }
    }

    public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
    {
      if (_CariTanim == "Böyle bir kayıt yok") { return; }
      // 1 önceki kayıt mesai başlangıcıydı
      // 3 önceki kayıt giriş ti
      if (SimdikiTurID == 1 || SimdikiTurID == 2)// mesai başlangıcı veya giriş ise yeni kayıt , yani çıkış yapılacak bu sefer
      {
        using (cmd = new SqlCommand(@"insert into PdksHr 
      (  PersonelID, Zaman1, AciklamaID, TurID) values 
      (  @PersonelID, @Zaman1, @AciklamaID, @TurID ) ", Baglanti, Tr))
        {
          cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = _PersonelID;
          cmd.Parameters.Add("@Zaman1", SqlDbType.DateTime).Value = _Zaman1;

          if (SimdikiTurID == 1) // mesai Başlangıcı açıklama ID yi -1 olarak kaydetsin
            cmd.Parameters.Add("@AciklamaID", SqlDbType.Int).Value = -1;
          else
            cmd.Parameters.Add("@AciklamaID", SqlDbType.Int).Value = _AciklamaID;

          cmd.Parameters.Add("@TurID", SqlDbType.Int).Value = SimdikiTurID;
          cmd.ExecuteNonQuery();
        }
      }
      else if (SimdikiTurID == 3) // çıkış ise girişi update edecek
      {
        using (cmd = new SqlCommand("update PdksHr set Zaman2 = @Zaman2, TurID = @TurID where PdksHrID = @PdksHrID", Baglanti, Tr))
        {
          cmd.Parameters.Add("@Zaman2", SqlDbType.DateTime).Value = _Zaman2;
          cmd.Parameters.Add("@PdksHrID", SqlDbType.Int).Value = _PdksHrID;
          cmd.Parameters.Add("@TurID", SqlDbType.Int).Value = SimdikiTurID;

          cmd.ExecuteNonQuery();
        }
      }





    }
    DataTable dt_HareketListesi;
    DataTable Dt_KimNerede;

    /// <summary>
    /// Şifresi Verilen Hareketleri Getirir
    /// </summary>
    /// <param name="Baglanti"></param>
    /// <param name="Tr"></param>
    /// <param name="Sifre"></param>
    /// <returns></returns>
    public DataTable HareketleriniGetir(SqlConnection Baglanti, SqlTransaction Tr, string Sifre)
    {
      using (da = new SqlDataAdapter(@"select Cari.CariTanim, PdksHr.Zaman1, PdksHr.Zaman2 , 
datediff(minute, PdksHr.Zaman1, isnull(PdksHr.Zaman2, PdksHr.Zaman1)) as 'Fark (dk)',
 PDKSAciklama.Aciklama, 
 case PdksHr.TurID 
 when 1 then 'Mesai Başlangıcı'
 when 2 then 'Çıkış - Daha Gelmedi'
 when 3 then 'Çıkış - Giriş'
 end as 'Turu'
 from PdksHr
inner join Personel on Personel.PersonelID = PdksHr.PersonelID
inner join Cari on Cari.CariID = Personel.CariID
left join PDKSAciklama on PDKSAciklama.PDKSAciklamaID = PdksHr.AciklamaID
where Personel.PDKSsifre = @PDKSsifre and
Zaman1 between @ZamanIlk and @ZamanSon
order by Zaman1 desc", Baglanti))
      {
        da.SelectCommand.Parameters.Add("@PDKSsifre", SqlDbType.NVarChar).Value = Sifre;
        da.SelectCommand.Parameters.Add("@ZamanIlk", SqlDbType.DateTime).Value = DateTime.Today;
        da.SelectCommand.Parameters.Add("@ZamanSon", SqlDbType.DateTime).Value = DateTime.Now;

        da.SelectCommand.Transaction = Tr;
        using (dt_HareketListesi = new DataTable())
        {
          da.Fill(dt_HareketListesi);
          return dt_HareketListesi;
        }
      }
    }

    /// <summary>
    /// Bütün Hareketleri Getirir
    /// </summary>
    /// <param name="Baglanti"></param>
    /// <param name="Tr"></param>
    /// <returns></returns>
    public DataTable HareketleriniGetir(SqlConnection Baglanti, SqlTransaction Tr)
    {
        using (da = new SqlDataAdapter(@"select * ,
case 
when tur = 1 then 'Mesai Başlangıcı'
when tur = 2 then 'Giriş'
when tur = 3 then 'Çıkış'
end as TurAdi
from Hareketler
inner join personel on Personel.PersonelID = Hareketler.PersonelID
left join Yerler on Yerler.YerID = Hareketler.YerID
where 
Hareketler.Zaman between CONVERT(DATETIME, CONVERT(VARCHAR, GETDATE(), 101)) and getdate()
order by zaman desc", Baglanti))
      {

        da.SelectCommand.Transaction = Tr;
        using (dt_HareketListesi = new DataTable())
        {
          da.Fill(dt_HareketListesi);
          return dt_HareketListesi;
        }
      }
    }


    public DataTable Nerede(SqlConnection Baglanti, SqlTransaction Tr) // bunun sql i artık tamamen yanlış
    {
      try
      {
        // burada ki sqlde kullanılan isnull 
        // datediff çıkarma yaparken bi zaman 2 boş olabiliryor boş olduğu zaman da hata veriyor
        using (da = new SqlDataAdapter(@"select Cari.CariTanim, --PdksHr.TurID,
sum (datediff(minute, PdksHr.Zaman1, isnull(PdksHr.Zaman2, PdksHr.Zaman1))) as 'Toplam dk', 
case convert(nvarchar(50),(isnull((select Top 1 TurID from pdksHr as pdksHrTur 
where TurID = 2 and PdksHr.PersonelID = pdksHrTur.PersonelID 
and pdksHrTur.zaman1 between @ZamanIlk and @ZamanSon
order by pdksHrTur.Zaman1 desc), '0')), 0)
when '2' then 
(select Aciklama from pdksHr as pdksHrTur 
left join PDKSAciklama on PDKSAciklama.PDKSAciklamaID = pdksHrTur.AciklamaID
where pdksHrTur.TurID = 2 and PdksHr.PersonelID = pdksHrTur.PersonelID
and pdksHrTur.zaman1 between @ZamanIlk and @ZamanSon) -- her personelin o an için sadece bir tane 2 olan tur ID si olabilir
when '0' then 'Mağazada'
end As nerede
from PdksHr
inner join Personel on Personel.PersonelID = PdksHr.PersonelID
inner join Cari on Cari.CariID = Personel.CariID
left join PDKSAciklama on PDKSAciklama.PDKSAciklamaID = PdksHr.AciklamaID
where PdksHr.Zaman1 between @ZamanIlk and @ZamanSon
group by Cari.CariTanim, PdksHr.PersonelID", Baglanti))
        {
          da.SelectCommand.Parameters.Add("@ZamanIlk", SqlDbType.DateTime).Value = DateTime.Today;
          da.SelectCommand.Parameters.Add("@ZamanSon", SqlDbType.DateTime).Value = DateTime.Now;
          da.SelectCommand.Transaction = Tr;

          using (Dt_KimNerede = new DataTable())
          {
            da.Fill(Dt_KimNerede);

            return Dt_KimNerede;
          }
        }
      }
      catch (Exception)
      {
        return Dt_KimNerede;
      }
    }
  }
}

