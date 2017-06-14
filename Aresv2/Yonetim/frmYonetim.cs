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
using System.Threading;



namespace Aresv2.Yonetim
{
    public partial class frmYonetim : DevExpress.XtraEditors.XtraForm
    {
        public frmYonetim()
        {
            InitializeComponent();
        }
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



        void GuncellenecekBilgiler()
        {
            while (true)
            {
                GirisCikislariGetir();

                Thread.Sleep(5000);
            }
        }




        void GirisCikislariGetir()
        {
            disardakiler.Getir2(PDKSSqlconnection.GetBaglanti());
            gridControl1.DataSource = disardakiler.dt;
        }
        void AlinanSiparisleri()
        {
            SiparisArama.HizliSatistaGozukecekMi = 1;
            SiparisArama.MuhasebelenmeDrumu = new object[1] { 4 };

            SiparisArama.SiparisAraListe(SqlConnections.GetBaglanti(), TrGenel);
            
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
    }
}