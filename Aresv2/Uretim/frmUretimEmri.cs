using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraEditors;

namespace Aresv2.Uretim
{
	public partial class frmUretimEmri : DevExpress.XtraEditors.XtraForm
	{
		public frmUretimEmri()
		{
			InitializeComponent();
		}

		SqlDataAdapter daUretim = new SqlDataAdapter();
		DataTable dt = new DataTable();
		SqlTransaction trGenel;

		private void frmUretimEmri_Load(object sender, EventArgs e)
		{
			try
			{
				using (daUretim.SelectCommand = new SqlCommand(@"SELECT dbo.UretimEmri.UretimEmriID, dbo.UretimEmri.PartiNo, dbo.UretimEmri.UretimTarihi, dbo.UretimEmri.OzelKod1, dbo.UretimEmri.OzelKod2, 
                      dbo.UretimEmri.CariID, dbo.UretimEmri.SarfAmbarID, dbo.UretimEmri.UretimdenGirisAmbarID, dbo.UretimEmri.ReceteMasterID, dbo.UretimEmri.UretimMiktari, 
                      dbo.UretimEmri.BaslangicTarihi, dbo.UretimEmri.BitisTarihi, dbo.UretimEmri.TeslimTarihi, dbo.UretimEmri.UretimAciklama, dbo.UretimEmri.Durum, 
                      CASE WHEN Durum = 0 THEN 'Kaydedildi' ELSE 'Üretildi' END AS UretimDurum, dbo.UretimEmri.KaydedenID, dbo.UretimEmri.KayitTarihi, 
                      dbo.UretimEmri.GuncelleyenID, dbo.UretimEmri.GuncellemeTarihi, SarfAmbar.DepoAdi AS SarfAmbar, UretimAmbar.DepoAdi AS UretimdenGiris
FROM         dbo.UretimEmri LEFT OUTER JOIN
                      dbo.Depo AS UretimAmbar ON dbo.UretimEmri.UretimdenGirisAmbarID = UretimAmbar.DepoID LEFT OUTER JOIN
                      dbo.Depo AS SarfAmbar ON dbo.UretimEmri.SarfAmbarID = SarfAmbar.DepoID
ORDER BY dbo.UretimEmri.UretimEmriID DESC", SqlConnections.GetBaglanti()))
				{
					dt.Clear();
					daUretim.Fill(dt);
					gcUretimEmri.DataSource = dt;
				}

				GridArayuzIslemleri(enGridArayuzIslemleri.Get);

				#region GRİD SATIR RENKLERİ AYARLANIYOR
				StyleFormatCondition cTamamlandi = new StyleFormatCondition(FormatConditionEnum.Equal, gvUretimEmri.Columns["UretimDurum"], "cTamamlandi", "Üretildi");
				//cTamamlandi.Appearance.BackColor = Color.LightGreen;
				cTamamlandi.Appearance.ForeColor = System.Drawing.Color.Green; //Color.FromName(Sirada);
				//cTamamlandi.Appearance.Options.UseBackColor = true;
				cTamamlandi.Appearance.Options.UseForeColor = true;
				cTamamlandi.ApplyToRow = true;
				gvUretimEmri.FormatConditions.Add(cTamamlandi);

				//*****************
				StyleFormatCondition cKaydedildi = new StyleFormatCondition(FormatConditionEnum.Equal, gvUretimEmri.Columns["UretimDurum"], "cKaydedildi", "Kaydedildi");
				//cTamamlandi.Appearance.BackColor = Color.LightGreen;
				cKaydedildi.Appearance.ForeColor = System.Drawing.Color.Red; //Color.FromName(Sirada);
				//cTamamlandi.Appearance.Options.UseBackColor = true;
				cKaydedildi.Appearance.Options.UseForeColor = true;
				cKaydedildi.ApplyToRow = true;
				gvUretimEmri.FormatConditions.Add(cKaydedildi);
				#endregion
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnEkle_Click(object sender, EventArgs e)
		{
			Uretim.frmUretimEmriDetay frmUretimEmriDetay = new frmUretimEmriDetay("-1");
			if (frmUretimEmriDetay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				dt.Clear();
				daUretim.Update(dt);
				daUretim.Fill(dt);
			}
		}
		private void btnSil_Click(object sender, EventArgs e)
		{

		}
		private void btnDegistir_Click(object sender, EventArgs e)
		{
			if (gvUretimEmri.FocusedRowHandle < 0) return;
			string SeciliID = gvUretimEmri.GetFocusedRowCellValue("UretimEmriID").ToString();
			Uretim.frmUretimEmriDetay frmUretimEmriDetay = new frmUretimEmriDetay(SeciliID);
			if (frmUretimEmriDetay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				frmUretimEmri_Load(null, null);
				EklenenSatiraKonumlan(SeciliID);
			}
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
		private void frmUretimEmri_FormClosed(object sender, FormClosedEventArgs e)
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
			frmExceleAktar frm = new frmExceleAktar(gcUretimEmri);
			frm.Show();
		}
		private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (gvUretimEmri.FocusedRowHandle < 0) { e.Cancel = true; }
			if ((bool)gvUretimEmri.GetFocusedRowCellValue(colDurum) == false)
			{
				cbtnKaydedildi.Visible = false;
				cbtnUretildi.Visible = true;
			}
			else
			{
				cbtnKaydedildi.Visible = true;
				cbtnUretildi.Visible = false;
			}
		}
		private void cbtnKaydedildi_Click(object sender, EventArgs e)
		{
			try
			{
				if (XtraMessageBox.Show("Üretim Emri Durumu 'Kaydedildi' Olarak Değiştirilecek.\n{Üretim Fişleri silinecek.}\nOnaylıyor musunuz?", "ARES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
				int SeciliSatir = gvUretimEmri.FocusedRowHandle;

				#region StokFis ve StokFisDetay Tablolarından  'StokFisNo' su yakalanan satır siliniyor.
				string StokFisID = "-1";
				using (SqlCommand cmd = new SqlCommand("Select StokFisID From StokFis Where StokFisNo=@StokFisNo", SqlConnections.GetBaglanti()))
				{
					cmd.Parameters.Add("@StokFisNo", SqlDbType.NVarChar).Value = gvUretimEmri.GetFocusedRowCellValue("PartiNo").ToString();
					using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
						if (dr.Read())
							StokFisID = dr["StokFisID"].ToString();
				}

				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				using (SqlCommand cmdDelete = new SqlCommand("Delete From StokFis Where StokFisID=@StokFisID", SqlConnections.GetBaglanti()))
				{
					cmdDelete.Transaction = trGenel;
					cmdDelete.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StokFisID;
					cmdDelete.ExecuteNonQuery();
				}

				System.Collections.Generic.List<Int32> hareketler = new System.Collections.Generic.List<int>();
				using (SqlCommand cmdHareketler = new SqlCommand("Select StokFisDetayID From StokFisDetay Where StokFisID=@StokFisID", SqlConnections.GetBaglanti()))
				{
					cmdHareketler.Transaction = trGenel;

					cmdHareketler.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StokFisID;
					using (SqlDataReader dr = cmdHareketler.ExecuteReader())
						while (dr.Read()) hareketler.Add(Convert.ToInt32(dr["StokFisDetayID"].ToString()));
				}

				foreach (Int32 ID in hareketler)
				{
					using (SqlCommand cmdDelete = new SqlCommand("Delete From StokFisDetay Where StokFisDetayID=@StokFisDetayID", SqlConnections.GetBaglanti()))
					{
						cmdDelete.Transaction = trGenel;
						cmdDelete.Parameters.Add("@StokFisDetayID", SqlDbType.Int).Value = ID;
						cmdDelete.ExecuteNonQuery();
					}
				}

				trGenel.Commit();
				#endregion

				#region UretimEmri Kaydının Durum'u değiştiriliyor.
				using (SqlCommand cmd = new SqlCommand(@"Update UretimEmri Set Durum=0 Where UretimEmriID=@UretimEmriID", SqlConnections.GetBaglanti()))
				{
					cmd.Parameters.Add("@UretimEmriID", SqlDbType.Int).Value =gvUretimEmri.GetFocusedRowCellValue("UretimEmriID").ToString();
					cmd.ExecuteNonQuery();
				}
				#endregion
				dt.Clear();
				daUretim.Update(dt);
				daUretim.Fill(dt);

				gvUretimEmri.FocusedRowHandle = SeciliSatir;
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void cbtnUretildi_Click(object sender, EventArgs e)
		{
			if (XtraMessageBox.Show("Üretim Emri Durumu 'Üretildi' Olarak Değiştirilecek.\n{Üretim Fişleri oluşturulacak.}\nOnaylıyor musunuz?", "ARES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
			int SeciliSatir = gvUretimEmri.FocusedRowHandle;
			int UretimEmriID = (int)gvUretimEmri.GetFocusedRowCellValue("UretimEmriID");
			int CiktiStokID = -1;

			#region REÇETEDEKİ ÇIKTI STOK BİLGİSİ ALINIYOR
			using (SqlCommand cmd = new SqlCommand(@"SELECT StokID FROM dbo.ReceteDetail WHERE (SatirTur = 1) AND (ReceteMasterID = @ReceteMasterID)", SqlConnections.GetBaglanti()))
			{
				cmd.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = gvUretimEmri.GetFocusedRowCellValue("ReceteMasterID").ToString();
				using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
				{
					if (dr.Read())
						CiktiStokID = (int)dr["StokID"];
				}
			}
			#endregion

			#region ÇIKTI SATIRI UretimFis TABLOSUNA KAYDEDİLİYOR.
			//using (SqlCommand cmd = new SqlCommand(@"Insert Into UretimFis(UretimEmriID, FisTuru, ModulNo, GirisCikis, FisNo, DepoID, StokID, Miktar) Values(@UretimEmriID, @FisTuru, @ModulNo, @GirisCikis, @FisNo, @DepoID, @StokID, @Miktar)", SqlConnections.GetBaglanti()))
			//{
			//  cmd.Parameters.Add("@UretimEmriID", SqlDbType.Int).Value = gvUretimEmri.GetFocusedRowCellValue("UretimEmriID").ToString();
			//  cmd.Parameters.Add("@FisTuru", SqlDbType.Int).Value = "13"; //13:üretimden giriş fişi,
			//  cmd.Parameters.Add("@ModulNo", SqlDbType.Int).Value = "3"; //3: Malzeme yönetimi
			//  cmd.Parameters.Add("@GirisCikis", SqlDbType.Int).Value = "0";
			//  cmd.Parameters.Add("@FisNo", SqlDbType.NVarChar).Value = gvUretimEmri.GetFocusedRowCellValue("PartiNo").ToString();
			//  cmd.Parameters.Add("@DepoID", SqlDbType.Int).Value = gvUretimEmri.GetFocusedRowCellValue("UretimdenGirisAmbarID").ToString();
			//  cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = CiktiStokID;
			//  cmd.Parameters.Add("@Miktar", SqlDbType.Decimal).Value = CiktiMiktariniGetir();

			//  cmd.ExecuteNonQuery();
			//}
			#endregion

			#region STOKFIS VE STOKFISDETAY TABLOLARINA KAYIT EKLENİYOR.
			int StokFisID = 0;
			#region Stok Fiş
			using (SqlCommand cmdMaster = new SqlCommand(
@"INSERT INTO StokFis( StokFisNo, FisTarihi, FisTuru, GirisCikis, ModulNo, CikisAmbarID, GirisAmbarID) 
    VALUES(@StokFisNo,@FisTarihi,@FisTuru,@GirisCikis,@ModulNo,@CikisAmbarID,@GirisAmbarID) SET @YeniID = SCOPE_IDENTITY()", SqlConnections.GetBaglanti()))
			{
				cmdMaster.Parameters.Add("@StokFisNo", SqlDbType.NVarChar).Value = gvUretimEmri.GetFocusedRowCellValue("PartiNo").ToString();
				cmdMaster.Parameters.Add("@FisTarihi", SqlDbType.DateTime).Value = gvUretimEmri.GetFocusedRowCellValue("UretimTarihi").ToString();
				cmdMaster.Parameters.Add("@FisTuru", SqlDbType.Int).Value = 13;//Üretimden Giriş Fişi
				cmdMaster.Parameters.Add("@GirisCikis", SqlDbType.Int).Value = 1;
				cmdMaster.Parameters.Add("@ModulNo", SqlDbType.Int).Value = 3;//Malzeme Yönetimi
				cmdMaster.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = -1;
				cmdMaster.Parameters.Add("@GirisAmbarID", SqlDbType.Int).Value = -1;
				cmdMaster.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmdMaster.ExecuteNonQuery();
				StokFisID = Convert.ToInt32(cmdMaster.Parameters["@YeniID"].Value.ToString());
			}
			#endregion

			#region StokFisDetay
			DataTable dtFisDetay = new DataTable();
			using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT SatirTur, StokID, Miktar, UretimMiktar
FROM   dbo.ReceteDetail WHERE (ReceteMasterID = @ReceteMasterID)", SqlConnections.GetBaglanti()))
			{
				da.SelectCommand.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = gvUretimEmri.GetFocusedRowCellValue("ReceteMasterID").ToString();
				dtFisDetay.Clear();
				da.Fill(dtFisDetay);
			}
			int SiraNo = 0;
			foreach (DataRow row in dtFisDetay.AsEnumerable())
			{
				//ReceteDetail.SatirTur -> 1: Çıktı, 2: Hammadde				

				#region ÇIKTI SATIRI İŞLEMİ
				using (SqlCommand cmdDetail = new SqlCommand(
@"INSERT INTO StokFisDetay(FisTuru, ModulNo, GirisCikis, StokID, StokFisID, SatirNo, Miktar, CikisAmbarID)
VALUES(13,3,@GirisCikis,@StokID,@StokFisID,@SatirNo,@Miktar,@CikisAmbarID)", SqlConnections.GetBaglanti()))
				{
					SiraNo++;
					if (row["SatirTur"].ToString() == "1")
						cmdDetail.Parameters.Add("@GirisCikis", SqlDbType.Int).Value = 1;
					else if (row["SatirTur"].ToString() == "2")
						cmdDetail.Parameters.Add("@GirisCikis", SqlDbType.Int).Value = 0;
					cmdDetail.Parameters.Add("@StokID", SqlDbType.Int).Value = row["StokID"].ToString();
					cmdDetail.Parameters.Add("@SatirNo", SqlDbType.Int).Value = SiraNo;

					cmdDetail.Parameters.Add("@Miktar", SqlDbType.Decimal).Value = row["Miktar"].ToString();
					string a = gvUretimEmri.GetFocusedRowCellValue("UretimdenGirisAmbarID").ToString();
					cmdDetail.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = gvUretimEmri.GetFocusedRowCellValue("UretimdenGirisAmbarID").ToString();
					cmdDetail.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StokFisID;
					cmdDetail.ExecuteNonQuery();
				}
				#endregion
			}
			#endregion
			#endregion

			#region UretimEmri Kaydının Durum'u değiştiriliyor.
			using (SqlCommand cmd = new SqlCommand(@"Update UretimEmri Set Durum=1 Where UretimEmriID=@UretimEmriID", SqlConnections.GetBaglanti()))
			{
				cmd.Parameters.Add("@UretimEmriID", SqlDbType.Int).Value = UretimEmriID;
				cmd.ExecuteNonQuery();
			}
			#endregion

			dt.Clear();
			daUretim.Update(dt);
			daUretim.Fill(dt);

			gvUretimEmri.FocusedRowHandle = SeciliSatir;
		}
		private decimal CiktiMiktariniGetir()
		{
			decimal CiktiMiktari = 0;
			using (SqlCommand cmd = new SqlCommand(@"SELECT     dbo.UretimEmri.UretimMiktari * dbo.ReceteDetail.Miktar AS CiktiMiktari
FROM         dbo.UretimEmri INNER JOIN
                      dbo.ReceteMaster ON dbo.UretimEmri.ReceteMasterID = dbo.ReceteMaster.ReceteMasterID INNER JOIN
                      dbo.ReceteDetail ON dbo.ReceteMaster.ReceteMasterID = dbo.ReceteDetail.ReceteMasterID
WHERE     (dbo.ReceteDetail.SatirTur = 1) AND (dbo.UretimEmri.UretimEmriID = @UretimEmriID)", SqlConnections.GetBaglanti()))
			{
				cmd.Parameters.Add("@UretimEmriID", SqlDbType.Int).Value = gvUretimEmri.GetFocusedRowCellValue("UretimEmriID").ToString();
				using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
				{
					if (dr.Read())
						CiktiMiktari = (decimal)dr["CiktiMiktari"];
				}
			}
			return CiktiMiktari;
		}
		void EklenenSatiraKonumlan(string UretimEmriID)
		{
			gvUretimEmri.FocusedRowHandle = -1;
			int index = 0;
			for (int i = 0; i < gvUretimEmri.DataRowCount; i++)
			{
				if (gvUretimEmri.GetRowCellValue(index, "UretimEmriID").ToString() == UretimEmriID)
					break;
				else
					index++;
			}
			gvUretimEmri.FocusedRowHandle = index;
		}
	}
}