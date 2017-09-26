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

namespace Aresv2.Stok
{
    public partial class frmStokGruplari : DevExpress.XtraEditors.XtraForm
    {
        public enum NasilAcsin
        {
            AramaIcin,
            DuzenlemeIcin
        }
        public frmStokGruplari(NasilAcsin AcmaSekli)
        {
            this.AcmaSekli = AcmaSekli;
            InitializeComponent();
        }
        //public frmStokGruplari(NasilAcsin AcmaSekli, list[SeciliStokGrubu] SeciliOlanlar)
        //{
        //    SeciliStokGruplari = SeciliOlanlar;
        //    this.AcmaSekli = AcmaSekli;
        //    InitializeComponent();
        //}




        NasilAcsin AcmaSekli;
        SqlTransaction TrGenel;
        public clsTablolar.Stok.csStokGrup Guplar;


        private void frmStokGruplari_Load(object sender, EventArgs e)
        {



            Guplar = new clsTablolar.Stok.csStokGrup();
            treeList1.DataSource = Guplar.StokGrupDoldur(SqlConnections.GetBaglanti(), TrGenel);

            treeList1.ParentFieldName = "UstGrupID";

            treeList1.KeyFieldName = "StokGrupID";
            if (AcmaSekli == NasilAcsin.AramaIcin)
            {

                btnDeleteItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                btnKaydetitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                btnAltGrupEkleItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                treeList1.OptionsView.ShowCheckBoxes = true;
                treeList1.OptionsBehavior.Editable = false;
            }
            else // düzenleme için
            {
                btnTamamItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            treeList1.ExpandAll();
            if (SeciliStokGruplari != null && SeciliStokGruplari.Count > 0)
            {
                foreach (var item in SeciliStokGruplari)
                {
                    treeList1.FindNodeByKeyID(item.StokGrupID).Checked = true;
                }
            }
        }

        int ahabunesacmalik = 1;

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if ((int)treeList1.GetFocusedRowCellValue(colStokGrupID) < 0) //
            {
                MessageBox.Show("Bu işlemi yapmadan önce kaydetmen gerekiyor");
                return;
            }
            Guplar.dt.Rows.Add(Guplar.dt.NewRow());
            Guplar.dt.Rows[Guplar.dt.Rows.Count - 1]["UstGrupID"] = treeList1.GetFocusedRowCellValue(colStokGrupID);
            Guplar.dt.Rows[Guplar.dt.Rows.Count - 1]["StokGrupID"] = -1 * ahabunesacmalik;
            ahabunesacmalik++;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Guplar.TablodanGrupKaydet(SqlConnections.GetBaglanti(), TrGenel);
                TrGenel.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            treeList1.DeleteSelectedNodes();
        }

        public class SeciliStokGrubu
        {
            public int StokGrupID { get; set; }
            public string StokGrupAdi { get; set; }
        }

        public List<SeciliStokGrubu> SeciliStokGruplari;

        private void btnTamam_Click(object sender, EventArgs e)
        {
            //SeciliStokGruplari = treeList1.GetSelectedCells().Capacity;

            SeciliStokGruplari = new List<SeciliStokGrubu>(treeList1.GetAllCheckedNodes().Count);

            foreach (var item in treeList1.GetAllCheckedNodes())
            {
                SeciliStokGruplari.Add(new SeciliStokGrubu() { StokGrupAdi = item[0].ToString(), StokGrupID = (int)treeList1.GetRowCellValue(item, colStokGrupID) });
            }
            this.DialogResult = DialogResult.Yes;
        }
    }
}