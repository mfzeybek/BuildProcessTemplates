using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel.PDKS
{
    public class csPdksV2 : IDisposable
    {
        /*
         --Açıklama--
         Türünün Giriş mi Çıkış mı Mesai Başlangıcı mı olduğunu
         MesaiBaslangici = 1,
         Cikis = ,
         Giris =
     
         pdks günün ilk kaydıysa Mesai Başlangıcı olarak algılayıp
     
     
         */

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private int _ID;
        private int _PersonelID;
        private DateTime _Zaman;
        private int _YerID;
        private PDKSTUR _Tur;


        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int PersonelID
        {
            get { return _PersonelID; }
            set { _PersonelID = value; }
        }
        public DateTime Zaman
        {
            get { return _Zaman; }
            set { _Zaman = value; }
        }

        public int YerID
        {
            get { return _YerID; }
            set { _YerID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public PDKSTUR Tur
        {
            get { return _Tur; }
            set { _Tur = value; }
        }

        public csPdksV2(SqlConnection Baglanti, SqlTransaction Tr, int PdksHrID)
        {
            if (PdksHrID == -1)
            {
                _ID = -1;
                _PersonelID = -1;
                _Zaman = DateTime.Now;
                _YerID = -1;
                _Tur = PDKSTUR.Cikis;
            }
            else
            {
                Getir(Baglanti, Tr, PdksHrID);
            }
        }
        SqlCommand cmd;
        SqlDataReader dr;
        private void Getir(SqlConnection Baglanti, SqlTransaction Tr, int PdksHrID)
        {
            using (cmd = new SqlCommand("select * from Hareketler where Hareketler.ID = @ID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = PdksHrID;

                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        _ID = Convert.ToInt32(dr["ID"]);
                        _PersonelID = Convert.ToInt32(dr["PersonelID"]);
                        _Zaman = Convert.ToDateTime(dr["Zaman"]);
                        _YerID = Convert.ToInt32(dr["YerID"]);
                        _Tur = (PDKSTUR)Enum.Parse(typeof(IslemTipi), dr["Tur"].ToString());
                    }
                }
            }
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int PdksHrID)
        {
            if (PdksHrID == -1)
            {
                using (cmd = new SqlCommand(@"insert into Hareketler 
          ( PersonelID, Zaman, YerID, Tur )
          values 
          ( @PersonelID, @Zaman, @YerID, @Tur  ) 
            set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr))
                {
                    cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = _PersonelID;

                    cmd.Parameters.Add("@Zaman", SqlDbType.DateTime).Value = _Zaman;

                    cmd.Parameters.Add("@YerID", SqlDbType.Int).Value = _YerID;
                    cmd.Parameters.Add("@Tur", SqlDbType.Int).Value = _Tur;
                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                using (cmd = new SqlCommand(@"update Hareketler set PersonelID = @PersonelID, Zaman = @Zaman, YerID = @YerID, Tur = @Tur
                            where ID = @ID ", Baglanti, Tr))
                {

                    cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = _PersonelID;
                    cmd.Parameters.Add("@Zaman", SqlDbType.DateTime).Value = _Zaman;
                    cmd.Parameters.Add("@YerID", SqlDbType.Int).Value = _YerID;
                    cmd.Parameters.Add("@Tur", SqlDbType.Int).Value = _Tur;

                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = _ID;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public enum PDKSTUR
        {
            MesaiBaslangici = 1,
            Giris = 2,
            Cikis = 3
        }
    }
}
