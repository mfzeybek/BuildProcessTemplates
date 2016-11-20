using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


namespace Aresv2.ExceldenUrun_CariCek
{
  public partial class frmExceldenCariAktar : DevExpress.XtraEditors.XtraForm
  {
    public frmExceldenCariAktar()
    {
      InitializeComponent();
    }
    clsTablolar.csExceltoDatatable exceldenal;

    private void buttonEdit1_Properties_Click(object sender, EventArgs e)
    {
      if (DialogResult.OK == openFileDialog1.ShowDialog())
      {
        exceldenal = new clsTablolar.csExceltoDatatable(openFileDialog1.FileName);
        gcExeldekiler.DataSource = exceldenal.dt_Excel;

        buttonEdit1.Text = openFileDialog1.FileName;

        for (int i = 0; i < exceldenal.dt_Excel.Columns.Count; i++)
        {
          repositoryItemComboBox1.Items.Add(exceldenal.dt_Excel.Columns[i].ColumnName);
        }
        xtraTabControl1.Enabled = true;
        btnAktar.Enabled = true;
      }
    }

    DataTable dt_AlanAyarlari;
    void dt_AlanAyarlari_TablosunuOlustur()
    {
      dt_AlanAyarlari = new DataTable();
     dt_AlanAyarlari.Columns.Add("Aktar"); // aktarıp aktarmayacağı
      dt_AlanAyarlari.Columns["Aktar"].DataType = System.Type.GetType("System.Boolean");

      dt_AlanAyarlari.Columns.Add("AlanAdi"); //Stokta Hangi Alana Geliyor
      dt_AlanAyarlari.Columns["AlanAdi"].DataType = System.Type.GetType("System.String");

      dt_AlanAyarlari.Columns.Add("ExcelSutunu"); //Excelde Hangi Alana Geliyor
      dt_AlanAyarlari.Columns["ExcelSutunu"].DataType = System.Type.GetType("System.String");

      dt_AlanAyarlari.Columns.Add("Aciklama"); // Açıklama
      dt_AlanAyarlari.Columns["Aciklama"].DataType = System.Type.GetType("System.String");


      //dt_AlanAyarlari Tablosuna satırları ekliyoruz,
      for (int i = 0; i < 3; i++) // 3 adet satır eklemesini sağladık
      {
        dt_AlanAyarlari.Rows.Add(dt_AlanAyarlari.NewRow());
        dt_AlanAyarlari.Rows[i]["Aktar"] = false; // EKLEDİĞİMİZ 3 SATIRIN
      }

      dt_AlanAyarlari.Rows[0]["AlanAdi"] = "CariAdi";
      dt_AlanAyarlari.Rows[1]["AlanAdi"] = "VergiDairesi";
      dt_AlanAyarlari.Rows[2]["AlanAdi"] = "VergiNumarasi";
    }

    private void frmExceldenCariAktar_Load(object sender, EventArgs e)
    {
      try
      {
        dt_AlanAyarlari_TablosunuOlustur();

        gcAktarilacaklarListesi.DataSource = dt_AlanAyarlari; // burası alan adı kolonuna bağlı imiş
      }
      catch (Exception)
      {
        
        throw;
      }
      
    }

    clsTablolar.cari.csCariv2 CariEkleme;
    SqlTransaction Trgenel;

    private void btnAktar_Click(object sender, EventArgs e)
    {
      ExceldenAktarV2();
    }

    clsTablolar.Stok.csStokGrubuAdindanIDBul GrubAdi = new clsTablolar.Stok.csStokGrubuAdindanIDBul();

    void ExceldenAktarV2() //Excelden alınan bilgileri dt_Alanayarları (yani hangi alan exceldeki hangi kolonda ise) na göre aktarılır.
    {
      for (int i = 0; i < exceldenal.dt_Excel.Rows.Count; i++)
      {
        CariEkleme = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), Trgenel, -1);

        if ((bool)dt_AlanAyarlari.Rows[0]["Aktar"] == true) // Cari Adi için Aktar seçilmişse
          CariEkleme.CariTanim = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[0]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[1]["Aktar"] == true) // Vergi dairesi için Aktar seçilmişse
          CariEkleme.VergiDairesi = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[1]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[2]["Aktar"] == true) // Vergi Numarası için Aktar seçilmişse
          CariEkleme.VergiNumarasi = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[2]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        

        clsTablolar.csNumaraVer stokkoduVer = new clsTablolar.csNumaraVer();

        CariEkleme.CariKod = stokkoduVer.VarsayilanNumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), Trgenel, clsTablolar.IslemTipi.CariKart);

        CariEkleme.CariGuncelle(SqlConnections.GetBaglanti(), Trgenel);
      }
    }

    

  }
}