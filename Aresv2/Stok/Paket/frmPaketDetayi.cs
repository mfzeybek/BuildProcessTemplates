using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Aresv2.Stok.Paket
{
    public partial class frmPaketDetayi : Form
    {
        public frmPaketDetayi(int PaketID)
        {
            _PaketID = PaketID;
            InitializeComponent();
        }
        int _PaketID = -1;
        clsTablolar.Stok.Paket.csPaket Paket;
        clsTablolar.Stok.Paket.csPaketDetay Detay;

        SqlTransaction TrGenel;
        private void frmPaketDetayi_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Paket = new clsTablolar.Stok.Paket.csPaket(SqlConnections.GetBaglanti(), TrGenel, _PaketID);
            Detay = new clsTablolar.Stok.Paket.csPaketDetay();
            Detay.Getir(SqlConnections.GetBaglanti(), TrGenel, _PaketID);
            TrGenel.Commit();

            gridControl1.DataSource = Detay.dt;
            al();
        }
        void al()
        {
            _PaketID = Paket.PaketID;
            txtPaketAdi.EditValue = Paket.PaketAdi;
            txtBarkod.EditValue = Paket.Barkod;
            memoAciklama.EditValue = Paket.PaketAciklama;
        }
        void Ver()
        {
            Paket.PaketAdi = txtPaketAdi.EditValue.ToString();
            Paket.Barkod = txtBarkod.EditValue.ToString();
            Paket.PaketAciklama = memoAciklama.EditValue.ToString();
        }
        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            using (frmStokListesi frm = new frmStokListesi(true))
            {
                frm.Stok_Sec = StokEkle;
                frm.ShowDialog();
            }
        }
        void StokEkle(int StokID, decimal Miktar)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            clsTablolar.Stok.csStok YeniSatir = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, StokID);
            TrGenel.Commit();

            Detay.dt.Rows.Add(Detay.dt.NewRow());
            int SonSatirNo = Detay.dt.Rows.Count - 1;
            Detay.dt.Rows[SonSatirNo]["StokAdi"] = YeniSatir.StokAdi;
            Detay.dt.Rows[SonSatirNo]["StokID"] = YeniSatir.StokID;
            Detay.dt.Rows[SonSatirNo]["Miktar"] = Miktar;
            Detay.dt.Rows[SonSatirNo]["AnaBirimID"] = YeniSatir.StokBirimID;

            Detay.dt.Rows[SonSatirNo]["KatSayi"] = 1;
            Detay.dt.Rows[SonSatirNo]["AltBirimID"] = YeniSatir.StokBirimID;
            Detay.dt.Rows[SonSatirNo]["AltBirimMiktar"] = Miktar;


        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Ver();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Paket.Kaydet(SqlConnections.GetBaglanti(), TrGenel);
            Detay.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Paket.PaketID);
            _PaketID = Paket.PaketID;
            TrGenel.Commit();
        }
    }
}
