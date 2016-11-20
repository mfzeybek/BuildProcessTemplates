using System;
using System.Windows.Forms;

namespace TeraziSatis
{
    public partial class frmPaketleme : DevExpress.XtraEditors.XtraForm
    {
        public frmPaketleme(frmTerazi TeraziFormu)
        {
            InitializeComponent();
            _TeraziFormundakiTerazidekiMiktar = TeraziFormu.txtTerazidekiMiktari;
            _TeraziFormundakiTerazidekiSabitMiktar = TeraziFormu.textBox1;
            _TeraziFormu = TeraziFormu;
        }

        DevExpress.XtraEditors.TextEdit _TeraziFormundakiTerazidekiMiktar;
        TextBox _TeraziFormundakiTerazidekiSabitMiktar;

        frmTerazi _TeraziFormu;


        public int BarkodAyarID;
        public int OnEk;
        public clsTablolar.Ayarlar.csBarkodTipleri.BarkodTipleri BarkodTipi;
        public bool KontrolNoOlsunMu;
        public bool MiktarOlacakMi;
        public Int16 KacHaneMiktar;
        public Int16 KacHaneKod;
        public string Aciklama;
        public Int16 ToplamKarakterSayisi;
        public int SiradakiKod;


        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmPaketleme_Load(object sender, EventArgs e)
        {
            _TeraziFormundakiTerazidekiMiktar.EditValueChanged += _TeraziFormundakiTerazidekiMiktar_EditValueChanged;
            _TeraziFormundakiTerazidekiSabitMiktar.TextChanged += _TeraziFormundakiTerazidekiSabitMiktar_TextChanged;
            YazdirmakIcinHazirla();
        }

        void _TeraziFormundakiTerazidekiSabitMiktar_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(_TeraziFormundakiTerazidekiSabitMiktar.Text) != 0)
                txtTerazidenGelenSabitMiktar.EditValue = Convert.ToDecimal(_TeraziFormundakiTerazidekiSabitMiktar.Text) - DaraMiktari;
            else
                btnDaraIptal_Click(null, null);
        }

        void _TeraziFormundakiTerazidekiMiktar_EditValueChanged(object sender, EventArgs e)
        {
            txtTerazidekiMiktari.EditValue = Convert.ToDecimal(_TeraziFormundakiTerazidekiMiktar.EditValue) - DaraMiktari;
        }


        decimal DaraMiktari = 0;


        void YazdirmakIcinHazirla()
        {
            yazz.dt_ekle("Tablo");
            yazz.dtAlanEkleVeriEkle("Tablo", "StokAdi", "", System.Type.GetType("System.String"));
            yazz.dtAlanEkleVeriEkle("Tablo", "StokEtiketAdi", "", System.Type.GetType("System.String"));
            yazz.dtAlanEkleVeriEkle("Tablo", "AltBirimBarkodu", "", System.Type.GetType("System.String"));
            yazz.dtAlanEkleVeriEkle("Tablo", "Fiyati", "", System.Type.GetType("System.Decimal"));
            yazz.dtAlanEkleVeriEkle("Tablo", "AltBirimFiyati", "", System.Type.GetType("System.Decimal"));
        }

        bool UrununEtiketiBasildiktanSonraTerazidekiUrunlerKAldirildi = false;

        string SeciliYaziciAdi = string.Empty;

        clsTablolar.Yazdirma.csYazdir yazz = new clsTablolar.Yazdirma.csYazdir();
        private void btnEtiketYazdir_Click(object sender, EventArgs e)
        {
            try
            {
                yazz.ds.Tables[0].Rows[0]["StokAdi"] = txtStokAdi.Text;
                yazz.ds.Tables[0].Rows[0]["StokEtiketAdi"] = txtStokEtiketAdi.Text;
                yazz.ds.Tables[0].Rows[0]["AltBirimBarkodu"] = txtAltBirimBarkodu.Text;
                yazz.ds.Tables[0].Rows[0]["Fiyati"] = txtFiyati.Text;
                yazz.ds.Tables[0].Rows[0]["AltBirimFiyati"] = txtAltBirimFiyati.EditValue;

                //foreach (String yazici in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                //{
                //    comboBox_yazicilar.Items.Add(yazici);
                //}

                yazz.Yazdirr(Application.StartupPath + @"\Raporlar\AHANDA ARGOX İÇİN ÜRÜN BU HAMISINA.repx", clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir, lblYaziciAdi.Text);

                //yazz.Yazdirr()
                UrununEtiketiBasildiktanSonraTerazidekiUrunlerKAldirildi = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            clsTablolar.frmStokBilgileri frm = new clsTablolar.frmStokBilgileri(SqlConnections.GetBaglanti());
            frm.ShowDialog();

            txtStokAdi.EditValue = frm.txtStokAdi.EditValue;
            txtStokEtiketAdi.EditValue = frm.txtStokEtiketAdi.EditValue;
            StokID = frm.StokID;
            txtFiyati.EditValue = frm.txtKdvDahilFiyat.EditValue;

        }
        int StokID = -1;


        private void btnBirimSec_Click(object sender, EventArgs e)
        {
            clsTablolar.Stok.frmStokBirim birimleri = new clsTablolar.Stok.frmStokBirim(StokID, SqlConnections.GetBaglanti());


            if (birimleri.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                txtAltBirimBarkodu.EditValue = birimleri.AltBirimBarkod;
                BarkodNumarasi = birimleri.AltBirimBarkod;
                txtAltBirimi.EditValue = birimleri.AltBirimAdi;
                txtAltBirimKatsayi.EditValue = birimleri.AltBirimKatsayi;
                BarkodtaMiktarVarmi = birimleri.MiktarYaziyorMu;
            }
        }

        bool BarkodtaMiktarVarmi = false;
        string BarkodNumarasi = "";
        string KontrolNumarasiIleBirlikteBarkodNumarasi = "";
        private void txtTerazidenGelenSabitMiktar_EditValueChanged(object sender, EventArgs e)
        {
            if (ceMiktarStandartDegil.Checked == true && Convert.ToDecimal(txtTerazidenGelenSabitMiktar.EditValue) != 0)
            {
                txtPaketinKilogrami.EditValue = txtTerazidenGelenSabitMiktar.EditValue;
            }

            if (ceMiktarStandartDegil.Checked == false && ceOtomatikDaraAl.Checked == true)
            {
                //if (this.Visible == false)
                //return;

                decimal IStenilenMiktar = Convert.ToDecimal(txtPaketinKilogrami.EditValue);
                decimal TerazidenGelenSabitMiktar = Convert.ToDecimal(txtTerazidenGelenSabitMiktar.EditValue);
                decimal ArtiMiktar = Convert.ToDecimal(txtArtiMiktar.EditValue);
                if (IStenilenMiktar == TerazidenGelenSabitMiktar || (TerazidenGelenSabitMiktar <= IStenilenMiktar + ArtiMiktar && TerazidenGelenSabitMiktar > IStenilenMiktar))
                {
                    btnDaraAl_Click(null, null);
                }
            }

            if (Convert.ToDecimal(txtTerazidenGelenSabitMiktar.EditValue) == 0)
            {
                UrununEtiketiBasildiktanSonraTerazidekiUrunlerKAldirildi = true;
            }
        }

        private void txtPaketinKilogrami_EditValueChanged(object sender, EventArgs e)
        {
            if (BarkodtaMiktarVarmi)
            {
                int Tekler = 0;
                int Ciftler = 0;
                int KontrolNu = 0;
                string EklenecekMiktarHanesi = "";
                decimal PaketinKilogrami = 0;
                PaketinKilogrami = Convert.ToDecimal(txtPaketinKilogrami.Text) - Convert.ToDecimal(txtDara.Text);
                PaketinKilogrami.ToString("F3");
                if (PaketinKilogrami.ToString("F3").Length == 5)
                {
                    EklenecekMiktarHanesi = "0" + PaketinKilogrami.ToString("F3").Remove(PaketinKilogrami.ToString("F3").IndexOf(','), 1);
                }
                else if (PaketinKilogrami.ToString("F3").Length == 6)
                {
                    EklenecekMiktarHanesi = PaketinKilogrami.ToString("F3").Remove(PaketinKilogrami.ToString("F3").IndexOf(','), 1);
                }
                KontrolNumarasiIleBirlikteBarkodNumarasi = BarkodNumarasi + EklenecekMiktarHanesi;
                for (int i = 1; i <= KontrolNumarasiIleBirlikteBarkodNumarasi.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Ciftler += Convert.ToInt32(KontrolNumarasiIleBirlikteBarkodNumarasi[KontrolNumarasiIleBirlikteBarkodNumarasi.Length - i].ToString());
                    }
                    else
                    {
                        Tekler += Convert.ToInt32(KontrolNumarasiIleBirlikteBarkodNumarasi[KontrolNumarasiIleBirlikteBarkodNumarasi.Length - i].ToString());
                    }
                }
                KontrolNu = 10 - (((Tekler * 3) + Ciftler) % 10);
                if (KontrolNu == 10)
                    KontrolNu = 0;
                KontrolNumarasiIleBirlikteBarkodNumarasi = KontrolNumarasiIleBirlikteBarkodNumarasi + KontrolNu.ToString();

                txtAltBirimBarkodu.EditValue = KontrolNumarasiIleBirlikteBarkodNumarasi;
                txtAltBirimKatsayi.EditValue = PaketinKilogrami;
                txtAltBirimFiyati.EditValue = PaketinKilogrami * Convert.ToDecimal(txtFiyati.EditValue);
            }
            if (checkEdit1.Checked == true && UrununEtiketiBasildiktanSonraTerazidekiUrunlerKAldirildi)
            {
                btnEtiketYazdir_Click(null, null);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }

        private void btnDaraAl_Click(object sender, EventArgs e)
        {
            try
            {
                DaraMiktari += Convert.ToDecimal(txtTerazidenGelenSabitMiktar.EditValue);
                txtDaraMiktari.EditValue = DaraMiktari;
                if (ceDaraAlaBasildigindaPaketlenenAdetiBirArttir.Checked == true)
                    txtPaketlenenAdet.EditValue = Convert.ToDecimal(txtPaketlenenAdet.EditValue) + 1;

                _TeraziFormundakiTerazidekiMiktar_EditValueChanged(null, null);
                _TeraziFormundakiTerazidekiSabitMiktar_TextChanged(null, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnGizle_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        clsTablolar.frmMiktarGir frm;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                txtPaketinKilogrami.EditValue = frm.textEdit1.EditValue;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                txtArtiMiktar.EditValue = frm.textEdit1.EditValue;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                txtEksiMiktar.EditValue = frm.textEdit1.EditValue;
            }
        }

        private void btnDaraIptal_Click(object sender, EventArgs e)
        {
            DaraMiktari = 0;
        }

        private void btnPaketLenenAdet_Click(object sender, EventArgs e)
        {
            frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                txtPaketlenenAdet.EditValue = frm.textEdit1.EditValue;
            }
        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }

        private void btnEtiketDara_Click(object sender, EventArgs e)
        {
            frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli);

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                txtDara.EditValue = frm.textEdit1.EditValue;
            }
        }

        private void txtDara_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                yazz.ds.Tables[0].Rows[0]["StokAdi"] = txtStokAdi.Text;
                yazz.ds.Tables[0].Rows[0]["StokEtiketAdi"] = txtStokEtiketAdi.Text;
                yazz.ds.Tables[0].Rows[0]["AltBirimBarkodu"] = txtAltBirimBarkodu.Text;
                yazz.ds.Tables[0].Rows[0]["Fiyati"] = txtFiyati.Text;
                yazz.ds.Tables[0].Rows[0]["AltBirimFiyati"] = txtAltBirimFiyati.EditValue;

                //foreach (String yazici in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                //{
                //    comboBox_yazicilar.Items.Add(yazici);
                //}

                yazz.Yazdirr(Application.StartupPath + @"\Raporlar\AHANDA ARGOX İÇİN ÜRÜN BU HAMISINA.repx", clsTablolar.Yazdirma.csYazdir.Nasil.YazdirmaDiyalogu);

                //yazz.Yazdirr()
                UrununEtiketiBasildiktanSonraTerazidekiUrunlerKAldirildi = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void txtTerazidekiMiktari_EditValueChanged(object sender, EventArgs e)
        {
            //if (_TeraziFormu.MiktarAl.OkunanSabitMiktar == (decimal)_TeraziFormundakiTerazidekiMiktar.EditValue)
            //{ txtTerazidenGelenSabitMiktar.EditValue = _TeraziFormu.MiktarAl.OkunanSabitMiktar; }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            using (frmYaziciSec frm = new frmYaziciSec())
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    lblYaziciAdi.Text = frm.SecilenYaziciAdi;
                }
            }
        }
    }
}