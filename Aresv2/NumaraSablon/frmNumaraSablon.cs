using System;
using System.Data;
using clsTablolar;

namespace Aresv2.NumaraSablon
{
  public partial class frmNumaraSablon : DevExpress.XtraEditors.XtraForm
  {
    public frmNumaraSablon()
    {
      InitializeComponent();
    }
    csNumaraSablon ns = new csNumaraSablon();

    private void frmNumaraSablon_Load(object sender, EventArgs e)
    {

      gcModul.DataSource = dt_NumaraSablonIcinModuller();
    }
    private void gvModul_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      try
      {
        gcNumaraSablon.DataSource = ns.NumaraDoldur(SqlConnections.GetBaglanti(),
          Convert.ToInt32(gvModul.GetFocusedRowCellValue("IslemTipiID").ToString()));
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void btnSatirEkle_Click(object sender, EventArgs e)
    {
      ns.dt.Rows.Add(new object[] { DBNull.Value, gvModul.GetFocusedRowCellValue("IslemTipiID").ToString(), DBNull.Value, DBNull.Value, DBNull.Value, true });
    }
    private void btnSatirSil_Click(object sender, EventArgs e)
    {
      if (gvNumaraSablon.FocusedRowHandle < 0) return;
      gvNumaraSablon.DeleteRow(gvNumaraSablon.FocusedRowHandle);
    }
    private void btnKaydet_Click(object sender, EventArgs e)
    {
      try
      {
        ns.NumaraGuncelle(SqlConnections.GetBaglanti());
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private DataTable dt_NumaraSablonIcinModuller() // bu ile islem tiplerinin aynı olması gerekiyor
    {
      DataTable dt_IslemTipleri = new DataTable();
      dt_IslemTipleri.Columns.Add("IslemTipiID");
      dt_IslemTipleri.Columns.Add("Adi");

      string[] TipAdi = Enum.GetNames(typeof(IslemTipi));
      Array TipID = Enum.GetValues(typeof(IslemTipi));

      foreach (string Adi in TipAdi)
      {
        dt_IslemTipleri.Rows.Add(dt_IslemTipleri.NewRow());
        dt_IslemTipleri.Rows[dt_IslemTipleri.Rows.Count - 1]["Adi"] = Adi;
        dt_IslemTipleri.Rows[dt_IslemTipleri.Rows.Count - 1]["IslemTipiID"] = TipID.GetValue(dt_IslemTipleri.Rows.Count - 1).GetHashCode();
      }

      return dt_IslemTipleri;

    }
  }
}