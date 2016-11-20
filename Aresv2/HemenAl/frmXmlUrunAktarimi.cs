using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Xml;



namespace Aresv2.HemenAl
{
  public partial class frmXmlUrunAktarimi : DevExpress.XtraEditors.XtraForm
  {
    public frmXmlUrunAktarimi()
    {
      InitializeComponent();
    }
    clsTablolar.Stok.csStokArama EntegrasyonUrunlari;
    SqlTransaction Trgenel;
    private void frmXmlUrunAktarimi_Load(object sender, EventArgs e)
    {
      Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
      EntegrasyonUrunlari = new clsTablolar.Stok.csStokArama();
      EntegrasyonUrunlari.EMagazaErisimi = 1;

      EntegrasyonUrunlari.StokListeGetir(SqlConnections.GetBaglanti(), Trgenel);
      gridControl1.DataSource = EntegrasyonUrunlari.dt_StokListesi;

      Trgenel.Commit();
    }
    string xmll = @"<?xml version='1.0' encoding='utf-8'?>
                    <Urunler>";

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      foreach (DataRow item in EntegrasyonUrunlari.dt_StokListesi.AsEnumerable())
      {
        xmll += "<Urun>";
        xmll += "<Urun0></Urun0>";
        xmll += "<Urun1>" + "" + "</Urun1>";   // marka
        xmll += "<Urun2>" + item["StokKodu"] + "</Urun2>";   // kodu
        xmll += "<Urun3>" + item["StokAdi"] + "</Urun3>";   // urunadi
        xmll += "<Urun4>" + item["DetayliUrunBilgisi"] + "</Urun4>";   // Açıklama
        xmll += "<Urun5>" + item["Garanti"] + "</Urun5>";   // Garanti (Ay)
        xmll += "<Urun6>" + "" + "</Urun6>";   // Fiyat
        xmll += "<Urun7>" + "" + "</Urun7>";   // B.Fiyatı
        xmll += "<Urun8>" + "" + "</Urun8>";   // PB - TL-USD-EUR
        xmll += "<Urun9>" + "" + "</Urun9>";   // KDV Oranı
        xmll += "<Urun10>" + item["Desi"] + "</Uru10>";   // Kargo Desi
        xmll += "<Urun11>" + "" + "</Urun11>";   // Stok
        xmll += "<Urun12>" + item[""] + "</Urun12>";   // Resim Dosyası Adı
        xmll += "<Urun13>" + item[""] + "</Urun13>";   // Sitede Açılmış Olan Kategori ID Girmelisiniz
        xmll += "<Urun14>" + item[""] + "</Urun14>";   // Piyasa Fiyatı
        xmll += "<Urun15>" + item[""] + "</Urun15>";   // Maliyet Fiyatı
        xmll += "<Urun16>" + item[""] + "</Urun16>";   // Görüntülenme Sırası
        xmll += "<Urun17>" + item[""] + "</Urun17>";   // Seo Anahtar Kelimeler
        xmll += "<Urun30>" + item[""] + "</Urun30>";   // Stok Durumu ID
        xmll += "<Urun31>" + item[""] + "</Urun31>";   // İndirim Oranı
        xmll += "<Urun32>" + item[""] + "</Urun32>";   // Özel Kategori ID
        xmll += "<Urun33>" + item[""] + "</Urun33>";   // Anahtar Kelimeler
        xmll += "<Urun34>" + item[""] + "</Urun34>";   // Resim 2
        xmll += "<Urun35>" + item[""] + "</Urun35>";   // Resim 3
        xmll += "<Urun36>" + item[""] + "</Urun36>";   // Resim 4
        xmll += "<Urun37>" + item[""] + "</Urun37>";   // Resim 5
        xmll += "<Urun38>" + item[""] + "</Urun38>";   // Resim 6
        xmll += "<Urun39>" + item[""] + "</Urun39>";   // Resim 7
        xmll += "<Urun40>" + item[""] + "</Urun40>";   // Resim 8
        xmll += "<UrunCari>" + item[""] + "</UrunCari>";   // Cari Kodu (excelde AA kolonunda)
        xmll += "</Urun>";
      }
      xmll += @"<UrunlerSecenekMatris>
</UrunlerSecenekMatris>
</Urunler>";

      XmlDocument GelenTumveri = new XmlDocument();

      GelenTumveri.LoadXml(xmll);

      XmlReader xmlReader = new XmlNodeReader(GelenTumveri);


      //if (!File.Exists("KullaniciRaporu.xml"))
      //{
      //  XmlTextWriter xmlolustur = new XmlTextWriter("KullaniciRaporu.xml", null);//ilk parametre dosyanın oluşturulacağı lokasyon, ikinci parametre encoding

      //  xmlolustur.WriteStartDocument();//xml içinde element oluşturma işlemine başlandı

      //  xmlolustur.WriteComment("kullanıcı detayları raporu");
      //    //+/dosya içine bir açıklama satırı eklendi

      //  xmlolustur.WriteStartElement("Rapor");//bir etiket oluşturduk

      //  xmlolustur.WriteEndDocument();//element oluşturma işlemi bitti

      //  xmlolustur.Close();//dosya oluşturuldu ve işlemler tamamlandı
      //}
    }
  }
}