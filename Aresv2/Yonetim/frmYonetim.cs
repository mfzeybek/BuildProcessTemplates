using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;



namespace Aresv2.Yonetim
{
    public partial class frmYonetim : DevExpress.XtraEditors.XtraForm
    {
        public frmYonetim()
        {
            InitializeComponent();
        }

        bool AktifSayfa = false; // Bu sayfa aktif ise


        clsTablolar.Siparis.csSiparisArama SiparisArama = new clsTablolar.Siparis.csSiparisArama();
        clsTablolar.TeraziSatisClaslari.csSatislarV2 Satislar;

        clsTablolar.Fatura.csFaturaArama fatArama;

        clsTablolar.Personel.csDisaridakiPersonel disardakiler = new clsTablolar.Personel.csDisaridakiPersonel();
        PDKSSqlconnection connn = new PDKSSqlconnection();



        Thread ahanda;
        SqlTransaction TrGenel;

        private void frmYonetim_Load(object sender, EventArgs e)
        {


            CheckForIllegalCrossThreadCalls = false;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            //SiparisArama.

            //fatArama = new clsTablolar.Fatura.csFaturaArama(SqlConnections.GetBaglanti(), TrGenel, -1);
            //fatArama.Tarih1 = DateTime.Today;
            //fatArama.Tarih2 = DateTime.Today;


            //KasadanOdenenSatislariGetir();
            //GirisCikislariGetir();
            ahanda = new Thread(new ThreadStart(GuncellenecekBilgiler));
            ahanda.Start();
        }

        //void KasadanOdenenSatislariGetir()
        //{
        //    //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        //    //gridControl2.DataSource = fatArama.FaturaAraListe(SqlConnections.GetBaglanti(), TrGenel);
        //    //TrGenel.Commit();
        //}

        //void SatislariGetir()
        //{
        //    TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        //    Satislar = new clsTablolar.TeraziSatisClaslari.csSatislarV2(SqlConnections.GetBaglanti(), TrGenel, -1);
        //    TrGenel.Commit();
        //}

        int BeklemeSuresi = 60000;

        void GuncellenecekBilgiler()
        {
            while (true)
            {
                if (this.IsActive)
                {
                    //GirisCikislariGetir();
                    AlinanSiparisleri();
                }
                Thread.Sleep(BeklemeSuresi);
            }
        }




        void GirisCikislariGetir()
        {
            if (disardakiler.YeniHareketVarMi(1, PDKSSqlconnection.GetBaglanti()))
            {
                disardakiler.Getir2(PDKSSqlconnection.GetBaglanti());
                gridControl1.DataSource = disardakiler.dt;
            }
        }

        DateTime AlinanSiparisSonDegisiklikZamani = DateTime.MinValue;

        void AlinanSiparisleri()
        {
            if (SiparisArama.SiparisteDegisiklikVarMi(SqlConnections.GetBaglanti(), AlinanSiparisSonDegisiklikZamani))
            {

                SiparisArama.HizliSatistaGozukecekMi = 1;

                //SiparisArama.MuhasebelenmeDrumu = new object[1] { 4 };
                SiparisArama.SiparisDurumTanimID = new Int32[1] { 2 };
                SiparisArama.HazirlanmisSiparislerdenSonUcGünüdeGetir = true;

                gcAlinanSiparisler.DataSource = SiparisArama.SiparisAraListe(SqlConnections.GetBaglanti(), TrGenel);

                //SiparisArama.dt_SiparisListesi.Select("DuzenlemeTarihi = MAX(DuzenlemeTarihi)");

                var last = SiparisArama.dt_SiparisListesi.AsEnumerable()
              .Select(cols => cols.Field<DateTime>(SiparisArama.dt_SiparisListesi.Columns["DuzenlemeTarihi"]))
              .OrderByDescending(p => p.Ticks)
              .FirstOrDefault();

                AlinanSiparisSonDegisiklikZamani = last;
            }
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //TabbedView view = new TabbedView();
            //view.EnableFreeLayoutMode = DevExpress.Utils.DefaultBoolean.True;
            //documentManager1.View = view;
            //documentManager1.ViewCollection.Add(view);
            //documentManager1.ContainerControl = ownerControl;
            //DocumentGroupCollection groups = view.DocumentGroups;
            //for (int i = 1; i <= 3; i++)
            //{
            //    BaseDocument document = view.AddDocument(new Control());
            //    document.Caption = "Document" + i;
            //    DocumentGroup documentGroup = new DocumentGroup();
            //    view.DocumentGroups.Add(documentGroup);
            //    view.Controller.Dock(document as Document, documentGroup);
            //}
            //groups[2].DockTo(groups[1], Orientation.Vertical);
            //view.LayoutChanged();


        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {

        }

        private void frmYonetim_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ahanda.Abort();
            }
            catch (Exception)
            {

            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }


        Siparis.frmSiparisDetay SipDetay;
        private void dockPanel2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Yenile")
            {
                AlinanSiparisleri();
            }
            else if (e.Button.Properties.Caption == "Kaydı Aç")
            {
                if (gvAlinanSiparisler.RowCount > 0)
                {
                    SipDetay = new Siparis.frmSiparisDetay((int)gvAlinanSiparisler.GetFocusedRowCellValue("SiparisID"));
                    SipDetay.MdiParent = this.MdiParent;
                    SipDetay.Show();
                }
            }
            else if (e.Button.Properties.Caption == "Görüntü Al")
            {
                    Bitmap Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Graphics GFX = Graphics.FromImage(Screenshot);
                    GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);

            }
        }

        private void dockPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            GirisCikislariGetir();
        }
    }
}