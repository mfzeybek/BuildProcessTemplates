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
using DevExpress.XtraGrid.Helpers;



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

            //gridView1.DataSource
            //colMaliyet.OptionsColumn.ImmediateUpdateRowPosition = 

            DevExpress.XtraGrid.Helpers.GridColumnData data = new GridColumnData(gridView1);

            FiyatTaniminiYukle();
            TrGenel.Commit();

            gridControl1.DataSource = UretimDetay.dt;
            Al();
        }

        void FiyatTaniminiYukle()
        {
            lkpKullanilanFiyatTanimi.Properties.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel, true);
            lkpKullanilanFiyatTanimi.Properties.DisplayMember = "FiyatTanimAdi";
            lkpKullanilanFiyatTanimi.Properties.ValueMember = "FiyatTanimID";

            repositoryItemLookUpEdit1.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel, true);
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
            using (frmBasitUretimRecetesiListesi frm = new frmBasitUretimRecetesiListesi(false))
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
            if (gridView1.IsEditing)
                gridView1.CloseEditor();

            if (gridView1.FocusedRowModified)
                gridView1.UpdateCurrentRow();

            if (string.IsNullOrEmpty(txtUretilenStokKodu.Text))
            {
                MessageBox.Show("Üretilecek Stok Seçilmedi");
                return;
            }

            Ver();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            Uretim.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Uretim.BasitUretimID);
            UretimDetay.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Uretim.BasitUretimID);

            clsTablolar.Stok.csStokHr UretilenStok = new clsTablolar.Stok.csStokHr();
            UretilenStok.AhandaKolaycaBasitUretimdetaydanStokHrEEkledik(SqlConnections.GetBaglanti(), TrGenel, Uretim.BasitUretimID);

            TrGenel.Commit();
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            Stok.frmStokListesi frm = new Stok.frmStokListesi(true);
            frm.Stok_Sec = StokEkle;
            frm.ShowDialog();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        void StokEkle(int StokID, decimal Miktar)
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

        private void btnStokCikar_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;
            if (MessageBox.Show("Seçili Satır Silinsin Mi??", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
            }
        }

        private void btnStokAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                return;

            Stok.frmStokDetay frm = new Stok.frmStokDetay((int)gridView1.GetFocusedRowCellValue(colMalzemeStokID));
            frm.ShowDialog();
        }

        private void btnFiyatTanim_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            using (Stok.frmStokFiyatlari frm = new Stok.frmStokFiyatlari(Stok.frmStokFiyatlari.NeFiyati.Hepsi, (int)gridView1.GetFocusedRowCellValue(colMalzemeStokID), -1))
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    gridView1.SetFocusedRowCellValue(colMaliyet, frm.Fiyat);
                    gridView1.SetFocusedRowCellValue(colMaliyetFiyatTanimID, frm.FiyatTanimID);
                }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colMaliyet || e.Column == colGerekliMiktar)
            {
                //decimal Maliyet = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, colMaliyet));
                //decimal GerekliMiktar = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, colGerekliMiktar));
                //decimal MAliyetTutari = Maliyet * GerekliMiktar;
                //gridView1.SetRowCellValue(e.RowHandle, colMaliyetTutari, MAliyetTutari);

                //MaliyetTutariHesapla();
            }
        }

        decimal DecimalaCevir(object Deger)
        {
            if (Deger is null || Deger == "" || Deger == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(Deger);
        }

        void SatirHesapla(DevExpress.XtraGrid.Columns.GridColumn kolon, int _rowHandle ,decimal Deger)
        {




        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal Maliyet;
            decimal GerekliMiktar;
            int Maliyetkolon = colMaliyet.ColumnHandle;

            if (e.Column == colMaliyet)
            {
                gridView1.SetFocusedRowCellValue(colMaliyetFiyatTanimID, -2);
                Maliyet = DecimalaCevir(e.Value);
            }
            else
                Maliyet = DecimalaCevir(gridView1.GetRowCellValue(e.RowHandle, colMaliyet));

            if (e.Column == colGerekliMiktar)
                GerekliMiktar = DecimalaCevir(e.Value);
            else
                GerekliMiktar = DecimalaCevir(gridView1.GetRowCellValue(e.RowHandle, colGerekliMiktar));


            if (e.Column == colMaliyet || e.Column == colGerekliMiktar)
            {
                decimal MaliyetTutari = Maliyet * GerekliMiktar;
                gridView1.SetRowCellValue(e.RowHandle, colMaliyetTutari, MaliyetTutari);
                MaliyetTutariHesapla();
            }
            //if (gridView1.FocusedRowModified)

            //    if (gridView1.IsEditing)
            //        gridView1.PostEditor();



            //gridView1.BeginInit();
            //gridView1.EndInit();
            //gridView1.
            //if (gridView1.IsEditing)
            //    gridView1.CloseEditor();


            //gridView1.UpdateCurrentRow();

            //gridView1.UpdateCurrentRow();

            //DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //TextEdit edit = view.ActiveEditor as TextEdit;
            //if (edit == null) return;
            ////if (edit.Text.Length > 3)
            //{
            //    edit.SelectionStart = edit.Text.Length;
            //    edit.SelectionLength = 0;
            //}




            //gridView1.
            //gridView1.SetFocusedRowCellValue(e.Column, e.Value);
            //gridView1.UpdateCurrentRow();
            //gridView1.PostEditor();



            //if (gridView1.IsEditing)
            //    gridView1.CloseEditor();

            //if (gridView1.FocusedRowModified)
            //    gridView1.UpdateCurrentRow();

        }

        void MaliyetTutariHesapla()
        {
            decimal Toplam = 0;

            foreach (var item in UretimDetay.dt.AsEnumerable().Where(s => s.RowState != DataRowState.Deleted))
            {
                if (!item.IsNull(colMaliyetTutari.FieldName))
                    Toplam += Convert.ToDecimal(item[colMaliyetTutari.FieldName]);
            }
            txtToplamMaliyet.EditValue = Toplam;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (lkpKullanilanFiyatTanimi.EditValue is null) return;

            for (int i = 0; i < gridView1.RowCount; i++)
            {

                gridView1.SetRowCellValue(i, colMaliyet, FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, (int)lkpKullanilanFiyatTanimi.EditValue, (int)gridView1.GetRowCellValue(i, colMalzemeStokID)));
                gridView1.SetRowCellValue(i, colMaliyetFiyatTanimID, (int)lkpKullanilanFiyatTanimi.EditValue);
            }
        }
    }
}