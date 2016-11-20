using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Cek
{
    public class csCekHr : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private int _CekHrID;
        private DateTime _Tarih;
        private CekDurumu _EvrakDurumu;
        private string _EvrakNo;
        private DateTime _EvrakTarihi;
        private decimal _Tutari;
        private string _KesideYeri;
        private string _EvrakBankasi;
        private string _EvrakSubesi;
        private string _EvrakHesapNo;
        private int _CariID;
        private CekTipi _EvrakTipi;
        private bool _SilindiMi;




        public int CekHrID
        {
            get { return _CekHrID; }
            set { _CekHrID = value; }
        }
        public DateTime Tarih
        {
            get { return _Tarih; }
            set { _Tarih = value; }
        }
        public CekDurumu EvrakDurumu
        {
            get { return _EvrakDurumu; }
            set { _EvrakDurumu = value; }
        }
        public string EvrakNo
        {
            get { return _EvrakNo; }
            set { _EvrakNo = value; }
        }
        public DateTime EvrakTarihi
        {
            get { return _EvrakTarihi; }
            set { _EvrakTarihi = value; }
        }
        public decimal Tutari
        {
            get { return _Tutari; }
            set { _Tutari = value; }
        }
        public string KesideYeri
        {
            get { return _KesideYeri; }
            set { _KesideYeri = value; }
        }
        public string EvrakBankasi
        {
            get { return _EvrakBankasi; }
            set { _EvrakBankasi = value; }
        }
        public string EvrakSubesi
        {
            get { return _EvrakSubesi; }
            set { _EvrakSubesi = value; }
        }
        public string EvrakHesapNo
        {
            get { return _EvrakHesapNo; }
            set { _EvrakHesapNo = value; }
        }
        public int CariID
        {
            get { return _CariID; }
            set { _CariID = value; }
        }
        public CekTipi EvrakTipi
        {
            get { return _EvrakTipi; }
            set { _EvrakTipi = value; }
        }
        public bool SilindiMi
        {
            get { return _SilindiMi; }
            set { _SilindiMi = value; }
        }


        public csCekHr(SqlConnection Baglanti, SqlTransaction Tr, int CekHrID)
        {
            if (CekHrID == -1)
            {
                _CekHrID = -1;
                _Tarih = DateTime.Now;
                _EvrakDurumu = CekDurumu.Odenmedi;
                _EvrakNo = "";
                _EvrakTarihi = DateTime.Now;
                _Tutari = 0;
                _KesideYeri = "";
                _EvrakBankasi = "";
                _EvrakSubesi = "";
                _EvrakHesapNo = "";
                _CariID = -1;
                _EvrakTipi = CekTipi.AlinanCek;
            }
            else
            {
                CekGetir(Baglanti, Tr, CekHrID);
            }
        }
        SqlCommand cmd;
        SqlDataReader dr;

        public void CekGetir(SqlConnection Baglanti, SqlTransaction Tr, int CekHrID)
        {
            using (cmd = new SqlCommand(@"select CekHrID, Tarih, EvrakDurumu, EvrakNo, EvrakTarihi, Tutari, KesideYeri, EvrakBankasi, EvrakSubesi, 
                                    EvrakHesapNo, CariID, EvrakTipi from CekHr where CekHrID = @CekHrID ", Baglanti, Tr))
            {
                cmd.Parameters.Add("@CekHrID", SqlDbType.Int).Value = CekHrID;
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        _CekHrID = Convert.ToInt32(dr["CekHrID"]);
                        _Tarih = Convert.ToDateTime(dr["Tarih"]);
                        _EvrakDurumu = (CekDurumu)Convert.ToInt32(dr["EvrakDurumu"].ToString());
                        _EvrakNo = dr["EvrakNo"].ToString();
                        _EvrakTarihi = Convert.ToDateTime(dr["EvrakTarihi"]);
                        _Tutari = Convert.ToDecimal(dr["Tutari"]);
                        _KesideYeri = dr["KesideYeri"].ToString();
                        _EvrakBankasi = dr["EvrakBankasi"].ToString();
                        _EvrakSubesi = dr["EvrakSubesi"].ToString();
                        _EvrakHesapNo = dr["EvrakHesapNo"].ToString();
                        _CariID = Convert.ToInt32(dr["CariID"]);
                        _EvrakTipi = (CekTipi)Convert.ToInt32(dr["EvrakTipi"]);
                    }
                }
            }
        }


        public void CekKaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            if (_CekHrID == -1)
            {
                cmd = new SqlCommand(@"insert into CekHr 
                     ( Tarih, EvrakDurumu, EvrakNo, EvrakTarihi, Tutari, KesideYeri, EvrakBankasi, EvrakSubesi, 
                     EvrakHesapNo, CariID, EvrakTipi, SilindiMi ) 
                     values 
                     ( @Tarih, @EvrakDurumu, @EvrakNo, @EvrakTarihi, @Tutari, @KesideYeri, @EvrakBankasi, @EvrakSubesi, 
                     @EvrakHesapNo, @CariID, @EvrakTipi,  @SilindiMi )set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);
                cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
            }
            else
            {
                cmd = new SqlCommand(@"update CekHr set Tarih = @Tarih, EvrakDurumu = @EvrakDurumu, EvrakNo = @EvrakNo, 
                               EvrakTarihi = @EvrakTarihi, Tutari = @Tutari, KesideYeri = @KesideYeri, EvrakBankasi = @EvrakBankasi, 
                               EvrakSubesi = @EvrakSubesi, EvrakHesapNo = @EvrakHesapNo, CariID = @CariID, EvrakTipi = @EvrakTipi, SilindiMi = @SilindiMi where CekHrID = @CekHrID", Baglanti, Tr);

                cmd.Parameters.Add("@CekHrID", SqlDbType.Int).Value = CekHrID;
            }
            cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = _Tarih;
            cmd.Parameters.Add("@EvrakDurumu", SqlDbType.TinyInt).Value = Convert.ToInt32(_EvrakDurumu);
            cmd.Parameters.Add("@EvrakNo", SqlDbType.NVarChar).Value = _EvrakNo.ToString();
            cmd.Parameters.Add("@EvrakTarihi", SqlDbType.DateTime).Value = _EvrakTarihi;
            cmd.Parameters.Add("@Tutari", SqlDbType.Decimal).Value = _Tutari;
            cmd.Parameters.Add("@KesideYeri", SqlDbType.NVarChar).Value = _KesideYeri;
            cmd.Parameters.Add("@EvrakBankasi", SqlDbType.NVarChar).Value = _EvrakBankasi;
            cmd.Parameters.Add("@EvrakSubesi", SqlDbType.NVarChar).Value = _EvrakSubesi;
            cmd.Parameters.Add("@EvrakHesapNo", SqlDbType.NVarChar).Value = _EvrakHesapNo;
            cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
            cmd.Parameters.Add("@EvrakTipi", SqlDbType.TinyInt).Value = Convert.ToInt32(_EvrakTipi);
            cmd.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;

            try
            {
                cmd.ExecuteNonQuery();

                if (_CekHrID == -1)
                {
                    _CekHrID = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);
                }
            }
            catch (Exception)
            {

            }
        }

        public enum CekDurumu
        {
            Odendi = 1,
            Odenmedi = 2
        }
        public enum CekTipi
        {
            AlinanCek = IslemTipi.AlinanCek,
            VerilenCek = IslemTipi.VerilenCek
        }

    }
}
