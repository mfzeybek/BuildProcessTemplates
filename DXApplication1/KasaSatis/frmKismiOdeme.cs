using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasaSatis
{
    public partial class frmKismiOdeme : Form
    {
        public frmKismiOdeme()
        {
            InitializeComponent();
        }

        // şimdilik Pos cihazlarını da kasa olarak kaydettik. o yüzden
        public int KismiOdemesiYapilanKasaID; // buraya şimdilik pos cihazla
        public decimal Tutar;
        public string Aciklama;

        private void frmKismiOdeme_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == -1)
            {
                MessageBox.Show("Ödeme tipi seçilmedi.");
                return;
            }
            Tutar = Convert.ToDecimal(textEdit1.EditValue);
            KismiOdemesiYapilanKasaID = Convert.ToInt32(radioGroup1.EditValue);
            Aciklama = memoEdit1.Text;
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void btnTutarGir_Click(object sender, EventArgs e)
        {
            clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                textEdit1.EditValue = frm.textEdit1.EditValue;
            }
        }

        private void memoEdit1_Enter(object sender, MouseEventArgs e)
        {

        }

        private void memoEdit1_Click(object sender, EventArgs e)
        {

        }

        private void btnAciklama_Click(object sender, EventArgs e)
        {
            clsTablolar.TeraziSatisClaslari.frmYaziGirisi frm = new clsTablolar.TeraziSatisClaslari.frmYaziGirisi();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                memoEdit1.EditValue = frm.memoEdit1.EditValue;
            }
        }
    }
}
