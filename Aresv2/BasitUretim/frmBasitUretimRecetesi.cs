using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


namespace Aresv2.BasitUretim
{
    public partial class frmBasitUretimRecetesi : DevExpress.XtraEditors.XtraForm
    {
        public frmBasitUretimRecetesi(int BUReceteID)
        {
            _BUReceteID = BUReceteID;
            InitializeComponent();
        }
        int _BUReceteID;

        // Maliyet tanımları Fiyat Tanımları + Son Alış Fiyatı + Elle Giriştir.
        DataTable dt_MaliyetTanimlari;

        clsTablolar.BasitUretim.csBasitUretimRecete Recete;
        clsTablolar.BasitUretim.csBasitUretimReceteDetay Detay;

        Stok.frmStokListesi StokArama;


        SqlTransaction TrGenel;
        clsTablolar.Stok.csStok StokClasi;

        Stok.frmStokDetay StokKarti;

        private void frmBasitUretimRecetesi_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Recete = new clsTablolar.BasitUretim.csBasitUretimRecete(SqlConnections.GetBaglanti(), TrGenel, _BUReceteID);
                Detay = new clsTablolar.BasitUretim.csBasitUretimReceteDetay();

                Detay.Getir(SqlConnections.GetBaglanti(), TrGenel, Recete.BUReceteID);

                gridControl1.DataSource = Detay.dt;

                if (Recete.BUReceteID != -1)
                {
                    StokClasi = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, Recete.UretilenStokID);
                    UretilenStokID_denStokBilgileriniGetir();
                }

                MaliyetTanimlariniOlustur();
                claslardanYukle();
                TrGenel.Commit();

                Kaydet_Vazgec_Sil_Enable(true);
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }




        void claslardanYukle()
        {
            txtOzelKod1.Text = Recete.OzelKod1;
            txtOzelKod2.Text = Recete.OzelKod2;
            memoEdit_Aciklama.Text = Recete.Aciklama;
            txtUretimMiktari.EditValue = Recete.UretimMiktari;
        }
        void ClaslaraGonder()
        {
            Recete.OzelKod1 = txtOzelKod1.Text;
            Recete.OzelKod2 = txtOzelKod2.Text;
            Recete.Aciklama = memoEdit_Aciklama.Text;
            Recete.UretimMiktari = Convert.ToDecimal(txtUretimMiktari.EditValue);
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            StokArama = new Stok.frmStokListesi(true);
            StokArama.Stok_Sec = StokEkle;
            StokArama.ShowDialog();

            //gridView1.FocusedRowHandle = gvSiparisHareket.RowCount - 1;
            //gridView1.FocusedColumn = colMiktar;
            //gridView1.ShowEditor();
        }

        void StokEkle(int StokID, decimal Miktar)
        {
            StokClasi = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, StokID);
            Detay.dt.Rows.Add(Detay.dt.NewRow());

            Detay.dt.Rows[Detay.dt.Rows.Count - 1]["MalzemeStokID"] = StokClasi.StokID;
            Detay.dt.Rows[Detay.dt.Rows.Count - 1]["StokAdi"] = StokClasi.StokAdi;
            Detay.dt.Rows[Detay.dt.Rows.Count - 1]["StokKodu"] = StokClasi.StokKodu;

            Detay.dt.Rows[Detay.dt.Rows.Count - 1]["MaliyetFiyatTanimID"] = clsTablolar.Ayarlar.csAyarlar.StokAlisFiyatTanimID;

            Detay.dt.Rows[Detay.dt.Rows.Count - 1]["MaliyetFiyatTanimID"] = clsTablolar.Ayarlar.csAyarlar.StokAlisFiyatTanimID;
            Kaydet_Vazgec_Sil_Enable(true);
        }
        clsTablolar.csFiyatTanim FiyatTanimlari = new clsTablolar.csFiyatTanim();

        void MaliyetTanimlariniOlustur()
        {
            dt_MaliyetTanimlari = new DataTable();


            dt_MaliyetTanimlari = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel).Copy();



            dt_MaliyetTanimlari.Rows.Add(dt_MaliyetTanimlari.NewRow());
            dt_MaliyetTanimlari.Rows[dt_MaliyetTanimlari.Rows.Count - 1]["FiyatTanimID"] = -2;
            dt_MaliyetTanimlari.Rows[dt_MaliyetTanimlari.Rows.Count - 1]["FiyatTanimAdi"] = "Son Alis Fiyati";

            dt_MaliyetTanimlari.Rows.Add(dt_MaliyetTanimlari.NewRow());
            dt_MaliyetTanimlari.Rows[dt_MaliyetTanimlari.Rows.Count - 1]["FiyatTanimID"] = -3;
            dt_MaliyetTanimlari.Rows[dt_MaliyetTanimlari.Rows.Count - 1]["FiyatTanimAdi"] = "Elle Giris";

            repositoryItemLookUpEdit_MaliyetFiyatTanim.DataSource = dt_MaliyetTanimlari;
            repositoryItemLookUpEdit_MaliyetFiyatTanim.ValueMember = "FiyatTanimID";
            repositoryItemLookUpEdit_MaliyetFiyatTanim.DisplayMember = "FiyatTanimAdi";

            lkpFiyatTanimDegistir.Properties.DataSource = dt_MaliyetTanimlari;
            lkpFiyatTanimDegistir.Properties.ValueMember = "FiyatTanimID";
            lkpFiyatTanimDegistir.Properties.DisplayMember = "FiyatTanimAdi";



        }

        void MaliyetFiyatiGetir()
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            for (int i = 0; i < gridView1.RowCount; i++)
            {

                decimal MaliyetFiyati = 0;

                // MaliyetFiyatTanimID -2 ise Son Alış Fiyatını Getir
                if ((int)gridView1.GetRowCellValue(i, colMaliyetFiyatTanimID) == -2)
                {
                    MaliyetFiyati = FiyatTanimlari.SonAlisFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, (int)gridView1.GetRowCellValue(i, colMalzemeStokID));
                }
                // MaliyetFiyatTanimID -3 ise Maliyet Fiyatı Elle Girilecek
                else if ((int)gridView1.GetRowCellValue(i, colMaliyetFiyatTanimID) == -3)
                {

                }

                else

                    MaliyetFiyati = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, (int)gridView1.GetRowCellValue(i, colMaliyetFiyatTanimID), (int)gridView1.GetRowCellValue(i, colMalzemeStokID));

                gridView1.SetRowCellValue(i, colMaliyetFiyati, MaliyetFiyati);


            }
            TrGenel.Commit();
            SatirTutarHesapla();
            ToplamMaliyetHesapla();
        }

        void SatirTutarHesapla()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                decimal Tutar = Convert.ToDecimal(gridView1.GetRowCellValue(i, colMaliyetFiyati)) * Convert.ToDecimal(gridView1.GetRowCellValue(i, colGerekliMiktar));

                gridView1.SetRowCellValue(i, colMaliyetTutari, Tutar);
            }

        }

        void ToplamMaliyetHesapla()
        {
            decimal ToplamMaliyet = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                ToplamMaliyet += Convert.ToDecimal(gridView1.GetRowCellValue(i, colMaliyetTutari));
            }
            txtToplamMaliyet.EditValue = ToplamMaliyet;
        }

        private void btnStokBul_Click(object sender, EventArgs e)
        {
            StokArama = new Stok.frmStokListesi(true);
            StokArama.Stok_Sec = UretilenStokEkle;
            StokArama.ShowDialog();
            //gvSiparisHareket.FocusedRowHandle = gvSiparisHareket.RowCount - 1;
            //gvSiparisHareket.FocusedColumn = colMiktar;
            //gvSiparisHareket.ShowEditor();
        }

        void UretilenStokEkle(int StokID, decimal Miktar)
        {
            Recete.UretilenStokID = StokID;
            UretilenStokID_denStokBilgileriniGetir();
        }

        void UretilenStokID_denStokBilgileriniGetir()
        {
            StokClasi = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, Recete.UretilenStokID);
            lblStokAdi.Text = StokClasi.StokAdi;
            lblStokKodu.Text = StokClasi.StokKodu;

        }

        void Kaydet_Vazgec_Sil_Enable(bool true_false)
        {
            if (true_false == true)
                Tag = 0;
            else
                Tag = 1;

            btnKaydet.Enabled = true_false;
            btnVazgec.Enabled = true_false;
            btnSil.Enabled = !true_false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                ClaslaraGonder();
                BindingContext[gridControl1.DataSource].EndCurrentEdit();

                Recete.Kaydet(SqlConnections.GetBaglanti(), TrGenel);
                Detay.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Recete.BUReceteID);

                TrGenel.Commit();
                Kaydet_Vazgec_Sil_Enable(false);
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            Kaydet_Vazgec_Sil_Enable(false);
            Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğine emin misin??", "Ahanda dikkat", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Recete.Sil(SqlConnections.GetBaglanti(), TrGenel);
                TrGenel.Commit();
                Close();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStokCikar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle < 0) return;
                if (XtraMessageBox.Show("satırı silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                gridView1.DeleteSelectedRows();
                Kaydet_Vazgec_Sil_Enable(true);
                //SiparisHareket.dt_SiparisHareketleri.Rows.RemoveAt(gvSiparisHareket.FocusedRowHandle);
                //SatirNumaralariniOlustur();
                //hesaplama.AltToplamlariHesapla();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Kaydet_Vazgec_Sil_Enable(true);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MaliyetFiyatiGetir();
        }

        private void btnStokKartAc_Click(object sender, EventArgs e)
        {
            StokKarti = new Stok.frmStokDetay(Recete.UretilenStokID);
            StokKarti.MdiParent = this.MdiParent;
            StokKarti.Show();
        }

        private void ButunTextlerIcin_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Kaydet_Vazgec_Sil_Enable(true);
        }

        private void frmBasitUretimRecetesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                MessageBox.Show("Kayıt Tamamlanmadı");
                e.Cancel = true;
            }

        }

        private void btnHarekettekiStokKartiniAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;

            StokKarti = new Stok.frmStokDetay((int)gridView1.GetFocusedRowCellValue(colMalzemeStokID));
            StokKarti.MdiParent = this.MdiParent;
            StokKarti.Show();
        }

        private void btnMaliyetFiyatTanimDegistir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Fiyat Tanimlari Degisecek", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, colMaliyetFiyatTanimID, lkpFiyatTanimDegistir.EditValue);
            }
        }

        private void dropDownButton_Yazdir_Click(object sender, EventArgs e)
        {

        }

        #region Yazdırma İşlemleri
        clsTablolar.Yazdirma.csYazdir yazdirrr = new clsTablolar.Yazdirma.csYazdir();
        //DataTable dt_yazdirma = new DataTable();

        void YazdirmakicinVerileriHazirla()
        {
            yazdirrr.dt_ekle("UretimUstBilgi");
            yazdirrr.dt_ekle("UretimDetay");
            yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "UretilenStokAdi", string.Empty, System.Type.GetType("System.String"));
            yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "UretilenStokBarkodu", string.Empty, System.Type.GetType("System.String"));
            yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "UretilenStokKodu", string.Empty, System.Type.GetType("System.String"));
            yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "UretilenStokAciklama", string.Empty, System.Type.GetType("System.String"));
            yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "UretilenStokKodu", string.Empty, System.Type.GetType("System.String"));
            yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "UretilenStokKodu", string.Empty, System.Type.GetType("System.String"));


            yazdirrr.dt_yeAlanEkle("UretimDetay", "HammaddeStokKodu", System.Type.GetType("System.String"));
            yazdirrr.dt_yeAlanEkle("UretimDetay", "HammaddeStokAdi", System.Type.GetType("System.String"));
            yazdirrr.dt_yeAlanEkle("UretimDetay", "HammaddeAciklama", System.Type.GetType("System.String"));
            yazdirrr.dt_yeAlanEkle("UretimDetay", "HammaddeKullanilanMiktar", System.Type.GetType("System.Decimal"));
            yazdirrr.dt_yeAlanEkle("UretimDetay", "HammaddeAciklama", System.Type.GetType("System.String"));

            //yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "UretilenStokAciklama", DBNull.Value, System.Type.GetType("System.DateTime"));
            //yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "UretilenStokKartiAciklama", DBNull.Value, System.Type.GetType("System.DateTime"));
            //yazdirrr.dtAlanEkleVeriEkle("UretimUstBilgi", "FaturaTutari", DBNull.Value, System.Type.GetType("System.Decimal"));


            yazdirrr.Yazdirr(clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir);


            //MusteriFisi = new DevExpress.XtraReports.UI.XtraReport();
            //MusteriFisi.LoadLayout(Application.StartupPath + @"\Raporlar\MusteriNumarasi.repx");
        }
        //DevExpress.XtraReports.UI.XtraReport MusteriFisi;

        private void btnYazdir_Click(object sender, EventArgs e)
        {





            //this.TopMost = true;



            //this.TopMost = false;

            //this.Show();
            //this.Activate();




        }


        #endregion

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(yazdirrr, clsTablolar.csRaporDizayn.RaporModul.BasitUretimRecetesi);
            frm.ShowDialog();
        }
    }
}