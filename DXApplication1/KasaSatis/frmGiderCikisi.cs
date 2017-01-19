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


namespace KasaSatis
{
    public partial class frmGiderCikisi : Form
    {
        public frmGiderCikisi()
        {
            InitializeComponent();
        }


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
            using (frmGiderKarti frm = new frmGiderKarti(-1))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Getir();
                }
            }
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            using (frmGiderKarti frm = new frmGiderKarti(Convert.ToInt32(gridView1.GetFocusedRowCellValue("KasaHrID"))))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Getir();
                }
            }
        }
    }
}
