using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.n11
{
    public partial class frmEticaretSenkronizasyon : DevExpress.XtraEditors.XtraForm
    {
        public frmEticaretSenkronizasyon()
        {
            InitializeComponent();
        }
        SqlTransaction TrGenel;

        DataTable dtArestekiStoklar;
        DataTable dtN11Deki;
        public void ArestekiN11StoklariniGetir()
        {
            clsTablolar.Stok.csStokArama stkArama = new clsTablolar.Stok.csStokArama();
            stkArama.N11Entegrasyonu = 1;

            stkArama.Aktif = true;
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            dtArestekiStoklar = stkArama.StokListeGetir(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();
        }

        void ArestekiStoklarIcinVtYiOluştur()
        {


        }



        csN11ProductList liste = new csN11ProductList();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            liste.UrunlistesiniGetir();
            liste.DTolustir();
            dtN11Deki = liste.ds.Tables[0];
            //gridControl1.DataSource = liste.ds.Tables[0];
            //gridView1.PopulateColumns();

            //return;

            liste.ds.Tables[0].Columns.Add("ArestekiN11Fiyati", typeof(System.Decimal));

            foreach (var item in liste.ds.Tables[0].AsEnumerable())
            {
                //item["ArestekiN11Fiyati"] = Convert.ToDecimal(AresStokununN11IcinTanimliFiyatiniGetir(item["StokID"], item[]));
            }




            var AresteOlupN11deOlmayanlar =
    from Aresteki in dtArestekiStoklar.AsEnumerable()
    join N11Deki in dtN11Deki.AsEnumerable() on Aresteki["AresN11StokKodu"] equals N11Deki[9] into ps
    from N11Deki in ps.DefaultIfEmpty()
    where (N11Deki == null)
    select new
    {
        StokID = (int)Aresteki["AresStokID"],
        StokAdi = Aresteki["AresUrunBasligi"].ToString(),
        n11dekiTitle = Aresteki["AresAltBaslik"].ToString(),

        Aciklama = "Areste var n11 stok kartı açılmamış",
        ArestekiStokKodu = Aresteki["AresN11StokKodu"].ToString(),
        N11DekiStokKodu = string.Empty,
        KalanMiktar = (decimal)Aresteki["ArestekiN11Miktari"],
        Fiyat = (decimal)Aresteki["AresTekiN11Fiyati"],
    };

            try
            {
                var N11deOlupAresteOlmayanlar =
from N11Deki in dtN11Deki.AsEnumerable()
join Aresteki in dtArestekiStoklar.AsEnumerable() on N11Deki[9] equals Aresteki["AresN11StokKodu"] into ps
from Aresteki in ps.DefaultIfEmpty()
where (Aresteki == null)//|| k.CategoryName == "Condiments") && (l.City == "London" || l.City == "Bend") && b.Quantity == 20
select new
{

    Aciklama = "N11 de var Areste n11 kartı açılmamış",

    approvalStatus = N11Deki["approvalStatus"],
    approvalStatus2 = N11Deki["approvalStatus2"],
    currencyAmount = N11Deki["currencyAmount"],
    currencyType = N11Deki["currencyType"],
    oldPrice = N11Deki["oldPrice"],
    price = N11Deki["price"],

    saleStatus = N11Deki["saleStatus"],
    StokID = -2,

    n11dekiTitle = N11Deki["title"].ToString(),

    AresStokAdi = string.Empty,

    title = N11Deki["title"].ToString(),
    subtitle = N11Deki["subtitle"].ToString(),
    displayPrice = Convert.ToDecimal(N11Deki["displayPrice"]),
    productSellerCode = N11Deki["productSellerCode"].ToString(),
    StokMiktari = Convert.ToDecimal(N11Deki["StokMiktari"]),
    N11DekiStokKodu = N11Deki == null ? "(Kayıtlı Değil)" : N11Deki[9]
};

                var Farklar =
                    from N11Deki in dtN11Deki.AsEnumerable()
                    join Aresteki in dtArestekiStoklar.AsEnumerable() on N11Deki[9] equals Aresteki["AresN11StokKodu"] into ps
                    from Aresteki in ps.DefaultIfEmpty()
                    where !(Aresteki == null || N11Deki == null)//|| k.CategoryName == "Condiments") && (l.City == "London" || l.City == "Bend") && b.Quantity == 20
                    select new
                    {
                        Aciklama = (Aresteki == null ? "Arese Kayıtlı Değil" :
                    Convert.ToDecimal(Aresteki["ArestekiN11Miktari"]).ToString("0.##") == Convert.ToDecimal(N11Deki["StokMiktari"]).ToString("0.##") ? "Miktarları Aynı" :
                    "Miktarlar Farklı"),


                        AresMiktari = Convert.ToDecimal(Aresteki["ArestekiN11Miktari"]),
                        N11Miktari = Convert.ToDecimal(N11Deki["StokMiktari"]),

                        AresStokAdi = Aresteki["AresUrunBasligi"].ToString(),
                        n11Title = N11Deki["title"].ToString(),

                        AresFiyati = (decimal)Aresteki["AresTekiN11Fiyati"],
                        n11Fiyati = Convert.ToDecimal(N11Deki["displayPrice"]),
                        StokID = (int)Aresteki["AresStokID"],

                        id = N11Deki["id"],
                        title = N11Deki["title"],
                        subtitle = N11Deki["subtitle"],
                        displayPrice = N11Deki["displayPrice"],
                        approvalStatus = N11Deki["approvalStatus"], // güncel durum
                        approvalStatus2 = N11Deki["approvalStatus2"], // güncel durum
                        currencyAmount = N11Deki["currencyAmount"],
                        currencyType = N11Deki["currencyType"],
                        oldPrice = N11Deki["oldPrice"],
                        price = N11Deki["price"],
                        productSellerCode = N11Deki["productSellerCode"],
                        saleStatus = N11Deki["saleStatus"],
                        StokMiktari = N11Deki["StokMiktari"],



                        N11DekiStokKodu = N11Deki["productSellerCode"].ToString()
                    };

                var ahanda =

                N11deOlupAresteOlmayanlar.Select(y => new
                {
                    StokID = y.StokID,
                    StokAdi = y.n11dekiTitle,
                    n11dekiTitle = y.n11dekiTitle,
                    Aciklama = y.Aciklama,
                    AresStokkodu = y.productSellerCode,
                    AresFiyati = Convert.ToDecimal(0),
                    n11Fiyati = y.displayPrice,
                    AresMiktari = Convert.ToDecimal(0),
                    n11Miktari = y.StokMiktari,
                    approvalStatus = y.approvalStatus.ToString(),
                    approvalStatus2 = y.approvalStatus2.ToString()
                }).Union
                (
                    AresteOlupN11deOlmayanlar.Select(z => new
                    {
                        StokID = z.StokID,
                        StokAdi = z.StokAdi,
                        n11dekiTitle = z.n11dekiTitle,
                        Aciklama = z.Aciklama,
                        AresStokkodu = z.ArestekiStokKodu.ToString(),
                        AresFiyati = z.Fiyat,
                        n11Fiyati = Convert.ToDecimal(0),
                        AresMiktari = z.KalanMiktar,
                        n11Miktari = Convert.ToDecimal(0),
                        approvalStatus = string.Empty,
                        approvalStatus2 = string.Empty
                    })
            );
                var ahanda2 = Farklar.Select(x => new
                {
                    StokID = x.StokID,
                    StokAdi = x.AresStokAdi,
                    n11dekiTitle = x.n11Title,
                    Aciklama = x.Aciklama,
                    StokKodu = x.N11DekiStokKodu,
                    AresFiyati = x.AresFiyati,
                    n11Fiyati = x.n11Fiyati,
                    AresMiktari = x.AresMiktari,
                    n11Miktari = x.N11Miktari,
                    approvalStatus = x.approvalStatus.ToString(),
                    approvalStatus2 = x.approvalStatus2.ToString()

                }
                    ).Union(ahanda.Select(z => new
                    {
                        StokID = z.StokID,
                        StokAdi = z.StokAdi,
                        n11dekiTitle = z.n11dekiTitle,
                        Aciklama = z.Aciklama,
                        StokKodu = z.AresStokkodu,
                        AresFiyati = z.AresFiyati,
                        n11Fiyati = z.n11Fiyati,
                        AresMiktari = z.AresMiktari,
                        n11Miktari = z.n11Miktari,
                        approvalStatus = z.approvalStatus,
                        approvalStatus2 = z.approvalStatus2.ToString()

                    }));

                gridControl1.DataSource = ahanda2;
                gridView1.PopulateColumns();
            }
            catch (Exception ex)
            {

            }
        }

        private void frmEticaretSenkronizasyon_Load(object sender, EventArgs e)
        {
            dtArestekiStoklar = new DataTable();
            dtArestekiStoklar.Columns.Add("AresStokID", typeof(System.Int32));
            dtArestekiStoklar.Columns.Add("AresN11StokKodu", typeof(System.String));
            dtArestekiStoklar.Columns.Add("AresUrunBasligi", typeof(System.String));
            dtArestekiStoklar.Columns.Add("AresAltBaslik", typeof(System.String));
            dtArestekiStoklar.Columns.Add("ArestekiN11Miktari", typeof(System.Decimal));
            dtArestekiStoklar.Columns.Add("AresTekiN11Fiyati", typeof(System.Decimal));

            gridControl1.DataSource = dtArestekiStoklar;
        }
        Stok.frmStokDetay frmStok;
        private void btnStokKartiniAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;

            int StokID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("StokID"));

            if (StokID < 0)
            {
                MessageBox.Show("Bu stok Areste bir stoga baglanmamis veya arest böyle bir stok yok");
                return;
            }
            frmStok = new Stok.frmStokDetay(StokID);
            frmStok.MdiParent = this.MdiParent;
            frmStok.Show();
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            Stok.frmStokListesi frm = new Stok.frmStokListesi(true);
            frm.Stok_Sec = stokEkle;
            frm.StokArama.N11Entegrasyonu = 1;
            frm.cmbN11.SelectedIndex = 1;
            frm.cmbN11.Enabled = false;
            frm.ShowDialog();
        }
        clsTablolar.Stok.csStokMiktar miktarr = new clsTablolar.Stok.csStokMiktar();

        void stokEkle(int StokID, decimal Miktar)
        {
            try
            {
                DataRow dr = dtArestekiStoklar.NewRow();

                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                //clsTablolar.Stok.csStok stokEkleme = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, StokID);
                clsTablolar.n11.csN11Product n11Prod = new clsTablolar.n11.csN11Product(SqlConnections.GetBaglanti(), TrGenel, StokID);
                clsTablolar.Stok.csStokFiyat Fiyat = new clsTablolar.Stok.csStokFiyat();

                dr["AresStokID"] = StokID;
                dr["AresN11StokKodu"] = n11Prod.N11StokKodu;
                dr["AresUrunBasligi"] = n11Prod.UrunBasligi;
                dr["AresAltBaslik"] = n11Prod.AltBaslik;

                switch (n11Prod.StokMiktariEsitlemeSekli)
                {
                    case clsTablolar.n11.csN11Product.StokMiktariEsitlemeSekliTanim.SabitMiktar:
                        dr["ArestekiN11Miktari"] = n11Prod.StokMiktariEsitlemeMiktari;
                        break;
                    case clsTablolar.n11.csN11Product.StokMiktariEsitlemeSekliTanim.StokMiktarıninAynisi:
                        dr["ArestekiN11Miktari"] = miktarr.StokMiktariGetir(SqlConnections.GetBaglanti(), TrGenel, StokID);
                        break;
                    case clsTablolar.n11.csN11Product.StokMiktariEsitlemeSekliTanim.StokMiktarindanAdetFazla:
                        dr["ArestekiN11Miktari"] = miktarr.StokMiktariGetir(SqlConnections.GetBaglanti(), TrGenel, StokID) + n11Prod.StokMiktariEsitlemeMiktari;
                        break;
                    case clsTablolar.n11.csN11Product.StokMiktariEsitlemeSekliTanim.StokMiktarindanAdetEksik:
                        dr["ArestekiN11Miktari"] = miktarr.StokMiktariGetir(SqlConnections.GetBaglanti(), TrGenel, StokID) - n11Prod.StokMiktariEsitlemeMiktari;
                        break;
                    default:
                        break;
                }

                dr["AresTekiN11Fiyati"] = Fiyat.StokFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, StokID, n11Prod.KullanilacakFiyatTanimID);

                TrGenel.Commit();
                dtArestekiStoklar.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        n11.frmN11Urun n11frm;
        private void btnN11KartiniAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;

            int StokID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("StokID"));

            if (StokID < 0)
            {
                MessageBox.Show("Bu stok Areste bir stoga baglanmamis veya areste böyle bir stok yok");
                return;
            }
            n11frm = new frmN11Urun(StokID);
            n11frm.MdiParent = this.MdiParent;
            n11frm.Show();
        }

        public void SatisaBaslat(string StokKodu)
        {


        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;
            string StokKodu = gridView1.GetFocusedRowCellValue("StokKodu").ToString();
            liste.UrunSatisiniBaaslat(StokKodu);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;
            string StokKodu = gridView1.GetFocusedRowCellValue("StokKodu").ToString();
            liste.UrunSatisiniDurdur(StokKodu);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;
            string StokKodu = gridView1.GetFocusedRowCellValue("StokKodu").ToString();
            liste.StokMiktariGuncelle(StokKodu, 12, 0);
        }
    }
}