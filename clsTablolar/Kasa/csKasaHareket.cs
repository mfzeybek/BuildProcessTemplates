using System;
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
        public DateTime Tarih { get; set; }
        public bool SilindiMi { get; set; }
        public int KaydedenPersonelID { get; set; }
        public HareketTipleri HareketTipi { get; set; }

        public enum HareketTipleri
        {
            bos = -1,
            ParaGirisi = 1,
            GiderCikisi = 2,
            Iade = 3,
            ZRaporuAlindiktanSonraCikis = 4,
            KasaTransfer = 5
        }

        public csKasaHareket()
        {
            this.KasaHrID = -1;
            this.KasaID = -1;
            this.Alacak = 0;
            this.Borc = 0;
            this.Aciklama = String.Empty;
            this.SilindiMi = false;
            this.Tarih = DateTime.Now;
            this.HareketTipi = HareketTipleri.bos;
        }

        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int KasaHrID)
        {
            if (KasaHrID == -1)
                return;

            using (SqlCommand cmd = new SqlCommand("Select * from KasaHareket where SilindiMi = 0 and KasaHrID = @KasaHrID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@KasaHrID", SqlDbType.Int).Value = KasaHrID;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        this.KasaHrID = (int)dr["KasaHrID"];
                        this.KasaID = (int)dr["KasaID"];
                        this.Alacak = (decimal)dr["Alacak"];
                        this.Borc = (decimal)dr["Borc"];
                        this.Aciklama = dr["Aciklama"].ToString();
                        this.Tarih = (DateTime)dr["Tarih"];
                        this.KaydedenPersonelID = (int)dr["KaydedenPersonelID"];
                        this.HareketTipi = (HareketTipleri)(Convert.ToInt32(dr["HareketTipi"]));
                    }
                }
            }
        }
        public int HarekeKaydet(SqlConnection Baglanti, SqlTransaction Tr, int KasaHrID, int KasaID, decimal Alacak, decimal Borc, string Aciklama, DateTime Tarih, HareketTipleri HareketTipi, int PersonelID, bool SilinniMi)
        {
            this.KasaHrID = KasaHrID;
            this.KasaID = KasaID;
            this.Alacak = Alacak;
            this.Borc = Borc;
            this.Aciklama = Aciklama;
            this.Tarih = Tarih;
            this.SilindiMi = SilindiMi;
            this.KaydedenPersonelID = PersonelID;
            this.HareketTipi = HareketTipi;

            return HarekeKaydet(Baglanti, Tr);
        }
        public int HarekeKaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Baglanti;
                cmd.Transaction = Tr;
                if (KasaHrID != -1)
                {
                    cmd.CommandText = "update KasaHareket set KasaID = @KasaID, Alacak = @Alacak, Borc = @Borc, Aciklama = @Aciklama , Tarih = @Tarih, HareketTipi = @HareketTipi ,SilindiMi = @SilindiMi, KaydedenPersonelID = @KaydedenPersonelID where KasaHrID = @KasaHrID ";
                    cmd.Parameters.Add("@KasaHrID", SqlDbType.Int).Value = KasaHrID;
                }
                else
                {
                    cmd.CommandText = @"insert into KasaHareket (KasaID, Alacak, Borc, Aciklama, Tarih, HareketTipi ,SilindiMi, KaydedenPersonelID) values 
(@KasaID, @Alacak, @Borc, @Aciklama, @Tarih, @HareketTipi ,@SilindiMi, @KaydedenPersonelID) set @YeniID = SCOPE_IDENTITY() ";
                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                }

                cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaID;
                cmd.Parameters.Add("@Alacak", SqlDbType.Decimal).Value = Alacak;
                cmd.Parameters.Add("@Borc", SqlDbType.Decimal).Value = Borc;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Tarih;
                cmd.Parameters.Add("@HareketTipi", SqlDbType.Int).Value = HareketTipi;
                cmd.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = SilindiMi;
                cmd.Parameters.Add("@KaydedenPersonelID", SqlDbType.Int).Value = KaydedenPersonelID;

                cmd.ExecuteNonQuery();

                if (KasaHrID == -1)
                {
                    this.KasaHrID = (int)cmd.Parameters["@YeniID"].Value;
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

        public void HareketiSil(SqlConnection Baglanti, SqlTransaction Tr, int HareketID)
        {
            using (SqlCommand cmd = new SqlCommand("update KasaHareket set SilindiMi = 1 where KasaHrID = @KasaHrID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@KasaHrID", SqlDbType.Int).Value = HareketID;
                int ads = cmd.ExecuteNonQuery();
            }
        }
    }
}

