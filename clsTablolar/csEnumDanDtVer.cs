using System;
using System.Data;

namespace clsTablolar
{
  public class csEnumDanDtVer:IDisposable
  {
    /// <summary>
    /// enum u geriye datatable döndürür
    /// 2 kolonu olur dt nin name ve value
    /// </summary>
    /// <param name="enumType"></param>
    /// <returns></returns>
    public DataTable ToDataTable(Type enumType)
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

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
