using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

/* 1nci amacı stokların 2 farklı fiyatlarını karşılaştırmak  
 * 
 *  2nci amacı gene Fiyat karşılaştırmak ancak yeni bir alış fiyatı kaydedildiğinde faturadaki 
 *  stok un alış fiyatı eski alış fiyatından farklı ise o zaman  
 *  hem eski alış fiyatını bilmek 
 *  hem yeni alış fiyatını bilmek gerekiyor bunun için program faturadan gelip gelmediğini kontrol ediyoruz
 *  
 *  Faturadan geliyorsa (faturadan olduğu zaman showdialog olarak açmak gerekiyor çünkü yeni alış fiyatını )
 *        => fiyat 1 in adını alış fiyatı olarak değiştiriyoruz ve bir alan daha ekliyoruz grid e yeni alış fiyatı
 *        => 
 *  
 * 
 * Kolay anlaşılması için
 * 2 adet fiyat tipini karşılaştırıyor fiyat 1 ve fiyat 2 faturadan geldiğinde bunlar genelde alış fiyatı ve satış fiyatı tanımlanıyor
 * 
 *  fiyat karşılaştırmak*/


namespace Aresv2.Stok
{
  public partial class frmStokFiyatKarsilastirma : DevExpress.XtraEditors.XtraForm
  {
    public enum NeIcin
    {
      Faturadan,
      FaturadanDegil
    }

    public frmStokFiyatKarsilastirma(NeIcin Acilacak)
    {
      InitializeComponent();
      if (Acilacak == NeIcin.Faturadan)
      {
        // fauradansa eski fiyat bir göserilecek
        btnStokEkle.Visible = false;
        btnStokCikar.Visible = false;
        btnStokBosalt.Visible = false;

        lkpStokFiyat1.Enabled = false;
        lkpStokFiyat2.Enabled = false;
        
        colEskiFiyat1.Caption = "Eski Alış Fiyatı";
        colFiyat1.Caption = "Yeni Alış Fiyatı";

      }
      else if (Acilacak == NeIcin.FaturadanDegil)
      {
        colEskiFiyat1.Visible = false; // eğer faturadan açmıyorsak eski fiyat yeni fiyat diye bişi yok
        //faturadan değilse eski fiyat 1 gösterilmeyecek
      }
    }

    DataTable dt;

    private void btnKarşılaştır_Click(object sender, EventArgs e)
    {

    }

    decimal FiyattanYuzdeVer(decimal Fiyat1, decimal Fiyat2, decimal Yuzde) // burada yüzde olmasının bir anlamı yok
    {
      if (Fiyat1 != 0)
      {
        Yuzde = ((Fiyat2 - Fiyat1) * 100) / Fiyat1;
        return Yuzde;
      }
      else
        return 0;
    }
    
    decimal YuzdedenFiyat2Ver(decimal Fiyat1, decimal Fiyat2, decimal Yuzde) // buradada Fiyat 2 olmasının bir anlamı yok
    {
      Fiyat2 = Fiyat1 + ((Yuzde * Fiyat1) / 100);
      return Fiyat2;
    }

    clsTablolar.csFiyatTanim FiyatTanimlari = new clsTablolar.csFiyatTanim();
    Stok.frmStokListesi StokArama;
    clsTablolar.Stok.csStok Stok;

    SqlTransaction TrGenel;

    private void frmStokFiyatKarsilastirma_Load(object sender, EventArgs e)
    {



      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

      lkpStokFiyat1.Properties.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel);
      lkpStokFiyat1.Properties.ValueMember = "FiyatTanimID";
      lkpStokFiyat1.Properties.DisplayMember = "FiyatTanimAdi";
      lkpStokFiyat1.EditValue = 1;

      lkpStokFiyat2.Properties.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), TrGenel);
      lkpStokFiyat2.Properties.ValueMember = "FiyatTanimID";
      lkpStokFiyat2.Properties.DisplayMember = "FiyatTanimAdi";
      lkpStokFiyat2.EditValue = 2;


      TrGenel.Commit();

      HareketIcinTabloyuOlustur();

    }

    void HareketIcinTabloyuOlustur()
    {
      dt = new DataTable();

      dt.Columns.Add("StokID");
      dt.Columns.Add("StokAdi");
      dt.Columns.Add("Fiyat1TanimID");
      dt.Columns.Add("FiyatTanimAdi1");
      dt.Columns.Add("Fiyat1", typeof(System.Decimal));
      dt.Columns.Add("EskiFiyat1", typeof(System.Decimal)); // eğer faturadan geliyorsa burası eski fiyat bir fiyatı değişen ürünü görebilmemiz için

      dt.Columns.Add("Yuzde", typeof(System.Decimal)); // Fiyat 2 nin Fiyat 1 den Yuzde Kac Fazla Oldugu Hesaplanıp yazılacak

      dt.Columns.Add("Fiyat2TanimID");
      dt.Columns.Add("FiyatTanimAdi2");
      dt.Columns.Add("Fiyat2", typeof(System.Decimal));
      dt.Columns.Add("EskiFiyat2", typeof(System.Decimal));

      gridControl1.DataSource = dt;

    }

    public void StokEkle(int StokID, decimal Miktar) // miktarın herhangi bir işlemi yok burada sadece delegeye uysun diye
    {
      try
      {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        Stok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), TrGenel, StokID);

        dt.Rows.Add(dt.NewRow());

        dt.Rows[dt.Rows.Count - 1]["StokID"] = Stok.StokID;
        dt.Rows[dt.Rows.Count - 1]["StokAdi"] = Stok.StokAdi;

        dt.Rows[dt.Rows.Count - 1]["Fiyat1TanimID"] = lkpStokFiyat1.EditValue;



        dt.Rows[dt.Rows.Count - 1]["FiyatTanimAdi1"] = lkpStokFiyat1.Text;
        decimal Fiyat1 = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(lkpStokFiyat1.EditValue), StokID);
        dt.Rows[dt.Rows.Count - 1]["Fiyat1"] = Fiyat1;
        dt.Rows[dt.Rows.Count - 1]["EskiFiyat1"] = Fiyat1;

        


        dt.Rows[dt.Rows.Count - 1]["Fiyat2TanimID"] = lkpStokFiyat2.EditValue;
        dt.Rows[dt.Rows.Count - 1]["FiyatTanimAdi2"] = lkpStokFiyat2.Text;

        decimal Fiyat2 = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(lkpStokFiyat2.EditValue), StokID);
        dt.Rows[dt.Rows.Count - 1]["Fiyat2"] = Fiyat2;
        dt.Rows[dt.Rows.Count - 1]["EskiFiyat2"] = Fiyat2;



        decimal Yuzde = 0;
        dt.Rows[dt.Rows.Count - 1]["Yuzde"] = FiyattanYuzdeVer(Fiyat1, Fiyat2, Yuzde);

        TrGenel.Commit();
      }
      catch (Exception hata)
      {
        TrGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    public void StokEkleFaturadan(int StokID, decimal YeniAlisFiyati)
    {
      StokEkle(StokID, 0);
      dt.Rows[dt.Rows.Count - 1]["Fiyat1"] = YeniAlisFiyati;
      decimal Yuzde = 0;
      dt.Rows[dt.Rows.Count - 1]["Yuzde"] = FiyattanYuzdeVer(YeniAlisFiyati, Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Fiyat2"]), Yuzde); // StokEklede hesaplamasına karşı burada tekrar hesaplıyoruz çünkü yeni Alış fiyatı burada geliyor
    }

    private void btnStokEkle_Click(object sender, EventArgs e)
    {
      StokArama = new frmStokListesi(true);
      StokArama.Stok_Sec = StokEkle;

      StokArama.ShowDialog();
    }

    private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
      decimal Fiyat1 = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, colFiyat1));
      decimal Fiyat2 = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, colFiyat2));
      decimal Yuzde = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, colYuzde));


      if (e.Column == gridView1.Columns["Yuzde"])
      {
        Yuzde = Convert.ToDecimal(e.Value);
        gridView1.SetRowCellValue(e.RowHandle, colFiyat2, YuzdedenFiyat2Ver(Fiyat1, Fiyat2, Yuzde));
      }
      if (e.Column == gridView1.Columns["Fiyat2"])
      {
        Fiyat2 = Convert.ToDecimal(e.Value);
        gridView1.SetRowCellValue(e.RowHandle, colYuzde, FiyattanYuzdeVer(Fiyat1, Fiyat2, Yuzde));
      }
    }

    private void btnStokBosalt_Click(object sender, EventArgs e)
    {
      HareketIcinTabloyuOlustur();
    }

    private void btnStokCikar_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes == MessageBox.Show("seçili kayıt çıkartılacaktır", "silerim haaaaa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
      {
        gridView1.DeleteSelectedRows();
      }
    }

    private void btnStokAc_Click(object sender, EventArgs e)
    {
      if (gridView1.RowCount == 0) return;

      frmStokDetay frm = new frmStokDetay(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colStokID)));
      frm.MdiParent = this.MdiParent;
      frm.Show();
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      if (gridView1.RowCount == 0) return;

      try
      {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

        for (int i = 0; i < gridView1.RowCount; i++)
        {
          FiyatTanimlari.FiyatKaydet(SqlConnections.GetBaglanti(), TrGenel, Convert.ToInt32(gridView1.GetRowCellValue(i, colStokID)), Convert.ToInt32(gridView1.GetRowCellValue(i, colFiyat2TanimID)), Convert.ToDecimal(gridView1.GetRowCellValue(i, colFiyat2)));
        }

        TrGenel.Commit();
      }
      catch (Exception hata)
      {
        TrGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }



    }
    // yüzde oranlarının hepsini toplu günceller
    private void btnYuzdeAktar_Click(object sender, EventArgs e)
    {
      decimal Yuzde = Convert.ToDecimal(txtYuzde.EditValue);
      for (int i = 0; i < gridView1.RowCount; i++)
      {
        gridView1.SetRowCellValue(i, colYuzde, Yuzde);

        DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs dsd = new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(i, colYuzde, Yuzde);

        gridView1_CellValueChanging(null, dsd);


      }
    }

    private void btnYukariYuvarla_Click(object sender, EventArgs e)
    {
      if (Convert.ToDecimal(txtAsagiYukariYuvarla.EditValue) != 0)
      {
        for (int i = 0; i < gridView1.RowCount; i++)
        {
          decimal rakkamhamisina = Yuvarlama(Convert.ToDecimal(gridView1.GetRowCellValue(i, colFiyat2)), YuvarlamaSekli.Yukari, Convert.ToDecimal(txtAsagiYukariYuvarla.EditValue));
          gridView1.SetRowCellValue(i, colFiyat2, rakkamhamisina);
          DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs dsd = new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(i, colFiyat2, rakkamhamisina);

          gridView1_CellValueChanging(null, dsd);
        }
      }
    }

    decimal Yuvarlama(decimal YuvarlanacakSayi, YuvarlamaSekli AsagimiYukarimi, decimal YuvarlamaMiktari)
    {
      decimal sonuc = YuvarlanacakSayi;
      if (YuvarlamaSekli.Yukari == AsagimiYukarimi)
      {
        if (YuvarlanacakSayi % YuvarlamaMiktari != 0)
          sonuc = YuvarlanacakSayi + YuvarlamaMiktari - (YuvarlanacakSayi % YuvarlamaMiktari);
      }
      else if (YuvarlamaSekli.Asagi == AsagimiYukarimi)
      {
        if (YuvarlanacakSayi % YuvarlamaMiktari != 0)
          sonuc = YuvarlanacakSayi - (YuvarlanacakSayi % YuvarlamaMiktari);
      }

      return sonuc;
    }
    enum YuvarlamaSekli
    {
      Yukari,
      Asagi
    }

    private void btnAsagiYuvarla_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < gridView1.RowCount; i++)
      {
        decimal YuvarlanmisSayi = Yuvarlama(Convert.ToDecimal(gridView1.GetRowCellValue(i, colFiyat2)), YuvarlamaSekli.Asagi, Convert.ToDecimal(txtAsagiYukariYuvarla.EditValue));
        gridView1.SetRowCellValue(i, colFiyat2, YuvarlanmisSayi);
      }

    }

    private void btnTanimliFiyatGetir_Click(object sender, EventArgs e) // belli bir tanımdaki bütün fiyatları getirmesi için
    {

    }

    private void btnExceleAktar_Click(object sender, EventArgs e)
    {
      frmExceleAktar frm = new frmExceleAktar(gridControl1);
      frm.ShowDialog();
    }

    private void btnFiyat2Getir_Click(object sender, EventArgs e)
    {

    }
  }
}