using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.IO;

namespace Aresv2.EksilenStokListesi
{
  public partial class EksilenStokListesi : DevExpress.XtraEditors.XtraForm
  {
    public EksilenStokListesi()
    {
      InitializeComponent();
    }
    SqlConnections Turettim = new SqlConnections();
    SqlTransaction trGenel;
    DataTable dt = new DataTable();
    SqlDataAdapter da = new SqlDataAdapter();
    private void EksilenStokListesi_Load(object sender, EventArgs e)
    {
      try
      {
        SqlConnections.GetBaglanti();
        using (da.SelectCommand = new SqlCommand(@"SELECT     dbo.EksilenStokListesi.EksilenStokListesiID, dbo.EksilenStokListesi.StokID, dbo.Stok.StokAdi, dbo.EksilenStokListesi.CariID, dbo.Cari.CariTanim, 
                      dbo.EksilenStokListesi.SiparisMiktari, dbo.EksilenStokListesi.SiparisTarihi, dbo.EksilenStokListesi.TedarikTarihi, dbo.EksilenStokListesi.TedarikFiyat, 
                      dbo.EksilenStokListesi.SiparisAciklama, dbo.EksilenStokListesi.KalanMiktar, dbo.EksilenStokListesi.IslemAciklama, dbo.EksilenStokListesi.YapilanIslem, 
                      dbo.EksilenStokListesi.IslemTarihi
FROM         dbo.EksilenStokListesi LEFT OUTER JOIN
                      dbo.Stok ON dbo.EksilenStokListesi.StokID = dbo.Stok.StokID LEFT OUTER JOIN
                      dbo.Cari ON dbo.EksilenStokListesi.CariID = dbo.Cari.CariID ", SqlConnections.GetBaglanti()))
        {
          dt.Clear();
          da.Fill(dt);
          gcStokListe.DataSource = dt;
        }
        GridArayuzIslemleri(enGridArayuzIslemleri.Get);

      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void cbtnEkle_Click(object sender, EventArgs e)
    {
      Aresv2.EksilenStokListesi.EksilenStokDetay EksilenStokDetay = new EksilenStokDetay("-1");
      if (EksilenStokDetay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        dt.Clear();
        da.Update(dt);
        da.Fill(dt);
      }
    }
    private void cbtnDegistir_Click(object sender, EventArgs e)
    {
      Aresv2.EksilenStokListesi.EksilenStokDetay EksilenStokDetay = new EksilenStokDetay(gvStokListe.GetFocusedRowCellValue("EksilenStokListesiID").ToString());
      EksilenStokDetay.StokID = gvStokListe.GetFocusedRowCellValue("StokID").ToString();
      EksilenStokDetay.txtStok.Text = gvStokListe.GetFocusedRowCellValue("StokAdi").ToString();

      EksilenStokDetay.CariID = gvStokListe.GetFocusedRowCellValue("CariID").ToString();
      EksilenStokDetay.txtCari.Text = gvStokListe.GetFocusedRowCellValue("CariTanim").ToString();
      EksilenStokDetay.txtSiparisMiktari.Text = gvStokListe.GetFocusedRowCellValue("SiparisMiktari").ToString();
      if (gvStokListe.GetFocusedRowCellValue("SiparisTarihi") == DBNull.Value)
        EksilenStokDetay.deSiparisTarihi.Text = "";
      else
        EksilenStokDetay.deSiparisTarihi.DateTime = Convert.ToDateTime(gvStokListe.GetFocusedRowCellValue("SiparisTarihi").ToString());
      if (gvStokListe.GetFocusedRowCellValue("TedarikTarihi") == DBNull.Value)
        EksilenStokDetay.deTedarikTarihi.Text = "";
      else
        EksilenStokDetay.deTedarikTarihi.DateTime = Convert.ToDateTime(gvStokListe.GetFocusedRowCellValue("TedarikTarihi").ToString());
      EksilenStokDetay.txtTedarikFiyat.Text = gvStokListe.GetFocusedRowCellValue("TedarikFiyat").ToString();
      EksilenStokDetay.memoSiparisAciklama.Text = gvStokListe.GetFocusedRowCellValue("SiparisAciklama").ToString();

      if (gvStokListe.GetFocusedRowCellValue("IslemTarihi") == DBNull.Value)
        EksilenStokDetay.deIslemTarihi.Text = "";
      else
        EksilenStokDetay.deIslemTarihi.DateTime = Convert.ToDateTime(gvStokListe.GetFocusedRowCellValue("IslemTarihi").ToString());
      EksilenStokDetay.txtKalanMiktar.Text = gvStokListe.GetFocusedRowCellValue("KalanMiktar").ToString();
      EksilenStokDetay.memoIslemAciklama.Text = gvStokListe.GetFocusedRowCellValue("IslemAciklama").ToString();
      EksilenStokDetay.memoYapilanIslem.Text = gvStokListe.GetFocusedRowCellValue("YapilanIslem").ToString();

      if (EksilenStokDetay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        dt.Clear();
        da.Update(dt);
        da.Fill(dt);
      }
    }
    private void cbtnSil_Click(object sender, EventArgs e)
    {
      if (gvStokListe.FocusedRowHandle < 0) return;

      if (XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        == System.Windows.Forms.DialogResult.No) return;

      using (SqlCommand cmd = new SqlCommand("Delete From EksilenStokListesi Where EksilenStokListesiID=@EksilenStokListesiID", SqlConnections.GetBaglanti()))
      {
        cmd.Parameters.Add("@EksilenStokListesiID", SqlDbType.NVarChar).Value = gvStokListe.GetFocusedRowCellValue("EksilenStokListesiID").ToString();
        cmd.ExecuteNonQuery();

        dt.Clear();
        da.Update(dt);
        da.Fill(dt);
      }
    }
    private void EksilenStokListesi_FormClosed(object sender, FormClosedEventArgs e)
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