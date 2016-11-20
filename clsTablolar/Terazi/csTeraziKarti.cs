using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Terazi
{
    public class csTeraziKarti : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int TeraziID { get; set; }
        public string TeraziAdi { get; set; }
        public string TeraziMarkasi { get; set; }
        public string TeraziAciklama { get; set; }


        SqlCommand cmd;
        SqlDataReader dr;

        public csTeraziKarti(SqlConnection baglanti, SqlTransaction Tr, int _TeraziID)
        {
            if (_TeraziID == -1)
            {
                TeraziID = -1;
                TeraziAdi = "";
                TeraziMarkasi = "";
                TeraziAciklama = "";
            }
            else
            {
                TeraziGetirHamisina(baglanti, Tr, _TeraziID);
            }
        }

        private void TeraziGetirHamisina(SqlConnection baglanti, SqlTransaction Tr, int _TeraziID)
        {
            using (cmd = new SqlCommand("select * from Teraziler where TeraziID = @TeraziID", baglanti, Tr))
            {
                cmd.Parameters.Add("@TeraziID", SqlDbType.Int).Value = _TeraziID;

                using (dr = cmd.ExecuteReader())
                {

                    if (dr.Read())
                    {
                        TeraziID = (int)dr["TeraziID"];
                        TeraziAdi = dr["TeraziAdi"].ToString();
                        TeraziMarkasi = dr["TeraziMarkasi"].ToString();
                        TeraziAciklama = dr["TeraziAciklama"].ToString();
                    }
                }
            }
        }

        public void TeraziKaydet(SqlConnection Baglanti, SqlTransaction Tr, int _TeraziID)
        {
            using (cmd = new SqlCommand("", Baglanti, Tr))
            {
                if (_TeraziID == -1)
                {
                    cmd.CommandText = "insert into Teraziler (TeraziAdi, TeraziMarkasi, TeraziAciklama) values (@TeraziAdi, @TeraziMarkasi, @TeraziAciklama)  set @YeniID = SCOPE_IDENTITY() ";

                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

                }
                else
                {
                    cmd.CommandText = "update Teraziler set TeraziAdi = @TeraziAdi, TeraziMarkasi = @TeraziMarkasi, TeraziAciklama = @TeraziAciklama where TeraziID = @TeraziID";
                    cmd.Parameters.Add("@TeraziID", SqlDbType.Int).Value = _TeraziID;
                }

                cmd.Parameters.Add("@TeraziAdi", SqlDbType.NVarChar).Value = TeraziAdi;

                cmd.Parameters.Add("@TeraziMarkasi", SqlDbType.NVarChar).Value = TeraziMarkasi;
                cmd.Parameters.Add("@TeraziAciklama", SqlDbType.NVarChar).Value = TeraziAciklama;

                cmd.ExecuteNonQuery();

                if (_TeraziID == -1)
                    TeraziID = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);
            }
        }
    }
}
