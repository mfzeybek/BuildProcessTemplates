using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.Personel
{
    public partial class frmPersonelGorevTanimi : Form
    {
        public frmPersonelGorevTanimi()
        {
            InitializeComponent();
        }

        clsTablolar.Personel.csPersonelGorevTanim GorevTanim;

        private void frmPersonelGorevTanimi_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            GorevTanim = new clsTablolar.Personel.csPersonelGorevTanim(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();

            gcGorev.DataSource = GorevTanim.dt_PersonelGorev;
        }

        SqlTransaction TrGenel;

        private void frmPersonelGorevTanimi_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                GorevTanim.GorevKaydet(SqlConnections.GetBaglanti(), TrGenel);
                TrGenel.Commit();
            }
            catch (Exception)
            {
                TrGenel.Rollback();
            }
            
        }

        private void frmPersonelGorevTanimi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.F3)
            {
                if (DialogResult.Yes == MessageBox.Show(gvGorev.GetFocusedRowCellValue(colGorevAdi).ToString()+ "\nAdlı kayıt silinecektir.","Dikkat hamisina",MessageBoxButtons.YesNo))
                {
                    gvGorev.DeleteSelectedRows();
                }
            }
        }
    }
}
