using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using clsTablolar;
using DevExpress.XtraEditors;
using System.Drawing;

namespace Aresv2.Uretim
{
	public partial class frmRDCikti : DevExpress.XtraEditors.XtraForm
	{
		public frmRDCikti()
		{
			InitializeComponent();
		}
		string _StokID = "-1";
		clsTablolar.Stok.csStokBirimTanimlari BirimTanimlari = new clsTablolar.Stok.csStokBirimTanimlari();
		SqlTransaction trGenel;
		clsTablolar.Stok.csStok YeniStok;
		private void frmReceteDetayCikti_Load(object sender, EventArgs e)
		{
			try
			{
				lkpStokBirim.Properties.DataSource = BirimTanimlari.BirimDoldur(SqlConnections.GetBaglanti(), trGenel);
				lkpStokBirim.Properties.ValueMember = "BirimID";
				lkpStokBirim.Properties.DisplayMember = "BirimAdi";
				lkpStokBirim.Properties.PopulateColumns();
				lkpStokBirim.Properties.Columns["BirimID"].Visible = false;

				if (Uretim.frmReceteDetay.ReceteDetailID != "-1")
				{
					#region REÇETE DETAY BİLGİLERİ OKUNUYOR.
					using (SqlCommand cmd = new SqlCommand(@"SELECT dbo.ReceteDetail.StokID, dbo.Stok.StokKodu, dbo.Stok.StokAdi, dbo.ReceteDetail.Miktar, dbo.ReceteDetail.SatirAciklama, dbo.Stok.StokBirimID FROM dbo.ReceteDetail INNER JOIN dbo.Stok ON dbo.ReceteDetail.StokID = dbo.Stok.StokID WHERE (dbo.ReceteDetail.ReceteDetailID = @ReceteDetailID)", SqlConnections.GetBaglanti()))
					{
						cmd.Parameters.Add("@ReceteDetailID", SqlDbType.Int).Value = Uretim.frmReceteDetay.ReceteDetailID;
						using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow))
						{
							if (dr.Read())
							{
								_StokID = dr["StokID"].ToString();
								txtStokTanim.Text = dr["StokAdi"].ToString();
								txtStokKodu.Text = dr["StokKodu"].ToString();
								txtMiktar.Text = dr["Miktar"].ToString();
								memoAciklama.Text = dr["SatirAciklama"].ToString();
								lkpStokBirim.EditValue = Convert.ToInt32(dr["StokBirimID"].ToString());
							}
						}
					}
					#endregion
				}
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void StokEkle(int StokID, decimal Miktar)
		{
			try
			{
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, StokID);
				txtStokKodu.Text = YeniStok.StokKodu;
				txtStokTanim.Text = YeniStok.StokAdi;

				_StokID = YeniStok.StokID.ToString();
				trGenel.Commit();

				lkpStokBirim.EditValue = YeniStok.StokBirimID;//Convert.ToInt32(Stok["StokBirimID"].ToString()); // yeni stoktan gelecek
				//StokID = YeniStok.StokID;// yeni stoktan gelecek
			}
			catch (Exception hata)
			{
				trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void txtStokKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			Stok.frmStokListesi StokArama = new Stok.frmStokListesi(true);
			StokArama.Stok_Sec = StokEkle;
			StokArama.ShowDialog();

			if (_StokID != "-1")
				txtMiktar.Focus();
		}
		private void btnKaydet_Click(object sender, EventArgs e)
		{
			Uretim.frmReceteDetay.StokID = _StokID;
			Uretim.frmReceteDetay.Miktar = txtMiktar.Text;
			Uretim.frmReceteDetay.SatirAciklama = memoAciklama.Text;
			Uretim.frmReceteDetay.StokKodu = txtStokKodu.Text;
			Uretim.frmReceteDetay.StokAdi = txtStokTanim.Text;

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Hide();
		}
		private void btnKapat_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
		private void txtMiktar_Validating(object sender, CancelEventArgs e)
		{
			decimal Miktar = 0;
			if (decimal.TryParse(txtMiktar.Text, out Miktar) == false)
				e.Cancel = true;
		}
		private void frmRDCikti_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			if (trGenel != null) trGenel.Dispose();
		}
		private void txtStokKodu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.F10)
				txtStokKodu_ButtonClick(null, null);
		}
		private void frmRDCikti_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.F2)
				btnKaydet_Click(null, null);
			else if (e.KeyCode == System.Windows.Forms.Keys.F2)
				btnKapat_Click(null, null);
		}
		private void AktifTextBackColorChange(object sender, EventArgs e)
		{
			DevExpress.XtraEditors.TextEdit AktifText = (TextEdit)sender;
			AktifText.BackColor = Color.AntiqueWhite;
		}
		private void PasifTextBackColorChange(object sender, EventArgs e)
		{
			DevExpress.XtraEditors.TextEdit AktifText = (TextEdit)sender;
			AktifText.BackColor = Color.White;
		}
	}
}