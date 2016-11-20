using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;

namespace AresUrunTanitim
{
    public partial class frmConfig : DevExpress.XtraEditors.XtraForm
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            XmlOku();
        }
        private void XmlOku()
        {
            string strPath = Application.StartupPath + @"\AresUrunTanitim.exe.config";
            char tirnak = '"';
            if (File.Exists(strPath))
            {
                FileStream fsConfigFile = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                XmlDocument xdConfigFile = new XmlDocument();
                xdConfigFile.Load(fsConfigFile);
                string strInnerXml = xdConfigFile.DocumentElement.ChildNodes.Item(1).InnerXml;
                string[] arItems = strInnerXml.Split(new string[] { "/>" }, StringSplitOptions.RemoveEmptyEntries);
                string strAresCon = "";
                string strAresUTCon = "";
                if (arItems[0].Contains("AresUrunTanitim.Properties.Settings.DBConStrAres"))
                {
                    strAresUTCon = arItems[0];
                    strAresCon = arItems[1];
                }
                else if (arItems[0].Contains("AresUrunTanitim.Properties.Settings.DBConStrAresUT"))
                {
                    strAresUTCon = arItems[1];
                    strAresCon = arItems[0];
                }

                string[] arDBConStrAres = strAresUTCon.Split(new char[] { tirnak }, StringSplitOptions.RemoveEmptyEntries);
                string[] arDegerlerAres = arDBConStrAres[3].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arDegerlerAres.Length; i++)
                {
                    if (arDegerlerAres[i].Contains("Data Source"))
                        txtAresServer.Text = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
                    else if (arDegerlerAres[i].Contains("Initial Catalog"))
                        txtAresDb.Text = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
                    else if (arDegerlerAres[i].Contains("User ID"))
                        txtAresKullanici.Text = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
                    else if (arDegerlerAres[i].Contains("Password"))
                        txtAresSifre.Text = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
                }

                string[] arDBConStrAresUT = strAresCon.Split(new char[] { tirnak }, StringSplitOptions.RemoveEmptyEntries);
                string[] arDegerlerAresUT = arDBConStrAresUT[3].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arDegerlerAresUT.Length; i++)
                {
                    if (arDegerlerAresUT[i].Contains("Data Source"))
                        txtAresUTServer.Text = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
                    else if (arDegerlerAresUT[i].Contains("Initial Catalog"))
                        txtAresUTDb.Text = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
                    else if (arDegerlerAresUT[i].Contains("User ID"))
                        txtAresUTKullanici.Text = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
                    else if (arDegerlerAresUT[i].Contains("Password"))
                        txtAresUTSifre.Text = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
                }

                fsConfigFile.Close();
                fsConfigFile.Dispose();
            }
        }
        private void DbYoluYaz(string ServerNameAres, string DbNameAres, string ConStrNameAres, string UserNameAres, string PasswordAres,
          string ServerNameAresUT, string DbNameAresUT, string ConStrNameAresUT, string UserNameAresUT, string PasswordAresUT)
        {
            if (ServerNameAres == "" || DbNameAres == "" || ServerNameAresUT == "" || DbNameAresUT == "") return;
            string strPath = Application.StartupPath + @"\AresUrunTanitim.exe.config";
            char tirnak = '"';

            System.Data.SqlClient.SqlConnectionStringBuilder ConnBuilderAres = new System.Data.SqlClient.SqlConnectionStringBuilder();
            System.Data.SqlClient.SqlConnectionStringBuilder ConnBuilderAresUT = new System.Data.SqlClient.SqlConnectionStringBuilder();

            ConnBuilderAres.DataSource = ServerNameAres;
            ConnBuilderAres.InitialCatalog = DbNameAres;
            if (UserNameAres == "" && PasswordAres == "")
            {
                ConnBuilderAres.IntegratedSecurity = true;
            }
            else if (UserNameAres != "" && PasswordAres != "")
            {
                ConnBuilderAres.UserID = UserNameAres;
                ConnBuilderAres.Password = PasswordAres;
                ConnBuilderAres.PersistSecurityInfo = true;
            }
            else if (UserNameAres != "" && PasswordAres == "")
            {
                ConnBuilderAres.UserID = UserNameAres;
            }

            ConnBuilderAresUT.DataSource = ServerNameAresUT;
            ConnBuilderAresUT.InitialCatalog = DbNameAresUT;
            if (UserNameAresUT == "" && PasswordAresUT == "")
            {
                ConnBuilderAresUT.IntegratedSecurity = true;
            }
            else if (UserNameAresUT != "" && PasswordAresUT != "")
            {
                ConnBuilderAresUT.UserID = UserNameAresUT;
                ConnBuilderAresUT.Password = PasswordAresUT;
                ConnBuilderAresUT.PersistSecurityInfo = true;
            }
            else if (UserNameAresUT != "" && PasswordAresUT == "")
            {
                ConnBuilderAresUT.UserID = UserNameAresUT;
            }

            string strText =
      "<?xml version=" + tirnak + "1.0" + tirnak + " encoding=" + tirnak + "utf-8" + tirnak + " ?>" +
      "<configuration>" +
          "<configSections>" +
          "</configSections>" +
          "<connectionStrings>" +
              "<add name=" + tirnak + "AresUrunTanitim.Properties.Settings.DBConStrAres" + tirnak + " connectionString=" + tirnak + ConnBuilderAres.ConnectionString + tirnak +
                  " providerName=" + tirnak + "System.Data.SqlClient" + tirnak + " />" +
              "<add name=" + tirnak + "AresUrunTanitim.Properties.Settings.DBConStrAresUT" + tirnak + " connectionString=" + tirnak + ConnBuilderAresUT.ConnectionString + tirnak +
                  " providerName=" + tirnak + "System.Data.SqlClient" + tirnak + " />" +
          "</connectionStrings>" +
      "</configuration>";

            try
            {
                File.Delete(strPath);
                File.WriteAllText(strPath, strText, Encoding.UTF8);
                XtraMessageBox.Show("VERİTABANI DEĞİŞİKLİKLERİ KAYDEDİLDİ.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Hata Kodu : " + hata.Message + "\nHata Açıklama : " + hata.StackTrace, "    ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DbYoluYaz(txtAresServer.Text, txtAresDb.Text, "DBConStrAres", txtAresKullanici.Text, txtAresSifre.Text, txtAresUTServer.Text, txtAresUTDb.Text, "DBConStrAresUT", txtAresUTKullanici.Text, txtAresUTSifre.Text);
            this.Close();
        }

        private void frmConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}