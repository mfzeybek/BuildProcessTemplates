using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Drawing;

namespace Aresv2.Uretim
{
	public partial class frmReceteDetay : DevExpress.XtraEditors.XtraForm
	{
		/// <summary>
		///  Gönderilen ReceteMasterID ye göre ReceteDetail tablosundaki bilgileri düzenler.
		/// </summary>
		/// <param name="ReceteMasterID"></param>
		public frmReceteDetay(string ReceteMasterID)
		{
			InitializeComponent();
			_ReceteMasterID = ReceteMasterID;
		}
		/// <summary>
		/// ReceteDetail -> SatirTur
		/// 1: Çıktı
		/// 2: Hammadde
		/// ************************
		/// Farklı farklı formlardan ReceteDetay daki bilgilere erişmek istediğimiz zaman nesneleri bir kez daha türetmeye gerek kalmasın diye,
		/// public static değişkenler kullandık.
		/// </summary>
		public static string _ReceteMasterID = "-1", ReceteDetailID = "-1", SatirTur = "", StokID = "-1",
			Miktar = "0", UretimMiktar = "1", Seviye = "0", SatirAciklama = "", Birim = "0", StokKodu = "", StokAdi = "";
		public static bool Yenisatir = false;

		SqlCommand cmdGenel = new SqlCommand();
		SqlTransaction trGenel;
		clsTablolar.Uretim.csReceteMaster MasterIslem;
		clsTablolar.Uretim.csReceteDetail DetailIslem;

		private void frmReceteDetay_Load(object sender, EventArgs e)
		{
			try
			{
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				MasterIslem = new clsTablolar.Uretim.csReceteMaster(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(_ReceteMasterID));
				txtReceteKodu.Text = MasterIslem.ReceteKod;
				txtOzelKod1.Text = MasterIslem.OzelKod1;
				txtOzelKod2.Text = MasterIslem.OzelKod2;
				memoAciklama.Text = MasterIslem.Aciklama;

				GridDoldur();
				trGenel.Commit();
				GridArayuzIslemleri(enGridArayuzIslemleri.Get);
			}
			catch (Exception hata)
			{
				trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		void GridDoldur()
		{
			DetailIslem = new clsTablolar.Uretim.csReceteDetail();
			gcReceteDetay.DataSource = DetailIslem.ReceteDetailDoldur(SqlConnections.GetBaglanti(), trGenel, _ReceteMasterID);
		}
		private void mbtnCiktiSatiri_Click(object sender, EventArgs e)
		{
			try
			{
				#region ÇIKTI SATIRI KONTROLÜ -Eğer satırlarda "çıktı satırı" varsa bir kez daha eklemeye izin verilmiyor.
				for (int i = 0; i < gvReceteDetay.RowCount; i++)
					if (gvReceteDetay.GetRowCellValue(i, "SatirTur").ToString() == "1")
					{
						XtraMessageBox.Show("Zaten mevcut bir Çıktı satırınız var.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				#endregion

				Yenisatir = true; SatirTur = "1"; ReceteDetailID = "-1"; StokID = "-1"; Miktar = "0"; Seviye = "0"; SatirAciklama = ""; UretimMiktar = "1"; Birim = "0"; StokKodu = ""; StokAdi = "";
				frmRDCikti frmReceteDetayCikti = new frmRDCikti();
				if (frmReceteDetayCikti.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					SatirEkle();
					EklenenSatiraKonumlan();
				}
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void mbtnHammaddeSatiri_Click(object sender, EventArgs e)
		{
			try
			{
				Yenisatir = true; SatirTur = "2"; ReceteDetailID = "-1"; StokID = "-1"; Miktar = "0"; Seviye = "0"; SatirAciklama = ""; UretimMiktar = "1"; Birim = "0"; StokKodu = ""; StokAdi = "";
				Uretim.frmRDHammadde frmRDHammadde = new Uretim.frmRDHammadde();
				if (frmRDHammadde.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					SatirEkle();
					EklenenSatiraKonumlan();
				}
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		void EklenenSatiraKonumlan()
		{
			//Grid Eklenen Kayıtta kalsın.
			gvReceteDetay.FocusedRowHandle = -1;
			int index = 0;
			for (int i = 0; i < gvReceteDetay.DataRowCount; i++)
			{
				if (gvReceteDetay.GetRowCellValue(index, "StokID").ToString() == StokID)
					break;
				else
					index++;
			}
			gvReceteDetay.FocusedRowHandle = index;
		}
		private void mbtnSil_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvReceteDetay.DataRowCount == 0) return;
				if (XtraMessageBox.Show("Seçilen Kaydı Silmek İstediğinize Emin misiniz?", " Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
					return;
				gvReceteDetay.DeleteRow(gvReceteDetay.FocusedRowHandle);
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void mbtnDegistir_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvReceteDetay.FocusedRowHandle < 0) return;

				#region SATIR BİLGİLERİ DEĞİŞKENLERE AKTARILIYOR.
				ReceteDetailID = gvReceteDetay.GetFocusedRowCellValue("ReceteDetailID").ToString();

				SatirTur = gvReceteDetay.GetFocusedRowCellValue("SatirTur").ToString();
				StokID = gvReceteDetay.GetFocusedRowCellValue("StokID").ToString();
				Miktar = gvReceteDetay.GetFocusedRowCellValue("Miktar").ToString();
				UretimMiktar = gvReceteDetay.GetFocusedRowCellValue("UretimMiktar").ToString();
				Seviye = gvReceteDetay.GetFocusedRowCellValue("Seviye").ToString();
				SatirAciklama = gvReceteDetay.GetFocusedRowCellValue("SatirAciklama").ToString();
				StokKodu = gvReceteDetay.GetFocusedRowCellValue("StokKodu").ToString();
				StokAdi = gvReceteDetay.GetFocusedRowCellValue("StokAdi").ToString();
				Yenisatir = false;
				#endregion
				DialogResult cevap = DialogResult.Cancel;
				switch (SatirTur)
				{
					case "1":
						Uretim.frmRDCikti frmRDCikti = new Uretim.frmRDCikti();
						cevap = frmRDCikti.ShowDialog();
						break;
					case "2":
						Uretim.frmRDHammadde frmRDHammadde = new Uretim.frmRDHammadde();
						cevap = frmRDHammadde.ShowDialog();
						break;
					default:
						break;
				}
				if (cevap == DialogResult.OK)
					SatirEkle();
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnKaydet_Click(object sender, EventArgs e)
		{
			try
			{
				#region BOŞ ALAN KONTROLÜ YAPILIYOR.
				if (txtReceteKodu.Text == "")
				{
					XtraMessageBox.Show("Reçete Kodu boş geçilemez.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtReceteKodu.Focus();
					return;
				}

				if (gvReceteDetay.RowCount < 1)
				{
					XtraMessageBox.Show("Reçete boş kaydedilemez.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtReceteKodu.Focus();
					return;
				}
				#endregion

				#region ÇIKTI SATIRI VAR MI KONTROLÜ
				//Satırda eğer çıktı satırı yoksa, kaydetme işlemine devam edilmiyor.
				bool CiktiSatiriVar = false;
				for (int i = 0; i < DetailIslem.dt.Rows.Count; i++)
				{
					if (DetailIslem.dt.Rows[i].RowState != DataRowState.Deleted)
						if (DetailIslem.dt.Rows[i]["SatirTur"].ToString() == "1")
						{
							CiktiSatiriVar = true;
							break;
						}
				}
				if (CiktiSatiriVar == false)
				{
					XtraMessageBox.Show("Çıktı satırı ekleyiniz.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				#endregion

				MasterIslem.ReceteKod = txtReceteKodu.Text;
				MasterIslem.Aciklama = memoAciklama.Text;
				MasterIslem.OzelKod1 = txtOzelKod1.Text;
				MasterIslem.OzelKod2 = txtOzelKod2.Text;
				MasterIslem.KaydedenID = Convert.ToInt32(frmKullaniciGiris.KullaniciID);
				MasterIslem.KayitTarihi = DateTime.Now;
				if (_ReceteMasterID == "-1")
				{
					#region AYNI REÇETE KODU VAR MI KONTROLÜ YAPILIYOR.
					//Reçete Kodu daha önce kaydedilen reçetelerde var mı kontrolü yapılıyor.
					cmdGenel.CommandText = @"Select ReceteMasterID From ReceteMaster where ReceteKod=@ReceteKod";
					cmdGenel.CommandType = CommandType.Text;
					cmdGenel.Connection = SqlConnections.GetBaglanti();
					cmdGenel.Parameters.Clear();
					cmdGenel.Parameters.Add("@ReceteKod", SqlDbType.NVarChar).Value = txtReceteKodu.Text;

					using (SqlDataReader drGenel = cmdGenel.ExecuteReader(CommandBehavior.SingleResult))
					{
						if (drGenel.Read())
						{
							XtraMessageBox.Show("Girilen Reçete Kodu kullanılıyor.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
							txtReceteKodu.Focus();
							return;
						}
					}
					#endregion

					#region EĞER FORM YENİ KAYIT İLE AÇILDIYSA ÖNCE MASTER KAYDI YAPILIYOR
					_ReceteMasterID = MasterIslem.ReceteMasterInsert(SqlConnections.GetBaglanti(), trGenel);
					#endregion

					#region EĞER YENİ KAYIT İLE AÇILDIYSA, GRİD DEKİ RECETEMASTERID LER GÜNCELLENİYOR.
					foreach (DataRow row in DetailIslem.dt.AsEnumerable())
					{
						row["ReceteMasterID"] = _ReceteMasterID;
					}
					#endregion
				}
				else
				{
					MasterIslem.ReceteMasterUpdate(SqlConnections.GetBaglanti(), trGenel);
				}

				DetailIslem.ReceteDetailUpdate(SqlConnections.GetBaglanti());
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnKapat_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
		public void SatirEkle()
		{
			try
			{
				//Eğer Yenisatir değişkeninde true değeri varsa önce yeni bir satır ekleniyor. sonra yeni eklenen satıra değerler atanıyor.
				if (Yenisatir)
					gvReceteDetay.AddNewRow();

				gvReceteDetay.SetFocusedRowCellValue("ReceteDetailID", ReceteDetailID);
				gvReceteDetay.SetFocusedRowCellValue("ReceteMasterID", _ReceteMasterID);
				gvReceteDetay.SetFocusedRowCellValue("SatirTur", SatirTur);
				gvReceteDetay.SetFocusedRowCellValue("StokID", StokID);
				gvReceteDetay.SetFocusedRowCellValue("Miktar", Miktar);
				gvReceteDetay.SetFocusedRowCellValue("UretimMiktar", UretimMiktar);
				gvReceteDetay.SetFocusedRowCellValue("Seviye", Seviye);
				gvReceteDetay.SetFocusedRowCellValue("SatirAciklama", SatirAciklama);
				gvReceteDetay.SetFocusedRowCellValue("KaydedenID", frmKullaniciGiris.KullaniciID);
				gvReceteDetay.SetFocusedRowCellValue("KayitTarihi", DateTime.Now.ToShortDateString());
				gvReceteDetay.SetFocusedRowCellValue("StokKodu", StokKodu);
				gvReceteDetay.SetFocusedRowCellValue("StokAdi", StokAdi);
				gvReceteDetay.SetFocusedRowCellValue("Birim", Birim);

				switch (SatirTur)
				{
					case "1":
						gvReceteDetay.SetFocusedRowCellValue("SatirTuru", "Çıktı");
						break;
					case "2":
						gvReceteDetay.SetFocusedRowCellValue("SatirTuru", "Hammadde");
						break;
					default:
						break;
				}
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void gvReceteDetay_DoubleClick(object sender, EventArgs e)
		{
			mbtnDegistir_Click(null, null);
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
		private void frmReceteDetay_FormClosed(object sender, FormClosedEventArgs e)
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
		private void frmReceteDetay_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.F2)
				btnKaydet_Click(null, null);
			else if (e.KeyCode == System.Windows.Forms.Keys.F2)
				btnKapat_Click(null, null);
		}

    private void panelControl2_Paint(object sender, PaintEventArgs e)
    {

    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {

    }
	}
}