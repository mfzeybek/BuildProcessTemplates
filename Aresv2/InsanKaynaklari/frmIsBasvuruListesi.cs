using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Aresv2.InsanKaynaklari
{
  public partial class frmIsBasvuruListesi : DevExpress.XtraEditors.XtraForm
  {
    public frmIsBasvuruListesi()
    {
      InitializeComponent();
    }

    private void labelControl1_Click(object sender, EventArgs e)
    {

    }

    private void textEdit16_EditValueChanged(object sender, EventArgs e)
    {

    }

    clsTablolar.IsBasvurulari.csIsBasvurulariArama aramaa = new clsTablolar.IsBasvurulari.csIsBasvurulariArama();

    SqlTransaction Trgenel;
    private void simpleButton1_Click(object sender, EventArgs e)
    {
      Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
      gridControl1.DataSource = aramaa.BasvuruListesi(SqlConnections.GetBaglanti(), Trgenel);
      try
      {
        gridView1.OptionsLayout.StoreAllOptions = true;
        gridView1.OptionsLayout.StoreVisualOptions = true;
        //gridView1.OptionsLayout.StoreDataSettings = true;
        gridView1.RestoreLayoutFromStream(cs.csGridLayout.GetLayout(1, this.Name, gridView1.Name, SqlConnections.GetBaglanti(), Trgenel));
        //gridView1.OptionsBehavior.ReadOnly = true;
        //gridView1.OptionsBehavior.Editable = false;
        //gridView1.Columns["MulakatTarihi"].DisplayFormat.FormatString = "f";
        //gridView1.Columns["MulakatTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      }
      catch (Exception)
      {
      }
      Trgenel.Commit();
    }

    private void btnKaydiAc_Click(object sender, EventArgs e)
    {
      if (gridView1.RowCount == 0) return;
      InsanKaynaklari.frmBasvuruKarti frm = new frmBasvuruKarti(Convert.ToInt32(gridView1.GetFocusedRowCellValue("IsBasvuruID")));
      frm.MdiParent = this.MdiParent;
      frm.Show();
    }

    private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      if (checkButton1.Checked == true && gridView1.RowCount != 0)
      {
        pictureEdit1.DataBindings.Clear();
        pictureEdit1.DataBindings.Add("EditValue", aramaa.FotolariniGetir(SqlConnections.GetBaglanti(), Trgenel, Convert.ToInt32(gridView1.GetFocusedRowCellValue("IsBasvuruID"))), "Dosya");

      }
    }

    private void checkButton1_CheckedChanged(object sender, EventArgs e)
    {
      if (checkButton1.Checked == true)
      {
        pictureEdit1.Visible = true;
      }
      else
      {
        pictureEdit1.Visible = false;
      }
    }

    #region Fotoyu Hareket Ettirenler

    bool Suruklenme = false;
    Point IlkKonum;

    private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
    {
      Suruklenme = true;
      IlkKonum = e.Location;
    }

    private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
    {
      if (Suruklenme == true)
      {
        pictureEdit1.Left = e.X + pictureEdit1.Left - (IlkKonum.X);
        pictureEdit1.Top = e.Y + pictureEdit1.Top - (IlkKonum.Y);
      }
    }

    private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
    {
      Suruklenme = false;
    }



    #endregion


    clsTablolar.IsBasvurulari.csIsBasvurulariGrup Grup = new clsTablolar.IsBasvurulari.csIsBasvurulariGrup();
    private void frmIsBasvuruListesi_Load(object sender, EventArgs e)
    {
      Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
      lkpGrup.Properties.DataSource = Grup.IsBasvurulariGrupGetir(SqlConnections.GetBaglanti(), Trgenel);

      lkpGrup.Properties.DisplayMember = "GrupAdi";
      lkpGrup.Properties.ValueMember = "IsBasvurulariGrupID";


      lkpGrup.DataBindings.Add("EditValue", aramaa, "IsBasvurulariGrupID", false, DataSourceUpdateMode.OnPropertyChanged);

      txtAdi.DataBindings.Add("EditValue", aramaa, "Adi", false, DataSourceUpdateMode.OnPropertyChanged);
      txtSoyadi.DataBindings.Add("EditValue", aramaa, "Soyadi", false, DataSourceUpdateMode.OnPropertyChanged);

      Trgenel.Commit();
    }

    private void lookUpEdit1_Properties_Click(object sender, EventArgs e)
    {

    }

    private void lookUpEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      if (e.Button.Index == 1)
      {
        lkpGrup.EditValue = -1;
      }
    }

    private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      try
      {
        Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
        cs.csGridLayout.InsertLayout(1, this.Name, gridView1, SqlConnections.GetBaglanti(), Trgenel);
        Trgenel.Commit();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      try
      {
        Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
        cs.csGridLayout.InsertLayout(1, this.Name, gridView1, SqlConnections.GetBaglanti(), Trgenel);
        Trgenel.Commit();
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
  }
}