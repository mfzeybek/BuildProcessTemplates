using System;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Xml;
using System.Configuration;

namespace Aresv2
{
    public partial class frmVeriTabaniBaglanti : DevExpress.XtraEditors.XtraForm
    {
        public frmVeriTabaniBaglanti()
        {
            InitializeComponent();
        }

        public static System.Data.SqlClient.SqlConnection Baglanti;

        private void VeriTabaniIslemleri_Load(object sender, EventArgs e)
        {
            Baglanti = new System.Data.SqlClient.SqlConnection(Aresv2.Properties.Settings.Default.DBConStr);
            txtPassword.Text = "1"; // bu kullanıcının deil veritabaının şifresi
            txtServerName.Text = Baglanti.DataSource;
            txtUserName.Text = "sa"; // // bu kullanıcının deil veritabaının kullanıcı adı 
            cmbAuthentication.SelectedIndex = 1;
            txtServerName_Leave(null, null);
            cmbDbName.Text = Baglanti.Database;
            ceGelistiriciModu.Checked = Aresv2.Properties.Settings.Default.GelistiriciModu;
            txtKullaniciAdi.Text = Aresv2.Properties.Settings.Default.KullaniciAdi;
            txtKullaniciSifre.Text = Aresv2.Properties.Settings.Default.KullaniciSifresi;
        }

        private void simpleButton1_Click(object sender, EventArgs e) // test et...
        {
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            try
            {
                if (txtServerName.Text == "") return;
                if (cmbAuthentication.SelectedIndex == 1 && txtUserName.Text == "") return;
                if (cmbDbName.Text == "") return;


                builder.DataSource = txtServerName.Text;
                builder.InitialCatalog = cmbDbName.Text;

                if (cmbAuthentication.SelectedIndex == 0) builder.IntegratedSecurity = true;
                else
                {
                    builder.PersistSecurityInfo = true;
                    builder.UserID = txtUserName.Text;
                    if (txtPassword.Text != "") builder.Password = txtPassword.Text;
                }
            }
            catch (Exception ex) { MessageBox.Show("Baglantı bilgileri derlenirken hata meydana geldi.\n" + ex.Message); }
            try
            {
                Baglanti = new System.Data.SqlClient.SqlConnection(builder.ConnectionString);
                Baglanti.Open();
                MessageBox.Show("Sınama bağlantısı başarılı.");
                Aresv2.Properties.Settings.Default.GelistiriciModu = true;
                xmlKaydet(builder);
                Close();
            }
            catch (Exception ex) { MessageBox.Show("Veri tabanı ile bağlantı kurulurken hata meydana geldi.\n" + ex.Message); }
        }

        private void txtServerName_Leave(object sender, EventArgs e)
        {
            if (txtServerName.Text == "") return;
            try
            {
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.DataSource = txtServerName.Text;
                builder.InitialCatalog = "master";
                builder.IntegratedSecurity = true;
                System.Data.SqlClient.SqlConnection Baglanti = new System.Data.SqlClient.SqlConnection(builder.ConnectionString);
                Baglanti.Open();
                System.Data.SqlClient.SqlCommand cmdDbNames = new System.Data.SqlClient.SqlCommand("Select name From sys.databases", Baglanti);
                using (System.Data.SqlClient.SqlDataReader drDbNames = cmdDbNames.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    cmbDbName.Properties.Items.Clear();
                    while (drDbNames.Read())
                        cmbDbName.Properties.Items.Add(drDbNames["name"].ToString());
                }
            }
            catch (Exception) { }
        }



        void xmlKaydet(System.Data.SqlClient.SqlConnectionStringBuilder bld)
        {
            XmlDocument doc = new XmlDocument();
            //doc.Load("Aresv2.exe.config");
            doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement xElement in doc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    //setting the coonection string
                    xElement.FirstChild.Attributes[1].Value = bld.ConnectionString;
                }
            }

            //writing the connection string in config file

            //XmlDocument doc = new XmlDocument();
            //doc.Load("Aresv2.exe.config");

            using (XmlNodeList nl = doc.SelectNodes("/configuration/userSettings/Aresv2.Properties.Settings/setting/value"))
                nl[2].InnerText = ceGelistiriciModu.Checked.ToString(); // Geliştirici Modu

            using (XmlNodeList nl = doc.SelectNodes("/configuration/userSettings/Aresv2.Properties.Settings/setting/value"))
            {
                nl[0].InnerText = txtKullaniciAdi.Text;
                nl[1].InnerText = txtKullaniciSifre.Text;
            }
            //doc.Save("Aresv2.exe.config");
            Aresv2.Properties.Settings.Default.KullaniciAdi = txtKullaniciAdi.EditValue.ToString();
            Aresv2.Properties.Settings.Default.KullaniciSifresi = txtKullaniciSifre.EditValue.ToString();
            //SqlConnections.BaglantiyiKapat();




            doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            MessageBox.Show("Kapatıp yeniden açman lazım hamısına");
        }
    }
}