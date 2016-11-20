using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;

namespace Aresv2
{
  public partial class frmHataBildir : DevExpress.XtraEditors.XtraForm
  {
    public frmHataBildir(string hataMesaj, string hataDetay)
    {
      InitializeComponent();
      HataMesaj = hataMesaj;
      HataDetay = hataDetay;
    }

    string HataMesaj = "", HataDetay = "";
    SqlConnection Baglanti = SqlConnections.GetBaglanti();

    private void labelControl1_Click(object sender, EventArgs e)
    {
      pnlHataDetay.Visible = false;
    }
    private void hyperLinkEdit1_Click(object sender, EventArgs e)
    {
      pnlHataDetay.Visible = true;
      pnlHataDetay.Dock = DockStyle.Fill;
    }
    private void frmHataBildir_Load(object sender, EventArgs e)
    {
      cs.csEkranYakala yakala = new cs.csEkranYakala();
      memoHataDetay.Text = "Hata : \r\n" + HataMesaj + "\r\n\r\nHata Detay :\r\n" + HataDetay; 
    }
    public void MailGonder(string HataMesaj, string HataDetay, string Baslik)
    {
      try
      {
        string URL = "smtp.gmail.com";
        System.Net.IPHostEntry obj = System.Net.Dns.GetHostByName(URL);

        MailMessage MailMessage = new MailMessage();
        MailMessage.From = new MailAddress("xxx@gmail.com", " ARES ", System.Text.Encoding.UTF8);
        SmtpClient SmtpClient = new SmtpClient();
        MailMessage.Attachments.Add(new Attachment(Application.StartupPath + "\\ErrorScreen\\Aresv2HataEkran.jpg"));
        MailMessage.To.Add("yyy@gmail.com");
        MailMessage.Subject = Baslik;
        MailMessage.IsBodyHtml = false;
        MailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        MailMessage.Body = "ARES Programında Hata Meydana Geldi...Hata Kodu   : " + HataMesaj + " Hata İçeriği : " + HataDetay + "\n";
        MailMessage.Priority = MailPriority.High;
        SmtpClient.Credentials = new System.Net.NetworkCredential("xxx@gmail.com", "parola");
        SmtpClient.Port = 587;
        SmtpClient.Host = "smtp.gmail.com";
        SmtpClient.EnableSsl = true;
        SmtpClient.Send(MailMessage);
      }
      catch (Exception HATA)
      {
      }
    }
    private void btnHataRaporuGodner_Click(object sender, EventArgs e)
    {
      MailGonder(HataMesaj, HataDetay, "ARES HATA GÖNDERDİ");
    }
    private void btnGonderme_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
    {

    }
  }
}