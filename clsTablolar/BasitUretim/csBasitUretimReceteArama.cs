using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.BasitUretim
{
    public class csBasitUretimReceteArama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public string UretilenStokAdi { get; set; }
        public string UretilenStokKodu { get; set; }
        public string UretilenStokBarkodu { get; set; }
        public string UretilenStokAciklama { get; set; }

        public int StokGrupID { get; set; }
        public int StokAraGrupID { get; set; }
        public int StokAltGrupID { get; set; }

        public string HammaddeStokAdi { get; set; }
        public string HammaddeStokKoodu { get; set; }
        public string HammaddeStokBarkodu { get; set; }
        public string HammaddeStokAciklama { get; set; }
        public int HammaddeStokGrupID { get; set; }
        public int HammaddeStokAraGrupID { get; set; }
        public int HammaddeStokAltGrupID { get; set; }

        //şimdi ben burada yaparkenefsdfsdsdfdsfds

        //dfgdfgfdg
        /// <summary>
        /// /he ya.aver .
        /// </summary>


        private SqlDataAdapter da;
        public DataTable dt;

        public csBasitUretimReceteArama()
        {
            UretilenStokAdi = string.Empty;
            UretilenStokKodu = string.Empty;
            UretilenStokBarkodu = string.Empty;
            UretilenStokAciklama = string.Empty;
            StokGrupID = -1;
            StokAraGrupID = -1;
            StokAltGrupID = -1;

            HammaddeStokAdi = string.Empty;
            HammaddeStokKoodu = string.Empty;
            HammaddeStokBarkodu = string.Empty;
            HammaddeStokAciklama = string.Empty;
            HammaddeStokGrupID = -1;
            HammaddeStokAraGrupID = -1;
            HammaddeStokAltGrupID = -1;
        }

        public DataTable GetirHamisina(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da = new SqlDataAdapter(@"
select distinct UretilenStok.*,  BasitUretimRecetesi.* from BasitUretimRecetesi
inner join Stok as UretilenStok on UretilenStokID = UretilenStok.StokID
left join BasitUretimReceteDetayi on BasitUretimReceteDetayi.BUReceteID = BasitUretimRecetesi.BUReceteID
left Join Stok as HammaddeStok on HammaddeStok.StokID = BasitUretimReceteDetayi.MalzemeStokID
where 1 = 1 
", Baglanti);

            if (UretilenStokAdi != string.Empty)
            {
                da.SelectCommand.CommandText += " and UretilenStok.StokAdi like '%'+@UretilenStokAdi+'%'";
                da.SelectCommand.Parameters.Add("@UretilenStokAdi", SqlDbType.NVarChar).Value = UretilenStokAdi;
            }

            if (UretilenStokKodu != string.Empty)
            {
                da.SelectCommand.CommandText += " and UretilenStok.StokKodu = @UretilenStokKodu ";
                da.SelectCommand.Parameters.Add("@UretilenStokKodu", SqlDbType.NVarChar).Value = UretilenStokKodu;
            }

            if (UretilenStokBarkodu != string.Empty)
            {
                da.SelectCommand.CommandText += " and [dbo].[StokBarkoduAra](@UretilenStokBarkod) = UretilenStok.StokID ";
                da.SelectCommand.Parameters.Add("@UretilenStokBarkod", SqlDbType.NVarChar).Value = UretilenStokBarkodu;
            }

            if (StokGrupID != -1)
            {
                da.SelectCommand.CommandText += " and UretilenStok.StokGrupID = @StokGrupID ";
                da.SelectCommand.Parameters.Add("@StokGrupID", SqlDbType.NVarChar).Value = StokGrupID;
            }
            if (StokAraGrupID != -1)
            {
                da.SelectCommand.CommandText += " and UretilenStok.StokAraGrupID = @UretilenStokAraGrupID ";
                da.SelectCommand.Parameters.Add("@UretilenStokAraGrupID", SqlDbType.NVarChar).Value = StokAraGrupID;
            }
            if (StokAltGrupID != -1)
            {
                da.SelectCommand.CommandText += " and UretilenStok.StokAltGrupID = @UretilenStokAltGrupID ";
                da.SelectCommand.Parameters.Add("@UretilenStokAltGrupID", SqlDbType.NVarChar).Value = StokAltGrupID;
            }


            if (!string.IsNullOrEmpty(HammaddeStokAdi))
            {
                da.SelectCommand.CommandText += " and HammaddeStok.StokAdi like '%'+@HammaddeStokAdi+'%'";
                da.SelectCommand.Parameters.Add("@HammaddeStokAdi", SqlDbType.NVarChar).Value = HammaddeStokAdi;
            }

            if (!string.IsNullOrEmpty(HammaddeStokKoodu))
            {
                da.SelectCommand.CommandText += " and HammaddeStok.StokKodu = +@HammaddeStokKodu ";
                da.SelectCommand.Parameters.Add("@HammaddeStokKodu", SqlDbType.NVarChar).Value = HammaddeStokKoodu;
            }
            if (!string.IsNullOrEmpty(HammaddeStokBarkodu))
            {
                da.SelectCommand.CommandText += " and [dbo].[StokBarkoduAra](@HammaddeStokBarkodu) = HammaddeStok.StokID ";
                da.SelectCommand.Parameters.Add("@HammaddeStokBarkodu", SqlDbType.NVarChar).Value = HammaddeStokBarkodu;
            }

            if (HammaddeStokGrupID != -1)
            {
                da.SelectCommand.CommandText += " and HammaddeStok.StokGrupID like @HammaddeStokGrupID ";
                da.SelectCommand.Parameters.Add("@HammaddeStokGrupID", SqlDbType.Int).Value = HammaddeStokGrupID;
            }

            if (HammaddeStokAraGrupID != -1)
            {
                da.SelectCommand.CommandText += " and HammaddeStok.StokAraGrupID like @HammaddeStokAraGrupID ";
                da.SelectCommand.Parameters.Add("@HammaddeStokAraGrupID", SqlDbType.Int).Value = HammaddeStokAraGrupID;
            }
            if (HammaddeStokAltGrupID != -1)
            {
                da.SelectCommand.CommandText += " and HammaddeStok.StokAltGrupID like @HammaddeStokAltGrupID ";
                da.SelectCommand.Parameters.Add("@HammaddeStokAltGrupID", SqlDbType.Int).Value = HammaddeStokAltGrupID;
            }

            da.SelectCommand.Transaction = Tr;

            dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
    }
}
