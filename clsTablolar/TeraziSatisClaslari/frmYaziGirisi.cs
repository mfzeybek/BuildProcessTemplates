using System;
using System.IO;
using System.Windows.Input;



namespace clsTablolar.TeraziSatisClaslari
{
    public partial class frmYaziGirisi : DevExpress.XtraEditors.XtraForm
    {
        public frmYaziGirisi()
        {
            InitializeComponent();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            memoEdit1.EditValue = string.Empty;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            //proc.Close();
            //proc.CloseMainWindow();

            KlavyeyiKapat();
            Close();
        }

        void KlavyeyiKapat()
        {
            System.Diagnostics.Process[] oskProcessArray = System.Diagnostics.Process.GetProcessesByName("TabTip");
            foreach (System.Diagnostics.Process onscreenProcess in oskProcessArray)
            {
                onscreenProcess.Kill();
            }

        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            KlavyeyiKapat();
            Close();
        }
        System.Diagnostics.Process proc = new System.Diagnostics.Process();// = System.Diagnostics.Process.Start(keyboardPath);
        private void frmYaziGirisi_Load(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string keyboardPath = Path.Combine(progFiles, "TabTip.exe");

            //inputPanelConfig.EnableFocusTracking();
            proc.StartInfo = new System.Diagnostics.ProcessStartInfo(keyboardPath);
            proc.Start();
            //proc.
        }
        public sealed class InputPane
        {


        }
        private void btnKlavyeyiAc_Click(object sender, EventArgs e)
        {
            InputPane pann = new InputPane();

            System.Windows.Input.ICommand cxcx;






            //pann.
            proc.Start();
            memoEdit1.Focus();
        }




    }
}