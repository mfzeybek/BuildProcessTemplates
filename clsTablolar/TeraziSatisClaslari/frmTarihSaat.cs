using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeraziSatis
{
    public partial class frmTarihSaat : Form
    {
        public frmTarihSaat()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateNavigator1.DateTime = DateTime.Now;
            btnSaatiSil_Click(null, null);
        }

        private void dateNavigator1_Click(object sender, EventArgs e)
        {

        }

        private void weekDaysEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSonrakiAy_Click(object sender, EventArgs e)
        {
            dateNavigator1.DateTime = dateNavigator1.DateTime.AddMonths(1);
        }

        private void timeSpanEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSaatiSil_Click(object sender, EventArgs e)
        {
            DateTime saat = dateNavigator1.DateTime;
            saat = saat.AddHours(-1 * saat.Hour).AddMinutes(-1 * saat.Minute).AddSeconds(-1 * saat.Second);

            dateNavigator1.DateTime = saat;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            Close();
        }

        private void btnOncekiAy_Click(object sender, EventArgs e)
        {
            dateNavigator1.DateTime = dateNavigator1.DateTime.AddMonths(-1);
        }

        private void btnBugun_Click(object sender, EventArgs e)
        {
            dateNavigator1.DateTime = DateTime.Now;
        }

        private void btnSabah_Click(object sender, EventArgs e)
        {
            DateTime saat = dateNavigator1.DateTime;
            saat = saat.AddHours(-1 * saat.Hour).AddHours(10).AddMinutes(-1 * saat.Minute).AddSeconds(-1 * saat.Second);

            dateNavigator1.DateTime = saat;
        }

        private void btnOglen_Click(object sender, EventArgs e)
        {
            DateTime saat = dateNavigator1.DateTime;
            saat = saat.AddHours(-1 * saat.Hour).AddHours(13).AddMinutes(-1 * saat.Minute).AddSeconds(-1 * saat.Second);

            dateNavigator1.DateTime = saat;
        }

        private void btnAksam_Click(object sender, EventArgs e)
        {
            DateTime saat = dateNavigator1.DateTime;
            saat = saat.AddHours(-1 * saat.Hour).AddHours(18).AddMinutes(-1 * saat.Minute).AddSeconds(-1 * saat.Second);

            dateNavigator1.DateTime = saat;
        }

        private void dateNavigator1_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            txtTarih.EditValue = dateNavigator1.DateTime;
            txtSaat.EditValue = dateNavigator1.DateTime;
        }

        private void txtSaat_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnSaatGir_Click(object sender, EventArgs e)
        {
            using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Saat))
            {
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    DateTime saat = dateNavigator1.DateTime;
                    saat = saat.AddHours(-1 * saat.Hour).AddHours(Convert.ToInt16(frm.textEdit1.Text)).AddMinutes(-1 * saat.Minute).AddSeconds(-1 * saat.Second);

                    dateNavigator1.DateTime = saat;
                }
            }
        }
    }
}
