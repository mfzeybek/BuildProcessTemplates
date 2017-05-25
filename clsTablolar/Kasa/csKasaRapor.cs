using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.Kasa
{
    public class csKasaRapor : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int KasaRaporID { get; set; }
        DateTime Tarih { get; set; }
        public int KasaPersonelID { get; set; }
        public string KasaPersonelAdi { get; set; }
        public decimal NakitBakiye { get; set; }
        public decimal NakitAlacak { get; set; }
        public decimal NakitBorc { get; set; }
        public decimal PosBakiye { get; set; }
        public decimal PosAlacak { get; set; }
        public decimal PosBorc { get; set; }
        public decimal GenelToplam { get; set; }

        public string Aciklama { get; set; }
        public int KasaHareketID { get; set; }

        public csKasaRapor()
        {
            KasaRaporID = -1;
            KasaPersonelID = -1;
            KasaPersonelAdi = string.Empty;
            NakitBakiye = 0;
            NakitAlacak = 0;
            NakitBorc = 0;
            PosBakiye = 0;
            PosAlacak = 0;
            PosBorc = 0;
            Tarih = DateTime.MinValue;
            GenelToplam = 0;
            Aciklama = string.Empty;
        }

        /// <summary>
        /// Bu da aslında bakiye ver değil Rapor Bilgilerini getir olmalı ve raporu bu bilgilere göre kaydetmeli
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="KasaID"></param>
        /// <returns></returns>
        public void YeniAlinacakRaporBilgileriniGetir(SqlConnection Baglanti, SqlTransaction Tr, int KasaID, int PosKasaID, int PersonelID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@" select  Isnull(SUM(PosHr.Alacak) - SUM(PosHr.Borc), 0) as PosBakiye, Isnull (SUM(PosHr.Alacak), 0) as PosAlacak ,  ISnull( SUM(PosHr.Borc), 0) as PosBorc
, ISnull(SUM(NakitHr.Alacak), 0) - ISnull( SUM(NakitHr.Borc), 0) as NakitBakiye, ISnull( SUM(NakitHr.Alacak),0) as NakitAlacak,  ISnull( SUM(NakitHr.Borc), 0) as NakitBorc from KasaHareket-- as NakitHr
--inner join CariHr on CariHr.KasaHrID = KasaHareket.KasaHrID and CariHr.SilindiMi = 0
left join KasaHareket PosHr on PosHr.KasaHrID = KasaHareket.KasaHrID and PosHr.KasaID = 3 and PosHr.SilindiMi = 0
left join KasaHareket NakitHr on NakitHr.KasaHrID = KasaHareket.KasaHrID and NakitHr.KasaID = @KasaID and NakitHr.SilindiMi = 0
where  
(isnull((select top 1 KasaHareketID from KasaRaporu order by KasaHareketID desc),-1) < NakitHr.KasaHrID 
or isnull((select top 1 KasaHareketID from KasaRaporu order by KasaHareketID desc),-1) < PosHr.KasaHrID)", Baglanti, Tr))
                {
                    cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaID;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            NakitBakiye = Convert.ToDecimal(dr["NakitBakiye"]);
                            NakitAlacak = (decimal)dr["NakitAlacak"];
                            NakitBorc = (decimal)dr["NakitBorc"];
                            PosBakiye = (decimal)dr["PosBakiye"];
                            PosAlacak = (decimal)dr["PosAlacak"];
                            PosBorc = (decimal)dr["PosBorc"];
                            GenelToplam = (decimal)dr["NakitAlacak"] + (decimal)dr["PosAlacak"];
                        }
                    }
                }
                using (Personel.csPersonel personel = new Personel.csPersonel(Baglanti, Tr, PersonelID))
                {
                    KasaPersonelAdi = personel.PersonelAdi;
                }
            }
            catch (Exception hata)
            {
                throw hata;
            }
        }


        /* 
         Rapor kaydolurken olacaklar
             
             */


        public void RaporKaydet(SqlConnection Baglanti, SqlTransaction Tr, int KasaHareketID)
        {
            using (SqlCommand cmd = new SqlCommand("", Baglanti, Tr))
            {
                try
                {
                    if (KasaRaporID == -1) // ahanda burada kaldın
                    {
                        cmd.CommandText = @"insert into KasaRaporu (Tarih, Aciklama, RaporuAlanPersonelID, NakitTutar, KrediKartiTutari, KasaBakiyesi, KasaHareketID)
                        values
                        (@Tarih, @Aciklama, @RaporuAlanPersonelID, @NakitTutar, @KrediKartiTutari, @KasaBakiyesi, @KasaHareketID) ";

                        cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;
                        cmd.Parameters.Add("@RaporuAlanPersonelID", SqlDbType.Int).Value = KasaPersonelID;
                        cmd.Parameters.Add("@NakitTutar", SqlDbType.Decimal).Value = NakitAlacak;
                        cmd.Parameters.Add("@KrediKartiTutari", SqlDbType.Decimal).Value = PosAlacak;
                        cmd.Parameters.Add("@KasaBakiyesi", SqlDbType.Decimal).Value = NakitBakiye;
                        cmd.Parameters.Add("@KasaHareketID", SqlDbType.Int).Value = KasaHareketID;

                        cmd.ExecuteNonQuery();

                        // KasaPersonelID Gereksiz, değil işte amk
                        //KasaHareketID Neden var?? Z raporu alınınca Kasadaki paralar çıkıyor, yani öyle işte anladın sen onu hamısına
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
