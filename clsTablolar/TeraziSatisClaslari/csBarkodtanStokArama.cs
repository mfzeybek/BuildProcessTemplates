using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.TeraziSatisClaslari
{
    public class csBarkodtanStokArama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public class StokIDMiktarBirim
        {
            public int StokID { get; set; }
            public decimal Miktar { get; set; }
            public int AltBirimID { get; set; } // Alt birim seçilmişse alt birim yoksa ana birimin ID si verilir.

            public decimal Katsayi { get; set; }
        }

        SqlDataReader dr;

        public StokIDMiktarBirim StokBarkodundanStokIDVer(SqlConnection Baglanti, SqlTransaction Tr, string Barkod)
        {
            using (SqlCommand cmd = new SqlCommand(@"BarkodtanUrunAra", Baglanti, Tr))
            {
                cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = Barkod;
                cmd.CommandType = CommandType.StoredProcedure;
                using (dr = cmd.ExecuteReader())
                {

                    StokIDMiktarBirim IDveMiktar = new StokIDMiktarBirim();

                    if (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            IDveMiktar.StokID = (int)dr["StokID"];
                            IDveMiktar.Miktar = (decimal)dr["Miktar"];
                            IDveMiktar.AltBirimID = (int)dr["StokBirimID"];
                            IDveMiktar.Katsayi = Convert.ToDecimal(dr["KatSayi"]);
                        }
                        else
                        {
                            IDveMiktar.StokID = -1;
                            IDveMiktar.Miktar = -1;
                            IDveMiktar.AltBirimID = -1;
                            IDveMiktar.Katsayi = -1;
                        }
                    }
                    else
                    {
                        IDveMiktar.StokID = -1;
                        IDveMiktar.Miktar = -1;
                        IDveMiktar.AltBirimID = -1;
                        IDveMiktar.Katsayi = -1;
                    }
                    return IDveMiktar; // herbişeyi eksik hamısınaaaa
                }
            }
        }





    }
}
