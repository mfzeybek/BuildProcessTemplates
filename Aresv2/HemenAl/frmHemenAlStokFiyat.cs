using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aresv2.HemenAl
{
  public partial class frmHemenAlStokFiyat : DevExpress.XtraEditors.XtraForm
  {
    public frmHemenAlStokFiyat()
    {
      InitializeComponent();
    }

    private void frmHemenAlStokFiyat_Load(object sender, EventArgs e)
    {
      csHemenAlGetSet HemelAl = new csHemenAlGetSet();
      gridControl1.DataSource = HemelAl.csHemenAlStringToDatatablesds(HemelAl.Get_Set_Fonksiyonlari.GetUrunStokFiyat());
    }
  }
}