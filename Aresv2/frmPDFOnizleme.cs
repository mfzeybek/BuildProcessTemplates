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
using System.IO;
using System.Net;

namespace Aresv2
{
    public partial class frmPDFOnizleme : DevExpress.XtraEditors.XtraForm
    {
        public frmPDFOnizleme()
        {
            InitializeComponent();
        }

        private void frmPDFOnizleme_Load(object sender, EventArgs e)
        {
            PdfleriListle(@"\\192.168.2.8\Tarananlar");


            //DevExpress.XtraPdfViewer.PdfViewer pdfvi = new DevExpress.XtraPdfViewer.PdfViewer();
            //pdfvi.DocumentFilePath = PDFler[0];


            //flowLayoutPanel1.Controls.Add(pdfvi);
            ////flowLayoutPanel1.Controls[1].Size.Width
            //pdfvi.Size = new Size(250, 300);
            //pdfvi.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
            //pdfViewer1.
            //documentViewer1.Document

            //printPreviewControl1.Document @"C:\Users\Fatih\Desktop\Argox_AS-8520_User_Manual.pdf";
            for (int i = 0; i < PDFler.Length; i++)
            {
                flowLayoutPanel1.Controls.Add(new DevExpress.XtraPdfViewer.PdfViewer());
                (flowLayoutPanel1.Controls[i] as DevExpress.XtraPdfViewer.PdfViewer).ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
                (flowLayoutPanel1.Controls[i] as DevExpress.XtraPdfViewer.PdfViewer).DocumentFilePath = PDFler[i];
                (flowLayoutPanel1.Controls[i] as DevExpress.XtraPdfViewer.PdfViewer).Size = new Size(250, 300);


                //layoutControl1.Controls.Add(new DevExpress.XtraPdfViewer.PdfViewer());
                //((DevExpress.XtraPdfViewer.PdfViewer)(layoutControl1.Controls[i])).DocumentFilePath = PDFler[i];
                //(layoutControl1.Controls[i] as DevExpress.XtraPdfViewer.PdfViewer).DocumentFilePath = PDFler[i];
                //(layoutControl1.Controls[i] as DevExpress.XtraPdfViewer.PdfViewer).ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
                //(layoutControl1.Controls[i] as DevExpress.XtraPdfViewer.PdfViewer).Size = new Size(250, 300);

            }

        }
        string[] PDFler;

        void PdfleriListle(string Yol)
        {
            PDFler = Directory.GetFiles(Yol, "*.pdf", SearchOption.AllDirectories);
            //requestDir.Credentials = new NetworkCredential("username", "password");
            //requestDir.Credentials = new NetworkCredential("username", "password");
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}