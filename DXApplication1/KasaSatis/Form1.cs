using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using Tremol;

namespace KasaSatis
{
    public partial class frmKasaOdeme : DevExpress.XtraEditors.XtraForm
    {
        public frmKasaOdeme()
        {
            InitializeComponent();
        }

        //int SonOdemesiYapilanMusterinin_FaturaID = -1;

        clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama BarkodtanStokArma;

        enum OkcEntegrasyonTipi
        {
            TamEntegrasyon = 1, // Tam entegrasyon işte, Fiş çıkmadan satıl yapılamaz
            EntegrasyonYok = 2, // Kasadan Fiş çıkmıyor
            YariEntegrasyon = 3 // Isteğe bağlı olarak fiş çıkar
        }




        OkcEntegrasyonTipi OKCEntegrasyonu;

        csMikroSarayOKC MikroSarayOKC = new csMikroSarayOKC();

        private void btnAlisVerisiNakitOlarakKapat_Click(object sender, EventArgs e)
        {
            try
            {
                if (OKCEntegrasyonu != OkcEntegrasyonTipi.EntegrasyonYok && MikroSarayOKC.BaglantiVarMi != csMikroSarayOKC.BaglantiDurumu.Var)
                {
                    MessageBox.Show("OKC baglantısı daha tamamlanmadı biraz bekleyin");
                    return;
                }

                if (gvOdemesiYapilacakSatis.RowCount == 0 || gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID") == DBNull.Value || (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID") == -1)
                {
                    MessageBox.Show("Satış yok veya seçili satışın daha tüm bilgileri gelmedi mk");
                    return;
                }

                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                csOdemeKaydet.OdemeDonenBilgisi donenOdemeBilgisi = OdemeKay.FaturaninBakiyesininKalaniniNakitTahsilEt(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")), Properties.Settings.Default.KasaID, "Fatura Nakit Ödeme", 0, _PersonelID);

                TrGenel.Commit();

                if (csOdemeKaydet.OdemeDonenBilgisi.OncedenOdemesiTamamlanmis == donenOdemeBilgisi)
                {
                    MessageBox.Show("Ödemesi önceden tamamlanmış hamısına");
                    //TODO: buraya bir kontrol daha eklenip ödemesi tamamlanmış ama fiş yazdırılmamışsa fiş yazdırması için sor istenirse fiş yazdırsın. yazdırmışsa da aynı fişi tekrar yazdırsın ama sanırım sadece son fişi tekrar yazdırabiliyor.
                }
                else if (donenOdemeBilgisi == csOdemeKaydet.OdemeDonenBilgisi.OdemesiTamamlandi && OKCEntegrasyonu == OkcEntegrasyonTipi.TamEntegrasyon)
                {
                    UrunleriGecir();
                    MikroSarayOKC.OKCFisiNakitKapat(Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")));


                    //ZnoVeFisNoyuFaturayaKaydet(Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")), (int)MikroSarayOKC.z_num, (int)MikroSarayOKC.rcp_num);
                    //MessageBox.Show("z numarası " + (int)MikroSarayOKC.z_num + "\rn Fiş numarası " + (int)MikroSarayOKC.rcp_num);
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
        clsTablolar.TeraziSatisClaslari.csPersonel Personel = new clsTablolar.TeraziSatisClaslari.csPersonel();


        clsTablolar.TeraziSatisClaslari.csSatislarV2 Satislar;
        clsTablolar.cari.csCariv2 CariKart;

        public string FaturaBarkodIcinKullanilacakOnEk = string.Empty;

        clsTablolar.csNumaraVer NumaraVer = new clsTablolar.csNumaraVer();

        int _PersonelID = -1;

        void Baglanti(csMikroSarayOKC.BaglantiDurumu Baglanti)
        {
            switch (Baglanti)
            {
                case csMikroSarayOKC.BaglantiDurumu.Var:
                    listBoxControl1.Items.Add("Baglanti Kuruldu");
                    break;
                case csMikroSarayOKC.BaglantiDurumu.yok:
                    listBoxControl1.Items.Add("Baglanti Kuruluyor.");
                    break;
                case csMikroSarayOKC.BaglantiDurumu.BaglantiKayboldu:
                    listBoxControl1.Items.Add("BaglantiKoptu");
                    break;
                default:
                    break;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            OKCEntegrasyonu = OkcEntegrasyonTipi.EntegrasyonYok;

            if (OKCEntegrasyonu != OkcEntegrasyonTipi.EntegrasyonYok) // yani entegrasyon bir şekilde varsa
            {
                MikroSarayOKC.BaglantDurumu = Baglanti;
                MikroSarayOKC.BaglantiKur();
            }
            else if (OKCEntegrasyonu == OkcEntegrasyonTipi.EntegrasyonYok) // yani entegrasyon yoksa
            {
                barSubItem_OKCMEnu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }



            //CheckForIllegalCrossThreadCalls = false;
            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

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

            // bu kullanılmıyor sanırım artık
            //dt_Odenecekler = Satislar.dt_threadSatislar.Clone();


            //txtFaturaTutari.DataBindings.Add("EditValue", gcSatislar.DataSource, "FaturaTutari");
            Satislar.dt_threadSatislar.RowDeleted += dt_threadSatislar_RowDeleted;

            BirimleriGetir();
            repositoryItemLookUpEdit_AltBirim.DataSource = dtBirimler;
            repositoryItemLookUpEdit_AltBirim.DisplayMember = "BirimAdi";
            repositoryItemLookUpEdit_AltBirim.ValueMember = "BirimID";

            //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            //Satislar.OdemesiAlinanSonKirkSatis(SqlConnections.GetBaglanti(), TrGenel);
            //TrGenel.Commit();

            gvOdemesiYapilacakSatis_FocusedRowChanged(null, null);


            while (true)
            {
                using (clsTablolar.frmMiktarGir frmm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.TamSayi))
                {
                    frmm.labelControl1.Text = "Personel Kartını Okutun";
                    if (frmm.ShowDialog() == DialogResult.Yes)
                    {
                        txtBarkodu.EditValue = frmm.textEdit1.EditValue;
                        btnMusteriUrunAra_Click(null, null);
                        if (_PersonelID != -1)
                            break;
                        else
                            MessageBox.Show("Hatalı Personel Kartı");
                    }
                }
            }
            YazdirmaIslemiIcinHazirlik();
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

                // ahanda en son bunu kapattın
                kaydet(); // bu çok önemli ama neden?? lan başka bir yerden kayıt yapılmıyor
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
                    gvOdemesiYapilacakSatis.RefreshData();

                    //if (YeniKayitMi && checkEdit1.Checked == true)
                    //    btnYazdir_Click(null, null);
                    //btnKaydet.Enabled = false;
                }
            }
            catch (Exception ex)
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
            try
            {
                ThOkcISlemleri.Abort();
            }
            catch (Exception)
            {
            }
        }

        private void btnMusteriUrunAra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarkodu.Text)) // barkoda bişi yazılı değilse yazması için düğmeleri çıkar
            {
                clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Yazi);
                if (DialogResult.Yes == frm.ShowDialog() && !string.IsNullOrEmpty(frm.textEdit1.Text)) //textboxın doluluk uğunu sorgulamazsam sonsuz döngüye girer
                {
                    txtBarkodu.Text = frm.textEdit1.Text;
                    btnMusteriUrunAra_Click(null, null);
                }
                return;
            }
            if (txtBarkodu.EditValue.ToString().StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.FaturaBarkodIcinKullanilacakOnEk)) // okutunlan barkod fatura için olan bir barkodsa
            {
                try
                {
                    BarkodtanMusteriAra(txtBarkodu.Text);
                    if (ceBarkoduOkutulanFaturaninOdemesiniYap.Checked)
                        btnAlisVerisiNakitOlarakKapat_Click(null, null);
                }
                catch
                {
                }
                finally
                { txtBarkodu.EditValue = string.Empty; }
            }
            else if (txtBarkodu.EditValue.ToString().StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.SiparisBarkodNumarasiOnEki)) // bu sipariş için sanırım
            {
                //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                {
                    using (clsTablolar.Siparis.csBarkodtanSiparisIDGetir barkodtanGetir = new clsTablolar.Siparis.csBarkodtanSiparisIDGetir())
                    {
                        clsTablolar.Siparis.csBarkodtanSiparisIDGetir.SiparisOdeme SipBilgisi = barkodtanGetir.BarkodtaSiparisIDGetir(SqlConnections.GetBaglanti(), TrGenel, txtBarkodu.Text);

                        if (SipBilgisi.SipariID != -1) // Sipariş Varsa
                        {
                            if (SipBilgisi.FaturaID != -1) // Sipariş Faturaya Aktarılmışsa (sipariş Satışa aktarılmışsa)
                            {
                                //if (SipBilgisi.OdemesiTamamlandiMi == false) // Siparişin Faturaya Aktarılmış ve ödemesi tamamlanmamışsa
                                {
                                    txtBarkodu.EditValue = SipBilgisi.FaturaBarkod;
                                    btnMusteriUrunAra_Click(null, null);
                                    return;
                                }
                                //else
                                //{ MesajGoster("Bu sipariş Satışa aktarılmış ve ödemesi tamamlanmış!"); }
                            }
                            else // faturaya aktarılmamışsa
                            {
                                using (clsTablolar.TeraziSatisClaslari.frmSiparis sip = new clsTablolar.TeraziSatisClaslari.frmSiparis(SipBilgisi.SipariID, SqlConnections.GetBaglanti(), KasaSatis.Properties.Settings.Default.TeraziID, -1, YaziciAdi1))
                                {
                                    sip.SiparisiSatisaAktarma = SiparisiSatisaAktarma;
                                    sip.ShowDialog();
                                    return;
                                }
                            }
                        }
                        else  // faturaID gelirse fatura aktarılmıştır.
                        {
                            MessageBox.Show("Sipariş Yok");
                        }
                    }
                }
            }
            else if (txtBarkodu.EditValue.ToString().StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.PersonelBarkodNumarasiOnEki)) // girinlen numara personel numarası ise
            {
                try
                {
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Personel.BardoktanPersonelGetir(SqlConnections.GetBaglanti(), TrGenel, txtBarkodu.EditValue.ToString());
                    TrGenel.Commit();
                    if (Personel.PersonelID == -1)
                    {
                        MessageBox.Show("Yok hamısına");
                    }
                    else
                    {
                        lblKasiyer.Text = Personel.PersonelAdi;
                        _PersonelID = Personel.PersonelID;
                    }
                }
                catch (Exception) { }
                finally
                { txtBarkodu.EditValue = string.Empty; }
            }
            else
                try
                {
                    if (gvOdemesiYapilacakSatis.RowCount != 0 && OdemesiTamamlanmisMi(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()))
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
                if (OKCEntegrasyonu == OkcEntegrasyonTipi.TamEntegrasyon && FisiOkuturOkutmazYazdirmayaBasla)
                {
                    UrunleriGecir();
                }

            }
            else
            {
                MessageBox.Show("Böyle Bi müşteri yok hamısına");
            }
        }


        DataTable dtBirimler;
        public void BirimleriGetir()
        {

            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                clsTablolar.Stok.csStokBirimTanimlari BirimTanimlari = new clsTablolar.Stok.csStokBirimTanimlari();
                BirimTanimlari.BirimDoldur(SqlConnections.GetBaglanti(), TrGenel);
                dtBirimler = BirimTanimlari.dt;
                TrGenel.Commit();
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

        void SiparisiSatisaAktarma(string FaturaBarkod)// burada yanlış tanımlamışsın siparişi aktarma diye birşey değil bu. Zaten satışa aktarılmış bir siparişin barkodu okutulursa oradan fatura barkodunu buluyor
        {
            try
            {
                txtBarkodu.Text = FaturaBarkod;
                btnMusteriUrunAra_Click(null, null);

                //gvSatislar.MoveLast();
                //gvSatislar.FocusedRowHandle = gvSatislar.RowCount - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Hesapla.AltToplamlariHesapla();
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

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (gvOdemesiYapilacakSatis.RowCount == 0)
            {
                return;
            }

            FisBilgleri.Barkod = gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaBarkod).ToString();
            FisBilgleri.Tarih = Convert.ToDateTime(gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaTarihi));
            FisBilgleri.Tutar = Convert.ToDecimal(gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaTutari));
            FisBilgleri.YaziciAdi = YaziciAdi1;
            //th_Yazdir = new Thread(new ParameterizedThreadStart(YazdirThreadi));

            //th_Yazdir.Start(FisBilgleri);

            YazdirThreadi(FisBilgleri);
        }

        #region Yazdırma İşlemleri
        clsTablolar.Yazdirma.csYazdir yazdirrr = new clsTablolar.Yazdirma.csYazdir();
        //DataTable dt_yazdirma = new DataTable();

        string YaziciAdi1 = string.Empty;

        void YazdirmaIslemiIcinHazirlik()
        {
            yazdirrr.dt_ekle("Fatura");
            yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaBarkod", string.Empty, System.Type.GetType("System.String"));
            yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaTarihi", DBNull.Value, System.Type.GetType("System.DateTime"));
            yazdirrr.dtAlanEkleVeriEkle("Fatura", "FaturaTutari", DBNull.Value, System.Type.GetType("System.Decimal"));

            YaziciAdi1 = KasaSatis.Properties.Settings.Default.VarsayilanYaziciAdi;


            FisBilgleri = new csMusteriFisBilgileri();

            //MusteriFisi = new DevExpress.XtraReports.UI.XtraReport();
            //MusteriFisi.LoadLayout(Application.StartupPath + @"\Raporlar\MusteriNumarasi.repx");

            yazdirrr.DosyayaiArabellegeAl(Application.StartupPath + @"\Raporlar\MusteriNumarasi.repx");
        }
        //DevExpress.XtraReports.UI.XtraReport MusteriFisi;
        csMusteriFisBilgileri FisBilgleri;

        public class csMusteriFisBilgileri
        {
            public string Barkod { get; set; }
            public DateTime Tarih { get; set; }
            public decimal Tutar { get; set; }
            public string YaziciAdi { get; set; }
            csMusteriFisBilgileri(string _Barkod, DateTime _Tarih, decimal _Tutar)
            {
                Barkod = _Barkod;
                Tarih = _Tarih;
                Tutar = _Tutar;
            }
            public csMusteriFisBilgileri()
            { }
        }


        public void YazdirThreadi(object FisBilgileri)
        {
            {
                yazdirrr.ds.Tables[0].Rows[0]["FaturaBarkod"] = ((csMusteriFisBilgileri)FisBilgileri).Barkod;
                yazdirrr.ds.Tables[0].Rows[0]["FaturaTarihi"] = ((csMusteriFisBilgileri)FisBilgileri).Tarih;
                yazdirrr.ds.Tables[0].Rows[0]["FaturaTutari"] = ((csMusteriFisBilgileri)FisBilgileri).Tutar;

                yazdirrr.Yazdirr(clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir, ((csMusteriFisBilgileri)FisBilgileri).YaziciAdi, 1);
                this.BringToFront();
                this.Focus();
            }
        }


        #endregion

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
            gvOdemesiYapilacakSatis.MovePrevPage();
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
                    if (gvSatisHareketleri.RowCount == 0)
                        return;
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
            if (gvOdemesiYapilacakSatis.RowCount == 0 && string.IsNullOrEmpty(gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaBarkod).ToString()))
                return;
            {
                gvOdemesiYapilacakSatis_FocusedRowChanged(null, null);

                //gvSatisHareketleri_CellValueChanged(null, null);
                //Satislar.FaturaIDdenFaturayiYenile(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaID));

                Satislar.FaturaBarkodtanSatisiGetir(SqlConnections.GetBaglanti(), TrGenel, gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaBarkod").ToString());

                //gvOdemesiYapilacakSatis.RefreshRow(gvOdemesiYapilacakSatis.FocusedRowHandle);
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
                    int FatId = (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaID);

                    if (FatId == -1)
                        MessageBox.Show("Burada -1 gelmemesi gerekiyordu bunu bana bildir.");

                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    //string barkodNo = Satislar.OdemesiYapilanSatisiGeriGetir(SqlConnections.GetBaglanti(), TrGenel, (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaID));

                    Satislar.OdemesiYapilanSatisiGeriGetir(SqlConnections.GetBaglanti(), TrGenel, FatId);
                    TrGenel.Commit();
                    //BarkodtanMusteriAra(barkodNo);
                    btnYenile_Click(null, null);
                    //SonOdemesiYapilanMusterinin_FaturaID = -1;
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
                    decimal KatSayi = (decimal)gvSatisHareketleri.GetFocusedRowCellValue(colKatSayi);
                    gvSatisHareketleri.SetFocusedRowCellValue(colMiktar, KatSayi * Convert.ToDecimal(frm.textEdit1.EditValue));
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

                decimal KatSayi = (decimal)gvSatisHareketleri.GetFocusedRowCellValue(colKatSayi);
                //decimal 

                gvSatisHareketleri.SetFocusedRowCellValue(colMiktar, KatSayi * ((decimal)gvSatisHareketleri.GetFocusedRowCellValue(colAltBirimMiktar) + 1));


            }
            catch (Exception exx)
            {


            }
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

        private void btnUrunButonlari_Click(object sender, EventArgs e)
        {

            // eğer hiç satış yoksa yeni müşteriye basıcak, o zaman da ödemesinin tamamlandığını kontrol etmesine gerek yok
            if (gvOdemesiYapilacakSatis.RowCount != 0 && OdemesiTamamlanmisMi(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()))
            {
                MessageBox.Show("Ödemesi Tamamlanan Satış Değiştilemez");
                return;
            }
            if (gvOdemesiYapilacakSatis.RowCount == 0)
            {
                btnYeniMusteri_Click(null, null);
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


        private void chckbtnIskontoIslemleri_CheckedChanged(object sender, EventArgs e)
        { /*
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
            }*/
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

        private void btnBakiyeyiKrediKartiIleAl_Click(object sender, EventArgs e)
        {

            if (gvOdemesiYapilacakSatis.RowCount == 0 || gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID") == DBNull.Value)
            {
                MessageBox.Show("Satış yok veya seçili satışın daha tüm bilgileri gelmedi mk");
                return;
            }
            if (OKCEntegrasyonu != OkcEntegrasyonTipi.EntegrasyonYok && MikroSarayOKC.BaglantiVarMi != csMikroSarayOKC.BaglantiDurumu.Var)
            {
                MessageBox.Show("OKC baglantısı daha tamamlanmadı biraz bekleyin");
                return;
            }
            //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            //OdemeKay.OdemeyiKaydet(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")));
            //TrGenel.Commit();
            //gvOdemesiYapilacakSatis.SetFocusedRowCellValue("OdendiMi", true);
            //SonOdemesiYapilanMusterinin_FaturaID = (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID"); // bu nerde kullanıyor hamısına

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            csOdemeKaydet.OdemeDonenBilgisi donenOdemeBilgisi = OdemeKay.FaturaninBakiyesininKalaniniNakitTahsilEt(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")), 3, "Fatura Kredi KArtı İle ödeme", 0, _PersonelID); // KAsaID 3 pos cihazı için verilen ID
            TrGenel.Commit();


            if (csOdemeKaydet.OdemeDonenBilgisi.OncedenOdemesiTamamlanmis == donenOdemeBilgisi)
            {
                MessageBox.Show("Ödemesi önceden tamamlanmış hamısına");
            }
            else if (donenOdemeBilgisi == csOdemeKaydet.OdemeDonenBilgisi.OdemesiTamamlandi && OKCEntegrasyonu == OkcEntegrasyonTipi.TamEntegrasyon)
            {
                UrunleriGecir();
                MikroSarayOKC.KrediKartiIleOde(float.Parse(gvOdemesiYapilacakSatis.GetFocusedRowCellValue(colFaturaTutari).ToString()));
            }


            // bunu raşağıda yazdığın row style girdin diye yaptın.
            btnYenile_Click(null, null);
            gvOdemesiYapilacakSatis.RefreshRow(gvOdemesiYapilacakSatis.GetRowHandle(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()));
        }

        private void btnKismiOdeme_Click(object sender, EventArgs e)
        {
            if (gvOdemesiYapilacakSatis.RowCount == 0 || gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID") == DBNull.Value)
            {
                MessageBox.Show("Satış yok veya seçili satışın daha tüm bilgileri gelmedi mk");
                return;
            }

            frmKismiOdeme frm = new frmKismiOdeme();
            if (DialogResult.Yes == frm.ShowDialog())
            {
                //SonOdemesiYapilanMusterinin_FaturaID = (int)gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID"); // bu nerde kullanıyor hamısına

                int KismiOdemeKasaID = frm.KismiOdemesiYapilanKasaID;
                decimal KismiOdemeTutari = frm.Tutar;
                string KismiODemeAciklama = frm.Aciklama;

                if (OKCEntegrasyonu == OkcEntegrasyonTipi.TamEntegrasyon)
                {
                    MikroSarayOKC.OKCNakitOde2((float)KismiOdemeTutari);
                }

                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                OdemeKay.FaturaninBakiyesininKalaniniNakitTahsilEt(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvOdemesiYapilacakSatis.GetFocusedRowCellValue("FaturaID")), KismiOdemeKasaID, KismiODemeAciklama, KismiOdemeTutari, _PersonelID);
                TrGenel.Commit();

                // bunu raşağıda yazdığın row style girdin diye yaptın.
                btnYenile_Click(null, null);
                gvOdemesiYapilacakSatis.RefreshRow(gvOdemesiYapilacakSatis.GetRowHandle(gvOdemesiYapilacakSatis.GetFocusedDataSourceRowIndex()));
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmGiderCikisi frm = new frmGiderCikisi(_PersonelID))
                frm.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_PersonelID == -1)
            {
                MessageBox.Show("Personel Tanımı Yap önce");
                return;
            }
            using (frmKasaRaporu Rapor = new frmKasaRaporu(_PersonelID))
            {
                Rapor.ShowDialog();
            }



        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clsTablolar.frmStokBilgileri frm = new clsTablolar.frmStokBilgileri(SqlConnections.GetBaglanti());
            frm.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("TeraziSatisBaslat2"))
                //{
                //    proc.Kill();
                //}

                if (!Directory.Exists(Application.StartupPath + @"\Guncelleme"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\Guncelleme");
                }

                File.Copy(Application.StartupPath + @"\TeraziSatisGuncelleme.exe", Application.StartupPath + @"\Guncelleme\TeraziSatisGuncelleme.exe", true);
                File.Copy(Application.StartupPath + @"\TeraziSatisGuncelleme.pdb", Application.StartupPath + @"\Guncelleme\TeraziSatisGuncelleme.pdb", true);


                System.Diagnostics.Process.Start(Application.StartupPath + @"\Guncelleme\TeraziSatisGuncelleme.exe", "3");
                Application.Exit();
            }
            catch (Exception)
            {
                throw;
            }
        }


        Thread ThOkcISlemleri;



        #region OKCIsleri


        bool FisiOkuturOkutmazYazdirmayaBasla = false;


        //public object lokcTaken = new object();


        private void barBtnSonFisiTekrarYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MikroSarayOKC.SonFisiTekrarYazdir();
        }

        private void barbtnOkcBilgileri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmOKCBilgileri frm = new frmOKCBilgileri())
            {
                //TODO: Buraya Okc bilgileri gelecek yeni oluşturduğun clastan

                //frm.labelControl1.Text = dll.getDemoSDKVersion();
                //frm.labelControl2.Text = dll.getDemoSDKVersionCSharp();
                //frm.labelControl3.Text = dll.getDemoSDKVersionDelphi();
                //frm.labelControl4.Text = dll.getFactoryNumber();

                frm.ShowDialog();
            }
        }



        void UrunleriGecir()
        {
            try
            {
                lock (MikroSarayOKC.lokcTaken) // bu lock un burada olması çok önemli çünkü oluşturulan list yazdırılmadan yenisi oluşturulmadan başka bir yerde kulllanılmamalı
                {
                    MikroSarayOKC.YazdirilacakFisBilgileri = new List<csMikroSarayOKC.OKCFisBilgileri>();
                    for (int i = 0; i < gvSatisHareketleri.RowCount; i++)
                    {
                        MikroSarayOKC.YazdirilacakFisBilgileri.Add(new csMikroSarayOKC.OKCFisBilgileri(gvSatisHareketleri.GetRowCellValue(i, colFaturaHareketStokAdi).ToString(),
                            "1111",
                            gvSatisHareketleri.GetRowCellValue(i, colStokAltBirimAdi).ToString(),
                            float.Parse(gvSatisHareketleri.GetRowCellValue(i, colKdvDahilFiyat).ToString()),
                            float.Parse(gvSatisHareketleri.GetRowCellValue(i, colAltBirimMiktar).ToString())
                            ));
                    }


                    ThOkcISlemleri = new Thread(new ThreadStart(MikroSarayOKC.OkcyUrunleriYazidir));
                    ThOkcISlemleri.Start();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("ahanda hata");
            }
            //if (!string.IsNullOrEmpty(EssizNumaraUret())) // empty gelmezse yeni eşsiz numara üretilmiş demektir.
            //OkcyURunleriYazidir();
        }






        private void barbtnOkcFisIptal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MikroSarayOKC.FisiIptalEt();
            }
            catch (Exception ex)
            {
                if (ex.Message == "FP: OK; Command: Illegal.")
                {
                    MessageBox.Show("İptal edilecek Satış Fiş yok");
                }
            }
        }


        #endregion

        private void btnSiparisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (clsTablolar.TeraziSatisClaslari.frmSiparisListesi frm = new clsTablolar.TeraziSatisClaslari.frmSiparisListesi(SqlConnections.GetBaglanti(), KasaSatis.Properties.Settings.Default.TeraziID, YaziciAdi1))
            {
                frm.SiparisiSatisaAktarma = SiparisiSatisaAktarma;
                frm.ShowDialog();
            }
        }

        private void btnYeniSiparis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //{
            try
            {
                clsTablolar.TeraziSatisClaslari.frmSiparis frm = new clsTablolar.TeraziSatisClaslari.frmSiparis(-1, SqlConnections.GetBaglanti(), KasaSatis.Properties.Settings.Default.TeraziID, -1, YaziciAdi1);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //if (Kilitlimi)
                //    Monitor.Exit(clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit);
            }
        }
    }
}

