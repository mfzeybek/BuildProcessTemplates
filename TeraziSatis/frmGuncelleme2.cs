using System;
using System.Windows.Forms;
using System.IO;

namespace TeraziSatis
{
    public partial class frmGuncelleme2 : Form
    {
        public frmGuncelleme2(string guncellemeYolu)
        {
            _guncellemeUolu = guncellemeYolu;
            InitializeComponent();
        }
        string _guncellemeUolu = "";

        private void frmGuncelleme2_Load(object sender, EventArgs e)
        {
            
        }

        public static void CopyDirectory(string SourceFolderPath, string TargetFolderPath)
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
                        CopyDirectory(file, TargetFolderPath + Path.GetFileName(file));
                    }

                    // dizindeki dosyalar
                    else
                    {
                        File.Copy(file, TargetFolderPath + Path.GetFileName(file), true);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CopyDirectory(_guncellemeUolu, Application.StartupPath);
        }
    }
}
