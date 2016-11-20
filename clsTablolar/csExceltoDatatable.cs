using System;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace clsTablolar
{
  public class csExceltoDatatable : IDisposable
  {
    public System.Data.DataTable dt_Excel;
    private SqlDataAdapter da;

    /// <summary>
    /// excel dosyasının sayfa adı Urunler olmalı
    /// Oluşan tablonun kolon isimleri excel dosyasındaki ilk satır yani kolon başlıkları olur.
    /// </summary>
    /// <param name="ExcelDosyaYolu"></param>
    public csExceltoDatatable(string ExcelDosyaYolu)
    {
      string bagExcel = " Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ExcelDosyaYolu + "; Extended Properties=Excel 12.0";
      string cmd = "Select * From [Urunler$]";
      OleDbDataAdapter ole_da = new OleDbDataAdapter(cmd, bagExcel);
      try
      {
        dt_Excel = new System.Data.DataTable();
        ole_da.Fill(dt_Excel);
      }
      catch
      {

      }
    }
    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
