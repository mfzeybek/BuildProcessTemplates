using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraGrid;

namespace Aresv2.Stok
{
  public partial class frmCevrimBirimListesi : DevExpress.XtraEditors.XtraForm
  {
    public frmCevrimBirimListesi(string StokID)
    {
      InitializeComponent();
      _StokID = StokID;
    }
    string _StokID = "-1";

    public static string AltBirim = "", AltBirimKatsayi = "";
    SqlTransaction trGenel;
    private void frmCevrimBirimListesi_Load(object sender, EventArgs e)
    {
      try
      {
        using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT     SB.BirimID, SB.BirimAdi, SBC.KatSayi, SBC.Barkodu
FROM         dbo.StokBirimCevrim AS SBC INNER JOIN
                      dbo.Stok AS S ON SBC.StokID = S.StokID INNER JOIN
                      dbo.StokBirim AS SB ON SBC.BirimID = SB.BirimID
WHERE     (S.StokID = @StokID)", SqlConnections.GetBaglanti()))
        {

          da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = _StokID;
          DataTable dt = new DataTable();
          da.Fill(dt);
          gcBirim.DataSource = dt;
        }
        GridArayuzIslemleri(enGridArayuzIslemleri.Get);
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void gvBirim_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        AltBirim = gvBirim.GetFocusedRowCellValue("BirimID").ToString();
        AltBirimKatsayi = gvBirim.GetFocusedRowCellValue("KatSayi").ToString();
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void frmCevrimBirimListesi_FormClosed(object sender, FormClosedEventArgs e)
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