using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HarmonyHub;


namespace akıllı_ev
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string loginnn = HarmonyLogin.LoginToLogitech("fatih@osmansenoz.com", "fth123fth", "192.168.2.194", 5222);
            HarmonyHub.Device dev = new Device();

            HarmonyHub.Activity ac = new Activity();
            
        }
    }
}
