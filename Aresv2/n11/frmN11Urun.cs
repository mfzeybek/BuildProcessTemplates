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
    }
}
