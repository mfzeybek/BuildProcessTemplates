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

namespace Aresv2.Stok.Paket
{
    public partial class frmPaketListesi : Form
    {
        public frmPaketListesi()
        {
            InitializeComponent();
        }

        SqlTransaction TrGEnel;
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            clsTablolar.Stok.Paket.csPaketArama Arama = new clsTablolar.Stok.Paket.csPaketArama();
            TrGEnel = SqlConnections.GetBaglanti().BeginTransaction();
            gridControl1.DataSource = Arama.Getir(SqlConnections.GetBaglanti(), TrGEnel);
            TrGEnel.Commit();
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            frmPaketDetayi frm = new frmPaketDetayi((int)gridView1.GetFocusedRowCellValue("PaketID"));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
