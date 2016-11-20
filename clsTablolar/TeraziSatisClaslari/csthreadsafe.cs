using System;

namespace clsTablolar.TeraziSatisClaslari
{
    public class csthreadsafe : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public static object ThreadKilit = new object();

    }
}
