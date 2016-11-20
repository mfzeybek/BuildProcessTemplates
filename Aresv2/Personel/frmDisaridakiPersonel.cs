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

namespace Aresv2.Personel
{
    public partial class frmDisaridakiPersonel : DevExpress.XtraEditors.XtraForm
    {
        public frmDisaridakiPersonel()
        {
            InitializeComponent();
        }

        clsTablolar.Personel.csDisaridakiPersonel dp = new clsTablolar.Personel.csDisaridakiPersonel();
        private void frmDisaridakiPersonel_Load(object sender, EventArgs e)
        {
            PDKSSqlconnection connn = new PDKSSqlconnection();
            dp.getir(PDKSSqlconnection.GetBaglanti());
            gridControl1.DataSource = dp.dt;
        }
    }
}