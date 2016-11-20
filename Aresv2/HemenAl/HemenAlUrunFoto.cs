using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Data.SqlClient;

namespace Aresv2.HemenAl
{
  public partial class HemenAlUrunFoto : DevExpress.XtraEditors.XtraForm
  {
    public HemenAlUrunFoto()
    {
      InitializeComponent();
    }
    DataTable dt_UrunFotolari;
    DataTable dt_Urunler;
    private void HemenAlUrunFoto_Load(object sender, EventArgs e)
    {
      csHemenAlGetSet hemenAlma = new csHemenAlGetSet();
      //HemenAlServis.GetUrunResimResponse x = await HemenAlServis.
      //gridControl1.DataSource = hemenAlma.csHemenAlStringToDatatablesds(hemenAlma.Get_Set_Fonksiyonlari.GetUrunResim(""));
      dt_UrunFotolari = new DataTable();

      dt_UrunFotolari = hemenAlma.csHemenAlStringToDatatablesds(hemenAlma.Get_Set_Fonksiyonlari.GetUrunResim("1")).Copy();

      dt_Urunler = new DataTable();
      dt_Urunler = hemenAlma.csHemenAlStringToDatatablesds(hemenAlma.Get_Set_Fonksiyonlari.GetUrun()).Copy();

      //dt_Urunler.Load(hemenAlma.csHemenAlStringToDatatablesds(hemenAlma.Get_Set_Fonksiyonlari.GetUrun()).CreateDataReader());

      var fototo = from Urunler in dt_Urunler.AsEnumerable()
                   join Fotolaar in dt_UrunFotolari.AsEnumerable()
                   on Urunler.Field<string>("product_id") equals Fotolaar.Field<string>("id") 
                   //into data
                   //from Fotolaar in data.DefaultIfEmpty()
                   select new
                   {
                     adi = Urunler[6],
                     stokkodu = Urunler[4],
                     id = Urunler[0],
                     url = Fotolaar["url"]
                   };

      gridControl1.DataSource = fototo;

      MessageBox.Show(gridView1.RowCount.ToString());


      
      //gridControl2.DataSource
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      webBrowser1.Navigate(gridView1.GetFocusedRowCellValue("url").ToString());
    }

    clsTablolar.Stok.csStokArama StokArama;

    SqlTransaction TrGenel;
    
    
    void StokveFotoYukle()
    {
      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
      StokArama = new clsTablolar.Stok.csStokArama();

      StokArama.EMagazaErisimi = 1;
      DataTable dt = new DataTable();
      SqlDataAdapter da = new SqlDataAdapter(@"select stok.stokID, stok.StokKodu, StokAdi ,StokResim.Ftp from stok
left join StokResim on StokResim.StokID = Stok.stokID
where stok.Silindi = 0 and stok.EMagazaErisimi = 1", SqlConnections.GetBaglanti());
      da.SelectCommand.Transaction = TrGenel;
      da.Fill(dt);

      StokArama.StokListeGetir(SqlConnections.GetBaglanti(), TrGenel);

    }

    private void simpleButton4_Click(object sender, EventArgs e)
    {
      csHemenAlGetSet hemenAlma = new csHemenAlGetSet();
      hemenAlma.Get_Set_Fonksiyonlari.SetUrun("Ares", "", gv.GetFocusedRowCellValue("stokkodu").ToString(), gv.GetFocusedRowCellValue("stokkodu").ToString(), "", "", "", "", "", gv.GetFocusedRowCellValue("url").ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "");

    }
  }
}