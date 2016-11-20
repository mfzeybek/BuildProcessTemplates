using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;

namespace Aresv2.Ayarlar
{
  public partial class frmGenelAyarlar : DevExpress.XtraEditors.XtraForm
  {
    public frmGenelAyarlar()
    {
      InitializeComponent();
    }

    SqlConnections Turetttim = new SqlConnections();
    SqlTransaction trGenel;

    SqlDataAdapter daVOIP = new SqlDataAdapter();
    DataTable dtVOIP = new DataTable();

    SqlDataAdapter daKullanici = new SqlDataAdapter();
    DataTable dtKullanici = new DataTable();
    clsTablolar.csFiyatTanim FiyatTanim = new clsTablolar.csFiyatTanim();


    clsTablolar.Ayarlar.csAyarlar Ayarlar;

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
    private void frmGenelAyarlar_Load(object sender, EventArgs e)
    {
      try
      {

        #region gcVOIP DOLDURULUYOR.
        using (daVOIP.SelectCommand = new SqlCommand(@"SELECT AyarlarVOIPID,VOIPTanim,DisplayName,UserName,RegisterName FROM dbo.AyarlarVOIP", SqlConnections.GetBaglanti()))
        {
          dtVOIP.Clear();
          daVOIP.Fill(dtVOIP);
          gcVOIP.DataSource = dtVOIP;
        }
        gvVOIP.BestFitColumns();
        #endregion

        trGenel = SqlConnections.GetBaglanti().BeginTransaction();

        #region gcKullanici DOLDURULUYOR.

        gcKullanici.DataSource = clsTablolar.csKullanici.KullaniciListesi(SqlConnections.GetBaglanti(), trGenel);

        gvKullanici.BestFitColumns();
        #endregion



        #region HemenAl için FİYAT TANIMLAR DOLDURULUYOR.
        lkpSKFiyatTanimID.Properties.DataSource = FiyatTanim.FiyatTanimGetir(SqlConnections.GetBaglanti(), trGenel);
        lkpSKFiyatTanimID.Properties.DisplayMember = "FiyatTanimAdi";
        lkpSKFiyatTanimID.Properties.ValueMember = "FiyatTanimID";

        lkpBayiFiyatTanimID.Properties.DataSource = FiyatTanim.FiyatTanimGetir(SqlConnections.GetBaglanti(), trGenel);
        lkpBayiFiyatTanimID.Properties.DisplayMember = "FiyatTanimAdi";
        lkpBayiFiyatTanimID.Properties.ValueMember = "FiyatTanimID";

        lkpOzelFiyatTanimID.Properties.DataSource = FiyatTanim.FiyatTanimGetir(SqlConnections.GetBaglanti(), trGenel);
        lkpOzelFiyatTanimID.Properties.DisplayMember = "FiyatTanimAdi";
        lkpOzelFiyatTanimID.Properties.ValueMember = "FiyatTanimID";

        lkpPiyasaFiyatTanimID.Properties.DataSource = FiyatTanim.FiyatTanimGetir(SqlConnections.GetBaglanti(), trGenel);
        lkpPiyasaFiyatTanimID.Properties.DisplayMember = "FiyatTanimAdi";
        lkpPiyasaFiyatTanimID.Properties.ValueMember = "FiyatTanimID";
        #endregion

        //lkpAlisFaturasindaAlisFiyatininAktarilacagiFiyat.DataBindings.Add("EditValue", clsTablolar.csAyarlar,"StokAlisFiyatTanimID");

        Ayarlar = new clsTablolar.Ayarlar.csAyarlar(SqlConnections.GetBaglanti(), trGenel);


        lkpAlisFaturasindaAlisFiyatininAktarilacagiFiyat.Properties.DataSource = FiyatTanim.FiyatTanimGetir(SqlConnections.GetBaglanti(), trGenel);
        lkpAlisFaturasindaAlisFiyatininAktarilacagiFiyat.Properties.DisplayMember = "FiyatTanimAdi";
        lkpAlisFaturasindaAlisFiyatininAktarilacagiFiyat.Properties.ValueMember = "FiyatTanimID";

        lkpSatisFaturasiIcinFiyat.Properties.DataSource = FiyatTanim.FiyatTanimGetir(SqlConnections.GetBaglanti(), trGenel);
        lkpSatisFaturasiIcinFiyat.Properties.DisplayMember = "FiyatTanimAdi";
        lkpSatisFaturasiIcinFiyat.Properties.ValueMember = "FiyatTanimID";

        

        ClastanVerileriAl();



        trGenel.Commit();





        #region HemenAlEntegrasyon BİLGİLERİ GETİRİLİYOR.
        using (SqlCommand cmd = new SqlCommand(@"SELECT SiteAdi,Auth_Code,username,password,Aktif,SKFiyatTanimID,BayiFiyatTanimID,OzelFiyatTanimID,PiyasaFiyatTanimID FROM HemenAlEntegrasyon", SqlConnections.GetBaglanti()))
        {
          using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
          {
            if (dr.Read())
            {
              txtSiteTanim.Text = dr["SiteAdi"].ToString();
              txtAuth_Code.Text = dr["Auth_Code"].ToString();
              txtusername.Text = dr["username"].ToString();
              txtpassword.Text = dr["password"].ToString();
              ceAktif.Checked = (bool)dr["Aktif"];
              lkpSKFiyatTanimID.EditValue = Convert.ToInt32(dr["SKFiyatTanimID"].ToString());
              lkpBayiFiyatTanimID.EditValue = Convert.ToInt32(dr["BayiFiyatTanimID"].ToString());
              lkpOzelFiyatTanimID.EditValue = Convert.ToInt32(dr["OzelFiyatTanimID"].ToString());
              lkpPiyasaFiyatTanimID.EditValue = Convert.ToInt32(dr["PiyasaFiyatTanimID"].ToString());
            }
          }
        }
        #endregion
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    void ClastanVerileriAl()
    {
      #region Alıs Faturası
      lkpAlisFaturasindaAlisFiyatininAktarilacagiFiyat.EditValue = clsTablolar.Ayarlar.csAyarlar.AlisFaturasiFiyatTanimID;
      lkpAlisFaturasiDepoID.EditValue = clsTablolar.Ayarlar.csAyarlar.AlisFaturasiDepoID;
      #endregion
      lkpSatisFaturasiIcinFiyat.EditValue = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID;
      lkpSatisFaturasiIcinDepo.EditValue = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiDepoID;
    }
    void ClasaVerileriVer()
    {
      clsTablolar.Ayarlar.csAyarlar.AlisFaturasiFiyatTanimID = Convert.ToInt32(lkpAlisFaturasindaAlisFiyatininAktarilacagiFiyat.EditValue);
      clsTablolar.Ayarlar.csAyarlar.AlisFaturasiDepoID = Convert.ToInt32(lkpAlisFaturasiDepoID.EditValue);

      clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID = Convert.ToInt32(lkpSatisFaturasiIcinFiyat.EditValue);
      clsTablolar.Ayarlar.csAyarlar.SatisFaturasiDepoID = Convert.ToInt32(lkpSatisFaturasiIcinDepo.EditValue);

    }


    #region VOIP Bağlantı Listesi
    private void btnVOIPEkle_Click(object sender, EventArgs e)
    {
      Ayarlar.frmAyarlarVOIP frmAyarlarVOIP = new frmAyarlarVOIP("-1");
      frmAyarlarVOIP.ShowDialog();
    }
    private void btnVOIPSil_Click(object sender, EventArgs e)
    {
      try
      {
        if (gvVOIP.FocusedRowHandle < 0) return;

        if (XtraMessageBox.Show("Seçili VOIP ayar kaydını silmek istediğinize emin misiniz?", " ",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
          == System.Windows.Forms.DialogResult.No) return;

        using (SqlCommand cmd = new SqlCommand("Delete From AyarlarVOIP Where AyarlarVOIPID=@AyarlarVOIPID", SqlConnections.GetBaglanti()))
        {
          cmd.Parameters.Add("@AyarlarVOIPID", SqlDbType.NVarChar).Value = gvVOIP.GetFocusedRowCellValue("AyarlarVOIPID").ToString();
          cmd.ExecuteNonQuery();

          dtVOIP.Clear();
          daVOIP.Update(dtVOIP);
          daVOIP.Fill(dtVOIP);
        }
      }
      catch (Exception hata)
      {
        if (trGenel != null) trGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void btnVOIPDegistir_Click(object sender, EventArgs e)
    {
      try
      {
        int satirNo = gvVOIP.FocusedRowHandle;
        Ayarlar.frmAyarlarVOIP frmAyarlarVOIP = new frmAyarlarVOIP(gvVOIP.GetFocusedRowCellValue("AyarlarVOIPID").ToString());
        if (frmAyarlarVOIP.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          dtVOIP.Clear();
          daVOIP.Update(dtVOIP);
          daVOIP.Fill(dtVOIP);
        }
        gvVOIP.FocusedRowHandle = satirNo;
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void btnVOIPGuncelle_Click(object sender, EventArgs e)
    {
      dtVOIP.Clear();
      daVOIP.Update(dtVOIP);
      daVOIP.Fill(dtVOIP);
    }
    private void btnVOIPExcel_Click(object sender, EventArgs e)
    {
      frmExceleAktar frmExceleAktar = new frmExceleAktar(gcVOIP);
      frmExceleAktar.Show();
    }
    #endregion

    #region Kullanıcı Listesi
    private void btnKullaniciEkle_Click(object sender, EventArgs e)
    {
      Ayarlar.frmAyarlarKullanici frmAyarlarKullanici = new frmAyarlarKullanici("-1");
      frmAyarlarKullanici.ShowDialog();
    }
    private void btnKullaniciSil_Click(object sender, EventArgs e)
    {
      try
      {
        if (gvVOIP.FocusedRowHandle < 0) return;

        if (XtraMessageBox.Show("Seçili Kullanıcı kaydını silmek istediğinize emin misiniz?", " ",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
          == System.Windows.Forms.DialogResult.No) return;

        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        clsTablolar.csKullanici.KullaniciDelete(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(gvKullanici.GetFocusedRowCellValue("KullaniciID").ToString()));
        trGenel.Commit();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void btnKullaniciDegistir_Click(object sender, EventArgs e)
    {
      try
      {
        int satirNo = gvKullanici.FocusedRowHandle;
        Ayarlar.frmAyarlarKullanici frmAyarlarKullanici = new frmAyarlarKullanici(gvKullanici.GetFocusedRowCellValue("KullaniciID").ToString());
        if (frmAyarlarKullanici.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          dtKullanici.Clear();
          //daKullanici.Update(dtKullanici);
          daKullanici.Fill(dtKullanici);
        }
        gvKullanici.FocusedRowHandle = satirNo;
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
    {
    }
    private void btnKullaniciExcel_Click(object sender, EventArgs e)
    {
      frmExceleAktar frmExceleAktar = new frmExceleAktar(gcKullanici);
      frmExceleAktar.Show();
    }
    #endregion

    private void itemHemelAl_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
    {

    }
    private void simpleButton1_Click(object sender, EventArgs e)
    {
      try
      {

        AyarlarHemeAl.frmHAKategori frmHAKategori = new AyarlarHemeAl.frmHAKategori();
        frmHAKategori.ShowDialog();

        //HemenAlServis.hemenalserviceSoapClient a = new HemenAlServis.hemenalserviceSoapClient();
        //a.Auth("cikolatacerez*+/46", "cikolatacerez", "123456");

        ////a.SetKategori("ornek","001","0","Ana Kategori","0");
        ////a.SetKategori("ornek", "002", "001", "Alt Kategori", "0");

        //a.SetKategori("ornek", "Kategori_Kod_1", "0", "Kategori 1", "0");
        //a.SetKategori("ornek", "Alt_Kategori_Kod_11", "Kategori_Kod_1", "Alt Kategori 11", "0");
        //a.SetKategori("ornek", "Alt_Kategori_Kod_12", "Kategori_Kod_1", "Alt Kategori 12", "0");
        //a.SetKategori("ornek", "Alt_Kategori_Kod_13", "Kategori_Kod_1", "Alt Kategori 13", "0");

        //a.SetKategori("ornek", "Kategori_Kod_2", "0", "Kategori 2", "0");
        //a.SetKategori("ornek", "Alt_Kategori_Kod_21", "Kategori_Kod_2", "Alt Kategori 21", "0");
        //a.SetKategori("ornek", "Alt_Kategori_Kod_22", "Kategori_Kod_2", "Alt Kategori 22", "0");
        //a.SetKategori("ornek", "Alt_Kategori_Kod_23", "Kategori_Kod_2", "Alt Kategori 23", "0");

        //XmlDocument GelenTumveri = new XmlDocument();
        //GelenTumveri.LoadXml(a.GetKategori().ToString());
        //XmlReader xmlReader = new XmlNodeReader(GelenTumveri);
        //DataSet dsGelen = new DataSet();
        //DataTable dtGelen = new DataTable();
        //dsGelen.ReadXml(xmlReader);
        //dtGelen = dsGelen.Tables[0];
        //gridControl1.DataSource = dtGelen;

        //HemenAlServis.hemenalserviceSoapClient a = new HemenAlServis.hemenalserviceSoapClient();
        //a.Auth(
        //a.get
      }
      catch (Exception hata)
      {
        MessageBox.Show(hata.Message);
      }
    }
    private void simpleButton1_Click_1(object sender, EventArgs e)
    {
      AyarlarHemeAl.frmHAStok frmHAStok = new AyarlarHemeAl.frmHAStok();
      frmHAStok.ShowDialog();
    }
    private void btnHemenAlGuncelle_Click(object sender, EventArgs e)
    {
      try
      {
        #region BOŞ ALAN KONTROLÜ YAPILIYOR.
        if (txtAuth_Code.Text == "" || txtpassword.Text == "" || txtSiteTanim.Text == "" || txtusername.Text == "" ||
          lkpSKFiyatTanimID.EditValue == null)
        {
          XtraMessageBox.Show("ilgili alanlar boş geçilemez.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        #endregion
        using (SqlCommand cmd = new SqlCommand(@"
IF EXISTS (SELECT HemenAlEntegrasyonID From HemenAlEntegrasyon )
BEGIN UPDATE HemenAlEntegrasyon SET SiteAdi=@SiteAdi,Auth_Code=@Auth_Code,username=@username,password=@password,Aktif=@Aktif,
SKFiyatTanimID=@SKFiyatTanimID,BayiFiyatTanimID=@BayiFiyatTanimID,OzelFiyatTanimID=@OzelFiyatTanimID,PiyasaFiyatTanimID=@PiyasaFiyatTanimID END
ELSE BEGIN INSERT INTO HemenAlEntegrasyon VALUES(@SiteAdi,@Auth_Code,@username,@password,@Aktif,@SKFiyatTanimID,@BayiFiyatTanimID,@OzelFiyatTanimID,@PiyasaFiyatTanimID)  END ", SqlConnections.GetBaglanti()))
        {
          cmd.Parameters.Add("@SiteAdi", SqlDbType.NVarChar).Value = txtSiteTanim.Text;
          cmd.Parameters.Add("@Auth_Code", SqlDbType.NVarChar).Value = txtAuth_Code.Text;
          cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = txtusername.Text;
          cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtpassword.Text;
          cmd.Parameters.Add("@Aktif", SqlDbType.Bit).Value = ceAktif.Checked;
          cmd.Parameters.Add("@SKFiyatTanimID", SqlDbType.Int).Value = lkpSKFiyatTanimID.EditValue.ToString();
          cmd.Parameters.Add("@BayiFiyatTanimID", SqlDbType.Int).Value = lkpBayiFiyatTanimID.EditValue.ToString();
          cmd.Parameters.Add("@OzelFiyatTanimID", SqlDbType.Int).Value = lkpOzelFiyatTanimID.EditValue.ToString();
          cmd.Parameters.Add("@PiyasaFiyatTanimID", SqlDbType.Int).Value = lkpPiyasaFiyatTanimID.EditValue.ToString();

          cmd.ExecuteNonQuery();
        }
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void btnHemenAlKategori_Click(object sender, EventArgs e)
    {
      AyarlarHemeAl.frmHAKategori frmHAKategori = new AyarlarHemeAl.frmHAKategori();
      frmHAKategori.ShowDialog();
    }

    private void btnMarkalariEsitle_Click(object sender, EventArgs e)
    {
      AyarlarHemeAl.frmHAMarka frmHAMarka = new AyarlarHemeAl.frmHAMarka();
      frmHAMarka.ShowDialog();
    }

    private void simpleButton2_Click(object sender, EventArgs e)
    {
      try
      {
        ClasaVerileriVer();

        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        Ayarlar.AyarlariKaydet(SqlConnections.GetBaglanti(), trGenel);

        trGenel.Commit();
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
  }
}