using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace KasaSatis
{
    public partial class frmGiderCikisi : Form
    {
        public frmGiderCikisi(int PersonelID)
        {
            this.PersonelID = PersonelID;
            InitializeComponent();
        }

        int PersonelID = -1;

        clsTablolar.Kasa.csKasaHareketArama GiderHareketi = new clsTablolar.Kasa.csKasaHareketArama();
        SqlTransaction TrGenel;


        private void frmGiderCikisi_Load(object sender, EventArgs e)
        {

            GiderHareketi.SonZRaporundanSonraMi = true;
            GiderHareketi.KasaID = KasaSatis.Properties.Settings.Default.KasaID;
            GiderHareketi.Yonu = clsTablolar.Kasa.csKasaHareketArama.hareketYonu.Borc;

            Getir();
        }

        void Getir()
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            gridControl1.DataSource = GiderHareketi.KasaHareketListe(SqlConnections.GetBaglanti(), TrGenel, KasaSatis.Properties.Settings.Default.KasaID);
            TrGenel.Commit();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        clsTablolar.Kasa.csKasaHareket Hareket = new clsTablolar.Kasa.csKasaHareket();

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            using (frmGiderKarti frm = new frmGiderKarti(-1, PersonelID))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Getir();
                }
            }
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;

            using (frmGiderKarti frm = new frmGiderKarti(Convert.ToInt32(gridView1.GetFocusedRowCellValue("KasaHrID")), PersonelID))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Getir();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili Gideri Silmek İstediğine Emin misin??", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Hareket.HareketiSil(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gridView1.GetFocusedRowCellValue("KasaHrID")));
                TrGenel.Commit();
            }
            catch (Exception)
            {
                MessageBox.Show("Silme İşleminde Hata");
            }
            Getir();
        }
    }
}
