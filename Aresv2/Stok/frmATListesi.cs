using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace Aresv2.Stok
{
  public partial class frmATListesi : DevExpress.XtraEditors.XtraForm
  {
    /// <summary>
    /// Ambar Transfer Fişlerinin Listelendiği Form
    /// </summary>
    public frmATListesi()
    {
      InitializeComponent();
    }

    SqlTransaction trGenel;
    SqlDataAdapter daAT = new SqlDataAdapter();
    DataTable dtAT = new DataTable();

    private void frmATListesi_Load(object sender, EventArgs e)
    {
      try
      {

        using (SqlDataAdapter daCikis = new SqlDataAdapter())
        {
          DataTable dtCikis = new DataTable();
          daCikis.SelectCommand = new SqlCommand("SELECT DepoID, DepoAdi from Depo", SqlConnections.GetBaglanti());
          using (dtCikis = new DataTable())
          {
            daCikis.Fill(dtCikis);
            lkpCikisAmbar.Properties.PopulateColumns();
            lkpCikisAmbar.Properties.DataSource = dtCikis;
            lkpCikisAmbar.Properties.DisplayMember = "DepoAdi";
            lkpCikisAmbar.Properties.ValueMember = "DepoID";
          }
        }

        using (SqlDataAdapter daGiris = new SqlDataAdapter())
        {
          DataTable dtGiris = new DataTable();
          daGiris.SelectCommand = new SqlCommand("SELECT DepoID, DepoAdi from Depo", SqlConnections.GetBaglanti());
          using (dtGiris = new DataTable())
          {
            daGiris.Fill(dtGiris);
            lkpGirisAmbar.Properties.PopulateColumns();
            lkpGirisAmbar.Properties.DataSource = dtGiris;
            lkpGirisAmbar.Properties.DisplayMember = "DepoAdi";
            lkpGirisAmbar.Properties.ValueMember = "DepoID";
          }
        }
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        MessageBox.Show(hata.Message);
      }
    }
    private void btnFiltrele_Click(object sender, EventArgs e)
    {
      try
      {
        gcAmbarTransfer.DataSource = InitDbCommand();
        gvAmbarTransfer.BestFitColumns();
        GridArayuzIslemleri(enGridArayuzIslemleri.Get);
      }
      catch (Exception hata)
      {
        MessageBox.Show(hata.Message);
      }
    }
    private DataTable InitDbCommand()
    {
      SqlDataAdapter da = new SqlDataAdapter(@"
SELECT    SF.StokFisID, SF.StokFisNo, SF.FisTarihi, SF.FisTuru, SF.GirisCikis, SF.ModulNo, SF.CikisAmbarID, CikisAmbar.DepoAdi AS CikisAmbar, SF.GirisAmbarID, 
                      GirisAmbar.DepoAdi AS GirisAmbar
FROM         dbo.StokFis AS SF LEFT OUTER JOIN
                      dbo.Depo AS GirisAmbar ON SF.GirisAmbarID = GirisAmbar.DepoID LEFT OUTER JOIN
                      dbo.Depo AS CikisAmbar ON SF.CikisAmbarID = CikisAmbar.DepoID", SqlConnections.GetBaglanti());

      StringBuilder sb = new StringBuilder();

      if (lkpCikisAmbar.EditValue != null)
      {
        sb.Append(" (SF.CikisAmbarID=@CikisAmbarID) AND ");
        da.SelectCommand.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = lkpCikisAmbar.EditValue.ToString();
      }

      if (lkpGirisAmbar.EditValue != null)
      {
        sb.Append(" (SF.GirisAmbarID=@GirisAmbarID) AND ");
        da.SelectCommand.Parameters.Add("@GirisAmbarID", SqlDbType.Int).Value = lkpGirisAmbar.EditValue.ToString();
      }

      if (sb.ToString() != "") da.SelectCommand.CommandText += " Where " + sb.ToString().Remove(sb.ToString().Length - 4, 4);

      DataTable dt = new DataTable();
      da.Fill(dt);
      return dt;
    }
    private void btnTemizle_Click(object sender, EventArgs e)
    {

    }
    private void btnKaydiAc_Click(object sender, EventArgs e)
    {
      if (gvAmbarTransfer.FocusedRowHandle < 0) return;
      Stok.frmAmbarTransfer frmAmbarTransfer = new frmAmbarTransfer(Convert.ToInt32(gvAmbarTransfer.GetFocusedRowCellValue("StokFisID").ToString()), frmAmbarTransfer.FormOpenEnum.Edit);
      frmAmbarTransfer.MdiParent = this.MdiParent;
      frmAmbarTransfer.Show();
    }
    private void lkpCikisAmbar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      if (e.Button.Index == 1) lkpCikisAmbar.EditValue = null;
    }
    private void lkpGirisAmbar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      if (e.Button.Index == 1) lkpGirisAmbar.EditValue = null;
    }
    private void frmATListesi_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F2) btnFiltrele_Click(null, null);
    }
    /// <summary>
    /// tablolardaki Triggerların doğru çalışabilmesi için, silinecek detay satırları öncelikle listeye atılıyor sonrasında listeden tek tek çağrılıp siliniyor.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSil_Click(object sender, EventArgs e)
    {
      try
      {
        if (gvAmbarTransfer.FocusedRowHandle < 0) return;
        if (XtraMessageBox.Show("Seçili Transfer İşlemini silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;
        System.Collections.Generic.List<Int32> hareketler = new System.Collections.Generic.List<int>();
        using (SqlCommand cmdHareketler = new SqlCommand("Select StokFisDetayID From StokFisDetay Where StokFisID=@StokFisID", SqlConnections.GetBaglanti()))
        {
          cmdHareketler.Parameters.Add("@StokFisID", SqlDbType.Int).Value = gvAmbarTransfer.GetFocusedRowCellValue("StokFisID").ToString();
          using (SqlDataReader dr = cmdHareketler.ExecuteReader())
          {
            while (dr.Read()) hareketler.Add(Convert.ToInt32(dr["StokFisDetayID"].ToString()));
          }
        }

        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        foreach (Int32 ID in hareketler)
        {
          using (SqlCommand cmdDelete = new SqlCommand("Delete From StokFisDetay Where StokFisDetayID=@StokFisDetayID", SqlConnections.GetBaglanti()))
          {
            cmdDelete.Transaction = trGenel;
            cmdDelete.Parameters.Add("@StokFisDetayID", SqlDbType.Int).Value = ID;
            cmdDelete.ExecuteNonQuery();
          }
        }
        using (SqlCommand cmdDelete = new SqlCommand("Delete From StokFis Where StokFisID=@StokFisID", SqlConnections.GetBaglanti()))
        {
          cmdDelete.Transaction = trGenel;
          cmdDelete.Parameters.Add("@StokFisID", SqlDbType.Int).Value = gvAmbarTransfer.GetFocusedRowCellValue("StokFisID").ToString();
          cmdDelete.ExecuteNonQuery();
        }
        trGenel.Commit();
        btnFiltrele_Click(null, null);
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void frmATListesi_FormClosed(object sender, FormClosedEventArgs e)
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