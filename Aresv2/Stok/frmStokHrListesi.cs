using System;
using System.Data.SqlClient;
using System.Linq;
using System.Data;


namespace Aresv2.Stok
{
    public partial class frmStokHrListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmStokHrListesi()
        {
            InitializeComponent();
        }

        clsTablolar.Stok.StokHareket.StokHrArama HareketArama = new clsTablolar.Stok.StokHareket.StokHrArama();
        DataTable dtt2;
        clsTablolar.Stok.csStokAraGrup AraGrubu;
        private void frmStokHrListesi_Load(object sender, EventArgs e)
        {
            try
            {
                AraGrubu = new clsTablolar.Stok.csStokAraGrup(SqlConnections.GetBaglanti(), TrGenel, -1);
                Al();
                gruplariYukle();

                dtt2 = new DataTable();
                dtt2.Columns.Add("StokID", System.Type.GetType("System.Int32"));
                dtt2.Columns.Add("StokAdi", System.Type.GetType("System.String"));
                dtt2.Columns.Add("GirisMiCikisMi", System.Type.GetType("System.String"));
                dtt2.Columns.Add("Miktar", System.Type.GetType("System.Decimal"));
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        void GridIkiyiAyarla()
        {
            try
            {
                var categories =
                      from row in HareketArama.dt.AsEnumerable()
                          //where row.RowState != DataRowState.Deleted && row["BirlesikUrunHareketID"] == "" // Silinen Satırları ve Birleşik Ürünlerin alt detaylarını hesaba katmıyoruz
                      group row by new
                      {
                          StokID = row["StokID"],
                          StokAdi = row["StokAdi"],
                          HareketYonu = row["HareketYonu"],
                          //(if (1 == 1)
                          Fiyati = row["Fiyat"],
                          Donemi = ((DateTime)row["Tarih"]).Month

                          //StokIskonto2 = row["StokIskonto2"],
                          //StokIskonto3 = row["StokIskonto3"],
                          //CariIskonto1 = row["CariIskonto1"],
                          //CariIskonto2 = row["CariIskonto2"],
                          //CariIskonto3 = row["CariIskonto3"]
                      } into g
                      select new
                      {
                          StokID = g.Key.StokID,
                          StokAdi = g.Key.StokAdi,
                          HareketYonu = g.Key.HareketYonu,
                          Fiyat = g.Key.Fiyati,
                          ToplamTutar = Convert.ToDecimal(g.Key.Fiyati) * g.Sum(p => Convert.ToDecimal(p["Miktar"].ToString())),
                          Ayi = g.Key.Donemi,
                          //StokIskonto2 = g.Key.StokIskonto2,
                          //StokIskonto3 = g.Key.StokIskonto3,
                          //CariIskonto1 = g.Key.CariIskonto1,
                          //CariIskonto2 = g.Key.CariIskonto2,
                          //CariIskonto3 = g.Key.CariIskonto3,
                          //CariToplamIskonto
                          Miktar = g.Sum(p => Convert.ToDecimal(p["Miktar"].ToString())),
                          KacDefaSatilmis = g.Sum(p => 1)

                          //CariToplamIskonto = g.Sum(p => Convert.ToDecimal((p["CariToplamIskonto"]).ToString())),
                          //ToplamIskonto = g.Sum(p => Convert.ToDecimal((p["ToplamIskonto"]).ToString()))
                      };

                //gridControl2.DataSource = categories;
                //dtt2.Clear();

                //foreach (var item in categories)
                //{
                //    dtt2.Rows.Add(dtt2.NewRow());
                //    dtt2.Rows[dtt2.Rows.Count - 1]["StokID"] = item.StokID;
                //    dtt2.Rows[dtt2.Rows.Count - 1]["Miktar"] = item.Miktar;
                //    //dtt2.Rows[dtt2.Rows.Count - 1]["GirisMiCikisMi"] = item.GirisMiCikisMi;
                //}

                //gridControl2.DataSource = dtt2;
            }
            catch (Exception e)
            {


            }



        }

        void Al()
        {
            txtStokAdi.EditValue = HareketArama.StokAdi;
            txtStokKodu.EditValue = HareketArama.StokKodu;
            N.SelectedIndex = HareketArama.GirisCikis;
            deTarih1.DateTime = HareketArama.IlkTarih;
            deTarih2.DateTime = HareketArama.IkinciTarih;
            lkpGrup.EditValue = HareketArama.StokGrupID;
            lkpAraGrup.EditValue = HareketArama.StokAraGrupID;
            lkpAltGrup.EditValue = HareketArama.StokAltGrupID;
        }
        void Ver()
        {
            HareketArama.StokAdi = txtStokAdi.EditValue.ToString();
            HareketArama.StokKodu = txtStokKodu.EditValue.ToString();
            HareketArama.GirisCikis = N.SelectedIndex;
            HareketArama.IlkTarih = deTarih1.DateTime;
            HareketArama.IkinciTarih = deTarih2.DateTime;
            HareketArama.StokGrupID = (int)lkpGrup.EditValue;
            HareketArama.StokAraGrupID = (int)lkpAraGrup.EditValue;
            HareketArama.StokAltGrupID = (int)lkpAltGrup.EditValue;
        }

        SqlTransaction TrGenel;
        public void btnFiltrele_Click(object sender, EventArgs e)
        {
            try
            {
                Ver();
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                gridControl1.DataSource = HareketArama.HareketleriGetir(SqlConnections.GetBaglanti(), TrGenel);
                try
                {
                    //gridView1.RestoreLayoutFromStream(cs.csGridLayout.GetLayout(1, this.Name, gridView1.Name, SqlConnections.GetBaglanti(), TrGenel));
                }
                catch (Exception)
                {
                }
                TrGenel.Commit();
                //GridIkiyiAyarla();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        clsTablolar.Stok.csStokGrup Grubu;

        void gruplariYukle()
        {
            using (clsTablolar.Stok.csStokGrup StokGrup = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), TrGenel, -1))
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                lkpGrup.Properties.DataSource = StokGrup.StokGrupDoldur(SqlConnections.GetBaglanti(), TrGenel);
                lkpGrup.Properties.DisplayMember = "StokGrupAdi";
                lkpGrup.Properties.ValueMember = "StokGrupID";
                TrGenel.Commit();
            }
            AraGrupGetir((int)lkpGrup.EditValue);
            AltGrubu = new clsTablolar.Stok.csStokAltGrup();
            AltGrupGetir((int)lkpAraGrup.EditValue);
        }


        void AraGrupGetir(int StokGrupID)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            lkpAraGrup.Properties.DataSource = AraGrubu.StokAraGrupDoldur(SqlConnections.GetBaglanti(), TrGenel, StokGrupID);
            lkpAraGrup.Properties.DisplayMember = "StokAraGrupAdi";
            lkpAraGrup.Properties.ValueMember = "StokAraGrupID";
            TrGenel.Commit();
        }
        clsTablolar.Stok.csStokAltGrup AltGrubu;
        void AltGrupGetir(int StokAraGrupID)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            lkpAltGrup.Properties.DataSource = AltGrubu.StokAltGrupDoldur(SqlConnections.GetBaglanti(), TrGenel, StokAraGrupID);
            lkpAltGrup.Properties.ValueMember = "StokAltGrupID";
            lkpAltGrup.Properties.DisplayMember = "StokAltGrupAdi";
            TrGenel.Commit();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                cs.csGridLayout.InsertLayout(1, this.Name, gridView1, SqlConnections.GetBaglanti(), TrGenel);
                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnHareketiAc_Click(object sender, EventArgs e)
        {
            clsTablolar.IslemTipi EntegrasyonNo = (clsTablolar.IslemTipi)Convert.ToInt32(gridView1.GetFocusedRowCellValue("Entegrasyon"));

            if (EntegrasyonNo == clsTablolar.IslemTipi.AlisFaturasi || EntegrasyonNo == clsTablolar.IslemTipi.SatisFaturasi)
            {
                clsTablolar.Fatura.csFaturaHareketIDdenFaturaIDVer Idver = new clsTablolar.Fatura.csFaturaHareketIDdenFaturaIDVer();
                int FaturaID = 0;
                try
                {
                    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    FaturaID = Idver.FaturaHareketIDdenFaturaIDVer((int)gridView1.GetFocusedRowCellValue("EntegrasyonID"), SqlConnections.GetBaglanti(), TrGenel);
                    TrGenel.Commit();
                }
                catch (Exception hata)
                {
                    TrGenel.Rollback();
                    frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                    frmHataBildir.ShowDialog();
                }
                Fatura.frmFaturaDetay frmAlisFatura = new Fatura.frmFaturaDetay(FaturaID);
                frmAlisFatura.MdiParent = this.MdiParent;
                frmAlisFatura.Show();

            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBugun_Click(object sender, EventArgs e)
        {
            deTarih1.DateTime = DateTime.Today;
            deTarih2.DateTime = DateTime.Today;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(colStokID) == null) return;
            Stok.frmStokDetay frm = new frmStokDetay((int)gridView1.GetFocusedRowCellValue(colStokID));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void lkpGrup_EditValueChanged(object sender, EventArgs e)
        {
            AraGrupGetir((int)lkpGrup.EditValue);
        }

        private void lkpAraGrup_EditValueChanged(object sender, EventArgs e)
        {
            AltGrupGetir((int)lkpAraGrup.EditValue);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void cmbHizliTarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHizliTarih.SelectedIndex == 0)
            {

            }

            switch (cmbHizliTarih.SelectedIndex)
            {
                case 0:
                    deTarih1.DateTime = DateTime.Today;
                    deTarih2.DateTime = DateTime.Today; break;
                case 1:
                    deTarih1.DateTime = DateTime.Today.AddDays(-1);
                    deTarih2.DateTime = DateTime.Today.AddDays(-1); break;
                case 2:
                    deTarih1.DateTime = haftaBasi(DateTime.Today, DayOfWeek.Monday);
                    deTarih2.DateTime = haftasonu(DateTime.Today, DayOfWeek.Sunday);
                    break;
                case 3:
                    deTarih1.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    deTarih2.DateTime = deTarih1.DateTime.AddMonths(1).AddDays(-1);
                    break;
            }



        }


        DateTime haftaBasi(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
        DateTime haftasonu(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(diff).Date;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}