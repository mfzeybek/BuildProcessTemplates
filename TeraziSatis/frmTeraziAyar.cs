using System;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace TeraziSatis
{
    public partial class frmTeraziAyar : DevExpress.XtraEditors.XtraForm
    {
        public frmTeraziAyar()
        {
            InitializeComponent();
        }


        clsTablolar.Terazi.csTeraziArama TeraziListesi = new clsTablolar.Terazi.csTeraziArama();
        SqlTransaction TrGenel;
        private void frmTeraziAyar_Load(object sender, EventArgs e)
        {
            txtConnStr.Text = TeraziSatis.Properties.Settings.Default.DBConStr;

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            TeraziListesi.TeraziGetir(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();

            lookUpEdit1.Properties.DataSource = TeraziListesi.dt;


            //cmbTeraziNumarasi.
            //    com
            //                cmbTeraziNumarasi.DataSource = teraziListesi.dt;
            lookUpEdit1.Properties.DisplayMember = "TeraziAdi";
            lookUpEdit1.Properties.ValueMember = "TeraziID";

            lookUpEdit1.EditValue = TeraziSatis.Properties.Settings.Default.TeraziID;

            foreach (String yazici in PrinterSettings.InstalledPrinters)
            {
                comboBoxEdit1.Properties.Items.Add(yazici);
                comboBoxEdit2.Properties.Items.Add(yazici);
            }

            comboBoxEdit1.Text = TeraziSatis.Properties.Settings.Default.Yazici1;
            comboBoxEdit2.Text = TeraziSatis.Properties.Settings.Default.Yazici2;
            txtTeraziBaglantiNok.Text = TeraziSatis.Properties.Settings.Default.TeraziBagNok;
            txtTeraziModeli.Text = TeraziSatis.Properties.Settings.Default.TeraziModel.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("TeraziSatis.exe.config");

            XmlNodeList nl = doc.SelectNodes("/configuration/userSettings/TeraziSatis.Properties.Settings/setting/value");
            //XmlNode node = nl[0];
            nl[0].InnerText = lookUpEdit1.EditValue.ToString(); // teraziID
            //nl[1].InnerText = txtKullaniciSifre.Text;
            //node.Value = txtKullaniciSifre.Text;

            //nl = doc.SelectNodes("/configuration/connectionStrings");
            //nl[0].Value = "tessstt";
            //ChildNodes[0].InnerText = "bu mudur";
            nl[1].InnerText = txtTeraziBaglantiNok.Text; // Bağlantı noktası
            nl[4].InnerText = txtTeraziModeli.Text; // TeraziModel
            nl[5].InnerText = comboBoxEdit1.Text; // teraziID
            nl[6].InnerText = comboBoxEdit2.Text; // teraziID

            //doc.Load("TeraziSatis.exe.config");


            //XDocument doc = XDocument.Load("dosya.xml");
            //doc.Element("tablo").Element("surum").Value = "1.1";
            doc.Save("TeraziSatis.exe.config");

            //Aresv2.Properties.Settings.Default.KullaniciAdi = txtKullaniciAdi.EditValue.ToString();
            //Aresv2.Properties.Settings.Default.KullaniciSifresi = txtKullaniciSifre.EditValue.ToString();
            //SqlConnections.BaglantiyiKapat();
            MessageBox.Show("Kapatıp yeniden açman lazım hamısına");
        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}