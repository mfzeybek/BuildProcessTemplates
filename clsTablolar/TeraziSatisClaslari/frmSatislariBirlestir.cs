using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace clsTablolar.TeraziSatisClaslari
{
    public partial class frmSatislariBirlestir : DevExpress.XtraEditors.XtraForm
    {
        public frmSatislariBirlestir(SqlConnection _Baglanti, string BarkodNumarasi1)
        {
            this.Baglanti = _Baglanti;
            InitializeComponent();
            txtBarkodBir.Text = BarkodNumarasi1;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSatislariBirlestir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (txtBarkodIki.Text.ToString() == "")
                    txtBarkodIki.Focus();
                else if (txtBarkodBir.Text.ToString() == "")
                    txtBarkodBir.Focus();
            }
            if (e.KeyCode == Keys.Enter && txtBarkodBir.Text != "" && txtBarkodIki.Text != "")
            {
                btnBirlestir_Click(null, null);
            }
        }

        clsTablolar.TeraziSatisClaslari.csSatislarV2 satislar;
        SqlConnection Baglanti;
        SqlTransaction Tr;

        public string BirlestirilenBarkod;

        private void btnBirlestir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarkodBir.Text == txtBarkodIki.Text)
                {
                    lblMesaj.Text = "İki Numara da Aynı";
                    return;
                }
                Tr = Baglanti.BeginTransaction();
                //satislar = new csSatislarV2(SqlConnection, trge)
                
                
                int EtkilenenHareketSayisi = satislar.SatislariBirlestir(Baglanti, Tr, txtBarkodBir.Text, txtBarkodIki.Text);
                if (EtkilenenHareketSayisi == 0)
                    lblMesaj.Text = "Hiç Bir Hareket Aktarılmadı";
                else
                    lblMesaj.Text = EtkilenenHareketSayisi.ToString() + " Adet Hareket Aktarıldı.";

                Tr.Commit();
                BirlestirilenBarkod = txtBarkodBir.Text;
                //this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            catch (Exception)
            {
                try
                {
                    Tr.Rollback();
                }
                catch (Exception)
                {
                }
            }
        }

        private void frmSatislariBirlestir_Load(object sender, EventArgs e)
        {
            txtBarkodIki.Focus();
        }
    }
}