using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tremol;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;
using System.Data;
using System.Data.SqlClient;


namespace KasaSatis
{
    public class csMikroSarayOKC : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        OKCDrumlari okcDurumlari = new OKCDrumlari();

        private BaglantiDurumu _BaglantiVarMi;

        public BaglantiDurumu BaglantiVarMi { get => _BaglantiVarMi; }

        public csMikroSarayOKC()
        {


        }

        public delegate void dlg_OKCBaglantiDurumu(BaglantiDurumu BaflantiDurumu);
        public dlg_OKCBaglantiDurumu BaglantDurumu;

        public void BaglantiKur()
        {
            OKCOdemeIslemleri = new Thread(new ThreadStart(Baglan));
            OKCOdemeIslemleri.Start();
        }

        public enum BaglantiDurumu
        {
            Var = 1,
            yok = 2,
            BaglantiKayboldu = 3
        }

        private void Baglan()
        {
            //lock (lokcTaken)
            {
                dll.setgmp(true);
                dll.setgmp_force(true);
                dll.connect();
                _BaglantiVarMi = BaglantiDurumu.yok;
                BaglantDurumu(_BaglantiVarMi); // buradan bağlantı kuruluyor yazıcak
                while (true) // bu zaten şuan  ayrı bir threadte
                {
                    if (dll.checkConnectGMP3Coupling())
                    {
                        if (_BaglantiVarMi == BaglantiDurumu.yok) //Bağlantı zaten varken bağlantının olduğu doğrulanırsa bişi yapmasın;
                        {
                            _BaglantiVarMi = BaglantiDurumu.Var;
                            BaglantDurumu(_BaglantiVarMi);
                        }
                        else if (_BaglantiVarMi == BaglantiDurumu.BaglantiKayboldu) // bağlantı önceden kaybolmuş ama gelmişse
                        {
                            _BaglantiVarMi = BaglantiDurumu.Var;
                            BaglantDurumu(_BaglantiVarMi);
                        }
                    }
                    else // yani bağlantı yoksa
                    {
                        if (_BaglantiVarMi == BaglantiDurumu.Var) //Bağlantı varken bağlantının olmazsa, yani bağlantı düşerse bağlantı yok olsun
                        {
                            _BaglantiVarMi = BaglantiDurumu.BaglantiKayboldu;
                            BaglantDurumu(this._BaglantiVarMi);
                            dll.connect(); // bağlantı kaybolduğu için yeniden bağlanmaya çalışalım
                        }
                        //else if (_BaglantiVarMi == BaglantiDurumu.BaglantiKayboldu || _BaglantiVarMi == BaglantiDurumu.BaglantiKayboldu)
                        //{

                        //}
                    }
                    Thread.Sleep(1500);
                }
            }
        }



        public object lokcTaken = new object();




        public class OKCDrumlari : IDisposable
        {
            public static Tremol.FP.Status DURUM;

            public bool FisAcik;
            public bool PilZayif;
            public bool TarihYanlis;
            public bool MaliOlmayanFisAcik;
            public bool ZRaporuAlinmali;
            public bool PrinterMesgul;
            public bool PrinterYazdiriyor;
            public bool KagitBitti;

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            public void Getir()
            {
                try
                {
                    DURUM = BmsSdkDLL.BmsSdkLib.fp.GetStatus();
                    FisAcik = DURUM.OpenFiscalReceipt;
                    PilZayif = DURUM.PrinterLowVoltage;
                    TarihYanlis = DURUM.IncorectDate;
                    MaliOlmayanFisAcik = DURUM.OpenNonFiscalReceipt;
                    ZRaporuAlinmali = DURUM.ReportsAccumulationOverflowWarning24;
                    PrinterMesgul = DURUM.PrinterBusy;
                    PrinterYazdiriyor = DURUM.PrinterPrinting;
                    KagitBitti = DURUM.PrinterNoPaper;
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
        }

        public class OKCFisBilgileri : IDisposable
        {
            public string UrunAdi { get; set; }
            public string PLU { get; set; }
            public string Birimi { get; set; }
            public float Fiyati { get; set; }
            public float Miktari { get; set; }


            public OKCFisBilgileri(string UrunAdi, string PLU, string Birimi, float Fiyati, float Miktari)
            {
                this.UrunAdi = UrunAdi;
                this.PLU = PLU;
                this.Birimi = Birimi;
                this.Fiyati = Fiyati;
                this.Miktari = Miktari;
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }

        public List<OKCFisBilgileri> YazdirilacakFisBilgileri;


        public void OkcyUrunleriYazidir() // essiz numarayı burada üretiyor
        {
            lock (lokcTaken)
            {

                okcDurumlari.Getir();
                if (okcDurumlari.FisAcik)
                {
                    MessageBox.Show("Şuan Satış var \rnÖdemesini Tamamlanyın Önce");
                    return;
                }
                if (okcDurumlari.MaliOlmayanFisAcik)
                {
                    MessageBox.Show("Mali olmayan fiş açık");
                }

                //if ((dll.getStatus() as String[])[4] == "[OpenFiscalReceipt][Mali Fis Açik]")
                //{
                //    //MessageBox.Show("Şuan Satış var");
                //}
                //else if ((dll.getStatus() as String[])[4] == "[NonZeroDailyReport][Satis Islemi baslatildi]")
                {
                    if (string.Empty == EssizNumaraUret())
                    {

                    }
                    else
                    {

                    }
                }
                try
                {
                    for (int i = 0; i < YazdirilacakFisBilgileri.Count; i++)
                    {
                        // geri dönene şey her satışta fişteki tutar
                        decimal ahandaa = dll.SellItem(YazdirilacakFisBilgileri[i].UrunAdi, YazdirilacakFisBilgileri[i].PLU, YazdirilacakFisBilgileri[i].Birimi, YazdirilacakFisBilgileri[i].Fiyati, YazdirilacakFisBilgileri[i].Miktari);
                        if (ahandaa != 0)
                        {
                            //MessageBox.Show("1   - " + ahandaa.ToString());
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (ex.Message == "The Fiscal Printer is busy;t.l.")
                    {
                        MessageBox.Show("Yazıcı Meşgul");
                    }
                    else if (ex.Message == "FP: OK; Command: Illegal.")
                    {
                        MessageBox.Show("Yeni Eşsiz Numara Üretilmemiş");
                    }
                    else if (ex.Message == "GMP3 Error!GMP3 Initialization procedure required!")
                    {
                        MessageBox.Show("OKC Bağlantısı Yok");
                    }
                    else
                    {
                        MessageBox.Show("Başka bir hata" + Environment.NewLine + ex.Message);
                    }
                }
            }
        }



        string EssizNumaraUret()
        {
            try
            {
                string EssizNumara = dll.GenerateNewUnqNum();

                bool DonenBool = dll.setUnqNum(EssizNumara);
                if (DonenBool == false)
                {
                    MessageBox.Show("false döndü");
                }
                int returnValue = 0;
                //ThOkcISlemleri = new Thread(new ThreadStart(dll.openReceipt((int)(BmsSdkDLL.Parameters.SaleType.Sales), false)))
                returnValue = dll.openReceipt((int)(BmsSdkDLL.Parameters.SaleType.Sales), false);
                if (returnValue != 0)
                {
                    MessageBox.Show("retun 0 dan farklı gelsdi");
                }
                return EssizNumara;
            }
            catch (Exception ex)
            {
                if (ex.Message == "FP: Open fiscal receipt; Command: Illegal.")
                {
                    MessageBox.Show("Açıkta fiş Var, yani eşsiz numara üretilmiş zaten. Önce Ödemesini tamamla");
                }
                else if (ex.Message == "GMP3 Error!GMP3 Initialization procedure required!")
                {
                    MessageBox.Show("OKC Bağlantısı Yok");
                }
                else
                {
                    MessageBox.Show("Başka bir hata" + Environment.NewLine + ex.Message);
                }
                return string.Empty;
            }
        }

        public void VerisyonBilgisi()
        {
            dll.getDemoSDKVersionCSharp();
            dll.getDemoSDKVersion();
            dll.getStatusLastException();
        }

        public void OKCFisiNakitKapat(int FaturaID)
        {
            OKCOdemeIslemleri = new Thread(new ParameterizedThreadStart(OKCNakitKapat));
            OKCOdemeIslemleri.Start(FaturaID);
        }

        /// <summary>
        /// Eğer ödeme tutarı Fatura tutarı ile aynı ise
        /// </summary>
        /// <param name="OdemeTutari"></param>
        void OKCNakitKapat(object FaturaID)
        {
            try
            {
                //lstExecption.Items.Add("openReceipt --> " + returnValue.ToString());
                //tabControlDLL.SelectedTab = tabPageSales;
                lock (lokcTaken)
                {
                    OKCSonFisNoBul(); // burada sıradaki fiş bilgilerini buluyoruz
                    int aahnda;
                    aahnda = dll.closeReceipt();
                    if (aahnda != 0)
                    {
                        MessageBox.Show(" ahanda");
                    }

                    ZnoVeFisNoyuFaturayaKaydet((int)FaturaID, (int)z_num, (int)rcp_num); // burada bulunan fiş bilgilerini Fatura Tablosuna kaydediyoruz.
                    ZRep();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "FP: OK; Command: Illegal.")
                {
                    MessageBox.Show("Ödemesi Tamamlanmayan Bir fiş yok");
                }
                else
                {
                    MessageBox.Show("Başka bir hata" + Environment.NewLine + ex.Message);
                }
                //lstExecption.Items.Add("openReceipt --> " + ex.StackTrace.ToString());
            }
        }
        Thread OKCOdemeIslemleri;




        public BmsDll4Delphi.BmsDllForDelphi dll = new BmsDll4Delphi.BmsDllForDelphi();



        public uint rcp_num = 0;
        public uint z_num = 0;
        public uint eku_num = 0;

        public void OKCSonFisNoBul()
        {
            try
            {
                lock (lokcTaken)
                {
                    //dll.ZRepData();
                    uint rcp_num = 0;
                    uint z_num = 0;
                    uint eku_num = 0;
                    dll.getFiscalInformation(out rcp_num, out z_num, out eku_num);

                    this.rcp_num = rcp_num;
                    this.z_num = z_num;
                    this.eku_num = eku_num;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void ZnoVeFisNoyuFaturayaKaydet(int FaturaID, int Zno, int FisNo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("update Fatura set OkcZNo = @OkcZNo, OkcFisNo = @OkcFisNo where FaturaID = @FaturaID", SqlConnections.GetBaglanti()))
                {
                    cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
                    cmd.Parameters.Add("@OkcZNo", SqlDbType.Int).Value = Zno;
                    cmd.Parameters.Add("@OkcFisNo", SqlDbType.Int).Value = FisNo;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fiş Bilgilerini Fatura Tablosuna yazarken hata");
            }
        }

        public void ZRep()
        {
            MessageBox.Show(dll.ZRepData());
        }

        public void SonFisiTekrarYazdir()
        {
            dll.PrintDuplicate();
        }
        public void KrediKartiIleOde(float OdemeTutari)
        {
            try
            {
                lock (lokcTaken)
                {

                    int aha = dll.payWithBankCard(OdemeTutari);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ahanda hata");
            }
        }


        public void FisiIptalEt()
        {
            try
            {
                int ahahanda = dll.cancelFR();
                if (ahahanda != 0)
                {
                    MessageBox.Show("2 buradan 0 dönmedi");
                }

            }
            catch (Exception ex)
            {
                if (ex.Message == "FP: OK; Command: Illegal.")
                {
                    MessageBox.Show("İptal edilecek Satış Fiş yok");
                }
            }

        }


        public void OKCNakitOde2(float OdemeTutari)
        {
            try
            {
                int aahnda;
                float NakitOdeme = OdemeTutari;
                aahnda = dll.payInCash(NakitOdeme);
                if (aahnda != 0)
                {
                    MessageBox.Show("ahanda 1");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "FP: OK; Command: Illegal.")
                {
                    MessageBox.Show("Ödemesi Tamamlanmayan Bir fiş yok");
                }
                else if (ex.Message == "FP: Bill payment finished; Open receipt; Command: Illegal.")
                {
                    MessageBox.Show("Fiş Tutarından daha fazla ödeme yapılamaz");
                }
                else
                {
                    MessageBox.Show("Başka bir hata" + Environment.NewLine + ex.Message);
                }
            }
        }


    }
}
