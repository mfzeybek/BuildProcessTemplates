using System;
using System.Data.SqlClient;

namespace Aresv2.Stok
{
    public partial class frmStokBirim : DevExpress.XtraEditors.XtraForm
    {
        public frmStokBirim(SqlConnection Baglanti, int StokID, bool FazladanPaketTanimlariGetir)
        {

            this.Baglanti = Baglanti;
            _StokID = StokID;
            this.FazladanPaketTanimlariGetir = FazladanPaketTanimlariGetir;
            InitializeComponent();
        }
        clsTablolar.Stok.csStokunBirimleri AltBirimler;

        int _StokID;
        SqlConnection Baglanti;
        SqlTransaction TrGenel;

        public int AltBirimID;
        public string AltBirimAdi;
        public decimal AltBirimKatsayi;
        public string AltBirimBarkod;
        public bool MiktarYaziyorMu;
        public int BirimCevrimID;

        public bool FazladanPaketTanimlariGetir;

        private void frmStokBirim_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = Baglanti.BeginTransaction();

                AltBirimler = new clsTablolar.Stok.csStokunBirimleri(Baglanti, TrGenel, _StokID, true);

                gridControl1.DataSource = AltBirimler.dt;

                if (FazladanPaketTanimlariGetir)
                {
                    AltBirimler.dt.Rows.Add(AltBirimler.dt.NewRow());

                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["StokBirimCevirmeID"] = -2;
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["BirimID"] = 1;
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["KatSayi"] = 0.05; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["BirimAdi"] = "50 GR Ad"; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["Aciklama"] = "50 GR Ad"; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["MiktarOlacakMi"] = false; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["Barkodu"] = string.Empty; // 50 gr

                    AltBirimler.dt.Rows.Add(AltBirimler.dt.NewRow());

                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["StokBirimCevirmeID"] = -2;
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["BirimID"] = 1; // TODO: Buradaki Ad miktarını daha sonra ayarlardan alacak
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["KatSayi"] = 0.075; 
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["BirimAdi"] = "75 GR Ad"; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["Aciklama"] = "75 GR Ad"; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["MiktarOlacakMi"] = false; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["Barkodu"] = string.Empty; // 50 gr

                    AltBirimler.dt.Rows.Add(AltBirimler.dt.NewRow());

                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["StokBirimCevirmeID"] = -2;
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["BirimID"] = 1;
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["KatSayi"] = 0.1;
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["BirimAdi"] = "100 GR Ad"; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["Aciklama"] = "100 GR Ad"; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["MiktarOlacakMi"] = false; // 50 gr
                    AltBirimler.dt.Rows[AltBirimler.dt.Rows.Count - 1]["Barkodu"] = string.Empty; // 50 gr
                }

                

                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                try { TrGenel.Rollback(); }
                catch (Exception) { }

                throw hata;
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
            if (gridView1.GetFocusedRowCellValue("MiktarOlacakMi") != DBNull.Value)
                MiktarYaziyorMu = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("MiktarOlacakMi"));
            BirimCevrimID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("StokBirimCevirmeID"));

            Close();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }
    }
}