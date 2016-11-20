using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraGrid;

namespace Aresv2
{
  public partial class frmCariOzelBilgi : DevExpress.XtraEditors.XtraForm
  {
    /// <summary>
    /// Veritabanındaki "CariOzelBilgiTanimlari" tablosu kayıtlarını günceller.
    /// </summary>
    public frmCariOzelBilgi()
    {
      InitializeComponent();
    }
    SqlTransaction trGenel;
		clsTablolar.cari.csCariOzelBilgi OzelBilgi = new clsTablolar.cari.csCariOzelBilgi();
    private void frmCariOzelBilgi_Load(object sender, EventArgs e)
    {
      gridControl1.DataSource = OzelBilgi.OzelBilgiGetir(SqlConnections.GetBaglanti());
      GridArayuzIslemleri(enGridArayuzIslemleri.Get);
    }
    private void frmCariOzelBilgi_FormClosed(object sender, FormClosedEventArgs e)
    {
      try
      {
        OzelBilgi.OzelBilgiGuncelle(SqlConnections.GetBaglanti());
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
  }
}