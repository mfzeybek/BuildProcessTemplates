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

namespace Aresv2.BasitUretim
{
    public partial class frmUretimListesi : Form
    {
        public frmUretimListesi()
        {
            InitializeComponent();
        }

        clsTablolar.BasitUretim.csBasitUretimArama arama = new clsTablolar.BasitUretim.csBasitUretimArama();
        SqlTransaction TrGenel;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            arama.Getir(SqlConnections.GetBaglanti(), TrGenel);
            gridControl1.DataSource = arama.dt;
            TrGenel.Commit();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            BasitUretim.frmBasitUretim frm = new frmBasitUretim((int)gridView1.GetFocusedRowCellValue(colBasitUretimID));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
