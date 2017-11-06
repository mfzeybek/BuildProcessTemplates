using System;
using System.Data;
using System.Data.SqlClient;

namespace PDKS
{
    public class csHareketler : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public enum Tur
        {
            MesaiBaslangici = 1,
            Giris = 2,
            Cikis = 3,
            HicKayitYok
        }

        SqlCommand cmd;
        SqlDataReader dr;

        /// <summary>
        /// Personelin o günkü Son kaydının Tipini Getirir
        /// </summary>
        /// <returns></returns>
        public Tur PersonelinEnSonKayitTipiNe(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID)
        {
            using (cmd = new SqlCommand(@"--declare @PersonelID int = 1
select Top 1 Tur from hareketler where PersonelID = @PersonelID and CONVERT(date, Zaman)  = CONVERT(date, GETDATE())
order by Hareketler.ID desc
--order by Zaman desc", Baglanti, Tr))
            {
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;


                Tur HareketTuru = new Tur();

                try
                {
                    HareketTuru = (Tur)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    HareketTuru = Tur.HicKayitYok;
                }
                return HareketTuru;
            }
        }

        public void HareketKaydet(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID, Tur HareketTuru, int YerID)
        {
            using (cmd = new SqlCommand("insert into Hareketler (PersonelID, Zaman, Tur, YerID) values (@PersonelID, GETDATE(), @Tur, @YerID)", Baglanti, Tr))
            {
                try
                {
                    cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
                    //cmd.Parameters.Add("@Zaman", SqlDbType.DateTime).Value = DateTime.Now;

                    cmd.Parameters.Add("@Tur", SqlDbType.Int).Value = (int)HareketTuru;

                    cmd.Parameters.Add("@YerID", SqlDbType.Int).Value = YerID;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }

        public int PersonelinSonCikisYaptigiYerinIDsi(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID)
        {
            using (cmd = new SqlCommand(@"--declare @PersonelID int = 1

                        select Top 1 YerID from hareketler where PersonelID = @PersonelID and Zaman between CONVERT(varchar,GETDATE(),101) and GETDATE()
                        order by Zaman desc", Baglanti, Tr))
            {
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;

                return (int)cmd.ExecuteScalar(); ;
            }
        }




        public int SonCikisYaptigiYerID { get; set; }
        public string SonCikisYaptigiYerAdi { get; set; }
        public DateTime SonCikisYaptigiZaman { get; set; }



        /// <summary>
        /// Bu kısım Sadece Hareket Girşi Yapılırken Turu.Giriş ise Bir önceki Girişin bilgilerini almak için kullanılacak
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="PersonelID"></param>
        public void PersonelinSonCikisYaptigiYerinBilgileri(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID)
        {
            using (cmd = new SqlCommand(@"--declare @PersonelID int = 1

select Top 1 * from hareketler 
inner join Yerler on Yerler.YerID = Hareketler.YerID
where PersonelID = @PersonelID and Zaman between CONVERT(varchar,GETDATE(),101) and GETDATE()

order by Zaman desc", Baglanti, Tr))
            {
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;

                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        SonCikisYaptigiYerID = (int)dr["YerID"];
                        SonCikisYaptigiYerAdi = dr["YerAdi"].ToString();
                        SonCikisYaptigiZaman = (DateTime)dr["Zaman"];
                    }
                }
            }
        }
    }
}
