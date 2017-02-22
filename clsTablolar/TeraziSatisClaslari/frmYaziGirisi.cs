using System;
using System.Runtime.InteropServices;
using System.Management;
using System.Linq;


namespace clsTablolar.TeraziSatisClaslari
{
    public partial class frmYaziGirisi : DevExpress.XtraEditors.XtraForm
    {
        public frmYaziGirisi()
        {
            InitializeComponent();
        }


        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string sClassName, string sAppName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);


        private void btnTemizle_Click(object sender, EventArgs e)
        {
            memoEdit1.EditValue = string.Empty;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;

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

        private void frmYaziGirisi_Load(object sender, EventArgs e)
        {
            btnKlavyeyiAc_Click(null, null);
        }

        //public static string GetOSFriendlyName()
        //{
        //    string result = string.Empty;
        //    System.Management.Instrumentation.
        //    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
        //    foreach (ManagementObject os in searcher.Get())
        //    {
        //        result = os["Caption"].ToString();
        //        break;
        //    }
        //    return result;
        //}

        private void btnKlavyeyiAc_Click(object sender, EventArgs e)
        {
            if (Environment.OSVersion.VersionString != "")
            {

                //labelControl1.Text = ;

                System.OperatingSystem osInfo = System.Environment.OSVersion;
                labelControl1.Text = osInfo.Platform.ToString();
            }

            var trayWnd = FindWindow("Shell_TrayWnd", null);
            var nullIntPtr = new IntPtr(0);


            if (trayWnd != nullIntPtr)
            {
                var trayNotifyWnd = FindWindowEx(trayWnd, nullIntPtr, "TrayNotifyWnd", null);
                if (trayNotifyWnd != nullIntPtr)
                {
                    var tIPBandWnd = FindWindowEx(trayNotifyWnd, nullIntPtr, "TIPBand", null);

                    if (tIPBandWnd != nullIntPtr)
                    {
                        PostMessage(tIPBandWnd, (UInt32)WMessages.WM_LBUTTONDOWN, 1, 65537);
                        PostMessage(tIPBandWnd, (UInt32)WMessages.WM_LBUTTONUP, 1, 65537);
                    }
                }
            }
            memoEdit1.Focus();
        }

        public enum WMessages : int
        {
            WM_LBUTTONDOWN = 0x201,
            WM_LBUTTONUP = 0x202,
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14,
        }
    }
}