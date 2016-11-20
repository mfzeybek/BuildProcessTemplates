using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraGrid;

namespace Aresv2.Stok
{
    public partial class frmStokSayim : DevExpress.XtraEditors.XtraForm
  {
    public frmStokSayim(NasilAcsin NasilAcicak_Hamisina)
    {
      NasilHamisina = NasilAcicak_Hamisina;
      InitializeComponent();
    }

    NasilAcsin NasilHamisina; // bazen Sayimdan Bir yere bişiler eklme ihtiyacı olabilir
    SqlTransaction trGenel;

    clsTablolar.Sayim.csStokSayimArama Arama = new clsTablolar.Sayim.csStokSayimArama();
    clsTablolar.csDepo Depo;

    /// <summary>
    /// Liste Seçilirse Bir yere eklemek için değil, arama seçilirse bir yere eklemek için
    /// </summary>
    public enum NasilAcsin { Listemi, Arama }

    private void frmStokSayim_Load(object sender, EventArgs e)
    {
      ClasstanBilgileriAlanlariAl();
      try
      {
        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        Depo = new clsTablolar.csDepo(SqlConnections.GetBaglanti(), trGenel);

        lkpSayimDeposu.Properties.DataSource = Depo.dt_Depo;
        lkpSayimDeposu.Properties.ValueMember = "DepoID";
        lkpSayimDeposu.Properties.DisplayMember = "DepoAdi";

        trGenel.Commit();
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }


    }

    /// <summary>
    /// Bunu Başka Formlara Veri Göndermek İçin Kullanıyorsun Hamısına 
    /// Hangi formda kullanmıştın unuttum şimdi
    /// </summary>
    public int SecilenSayimID = -1;

    private void frmStokSayim_FormClosed(object sender, FormClosedEventArgs e)
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



    void ClasstanBilgileriAlanlariAl()
    {
      deTarihAraligi1.EditValue = Arama.SayimTarihiAraligi1;
      deTarihAraligi2.EditValue = Arama.SayimTarihiAraligi2;

      txtSayimKodu.EditValue = Arama.SayimKodu;
      txtAciklama.EditValue = Arama.Aciklama;

      lkpSayimDeposu.EditValue = Arama.SayimDepoID;
    }
    void ClassaBilgileriGonder()
    {
      if (deTarihAraligi1.EditValue != null)
        Arama.SayimTarihiAraligi1 = (DateTime)deTarihAraligi1.EditValue;

      if (deTarihAraligi2.EditValue != null)
        Arama.SayimTarihiAraligi2 = (DateTime)deTarihAraligi2.EditValue;

      Arama.SayimKodu = txtSayimKodu.EditValue.ToString();
      Arama.Aciklama = txtAciklama.EditValue.ToString();

      Arama.SayimDepoID = (int)lkpSayimDeposu.EditValue;
    }


    private void btnFiltrele_Click(object sender, EventArgs e)
    {
      ClassaBilgileriGonder();

      try
      {
        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        Arama.SayimlariGetir(SqlConnections.GetBaglanti(), trGenel);
        trGenel.Commit();
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
      

      gcSayim.DataSource = Arama.Dt_Sayimlar;

      GridArayuzIslemleri(enGridArayuzIslemleri.Get);
    }

    private void btnSayimGuncelle_Click(object sender, EventArgs e)
    {
      try
      {
        if (gvSayim.DataRowCount < 1) return;
        //string a = gvSayim.GetFocusedRowCellValue("SayimID").ToString(); bu hiç bir yerde kullanılmıyor
        if (NasilHamisina == NasilAcsin.Arama)
        {
          SecilenSayimID = Convert.ToInt32(gvSayim.GetFocusedRowCellValue(colSayimID));
          DialogResult = System.Windows.Forms.DialogResult.Yes;
          Close();
        }
        else
        {
          Stok.frmStokSayimDetayv2 frmStokSayimDetayv2 = new frmStokSayimDetayv2(Convert.ToInt32(gvSayim.GetFocusedRowCellValue("SayimID").ToString()));
          frmStokSayimDetayv2.MdiParent = this.MdiParent;
          frmStokSayimDetayv2.Show();
        }
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void deTarihAraligi1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      if (e.Button.Index == 1)
      {
        deTarihAraligi1.EditValue = null;
      }
    }

    private void deTarihAraligi2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      if (e.Button.Index == 1)
      {
        deTarihAraligi2.EditValue = null;
      }
    }

    private void lkpSayimDeposu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      if (e.Button.Index == 1)
      {
        lkpSayimDeposu.EditValue = -1;
      }
    }
  }
}