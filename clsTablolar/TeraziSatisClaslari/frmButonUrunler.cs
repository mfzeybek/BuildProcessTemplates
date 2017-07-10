using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace clsTablolar.TeraziSatisClaslari
{
    public partial class frmButonUrunler : DevExpress.XtraEditors.XtraForm
    {
        public frmButonUrunler(int TeraziID,SqlConnection Baglanti) // TeraziID daha sonra CihazID olarak değiştiirlecek
        {
            this.Baglanti = Baglanti;
            _TeraziID = TeraziID;
            InitializeComponent();
        }

        int _TeraziID = -1;

        // butona tıklanında verdiği StokID
        public int GeriDonenStokID = -1;
        SqlConnection Baglanti;

        SqlTransaction TrGenel;
        private void frmButonUrunler_Load(object sender, EventArgs e)
        {
            TrGenel = Baglanti.BeginTransaction();
            stokButonGrupVeStokButonlari1.AhandaBudur(Baglanti, TrGenel, _TeraziID);
            TrGenel.Commit();
            stokButonGrupVeStokButonlari1.StokButonuTikildatiginda = StokButonuTiklandiginda;
        }
        void StokButonuTiklandiginda(clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi BTipi ,int StokID)
        {
            try
            {
                if (BTipi == clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi.StokButonu)
                {
                    GeriDonenStokID = StokID;
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    //Close();
                }
                else
                {

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("ahanda dıklatma hatası mk");
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}