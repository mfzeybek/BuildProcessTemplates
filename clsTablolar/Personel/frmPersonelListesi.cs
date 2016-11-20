using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aresv2.Personel
{
    public partial class frmPersonelListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmPersonelListesi()
        {
            InitializeComponent();
        }

        clsTablolar.Personel.csPersonelArama PersonelArama;


        private void frmPersonelListesi_Load(object sender, EventArgs e)
        {
            PersonelArama = new clsTablolar.Personel.csPersonelArama();
            txtPersonelAdi.DataBindings.Add("EditValue", PersonelArama, "CariTanim", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            PersonelArama.PersonelDoldur(SqlConnections.GetBaglanti());
            gcPersonel.DataSource = PersonelArama.dt_PersonelListesi;
        }

        private void btnKaydiAc_Click(object sender, EventArgs e)
        {
            frmPersonelKarti frm = new frmPersonelKarti(Convert.ToInt32(gvPersonel.GetFocusedRowCellValue(colPersonelID)));
            frm.ShowDialog();
        }
    }
}