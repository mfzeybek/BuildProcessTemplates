using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using clsTablolar;

namespace Aresv2.Uretim
{
	public partial class frmReceteListesi : DevExpress.XtraEditors.XtraForm
	{
		public frmReceteListesi()
		{
			InitializeComponent();
		}

		public static string ReceteMasterID = "-1", ReceteKod = "";
		clsTablolar.Uretim.csRecete csRecete;

		private void GridiDoldur()
		{
			try
			{
				using (csRecete = new clsTablolar.Uretim.csRecete(SqlConnections.GetBaglanti()))
					gcReceteListesi.DataSource = csRecete.dt;
				
				gvReceteListesi.BestFitColumns();
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void frmReceteListesi_Load(object sender, EventArgs e)
		{
			GridiDoldur();
		}
		private void frmReceteListesi_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F2)
				grvReceteListesi_DoubleClick(null, null);
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}
		private void grvReceteListesi_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				ReceteMasterID = gvReceteListesi.GetFocusedRowCellDisplayText(colReceteMasterID);
				ReceteKod = gvReceteListesi.GetFocusedRowCellDisplayText(colReceteKod) + "  " + gvReceteListesi.GetFocusedRowCellDisplayText(colAciklama);
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
	}
}