using System;
using System.IO;
using System.Net;


namespace Aresv2.HemenAl
{
  public class csFtpYeGonder : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
    /// <summary>
    /// DosyaAdi + DateTime.Now + ".jpeg" olarak adını gönderirir
    /// </summary>
    /// <param name="DosyaAdi"></param>
    /// <param name="Dosya"></param>
    /// <returns></returns>
    public string Gonder(string DosyaAdi, byte[] Dosya)
    {
      string DosyaAdi2 = DosyaAdi + DateTime.Now + ".jpeg";
      try
      {
        FtpWebRequest ftpistek = (FtpWebRequest)WebRequest.Create("ftp://cikolatacerez.xml.in/www/" + DosyaAdi2);

        //Metodumuz basit, UploadFile olacak.
        ftpistek.Method = WebRequestMethods.Ftp.UploadFile;

        //Hesap ayarlarımızı ayarlıyoruz.
        ftpistek.Credentials = new NetworkCredential("user2429275", "Sadeceben1");

        //Upload steği gibi istekler için bir akım(Stream) oluşturuyoruz ve upload edeceğimiz dosya için bir FileStream oluşturuyoruz.
        Stream ftpakım = ftpistek.GetRequestStream();


        ftpakım.Write(Dosya, 0, Dosya.Length);

        //ftpistek.Abort();
        ftpakım.Dispose();
        

      }
      catch (Exception)
      {
        //MessageBox.Show("Yüklenemedi");
        return "Hata";
      }

      return "http://www.cikolatacerez.xml.in/" + DosyaAdi2;
    }
  }
}
