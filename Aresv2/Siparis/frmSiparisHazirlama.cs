using System;

namespace Aresv2.Siparis
{
    public partial class frmSiparisHazirlama : DevExpress.XtraEditors.XtraForm
    {
        public frmSiparisHazirlama()
        {
            InitializeComponent();
        }

        clsTablolar.Yazdirma.csYazdir Yazdir = new clsTablolar.Yazdirma.csYazdir();



        private void btnFormSecerekYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(Yazdir, clsTablolar.csRaporDizayn.RaporModul.SiparisVerme);
            frm.ShowDialog();
        }

        void YazdirmakicinVerileriHazirla()
        {
            //Yazdir.
        }

        private void btnYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmSiparisHazirlama_Load(object sender, EventArgs e)
        {

        }
    }
}