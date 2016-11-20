using System;
using System.Data.SqlClient;

namespace Aresv2.Terazi
{
    public partial class frmTeraziStokButonGrupTanimlari : DevExpress.XtraEditors.XtraForm
    {
        public frmTeraziStokButonGrupTanimlari()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            GrupTanimlari.Kaydet(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();
        }

        SqlTransaction TrGenel;

        clsTablolar.Terazi.csTeraziStokGrupTanimlari GrupTanimlari = new clsTablolar.Terazi.csTeraziStokGrupTanimlari();


        private void frmTeraziStokButonGrupTanimlari_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

            GrupTanimlari.GruplariGetir(SqlConnections.GetBaglanti(), TrGenel);

            gcStokButonGruplari.DataSource = GrupTanimlari.dt;

            TrGenel.Commit();
        }

        private void btnGrubunStoklariniDuzenle_Click(object sender, EventArgs e)
        {
            Terazi.frmTeraziStokGruplarininStokButonlari StokButonlari = new frmTeraziStokGruplarininStokButonlari((int)gvStokButonGruplari.GetFocusedRowCellValue("TeraziStokGrupTanimID"));

            StokButonlari.MdiParent = this.MdiParent;
            StokButonlari.Show();
        }
    }
}