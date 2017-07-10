using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace clsTablolar.TeraziSatisClaslari
{
    public partial class frmSiparis : Form
    {
        public frmSiparis(int SiparisID, SqlConnection Baglanti, int TeraziID, int SiparisiFaturalandiracakPersonel)
        {
            this.TeraziID = TeraziID;
            this.Baglanti = Baglanti;
            this.SiparisiFaturalandiracakPersonel = SiparisiFaturalandiracakPersonel;
            _SiparisID = SiparisID;
            InitializeComponent();
        }
        public sealed class InputPane { }
        //public sealed class InputPane
        //{
        int _SiparisID;
        int TeraziID;
        int SiparisiFaturalandiracakPersonel;
        //}
        clsTablolar.Siparis.csSiparis Siparis;
        clsTablolar.Siparis.csSiparisHareket SiparisHareket;
        SqlConnection Baglanti;

        SqlTransaction TrGenel;

        public delegate void dlg_SiparisiSatisaAktarma(string FaturaBarkod);
        public dlg_SiparisiSatisaAktarma SiparisiSatisaAktarma;

        private void frmSiparis_Load(object sender, EventArgs e)
        {

            clsTablolar.Siparis.csSiparisDurumTanimlari DurumTanimlari = new clsTablolar.Siparis.csSiparisDurumTanimlari();
            TrGenel = Baglanti.BeginTransaction();
            lkpSiparisDurumu.Properties.DataSource = DurumTanimlari.dt_Getir(Baglanti, TrGenel);
            TrGenel.Commit();

            lkpSiparisDurumu.Properties.ValueMember = "SiparisDurumTanimID";
            lkpSiparisDurumu.Properties.DisplayMember = "SiparisDurumTanimAdi";

            if (_SiparisID == -1)
            {
                TrGenel = Baglanti.BeginTransaction();
                Siparis = new clsTablolar.Siparis.csSiparis(Baglanti, TrGenel, clsTablolar.Siparis.csSiparis.SiparisTip.AlinanSiparis, clsTablolar.Ayarlar.csAyarlar.TeraziVarsayilanCariID);
                SiparisHareket = new clsTablolar.Siparis.csSiparisHareket(Baglanti, TrGenel, _SiparisID);
                TrGenel.Commit();
                Siparis.HizliSatistaDegisiklikYapmaIzniVarMi = true;
                Siparis.HizliSatistaGozukecekMi = true;
                Siparis.SiparisDurumTanimID = clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.YeniSiparisDurumID;
            }
            else
            {
                TrGenel = Baglanti.BeginTransaction();
                Siparis = new clsTablolar.Siparis.csSiparis(Baglanti, TrGenel, _SiparisID);
                SiparisHareket = new clsTablolar.Siparis.csSiparisHareket(Baglanti, TrGenel, _SiparisID);
                TrGenel.Commit();
            }
            bindle();

            gridControl1.DataSource = SiparisHareket.dt_SiparisHareketleri;
            hesapla = new clsTablolar.csFatura_Irsaliye_Teklif_Hesapla(SiparisHareket.dt_SiparisHareketleri, gridView1);

            hesapla.AltToplamlarDegisti = AltToplamlariAl;

            KayitTamamlandimi(true);
        }

        void KayitTamamlandimi(bool TamamMi)
        {
            if (TamamMi == true)
            {
                btnKaydet.Enabled = false;
                btnVazgec.Enabled = false;
            }
            else
            {
                btnKaydet.Enabled = true;
                btnVazgec.Enabled = true;
            }
        }

        void bindle()
        {
            lkpSiparisDurumu.DataBindings.Add("EditValue", Siparis, "SiparisDurumTanimID", true, DataSourceUpdateMode.OnPropertyChanged);
            txtToplamTutar.DataBindings.Add("EditValue", Siparis, "SiparisTutari", true, DataSourceUpdateMode.OnPropertyChanged);
            txtKdvTutari.DataBindings.Add("EditValue", Siparis, "ToplamKdv", true, DataSourceUpdateMode.OnPropertyChanged);
            txtToplamIskonto.DataBindings.Add("EditValue", Siparis, "ToplamIndirim", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSiparisBarkodu.DataBindings.Add("EditValue", Siparis, "SiparisBarkodNu", true, DataSourceUpdateMode.OnPropertyChanged);

            memoAciklama.DataBindings.Add("EditValue", Siparis, "Aciklama", true, DataSourceUpdateMode.OnPropertyChanged);
            memoMusterininAdiSoyadi.DataBindings.Add("EditValue", Siparis, "CariTanim", true, DataSourceUpdateMode.OnPropertyChanged);

            txtSiparisTarihi.DataBindings.Add("EditValue", Siparis, "SiparisTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTeslimTarihi.DataBindings.Add("EditValue", Siparis, "TeslimTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPersonelAdi.DataBindings.Add("EditValue", Siparis, "PersonelAdi", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        void AltToplamlariAl()
        {
            Siparis.IskontoluToplam = hesapla.IskontoluToplam;
            Siparis.ToplamKdv = hesapla.ToplamKdv;
            Siparis.SiparisTutari = hesapla.FaturaTutari;
            Siparis.StokIskontoToplami = hesapla.StokIskontoToplami;
            Siparis.ToplamIndirim = hesapla.ToplamIndirim;
            Siparis.Toplam_Iskontosuz_Kdvsiz = hesapla.Toplam_Iskontosuz_Kdvsiz;
            Siparis.CariIskontoToplami = hesapla.CariIskontoToplami;

            txtToplamTutar.EditValue = hesapla.FaturaTutari;
            txtKdvTutari.EditValue = hesapla.ToplamKdv;
            txtToplamIskonto.EditValue = hesapla.ToplamIndirim;
        }

        clsTablolar.csFatura_Irsaliye_Teklif_Hesapla hesapla;
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        System.Diagnostics.Process proc = new System.Diagnostics.Process();// = System.Diagnostics.Process.Start(keyboardPath);

        private void btnKlavyeyiAc_Click(object sender, EventArgs e)
        {




            //System.Diagnostics.Process proc = System.Diagnostics.Process.
            //proc.Close();

            proc.Start();


        }

        private void btnStokButonlari_Click(object sender, EventArgs e)
        {
            using (frmButonUrunler frm = new frmButonUrunler(TeraziID, Baglanti))
            {
                if (DialogResult.Yes == frm.ShowDialog(this))
                {
                    StokEkle(frm.GeriDonenStokID);
                }
            }
        }

        clsTablolar.TeraziSatisClaslari.csStok Stok = new clsTablolar.TeraziSatisClaslari.csStok();

        clsTablolar.TeraziSatisClaslari.csPersonel Personel = new clsTablolar.TeraziSatisClaslari.csPersonel();

        public void StokEkle(int StokID)
        {
            if (clsTablolar.TeraziSatisClaslari.csStok.StokDonenBilgi.StokBulunamadi != Stok.GetirHamisina(Baglanti, TrGenel, StokID))
            {
                //gcSatisHareketleri.DataSource = Hareketler.dt_FaturaHareketleri;

                SiparisHareket.dt_SiparisHareketleri.Rows.Add(SiparisHareket.dt_SiparisHareketleri.NewRow());

                int SonSatirIndex = SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1;
                int SonSatirRowHandle = gridView1.GetRowHandle(SonSatirIndex);
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["SiparisID"] = Siparis.SiparisID;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["SiparisHareketStokAdi"] = Stok.StokAdi;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["StokID"] = Stok.StokID;
                //SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["StokAnaBirimAdi"] = Stok.StokAnaBirimAdi;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["AnaBirimFiyat"] = Stok.KdvHaricFiyat; // ana Birime Her zaman kdv hariç Fiyatı atıyoruz hamısına çünkü hesaplamaları öyle
                //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["KdvDahilFiyat"] = Stok.KdvDahilFiyat; // ana Birime Her zaman kdv hariç Fiyatı atıyoruz hamısına çünkü hesaplamaları öyle

                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["Kdv"] = Stok.Kdv;

                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["StokIskonto1"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["StokIskonto2"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["StokIskonto3"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["CariIskonto1"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["CariIskonto2"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["CariIskonto3"] = 0;


                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["StokAnaBirimID"] = Stok.AnaBirimID;

                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["KatSayi"] = 1;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["Birim2ID"] = Stok.AnaBirimID;
                //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = MiktarAl.OkunanSabitMiktar;
                //TerazidenSabitMiktariAl(MiktarAl.OkunanSabitMiktar);
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["FireMiktari"] = 0;
                //SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["FireVarMi"] = 0;
                //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["BirlesikUrunHareketID"] = -2; // -2 verildiği zaman ne birleşik ürün veya birleşik ürünün alt ürünleri değil manasına gelsin


                //SiparisHareket.dt_SiparisHareketleri.Rows[SonSatirIndex]["Miktar"] = 1;
                //gridView1.SetFocusedRowCellValue(colMiktar, 1);
                gridView1.SetRowCellValue(SonSatirRowHandle, colMiktar, 1);
                gridView1.RefreshData();

                //TrGenel.Commit();
                //BindleHamisina();

                //if (checkEdit3.Checked == true && Convert.ToDecimal(txtTerazidenGelenSabitMiktar.Text) == 0)
                //{
                //    btnDaraAl_Click(null, null);
                //}

            }
            else
                MessageBox.Show(this, "Ürün bulunamadı\nVeya fiyatı yok");

        }
        clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama BarkodtanStokArma;
        private void btnBarkodAra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarkod.Text.StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.FaturaBarkodIcinKullanilacakOnEk))
                {
                    MessageBox.Show("Burada sadece ürün veya personel barkod numarası girilebilir");
                    return;
                }
                if (txtBarkod.Text.StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.PersonelBarkodNumarasiOnEki)) // girinlen numara personel numarası ise
                {
                    TrGenel = Baglanti.BeginTransaction();
                    Personel.BardoktanPersonelGetir(Baglanti, TrGenel, txtBarkod.Text);
                    TrGenel.Commit();
                    if (Personel.PersonelID == -1)
                    {
                        MessageBox.Show("Yok hamısına");
                    }
                    else
                    {
                        txtPersonelAdi.Text = Personel.PersonelAdi;
                        Siparis.SatisElemaniID = Personel.PersonelID;
                    }
                }
                else
                {
                    TrGenel = Baglanti.BeginTransaction();
                    BarkodtanStokArma = new clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama();
                    clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama.StokIDMiktarBirim IdveMiktar = BarkodtanStokArma.StokBarkodundanStokIDVer(Baglanti, TrGenel, txtBarkod.EditValue.ToString());
                    TrGenel.Commit();

                    if (IdveMiktar.StokID != -1)
                    {
                        try
                        {
                            StokEkle(IdveMiktar.StokID);

                            //if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colStokAnaBirimID) == 2 && IdveMiktar.Miktar ) // TODO : Ayarlardan alıcak
                            //{
                            //    Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["FireVarMi"] = 1;
                            //}

                            SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["KatSayi"] = IdveMiktar.Katsayi;
                            SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["Birim2ID"] = IdveMiktar.AltBirimID;
                            gridView1.SetFocusedRowCellValue("Miktar", IdveMiktar.Miktar); // Bu AltBirim Aslında

                        }
                        catch (Exception hata)
                        {

                        }
                        finally
                        {

                        }
                    }
                    else
                        MessageBox.Show(this, "Ürün Bulunamadı");
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                txtBarkod.Text = string.Empty;
            }
        }

        private void memoEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        clsTablolar.csNumaraVer NumaraVer;
        clsTablolar.Ayarlar.csBarkodNuVer BarkodNuVer = new clsTablolar.Ayarlar.csBarkodNuVer();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                if (Siparis.SiparisID == -1)
                {

                    // sipariş numarası boşsa varsayilan numarayı ver
                    if (Siparis.SiparisNo == string.Empty)
                    {
                        TrGenel = Baglanti.BeginTransaction();
                        NumaraVer = new clsTablolar.csNumaraVer();
                        Siparis.SiparisNo = NumaraVer.VarsayilanNumaraVer_ve_Kaydet(Baglanti, TrGenel, clsTablolar.IslemTipi.AlinanSiparis);
                        TrGenel.Commit();
                    } // secilen numara şablonID -1 den farklı olması bir numara şablon u seçilmiş demektir o o numarasablonId ye göre numarayı yeniden ver
                    TrGenel = Baglanti.BeginTransaction();
                    Siparis.SiparisBarkodNu = BarkodNuVer.BarkodNuVerYeniNoyuKaydet(Baglanti, TrGenel, 3);
                    txtSiparisBarkodu.EditValue = Siparis.SiparisBarkodNu;
                    TrGenel.Commit();
                }
                if (Siparis.HizliSatistaDegisiklikYapmaIzniVarMi == false)
                {
                    MessageBox.Show("Değişiklik yapmaya izin yok");
                    return;
                }

                TrGenel = Baglanti.BeginTransaction();
                Siparis.SiparisKAydet(Baglanti, TrGenel);
                SiparisHareket.SiparisHareketleriniKaydet(Baglanti, TrGenel, Siparis.SiparisID);
                TrGenel.Commit();

                KayitTamamlandimi(true);
            }
            catch (Exception)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }
                throw;
            }

        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTeslimTarihiGir_Click(object sender, EventArgs e)
        {
            using (frmTarihSaat frm = new frmTarihSaat())
            {
                frm.dateNavigator1.DateTime = Convert.ToDateTime(txtTeslimTarihi.EditValue);
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    txtTeslimTarihi.EditValue = frm.dateNavigator1.DateTime;
                }
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            KayitTamamlandimi(true);
            Close();
        }

        private void btnSiparisTarihiGir_Click(object sender, EventArgs e)
        {

        }

        private void btnUrunCikart_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;

            // burada şimdilik karışık ürün kullanılmıyor.
            if ((int)gridView1.GetFocusedRowCellValue(colBirlesikUrunHareketID) != -2) // && !KarisikUrunFormuAcik)
            {
                MessageBox.Show(this, "Birlşik Ürün Silinemez");
                return;
            }

            try
            {


                if (DialogResult.Yes == MessageBox.Show(this, "Seçili ürünü silmek istediğinden emin misin hamısna", "Dikkat Hamısına", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    gridView1.DeleteSelectedRows();
                    hesapla.AltToplamlariHesapla();
                }
            }
            catch (Exception hata)
            {

            }
            finally
            {
            }
        }

        private void frmSiparis_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                txtBarkod.Focus();
                txtBarkod.SelectAll();
            }
            else if (txtBarkod.ContainsFocus == false)
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
        (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
        e.KeyCode == Keys.Decimal)
                {
                    txtBarkod.Focus();
                    txtBarkod.Select(txtBarkod.Text.Length, 0);
                    switch (e.KeyCode)
                    {
                        case Keys.NumPad0:
                            txtBarkod.Text = txtBarkod.Text + "0";
                            break;
                        case Keys.NumPad1:
                            txtBarkod.Text = txtBarkod.Text + "1";
                            break;
                        case Keys.NumPad2:
                            txtBarkod.Text = txtBarkod.Text + "2";
                            break;
                        case Keys.NumPad3:
                            txtBarkod.Text = txtBarkod.Text + "3";
                            break;
                        case Keys.NumPad4:
                            txtBarkod.Text = txtBarkod.Text + "4";
                            break;
                        case Keys.NumPad5:
                            txtBarkod.Text = txtBarkod.Text + "5";
                            break;
                        case Keys.NumPad6:
                            txtBarkod.Text = txtBarkod.Text + "6";
                            break;
                        case Keys.NumPad7:
                            txtBarkod.Text = txtBarkod.Text + "7";
                            break;
                        case Keys.NumPad8:
                            txtBarkod.Text = txtBarkod.Text + "8";
                            break;
                        case Keys.NumPad9:
                            txtBarkod.Text = txtBarkod.Text + "9";
                            break;
                        default:
                            txtBarkod.Text = txtBarkod.Text + Convert.ToChar((int)e.KeyValue).ToString();
                            break;
                    }
                    txtBarkod.Select(txtBarkod.Text.Length, 0);
                }
        }

        private void txtBarkod_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBarkodAra_Click(null, null);
        }

        private void txtSiparisTarihi_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void btnSiparisTarihiGir_Click_1(object sender, EventArgs e)
        {
            using (frmTarihSaat frm = new frmTarihSaat())
            {
                frm.dateNavigator1.DateTime = Convert.ToDateTime(txtSiparisTarihi.EditValue);
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    txtSiparisTarihi.EditValue = frm.dateNavigator1.DateTime;
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.UpdateCurrentRow();
            KayitTamamlandimi(false);
        }

        private void btnMiktarGir_Click(object sender, EventArgs e)
        {
            using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
            {
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    gridView1.SetFocusedRowCellValue(colAltBirimMiktar, frm.textEdit1.EditValue);
                }
            }
        }

        private void btnMusteriAdiSoyadi_Click(object sender, EventArgs e)
        {
            using (clsTablolar.TeraziSatisClaslari.frmYaziGirisi frm = new clsTablolar.TeraziSatisClaslari.frmYaziGirisi())
            {
                frm.labelControl1.Text = "Müşterinin Adını ve Soyadını yazın";
                frm.memoEdit1.EditValue = memoMusterininAdiSoyadi.EditValue;
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    memoMusterininAdiSoyadi.EditValue = frm.memoEdit1.EditValue;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!(lkpSiparisDurumu.IsPopupOpen))
                lkpSiparisDurumu.ShowPopup();
        }

        private void btnAciklama_Click(object sender, EventArgs e)
        {
            using (clsTablolar.TeraziSatisClaslari.frmYaziGirisi frm = new clsTablolar.TeraziSatisClaslari.frmYaziGirisi())
            {
                frm.labelControl1.Text = "Açıklama, Adres, Telefon Vb..";
                frm.memoEdit1.EditValue = memoAciklama.EditValue;
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    memoAciklama.EditValue = frm.memoEdit1.EditValue;
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                MessageBox.Show("Sipariş Kaydedilmedi \r\nKaydedin veya Vazgeçin");
            }
            else
            { Close(); }
        }

        private void lkpSiparisDurumu_EditValueChanged(object sender, EventArgs e)
        {
            KayitTamamlandimi(false);
        }

        private void btnIskontoUygula_Click(object sender, EventArgs e)
        {

        }

        private void barBtnButunUrunlereIskonto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //            if (gridView1.RowCount == 0)
            //                return;
            //            using (frmIndirim frm = new frmIndirim())
            //            {
            //                frm.lblStokBilgileri.Text = "Bütün ürünlere Indirim Uygula";

            //                //hesapla.
            //                decimal TumSatirlarinToplam_KdvDahilIndirimUygulanmamis = 0;
            //                decimal ToplamMiktar = 0;

            //                for (int i = 0; i < gridView1.RowCount; i++)
            //                {
            //                    TumSatirlarinToplam_KdvDahilIndirimUygulanmamis +=
            //(Convert.ToDecimal(gridView1.GetRowCellValue(i, colAnaBirimFiyat)) + (Convert.ToDecimal(gridView1.GetRowCellValue(i, colAnaBirimFiyat)) * Convert.ToDecimal(gridView1.GetRowCellValue(i, colKdv)) / 100)) * Convert.ToDecimal(gridView1.GetRowCellValue(i, colMiktar));

            //                    ToplamMiktar += Convert.ToDecimal(gridView1.GetRowCellValue(i, colMiktar));
            //                }
            //                frm.txtNormalFiyat.EditValue = TumSatirlarinToplam_KdvDahilIndirimUygulanmamis;

            //                if (DialogResult.Yes == frm.ShowDialog())
            //                {

            //                    decimal IndirimYuzdesi = ((100 * (TumSatirlarinToplam_KdvDahilIndirimUygulanmamis - Convert.ToDecimal(frm.txtIndirimliFiyat.EditValue))) / TumSatirlarinToplam_KdvDahilIndirimUygulanmamis);
            //                    for (int i = 0; i < gridView1.RowCount; i++)
            //                    {
            //                        gridView1.SetRowCellValue(i, colStokIskonto1, IndirimYuzdesi);
            //                    }
            //                }
            //            }
        }

        private void barBtnSeciliUruneIskonto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (gridView1.RowCount == 0)
            //    return;
            //using (frmIndirim frm = new frmIndirim())
            //{
            //    frm.lblStokBilgileri.Text = gridView1.GetFocusedRowCellValue(colSiparisHareketStokAdi).ToString() + " Birim Fiyatına Indirim Uygula";

            //    frm.txtNormalFiyat.EditValue = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colAltBirimKdvDahilFiyat));
            //    frm.txtIndirimYuzdesi.EditValue = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colStokIskonto1));
            //    if (DialogResult.Yes == frm.ShowDialog())
            //    {
            //        gridView1.SetFocusedRowCellValue(colStokIskonto1, Convert.ToDecimal(frm.txtIndirimYuzdesi.EditValue));
            //    }
            //}
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount == 0)
                    return;

                if (btnKaydet.Enabled == true)
                    btnKaydet_Click(null, null);

                using (clsTablolar.Yazdirma.csYazdir YazdirDetay = new clsTablolar.Yazdirma.csYazdir())
                {
                    YazdirDetay.dt_ekle("Siparis");

                    YazdirDetay.dtAlanEkleVeriEkle("Siparis", "SiparisBarkod", string.Empty, System.Type.GetType("System.String"));
                    YazdirDetay.dtAlanEkleVeriEkle("Siparis", "PersonelAdi", string.Empty, System.Type.GetType("System.String"));
                    YazdirDetay.dtAlanEkleVeriEkle("Siparis", "Aciklama", string.Empty, System.Type.GetType("System.String"));
                    YazdirDetay.dtAlanEkleVeriEkle("Siparis", "SiparisTarihi", DBNull.Value, System.Type.GetType("System.DateTime"));
                    YazdirDetay.dtAlanEkleVeriEkle("Siparis", "TeslimTarihi", DBNull.Value, System.Type.GetType("System.DateTime"));
                    YazdirDetay.dtAlanEkleVeriEkle("Siparis", "SiparisTutari", DBNull.Value, System.Type.GetType("System.Decimal"));
                    YazdirDetay.dtAlanEkleVeriEkle("Siparis", "MusteriAdi", DBNull.Value, System.Type.GetType("System.String"));

                    YazdirDetay.ds.Tables[0].Rows[0]["SiparisBarkod"] = txtSiparisBarkodu.Text;
                    YazdirDetay.ds.Tables[0].Rows[0]["SiparisTarihi"] = Siparis.SiparisTarihi;
                    YazdirDetay.ds.Tables[0].Rows[0]["SiparisTutari"] = Siparis.SiparisTutari;
                    YazdirDetay.ds.Tables[0].Rows[0]["TeslimTarihi"] = Siparis.TeslimTarihi;
                    YazdirDetay.ds.Tables[0].Rows[0]["Aciklama"] = Siparis.Aciklama;
                    YazdirDetay.ds.Tables[0].Rows[0]["PersonelAdi"] = Siparis.PersonelAdi;
                    YazdirDetay.ds.Tables[0].Rows[0]["MusteriAdi"] = Siparis.CariTanim;


                    YazdirDetay.dt_ekle("SiprisHareket");

                    YazdirDetay.dtAlanEkleVeriEkle("SiprisHareket", colToplam.FieldName, DBNull.Value, System.Type.GetType("System.Decimal"));
                    YazdirDetay.dtAlanEkleVeriEkle("SiprisHareket", colAltBirimKdvDahilFiyat.FieldName, DBNull.Value, System.Type.GetType("System.Decimal"));
                    YazdirDetay.dtAlanEkleVeriEkle("SiprisHareket", colAltBirimMiktar.FieldName, DBNull.Value, System.Type.GetType("System.Decimal"));
                    YazdirDetay.dtAlanEkleVeriEkle("SiprisHareket", colStokAltBirimAdi.FieldName, DBNull.Value, System.Type.GetType("System.String"));
                    YazdirDetay.dtAlanEkleVeriEkle("SiprisHareket", colSiparisHareketStokAdi.FieldName, DBNull.Value, System.Type.GetType("System.String"));
                    YazdirDetay.dtAlanEkleVeriEkle("SiprisHareket", colAltBirimKdvDahilFiyat.FieldName, DBNull.Value, System.Type.GetType("System.Decimal"));


                    this.BindingContext[gridControl1.DataSource].EndCurrentEdit();
                    //gvSatisHareketleri.UpdateCurrentRow();

                    foreach (var item in SiparisHareket.dt_SiparisHareketleri.Copy().AsEnumerable().Where(k => k.RowState != DataRowState.Deleted))
                    {
                        YazdirDetay.DtyaYeniSatirEkle("SiprisHareket");

                        int SonSatirIndex = YazdirDetay.ds.Tables["SiprisHareket"].Rows.Count - 1;

                        YazdirDetay.ds.Tables["SiprisHareket"].Rows[SonSatirIndex][colToplam.FieldName] = item[colToplam.FieldName];
                        YazdirDetay.ds.Tables["SiprisHareket"].Rows[SonSatirIndex][colAltBirimKdvDahilFiyat.FieldName] = item[colAltBirimKdvDahilFiyat.FieldName];
                        YazdirDetay.ds.Tables["SiprisHareket"].Rows[SonSatirIndex][colAltBirimMiktar.FieldName] = item[colAltBirimMiktar.FieldName];
                        YazdirDetay.ds.Tables["SiprisHareket"].Rows[SonSatirIndex][colStokAltBirimAdi.FieldName] = item[colStokAltBirimAdi.FieldName];
                        YazdirDetay.ds.Tables["SiprisHareket"].Rows[SonSatirIndex][colSiparisHareketStokAdi.FieldName] = item[colSiparisHareketStokAdi.FieldName];
                        YazdirDetay.ds.Tables["SiprisHareket"].Rows[SonSatirIndex][colAltBirimKdvDahilFiyat.FieldName] = item[colAltBirimKdvDahilFiyat.FieldName];
                    }
                    YazdirDetay.Yazdirr(Application.StartupPath + @"\Raporlar\Siparis.repx", clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata oldu Bildir");
                //HataDosyasiOlusturma("", hata);
            }
        }

        string FaturaBarkod = string.Empty;


        private void btnSatisaAktar_Click(object sender, EventArgs e)
        {
            try
            {
                TrGenel = Baglanti.BeginTransaction();
                FaturaBarkod = Siparis.SiparisiSatisaAktar(Baglanti, TrGenel, _SiparisID, SiparisiFaturalandiracakPersonel);
                TrGenel.Commit();
                if (FaturaBarkod != "")
                    SiparisiSatisaAktarma(FaturaBarkod);

                Close();
            }
            catch (Exception ex)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }
                MessageBox.Show(ex.Message);
            }
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnSiparisiSil_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("Önce Eklenen Ürünlerin Hepsini Silmen gerekir");
                return;
            }
            if (MessageBox.Show("Silmek İstediğine  Emin miisin ??", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            clsTablolar.EvrakIliski.csEvrakIliski Evraklari = new clsTablolar.EvrakIliski.csEvrakIliski();

            TrGenel = Baglanti.BeginTransaction();
            if (Evraklari.SiparisFaturayaAktarilmisMi(Baglanti, TrGenel, Siparis.SiparisID) == clsTablolar.EvrakIliski.csEvrakIliski.SiparisinFaturayaAktarilmaDurumu.Faturalandi)
            {
                TrGenel.Commit();
                if (DialogResult.No == MessageBox.Show("Bu Sipariş Satışa Aktarılmış Gene de Silmek ,istyor musun", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2))
                {
                    return;
                }
            }
            else
            { TrGenel.Commit(); }


            TrGenel = Baglanti.BeginTransaction();
            Siparis.SiparisSil(Baglanti, TrGenel, Siparis.SiparisID);
            TrGenel.Commit();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);

            if (frm.ShowDialog() == DialogResult.Yes)
            {
                //clsTablolar.cari.CariHr.csCariHr KApora = new clsTablolar.cari.CariHr.csCariHr();
                //KApora.Aciklama = "Kapora";
                //KApora.AlacakMiBorcMu = clsTablolar.cari.CariHr.HareketYonu.Alacak;
                //KApora.CariID = Siparis.CariID;
                //KApora.Devirmi = false;
                //KApora.Entegrasyon = clsTablolar.cari.CariHr.CariHrEntegrasyon.CariKartHareketi;
                //KApora.
                txtKaporaTutari.Text = frm.textEdit1.Text;
            }
        }

        private void chckbtnIskontoIslemleri_CheckedChanged(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                chckbtnIskontoIslemleri.Checked = false;
                return;
            }

            if (chckbtnIskontoIslemleri.Checked)
            {
                //Hesapla.AltToplamlariHesapla();
                colStokIskonto1.Visible = true;
                //colKdvDahilStokIskonto1IndirimMiktari.Visible = true;
                colAltBirimKdvDahilIndirimHaricFiyat.Visible = true;
                //splitContainerControl2.SplitterPosition = splitContainerControl2.Width;
                //pcontrol_IskontoAyrintilari.Visible = true;
                txtToplamTutar.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.PaleGreen;
                colAltBirimKdvDahilFiyat.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceCell.Options.HighPriority = true;
                colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = true;
            }
            else
            {
                colAltBirimKdvDahilIndirimHaricFiyat.Visible = false;
                //colKdvDahilStokIskonto1IndirimMiktari.Visible = false;
                //splitContainerControl2.SplitterPosition = 425;
                //pcontrol_IskontoAyrintilari.Visible = false;
                txtToplamTutar.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                colAltBirimKdvDahilFiyat.AppearanceCell.BackColor = System.Drawing.Color.White;
                colStokIskonto1.AppearanceCell.BackColor = System.Drawing.Color.White;
                colStokIskonto1.AppearanceCell.Options.HighPriority = false;
                colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = false;
            }
        }

        private void txtToplamTutar_EditValueChanged(object sender, EventArgs e)
        {
            if (chckbtnIskontoIslemleri.Checked)
            {

                try
                {
                    if (gridView1.RowCount == 0)
                        return;
                    //KaydedileBilirMi = false;
                    hesapla.ToplamFaturaTutariGirerekISkontoUygula(this);
                    //IndirimVarsaIskontoKolonunuGosterYoksaGosterme();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MesajGoster(ex.Message);
                }
                finally
                {

                }

            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (chckbtnIskontoIslemleri.Checked)
            {
                if (e.Column == colStokIskonto1)
                {
                    try
                    {

                        using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colStokIskonto1)), clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                        {
                            frm.labelControl1.Text = gridView1.GetFocusedRowCellValue(colSiparisHareketStokAdi).ToString() + "\nürüne yüzde indirim uygular";
                            if (frm.ShowDialog() == DialogResult.Yes)
                            {
                                decimal IndirimYuzdesi = Convert.ToDecimal(frm.textEdit1.EditValue);

                                gridView1.SetFocusedRowCellValue(colStokIskonto1, IndirimYuzdesi);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                    }
                }
                else if (e.Column == colAltBirimKdvDahilFiyat)
                {
                    try
                    {
                        using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colAltBirimKdvDahilFiyat)), clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
                        {
                            frm.labelControl1.Text = gridView1.GetFocusedRowCellValue(colSiparisHareketStokAdi).ToString() + "\nstokun olmasını istediğin fiyatını yaz";
                            if (frm.ShowDialog() == DialogResult.Yes)
                            {
                                decimal IndirimliFiyat = Convert.ToDecimal(frm.textEdit1.EditValue);
                                decimal AltBirimKdvDahilIndirimHaricFiyat = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colAltBirimKdvDahilIndirimHaricFiyat));
                                decimal IndirimYuzdesi = 100 * ((AltBirimKdvDahilIndirimHaricFiyat - IndirimliFiyat) / AltBirimKdvDahilIndirimHaricFiyat);
                                gridView1.SetFocusedRowCellValue(colStokIskonto1, IndirimYuzdesi);
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}
