using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace AresUrunTanitim
{
  public partial class frmStokListesi : DevExpress.XtraEditors.XtraForm
  {
    public frmStokListesi()
    {
      InitializeComponent();
    }
    DataTable dtUrun = new DataTable();
    SqlDataAdapter daUrun = new SqlDataAdapter();

    SqlConnections Turettim = new SqlConnections();
    SqlConnection BaglantiAres = new SqlConnection();
    SqlConnection BaglantiAresUT = new SqlConnection();
    SqlTransaction trGenel;
    string UrunID = "", SecilenDosyaTamYolu = "", SecilenDosyaAdi = "", SonResimID = "";

    private void frmUrunListesi_Load(object sender, EventArgs e)
    {
      BaglantiAres = SqlConnections.GetAresSqlConnection();
      BaglantiAresUT = SqlConnections.GetAresUTSqlConnection();

      if (BaglantiAres.State == ConnectionState.Closed)
        BaglantiAres.Open();
      if (BaglantiAresUT.State == ConnectionState.Closed)
        BaglantiAresUT.Open();

      GridDoldur();
    }
    private void GridDoldur()
    {
      try
      {
        using (daUrun.SelectCommand = new SqlCommand(@"SELECT dbo.Stok.StokID, dbo.Stok.StokAdi, dbo.Stok.Aciklama, dbo.Stok.StokGrubu, dbo.Stok.Barkod, 
dbo.Stok.Adet, dbo.Resim.ResimAdi, dbo.Resim.OnTanimli, dbo.Stok.OzelKod1, dbo.Stok.OzelKod2, dbo.Stok.OzelKod3
FROM  dbo.Stok INNER JOIN dbo.Resim ON dbo.Stok.StokID = dbo.Resim.StokID WHERE (dbo.Stok.SlayttaGosterilsin = 1)", BaglantiAresUT))
        {
          dtUrun.Clear();
          daUrun.Fill(dtUrun);
          gcUrun.DataSource = dtUrun;

          gvUrun.Columns["StokID"].Visible = false;
          gvUrun.Columns["Aciklama"].Visible = false;
          gvUrun.Columns["StokGrubu"].Visible = false;
          gvUrun.Columns["OzelKod1"].Visible = false;
          gvUrun.Columns["OzelKod2"].Visible = false;
          gvUrun.Columns["OzelKod3"].Visible = false;
          gvUrun.Columns["Barkod"].Visible = false;
          gvUrun.Columns["Adet"].Visible = false;
          gvUrun.Columns["ResimAdi"].Visible = false;
          gvUrun.Columns["OnTanimli"].Visible = false;
        }
      }
      catch (Exception hata)
      {
        throw new Exception(hata.Message);
      }
    }

    private void gvUrun_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      try
      {
        if (gvUrun.GetFocusedRowCellValue("StokID") != null)
          using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT ResimID,ResimAdi FROM dbo.Resim Where StokID=@StokID", BaglantiAresUT))
          {
            da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = gvUrun.GetFocusedRowCellValue("StokID").ToString();
            DataTable dt = new DataTable();
            da.Fill(dt);
            gcResim.DataSource = dt;
          }
       // gvResimler_FocusedRowChanged(null, null);
      }
      catch (Exception hata)
      {
        MessageBox.Show(hata.Message);
      }
    }

    private void btnResimEkle_Click(object sender, EventArgs e)
    {
      try
      {
        if (ofdDokuman.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          SecilenDosyaAdi = ofdDokuman.SafeFileName;
          SecilenDosyaTamYolu = ofdDokuman.FileName;

          FileStream fs = new FileStream(SecilenDosyaTamYolu, FileMode.Open, FileAccess.Read);
          BinaryReader br = new BinaryReader(fs);
          byte[] resim = br.ReadBytes((int)fs.Length);
          br.Close();
          fs.Close();
          
          trGenel = BaglantiAres.BeginTransaction();

          #region Veri Tabanına Kayıt Yapılıyor.
          using (SqlCommand cmd = new SqlCommand(
            "Insert Into StokResim(StokID,Resim,Varsayilan) Values(@StokID,@Resim,1) ", BaglantiAres, trGenel))
          {
            cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = -1;
            cmd.Parameters.Add("@Resim", SqlDbType.Image, resim.Length).Value = resim;
            
            cmd.ExecuteNonQuery();
          }
          #endregion

          trGenel.Commit();

          //DosyayiKopyala(SonResimID, SecilenDosyaAdi, SecilenDosyaTamYolu);

          gvUrun_FocusedRowChanged(null,null);
        }
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        MessageBox.Show(hata.Message);
      }
    }
    void DosyayiKopyala(string SourceID, string SecilenDosyaAdi, string SecilenDosyaYolu)
    {
      FileStream fsTarget;
      try
      {
        string fsYolu = Application.StartupPath + "\\UrunResmi\\" + SecilenDosyaAdi; ;
     
        fsTarget = new FileStream(fsYolu, FileMode.Create, FileAccess.Write);

        FileStream fsSource = new FileStream(SecilenDosyaYolu, FileMode.Open, FileAccess.Read);
        byte[] buffer = new byte[fsSource.Length];
        fsSource.Read(buffer, 0, buffer.Length);
        fsSource.Close();
        fsSource.Dispose();

        fsTarget.Write(buffer, 0, buffer.Length);
        fsTarget.Close();
        fsTarget.Dispose();
      }
      catch (Exception hata)
      {
        throw new Exception(hata.Message);
      }
    }

    private void btnVarsayilanYap_Click(object sender, EventArgs e)
    {
      try
      {
        using (SqlCommand cmdGenel = new SqlCommand(@"Update Resim set OnTanimli=1 Where StokID=@StokID; 
Update Resim set OnTanimli=0 Where ResimID NOT IN (@ResimID) AND StokID=@StokID", BaglantiAresUT))
        {

          cmdGenel.Parameters.Add("@ResimID", SqlDbType.Int).Value = gvResim.GetFocusedRowCellValue("ResimID").ToString();
          cmdGenel.Parameters.Add("@StokID", SqlDbType.Int).Value = gvUrun.GetFocusedRowCellValue("StokID").ToString(); 

        cmdGenel.ExecuteNonQuery();
        }
     
      }
      catch (Exception hata)
      {
        MessageBox.Show(hata.Message);
      }
    }
  }
}