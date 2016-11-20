using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Diagnostics;

namespace Aresv2.Cari
{
  public partial class frmCariDetay : DevExpress.XtraEditors.XtraForm
  {
    public frmCariDetay(int CariID)
    {
      InitializeComponent();
      _CariID = CariID;
    }
    int _CariID = -1;

    clsTablolar.cari.csCariv2 cari;
    clsTablolar.csFiyatTanim fiyat = new csFiyatTanim();

    //clsTablolar.cari.csTelefon Telefon = new clsTablolar.cari.csTelefon();

    SqlTransaction trGenel;
    DataTable dtTelefon = new DataTable();

    csNumaraVer NumaraVer;

    clsTablolar.cari.csAdres Adres;
    clsTablolar.cari.csTelefon Telefon;
    clsTablolar.cari.csCariBakiye Bakiye;


    DataTable dtPhoneType;
    /// <summary>
    /// Kaydet butonuna direk
    /// sil e ise tersi olarak
    /// 
    /// 
    /// </summary>
    /// <param name="True_False"></param>
    void KaydetVazgecSil_Enable(bool True_False)
    {
      if (True_False == true)
        this.Tag = 0;
      else
        this.Tag = 1;

      btnKaydet.Enabled = True_False;
      btnVazgec.Enabled = True_False;

      btnSil.Enabled = !True_False;
    }

    private void frmCariv2_Load(object sender, EventArgs e)
    {
      try
      {
        if (SqlConnections.GetBaglanti().State == ConnectionState.Closed)
          SqlConnections.GetBaglanti().Open();

        NesnelerDolduruluyor();
        trGenel = SqlConnections.GetBaglanti().BeginTransaction();

        cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(_CariID));
        trGenel.Commit();



        CariAlanlariniYukle();
        CariBakiyeYukle();
        //Adres.AdresBind(SqlConnections.GetBaglanti(), _CariID);
        //gcAdres.DataSource = Adres.dt;


        #region Get PhoneType
        SqlDataAdapter daPhoneType = new SqlDataAdapter(@"SELECT TelefonTipiID, TelefonTipi FROM dbo.TelefonTipi", SqlConnections.GetBaglanti());
        dtPhoneType = new DataTable();
        daPhoneType.Fill(dtPhoneType);

        repositoryItemLookUpEdit1.DataSource = dtPhoneType;

        repositoryItemLookUpEdit1.ValueMember = "TelefonTipiID";
        repositoryItemLookUpEdit1.DisplayMember = "TelefonTipi";
        #endregion

        Get_AdresList();
        Get_TelefonList();
        GridArayuzIslemleri(enGridArayuzIslemleri.Get);
        KaydetVazgecSil_Enable(false);
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void NesnelerDolduruluyor()
    {
      try
      {

        #region lkpGrup Doldur
        lkpGrup.Properties.DataSource = clsTablolar.cari.csCariGrup.CariGrupListesi(SqlConnections.GetBaglanti());
        lkpGrup.Properties.PopulateColumns();
        lkpGrup.Properties.ValueMember = "CariGrupID";
        lkpGrup.Properties.DisplayMember = "CariGrup";
        lkpGrup.Properties.Columns["CariGrupID"].Visible = false;
        lkpGrup.Properties.Columns["KaydedenID"].Visible = false;
        lkpGrup.Properties.Columns["KayitTarihi"].Visible = false;
        lkpGrup.Properties.Columns["GuncelleyenID"].Visible = false;
        lkpGrup.Properties.Columns["GuncellemeTarihi"].Visible = false;
        #endregion

        #region lkpFiyatTanim Doldur
        lkpFiyatTanim.Properties.DataSource = fiyat.FiyatTanimGetir(SqlConnections.GetBaglanti(), trGenel);
        lkpFiyatTanim.Properties.PopulateColumns();
        lkpFiyatTanim.Properties.ValueMember = "FiyatTanimID";
        lkpFiyatTanim.Properties.DisplayMember = "FiyatTanimAdi";
        #endregion
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void CariAlanlariniYukle()
    {
      try
      {
        txtCariTanim.Text = cari.CariTanim;
        txtCariKod.Text = cari.CariKod;
        txtVergiDairesi.Text = cari.VergiDairesi;
        txtVergiNumarasi.Text = cari.VergiNumarasi;
        memoAciklama.Text = cari.Aciklama;

        txtOzelKod1.Text = cari.OzelKod1;
        txtOzelKod2.Text = cari.OzelKod2;
        txtOzelKod3.Text = cari.OzelKod3;

        lkpGrup.EditValue = Convert.ToInt32(cari.CariGrupID);
        lkpAltGrup.EditValue = Convert.ToInt32(cari.CariAltGrupID);

        txtWebSayfasi.Text = cari.WebSayfasi;
        lkpFiyatTanim.EditValue = Convert.ToInt32(cari.CariFiyatTanimID);
        txtIskOrani1.Text = cari.IskOrani1.ToString();
        txtIskOrani2.Text = cari.IskOrani2.ToString();
        txtIskOrani3.Text = cari.IskOrani3.ToString();

        txtBankaAdi.Text = cari.BankaAdi.ToString();
        txtBankaSubeAdi.Text = cari.BankaSubeAdi.ToString();
        txtBankaSubeKodu.Text = cari.BankaSubeKodu.ToString();
        txtBankaHesapNo.Text = cari.BankaHesapNo.ToString();
        txtBankaIbanNo.Text = cari.BankaIbanNo.ToString();
        txtBankaAciklama.Text = cari.BankaAciklama.ToString();

      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void CariBakiyeYukle()
    {
      trGenel = SqlConnections.GetBaglanti().BeginTransaction();
      Bakiye = new clsTablolar.cari.csCariBakiye();
      Bakiye.BakiyeVer(SqlConnections.GetBaglanti(), trGenel, cari.CariID);
      trGenel.Commit();
      txtBakiye.EditValue = Bakiye.Bakiye;
      txtAlacak.EditValue = Bakiye.AlacakToplami;
      txtBorc.EditValue = Bakiye.BorcToplami;
    }

    private void lkpGrup_EditValueChanged(object sender, EventArgs e)
    {
      if (lkpGrup.EditValue == null) return;
      lkpAltGrup.Properties.DataSource = clsTablolar.cari.csCariAltGrup.CariAltGrupDoldur(SqlConnections.GetBaglanti(), lkpGrup.EditValue.ToString());
      lkpAltGrup.Properties.PopulateColumns();
      lkpAltGrup.Properties.ValueMember = "CariAltGrupID";
      lkpAltGrup.Properties.DisplayMember = "CariAltGrup";
      lkpAltGrup.Properties.Columns["CariAltGrupID"].Visible = false;
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      try
      {
        //#region BOŞ ALAN KONTROLÜ YAPILIYOR
        //if (txtCariKod.Text == "")
        //{
        //  //txtCariKod.Focus();
        //  //XtraMessageBox.Show("Cari Kod Bilgisini Giriniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //  //return;
        //}
        //if (txtCariTanim.Text == "")
        //{
        //  txtCariTanim.Focus();
        //  XtraMessageBox.Show("Cari Tanım Bilgisini Giriniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //  return;
        //}
        //if ((int)lkpCariTip.EditValue == -1)
        //{
        //  lkpCariTip.Focus();
        //  XtraMessageBox.Show("Cari Tip Seçiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //  return;
        //}
        //#endregion
        gvTelefon.FocusedRowHandle = -1;
        gvAdres.FocusedRowHandle = -1;
        foreach (DataRow row in Adres.dt.AsEnumerable())
          if (row.RowState != DataRowState.Deleted)
            if (row["Varsayilan"].ToString() == "")
            {
              XtraMessageBox.Show("Adres listesi içinde boş Varsayilan değer olamaz.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
            }

        //foreach (DataRow row in Telefon.dt.AsEnumerable())
        //  if (row.RowState != DataRowState.Deleted)
        //    if (row["Varsayilan"].ToString() == "")
        //    {
        //      XtraMessageBox.Show("Telefon listesi içinde boş Varsayilan değer olamaz.", "ARES", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //      return;
        //    }



        cari.CariKod = txtCariKod.Text;
        cari.CariTanim = txtCariTanim.Text;
        cari.VergiDairesi = txtVergiDairesi.Text;
        cari.VergiNumarasi = txtVergiNumarasi.Text;
        cari.Aciklama = memoAciklama.Text;
        cari.Aktif = true;

        if (lkpGrup.EditValue == null)
          cari.CariGrupID = -1;
        else
          cari.CariGrupID = Convert.ToInt32(lkpGrup.EditValue.ToString());

        if (lkpAltGrup.EditValue == null)
          cari.CariAltGrupID = -1;
        else
          cari.CariAltGrupID = Convert.ToInt32(lkpAltGrup.EditValue.ToString());


        cari.OzelKod1 = txtOzelKod1.Text;
        cari.OzelKod2 = txtOzelKod2.Text;
        cari.OzelKod3 = txtOzelKod3.Text;
        cari.WebSayfasi = txtWebSayfasi.Text;

        if (txtIskOrani1.Text == "")
          cari.IskOrani1 = 0;
        else
          cari.IskOrani1 = Convert.ToDecimal(txtIskOrani1.Text);
        if (txtIskOrani2.Text == "")
          cari.IskOrani2 = 0;
        else
          cari.IskOrani2 = Convert.ToDecimal(txtIskOrani2.Text);
        if (txtIskOrani3.Text == "")
          cari.IskOrani3 = 0;
        else
          cari.IskOrani3 = Convert.ToDecimal(txtIskOrani3.Text);

        if (lkpFiyatTanim.EditValue == null)
          cari.CariFiyatTanimID = -1;
        else
          cari.CariFiyatTanimID = Convert.ToInt32(lkpFiyatTanim.EditValue.ToString());


        cari.BankaAdi = txtBankaAdi.Text;
        cari.BankaSubeAdi = txtBankaSubeAdi.Text;
        cari.BankaSubeKodu = txtBankaSubeKodu.Text;
        cari.BankaHesapNo = txtBankaHesapNo.Text;
        cari.BankaIbanNo = txtBankaIbanNo.Text;
        cari.BankaAciklama = txtBankaAciklama.Text;

        trGenel = SqlConnections.GetBaglanti().BeginTransaction();

        if (cari.CariID == -1)
        {
          NumaraVer = new csNumaraVer();
          cari.CariKod = NumaraVer.VarsayilanNumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel, IslemTipi.CariKart);
          txtCariKod.Text = cari.CariKod;
        }
        string cevap = cari.CariGuncelle(SqlConnections.GetBaglanti(), trGenel);
        MessageBox.Show(cevap);




        #region gcAdres İŞLEMLERİ
        this.BindingContext[gcAdres.DataSource].EndCurrentEdit();
        Adres.AdresGuncelle(SqlConnections.GetBaglanti(), trGenel, cari.CariID);
        #endregion

        #region gcTelefon İŞLEMLERİ
        this.BindingContext[gcTelefon.DataSource].EndCurrentEdit();
        Telefon.TelefonGuncelle(SqlConnections.GetBaglanti(), trGenel, cari.CariID);
        #endregion

        KaydetVazgecSil_Enable(false);

        trGenel.Commit();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
        trGenel.Rollback();
      }
    }

    #region Adres

    public void Get_AdresList()
    {
      try
      {
        Adres = new clsTablolar.cari.csAdres(SqlConnections.GetBaglanti(), _CariID);
        gcAdres.DataSource = Adres.dt;
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void btnAdresDegistir_Click(object sender, EventArgs e)
    {

    }

    frmCariAdres AdresKarti;

    private void btnAdresEkle_Click(object sender, EventArgs e)
    {
      AdresKarti = new frmCariAdres();


      try
      {
        if (AdresKarti.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
        {
          Adres.dt.Rows.Add(Adres.dt.NewRow());

          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["AdresTipID"] = BossaVeyaNulsaEksibirVer(AdresKarti.lkpAdresTip.EditValue);
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["PostaKodu"] = AdresKarti.txtPostaKodu.EditValue;
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["UlkeID"] = BossaVeyaNulsaEksibirVer(AdresKarti.lkpUlke.EditValue);
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["UlkeAdi"] = AdresKarti.lkpUlke.Text;
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["SehirAdi"] = AdresKarti.lkpSehir.Text;

          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["IlceAdi"] = AdresKarti.lkpIlce.Text;

          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["SehirID"] = BossaVeyaNulsaEksibirVer(AdresKarti.lkpSehir.EditValue);
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["IlceID"] = BossaVeyaNulsaEksibirVer(AdresKarti.lkpIlce.EditValue);
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["Aciklama"] = AdresKarti.memoAdresAciklama.EditValue.ToString();
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["Adres"] = AdresKarti.memoAdres.EditValue.ToString();
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["AdresTip"] = AdresKarti.lkpAdresTip.Text.ToString();

          if (Adres.dt.Rows.Count == 1)
            Adres.dt.Rows[Adres.dt.Rows.Count - 1]["Varsayilan"] = true;
          else
            Adres.dt.Rows[Adres.dt.Rows.Count - 1]["Varsayilan"] = false;
        }
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    int BossaVeyaNulsaEksibirVer(object obje)
    {
      try
      {
        return Convert.ToInt32(obje);
      }
      catch (Exception)
      {
        return -1;
      }
    }

    private void btnAdresSil_Click(object sender, EventArgs e)
    {
      try
      {
        if (XtraMessageBox.Show("Seçilen Kaydı Silmek İstediğinize Emin misiniz?", " Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
          return;
        gvAdres.DeleteSelectedRows();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void btnAdresDuzenle_Click(object sender, EventArgs e)
    {
      AdresKarti = new frmCariAdres();

      int AdresIndex = gvAdres.GetFocusedDataSourceRowIndex();
      AdresKarti.lkpAdresTip.EditValue = BossaVeyaNulsaEksibirVer(Adres.dt.Rows[AdresIndex]["AdresTipID"]);

      AdresKarti.txtPostaKodu.EditValue = Adres.dt.Rows[AdresIndex]["PostaKodu"];
      AdresKarti.lkpUlke.EditValue = BossaVeyaNulsaEksibirVer(Adres.dt.Rows[AdresIndex]["UlkeID"]);
      //AdresKarti.lkpUlke.Text = Adres.dt.Rows[AdresIndex]["UlkeAdi"].ToString();
      AdresKarti.lkpSehir.Text = Adres.dt.Rows[AdresIndex]["SehirAdi"].ToString();

      AdresKarti.lkpIlce.Text = Adres.dt.Rows[AdresIndex]["IlceAdi"].ToString();


      AdresKarti.lkpSehir.EditValue = BossaVeyaNulsaEksibirVer(Adres.dt.Rows[AdresIndex]["SehirID"]);
      AdresKarti.lkpIlce.EditValue = BossaVeyaNulsaEksibirVer(Adres.dt.Rows[AdresIndex]["IlceID"]);
      AdresKarti.memoAdresAciklama.EditValue = Adres.dt.Rows[AdresIndex]["Aciklama"];
      AdresKarti.memoAdres.EditValue = Adres.dt.Rows[AdresIndex]["Adres"];
      //AdresKarti.lkpAdresTip.Text = Adres.dt.Rows[AdresIndex]["AdresTip"].ToString();

      if (AdresKarti.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
      {


        Adres.dt.Rows[AdresIndex]["AdresTipID"] = BossaVeyaNulsaEksibirVer(AdresKarti.lkpAdresTip.EditValue);
        Adres.dt.Rows[AdresIndex]["PostaKodu"] = AdresKarti.txtPostaKodu.EditValue;
        Adres.dt.Rows[AdresIndex]["UlkeID"] = BossaVeyaNulsaEksibirVer(AdresKarti.lkpUlke.EditValue);
        Adres.dt.Rows[AdresIndex]["UlkeAdi"] = AdresKarti.lkpUlke.Text;
        Adres.dt.Rows[AdresIndex]["SehirAdi"] = AdresKarti.lkpSehir.Text;

        Adres.dt.Rows[AdresIndex]["IlceAdi"] = AdresKarti.lkpIlce.Text;

        Adres.dt.Rows[AdresIndex]["SehirID"] = BossaVeyaNulsaEksibirVer(AdresKarti.lkpSehir.EditValue);
        Adres.dt.Rows[AdresIndex]["IlceID"] = BossaVeyaNulsaEksibirVer(AdresKarti.lkpIlce.EditValue);
        Adres.dt.Rows[AdresIndex]["Aciklama"] = AdresKarti.memoAdresAciklama.EditValue.ToString();
        Adres.dt.Rows[AdresIndex]["Adres"] = AdresKarti.memoAdres.EditValue.ToString();
        Adres.dt.Rows[AdresIndex]["AdresTip"] = AdresKarti.lkpAdresTip.Text.ToString();

        if (Adres.dt.Rows.Count == 1)
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["Varsayilan"] = true;
        else
          Adres.dt.Rows[Adres.dt.Rows.Count - 1]["Varsayilan"] = false;
      }
    }

    //Adresin varsayilanı seçtiği an için önemli
    void repositoryItemCheckEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
    {
      if (Convert.ToBoolean(e.NewValue) == false)
      {
        e.Cancel = true;
        return;
      }


      for (int i = 0; i < gvAdres.RowCount; i++)
      {
        gvAdres.SetRowCellValue(i, colVarsayilan, false);
      }
    }

    #endregion

    #region Telefon

    public void Get_TelefonList()
    {
      try
      {
        Telefon = new clsTablolar.cari.csTelefon(SqlConnections.GetBaglanti(), _CariID);
        gcTelefon.DataSource = Telefon.dt;
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void btnTelefonSil_Click(object sender, EventArgs e)
    {
      try
      {
        if (XtraMessageBox.Show("Seçilen Kaydı Silmek İstediğinize Emin misiniz?", " Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
          return;
        gvTelefon.DeleteSelectedRows();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void btnNumarayiAra_Click(object sender, EventArgs e)
    {
      //if (txtTelefon.Text == "") return;
      //SoftPhone.frmNetTelefonv2 frmNetTelefonv2 = new SoftPhone.frmNetTelefonv2(txtTelefon.Text);
      //frmNetTelefonv2.ShowDialog();
    }

    private void gvTelefon_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
    {
      gvTelefon.SetRowCellValue(e.RowHandle, colVarsayilan, false);
      repositoryItemLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;

      gvTelefon.SetRowCellValue(e.RowHandle, colTelefonTipID, ((DataTable)(repositoryItemLookUpEdit1.DataSource)).Rows[0]["TelefonTipiID"]);
    }

    #endregion

    private void frmCariDetay_FormClosed(object sender, FormClosedEventArgs e)
    {
      try
      {
        GridArayuzIslemleri(enGridArayuzIslemleri.Set);
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    #region Gird Arayüz İşlemleri
    enum enGridArayuzIslemleri { Set, Get };
    void GridArayuzIslemleri(enGridArayuzIslemleri islem)
    {
      try
      {
        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        FormdakiGridleriBul(this, islem);
        trGenel.Commit();
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
      }
    }
    private void FormdakiGridleriBul(Control nesne, enGridArayuzIslemleri islem)
    {
      if (nesne is DevExpress.XtraGrid.GridControl)
      {
        if (islem == enGridArayuzIslemleri.Set)
          GridArayuzleriKaydet(nesne);
        else
          GridArayuzleriYukle(nesne);
      }

      foreach (Control altnesne in nesne.Controls)
        FormdakiGridleriBul(altnesne, islem);
    }
    void GridArayuzleriKaydet(Control ctrl)
    {
      DevExpress.XtraGrid.GridControl gc = new GridControl();
      gc = ctrl as DevExpress.XtraGrid.GridControl;
      DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

      string Layout = "";
      using (var ms = new MemoryStream())
      {
        gv.SaveLayoutToStream(ms);
        ms.Position = 0;
        using (var reader = new StreamReader(ms))
          Layout = reader.ReadToEnd();
      }
      cs.csGridLayout.InsertLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, Layout, SqlConnections.GetBaglanti(), trGenel);
    }
    void GridArayuzleriYukle(Control ctrl)
    {
      DevExpress.XtraGrid.GridControl gc = new GridControl();
      gc = ctrl as DevExpress.XtraGrid.GridControl;
      DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

      MemoryStream ms = cs.csGridLayout.GetLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, SqlConnections.GetBaglanti(), trGenel);
      if (ms.Length > 0)
        gv.RestoreLayoutFromStream(ms);
    }
    #endregion

    private void txtCariKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      NumaraSablon.frmNumaraSablonListesi frmNumaraSablonListesi = new NumaraSablon.frmNumaraSablonListesi((int)clsTablolar.IslemTipi.CariKart);
      if (frmNumaraSablonListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        // txtFaturaNo.Text = NumaraSablon.frmNumaraSablonListesi.Numara;
        // NumaraVer = new csNumaraVer(SqlConnections.GetBaglanti(), trGenel, Fatura.FaturaTipi);

        txtCariKod.Text = frmNumaraSablonListesi._KullanilacakNumara;
        cari.CariKod = frmNumaraSablonListesi._KullanilacakNumara;
      }
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

    private void btnVazgec_Click(object sender, EventArgs e)
    {
      KaydetVazgecSil_Enable(false);
      this.Close();
    }

    private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      Cari.CariHr.frmCariHrKarti frm = new CariHr.frmCariHrKarti(-1, cari.CariID);
      frm.MdiParent = this.MdiParent;
      frm.Show();
    }

    private void btnBakiyeGuncelle_Click(object sender, EventArgs e)
    {
      CariBakiyeYukle();
    }

    private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      Cari.CariHr.frmCariHrListesiv3 HareketListesi = new Cari.CariHr.frmCariHrListesiv3(CariHr.frmCariHrListesiv3.NasilAcicak.Liste);
      HareketListesi.MdiParent = this.MdiParent;
      HareketListesi.Show();

      HareketListesi.txtCariKodu.Text = cari.CariKod;
      HareketListesi.btnFiltrele_Click(null, null);
    }

    private void txtCariKod_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
    {
      KaydetVazgecSil_Enable(true);
    }

    private void gvAdres_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
      KaydetVazgecSil_Enable(true);

    }

    private void frmCariDetay_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (btnKaydet.Enabled == true)
      {
        MessageBox.Show("Kayıt tamamlanmadı");
        e.Cancel = true;
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      //launch xlite and have it dial the number
      //if xlite is running, it will just dial the number
      Process process = new Process();
      process.StartInfo.FileName = "C:\\Program Files (x86)\\CounterPath\\X-Lite\\x-lite.exe";
      process.StartInfo.Arguments = "-dial=\"" + "+905549578244" + "\"";
      process.Start();
    }



  }
}