using System;
using System.Windows.Forms;

namespace Aresv2.AyarlarHemeAl
{
	public partial class frmHAStok : DevExpress.XtraEditors.XtraForm
	{
		public frmHAStok()
		{
			InitializeComponent();
		}
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(richEditControl1.HtmlText);
		}
	}
}