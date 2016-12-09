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

namespace Aresv2.BasitUretim
{
    public partial class frmBasitUretim : DevExpress.XtraEditors.XtraForm
    {
        public frmBasitUretim(int BasitUretimID)
        {
            _BasitUretimID = BasitUretimID;
            InitializeComponent();
        }
        int _BasitUretimID;
        clsTablolar.BasitUretim.csBasitUretim Uretim = new clsTablolar.BasitUretim.csBasitUretim();
        clsTablolar.BasitUretim.csBasitUretimDetay UretimDetay = new clsTablolar.BasitUretim.csBasitUretimDetay();
        clsTablolar.csFiyatTanim FiyatTanimlari = new clsTablolar.csFiyatTanim();
        SqlTransaction TrGenel;
        int _UretilenStokID = -1;
        int _ReceteID = -1;
        int _CariID = -1;


        private void BasitUretim_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Uretim.Getir(SqlConnections.GetBaglanti(), TrGenel, _BasitUretimID);
            UretimDetay.getir(SqlConnections.GetBaglanti(), TrGenel, _BasitUretimID);



            FiyatTaniminiYukle();
            TrGenel.Commit();

            gridControl1.DataSource = UretimDetay.dt;
            Al();
        }

        void FiyatTaniminiYukle()
        {
            lkpKullanilanFiyatTanimi.Properties.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel);
            lkpKullanilanFiyatTanimi.Properties.DisplayMember = "FiyatTanimAdi";
            lkpKullanilanFiyatTanimi.Properties.ValueMember = "FiyatTanimID";

            repositoryItemLookUpEdit1.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel);
            repositoryItemLookUpEdit1.DisplayMember = "FiyatTanimAdi";
            repositoryItemLookUpEdit1.ValueMember = "FiyatTanimID";
        }

        void Al()
        {
            txtUretilenStokAdi.EditValue = Uretim.UretilenStokAdi;
            txtUretilenStokKodu.EditValue = Uretim.UretilenStokKodu;
            txtUretimMiktari.EditValue = Uretim.UretimMiktari;
            txtAciklama.EditValue = Uretim.Aciklama;
            _UretilenStokID = Uretim.UretilenStokID;
            _CariID = Uretim.CariID;
            _ReceteID = Uretim.BUReceteID;
        }

        void Ver()
        {
            Uretim.UretilenStokAdi = txtUretilenStokAdi.Text;
            Uretim.UretilenStokKodu = txtUretilenStokKodu.Text;
            Uretim.UretimMiktari = Convert.ToDecimal(txtUretimMiktari.EditValue);
            Uretim.Aciklama = txtAciklama.Text;
            Uretim.UretilenStokID = _UretilenStokID;
            Uretim.CariID = _CariID;
            Uretim.BUReceteID = _ReceteID;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (frmBasitUretimRecetesiListesi frm = new frmBasitUretimRecetesiListesi())
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    ReceteSec(frm.ReceteID);
                }
            }
        }


        clsTablolar.BasitUretim.csBasitUretim BasitUretim = new clsTablolar.BasitUretim.csBasitUretim();
        public void ReceteSec(int ReceteID)
        {
            clsTablolar.BasitUretim.csBasitUretimRecete Recete = new clsTablolar.BasitUretim.csBasitUretimRecete(SqlConnections.GetBaglanti(), TrGenel, ReceteID);
            BasitUretim.BUReceteID = Recete.BUReceteID;
            BasitUretim.UretilenStokID = Recete.UretilenStokID;

            BasitUretim.UretimMiktari = Recete.UretimMiktari;
            txtUretimMiktari.EditValue = Recete.UretimMiktari;
            txtUretilenStokAdi.EditValue = Recete.StokAdi;
            txtUretilenStokKodu.EditValue = Recete.StokKodu;
            _UretilenStokID = Recete.UretilenStokID;


            clsTablolar.BasitUretim.csBasitUretimReceteDetay Recetedetay = new clsTablolar.BasitUretim.csBasitUretimReceteDetay();
            Recetedetay.Getir(SqlConnections.GetBaglanti(), TrGenel, Recete.BUReceteID);

            foreach (DataRow item in Recetedetay.dt.AsEnumerable())
            {
                //StokEkle((int)item["MalzemeStokID"]);
                UretimDetay.dt.Rows.Add(UretimDetay.dt.NewRow());
                UretimDetay.dt.Rows[UretimDetay.dt.Rows.Count - 1]["MalzemeStokID"] = item["MalzemeStokID"];
                UretimDetay.dt.Rows[UretimDetay.dt.Rows.Count - 1]["MaliyetFiyatTanimID"] = item["MaliyetFiyatTanimID"];
                //UretimDetay.dt.Rows[UretimDetay.dt.Rows.Count - 1]["Maliyet"] = item[""];
                UretimDetay.dt.Rows[UretimDetay.dt.Rows.Count - 1]["GerekliMiktar"] = item["GerekliMiktar"];
                //UretimDetay.dt.Rows[UretimDetay.dt.Rows.Count - 1]["MaliyetTutari"] = item["MalzemeStokID"];
                UretimDetay.dt.Rows[UretimDetay.dt.Rows.Count - 1]["Aciklama"] = item["Aciklama"];
                UretimDetay.dt.Rows[UretimDetay.dt.Rows.Count - 1]["MalzemeStokAdi"] = item["StokAdi"];
                UretimDetay.dt.Rows[UretimDetay.dt.Rows.Count - 1]["MalzemeStokKodu"] = item["StokKodu"];

            }
        }
        public void StokEkle(int StokID)
        {


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUretilenStokKodu.Text))
            {
                MessageBox.Show("Üretilecek Stok Seçilmedi");
                return;
            }

            Ver();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Uretim.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Uretim.BasitUretimID);
            UretimDetay.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Uretim.BasitUretimID);
            TrGenel.Commit();
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        frmCariListe cariSec = new frmCariListe();

        private void btnCariSec_Click(object sender, EventArgs e)
        {
            cariSec._CariIDVer = CariSec;
            cariSec.ShowDialog();
        }

        void CariSec(int CariID)
        {
            this._CariID = CariID;
            clsTablolar.cari.csCariv2 carr = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), TrGenel, CariID);
            txtCariTanim.Text = carr.CariTanim;
            txtCariKodu.Text = carr.CariKod;
        }
    }
}