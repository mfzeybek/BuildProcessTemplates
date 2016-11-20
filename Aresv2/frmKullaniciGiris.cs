using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
//using clsTablolar;

namespace Aresv2
{
    public partial class frmKullaniciGiris : DevExpress.XtraEditors.XtraForm
    {
        public frmKullaniciGiris()
        {
            InitializeComponent();
        }

        SqlConnections Turettim = new SqlConnections();
        SqlTransaction trGenel;

        public static string KullaniciAdi = "", KullaniciID;
        // bu ayarların hepsi buradan alınacak
        public static string AyarlarVOIPID = "", VOIPTanim = "", DisplayName = "", UserName = "", RegisterName = "",
          RegisterPassword = "", DomainServerHost = "", DomainServerPort = "", GelenAramaKontrolu = "", NotPenceresiAcilsin = "",
          HemenAl_Auth_Code = "", HemenAl_username = "", HemenAl_password = "";




        //public static int SatisFaturasiFiyatID, AlisFaturasiFiyatID; // bu ne ya bu böyle olmazki amk

        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKullaniciAdi.Text == "" || txtKullaniciSifre.Text == "")
                {
                    txtKullaniciAdi.Focus();
                    return;
                }
                SqlConnections.GetBaglanti();
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                // KullaniciID = DbClass.Kullanici.KullaniciKontrol(SqlConnections.GetBaglanti(), trGenel, txtKullaniciAdi.Text, txtKullaniciSifre.Text);
                clsTablolar.csKullanici islem = new clsTablolar.csKullanici(SqlConnections.GetBaglanti(), trGenel, -1);

                KullaniciID = islem.KullaniciKontrol(SqlConnections.GetBaglanti(), trGenel, txtKullaniciAdi.Text, txtKullaniciSifre.Text);

                if (KullaniciID != "-1")
                {
                    // voip ve  hemen ayalarının hepsi buradan alınacak

                    #region VOIP BİLGİLERİ GETİRİLİYOR.
                    using (SqlCommand cmd = new SqlCommand(@"
SELECT     AyarlarVOIPID,VOIPTanim,DisplayName,UserName,RegisterName,RegisterPassword,DomainServerHost,DomainServerPort,GelenAramaKontrolu,NotPenceresiAcilsin
FROM         dbo.AyarlarVOIP", SqlConnections.GetBaglanti(), trGenel))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                        {
                            if (dr.Read())
                            {
                                AyarlarVOIPID = dr["AyarlarVOIPID"].ToString();
                                VOIPTanim = dr["VOIPTanim"].ToString();
                                DisplayName = dr["DisplayName"].ToString();
                                UserName = dr["UserName"].ToString();
                                RegisterName = dr["RegisterName"].ToString();
                                RegisterPassword = dr["RegisterPassword"].ToString();
                                DomainServerHost = dr["DomainServerHost"].ToString();
                                DomainServerPort = dr["DomainServerPort"].ToString();
                                GelenAramaKontrolu = dr["GelenAramaKontrolu"].ToString();
                                NotPenceresiAcilsin = dr["NotPenceresiAcilsin"].ToString();
                            }
                        }
                    }
                    #endregion

                    #region HemenAl BİLGİLERİ GETİRİLİYOR.
                    using (SqlCommand cmd = new SqlCommand(@"SELECT SiteAdi,Auth_Code,username,password,Aktif FROM HemenAlEntegrasyon", SqlConnections.GetBaglanti(), trGenel))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                        {
                            if (dr.Read())
                            {



                                HemenAl_Auth_Code = dr["Auth_Code"].ToString();
                                HemenAl_username = dr["username"].ToString();
                                HemenAl_password = dr["password"].ToString();
                            }
                        }
                    }
                    #endregion


                    #region genelAyarlar Hamısına

                    clsTablolar.Ayarlar.csAyarlar Ayarlarr = new clsTablolar.Ayarlar.csAyarlar(SqlConnections.GetBaglanti(), trGenel);
                    clsTablolar.Ayarlar.csYetkiler Yetkiler = new clsTablolar.Ayarlar.csYetkiler(SqlConnections.GetBaglanti(), trGenel);


                    #endregion




                    trGenel.Commit();
                    frmAnaForm frmAnaForm = new frmAnaForm()    ;
                    this.Hide();
                    frmAnaForm.Show();
                }
                else
                {
                    trGenel.Commit();
                    XtraMessageBox.Show("Kullanıcı Kodu veya Şifresniz Hatalı.", " Ares ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
            finally
            {

                //XmlDocument doc = new XmlDocument();
                //doc.Load("Aresv2.exe.config");
                //XmlNodeList nl = doc.SelectNodes("/configuration/userSettings/Aresv2.Properties.Settings/setting/value");
                //nl[0].InnerText = txtKullaniciAdi.Text;
                //nl[1].InnerText = txtKullaniciSifre.Text;
                //doc.Save("Aresv2.exe.config");
                //Aresv2.Properties.Settings.Default.KullaniciAdi = txtKullaniciAdi.EditValue.ToString();
                //Aresv2.Properties.Settings.Default.KullaniciSifresi = txtKullaniciSifre.EditValue.ToString();

                SqlConnections.BaglantiyiKapat();
            }
        }

        public void ProgramiKapat()
        {
            this.Close();
        }

        private void AktifTextBackColorChange(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit AktifText = (TextEdit)sender;
            AktifText.BackColor = Color.AntiqueWhite;
        }

        private void PasifTextBackColorChange(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit AktifText = (TextEdit)sender;
            AktifText.BackColor = Color.White;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtKullaniciAdi.Text != "")
                txtKullaniciSifre.Focus();
        }
        private void txtKullaniciSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtKullaniciSifre.Text != "")
                btnTamam_Click(null, null);
        }

        private void frmKullaniciGiris_Load(object sender, EventArgs e)
        {
            txtKullaniciAdi.EditValue = Aresv2.Properties.Settings.Default.KullaniciAdi;
            txtKullaniciSifre.EditValue = Aresv2.Properties.Settings.Default.KullaniciSifresi;

        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmVeriTabaniBaglanti frm = new frmVeriTabaniBaglanti();
            frm.ShowDialog();
        }
    }
}