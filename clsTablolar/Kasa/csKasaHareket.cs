﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Kasa
{
    public class csKasaHareket : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int KasaHrID { get; set; }
        public int KasaID { get; set; }
        public decimal Alacak { get; set; }
        public decimal Borc { get; set; }
        public string Aciklama { get; set; }

        public csKasaHareket()
        {
            this.KasaHrID = -1;
            this.KasaID = -1;
            this.Alacak = 0;
            this.Borc = 0;
            this.Aciklama = String.Empty;
        }

        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int KasaHrID)
        {
            if (KasaHrID == -1)
                return;

            using (SqlCommand cmd = new SqlCommand("Select * from KasaHareket where KasaHrID = @KasaHrID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@KasaHrID", SqlDbType.Int).Value = KasaHrID;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        this.KasaHrID = (int)dr["KasaHrID"];
                        this.KasaID = (int)dr["KasaID"];
                        this.Alacak = (decimal)dr["Alacak"];
                        this.Borc = (decimal)dr["Borc"];
                        this.Aciklama = dr["Aciklama"].ToString();
                    }
                }
            }
        }
        public int HarekeKaydet(SqlConnection Baglanti, SqlTransaction Tr, int KasaHrID, int KasaID, decimal Alacak, decimal Borc, string Aciklama)
        {
            this.KasaHrID = KasaHrID;
            this.KasaID = KasaID;
            this.Alacak = Alacak;
            this.Borc = Borc;
            this.Aciklama = Aciklama;


            return HarekeKaydet(Baglanti, Tr);
        }
        public int HarekeKaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Baglanti;
                cmd.Transaction = Tr;
                if (KasaHrID != -1)
                {
                    cmd.CommandText = "update KasaHareket set KasaID = @KasaID, Alacak = @Alacak, Borc = @Borc, Aciklama = @Aciklama where KasaHrID = @KasaHrID";
                    cmd.Parameters.Add("@KasaHrID", SqlDbType.Int).Value = KasaHrID;
                }
                else
                {
                    cmd.CommandText = @"insert into KasaHareket (KasaID, Alacak, Borc, Aciklama) values 
(@KasaID, @Alacak, @Borc, @Aciklama) set @YeniID = SCOPE_IDENTITY() ";
                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                }

                cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaID;
                cmd.Parameters.Add("@Alacak", SqlDbType.Decimal).Value = Alacak;
                cmd.Parameters.Add("@Borc", SqlDbType.Decimal).Value = Borc;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;

                cmd.ExecuteNonQuery();

                if (KasaHrID == -1)
                {
                    this.KasaHrID = (int)cmd.Parameters["@YeniID"].Value;
                }
            }

            //cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value;

            return KasaHrID;
        }


        public DataTable KasaListeGetir(SqlConnection baglanti, SqlTransaction Tr)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select * from Kasa", baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        /// <summary>
        /// Kasadaki Bütün Paraların çıkışını yapar.
        /// </summary>
        public void ZRaporuAl()
        {
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.CommandText = @"insert into ZRaporu (ZRaporuID, Tarih, Aciklama, RaporuAlanPersonelID, NakitTutar, KrediKartiTutari, KasaBakiyesi)
            //values(@ZRaporuID, @Tarih, @Aciklama, @RaporuAlanPersonelID, @NakitTutar, @KrediKartiTutari, @KasaBakiyesi)";
            //            cmd.Parameters.Add()
        }


    }
}

