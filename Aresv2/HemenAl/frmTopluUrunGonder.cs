using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.HemenAl
{
    public partial class frmTopluUrunGonder : DevExpress.XtraEditors.XtraForm
    {
        public frmTopluUrunGonder()
        {
            InitializeComponent();
        }

        clsTablolar.Stok.csStokArama Arama;


        SqlTransaction trgenel;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Stok.frmStokListesi liste = new Stok.frmStokListesi(true);


            liste.Stok_Sec = StokListedelege;

            //liste.Show();
            //liste.cmbEMagazaErisimi.Text = "Olan";
            //liste.cmbEMagazaErisimi.SelectedIndex = 2;

            //liste.cmbEMagazaErisimi.Enabled = false;
            //liste.Visible = false;

            liste.StokArama.EMagazaErisimi = 1;
            liste.cmbEMagazaErisimi.SelectedIndex = 1;
            liste.cmbEMagazaErisimi.Enabled = false;
            liste.ShowDialog();

        }


        DataTable dt = new DataTable();


        clsTablolar.Stok.csStok StoBilgileri;
        public void StokListedelege(int StokID, decimal Miktar)
        {
            trgenel = SqlConnections.GetBaglanti().BeginTransaction();
            StoBilgileri = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trgenel, StokID);
            trgenel.Commit();

            dt.Rows.Add(dt.NewRow());

            dt.Rows[dt.Rows.Count - 1]["StokID"] = StoBilgileri.StokID;
            dt.Rows[dt.Rows.Count - 1]["StokAdi"] = StoBilgileri.StokAdi;
            dt.Rows[dt.Rows.Count - 1]["StokKodu"] = StoBilgileri.StokKodu;
        }

        private void frmTopluUrunGonder_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("StokID");
            dt.Columns.Add("StokKodu");
            dt.Columns.Add("StokAdi");

            gridControl1.DataSource = dt;
        }


        csHemenAlGetSet hemeaq;
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            string Cevap = "";
            using (hemeaq = new csHemenAlGetSet())
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {

                    trgenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Cevap += hemeaq.HememAl_SetUrun(SqlConnections.GetBaglanti(), trgenel, Convert.ToInt32(gridView1.GetRowCellValue(i, "StokID")));

                    // yukarıdan hemenal daki ürün ün Id si dönüyor;
                    Cevap += " ID li" + "\n" + gridView1.GetRowCellValue(i, "StokKodu") + " " + gridView1.GetRowCellValue(i, "StokAdi");
                    memoEdit1.Lines = Cevap.Split('\n');
                    trgenel.Commit();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(gridView1.GetFocusedRowCellValue("StokAdi").ToString() + "\nİsimli kayıt çıkartılacak", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                gridView1.DeleteSelectedRows();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            Stok.frmStokDetay frm = new Stok.frmStokDetay(Convert.ToInt32(gridView1.GetFocusedRowCellValue("StokID")));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}