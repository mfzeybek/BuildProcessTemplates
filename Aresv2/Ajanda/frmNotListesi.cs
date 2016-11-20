using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


namespace Aresv2.Ajanda
{
  public partial class frmNotListesi : DevExpress.XtraEditors.XtraForm
  {
    public frmNotListesi()
    {
      InitializeComponent();
    }

    clsTablolar.Ajanda.csNotArama notlarrr = new clsTablolar.Ajanda.csNotArama();

    SqlTransaction TrGenel;

    clsTablolar.Ajanda.csNotGuruplari Gruplar = new clsTablolar.Ajanda.csNotGuruplari();


    private void btnFiltrele_Click(object sender, EventArgs e)
    {
      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

      gridControl1.DataSource = notlarrr.Listele(SqlConnections.GetBaglanti(), TrGenel);
      TrGenel.Commit();
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      if (gridView1.RowCount == 0) return;

      Ajanda.frmNotKarti frmm = new frmNotKarti(Convert.ToInt32(gridView1.GetFocusedRowCellValue("NotID")));
      frmm.MdiParent = this.MdiParent;
      frmm.Show();
    }

    SqlTransaction Trgenel;
    private void frmNotListesi_Load(object sender, EventArgs e)
    {
      try
      {
        Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
        Gruplar.GruplariDoldur(SqlConnections.GetBaglanti(), Trgenel);
        Trgenel.Commit();

        treeList1.DataSource = Gruplar.dt_NotGruplari;

        treeList1.KeyFieldName = "NotGurupID";
        treeList1.ParentFieldName = "UstGurupID";
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
  }
}