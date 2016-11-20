using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Data;

namespace TeraziSatis
{
    public class csTeraziLogs : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        SQLiteConnection sqlConnect;
        SQLiteCommand sqliteCommand_Insert;
        private void VeriTabaniniOlustur()
        {
            if (!Directory.Exists(Application.StartupPath + @"\Loglar"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Loglar");
            }

            string DbDosya = Application.StartupPath + @"\Loglar\Loglar_" + SystemInformation.ComputerName + "_" + DateTime.Today.ToShortDateString() + ".db";


            SQLiteConnectionStringBuilder connectStr =
            new SQLiteConnectionStringBuilder();
            connectStr.DataSource = DbDosya;
            connectStr.UseUTF16Encoding = true;

            //SQLiteConnection.CreateFile(DbDosya);

            //string dataFile = @"D:\temp\Linq_ve_sqlitetest.db";
            //System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection(@"Data Source=" + DbDosya + ";Version=3;");
            dt = new DataTable();
            dt.Columns.Add("Aciklama");
            dt.Columns.Add("ThreadName");
            dt.Columns.Add("Zaman");
            dt.Columns.Add("Grup");
            dt.Columns.Add("VersiyonNu");
            dt.Columns.Add("BilgisayarAdi");

            try
            {
                sqlConnect =
                new SQLiteConnection(connectStr.ConnectionString);
                {
                    ; // bu çalıştığında Dosya yoksa Oluşturuyor;

                    using (SQLiteCommand sqlCommand =
                    new SQLiteCommand(sqlConnect))
                    {
                        // Veritabanı dosyasının varlğının kontrol&uuml;
                        if (!File.Exists(DbDosya))
                        {


                            sqlConnect.Open();
                            sqlCommand.CommandText = @"--Table: Logs

--DROP TABLE Logs;

CREATE TABLE Logs (
  Logs_ID     integer NOT NULL PRIMARY KEY AUTOINCREMENT,
  Aciklama    nvarchar(500),
  ThreadName  nvarchar(50),
  Zaman       datetime,
  Grup        nvarchar(100),
VersiyonNu        nvarchar(100),
BilgisayarAdi        nvarchar(100)
);";
                            sqlCommand.ExecuteNonQuery();
                        }
                        //if (sqlConnect.State == System.Data.ConnectionState.Closed)
                        //    sqlConnect.Open();

                        sqliteCommand_Insert = new SQLiteCommand(sqlConnect);
                        sqliteCommand_Insert.CommandText = "INSERT INTO Logs " +
                            "(Aciklama, ThreadName, Zaman, Grup, VersiyonNu, BilgisayarAdi)" +
                            " VALUES(@Aciklama, @ThreadName, @Zaman, @Grup, @VersiyonNu, @BilgisayarAdi);";

                        //using (SQLiteTransaction trans =
                        //sqlConnect.BeginTransaction())
                        //{
                        //    // Tablo bilgilerinin silinmesi
                        //    //sqlCommand.CommandText = "Delete From KutuKesit;";
                        //    //sqlCommand.ExecuteNonQuery();
                        //    // Tabloya veri eklenmesi

                        //    //LogYaz()

                        //    sqliteCommand_Insert.ExecuteNonQuery();
                        //    trans.Commit();
                        //}
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        public csTeraziLogs()
        {
            VeriTabaniniOlustur();



            THLlogYaz = new Thread(() => { LogYazz(); });
            THLlogYaz.Name = "logthredi" + i.ToString();
            i++;

            THLlogYaz.Start();
        }
        public enum Grup
        {
            Grupsuz,
            ThreadKilit,
            Hata
        }
        static Thread[] treads;
        static WaitCallback ekle;

        private static DataTable dt;

        Thread THLlogYaz;
        int i = 0;

        public static object BuradaBilenekKilit = new object();


        public static void LogYaz(Grup Grup, string Aciklama)
        {
            DataRow row = dt.NewRow();
            row["Aciklama"] = Aciklama;
            row["Grup"] = Grup.ToString();
            lock (BuradaBilenekKilit)
                dt.Rows.Add(row);
        }

        private void LogYazz()
        {
            while (true)
            {
                if (dt.Rows.Count > 0)
                    //string Threadname = Thread.CurrentThread.Name;
                    lock (this)
                        try
                        {

                            if (sqlConnect.State == System.Data.ConnectionState.Closed)
                                sqlConnect.Open();

                            using (SQLiteTransaction trans =
                            sqlConnect.BeginTransaction())
                            {
                                // Tablo bilgilerinin silinmesi
                                //sqlCommand.CommandText = "Delete From KutuKesit;";
                                //sqlCommand.ExecuteNonQuery();
                                // Tabloya veri eklenmesi
                                sqliteCommand_Insert.Parameters.Add("@Aciklama", System.Data.DbType.String).Value = dt.Rows[0]["Aciklama"].ToString();
                                sqliteCommand_Insert.Parameters.Add("@ThreadName", System.Data.DbType.String).Value = Thread.CurrentThread.Name;
                                sqliteCommand_Insert.Parameters.Add("@Zaman", System.Data.DbType.DateTime).Value = DateTime.Now;
                                sqliteCommand_Insert.Parameters.Add("@Grup", System.Data.DbType.String).Value = dt.Rows[0]["Grup"].ToString();
                                sqliteCommand_Insert.Parameters.Add("@VersiyonNu", System.Data.DbType.String).Value = frmTerazi.VersiyonNo;
                                sqliteCommand_Insert.Parameters.Add("@BilgisayarAdi", System.Data.DbType.String).Value = SystemInformation.ComputerName;

                                sqliteCommand_Insert.ExecuteNonQuery();
                                trans.Commit();
                                lock (BuradaBilenekKilit)
                                {
                                    dt.Rows[0].Delete();
                                    if (dt.Rows.Count == 0)
                                        dt.Clear();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Log Kaydında Hata");
                        }
                Thread.Sleep(1000);
            }
        }
    }
}

