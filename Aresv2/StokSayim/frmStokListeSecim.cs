using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using System.IO;

namespace Aresv2.Stok
{
  public partial class frmStokListeSecim : DevExpress.XtraEditors.XtraForm
  {
    public frmStokListeSecim()
    {
      InitializeComponent();
    }
    SqlTransaction trGenel;
    public static string StokID = "", StokAdi = "", BirimID = "", BirimAdi = "";
    private void frmStokListeSecim_Load(object sender, EventArgs e)
    {
      try
      {
        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT     SB.BirimID, SB.BirimAdi, S.StokID, S.StokAdi FROM         dbo.Stok AS S LEFT OUTER JOIN  dbo.StokBirim AS SB ON S.StokBirimID = SB.BirimID", SqlConnections.GetBaglanti()))
        {
          da.SelectCommand.Transaction = trGenel;
          DataTable dt = new DataTable();
          da.Fill(dt);
          gcStok.DataSource = dt;
        }
        trGenel.Commit();
        GridArayuzIslemleri(enGridArayuzIslemleri.Get);
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void gvStok_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        if (gvStok.FocusedRowHandle < 0) return;
        StokID = gvStok.GetFocusedRowCellValue("StokID").ToString();
        StokAdi = gvStok.GetFocusedRowCellValue("StokAdi").ToString();
        BirimID = gvStok.GetFocusedRowCellValue("BirimID").ToString();
        BirimAdi = gvStok.GetFocusedRowCellValue("BirimAdi").ToString();
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void frmStokListeSecim_FormClosed(object sender, FormClosedEventArgs e)
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
  }
}