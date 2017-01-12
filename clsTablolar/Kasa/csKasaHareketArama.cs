using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Kasa
{
    public class csKasaHareketArama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public bool SonZRaporundanSonraMi { get; set; }

        public hareketYonu Yonu { get; set; }

        public enum hareketYonu
        {
            Hepsi,
            Alacak,
            Borc
        }

        public int KasaID { get; set; }


        public DataTable KasaHareketListe(SqlConnection Baglanti, SqlTransaction Tr, int KasaID)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand.CommandText = @"select SUM(Borc) from kasahareket 
where 1 = 1 ";

            if (SonZRaporundanSonraMi)
            {
                da.SelectCommand.CommandText = da.SelectCommand.CommandText + " and isnull((select top 1 ZRaporu.KasaHareketID from ZRaporu),-1) < KasaHareket.KasaHrID ";
            }
            if (KasaID != -1)
            {
                da.SelectCommand.CommandText = da.SelectCommand.CommandText + " and KasaHareket.KasaID = @KasaID ";
            }
            if (Yonu == hareketYonu.Borc)
            {
                da.SelectCommand.CommandText = da.SelectCommand.CommandText + " and Borc > 0 ";
            }


            DataTable dt = new DataTable();

            return dt;
        }
    }
}
