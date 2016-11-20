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
using DevExpress.XtraReports.UserDesigner;

namespace Aresv2.Stok
{
    public partial class frmOzelEtiket : DevExpress.XtraEditors.XtraForm
    {
        public frmOzelEtiket()
        {
            InitializeComponent();
        }

        private void frmOzelEtiket_Load(object sender, EventArgs e)
        {
            documentViewer2.SetPageView(DevExpress.XtraPrinting.PageViewModes.RowColumn);

            //DevExpress.DocumentView.Controls.DocumentViewerBase.
            //dokuman.
            //DevExpress./*DocumentView*/
            //documentViewer1.Document
            //documentViewer1.Controls.
            //snapControl1.LoadDocument()
        }

        private void snapControl1_Click(object sender, EventArgs e)
        {

        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {

        }
        XtraReport1 rpt = new XtraReport1();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //rpt.LoadLayout(@"C:\AresRapor\StokEtiket\50ye30 ruhuna fatiha.repx");
            rpt.xrLabel1.Lines = memoEdit1.Lines;
            //rpt.xrLabel1.AutoWidth = true;

            documentViewer2.DocumentSource = rpt;

            
            rpt.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            rpt.xrLabel1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Both;
            rpt.xrLabel1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Both;
            rpt.xrLabel1.Multiline = false;
            //rpt.xrLabel1.
            //textEdit1.Text = rpt.xrLabel1.SizeF.ToString();
            textEdit2.Text = rpt.xrLabel1.Font.Height.ToString();
            textEdit3.Text = rpt.xrLabel1.Font.SizeInPoints.ToString();
            textEdit1.Text = rpt.xrLabel1.Font.GetHeight().ToString();
            textEdit4.Text = rpt.xrLabel1.Font.Size.ToString();
            textEdit5.Text = rpt.xrLabel1.SizeF.ToString();

            rpt.CreateDocument(true);

            //documentViewer2.Validate();
            //rpt.xrLabel1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Both;
            //rpt.xrLabel1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Both;


            //documentViewer2.rep
            //documentViewer2.req

            //documentViewer2.DocumentSource
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XRDesignFormEx XrDesigner = new XRDesignFormEx();
            XrDesigner.FileName = "50ye30 ruhuna fatiha.repx";
            //XrDesigner.OpenReport(@"C:\AresRapor\StokEtiket\50ye30 ruhuna fatiha.repx");
            XrDesigner.OpenReport(rpt);

            XrDesigner.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            rpt.SuspendLayout();
            
        }
    }
}