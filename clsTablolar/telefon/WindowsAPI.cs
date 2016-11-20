using System;
using System.Runtime.InteropServices;

namespace TapiInCS
{
  // Programınızın windowstaki handle değerini döndüren ve
  // pencere özellikleriyle ilgili bazı Win32 API fonksiyonlarını kullanan sınıfımız.
  // Daha fazla bilgi için: bkz. Platform SDK
  public class WindowsAPI
  {
    // SW_HIDE sabiti pencerenin saklanacağını bildirir. Bkz. winuser.h
    public const Int32 SW_HIDE = 0;

    #region API Functions

    // Kendi programınızın windows'taki tanıtıcı değerini alan (handle) fonksiyon.
    // Fonksiyon çağrısı başarılıysa geriye modüle ait bir handle,
    // başarısız durumda ise null değer çevirir.
    [DllImport("kernel32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(
      // Exe vey DLL dosyasının adı veya null değer. 
        string lpModuleName);

    // Sınıf ismi ve adı verilen pencereyi bulan fonksiyon.
    // Fonksiyon çağrısı başarılıysa geriye pencereye ait bir handle,
    // başarısız durumda ise null değer çevirir.
    [DllImport("user32.DLL", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr FindWindow(
      // Pencere sınıfının adı
        string lpClassName,
      // Pencere başlığı
        string lpWindowName);

    // Pencerenin nasıl görüntüleneceğini belirten fonksiyon.
    [DllImport("user32", CharSet = CharSet.Auto)]
    public static extern Int32 ShowWindow(
      // Pencerinin tanıtıcısı (windows'taki değeri veya handle)
        IntPtr hWnd,
      // Pencerenin nasıl görüntüleceğini bildiren sabit
        Int32 nCmdShow);

    #endregion
  }
}