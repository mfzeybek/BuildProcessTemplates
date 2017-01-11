using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KasaSatis
{
    public partial class frmKasaRaporu : Form
    {
        public frmKasaRaporu()
        {
            InitializeComponent();
        }

        clsTablolar.Kasa.csKasaHareket KasaHareketi = new clsTablolar.Kasa.csKasaHareket();
        clsTablolar.Kasa.csKasaHareket.KasaRapor Rapor = new clsTablolar.Kasa.csKasaHareket.KasaRapor();

        SqlTransaction TrGenel;
        int _KasaID = KasaSatis.Properties.Settings.Default.KasaID;
        int _PosID = 3;//şimdilik tek pos var Onun ID si 3



        private void frmKasaRaporu_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

            Rapor = KasaHareketi.KasaBakiyeVer(SqlConnections.GetBaglanti(), TrGenel, _KasaID);
            //TrGenel.Commit();

            txtKasaBakiyesi.EditValue = Rapor.KasaBakiye;
            txtNakit.EditValue = Rapor.Alacak;
            txtGiderToplami.EditValue = Rapor.Borc;

            //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Rapor = KasaHareketi.KasaBakiyeVer(SqlConnections.GetBaglanti(), TrGenel, 3); // bu sefer pos un bakiyelerini yüklüyoruz

            // posun çıkışı olabiliyor mu bilmiyorum??
            txtKredi.EditValue = Rapor.KasaBakiye;

            TrGenel.Commit();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
