using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace Aresv2.Uretim
{
	public partial class frmRecete : DevExpress.XtraEditors.XtraForm
	{
		/// <summary>
		/// Reçete liste formu.
		/// </summary>
		public frmRecete()
		{
			InitializeComponent();
		}

		DataTable dt = new DataTable();
		SqlTransaction trGenel;
		clsTablolar.Uretim.csRecete csRecete;

		private void frmRecete_Load(object sender, EventArgs e)
		{
			try
			{
				using (csRecete = new clsTablolar.Uretim.csRecete(SqlConnections.GetBaglanti()))
					gcRecete.DataSource = csRecete.dt;

				GridArayuzIslemleri(enGridArayuzIslemleri.Get);
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnEkle_Click(object sender, EventArgs e)
		{
			Uretim.frmReceteDetay frmReceteDetay = new frmReceteDetay("-1");
			if (frmReceteDetay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				dt.Clear();
				frmRecete_Load(null, null);
			}
		}
		private void btnSil_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvRecete.FocusedRowHandle < 0) return;
				if (XtraMessageBox.Show("Seçili Reçete kaydını silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				string cevap = clsTablolar.Uretim.csRecete.ReceteSil(SqlConnections.GetBaglanti(), trGenel, gvRecete.GetFocusedRowCellValue("ReceteMasterID").ToString());
				if (cevap == "ok")
				{
					trGenel.Commit();
					trGenel.Dispose();
					frmRecete_Load(null, null);
				}
				else
					XtraMessageBox.Show(cevap, "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception hata)
			{
				trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnDegistir_Click(object sender, EventArgs e)
		{
			if (gvRecete.FocusedRowHandle < 0) return;
			Uretim.frmReceteDetay frmReceteDetay = new frmReceteDetay(gvRecete.GetFocusedRowCellValue("ReceteMasterID").ToString());
			if (frmReceteDetay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				frmRecete_Load(null, null);
		}
		#region Gird Arayüz İşlemleri
		enum enGridArayuzIslemleri { Set, Get };
		void GridArayuzIslemleri(enGridArayuzIslemleri islem)
		{
			try
			{
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				FormdakiGridleriBul(this, islem);
				trGenel.Commit();
			}
			catch (Exception hata)
			{
				trGenel.Rollback();
				throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
			}
		}
		private void FormdakiGridleriBul(Control nesne, enGridArayuzIslemleri islem)
		{
			if (nesne is DevExpress.XtraGrid.GridControl)
			{
				if (islem == enGridArayuzIslemleri.Set)
					GridArayuzleriKaydet(nesne);
				else
					GridArayuzleriYukle(nesne);
			}

			foreach (Control altnesne in nesne.Controls)
				FormdakiGridleriBul(altnesne, islem);
		}
		void GridArayuzleriKaydet(Control ctrl)
		{
			DevExpress.XtraGrid.GridControl gc = new GridControl();
			gc = ctrl as DevExpress.XtraGrid.GridControl;
			DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

			string Layout = "";
			using (var ms = new MemoryStream())
			{
				gv.SaveLayoutToStream(ms);
				ms.Position = 0;
				using (var reader = new StreamReader(ms))
					Layout = reader.ReadToEnd();
			}
			cs.csGridLayout.InsertLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, Layout, SqlConnections.GetBaglanti(), trGenel);
		}
		void GridArayuzleriYukle(Control ctrl)
		{
			DevExpress.XtraGrid.GridControl gc = new GridControl();
			gc = ctrl as DevExpress.XtraGrid.GridControl;
			DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

			MemoryStream ms = cs.csGridLayout.GetLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, SqlConnections.GetBaglanti(), trGenel);
			if (ms.Length > 0)
				gv.RestoreLayoutFromStream(ms);
		}
		#endregion
		private void frmRecete_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				GridArayuzIslemleri(enGridArayuzIslemleri.Set);
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnExceleAktar_Click(object sender, EventArgs e)
		{
			frmExceleAktar frm = new frmExceleAktar(gcRecete);
			frm.Show();
		}
		private void btnGuncelle_Click(object sender, EventArgs e)
		{
			frmRecete_Load(null, null);
		}

		private void gcRecete_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnDegistir_Click(null, null);
		}
	}
}