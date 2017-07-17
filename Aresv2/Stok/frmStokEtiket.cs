using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Aresv2.Stok
{
    public partial class frmStokEtiket : DevExpress.XtraEditors.XtraForm
    {
        public frmStokEtiket()
        {
            InitializeComponent();
        }

        DataTable dt_Yazdirilacak; // Grid Buna bağlı
        clsTablolar.Stok.csStok StokBilgileri;
        //clsTablolar.Stok.fi
        clsTablolar.csFiyatTanim FiyatTanimlari = new clsTablolar.csFiyatTanim();


        SqlTransaction TrGenel;

        private void frmStokEtiket_Load(object sender, EventArgs e)
        {
            // TODO: Kolonların tipleri girilecek
            #region Yetki ayarları

            if (clsTablolar.Ayarlar.csYetkiler.StokKartGorme == false)
            {
                btnStokAc.Visible = false;
            }

            #endregion


            dt_Yazdirilacak = new DataTable();
            dt_Yazdirilacak.Columns.Add("StokID", System.Type.GetType("System.Int32"));
            dt_Yazdirilacak.Columns.Add("Stok Kodu");
            dt_Yazdirilacak.Columns.Add("Stok Adi");
            dt_Yazdirilacak.Columns.Add("Stok Etiket Adi");
            dt_Yazdirilacak.Columns.Add("Barkodu", System.Type.GetType("System.String"));
            dt_Yazdirilacak.Columns.Add("Ozel Kod1");
            dt_Yazdirilacak.Columns.Add("Ozel Kod2");
            dt_Yazdirilacak.Columns.Add("Ozel Kod3");
            dt_Yazdirilacak.Columns.Add("Fiyat1", System.Type.GetType("System.Decimal"));
            dt_Yazdirilacak.Columns.Add("Fiyat2", System.Type.GetType("System.Decimal"));
            dt_Yazdirilacak.Columns.Add("Aciklama");
            dt_Yazdirilacak.Columns.Add("RafYeri", System.Type.GetType("System.String"));

            dt_Yazdirilacak.Columns.Add("Ozel Tarih", System.Type.GetType("System.DateTime")); // Bu stoktan gelmeyecek
            dt_Yazdirilacak.Columns.Add("Ozel Metin"); // Bu stoktan gelmeyecek


            dt_Yazdirilacak.Columns.Add("EtiketMiktari", System.Type.GetType("System.Int32"));

            dt_Yazdirilacak.Columns.Add("AnaBirimID", System.Type.GetType("System.Int32"));
            dt_Yazdirilacak.Columns.Add("AltBirimID", System.Type.GetType("System.Int32"));
            dt_Yazdirilacak.Columns.Add("AltBirimBarkod", System.Type.GetType("System.String"));
            dt_Yazdirilacak.Columns.Add("AltBirimAdi", System.Type.GetType("System.String"));
            dt_Yazdirilacak.Columns.Add("AltBirimKatSayi", System.Type.GetType("System.Decimal"));
            dt_Yazdirilacak.Columns.Add("AnaBirimAdi", System.Type.GetType("System.String"));

            dt_Yazdirilacak.Columns.Add("BirimAciklama", System.Type.GetType("System.String"));


            // Yapılması gereken alanları tek tek doldurtup
            // Sonra Miktar alanı kadar tekrar eklenecek
            // en son yazdırmaya göndermeden önce miktar kolonunu sil.

            gridControl1.DataSource = dt_Yazdirilacak;


            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

            lkpFiyat1Tanim.Properties.DataSource = FiyatTanimlari.FiyatTanimGetir(SqlConnections.GetBaglanti(), TrGenel);

            lkpFiyat1Tanim.Properties.DisplayMember = "FiyatTanimAdi";
            lkpFiyat1Tanim.Properties.ValueMember = "FiyatTanimID";

            //TODO: değerler ayarlardan gelecek;
            lkpFiyat1Tanim.EditValue = 2;
            lkpFiyat2Tanim.EditValue = 3;



            lkpFiyat2Tanim.Properties.DataSource = FiyatTanimlari.FiyatTanimGetir(SqlConnections.GetBaglanti(), TrGenel);

            lkpFiyat2Tanim.Properties.DisplayMember = "FiyatTanimAdi";
            lkpFiyat2Tanim.Properties.ValueMember = "FiyatTanimID";
            TrGenel.Commit();
        }

        private void BarkoduMiktarliBirBarkodIseMiktarHanesiniDoldur()
        {
            frmMiktarGir frm = new frmMiktarGir(0);

            frm.textEdit1.Text = "1";

            frm.labelControl1.Text = "Barkoda yazılacak Miktarı Girin";
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {

                string BarkodaEklenecek = "";

                decimal Miktar = Convert.ToDecimal(frm.textEdit1.EditValue);

                gridView1.SetFocusedRowCellValue(colAltBirimKatSayi, Miktar);

                if (Miktar >= 10) // miktar 10 a eşit veya küçük ise ilk basamak
                {
                    BarkodaEklenecek = Miktar.ToString().Replace(",", "");
                }
                else if (Miktar < 10) // 0 dan büyük 10 dan küçük ise (yani 1 basmaklı ise) başına 0 koyuyoruz
                {// 0 dan da küçükse gene başına 1 sıfır koyuyoruz çünkü 0 dan küçüksa ör: 0,10 ise başında 1 sıfır zaten var
                    BarkodaEklenecek = Miktar.ToString().Replace(",", "");
                    BarkodaEklenecek = "0" + BarkodaEklenecek;
                }
                // en sonunda da kontrol hanesine ulaşana kadar sonuna sıfır ekliyoruz

                for (int i = 0; 5 > BarkodaEklenecek.Length; i++) // buradaki 5 sayısının aslında ayarlardan gelmesi gerekiyor
                {
                    BarkodaEklenecek = BarkodaEklenecek + "0";
                }

                // daha da sonunda kontrol numarasını ekliyoruz

                #region KontrolNumarasıOluşturma

                int[] Tekler;
                int[] Ciftler;
                int KontrolNu = 0;

                BarkodaEklenecek = gridView1.GetFocusedRowCellValue(colAltBirimBarkod).ToString() + BarkodaEklenecek;

                if (BarkodaEklenecek.Length % 2 == 0) // numara nın uzunluğu çift ise
                {
                    Tekler = new int[BarkodaEklenecek.Length / 2];
                    Ciftler = new int[BarkodaEklenecek.Length / 2];
                }
                else // numaranın uzunluğu tek ise
                {
                    Tekler = new int[(BarkodaEklenecek.Length / 2) + 1];
                    Ciftler = new int[BarkodaEklenecek.Length / 2];
                }


                for (int i = 1, b = 0; i < BarkodaEklenecek.Length; i++, b++) // Sondan başlayarak ilk önce tek sonra cift sonra tek... diye atması lazım
                {
                    Tekler[b] = Convert.ToInt16(BarkodaEklenecek[BarkodaEklenecek.Length - i].ToString());
                    i += 1;
                    if (Ciftler.Length + 1 > b)
                        Ciftler[b] = Convert.ToInt16(BarkodaEklenecek[BarkodaEklenecek.Length - i].ToString());
                }
                //for (int i = 1; i < Ciftler.Length; i++) // çiftleri atıyorum
                //{
                //  Ciftler[i] = Convert.ToInt16(numara[numara.Length - (i * 2)]);
                //}

                //for (int i = 0; i < numara.Length; i++) // çiftleri atıyorum
                //{
                //  if (numara.le)
                //  Ciftler[i] = Convert.ToInt16(numara[numara.Length - (i * 2)]);
                //}
                int TeklerToplami = 0;
                int CiftlerToplami = 0;
                for (int i = 0; i < Tekler.Length; i++)
                {
                    TeklerToplami += Tekler[i];
                }
                for (int i = 0; i < Ciftler.Length; i++)
                {
                    CiftlerToplami += Ciftler[i];
                }


                KontrolNu = 10 - (((TeklerToplami * 3) + CiftlerToplami) % 10);

                BarkodaEklenecek = BarkodaEklenecek + KontrolNu.ToString();

                gridView1.SetFocusedRowCellValue(colAltBirimBarkod, BarkodaEklenecek);

                #endregion


                gridView1.PostEditor();
                gridView1.Focus();
                gridView1.RefreshData();
            }
        }

        #region yazdırma işlemleri
        clsTablolar.Yazdirma.csYazdir yazdir = new clsTablolar.Yazdirma.csYazdir();
        clsTablolar.Rapor.csRaporVarsayilanYolu varsayilanyol;
        frmRaporDizaynListesiv2 RaporDizaynListesi;

        /// <summary>
        /// bütün butonlardan önce bunu çalıştır sonra istediğin işlemi yap
        /// </summary>
        private void YazdirmakicinVerileriHazirla(bool SadeceSonEklenenSatiriYazdir)
        {
            gridView1.PostEditor();
            DataTable dt = dt_Yazdirilacak.Clone(); //
            //dt.Rows.Clear();

            if (SadeceSonEklenenSatiriYazdir == false) // eğer sadece son satır yazdırılmak isteniyorsa
            {
                for (int i = 0; i < dt_Yazdirilacak.Rows.Count; i++) // bütün satırlara uğrayıp
                {
                    for (int j = 0; j < Convert.ToInt32(Convert.ToDecimal(dt_Yazdirilacak.Rows[i]["EtiketMiktari"])); j++)
                    {
                        dt.ImportRow(dt_Yazdirilacak.Rows[i]);
                    }
                }
            }
            else
            {
                dt.ImportRow(dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]);
            }

            //yazdir = new clsTablolar.Yazdirma.csYazdir();

            if (yazdir.ds.Tables.Count != 0)
                yazdir.ds.Tables.Clear();
            //yazdir.ds.
            yazdir.dt_ekle(dt.Copy());
        }

        // yazdır
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla(false);
            YazdirmaIslemi = new Thread(new ThreadStart(Yazdir));
            YazdirmaIslemi.Start();
        }

        Thread YazdirmaIslemi;

        void Yazdir()
        {
            using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {

                varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), clsTablolar.csRaporDizayn.RaporModul.StokEtiket);

                yazdir.YaziciAdi = varsayilanyol.YaziciAdi;
                yazdir.KagitKaynagiIndex = varsayilanyol.KagitKaynagiIndex;
                yazdir.Yazdirr(varsayilanyol.RaporDizaynYolu, clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir);
            }
        }


        public void EklenenSonSatiriYazdir(int KopyaSayisi) //Bir yere bağlı değil sadece falan filan
        {
            YazdirmakicinVerileriHazirla(true);

            Thread th = new Thread(new ParameterizedThreadStart(SonEkleneniYazdir));
            th.Start(KopyaSayisi);
        }

        object lockTaken = new object();


        void SonEkleneniYazdir(object KopyaSayisi)
        {
            lock (lockTaken)
            {
                yazdir.YaziciAdi = SeciliYaziciAdi;
                yazdir.NumberOfCopy = (int)KopyaSayisi;
                yazdir.Yazdirr(clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir, SeciliYaziciAdi, (int)KopyaSayisi);// çok yanlış gelmişsin
                yazdir.NumberOfCopy = 1;
            }
        }


        // ön izle
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla(false);
            using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                yazdir.Yazdirr(varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), clsTablolar.csRaporDizayn.RaporModul.StokEtiket), clsTablolar.Yazdirma.csYazdir.Nasil.Goster);
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                YazdirmakicinVerileriHazirla(false);
                RaporDizaynListesi = new frmRaporDizaynListesiv2(yazdir, clsTablolar.csRaporDizayn.RaporModul.StokEtiket);
                RaporDizaynListesi.ShowDialog();
            }
            catch (Exception exxep)
            {
                MessageBox.Show(exxep.Message);
            }

        }
        #endregion

        public void StokEkle(int StokID, decimal Miktar)
        {
            try
            {
                Convert.ToInt32(Miktar);
            }
            catch (Exception)
            {
                MessageBox.Show("Tam Sayı Girilmesi Lazım");
                return;
            }

            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                StokBilgileri = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, StokID);

                dt_Yazdirilacak.Rows.Add(dt_Yazdirilacak.NewRow());

                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["StokID"] = StokBilgileri.StokID;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Stok Kodu"] = StokBilgileri.StokKodu;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Stok Adi"] = StokBilgileri.StokAdi;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Stok Etiket Adi"] = StokBilgileri.EtiketAdi;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Barkodu"] = StokBilgileri.Barkod;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Ozel Kod1"] = StokBilgileri.OzelKod1;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Ozel Kod2"] = StokBilgileri.OzelKod2;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Ozel Kod3"] = StokBilgileri.OzelKod3;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["RafYeri"] = StokBilgileri.RafYeriAciklama;


                decimal Fiyat1 = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, (int)lkpFiyat1Tanim.EditValue, StokBilgileri.StokID);
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Fiyat1"] = Fiyat1;

                decimal Fiyat2 = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, (int)lkpFiyat2Tanim.EditValue, StokBilgileri.StokID);
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Fiyat2"] = Fiyat2;

                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["Aciklama"] = StokBilgileri.Aciklama;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["EtiketMiktari"] = Miktar;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["AnaBirimAdi"] = StokBilgileri.StokAnaBirimAdi;


                // alt Birim ile ilgili alanlar
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["AltBirimKatSayi"] = 1;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["AltBirimID"] = StokBilgileri.StokBirimID;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["AltBirimAdi"] = StokBilgileri.StokAnaBirimAdi;
                dt_Yazdirilacak.Rows[dt_Yazdirilacak.Rows.Count - 1]["AltBirimBarkod"] = StokBilgileri.Barkod;

                BirimAciklamaKolonunaYaz(dt_Yazdirilacak.Rows.Count - 1, BirimFarki.AltBirimAyni);

                TrGenel.Commit();

                if (string.IsNullOrEmpty(StokBilgileri.Barkod))
                {
                    biri


                }
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
            if (ceStokEkleninceYazdir.CheckState == CheckState.Checked)
            {
                EklenenSonSatiriYazdir((int)Miktar);
            }
        }


        enum BirimFarki // ahanda ne la bu açıklama yaz
        {
            AltBirimAyni,
            AltBirimFarkli,
            AltBirimBarkodlu
        }

        private void BirimAciklamaKolonunaYaz(int SatirNo, BirimFarki Brim) // satirnumarasindan ilgili satırın Birim Aciklamasını oluşturur.
        {
            if (Brim == BirimFarki.AltBirimAyni)
            {
                dt_Yazdirilacak.Rows[SatirNo]["BirimAciklama"] = "1 " + gridView1.GetRowCellValue(SatirNo, colAnabirimAdi).ToString();
            }
            else if (Brim == BirimFarki.AltBirimFarkli)
            {
                dt_Yazdirilacak.Rows[SatirNo]["BirimAciklama"] = Convert.ToDecimal(gridView1.GetRowCellValue(SatirNo, colAltBirimKatSayi)).ToString("0.00") + " " + gridView1.GetRowCellValue(SatirNo, colAnabirimAdi).ToString() + " =  1 " + gridView1.GetRowCellValue(SatirNo, colAltBirimAdi).ToString();
            }
            else if (Brim == BirimFarki.AltBirimBarkodlu)
            {
                dt_Yazdirilacak.Rows[SatirNo]["BirimAciklama"] = Convert.ToDecimal(gridView1.GetRowCellValue(SatirNo, colAltBirimKatSayi)).ToString("0.00") + " " + gridView1.GetRowCellValue(SatirNo, colAltBirimAdi).ToString();
            }
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            Stok.frmStokListesi StokArama = new Stok.frmStokListesi(true);
            StokArama.Stok_Sec = StokEkle;
            StokArama.ShowDialog();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            gridView1.FocusedColumn = gridView1.Columns["EtiketMiktari"];
            gridView1.ShowEditor();
        }

        private void btnStokCikar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Seçili satır silinsin mi?", "Dikkat hamısına", MessageBoxButtons.YesNo))
                gridView1.DeleteSelectedRows();
        }

        private void btnStokAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;

            Stok.frmStokDetay frm = new frmStokDetay(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colStokID)));
            frm.MdiParent = this.MdiParent;
            frm.Show();

        }

        private void frmStokEtiket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && btnStokAc.Visible == true)
                btnStokEkle_Click(null, null);
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        void Temizle()
        {
            dt_Yazdirilacak.Clear();
        }

        // önce StokIDlerini BirKenera alsın sonra tüm stokları çıkartsın sonra yeniden eklesin
        // veya daha iyisi aklıma geldi
        private void btnYenile_Click(object sender, EventArgs e)
        {
            int[,] StokIDler = new int[gridView1.RowCount, 2];

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                StokIDler[i, 0] = (int)gridView1.GetRowCellValue(i, colStokID);
                StokIDler[i, 1] = (int)gridView1.GetRowCellValue(i, colEtiketMiktari);
            }
            Temizle();
            for (int i = 0; i < StokIDler.Length / 2; i++)
            {
                StokEkle(StokIDler[i, 0], StokIDler[i, 1]);
            }

        }

        private void btnMiktarDegistir_Click(object sender, EventArgs e)
        {
            frmMiktarGir MiktarGir = new frmMiktarGir(1);
            MiktarGir.labelControl1.Text = "Bütün Hepsinin Etiket Miktarını Değiştir";

            if (MiktarGir.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, colEtiketMiktari, Convert.ToInt32(MiktarGir.textEdit1.EditValue));
                }
            }
        }

        Stok.frmStokBirim AltBirimler;
        private void repositoryItemButtonEdit_AltBirimAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (AltBirimler = new frmStokBirim(SqlConnections.GetBaglanti(), Convert.ToInt32(gridView1.GetFocusedRowCellValue(colStokID)), false))
            {
                if (AltBirimler.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    gridView1.SetFocusedRowCellValue(colAltBirimAdi, AltBirimler.AltBirimAdi);
                    gridView1.SetFocusedRowCellValue(colAltBirimID, AltBirimler.AltBirimID);
                    gridView1.SetFocusedRowCellValue(colAltBirimKatSayi, AltBirimler.AltBirimKatsayi);
                    gridView1.SetFocusedRowCellValue(colAltBirimBarkod, AltBirimler.AltBirimBarkod);


                    if (AltBirimler.BirimCevrimID == -1) // Eğer Birim ÇevrimID -1 ise bu anabirimdir. (formdan ana birim seçilmiştir.)
                    {
                        BirimAciklamaKolonunaYaz(gridView1.GetFocusedDataSourceRowIndex(), BirimFarki.AltBirimAyni);
                    }
                    else if (AltBirimler.MiktarYaziyorMu == true)
                    {
                        BarkoduMiktarliBirBarkodIseMiktarHanesiniDoldur();
                        BirimAciklamaKolonunaYaz(gridView1.GetFocusedDataSourceRowIndex(), BirimFarki.AltBirimBarkodlu);
                    }
                    else
                    {
                        BirimAciklamaKolonunaYaz(gridView1.GetFocusedDataSourceRowIndex(), BirimFarki.AltBirimFarkli);
                    }

                    gridView1.PostEditor();
                    gridView1.Focus();
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        string SeciliYaziciAdi;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            clsTablolar.frmYaziciSec frm = new clsTablolar.frmYaziciSec();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                SeciliYaziciAdi = frm.SecilenYaziciAdi;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(clsTablolar.csRaporDizayn.RaporModul.StokEtiket))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    frm.btnDuzenle.Visible = false;
                    frm.btnEkle.Visible = false;
                    frm.btnOnizle.Visible = false;
                    frm.btnSil.Visible = false;
                    frm.btnYazdir.Visible = false;
                    frm.btnYazdirmaDiyalogu.Visible = false;

                    yazdir.DosyayaiArabellegeAl(frm.SeciliRaporYolu);
                }
            }
        }
    }
}