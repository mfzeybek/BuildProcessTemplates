using System;
using System.Data;

namespace clsTablolar.Yazdirma
{
  public class csYazdirmaIslemiIcinDatasetVer:IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }
    static DataSet ds;
    public static DataSet YazdirmaVerileri(DataTable dt1)
    {
      ds = new DataSet();
      ds.Tables.Add(dt1.Copy());
      return ds;
    }
    public static DataSet YazdirmaVerileri(DataTable dt1, DataTable dt2)
    {
      ds = new DataSet();
      ds.Tables.Add(dt1.Copy());
      ds.Tables.Add(dt2.Copy());
      return ds;
    }
  }
}
