using System;
using System.Windows.Forms;
using System.IO;

namespace TeraziSatisGuncelleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //AhandaGuncellenecekProgram = ahanda;
            InitializeComponent();
        }


        public enum GuncellenecekProgram
        {
            Ares = 1,
            Terazi = 2,
            Kasa = 3
        }

        public GuncellenecekProgram AhandaGuncellenecekProgram;


        // Güncellemelerde config dosyası yani ayar dosyası güncellenmez, ama istenirse onunda güncellenebilmesi bir için bişiler yapılabilir



        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "3";

            if (AhandaGuncellenecekProgram == GuncellenecekProgram.Ares)
            {
                label1.Text = "Güncellenecek Program Ares";
            }
            else if (AhandaGuncellenecekProgram == GuncellenecekProgram.Kasa)
            {
                label1.Text = "Güncellenecek Program Kasa";
            }
            else if (AhandaGuncellenecekProgram == GuncellenecekProgram.Terazi)
            {
                label1.Text = "Güncellenecek Program Terazi";
            }
        }
        // burada devexpressten bişi kullanma

        //public void YeniGuncellemeVarmi()
        //{
        //    //List<string> klasor = new List<string>();
        //    DirectoryInfo di = new DirectoryInfo(@"\\192.168.2.16\Public\TeraziGuncellemeDosyalari\AresTerazi\");
        //    DirectoryInfo[] getdir = di.GetDirectories();



        //    foreach (DirectoryInfo veri in getdir)
        //    {
        //        //klasor.Add(veri.ToString());

        //        if (veri.ToString().Split('_')[0].ToString() == "Debug (ver" && Convert.ToInt32(Program.VersiyonNumarasi) < Convert.ToInt32(veri.ToString().Split('_')[1].ToString().Trim(')')))
        //        {
        //            if (DialogResult.Yes == MessageBox.Show(this, "Yeni Guncelleme Var", "Güncellenesin mi??", MessageBoxButtons.YesNo))
        //            {
        //                //lblGuncellemeVarMi.Text = "Var Hamısına Yeni Sürüm No : ";
        //                //lblGuncellemeVarMi.Text += veri.ToString().Split('_')[1].ToString().Trim(')');
        //                GuncellemeYolu = @"\\192.168.2.16\Public\TeraziGuncellemeDosyalari\AresTerazi\" + veri.ToString() + @"\";

        //                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(Guncelle));
        //                t.Start();

        //                this.Close();
        //                break;
        //            }
        //        }

        //        //lblGuncellemeVarMi.Text = "Yeni Sürüm Yok";
        //    }
        //}
        int KopyalananDosyaSayisi = 0;

        public void CopyDirectory(string SourceFolderPath, string TargetFolderPath, bool HizliGuncelleme)
        {
            try
            {
                String[] files;
                if (TargetFolderPath[TargetFolderPath.Length - 1] != Path.DirectorySeparatorChar)
                {
                    TargetFolderPath += Path.DirectorySeparatorChar;
                }

                // parametre olarak verilen hedef dizin yok ise oluştur.
                if (!Directory.Exists(TargetFolderPath))
                {
                    Directory.CreateDirectory(TargetFolderPath);
                }

                // kaynak dizindeki tüm alt dizin ve dosya adlarını al.
                files = Directory.GetFileSystemEntries(SourceFolderPath);

                foreach (string file in files)
                {
                    // alt dizinler
                    if (Directory.Exists(file))
                    {
                        // metot öz yineleme (recursive) kullanarak kaynak dizinde dosya bulunduğu
                        // müddetçe dizindeki tüm dosyalar hedef dizine kopyalanmaya devam ediyor.
                        CopyDirectory(file, TargetFolderPath + Path.GetFileName(file), HizliGuncelleme);
                    }
                    // dizindeki dosyalar
                    else
                    {
                        if (HizliGuncelleme)
                        {
                            if (Path.GetFileName(file) == "Aresv2.exe"
                            && Path.GetFileName(file) != "clsTablolar.dll"
                            && Path.GetFileName(file) != "TeraziSatisGuncelleme.exe"
                            && Path.GetFileName(file) != "clsTablolar.dll"
                            && Path.GetFileName(file) != "clsTablolar.dll"

                            )
                            {
                                File.Copy(file, TargetFolderPath + Path.GetFileName(file), true);
                                KopyalananDosyaSayisi++;
                            }
                        }
                        else
                        {

                            if (Path.GetFileName(file) != "TeraziSatis.exe.config"
                            && Path.GetFileName(file) != "Loglar.db"
                            && Path.GetFileName(Path.GetDirectoryName(file)) != "Loglar"
                            && Path.GetFileName(Path.GetDirectoryName(file)) != "TeraziGuncelleme"
                            && Path.GetFileName(file) != "TeraziSatis.vshost.exe"
                            && Path.GetFileName(file) != "Aresv2.exe.config"
                            && Path.GetFileName(file) != "KasaSatis.exe.config"
                            && Path.GetFileName(file) != "YaziciAyarlari.sqlite"
                            )
                            {
                                File.Copy(file, TargetFolderPath + Path.GetFileName(file), true);
                                KopyalananDosyaSayisi++;
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void btnTamGuncelleme_Click(object sender, EventArgs e)
        {
            if (AhandaGuncellenecekProgram == GuncellenecekProgram.Ares)
            {
                CopyDirectory(@"\\192.168.2.8\AresSonSurumu\Debug\", Directory.GetParent(Application.StartupPath).FullName, false);
                MessageBox.Show("Kopyalanan Dosya Sayısı : " + KopyalananDosyaSayisi.ToString());
                System.Diagnostics.Process.Start(Directory.GetParent(Application.StartupPath).FullName + @"\Aresv2.exe");
            }
            else if (AhandaGuncellenecekProgram == GuncellenecekProgram.Kasa)
            {
                CopyDirectory(@"\\192.168.2.8\TeraziDosyalari\Kasa\Debug\", Directory.GetParent(Application.StartupPath).FullName, false);
                MessageBox.Show("Kopyalanan Dosya Sayısı : " + KopyalananDosyaSayisi.ToString());
                System.Diagnostics.Process.Start(Directory.GetParent(Application.StartupPath).FullName + @"\KasaSatis.exe");
            }
            else if (AhandaGuncellenecekProgram == GuncellenecekProgram.Terazi)
            {
                CopyDirectory(@"\\192.168.2.8\TeraziDosyalari\Debug\", Directory.GetParent(Application.StartupPath).FullName, false);
                MessageBox.Show("Kopyalanan Dosya Sayısı : " + KopyalananDosyaSayisi.ToString());
                System.Diagnostics.Process.Start(Directory.GetParent(Application.StartupPath).FullName + @"\TeraziSatisBaslat2.exe");
            }
            label1.Text = "Güncelleme Tamamlandi";
            Close();
            Application.Exit();
        }

        private void btnHizliGuncelleme_Click(object sender, EventArgs e)
        {

        }

        private void btnBetaSurumKur_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bata sürüm Yok");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Copy(@"\\192.168.2.8\TeraziDosyalari\Debug\TeraziSatis.exe.config", Directory.GetParent(Application.StartupPath).FullName + @"\TeraziSatis.exe.config", true);
            File.Copy(@"\\192.168.2.8\TeraziDosyalari\Debug\TeraziSatis.vshost.exe", Directory.GetParent(Application.StartupPath).FullName + @"\TeraziSatis.vshost.exe", true);
        }
    }
}
