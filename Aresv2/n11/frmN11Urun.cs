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



namespace Aresv2.n11
{
    public partial class frmN11Urun : Form
    {
        public frmN11Urun(int StokID)
        {
            this.StokID = StokID;

            InitializeComponent();
        }

        int StokID;
        clsTablolar.n11.csN11Product Urun;
        SqlTransaction TrGenel;

        private void frmN11Urun_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Urun = new clsTablolar.n11.csN11Product(SqlConnections.GetBaglanti(), TrGenel, StokID);
            TrGenel.Commit();
        }
        void Al()
        {
            DetayliUrunBilgisi.DocumentText = Urun.DetayliUrunBilgisi;


        }


        private void btnAciklamaDuzenle_Click(object sender, EventArgs e)
        {
            using (frmhtmlEditor htmm = new frmhtmlEditor())
            {
                htmm.richEditControl1.HtmlText = Urun.DetayliUrunBilgisi;
                htmm.ShowDialog();
                DetayliUrunBilgisi.DocumentText = htmm.richEditControl1.HtmlText;
                Urun.DetayliUrunBilgisi = htmm.richEditControl1.HtmlText;
                //ButonlariAktifPasifYap(true);
            }
        }
    }
}
