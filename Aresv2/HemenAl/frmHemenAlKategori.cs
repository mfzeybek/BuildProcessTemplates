using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.HemenAl
{
  public partial class frmHemenAlKategori : DevExpress.XtraEditors.XtraForm
  {
    public frmHemenAlKategori()
    {
      InitializeComponent();
    }


    /* UZUUUN ARADAN SONRA GELEN NOT OLMASI GEREKEN  
     *     KATEGORİLER ÖNCE ARESE KAYDEDİLİR SONRA SİTEDEKİLERLE EŞLEŞTİRİLİR. */
    
    SqlTransaction TrGenel;
    csHemenAlGetSet Kategori = new csHemenAlGetSet();

    clsTablolar.HemenAl.csHemenAlKategori AresHemenAlKategori;
    private void frmHemenAlKategori_Load(object sender, EventArgs e)
    {
      HemenAlKategoriYukle();

      AresHemenAlKategoriYukle();
    }

    private void HemenAlKategoriYukle()
    {
      Kategori.csHemenAlStringToDatatablesds(Kategori.Get_Set_Fonksiyonlari.GetKategori());
      gcHemenAldakiKategoriler.DataSource = Kategori.dt_Gelen;
      
      //lkpHemenAlUstKategori.Properties.

      repositoryItemLookUpEdit_HemenAl_UstKategori.DataSource = Kategori.dt_Gelen;
      repositoryItemLookUpEdit_HemenAl_UstKategori.DisplayMember = "KategoriAdi";
      repositoryItemLookUpEdit_HemenAl_UstKategori.ValueMember = "id";
    }

    private void AresHemenAlKategoriYukle()
    {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

      AresHemenAlKategori = new clsTablolar.HemenAl.csHemenAlKategori();
      AresHemenAlKategori.KategoriGetir(SqlConnections.GetBaglanti(), TrGenel);

      treeList1.DataSource = AresHemenAlKategori.dt_Kategoriler;
      treeList1.KeyFieldName = "HemanAlKategoriID";
      treeList1.ParentFieldName = "UstKategoriID";

      lkpAresHemenAlUstKategori.Properties.DataSource = AresHemenAlKategori.dt_Kategoriler;
      lkpAresHemenAlUstKategori.Properties.DisplayMember = "KategoriAdi";
      lkpAresHemenAlUstKategori.Properties.ValueMember = "HemanAlKategoriID";

      lkpAresHemenAlUstKategori.EditValue = 0;
      lkpAresHemenAlUstKategori.Text = "";
      TrGenel.Commit();
    }



    private void btnAresHemenAlKategoriKaydet_Click(object sender, EventArgs e)
    {
      AresHemenAlKategori.dt_Kategoriler.Rows.Add(AresHemenAlKategori.dt_Kategoriler.NewRow());
      AresHemenAlKategori.dt_Kategoriler.Rows[AresHemenAlKategori.dt_Kategoriler.Rows.Count - 1]["KategoriAdi"] = txtAresHemenAlKategoriAdi.EditValue;
      AresHemenAlKategori.dt_Kategoriler.Rows[AresHemenAlKategori.dt_Kategoriler.Rows.Count - 1]["UstKategoriID"] = lkpAresHemenAlUstKategori.EditValue;

      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
      AresHemenAlKategori.KategoriGuncelle(SqlConnections.GetBaglanti(), TrGenel);
      TrGenel.Commit();

    }

    private void btnGonder_Click(object sender, EventArgs e)
    {
      //Kategori.Get_Set_Fonksiyonlari.SetKategori("Ares", gridView2.GetFocusedRowCellValue(colAresHemenAl_HemanAlKategoriID).ToString(), gridView2.GetFocusedRowCellValue(colAresHemenAl_UstKategoriID).ToString(), gridView2.GetFocusedRowCellValue(colAresHemenAl_KategoriAdi).ToString(), "0");

      treeList1.CheckAll();
        MessageBox.Show(treeList1.GetAllCheckedNodes()[0].ToString());
    }

    private void lkpAresHemenAlUstKategori_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      if (e.Button.Index == 1)
      {
        lkpAresHemenAlUstKategori.EditValue = 0;
        lkpAresHemenAlUstKategori.Text = "";
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {

    }

    private void btnHemenAldakiKategorileriYenile_Click(object sender, EventArgs e)
    {
      HemenAlKategoriYukle();
    }

    private void simpleButton4_Click(object sender, EventArgs e)
    {

    }

  
      


    



  }
}