using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCam_Capture;


namespace Aresv2.cs
{
    public partial class frmWebCam : Form
    {
        public frmWebCam()
        {
            InitializeComponent();
        }

        WebCam_Capture.WebCamCapture cam = new WebCamCapture();

        private void frmWebCam_Load(object sender, EventArgs e)
        {

        }

        void cam_ImageCaptured(object source, WebcamEventArgs e)
        {
            //pictureEdit1.EditValue = e.WebCamImage;
        }
        //public Bitmap Foto;
        Image img;

        public byte[] ftotoo;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Foto = cameraControl1.Device.CurrentFrame;
            img = cameraControl1.Device.CurrentFrame;


            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();
                byte[] byteArray = new byte[0];

                byteArray = stream.ToArray();
                ftotoo = byteArray;
                this.DialogResult = DialogResult.Yes;
            }
            Close();
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
