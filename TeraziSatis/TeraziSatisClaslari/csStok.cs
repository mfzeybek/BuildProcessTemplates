using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TeraziSatis.cls
{
    public class csStok : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int StokID { get; set; }
        public string StokAdi { get; set; }
        public decimal Kdv { get; set; }
        public decimal Barkod { get; set; }

        public decimal KdvDahilFiyat { get; set; }
        public decimal KdvHaricFiyat { get; set; }

        public int AnaBirimID { get; set; }


        SqlCommand cmd;
        SqlDataReader dr;

        // şimdilik fiyatı satış fiyatımızdan kullanıyoruz ama normalde fiyatı cariden alıcak

        public void GetirHamisina(SqlConnection Baglanti, SqlTransaction TrGenel, int StokID)
        {
            if (StokID == -1) // hangi ihtimallerde -1 verilebilir birleşik ürün istendiğinde sanırım
            {
                this.StokID = -1;
                StokAdi = "";
                Kdv = 0;
                KdvDahilFiyat = 0;
                KdvHaricFiyat = 0;
                AnaBirimID = 0;
            }
            else
            {
                using (cmd = new SqlCommand(@"select stok.StokID, StokKodu, StokAdi, Barkod, 

case
when StokFiyat.KdvDahil = 1 -- fiyata kdv dahilse direk kdv dahil fiyatını ver
then StokFiyat.Fiyat
when StokFiyat.KdvDahil = 0 -- Fiyata kdv dahil değilse kdv hariş fiyat olarak direk ver
then StokFiyat.Fiyat + ((100 + StokFiyat.Fiyat * SatisKdv)/ 100)
end
as KdvDahilFiyat, -- bu fiyatlar tabi ana birim in fiyatı

case
when StokFiyat.KdvDahil = 1 -- fiyata kdv dahilse kdv sini çıkar kdv hariç fiyat olarak ver
then StokFiyat.Fiyat / ((100 + Stok.SatisKdv)/ 100)
when StokFiyat.KdvDahil = 0 -- Fiyata kdv dahil değilse kdv hariş fiyat olarak direk ver
then StokFiyat.Fiyat 
end
as KdvHaricFiyat, -- bu fiyatlar tabi ana birim in fiyatı
Stok.SatisKdv, Stok.StokBirimID

  from stok
inner join StokFiyat on StokFiyat.StokID = Stok.stokID and FiyatTanimID = 2 -- bunu sonradan ayarlardan veya seçilen cariye göre alıcak
where stok.StokID = @StokID


", Baglanti, TrGenel))
                {
                    cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            this.StokID = (int)dr["StokID"];
                            StokAdi = dr["StokAdi"].ToString();
                            Kdv = (decimal)dr["SatisKdv"];
                            KdvDahilFiyat = Convert.ToDecimal(dr["KdvDahilFiyat"]);
                            KdvHaricFiyat = Convert.ToDecimal(dr["KdvHaricFiyat"]);
                            AnaBirimID = (int)dr["StokBirimID"];
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

        public void GetirHamisina(SqlConnection Baglanti, SqlTransaction Tr, string Barkod)
        {

        }

    }
}
