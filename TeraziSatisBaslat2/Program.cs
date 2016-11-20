using System;
using System.Windows.Forms;



namespace TeraziSatisBaslat2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //BonusSkins.Register();

            foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("TeraziSatis"))
            {
                proc.Kill();
            }
            System.Diagnostics.Process.Start(Application.StartupPath + "\\TeraziSatis.exe");

            foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("TeraziSatisBaslat2"))
            {
                if (System.Diagnostics.Process.GetProcessesByName("TeraziSatisBaslat2").Length > 1)
                {
                    proc.Kill();
                }
            }


            //System.Diagnostics.Process.Start(@"C:\Users\Fatih\Desktop\ARESV2\ARES\BuildProcessTemplates\TeraziSatis\bin\Debug" + "\\TeraziSatis.exe");

            Application.Run(new frmNotifi());

            //Application.Exit();
        }
    }
}

