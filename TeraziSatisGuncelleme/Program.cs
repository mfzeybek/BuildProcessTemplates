using System;
using System.Windows.Forms;

namespace TeraziSatisGuncelleme
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] MyParameters)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frm = new Form1();
            frm.AhandaGuncellenecekProgram = (Form1.GuncellenecekProgram)Convert.ToInt32(MyParameters[0]);
            Application.Run(frm);
        }
    }
}
