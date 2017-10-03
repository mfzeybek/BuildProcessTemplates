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

namespace Aresv2.n11
{
    public partial class frmN11ProductList : Form
    {
        public frmN11ProductList()
        {
            InitializeComponent();
        }

        clsTablolar.n11.csn11ProductList n11UrunListesi = new clsTablolar.n11.csn11ProductList();
        SqlTransaction TrGenel;


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            n11UrunListesi.Getir(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();

            gridControl2.DataSource = n11UrunListesi.dt;
        }

        private void frmN11ProductList_Load(object sender, EventArgs e)
        {

        }
    }
}
