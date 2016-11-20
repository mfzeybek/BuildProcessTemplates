using System;
using System.Windows.Forms;

namespace TeraziSatis
{
    public partial class frmIndirim : DevExpress.XtraEditors.XtraForm
    {
        public frmIndirim()
        {
            InitializeComponent();
        }

        public decimal NormalFiyat = 0; // bu geliyor

        public decimal IndirimliFiyat = 0;
        public decimal IndirimYuzdesi = 0;  // bu geliyor

        public decimal IndirimliSatisTutari = 0;
        public decimal SatisTutari = 0;



        private void frmIndirim_Load(object sender, EventArgs e)
        {

        }

        private void txtIndirimYuzdesi_EditValueChanged(object sender, EventArgs e)
        {
            NormalFiyat = Convert.ToDecimal(txtNormalFiyat.EditValue);

            IndirimliFiyat = 0;
            IndirimYuzdesi = 0;
            IndirimliSatisTutari = 1;
            SatisTutari = 0;

            if (txtIndirimYuzdesi.EditValue != null && txtIndirimYuzdesi.EditValue != "")
                IndirimYuzdesi = Convert.ToDecimal(txtIndirimYuzdesi.EditValue);

            IndirimliFiyat = NormalFiyat - ((NormalFiyat * IndirimYuzdesi) / 100);

            txtIndirimliFiyat.EditValue = IndirimliFiyat;
        }

        private void txtIndirimliFiyat_EditValueChanged(object sender, EventArgs e)
        {
            NormalFiyat = Convert.ToDecimal(txtNormalFiyat.EditValue);

            IndirimliFiyat = 0;
            IndirimYuzdesi = 0;

            if (txtIndirimliFiyat.EditValue != null && txtIndirimliFiyat.EditValue != "")
                IndirimliFiyat = Convert.ToDecimal(txtIndirimliFiyat.EditValue);

            IndirimYuzdesi = 100 * ((NormalFiyat - IndirimliFiyat) / NormalFiyat);

            txtIndirimYuzdesi.EditValue = IndirimYuzdesi;
        }

        private void txtNormalFiyat_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtIndirimYuzdesi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }


        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtIndirimYuzdesi.EditValue) < 0)
            {
                MessageBox.Show("Eksi indirim yapılamaz");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.Yes;


            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnYuzdeGir_Click(object sender, EventArgs e)
        {
            using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
            {
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    txtIndirimYuzdesi.EditValue = frm.textEdit1.EditValue;
                }
            }
        }

        private void btnFiyatGir_Click(object sender, EventArgs e)
        {
            using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
            {
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    txtIndirimliFiyat.EditValue = frm.textEdit1.EditValue;
                }
            }
        }
    }
}