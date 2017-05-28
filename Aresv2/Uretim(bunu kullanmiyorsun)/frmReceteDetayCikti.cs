using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.Uretim
{
  public partial class frmReceteDetayCikti : DevExpress.XtraEditors.XtraForm
  {
    public frmReceteDetayCikti(string ReceteDetayID)
    {
      InitializeComponent();
      _ReceteDetayID = ReceteDetayID;
    }
    string _ReceteDetayID = "-1", StokID = "-1";

    SqlTransaction tr_genel;

    private void frmReceteDetayCikti_Load(object sender, EventArgs e)
    {
      try
      {
        if (_ReceteDetayID != "-1")
        {
          #region REÇETE DETAY BİLGİLERİ OKUNUYOR.
          using (SqlCommand cmd = new SqlCommand(@"
SELECT     dbo.ReceteDetail.StokID, dbo.Stok.StokKodu, dbo.Stok.StokAdi, dbo.ReceteDetail.Miktar, dbo.ReceteDetail.SatirAciklama
FROM         dbo.ReceteDetail INNER JOIN dbo.Stok ON dbo.ReceteDetail.StokID = dbo.Stok.StokID
WHERE     (dbo.ReceteDetail.ReceteDetailID = @ReceteDetailID)", SqlConnections.GetBaglanti()))
          {
            cmd.Parameters.Add("@ReceteDetailID", SqlDbType.Int).Value = _ReceteDetayID;
            using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow))
            {
              if (dr.Read())
              {
                StokID = dr["StokID"].ToString();
                txtStokTanim.Text = dr["StokKodu"].ToString();
                txtStokKodu.Text = dr["StokAdi"].ToString();
                txtMiktar.Text = dr["Miktar"].ToString();
                memoAciklama.Text = dr["SatirAciklama"].ToString();
              }
            }
          }
          #endregion

        }
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    clsTablolar.Stok.csStok YeniStok;
    private void StokEkle(int StokID, decimal Miktar)
    {
      try
      {
        tr_genel = SqlConnections.GetBaglanti().BeginTransaction();
        YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), tr_genel, StokID);
        txtStokKodu.Text = YeniStok.StokKodu;
        txtStokTanim.Text = YeniStok.StokAdi;

        StokID = YeniStok.StokID;
        tr_genel.Commit();
      }
      catch (Exception hata)
      {
        tr_genel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void txtStokKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      Stok.frmStokListesi StokArama = new Stok.frmStokListesi(true);
      StokArama.Stok_Sec = StokEkle;
      StokArama.ShowDialog();
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {

    }
    private void btnKapat_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}