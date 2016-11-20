using System;

namespace Aresv2
{
  public partial class frmBuyukFoto : DevExpress.XtraEditors.XtraForm
  {
    public frmBuyukFoto(byte[] Foto)
    {
      _Foto = Foto;
      InitializeComponent();
    }
    byte[] _Foto;

    private void frmBuyukFoto_Load(object sender, EventArgs e)
    {
      pictureEdit1.EditValue = _Foto;
    }

  }
}