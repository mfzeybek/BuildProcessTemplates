using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aresv2
{
  public partial class frmWebEntegrasyonUrunler : DevExpress.XtraEditors.XtraForm
  {
    public frmWebEntegrasyonUrunler()
    {
      InitializeComponent();
    }
    csHemenAlGetSet hemenalma;
    private void frmWebEntegrasyonUrunler_Load(object sender, EventArgs e)
    {
      try
      {
        hemenalma = new csHemenAlGetSet();

        gridControl1.DataSource = hemenalma.csHemenAlStringToDatatablesds(hemenalma.Get_Set_Fonksiyonlari.GetUrun());
      }
      catch (Exception)
      {
        
        throw;
      }

    }
  }
}