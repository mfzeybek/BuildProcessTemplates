using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Aresv2.cs
{
  public class csEkranYakala
  {
    public csEkranYakala()
    {
      Graphics grp;
      Bitmap Ekran = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppPArgb);
      grp = Graphics.FromImage(Ekran);
      grp.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
      //Ekran.Save(Application.StartupPath + "\\ErrorScreen\\Aresv2HataEkran.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
  }
}