using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


namespace Aresv2.Ayarlar
{
    public partial class frmYetkiler : DevExpress.XtraEditors.XtraForm
    {
        public frmYetkiler(int KullaniciID)
        {
            _KullaniciID = KullaniciID;
            InitializeComponent();
        }

        int _KullaniciID = -1;

        SqlTransaction TrGenel;

        clsTablolar.Ayarlar.csYetkiler Yetkiler;
        private void frmYetkiler_Load(object sender, EventArgs e)
        {
            try
            {
                // yetkileri burada türetmesine gerek yok var olan ayarları alır şayet bir değişiklik yapılması istenirse o zaman türetir olmaz mı düşün hamısına
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Yetkiler = new clsTablolar.Ayarlar.csYetkiler();

                vGridControl1.DataSource = Yetkiler.YetkilerGetir(SqlConnections.GetBaglanti(), TrGenel, _KullaniciID);
                TrGenel.Commit();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Yetkiler.YetkileriKaydet(SqlConnections.GetBaglanti(), TrGenel, _KullaniciID);
                TrGenel.Commit();
            }
            catch (Exception)
            {
                TrGenel.Rollback();
                
            }
        }

        private void vGridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}