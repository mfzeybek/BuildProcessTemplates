using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.Terazi
{
    public partial class frmTeraziStokGruplarininStokButonlari : DevExpress.XtraEditors.XtraForm
    {
        public frmTeraziStokGruplarininStokButonlari(int TeraziStokGrupTanimID)
        {
            _TeraziStokGrupTanimID = TeraziStokGrupTanimID;
            InitializeComponent();
        }

        int _TeraziStokGrupTanimID;



        clsTablolar.Terazi.csTeraziStokGruplari Stoklar = new clsTablolar.Terazi.csTeraziStokGruplari();
        SqlTransaction TrGenel;
        void StokButonlariniGetir(int TeraziStokGrupTanimID)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Stoklar.TeraziStokGruplari_Getir(SqlConnections.GetBaglanti(), TrGenel, TeraziStokGrupTanimID);
                gcStokButonlari.DataSource = Stoklar.dt;

                TrGenel.Commit();
            }
            catch (Exception)
            {
                TrGenel.Rollback();
            }
        }
        Stok.frmStokListesi StokArama;
        clsTablolar.Stok.csStok YeniStok;


        private void frmTeraziStokGruplarininStokButonlari_Load(object sender, EventArgs e)
        {

            Stoklar.TeraziStokGruplari_Getir(SqlConnections.GetBaglanti(), TrGenel, _TeraziStokGrupTanimID);
            gcStokButonlari.DataSource = Stoklar.dt;

            if (clsTablolar.Ayarlar.csYetkiler.StokKartGorme)
            {
                btnStokKartiAc.Visible = true;
            }
            else
            {
                btnStokKartiAc.Visible = false;
            }
        }


        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            using (StokArama = new Stok.frmStokListesi(true))
            {
                StokArama.Stok_Sec = StokEkle;
                StokArama.ShowDialog();
            }
        }

        void StokEkle(int StokID, decimal Miktar)
        {
            if (Stoklar.dt.Select("StokID = '" + StokID.ToString() + "'").Length > 0)
            {
                MessageBox.Show("Stok Daha Önce eklenmiş");


                int dtRowIndex = Stoklar.dt.Rows.IndexOf(Stoklar.dt.Select("StokID = '" + StokID.ToString() + "'")[0]);
                int RowHandle = gvStokButonlari.GetRowHandle(dtRowIndex);
                gvStokButonlari.FocusedRowHandle = RowHandle;
                return;
            }


            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

            YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, StokID);
            TrGenel.Commit();

            Stoklar.dt.Rows.Add(Stoklar.dt.NewRow());

            Stoklar.dt.Rows[Stoklar.dt.Rows.Count - 1]["StokID"] = StokID;
            Stoklar.dt.Rows[Stoklar.dt.Rows.Count - 1]["StokAdi"] = YeniStok.StokAdi;

            Stoklar.dt.Rows[Stoklar.dt.Rows.Count - 1]["SiraNu"] = gvStokButonlari.RowCount;
            Stoklar.dt.Rows[Stoklar.dt.Rows.Count - 1]["Aktif"] = true;
            Stoklar.dt.Rows[Stoklar.dt.Rows.Count - 1]["ButonTipi"] = 1;

            gvStokButonlari.FocusedRowHandle = gvStokButonlari.RowCount - 1;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Stoklar.StoklariGruplaraKaydetHamisina(SqlConnections.GetBaglanti(), TrGenel, _TeraziStokGrupTanimID);
        }

        private void btnStokCikar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili Stok Çıkartılsın mı?", "Dikkat Hamısına", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                gvStokButonlari.DeleteSelectedRows();
        }

        private void gvStokButonlari_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column == colSiraNu)
            //{
            //    int SimdikiSiraNu = Convert.ToInt16(e.Value);


            //    if (OncekiSiraNu > SimdikiSiraNu) 
            //    {
            //        for (int i = SimdikiSiraNu; i < OncekiSiraNu - SimdikiSiraNu; i++)
            //        {
            //            Stoklar.dt.Rows[i]["SiraNu"] = Convert.ToInt16(Stoklar.dt.Rows[i]["SiraNu"]) + 1;
            //        }
            //    }

            //    if (SimdikiSiraNu > OncekiSiraNu)
            //    {
            //        for (int i = OncekiSiraNu; i < SimdikiSiraNu - OncekiSiraNu; i++)
            //        {
            //            Stoklar.dt.Rows[i]["SiraNu"] = Convert.ToInt16(Stoklar.dt.Rows[i]["SiraNu"]) + 1;
            //        }
            //    }
            //}
        }

        private void gvStokButonlari_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gvStokButonlari_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }

        private void gvStokButonlari_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        int OncekiSiraNu = 0;
        private void gvStokButonlari_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    OncekiSiraNu = (int)gvStokButonlari.GetFocusedRowCellValue(colSiraNu);
            //}
            //catch (Exception)
            //{

            //}

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvStokButonlari.RowCount; i++)
            {
                gvStokButonlari.SetRowCellValue(gvStokButonlari.GetVisibleIndex(i), colSiraNu, gvStokButonlari.GetVisibleIndex(i) + 1);
            }
        }

        private void btnStokKartiAc_Click(object sender, EventArgs e)
        {
            Stok.frmStokDetay frm = new Stok.frmStokDetay((int)gvStokButonlari.GetFocusedRowCellValue(colStokID));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}