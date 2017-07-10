using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace clsTablolar.TeraziSatisClaslari
{
    public partial class frmSiparisListesi : Form
    {

        public delegate void dlg_SiparisiSatisaAktarma(string FaturaBarkod);
        public dlg_SiparisiSatisaAktarma SiparisiSatisaAktarma;

        public frmSiparisListesi(SqlConnection Baglanti, int TeraziID)
        {
            this.Baglanti = Baglanti;
            TeraziID = TeraziID;
            InitializeComponent();
        }

        SqlConnection Baglanti;
        int TeraziID;
        //SqlConnection connn = new SqlConnection();

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        SqlTransaction TrGenel;
        clsTablolar.Siparis.csSiparisDurumTanimlari Tanimlar = new clsTablolar.Siparis.csSiparisDurumTanimlari();

        private void frmSiparisListesi_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = Baglanti.BeginTransaction();
                checkedListBoxControl1.DataSource = Tanimlar.Dt_Getir_HepsiSatiriIleBirlikte(Baglanti, TrGenel);
                TrGenel.Commit();
                //checkedListBoxControl1.CheckMember = "SiparisDurumTanimID";

                checkedListBoxControl1.ValueMember = "SiparisDurumTanimID";
                checkedListBoxControl1.DisplayMember = "SiparisDurumTanimAdi";



                Siparis = new clsTablolar.Siparis.csSiparisArama(Baglanti, TrGenel, -1);

                Siparis.HizliSatistaGozukecekMi = 1;
                Siparis.HizliSatistaDegisiklikYapmaIzniVarMi = 1; // aslında bunun farketmemesi lazım

                TrGenel = Baglanti.BeginTransaction();
                SiparisDetayi = new clsTablolar.Siparis.csSiparisHareket(Baglanti, TrGenel, -1);
                TrGenel.Commit();

                gcSiparis.DataSource = Siparis.dt_SiparisListesi;
                gcSiparisDetayi.DataSource = SiparisDetayi.dt_SiparisHareketleri;


                Getir();

                //gvSiparis.Columns[colTeslimTarihi.Name].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                //colTeslimTarihi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
                //gvSiparis.OptionsCustomization.AllowSort = true;


                //gvSiparis.Columns[1].SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
                //gvSiparis.Columns[1].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

                gvSiparis.BeginSort();
                gvSiparis.ClearSorting();
                colTeslimTarihi.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
                colTeslimTarihi.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                gvSiparis.EndSort();

                //gvSiparis.OptionsCustomization.

            }
            catch (Exception)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }
                throw;
            }
        }
        clsTablolar.Siparis.csSiparisArama Siparis;

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            gvSiparis.FocusedRowChanged -= gvSiparis_FocusedRowChanged;
            Getir();
            gvSiparis.FocusedRowChanged += gvSiparis_FocusedRowChanged;
            gvSiparis_FocusedRowChanged(null, null);
        }

        clsTablolar.Siparis.csSiparisHareket SiparisDetayi;
        private void gvSiparis_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TrGenel = Baglanti.BeginTransaction();
                DetayiniGetir();
                TrGenel.Commit();
            }
            catch (Exception)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }
                throw;
            }

        }
        void DetayiniGetir()
        {
            if (gvSiparis.RowCount != 0)
                SiparisDetayi = new clsTablolar.Siparis.csSiparisHareket(Baglanti, TrGenel, (int)gvSiparis.GetFocusedRowCellValue(colSiparisID));
            else
                SiparisDetayi = new clsTablolar.Siparis.csSiparisHareket(Baglanti, TrGenel, -1);

            gcSiparisDetayi.DataSource = SiparisDetayi.dt_SiparisHareketleri;
        }



        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
        void Getir()
        {
            try
            {
                Siparis.SiparisDurumTanimID = new int[checkedListBoxControl1.CheckedItems.Count];
                for (int i = 0; i < checkedListBoxControl1.CheckedItems.Count; i++)
                {
                    Siparis.SiparisDurumTanimID[i] = (int)checkedListBoxControl1.CheckedItems[i];
                }



                Siparis.MuhasebelenmeDrumu = new object[1];
                Siparis.MuhasebelenmeDrumu[0] = radioGroup1.EditValue;
                gvSiparis.FocusedRowChanged -= gvSiparis_FocusedRowChanged;
                TrGenel = Baglanti.BeginTransaction();
                Siparis.SiparisAraListe(Baglanti, TrGenel);
                TrGenel.Commit();
            }
            catch (Exception)
            {
                try
                {
                    TrGenel.Rollback();
                }
                catch (Exception) { }
                throw;
            }
            finally
            {
                gvSiparis.FocusedRowChanged += gvSiparis_FocusedRowChanged;
                gvSiparis_FocusedRowChanged(null, null);
            }
        }
        private void btnSiparisiAc_Click(object sender, EventArgs e)
        {
            if (gvSiparis.RowCount == 0)
                return;

            using (frmSiparis frm = new frmSiparis((int)gvSiparis.GetFocusedRowCellValue(colSiparisID), Baglanti, TeraziID, -1))
            {
                frm.SiparisiSatisaAktarma = this.SatisaAKtar;
                frm.ShowDialog();
            }
        }
        public void SatisaAKtar(string FaturaBarkod)
        {
            SatisaAKtar(FaturaBarkod);
        }


        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                Siparis.IlkFaturaTarihi = DateTime.MinValue;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                Siparis.IlkFaturaTarihi = DateTime.Today.Date.AddDays(-2);
            }
            Getir();
        }
    }
}
