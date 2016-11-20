using System;
using System.Data.SqlClient;
using System.Linq;
using System.Data;


namespace Aresv2.Cek
{
    public partial class frmCekListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmCekListesi()
        {
            InitializeComponent();
        }

        private void frmCekListesi_Load(object sender, EventArgs e)
        {

        }

        clsTablolar.Cek.csCekArama Arama = new clsTablolar.Cek.csCekArama();

        SqlTransaction Trgenel;

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            try
            {
                Arama.EvrakTarihi1 = deEvrakTarihi1.DateTime;
                Arama.EvratkTarihi2 = dateEdit2.DateTime;



                Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
                gridControl1.DataSource = Arama.ListeGetir(SqlConnections.GetBaglanti(), Trgenel);
                Trgenel.Commit();

                AltBilgileriHesapla();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnKartiAc_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            Cek.frmCekKarti frm = new frmCekKarti(Convert.ToInt32(gridView1.GetFocusedRowCellValue("CekHrID")));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void panelControl2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void AltBilgileriHesapla()
        {
            try
            {
                var categories =
          from row in Arama.dt.AsEnumerable()
          //where row.RowState != DataRowState.Deleted && row["BirlesikUrunHareketID"] == "" // Silinen Satırları ve Birleşik Ürünlerin alt detaylarını hesaba katmıyoruz
          group row by new
          {
              //StokIskonto1 = row["StokIskonto1"],
              //StokIskonto2 = row["StokIskonto2"],
              //StokIskonto3 = row["StokIskonto3"],
              //CariIskonto1 = row["CariIskonto1"],
              //CariIskonto2 = row["CariIskonto2"],
              //CariIskonto3 = row["CariIskonto3"],
              //AlacakTutar = row[(int)clsTablolar.IslemTipi.AlinanCek],
              //BorcTutar = row[(int)clsTablolar.IslemTipi.VerilenCek]
          } into g
          select new
          {
              //StokIskonto1 = g.Key.StokIskonto1,
              //StokIskonto2 = g.Key.StokIskonto2,
              //StokIskonto3 = g.Key.StokIskonto3,
              //CariIskonto1 = g.Key.CariIskonto1,
              //CariIskonto2 = g.Key.CariIskonto2,
              //CariIskonto3 = g.Key.CariIskonto3,
              ////CariToplamIskonto
              //StokIskontoTutari = g.Sum(p => Convert.ToDecimal(p["StokToplamIskonto"].ToString())),
              //CariToplamIskonto = g.Sum(p => Convert.ToDecimal((p["CariToplamIskonto"]).ToString())),
              //ToplamIskonto = g.Sum(p => Convert.ToDecimal((p["ToplamIskonto"]).ToString())),

              ToplamCekTutari = g.Sum(p => Convert.ToDecimal((p["Tutari"]).ToString()))
          };

                //lblVerilenCeklerinToplami.Text = categories.

                foreach (var item in categories)
                {
                    txtVerilenCeklerinToplami.Text = item.ToplamCekTutari.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void monthEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //monthEdit1.

            //DateTime IlkTarih;
            //DateTime IkinciTarih;

            deEvrakTarihi1.DateTime = new DateTime(DateTime.Now.Year, (int)monthEdit1.EditValue, 1, 0, 0, 0);
            dateEdit2.DateTime = new DateTime(DateTime.Now.Year, (int)monthEdit1.EditValue, 1).AddMonths(1).AddDays(-1);


        }
    }
}