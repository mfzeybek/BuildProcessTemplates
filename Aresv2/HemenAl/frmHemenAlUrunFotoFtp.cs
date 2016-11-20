using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Net;
using System.IO;


namespace Aresv2.HemenAl
{
  public partial class frmHemenAlUrunFotoFtp : DevExpress.XtraEditors.XtraForm
  {
    public frmHemenAlUrunFotoFtp()
    {
      InitializeComponent();
    }


    clsTablolar.Stok.csStokArama Urunler;

    SqlTransaction TrGenel;

    DataTable dt_Stoklar = new DataTable();

    private void frmHemenAlUrunFotoFtp_Load(object sender, EventArgs e)
    {
      //Urunler = new clsTablolar.Stok.csStokArama();

      //Urunler.EMagazaErisimi = 1;

      //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
      //Urunler.StokListeGetir(SqlConnections.GetBaglanti(), TrGenel);

      //gcUrunler.DataSource = Urunler.dt_StokListesi;
      //TrGenel.Commit();

      dt_Stoklar.Columns.Add("StokKodu");
      dt_Stoklar.Columns.Add("StokAdi");
      dt_Stoklar.Columns.Add("StokID");

      gcUrunler.DataSource = dt_Stoklar;

    }

    void FotosunuGetir()
    {
      //Urunler.FotoListesiVer(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvUrunler.GetFocusedRowCellValue("StokID")));


      //şimdilik kapattım
      if (gvUrunler.RowCount == 0) return;
      foto = new clsTablolar.csStokResim(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvUrunler.GetFocusedRowCellValue("StokID")));

      gcFotolar.DataSource = foto.dt_StokResimleri;
    }


    csFtpYeGonder ftppgonder = new csFtpYeGonder();
    public void FtpGonder(string DosyaAdi, byte[] Dosya)
    {
      string cevap = ftppgonder.Gonder(DosyaAdi, Dosya);

      gvFotolar.SetFocusedRowCellValue("Ftp", cevap);
      this.BindingContext[gvFotolar.DataSource].EndCurrentEdit();
      foto.ResimleriGuncelle(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gvFotolar.GetFocusedRowCellValue("StokID")));
    }

    clsTablolar.csStokResim foto;

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      FtpGonder(gvUrunler.GetFocusedRowCellValue("StokAdi").ToString() + gvFotolar.GetFocusedRowCellValue("StokResimID").ToString(), (byte[])gvFotolar.GetFocusedRowCellValue("Resim"));
    }

    private void gvUrunler_Click(object sender, EventArgs e)
    {

    }

    private void gvUrunler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      if (gvUrunler.RowCount == 0) { return; }
      FotosunuGetir();
    }

    private void btnSeciliUrununButunFotoGonder_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < gvFotolar.RowCount; i++)
      {
        FtpGonder(gvUrunler.GetFocusedRowCellValue("StokAdi").ToString() + foto.dt_StokResimleri.Rows[i]["StokResimID"].ToString(), (byte[])foto.dt_StokResimleri.Rows[i]["Resim"]);
      }
    }



    private void simpleButton3_Click(object sender, EventArgs e)
    {
      gcUrunler.Enabled = false;
      gvUrunler.SelectRow(0);
      gvUrunler.MoveFirst();

      for (int x = 0; x < gvUrunler.RowCount; x++)
      {
        gvUrunler.SelectRow(x);
        btnSeciliUrununButunFotoGonder_Click(null, null);
        gvUrunler.MoveNext();
      }
      gcUrunler.Enabled = true;
    }

    private void simpleButton4_Click(object sender, EventArgs e)
    {
      Stok.frmStokDetay frm = new Stok.frmStokDetay(Convert.ToInt32(gvUrunler.GetFocusedRowCellValue("StokID")));
      frm.MdiParent = this.MdiParent;
      frm.Show();
    }


    Stok.frmStokListesi StokArama = new Stok.frmStokListesi();
    private void btnStokEkle_Click(object sender, EventArgs e)
    {
      StokArama.cmbEMagazaErisimi.SelectedIndex = 1;
      StokArama.cmbEMagazaErisimi.Enabled = false;
      StokArama.Stok_Sec = StokEkle;
      StokArama.ShowDialog();

    }

    clsTablolar.Stok.csStok YeniStok;
    void StokEkle(int StokID, decimal Miktar)
    {
      try
      {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, StokID);

        // ekleme işlemi bitene kadar FocusedRowChanged olayını iptal ettim çünkü eklerken de devreye girip hata veriyor
        gvUrunler.FocusedRowChanged -= gvUrunler_FocusedRowChanged;

        dt_Stoklar.Rows.Add(dt_Stoklar.NewRow());
        dt_Stoklar.Rows[dt_Stoklar.Rows.Count - 1]["StokKodu"] = YeniStok.StokKodu;
        dt_Stoklar.Rows[dt_Stoklar.Rows.Count - 1]["StokID"] = YeniStok.StokID;
        dt_Stoklar.Rows[dt_Stoklar.Rows.Count - 1]["StokAdi"] = YeniStok.StokAdi;

        gvUrunler.FocusedRowChanged += gvUrunler_FocusedRowChanged;

        TrGenel.Commit();
      }
      catch (Exception hata)
      {
        TrGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }



    private void btn_Click(object sender, EventArgs e)
    {
      HemenAl.frmTopluUrunGonder frm = new frmTopluUrunGonder();
      frm.MdiParent = this.MdiParent;
      frm.Show();
      for (int i = 0; i < gvUrunler.RowCount; i++)
      {
        frm.StokListedelege(Convert.ToInt32(gvUrunler.GetRowCellValue(i, "StokID")), 1);
      }

    }


  }
}