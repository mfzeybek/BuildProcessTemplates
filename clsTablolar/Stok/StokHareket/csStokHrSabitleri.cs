using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clsTablolar.Stok.StokHareket
{
  public class csStokHrSabitleri:IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }

  public enum StokHrGirisCikis
  {
    Giris = IslemTipi.StokGirisi,
    Cikis = IslemTipi.StokCikisi
  }

}
