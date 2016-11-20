using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;

namespace Aresv2.AyarlarHemeAl
{
	public partial class frmHAKategori : DevExpress.XtraEditors.XtraForm
	{
		public frmHAKategori()
		{
			InitializeComponent();
		}
    SqlConnections Turetttim = new SqlConnections();
		SqlTransaction trGenel;

		clsTablolar.Stok.csStokGrup stokGrup;
		clsTablolar.Stok.csStokAraGrup stokAraGrup;

		DataTable dtHemenAlStokGrup = new DataTable();
		DataTable dtStokGrup = new DataTable();

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
				stokGrup = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), trGenel, -1);
				stokAraGrup = new clsTablolar.Stok.csStokAraGrup(SqlConnections.GetBaglanti(), trGenel, -1);
				dtStokGrup.Clear();
				dtStokGrup = stokGrup.StokGrupDoldur(SqlConnections.GetBaglanti(), trGenel);
				gcStokGrup.DataSource = dtStokGrup;
				
				gvStokGrup.Columns["StokGrupID"].Visible = false;
				gvStokGrup.Columns["StokGrupAdi"].Caption = "Stok Grup Adı";
				gvStokGrup.Columns["StokGrupAdi"].Width = gcStokGrup.Width - 25;
				trGenel.Commit();


				HemenAlServis.hemenalserviceSoapClient a = new HemenAlServis.hemenalserviceSoapClient();
				if (a.Auth(frmKullaniciGiris.HemenAl_Auth_Code, frmKullaniciGiris.HemenAl_username, frmKullaniciGiris.HemenAl_password) == "False")
				{
					XtraMessageBox.Show("HemenAl Entegrasyon Bilgileri Doğrulanamadı.\n İşlem İptal Edilecek.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Close();
				}

				XmlDocument GelenTumveri = new XmlDocument();
				GelenTumveri.LoadXml(a.GetUrun().ToString());
				XmlReader xmlReader = new XmlNodeReader(GelenTumveri);
				DataSet dsGelen = new DataSet();
				dtHemenAlStokGrup.Clear();
				dsGelen.ReadXml(xmlReader);
				if (dsGelen.Tables.Count == 0)
				{
					XtraMessageBox.Show("Siteden bilgiler okunamadı.");
					//this.Close();
				}
				else
				{
					dtHemenAlStokGrup = dsGelen.Tables[0];
					gcHAKategori.DataSource = dtHemenAlStokGrup;
				}
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void gvStokAraGrup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{

		}
		private void gvStokGrup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			try
			{
				if (gvStokGrup.GetFocusedRowCellValue("StokGrupID") == null) return;
				//trGenel = SqlConnections.GetBaglanti().BeginTransaction();

				gcStokAraGrup.DataSource = stokAraGrup.StokAraGrupDoldur(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(gvStokGrup.GetFocusedRowCellValue("StokGrupID")));
				gvStokAraGrup.Columns["StokAraGrupID"].Visible = false;
				gvStokAraGrup.Columns["StokGrupID"].Visible = false;
				gvStokAraGrup.Columns["StokAraGrupAdi"].Caption = "Stok Ara Grup Adı";
				gvStokAraGrup.Columns["StokAraGrupAdi"].Width = gcStokAraGrup.Width - 25;
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
			clsTablolar.Stok.csStokGrup StokGrup = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), trGenel, -1);
			foreach (DataRow row in dtHemenAlStokGrup.AsEnumerable())
			{
				if (row["ustKategoriID"].ToString() == "0")
				{
					StokGrup.StokGrupAdi = row["KategoriAdi"].ToString();
					StokGrup.StokGrupID = -1;
					StokGrup.KaydedenID = Convert.ToInt32(frmKullaniciGiris.KullaniciID);
					StokGrup.KayitTarihi = DateTime.Now;
					StokGrup.StokGrupKAydet(SqlConnections.GetBaglanti(), trGenel);
				}
			}
			trGenel.Commit();
			trGenel.Dispose();

			#endregion

			#region STOKGRUP LARI DEĞİŞKENE AKTARILIYOR.
			Dictionary<string, Int32> KategoriListesi = new Dictionary<string, int>();
			foreach (DataRow row in dtHemenAlStokGrup.AsEnumerable())
				if (row["ustKategoriID"].ToString() == "0")
					KategoriListesi.Add(row["KategoriAdi"].ToString(), Convert.ToInt32(row["id"].ToString()));
			#endregion

			trGenel = SqlConnections.GetBaglanti().BeginTransaction();
			clsTablolar.Stok.csStokAraGrup StokAraGrup = new clsTablolar.Stok.csStokAraGrup(SqlConnections.GetBaglanti(), trGenel, -1);

			foreach (DataRow row in dtHemenAlStokGrup.AsEnumerable())
			{
				#region StokAraGrup TABLOSUNA KAYIT EKLENİYOR.
				if (row["ustKategoriID"].ToString() != "0")
				{
					StokAraGrup.StokAraGrupID = -1;
					StokAraGrup.StokGrupID = -1;
					string StokGrup_ = "";

					foreach (KeyValuePair<string, Int32> item in KategoriListesi)
						if (row["ustKategoriID"].ToString() == item.Value.ToString())
						{
							StokGrup_ = item.Key;
							break;
						}

					StokAraGrup.StokGrupAdi = StokGrup_;
					StokAraGrup.StokAraGrupAdi = row["KategoriAdi"].ToString();
					StokAraGrup.KaydedenID = Convert.ToInt32(frmKullaniciGiris.KullaniciID);
					StokAraGrup.KayitTarihi = DateTime.Now;
					StokAraGrup.StokAraGrupKaydetHemenAl(SqlConnections.GetBaglanti(), trGenel);
				}
				#endregion
			}

			dtStokGrup.Clear();
			dtStokGrup = stokGrup.StokGrupDoldur(SqlConnections.GetBaglanti(), trGenel);
			gcStokGrup.DataSource = dtStokGrup;

			trGenel.Commit();
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

				int sayac = 0;
				for (int i = 0; i < gvStokGrup.DataRowCount; i++)
				{
					a.SetKategori("Ares", gvStokGrup.GetRowCellValue(i, "StokGrupAdi").ToString(), "0", gvStokGrup.GetRowCellValue(i, "StokGrupAdi").ToString(), sayac.ToString());
sayac++;
					#region AltKategori Bilgileri gönderiliyor.
					using (SqlCommand cmd = new SqlCommand("Select StokAraGrupAdi From StokAraGrup Where StokGrupID=@StokGrupID", SqlConnections.GetBaglanti(), trGenel))
					{
						cmd.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = gvStokGrup.GetRowCellValue(i, "StokGrupID").ToString();
						using (SqlDataReader dr=cmd.ExecuteReader())
						{
							while (dr.Read())
							{
                //SetKategori(“ornek”,”001”,”0”,”Ana Kategori”)
								//SetKategori(“ornek”,”002”,”001”,”Alt Kategori”)

                a.SetKategori("Ares", dr["StokAraGrupAdi"].ToString(), gvStokGrup.GetRowCellValue(i, "StokGrupAdi").ToString(),
										dr["StokAraGrupAdi"].ToString(), "0");
							}
						}
						
					}
					#endregion
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