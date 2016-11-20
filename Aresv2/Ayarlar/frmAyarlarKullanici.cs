using System;
using System.Data;
using System.Data.SqlClient;
using clsTablolar;

namespace Aresv2.Ayarlar
{
	public partial class frmAyarlarKullanici : DevExpress.XtraEditors.XtraForm
	{
		public frmAyarlarKullanici(string KullaniciID)
		{
			InitializeComponent();
			_KullaniciID = KullaniciID;
		}
		string _KullaniciID = "-1";
		SqlTransaction trGenel;
		clsTablolar.csKullanici kullanici;
		private void frmAyarlarKullanici_Load(object sender, EventArgs e)
		{
			try
			{
				#region lkpVOIP DOLDURULUYOR.
				using (SqlDataAdapter da = new SqlDataAdapter(@"Select AyarlarVOIPID,VOIPTanim From AyarlarVOIP", SqlConnections.GetBaglanti()))
				{
					DataTable dt = new DataTable();
					da.Fill(dt);
					lookUpEdit1.Properties.DataSource = dt;
					lookUpEdit1.Properties.DisplayMember = "VOIPTanim";
					lookUpEdit1.Properties.ValueMember = "AyarlarVOIPID";
				}
				#endregion

				#region KULLANICI BİLGİLERİ GETİRİLİYOR.
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				kullanici = new csKullanici(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(_KullaniciID));
				txtKullaniciKodu.Text = csKullanici.KullaniciAdi;
				txtKullaniciSifre.Text = kullanici.KullaniciSifre;
				lookUpEdit1.EditValue = kullanici.AyarlarVOIPID;
				trGenel.Commit(); 
				#endregion
			}
			catch (Exception hata)
			{
				if (trGenel != null) trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnKaydet_Click(object sender, EventArgs e)
		{
			try
			{
                csKullanici.KullaniciAdi = txtKullaniciKodu.Text;
				kullanici.KullaniciSifre = txtKullaniciSifre.Text;
				kullanici.AyarlarVOIPID = Convert.ToInt32(lookUpEdit1.EditValue.ToString());
				kullanici.AramaYapabilsin = ceAramaYapabilsin.Checked;
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				if (_KullaniciID == "-1")
					kullanici.KullaniciInsert(SqlConnections.GetBaglanti(), trGenel);
				else
					kullanici.KullaniciUpdate(SqlConnections.GetBaglanti(), trGenel);

				trGenel.Commit();
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
			catch (Exception hata)
			{
				if (trGenel != null) trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}

		private void ceAramaYapabilsin_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}