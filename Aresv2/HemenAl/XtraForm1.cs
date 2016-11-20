using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Aresv2.HemenAl
{
  public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
  {
    public XtraForm1()
    {
      InitializeComponent();
    }

    csHemenAlGetSet hemene;

    private void XtraForm1_Load(object sender, EventArgs e)
    {
      try
      {
        hemene = new csHemenAlGetSet();
        gridControl1.DataSource = hemene.csHemenAlStringToDatatablesds(hemene.Get_Set_Fonksiyonlari.GetStokTip());

        //= hemene.GetUrun();
        //gridControl1.DataSource = hemene.btnHemenAlUrunleriGetir_ItemClick(null, null);
      }
      catch (Exception)
      {

        throw;
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      HttpWebRequest PedirPagina = (HttpWebRequest)WebRequest.Create("http://192.168.1.206/prestashop/api/order_histories");
      NetworkCredential nc = new NetworkCredential("46TME410KYCDCE70HGKCVXNHQEYSP9HY", "");
      PedirPagina.Credentials = nc; 
      PedirPagina.Method = "POST";
      PedirPagina.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
      byte[] byteArray = Encoding.UTF8.GetBytes(@"xml=" + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<prestashop xmlns:xlink=\"http://www.w3.org/1999/xlink\">" + "<order_history><id_order_state>7</id_order_state><id_order>7</id_order><id_employee>1</id_employee></order_history>" + "</prestashop>"); PedirPagina.ContentLength = byteArray.Length; Stream dataStream = PedirPagina.GetRequestStream(); dataStream.Write(byteArray, 0, byteArray.Length); dataStream.Close(); HttpWebResponse RespuestaPagina = (HttpWebResponse)PedirPagina.GetResponse();
      if (PedirPagina.HaveResponse) // si hay respuesta          
      {                            //obtener contenido de la respuesta                            
        using (Stream streamContenido = RespuestaPagina.GetResponseStream())
        {
          MessageBox.Show(new StreamReader(streamContenido).ReadToEnd());
        }
      }
      RespuestaPagina.Close();







      //hemene.Get_Set_Fonksiyonlari.SetOzellik("Ares", "", "S00414","168", ""
      //gridControl1.DataSource = hemene.csHemenAlStringToDatatablesds(hemene.Get_Set_Fonksiyonlari.geto);
    }
  }
}