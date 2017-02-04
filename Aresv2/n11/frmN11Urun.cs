using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Aresv2.n11
{
    public partial class frmN11Urun : Form
    {
        public frmN11Urun()
        {
            InitializeComponent();
        }

        private void frmN11Urun_Load(object sender, EventArgs e)
        {

        }



        private void btnAciklamaDuzenle_Click(object sender, EventArgs e)
        {
            using (frmhtmlEditor htmm = new frmhtmlEditor())
            {
                htmm.richEditControl1.HtmlText = Stok.DetayliUrunBilgisi;
                htmm.ShowDialog();
                DetayliUrunBilgisi.DocumentText = htmm.richEditControl1.HtmlText;
                Stok.DetayliUrunBilgisi = htmm.richEditControl1.HtmlText;
                ButonlariAktifPasifYap(true);
            }
        }
    }
}
