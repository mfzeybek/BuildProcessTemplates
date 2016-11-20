using System;
using System.Data.SqlClient;
using System.Data;

namespace clsTablolar.cari.CariHr
{

  public class csHareketYonu : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
    private DataTable ToDataTable(Type enumType)
    {
      DataTable dt = new DataTable();
      dt.Columns.Add("name", typeof(string));
      dt.Columns.Add("value", typeof(int));

      Array arr = Enum.GetValues(enumType);

      foreach (object o in arr)
      {
        DataRow dr = dt.NewRow();
        dr["name"] = o.ToString();
        dr["value"] = Enum.Parse(enumType, o.ToString());
        dt.Rows.Add(dr);
      }
      return dt;
    }

    

    public DataTable dt_HareketYonu()
    {
      return ToDataTable(typeof(HareketYonu));
    }

  }

  /// <summary>
  /// Alacak mi Borç mu
  /// </summary>
  public enum HareketYonu
  {
    Alacak = 2,
    Borc = 3
  }

  public enum CariHrEntegrasyon
  {
    SatisFaturasi = IslemTipi.SatisFaturasi,
    AlisFaturasi = IslemTipi.AlisFaturasi,
    CariKartHareketi = IslemTipi.CariHareket,
    AlinanCek = IslemTipi.AlinanCek,
    VerilenCek = IslemTipi.VerilenCek,
    BankaHareketi = IslemTipi.BankaHareketi
  }






}
