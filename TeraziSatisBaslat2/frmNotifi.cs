using System;
using System.Windows.Forms;
using FarukUNAL;

namespace TeraziSatisBaslat2
{
    public partial class frmNotifi : DevExpress.XtraEditors.XtraForm
    {
        public frmNotifi()
        {
            InitializeComponent();
            DinlenecekTuslariAyarla();
        }

        globalKeyboardHook klavyeDinleyicisi = new globalKeyboardHook();

        private void frmNotifi_Load(object sender, EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            //this.Visible = false;
            //Hide();

        }

        public void DinlenecekTuslariAyarla()
        {
            // hangi tuşları dinlemek istiyorsak burada ekliyoruz
            // Ben burada F,K ve M harflerine basılınca tetiklenecek şekilde ayarladım
            klavyeDinleyicisi.HookedKeys.Add(Keys.VolumeUp);
            //klavyeDinleyicisi.HookedKeys.Add(Keys.K);
            //klavyeDinleyicisi.HookedKeys.Add(Keys.M);

            //basıldığında ilk burası çalışır
            klavyeDinleyicisi.KeyDown += new KeyEventHandler(islem1);
            //basıldıktan sonra ikinci olarak burası çalışır
            klavyeDinleyicisi.KeyUp += new KeyEventHandler(islem2);
        }
        void islem1(object sender, KeyEventArgs e)
        {
            try
            {
                //Yapılmasını istediğiniz kodlar burada yer alacak
                //Burası tuşa basıldığı an çalışır

                foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("TeraziSatis"))
                {
                    proc.Kill();
                }
                System.Diagnostics.Process.Start(Application.StartupPath + "\\TeraziSatis.exe");
                //System.Diagnostics.Process.Start(@"C:\Users\Fatih\Desktop\ARESV2\ARES\BuildProcessTemplates\TeraziSatis\bin\Debug" + "\\TeraziSatis.exe");
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(10000, "hamısına", "Terazi programı başlatıldı", ToolTipIcon.Info);

                //Eğer buraya gelecek olan tuşa basıldığında
                //o tuşun normal işlevi yine çalışsın istiyorsanız
                //e.Handled değeri false olmalı
                //eğer ilgili tuşa basıldığında burada yakalansın
                // ve devamında tuş başka bir işlev gerçekleştirmesin
                //istiyorsanız bu değeri true yapmalısınız
                e.Handled = true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void islem2(object sender, KeyEventArgs e)
        {
            //Yapılmasını istediğiniz kodlar burada yer alacak
            // Burası ilgili tuşlara basılıp çekildikten sonra çalışır



            //Eğer buraya gelecek olan tuşa basıldığında
            //o tuşun normal işlevi yine çalışsın istiyorsanız
            //e.Handled değeri false olmalı
            //eğer ilgili tuşa basıldığında burada yakalansın
            // ve devamında tuş başka bir işlev gerçekleştirmesin
            //istiyorsanız bu değeri true yapmalısınız
            //e.Handled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //toastNotificationsManager1.ShowNotification(1);
                //toastNotificationsManager1.
                //NotifyIcon notifyIcon1 = new NotifyIcon();


                //notifyIcon1.
            }
            catch (Exception ex)
            {

            }
        }
    }
}