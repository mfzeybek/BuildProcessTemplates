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
using System.Data;
using System.Data.SqlClient;


namespace Aresv2.Terazi
{
    public partial class frmTeraziListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmTeraziListesi()
        {
            InitializeComponent();
        }

        clsTablolar.Terazi.csTeraziArama Arama = new clsTablolar.Terazi.csTeraziArama();
        SqlTransaction TrGenel;


        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Arama.TeraziGetir(SqlConnections.GetBaglanti(), TrGenel);

            gridControl1.DataSource = Arama.dt;

            TrGenel.Commit();
        }



        private void btnTeraziKartiniAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                frmTeraziKarti frm = new frmTeraziKarti((int)gridView1.GetFocusedRowCellValue("TeraziID"));
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }
    }
}