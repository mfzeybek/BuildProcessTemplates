using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace clsTablolar.TeraziSatisClaslari
{
    public partial class frmSatislar : DevExpress.XtraEditors.XtraForm
    {
        public frmSatislar(SqlConnection Baglanti)
        {
            _Baglanti = Baglanti;
            InitializeComponent();
        }
        SqlConnection _Baglanti;

        SqlTransaction Trgenel;

        public string FaturaBarkod = "";

        private void frmSatislar_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            checkButton_OdemesiTamamlanmamis.Checked = true;
            checkButton1.Checked = true;

            btnYenile_Click(null, null);
            gcSatisHareketleri.DataSource = Hareketler.dt_FaturaHareketleri;
        }


        DataTable dt;
        DataTable dt_hareketleri;
        SqlDataAdapter da_Hareketleri;
        private void btnYenile_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(@"select CariID, CariKod, CariTanim, FaturaNo, DegismeTarihi, FaturaBarkod, 
FaturaTutari, DuzenlemeTarihi, FaturaTarihi, FaturaTipi, Fatura.FaturaID
--, TeraziFaturaID 
from Fatura with(nolock)
--inner join TeraziFaturaIliski with(nolock) on TeraziFaturaIliski.FaturaID = Fatura.FaturaID 
where HizliSatistaGozukecekMi = 1 and Fatura.SilindiMi = 0  ", _Baglanti))
                {
                    if (checkButton_OdemesiTamamlanmamis.Checked == true)
                    {
                        da.SelectCommand.CommandText += @" and [dbo].[FaturaninOdemesiTamamlanmisMi](Fatura.FaturaID) = 0";
                    }
                    else if (checkButton_OdemesiTamamlanmis.Checked == true)
                    {
                        da.SelectCommand.CommandText += @" and [dbo].[FaturaninOdemesiTamamlanmisMi](Fatura.FaturaID) = 1 and FaturaTarihi > (select DATEADD(hour, -3, getdate()))";
                    }

                    if (checkButton1.Checked == true)
                    {
                        da.SelectCommand.CommandText += @" and FaturaTarihi > (select DATEADD(hour, -1, getdate()))";
                    }
                    da.SelectCommand.CommandText += @" order by FaturaTarihi desc ";

                    //Trgenel = _Baglanti.BeginTransaction();

                    //da.SelectCommand.Transaction = Trgenel;
                    using (dt = new DataTable())
                    {
                        da.Fill(dt);

                        //Trgenel.Commit();
                        gcSatislar.DataSource = dt;
                        gvSatislar_FocusedRowChanged(null, null);
                    }
                }
            }
            catch (Exception)
            {
                try
                { Trgenel.Rollback(); }
                catch (Exception) { }
                MessageBox.Show("hata mk");
            }
        }

        private void HareketleriGetir()
        {
            using (da_Hareketleri = new SqlDataAdapter("", _Baglanti))
            { }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            //Trgenel.Commit();
            FaturaBarkod = gvSatislar.GetFocusedRowCellValue(colFaturaBarkod).ToString();


            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            _Baglanti.Close();
            _Baglanti = null;
            //da_Hareketleri.Dispose();
            //this.Dispose();

            dt.Dispose();
            Trgenel.Dispose();
            Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            try
            {
                Trgenel.Commit();
                //_Baglanti.Close();
                //_Baglanti.Dispose();
                //Trgenel.Dispose();
            }
            catch (Exception)
            {
                try { Trgenel.Rollback(); }
                catch (Exception) { }
            }
            finally
            { Close(); }

        }

        private void btnOncekiSayfa_Click(object sender, EventArgs e)
        {
            gvSatislar.MovePrevPage();
        }

        private void btnSonrakiSayfa_Click(object sender, EventArgs e)
        {
            gvSatislar.MoveNextPage();
        }

        private void checkButton_OdemesiTamamlanmamis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton_OdemesiTamamlanmamis.Checked == true)
            {
                checkButton_OdemesiTamamlanmamis.Image = clsTablolar.Properties.Resources.apply_32x32;
                checkButton_OdemesiTamamlanmis.Checked = false;
            }
            else
            { checkButton_OdemesiTamamlanmamis.Image = clsTablolar.Properties.Resources.cancel_32x32; }
        }

        private void checkButton_OdemesiTamamlanmis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton_OdemesiTamamlanmis.Checked == true)
            {
                checkButton_OdemesiTamamlanmis.Image = clsTablolar.Properties.Resources.apply_32x32;
                checkButton_OdemesiTamamlanmamis.Checked = false;
            }
            else
            { checkButton_OdemesiTamamlanmis.Image = clsTablolar.Properties.Resources.cancel_32x32; }
        }

        private void gvSatislar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvSatislar.RowCount > 0)
            { HareketleriGetir((int)gvSatislar.GetFocusedRowCellValue(colFaturaID)); }
        }
        clsTablolar.Fatura.csFaturaHareket Hareketler = new Fatura.csFaturaHareket();
        void HareketleriGetir(int FaturaID)
        {
            try
            {
                Trgenel = _Baglanti.BeginTransaction();
                Hareketler.FaturaHareketleriniGetir(_Baglanti, Trgenel, FaturaID);
                Trgenel.Commit();
            }
            catch (Exception)
            {
                try { Trgenel.Rollback(); }
                catch (Exception) { }
            }
        }

        private void btnBirlestir_Click(object sender, EventArgs e)
        {
            gvSatislar.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            gvSatislar.OptionsSelection.MultiSelect = true;
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton1.Checked == true)
            {
                checkButton1.Image = clsTablolar.Properties.Resources.apply_32x32;
            }
            else
            { checkButton1.Image = clsTablolar.Properties.Resources.cancel_32x32; }
        }

        private void btnAyir_Click(object sender, EventArgs e)
        {
            // Ayırma işlemi hareketleri

            if (!gvSatisHareketleri.IsMultiSelect)
            {
                gvSatisHareketleri.OptionsSelection.MultiSelect = true;
                gvSatisHareketleri.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                //barButtonItem_HepsiniSec.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //layoutView1.OptionsSelection.MultiSelect = true;
            }
            else
            {
                ahandaYeniSatis();

                decimal Miktar = 0;
                decimal Fiyat = 0;
                decimal StokIsk1 = 0;
                foreach (int item in gvSatisHareketleri.GetSelectedRows())
                {

                    Miktar = (decimal)gvSatisHareketleri.GetRowCellValue(item, colMiktar);
                    Fiyat = (decimal)gvSatisHareketleri.GetRowCellValue(item, colAnaBirimFiyat);
                    StokIsk1 = (decimal)gvSatisHareketleri.GetRowCellValue(item, colStokIskonto1);

                    StokEkle((int)gvSatisHareketleri.GetFocusedRowCellValue(colStokID), Miktar, Fiyat, StokIsk1);

                    
                }
                foreach (int item in gvSatisHareketleri.GetSelectedRows())
                {
                    //HareketSil();
                }

                gvSatisHareketleri.OptionsSelection.MultiSelect = false;
                //barButtonItem_HepsiniSec.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //gvStokListesi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
                //layoutView1.OptionsSelection.MultiSelect = false;
            }
        }
        public delegate bool ahandaStokEkle(int StokID, decimal Miktar, decimal KdvDahilStokFiyat, decimal StokIsk1Yuzde);
        public ahandaStokEkle StokEkle;

        public delegate void YeniSatis();
        public YeniSatis ahandaYeniSatis;

        public delegate void _HareketSil();
        public _HareketSil HareketSil;
    }
}
