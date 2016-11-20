using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Linq;



namespace Aresv2.Fatura
{
    public partial class frmFaturaKarAnalizi : Form
    {
        public frmFaturaKarAnalizi()
        {
            InitializeComponent();
        }
        DataTable dt_FaturalarinStoklari;
        DataTable dt_StokAGoreGruplu;
        DataSet ds = new DataSet();

        SqlTransaction TrGenel;

        private void frmFaturaKarAnalizi_Load(object sender, EventArgs e)
        {
            DataTableAyarla();
            ds.Tables.Add(dt_FaturalarinStoklari);
        }

        private void btnFaturadanSec_Click(object sender, EventArgs e)
        {
            frmFaturaListesi frm = new frmFaturaListesi(frmFaturaListesi.AcmaYontemi.FaturaArama);
            frm.cmbGirisCikis.SelectedIndex = 2;
            frm.cmbGirisCikis.Enabled = false;
            frm.Fatura_Sec = FaturaEkle;
            frm.ShowDialog();
        }

        public void FaturaEkle(int FaturaID)
        {
            try
            {
                clsTablolar.Fatura.csFaturaHareket hareket = new clsTablolar.Fatura.csFaturaHareket();
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                hareket.FaturaHareketleriniGetir(SqlConnections.GetBaglanti(), TrGenel, FaturaID);




                foreach (DataRow item in hareket.dt_FaturaHareketleri.AsEnumerable())
                {
                    if (dt_FaturalarinStoklari.Select("FaturaHareketID = " + item["FaturaHareketID"]).Length != 0)
                    {
                        MessageBox.Show("Bu hareket daha önce eklenmiş");
                        continue;
                    }





                    dt_FaturalarinStoklari.Rows.Add(dt_FaturalarinStoklari.NewRow());
                    int SonSatirIndex = dt_FaturalarinStoklari.Rows.Count - 1;
                    dt_FaturalarinStoklari.Rows[SonSatirIndex]["StokID"] = item["StokID"];
                    dt_FaturalarinStoklari.Rows[SonSatirIndex]["FaturaHareketID"] = item["FaturaHareketID"];
                    dt_FaturalarinStoklari.Rows[SonSatirIndex]["StokAdi"] = item["StokAdi"];
                    dt_FaturalarinStoklari.Rows[SonSatirIndex]["AnaBirimMiktar"] = item["Miktar"];

                    dt_FaturalarinStoklari.Rows[SonSatirIndex]["AnaBirimID"] = item["StokAnaBirimID"];
                    dt_FaturalarinStoklari.Rows[SonSatirIndex]["FaturadakiSatisFiyati"] = item["IskonToluFiyat"];

                    //dt_FaturalarinStoklari.Rows[SonSatirIndex]["MaliyetFiyati"] = item[""];
                    //dt_FaturalarinStoklari.Rows[SonSatirIndex]["SatisTutari"] = item[""];
                    //dt_FaturalarinStoklari.Rows[SonSatirIndex]["SonSatisTarihi"] = item[""];
                    //dt_FaturalarinStoklari.Rows[SonSatirIndex]["IlkSatisTarihi"] = item[""];
                    //dt_FaturalarinStoklari.Rows[SonSatirIndex]["StokAdi"] = item[""];
                    if (comboBoxEdit1.SelectedIndex == 0)
                    {
                        clsTablolar.Stok.csStokFiyat Fiyat = new clsTablolar.Stok.csStokFiyat();
                        dt_FaturalarinStoklari.Rows[SonSatirIndex]["MaliyetFiyati"] = Fiyat.StokKartindakiVarsayilanAlisFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, (int)item["StokID"]);
                    }

                    Hesapla(dt_FaturalarinStoklari.Rows[SonSatirIndex]);
                    //StokAGoreGruplu();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                TrGenel.Commit();
            }


        }

        void DataTableAyarla()
        {

            dt_FaturalarinStoklari = new DataTable();
            dt_FaturalarinStoklari.Columns.Add("StokID", typeof(System.Int32));
            dt_FaturalarinStoklari.Columns.Add("FaturaHareketID", typeof(System.Int32));
            dt_FaturalarinStoklari.Columns.Add("StokAdi", typeof(System.String));
            dt_FaturalarinStoklari.Columns.Add("AnaBirimMiktar", typeof(System.Decimal));
            dt_FaturalarinStoklari.Columns.Add("AnaBirimID", typeof(System.Int32));
            dt_FaturalarinStoklari.Columns.Add("FaturadakiSatisFiyati", typeof(System.Decimal)); // iskontolu satış fiyatı

            dt_FaturalarinStoklari.Columns.Add("MaliyetFiyati", typeof(System.Decimal)); // Seçilebilir bişi bu
            dt_FaturalarinStoklari.Columns.Add("MaliyetTutari", typeof(System.Decimal));
            dt_FaturalarinStoklari.Columns.Add("FaturadakiSatisTutari", typeof(System.Decimal));
            dt_FaturalarinStoklari.Columns.Add("KarYuzdesi", typeof(System.Decimal));
            dt_FaturalarinStoklari.Columns.Add("KarTutari", typeof(System.Decimal));
            dt_FaturalarinStoklari.Columns.Add("Tarihi", typeof(System.DateTime)); // 
        }


        public void Hesapla(DataRow Dr)
        {
            decimal MaliyetFiyati = (decimal)Dr["MaliyetFiyati"];
            decimal SatisFiyati = (decimal)Dr["FaturadakiSatisFiyati"];

            Dr["MaliyetTutari"] = (decimal)Dr["MaliyetFiyati"] * (decimal)Dr["AnaBirimMiktar"];
            Dr["FaturadakiSatisTutari"] = (decimal)Dr["FaturadakiSatisFiyati"] * (decimal)Dr["AnaBirimMiktar"];


            Dr["KarTutari"] = (decimal)Dr["FaturadakiSatisTutari"] - (decimal)Dr["MaliyetTutari"];
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //gridView1.gro
        }

        public DataTable StokAGoreGruplu()
        {
            //var categories =
            //    from row in dt_FaturalarinStoklari.AsEnumerable()
            //    group row by row["StokID"] into g
            //    select new { Kdv = g.Key, ToplamKarTutari = g.Sum(p => Convert.ToDecimal((p["KarTutari"]).ToString())) };

            ////dt_StokAGoreGruplu = categories;
            ////dt_StokAGoreGruplu
            //foreach (var item in categories)
            //{
            //    //categories.
            //    //if (
            //    //if (((DataRow)item).RowState != DataRowState.Deleted)
            //    {
            //        dt_StokAGoreGruplu.Rows.Add(dt_StokAGoreGruplu.NewRow());
            //        dt_StokAGoreGruplu.Rows[dt_StokAGoreGruplu.Rows.Count - 1]["KdvTutari"] = item.ToplamKarTutari;
            //        dt_StokAGoreGruplu.Rows[dt_StokAGoreGruplu.Rows.Count - 1]["Kdv"] = item.Kdv;
            //    }
            //}

            dt_StokAGoreGruplu = dt_FaturalarinStoklari.AsEnumerable()
       .GroupBy(r => new { Col1 = r["StokID"], Col2 = r["StokAdi"] })
       .Select(g => g.OrderBy(r => r["StokID"]).First())
       .CopyToDataTable();

            return dt_StokAGoreGruplu;
        }

        private void btnStokKartiniAc_Click(object sender, EventArgs e)
        {
            if (dt_StokAGoreGruplu == null)
            {
                ds.Tables.Add(StokAGoreGruplu());
                ds.Relations.Add("Detay", ds.Tables[0].Columns["StokID"], ds.Tables[1].Columns["StokID"]);
                //gridControl1.DataSource = ds;
                gridControl1.DataSource = ds.Tables[0];
            }
        }
    }
}
