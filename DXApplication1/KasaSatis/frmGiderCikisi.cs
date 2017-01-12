using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KasaSatis
{
    public partial class frmGiderCikisi : Form
    {
        public frmGiderCikisi()
        {
            InitializeComponent();
        }


        clsTablolar.Kasa.csKasaHareketArama GiderHareketi = new clsTablolar.Kasa.csKasaHareketArama();
        SqlTransaction TrGenel;


        private void frmGiderCikisi_Load(object sender, EventArgs e)
        {

            GiderHareketi.SonZRaporundanSonraMi = true;
            GiderHareketi.KasaID = KasaSatis.Properties.Settings.Default.KasaID;
            GiderHareketi.Yonu = clsTablolar.Kasa.csKasaHareketArama.hareketYonu.Borc;


            gridControl1.DataSource = GiderHareketi.KasaHareketListe(SqlConnections.GetBaglanti(), TrGenel, KasaSatis.Properties.Settings.Default.KasaID);

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
