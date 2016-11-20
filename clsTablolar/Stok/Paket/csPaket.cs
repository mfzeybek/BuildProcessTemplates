using System;
using System.Data.SqlClient;

namespace clsTablolar.Stok.Paket
{
    public class csPaket : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int PaketID { get; set; }
        public string PaketAdi { get; set; }
        public string PaketAciklama { get; set; }
        public string Barkod { get; set; }

        SqlCommand cmd;

        public csPaket(SqlConnection Baglanti, SqlTransaction Tr, int _PaketID)
        {
            if (_PaketID == -1)
            {
                PaketID = -1;
                PaketAdi = string.Empty;
                PaketAciklama = string.Empty;
                Barkod = string.Empty;
            }
            else
            {
                Getir(Baglanti, Tr, _PaketID);
            }



        }

        private void Getir(SqlConnection Baglanti, SqlTransaction Tr, int _PaketID)
        {
            using (cmd = new SqlCommand("select * from Paket where PaketID = @PaketID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@PaketID", System.Data.SqlDbType.Int).Value = _PaketID;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        PaketID = (int)dr["PaketID"];
                        PaketAdi = dr["PaketAdi"].ToString();
                        PaketAciklama = dr["PaketAciklama"].ToString();
                        Barkod = dr["Barkod"].ToString();
                    }
                }
            }
        }
        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (cmd = new SqlCommand("insert into paket (PaketAdi, PaketAciklama, Barkod) values (@PaketAdi, @PaketAciklama, @Barkod)", Baglanti, Tr))
            {
                if (PaketID == -1)
                {
                    cmd.CommandText = "insert into Paket (PaketAdi, PaketAciklama, Barkod) values (@PaketAdi, @PaketAciklama, @Barkod) set @YeniID = SCOPE_IDENTITY()";
                    cmd.Parameters.Add("@YeniID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                }
                else
                {
                    cmd.CommandText = "Update Paket set  PaketAdi = @PaketAdi, PaketAciklama = @PaketAciklama, Barkod = @Barkod where PaketID = @PaketID";
                    cmd.Parameters.Add("PaketID", System.Data.SqlDbType.Int).Value = PaketID;
                }



                cmd.Parameters.Add("@PaketAdi", System.Data.SqlDbType.NVarChar).Value = PaketAdi;
                cmd.Parameters.Add("@PaketAciklama", System.Data.SqlDbType.NVarChar).Value = PaketAciklama;
                cmd.Parameters.Add("@Barkod", System.Data.SqlDbType.NVarChar).Value = Barkod;

                cmd.ExecuteNonQuery();

                if (PaketID == -1)
                {
                    PaketID = (int)cmd.Parameters["@YeniID"].Value;
                }
            }
        }
    }
}
