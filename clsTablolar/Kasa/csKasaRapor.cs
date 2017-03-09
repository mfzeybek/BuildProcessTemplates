﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                using (SqlCommand cmd = new SqlCommand(@" select SUM(PosHr.Alacak) - SUM(PosHr.Borc) as PosBakiye, SUM(PosHr.Alacak) PosAlacak,  SUM(PosHr.Borc) PosBorc
, SUM(NakitHr.Alacak) - SUM(NakitHr.Borc) as NakitBakiye, SUM(NakitHr.Alacak) NakitAlacak,  SUM(NakitHr.Borc) NakitBorc from CariHr
--inner join CariHr on CariHr.KasaHrID = KasaHareket.KasaHrID and CariHr.SilindiMi = 0
left join KasaHareket PosHr on PosHr.KasaHrID = CariHr.KasaHrID and PosHr.KasaID = 3
left join KasaHareket NakitHr on NakitHr.KasaHrID = CariHr.KasaHrID and NakitHr.KasaID = @KasaID
where  
isnull((select top 1 KasaHareketID from KasaRaporu),-1) < CariHr.KasaHrID ", Baglanti, Tr))
                {
                    cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaID;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            NakitBakiye = (decimal)dr["NakitBakiye"];
                            NakitAlacak = (decimal)dr["NakitAlacak"];
                            NakitBorc = (decimal)dr["NakitBorc"];
                            PosBakiye = (decimal)dr["PosBakiye"];
                            PosAlacak = (decimal)dr["PosAlacak"];
                            PosBorc = (decimal)dr["PosBorc"];
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


        public void RaporKaydet(SqlConnection Baglanti, SqlTransaction Tr)
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
