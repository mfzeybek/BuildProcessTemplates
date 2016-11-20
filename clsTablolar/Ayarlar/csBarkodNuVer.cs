using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Ayarlar
{
    public class csBarkodNuVer : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public int BarkodAyarID;
        public int OnEk;
        public csBarkodTipleri.BarkodTipleri BarkodTipi;
        public bool KontrolNoOlsunMu;
        public bool MiktarOlacakMi;
        public Int16 KacHaneMiktar;
        public Int16 KacHaneKod;
        public string Aciklama;
        public Int16 ToplamKarakterSayisi;
        public int SiradakiKod;

        /* Numara nasıl verili Bununla ilgili bir numara verme protololü hazırla numara verilmesi gereken her yere bunu koy

         * 
         * 
         */


        // Eğer konrol numarası olacaksa
        // OnEk + KacHaneKod + KontrolNumarasi = ToplamKarakterSayisi;

        // 

        // Eğer miktarlı bir barkod numarası tanımlanıyorsa kontrolnumarası eklenmeyecek
        //

        // barkod kontrol numarası nasıl hesaplanır

        // 1. Sağdan başlayarak ilk hane tek olmak üzere tüm haneler tek çift diye ayrılır.
        // 2. Tek hanedeki sayılar toplanır ve 3 ile çarpılır
        // 3. Çift hanedeki sayılar toplanır
        // 4. Her iki toplam toplanır ve 10 sayısının katına ulaşmak için gerekli sayı kontrol numarasıdır.

        public string SadeceNumaraverAMK()
        {
            string numara = SiradakiKod.ToString();

            for (int i = 0; i < KacHaneKod - SiradakiKod.ToString().Length; i++)
            {
                numara = "0" + numara;
            }
            numara = OnEk + numara;

            if (KontrolNoOlsunMu == true)
            {

                int Tekler = 0;
                int Ciftler = 0;
                int KontrolNu = 0;
                for (int i = 1; i <= numara.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Ciftler += Convert.ToInt32(numara[numara.Length - i].ToString());
                    }
                    else
                    {
                        Tekler += Convert.ToInt32(numara[numara.Length - i].ToString());
                    }
                }
                KontrolNu = 10 - (((Tekler * 3) + Ciftler) % 10);
                if (KontrolNu == 10)
                    KontrolNu = 0;
                numara = numara + KontrolNu.ToString();
            }
            return numara;
        }
        public string NumaraVer(SqlConnection Baglanti, SqlTransaction Tr)
        {

            SiradakiKoduKaydet(Baglanti, Tr, SiradakiKod + 1, BarkodAyarID);
            return SadeceNumaraverAMK();
        }


        SqlCommand cmd;


        private void SiradakiKoduKaydet(SqlConnection baglanti, SqlTransaction Tr, int _SiradakiKod, int BarkodAyarID)
        {
            using (cmd = new SqlCommand("update BarkodAyar set SiradakiKod = @SiradakiKod where BarkodAyarID = @BarkodAyarID ", baglanti, Tr))
            {
                cmd.Parameters.Add("@SiradakiKod", SqlDbType.Int).Value = _SiradakiKod;
                cmd.Parameters.Add("@BarkodAyarID", SqlDbType.Int).Value = BarkodAyarID;

                cmd.ExecuteNonQuery();
            }
        }


        // sisteme kayıtlı 3 çeşit barkod olabilir
        // 1. Ürününüzerinde gelen barkodlar
        // Sistemimiz gibi gibi burayı doldur amk
        public decimal BarkodtanMiktarVer(SqlConnection Baglanti, SqlTransaction TrGenel, string BardkodNo)
        {
            using (cmd = new SqlCommand(@"

--declare @Barkod nvarchar(50) ,
declare  @MiktarKacinciHanedenBasliyor tinyint,
@MiktarKacHane tinyint
 -- set @Barkod = '2600000000113'




-- Hem ön eke hem barkodunda miktar varsa
-- yalnız programda şöyle bişi olması lazım
-- aynı ön eke sahip birden fazla barkod numarası oluşturulmasını engellemeli
if (select  1 from BarkodAyar where OnEk = LEFT(@Barkod, 2)  and BarkodAyar.MiktarOlacakMi = 1) = 1
  begin
      update BarkodAyar set @MiktarKacinciHanedenBasliyor = (2 + KacHaneKod + 1), @MiktarKacHane = KacHaneMiktar from BarkodAyar where OnEk = LEFT(@Barkod, 2)  and BarkodAyar.MiktarOlacakMi = 1
      select  
      convert(decimal(12,10),  -- decimal a çeviriyoruz
      (SUBSTRING(@Barkod, @MiktarKacinciHanedenBasliyor , 2)  -- ilk haneyi alıyoru<
      + '.' +  -- araya nokta koyuyoruz
      SUBSTRING(@Barkod, @MiktarKacinciHanedenBasliyor + 2 , @MiktarKacHane  - 2)))  -- virgülden sonraki haneleri alıyoruz
  end
else
      select 1 as Miktar from Stok
      where Stok.Barkod like @Barkod and Stok.Silindi = 0
      union all
      select StokBirimCevrim.KatSayi from StokBirimCevrim
      where StokBirimCevrim.Barkodu like @Barkod", Baglanti, TrGenel))
            {
                cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = BardkodNo;
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public string BarkodNuVerYeniNoyuKaydet(SqlConnection Baglanti, SqlTransaction Tr, int BarkodunKullanildigiYer)
        {
            using (cmd = new SqlCommand(@"select * from BarkodAyar where BarkodunKullanildigiYer = @BarkodunKullanildigiYer
update BarkodAyar set BarkodAyar.SiradakiKod += 1 where BarkodAyar.BarkodunKullanildigiYer = @BarkodunKullanildigiYer", Baglanti, Tr))
            {
                cmd.Parameters.Add("@BarkodunKullanildigiYer", SqlDbType.Int).Value = BarkodunKullanildigiYer;
                //cmd.Parameters.Add("")
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        BarkodAyarID = (int)dr["BarkodAyarID"];
                        OnEk = (int)dr["OnEk"]; // on ekin integer olması mantıksız olmuş

                        BarkodTipi = (clsTablolar.Ayarlar.csBarkodTipleri.BarkodTipleri)Convert.ToInt32(dr["BarkodTipi"].ToString());

                        KontrolNoOlsunMu = (bool)dr["KontrolNoOlsunMu"];
                        MiktarOlacakMi = (bool)dr["MiktarOlacakMi"];
                        KacHaneMiktar = Convert.ToInt16(dr["KacHaneMiktar"]);
                        KacHaneKod = Convert.ToInt16(dr["KacHaneKod"]);
                        Aciklama = dr["Aciklama"].ToString();
                        ToplamKarakterSayisi = Convert.ToInt16(dr["ToplamKarakterSayisi"]);
                        SiradakiKod = (int)dr["SiradakiKod"];
                    }
                }
            }
            return SadeceNumaraverAMK();
        }
    }
}
