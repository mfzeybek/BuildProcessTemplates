using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aresv2.n11
{
    public partial class frmEticaretSenkronizasyon : DevExpress.XtraEditors.XtraForm
    {
        public frmEticaretSenkronizasyon()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            csN11ProductList liste = new csN11ProductList();
            liste.UrunlistesiniGetir();
        }

        private void frmEticaretSenkronizasyon_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            n11.csN11ProductService urun = new csN11ProductService();
            urun.ProducktGetir("S04013");
        }
    }
}