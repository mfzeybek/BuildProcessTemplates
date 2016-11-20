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
using System.Data.SqlClient;

namespace Aresv2.BasitUretim
{
    public partial class frmBasitUretim : DevExpress.XtraEditors.XtraForm
    {
        public frmBasitUretim()
        {
            InitializeComponent();
        }

        private void BasitUretim_Load(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        SqlTransaction TrGenel;
        clsTablolar.BasitUretim.csBasitUretim BasitUretim = new clsTablolar.BasitUretim.csBasitUretim();
        public void ReceteSec(int ReceteID)
        {
            clsTablolar.BasitUretim.csBasitUretimRecete Recete = new clsTablolar.BasitUretim.csBasitUretimRecete(SqlConnections.GetBaglanti(), TrGenel, ReceteID);
            BasitUretim.BUReceteID = Recete.BUReceteID;
            BasitUretim.UretilenStokID = Recete.UretilenStokID;
            BasitUretim.UretimMiktari = Recete.UretimMiktari;
            BasitUretim.Aciklama = Recete.Aciklama;

            

        }
        public void StokEkle(int StokID)
        {


        }
    }
}