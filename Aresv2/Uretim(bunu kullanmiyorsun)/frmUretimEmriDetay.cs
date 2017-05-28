using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aresv2.Uretim
{
	public partial class frmUretimEmriDetay : DevExpress.XtraEditors.XtraForm
	{
		public frmUretimEmriDetay(string UretimEmriID)
		{
			InitializeComponent();
			_UretimEmriID = UretimEmriID;
		}

		SqlCommand cmdGenel = new SqlCommand();

		public static string ReceteMasterID = "-1", CariID = "-1";
		bool blGuncellemeYapildimi = false;
		string _UretimEmriID = "-1", IlkKarakter = "", KarakterSayisi = "", Numara = "";

		SqlTransaction trGenel;
		clsTablolar.Uretim.csUretimEmri UretimEmri;
    clsTablolar.cari.csCariv2 Cari;

		private void frmUretimEmriDetay_Load(object sender, EventArgs e)
		{
			try
			{
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();

				#region AMBARLAR BİLGİLERİ DOLDURULUYOR.
				using (SqlDataAdapter da = new SqlDataAdapter("Select DepoID, DepoAdi From Depo", SqlConnections.GetBaglanti()))
				{
					da.SelectCommand.Transaction = trGenel;
					DataTable dt = new DataTable();
					da.Fill(dt);

					lkpSarfAmbar.Properties.DataSource = dt;
					lkpSarfAmbar.Properties.PopulateColumns();
					lkpSarfAmbar.Properties.Columns["DepoID"].Visible = false;
					lkpSarfAmbar.Properties.Columns["DepoAdi"].Caption = "Depo Adı";
					lkpSarfAmbar.Properties.ValueMember = "DepoID";
					lkpSarfAmbar.Properties.DisplayMember = "DepoAdi";
					lkpSarfAmbar.EditValue = 1;
				}

				using (SqlDataAdapter da = new SqlDataAdapter("Select DepoID, DepoAdi From Depo", SqlConnections.GetBaglanti()))
				{
					da.SelectCommand.Transaction = trGenel;
					DataTable dt = new DataTable();
					da.Fill(dt);

					lkpUretimdenGirisAmbar.Properties.DataSource = dt;
					lkpUretimdenGirisAmbar.Properties.PopulateColumns();
					lkpUretimdenGirisAmbar.Properties.Columns["DepoID"].Visible = false;
					lkpUretimdenGirisAmbar.Properties.Columns["DepoAdi"].Caption = "Depo Adı";
					lkpUretimdenGirisAmbar.Properties.ValueMember = "DepoID";
					lkpUretimdenGirisAmbar.Properties.DisplayMember = "DepoAdi";
					lkpUretimdenGirisAmbar.EditValue = 1;
				}
				#endregion


				UretimEmri = new clsTablolar.Uretim.csUretimEmri(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(_UretimEmriID));
				txtPartiNo.Text = UretimEmri.PartiNo;
				deUretimTarihi.DateTime = UretimEmri.UretimTarihi;
				txtOzelKod1.Text = UretimEmri.OzelKod1;
				txtReceteKod.Text = UretimEmri.ReceteKod;
				ReceteMasterID = UretimEmri.ReceteMasterID.ToString();
				txtUretimMiktari.Text = UretimEmri.UretimMiktari.ToString();
				txtCariKod.Text = UretimEmri.CariKod + "" + UretimEmri.CariTanim;
				CariID = UretimEmri.CariID.ToString();
				txtAciklama.Text = UretimEmri.UretimAciklama.ToString();
				lkpSarfAmbar.EditValue = UretimEmri.SarfAmbarID;
				lkpUretimdenGirisAmbar.EditValue = UretimEmri.UretimdenGirisAmbarID;
				if ((bool)UretimEmri.Durum)
					cmbDurum.SelectedIndex = 1;
				else
					cmbDurum.SelectedIndex = 0;
				deBaslangicTarihi.DateTime = UretimEmri.BaslangicTarihi;
				deBitisTarihi.DateTime = UretimEmri.BitisTarihi;
				deTeslimTarihi.DateTime = UretimEmri.TeslimTarihi;

				if (_UretimEmriID == "-1")
				{
					#region AKTİF AMBAR BİLGİLERİ GETİRİLİYOR
					using (SqlCommand cmd = new SqlCommand(@"Select SarfDepoID,UretimdenGirisDepoID From DepoSabit", SqlConnections.GetBaglanti(), trGenel))
					using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
						if (dr.Read())
						{
							lkpSarfAmbar.EditValue = (int)dr["SarfDepoID"];
							lkpSarfAmbar.EditValue = (int)dr["UretimdenGirisDepoID"];
						}
					#endregion

					deBaslangicTarihi.DateTime = DateTime.Now;
					deBitisTarihi.DateTime = DateTime.Now;
					deUretimTarihi.DateTime = DateTime.Now;
					deTeslimTarihi.DateTime = DateTime.Now;
				}

				trGenel.Commit();
			}
			catch (Exception hata)
			{
				trGenel.Dispose();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void txtReceteKod_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Home && e.KeyCode != Keys.End && e.KeyCode!= Keys.F10)
				e.SuppressKeyPress = true;
			else if(e.KeyCode== Keys.F10)
				txtReceteKod_ButtonClick(null,null);
		}
		private void txtReceteKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			frmReceteListesi frm_ReceteListesi = new frmReceteListesi();
			if (frm_ReceteListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtReceteKod.Text = frmReceteListesi.ReceteKod;
				ReceteMasterID = frmReceteListesi.ReceteMasterID;
				txtUretimMiktari.Focus();
			}
		}
		void CariAktar(int CariID)
		{
			try
			{
        Cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), trGenel, CariID);
        CariID = CariID;
				txtCariKod.EditValue =Cari.CariKod;
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void txtCariKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			if (e.Button.Index == 0)
			{
				frmCariListe frmCariListe = new frmCariListe();
				frmCariListe.Text = "Cari Seçim";
				frmCariListe._CariIDVer = CariAktar;
				frmCariListe.ShowDialog();
			}
			else
			{
				CariID = "-1";
				txtCariKod.Text = "";
			}
		}
		private void btnKaydet_Click(object sender, EventArgs e)
		{
			try
			{				
				#region BOŞ ALAN KONTROLÜ YAPILIYOR.
				Control BosNesne = BosAlanKontrolu(new Control[] { txtPartiNo, txtReceteKod, txtUretimMiktari });
				if (BosNesne != null)
				{
					BosNesne.Focus();
					return;
				}
				#endregion

				trGenel = SqlConnections.GetBaglanti().BeginTransaction();

				UretimEmri.UretimEmriID = Convert.ToInt32(_UretimEmriID);
				UretimEmri.PartiNo = txtPartiNo.Text;
				UretimEmri.UretimTarihi = deUretimTarihi.DateTime;
				UretimEmri.OzelKod1 = txtOzelKod1.Text;
				UretimEmri.CariID = Convert.ToInt32(CariID);
				UretimEmri.SarfAmbarID = Convert.ToInt32(lkpSarfAmbar.EditValue.ToString());
				UretimEmri.UretimdenGirisAmbarID = Convert.ToInt32(lkpUretimdenGirisAmbar.EditValue.ToString());
				UretimEmri.ReceteMasterID = Convert.ToInt32(ReceteMasterID);
				UretimEmri.UretimMiktari = Convert.ToDecimal(txtUretimMiktari.Text);
				UretimEmri.BaslangicTarihi = deBaslangicTarihi.DateTime;
				UretimEmri.BitisTarihi = deBitisTarihi.DateTime;
				UretimEmri.TeslimTarihi = deTeslimTarihi.DateTime;
				UretimEmri.UretimAciklama = txtAciklama.Text;
				if (cmbDurum.SelectedIndex == 0)
					UretimEmri.Durum = false;
				else
					UretimEmri.Durum = true;

				if (_UretimEmriID == "-1")
				{
					UretimEmri.KaydedenID = Convert.ToInt32(frmKullaniciGiris.KullaniciID);
					UretimEmri.KayitTarihi = DateTime.Now;

					#region AYNI PARTİ NUMARASI OLUP OLMADIĞI KONTROL EDİLİYOR.
					using (SqlCommand cmd = new SqlCommand("Select UretimEmriID From UretimEmri Where PartiNo=@PartiNo", SqlConnections.GetBaglanti(), trGenel))
					{
						cmd.Parameters.Add("@PartiNo", SqlDbType.NVarChar).Value = txtPartiNo.Text;
						using (SqlDataReader drGenel = cmd.ExecuteReader(CommandBehavior.SingleResult))
						{
							if (drGenel.Read())
							{
								XtraMessageBox.Show("Girilen Parti Numarası kullanılıyor.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
								txtPartiNo.Focus();
								return;
							}
						}
					}
					#endregion

					UretimEmri.UretimEmriInsert(SqlConnections.GetBaglanti(), trGenel);
				}
				else
				{
					UretimEmri.GuncelleyenID = Convert.ToInt32(frmKullaniciGiris.KullaniciID);
					UretimEmri.GuncellemeTarihi = DateTime.Now;

					UretimEmri.UretimEmriUpdate(SqlConnections.GetBaglanti(), trGenel);
				}

				trGenel.Commit();
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch (Exception hata)
			{
				trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private Control BosAlanKontrolu(Control[] Nesne)
		{
			Control cevap = null;
			for (int i = 0; i < Nesne.Length; i++)
				if (Nesne[i].Text == "")
				{
					XtraMessageBox.Show("Zorunlu Alanlar boş geçilemez.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
					cevap = Nesne[i];
					return cevap;
				}
			return cevap;
		}
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Enter)
			{
				Control control = this.GetNextControl(ActiveControl, true);
				while (control != null && !control.TabStop)
				{
					control = this.GetNextControl(control, true);
				}
				if (control != null)
				{
					control.Focus();
					return true;
				}
			}
			return base.ProcessDialogKey(keyData);
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
		private void btnKapat_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
		private void Tex_Change(object sender, EventArgs e)
		{
			blGuncellemeYapildimi = true;
		}
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.WindowsShutDown) return;

			if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
				e.Cancel = false;
			else
			{
				if (blGuncellemeYapildimi)
					if (XtraMessageBox.Show(this, "Yaptığınız değişiklikler iptal edilecek. Onaylıyor musunuz?", "Kapatma Onayı", MessageBoxButtons.YesNo) == DialogResult.No)
						e.Cancel = true;
			}
			base.OnFormClosing(e);
		}

		private void frmUretimEmriDetay_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
				btnKaydet_Click(null, null);
			else if (e.KeyCode == Keys.F3)
				btnKapat_Click(null, null);
		}
	}
}