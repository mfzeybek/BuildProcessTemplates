using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace TeraziSatis
{
    public class csStokAramaIslemleri : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlCommand cmd;
        SqlDataReader dr;



        public class csTeraziStokButonGrupOzellikleri : IDisposable
        {
            public SimpleButton Btn { get; set; }
            public int StokButonGrupID { get; set; }
            public string KisayolTusu { get; set; }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }

        public List<csTeraziStokButonGrupOzellikleri> StokButonGruplariListesi;

        public void StokButonGruplariniGetir(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            using (cmd = new SqlCommand(@"select TeraziStokGrupTanimlari.TeraziStokGrupTanimID, TeraziStokGrupTanimlari.TeraziStokButonGrupTanimAdi
 from TeraziStokGruplariIliskileri
inner join TeraziStokGrupTanimlari on TeraziStokGrupTanimlari.TeraziStokGrupTanimID = TeraziStokGruplariIliskileri.TeraziStokGrupTanimID
where TeraziStokGruplariIliskileri.TeraziID = @TeraziID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@TeraziID", SqlDbType.Int).Value = TeraziID;

                using (dr = cmd.ExecuteReader())
                {
                    StokButonGruplariListesi = new List<csTeraziStokButonGrupOzellikleri>();
                    // burada birçok şey türetiliyor ve isimler birbirine yakın olduğu için karıştırılabiliyor düzgün bir açıklama lazım
                    int i = 0;
                    while (dr.Read())
                    {
                        DevExpress.XtraEditors.SimpleButton StokGrupButonu = new DevExpress.XtraEditors.SimpleButton();
                        StokGrupButonu.Text = dr["TeraziStokButonGrupTanimAdi"].ToString();
                        StokGrupButonu.Width = 100;
                        StokGrupButonu.Height = 100;

                        StokGrupButonu.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
                        
                        StokGrupButonu.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        StokGrupButonu.Appearance.Options.UseTextOptions = true;
                        StokGrupButonu.Tag = i;
                        i++;



                        csTeraziStokButonGrupOzellikleri StokGrupButonuOzellikhamisina = new csTeraziStokButonGrupOzellikleri();
                        StokGrupButonuOzellikhamisina.Btn = StokGrupButonu;
                        StokGrupButonuOzellikhamisina.KisayolTusu = ""; // buraya kisayol tuşu eklenecek veri tabanında oluşturulmadı sanırım daha
                        StokGrupButonuOzellikhamisina.StokButonGrupID = (int)dr["TeraziStokGrupTanimID"];


                        // ya stokbutonGrup mu?
                        // Stok Grup Buton mu ulan farklı isimlendirmeler yapmasana amk 2 tane beyin hücren ver 20 tane şey düşünüyorsun

                        StokButonGruplariListesi.Add(StokGrupButonuOzellikhamisina);


                    }
                }
            }
        }


        public class StokIDVeMiktar
        {
            public int StokID { get; set; }
            public decimal Miktar { get; set; }
        }
        public StokIDVeMiktar StokBarkodundanStokIDVer(SqlConnection Baglanti, SqlTransaction Tr, string Barkod)
            {
            using (SqlCommand cmd = new SqlCommand(@"
--declare @Barkod nvarchar(50) ,
declare 
@MiktarKacinciHanedenBasliyor tinyint,
@MiktarKacHane tinyint
 -- set @Barkod = '2600004000113' 

-- Hem ön eke hem barkodunda miktar varsa
-- yalnız programda şöyle bişi olması lazım
-- aynı ön eke sahip birden fazla barkod numar ası oluşturulmasını engellemeli
if (select  1 from BarkodAyar where OnEk = LEFT(@Barkod, 2)  and BarkodAyar.MiktarOlacakMi = 1 and len(@Barkod) = 13) = 1
  begin
      update BarkodAyar set @MiktarKacinciHanedenBasliyor = (2 + KacHaneKod + 1), @MiktarKacHane = KacHaneMiktar from BarkodAyar where OnEk = LEFT(@Barkod, 2)  and BarkodAyar.MiktarOlacakMi = 1
      select  
      convert(decimal(12,10),  -- decimal a çeviriyoruz
      (SUBSTRING(@Barkod, @MiktarKacinciHanedenBasliyor , 2)  -- ilk haneyi alıyoru<
      + '.' +  -- araya nokta koyuyoruz
      SUBSTRING(@Barkod, @MiktarKacinciHanedenBasliyor + 2 , @MiktarKacHane  - 2))) as Miktar-- virgülden sonraki haneleri alıyoruz
	  , StokBirimCevrim.StokID 
	  from StokBirimCevrim where StokBirimCevrim.Barkodu = (select SUBSTRING(@Barkod, 0, @MiktarKacinciHanedenBasliyor))
  end
else
      select 1 as Miktar, StokID from Stok
      where Stok.Barkod like @Barkod and Stok.Silindi = 0
      union all
      select StokBirimCevrim.KatSayi, StokID from StokBirimCevrim
      where StokBirimCevrim.Barkodu like @Barkod", Baglanti, Tr))
            {
                cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = Barkod;

                using (dr = cmd.ExecuteReader())
                {

                    StokIDVeMiktar IDveMiktar = new StokIDVeMiktar();

                    if (dr.Read())
                    {
                        IDveMiktar.StokID = (int)dr["StokID"];
                        IDveMiktar.Miktar = (decimal)dr["Miktar"];
                    }
                    else
                    {
                        IDveMiktar.StokID = -1;
                        IDveMiktar.Miktar = -1;
                    }
                    return IDveMiktar; // herbişeyi eksik hamısınaaaa
                }
            }
        }

        public class StokButonOzellikleri : IDisposable
        {
            public SimpleButton StokButonu { get; set; }
            public int StokID { get; set; }
            public string KisayolTusu { get; set; }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }

        public List<StokButonOzellikleri> StokButonlariListesi;

        // stoklari getirecek Butonlari Getiriyor yani hamısına TeraziID ye gerek yok
        public void StokButonlariniGetir(SqlConnection Baglanti, SqlTransaction Tr, int TeraziStokGrupTanimID)
        {
            cmd = new SqlCommand(@"select Stok.StokID, StokAdi, TeraziStokGruplari.SiraNu  from TeraziStokGruplari
inner join Stok on Stok.StokID = TeraziStokGruplari.StokID
where TeraziStokGruplari.TeraziStokGrupTanimID = @TeraziStokGrupTanimID", Baglanti, Tr);

            cmd.Parameters.Add("@TeraziStokGrupTanimID", SqlDbType.Int).Value = (Int32)TeraziStokGrupTanimID;

            using (dr = cmd.ExecuteReader())
            {

                StokButonlariListesi = new List<StokButonOzellikleri>();

                while (dr.Read())
                {
                    DevExpress.XtraEditors.SimpleButton StokButonu = new DevExpress.XtraEditors.SimpleButton();
                    StokButonu.Text = dr["StokAdi"].ToString(); // stok un adı;

                    //csStokButonlari class i simple butonu, buton adını, kısayol tuşunu bu klas tutuyor

                    StokButonOzellikleri Butonhamisina = new StokButonOzellikleri();
                    //Butonhamisina.StokID = (int)dr["StokID"];



                    Butonhamisina.StokID = (int)dr["StokID"]; // StokID
                    //Butonhamisina.KisayolTusu = dr["KisayolTusu"].ToString(); //StokButonlari un kisayoltusu
                    Butonhamisina.StokButonu = StokButonu; // Buda buton hamısına

                    StokButonlariListesi.Add(Butonhamisina);
                    StokButonu.Tag = StokButonlariListesi.Count - 1;// burada index atmış gibi bişi olduk
                    StokButonu.Height = 100;
                    StokButonu.Width = 100;
                    StokButonu.Appearance.Options.UseTextOptions = true;
                    StokButonu.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;

                    StokButonu.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    StokButonu.Appearance.Options.UseTextOptions = true;
                }
            }
        }

    }
}
