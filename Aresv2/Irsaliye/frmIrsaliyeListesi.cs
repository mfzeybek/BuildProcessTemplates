using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace Aresv2.Irsaliye
{
	public partial class frmIrsaliyeListesi : DevExpress.XtraEditors.XtraForm
	{
		public frmIrsaliyeListesi()
		{
			InitializeComponent();
		}
		SqlTransaction trGenel;
		clsTablolar.Irsaliye.csIrsaliyeArama IrsaliyeArama;
		clsTablolar.Irsaliye.csIrsaliyeTipi IrsaliyeTipi = new clsTablolar.Irsaliye.csIrsaliyeTipi();
		//csIrsaliyeGrubu IrsaliyeGrubu = new csIrsaliyeGrubu();
		DataTable dtIrsaliye = new DataTable();
		enum ReportAction { Print, Preview, Dizayn }

		private void frmIrsaliyeListesi_Load(object sender, EventArgs e)
		{
			try
			{
				IrsaliyeArama = new clsTablolar.Irsaliye.csIrsaliyeArama(SqlConnections.GetBaglanti(), trGenel, -1);

				txtCariAdi.DataBindings.Add("EditValue", IrsaliyeArama, "CariTanimi");
				lkpIrsaliyeTipi.Properties.DataSource = IrsaliyeTipi.IrsaliyeTipleri();
				lkpIrsaliyeTipi.Properties.PopulateColumns();
				lkpIrsaliyeTipi.Properties.ValueMember = "TipiID";
				lkpIrsaliyeTipi.Properties.DisplayMember = "Adi";

				lkpIrsaliyeTipi.DataBindings.Add("EditValue", IrsaliyeArama, "IrsaliyeTipi");
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnFiltrele_Click(object sender, EventArgs e)
		{
			dtIrsaliye = IrsaliyeArama.IrsaliyeAraListe(SqlConnections.GetBaglanti(), trGenel);
			gcIrsaliye.DataSource = dtIrsaliye;
			GridArayuzIslemleri(enGridArayuzIslemleri.Get);
		}
		private void btnKaydiAc_Click(object sender, EventArgs e)
		{
			//aslında gridde seçili satır yoksa işlem yapmasın demek için "FocusedRowHandle" yeterdi ama
			//elimizde farklı kod olsun diye "SelectedRowsCount" u da yazdık. :)
			if (gvIrsaliye.FocusedRowHandle < 0 || gvIrsaliye.SelectedRowsCount <= 0) return;

			Irsaliye.frmIrsaliyeDetay IrsaliyeKarti = new Irsaliye.frmIrsaliyeDetay(Convert.ToInt32(gvIrsaliye.GetFocusedRowCellValue("IrsaliyeID")));
			IrsaliyeKarti.MdiParent = this.MdiParent;
			IrsaliyeKarti.Show();
		}
		private void lkpIrsaliyeTipi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			if (e.Button.Index == 1)
				lkpIrsaliyeTipi.EditValue = -1;
		}
		private void frmIrsaliyeListesi_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				GridArayuzIslemleri(enGridArayuzIslemleri.Set);
			}
			catch (Exception hata)
			{
				XtraMessageBox.Show(hata.Message);
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
		private void btnSil_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvIrsaliye.FocusedRowHandle < 0) return;
				if (XtraMessageBox.Show("Seçili İrsaliyeyi silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
				System.Collections.Generic.List<Int32> hareketler = new System.Collections.Generic.List<int>();
				using (SqlCommand cmdHareketler = new SqlCommand("Select IrsaliyeHareketID From IrsaliyeHareket Where IrsaliyeID=@IrsaliyeID", SqlConnections.GetBaglanti()))
				{
					cmdHareketler.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = Convert.ToInt32(gvIrsaliye.GetFocusedRowCellValue("IrsaliyeID").ToString());
					using (SqlDataReader drHareketler = cmdHareketler.ExecuteReader())
					{
						while (drHareketler.Read()) hareketler.Add(Convert.ToInt32(drHareketler["IrsaliyeHareketID"].ToString()));
					}
				}
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				foreach (Int32 ID in hareketler)
				{
					using (SqlCommand cmdHareketDelete = new SqlCommand("Delete From IrsaliyeHareket Where IrsaliyeHareketID=@IrsaliyeHareketID", SqlConnections.GetBaglanti()))
					{
						cmdHareketDelete.Transaction = trGenel;
						cmdHareketDelete.Parameters.Add("@IrsaliyeHareketID", SqlDbType.Int).Value = ID;
						cmdHareketDelete.ExecuteNonQuery();
					}
				}
				using (SqlCommand cmdIrsaliyeDelete = new SqlCommand("Delete From Irsaliye Where IrsaliyeID=@IrsaliyeID", SqlConnections.GetBaglanti()))
				{
					cmdIrsaliyeDelete.Transaction = trGenel;
					cmdIrsaliyeDelete.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = gvIrsaliye.GetFocusedRowCellValue("IrsaliyeID").ToString();
					cmdIrsaliyeDelete.ExecuteNonQuery();
				}
				trGenel.Commit();
			}
			catch (Exception hata)
			{
				trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		#region YAZDIRMA İŞLEMLERİ
		private void mbtnYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ProcessReport(ReportAction.Print);
		}
		private void mbtnOnizleme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ProcessReport(ReportAction.Preview);
		}
		private void mbtnDizayn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ProcessReport(ReportAction.Dizayn);
		}
		private void ProcessReport(ReportAction action)
		{
			switch (action)
			{
				case ReportAction.Print:
					RaporStokGiris().PrintDialog();
					break;
				case ReportAction.Preview:
					RaporStokGiris().ShowPreview();
					break;
				case ReportAction.Dizayn:
					XRDesignFormEx XrDesigner = new XRDesignFormEx();

					XrDesigner.FileName = Application.StartupPath + "\\ReportDesigners\\Irsaliye\\rptIrsaliye.repx";
					XrDesigner.OpenReport(RaporStokGiris());

					XrDesigner.Show();
					break;
			}
		}
		private XtraReport RaporStokGiris()
		{
			XtraReport xr_Master = new XtraReport();
			xr_Master.LoadLayout(Application.StartupPath + "\\ReportDesigners\\Irsaliye\\rptIrsaliye.repx");

			SqlDataAdapter da = new SqlDataAdapter(
				 @"SELECT     dbo.IrsaliyeHareket.IrsaliyeHareketID, dbo.IrsaliyeHareket.IrsaliyeID, dbo.IrsaliyeHareket.SatirNo, dbo.IrsaliyeHareket.StokID, dbo.Stok.StokKodu, dbo.Stok.StokAdi, 
                      dbo.IrsaliyeHareket.Miktar, dbo.IrsaliyeHareket.StokAnaBirimID, dbo.StokBirim.BirimAdi, dbo.IrsaliyeHareket.AnaBirimFiyat, dbo.IrsaliyeHareket.Kdv, 
                      dbo.IrsaliyeHareket.Toplam, dbo.IrsaliyeHareket.KdvToplam, dbo.IrsaliyeHareket.Net, dbo.IrsaliyeHareket.StokIskonto1, dbo.IrsaliyeHareket.StokIskonto2, 
                      dbo.IrsaliyeHareket.StokIskonto3, dbo.IrsaliyeHareket.CariIskonto1, dbo.IrsaliyeHareket.CariIskonto2, dbo.IrsaliyeHareket.CariIskonto3, 
                      dbo.IrsaliyeHareket.IndirimYuzdesi1, dbo.IrsaliyeHareket.IndirimYuzdesi, dbo.IrsaliyeHareket.Indirim, dbo.IrsaliyeHareket.SatirIndirimliBirimFiyat, 
                      dbo.IrsaliyeHareket.SatirIndirimliKDVTutar, dbo.IrsaliyeHareket.SatirIndirimliToplam, dbo.IrsaliyeHareket.AltIndirimBirimFiyat, dbo.IrsaliyeHareket.AltIndirimKDVTutar, 
                      dbo.IrsaliyeHareket.AltIndirimToplamTutar, dbo.IrsaliyeHareket.SatirToplamIndirim, dbo.IrsaliyeHareket.SatirToplamTutar, dbo.IrsaliyeHareket.SatirAciklama
FROM         dbo.IrsaliyeHareket LEFT OUTER JOIN
                      dbo.Stok ON dbo.IrsaliyeHareket.StokID = dbo.Stok.StokID LEFT OUTER JOIN
                      dbo.StokBirim ON dbo.IrsaliyeHareket.StokAnaBirimID = dbo.StokBirim.BirimID WHERE (IrsaliyeID= @IrsaliyeID)", SqlConnections.GetBaglanti());

			da.SelectCommand.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = gvIrsaliye.GetFocusedRowCellValue("IrsaliyeID").ToString();

			DataTable dt = new DataTable();
			da.Fill(dt);
			xr_Master.DataSource = dt;
			return xr_Master;
		}
		#endregion
		private void btnYazdir_Click(object sender, EventArgs e)
		{
			if (gvIrsaliye.FocusedRowHandle < 0) return;
      //frmRaporDizaynListesiv2 frmRaporDizaynListesi = new frmRaporDizaynListesiv2(cs.RaporModul.Irsaliye, gvIrsaliye.GetFocusedRowCellValue("CariID").ToString(), gvIrsaliye.GetFocusedRowCellValue("IrsaliyeID").ToString());
      //if (frmRaporDizaynListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      //{
      //  //XRDesignFormEx XrDesigner = new XRDesignFormEx();

      //  //XrDesigner.FileName = Application.StartupPath + "\\ReportDesigners\\Irsaliye\\" + frmRaporDizaynListesi.RaporDizaynAdi + ".repx";
      //  //XrDesigner.OpenReport(RaporStokGiris());

      //  //XrDesigner.Show();
      //}
		}
		private void cbtnFaturalandir_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvIrsaliye.FocusedRowHandle < 0) return;

				string Secilenler = "", SecilenIslemTipi = "";

				#region SEÇİLEN SATIR KONTROLLERİ
				//Seçilen İrsaliye satırlarının IrsaliyeID değişkenleri okunuyor. Eğer Seçilen satırlar birbirinden farklı bir Tipe sahipse işlem yapılmıyor.
				foreach (DataRow row in dtIrsaliye.AsEnumerable())
					if (row["Secim"].ToString() != "")
						if (Convert.ToBoolean(row["Secim"].ToString()))
							if (row["F"].ToString() == "F")
							{
								XtraMessageBox.Show("Seçilen satırlar içinde, faturalanmış kayıt var.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
							else
							{
								if (SecilenIslemTipi == "")
								{
									SecilenIslemTipi = row["IrsaliyeTipi"].ToString();
									Secilenler += row["IrsaliyeID"].ToString() + ",";
								}
								else
								{
									if (SecilenIslemTipi != row["IrsaliyeTipi"].ToString())
									{
										XtraMessageBox.Show("Seçilen satırlardaki İrsaliye Tipleri aynı olmak zorunda.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}
									Secilenler += row["IrsaliyeID"].ToString() + ",";
								}
							}
				#endregion

				// Eğer CheckEdit i işaretlenmiş satır yoksa seçili satır için faturalandırma işlemi yapılacak.
				if (Secilenler != "")
					Secilenler = Secilenler.Remove(Secilenler.Length - 1, 1);
				else
				{
					if (gvIrsaliye.GetFocusedRowCellValue("F").ToString() == "F")
					{
						XtraMessageBox.Show("Bu satır zaten faturalanmış.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					Secilenler = gvIrsaliye.GetFocusedRowCellValue("IrsaliyeID").ToString();
				}
				
				int Satir = gvIrsaliye.FocusedRowHandle;
				trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        //burası ne hamısına
        //csNumaraVer NumaraVer = new csNumaraVer(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(gvIrsaliye.GetFocusedRowCellValue("IrsaliyeTipi").ToString()) - 5);

        string KullanilanNumara = "";// NumaraVer.KullanilacakNumara;
        string KullanilanNumaraSablonID = "";// NumaraVer.NumaraSablonID.ToString();
				string FaturaID = "";

				#region FATURA ANA BAŞLIĞI KAYDEDİLİYOR.
				//seçilen Irsaliye satırlarından birinin başlık bilgileri yeni Fatura kaydının Başlık bilgileri olarak kaydediliyor.
				using (SqlCommand cmd = new SqlCommand(@"insert into Fatura Select IrsaliyeTipi -5, IrsaliyeTarihi, DuzenlemeTarihi, @IrsaliyeNo, CariID, CariKod, VergiDairesi, VergiNo, Adres, Il, Ilce, ToplamIndirim, ToplamKdv, Toplam, NetToplam, Vadesi, Iptal, SilindiMi, Aciklama, KaydedenID, KayitTarihi, DegistirenID, DegismeTarihi, DepoID, SatisElemaniID from Irsaliye Where IrsaliyeID=@IrsaliyeID  SET @FaturaID=SCOPE_IDENTITY()", SqlConnections.GetBaglanti(), trGenel))
				{
					cmd.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = gvIrsaliye.GetFocusedRowCellValue("IrsaliyeID").ToString();
					cmd.Parameters.Add("@IrsaliyeNo", SqlDbType.NVarChar).Value = KullanilanNumara;
					cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Direction = ParameterDirection.Output;
					cmd.ExecuteNonQuery();
					FaturaID = cmd.Parameters["@FaturaID"].Value.ToString();
				}

				#endregion

				#region FATURA DETAY KAYDEDİLİYOR.
				//Sql deki Fatura Tablosunun altındaki "FaturaHareket_INSERT" Trigger inin çalışması için tek tek eklemek zorundayız.
				DataTable dtTemp = new DataTable();
				using (SqlDataAdapter da = new SqlDataAdapter(@" SELECT IrsaliyeHareketID,SatirIndirimliKDVTutar,SatirToplamIndirim,SatirToplamTutar FROM  dbo.IrsaliyeHareket Where IrsaliyeID IN(" + Secilenler + @") ", SqlConnections.GetBaglanti()))
				{
					da.SelectCommand.Transaction = trGenel;
					da.Fill(dtTemp);
				}

				decimal SatirToplamIndirim = 0, SatirIndirimliKDVTutar = 0, Toplam = 0, SatirToplamTutar = 0;
				foreach (DataRow item in dtTemp.AsEnumerable())
				{
					//IrsaliyeHareket Satırları, FaturaHareket tablosuna tek tek kaydediliyor.

					//Yeni Fatura kaydının içindeki bütün satırların Alt Toplamları hesaplanıyor.
					SatirIndirimliKDVTutar += Convert.ToDecimal(item["SatirIndirimliKDVTutar"].ToString());
					SatirToplamIndirim += Convert.ToDecimal(item["SatirToplamIndirim"].ToString());
					SatirToplamTutar += Convert.ToDecimal(item["SatirToplamTutar"].ToString());

					using (SqlCommand cmd = new SqlCommand(@" Insert Into FaturaHareket  SELECT    @FaturaID ,SatirNo, StokID, Miktar, StokAnaBirimID, AnaBirimFiyat, Birim2ID, KatSayi, Birim2Fiyat, Kdv, Toplam, KdvToplam, Net, StokIskonto1, StokIskonto2, StokIskonto3, CariIskonto1, CariIskonto2, CariIskonto3, IndirimYuzdesi1, IndirimYuzdesi, Indirim, SatirIndirimliBirimFiyat, SatirIndirimliKDVTutar, SatirIndirimliToplam,  AltIndirimBirimFiyat, AltIndirimKDVTutar, AltIndirimToplamTutar, SatirToplamIndirim, SatirToplamTutar, SatirAciklama, DepoID FROM dbo.IrsaliyeHareket Where IrsaliyeHareketID=@IrsaliyeHareketID  ", SqlConnections.GetBaglanti(), trGenel))
					{
						cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
						cmd.Parameters.Add("@IrsaliyeHareketID", SqlDbType.Int).Value = item["IrsaliyeHareketID"].ToString();
						cmd.ExecuteNonQuery();
					}
				}
				Toplam = SatirToplamTutar - SatirIndirimliKDVTutar;
				#endregion

				#region İRSALİYE FATURALANDI OLARAK İŞARETLENİYOR
				using (SqlCommand cmd = new SqlCommand(@"Update Irsaliye SET Faturalandi =1 Where IrsaliyeID IN (" + Secilenler + @") ", SqlConnections.GetBaglanti(), trGenel))
				{
					cmd.ExecuteNonQuery();
				}
				#endregion

				#region YENİ KAYDEDİLEN FATURADAKİ TOPLAM ALANLARI GÜNCELLENİYOR.
				using (SqlCommand cmd = new SqlCommand(@"Update Fatura SET ToplamKdv =@ToplamKdv, ToplamIndirim=@ToplamIndirim,Toplam=@Toplam,NetToplam=@NetToplam Where FaturaID=@FaturaID ", SqlConnections.GetBaglanti(), trGenel))
				{
					cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
					cmd.Parameters.Add("@ToplamKdv", SqlDbType.Decimal).Value = SatirIndirimliKDVTutar;
					cmd.Parameters.Add("@ToplamIndirim", SqlDbType.Decimal).Value = SatirToplamIndirim;
					cmd.Parameters.Add("@Toplam", SqlDbType.Decimal).Value = Toplam;
					cmd.Parameters.Add("@NetToplam", SqlDbType.Decimal).Value = SatirToplamTutar;
					cmd.ExecuteNonQuery();
				}
				#endregion

				#region FATURALANAN İRSALİYE/İRSALİYELER FATURALAR İLE İLİŞKİLENDİRİLİYOR.
				//FaturaIrsaliye tablosunda fatura ve Irsaliyeleri ilişkilendiriyoruz.
				//şimdilik irsaliyeden faturayı sil yada fatura silinince bunun irsaliyeside silinsin yok ama ileride istenirse. bu ilişki tablosu kullanılacak.
				//İRSALİYEDEN FATURA OLUŞTURULACAĞI İÇİN Evrak1->İRSAİLYE, Evrak2-> FATURA YI TEMSİL ETMEKTEDİR.
				string[] s = Secilenler.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < s.Length; i++)
				{
					using (SqlCommand cmd = new SqlCommand(@"Insert EvrakIliski(Evrak1Tip,Evrak2Tip,Evrak1ID,Evrak2ID) Values(@Evrak1Tip,@Evrak2Tip,@Evrak1ID,@Evrak2ID)", SqlConnections.GetBaglanti(), trGenel))
					{
						cmd.Parameters.Add("@Evrak1Tip", SqlDbType.Int).Value = gvIrsaliye.GetFocusedRowCellValue("IrsaliyeTipi").ToString();
						cmd.Parameters.Add("@Evrak2Tip", SqlDbType.Int).Value = Convert.ToInt32(gvIrsaliye.GetFocusedRowCellValue("IrsaliyeTipi").ToString()) - 5;
						cmd.Parameters.Add("@Evrak1ID", SqlDbType.Int).Value = s[i].ToString();
						cmd.Parameters.Add("@Evrak2ID", SqlDbType.Int).Value = FaturaID;
						cmd.ExecuteNonQuery();
					}
				}
				#endregion

				trGenel.Commit();
				btnFiltrele_Click(null, null);
				gvIrsaliye.FocusedRowHandle = Satir;
			}
			catch (Exception hata)
			{
				trGenel.Rollback();
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void contextMenuStrip1_Opened(object sender, EventArgs e)
		{
			if (gvIrsaliye.DataRowCount <= 0)
				cbtnFaturalandir.Visible = false;
		}
	}
}