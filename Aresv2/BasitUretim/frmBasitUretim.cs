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
        }

        void Al()
        {
            txtUretilenStokAdi.EditValue = Uretim.UretilenStokAdi;
            txtUretilenStokKodu.EditValue = Uretim.UretilenStokKodu;
            txtUretimMiktari.EditValue = Uretim.UretimMiktari;
        }

        void Ver()
        {
            txtUretilenStokAdi.EditValue = Uretim.UretilenStokAdi;
            txtUretilenStokKodu.EditValue = Uretim.UretilenStokKodu;
            txtUretimMiktari.EditValue = Uretim.UretimMiktari;
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

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Uretim.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Uretim.BasitUretimID);
            UretimDetay.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Uretim.BasitUretimID);
            TrGenel.Commit();

        }
    }
}