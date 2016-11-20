using System;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace clsTablolar
{
    public partial class frmYaziciSec : DevExpress.XtraEditors.XtraForm
    {
        public frmYaziciSec()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        public string SecilenYaziciAdi;
        private void frmYaziciSec_Load(object sender, EventArgs e)
        {
            foreach (String yazici in PrinterSettings.InstalledPrinters)
            {
                listBoxControl1.Items.Add(yazici);
            }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            SecilenYaziciAdi = listBoxControl1.SelectedValue.ToString();
        }
    }
}