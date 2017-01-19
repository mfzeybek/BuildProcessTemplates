using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel
{
    public class csPersonel : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private int _PersonelID;
        private int _CariID;
        private decimal _Maasi;
        /// <summary>
        /// Adı buradan değiştirilemez burası sadece görüntülemek için 
        /// yapılan değişiklikler geçerli olmuyor
        /// </summary>
        private string _PersonelAdi;
        private string _PDKSsifre;



        public int PersonelID
        {
            get { return _PersonelID; }
            set { _PersonelID = value; }
        }
        public int CariID
        {
            get { return _CariID; }
            set { _CariID = value; }
        }
        public decimal Maasi
        {
            get { return _Maasi; }
            set { _Maasi = value; }
        }
        public string PersonelAdi
        {
            get { return _PersonelAdi; }
            set { _PersonelAdi = value; }
        }
        public string PDKSsifre
        {
            get { return _PDKSsifre; }
            set { _PDKSsifre = value; }
        }




        SqlCommand cmd;
        SqlDataReader dr;

        public csPersonel(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID)
        {
            if (PersonelID == -1)
            {
                _PersonelID = -1;
                _CariID = -1;
                _Maasi = 0;
                _PersonelAdi = "";
                _PDKSsifre = "";
            }
            else
            {
                PersonelGetir(Baglanti, Tr, PersonelID);
            }

        }

        private void PersonelGetir(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID)
        {

            using (cmd = new SqlCommand(@"select Personel.CariID, Personel.PersonelID, Personel.Maasi,Personel.PDKSsifre ,Cari.CariTanim from Personel 
inner join Cari on Cari.CariID = Personel.CariID where PersonelID = @PersonelID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        _PersonelID = Convert.ToInt32(dr["PersonelID"]);
                        _CariID = Convert.ToInt32(dr["CariID"]);
                        _Maasi = Convert.ToDecimal(dr["Maasi"]);
                        _PersonelAdi = dr["CariTanim"].ToString();
                        _PDKSsifre = dr["PDKSsifre"].ToString();
                    }
                }
            }
        }
        public void PersonelKaydet(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID)
        {
            using (cmd = new SqlCommand("", Baglanti, Tr))
            {
                if (PersonelID == -1)
                {
                    cmd.CommandText = "insert into Personel (CariID, Maasi, PDKSsifre) values (@CariID, @Maasi, @PDKSsifre) set @SonID = SCOPE_IDENTITY()";
                    cmd.Parameters.Add("@SonID", SqlDbType.Int).Direction = ParameterDirection.Output;
                }
                else
                {
                    cmd.CommandText = "update Personel set CariID = @CariID, Maasi = @Maasi, PDKSsifre = @PDKSsifre where PersonelID = @PersonelID";
                    cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
                }
                cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
                cmd.Parameters.Add("@Maasi", SqlDbType.Decimal).Value = _Maasi;
                cmd.Parameters.Add("@PDKSsifre", SqlDbType.NVarChar).Value = _PDKSsifre.ToString();

                try
                {
                    cmd.ExecuteNonQuery();
                    if (PersonelID == -1)
                        _PersonelID = Convert.ToInt32(cmd.Parameters["@SonID"].Value.ToString());
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
