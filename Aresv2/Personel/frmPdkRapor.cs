using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Aresv2.Personel
{
    public partial class frmPdkRapor : Form
    {
        public frmPdkRapor()
        {
            InitializeComponent();
        }

        SqlTransaction TrGenel;

        clsTablolar.Personel.PDKS.csPDKSYerler Yerler = new clsTablolar.Personel.PDKS.csPDKSYerler();
        clsTablolar.Personel.PDKS.csPdksRapor PDKSRapor = new clsTablolar.Personel.PDKS.csPdksRapor();

        clsTablolar.Personel.PDKS.csPDKSTur Tur = new clsTablolar.Personel.PDKS.csPDKSTur();

        private void frmPdkRapor_Load(object sender, EventArgs e)
        {
            try
            {
                PDKSSqlconnection tetge = new PDKSSqlconnection();
                TrGenel = PDKSSqlconnection.GetBaglanti().BeginTransaction();

                Yerler.YerleriGetir(PDKSSqlconnection.GetBaglanti(), TrGenel);
                lkpGrup.Properties.DataSource = Yerler.dt;


                lkpGrup.Properties.DisplayMember = "YerAdi";
                lkpGrup.Properties.ValueMember = "YerID";

                lkpTur.Properties.DataSource = Tur.dt;
                lkpTur.Properties.DisplayMember = "TurAdi";
                lkpTur.Properties.ValueMember = "TurID";



                Al();

                repositoryItemLookUpEdit_Aciklama.DataSource = Yerler.dt;
                repositoryItemLookUpEdit_Aciklama.DisplayMember = "YerID";
                repositoryItemLookUpEdit_Aciklama.ValueMember = "YerAdi";


                repositoryItemLookUpEdit_Tur.DataSource = Tur.dt;
                repositoryItemLookUpEdit_Tur.DisplayMember = "TurAdi";
                repositoryItemLookUpEdit_Tur.ValueMember = "TurID";

                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        void Al()
        {
            lkpGrup.EditValue = PDKSRapor.AciklamaID;
            txtPersonelAdi.EditValue = PDKSRapor.PersonelAdi;

            lkpTur.EditValue = PDKSRapor.TurID;

            if (PDKSRapor.IlkZaman != DateTime.MinValue)
                deTarih1.DateTime = PDKSRapor.Zaman1;

            if (PDKSRapor.IkinciZaman != DateTime.MinValue)
                deTarih2.DateTime = PDKSRapor.Zaman2;



        }


        void Gonder()
        {
            PDKSRapor.AciklamaID = Convert.ToInt32(lkpGrup.EditValue);
            PDKSRapor.PersonelAdi = txtPersonelAdi.EditValue.ToString();



            PDKSRapor.TurID = Convert.ToInt32(lkpTur.EditValue);

            if (deTarih1.EditValue != null)
                PDKSRapor.IlkZaman = deTarih1.DateTime;
            if (deTarih2.EditValue != null)
                PDKSRapor.IkinciZaman = deTarih2.DateTime;




        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            Gonder();
            TrGenel = PDKSSqlconnection.GetBaglanti().BeginTransaction();
            gridControl1.DataSource = PDKSRapor.Listele(PDKSSqlconnection.GetBaglanti(), TrGenel);

            TrGenel.Commit();
            //AltDetay();
        }

        void AltDetay()
        {
            var categories =
          from row in PDKSRapor.dt.AsEnumerable()
          group row by new
          {
              //ToplamFark = row["Fark (dk)"],
              //ToplamHareket = row["StokIskonto2"],
              //ToplamErkenCikis = row["StokIskonto3"],
              //ToplamGelmedigiGun = row["CariIskonto1"],
              //ToplamGecGiris = row["CariIskonto2"],
          } into g
          select new
          {
              ToplamHareket = g.Count(),
              ToplamErkenCikis = "Yapılacak",
              ToplamGelmedigiGun = "Yapılacak",
              ToplamGecGiris = "Yapılacak",
              ToplamFark = g.Sum(p => Convert.ToDecimal(p["Fark (dk)"].ToString())),
          };

            gridControl2.DataSource = categories;

        }


        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExceleAktar eexx = new frmExceleAktar(gridControl1);
            eexx.Show();
        }

        private void lkpGrup_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                lkpGrup.EditValue = -1;
        }

        private void lkpTur_PropertiesChanged(object sender, EventArgs e)
        {

        }

        private void lkpTur_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                lkpTur.EditValue = -1;
        }

        clsTablolar.Personel.PDKS.csTabloOlarakGirisCikislar Tablo = new clsTablolar.Personel.PDKS.csTabloOlarakGirisCikislar();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Tablo.IlkZaman = dateEdit3.DateTime;
            Tablo.IkinciZaman = dateEdit2.DateTime;

            gridControl3.DataSource = Tablo.getir(PDKSSqlconnection.GetBaglanti());

            GridIkiyiAyarla();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        void GridIkiyiAyarla()
        {
            try
            {
                var categories =
                      from row in Tablo.dt.AsEnumerable()
                          //where row.RowState != DataRowState.Deleted && row["BirlesikUrunHareketID"] == "" // Silinen Satırları ve Birleşik Ürünlerin alt detaylarını hesaba katmıyoruz
                      group row by new
                      {
                          PersonelAdi = row["PersonelAdi"],
                          YerAdi = row["YerAdi"]
                          //HareketYonu = row["HareketYonu"],
                          //StokIskonto2 = row["StokIskonto2"],
                          //StokIskonto3 = row["StokIskonto3"],
                          //CariIskonto1 = row["CariIskonto1"],
                          //CariIskonto2 = row["CariIskonto2"],
                          //CariIskonto3 = row["CariIskonto3"]
                      } into g
                      select new
                      {
                          PersonelAdi = g.Key.PersonelAdi,
                          YerAdi = g.Key.YerAdi,
                          //HareketYonu = g.Key.HareketYonu,
                          //StokIskonto2 = g.Key.StokIskonto2,
                          //StokIskonto3 = g.Key.StokIskonto3,
                          //CariIskonto1 = g.Key.CariIskonto1,
                          //CariIskonto2 = g.Key.CariIskonto2,
                          //CariIskonto3 = g.Key.CariIskonto3,
                          //CariToplamIskonto
                          ToplamFark = g.Sum(p => Convert.ToDecimal(p["FarkDK"].ToString()))
                          //KacDefaSatilmis = g.Sum(p => 1)

                          //CariToplamIskonto = g.Sum(p => Convert.ToDecimal((p["CariToplamIskonto"]).ToString())),
                          //ToplamIskonto = g.Sum(p => Convert.ToDecimal((p["ToplamIskonto"]).ToString()))
                      };

                gridControl4.DataSource = categories;
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (xtraTabControl2.SelectedTabPage == xtraTabPage3)
                using (frmExceleAktar frm = new frmExceleAktar(gridControl3))
                {
                    frm.ShowDialog();
                }
            else
                if (xtraTabControl2.SelectedTabPage == xtraTabPage4)
            {
                using (frmExceleAktar frm = new frmExceleAktar(gridControl4))
                {
                    frm.ShowDialog();
                }

            }
        }

        private void weekDaysEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            switch ((DevExpress.XtraScheduler.WeekDays)weekDaysEdit1.Value)
            {
                case DevExpress.XtraScheduler.WeekDays.WorkDays:
                    MessageBox.Show("fsdf");
                    break;
                case DevExpress.XtraScheduler.WeekDays.WeekendDays:
                    MessageBox.Show("hafta sonu");
                    break;

                case DevExpress.XtraScheduler.WeekDays.EveryDay:
                    MessageBox.Show("Hergün");
                    break;


                    //default:
            }

            if ((DevExpress.XtraScheduler.WeekDays)weekDaysEdit1.Value == DevExpress.XtraScheduler.WeekDays.WorkDays)
            {

            }
            //dateEdit3.DateTime
        }
    }
}
