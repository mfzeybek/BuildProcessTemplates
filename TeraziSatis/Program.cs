using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace TeraziSatis
{
    static class Program
    {

        public static string VersiyonNumarasi = "11";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //public string VerNo = "";

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                Application.Run(new frmTerazi());
            }
            catch (NullReferenceException exep)
            {
                MessageBox.Show("boş referasns hatası hamısına bunu bildir en son en yapıyordun onu da bildir mk");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (InvalidOperationException exee)
            {
                MessageBox.Show("invalit exeption hamısına bunu bildir en son en yapıyordun onu da bildir mk");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Genel bir hata sanırım hamısına");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            finally
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill(); // bunu kaldırırsan program kapatılırken cls tabloları boşa çıkarmıyor;
            }
        }
    }
}