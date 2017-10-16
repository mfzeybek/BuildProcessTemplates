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

        public int KategoriID { get; set; }
        public int StokID { get; set; }
        public string DetayliUrunBilgisi { get; set; }
        public int HazirlikSuresi { get; set; }

        public string N11StokKodu { get; set; }

        public int KullanilacakBarkodID { get; set; }

        public int KullanilacakFiyatTanimID { get; set; }

        public StokMiktariEsitlemeSekliTanim StokMiktariEsitlemeSekli { get; set; }


        public enum StokMiktariEsitlemeSekliTanim
        {
            SabitMiktar = 1,
            StokMiktarıninAynisi = 2,
            StokMiktarindanAdetFazla = 3,
            StokMiktarindanAdetEksik = 4
        }

        public decimal StokMiktariEsitlemeMiktari { get; set; }

        enum EnfazlaSatisAdedi
        {
            EticarettekiStokMiktariKadar = 1,
        }




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
                        this.UrunBasligi = dr["UrunBasligi"].ToString();
                        this.AltBaslik = dr["AltBaslik"].ToString();
                        this.KategoriID = (int)dr["KategoriID"];
                        this.StokID = (int)dr["StokID"];
                        this.DetayliUrunBilgisi = dr["DetayliUrunBilgisi"].ToString();
                        this.HazirlikSuresi = (int)dr["HazirlikSuresi"];
                        this.KullanilacakBarkodID = (int)dr["KullanilacakBarkodID"];
                        this.KullanilacakFiyatTanimID = (int)dr["KullanilacakFiyatTanimID"];

                        if (dr["StokMiktariEsitlemeSekli"] != DBNull.Value)
                            this.StokMiktariEsitlemeSekli = (StokMiktariEsitlemeSekliTanim)Convert.ToInt16(dr["StokMiktariEsitlemeSekli"]);
                        else
                            this.StokMiktariEsitlemeSekli = StokMiktariEsitlemeSekliTanim.StokMiktarıninAynisi;

                        this.StokMiktariEsitlemeMiktari = Convert.ToDecimal(dr["StokMiktariEsitlemeMiktari"]);

                        this.N11StokKodu = dr["n11StokKodu"].ToString();
                    }

                    else // stok Id ye bağlı n11 produckt yoksa yeni kayıt için verilen stokID den Stok Bilgilerini Getir
                    {
                        dr.Close();
                        using (clsTablolar.Stok.csStok stk = new Stok.csStok(Baglanti, Tr, StokID))
                        {
                            this.n11ProductID = -1;
                            this.KategoriID = -1;
                            this.UrunBasligi = stk.StokAdi;
                            this.AltBaslik = stk.EtiketAdi;
                            this.StokID = stk.StokID;
                            this.DetayliUrunBilgisi = string.Empty;
                            this.HazirlikSuresi = 0;
                            this.KullanilacakBarkodID = -1;
                            this.KullanilacakFiyatTanimID = 2; // TODO: Bunu da ayarlardan alıcak
                            this.StokMiktariEsitlemeSekli = StokMiktariEsitlemeSekliTanim.StokMiktarıninAynisi;

                            this.StokMiktariEsitlemeMiktari = 0;
                            this.N11StokKodu = stk.StokKodu;
                        }
                    }
                }
            }
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (SqlCommand cmd = new SqlCommand("", Baglanti, Tr))
            {
                if (this.n11ProductID == -1)
                {
                    cmd.CommandText = " insert into n11Product (KategoriID, StokID, DetayliUrunBilgisi, HazirlikSuresi, KullanilacakBarkodID, KullanilacakFiyatTanimID, UrunBasligi, AltBaslik, StokMiktariEsitlemeSekli, StokMiktariEsitlemeMiktari, n11StokKodu) " +
                        "values " +
                        "(@KategoriID, @StokID, @DetayliUrunBilgisi, @HazirlikSuresi, @KullanilacakBarkodID, @KullanilacakFiyatTanimID, @UrunBasligi, @AltBaslik, @StokMiktariEsitlemeSekli, @StokMiktariEsitlemeMiktari, @n11StokKodu) set @YeniID = SCOPE_IDENTITY() ";

                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;


                }
                else
                {
                    cmd.CommandText = "update n11Product set KategoriID = @KategoriID, StokID = @StokID, DetayliUrunBilgisi = @DetayliUrunBilgisi, " +
                        "HazirlikSuresi = @HazirlikSuresi, KullanilacakBarkodID = @KullanilacakBarkodID, KullanilacakFiyatTanimID = @KullanilacakFiyatTanimID, UrunBasligi = @UrunBasligi, AltBaslik = @AltBaslik, StokMiktariEsitlemeSekli = @StokMiktariEsitlemeSekli, StokMiktariEsitlemeMiktari = @StokMiktariEsitlemeMiktari, n11StokKodu = @n11StokKodu where n11ProductID = @n11ProductID ";

                    cmd.Parameters.Add("@n11ProductID", SqlDbType.Int).Value = n11ProductID;
                }

                cmd.Parameters.Add("@KategoriID", SqlDbType.Int).Value = KategoriID;
                cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                cmd.Parameters.Add("@DetayliUrunBilgisi", SqlDbType.NVarChar).Value = DetayliUrunBilgisi;
                cmd.Parameters.Add("@HazirlikSuresi", SqlDbType.Int).Value = HazirlikSuresi;

                cmd.Parameters.Add("@KullanilacakBarkodID", SqlDbType.Int).Value = KullanilacakBarkodID;
                cmd.Parameters.Add("@KullanilacakFiyatTanimID", SqlDbType.Int).Value = KullanilacakFiyatTanimID;
                cmd.Parameters.Add("@UrunBasligi", SqlDbType.NVarChar).Value = UrunBasligi;
                cmd.Parameters.Add("@AltBaslik", SqlDbType.NVarChar).Value = AltBaslik;

                cmd.Parameters.Add("@StokMiktariEsitlemeSekli", SqlDbType.TinyInt).Value = StokMiktariEsitlemeSekli;
                cmd.Parameters.Add("@StokMiktariEsitlemeMiktari", SqlDbType.Decimal).Value = StokMiktariEsitlemeMiktari;

                cmd.Parameters.Add("@n11StokKodu", SqlDbType.NVarChar).Value = N11StokKodu;




                cmd.ExecuteNonQuery();

                if (n11ProductID == -1)
                {
                    n11ProductID = (int)cmd.Parameters["@YeniID"].Value;
                }
            }
        }
    }
}
