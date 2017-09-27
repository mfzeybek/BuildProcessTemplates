using System;

namespace clsTablolar.Stok
{
    public class csStokGrubuField : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public int ID { get; set; }
        public int StokID { get; set; }
        public int StokGrupID { get; set; }
        public string StokGrupAdi { get; set; }
    }
}
