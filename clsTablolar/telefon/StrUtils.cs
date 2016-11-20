using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace TapiInCS
{
  public class StrUtils
  {
    // GetStringFromByteArray metodu byte dizisindeki belli uzunluktaki
    // bir parçayı alarak, string olarak döndürür.
    //
    // bytes:  Byte dizisi.
    // iStart: Byte dizisindeki başlangıç konumu.
    // iLen:   Çevrilecek  byte parçasının uzunluğu.
    // dec:    Çevirmede kullanılacak Decoder.
    public static string GetStringFromByteArray(Byte[] bytes, int iStart,
        int iLen, Decoder dec)
    {
      // Parametrelerin hata kontrolünü yap.
      if ((iStart + iLen <= bytes.Length) && (iStart >= 0) && (iLen > 0))
      {
        // Karakter dizisi nesnesi oluştur.
        Char[] chars;
        // StringBuilder nesnesi oluştur.
        StringBuilder sb = new StringBuilder();

        // GetCharCount metoduyla, byte dizisindeki kodlaması çözülecek
        // olan byte'lar için gerekli karakter sayısını hesapla.
        int iCharCount = dec.GetCharCount(bytes, iStart, iLen);
        // Karakter dizisini boyutlandır.
        chars = new Char[iCharCount];
        // GetChars metoduyla, belirtilen sayı kadar, byte dizisinden
        // alınan elemanların karakter dizisine çevrilmesi:
        dec.GetChars(bytes, iStart, iLen, chars, 0);

        // must skip null-termination of C++ string
        // Karakter dizisinin sonundaki null kontrolü için:
        for (int i = 0; i < iCharCount; ++i)
        {
          // Konrol karakteri var mı?
          if (Char.GetUnicodeCategory(chars[i]) != UnicodeCategory.Control)
          {
            // Karakter dizini doldur.
            sb.Append(chars[i].ToString());
          }
          else
          {
            break;      // Konrol karakteri yakalandı.
          }//if
        }//for

        return sb.ToString();
      }
      else
      {
        // Parametrelerde hata bulundu. Boş bir string çevir.
        return String.Empty;
      }
    }//GetStringFromByteArray
  }//StrUtils
}
