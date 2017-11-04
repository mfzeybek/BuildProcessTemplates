using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Aresv2.n11
{
    public partial class frmN11Urun : Form
    {
        public frmN11Urun(int StokID)
        {
            this.StokID = StokID;
            InitializeComponent();
        }

        int StokID; // stok ID nin -1 gelme ihtimali yok.
        clsTablolar.n11.csN11Product Urun;
        clsTablolar.n11.csN11Kategori Kategori;
        SqlTransaction TrGenel;
        clsTablolar.Stok.csStokMiktar miktar = new clsTablolar.Stok.csStokMiktar();

        private void frmN11Urun_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Urun = new clsTablolar.n11.csN11Product(SqlConnections.GetBaglanti(), TrGenel, StokID);

                TrGenel.Commit();
                KategoriDoldur();
                FiyatTanimlariniGetir();

                Al();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void Al()
        {
            treeListLookUpEdit1.EditValue = Urun.KategoriID;
            txtUrunBasligi.EditValue = Urun.UrunBasligi;
            txtAltBaslik.EditValue = Urun.AltBaslik;
            txtBarkod.EditValue = "";
            DetayliUrunBilgisi.DocumentText = Urun.DetayliUrunBilgisi;
            txtHazirlikSuresi.EditValue = Urun.HazirlikSuresi;
            txtStokMiktari.EditValue = miktar.StokMiktari;

            comboBoxEdit1.SelectedIndex = (int)Urun.StokMiktariEsitlemeSekli - 1;

            txtStokMiktari.EditValue = Urun.StokMiktariEsitlemeMiktari;
            lkpFiyatTanimlari.EditValue = Urun.KullanilacakFiyatTanimID;
            txtN11StokKodu.EditValue = Urun.N11StokKodu;

            cmbapprovalStatus.SelectedIndex = (int)Urun.N11approvalStatus - 1;
        }
        void Ver()
        {
            try
            {
                Urun.KategoriID = (int)treeListLookUpEdit1.EditValue;
                Urun.UrunBasligi = txtUrunBasligi.EditValue.ToString();
                Urun.AltBaslik = txtAltBaslik.EditValue.ToString();
                //Urun.txtBarkod.EditValue = "";
                Urun.DetayliUrunBilgisi = DetayliUrunBilgisi.DocumentText;
                Urun.HazirlikSuresi = Convert.ToInt32(txtHazirlikSuresi.EditValue);

                Urun.StokMiktariEsitlemeSekli = (clsTablolar.n11.csN11Product.StokMiktariEsitlemeSekliTanim)comboBoxEdit1.SelectedIndex + 1;
                Urun.StokMiktariEsitlemeMiktari = Convert.ToDecimal(txtStokMiktari.EditValue);
                Urun.KullanilacakFiyatTanimID = Convert.ToInt32(lkpFiyatTanimlari.EditValue);

                Urun.N11StokKodu = txtN11StokKodu.EditValue.ToString();

                Urun.N11approvalStatus = (clsTablolar.n11.csN11ApprovalStatus.approvalStatus)(cmbapprovalStatus.SelectedIndex + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void KategoriDoldur()
        {
            Kategori = new clsTablolar.n11.csN11Kategori();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            treeListLookUpEdit1.Properties.DataSource = Kategori.KategoriListesi(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();
            treeListLookUpEdit1.Properties.TreeList.PopulateColumns();
            treeListLookUpEdit1.Properties.TreeList.ParentFieldName = "n11UstKategoriID";
            treeListLookUpEdit1.Properties.TreeList.KeyFieldName = "n11KategoriID";
            treeListLookUpEdit1.Properties.DisplayMember = "KategoriAdi";
            treeListLookUpEdit1.Properties.ValueMember = "n11KategoriID";
        }


        private void btnAciklamaDuzenle_Click(object sender, EventArgs e)
        {
            using (frmhtmlEditor htmm = new frmhtmlEditor())
            {
                htmm.richEditControl1.HtmlText = Urun.DetayliUrunBilgisi;
                htmm.ShowDialog();
                DetayliUrunBilgisi.DocumentText = htmm.richEditControl1.HtmlText;
                Urun.DetayliUrunBilgisi = htmm.richEditControl1.HtmlText;
                //ButonlariAktifPasifYap(true);
            }
        }

        void FiyatTanimlariniGetir()
        {
            clsTablolar.csFiyatTanim tanim = new clsTablolar.csFiyatTanim();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            tanim.SatisTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();

            lkpFiyatTanimlari.Properties.DataSource = tanim.dt_SatisTanimlari;
            lkpFiyatTanimlari.Properties.DisplayMember = "FiyatTanimAdi";
            lkpFiyatTanimlari.Properties.ValueMember = "FiyatTanimID";
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ver();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Urun.Kaydet(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            csN11ProductService ahanda = new csN11ProductService();
            ahanda.ProducktGetir(txtN11StokKodu.Text);

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //n11CategoryService. aha = new Aresv2.n11CategoryService();
            csKategoriOzellikGosterme kat = new csKategoriOzellikGosterme();
            kat.main(Convert.ToInt64(treeListLookUpEdit1.EditValue));
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            csN11ProductService ahanda = new csN11ProductService();
            ahanda.ProducktGetir(txtN11StokKodu.Text);
            ahanda.description = DetayliUrunBilgisi.DocumentText;
            //ahanda.description = DetayliUrunBilgisi.Document.Body.InnerHtml;
            if (ahanda.ahandaaa() == csN11ProductService.KayitIslemi.Basarili)
            {
                MessageBox.Show("Basarili");
            }
        }
    }
}

