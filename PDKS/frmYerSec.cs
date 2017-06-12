using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PDKS
{
    public partial class frmYerSec : DevExpress.XtraEditors.XtraForm
    {
        public frmYerSec()
        {
            InitializeComponent();
        }

        // Çıkış yaparken kullanılıyor;
        public int YerID = -1;
        public string YerAdi = "";

        csYerler Yerler = new csYerler();

        DevExpress.XtraEditors.SimpleButton[] Butonlarrr;
        string[] ButonlarinKisayollari;

        string[] YerAdlari;




        SqlTransaction TrGenel;
        private void frmYerSec_Load(object sender, EventArgs e)
        {
            try
            {
                Yerler.YerleriGetir(SqlConnections.GetBaglanti(), TrGenel);

                Butonlarrr = new DevExpress.XtraEditors.SimpleButton[Yerler.Dt.Rows.Count];
                ButonlarinKisayollari = new string[Butonlarrr.Length];
                YerAdlari = new string[Butonlarrr.Length];


                for (int i = 0; i < Yerler.Dt.Rows.Count; i++) // veri Tabanındaki yerler kadar buton ekliyoruz
                {
                    DevExpress.XtraEditors.SimpleButton Buton = new SimpleButton();
                    Buton.Name = "simpbtn" + i.ToString();
                    Buton.Text = Yerler.Dt.Rows[i]["YerAdi"].ToString() + " - (" + Yerler.Dt.Rows[i]["KisayolTusu"].ToString() + ")";
                    Buton.Click += Buton_Click;
                    // tagına hem ID yi atıyoruz hem kısayol tuşunu atıyoruz
                    Buton.Tag = Yerler.Dt.Rows[i]["YerID"];

                    Buton.Size = new System.Drawing.Size(200, 150);
                    flowLayoutPanel1.Controls.Add(Buton);

                    Butonlarrr[i] = Buton;
                    ButonlarinKisayollari[i] = Yerler.Dt.Rows[i]["KisayolTusu"].ToString();
                    YerAdlari[i] = Yerler.Dt.Rows[i]["YerAdi"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        void Buton_Click(object sender, EventArgs e)
        {
            YerID = (int)(sender as DevExpress.XtraEditors.SimpleButton).Tag;
            YerAdi = YerAdlari[Array.IndexOf(Butonlarrr, sender)];


            this.DialogResult = System.Windows.Forms.DialogResult.Yes;

            Close();
        }

        void ButondanYersec()
        {



        }

        string AramaKodu = "";

        private void frmYerSec_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
        e.KeyCode == Keys.Decimal)
            {
                AramaKodu += ((char)e.KeyCode).ToString();

                // Aramakoduna rakam eklenir eklenmez timer calismaya başlar
                timer1.Start();
                this.Text = AramaKodu;
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad0: AramaKodu += "0";
                        break;
                    case Keys.NumPad1: AramaKodu += "1";
                        break;
                    case Keys.NumPad2: AramaKodu += "2";
                        break;
                    case Keys.NumPad3: AramaKodu += "3";
                        break;
                    case Keys.NumPad4: AramaKodu += "4";
                        break;
                    case Keys.NumPad5: AramaKodu += "5";
                        break;
                    case Keys.NumPad6: AramaKodu += "6";
                        break;
                    case Keys.NumPad7: AramaKodu += "7";
                        break;
                    case Keys.NumPad8: AramaKodu += "8";
                        break;
                    case Keys.NumPad9: AramaKodu += "9";
                        break;
                    default: AramaKodu = AramaKodu + Convert.ToChar((int)e.KeyValue).ToString();
                        break;
                }
            }
            this.Text = AramaKodu;
            if (Array.IndexOf(ButonlarinKisayollari, AramaKodu) != -1)
                Butonlarrr[Array.IndexOf(ButonlarinKisayollari, AramaKodu)].Focus();
            if (e.KeyData == Keys.Delete)
            {
                AramaKodu = "";
                this.Text = AramaKodu;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AramaKodu = "";
            this.Text = AramaKodu;
        }
    }
}