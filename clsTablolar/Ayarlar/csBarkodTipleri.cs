using System;
using System.Data;



namespace clsTablolar.Ayarlar
{
  public class csBarkodTipleri : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    public enum BarkodTipleri
    {
      EAN_13 = 1,
      EAN_8 = 2,
      UPC_A = 3,
      UPC_E = 4,
      Code_39 = 5,
      Code_128 = 6,
      Code_93 = 7,
      UCC_EAN_128 = 8
    }


    clsTablolar.csEnumDanDtVer DtVer;

    public DataTable dt_BarkodTipleri()
    {
      DtVer = new clsTablolar.csEnumDanDtVer();

      return DtVer.ToDataTable(typeof(BarkodTipleri));
    }
  }
}
