using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.BasitUretim
{
    public class csBasitUretim : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       public  int BasitUretimID { get; set; }
        public int BUReceteID { get; set; }
        public int UretilenStokID { get; set; }
        public int CariID { get; set; }
        public String Aciklama { get; set; }
        public decimal UretimMiktari { get; set; }
        public decimal UretimMaliyeti { get; set; }

        SqlCommand cmd;



        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int BasitUretimID)
        {
            using (cmd = new SqlCommand("select * from BasitUretim where BasitUretimID = @BasitUretimID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@BasitUretimID", SqlDbType.Int).Value = BasitUretimID;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        this.BasitUretimID = (int)dr["BasitUretimID"];
                        this.BUReceteID = (int)dr["BUReceteID"];
                        this.UretilenStokID = (int)dr["UretilenStokID"];
                        this.CariID = (int)dr["CariID"];
                        this.Aciklama = dr["Aciklama"].ToString();
                        this.UretimMiktari = (decimal)dr["UretimMiktari"];
                        this.UretimMaliyeti = (decimal)dr["UretimMaliyeti"];
                    }
                }
            }
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int BasitUretimID)
        {
            using (cmd = new SqlCommand("", Baglanti, Tr))
            {
                if (BasitUretimID == -1)
                {
                    cmd.CommandText = "insert into BasitUretim (BUReceteID, UretilenStokID, CariID, Aciklama, UretimMiktari, UretimMaliyeti  ) values (@BUReceteID, @UretilenStokID, @CariID, @Aciklama, @UretimMiktari, @UretimMaliyeti  )   set @YeniID = SCOPE_IDENTITY() ";
                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                }
                else
                {
                    cmd.CommandText = " update BasitUretim set BUReceteID = @BUReceteID, UretilenStokID = @UretilenStokID, CariID = @CariID, Aciklama = @Aciklama, UretimMiktari = @UretimMiktari = @UretimMaliyeti wehere BasitUretimID = @BasitUretimID";
                    cmd.Parameters.Add("@BasitUretimID", SqlDbType.Int).Value = BasitUretimID;
                }
                cmd.Parameters.Add("@BUReceteID", SqlDbType.Int).Value = BUReceteID;
                cmd.Parameters.Add("@UretilenStokID", SqlDbType.Int).Value = UretilenStokID;

                cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;
                cmd.Parameters.Add("@UretimMiktari", SqlDbType.Decimal).Value = UretimMiktari;
                cmd.Parameters.Add("@UretimMaliyeti", SqlDbType.Decimal).Value = UretimMaliyeti;

                cmd.ExecuteNonQuery();

            }
        }
    }
}
