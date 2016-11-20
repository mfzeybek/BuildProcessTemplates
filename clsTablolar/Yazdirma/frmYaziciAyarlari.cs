using System;
using System.Windows.Forms;
using System.Drawing.Printing;



namespace clsTablolar.Yazdirma
{
    public partial class frmYaziciAyarlari : Form
    {
        public frmYaziciAyarlari()
        {
            InitializeComponent();
        }

        PrintDocument pd = new PrintDocument();
        public string PinterName;
        public string KagitKaynagiAdi;
        public int KagitKaynagiIndex;
        public Duplex CiftTaraf;




        private void frmYaziciAyarlari_Load(object sender, EventArgs e)
        {
            //pd.PrinterSettings.PaperSources
            //pd.PrinterSettings.PrinterName = "Lexmark CS820 Series PS3";
            cmbYaziciAdi.Text = pd.PrinterSettings.PrinterName;
            YaziciDoldur();

            KagitKaynaginiDoldur();
        }

        void YaziciDoldur()
        {
            foreach (String yazici in PrinterSettings.InstalledPrinters)
            {
                cmbYaziciAdi.Properties.Items.Add(yazici);
            }
        }


        String[] KagitKaynaklariAdi;
        int[] KagitKaynadiIndex;

        void KagitKaynaginiDoldur()
        {
            pd.PrinterSettings.PrinterName = cmbYaziciAdi.Text;
            KagitKaynaklariAdi = new string[pd.PrinterSettings.PaperSources.Count];
            cmbKagitKaynagi.Properties.Items.Clear();
            for (int i = 0; i < KagitKaynaklariAdi.Length; i++)
            {
                KagitKaynaklariAdi[i] = pd.PrinterSettings.PaperSources[i].SourceName;
                cmbKagitKaynagi.Properties.Items.Add(KagitKaynaklariAdi[i]);
            }
        }

        string[] KagitBoyutlari;

        void KagitBoyutlariniGetir()
        {
            pd.PrinterSettings.PrinterName = cmbYaziciAdi.Text;
            KagitKaynaklariAdi = new string[pd.PrinterSettings.PaperSources.Count];
            cmbKagitBoyutu.Properties.Items.Clear();
            for (int i = 0; i < KagitKaynaklariAdi.Length; i++)
            {
                KagitKaynaklariAdi[i] = pd.PrinterSettings.PaperSizes[i].PaperName;
                cmbKagitKaynagi.Properties.Items.Add(KagitKaynaklariAdi[i]);
            }
        }


        private void btnTamam_Click(object sender, EventArgs e)
        {
            PinterName = cmbYaziciAdi.Text;
            KagitKaynagiAdi = cmbKagitKaynagi.Text;
            KagitKaynagiIndex = cmbKagitKaynagi.SelectedIndex;

            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }


        private void cmbYaziciAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            KagitKaynaginiDoldur();
        }
    }
}
