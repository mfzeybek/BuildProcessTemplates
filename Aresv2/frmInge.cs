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

namespace Aresv2
{
    public partial class frmInge : DevExpress.XtraEditors.XtraForm
    {
        public frmInge()
        {
            InitializeComponent();
        }

        private void frmInge_Load(object sender, EventArgs e)
        {
            Ingenico pos = new Ingenico("com3", 9600, textBox1);
            ////Ingenico.dlgInvoke = Invoketurlo;


            Ingenico.dlgInvoke gg = new Ingenico.dlgInvoke(Invoketurlo);
            //Ingenico.dlgInvoke gg = new Ingenico.dlgInvoke(Invoketurlo);


            Ingenico.dlgYaz yzz = yazz;

            pos.PortOpen();
        }


        void Invoketurlo()
        {
            //return 1;
        }

        void yazz(string ttt)
        {
            memoEdit2.Text = ttt;
        }
    }
}