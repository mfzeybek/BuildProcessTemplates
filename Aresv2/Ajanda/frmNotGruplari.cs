using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.Ajanda
{
  public partial class frmNotGruplari : DevExpress.XtraEditors.XtraForm
  {
    public frmNotGruplari()
    {
      InitializeComponent();
    }

    clsTablolar.Ajanda.csNotGuruplari gruplar;

    SqlTransaction TrGenel;

    private void frmNotGruplari_Load(object sender, EventArgs e)
    {
      try
      {
        gruplar = new clsTablolar.Ajanda.csNotGuruplari();
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        gruplar.GruplariDoldur(SqlConnections.GetBaglanti(), TrGenel);

        treeList1.DataSource = gruplar.dt_NotGruplari;

        treeList1.KeyFieldName = "NotGurupID";
        treeList1.ParentFieldName = "UstGurupID";

        TrGenel.Commit();
      }
      catch (Exception)
      {

        throw;
      }


    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {

      gruplar.dt_NotGruplari.Rows.Add(gruplar.dt_NotGruplari.NewRow());
      gruplar.dt_NotGruplari.Rows[gruplar.dt_NotGruplari.Rows.Count - 1]["GrupAdi"] = textEdit1.EditValue.ToString();

      if (checkEdit1.CheckState == CheckState.Checked)
      {
        gruplar.dt_NotGruplari.Rows[gruplar.dt_NotGruplari.Rows.Count - 1]["UstGurupID"] = treeList1.FocusedNode["NotGurupID"];
      }
      DevExpress.XtraTreeList.CellValueChangedEventArgs ee = new DevExpress.XtraTreeList.CellValueChangedEventArgs(null, treeList1.Nodes[treeList1.Nodes.Count - 1], null);
      
        treeList1_CellValueChanged(null, ee);
    }

    private void labelControl1_Click(object sender, EventArgs e)
    {

    }

    private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
    {
      try
      {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        //gruplar.GrupGuncelle(SqlConnections.GetBaglanti(), TrGenel, (DataRowView)treeList1.GetDataRecordByNode(treeList1.FocusedNode));
        gruplar.GrupGuncelle(SqlConnections.GetBaglanti(), TrGenel, (DataRowView)treeList1.GetDataRecordByNode(e.Node));

        TrGenel.Commit();
      }
      catch (Exception)
      {
        
        throw;
      }
      
    }
  }
}