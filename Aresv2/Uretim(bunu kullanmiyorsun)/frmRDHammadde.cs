using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using clsTablolar;

namespace Aresv2.Uretim
{
	public partial class frmRDHammadde : DevExpress.XtraEditors.XtraForm
	{
		public frmRDHammadde()
		{
			InitializeComponent();
		}
		string _StokID = "-1";
		SqlTransaction trGenel;
		clsTablolar.Stok.csStok YeniStok;
		clsTablolar.Stok.csStokBirimTanimlari BirimTanimlari = new clsTablolar.Stok.csStokBirimTanimlari();
		private void frmRDHammadde_Load(object sender, EventArgs e)
		{
			try
			{
				//trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				lkpStokBirim.Properties.DataSource = BirimTanimlari.BirimDoldur(SqlConnections.GetBaglanti(), trGenel);
				lkpStokBirim.Properties.ValueMember = "BirimID";
				lkpStokBirim.Properties.DisplayMember = "BirimAdi";
				lkpStokBirim.Properties.PopulateColumns();
				lkpStokBirim.Properties.Columns["BirimID"].Visible = false;

				if (Uretim.frmReceteDetay.ReceteDetailID != "-1")
				{
					#region REÇETE DETAY BİLGİLERİ OKUNUYOR.
					using (SqlCommand cmd = new SqlCommand(@"SELECT dbo.ReceteDetail.StokID, dbo.Stok.StokKodu, dbo.Stok.StokAdi, dbo.ReceteDetail.Miktar, dbo.ReceteDetail.UretimMiktar, dbo.ReceteDetail.SatirAciklama, dbo.Stok.StokBirimID FROM dbo.ReceteDetail INNER JOIN dbo.Stok ON dbo.ReceteDetail.StokID = dbo.Stok.StokID WHERE (dbo.ReceteDetail.ReceteDetailID = @ReceteDetailID)", SqlConnections.GetBaglanti()))
					{
						cmd.Parameters.Add("@ReceteDetailID", SqlDbType.Int).Value = Uretim.frmReceteDetay.ReceteDetailID;
						using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow))
						{
							if (dr.Read())
							{
								_StokID = dr["StokID"].ToString();
								txtStokTanim.Text = dr["StokAdi"].ToString();
								txtStokKodu.Text = dr["StokKodu"].ToString();
								txtKullanilanMiktar.Text = dr["Miktar"].ToString();
								txtUretimMiktar.Text = dr["UretimMiktar"].ToString();
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

				lkpStokBirim.EditValue = YeniStok.StokBirimID; //Convert.ToInt32("["StokBirimID"].ToString()); // bunu yenistoktan alacak
				StokID = YeniStok.StokID;// Stok["StokID"].ToString(); bunu da yenistokdan alıcak
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
				txtKullanilanMiktar.Focus();
		}
		private void btnKaydet_Click(object sender, EventArgs e)
		{
			Uretim.frmReceteDetay.StokID = _StokID;
			Uretim.frmReceteDetay.Miktar = txtKullanilanMiktar.Text;
			Uretim.frmReceteDetay.UretimMiktar = txtUretimMiktar.Text;
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
		private void txtKullanilanMiktar_Validating(object sender, CancelEventArgs e)
		{
			int KullanilanMiktar = 0;
			if (int.TryParse(txtKullanilanMiktar.Text, out KullanilanMiktar) == false)
				e.Cancel = true;
		}
		private void txtUretimMiktar_Validating(object sender, CancelEventArgs e)
		{
			int UretimMiktar = 0;
			if (int.TryParse(txtUretimMiktar.Text, out UretimMiktar) == false)
				e.Cancel = true;
		}
		private void txtStokKodu_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F10)
				txtStokKodu_ButtonClick(null, null);
		}
		private void frmRDHammadde_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
				btnKaydet_Click(null, null);
			else if (e.KeyCode == Keys.F2)
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