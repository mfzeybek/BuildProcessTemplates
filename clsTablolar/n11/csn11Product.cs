using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.n11
{
    public class csN11Product : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }




        public int n11ProductID { get; set; }
        public string UrunBasligi { get; set; }
        public string AltBaslik { get; set; }
        public decimal Fiyat { get; set; }
        public int KategoriID { get; set; }
        public int StokID { get; set; }
        public string DetayliUrunBilgisi { get; set; }
        public int HazirlikSuresi { get; set; }

        public int KullanilacakBarkodID { get; set; }

        public int KullanilacakFiyatTanimID { get; set; }

        public decimal Fiyati { get; set; } // bu stok kartından geliyor

        public string Barkodu { get; set; } // bu da stok kartından geliyor


        SqlDataReader dr;
        SqlCommand cmd;

        public csN11Product(SqlConnection Baglanti, SqlTransaction Tr, int stokID) // StokID buradan hiçbir zaman -1 gelmez zaten var olan stok un üzerine açılacak çünkü
        {
            if (stokID == -1) // Stok ID nin -1 gelme ihtimali yok çünkü açılmış bir stok kartına ekliyor
            {
                n11ProductID = -1;
                KategoriID = -1;
                stokID = -1;
                DetayliUrunBilgisi = string.Empty;
            }
            else
            {
                Getir(Baglanti, Tr, stokID);
            }
        }

        private void Getir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = " select * from n11Product where StokID = @StokID ";
                cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                cmd.Connection = Baglanti;
                cmd.Transaction = Tr;
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        this.n11ProductID = (int)dr["n11ProductID"];
                        this.UrunBasligi = dr["EtiketAdi"].ToString();
                        this.AltBaslik = dr["EtiketAdi"].ToString();
                        this.KategoriID = (int)dr["KategoriID"];
                        this.StokID = (int)dr["StokID"];
                        this.DetayliUrunBilgisi = dr["DetayliUrunBilgisi"].ToString();
                        this.HazirlikSuresi = (int)dr["HazirlikSuresi"];
                        this.KullanilacakBarkodID = (int)dr["KullanilacakBarkodID"];
                        this.KullanilacakFiyatTanimID = (int)dr["KullanilacakFiyatTanimID"];
                    }
                    else // stok Id ye bağlı n11 produckt yoksa yeni kayıt için verilen stokID den Stok Bilgilerini Getir
                    {
                        using (clsTablolar.Stok.csStok stk = new Stok.csStok(Baglanti, Tr, StokID))
                        {
                            this.n11ProductID = -1;
                            this.KategoriID = -1;
                            this.UrunBasligi = stk.EtiketAdi;
                            this.AltBaslik = string.Empty;
                            this.StokID = stk.StokID;
                            this.DetayliUrunBilgisi = string.Empty;
                            this.HazirlikSuresi = -1;
                            this.KullanilacakBarkodID = -1;
                            this.KullanilacakFiyatTanimID = -1;
                        }
                    }
                }
            }
        }
    }
}
