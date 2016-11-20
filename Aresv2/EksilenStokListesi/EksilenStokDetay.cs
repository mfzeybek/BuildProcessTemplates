using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using clsTablolar;

namespace Aresv2.EksilenStokListesi
{
	public partial class EksilenStokDetay : DevExpress.XtraEditors.XtraForm
	{
		/// <summary>
		/// Eksilen stok kaydının yapıldığı form.
		/// </summary>
		/// <param name="EksilenStokListesiID"></param>
		public EksilenStokDetay(string EksilenStokListesiID)
		{
			InitializeComponent();
			_EksilenStokListesiID = EksilenStokListesiID;
		}

		public string StokID = "-1", CariID = "-1";
		string _EksilenStokListesiID = "-1";

		private void EksilenStokDetay_Load(object sender, EventArgs e)
		{

		}
		private void btnKaydet_Click(object sender, EventArgs e)
		{
			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = SqlConnections.GetBaglanti();
				cmd.CommandType = CommandType.Text;

				if (_EksilenStokListesiID == "-1")
				{
					//insert
					cmd.CommandText = @"Insert Into 
EksilenStokListesi( StokID, CariID, SiparisMiktari, SiparisTarihi, TedarikTarihi, TedarikFiyat, SiparisAciklama, KalanMiktar, IslemAciklama, YapilanIslem, IslemTarihi) 
Values(@StokID, @CariID, @SiparisMiktari, @SiparisTarihi, @TedarikTarihi, @TedarikFiyat, @SiparisAciklama, @KalanMiktar, @IslemAciklama, @YapilanIslem, @IslemTarihi)";
				}
				else
				{
					//update
					cmd.CommandText = @"Update EksilenStokListesi  SET 
 StokID=@StokID, CariID=@CariID, SiparisMiktari=@SiparisMiktari, SiparisTarihi=@SiparisTarihi, TedarikTarihi=@TedarikTarihi, TedarikFiyat=@TedarikFiyat, 
SiparisAciklama=@SiparisAciklama, KalanMiktar=@KalanMiktar, IslemAciklama=@IslemAciklama, YapilanIslem=@YapilanIslem, IslemTarihi=@IslemTarihi 
Where EksilenStokListesiID=@EksilenStokListesiID ";
					cmd.Parameters.Add("@EksilenStokListesiID", SqlDbType.Int).Value = _EksilenStokListesiID;

				}

				decimal SiparisMiktari = 0, TedarikFiyat = 0, KalanMiktar = 0;
				//if (!decimal.TryParse(txtSiparisMiktari.Text, out SiparisMiktari))
				//{
				//  MessageBox.Show("SiparisMiktari olmadı.");
				//  txtSiparisMiktari.Focus();
				//  return;
				//}
				//if (!decimal.TryParse(txtTedarikFiyat.Text, out TedarikFiyat))
				//{
				//  MessageBox.Show("txtTedarikFiyat olmadı.");
				//  txtSiparisMiktari.Focus();
				//  return;
				//}
				//if (!decimal.TryParse(txtKalanMiktar.Text, out KalanMiktar))
				//{
				//  MessageBox.Show("txtKalanMiktar olmadı.");
				//  txtSiparisMiktari.Focus();
				//  return;
				//}

				cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
				cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
				cmd.Parameters.Add("@SiparisMiktari", SqlDbType.Decimal).Value = SiparisMiktari;
				if (deSiparisTarihi.Text == "")
					cmd.Parameters.Add("@SiparisTarihi", SqlDbType.DateTime).Value = DBNull.Value;
				else
					cmd.Parameters.Add("@SiparisTarihi", SqlDbType.DateTime).Value = deSiparisTarihi.DateTime;
				if (deTedarikTarihi.Text == "")
					cmd.Parameters.Add("@TedarikTarihi", SqlDbType.DateTime).Value = DBNull.Value;
				else
					cmd.Parameters.Add("@TedarikTarihi", SqlDbType.DateTime).Value = deTedarikTarihi.DateTime;
				cmd.Parameters.Add("@TedarikFiyat", SqlDbType.Decimal).Value = TedarikFiyat;
				cmd.Parameters.Add("@SiparisAciklama", SqlDbType.NVarChar).Value = memoSiparisAciklama.Text;
				cmd.Parameters.Add("@KalanMiktar", SqlDbType.Decimal).Value = KalanMiktar;
				cmd.Parameters.Add("@IslemAciklama", SqlDbType.NVarChar).Value = memoIslemAciklama.Text;
				cmd.Parameters.Add("@YapilanIslem", SqlDbType.NVarChar).Value = memoYapilanIslem.Text;
				if (deIslemTarihi.Text == "")
					cmd.Parameters.Add("@IslemTarihi", SqlDbType.DateTime).Value = DBNull.Value;
				else
					cmd.Parameters.Add("@IslemTarihi", SqlDbType.DateTime).Value = deIslemTarihi.DateTime;

				cmd.ExecuteNonQuery();
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message);
			}

		}
		private void txtStok_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			Stok.frmStokListesi frmStokListesi = new Stok.frmStokListesi(true);
			if (frmStokListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtStok.Text = Stok.frmStokListesi.StokAdi;
				StokID = Stok.frmStokListesi.StokID;
			}
		}
		private void txtCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			frmCariListe frmCariListe = new frmCariListe();
			if (frmCariListe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtCari.Text = frmCariListe.CariTanim;
				CariID = frmCariListe.CariID;
			}
		}
		private void txtCari_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F10)
				txtCari_ButtonClick(null, null);
		}
		private void EksilenStokDetay_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
				btnKaydet_Click(null, null);
			else if (e.KeyCode == Keys.F3)
				btnIptal_Click(null, null);
		}
		private void btnIptal_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void txtStok_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F10)
				txtStok_ButtonClick(null, null);
		}
	}
}