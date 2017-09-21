using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing;

namespace clsTablolar
{
    public class GoruntuIsleme : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        void YuzdeOlarakFotoKucult(decimal Yuzde)
        {
            try
            {
                //FotoEkle(ImageToByte2(ResizeImage(byteArrayToImage((byte[])gvResim.GetFocusedRowCellValue("Resim")), (int)(pictureEdit1.Image.Size.Width - (pictureEdit1.Image.Size.Width * Yuzde / 100)), (int)(pictureEdit1.Image.Size.Height - (pictureEdit1.Image.Size.Height * Yuzde / 100)))));
                
                
                
                //using (frmBuyukFoto bfoto = new frmBuyukFoto(ImageToByte(ResizeImage(byteArrayToImage((byte[])gvResim.GetFocusedRowCellValue("Resim")), pictureEdit1.Image.Size.Width - (pictureEdit1.Image.Size.Width / Yuzde), pictureEdit1.Image.Size.Height - (pictureEdit1.Image.Size.Height / Yuzde)))))
                //{
                //    bfoto.ShowDialog();
                //}
            }
            catch (Exception)
            {
                //MessageBox.Show("aha aha");
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage;

            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            returnImage = Image.FromStream(ms, true);
            return returnImage;
        }

        public static byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();
                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
