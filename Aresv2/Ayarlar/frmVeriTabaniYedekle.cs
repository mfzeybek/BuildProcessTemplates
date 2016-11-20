using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;

namespace Aresv2.Ayarlar
{
    public partial class frmVeriTabaniYedekle : DevExpress.XtraEditors.XtraForm
    {
        public frmVeriTabaniYedekle()
        {
            InitializeComponent();
        }

        private void frmVeriTabaniYedekle_Load(object sender, EventArgs e)
        {
            //textEdit3.Text = "C:\yedektirlo.bak";


        }

        private void btnYedekle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"
DECLARE @path varchar(100)
DECLARE @day int
DECLARE @date varchar(30)
DECLARE @cmd varchar(250)
DECLARE @DeleteDate datetime
 
---- PARAMETRE TANIMLAMALARI ----
 
SET @path = '\\192.168.2.3\Backup'  -- Backupların saklanacağı klasör yolu.
SET @day = 5             -- Verilen gün sayısından eski backupları siler.
 
---- PARAMETRE TANIMLAMALARI ----
 
SET @date = CONVERT(varchar(16),GETDATE(), 120)
print @date + ' Backup Log'
print ''
SELECT @date = REPLACE(@date,':','')
SELECT @date = REPLACE(@date,' ','')
SELECT @date = REPLACE(@date,'-','')
 
SET @cmd = 'IF DB_ID(''?'')<>2 BACKUP DATABASE [?] TO DISK = ''' + @path + '\?_backup_' + @date + '.bak'' WITH INIT'
EXEC sp_msforeachdb @cmd
 
SET @DeleteDate = DateAdd(day, -@day, GetDate())
EXECUTE master.sys.xp_delete_file 0, @path, N'bak', @DeleteDate, 0
select   @path +'\ARES_backup_' + @date + '.bak'
GO

", SqlConnections.GetBaglanti());
            string DosyaYoluVeAdi = cmd.ExecuteScalar().ToString();

            File.Copy(DosyaYoluVeAdi, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\" + Path.GetFileName(DosyaYoluVeAdi), true);

            //MessageBox.Show("Kopyalanan Dosya Sayısı : " + KopyalananDosyaSayisi.ToString());
            //label1.Text = "Güncelleme Tamamlandi";

            //System.Diagnostics.Process.Start(Directory.GetParent(Application.StartupPath).FullName + @"\TeraziSatis.exe");

        }
    }
}