using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.Terazi
{
    public partial class frmTeraziKarti : DevExpress.XtraEditors.XtraForm
    {
        public frmTeraziKarti(int TeraziID)
        {
            _TeraziID = TeraziID;
            InitializeComponent();
        }
        int _TeraziID;

        clsTablolar.Terazi.csTeraziStokGruplariIliskileri StokGruplariIleTeraziIliskileri = new clsTablolar.Terazi.csTeraziStokGruplariIliskileri();
        clsTablolar.Terazi.csTeraziStokGrupTanimlari ButonGrupTanimlari = new clsTablolar.Terazi.csTeraziStokGrupTanimlari();
        clsTablolar.Terazi.csTeraziKarti TeraziKarti;

        SqlTransaction TrGenel;

        void VerileriAl()
        {
            txtTeraziAdi.EditValue = TeraziKarti.TeraziAdi;
            memoTeraziAciklama.EditValue = TeraziKarti.TeraziAciklama;
        }
        void VerileriGonder()
        {
            TeraziKarti.TeraziAdi = txtTeraziAdi.EditValue.ToString();
            TeraziKarti.TeraziAciklama = memoTeraziAciklama.EditValue.ToString();
        }

        private void frmTeraziKarti_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            TeraziKarti = new clsTablolar.Terazi.csTeraziKarti(SqlConnections.GetBaglanti(), TrGenel, _TeraziID);

            StokGruplariIleTeraziIliskileri.Getir(SqlConnections.GetBaglanti(), TrGenel, TeraziKarti.TeraziID);
            gridControl1.DataSource = StokGruplariIleTeraziIliskileri.dt;


            ButonGrupTanimlari.GruplariGetir(SqlConnections.GetBaglanti(), TrGenel);

            repositoryItemLookUpEdit_ButonGruplari.DataSource = ButonGrupTanimlari.dt;
            repositoryItemLookUpEdit_ButonGruplari.DisplayMember = "TeraziStokButonGrupTanimAdi";
            repositoryItemLookUpEdit_ButonGruplari.ValueMember = "TeraziStokGrupTanimID";

            VerileriAl();


            TrGenel.Commit();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                VerileriGonder();
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                TeraziKarti.TeraziKaydet(SqlConnections.GetBaglanti(), TrGenel, TeraziKarti.TeraziID);
                StokGruplariIleTeraziIliskileri.Kaydet(SqlConnections.GetBaglanti(), TrGenel, TeraziKarti.TeraziID);

                TrGenel.Commit();
            }
            catch (Exception)
            {
                TrGenel.Rollback();
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnGrubuSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili Grup Teraziden Silinecek", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
            }
        }
    }
}