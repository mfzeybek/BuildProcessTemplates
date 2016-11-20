using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aresv2
{
  class csGenelKodlar
  {
    // Burada Kullanıcı ID (bunu sonra yapıcan), Grid Adi

    public static void TabloKaydet(string KullanıcıID, string form, string xml)
    {
      File.WriteAllText("c:\\"+KullanıcıID+"_"+form+".xml", xml, Encoding.UTF8);  
    }
     
    public static Int32 IDBossaEksiBirVer(object ID)
    {
      int ID2 = -1;
      if (ID == null || ID.ToString() == "" || ID == DBNull.Value)
      {
        ID2 = -1;
      }
      else
      {
        ID2 = Convert.ToInt32(ID);
      }
      return ID2;
    }
  }
}
