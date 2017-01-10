using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;


namespace KasaSatis
{
    public partial class frmKasaOdeme : DevExpress.XtraEditors.XtraForm
    {
        public frmKasaOdeme()
        {
            InitializeComponent();
        }

        int SonOdemesiYapilanMusterinin_FaturaID = -1;

        clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama BarkodtanStokArma;
        private void btnAlisVerisiNakitOlarakKapat_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvOdemesiYapilacakSatis.RowCount == 0 || gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID") == DBNull.Value)
                {
                    MessageBox.Show("Satış yok veya seçili satışın daha tüm bilgileri gelmedi mk");
                    return;
                }
                //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                //OdemeKay.OdemeyiKaydet(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")));
                //TrGenel.Commit();
                gvOdemesiYapilacakSatis.SetFocusedRowCellValue("OdendiMi", true);
                SonOdemesiYapilanMusterinin_FaturaID = (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID"); // bu nerde kullanıyor hamısına

                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                csOdemeKaydet.OdemeDonenBilgisi donenOdemeBilgisi = OdemeKay.FaturaninBakiyesininKalaniniNakitTahsilEt(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")), Properties.Settings.Default.KasaID, "Fatura Nakit Ödeme", 0);

                TrGenel.Commit();

                if (csOdemeKaydet.OdemeDonenBilgisi.OncedenOdemesiTamamlanmis == donenOdemeBilgisi)
                {
                    MessageBox.Show("Ödemesi önceden tamamlanmış hamısına");
                }

                // bunu raşağıda yazdığın row style girdin diye yaptın.
                btnYenile_Click(null, null);
                gvOdemesiYapilacakSatis.RefreshRow(gvOdemesiYapilacakSatis.GetRowHandle(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()));



                //gvOdemesiYapilacakSatis_RowStyle
                //gvSatislar_FocusedRowChanged(null, null);
            }
            catch (Exception hata)
            {
                try { TrGenel.Rollback(); }
                catch (Exception) { }
                MessageBox.Show("Hata hamısına");
            }
        }
        csOdemeKaydet OdemeKay = new csOdemeKaydet();
        SqlTransaction TrGenel;

        public clsTablolar.Fatura.csFaturaHareket Hareketler = new clsTablolar.Fatura.csFaturaHareket();
        public clsTablolar.csFatura_Irsaliye_Teklif_Hesapla Hesapla;

        clsTablolar.TeraziSatisClaslari.csStok Stok = new clsTablolar.TeraziSatisClaslari.csStok();


        clsTablolar.TeraziSatisClaslari.csSatislarV2 Satislar;
        clsTablolar.cari.csCariv2 CariKart;

        public string FaturaBarkodIcinKullanilacakOnEk = string.Empty;

        clsTablolar.csNumaraVer NumaraVer = new clsTablolar.csNumaraVer();

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            SqlConnections conn = new SqlConnections();

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Satislar = new clsTablolar.TeraziSatisClaslari.csSatislarV2(SqlConnections.GetBaglanti(), TrGenel, -2); // -2 yazarak boş tablo getirmiş oluyoruz
            TrGenel.Commit();

            CariGetir(2); // Perakende satışta kullanılan carinin ID si daha sonra ayarlardan alması gerekiyor ID yi
            gcSatisHareketleri.DataSource = Hareketler.dt_FaturaHareketleri;
            try
            {
                //Satislar.ThreadiBaslat(SqlConnections.GetBaglantiIki(), 100);
            }
            catch (Exception) { }
            gcOdemesiYapilacakSatis.DataSource = Satislar.dt_threadSatislar;


            Hesapla = new clsTablolar.csFatura_Irsaliye_Teklif_Hesapla(Hareketler.dt_FaturaHareketleri, gvSatisHareketleri);
            Hesapla.AltToplamlarDegisti = AltToplamHesaplamalariniAl;
            dt_Odenecekler = Satislar.dt_threadSatislar.Clone();


            //txtFaturaTutari.DataBindings.Add("EditValue", gcSatislar.DataSource, "FaturaTutari");
            Satislar.dt_threadSatislar.RowDeleted += dt_threadSatislar_RowDeleted;

            //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            //Satislar.OdemesiAlinanSonKirkSatis(SqlConnections.GetBaglanti(), TrGenel);
            //TrGenel.Commit();

            gvOdemesiYapilacakSatis_FocusedRowChanged(null, null);
        }

        void dt_threadSatislar_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            gvOdemesiYapilacakSatis_FocusedRowChanged(null, null);
        }

        void CariGetir(int CariID)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            CariKart = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), TrGenel, CariID);
            //memoCariTanim.EditValue = CariKart.CariTanim;
            TrGenel.Commit();
        }

        private void gvOdemesiYapilacakSatis_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //lock (Satislar.KilitHamisina)
                {
                    if (gvOdemesiYapilacakSatis.RowCount == 0)//|| (int)gvSatislar.GetFocusedRowCellValue("FaturaID") == -1)
                    {
                        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                        Hareketler.FaturaHareketleriniGetir(SqlConnections.GetBaglanti(), TrGenel, -1);
                        TrGenel.Commit();
                    }
                    else
                    {
                        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                        Hareketler.FaturaHareketleriniGetir(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID"));
                        TrGenel.Commit();
                    }
                }
            }
            catch (Exception)
            {
                try { TrGenel.Rollback(); }
                catch (Exception) { }
            }
        }

        void AltToplamHesaplamalariniAl()
        {
            //lock (Satislar.KilitHamisina)
            {
                gvOdemesiYapilacakSatis.SetFocusedRowCellValue("Toplam_Iskontosuz_Kdvsiz", Hesapla.Toplam_Iskontosuz_Kdvsiz);
                gvOdemesiYapilacakSatis.SetFocusedRowCellValue("CariIskontoToplami", Hesapla.CariIskontoToplami);
                gvOdemesiYapilacakSatis.SetFocusedRowCellValue("StokIskontoToplami", Hesapla.StokIskontoToplami);
                gvOdemesiYapilacakSatis.SetFocusedRowCellValue("ToplamIndirim", Hesapla.ToplamIndirim);
                gvOdemesiYapilacakSatis.SetFocusedRowCellValue("ToplamKdv", Hesapla.ToplamKdv);
                gvOdemesiYapilacakSatis.SetFocusedRowCellValue("IskontoluToplam", Hesapla.IskontoluToplam);
                gvOdemesiYapilacakSatis.SetFocusedRowCellValue("FaturaTutari", Hesapla.FaturaTutari);

                //txtFaturaTutari.EditValue = Hesapla.FaturaTutari;

                //BindleHamisina();

                kaydet();
            }
        }

        void kaydet()
        {
            try
            {
                //lock (Satislar.KilitHamisina)
                {
                    bool YeniKayitMi = false;
                    if ((int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID") == -1) // yeni kayıtsa
                    {
                        //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                        //gvOdemesiYapilacakSatis.SetFocusedRowCellValue("FaturaNo", NumaraVer.NumaraVerveKaydet(5, SqlConnections.GetBaglanti(), TrGenel)); //TODO: Varsayılan numara diye bir alan oluştur ilerde hamısına; // bu nereden alıcak hamısına
                        //TrGenel.Commit();
                        YeniKayitMi = true;
                    }
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Satislar.SatisiKaydet(SqlConnections.GetBaglanti(), TrGenel, gvOdemesiYapilacakSatis.GetFocusedDataRow(), KasaSatis.Properties.Settings.Default.TeraziID);
                    TrGenel.Commit();
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Hareketler.FaturaHareketleriniKaydet(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID"));
                    TrGenel.Commit();
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Satislar.SatisinAltToplamHesaplamalariniServerdanHesaplaveKaydet(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID"));
                    // alt toplamları serverdan da hesaplattırarak aynı anda iki müşteriye bakıldığında bile fatura tutarının doğru olmasını sağladık
                    // Böylece aynı anda iki müşteriye bakarken fatura tutarı kasaya direk doğru olarak gidecek
                    TrGenel.Commit();
                    //if (YeniKayitMi && checkEdit1.Checked == true)
                    //    btnYazdir_Click(null, null);
                    //btnKaydet.Enabled = false;
                }
            }
            catch (Exception)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }

                MessageBox.Show("kayıtta hata");
                //btnYenile_Click(null, null);
            }
        }

        private void gvSatislar_RowCountChanged(object sender, EventArgs e)
        {
            //lblSatisHareketSayisi.Text = gvOdemesiYapilacakSatis.RowCount.ToString() + " adet satışın ödemesi tamamlanmadı.";
        }

        private void frmKasaOdeme_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            //Satislar.ThreadiKApat();
            Application.Exit();
            Application.ExitThread();
        }

        private void frmKasaOdeme_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnMusteriUrunAra_Click(object sender, EventArgs e)
        {
            if (txtBarkodu.EditValue.ToString().StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.FaturaBarkodIcinKullanilacakOnEk)) // okutunlan barkod fatura için olan bir barkodsa
            {
                try
                {
                    BarkodtanMusteriAra(txtBarkodu.Text);
                    if (ceBarkoduOkutulanFaturaninOdemesiniYap.Checked)
                        btnAlisVerisiNakitOlarakKapat_Click(null, null);
                }
                catch { }
                finally
                { txtBarkodu.EditValue = string.Empty; }
            }
            else //Müşteri barkodu değilse
                try
                {
                    if (OdemesiTamamlanmisMi(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()))
                    {
                        MessageBox.Show("Ödemesi Tamamlanan Satış Değiştilemez");
                        return;
                    }

                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    BarkodtanStokArma = new clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama();
                    clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama.StokIDMiktarBirim IdveMiktar = BarkodtanStokArma.StokBarkodundanStokIDVer(SqlConnections.GetBaglanti(), TrGenel, txtBarkodu.EditValue.ToString());
                    TrGenel.Commit();

                    if (IdveMiktar.StokID != -1)
                    {
                        StokEkle(IdveMiktar.StokID);



                        //if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colStokAnaBirimID) == 2 && IdveMiktar.Miktar ) // TODO : Ayarlardan alıcak
                        //{
                        //    Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["FireVarMi"] = 1;
                        //}
                        Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["KatSayi"] = IdveMiktar.Katsayi;
                        Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Birim2ID"] = IdveMiktar.AltBirimID;
                        gvSatisHareketleri.SetFocusedRowCellValue("Miktar", IdveMiktar.Miktar);
                    }
                    else
                    {
                        MessageBox.Show("Ürün Bulunamadı");
                    }

                }
                catch { }
                finally
                { txtBarkodu.EditValue = string.Empty; }
        }

        void BarkodtanMusteriAra(string BarkodNumarasi)
        {
            if (string.IsNullOrEmpty(BarkodNumarasi))
                return;
            Satislar.FaturaBarkodtanSatisiGetir(SqlConnections.GetBaglanti(), TrGenel, txtBarkodu.Text); // Bu yüklü olan varsa günceller yüklü olan yoksa yükler

            if (Satislar.dt_threadSatislar.Select("FaturaBarkod = '" + BarkodNumarasi + "'").Length > 0) // Bu tereaziye yüklü olan bir fatura var demekmtir sanırım
            {
                for (int i = 0; i < gvOdemesiYapilacakSatis.RowCount; i++)
                {
                    if (gvOdemesiYapilacakSatis.GetRowCellValue(i, "FaturaBarkod").ToString() == BarkodNumarasi)
                    {
                        gvOdemesiYapilacakSatis.FocusedRowHandle = i;
                        btnYenile_Click(null, null);
                        //Hesapla.AltToplamlariHesapla();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Böyle Bi müşteri yok hamısına");
            }
        }

        public void StokEkle(int StokID) // ama nereye ekliyecek mevcut müşteriye mi yeni müşteriye mi
        {
            //lock (Satislar.KilitHamisina)
            {// TODO : Aynı zamanda ödemesi yapılmaış satış yoksa da yeni yeni müşteri butonuna bas veya seçili satışa mı yeni müşteriye mi diye sorsun
                if (gvOdemesiYapilacakSatis.RowCount == 0) // hiç aktif satış yoksa yeni satış için yeni müşteri butonuna bas
                {
                    btnYeniMusteri_Click(null, null);
                }

                //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Stok.GetirHamisina(SqlConnections.GetBaglanti(), TrGenel, StokID);

                gcSatisHareketleri.DataSource = Hareketler.dt_FaturaHareketleri;

                Hareketler.dt_FaturaHareketleri.Rows.Add(Hareketler.dt_FaturaHareketleri.NewRow());


                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["FaturaID"] = gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID");
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["FaturaHareketStokAdi"] = Stok.StokAdi;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["StokID"] = Stok.StokID;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["StokAnaBirimAdi"] = Stok.StokAnaBirimAdi;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["AnaBirimFiyat"] = Stok.KdvHaricFiyat; // ana Birime Her zaman kdv hariç Fiyatı atıyoruz hamısına çünkü hesaplamaları öyle
                //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["KdvDahilFiyat"] = Stok.KdvDahilFiyat; // ana Birime Her zaman kdv hariç Fiyatı atıyoruz hamısına çünkü hesaplamaları öyle

                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Kdv"] = Stok.Kdv;

                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto1"] = 0;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto2"] = 0;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["StokIskonto3"] = 0;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto1"] = 0;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto2"] = 0;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["CariIskonto3"] = 0;

                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["StokAnaBirimID"] = Stok.AnaBirimID;

                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["KatSayi"] = 1;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Birim2ID"] = 1;
                //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = MiktarAl.OkunanSabitMiktar;
                //TerazidenSabitMiktariAl(MiktarAl.OkunanSabitMiktar);
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["FireMiktari"] = 0;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["FireVarMi"] = 0;
                //Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = 0;
                Hareketler.dt_FaturaHareketleri.Rows[Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["BirlesikUrunHareketID"] = -2; // -2 verildiği zaman ne birleşik ürün veya birleşik ürünün alt ürünleri değil manasına gelsin

                gvSatisHareketleri.SetFocusedRowCellValue("Miktar", 1);

                //TrGenel.Commit();
                //BindleHamisina();
            }
        }

        private void btnUrunBilgileri_Click(object sender, EventArgs e)
        {
            clsTablolar.frmStokBilgileri frm = new clsTablolar.frmStokBilgileri(SqlConnections.GetBaglanti());
            frm.ShowDialog();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {

        }

        private void btnAktifSatisaDigerSatisinHareketleriniEkle_Click(object sender, EventArgs e)
        {
            //lock (Satislar.KilitHamisina)
            {
                //satislaribirlestir(gvSatislar.GetFocusedRowCellValue(colFaturaBarkod).ToString());
            }
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            Satislar.YeniKayitAc(CariKart);
            gvOdemesiYapilacakSatis.MoveLast();
        }

        private void frmKasaOdeme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                txtBarkodu.Focus();
                txtBarkodu.SelectAll();
            }
            else if (txtBarkodu.ContainsFocus == false)
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
        (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
        e.KeyCode == Keys.Decimal)
                {
                    txtBarkodu.Focus();
                    txtBarkodu.Select(txtBarkodu.Text.Length, 0);
                    switch (e.KeyCode)
                    {
                        case Keys.NumPad0:
                            txtBarkodu.Text = txtBarkodu.Text + "0";
                            break;
                        case Keys.NumPad1:
                            txtBarkodu.Text = txtBarkodu.Text + "1";
                            break;
                        case Keys.NumPad2:
                            txtBarkodu.Text = txtBarkodu.Text + "2";
                            break;
                        case Keys.NumPad3:
                            txtBarkodu.Text = txtBarkodu.Text + "3";
                            break;
                        case Keys.NumPad4:
                            txtBarkodu.Text = txtBarkodu.Text + "4";
                            break;
                        case Keys.NumPad5:
                            txtBarkodu.Text = txtBarkodu.Text + "5";
                            break;
                        case Keys.NumPad6:
                            txtBarkodu.Text = txtBarkodu.Text + "6";
                            break;
                        case Keys.NumPad7:
                            txtBarkodu.Text = txtBarkodu.Text + "7";
                            break;
                        case Keys.NumPad8:
                            txtBarkodu.Text = txtBarkodu.Text + "8";
                            break;
                        case Keys.NumPad9:
                            txtBarkodu.Text = txtBarkodu.Text + "9";
                            break;
                        default:
                            txtBarkodu.Text = txtBarkodu.Text + Convert.ToChar((int)e.KeyValue).ToString();
                            break;
                    }
                    txtBarkodu.Select(txtBarkodu.Text.Length, 0);
                }
        }

        private void txtBarkodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMusteriUrunAra_Click(null, null);
            }
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            gvOdemesiYapilacakSatis.MoveNextPage();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            //gvSatislar.MovePrevPage();
        }

        private void gvSatisHareketleri_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //btnKaydet.Enabled = true;
            gvSatisHareketleri.UpdateCurrentRow();
            gvSatislar_CellValueChanged(null, null);
        }

        private void gvSatislar_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                gvOdemesiYapilacakSatis.UpdateCurrentRow();
            }
            catch (Exception) { }
        }

        private void btnUrunCikar_Click(object sender, EventArgs e)
        {
            try
            {
                //lock (Satislar.KilitHamisina)
                {
                    if (OdemesiTamamlanmisMi(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()))
                    {
                        MessageBox.Show("Ödemesi Tamamlanan Satış Değiştilemez");
                        return;
                    }
                    if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colBirlesikUrunHareketID) != -2)
                    {
                        MessageBox.Show("Birlşik Ürün Silinemez");
                        return;
                    }

                    if (DialogResult.Yes == MessageBox.Show("Seçili ürünü silmek istediğinden emin misin hamısna", "Dikkat Hamısına", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                    {
                        gvSatisHareketleri.DeleteSelectedRows();
                        Hesapla.AltToplamlariHesapla();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void satislaribirlestir(string barkodNumarasi1)
        {
            using (clsTablolar.TeraziSatisClaslari.frmSatislariBirlestir frm = new clsTablolar.TeraziSatisClaslari.frmSatislariBirlestir(SqlConnections.GetBaglanti(), barkodNumarasi1))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    txtBarkodu.Text = frm.BirlestirilenBarkod;
                    btnMusteriUrunAra_Click(null, null);
                    Hesapla.AltToplamlariHesapla();
                }
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {// sadece seçili satışı yeniler
            //lock (Satislar.KilitHamisina)
            if (gvOdemesiYapilacakSatis.RowCount == 0)
                return;
            {
                gvOdemesiYapilacakSatis_FocusedRowChanged(null, null);
                //gvSatisHareketleri_CellValueChanged(null, null);
                //Satislar.FaturaIDdenFaturayiYenile(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaID));
                Satislar.FaturaBarkodtanSatisiGetir(SqlConnections.GetBaglanti(), TrGenel, gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaBarkod").ToString());
                gvOdemesiYapilacakSatis.RefreshRow(gvOdemesiYapilacakSatis.FocusedRowHandle);
                //Hesapla.AltToplamlariHesapla();
            }
        }

        private void btnOdemeIptal_Click(object sender, EventArgs e)
        {
            if (gvOdemesiYapilacakSatis.RowCount == 0)
            {
                return;
            }
            try
            {
                //lock (Satislar.KilitHamisina)
                {
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    //string barkodNo = Satislar.OdemesiYapilanSatisiGeriGetir(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaID));
                    Satislar.OdemesiYapilanSatisiGeriGetir(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaID));
                    TrGenel.Commit();
                    //BarkodtanMusteriAra(barkodNo);
                    btnYenile_Click(null, null);
                    SonOdemesiYapilanMusterinin_FaturaID = -1;
                }
            }
            catch (Exception)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }
            }
        }

        DataTable dt_Odenecekler;


        private void btnMiktarGir_Click(object sender, EventArgs e)
        {
            //lock (Satislar.KilitHamisina)
            {
                if (OdemesiTamamlanmisMi(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()))
                {
                    MessageBox.Show("Ödemesi Tamamlanan Satış Değiştilemez");
                    return;
                }
                if (gvSatisHareketleri.RowCount == 0)
                {
                    MessageBox.Show("Ürün yok");
                    return;
                }
                //if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colStokAnaBirimID) == 2)
                //{
                //    MessageBox.Show("Teraziden Tartılan ürünün miktarı değiştirilemez");
                //    return;
                //}
                if ((gvSatisHareketleri.GetFocusedRowCellValue(colBirlesikUrunHareketID).ToString() != "-2") && (int)gvSatisHareketleri.GetFocusedRowCellValue(colStokAnaBirimID) != 2)
                {// Birleşik ürün veya birleşik ürünün alt ürün olmayacak ve ürün kg olacak
                    MessageBox.Show("Bu ürünün Miktarı Değiştirilemez");
                    return;
                }
                clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);
                frm.labelControl1.Text = "Seçili Ürün İçin Miktar Girin";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    gvSatisHareketleri.SetFocusedRowCellValue(colMiktar, Convert.ToDecimal(frm.textEdit1.EditValue));
                }
            }
        }

        private bool OdemesiTamamlanmisMi(int datasourceRowIndex)
        {
            int RowHandlee = gvOdemesiYapilacakSatis.GetRowHandle(datasourceRowIndex);
            if (Math.Round((decimal)gvOdemesiYapilacakSatis.GetRowCellValue(RowHandlee, colOdenenTutar), 2) == Math.Round((decimal)gvOdemesiYapilacakSatis.GetRowCellValue(RowHandlee, "FaturaTutari"), 2) && Math.Round((decimal)gvOdemesiYapilacakSatis.GetRowCellValue(RowHandlee, "FaturaTutari"), 2) != 0)
            {
                return true;
            }
            else
            { return false; }

        }

        private void btnSeciliUrununMiktariniBirArttir_Click(object sender, EventArgs e)
        {
            //lock (Satislar.KilitHamisina)
            try
            {
                //if ((bool)gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colOdendiMi))
                if (OdemesiTamamlanmisMi(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()))
                {
                    MessageBox.Show("Ödemesi Tamamlanan Satış Değiştilemez");
                    return;
                }
                if (gvSatisHareketleri.RowCount == 0)
                {
                    MessageBox.Show("Ürün yok");
                    return;
                }
                if ((int)gvSatisHareketleri.GetFocusedRowCellValue(colBirim2ID) == 2)
                {
                    MessageBox.Show("Teraziden Tartılan ürünün miktarı bir arttırılamaz");
                    return;
                }
                if ((gvSatisHareketleri.GetFocusedRowCellValue(colBirlesikUrunHareketID).ToString() != "-2") && (int)gvSatisHareketleri.GetFocusedRowCellValue(colBirim2ID) != 2)
                {// Birleşik ürün veya birleşik ürünün alt ürün olmayacak ve ürün kg olacak
                    MessageBox.Show("Bu ürünün Miktarı Değiştirilemez");
                    return;
                }
                gvSatisHareketleri.SetFocusedRowCellValue(colAltBirimMiktar, (decimal)gvSatisHareketleri.GetFocusedRowCellValue(colAltBirimMiktar) + 1);
            }
            catch (Exception exx)
            {


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void gcOdemesiYapilacakSatis_Click(object sender, EventArgs e)
        {

        }

        private void gvOdemesiYapilacakSatis_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "OdendiMi")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    //e.

                }
            }
        }

        private void gvOdemesiYapilacakSatis_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle >= 0)
            {
                decimal KalanBakiye = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["KalanBakiye"]));
                decimal OdenenTutar = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["OdenenTutar"]));
                decimal FaturaTutari = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["FaturaTutari"]));
                //if ((bool)View.GetRowCellValue(e.RowHandle, View.Columns["OdendiMi"]))
                if (OdenenTutar == 0)
                {

                }
                else if (OdenenTutar == FaturaTutari)
                {
                    e.HighPriority = true;
                    //e.Appearance.BackColor = System.Drawing.Color.PeachPuff;
                    //e.Appearance.BackColor = System.Drawing.Color.White;
                    e.Appearance.ForeColor = System.Drawing.Color.Red;
                    e.Appearance.Options.UseBackColor = false;
                }
                else if (OdenenTutar < FaturaTutari)
                {
                    e.HighPriority = true;
                    //e.Appearance.BackColor = System.Drawing.Color.PeachPuff;
                    //e.Appearance.BackColor = System.Drawing.Color.White;
                    e.Appearance.ForeColor = System.Drawing.Color.Blue;
                    e.Appearance.Options.UseBackColor = false;
                }
            }
            //e.Appearance.Options.UseBackColor = true;
            //e.Appearance.Options.UseForeColor = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gvOdemesiYapilacakSatis.RowCount == 0)
            {
                btnYeniMusteri_Click(null, null);
            }
            if (OdemesiTamamlanmisMi(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()))
            {
                MessageBox.Show("Ödemesi Tamamlanan Satış Değiştilemez");
                return;
            }
            using (frmButonUrunler frm = new frmButonUrunler(Properties.Settings.Default.TeraziID))
            {
                if (DialogResult.Yes == frm.ShowDialog(this))
                {
                    StokEkle(frm.GeriDonenStokID);
                }
            }
        }

        private void gcSatisHareketleri_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBarkodu_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ceBarkoduOkutulanFaturaninOdemesiniYap_CheckedChanged(object sender, EventArgs e)
        {

        }
        clsTablolar.TeraziSatisClaslari.frmSatislar frmSatislar;

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmSatislar = new clsTablolar.TeraziSatisClaslari.frmSatislar(SqlConnections.GetBaglanti()))
                {
                    //formState.Maximize(frmSatislar);
                    frmSatislar.WindowState = FormWindowState.Maximized;
                    if (frmSatislar.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
                    {
                        txtBarkodu.Text = frmSatislar.FaturaBarkod;
                        btnMusteriUrunAra_Click(null, null);
                    }
                }
            }
            catch (Exception hata)
            {
                //HataDosyasiOlusturma("", hata);
                //Mesagg("btnMusteriler_Click burada hata oldu");
            }
            finally
            {
                //if (Satislarv2.th1.ThreadState != ThreadState.Running)
                //    Satislarv2.ThreadiBaslat(SqlConnections.GetBaglantiIki());
            }
        }

        private void btnMusteriUrunAra_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void gvOdemesiYapilacakSatis_RowCountChanged(object sender, EventArgs e)
        {
            if (gvOdemesiYapilacakSatis.RowCount > 40)
            {
                gvOdemesiYapilacakSatis.DeleteRow(0);
            }
        }

        private void labelControl3_Click_1(object sender, EventArgs e)
        {

        }

        private void chckbtnIskontoIslemleri_CheckedChanged(object sender, EventArgs e)
        {
            if (gvSatisHareketleri.RowCount == 0)
            {
                chckbtnIskontoIslemleri.Checked = false;
                return;
            }

            if (chckbtnIskontoIslemleri.Checked)
            {
                //Hesapla.AltToplamlariHesapla();
                colStokIskonto1.Visible = true;
                colKdvDahilStokIskonto1IndirimMiktari.Visible = true;
                colAltBirimKdvDahilIndirimHaricFiyat.Visible = true;
                //splitContainerControl2.SplitterPosition = splitContainerControl2.Width;
                //pcontrol_IskontoAyrintilari.Visible = true;
                //txtFaturaTutari.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.PaleGreen;
                colAltBirimKdvDahilFiyat.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
                colStokIskonto1.AppearanceCell.Options.HighPriority = true;
                colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = true;
            }
            else
            {
                colAltBirimKdvDahilIndirimHaricFiyat.Visible = false;
                colKdvDahilStokIskonto1IndirimMiktari.Visible = false;
                //splitContainerControl2.SplitterPosition = 425;
                //pcontrol_IskontoAyrintilari.Visible = false;
                //txtFaturaTutari.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
                colAltBirimKdvDahilFiyat.AppearanceCell.BackColor = System.Drawing.Color.White;
                colStokIskonto1.AppearanceCell.BackColor = System.Drawing.Color.White;
                colStokIskonto1.AppearanceCell.Options.HighPriority = false;
                colAltBirimKdvDahilFiyat.AppearanceCell.Options.HighPriority = false;
            }
        }

        private void btnSatisiSil_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < gvOdemesiYapilacakSatis.RowCount; i++)
            {
                //gvOdemesiYapilacakSatis.GetFocusedDataRow
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvSatisHareketleri.RowCount != 0)
            {
                MessageBox.Show("satışın hareketleri varken satış silinemez");
                return;
            }
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Satislar.SatisiSil(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaID));
                TrGenel.Commit();
                btnYenile_Click(null, null);
                gvOdemesiYapilacakSatis.DeleteSelectedRows();
            }
            catch (Exception hata)
            {
                try { TrGenel.Rollback(); }
                catch (Exception) { }
                MessageBox.Show("Satış Silmede Hata Bunu bildir");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gvOdemesiYapilacakSatis.RowCount == 0 || gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID") == DBNull.Value)
            {
                MessageBox.Show("Satış yok veya seçili satışın daha tüm bilgileri gelmedi mk");
                return;
            }
            //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            //OdemeKay.OdemeyiKaydet(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")));
            //TrGenel.Commit();
            //gvOdemesiYapilacakSatis.SetFocusedRowCellValue("OdendiMi", true);
            SonOdemesiYapilanMusterinin_FaturaID = (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID"); // bu nerde kullanıyor hamısına

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            OdemeKay.FaturaninBakiyesininKalaniniNakitTahsilEt(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")), 3, "Fatura Kredi KArtı İle ödeme", 0); // KAsaID 3 pos cihazı için verilen ID
            TrGenel.Commit();

            // bunu raşağıda yazdığın row style girdin diye yaptın.
            btnYenile_Click(null, null);
            gvOdemesiYapilacakSatis.RefreshRow(gvOdemesiYapilacakSatis.GetRowHandle(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()));
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gvOdemesiYapilacakSatis.RowCount == 0 || gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID") == DBNull.Value)
            {
                MessageBox.Show("Satış yok veya seçili satışın daha tüm bilgileri gelmedi mk");
                return;
            }

            frmKismiOdeme frm = new frmKismiOdeme();
            if (DialogResult.Yes == frm.ShowDialog())
            {
                SonOdemesiYapilanMusterinin_FaturaID = (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID"); // bu nerde kullanıyor hamısına

                int KismiOdemeKasaID = frm.KismiOdemesiYapilanKasaID;
                decimal KismiOdemeTutari = frm.Tutar;
                string KismiODemeAciklama = frm.Aciklama;

                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                OdemeKay.FaturaninBakiyesininKalaniniNakitTahsilEt(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")), KismiOdemeKasaID, KismiODemeAciklama, KismiOdemeTutari);
                TrGenel.Commit();

                // bunu raşağıda yazdığın row style girdin diye yaptın.
                btnYenile_Click(null, null);
                gvOdemesiYapilacakSatis.RefreshRow(gvOdemesiYapilacakSatis.GetRowHandle(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()));
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}

