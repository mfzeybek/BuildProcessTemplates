using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace Aresv2
{
  public partial class frmStokIhtiyac : Form
  {
    public frmStokIhtiyac()
    {
      InitializeComponent();
    }

    clsTablolar.csStokIhtiyac stokIhtiyac;
    private void Form1_Load(object sender, EventArgs e)
    {
      StokIhtiyacDoldur();
      IhtiyacDurumtanimlariniDoldur();


    }

    private void StokIhtiyacDoldur()
    {
      try
      {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        stokIhtiyac = new clsTablolar.csStokIhtiyac(SqlConnections.GetBaglanti(), TrGenel);
        GridKonumYukle();
        TrGenel.Commit();
      }
      catch (Exception hata)
      {
        TrGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }



      gcStokIhtiyac.DataSource = stokIhtiyac.dt_StokIhtiyac;

      stokIhtiyac.dt_StokIhtiyac.RowChanged += new DataRowChangeEventHandler(dt_StokIhtiyac_RowChanged);
      stokIhtiyac.dt_StokIhtiyac.RowDeleted += new DataRowChangeEventHandler(dt_StokIhtiyac_RowChanged);
      stokIhtiyac.dt_StokIhtiyac.RowChanging += new DataRowChangeEventHandler(dt_StokIhtiyac_RowChanged);

      gvStokIhtiyac.CellValueChanging += gvStokIhtiyac_CellValueChanging;
    }

    void gvStokIhtiyac_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
      ButonAktifMiPasifMi(true);
    }


    void dt_StokIhtiyac_RowChanged(object sender, DataRowChangeEventArgs e)
    {
      ButonAktifMiPasifMi(true);
    }


    SqlTransaction TrGenel;

    clsTablolar.StokIhtiyac.csStokIhtiyacDurumTanimlari DurumTanimlari;

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
      stokIhtiyac.StokIhtiyacGuncele(SqlConnections.GetBaglanti(), TrGenel);
      TrGenel.Commit();

      StokIhtiyacDoldur();

      ButonAktifMiPasifMi(false);


    }

    private void IhtiyacDurumtanimlariniDoldur()
    {
      DurumTanimlari = new clsTablolar.StokIhtiyac.csStokIhtiyacDurumTanimlari();
      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

      repositoryItemLookUpEdit_DurumTanimlari.DataSource = DurumTanimlari.TanimlariGetir(SqlConnections.GetBaglanti(), TrGenel);

      repositoryItemLookUpEdit_DurumTanimlari.DisplayMember = "TanimAdi";
      repositoryItemLookUpEdit_DurumTanimlari.ValueMember = "StokIhtiyacDurumTanimlariID";

      //checkedListBoxControl1.DataSource = DurumTanimlari.TanimlariGetir(SqlConnections.GetBaglanti(), TrGenel);
      //checkedListBoxControl1.Items.



      for (int i = 0; i < DurumTanimlari.dt_IhtiyacTanimlari.Rows.Count; i++)
      {
        checkedListBoxControl1.Items.Add(DurumTanimlari.dt_IhtiyacTanimlari.Rows[i]["StokIhtiyacDurumTanimlariID"].ToString(), DurumTanimlari.dt_IhtiyacTanimlari.Rows[i]["TanimAdi"].ToString(), CheckState.Unchecked, true);
      }

      //checkedListBoxControl1.Items.Add(DurumTanimlari.TanimlariGetir(SqlConnections.GetBaglanti(), TrGenel), false);





      //checkedListBoxControl1.DisplayMember = "TanimAdi";
      //checkedListBoxControl1.ValueMember = "StokIhtiyacDurumTanimlariID";

      TrGenel.Commit();
    }

    private void Filtre()
    {
      try
      {
        //gvStokIhtiyac.Columns[1].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
        //gvStokIhtiyac.FindFilterText = "1";
        //gvStokIhtiyac.ActiveFilterString = "DrumID = " + lookUpEdit1.EditValue.ToString();
        //gvStokIhtiyac.ActiveFilterCriteria = lookUpEdit1.EditValue.ToString();






        string str = "[DrumID] In (null ";

        List<object> isaretliler = checkedListBoxControl1.Items.GetCheckedValues();

        for (int i = 0; i < isaretliler.Count; i++)
        {
          //if (checkedListBoxControl1.Items[i].CheckState == CheckState.Checked)


          str += ", " + isaretliler[i].ToString();
          //checkedListBoxControl1.Items[i].Value.ToString();
        }
        str += ")";

        if (str.Split(',').Count() == 1)
          str = "";

        gvStokIhtiyac.ActiveFilterString = str;
        //str = 

        gvStokIhtiyac.Columns["DrumID"].OptionsFilter.AllowFilter = true;
        gvStokIhtiyac.Columns["DrumID"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;

      }
      catch (Exception)
      {
        MessageBox.Show("Filtreleme kriteri hatalı hamısına");
      }
    }

    private void btnStokEkle_Click(object sender, EventArgs e)
    {
      Stok.frmStokListesi frm = new Stok.frmStokListesi(true);

      frm.Stok_Sec = StokEkleBilmemneAmk;

      frm.ShowDialog();
    }
    clsTablolar.Stok.csStok YeniStok;
    void StokEkleBilmemneAmk(int StokID, decimal Miktar)
    {
      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
      YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, StokID);

      stokIhtiyac.dt_StokIhtiyac.Rows.Add(stokIhtiyac.dt_StokIhtiyac.NewRow());
      stokIhtiyac.dt_StokIhtiyac.Rows[stokIhtiyac.dt_StokIhtiyac.Rows.Count - 1]["StokID"] = YeniStok.StokID;
      stokIhtiyac.dt_StokIhtiyac.Rows[stokIhtiyac.dt_StokIhtiyac.Rows.Count - 1]["StokKodu"] = YeniStok.StokKodu;
      stokIhtiyac.dt_StokIhtiyac.Rows[stokIhtiyac.dt_StokIhtiyac.Rows.Count - 1]["StokAdi"] = YeniStok.StokAdi;
      stokIhtiyac.dt_StokIhtiyac.Rows[stokIhtiyac.dt_StokIhtiyac.Rows.Count - 1]["StokIhtiyacMiktari"] = Miktar;
      stokIhtiyac.dt_StokIhtiyac.Rows[stokIhtiyac.dt_StokIhtiyac.Rows.Count - 1]["EklemeTarihi"] = DateTime.Now;
      TrGenel.Commit();
    }

    private void barbtnExceleAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      frmExceleAktar frm = new frmExceleAktar(gcStokIhtiyac);
      frm.Show();
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
      if (gvStokIhtiyac.RowCount != 0 && DialogResult.Yes == MessageBox.Show(gvStokIhtiyac.GetFocusedRowCellValue(StokAdi).ToString() + "\nAdlı stok silinecek", "Sil", MessageBoxButtons.YesNo))
      {
        gvStokIhtiyac.DeleteSelectedRows();
      }
    }


    void ButonAktifMiPasifMi(bool TrueFalse)
    {
      btnKaydet.Enabled = TrueFalse;
      btnVazgec.Enabled = TrueFalse;
    }

    private void btnStokKartiAc_Click(object sender, EventArgs e)
    {
      if (gvStokIhtiyac.FocusedRowHandle < 0) return;
      Stok.frmStokDetay frm = new Stok.frmStokDetay(Convert.ToInt32(stokIhtiyac.dt_StokIhtiyac.Rows[gvStokIhtiyac.FocusedRowHandle]["StokID"]));
      frm.MdiParent = this.MdiParent;
      frm.Show();
    }

    private void btnVazgec_Click(object sender, EventArgs e)
    {
      ButonAktifMiPasifMi(false);
    }

    private void frmStokIhtiyac_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (btnKaydet.Enabled == true)
      {
        MessageBox.Show("Kayıt Tamamlanmadı");
        e.Cancel = true;
      }
    }

    private void frmStokIhtiyac_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Escape: Close();
          break;
        case Keys.F6: btnStokEkle_Click(null, null);
          break;
        default:
          break;
      }
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < checkedListBoxControl1.Items.Count; i++)
      {
        checkedListBoxControl1.Items[i].CheckState = CheckState.Unchecked;
      }
    }

    private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
    {
      Filtre();
    }

    private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      try
      {
        string Layout = "";
        {
          using (var ms = new MemoryStream())
          {
            gvStokIhtiyac.SaveLayoutToStream(ms);
            ms.Position = 0;
            using (var reader = new StreamReader(ms))
              Layout = reader.ReadToEnd();
          }
          TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
          cs.csGridLayout.InsertLayout(1, this.Name, gvStokIhtiyac.Name, Layout, SqlConnections.GetBaglanti(), TrGenel);
          TrGenel.Commit();
        }
      }
      catch (Exception hata)
      {
        TrGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    void GridKonumYukle()
    {
      MemoryStream ms = cs.csGridLayout.GetLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gvStokIhtiyac.Name, SqlConnections.GetBaglanti(), TrGenel);
      if (ms.Length > 0)
        gvStokIhtiyac.RestoreLayoutFromStream(ms);
    }
  }
}
