using System;
using System.Data;
using System.Data.SqlClient;

namespace PDKS
{
    public class csPersonel : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private int _PersonelID;
        public int PersonelID
        {
            get { return _PersonelID; }
            set { _PersonelID = value; }
        }

        private string _PersonelAdi;
        public string PersonelAdi
        {
            get { return _PersonelAdi; }
            set { _PersonelAdi = value; }
        }

        private string _PersonelSifre;
        public string PersonelSifre
        {
            get { return _PersonelSifre; }
            set { _PersonelSifre = value; }
        }

        private string _PersonelAciklama;
        public string PersonelAciklama
        {
            get { return _PersonelAciklama; }
            set { _PersonelAciklama = value; }
        }

        private byte[] _PersonelFoto;
        public byte[] PersonelFoto
        {
            get { return _PersonelFoto; }
            set { _PersonelFoto = value; }
        }


        SqlCommand cmd;
        SqlDataReader dr;

        public bool PersonelGetir(SqlConnection Baglanti, SqlTransaction Tr, string Sifre)
        {
            using (cmd = new SqlCommand("select * from Personel where PersonelSifre = @PersonelSifre", Baglanti, Tr))
            {
                cmd.Parameters.Add("@PersonelSifre", SqlDbType.NVarChar).Value = Sifre;

                using (dr = cmd.ExecuteReader())
                {

                    if (dr.Read())
                    {
                        _PersonelID = (int)dr["PersonelID"];
                        _PersonelAdi = dr["PersonelAdi"].ToString();
                        _PersonelSifre = dr["PersonelSifre"].ToString();
                        _PersonelAciklama = dr["PersonelAciklama"].ToString();

                        if (dr["PersonelFoto"] != DBNull.Value)
                            _PersonelFoto = (byte[])dr["PersonelFoto"];

                        return true;
                    }
                    else
                        return false;
                }
            }
            
        }


    }
}
