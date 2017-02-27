using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsTablolar.Fatura
{
    public class csFaturaBarkod : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        

    }
}
