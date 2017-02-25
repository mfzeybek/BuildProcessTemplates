using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using System.IO;


namespace Aresv2
{
    public partial class frmAnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        //SqlConnections Baglanti = new SqlConnections();
        SqlTransaction trGenel;

        //DevExpress.XtraBars.Ribbon.RibbonControl ;



        private void AnaForm_Load(object sender, EventArgs e)
        {
            //frmInge frmm = new frmInge();
            //frmm.Show();
            //ribbon.ScreenModeChanged += Ribbon_ScreenModeChanged;

            ribbon.ApplicationIcon = (Bitmap)ımageCollection1.Images[0];
            ribbon.ApplicationIcon.MakeTransparent(Color.White);
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                clsTablolar.Ayarlar.csAyarlar Ayarlar = new clsTablolar.Ayarlar.csAyarlar(SqlConnections.GetBaglanti(), trGenel); // bunu bir kere çalıştırıyoruz ki ayarlar gelsin.


                #region Cari Gorme  Yetkisi Yoksa Cari Kartlar Listesi olmayacak

                if (clsTablolar.Ayarlar.csYetkiler.CariKartGorme == true)
                {
                    btnCariListe.Visibility = BarItemVisibility.Always;
                }
                else if (clsTablolar.Ayarlar.csYetkiler.CariKartGorme == false)
                {
                    btnCariListe.Visibility = BarItemVisibility.Never;
                }
                #endregion

                #region Cari Kart Ekleme Yetkisi Yoksa
                if (clsTablolar.Ayarlar.csYetkiler.CariKartEkleme == true)
                {
                    btnCariEkle.Visibility = BarItemVisibility.Always;
                }
                else if (clsTablolar.Ayarlar.csYetkiler.CariKartEkleme == false)
                {
                    btnCariEkle.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region  Stok Kart Gorme Yetkisi

                if (clsTablolar.Ayarlar.csYetkiler.StokKartGorme == false)
                {
                    barBtnStokListesi.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Stok Kartı Açma Yetkisi
                if (clsTablolar.Ayarlar.csYetkiler.StokKartEkleme == false)
                {
                    BarbtnYeniStokKarti.Visibility = BarItemVisibility.Never;
                }


                #endregion

                #region Stok Hareketleri Gorme Yetkisi

                if (clsTablolar.Ayarlar.csYetkiler.StokHareketleri == false)
                {
                    rpStokHareketleri.Visible = false;
                }
                #endregion

                #region Fatura Gösterme
                // Fatura Listesinin hiç açılmaması için Hem Satış Hem Alış Faturasını Görünütüleme Yetkisi olmaması lazım
                // buraya birde iade edilen faturalar içinde kontrol lazım
                if (clsTablolar.Ayarlar.csYetkiler.SatisFaturasiGorme == false && clsTablolar.Ayarlar.csYetkiler.AlisFaturasiGorme == false)
                {
                    btnFaturaListesi.Visibility = BarItemVisibility.Never;
                }



                #endregion

                #region Satis Faturası Ekleme
                if (clsTablolar.Ayarlar.csYetkiler.SatisFaturasiEkleme == false)
                {
                    btnSatisFaturasi.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Alis Faturası Ekleme
                if (clsTablolar.Ayarlar.csYetkiler.AlisFaturasiGorme == false)
                {
                    btnAlisFaturasi.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Sipariş Görme
                // Alınan veya verilen sipiriş görme yetkisine sahip değilse Sipariş listesi butonu gizli olacak

                if (clsTablolar.Ayarlar.csYetkiler.AlinanSiparisGorme == false && clsTablolar.Ayarlar.csYetkiler.VerilenSiparisGorme == false)
                {
                    btnSiparisListesi.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Alinan Siparis Ekleme

                if (clsTablolar.Ayarlar.csYetkiler.AlinanSiparisEkleme == false)
                {
                    btnAlinanSiparis.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Verilen Sipariş Ekleme

                if (clsTablolar.Ayarlar.csYetkiler.VerilenSiparisEklme == false)
                {
                    btnVerilenSiparis.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Basit Üretim Reçetesi Görme

                if (clsTablolar.Ayarlar.csYetkiler.BasitUretimReceteGosterme == false)
                {
                    btnReceteListesi.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Basit Üretim Reçetesi Ekleme

                if (clsTablolar.Ayarlar.csYetkiler.BasitUretimReceteEkleme == false)
                {
                    btnReceteEkle.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Cek Görebilme Yetksi
                // hem alınan çekleri hem verilen çekleri görebilme yetkisi yoksa Çek Listesi görünmeyecek
                if (clsTablolar.Ayarlar.csYetkiler.AlinanCekGosterme == false && clsTablolar.Ayarlar.csYetkiler.VerilenCekGosterme == false)
                {
                    btnCekListesi.Visibility = BarItemVisibility.Never;
                }


                #endregion

                #region Verilen Çek Ekleme Yetkisi

                if (clsTablolar.Ayarlar.csYetkiler.VerilenCekEkleme == false)
                {
                    btnVerilenCek.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region Alinan Çek Ekleme Yetkisi
                if (clsTablolar.Ayarlar.csYetkiler.AlinanCekEkleme == false)
                {
                    btnAlinanCek.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region İş Başvuru Yetkileri

                if (clsTablolar.Ayarlar.csYetkiler.IsBasvuruGosterme == false)
                {
                    barBtnIsBasvuruListesi.Visibility = BarItemVisibility.Never;
                }

                if (clsTablolar.Ayarlar.csYetkiler.IsBasvuruEkleme == false)
                {
                    barBtnIsBasvuruKaydi.Visibility = BarItemVisibility.Never;
                }



                #endregion

                #region Ayarlar Yetkileri

                if (clsTablolar.Ayarlar.csYetkiler.Ayarlar == false)
                {
                    PageAyarlar.Visible = false;
                }

                #endregion

                #region StokEtiket

                if (clsTablolar.Ayarlar.csYetkiler.StokEtiket == false)
                {
                    barBtnStokEtiket.Visibility = BarItemVisibility.Never;
                }


                #endregion

                #region HemenAl İşlemleri
                // daha sonra HemenAl işlemleri ile ilgili yetkilendirmeler detaylandırılacak
                if (clsTablolar.Ayarlar.csYetkiler.HemenAlIslemleri == false)
                {
                    PageHemenAl.Visible = false;
                }


                #endregion

                #region Personel İşlemleri
                if (clsTablolar.Ayarlar.csYetkiler.PersonelIslemleri == false)
                {
                    PagePersonel.Visible = false;
                }


                #endregion


                #region Faturasindan Iade Gorme

                if (clsTablolar.Ayarlar.csYetkiler.AlisFaturasindanIadeEkleme == false)
                {
                    btnAlistanIadeFatura.Visibility = BarItemVisibility.Never;
                }
                if (clsTablolar.Ayarlar.csYetkiler.SatisFaturasindanIadeEkleme == false)
                {
                    btnSatisIadeFaturasi.Visibility = BarItemVisibility.Never;
                }

                #endregion






                #region CariHareket

                if (clsTablolar.Ayarlar.csYetkiler.CariHareketleriGorme == false)
                {
                    btnCariHareketListesi.Visibility = BarItemVisibility.Never;
                }

                if (clsTablolar.Ayarlar.csYetkiler.CariHareketEkleme == false)
                {
                    btnCariHareketEkle.Visibility = BarItemVisibility.Never;
                }

                #endregion

                #region StokSayim

                if (clsTablolar.Ayarlar.csYetkiler.StokSayim == false)
                {
                    rpStokSayim.Visible = false;
                }

                #endregion


                #region Fiyat Analiz

                if (clsTablolar.Ayarlar.csYetkiler.FiyatAnaliz == false)
                {
                    btnFiyatAnaliz.Visibility = BarItemVisibility.Never;
                }

                #endregion

                if (clsTablolar.Ayarlar.csYetkiler.AjandaGorme == false)
                {
                    ribbonPage7.Visible = false;
                }

                #region Falan Filan Açıklama yaz

                bool GrupGozukecekmi = false;
                bool PageGozukecekmi = false;

                //burada gözükmesini engellediğimiz Butonların 
                //Grubundaki butonları hepsi gizli oluyorsa pageGrup unda gözükmesini engelliyoruz

                //Page deki bütün grupların hepsi gizli ise page in visible ını false yapıyoruz

                for (int a = 0; a < ribbon.Pages.Count; a++) // ribbon da kaç adet sayfa varsa hepsini dolaşıyor
                {
                    PageGozukecekmi = false;
                    for (int b = 0; b < ribbon.Pages[a].Groups.Count; b++) // bir page in içinde kaç adet group varsa
                    {
                        // page in içinde deki falan filan buralara açıklamalar yaz

                        GrupGozukecekmi = false;
                        for (int c = 0; c < ribbon.Pages[a].Groups[b].ItemLinks.Count; c++) // group un içinde kaç adet buton varsa
                        {
                            if (ribbon.Pages[a].Groups[b].ItemLinks[c].Item.Visibility != BarItemVisibility.Never) // eğer içinde 1 tane bile never den farklı bişi varsa
                            {
                                // eğer bu alana girdiyse demektir ki
                                // bulunan grup gözükecek
                                // bulunan grup un gözükmemesi için içindekilerin hepsinin visibility özelleği never olması lazım
                                GrupGozukecekmi = true;
                                c = ribbon.Pages[a].Groups[b].ItemLinks.Count;
                            }

                        }
                        if (GrupGozukecekmi == false)
                            ribbon.Pages[a].Groups[b].Visible = false;

                        //PageGozukecekmi = false;
                        if (ribbon.Pages[a].Groups[b].Visible != false)
                        {
                            PageGozukecekmi = true;
                            //b = ribbon.Pages[a].Groups.Count;
                        }
                    }
                    if (PageGozukecekmi == false)
                        ribbon.Pages[a].Visible = false;
                }

                #endregion

                trGenel.Commit();

                if (Aresv2.Properties.Settings.Default.GelistiriciModu == false)
                {
                    barBtnEksilenStokListesi.Visibility = BarItemVisibility.Never;
                    btnStokIhtiyac.Visibility = BarItemVisibility.Never;
                    barButtonItem30.Visibility = BarItemVisibility.Never;
                    barBtnPaketListesi.Visibility = BarItemVisibility.Never;
                    ribbonPageGroup22.Visible = false;
                    ribbonPage10.Visible = false;
                    rpUretim.Visible = false;
                    ribbonPage4.Visible = false;
                    PagePersonel.Visible = false;
                    rpYonetim.Visible = false;
                    ribbonPage1.Visible = false;
                    PageHemenAl.Visible = false;
                }


                this.Text = SqlConnections._DB + " - " + " Versiyon = Beta 15 - " + SqlConnections._Server;

                if (clsTablolar.Ayarlar.csYetkiler.AjandaGorme == true)
                {
                    //barButtonItem_Ajanda_ItemClick(null, null);
                }
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void Ribbon_ScreenModeChanged(object sender, DevExpress.XtraBars.Ribbon.ScreenModeChangedEventArgs e)
        {

        }

        private void FormuAc(Form GelenForm)
        {
            try
            {
                bool Durum = false;
                foreach (var item in this.MdiChildren)
                {
                    if (item.Name == GelenForm.Name)
                    {
                        Durum = true;
                        item.Activate();
                    }
                }
                if (Durum == false)
                {
                    GelenForm.MdiParent = this;
                    GelenForm.Show();
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void FormuAc2(Form GelenForm)
        {
            try
            {
                GelenForm.MdiParent = this;
                GelenForm.Show();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnCariListe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCariListe frm = new frmCariListe();
            frm.Text = "Cari Kartlar Listesi";
            FormuAc(frm);
        }
        private void btnCariEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cari.frmCariDetay frmCariv2 = new Cari.frmCariDetay(-1);
            FormuAc(frmCariv2);
        }
        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                try
                {
                    if ((Application.OpenForms[i]).Tag.ToString() == "0")
                    {
                        e.Cancel = true;
                        (Application.OpenForms[i]).Activate();
                        //MessageBox.Show("Burada Kayıt Tamamlanmamış hamısınaaaaaa");
                        return;
                    }
                }
                catch (Exception)
                {
                    //Eğer btnkaydet butonu yoksa buraya düşecek ama öyle gereksiz bi yer hamısına
                }
            }


            try
            {
                ((frmKullaniciGiris)Application.OpenForms["frmKullaniciGiris"]).ProgramiKapat();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCariOzelBilgi frm = new frmCariOzelBilgi();
            FormuAc(frm);
        }
        private void btnYeniStokKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmStokDetay frm = new Stok.frmStokDetay(-1);
            FormuAc2(frm);
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmStokListesi frm = new Stok.frmStokListesi(false);
            frm.Text = "Stok Listesi";
            FormuAc(frm);
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            EksilenStokListesi.EksilenStokListesi EksilenStokListesi = new EksilenStokListesi.EksilenStokListesi();
            FormuAc(EksilenStokListesi);
        }
        private void btnStokSayim_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmStokSayim frmStokSayim = new Stok.frmStokSayim(Stok.frmStokSayim.NasilAcsin.Listemi);
            FormuAc(frmStokSayim);
        }
        private void btnExceldenVeriCek_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmExceldenUrunCek frm = new frmExceldenUrunCek();
            FormuAc(frm);
        }
        private void btnSatisFaturasi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Fatura.frmFaturaDetay frmFaturaDetay = new Fatura.frmFaturaDetay(clsTablolar.IslemTipi.SatisFaturasi, -1);
            frmFaturaDetay.MdiParent = this;
            frmFaturaDetay.Text = "SATIŞ FATURASI";
            frmFaturaDetay.Show();
        }
        private void btnAlisFaturasi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Fatura.frmFaturaDetay frmFaturaDetay = new Fatura.frmFaturaDetay(clsTablolar.IslemTipi.AlisFaturasi, -1);
            frmFaturaDetay.MdiParent = this;
            frmFaturaDetay.Text = "ALIŞ FATURASI";
            frmFaturaDetay.Show();
        }
        private void btnSatisIadeFaturasi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Fatura.frmFaturaDetay frmFaturaDetay = new Fatura.frmFaturaDetay(clsTablolar.IslemTipi.SatisIadeFaturasi, -1);
            frmFaturaDetay.MdiParent = this;
            frmFaturaDetay.Text = "SATIŞ İADE FATURASI";
            frmFaturaDetay.Show();
        }
        private void btnAlistanIadeFatura_ItemClick(object sender, ItemClickEventArgs e)
        {
            Fatura.frmFaturaDetay frmFaturaDetay = new Fatura.frmFaturaDetay(clsTablolar.IslemTipi.AlisIadeFaturasi, -1);
            frmFaturaDetay.MdiParent = this;
            frmFaturaDetay.Text = "ALIŞ İADE FATURASI";
            frmFaturaDetay.Show();
        }
        private void btnFaturaListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Fatura.frmFaturaListesi frm = new Fatura.frmFaturaListesi(Fatura.frmFaturaListesi.AcmaYontemi.FaturaListe);
            FormuAc(frm);
        }
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmStokSayimDetayv2 frmStokSayimDetayv2 = new Stok.frmStokSayimDetayv2(-1);
            FormuAc(frmStokSayimDetayv2);
        }
        private void btnAmbarTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmATListesi frmATListesi = new Stok.frmATListesi();
            FormuAc(frmATListesi);
        }
        private void btnAmbarTransfer_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Stok.frmAmbarTransfer frmAmbarTransfer = new Stok.frmAmbarTransfer(0, Stok.frmAmbarTransfer.FormOpenEnum.New);
            FormuAc(frmAmbarTransfer);
        }
        private void btnHizliSatis_ItemClick(object sender, ItemClickEventArgs e)
        {
            HizliSatis.frmHizliSatis frm = new HizliSatis.frmHizliSatis();
            FormuAc(frm);
        }
        private void btnStokIhtiyac_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmStokIhtiyac frm = new frmStokIhtiyac();
            FormuAc(frm);
        }
        private void btnNumaraSablon_ItemClick(object sender, ItemClickEventArgs e)
        {
            NumaraSablon.frmNumaraSablon frmNumaraSablon = new NumaraSablon.frmNumaraSablon();
            frmNumaraSablon.ShowDialog();
        }
        private void btnIrsaliyeListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Irsaliye.frmIrsaliyeListesi frm = new Irsaliye.frmIrsaliyeListesi();
            FormuAc(frm);
        }
        private void btnAlistanIadeIrsaliye_ItemClick(object sender, ItemClickEventArgs e)
        {
            Irsaliye.frmIrsaliyeDetay frmIrsaliyeDetay = new Irsaliye.frmIrsaliyeDetay(clsTablolar.IslemTipi.AlisIadeIrsaliyesi, -1);
            frmIrsaliyeDetay.MdiParent = this;
            frmIrsaliyeDetay.Text = "ALIŞ İADE İRSALİYESİ";
            frmIrsaliyeDetay.Show();
        }
        private void btnAlisIrsaliye_ItemClick(object sender, ItemClickEventArgs e)
        {
            Irsaliye.frmIrsaliyeDetay frmIrsaliyeDetay = new Irsaliye.frmIrsaliyeDetay(clsTablolar.IslemTipi.AlisIrsaliyesi, -1);
            frmIrsaliyeDetay.MdiParent = this;
            frmIrsaliyeDetay.Text = "ALIŞ İRSALİYESİ";
            frmIrsaliyeDetay.Show();
        }
        private void btnSatisIadeIrsaliye_ItemClick(object sender, ItemClickEventArgs e)
        {
            Irsaliye.frmIrsaliyeDetay frmIrsaliyeDetay = new Irsaliye.frmIrsaliyeDetay(clsTablolar.IslemTipi.SatisIadeIrsaliyesi, -1);
            frmIrsaliyeDetay.MdiParent = this;
            frmIrsaliyeDetay.Text = "SATIŞ İADE İRSALİYESİ";
            frmIrsaliyeDetay.Show();
        }
        private void btnSatisIrsaliye_ItemClick(object sender, ItemClickEventArgs e)
        {
            Irsaliye.frmIrsaliyeDetay frmIrsaliyeDetay = new Irsaliye.frmIrsaliyeDetay(clsTablolar.IslemTipi.SatisIrsaliyesi, -1);
            frmIrsaliyeDetay.MdiParent = this;
            frmIrsaliyeDetay.Text = "SATIŞ İRSALİYESİ";
            frmIrsaliyeDetay.Show();
        }
        private void btnSiparisListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Siparis.frmSiparisListesi frm = new Siparis.frmSiparisListesi();
            FormuAc(frm);
        }
        private void btnAlinanSiparis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Siparis.frmSiparisDetay frmSiparisDetay = new Siparis.frmSiparisDetay(clsTablolar.Siparis.csSiparis.SiparisTip.AlinanSiparis, -1);
            frmSiparisDetay.MdiParent = this;
            frmSiparisDetay.Text = "ALINAN SİPARİŞ";
            frmSiparisDetay.Show();
        }
        private void btnVerilenSiparis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Siparis.frmSiparisDetay frmSiparisDetay = new Siparis.frmSiparisDetay(clsTablolar.Siparis.csSiparis.SiparisTip.VerilenSiparis, -1);
            frmSiparisDetay.MdiParent = this;
            frmSiparisDetay.Text = "VERİLEN SİPARİŞ";
            frmSiparisDetay.Show();
        }
        private void btnRecete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Uretim.frmRecete frmRecete = new Uretim.frmRecete();
            FormuAc(frmRecete);
        }
        private void btnUretimEmirleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            Uretim.frmUretimEmri frmUretimEmri = new Uretim.frmUretimEmri();
            FormuAc(frmUretimEmri);
        }
        private void barbtnPersonelListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Personel.frmPersonelListesi frm = new Personel.frmPersonelListesi(Personel.frmPersonelListesi.AramamiListeMi.Liste);
            FormuAc(frm);
        }
        private void barBtnPersonelGorevTanimlari_ItemClick(object sender, ItemClickEventArgs e)
        {
            Personel.frmPersonelGorevTanimi frm = new Personel.frmPersonelGorevTanimi();
            FormuAc(frm);
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Personel.frmPersonelKarti frm = new Personel.frmPersonelKarti(-1);
            FormuAc(frm);
        }

        private void btnGenelAyarlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ayarlar.frmGenelAyarlar frmGenelAyarlar = new Ayarlar.frmGenelAyarlar();
            frmGenelAyarlar.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmhtmlEditor frm = new frmhtmlEditor();
            FormuAc(frm);
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.XtraForm1 FRM = new HemenAl.XtraForm1();
            FormuAc(FRM);
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmWebEntegrasyonUrunler frm = new frmWebEntegrasyonUrunler();
            FormuAc(frm);
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.frmHemenAlKategori frm = new HemenAl.frmHemenAlKategori();
            FormuAc(frm);
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            StokSayim.frmStokSayimKarsilastirma frm = new StokSayim.frmStokSayimKarsilastirma();
            FormuAc(frm);


        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.XtraForm1 urunler = new HemenAl.XtraForm1();
            FormuAc(urunler);
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.HemenAlUrunSecenekOnTanimlari frm = new HemenAl.HemenAlUrunSecenekOnTanimlari(HemenAl.HemenAlUrunSecenekOnTanimlari.NasinAcsin.OnTanimDuzenlemekIcin);
            FormuAc(frm);
        }

        private void barButtonItem_Ajanda_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ajanda.frmAjanda frm = new Ajanda.frmAjanda();
            FormuAc(frm);
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsanKaynaklari.frmIsBasvuruListesi frm = new InsanKaynaklari.frmIsBasvuruListesi();
            FormuAc(frm);
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsanKaynaklari.frmBasvuruKarti frm = new InsanKaynaklari.frmBasvuruKarti(-1);
            FormuAc(frm);
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ajanda.frmNotGruplari frm = new Ajanda.frmNotGruplari();
            FormuAc(frm);
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ajanda.frmNotKarti frm = new Ajanda.frmNotKarti(-1);
            FormuAc(frm);
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ajanda.frmNotListesi frm = new Ajanda.frmNotListesi();
            FormuAc(frm);

        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            Personel.frmPdks frm = new Personel.frmPdks();
            FormuAc(frm);
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.frmHemenAlStokFiyat frm = new HemenAl.frmHemenAlStokFiyat();
            FormuAc(frm);
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.HemenAlUrunFoto frm = new HemenAl.HemenAlUrunFoto();
            FormuAc(frm);

        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.frmXmlUrunAktarimi frm = new HemenAl.frmXmlUrunAktarimi();
            FormuAc(frm);

        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.frmHemenAlUrunFotoFtp ftpyeGonder = new HemenAl.frmHemenAlUrunFotoFtp();
            FormuAc(ftpyeGonder);
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExceldenUrun_CariCek.frmExceldenCariAktar frm = new ExceldenUrun_CariCek.frmExceldenCariAktar();
            FormuAc(frm);
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmStokHrListesi frm = new Stok.frmStokHrListesi();
            FormuAc(frm);
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmStokFiyatKarsilastirma frm = new Stok.frmStokFiyatKarsilastirma(Stok.frmStokFiyatKarsilastirma.NeIcin.FaturadanDegil);
            FormuAc(frm);
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cari.CariHr.frmCariHrListesiv3 frm = new Cari.CariHr.frmCariHrListesiv3(Cari.CariHr.frmCariHrListesiv3.NasilAcicak.Liste);
            FormuAc(frm);
        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cari.CariHr.frmCariHrKarti frm = new Cari.CariHr.frmCariHrKarti(-1);
            FormuAc(frm);
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cek.frmCekListesi frm = new Cek.frmCekListesi();
            FormuAc(frm);
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cek.frmCekKarti frm = new Cek.frmCekKarti(clsTablolar.Cek.csCekHr.CekTipi.AlinanCek);
            FormuAc(frm);
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cek.frmCekKarti frm = new Cek.frmCekKarti(clsTablolar.Cek.csCekHr.CekTipi.VerilenCek);
            FormuAc(frm);
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            HemenAl.frmTopluUrunGonder frm = new HemenAl.frmTopluUrunGonder();
            FormuAc(frm);
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            cs.frmHesapMak frm = new cs.frmHesapMak();
            FormuAc(frm);
        }

        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
        {
            Personel.frmPdkRapor frm = new Personel.frmPdkRapor();
            FormuAc(frm);
        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmStokEtiket frm = new Stok.frmStokEtiket();
            FormuAc(frm);
        }

        private void barButtonItem39_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            BasitUretim.frmBasitUretimRecetesiListesi frm = new BasitUretim.frmBasitUretimRecetesiListesi(true);
            FormuAc(frm);
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasitUretim.frmBasitUretimRecetesi frm = new BasitUretim.frmBasitUretimRecetesi(-1);
            FormuAc(frm);
        }

        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ayarlar.frmBarkodAyar frm = new Ayarlar.frmBarkodAyar(Ayarlar.frmBarkodAyar.NasilAcsin.AyarlamakIcin);
            FormuAc(frm);
        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmStokSayimDetayv2 frmStokSayimDetayv2 = new Stok.frmStokSayimDetayv2(-1);
            FormuAc(frmStokSayimDetayv2);
        }

        private void barBtnYetkiler_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ayarlar.frmYetkiler frm = new Ayarlar.frmYetkiler(clsTablolar.csKullanici.KullaniciID);
            FormuAc(frm);
        }

        private void btnTeraziButonGruplari_ItemClick(object sender, ItemClickEventArgs e)
        {
            Terazi.frmTeraziStokButonGrupTanimlari frm = new Terazi.frmTeraziStokButonGrupTanimlari();
            FormuAc(frm);
        }

        private void btnTeraziListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Terazi.frmTeraziListesi frm = new Terazi.frmTeraziListesi();
            FormuAc(frm);
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Terazi.frmTeraziKarti frm = new Terazi.frmTeraziKarti(-1);
            FormuAc(frm);
        }

        private void barBtnHizliUrunBilgileri_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsTablolar.frmStokBilgileri frm = new clsTablolar.frmStokBilgileri(SqlConnections.GetBaglanti());
            frm.StokKartiAc = StokkartiAc;
            FormuAc(frm);
        }

        private void StokkartiAc(int StokID)
        {
            if (clsTablolar.Ayarlar.csYetkiler.StokKartGorme)
            {
                Stok.frmStokDetay frm = new Stok.frmStokDetay(StokID, 3);
                frm.txtRafYeriAciklama.Focus();
                frm.txtRafYeriAciklama.SelectAll();
                frm.ShowDialog();
            }
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Terazi.frmTeraziDeadLock frm = new Terazi.frmTeraziDeadLock();
            FormuAc(frm);
        }

        private void barButtonItem16_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Fatura.frmFaturaKarAnalizi frm = new Fatura.frmFaturaKarAnalizi();
            FormuAc(frm);
        }

        private void barBtnPaketListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.Paket.frmPaketListesi frm = new Stok.Paket.frmPaketListesi();
            FormuAc(frm);
        }

        private void barBtnYeniPaketKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.Paket.frmPaketDetayi frm = new Stok.Paket.frmPaketDetayi(-1);
            FormuAc(frm);
        }

        private void barButtonItem18_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Siparis.frmSiparisHazirlama frm = new Siparis.frmSiparisHazirlama();
            FormuAc(frm);
        }

        private void barButtonItem19_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Ayarlar.frmVeriTabaniYedekle frm = new Ayarlar.frmVeriTabaniYedekle();
            FormuAc(frm);
        }

        private void barButtonItem29_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Yonetim.frmYonetim frm = new Yonetim.frmYonetim();
            FormuAc(frm);
        }

        private void barButtonItem31_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.frmOzelEtiket frm = new Stok.frmOzelEtiket();
            FormuAc(frm);
        }

        private void barButtonItem32_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmPDFGoruntuleme frm = new frmPDFGoruntuleme();
            FormuAc(frm);
        }

        private void barButtonItem33_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            Personel.frmDisaridakiPersonel frm = new Personel.frmDisaridakiPersonel();
            FormuAc(frm);
        }

        private void barButtonItem34_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmPDFOnizleme frm = new frmPDFOnizleme();
            FormuAc(frm);
        }


        private void barButtonItem35_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem_TamEkran_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsTablolar.FormState fs = new clsTablolar.FormState();
            fs.Maximize(this);
        }

        private void barButtonItem41_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            BasitUretim.frmBasitUretim frmm = new BasitUretim.frmBasitUretim(-1);

            FormuAc2(frmm);
        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasitUretim.frmUretimListesi frmm = new BasitUretim.frmUretimListesi();
            FormuAc2(frmm);
        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            n11.frmN11 frm = new n11.frmN11();
            FormuAc2(frm);
        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {
            n11.frmN11ProductList frm = new n11.frmN11ProductList();
            FormuAc2(frm);
        }

        private void barButtonItem47_ItemClick(object sender, ItemClickEventArgs e)
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


                System.Diagnostics.Process.Start(Application.StartupPath + @"\Guncelleme\TeraziSatisGuncelleme.exe", "1");
                Application.Exit();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
