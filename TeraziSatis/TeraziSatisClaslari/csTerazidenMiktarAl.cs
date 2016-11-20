using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;


namespace TeraziSatis.cls
{
    public class csTerazidenMiktarAl : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MiktarAlmaDurumu = true;

        public decimal OkunanAnlikMiktar = 0;
        public decimal OkunanSabitMiktar = 0;


        // Teraziden Mitkarı sürekli oku
        public delegate void dlg_TerazidenSurekliMiktar(decimal OkunanAnlikMiktar);
        public dlg_TerazidenSurekliMiktar TerazidekiMiktarAl;


        // sabit miktar değiştiğinde Burası tetiklensin
        public delegate void dlg_TerazidekiSabitMiktar(decimal OkunanSabitMiktar);
        public dlg_TerazidekiSabitMiktar SabitMiktarAl;

        Thread th1;

        public csTerazidenMiktarAl()
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
        }

        public void MiktarAlamayaBasla()
        {
            try
            {
                th1 = new Thread(new ThreadStart(TerazidenMiktarAl));
                th1.Start();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        SerialPort sp1;

        // Bu sadece OkunanAnlıkmiktarı ve OkunanSabitMiktar ı doldursun
        void TerazidenMiktarAl()
        {
            using (sp1 = new SerialPort(TeraziSatis.Properties.Settings.Default.TeraziBagNok))
            {
                if (TeraziSatis.Properties.Settings.Default.DemoMod == true) // Demo modda ise => Demo mode true ise Terazi bağlantısı olmadan çalışabilecek demektir
                {// demo mod ile ilgili hiçbir çalışma yapmadın daha

                }
                try
                {
                    if (!sp1.IsOpen) // comport u açık değilse açıyoruz
                        sp1.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Terazi Hatalı Bağlı");
                }

                try
                {
                    string OkunanMiktar = "";
                    while (MiktarAlmaDurumu)
                    {
                        OkunanMiktar = sp1.ReadLine();
                        OkunanAnlikMiktar = Convert.ToDecimal(OkunanMiktar.Substring(2, OkunanMiktar.Length - 5).Replace('.', ','));
                        if (OkunanMiktar.StartsWith("S")) // TERAZİDEN GELEN VERİ S İLE BAŞLIYORSA SABİT ANLAMINDA DIR
                        { // s ile başlıyorsa okunan anlık miktar okunan sabit miktar olabilir
                            if (OkunanSabitMiktar != OkunanAnlikMiktar)  // okunan anlık miktar ve okunan sabit miktar aynı ise alma ama neden ??
                            {
                                OkunanSabitMiktar = OkunanAnlikMiktar;
                                SabitMiktarAl(OkunanSabitMiktar);
                            }
                        }
                        TerazidekiMiktarAl(OkunanAnlikMiktar);
                    }
                }
                catch (Exception hata)
                    {
                    if (hata.HResult != -2147023901) // bu önemsiz bir kahve
                    {

                    }
                }
            }
        }

        public void portuDurdurhamisina()
        {
            th1.Abort();
            sp1.Close();
        }


        #region Odemesi Tamamlanan Satisi Listeden Kaldir
        // Odemesi Tamamlanan Satış ı sadece listeden kaldırır onunla ilgili odemesi tamamlandı diye herhangi bir kayıt yapmaz.
        // Odemesi Tamamlanan Satışı listeden kaldırırken olabilecek hataları önlemek için aktif satışın ID si bi kenera yazılır ve bütün bu Id ye erişilmek istendiğinde hrid üzerinden değil buradan erişilir falan filan hamısına işte; yapıcan tabi bunu daha sonra




        #endregion

    }
}
