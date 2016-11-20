using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;


namespace clsTablolar.TeraziSatisClaslari
{
    public class csTerazidenMiktarAl : IDisposable
    {
        public void Dispose()
        {
            sp1.Close();
            th1.Abort();
            GC.SuppressFinalize(this);
        }

        public bool MiktarAlmaDurumu = true;

        public decimal OkunanAnlikMiktar = 0;
        public decimal OkunanSabitMiktar = 0;
        private decimal OkunanAnlikMiktarOnceki = 0;

        // TeraziTipi

        // 1 se Cas TErazi
        // 2 se Baster
        // 3 ise Wtm 500 (örnek gelen değerer "ST,GS,   0.000kg", tabi bu format cihazdan değiştirilebiliyor 3 farklı format var)  
        // 4 ise Wtm 500 (örnek gelen değerer "S  0.284kg\r", tabi bu format cihazdan değiştirilebiliyor 3 farklı format var)  



        int TeraziTipi = 2;



        // Teraziden Mitkarı sürekli oku
        public delegate void dlg_TerazidenSurekliMiktar(decimal OkunanAnlikMiktar);
        public dlg_TerazidenSurekliMiktar TerazidekiMiktarAl;


        // sabit miktar değiştiğinde Burası tetiklensin
        public delegate bool dlg_TerazidekiSabitMiktar(decimal OkunanSabitMiktar);
        public dlg_TerazidekiSabitMiktar SabitMiktarAl;


        public delegate void dlg_MesjGonder(string str);
        public dlg_MesjGonder MesajGonder;

        public enum TeraziBaglantiDurumu
        {
            BagliVeMiktarlarAliniyor,
            BagliDegil
        }

        public delegate void dlg_TeraziBaglantiDurmu(TeraziBaglantiDurumu BaglnatiDurmu);
        public dlg_TeraziBaglantiDurmu BaglantiDurmu;

        public Thread th1;

        public csTerazidenMiktarAl()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
        }

        public void MiktarAlamayaBasla(string BagNok, int TeraziModel)
        {
            try
            {
                TeraziTipi = TeraziModel;
                MiktarAlmaDurumu = true;
                BaglantiNoktasi = BagNok;
                if (TeraziModel == 1 || TeraziTipi == 3 || TeraziTipi == 4)
                    th1 = new Thread(new ThreadStart(TerazidenMiktarAl));
                else if (TeraziModel == 2)
                    th1 = new Thread(new ThreadStart(TerazidenMiktarAl2));
                th1.Name = "Thread Name = csTerazidenMiktarAl_daOlusturulan th1 Thread";
                th1.SetApartmentState(ApartmentState.MTA);
                th1.Priority = ThreadPriority.Lowest;
                th1.Start();
            }
            catch (Exception hh)
            {
                MesajGonder(hh.StackTrace);
            }
        }


        SerialPort sp1;
        string BaglantiNoktasi;
        //public object MiktarAlmayiKilitle = new object();
        // Bu sadece OkunanAnlıkmiktarı ve OkunanSabitMiktar ı doldursun
        void TerazidenMiktarAl() // demo modu iptal ediyorum şimdilkik
        {
            Thread.Sleep(900);
            using (sp1 = new SerialPort(BaglantiNoktasi))
            {
                sp1.ReadTimeout = 900;
                if (TeraziTipi == 1)
                    sp1.BaudRate = 9600;
                else if (TeraziTipi == 3)
                    sp1.BaudRate = 38400;

                try
                {
                    if (!sp1.IsOpen) // comport u açık değilse açıyoruz
                        sp1.Open();
                }
                catch (Exception)
                {
                    MesajGonder("Terazi Hatalı Bağlı");
                    //MiktarAlmaDurumu = false;
                }

                try
                {
                    string OkunanMiktar = "";
                    while (true)
                    {
                        //if (sp1.IsOpen)
                        //    sp1.Close();

                        while (MiktarAlmaDurumu)
                       {
                            try
                            {
                                if (sp1.IsOpen)
                                {
                                    //sp1.WriteLine("A");

                                    //char[] buuf = {'f', 'f'};
                                    sp1.DiscardInBuffer();
                                    //sp1.DiscardNull = true ;
                                    //sp1.WriteLine("RW");
                                    //sp1.WriteLine("01");

                                    //sp1.WriteLine("RW");
                                    //byte[] asciiBytes = System.Text.Encoding.ASCII.GetBytes("D00RW\r" + Environment.NewLine);
                                    //sp1.
                                    //sp1.Write(asciiBytes, 0, asciiBytes.Length);
                                    //sp1.WriteLine("D00KW" + Environment.NewLine);

                                    //sp1.WriteLine("t");
                                    //sp1.WriteLine("01345");

                                    //string sdsd = sp1.ReadExisting();
                                    OkunanMiktar = sp1.ReadLine();
                                    //sp1.Read(OkunanMiktar.ToChrArray(), 0, 2);
                                    //OkunanMiktar = sp1.ReadExisting();


                                    //if (Monitor.TryEnter(MiktarAlmayiKilitle, 10))

                                    if (TeraziTipi == 3)
                                        OkunanAnlikMiktar = Convert.ToDecimal(OkunanMiktar.Substring(OkunanMiktar.Length - 10, OkunanMiktar.Length - 10).Replace('.', ','));
                                    else if (TeraziTipi == 1)
                                        OkunanAnlikMiktar = Convert.ToDecimal(OkunanMiktar.Substring((OkunanMiktar.Length - 9), OkunanMiktar.Length - 5).Replace('.', ','));
                                    else if (TeraziTipi == 4)
                                        OkunanAnlikMiktar = Convert.ToDecimal(OkunanMiktar.Substring((OkunanMiktar.Length - 10), OkunanMiktar.Length - 15).Replace('.', ','));




                                    if (OkunanAnlikMiktarOnceki != OkunanAnlikMiktar)
                                    {
                                        OkunanAnlikMiktarOnceki = OkunanAnlikMiktar;
                                        TerazidekiMiktarAl(OkunanAnlikMiktar);
                                    }

                                    if (OkunanMiktar.StartsWith("S") && OkunanSabitMiktar != OkunanAnlikMiktar) // TERAZİDEN GELEN VERİ S İLE BAŞLIYORSA SABİT ANLAMINDA DIR
                                    { // s ile başlıyorsa okunan anlık miktar okunan sabit miktar olabilir
                                        // okunan anlık miktar ve okunan sabit miktar aynı ise alma ama neden ??

                                        //if (SabitMiktarAl(OkunanAnlikMiktar))
                                        {
                                            SabitMiktarAl(OkunanAnlikMiktar);
                                            OkunanSabitMiktar = OkunanAnlikMiktar;
                                        }
                                        //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit) // terazideki kilite bağlıydı önceki sürümde
                                    }

                                    //lock (MiktarAlmayiKilitle)

                                    TerazininBaglantisiKoptu_MesajiGonderildiMi = false;

                                    if (BaglantiSayisi == 2)
                                    {
                                        BaglantiDurmu(TeraziBaglantiDurumu.BagliVeMiktarlarAliniyor);
                                        BaglantiSayisi = 0;
                                    }
                                    else
                                        BaglantiSayisi++;
                                    Thread.Sleep(10);
                                    //sp1.DiscardInBuffer();
                                }
                                else
                                {
                                    Thread.Sleep(10);

                                    try { sp1.Open(); }
                                    catch (TimeoutException)
                                    {
                                        if (!TerazininBaglantisiKoptu_MesajiGonderildiMi)
                                        {
                                            //MçlesajGonder("Terazinin Baglantisi Koptu");
                                            TerazininBaglantisiKoptu_MesajiGonderildiMi = true;
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            catch (TimeoutException ex2)
                            {
                                //MesajGonder("TimeoutEXception \n" + OkunanMiktar);
                            }
                            catch (FormatException)
                            {
                                //MesajGonder("Giriş dizesi hataı hamısına \n" + OkunanMiktar);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                //MesajGonder("Giriş dizesi hataı hamısına\n" + OkunanMiktar);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                //MesajGonder("Giriş dizesi hataı hamısına\n" + OkunanMiktar);
                            }
                            catch (System.ArgumentException)
                            {
                                //MesajGonder("Giriş dizesi hataı hamısına\n" + OkunanMiktar);
                            }
                            catch (Exception ex)
                            {
                                //if (th1.ThreadState == ThreadState.Running)
                                //    th1.Suspend();
                                //if (!(ex is System.TimeoutException))
                                //if (!TerazininBaglantisiKoptu_MesajiGonderildiMi)

                                //MiktarAlmaDurumu = false;
                                if (!TerazininBaglantisiKoptu_MesajiGonderildiMi)
                                {
                                    //MesajGonder("Terazinin Baglantisi Koptu");
                                    TerazininBaglantisiKoptu_MesajiGonderildiMi = true;
                                }

                                BaglantiDurmu(TeraziBaglantiDurumu.BagliDegil);
                                BaglantiSayisi = 0;
                                //Thread.Sleep(30);
                            }
                        } // burada alttaki while bitiyor falan filan buraya açıklama yazarsın
                        Thread.Sleep(10);
                        //sp1.DiscardInBuffer();
                    }
                }
                catch (Exception hata)
                {
                    BaglantiDurmu(TeraziBaglantiDurumu.BagliDegil);
                    BaglantiSayisi = 0;


                    if (hata.HResult != -2147023901) // bu önemsiz bir kahve
                    {

                    }
                    //MessageBox.Show("hatayı bildir");
                }
            }
        }

        string[] ports = SerialPort.GetPortNames();
        public void ComPortBul() // aslında comport ve model numarasını aynı anda bulması gerekiyor.
        {

            // Get a list of serial port names.
            

            Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.
            foreach (string port in ports)
            {
                
            }
            
        }
        public void TeraziModeliBul()
        {
            foreach (string port in ports)
            {
                SerialPort s = new SerialPort(port);
                s.ReadLine();
            }
        }


        public void Sifirla()
        {
            sp1.WriteLine("D00KT" + Environment.NewLine); // BU ÇALIŞIYOR COMMAND TYPE 2 DE

            //sp1.WriteLine("D00KT" + Environment.NewLine); // BU ÇALIŞIYOR COMMAND TYPE 2 DE
            //sp1.WriteLine("D00KW" + Environment.NewLine);            
            //string GHJ=  sp1.ReadLine();
        }

        bool TerazininBaglantisiKoptu_MesajiGonderildiMi = false;
        int BaglantiSayisi = 0;

        void TerazidenMiktarAl2()
        {
            using (sp1 = new SerialPort(BaglantiNoktasi))
            {
                try
                {
                    sp1.ReadTimeout = 3000;
                    if (!sp1.IsOpen) // comport u açık değilse açıyoruz
                        sp1.Open();
                }
                catch (Exception)
                {
                    MesajGonder("Terazi Hatalı Bağlı");
                    //MiktarAlmaDurumu = false;
                }

                try
                {
                    string OkunanMiktar = "";
                    while (true)
                    {
                        while (MiktarAlmaDurumu) //aslında miktar Alma durumu hiç bir zaman false olmayacaksa hiç gerek yok aslında
                        {
                            try
                            {
                                if (sp1.IsOpen)
                                {
                                    sp1.WriteLine("A");
                                    OkunanMiktar = sp1.ReadLine();

                                    try
                                    {
                                        OkunanAnlikMiktar = Convert.ToDecimal(OkunanMiktar.Substring(6, 7).Replace('.', ','));
                                    }
                                    catch (Exception hata)
                                    {
                                        sp1.WriteLine("A");
                                    }

                                    if (OkunanMiktar.StartsWith("S")) // TERAZİDEN GELEN VERİ S İLE BAŞLIYORSA SABİT ANLAMINDA DIR
                                    { // s ile başlıyorsa okunan anlık miktar okunan sabit miktar olabilir
                                        if (OkunanSabitMiktar != OkunanAnlikMiktar)  // okunan anlık miktar ve okunan sabit miktar aynı ise alma ama neden ??
                                        {
                                            OkunanSabitMiktar = OkunanAnlikMiktar;

                                            lock (TeraziSatisClaslari.csthreadsafe.ThreadKilit)
                                                SabitMiktarAl(OkunanSabitMiktar);
                                        }
                                    }

                                    TerazidekiMiktarAl(OkunanAnlikMiktar);
                                    TerazininBaglantisiKoptu_MesajiGonderildiMi = false;

                                    if (BaglantiSayisi == 2)
                                    {
                                        BaglantiDurmu(TeraziBaglantiDurumu.BagliVeMiktarlarAliniyor);
                                        BaglantiSayisi = 0;
                                    }
                                    else
                                        BaglantiSayisi++;
                                    Thread.Sleep(30);
                                }
                                else
                                {
                                    try { Thread.Sleep(30); }
                                    catch (Exception) { }
                                    try
                                    {
                                        sp1.Open();
                                        sp1.WriteLine("A");
                                    }
                                    catch (Exception ex)
                                    {
                                        //if (Monitor.IsEntered(MiktarAlmayiKilitle))
                                        //    Monitor.Exit(MiktarAlmayiKilitle);

                                        if (!TerazininBaglantisiKoptu_MesajiGonderildiMi)
                                        {
                                            MesajGonder("Terazinin Baglantisi Koptu");
                                            TerazininBaglantisiKoptu_MesajiGonderildiMi = true;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (!TerazininBaglantisiKoptu_MesajiGonderildiMi)
                                {
                                    MesajGonder("Terazinin Baglantisi Koptu");
                                    TerazininBaglantisiKoptu_MesajiGonderildiMi = true;
                                }
                                try { Thread.Sleep(30); }
                                catch (Exception) { }
                            }
                        }
                    }
                }
                catch (Exception hata)
                {
                    //MesajGonder(hata.StackTrace);
                    if (hata.HResult != -2147023901) // bu önemsiz bir kahve
                    {

                    }
                    //MessageBox.Show("hatayı bildir");
                }
            }
        }

        void Beklet()
        {
            th1.Suspend();
        }


        public void portuDurdurhamisina()
        {
            try
            {
                sp1.Close();
            }
            catch (Exception)
            {
                MesajGonder("Burada Hata mı mk ya");
            }
        }
    }
}
