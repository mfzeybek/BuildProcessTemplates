using System;
using System.Collections;
using System.Text;
using System.ComponentModel;
//using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TapiInCS
{
  // List koleksiyonu ile kullanılacak olan, hat özelliklerini içeren yardımcı sınıfımız.
  // Sınıfımız IComparable arayüzü sayesinde, karşılaştırmalar gerçekleştirebilir.
  public class LineClass : IComparable
  {
    #region Private Members
    //*************************************
    // LineClass sınıfı değişken üyeleri  *
    //*************************************

    // Hat nosu  değişkeni.
    private UInt32 m_iLineDevID;
    // TAPI versiyonu değişkeni.
    private UInt32 m_TAPIVer;
    // Hat adı değişkeni.
    private string m_sLineName;
    // Hizmet sağlayıcısı adı değişkeni.
    private string m_sProviderInfo;
    // Taşıyıcı biçimi değişkeni.
    private Enums.LineBearerMode m_lineBearerModes;
    // Kullanılabilir-uygun hat özellikleri değişkeni.
    private Enums.LineFeature m_lineFeatures;
    // Çağrı ortamı değişkeni.
    private Enums.LineMediaMode m_lineMediaTypes;
    // Hattın kullandığı string format değişkeni.
    private Enums.StringFormat m_StringFormat;
    // m_bSupportVoiceCall:  Hattın sesli arama durumunu gösteren değişken.
    private bool m_bSupportVoiceCall;

    #endregion

    #region Properties
    //*********************************
    // LineClass sınıfı özellikleri   *
    //*********************************

    // Hat ID'sini verir.
    public UInt32 LineDevID
    {
      get { return m_iLineDevID; }
    }

    // Hattın TAPI versiyonunu verir.
    public UInt32 TAPIVer
    {
      get { return m_TAPIVer; }
    }

    // Hattın adını verir.
    public string LineName
    {
      get { return m_sLineName; }
    }

    // Hattın hizmet sağlayıcısı adını verir.
    public string ProviderInfo
    {
      get { return m_sProviderInfo; }
    }

    // Hattın taşıyıcı biçimlerini verir.
    public Enums.LineBearerMode LineBearerModes
    {
      get { return m_lineBearerModes; }
    }

    // Hattın kullanılabilir-uygun özelliklerini verir.
    public Enums.LineFeature LineFeatures
    {
      get { return m_lineFeatures; }
    }

    // Hattın çağrı ortamı özelliğini verir.
    public Enums.LineMediaMode LineMediaTypes
    {
      get { return m_lineMediaTypes; }
    }

    // Hattın kullandığı string formatı verir. 
    public Enums.StringFormat StringFormat
    {
      get { return m_StringFormat; }
    }

    // Sesli aramanın yapılabilme durumunu gösterir.
    public bool SupportVoiceCall
    {
      get { return m_bSupportVoiceCall; }
    }

    #endregion

    #region Constructor
    // LineClass sınıfı yapıcı metodu
    public LineClass(UInt32 lineDevID, UInt32 iTapiVer)
    {
      this.m_iLineDevID = lineDevID;
      this.m_TAPIVer = iTapiVer;
    }

    #endregion

    #region Public Methods
    //***************************
    // Public Metodlar          *
    //***************************

    // IComparable arayüzünü gerçekleştirebilmek için
    // LineClass nesnesinin CompareTo metodunu ortaya koyması gerekir.
    public int CompareTo(Object obj)
    {
      // LineClass nesnesi, parametreden gelen nesneyle kendini karşılaştırır.
      // Burada karşılaştırma hat adıyla delege edilmiştir.
      return this.LineName.CompareTo(((LineClass)obj).LineName);
    }

    // LINEDEVCAPS yapısından ve byte dizisi parametrelerin kullanarak,
    // bir hattın alanlarını dolduracağız.
    public bool PutLineProperties(TAPIClass.LINEDEVCAPS lineDevCaps,
        Byte[] buffer)
    {
      Decoder dec = null;     // Decoder nesnesi

      try
      {
        // Taşıyıcı biçimi değerini ata.
        this.m_lineBearerModes = (Enums.LineBearerMode)lineDevCaps.dwBearerModes;
        // Hat özellikleri değerini ata.
        this.m_lineFeatures = (Enums.LineFeature)lineDevCaps.dwLineFeatures;
        // Çağrı ortamı değerini ata.
        this.m_lineMediaTypes = (Enums.LineMediaMode)lineDevCaps.dwMediaModes;
        // LINEDEVCAPS yapısındaki dwStringFormat parametresi hattın
        // kullandığı string formatını verir.
        this.m_StringFormat = (Enums.StringFormat)lineDevCaps.dwStringFormat;

        // GetDecoder metoduyla Decoder tipinden bir nesne atanıyor.
        dec = TAPIClass.GetDecoder(this.m_StringFormat);
        // Decoder nesnesi null değerse?
        if (dec != null)
        {
          // GetStringFromByteArray tanımlı metodumuzu çağırarak
          // hat adını değişkene ata.
          this.m_sLineName = StrUtils.GetStringFromByteArray(buffer,
              (int)lineDevCaps.dwLineNameOffset,
              (int)lineDevCaps.dwLineNameSize,
              dec);
          // GetStringFromByteArray tanımlı metodumuzu çağırarak
          // hizmet sağlayıcısı adını değişkene ata.
          this.m_sProviderInfo = StrUtils.GetStringFromByteArray(buffer,
              (int)lineDevCaps.dwProviderInfoOffset,
              (int)lineDevCaps.dwProviderInfoSize,
              dec);

          // Hat sesli aramayı destekliyor mu?
          if (CanSupportVoiceCall())
            this.m_bSupportVoiceCall = true;
        }//if

        return true;
      }
      catch (Exception ex)
      {
        //MessageBox.Show(ex.Message);
        return false;
      }
    }//PutLineProperties

    // Hat hakkında kısa bilgi vermek için kullanılır.
    // Bir StringBuilder nesnesini doldurarak string tipine çevirir.
    public string GetLineInfo()
    {
      // StringBuilder nesnesi oluştur.
      StringBuilder sb = new StringBuilder();

      // LineClass sınıfı özelliklerinden bazıları okunurak 'sb' değişkenine
      // ard arda eklenir.
      sb.Append("Hat ID:  " + this.LineDevID + "\r\n");
      sb.Append("Hat Adı:  " + this.LineName + "\r\n");
      sb.Append("Hizmet Sağlayıcısı:  " + this.ProviderInfo + "\r\n");
      sb.Append("Taşıyıcı Biçimi:  " + this.LineBearerModes + "\r\n");
      sb.Append("Hat Özellikleri:  " + this.LineFeatures + "\r\n");
      sb.Append("Çağrı Ortamı:  " + this.LineMediaTypes + "\r\n");

      if (this.CanSupportVoiceCall())
      {
        sb.Append("Sesli Arama:  Destekliyor");
      }
      else
      {
        sb.Append("Sesli Arama:  Desteklemiyor");
      }//if

      // 'sb' nesnesi içindeki sonucu string tipine çevir.
      return sb.ToString();
    }//GetLineInfo

    #endregion

    #region Private Methods
    //***************************
    // Private Metodlar         *
    //***************************

    // Hattın sesli aramayı destekleyip desteklemediğini veren metod.
    private bool CanSupportVoiceCall()
    {
      if (((this.LineBearerModes & Enums.LineBearerMode.LINEBEARERMODE_VOICE) != 0)
         && ((this.LineFeatures & Enums.LineFeature.LINEFEATURE_MAKECALL) != 0)
         && ((this.LineMediaTypes & Enums.LineMediaMode.LINEMEDIAMODE_INTERACTIVEVOICE) != 0))
      {
        // Sesli aramayı destekliyor
        return true;
      }
      else
      {
        // Sesli aramayı desteklemiyor
        return false;
      }//if
    }//CanSupportVoiceCall

    #endregion
  }//LineClass
}