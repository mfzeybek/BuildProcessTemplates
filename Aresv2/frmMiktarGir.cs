using System;
using System.Windows.Forms;

namespace Aresv2
{
    public partial class frmMiktarGir : DevExpress.XtraEditors.XtraForm
    {
        public frmMiktarGir(decimal Miktar)
        {
            InitializeComponent();
            _Miktar = Miktar;
        }
        public decimal _Miktar = 1;

        private void XtraForm3_Load(object sender, EventArgs e)
        {
            textEdit1.EditValue = _Miktar;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          this.DialogResult = System.Windows.Forms.DialogResult.Yes;  
          this.Close();
        }

        private void frmMiktarGir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1_Click(null, null);
            }
        }

        

    }
}