using System;
using System.Data;
using System.Windows.Forms;
using clsTablolar;
using System.Data.SqlClient;

namespace Aresv2
{
    public partial class frmExceldenUrunCek : Form
  {
    public frmExceldenUrunCek()
    {
      InitializeComponent();
    }

    DataTable dt_AlanAyarlari = new DataTable();

    void dt_AlanAyarlari_TablosunuOlustur()
    {
      dt_AlanAyarlari.Columns.Add("Aktar"); // aktarıp aktarmayacağı
      dt_AlanAyarlari.Columns["Aktar"].DataType = System.Type.GetType("System.Boolean");

      dt_AlanAyarlari.Columns.Add("AlanAdi"); //Stokta Hangi Alana Geliyor
      dt_AlanAyarlari.Columns["AlanAdi"].DataType = System.Type.GetType("System.String");

      dt_AlanAyarlari.Columns.Add("ExcelSutunu"); //Excelde Hangi Alana Geliyor
      dt_AlanAyarlari.Columns["ExcelSutunu"].DataType = System.Type.GetType("System.String");

      dt_AlanAyarlari.Columns.Add("Aciklama"); // Açıklama
      dt_AlanAyarlari.Columns["Aciklama"].DataType = System.Type.GetType("System.String");

      dt_AlanAyarlari.Columns.Add("tag"); // Açıklama
      dt_AlanAyarlari.Columns["tag"].DataType = System.Type.GetType("System.String");


      //dt_AlanAyarlari Tablosuna satırları ekliyoruz,
      int FiyatTanimSayisi = FiyatTanimlari.SatisTanimlariniGetir(SqlConnections.GetBaglanti(), Trgenel).Rows.Count;

      for (int i = 0; i < 8; i++) // 8 adet satır eklemesini sağladık
      {
        dt_AlanAyarlari.Rows.Add(dt_AlanAyarlari.NewRow());
        dt_AlanAyarlari.Rows[i]["Aktar"] = false; // EKLEDİĞİMİZ 8 SATIRIN
      }

      dt_AlanAyarlari.Rows[0]["AlanAdi"] = "StokKodu";
      dt_AlanAyarlari.Rows[1]["AlanAdi"] = "StokAdi";
      dt_AlanAyarlari.Rows[2]["AlanAdi"] = "Barkod";
      dt_AlanAyarlari.Rows[3]["AlanAdi"] = "Aciklama";
      dt_AlanAyarlari.Rows[4]["AlanAdi"] = "OzelKod1";
      dt_AlanAyarlari.Rows[5]["AlanAdi"] = "OzelKod2";
      dt_AlanAyarlari.Rows[6]["AlanAdi"] = "OzelKod3";
      dt_AlanAyarlari.Rows[7]["AlanAdi"] = "Grubu";

      for (int i = 0; i < FiyatTanimSayisi; i++)
      {
        dt_AlanAyarlari.Rows.Add(dt_AlanAyarlari.NewRow());
        dt_AlanAyarlari.Rows[dt_AlanAyarlari.Rows.Count - 1]["AlanAdi"] = FiyatTanimlari.dt_SatisTanimlari.Rows[i]["FiyatTanimAdi"];
        dt_AlanAyarlari.Rows[dt_AlanAyarlari.Rows.Count - 1]["tag"] = FiyatTanimlari.dt_SatisTanimlari.Rows[i]["FiyatTanimID"];
        dt_AlanAyarlari.Rows[dt_AlanAyarlari.Rows.Count - 1]["Aktar"] = false;
      }
    }

    private void frmExceldenUrunCek_Load(object sender, EventArgs e)
    {
      dt_AlanAyarlari_TablosunuOlustur();

      gcAktarilacaklarListesi.DataSource = dt_AlanAyarlari; // burası alan adı kolonuna bağlı imiş

    }

    clsTablolar.Stok.csStokFiyat StokFiyatlari = new clsTablolar.Stok.csStokFiyat();
    clsTablolar.csFiyatTanim FiyatTanimlari = new csFiyatTanim();

    csExceltoDatatable exceldenal;

    private void buttonEdit1_Properties_Click(object sender, EventArgs e)
    {
      if (DialogResult.OK == openFileDialog1.ShowDialog())
      {
        exceldenal = new csExceltoDatatable(openFileDialog1.FileName);
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


    clsTablolar.Stok.csStok StokEkleme;
    SqlTransaction Trgenel;

    private void btnAktar_Click(object sender, EventArgs e)
    {
      ExceldenAktarV2();
    }

    clsTablolar.Stok.csStokGrubuAdindanIDBul GrubAdi = new clsTablolar.Stok.csStokGrubuAdindanIDBul();
    clsTablolar.Stok.csStokArama Stokarama;

    void ExceldenAktarV2() //Excelden alınan bilgileri dt_Alanayarları (yani hangi alan exceldeki hangi kolonda ise) na göre aktarılır.
    {
      for (int i = 0; i < exceldenal.dt_Excel.Rows.Count; i++)
      {
        Stokarama = new clsTablolar.Stok.csStokArama();

        if (cmbStokKarsilastirmaAlani.Text == "Barkodu")
        {
          Stokarama.Barkod = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[2]["ExcelSutunu"].ToString()].ToString();
          Stokarama.StokListeGetir(SqlConnections.GetBaglanti(), Trgenel);
          if (Stokarama.dt_StokListesi.Rows.Count > 0)
          {
            StokEkleme = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), Trgenel, Convert.ToInt32(Stokarama.dt_StokListesi.Rows[0]["StokID"]));
          }
          else
          {
            StokEkleme = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), Trgenel, -1);
          }
        }

        if ((bool)dt_AlanAyarlari.Rows[0]["Aktar"] == true) // stok kodu için Aktar seçilmişse
          StokEkleme.StokKodu = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[0]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[1]["Aktar"] == true) // stok Adi için Aktar seçilmişse
          StokEkleme.StokAdi = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[1]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[2]["Aktar"] == true) // Barkod için Aktar seçilmişse
          StokEkleme.Barkod = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[2]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[3]["Aktar"] == true) //  Aciklama için Aktar seçilmişse
          StokEkleme.Aciklama = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[3]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[4]["Aktar"] == true) //  OzelKod1 için Aktar seçilmişse
          StokEkleme.OzelKod1 = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[4]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[5]["Aktar"] == true) //  OzelKod2 için Aktar seçilmişse
          StokEkleme.OzelKod2 = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[5]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[6]["Aktar"] == true) //  OzelKod3 için Aktar seçilmişse
          StokEkleme.OzelKod3 = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[6]["ExcelSutunu"].ToString()].ToString(); // kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır

        if ((bool)dt_AlanAyarlari.Rows[7]["Aktar"] == true) //  Grubu için Aktar seçilmişse
        {
          string GrupAdi = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[7]["ExcelSutunu"].ToString()].ToString();
          StokEkleme.StokAltGrupID = GrubAdi.GrubAdiverIDAl(SqlConnections.GetBaglanti(), Trgenel, GrupAdi);// kolon adını alan ayarlarında alıyor. O ıncı satır stok kodunun hanki alanda olduğunu söyleyen satır
        }

        if (StokEkleme.StokID == -1)
        {
          clsTablolar.csNumaraVer stokkoduVer = new csNumaraVer();
          StokEkleme.StokKodu = stokkoduVer.VarsayilanNumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), Trgenel, IslemTipi.StokKarti);
        }

        StokEkleme.StokGuncelle(SqlConnections.GetBaglanti(), Trgenel);

        StokFiyatlari.SatisFiyatiGetir(SqlConnections.GetBaglanti(), Trgenel, StokEkleme.StokID);
        StokFiyatlari.AlisFiyatiGetir(SqlConnections.GetBaglanti(), Trgenel, StokEkleme.StokID);

        for (int y = 8; y < dt_AlanAyarlari.Rows.Count; y++)
        {
          if ((bool)dt_AlanAyarlari.Rows[y]["Aktar"] == true) //  fiyat tanımları
          {
            if (StokFiyatlari.dt_SatisFiyati.Select("FiyatTanimID = " + gvAktarilacaklarListesi.GetRowCellValue(y, "tag").ToString()).Length == 1) // stok a o fiyat tanımı daha önceden eklenmişse
            {
              StokFiyatlari.dt_SatisFiyati.Select("FiyatTanimID = " + gvAktarilacaklarListesi.GetRowCellValue(y, "tag").ToString())[0]["Fiyat"] = exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[y]["ExcelSutunu"].ToString()].ToString();
            }
            else
            {
              StokFiyatlari.dt_SatisFiyati.Rows.Add(StokFiyatlari.dt_SatisFiyati.NewRow());
              StokFiyatlari.dt_SatisFiyati.Rows[StokFiyatlari.dt_SatisFiyati.Rows.Count - 1]["Fiyat"] = Convert.ToDecimal(exceldenal.dt_Excel.Rows[i][dt_AlanAyarlari.Rows[y]["ExcelSutunu"].ToString()]); ;
              StokFiyatlari.dt_SatisFiyati.Rows[StokFiyatlari.dt_SatisFiyati.Rows.Count - 1]["FiyatTanimID"] = dt_AlanAyarlari.Rows[y]["tag"];
            }
          }
        }
        StokFiyatlari.StokFiyatGuncelle(SqlConnections.GetBaglanti(), Trgenel, StokEkleme.StokID);
      }
    }
  }


}










