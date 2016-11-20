using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AresUrunTanitim
{
  public class SqlConnections : IDisposable
  {
    #region IDisposable Members

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    #endregion

    private static SqlConnection BaglantiAres;
    private static SqlConnection BaglantiAresUT;

    private static string _AresServer;
    public static string _AresDB;
    private static string _AresKullanici;
    private static string _AresSifre;
    private static string _AresUTServer;
    public static string _AresUTDB;
    private static string _AresUTKullanici;
    private static string _AresUTSifre;
    private static string _ConStrAres;
    private static string _ConStrAresUT;
    public static bool _IsXmlRead;

    public SqlConnections()
    {
      _AresServer = "";
      _AresDB = "";
      _AresKullanici = "";
      _AresSifre = "";
      _AresUTServer = "";
      _AresUTDB = "";
      _AresUTKullanici = "";
      _AresUTSifre = "";
      _ConStrAres = "";
      _ConStrAresUT = "";
      _IsXmlRead = false;
      if (!_IsXmlRead)
      {
        XmlOku();
        _ConStrAres = GetAresConnStr();
        _ConStrAresUT = GetAresUTConnStr(); 
      }
    }

    public void Update()
    {
      XmlOku();
      BaglantiAres = null;
      BaglantiAresUT = null;
      _ConStrAres = GetAresConnStr();
      _ConStrAresUT = GetAresUTConnStr();
    }

    public static SqlConnection GetAresSqlConnection()
    {
      if (BaglantiAres == null)
      {
        BaglantiAres = new SqlConnection(_ConStrAres);
        if (BaglantiAres.State == System.Data.ConnectionState.Closed)
          BaglantiAres.Open();
      }
      return BaglantiAres;
    }

    public static SqlConnection GetAresUTSqlConnection()
    {
      if (BaglantiAresUT == null)
      {
        BaglantiAresUT = new SqlConnection(_ConStrAresUT);
        if (BaglantiAresUT.State == System.Data.ConnectionState.Closed)
          BaglantiAresUT.Open();
      }
      return BaglantiAresUT;
    }

    private string GetAresConnStr()
    {
      System.Data.SqlClient.SqlConnectionStringBuilder ConnBuilderAres = new System.Data.SqlClient.SqlConnectionStringBuilder();

      ConnBuilderAres.DataSource = _AresServer;
      ConnBuilderAres.InitialCatalog = _AresDB;
      if (_AresKullanici == "" && _AresSifre == "")
      {
        ConnBuilderAres.IntegratedSecurity = true;
      }
      else if (_AresKullanici != "" && _AresSifre != "")
      {
        ConnBuilderAres.UserID = _AresKullanici;
        ConnBuilderAres.Password = _AresSifre;
        //ConnBuilderAres.PersistSecurityInfo = true;
      }
      else if (_AresKullanici != "" && _AresSifre == "")
      {
        ConnBuilderAres.UserID = _AresKullanici;
      }
     
      return ConnBuilderAres.ConnectionString;
    }

    private string GetAresUTConnStr()
    {
      System.Data.SqlClient.SqlConnectionStringBuilder ConnBuilderAresUT = new System.Data.SqlClient.SqlConnectionStringBuilder();

      ConnBuilderAresUT.DataSource = _AresUTServer;
      ConnBuilderAresUT.InitialCatalog = _AresUTDB;
      if (_AresUTKullanici == "" && _AresUTSifre == "")
      {
        ConnBuilderAresUT.IntegratedSecurity = true;
      }
      else if (_AresUTKullanici != "" && _AresUTSifre != "")
      {
        ConnBuilderAresUT.UserID = _AresUTKullanici;
        ConnBuilderAresUT.Password = _AresUTSifre;
        ConnBuilderAresUT.PersistSecurityInfo = true;
      }
      else if (_AresUTKullanici != "" && _AresUTSifre == "")
      {
        ConnBuilderAresUT.UserID = _AresUTKullanici;
      }
      return ConnBuilderAresUT.ConnectionString;
    }

    private void XmlOku()
    {
      string strPath = Application.StartupPath + @"\AresUrunTanitim.exe.config";
      char tirnak = '"';
      if (File.Exists(strPath))
      {
        FileStream fsConfigFile = new FileStream(strPath, FileMode.Open, FileAccess.Read);
        XmlDocument xdConfigFile = new XmlDocument();
        xdConfigFile.Load(fsConfigFile);
        string strInnerXml = xdConfigFile.DocumentElement.ChildNodes.Item(1).InnerXml;
        string[] arItems = strInnerXml.Split(new string[] { "/>" }, StringSplitOptions.RemoveEmptyEntries);
        string strAresUTCon = "";
        string strAresCon = "";
        if (arItems[0].Contains("AresUrunTanitim.Properties.Settings.DBConStrAres"))
        {
          strAresCon = arItems[0];
          strAresUTCon = arItems[1];
        }
        else if (arItems[0].Contains("AresUrunTanitim.Properties.Settings.DBConStrAresUT"))
        {
          strAresCon = arItems[1];
          strAresUTCon = arItems[0];
        }

        string[] arDBConStrAres = strAresCon.Split(new char[] { tirnak }, StringSplitOptions.RemoveEmptyEntries);
        string[] arDegerlerAres = arDBConStrAres[3].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < arDegerlerAres.Length; i++)
        {
          if (arDegerlerAres[i].Contains("Data Source"))
            _AresServer = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
          else if (arDegerlerAres[i].Contains("Initial Catalog"))
            _AresDB = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
          else if (arDegerlerAres[i].Contains("User ID"))
            _AresKullanici = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
          else if (arDegerlerAres[i].Contains("Password"))
            _AresSifre = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
        }

        string[] arDBConStrAresUT = strAresUTCon.Split(new char[] { tirnak }, StringSplitOptions.RemoveEmptyEntries);
        string[] arDegerlerAresUT = arDBConStrAresUT[3].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < arDegerlerAresUT.Length; i++)
        {
          if (arDegerlerAresUT[i].Contains("Data Source"))
            _AresUTServer = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
          else if (arDegerlerAresUT[i].Contains("Initial Catalog"))
            _AresUTDB = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
          else if (arDegerlerAresUT[i].Contains("User ID"))
            _AresUTKullanici = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
          else if (arDegerlerAresUT[i].Contains("Password"))
            _AresUTSifre = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
        }

        _IsXmlRead = true;
        fsConfigFile.Close();
        fsConfigFile.Dispose();
      }
    }
  }
}
