using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
    public class csCariGrup : IDisposable
    {
        #region Alanlar
        private int _CariGrupID;
        private string _CariGrup;
        private int _KaydedenID;
        private DateTime _KayitTarihi;
        private int _GuncelleyenID;
        private DateTime _GuncellemeTarihi;
        #endregion

        #region Property ler
        public int CariGrupID
        {
            get { return _CariGrupID; }
            set { _CariGrupID = value; }
        }
        public string CariGrup_
        {
            get { return _CariGrup; }
            set { _CariGrup = value; }
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
        #endregion

        #region Genel Değişkenler
        SqlCommand cmdGenel;
        SqlDataReader drGenel;
        #endregion

        public csCariGrup(SqlConnection baglanti, SqlTransaction trGenel, int CariGrupID)
        {
            if (CariGrupID == -1)
            {
                _CariGrupID = -1;
                _CariGrup = "";
                _KaydedenID = -1;
                _KayitTarihi = Convert.ToDateTime("01.01.1888");
                _GuncelleyenID = -1;
                _GuncellemeTarihi = Convert.ToDateTime("01.01.1888");
            }
            else
            {
                CariGrupGetir(baglanti, trGenel, CariGrupID);
            }
        }

        public csCariGrup()
        { }
        private void CariGrupGetir(SqlConnection baglanti, SqlTransaction trGenel, int CariGrupID)
        {
            try
            {
                using (cmdGenel = new SqlCommand(
          @" SELECT  CariGrup, KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi
FROM  dbo.CariGrup WHERE     (dbo.CariGrup.CariGrupID = @CariGrupID) ", baglanti))
                {
                    cmdGenel.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = CariGrupID;
                    cmdGenel.Transaction = trGenel;
                    using (drGenel = cmdGenel.ExecuteReader())
                    {
                        if (drGenel.Read())
                        {
                            CariGrup_ = drGenel["CariID"].ToString();
                            _KaydedenID = Convert.ToInt32(drGenel["KaydedenID"].ToString());
                            _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
                            _GuncelleyenID = Convert.ToInt32(drGenel["GuncelleyenID"].ToString());
                            _GuncellemeTarihi = Convert.ToDateTime(drGenel["GuncellemeTarihi"].ToString());
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
            }
        }
        public static DataTable CariGrupListesi(SqlConnection baglanti)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT CariGrupID, CariGrup, KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi From CariGrup", baglanti);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CariGrupListesi(SqlConnection baglanti, SqlTransaction Tr)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT CariGrupID, CariGrup, KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi From CariGrup", baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public string AdresInsert(SqlConnection baglanti, SqlTransaction trGenel)
        {
            try
            {
                cmdGenel = new SqlCommand(@"Insert Into CariGrup(CariGrup, KaydedenID, KayitTarihi)
Values (@CariGrup, @KaydedenID, @KayitTarihi) SET @SonID=SCOPE_IDENTITY()
", baglanti);
                cmdGenel.Parameters.Add("@CariGrup", SqlDbType.NVarChar).Value = _CariGrup;
                cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
                cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = _KayitTarihi;

                cmdGenel.Parameters.Add("@SonID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmdGenel.Transaction = trGenel;
                cmdGenel.ExecuteNonQuery();

                return cmdGenel.Parameters["@SonID"].Value.ToString();
            }
            catch (Exception hata)
            {
                throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
            }
        }
        public void AdresUpdate(SqlConnection baglanti, SqlTransaction tr)
        {
            try
            {
                cmdGenel = new SqlCommand(@"Update CariGrup SET 
CariGrup=@CariGrup, GuncelleyenID=@GuncelleyenID, GuncellemeTarihi=@GuncellemeTarihi Where CariGrupID=@CariGrupID ", baglanti);
                cmdGenel.Parameters.Add("@CariID", SqlDbType.NVarChar).Value = _CariGrup;
                cmdGenel.Parameters.Add("@GuncelleyenID", SqlDbType.Int).Value = _GuncelleyenID;
                cmdGenel.Parameters.Add("@GuncellemeTarihi", SqlDbType.DateTime).Value = _GuncellemeTarihi;

                cmdGenel.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = _CariGrupID;
                cmdGenel.Transaction = tr;
                cmdGenel.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
            }
        }
        public static void AdresDelete(SqlConnection baglanti, SqlTransaction trGenel, int CariGrupID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete From CariGrup Where CariGrupID=@CariGrupID", baglanti, trGenel);
                cmd.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = CariGrupID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
