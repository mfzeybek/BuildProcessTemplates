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

namespace Aresv2.Stok
{
    public partial class frmStokGruplari : DevExpress.XtraEditors.XtraForm
    {
        public frmStokGruplari()
        {
            InitializeComponent();
        }

        SqlTransaction TrGenel;
        clsTablolar.Stok.csStokGrup Guplar;


        private void frmStokGruplari_Load(object sender, EventArgs e)
        {

            Guplar = new clsTablolar.Stok.csStokGrup();
            treeList1.DataSource = Guplar.StokGrupDoldur(SqlConnections.GetBaglanti(), TrGenel);

            treeList1.ParentFieldName = "UstGrupID";

            treeList1.KeyFieldName = "StokGrupID";

        }
    }
}