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

namespace Aresv2.n11
{
    public partial class frmEticaretSenkronizasyon : DevExpress.XtraEditors.XtraForm
    {
        public frmEticaretSenkronizasyon()
        {
            InitializeComponent();
        }
        SqlTransaction TrGenel;

        DataTable dtArestekiStoklar;
        DataTable dtN11Deki;
        public void ArestekiN11StoklariniGetir()
        {
            clsTablolar.Stok.csStokArama stkArama = new clsTablolar.Stok.csStokArama();
            stkArama.N11Entegrasyonu = 1;

            stkArama.Aktif = true;
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            dtArestekiStoklar = stkArama.StokListeGetir(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();

            //JoinTwoDataTablesOnOneColumn(dtArestekiStoklar, )
        }

        public enum JoinType
        {
            /// <summary>
            /// Same as regular join. Inner join produces only the set of records that match in both Table A and Table B.
            /// </summary>
            Inner = 0,
            /// <summary>
            /// Same as Left Outer join. Left outer join produces a complete set of records from Table A, with the matching records (where available) in Table B. If there is no match, the right side will contain null.
            /// </summary>
            Left = 1
        }

        /// <summary>
        /// Joins the passed in DataTables on the colToJoinOn.
        /// <para>Returns an appropriate DataTable with zero rows if the colToJoinOn does not exist in both tables.</para>
        /// </summary>
        /// <param name="dtblLeft"></param>
        /// <param name="dtblRight"></param>
        /// <param name="colToJoinOn"></param>
        /// <param name="joinType"></param>
        /// <returns></returns>
        /// <remarks>
        /// <para>http://stackoverflow.com/questions/2379747/create-combined-datatable-from-two-datatables-joined-with-linq-c-sharp?rq=1</para>
        /// <para>http://msdn.microsoft.com/en-us/library/vstudio/bb397895.aspx</para>
        /// <para>http://www.codinghorror.com/blog/2007/10/a-visual-explanation-of-sql-joins.html</para>
        /// <para>http://stackoverflow.com/questions/406294/left-join-and-left-outer-join-in-sql-server</para>
        /// </remarks>
        public static DataTable JoinTwoDataTablesOnOneColumn(DataTable dtblLeft, DataTable dtblRight, string colToJoinOn, JoinType joinType)
        {
            //Change column name to a temp name so the LINQ for getting row data will work properly.
            string strTempColName = colToJoinOn + "_2";
            if (dtblRight.Columns.Contains(colToJoinOn))
                dtblRight.Columns[colToJoinOn].ColumnName = strTempColName;

            //Get columns from dtblLeft
            DataTable dtblResult = dtblLeft.Clone();

            //Get columns from dtblRight
            var dt2Columns = dtblRight.Columns.OfType<DataColumn>().Select(dc => new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));

            //Get columns from dtblRight that are not in dtblLeft
            var dt2FinalColumns = from dc in dt2Columns.AsEnumerable()
                                  where !dtblResult.Columns.Contains(dc.ColumnName)
                                  select dc;

            //Add the rest of the columns to dtblResult
            dtblResult.Columns.AddRange(dt2FinalColumns.ToArray());

            //No reason to continue if the colToJoinOn does not exist in both DataTables.
            if (!dtblLeft.Columns.Contains(colToJoinOn) || (!dtblRight.Columns.Contains(colToJoinOn) && !dtblRight.Columns.Contains(strTempColName)))
            {
                if (!dtblResult.Columns.Contains(colToJoinOn))
                    dtblResult.Columns.Add(colToJoinOn);
                return dtblResult;
            }

            switch (joinType)
            {

                default:
                case JoinType.Inner:
                    #region Inner
                    //get row data
                    //To use the DataTable.AsEnumerable() extension method you need to add a reference to the System.Data.DataSetExtension assembly in your project. 
                    var rowDataLeftInner = from rowLeft in dtblLeft.AsEnumerable()
                                           join rowRight in dtblRight.AsEnumerable() on rowLeft[colToJoinOn] equals rowRight[strTempColName]
                                           select rowLeft.ItemArray.Concat(rowRight.ItemArray).ToArray();


                    //Add row data to dtblResult
                    foreach (object[] values in rowDataLeftInner)
                        dtblResult.Rows.Add(values);

                    #endregion
                    break;
                case JoinType.Left:
                    #region Left
                    var rowDataLeftOuter = from rowLeft in dtblLeft.AsEnumerable()
                                           join rowRight in dtblRight.AsEnumerable() on rowLeft[colToJoinOn] equals rowRight[strTempColName] into gj
                                           from subRight in gj.DefaultIfEmpty()
                                           select rowLeft.ItemArray.Concat((subRight == null) ? (dtblRight.NewRow().ItemArray) : subRight.ItemArray).ToArray();


                    //Add row data to dtblResult
                    foreach (object[] values in rowDataLeftOuter)
                        dtblResult.Rows.Add(values);

                    #endregion
                    break;
            }

            //Change column name back to original
            dtblRight.Columns[strTempColName].ColumnName = colToJoinOn;

            //Remove extra column from result
            dtblResult.Columns.Remove(strTempColName);

            return dtblResult;
        }
        csN11ProductList liste = new csN11ProductList();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            liste.UrunlistesiniGetir();
            liste.DTolustir();

            //gridControl1.DataSource = liste.productList.AsEnumerable();
            //DevExpress.XtraGrid.GridLevelNode nodd = new DevExpress.XtraGrid.GridLevelNode();

            //BindingSource gPSucursalesBindingSource = new BindingSource(liste.productList.AsEnumerable(), "stockItems");
            //gPSucursalesBindingSource.DataSource = liste.productList;
            //gridView1.OptionsDetail.EnableMasterViewMode = true;
            //gPSucursalesBindingSource.child

            gridControl1.DataSource = liste.ds.Tables[0];
            dtN11Deki = liste.ds.Tables[0];
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ArestekiN11StoklariniGetir();

            //var result = from o in dtArestekiStoklar.AsEnumerable()
            //             from p in dtN11Deki.AsEnumerable()
            //             select new
            //             {
            //                 id = o["StokKodu"],
            //                 id2 = p[9]
            //                 //id3 = p["id"]
            //                 //p.ProductName,
            //                 //o.Quantity,
            //                 //o.TotalAmount,
            //                 //o.OrderDate
            //             };

            //gridControl1.DataSource = result;
            //gridView1.PopulateColumns();


            var q =
    from c in dtArestekiStoklar.AsEnumerable()
    join p in dtN11Deki.AsEnumerable() on c["StokKodu"] equals p[9] into ps
    from p in ps.DefaultIfEmpty()
    select new { Category = c["StokKodu"], ProductName = p == null ? "(No products)" : p[9] };

            gridControl1.DataSource = q;
            gridView1.PopulateColumns();
        }
    }
}