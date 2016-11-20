using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;



namespace clsTablolar.TeraziSatisClaslari
{
    public partial class StokButonGrupVeStokButonlari : UserControl
    {
        public StokButonGrupVeStokButonlari()
        {
            InitializeComponent();
        }

        csStokAramaIslemleri StokAramaIslemleri = new csStokAramaIslemleri();

        private void flpGrupButonlari_Paint(object sender, PaintEventArgs e)
        {

        }

        public void AhandaBudur(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            StokButonGruplariVeStokButonlariniGetir(Baglanti, Tr, TeraziID);


            foreach (var item in StokAramaIslemleri.StokButonGruplariListesi)
            {
                try
                {
                    item.Btn.Click += GrupButonu_Click;
                    flpGrupButonlari.Controls.Add(item.Btn);
                }
                catch (System.NotImplementedException)
                {
                    ResetExceptionState(item.Btn);
                }
                catch (System.Exception)
                {
                    throw;
                }

                // buraya tıklandığında o gruba ait olan stokButonlari Gelecek
            }

            foreach (var item in StokAramaIslemleri.StokButonlariListesi)
            {
                item.StokButonu.Click += StokButonu_Click; // bunu burada yapıyoruz itemin click eventeı bir kere oluşturuluyor;
                item.StokButonu.MouseClick += StokButonu_MouseClick;
            }
        }

        private void StokButonu_MouseClick(object sender, MouseEventArgs e)
        { // bu çalışmıyor ki
            if (e.Button == MouseButtons.Right)
            {
                if (StokButonuSagClick != null)
                {
                    int StokID = StokAramaIslemleri.StokButonlariListesi[(int)(sender as DevExpress.XtraEditors.SimpleButton).Tag].StokID;
                    ButonTipi Btipi = StokAramaIslemleri.StokButonlariListesi[(int)(sender as DevExpress.XtraEditors.SimpleButton).Tag].BTipi;
                    this.StokButonuSagClick(Btipi, StokID); // stok butonu eklendiğinden beri Artık stok ID değil, buton tipine göre StokID veya PaketID veriyor
                }
            }
        }

        void ResetExceptionState(Control control)
        {
            typeof(Control).InvokeMember("SetState", BindingFlags.NonPublic |
              BindingFlags.InvokeMethod | BindingFlags.Instance, null,
              control, new object[] { 0x400000, false });
        }

        void StokButonGruplariVeStokButonlariniGetir(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            StokAramaIslemleri.StokButonGruplariniGetir(Baglanti, Tr, TeraziID);
            StokAramaIslemleri.StokButonlariniGetir(Baglanti, Tr, TeraziID);
        }

        public enum ButonTipi // buton tipi aslında şimdilik kullanılmıyor
        {
            StokButonu = 1,
            PaketButonu = 2
        }
        //public event System.EventHandler StokButonuTiklandiginda;
        public delegate void StokButonuTiklandiginda(ButonTipi Tip, int StokID); // buton tipi aslında şimdilik kullanılmıyor

        public StokButonuTiklandiginda StokButonuTikildatiginda;

        public delegate void StokButonuSagTiklandiginda(ButonTipi Tip, int StokID); // buton tipi aslında şimdilik kullanılmıyor

        public StokButonuSagTiklandiginda StokButonuSagClick;
        //public int StokButonuTiklandiginda;

        public void StokButonu_Click(object sender, System.EventArgs e)
        {
            if (StokButonuTikildatiginda != null)
            {
                int StokID = StokAramaIslemleri.StokButonlariListesi[(int)(sender as DevExpress.XtraEditors.SimpleButton).Tag].StokID;
                ButonTipi Btipi = StokAramaIslemleri.StokButonlariListesi[(int)(sender as DevExpress.XtraEditors.SimpleButton).Tag].BTipi;
                this.StokButonuTikildatiginda(Btipi, StokID); // stok butonu eklendiğinden beri Artık stok ID değil, buton tipine göre StokID veya PaketID veriyor
            }
        }

        void GrupButonu_Click(object sender, System.EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in StokAramaIslemleri.StokButonlariListesi.FindAll(x => x.TeraziStokGrupTanimID == StokAramaIslemleri.StokButonGruplariListesi[(int)(sender as DevExpress.XtraEditors.SimpleButton).Tag].StokButonGrupID))
            {
                try
                {
                    flowLayoutPanel1.Controls.Add(item.StokButonu);
                }
                catch (System.NotImplementedException)
                {
                    ResetExceptionState(item.StokButonu);
                }
                catch (System.Exception)
                {
                    throw;
                }

            }
        }
    }
}
