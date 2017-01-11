using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Kasa
{
    public class csKasaHareket : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int KasaHrID { get; set; }
        public int KasaID { get; set; }
        public decimal Alacak { get; set; }
        public decimal Borc { get; set; }
        public string Aciklama { get; set; }


        public int HarekeKaydet(SqlConnection Baglanti, SqlTransaction Tr, int KasaHrID, int KasaID, decimal Alacak, decimal Borc, string Aciklama)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Baglanti;
                cmd.Transaction = Tr;
                if (KasaHrID != -1)
                {
                    cmd.CommandText = "update KasaHareket set KasaID = @KasaID, Alacak = @Alacak, Borc = @Borc, Aciklama = @Aciklama where KasaHrID = @KasaHrID";
                    cmd.Parameters.Add("@KasaHrID", SqlDbType.Int).Value = KasaHrID;
                }
                else
                {
                    cmd.CommandText = @"insert into KasaHareket (KasaID, Alacak, Borc, Aciklama) values 
(@KasaID, @Alacak, @Borc, @Aciklama) set @YeniID = SCOPE_IDENTITY() ";
                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                }

                cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaID;
                cmd.Parameters.Add("@Alacak", SqlDbType.Decimal).Value = Alacak;
                cmd.Parameters.Add("@Borc", SqlDbType.Decimal).Value = Borc;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;

                cmd.ExecuteNonQuery();

                if (KasaHrID == -1)
                {
                    this.KasaHrID = (int)cmd.Parameters["@YeniID"].Value;
                    KasaHrID = this.KasaHrID;
                }
            }

            //cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value;

            return KasaHrID;
        }

        public DataTable KasaListeGetir(SqlConnection baglanti, SqlTransaction Tr)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select * from Kasa", baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="KasaID"></param>
        /// <param name="SonAlinanZraporudanSonrakileriGetir"></param>
        public DataTable KasaHareketListe(SqlConnection Baglanti, SqlTransaction Tr, int KasaID, bool SonAlinanZraporudanSonrakileriGetir)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand
            DataTable dt = new DataTable();

            return dt;
        }

        /// <summary>
        /// Kasadaki Bütün Paraların çıkışını yapar.
        /// </summary>
        public void ZRaporuAl()
        {
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.CommandText = @"insert into ZRaporu (ZRaporuID, Tarih, Aciklama, RaporuAlanPersonelID, NakitTutar, KrediKartiTutari, KasaBakiyesi)
            //values(@ZRaporuID, @Tarih, @Aciklama, @RaporuAlanPersonelID, @NakitTutar, @KrediKartiTutari, @KasaBakiyesi)";
            //            cmd.Parameters.Add()


        }

        public class KasaRapor : IDisposable
        {
            public decimal KasaBakiye { get; set; }
            public decimal Alacak { get; set; }
            public decimal Borc { get; set; }


            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }

        public KasaRapor KasaBakiyeVer(SqlConnection Baglanti, SqlTransaction Tr, int KasaID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"select SUM(Alacak) - SUM(Borc) as Bakiye, SUM(Alacak) Alacak, SUM(Borc) Borc from KasaHareket
inner join CariHr on CariHr.KasaHrID = KasaHareket.KasaHrID and CariHr.SilindiMi = 0
where  isnull((select top 1 KasaHareketID from ZRaporu),-1) < kasahareket.KasaHrID and KasaHareket.KasaID = @KasaID
group by KasaHareket.KasaID", Baglanti, Tr))
                {
                    cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaID;
                    using (KasaRapor ksarpr = new KasaRapor())
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                ksarpr.KasaBakiye = (decimal)dr["Bakiye"];
                                ksarpr.Alacak = (decimal)dr["Alacak"];
                                ksarpr.Borc = (decimal)dr["Borc"];
                            }
                        }

                        return ksarpr;
                    }
                }
            }
            catch (Exception hata)
            {
                throw hata;
            }
        }
    }
}

