using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.Personel
{
    public partial class frmPdks : DevExpress.XtraEditors.XtraForm
    {
        public frmPdks()
        {
            InitializeComponent();
        }

        private void frmPdks_Load(object sender, EventArgs e)
        {
            PDKSSqlconnection pdks = new PDKSSqlconnection(); // bu bir kerelik türetilüyordu hamısına;

            labelControl1.Text = PDKSSqlconnection._Server.ToString();
            labelControl1.Text = PDKSSqlconnection.GetBaglanti().DataSource;
        }
        SqlTransaction TrGenel;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                TrGenel = PDKSSqlconnection.GetBaglanti().BeginTransaction();
                clsTablolar.Personel.PDKS.csPdksKrt pdks = new clsTablolar.Personel.PDKS.csPdksKrt();
                gridControl1.DataSource = pdks.HareketleriniGetir(PDKSSqlconnection.GetBaglanti(), TrGenel);
                TrGenel.Commit();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oldu");
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }
            frmPdksKart Kart = new frmPdksKart(Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID")));
            //Kart.MdiParent = this.MdiParent;
            Kart.ShowDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}