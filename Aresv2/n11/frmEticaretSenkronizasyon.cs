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
            liste.DTolustir();

            //gridControl1.DataSource = liste.productList.AsEnumerable();
            //DevExpress.XtraGrid.GridLevelNode nodd = new DevExpress.XtraGrid.GridLevelNode();

            //BindingSource gPSucursalesBindingSource = new BindingSource(liste.productList.AsEnumerable(), "stockItems");
            //gPSucursalesBindingSource.DataSource = liste.productList;
            //gridView1.OptionsDetail.EnableMasterViewMode = true;
            //gPSucursalesBindingSource.child

            gridControl1.DataSource = liste.ds.Tables[0];
            //gridControl1.LevelTree.Nodes.Add("ahanda", gridView3);
            //gridView3.PopulateColumns(liste.ds.Tables[1]);




            //gridControl1.LevelTree.Nodes.Add(new DevExpress.XtraGrid.GridLevelNode)
            //gridView3.DefaultRelationIndex = 0;


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