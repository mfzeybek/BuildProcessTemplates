using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PDKS
{
    public partial class frmPDKS : DevExpress.XtraEditors.XtraForm
    {
        public frmPDKS()
        {
            InitializeComponent();
        }

        clsTablolar.Personel.PDKS.csPdksKrt PDKSS;
        private void frmPDKS_Load(object sender, EventArgs e)
        {
            PDKSS = new clsTablolar.Personel.PDKS.csPdksKrt();

            txtPersonelSifre.Focus();
            txtPersonelSifre.Select();

            timer_kimneredeGoster.Start();
        }

        SqlTransaction TrGenel;
        SqlConnections sqll = new SqlConnections();


        private void btnBugunkuHareketlerimiGoster_Click(object sender, EventArgs e)
        {
            //using (Form1 frm = new Form1())
            //{
            //    frm.ShowDialog();
            //}
            //this.Select();
            //this.Focus();
            //this.Select(true, false);
            //this.txtPersonelSifre.SelectAll();
            //this.txtPersonelSifre.Select();
        }


        frmKimNerede Kimnerede = new frmKimNerede();
        private void btnKimNerede_Click(object sender, EventArgs e)
        {
            
        }

        
        csHareketler Hareketler = new csHareketler();
        csPersonel Personel = new csPersonel();
        frmYerSec YerSec;
        private void txtPersonelSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) // personel şifresini girdikten sonra entera bastığında
            {
                if (true == Personel.PersonelGetir(SqlConnections.GetBaglanti(), TrGenel, txtPersonelSifre.EditValue.ToString()))
                {// buraya şifrenin doğru yazılıp yazılmadığını kontrol eden bişi olmalı
                    lblAdiSoyadi.Text = Personel.PersonelAdi;


                    //Hareketler.PersonelinEnSonKayitTipiNe(SqlConnections.GetBaglanti(), TrGenel, Personel.PersonelID);

                    switch (Hareketler.PersonelinEnSonKayitTipiNe(SqlConnections.GetBaglanti(), TrGenel, Personel.PersonelID))
                    {
                        case csHareketler.Tur.MesaiBaslangici: // Son kayıt mesai Başlangıcı ise çıkış yapılacak
                            YerSec = new frmYerSec();
                            if (YerSec.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                            {
                                Hareketler.HareketKaydet(SqlConnections.GetBaglanti(), TrGenel, Personel.PersonelID, csHareketler.Tur.Cikis, YerSec.YerID);
                                lblBilgilendirme.Text = YerSec.YerAdi + " Çıkış Yapıldı";
                                lblZaman.Text = DateTime.Now.ToShortTimeString();
                            }
                            break;
                        case csHareketler.Tur.Giris: // Son kayıt Girişse Çıkış yapılacak
                            YerSec = new frmYerSec();
                            if (YerSec.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                            {
                                Hareketler.HareketKaydet(SqlConnections.GetBaglanti(), TrGenel, Personel.PersonelID, csHareketler.Tur.Cikis, YerSec.YerID);
                                lblZaman.Text = lblZaman.Text = DateTime.Now.ToShortTimeString();
                                lblBilgilendirme.Text = YerSec.YerAdi + " Çıkış Yapıldı";
                            }
                            break;
                        case csHareketler.Tur.Cikis: // son kayıt çıkışsa giriş yapılacak
                            //Hareketler.PersonelinSonCikisYaptigiYerinIDsi(SqlConnections.GetBaglanti(), TrGenel, Personel.PersonelID);
                            Hareketler.PersonelinSonCikisYaptigiYerinBilgileri(SqlConnections.GetBaglanti(), TrGenel, Personel.PersonelID);
                            Hareketler.HareketKaydet(SqlConnections.GetBaglanti(), TrGenel, Personel.PersonelID, csHareketler.Tur.Giris, Hareketler.SonCikisYaptigiYerID);
                            TimeSpan fark = DateTime.Now - Hareketler.SonCikisYaptigiZaman;
                            lblBilgilendirme.Text = Hareketler.SonCikisYaptigiYerAdi + " " + Convert.ToInt32(fark.TotalMinutes).ToString() + " Giriş Yapıldı";
                            //lblZaman.Text = Hareketler.

                            break;
                        case csHareketler.Tur.HicKayitYok: // Mesai Başlangıcı yapılacak o yüzden yerleri açmasına gerek yok
                            Hareketler.HareketKaydet(SqlConnections.GetBaglanti(), TrGenel, Personel.PersonelID, csHareketler.Tur.MesaiBaslangici, -1);
                            lblBilgilendirme.Text = "Mesai Başlangıcı Yapıldı";
                            lblZaman.Text = DateTime.Now.ToShortTimeString();
                            break;
                        default:
                            break;
                    }
                    
                }
                else
                {
                    lblBilgilendirme.Text = "Böyle Biri Yok Hamsına";
                }
                timer1.Start();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            lblBilgilendirme.Text = "Bilgilendirme";
            lblAdiSoyadi.Text = "";
            lblZaman.Text = "";
            txtPersonelSifre.EditValue = "";
        }

        private void frmPDKS_KeyDown(object sender, KeyEventArgs e)
        {
               if (txtPersonelSifre.ContainsFocus == false)
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
        (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
        e.KeyCode == Keys.Decimal)
                {
                    txtPersonelSifre.Focus();
                    txtPersonelSifre.Select(txtPersonelSifre.Text.Length, 0);
                    switch (e.KeyCode)
                    {
                        case Keys.NumPad0: txtPersonelSifre.Text = txtPersonelSifre.Text + "0";
                            break;
                        case Keys.NumPad1: txtPersonelSifre.Text = txtPersonelSifre.Text + "1";
                            break;
                        case Keys.NumPad2: txtPersonelSifre.Text = txtPersonelSifre.Text + "2";
                            break;
                        case Keys.NumPad3: txtPersonelSifre.Text = txtPersonelSifre.Text + "3";
                            break;
                        case Keys.NumPad4: txtPersonelSifre.Text = txtPersonelSifre.Text + "4";
                            break;
                        case Keys.NumPad5: txtPersonelSifre.Text = txtPersonelSifre.Text + "5";
                            break;
                        case Keys.NumPad6: txtPersonelSifre.Text = txtPersonelSifre.Text + "6";
                            break;
                        case Keys.NumPad7: txtPersonelSifre.Text = txtPersonelSifre.Text + "7";
                            break;
                        case Keys.NumPad8: txtPersonelSifre.Text = txtPersonelSifre.Text + "8";
                            break;
                        case Keys.NumPad9: txtPersonelSifre.Text = txtPersonelSifre.Text + "9";
                            break;
                        default: txtPersonelSifre.Text = txtPersonelSifre.Text + Convert.ToChar((int)e.KeyValue).ToString();
                            break;
                    }
                    txtPersonelSifre.Select(txtPersonelSifre.Text.Length, 0);
                }
        }
    }
}