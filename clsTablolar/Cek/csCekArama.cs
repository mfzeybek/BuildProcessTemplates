using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.Cek
{
    public class csCekArama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private DateTime _EvrakTarihi1;
        private DateTime _EvrakTarihi2;


        public DateTime EvrakTarihi1
        {
            get { return _EvrakTarihi1; }
            set { _EvrakTarihi1 = value; }
        }
        public DateTime EvratkTarihi2
        {
            get { return _EvrakTarihi2; }
            set { _EvrakTarihi2 = value; }
        }


        SqlDataAdapter da;
        public DataTable dt;

        public csCekArama()
        {
            _EvrakTarihi1 = DateTime.MinValue;
            _EvrakTarihi2 = DateTime.MinValue;
        }

        public DataTable ListeGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (da = new SqlDataAdapter(@"select CekHrID, Tarih, EvrakDurumu, EvrakNo, EvrakTarihi, Tutari, KesideYeri, EvrakBankasi, 
                                      EvrakSubesi, EvrakHesapNo, CariID, EvrakTipi from CekHr where SilindiMi = 0 ", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;

                if (_EvrakTarihi1 != DateTime.MinValue)
                {
                    da.SelectCommand.CommandText += " and convert(date, EvrakTarihi, 1) >= @EvrakTarihi1 ";
                    da.SelectCommand.Parameters.Add("@EvrakTarihi1", SqlDbType.DateTime).Value = _EvrakTarihi1.Date;
                }

                if (_EvrakTarihi2 != DateTime.MinValue)
                {
                    da.SelectCommand.CommandText += " and convert(date, EvrakTarihi, 1) <= @EvrakTarihi2 ";
                    da.SelectCommand.Parameters.Add("@EvrakTarihi2", SqlDbType.DateTime).Value = _EvrakTarihi2.Date;
                }


                using (dt = new DataTable())
                {
                    try
                    {
                        da.Fill(dt);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return dt;
        }
    }
}
