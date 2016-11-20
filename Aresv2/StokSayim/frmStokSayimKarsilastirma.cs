using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.StokSayim
{
    public partial class frmStokSayimKarsilastirma : DevExpress.XtraEditors.XtraForm
    {
        public frmStokSayimKarsilastirma()
        {
            InitializeComponent();
        }
        clsTablolar.Sayim.csSayim SayimBir;
        clsTablolar.Sayim.csSayim SayimIki;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SayimHamisina = new Stok.frmStokSayim(Stok.frmStokSayim.NasilAcsin.Arama);
            if (SayimHamisina.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                SayimBir = new clsTablolar.Sayim.csSayim(SqlConnections.GetBaglanti(), trGenel, SayimHamisina.SecilenSayimID);
                lblSayimBirAcikalama.Text = SayimBir.Aciklama;
                lblSayimBirTarih.Text = SayimBir.SayimTarihi.ToString();
            }
        }

        clsTablolar.Sayim.csSayimKarsilastirma SayimKarsilastirma;
        Stok.frmStokSayim SayimHamisina;
        private void frmStokSayimKarsilastirma_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SayimHamisina = new Stok.frmStokSayim(Stok.frmStokSayim.NasilAcsin.Arama);
            if (SayimHamisina.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                SayimIki = new clsTablolar.Sayim.csSayim(SqlConnections.GetBaglanti(), trGenel, SayimHamisina.SecilenSayimID);
                lblSayimIkiAciklama.Text = SayimIki.Aciklama;
                lblSayimIkiTarih.Text = SayimIki.SayimTarihi.ToString();
            }
        }
        SqlTransaction trGenel;

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            clsTablolar.Sayim.csSayimKarsilastirma Karsilastir = new clsTablolar.Sayim.csSayimKarsilastirma();
            trGenel = SqlConnections.GetBaglanti().BeginTransaction();

            gridControl1.DataSource = Karsilastir.SayimKarsilastir(SqlConnections.GetBaglanti(), trGenel, SayimBir.SayimID, SayimIki.SayimID);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmExceleAktar frm = new frmExceleAktar(gridControl1);
            frm.ShowDialog();
        }
    }
}