using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.Cari.CariHr
{
    public partial class frmCariHrListesiv3 : DevExpress.XtraEditors.XtraForm
    {
        public frmCariHrListesiv3(NasilAcicak listearama)
        {
            AramaMiListeMi = listearama;
            InitializeComponent();
        }


        public enum NasilAcicak
        {
            Liste,
            Arama
        }
        NasilAcicak AramaMiListeMi;

        SqlTransaction Trgenel;

        private void frmCariHrListesiv3_Load(object sender, EventArgs e)
        {
            clsTablolar.csEnumDanDtVer dt = new clsTablolar.csEnumDanDtVer();

            checkedListBoxControl_IslemTipi.DataSource = dt.ToDataTable(typeof(clsTablolar.cari.CariHr.CariHrEntegrasyon));
            checkedListBoxControl_IslemTipi.DisplayMember = "name";
            checkedListBoxControl_IslemTipi.ValueMember = "value";
            //checkedListBoxControl_IslemTipi.CheckMember = "value";

            lookUpEdit1.Properties.DataSource = clsTablolar.cari.csCariGrup.CariGrupListesi(SqlConnections.GetBaglanti());
            lookUpEdit1.Properties.DisplayMember = "CariGrup";
            lookUpEdit1.Properties.ValueMember = "CariGrupID";

            KasaGetir();
        }

        void KasaGetir()
        {
            clsTablolar.Kasa.csKasaHareket Kasalar = new clsTablolar.Kasa.csKasaHareket();

            Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
            lkpKasa.Properties.DataSource = Kasalar.KasaListeGetir(SqlConnections.GetBaglanti(), Trgenel);
            Trgenel.Commit();


            lkpKasa.Properties.ValueMember = "KasaID";
            lkpKasa.Properties.DisplayMember = "KasaAdi";
            //lkpKasa.EditValue = 2;


        }

        private void btnCariHrAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            if (Convert.ToInt32(gridView1.GetFocusedRowCellValue("Entegrasyon")) == Convert.ToInt32(clsTablolar.cari.CariHr.CariHrEntegrasyon.CariKartHareketi))
            {
                Cari.CariHr.frmCariHrKarti frm = new frmCariHrKarti((int)gridView1.GetFocusedRowCellValue("CariHrID"));
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            if (Convert.ToInt32(gridView1.GetFocusedRowCellValue("Entegrasyon")) == Convert.ToInt32(clsTablolar.cari.CariHr.CariHrEntegrasyon.AlisFaturasi) || Convert.ToInt32(gridView1.GetFocusedRowCellValue("Entegrasyon")) == Convert.ToInt32(clsTablolar.cari.CariHr.CariHrEntegrasyon.SatisFaturasi))
            {
                Fatura.frmFaturaDetay frm = new Fatura.frmFaturaDetay((int)gridView1.GetFocusedRowCellValue("EntegrasyonID"));
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            if (Convert.ToInt32(gridView1.GetFocusedRowCellValue("Entegrasyon")) == Convert.ToInt32(clsTablolar.cari.CariHr.CariHrEntegrasyon.AlinanCek) || Convert.ToInt32(gridView1.GetFocusedRowCellValue("Entegrasyon")) == Convert.ToInt32(clsTablolar.cari.CariHr.CariHrEntegrasyon.VerilenCek))
            {
                Cek.frmCekKarti frm = new Cek.frmCekKarti((int)gridView1.GetFocusedRowCellValue("EntegrasyonID"));
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
                cs.csGridLayout.InsertLayout(1, this.Name, gridView1, SqlConnections.GetBaglanti(), Trgenel);
                Trgenel.Commit();
            }
            catch (Exception hata)
            {
                Trgenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        clsTablolar.cari.CariHr.csCariHrArama Arama = new clsTablolar.cari.CariHr.csCariHrArama();

        public void btnFiltrele_Click(object sender, EventArgs e)
        {
            try
            {
                Arama.CariAdi = txtCariAdi.Text;
                Arama.Carikodu = txtCariKodu.Text;
                Arama.IlkTarih = deIlkTarih.DateTime;
                Arama.IkinciTarih = deIkınciTarih.DateTime;

                //if (lkpKasa.EditValue != null || !string.IsNullOrEmpty(lkpKasa.EditValue.ToString()))
                Arama.KasaID = (int)lkpKasa.EditValue;
                //else
                //    Arama.KasaID = -1;

                if (checkedListBoxControl_IslemTipi.CheckedItemsCount > 0)
                {
                    Arama.HareketTipleri = ",";

                    for (int i = 0; i < checkedListBoxControl_IslemTipi.CheckedItemsCount; i++)
                    {
                        //if (i > 0) // virgülü koyma ile alaklı bişi sanırım
                        //{
                        //    Arama.HareketTipleri += checkedListBoxControl_IslemTipi.CheckedItems[i].ToString() + " ,";
                        //}
                        //else
                        //{
                        Arama.HareketTipleri += checkedListBoxControl_IslemTipi.CheckedItems[i].ToString() + ",";
                        //}
                    }
                }
                else
                {
                    Arama.HareketTipleri = string.Empty;
                }

                //Arama.HareketTipi = checkedListBoxControl_IslemTipi.CheckedItems
                Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
                gridControl1.DataSource = Arama.HareketleriGetir(SqlConnections.GetBaglanti(), Trgenel);
                try
                {
                    gridView1.RestoreLayoutFromStream(cs.csGridLayout.GetLayout(1, this.Name, gridView1.Name, SqlConnections.GetBaglanti(), Trgenel));
                }
                catch (Exception) { }
                Trgenel.Commit();
            }
            catch (Exception hata)
            {
                Trgenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnCariKartAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;

            frmCariDetay CariKart = new frmCariDetay(Convert.ToInt32(gridView1.GetFocusedRowCellValue("CariID")));
            CariKart.MdiParent = this.MdiParent;
            CariKart.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExceleAktar frm = new frmExceleAktar(gridControl1);
            frm.Show();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBoxControl_IslemTipi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monthEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            deIlkTarih.DateTime = new DateTime(DateTime.Now.Year, (int)monthEdit1.EditValue, 1, 0, 0, 0);
            deIkınciTarih.DateTime = new DateTime(DateTime.Now.Year, (int)monthEdit1.EditValue, 1).AddMonths(1).AddDays(-1);
        }
    }
}