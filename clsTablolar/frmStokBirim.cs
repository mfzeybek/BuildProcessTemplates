using System;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public partial class frmStokBirim : DevExpress.XtraEditors.XtraForm
    {
        public frmStokBirim(int StokID, SqlConnection Baglanti)
        {
            _StokID = StokID;
            _Baglanti = Baglanti;
            InitializeComponent();
        }
        clsTablolar.Stok.csStokunBirimleri AltBirimler;

        int _StokID;
        SqlConnection _Baglanti;

        SqlTransaction TrGenel;

        public int AltBirimID;
        public string AltBirimAdi;
        public decimal AltBirimKatsayi;
        public string AltBirimBarkod;
        public bool MiktarYaziyorMu;
        public int BirimCevrimID;


        private void frmStokBirim_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = _Baglanti.BeginTransaction();

                AltBirimler = new clsTablolar.Stok.csStokunBirimleri(_Baglanti, TrGenel, _StokID, true);

                gridControl1.DataSource = AltBirimler.dt;

                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();

                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);

                //frmHataBildir.ShowDialog();
                
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnTamam_Click(null, null);
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            AltBirimID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BirimID"));
            AltBirimAdi = gridView1.GetFocusedRowCellValue("BirimAdi").ToString();
            AltBirimKatsayi = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("KatSayi"));
            AltBirimBarkod = gridView1.GetFocusedRowCellValue("Barkodu").ToString();
            MiktarYaziyorMu = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("MiktarOlacakMi"));
            BirimCevrimID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("StokBirimCevirmeID"));

            Close();
        }
    }
}