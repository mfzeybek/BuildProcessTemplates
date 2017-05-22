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

        DataTable dt_Giderler;
        SqlDataAdapter da;

        public csKasaHareketArama()
        {
            this.Yonu = hareketYonu.Hepsi;
            this.KasaID = -1;
            this.SonZRaporundanSonraMi = false;


        }

        public DataTable KasaHareketListe(SqlConnection Baglanti, SqlTransaction Tr, int KasaID)
        {
            da = new SqlDataAdapter(@"select kasahareket.KasaHrID, Aciklama ,Borc from kasahareket
where 1 = 1 ", Baglanti);
            da.SelectCommand.Transaction = Tr;
            //            da.SelectCommand.CommandText = @"select SUM(Borc) from kasahareket 
            //where 1 = 1 ";

            if (SonZRaporundanSonraMi)
            {
                da.SelectCommand.CommandText = da.SelectCommand.CommandText + " and isnull((select top 1 KasaHareketID from KasaRaporu order by KasaHareketID desc),-1) < KasaHareket.KasaHrID ";
            }
            if (KasaID != -1)
            {
                da.SelectCommand.CommandText = da.SelectCommand.CommandText + " and KasaHareket.KasaID = @KasaID ";
                da.SelectCommand.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaID;
            }
            if (Yonu == hareketYonu.Borc)
            {
                da.SelectCommand.CommandText = da.SelectCommand.CommandText + " and Borc > 0 ";
            }

            using (dt_Giderler = new DataTable())
            {
                da.Fill(dt_Giderler);
                return dt_Giderler;
            }
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da.InsertCommand = new SqlCommand("insert into KasaHareket (KasaID, Alacak, Borc, Aciklama, Tarih, HareketTipi)");

            //da.InsertCommand.Parameters.Add
        }
    }
}
