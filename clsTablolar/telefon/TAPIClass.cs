using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace TapiInCS
{
  // TAPI fonksiyonlarını, yapılarını ve sabitlerini sarmalayan sınıf.
  // Daha fazla bilgi için: bkz. Platform SDK -> TAPI Reference
  public class TAPIClass : IDisposable
  {
    #region Constants
    //***************************
    // Kullanacağımız sabitler  *
    //*************************** 

    // TAPI fonksiyon çağrısı başarıya ulaştı değeri.
    public const Int32 TAPI_SUCCESS = 0;
    // Windows için örnek TAPI versiyonu 2.0 varsayılıyor.
    public const UInt32 TAPISuppVer = 0x00020000;
    // En düşük TAPI versiyonu 1.3 atanıyor.
    public const UInt32 TAPILowVer = 0x00010003;
    // En yüksek TAPI versiyonu 3.0 atanıyor.
    public const UInt32 TAPIHighVer = 0x00030000;
    // frmTelephony adlı ana formumuz.
    //public static frmTelephony frmMain;
    // Phone Dialer içindeki Call Status penceresi başlığı.
    public string sCallStatusTitle = "Call Status";

    #endregion

    #region TAPI Structures
    //***************************
    // Kullanacağımız yapılar   *
    //***************************  

    // lineInitializeEx çağrılırken verilmesi gereken parametreleri tanımlayan yapı.
    [StructLayout(LayoutKind.Sequential)]
    public class LINEINITIALIZEEXPARAMS
    {
      // dwTotalSize: Yapının toplam uzunluğu
      public Int32 dwTotalSize = Marshal.SizeOf(typeof(LINEINITIALIZEEXPARAMS));
      public Int32 dwNeededSize;
      public Int32 dwUsedSize;
      public Int32 dwOptions;
      public IntPtr hEvent = IntPtr.Zero;
      public IntPtr hCompletionPort = IntPtr.Zero;
      public Int32 dwCompletionKey;
    }

    // Telefon numaraları çevirmekle ilgili bilgileri alan yapı.
    // Tuşlar arası süre, çevir sesi için bekleme süresi v.b.
    [StructLayout(LayoutKind.Sequential)]
    public class LINEDIALPARAMS
    {
      public Int32 dwDialPause;
      public Int32 dwDialSpeed;
      public Int32 dwDigitDuration;
      public Int32 dwWaitForDialtone;
    };

    // Dahili hat tanıtıcı yapısı.
    // lineNegotiateAPIVersion ile kullanılacak.
    [StructLayout(LayoutKind.Sequential)]
    public class LINEEXTENSIONID
    {
      public Int32 dwExtensionID0;
      public Int32 dwExtensionID1;
      public Int32 dwExtensionID2;
      public Int32 dwExtensionID3;
    };

    // Hat kapasitesi ve yetenekleriyle ilgili yapı.
    [StructLayout(LayoutKind.Sequential)]
    public class LINEDEVCAPS
    {
      // Yapı için ayrılan toplam uzunluk, byte.
      public Int32 dwTotalSize;
      // Dönen bilgileri tutmak için gereken uzunluk, byte.
      public Int32 dwNeededSize;
      // Faydalı bilgileri kapsayan kısmın uzunluğu, byte.
      public Int32 dwUsedSize;
      // Hizmet sağlayıcısı bilgisinin uzunluğu, byte. 
      public Int32 dwProviderInfoSize;
      // Yapının başlangıcından itibaren, hizmet sağlayıcısı bilgisinin başlangıç konumu.
      public Int32 dwProviderInfoOffset;
      public Int32 dwSwitchInfoSize;
      public Int32 dwSwitchInfoOffset;
      // Sistem tarafından verilen kalıcı hat kimlik nosu.
      public Int32 dwPermanentLineID;
      // Hat adı bilgisinin uzunluğu, byte.
      public Int32 dwLineNameSize;
      // Yapının başlangıcından itibaren, hat adı bilgisinin başlangıç konumu.
      public Int32 dwLineNameOffset;
      // Hattın kullandığı string türü. Bkz. Enums.StringFormat
      public Int32 dwStringFormat;
      // Hat adres kipi
      public Int32 dwAddressModes;
      // Hat adres sayısı
      public Int32 dwNumAddresses;
      // Taşıyıcı biçimi. Bkz. Enums.LineBearerMode
      public Int32 dwBearerModes;
      // Çağrı üzerindeki maksimum veri hızı bits/s
      public Int32 dwMaxRate;
      // Çağrı ortamı tipleri. Bkz. Enums.LineMediaMode
      public Int32 dwMediaModes;
      public Int32 dwGenerateToneModes;
      public Int32 dwGenerateToneMaxNumFreq;
      public Int32 dwGenerateDigitModes;
      public Int32 dwMonitorToneMaxNumFreq;
      public Int32 dwMonitorToneMaxNumEntries;
      public Int32 dwMonitorDigitModes;
      public Int32 dwGatherDigitsMinTimeout;
      public Int32 dwGatherDigitsMaxTimeout;
      public Int32 dwMedCtlDigitMaxListSize;
      public Int32 dwMedCtlMediaMaxListSize;
      public Int32 dwMedCtlToneMaxListSize;
      public Int32 dwMedCtlCallStateMaxListSize;
      public Int32 dwDevCapFlags;
      public Int32 dwMaxNumActiveCalls;
      public Int32 dwAnswerMode;
      public Int32 dwRingModes;
      public Int32 dwLineStates;
      public Int32 dwUUIAcceptSize;
      public Int32 dwUUIAnswerSize;
      public Int32 dwUUIMakeCallSize;
      public Int32 dwUUIDropSize;
      public Int32 dwUUISendUserUserInfoSize;
      public Int32 dwUUICallInfoSize;
      public LINEDIALPARAMS MinDialParams;
      public LINEDIALPARAMS MaxDialParams;
      public LINEDIALPARAMS DefaultDialParams;
      public Int32 dwNumTerminals;
      public Int32 dwTerminalCapsSize;
      public Int32 dwTerminalCapsOffset;
      public Int32 dwTerminalTextEntrySize;
      public Int32 dwTerminalTextSize;
      public Int32 dwTerminalTextOffset;
      public Int32 dwDevSpecificSize;
      public Int32 dwDevSpecificOffset;
      // Kullanılabilir-uygun hat özellikleri Bkz. Enums.LineFeatures
      public Int32 dwLineFeatures;
      public Int32 dwSettableDevStatus;
      public Int32 dwDeviceClassesSize;
      public Int32 dwDeviceClassesOffset;
      public Guid PermanentLineGuid = Guid.Empty;
      public Int32 dwAddressTypes;
      public Guid ProtocolGuid = Guid.Empty;
      public Int32 dwAvailableTracking;
    };

    // lineMakeCall ile yapılan aramalarda, kullanılacak parametreleri veren yapı.
    // Bazen lineOpen fonksiyonuyla da kullanılır.
    [StructLayout(LayoutKind.Sequential)]
    public class LINECALLPARAMS
    {
      public Int32 dwTotalSize = Marshal.SizeOf(typeof(LINECALLPARAMS));
      public Int32 dwBearerMode;
      public Int32 dwMinRate;
      public Int32 dwMaxRate;
      public Int32 dwMediaMode;
      public Int32 dwCallParamFlags;
      public Int32 dwAddressMode;
      public Int32 dwAddressID;
      LINEDIALPARAMS DialParams;
      public Int32 dwOrigAddressSize;
      public Int32 dwOrigAddressOffset;
      public Int32 dwDisplayableAddressSize;
      public Int32 dwDisplayableAddressOffset;
      public Int32 dwCalledPartySize;
      public Int32 dwCalledPartyOffset;
      public Int32 dwCommentSize;
      public Int32 dwCommentOffset;
      public Int32 dwUserUserInfoSize;
      public Int32 dwUserUserInfoOffset;
      public Int32 dwHighLevelCompSize;
      public Int32 dwHighLevelCompOffset;
      public Int32 dwLowLevelCompSize;
      public Int32 dwLowLevelCompOffset;
      public Int32 dwDevSpecificSize;
      public Int32 dwDevSpecificOffset;
      public Int32 dwPredictiveAutoTransferStates;
      public Int32 dwTargetAddressSize;
      public Int32 dwTargetAddressOffset;
      public Int32 dwSendingFlowspecSize;
      public Int32 dwSendingFlowspecOffset;
      public Int32 dwReceivingFlowspecSize;
      public Int32 dwReceivingFlowspecOffset;
      public Int32 dwDeviceClassSize;
      public Int32 dwDeviceClassOffset;
      public Int32 dwDeviceConfigSize;
      public Int32 dwDeviceConfigOffset;
      public Int32 dwCallDataSize;
      public Int32 dwCallDataOffset;
      public Int32 dwNoAnswerTimeout;
      public Int32 dwCallingPartyIDSize;
      public Int32 dwCallingPartyIDOffset;
      public Int32 dwAddressType;
    }

    #endregion

    #region Delegates & Events
    //***************************
    // Temsilciler ve olaylar   *
    //*************************** 

    // lineInitialize TAPI fonksiyonu için geri çağrılır bir gösterici olan
    // LineCallback adlı temsilcimizi tanımlıyoruz.
    // TAPI olayları için ana giriş.
    public delegate void LineCallback(
      // Hat veya çağrı için tutulan değer (handle)
        UInt32 hDevice,
      // Hat veya çağrı mesajı
        UInt32 dwMsg,
      // Uygulamaya geri çevrilen veri örneği 
        UInt32 dwCallbackInstance,
      // Mesaj parametresi
        UInt32 dwParam1,
      // Mesaj parametresi
        UInt32 dwParam2,
      // Mesaj parametresi
        UInt32 dwParam3);

    // CallStatusDialogEvent olayına aracılık edecek delege tanımla.
    public delegate void CallStatusDialogEventHandler();

    // CallStatusDialogEventHandler tipinde olay tanımla.
    public event CallStatusDialogEventHandler CallStatusDialogEvent = null;

    #endregion

    #region TAPI Functions
    //***************************
    // TAPI P/Invoke Metodlar   *
    //***************************

    // Uygulamamız için TAPI kullanımını başlatan (veya sıfırlayan) fonksiyon. 
    // Bulunan hatların sayısını verir.
    // Hat-çağrı durum ve olayları için harekete geçirilecek olan
    // geri çağrılır fonksiyonun adresini tutar.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll", CharSet = CharSet.Auto)]
    public static extern Int32 lineInitializeEx(
      // Uygulamanın, TAPI kullanımına ait handle.
        ref IntPtr lphLineApp,
      // Client uygulamaya (veya DLL) ait instance handle (null değer alabilir).
        IntPtr hInstance,
      // Geri çağrılır fonksiyonumuzun adresi.
        LineCallback lpfnCallback,
      // Uygulama adı.
        string lpszFriendlyAppName,
      // Bulunan hatların sayısı.
        ref UInt32 lpdwNumDevs,
      // TAPI tarafından desteklenen versiyonu verir.
        ref UInt32 lpdwAPIVersion,
      // LINEINITIALIZEEXPARAMS yapısı.
        LINEINITIALIZEEXPARAMS lpLineInitializeExParams);

    // Uygulamanın bir TAPI versiyonu kullanması için anlaşmasına izin verir.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll")]
    public static extern Int32 lineNegotiateAPIVersion(
      // TAPI ait handle.
        IntPtr hLineApp,
      // Hat tanıtıcı nosu
        UInt32 dwDeviceID,
      // Eski veya ilk TAPI versiyonu
        UInt32 dwAPILowVersion,
      // Son TAPI versiyonu
        UInt32 dwAPIHighVersion,
      // Anlaşmaya varılan veya uygun TAPI versiyonu.
        ref UInt32 lpdwAPIVersion,
      //LINEEXTENSIONID yapısı
        LINEEXTENSIONID lpExtensionID);

    // Belirtilen bir hattın kapasitesini sorgulayıp veren fonksiyon
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll", CharSet = CharSet.Auto)]
    public static extern Int32 lineGetDevCaps(
      // TAPI ait handle.
        IntPtr hLineApp,
      // Sorgulanacak hattın tanıtıcı nosu.
        UInt32 dwDeviceID,
      // TAPI versiyonu (lineNegotiateAPIVersion fonksiyonundan sağlanan)
        UInt32 dwAPIVersion,
      // dwExtVersion: Özel kullanım.  Sıfır değeri verilebilir.
        UInt32 dwExtVersion,
      // LINEDEVCAPS yapısı göstericisi
        IntPtr lpLineDevCaps);

    // Hat tanıtıcı nosu verilen bir hattı açar ve ilgili hatta ait bir handle verir.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll", CharSet = CharSet.Auto)]
    public static extern Int32 lineOpen(
      // TAPI ait handle.
        IntPtr hLineApp,
      // Açılacak hattın tanıtıcı nosu.
        UInt32 dwDeviceID,
      // Açılan hatta ait handle
        ref IntPtr hLine,
      // TAPI versiyonu
        UInt32 dwAPIVersion,
      // dwExtVersion: Özel kullanım. Sıfır değeri verilebilir.
        UInt32 dwExtVersion,
      // Geri çağrılır fonksiyon nesnesi (TAPI tarafından yorumlanmaz)
        LineCallback dwCallbackInstance,
      // Uygulamanın çağrıyla ilgili ayrıcalıklarının parametresi
        Enums.LineCallPrivilege dwPrivileges,
      // Çağrı ortamıyla ilgili parametre.
        Enums.LineMediaMode dwMediaModes,
      // LINECALLPARAMS yapısı
        LINECALLPARAMS lpCallParams);

    // Belirtilen hat üzerinden, telefon konuşması yapar. 
    // Fonksiyon çağrısı başarılıysa geriye pozitif bir tanıtıcı,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll", CharSet = CharSet.Auto)]
    public static extern Int32 lineMakeCall(
      // Açık olan hatta ait handle
        IntPtr hLine,
      // Çağrıya ait handle (fonksiyon başarılıysa).
        ref IntPtr lphCall,
      // Telefon numarası
        string lpszDestAddress,
      // Ülke kodu. Sıfır girilirse, varsayılan kullanılır.
        UInt32 dwCountryCode,
      // LINECALLPARAMS yapısı.
      // Boş girilirse, 3.1 kHz sesli arama/çağrı yapılacağı varsayılır.
        LINECALLPARAMS lpCallParams);

    // Belirtilen çağrıyı keser veya hattan düşürür.
    // Fonksiyon çağrısı başarılıysa geriye pozitif bir tanıtıcı,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll")]
    public static extern Int32 lineDrop(
      // Düşürülecek çağrıya ait handle.
        IntPtr hCall,
      // Uzak tarafa (remote) gönderilecek kullanıcı bilgisi (boş bırakılabilir).
        string lpsUserUserInfo,
      // kullanıcı bilgisini uzunluğu - byte (sıfır girilebilir).
        UInt32 dwSize);

    // Çağrıya ait tutulan handle serbest bırakılır.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll")]
    public static extern Int32 lineDeallocateCall(
      // Çağrıya ait bırakılacak handle
        IntPtr hCall);

    // Açık olan hattı kapatır.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll")]
    public static extern Int32 lineClose(
      // Kapatılacak olan hatta ait handle
        IntPtr hLine);

    // Uygulamanın hatla ilgili API'leri kullanmasını sonlandırır.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll")]
    public static extern Int32 lineShutdown(
      // TAPI ait handle.
        IntPtr hLineApp);

    // Çevrilecek telefon numarasına ait konum bilgileri, alan kodu,
    // arama kurallarını v.b. belirlemeğe yarar.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll", CharSet = CharSet.Auto)]
    public static extern Int32 lineTranslateDialog(
      // TAPI ait handle (lineInitializeEx ile dönen değer).
        IntPtr hLineApp,
      // Hattın tanıtıcı nosu.
        UInt32 dwDeviceID,
      // TAPI versiyonu
        UInt32 dwAPIVersion,
      // Diyalogun ana penceresine ait handle (null olabilir).
        IntPtr hwndOwner,
      // Belli bir formdaki telefon numarasu (boş girilebilir).
        string lpszAddressIn);

    // Hatla ilgili parametreleri ayarlamaya izin veren pencereyi getirir.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll", CharSet = CharSet.Auto)]
    public static extern Int32 lineConfigDialog(
      // Hattın tanıtıcı nosu.
        UInt32 dwDeviceID,
      // Diyalogun ana penceresine ait handle.
        IntPtr hwndOwner,
      // Aygıt sınıfı adı (boş girilebilir).
        string lpszDeviceClass);

    // Kontrol paneldeki kayıtlı olan ülke ve şehir kodunu verir.
    // Fonksiyon çağrısı başarılıysa geriye sıfır,
    // başarısız durumda ise bir negatif hata sayısı çevirir.
    [DllImport("Tapi32.dll", CharSet = CharSet.Auto)]
    public static extern Int32 tapiGetLocationInfo(
      // Ülke kodu
        StringBuilder lpszCountryCode,
      // Şehir kodu
        StringBuilder lpszCityCode);

    #endregion

    #region Private Members
    //*************************************
    // TAPIClass sınıfı değişken üyeleri  *
    //*************************************

    // TAPI kullanımına ait handle tipinden değişken,
    // lineInitializeEx fonksiyonundan elde edilecek.
    private IntPtr m_hLineApp = IntPtr.Zero;
    // Uygulamaya ait handle türünden değişken.
    private IntPtr m_hInstance = IntPtr.Zero;
    // lineOpen ile açılan hatta ait handle.
    private IntPtr m_hLine = IntPtr.Zero;
    // Telefonla arama-çağrıya ait handle tipinden değişken.
    private IntPtr m_hCall = IntPtr.Zero;
    // Bulunacak hatların sayısını alacak olan değişken.
    private UInt32 m_iNumLines = 0;
    // lineInitializeEx fonksiyonuna geçirilecek olan TAPI versiyonu değişkeni.
    private UInt32 m_iTAPIVer;
    // lineInitializeEx fonksiyonuna geçirilecek olan uygulama adı değişkeni.
    private string m_sAppName;
    // Ülke kodu değişkeni
    private string m_sCountryCode;
    // Şehir kodu değişkeni
    private string m_sCityCode;
    // LineCallback tipinden, TAPI olayları için delege nesnemizi tanımlıyoruz.
    private LineCallback m_CallBack;
    // List koleksiyonu tipinden değişken.
    private List<LineClass> m_ListLine;
    // m_bIsDisposed: Dispose metodunun çağrılmasını izleyen değişken.
    private bool m_bIsDisposed = false;
    // m_iPlaceCallIdt değişkeniyle lineMakeCall fonksiyonundan geriye dönen değere bakacağız. 
    private Int32 m_iPlaceCallIdt;
    // m_iDropCallIdt değişkeniyle lineDrop fonksiyonundan geriye dönen değere bakacağız.
    private Int32 m_iDropCallIdt;

    #endregion

    #region Properties
    //*********************************
    // TAPIClass sınıfı özellikleri   *
    //*********************************

    // hLineApp özelliği: TAPI kullanımına ait handle değerini verir.
    public IntPtr hLineApp
    {
      get { return m_hLineApp; }
    }

    // hLine özelliği: Hatta (line) ait handle değerini verir.
    public IntPtr hLine
    {
      get { return m_hLine; }
    }

    // Telefonla arama-çağrıya ait handle değerini verir.
    public IntPtr hCall
    {
      get { return m_hCall; }
    }

    // Ülke kodunu verir.
    public string CountryCode
    {
      get { return m_sCountryCode; }
    }

    // Şehir kodunu verir.
    public string CityCode
    {
      get { return m_sCityCode; }
    }

    // List koleksiyonu tipinden değişkene erişildiğinde, hattın (line) sahip
    // olduğu değerlerin alınabilmesini sağlar.
    public List<LineClass> ListLine
    {
      get { return m_ListLine; }
    }

    #endregion

    #region Constructor
    //*********************************
    // TAPIClass sınıfı constructor   *
    //*********************************
    // TAPIClass sınıfı yapıcı metodu.
    // sAppName: Uygulama adı.
    public TAPIClass(string sAppName)
    {
      m_sAppName = sAppName;
      m_iTAPIVer = TAPISuppVer;
      // Uygulamaya ait handle, m_hInstance değişkenine atanıyor.
      m_hInstance = WindowsAPI.GetModuleHandle(null);
      // LineClass tipinde yeni bir koleksiyon yarat.
      m_ListLine = new List<LineClass>();
      // Şimdi LineCallback tipinden delegenin bir örneğini yaratalım.
      // Temsilcimiz LineCallbackEventHandler metoduna işaret etmektedir.
      // Burada geri çağrılır metodumuz kaydediliyor.
      m_CallBack = new LineCallback(LineCallbackEventHandler);

      try
      {
        // LINEINITIALIZEEXPARAMS yapı nesnesi tanımlıyoruz.
        LINEINITIALIZEEXPARAMS initExParams = new LINEINITIALIZEEXPARAMS();
        // Uygulamamız için saklı pencere olay bildirimi mekanizması seçiyoruz.
        initExParams.dwOptions = (int)Enums.LineInitializeExOptions.LINEINITIALIZEEXOPTION_USEHIDDENWINDOW;

        // Uygulamanın TAPI kaynaklarını kullanmasını başlatır ve
        // hazır telefon hatlarının sayısını bulur. 
        Int32 lineErr = lineInitializeEx(ref m_hLineApp,
            m_hInstance,
            m_CallBack,
            m_sAppName,
            ref m_iNumLines,
            ref m_iTAPIVer,
            initExParams);

        // lineInitializeEx çağrısından dönen değeri kontrol et.
        if (lineErr == TAPI_SUCCESS)
        {
          // Bir hat sayısı bulunup bulunmadığını kontrol et.
          if (m_iNumLines > 0)
          {
            // Bulunan hatların bilgilerini doldur.
            InitializeTAPILines();

            // Telefonumuzun kullandığı ülke ve alan kodu bulundu mu?
            if (!GetCurrentLocationInfo())
            {
              //MessageBox.Show("tapiGetLocationInfo fonksiyonu çağrısı başarısız.\n" +
              //    "Ülke ve alan kodu alınamadı.");
            }
          }
          else
          {
            //MessageBox.Show("Bağlı bir telefon hattı bulunamadı.");
          }//if m_iNumLines
        }
        else
        {
          //MessageBox.Show("lineInitializeEx fonksiyonu çağrısı başarısız.");
        }//if lineErr == 0
      }
      catch (Exception ex)
      {
        //MessageBox.Show(ex.Message);
      }
    }//constructor

    #endregion

    #region Public Methods
    //***************************
    // Public Metodlar          *
    //***************************

    // Bir hattın, LineClass özelliklerine erişmek için GetLineByName metodunu kullanıyoruz.
    // sLineName: Hat adı
    // Bu metod, LineClass sınıfından bir nesne çevirir.
    public LineClass GetLineByName(string sLineName)
    {
      // Find metodunun amacı koleksiyondan istediğimiz koşulları sağlayan
      // ilk kümeyi bulmak ve geriye döndürmektir. Burada isimsiz metod kullanılmıştır.
      LineClass myLineClass = ListLine.Find(
        // LineClass sınıfını kullanan adsız temsilciyi parametre
        // olarak geçiriyoruz. Daha sonra, istenilen hat adına eşit olan
        // kümeyi bulup geriye döndüreceğiz.
          delegate(LineClass lineObj)
          {
            return lineObj.LineName.Equals(sLineName);
          });

      return myLineClass;
    }//GetLineByName

    // Metoda giren strFmt parametresi bir string formatı bildirir.
    // Buna göre, switch ile bir decoder nesnesi çevrilir.
    public static Decoder GetDecoder(Enums.StringFormat strFmt)
    {
      Decoder dec = null;

      // get the right decoder
      switch (strFmt)
      {
        case Enums.StringFormat.STRINGFORMAT_ASCII:
          dec = Encoding.ASCII.GetDecoder();
          break;

        case Enums.StringFormat.STRINGFORMAT_UNICODE:
          dec = Encoding.Unicode.GetDecoder();
          break;

        case Enums.StringFormat.STRINGFORMAT_DBCS:
          // CodePage = 1254 - Turkish (Windows)
          dec = Encoding.GetEncoding(1254).GetDecoder();
          break;

        case Enums.StringFormat.STRINGFORMAT_BINARY:
          // Kodlama işlemi veya kod çözümleme dışında özel bir durum.
          dec = null;
          break;
      }//switch

      return dec;
    }//GetDecoder

    // İlk önce bir hat açan ve daha sonra bir telefon araması yapan metodumuz.
    // sLineName:    hat adı
    // sPhoneNumber: telefon numarası
    public bool OpenLineDevice(string sLineName, string sPhoneNumber)
    {
      // Hat açıksa, CloseLine metodu çağrılarak hat kaptılıyor.
      if (CloseLine() == TAPI_SUCCESS)
      {
        // Bir LineClass nesnesi tanımlıyoruz ve
        // hattın sınıf değişkenlerine - özelliklerine erişmek için
        // GetLineByName metodunu çağırıyoruz.
        LineClass lnc = GetLineByName(sLineName);

        // LineClass nesnesi null mu?
        if ((lnc == null))
        {
          return false;
        }

        // LINECALLPARAMS yapı nesnesi tanımlıyoruz.
        LINECALLPARAMS callParams = new LINECALLPARAMS();

        // Hat açmak için lineOpen fonksiyonunu çağırıyoruz.
        // Fonksiyondan dönen değer, iRetVal değişkenine atanır.
        Int32 iRetVal = lineOpen(this.m_hLineApp,
            lnc.LineDevID,
            ref this.m_hLine,
            lnc.TAPIVer,
            0,
            this.m_CallBack,
            Enums.LineCallPrivilege.LINECALLPRIVILEGE_NONE,
            Enums.LineMediaMode.LINEMEDIAMODE_INTERACTIVEVOICE,
            callParams);

        // Fonksiyon çağrısı başarılı mı?
        if (iRetVal == TAPI_SUCCESS)
        {
          // CallStatusDialogEvent nesnesine OnCallStatusDialogEvent metodu adresi atanıyor.
          CallStatusDialogEvent += new
              CallStatusDialogEventHandler(OnCallStatusDialogEvent);

          //frmMain.ShowStatusMsg("Hat açıldı." + "\r\n");

          // sPhoneNumber değişkeni boşsa sadece çevir sesi alınır.
          // Boş değilse, bir telefon numarasını çevirerek arama yapar. 
          iRetVal = lineMakeCall(m_hLine, ref m_hCall, sPhoneNumber, 0, null);

          if (iRetVal > 0)
          {
            // Telefonla arama başlatma başarılı olursa, bu LINE_REPLY olayı ile bildirilir.
            // Geriye dönen pozitif tanıtıcı değer, LineCallbackEventHandler metodu içinde kullanılması için
            // m_iPlaceCallIdt değişkenine atanır.
            this.m_iPlaceCallIdt = iRetVal;

            return true;
          }
          else
          {
            return false;
          }//if
        }
        else
        {
          // lineOpen fonksiyonu çağrısı başarısız.
          //MessageBox.Show("Hat daha önce başka bir uygulama veya servis sağlayıcısı tarafından açılmış.");

          return false;
        }//if lineOpen
      }
      else
      {
        return false;
      }//if
    }//OpenLineDevice

    // DropCall metodu telefonla yapılan aramayı iptal eder.
    public bool DropCall(IntPtr hndCall)
    {
      // Arama-çağrıya ait handle geçerli mi?
      if (hndCall != IntPtr.Zero)
      {
        Thread.Sleep(200);

        // Arama-çağrıya kesmek için lineDrop fonksiyonunu çağırıyoruz.
        Int32 iRetVal = lineDrop(hndCall, String.Empty, 0);

        // lineDrop fonksiyon çağrısından dönen değer pozitif mi?
        if (iRetVal > 0)
        {
          // Fonksiyon aramayı kesme işlemini başarıyla tamamladı.
          this.m_iDropCallIdt = iRetVal;  // bkz. LINE_REPLY kullanılıyor.
          // Arama handle sıfırlanıyor.
          this.m_hCall = IntPtr.Zero;

          return true;
        }
        else
        {
          // Arama-çağrıyı düşürme başarısız oldu.
          return false;
        }//if
      }
      else
      {
        return true;
      }//if
    }//DropCall

    // Burada, bir hattın çevirme özelliklerini belirleyebilirsiniz.
    // Örneğin, alan kodu, şehir ve ülke adı, dış hat alabilmek için numara,
    // uzak aramalar için çevrilecek numara, alan kodu düzenleme v.b. belirleyebilirsiniz.
    public bool DialingPropertiesDialog(string sLineName)
    {
      // Bir LineClass nesnesi oluşturuyoruz ve 
      // içini GetLineByName metoduyla dolduruyoruz.
      LineClass lnc = GetLineByName(sLineName);

      // LineClass nesnesi null mu?
      if (lnc != null)
      {
        // lnc objesinden LineDevID ve TAPIVer özelliklerini parametre
        // olarak alıp, lineTranslateDialog fonksiyonunu çağırıyoruz.
        Int32 iRet = lineTranslateDialog(this.hLineApp,
            lnc.LineDevID,
            lnc.TAPIVer,
            IntPtr.Zero,
            String.Empty);

        // lineTranslateDialog çağrısı başarılıysa, true döndür. 
        if (iRet == TAPI_SUCCESS)
        {
          return true;
        }
      }

      return false;
    }//DialingPropertiesDialog

    // Burada, hizmet sağlayıcısının hat için verdiği ayarları değiştirebilirsiniz.
    // Örneğin, arama tercihleri, veri bağlantı tercihleri,
    // donanım ve uçbirim ayarları v.b. belirleyebilirsiniz.
    public bool LineDeviceConfigDialog(IntPtr hOwner, string sLineName)
    {
      // Bir LineClass nesnesi oluşturuyoruz ve 
      // içini GetLineByName metoduyla dolduruyoruz.
      LineClass lnc = GetLineByName(sLineName);

      // LineClass nesnesi null mu?
      if (lnc != null)
      {
        // lineConfigDialog fonksiyonunu çağırıyoruz.
        Int32 iRet = lineConfigDialog(lnc.LineDevID, hOwner, String.Empty);
        // lineConfigDialog çağrısı başarılıysa, true döndür. 
        if (iRet == TAPI_SUCCESS)
        {
          return true;
        }
      }

      return false;
    }//LineDeviceConfigDialog

    // Kullanıcının daha önce kaydettiği, bulunduğu konumdaki ülke ve şehir kodunu verir.
    // Uygulama telefon numaraları oluştururken, bu bilgi işe yarar.
    public bool GetCurrentLocationInfo()
    {
      // StringBuilder nesnelerini oluştur.
      StringBuilder sbCountryCode = new StringBuilder();
      StringBuilder sbCityCode = new StringBuilder();

      // tapiGetLocationInfo fonksiyonunu çağırıyoruz.
      if (tapiGetLocationInfo(sbCountryCode, sbCityCode) == TAPI_SUCCESS)
      {
        // Ülke kodu m_sCountryCode değişkenine atanıyor.
        this.m_sCountryCode = sbCountryCode.ToString();
        // Şehir kodu m_sCityCode değişkenine atanıyor.
        this.m_sCityCode = sbCityCode.ToString();

        return true;
      }
      else
      {
        return false;
      }
    }//GetCurrentLocationInfo

    // Hatla ilgili ve TAPI kullanımına ait handle'ları boşaltır.
    public Int32 TAPIShutDown()
    {
      // CloseLine metodu çağrılarak hat kapatılıyor.
      if (CloseLine() != TAPI_SUCCESS)
      {
        //MessageBox.Show("Kaynakları serbest bırakmak için hat kapatılmalıdır!");
      }

      // TAPI kullanımına ait handle geçerli mi?
      if (this.m_hLineApp != IntPtr.Zero)
      {
        // lineShutdown metodunu çağrırarak, uygulamanın hatla ilgili
        // API'leri kullanmasını sonlandır.
        return lineShutdown(this.m_hLineApp);
      }
      else
      {
        return TAPI_SUCCESS;
      }
    }//TAPIShutDown

    #endregion

    #region Private Methods
    //***************************
    // Private Metodlar         *
    //***************************

    // InitializeTAPILines metodu hatların uygun TAPI versiyonu bulup,
    // hat bilgilerini ve diğer özelliklerini doldurur.
    private Int32 InitializeTAPILines()
    {
      // Kararlaştırılacak TAPI versiyonu değişkeni.
      UInt32 TAPINegVer = 0x0;
      // LINEEXTENSIONID yapı nesnesi tanımlıyoruz.
      LINEEXTENSIONID lineExtensionID = new LINEEXTENSIONID();

      for (int i = 0; i < this.m_iNumLines; i++)
      {
        // Her bir hat için TAPI versiyonu konusunda anlaşma.
        Int32 iRetVal = lineNegotiateAPIVersion(this.m_hLineApp,
            (uint)i,
            TAPILowVer,
            TAPIHighVer,
            ref TAPINegVer,
            lineExtensionID);

        // Fonksiyondan dönen değer başarılı mı?
        if (iRetVal == TAPI_SUCCESS)
        {
          // Hat bilgisini ve diğer özelliklerini doldur.
          if (!GetLineDeviceCaps((uint)i, TAPINegVer))
          {
            // GetLineDeviceCaps çağrısı başarısız.
            //MessageBox.Show(i.ToString() + " nolu hat:\n" +
            //    "LINEDEVCAPS yapısı geçerli bir hat adına ve değerlerine sahip değil.");
          }//if
        }
        else
        {
          //MessageBox.Show(i.ToString() + " nolu hat:\n" +
          //    "lineNegotiateAPIVersion fonksiyonu çağrısı başarısız.\n" + "Hat mevcut değil veya bulunamadı.");
        }//if iRetVal
      }//for

      return TAPI_SUCCESS;
    }

    // Verilen bir telefon hattının sahip olduğu kapasite ve özelliklerini bulur.
    // Bunun için LINEDEVCAPS yapısı ve lineGetDevCaps fonksiyonunu kullanacağız.
    // devID:    Hat ID
    // iTapiVer: TAPI sürümü
    private bool GetLineDeviceCaps(UInt32 devID, UInt32 iTapiVer)
    {
      Int32 iSize = 0;            // LINEDEVCAPS yapısının ilk uzunluğu
      Int32 iTotalSize = 0;       // Yapının toplam uzunluğu
      Int32 iNeededSize = 0;      // Gereksinim duyulan uzunluk
      Byte[] totalBuffer = null;  // Yapıyı kopyalayacağımız byte dizisi
      bool bUseMemory = true;     // Bellek gereksinimini kontrol edecek

      // LINEDEVCAPS yapı nesnesi tanımlıyoruz.
      // Bu yapı, değişken bir uzunluğa sahiptir.
      LINEDEVCAPS lineDevCaps = new LINEDEVCAPS();

      // Yapının ilk uzunluğunu değişkenlere aynen atıyoruz.
      iSize = Marshal.SizeOf(lineDevCaps);
      iTotalSize = iSize;
      iNeededSize = iSize;

      while (bUseMemory)
      {
        // Gereksinim duyulan uzunluk, verilen toplam uzunluktan büyük mü? 
        if (iNeededSize > iTotalSize)
        {
          // Yapı için tutulacak olan toplam uzunluğu yeniden atıyoruz.
          lineDevCaps.dwTotalSize = iNeededSize;
        }
        else
        {
          // Yapı için tutulacak olan toplam uzunluğa, ilk uzunluğu atıyoruz.
          lineDevCaps.dwTotalSize = iSize;
        }//if

        // Tampon için bellekte, iNeededSize dönen uzunluk değeri kadar yer ayır.
        IntPtr buffer = Marshal.AllocHGlobal(iNeededSize);
        // LINEDEVCAPS yapısındaki değerleri tampona kopyala.
        Marshal.StructureToPtr(lineDevCaps, buffer, true);

        try
        {
          // LINEDEVCAPS yapısına verdiğimiz uzunluğun yeterli olup olmadığına
          // bakmak için, lineGetDevCaps fonksiyonunu çağırıyoruz.
          // Bundan sonra, yapıdaki dwTotalSize, dwNeededSize alanlarını
          // kıyaslama için kontrol edebileceğiz.
          Int32 iRetVal = lineGetDevCaps(this.m_hLineApp,
              (UInt32)devID,
              iTapiVer,
              0,
              buffer);

          // Fonksiyondan dönen değer başarılı mı?
          if (iRetVal == TAPI_SUCCESS)
          {
            // Burada, yönetilmeyen bellek öbeğindeki veriler,
            // yönetimli yapıya marshall ediliyor.
            Marshal.PtrToStructure(buffer, lineDevCaps);
            // Ölçü karşılaştırmasında kullanılacak olan, yapıdaki dwTotalSize
            // ve dwNeededSize alanlarını değişkenlere atıyoruz.
            iTotalSize = (Int32)lineDevCaps.dwTotalSize;
            iNeededSize = (Int32)lineDevCaps.dwNeededSize;

            // Gereksinim duyulan uzunluk, verilen toplam uzunluktan büyükse,
            // tampon için bellekte daha büyük bir yer ayırmak zorundayız.
            // buffer parametresini yeniden lineGetDevCaps fonksiyonuna göndermeliyiz.

            // Döngüdeki bUseMemory şartını yeni duruma göre eşitliyoruz. 
            bUseMemory = (iNeededSize > iTotalSize);

            // Bellekte tampon için daha fazla yer ayrılacak mı? 
            if (!bUseMemory)
            {
              // Yapıyı kopyalayacağımız byte dizisinin uzunluğunu iTotalSize ile geçir.
              totalBuffer = new byte[iTotalSize];
              // Yönetilmeyen bellekte bulunan veri içeriği
              // yönetilen bir dizi içine kopyalanıyor.
              Marshal.Copy(buffer, totalBuffer, 0, iTotalSize);
            }//if
          }
          else
          {
            //MessageBox.Show("lineGetDevCaps fonksiyonu çağrısı başarısız.");

            return false;
          }
        }
        finally
        {
          // AllocHGlobal ile bellekte ayrılan yeri serbest bırak.
          Marshal.FreeHGlobal(buffer);
        }
      }//while

      // LineClass nesne örneğini yarat.
      LineClass myLines = new LineClass(devID, iTapiVer);

      // LineClass içindeki hat alanlarını doldurmak için PutLineProperties metodunu çağır.
      if (myLines.PutLineProperties(lineDevCaps, totalBuffer))
      {
        // Hattın sesli arama özelliğini kontrol et.
        if (myLines.SupportVoiceCall)
          this.m_ListLine.Add(myLines);       // Koleksiyona ekle.
      }
      else
      {
        //MessageBox.Show("Hat özellikleri sınıf üyelerine doldurulurken hata oluştu.");

        return false;
      }//if

      return true;
    }

    // Arama-çağrıya ait handle serbest bırakılır.
    private Int32 DeallocateCall(IntPtr hndCall)
    {
      // Arama-çağrıya ait handle sıfır mı?
      if (hndCall != IntPtr.Zero)
      {
        // handle serbest bırak
        Int32 iRet = lineDeallocateCall(hndCall);

        if (iRet == TAPI_SUCCESS)
        {
          // Aramaya ait handle sıfırlanıyor.
          this.m_hCall = IntPtr.Zero;
        }
        else
        {
          //MessageBox.Show("lineDeallocateCall çağrısı başarısız.");
        }//if iRet

        // Fonksiyondan dönen değeri aynen geri çeviriyoruz.
        return iRet;
      }
      else
      {
        return TAPI_SUCCESS;
      }//if
    }//DeallocateCall

    // CloseLine metodu açık olan hattı kapatır.
    private Int32 CloseLine()
    {
      // Hatta ait handle geçerli mi?
      if (this.m_hLine != IntPtr.Zero)
      {
        Thread.Sleep(250);
        // Hat kapatmak için lineClose fonksiyonunu çağırıyoruz.
        Int32 iRet = lineClose(this.m_hLine);
        // Fonksiyon çağrısı başarısızsa olursa, iRet değeri negatiftir.
        if (iRet == TAPI_SUCCESS)
        {
          // Hatta ait handle sıfırlanıyor.
          this.m_hLine = IntPtr.Zero;
        }
        else
        {
          //MessageBox.Show("Hat kapatılırken hata oluştu.\n" + "lineClose fonksiyonu çağrısı başarısız.");
        }//if iRet

        // Fonksiyondan dönen değeri aynen geri çeviriyoruz.
        return iRet;
      }
      else
      {
        return TAPI_SUCCESS;
      }//if
    }//CloseLine

    #endregion

    #region Event Handling
    //*********************************
    // TAPI olayları ve olay işleme   *
    //*********************************

    // CallStatusDialogEvent olayı tetiklendiğinde çağrılacak metodumuz.
    public void OnCallStatusDialogEvent()
    {
      Thread.Sleep(5);

      // sCallStatusTitle pencere başlığı parametresiyle, pencereyi arayalım
      IntPtr hWnd = WindowsAPI.FindWindow(null, sCallStatusTitle);

      // Eşleşen bir pencere bulunduysa, geriye handle türünden bir değer döner.
      if (!hWnd.Equals(IntPtr.Zero))
      {
        // Eşleşen bir pencere bulundu ve gizlenecek.
        WindowsAPI.ShowWindow(hWnd, WindowsAPI.SW_HIDE);
      }
    }

    // LineCallbackEventHandler metodu, LineCallback temsilci tanımımızdaki ile
    // aynı imzayı taşımaktadır. Bu metod TAPI olaylarını işlemek için
    // temsilcimiz tarafından çağrılmaktadır.
    // hDevice:  Hat veya aramaya ait handle
    // dwMsg:    Hat veya arama mesajı/olayı
    // dwCallbackInstance: Uygulamaya geri çevrilen
    // dwParam1, dwParam2, dwParam3: Mesaj parametreleri
    public void LineCallbackEventHandler(UInt32 hDevice, UInt32 dwMsg,
        UInt32 dwCallbackInstance, UInt32 dwParam1, UInt32 dwParam2, UInt32 dwParam3)
    {
      string sLineMsg = String.Empty;

      switch ((Enums.LineDeviceMessages)(dwMsg))
      {
        case Enums.LineDeviceMessages.LINE_CALLSTATE:
          CallStatusDialogEvent();

          switch ((Enums.LineCallState)(dwParam1))
          {
            case Enums.LineCallState.LINECALLSTATE_IDLE:
              // Aramaya ait handle serbest bırak.
              if (DeallocateCall(this.m_hCall) == TAPI_SUCCESS)
              {
                sLineMsg = "Boşta duruyor";
              }
              break;
            case Enums.LineCallState.LINECALLSTATE_OFFERING:
              sLineMsg = "Gelen arama";
              break;

            case Enums.LineCallState.LINECALLSTATE_ACCEPTED:
              sLineMsg = "Arama kabul edildi";
              break;

            case Enums.LineCallState.LINECALLSTATE_DIALTONE:
              sLineMsg = "Çevir sesi";
              break;

            case Enums.LineCallState.LINECALLSTATE_DIALING:
              sLineMsg = "Numara çevriliyor";
              break;

            case Enums.LineCallState.LINECALLSTATE_BUSY:
              // Aramaya ait handle serbest bırak.
              if (DeallocateCall(this.m_hCall) == TAPI_SUCCESS)
              {
                sLineMsg = "Meşgul tonu";
              }
              break;

            case Enums.LineCallState.LINECALLSTATE_CONNECTED:
              sLineMsg = "Bağlantı kuruldu";
              break;

            case Enums.LineCallState.LINECALLSTATE_PROCEEDING:
              sLineMsg = "Telefon ağında ilerleme";
              //arama devamı
              break;

            case Enums.LineCallState.LINECALLSTATE_RINGBACK:
              sLineMsg = "Karşı tarafta zil çaldırılıyor";
              break;

            case Enums.LineCallState.LINECALLSTATE_DISCONNECTED:
              sLineMsg = "Arama kesildi";
              break;

            case Enums.LineCallState.LINECALLSTATE_UNKNOWN:
              sLineMsg = "Durumu bilinmiyor";
              break;
          }//swicth dwParam1
          break;

        // Hat zorla kapatıldığında veya hardware error vb. koşullar.
        case Enums.LineDeviceMessages.LINE_CLOSE:
          this.m_hLine = (IntPtr)hDevice;
          // Hatta ait handle sıfırlanıyor.
          this.m_hLine = IntPtr.Zero;
          sLineMsg = "Hat zorla kapatıldı";
          break;

        case Enums.LineDeviceMessages.LINE_LINEDEVSTATE:
          this.m_hLine = (IntPtr)hDevice;
          sLineMsg = "Çalıyor";
          break;

        case Enums.LineDeviceMessages.LINE_REPLY:
          if (dwParam1 == this.m_iPlaceCallIdt)
          {
            this.m_iPlaceCallIdt = 0;

            if (dwParam2 == TAPI_SUCCESS)
            {
              sLineMsg = "Arama isteği başarılı...";
            }
          }

          else if (dwParam1 == this.m_iDropCallIdt)
          {
            this.m_iDropCallIdt = 0;

            if (dwParam2 == TAPI_SUCCESS)
            {
              sLineMsg = "Hat bağlantısı kesildi...";
            }
          }
          else
          {
            sLineMsg = "LINE_REPLY hatası. Error No: " + dwParam2.ToString();
          }

          break;

        //case Enums.LineDeviceMessages.LINE_APPNEWCALL:
        //    this.m_hLine = (IntPtr)hDevice;
        //    this.m_hCall = (IntPtr)dwParam2;
        //    sLineMsg = "LINE_APPNEWCALL";
        //    break;

        case Enums.LineDeviceMessages.LINE_CALLINFO:
          this.m_hCall = (IntPtr)hDevice;
          sLineMsg = "Line_callinfo";
          break;

        default:
          sLineMsg = "LineCallbackEventHandler mesajı iptal edildi.\r\n";
          break;
      }//switch dwMsg

      //frmMain.ShowStatusMsg(sLineMsg + "\r\n");
    }

    #endregion

    #region IDisposable Members
    //*********************************
    // IDisposable                    *
    //*********************************

    public void Dispose()
    {
      // Aşırı yüklediğimiz Dispose metodunu çağır.
      this.Dispose(true);
    }

    // Dispose metodunu aşırı yüklüyoruz.
    protected virtual void Dispose(bool disposing)
    {
      // Dispose metodunun daha önce çağrılıp çağrılmadığını kontrol et?
      if (!this.m_bIsDisposed)
      {
        if (this.m_hLineApp != IntPtr.Zero)
        {
          // API kullanımını kapatmak için TAPIShutDown metodumuzu çağırıyoruz.
          this.TAPIShutDown();
          // TAPI handle sıfırlanıyor.
          this.m_hLineApp = IntPtr.Zero;
        }
        // disposing = true ise yönetimli serbest bırak.
        if (disposing)
        {
          // Nesneye ait sonlandırma kuyruğundaki kaynakları serbest bırakıyoruz. 
          GC.SuppressFinalize(this);
        }//if
      }//if
      // = true Dispose metodu çağrılmış durumda.
      m_bIsDisposed = true;
    }

    #endregion

    #region Destructor
    //*********************************
    // Destructor                     *
    //*********************************

    // TAPIClass sınıfı yıkıcı (destructor) metodu:
    // Dispose metodu çağrılmazsa devreye girer.
    ~TAPIClass()
    {
      // Aşırı yüklediğimiz virtual Dispose metodumuzu çağırarak,
      // yönetimsiz kaynakları yok edelim.
      Dispose(false);
    }

    #endregion
  }//TAPIClass
}