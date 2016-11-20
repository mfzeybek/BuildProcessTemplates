using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.TeraziSatisClaslari
{
    public class csStok : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int StokID { get; set; }
        public string StokAdi { get; set; }
        public decimal Kdv { get; set; }
        public decimal Barkod { get; set; }

        public decimal KdvDahilFiyat { get; set; }
        public decimal KdvHaricFiyat { get; set; }

        public int AnaBirimID { get; set; }

        public string StokAnaBirimAdi { get; set; }

        public string Aciklama { get; set; }

        public string RafYeriAciklama { get; set; }

        public byte[] Fotografi { get; set; }

        SqlCommand cmd;
        SqlDataReader dr;

        string selectCumlesi;


        public void GosterilecekAlanEkle(StokAlanTanimlari KolonAdi)
        {
            if (KolonAdi == StokAlanTanimlari.Fotografi)
            {
                //selectCumlesi = selectCumlesi; //+ ", (select StokResim.Resim from StokResim with(nolock) where StokResim.StokID = @StokID and StokResim.Varsayilan = 1) as Foto";
            }
            else
                selectCumlesi = selectCumlesi + ", " + KolonAdi.ToString();
        }

        public enum StokAlanTanimlari
        {
            EtiketAdi,
            StokAdi,
            Fiyati,
            Aciklama,
            StokMiktari,
            Fotografi
        }

        public enum StokDonenBilgi
        {
            StokBulunamadi,
            StokBirlesikHareket,
            StokBululndu
        }

        //TODO :  şimdilik fiyatı satış fiyatımızdan kullanıyoruz ama normalde fiyatı cariden alıcak

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="TrGenel"></param>
        /// <param name="StokID"></param>
        /// <returns>1 döndürürse kaydı bulmuştur (kaydın fiyatı yoksa kaydı bulamaz)
        /// -1 döndürürse kaydı bulamaıştır veya zaten boş kayıt getirmesi istenmiştir (birleşik ürün için)
        /// </returns>
        public StokDonenBilgi GetirHamisina(SqlConnection Baglanti, SqlTransaction TrGenel, int StokID)
        {
            if (StokID == -1) // hangi ihtimallerde -1 verilebilir birleşik ürün istendiğinde sanırım böyle geitirir ki
            {
                this.StokID = -1;
                StokAdi = "";
                Kdv = 0;
                KdvDahilFiyat = 0;
                KdvHaricFiyat = 0;
                AnaBirimID = 0;
                //EtiketAdi = "";
                //StokAdi = "";
                //Fiyati = 0;
                //Aciklama = string.Empty;
                //StokMiktari = 0;
                //Fotografi = DBNull.Value;
                //RafYeriAciklama = string.Empty;
                return StokDonenBilgi.StokBirlesikHareket;
            }
            else
            {
                using (cmd = new SqlCommand(@"StokBilgileriGetir", Baglanti, TrGenel))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                    //cmd.Parameters.Add("@FazladanSelectCumlesi", SqlDbType.NVarChar).Value = selectCumlesi;

                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            this.StokID = (int)dr["StokID"];
                            StokAdi = dr["StokAdi"].ToString();
                            Kdv = (decimal)dr["SatisKdv"];
                            KdvDahilFiyat = Convert.ToDecimal(dr["KdvDahilFiyat"]);
                            KdvHaricFiyat = Convert.ToDecimal(dr["KdvHaricFiyat"]);
                            AnaBirimID = (int)dr["StokBirimID"];
                            StokAnaBirimAdi = dr["BirimAdi"].ToString();
                            return StokDonenBilgi.StokBululndu;
                        }
                        else
                        {
                            return StokDonenBilgi.StokBulunamadi;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Stok Bilgilerini Getirmesi için Açıklama vb. şeyleri de getiriyor;
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="TrGenel"></param>
        /// <param name="StokID"></param>
        /// <returns></returns>
        public StokDonenBilgi GetirHamisinaAyrintili(SqlConnection Baglanti, SqlTransaction TrGenel, int StokID)
        {
            if (StokID == -1) // hangi ihtimallerde -1 verilebilir birleşik ürün istendiğinde sanırım böyle geitirir ki
            {
                this.StokID = -1;
                StokAdi = "";
                Kdv = 0;
                KdvDahilFiyat = 0;
                KdvHaricFiyat = 0;
                AnaBirimID = 0;
                //EtiketAdi = "";
                //StokAdi = "";
                //Fiyati = 0;
                Aciklama = string.Empty;
                //StokMiktari = 0;
                //Fotografi = DBNull.Value;
                return StokDonenBilgi.StokBirlesikHareket;
            }
            else
            {
                using (cmd = new SqlCommand(@"StokBilgileriGetir2", Baglanti, TrGenel))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            this.StokID = (int)dr["StokID"];
                            StokAdi = dr["StokAdi"].ToString();
                            Kdv = (decimal)dr["SatisKdv"];
                            KdvDahilFiyat = Convert.ToDecimal(dr["KdvDahilFiyat"]);
                            KdvHaricFiyat = Convert.ToDecimal(dr["KdvHaricFiyat"]);
                            AnaBirimID = (int)dr["StokBirimID"];
                            StokAnaBirimAdi = dr["BirimAdi"].ToString();
                            Aciklama = dr["Aciklama"].ToString();
                            RafYeriAciklama = dr["RafYeriAciklama"].ToString();
                            return StokDonenBilgi.StokBululndu;
                        }
                        else
                        {
                            return StokDonenBilgi.StokBulunamadi;
                        }
                    }
                }
            }
        }
    }
}
