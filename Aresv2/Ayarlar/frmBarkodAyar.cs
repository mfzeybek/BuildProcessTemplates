using System;
using System.Data.SqlClient;

namespace Aresv2.Ayarlar
{
    public partial class frmBarkodAyar : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Bu ya verilecek barkodları oluşturmak için yada stok kartına (sadece stok kartına) barkod eklemek için
        /// </summary>
        /// <param name="Nasil"></param>
        public frmBarkodAyar(NasilAcsin Nasil)
        {
            InitializeComponent();

            NasilHamisina = Nasil;

            if (Nasil == NasilAcsin.AyarlamakIcin)
            {
                btnTamam.Visible = false;
            }
            else // Stok Seçmek için
            {
                btnKaydet.Visible = false;
                btnSil.Visible = false;
                btnVazgec.Visible = false;
                btnTamam.Visible = true;
                gvBarkodAyar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                gvBarkodAyar.OptionsBehavior.ReadOnly = true;
                gvBarkodAyar.OptionsBehavior.Editable = false;
                gvBarkodAyar.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
        }

        NasilAcsin NasilHamisina;

        public enum NasilAcsin
        {
            AyarlamakIcin,
            StokaBarkodEklemekIcin
        }


        clsTablolar.Ayarlar.csBarkodAyar BarkodAyar = new clsTablolar.Ayarlar.csBarkodAyar();
        clsTablolar.Ayarlar.csBarkodTipleri BarkodTiplerii = new clsTablolar.Ayarlar.csBarkodTipleri();

        SqlTransaction TrGenel;

        private void frmBarkodAyar_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

                BarkodAyar.Getir(SqlConnections.GetBaglanti(), TrGenel);
                gcBarkodAyar.DataSource = BarkodAyar.dt;

                repositoryItemLookUpEdit_BarkodTip.DataSource = BarkodTiplerii.dt_BarkodTipleri();
                repositoryItemLookUpEdit_BarkodTip.DisplayMember = "name";
                repositoryItemLookUpEdit_BarkodTip.ValueMember = "value";

                //repositoryItemLookUpEdit_BarkodTip.Columns["name"].Visible = false;

                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                BindingContext[gcBarkodAyar.DataSource].EndCurrentEdit();
                BarkodAyar.Kaydet(SqlConnections.GetBaglanti(), TrGenel);
                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        public string BarkodNumarasi = "";
        clsTablolar.Ayarlar.csBarkodNuVer NumaraVer;

        private void gvBarkodAyar_DoubleClick(object sender, EventArgs e)
        {
            btnTamam_Click(null, null);
        }

        private void gcBarkodAyar_Click(object sender, EventArgs e)
        {

        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (NasilHamisina == NasilAcsin.StokaBarkodEklemekIcin)
            {
                using (NumaraVer = new clsTablolar.Ayarlar.csBarkodNuVer())
                {
                    NumaraVer.BarkodAyarID = (int)gvBarkodAyar.GetFocusedRowCellValue(colBarkodAyarID);
                    NumaraVer.OnEk = Convert.ToInt32(gvBarkodAyar.GetFocusedRowCellValue(colOnEk));
                    NumaraVer.BarkodTipi = (clsTablolar.Ayarlar.csBarkodTipleri.BarkodTipleri)(Convert.ToInt32(gvBarkodAyar.GetFocusedRowCellValue(colBarkodTipi)));

                    NumaraVer.KontrolNoOlsunMu = Convert.ToBoolean(gvBarkodAyar.GetFocusedRowCellValue(colKontrolNoOlsunMu));
                    NumaraVer.MiktarOlacakMi = Convert.ToBoolean(gvBarkodAyar.GetFocusedRowCellValue(colMiktarOlacakMi));
                    NumaraVer.KacHaneMiktar = Convert.ToInt16(gvBarkodAyar.GetFocusedRowCellValue(colKacHaneMiktar));
                    NumaraVer.KacHaneKod = Convert.ToInt16(gvBarkodAyar.GetFocusedRowCellValue(colKacHaneKod));
                    NumaraVer.Aciklama = gvBarkodAyar.GetFocusedRowCellValue(colAciklama).ToString();
                    NumaraVer.ToplamKarakterSayisi = Convert.ToInt16(gvBarkodAyar.GetFocusedRowCellValue(colToplamKarakterSayisi));
                    NumaraVer.SiradakiKod = Convert.ToInt32(gvBarkodAyar.GetFocusedRowCellValue(colSiradakiKod));

                    try
                    {
                        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                        BarkodNumarasi = NumaraVer.NumaraVer(SqlConnections.GetBaglanti(), TrGenel);
                        TrGenel.Commit();
                    }
                    catch (Exception hata)
                    {
                        TrGenel.Rollback();
                        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                        frmHataBildir.ShowDialog();
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                Close();
            }
        }
    }
}