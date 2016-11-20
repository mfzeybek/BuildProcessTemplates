using System;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
public   class csStokHepsi:IDisposable
  {
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    csStok Stok;
    csStokAltGrup StokAltGrup;
    csStokAraGrup StokAraGrup;
    csStokGrup StokGrup;

    public csStokHepsi(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      //Stok = new csStok(Baglanti, Tr, StokID);
      //StokAltGrup = new csStokAltGrup();
      //StokAraGrup = new csStokAraGrup();
      //StokGrup = new csStokGrup();
    }

  }
}
