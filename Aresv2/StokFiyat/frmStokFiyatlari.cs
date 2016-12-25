using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.Stok
{
    public partial class frmStokFiyatlari : DevExpress.XtraEditors.XtraForm
    {
        /* Stok ID ve Alış Fiyatlarımı Satış Fiyatlarını mı istendeiği öğrenilsin, istediği bu stokID ye göre Bütün fiyatlarını, çeksin sto */


        /* Hareketlerinde ne lazım?? 
         * Hareketin Tarihi, Hareketin Carisi, Hareketin Fiyati, Hareketin Miktari 
         tabi Bütün hareketlerini çekmesin en son 5 hareketini çeksin mesela*/


        public frmStokFiyatlari(NeFiyati AlisMiSAtisMi, int StokID, int CariID)
        {
            InitializeComponent();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            if (AlisMiSAtisMi == NeFiyati.Satis)
            {
                gridControl1.DataSource = Fiyatlar.SatisFiyatiGetir(SqlConnections.GetBaglanti(), TrGenel, StokID);
                repositoryItemLookUpEdit1.DataSource = FiyatTanim.SatisTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel);
            }
            else if (AlisMiSAtisMi == NeFiyati.Alis)
            {
                gridControl1.DataSource = Fiyatlar.AlisFiyatiGetir(SqlConnections.GetBaglanti(), TrGenel, StokID);
                repositoryItemLookUpEdit1.DataSource = FiyatTanim.AlisTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel);
            }
            else if (AlisMiSAtisMi == NeFiyati.Hepsi)
            {
                gridControl1.DataSource = Fiyatlar.ButunFiyatlariniGetir(SqlConnections.GetBaglanti(), TrGenel, StokID);
                repositoryItemLookUpEdit1.DataSource = FiyatTanim.FiyatTanimGetir(SqlConnections.GetBaglanti(), TrGenel);
            }
            TrGenel.Commit();



            repositoryItemLookUpEdit1.DisplayMember = "FiyatTanimAdi";
            repositoryItemLookUpEdit1.ValueMember = "FiyatTanimID";

            HareketleriGetir(StokID, CariID, AlisMiSAtisMi);

            _StokID = StokID;
            _CariID = CariID;
            _Nefiyati = AlisMiSAtisMi;



            repositoryItemLookUpEdit2.DataSource = DT_IslemTipi.ToDataTable(typeof(clsTablolar.IslemTipi));
            repositoryItemLookUpEdit2.DisplayMember = "name";
            repositoryItemLookUpEdit2.ValueMember = "value";
        }

        int _StokID;
        int _CariID;

        NeFiyati _Nefiyati;

        SqlTransaction TrGenel;

        clsTablolar.Stok.csStokFiyat Fiyatlar = new clsTablolar.Stok.csStokFiyat();

        clsTablolar.csFiyatTanim FiyatTanim = new clsTablolar.csFiyatTanim();



        public delegate void dlg_FiyatVer(decimal Fiyat);
        public dlg_FiyatVer FiyatVer;


        public enum NeFiyati
        {
            Alis,
            Satis,
            Hepsi
        }

        clsTablolar.csEnumDanDtVer DT_IslemTipi = new clsTablolar.csEnumDanDtVer();

        void HareketleriGetir(int StokID, int CariID, NeFiyati AlismiiSatissmi)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"select top 5 Fatura.FaturaTipi, Fatura.FaturaTarihi ,CariID, Fatura.CariTanim ,StokID, FaturaHareketStokAdi, Miktar, StokAnaBirimID, FaturaHareket.AnaBirimFiyat ,IskontoluFiyat from FaturaHareket
inner join fatura on Fatura.FaturaID = FaturaHareket.FaturaID and Fatura.SilindiMi = 0
where stokID = @StokID
", SqlConnections.GetBaglanti());

            da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

            if (CariID != -1) // -1 verilmezse Cari ye göre de filtrelenmesi isteniyordur
            {
                da.SelectCommand.CommandText += " and CariID = @CariID ";
                da.SelectCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
            }
            if (AlismiiSatissmi == NeFiyati.Alis)
            {
                da.SelectCommand.CommandText += " and FaturaTipi = @FaturaTipi ";
                da.SelectCommand.Parameters.Add("@FaturaTipi", SqlDbType.Int).Value = Convert.ToInt32(clsTablolar.IslemTipi.AlisFaturasi);
            }
            if (AlismiiSatissmi == NeFiyati.Satis)
            {
                da.SelectCommand.CommandText += " and FaturaTipi = @FaturaTipi ";
                da.SelectCommand.Parameters.Add("@FaturaTipi", SqlDbType.Int).Value = Convert.ToInt32(clsTablolar.IslemTipi.SatisFaturasi);
            }




            da.SelectCommand.CommandText += "order by  Fatura.FaturaTarihi desc";

            DataTable dt = new DataTable();
            da.Fill(dt);

            gridControl2.DataSource = dt;
        }


        private void frmStokFiyatlari_Load(object sender, EventArgs e)
        {

        }

        public int FiyatTanimID;
        public decimal Fiyat;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            FiyatTanimID = (int)gridView1.GetFocusedRowCellValue(colFiyatTanimID);
            Fiyat = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colFiyat));
            if (FiyatVer != null)
                FiyatVer(Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colFiyat)));

            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.FocusedColumn == colIskontoluFiyat) // eğer iskontolu fiyata tıklarsa iskontolu fiyatı versin
            {
                FiyatTanimID = -2;
                Fiyat = Convert.ToDecimal(gridView2.GetFocusedRowCellValue(colIskontoluFiyat));

                if (FiyatVer != null)
                    FiyatVer(Convert.ToDecimal(gridView2.GetFocusedRowCellValue(colIskontoluFiyat)));
            }
            else
            {
                Fiyat = Convert.ToDecimal(gridView2.GetFocusedRowCellValue(colAnaBirimFiyat));
                if (FiyatVer != null)
                {
                    FiyatVer(Convert.ToDecimal(gridView2.GetFocusedRowCellValue(colAnaBirimFiyat)));
                }
            }

            FiyatTanimID = -2; // bunu basit Üretimde kullanıyorsun. -2 mesela şey olsun bişey olsun
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void radioGroup1_CausesValidationChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
                HareketleriGetir(_StokID, _CariID, _Nefiyati);
            else
                HareketleriGetir(_StokID, -1, _Nefiyati);
        }
    }
}