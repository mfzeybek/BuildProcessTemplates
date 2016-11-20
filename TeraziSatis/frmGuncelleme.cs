using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TeraziSatis
{
    public partial class frmGuncelleme : DevExpress.XtraEditors.XtraForm
    {
        public frmGuncelleme()
        {
            InitializeComponent();
        }

        private void Guncelleme_Load(object sender, EventArgs e)
        {


            //File.Copy(@"\\192.168.2.16\Public\TeraziGuncellemeDosyalari\Debug\TeraziSatis.exe", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Debug\TeraziSatis.exe", true);
            //File.Copy(@"\\192.168.2.16\Public\TeraziGuncellemeDosyalari\Debug\clsTablolar.dll", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Debug\clsTablolar.dll", true);
            //File.Copy(@"\\192.168.2.16\Public\TeraziGuncellemeDosyalari\Debug\clsTablolar.pdb", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Debug\clsTablolar.pdb", true);


            //File.Copy(@"E:\ARESV2\ARES\BuildProcessTemplates\TeraziSatis\bin\Debug\clsTablolar.dll", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Debug\clsTablolar.dll", true);
            //File.Copy(@"E:\ARESV2\ARES\BuildProcessTemplates\TeraziSatis\bin\Debug\clsTablolar.dll", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Debug\clsTablolar.dll", true);




            List<string> klasor = new List<string>();
            DirectoryInfo di = new DirectoryInfo(@"\\192.168.2.16\Public\TeraziGuncellemeDosyalari\AresTerazi\");
            DirectoryInfo[] getdir = di.GetDirectories();



            foreach (DirectoryInfo veri in getdir)
            {
                klasor.Add(veri.ToString());

                if (veri.ToString().Split('_')[0].ToString() == "Debug (ver" && Convert.ToInt32(Program.VersiyonNumarasi) < Convert.ToInt32(veri.ToString().Split('_')[1].ToString().Trim(')')))
                {
                    lblGuncellemeVarMi.Text = "Var Hamısına Yeni Sürüm No : ";
                    lblGuncellemeVarMi.Text += veri.ToString().Split('_')[1].ToString().Trim(')');
                    GuncellemeDosyalarininYolu = @"\\192.168.2.16\Public\TeraziGuncellemeDosyalari\AresTerazi\" + veri.ToString() + @"\";
                    simpleButton1.Enabled = true;
                    break;
                }

                lblGuncellemeVarMi.Text = "Yeni Sürüm Yok";
            }
        }

        string GuncellemeDosyalarininYolu = "";

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(Guncelle));
            t.Start();



            Application.Exit();

            //Guncelle();
        }
        void Guncelle()
        {
            try
            {
                Application.Run(new frmGuncelleme2(GuncellemeDosyalarininYolu));
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
