using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Aresv2.Ajanda
{
  public partial class frmIslemlerIcinRenkSecimi : DevExpress.XtraEditors.XtraForm
  {
    public frmIslemlerIcinRenkSecimi()
    {
      InitializeComponent();
    }

    /*  işlemler için renk seçeceksin
     * Alış faturası Kesildiğinde
     * Satış Faturası Kesildiğinde
     * Verilen Çek Kesildiğinde
     * Verilen Çek Ödendiğinde
     * 
     * Sipariş Verildiğinde
     * Verilen Sipariş Teslim edildiğinde
     * Sipariş Alındığında
     * Alınan Sipariş Teslim Alındığında
     
     
     
     */
    DataTable dt;


    // IslemTipi, GozuksunMu, Renk

    void dt_Olustur()
    {
      dt = new DataTable();
      dt.Columns.Add("SiraNu");
      dt.Columns.Add("IslemID");
      dt.Columns.Add("IslemAdi");
      dt.Columns.Add("Renk");
      dt.Columns.Add("GosterilsinMi");

      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["SiraNu"] = 1;
      dt.Rows[0]["IslemID"] = "Ajanda Notları";
      dt.Rows[0]["IslemAdi"] = 1;
      dt.Rows[0]["Renk"] = 1;
      dt.Rows[0]["GosterilsinMi"] = 1;

      dt.Rows[1]["SiraNu"] = 1;
      dt.Rows[1]["IslemID"] = 1;
      dt.Rows[1]["IslemAdi"] = "Alış Faturaları";
      dt.Rows[1]["Renk"] = 1;
      dt.Rows[1]["GosterilsinMi"] = 1;

      dt.Rows[2]["SiraNu"] = 1;
      dt.Rows[2]["IslemID"] = 1;
      dt.Rows[2]["IslemAdi"] = "Satış Faturaları";
      dt.Rows[2]["Renk"] = 1;
      dt.Rows[2]["GosterilsinMi"] = 1;

      dt.Rows[3]["SiraNu"] = 1;
      dt.Rows[3]["IslemID"] = 1;
      dt.Rows[3]["IslemAdi"] = "Alınan Çekler";
      dt.Rows[3]["Renk"] = 1;
      dt.Rows[3]["GosterilsinMi"] = 1;

      dt.Rows[4]["SiraNu"] = 1;
      dt.Rows[4]["IslemID"] = 1;
      dt.Rows[4]["IslemAdi"] = "Verilen Çekler";
      dt.Rows[4]["Renk"] = 1;
      dt.Rows[4]["GosterilsinMi"] = 1;

      dt.Rows[5]["SiraNu"] = 1;
      dt.Rows[5]["IslemID"] = 1;
      dt.Rows[5]["IslemAdi"] = "Verilen Siparişler";
      dt.Rows[5]["Renk"] = 1;
      dt.Rows[5]["GosterilsinMi"] = 1;

      dt.Rows[6]["SiraNu"] = 1;
      dt.Rows[6]["IslemID"] = 1;
      dt.Rows[6]["IslemAdi"] = "Verilen Siparişlerin Teslim Tarihi";
      dt.Rows[6]["Renk"] = 1;
      dt.Rows[6]["GosterilsinMi"] = 1;

      dt.Rows[7]["SiraNu"] = 1;
      dt.Rows[7]["IslemID"] = 1;
      dt.Rows[7]["IslemAdi"] = "Alınan Siparişler Teslim Tarihi";
      dt.Rows[7]["Renk"] = 1;
      dt.Rows[7]["GosterilsinMi"] = 1;

      dt.Rows[8]["SiraNu"] = 1;
      dt.Rows[8]["IslemID"] = 1;
      dt.Rows[8]["IslemAdi"] = "İş Başvurularının Mülakat Tarihleri";
      dt.Rows[8]["Renk"] = 1;
      dt.Rows[8]["GosterilsinMi"] = 1;

      dt.Rows[9]["SiraNu"] = 1;
      dt.Rows[9]["IslemID"] = 1;
      dt.Rows[9]["IslemAdi"] = "";
      dt.Rows[9]["Renk"] = 1;
      dt.Rows[9]["GosterilsinMi"] = 1;

      dt.Rows[10]["SiraNu"] = 1;
      dt.Rows[10]["IslemID"] = 1;
      dt.Rows[10]["IslemAdi"] = "";
      dt.Rows[10]["Renk"] = 1;
      dt.Rows[10]["GosterilsinMi"] = 1;


    }
  }
}