using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Aresv2
{
  public class csDelegeler : IDisposable
  {
    
    /// <summary>
    /// Bu delege DataRow cinsinde birşey ister
    /// </summary>
    /// <param name="ArananBilgiler"></param>
    //public delegate void DataRowAramaBilgileri (DataRow ArananBilgiler);

    //public static delegate void Dadasdsa();    
    



    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
