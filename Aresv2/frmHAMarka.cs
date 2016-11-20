using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;

namespace Aresv2.AyarlarHemeAl
{
	public partial class frmHAMarka : DevExpress.XtraEditors.XtraForm
	{
		public frmHAMarka()
		{
			InitializeComponent();
		}
		SqlConnections Turetttim = new SqlConnections();
		SqlTransaction trGenel;

		clsTablolar.Stok.csStokMarka stokMarka;

		DataTable dtHemenAlStokMarka = new DataTable();
		DataTable dtStokMarka = new DataTable();

		private void frmHAKategori_Load(object sender, EventArgs e)
		{
			try
			{
				if (frmKullaniciGiris.HemenAl_Auth_Code == "")
				{
					XtraMessageBox.Show("HemenAl Entegrasyon Bilgileri Eksik.\n İşlem İptal Edilecek.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Close();
				}
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				stokMarka = new clsTablolar.Stok.csStokMarka(SqlConnections.GetBaglanti(), trGenel, -1);

				dtStokMarka.Clear();
				dtStokMarka = stokMarka.StokMarkaDoldur(SqlConnections.GetBaglanti(), trGenel);
				gcStokMarka.DataSource = dtStokMarka;

				gvStokMarka.Columns["StokMarkaID"].Visible = false;
				gvStokMarka.Columns["StokMarka"].Caption = "Stok Marka";
				gvStokMarka.Columns["StokMarka"].Width = gcStokMarka.Width - 25;
				trGenel.Commit();

				HemenAlServis.hemenalserviceSoapClient a = new HemenAlServis.hemenalserviceSoapClient();
				if (a.Auth(frmKullaniciGiris.HemenAl_Auth_Code, frmKullaniciGiris.HemenAl_username, frmKullaniciGiris.HemenAl_password) == "False")
				{
					XtraMessageBox.Show("HemenAl Entegrasyon Bilgileri Doğrulanamadı.\n İşlem İptal Edilecek.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Close();
				}

				XmlDocument GelenTumveri = new XmlDocument();
				GelenTumveri.LoadXml(a.GetMarka().ToString());
				XmlReader xmlReader = new XmlNodeReader(GelenTumveri);
				DataSet dsGelen = new DataSet();
				dtHemenAlStokMarka.Clear();
				dsGelen.ReadXml(xmlReader);
				if (dsGelen.Tables.Count == 0)
				{
					XtraMessageBox.Show("Siteden bilgiler okunamadı.");
					//this.Close();
				}
				else
				{
					dtHemenAlStokMarka = dsGelen.Tables[0];
					gcHAMarka.DataSource = dtHemenAlStokMarka;
				}
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnIceriBilgiAl_Click(object sender, EventArgs e)
		{
			#region StokGrup TABLOSUNA KAYIT EKLENİYOR.
			trGenel = SqlConnections.GetBaglanti().BeginTransaction();
			//clsTablolar.Stok.csStokGrup StokGrup = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), trGenel, -1);
			foreach (DataRow row in dtHemenAlStokMarka.AsEnumerable())
			{
				stokMarka.StokMarka = row["marka"].ToString();
				stokMarka.StokMarkaID = -1;
				stokMarka.KaydedenID = Convert.ToInt32(frmKullaniciGiris.KullaniciID);
				stokMarka.KayitTarihi = DateTime.Now;
				stokMarka.StokMarkaKAydet(SqlConnections.GetBaglanti(), trGenel);
			}
			trGenel.Commit();
			#endregion
		}
		private void btnWebeGonder_Click(object sender, EventArgs e)
		{
			try
			{
				HemenAlServis.hemenalserviceSoapClient a = new HemenAlServis.hemenalserviceSoapClient();
				if (a.Auth(frmKullaniciGiris.HemenAl_Auth_Code, frmKullaniciGiris.HemenAl_username, frmKullaniciGiris.HemenAl_password) == "False")
				{
					XtraMessageBox.Show("HemenAl Entegrasyon Bilgileri Doğrulanamadı.\n İşlem İptal Edilecek.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Close();
				}
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();

				for (int i = 0; i < gvStokMarka.DataRowCount; i++)
				{
					a.SetMarka(gvStokMarka.GetRowCellValue(i, "StokMarka").ToString(), gvStokMarka.GetRowCellValue(i, "StokMarka").ToString());
				}
				trGenel.Commit();
				XtraMessageBox.Show("Kaydetme Başarılı.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception hata)
			{
				trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
	}
}