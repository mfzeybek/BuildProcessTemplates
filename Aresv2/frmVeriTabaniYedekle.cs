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
using System.Data.SqlClient;

namespace Aresv2.Ayarlar
{
    public partial class frmVeriTabaniYedekle : DevExpress.XtraEditors.XtraForm
    {
        public frmVeriTabaniYedekle()
        {
            InitializeComponent();
        }

        private void frmVeriTabaniYedekle_Load(object sender, EventArgs e)
        {
            //textEdit3.Text = "C:\yedektirlo.bak";


        }

        private void btnYedekle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"BACKUP DATABASE [ARES] TO  DISK = N'C:\yedektirlo.bak' WITH NOFORMAT, NOINIT,  NAME = N'ARES-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", SqlConnections.GetBaglanti());
            cmd.ExecuteNonQuery();
        }
    }
}