using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;


namespace Aresv2.frmHemenAl
{
  
  public partial class frmHemenAlTeesst : DevExpress.XtraEditors.XtraForm
  {

    csHemenAlGetSet heee;

    private void frmHemenAlTeesst_Load(object sender, EventArgs e)
    {
      heee = new csHemenAlGetSet();
      heee.csHemenAlStringToDatatablesds(heee.Get_Set_Fonksiyonlari.GetUrun());
      gridControl1.DataSource = heee.dt_Gelen;
    }
  }
}
