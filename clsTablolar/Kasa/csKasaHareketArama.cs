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


        public bool AramaKriteriSonZRaporundanSonraMi { get; set; }

        public hareketYonu yonu { get; set; }

        public enum hareketYonu
        {
            Alacak,
            Borc
        }

        public int KasaID { get; set; }


        public DataTable KasaHareketListe(SqlConnection Baglanti, SqlTransaction Tr, int KasaID, bool SonAlinanZraporudanSonrakileriGetir)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand.CommandText = @"select SUM(Borc) from kasahareket 
where 1 = 1 

and
KasaHareket.KasaID = @Kasa";

            if (SonAlinanZraporudanSonrakileriGetir)
            {
                da.SelectCommand.CommandText = da.SelectCommand.CommandText + " and isnull((select top 1 ZRaporu.KasaHareketID from ZRaporu),-1) < KasaHareket.KasaHrID ";
            }


            DataTable dt = new DataTable();

            return dt;
        }

    }
}
