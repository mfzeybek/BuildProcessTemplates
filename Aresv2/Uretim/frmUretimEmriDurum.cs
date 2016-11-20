using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aresv2.Uretim
{
	public partial class frmUretimEmriDurum : DevExpress.XtraEditors.XtraForm
	{
		public frmUretimEmriDurum(bool Durum, string UretimEmriID)
		{
			InitializeComponent();
			_Durum = Durum;
			_UretimEmriID = UretimEmriID;
		}
		bool _Durum = false;
		string _UretimEmriID = "-1";
		private void frmUretimEmriDurum_Load(object sender, EventArgs e)
		{
			if (_Durum)
				rgrpDurum.SelectedIndex = 1;
			else
				rgrpDurum.SelectedIndex = 0;
		}
		private void btnKaydet_Click(object sender, EventArgs e)
		{
		
		}
		private void btnIptal_Click(object sender, EventArgs e)
		{

		}
	}
}