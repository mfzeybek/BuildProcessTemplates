using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Siparis
{
    public class csSiparisDurumTanimlari : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        DataTable dt_SiparisDurumTanimlari;

        public DataTable dt_Getir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select * from SiparisDurumTanimlari", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                using (dt_SiparisDurumTanimlari = new DataTable())
                {
                    da.Fill(dt_SiparisDurumTanimlari);
                    return dt_SiparisDurumTanimlari;
                }
            }
        }

        //Hepsi Satırı filtreleme yaparken belli tanıma göre değil hepsi diye bir satır ile getiriyor
        public DataTable Dt_Getir_HepsiSatiriIleBirlikte(SqlConnection Baglanti, SqlTransaction Tr)
        {
            dt_Getir(Baglanti, Tr);

            dt_SiparisDurumTanimlari.Rows.InsertAt(dt_SiparisDurumTanimlari.NewRow(), 0);
            dt_SiparisDurumTanimlari.Rows[0]["SiparisDurumTanimID"] = -1;
            dt_SiparisDurumTanimlari.Rows[0]["SiparisDurumTanimAdi"] = "Hepsi";
            return dt_SiparisDurumTanimlari;
        }
    }
}
