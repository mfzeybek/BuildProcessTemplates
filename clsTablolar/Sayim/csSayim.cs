using System;
using System.Data;
using System.Data.SqlClient;
namespace clsTablolar.Sayim
{
    public class csSayim : IDisposable
    {
        #region Parametre
        private int _SayimID;
        private string _SayimKodu;
        private DateTime _SayimTarihi;
        private int _DepoID;
        private int _KaydedenID;
        private DateTime _KayitTarihi;
        private int _GuncelleyenID;
        private DateTime _GuncellemeTarihi;
        private string _Aciklama;

        #endregion

        #region PROPERTY
        public int SayimID
        {
            get { return _SayimID; }
            set { _SayimID = value; }
        }
        public string SayimKodu
        {
            get { return _SayimKodu; }
            set { _SayimKodu = value; }
        }
        public DateTime SayimTarihi
        {
            get { return _SayimTarihi; }
            set { _SayimTarihi = value; }
        }
        public int DepoID
        {
            get { return _DepoID; }
            set { _DepoID = value; }
        }
        public int KaydedenID
        {
            get { return _KaydedenID; }
            set { _KaydedenID = value; }
        }
        public DateTime KayitTarihi
        {
            get { return _KayitTarihi; }
            set { _KayitTarihi = value; }
        }
        public int GuncelleyenID
        {
            get { return _GuncelleyenID; }
            set { _GuncelleyenID = value; }
        }
        public DateTime GuncellemeTarihi
        {
            get { return _GuncellemeTarihi; }
            set { _GuncellemeTarihi = value; }
        }
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }

        #endregion

        #region Genel DeğişkEnler
        SqlCommand cmdGenel;
        SqlDataReader drGenel;
        #endregion

        public csSayim(SqlConnection Baglanti, SqlTransaction Tr, int SayimID)
        {
            if (SayimID == -1)
            {
                _SayimID = -1;
                _SayimKodu = "";
                _SayimTarihi = DateTime.Now;
                _DepoID = -1;
                _KaydedenID = -1;
                _KayitTarihi = DateTime.Now;
                _GuncelleyenID = -1;
                _GuncellemeTarihi = DateTime.Now;
                _Aciklama = "";
            }
            else
                SayimGetir(Baglanti, Tr, SayimID);
        }
        private void SayimGetir(SqlConnection Baglanti, SqlTransaction TrGenel, int SayimID)
        {
            using (cmdGenel = new SqlCommand(@"SELECT SayimID, SayimKodu, SayimTarihi, DepoID, KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi, Aciklama FROM dbo.Sayim WHERE (SayimID = @SayimID)", Baglanti, TrGenel))
            {
                cmdGenel.Parameters.Add("@SayimID", SqlDbType.Int).Value = SayimID;
                using (drGenel = cmdGenel.ExecuteReader())
                {
                    if (drGenel.Read())
                    {
                        _SayimID = Convert.ToInt32(drGenel["SayimID"]);
                        _SayimKodu = drGenel["SayimKodu"].ToString();
                        _SayimTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
                        _DepoID = Convert.ToInt32(drGenel["DepoID"].ToString());
                        _KaydedenID = Convert.ToInt32(drGenel["KaydedenID"].ToString());
                        _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
                        _Aciklama = drGenel["Aciklama"].ToString();
                    }
                }
            }
        }
        public String SayimGuncelle(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (cmdGenel = new SqlCommand())
            {
                cmdGenel.Connection = Baglanti;
                cmdGenel.Transaction = Tr;
                if (_SayimID == -1)
                {
                    cmdGenel.CommandText = @" Insert Into Sayim (SayimKodu, SayimTarihi, DepoID, KaydedenID, KayitTarihi, Aciklama) values 
(@SayimKodu, @SayimTarihi, @DepoID, @KaydedenID, @KayitTarihi, @Aciklama) set @SonID = SCOPE_IDENTITY()";

                    cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                    cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
                    cmdGenel.Parameters.Add("@SonID", SqlDbType.Int).Direction = ParameterDirection.Output;
                }
                else
                {
                    cmdGenel.CommandText = @" Update Sayim Set SayimKodu=@SayimKodu, SayimTarihi=@SayimTarihi, DepoID=@DepoID, 
GuncelleyenID=@GuncelleyenID, GuncellemeTarihi=@GuncellemeTarihi, Aciklama = @Aciklama Where SayimID=@SayimID";

                    cmdGenel.Parameters.Add("@GuncellemeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                    cmdGenel.Parameters.Add("@GuncelleyenID", SqlDbType.Int).Value = _GuncelleyenID;
                    cmdGenel.Parameters.Add("@SayimID", SqlDbType.Int).Value = _SayimID;
                }
                cmdGenel.Parameters.Add("@SayimKodu", SqlDbType.NVarChar).Value = _SayimKodu;
                cmdGenel.Parameters.Add("@SayimTarihi", SqlDbType.DateTime).Value = _SayimTarihi;
                cmdGenel.Parameters.Add("@DepoID", SqlDbType.Int).Value = _DepoID;
                cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama.ToString();

                //cmdGenel.ExecuteNonQuery();
                try
                {
                    cmdGenel.ExecuteNonQuery();
                    if (_SayimID == -1)
                        _SayimID = Convert.ToInt32(cmdGenel.Parameters["@SonID"].Value.ToString());
                }
                catch (Exception e)
                {
                    if (e is SqlException && ((SqlException)e).Number == 2601)
                        return ((SqlException)e).Number.ToString();
                    else
                        return e.Message;
                }
            }
            return _SayimID.ToString();
        }


        public void SayimiDetaylariIleBirlikteSil(SqlConnection Baglanti, SqlTransaction Tr, int SayimID)
        {
            using (cmdGenel = new SqlCommand())
            {
                cmdGenel.CommandText = @"delete Sayim where SayimID = @SayimID
delete SayimDetay where SayimID = @SayimID";
                cmdGenel.Connection = Baglanti;
                cmdGenel.Transaction = Tr;
                cmdGenel.Parameters.Add("@SayimID", SqlDbType.Int).Value = SayimID;
                cmdGenel.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
