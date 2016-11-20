using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aresv2
{
  public partial class frmExceleAktar : DevExpress.XtraEditors.XtraForm
  {
    public frmExceleAktar(DevExpress.XtraGrid.GridControl GelenGrid)
    {
      InitializeComponent();
      _GelenGrid = GelenGrid;
    }
    DevExpress.XtraGrid.GridControl _GelenGrid;
    private void frmExcel_Load(object sender, EventArgs e)
    {
      try
      {
        sfdKaydet.Filter = "Excel Files |*.xls";

        if (sfdKaydet.ShowDialog() == DialogResult.OK)
        {
          _GelenGrid.ExportToXls(sfdKaydet.FileName);
          if (sfdKaydet.FileName != ".xls")
            if(XtraMessageBox.Show("Kaydetme Başarılı.\nKaydedilen Dosya Açılsın mı?", "Ares", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
              System.Diagnostics.Process.Start(sfdKaydet.FileName);
        }
        this.Dispose();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
  }
}