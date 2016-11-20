using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
  public class csCari : IDisposable
  {
    private int _CariID;
    private bool _Aktif;
    private string _CariKod;
    private string _CariTanim;
    private string _OzelKod1;
    private string _OzelKod2;
    private string _OzelKod3;
    private string _VergiDairesi;
    private string _VergiNumarasi;
    private int _SektorID;
    private int _AltSektorID;
    private int _CariGrupID;
    private int _CariAltGrupID;
    private string _WebSayfasi;
    private string _Aciklama;
    private bool _SilindiMi;
    private int _KaydedenID;
    private DateTime _KayitTarihi;
    private int _DegistirenID;
    private DateTime _DegismeTarihi;
    private decimal _iskOrani1;
    private decimal _iskOrani2;
    private decimal _iskOrani3;
    private int _CariFiyatTanimID;

    public int CariID
    {
      get { return _CariID; }
      set { _CariID = value; }
    }
    public bool Aktif
    {
      get { return _Aktif; }
      set { _Aktif = value; }
    }
    public string CariKod
    {
      get { return _CariKod; }
      set { _CariKod = value; }
    }
    public string CariTanim
    {
      get { return _CariTanim; }
      set { _CariTanim = value; }
    }
    public string OzelKod1
    {
      get { return _OzelKod1; }
      set { _OzelKod1 = value; }
    }
    public string OzelKod2
    {
      get { return _OzelKod2; }
      set { _OzelKod2 = value; }
    }
    public string OzelKod3
    {
      get { return _OzelKod3; }
      set { _OzelKod3 = value; }
    }
    public string VergiDairesi
    {
      get { return _VergiDairesi; }
      set { _VergiDairesi = value; }
    }
    public string VergiNumarasi
    {
      get { return _VergiNumarasi; }
      set { _VergiNumarasi = value; }
    }
    public int SektorID
    {
      get { return _SektorID; }
      set { _SektorID = value; }
    }
    public int AltSektorID
    {
      get { return _AltSektorID; }
      set { _AltSektorID = value; }
    }
    public int CariGrupID
    {
      get { return _CariGrupID; }
      set { _CariGrupID = value; }
    }
    public int CariAltGrupID
    {
      get { return _CariAltGrupID; }
      set { _CariAltGrupID = value; }
    }
    public string WebSayfasi
    {
      get { return _WebSayfasi; }
      set { _WebSayfasi = value; }
    }
    public string Aciklama
    {
      get { return _Aciklama; }
      set { _Aciklama = value; }
    }
    public bool SilindiMi
    {
      get { return _SilindiMi; }
      set { _SilindiMi = value; }
    }
    public int KaydedenID
    {
      get { return _KaydedenID; }
      set { _KaydedenID = value; }
    }
    public DateTime KayitTarihi
    {
      get { return _KayitTarihi; }
      set { _KayitTarihi = value; }
    }
    public int DegistirenID
    {
      get { return _DegistirenID; }
      set { _DegistirenID = value; }
    }
    public DateTime DegismeTarihi
    {
      get { return _DegismeTarihi; }
      set { _DegismeTarihi = value; }
    }
    public decimal IskOrani1
    {
      get { return _iskOrani1; }
      set { _iskOrani1 = value; }
    }
    public decimal IskOrani2
    {
      get { return _iskOrani2; }
      set { _iskOrani2 = value; }
    }
    public decimal IskOrani3
    {
      get { return _iskOrani3; }
      set { _iskOrani3 = value; }
    }
    public int CariFiyatTanimID
    {
      get { return _CariFiyatTanimID; }
      set { _CariFiyatTanimID = value; }
    }

    #region Genel DeğişkEnler
    SqlCommand cmdGenel;
    SqlDataReader drGenel;
    #endregion

    public csCari(SqlConnection Baglanti, SqlTransaction Tr, int CariID)
    {
      if (CariID == -1)
      {
        _Aktif = true;
        _CariID = -1;
        _CariKod = "";
        _CariTanim = "";
        _OzelKod1 = "";
        _OzelKod2 = "";
        _OzelKod3 = "";
        _VergiDairesi = "";
        _VergiNumarasi = "";
        _SektorID = -1;
        _AltSektorID = -1;
        _CariGrupID = -1;
          _CariAltGrupID = -1;
        _WebSayfasi = "";
        _Aciklama = "";
        _SilindiMi = false;
        _KaydedenID = -1;
        _KayitTarihi = DateTime.Now;
        _DegistirenID = -1;
        _DegismeTarihi = DateTime.MinValue;
        _iskOrani1 = 0;
        _iskOrani1 = 0;
        _iskOrani1 = 0;

        _CariFiyatTanimID = -1;
      }
      else
      {
        
        CariGetir(Baglanti, Tr, CariID);
      }
    }
    private string IDBossaEksiBirVer(object ID)
    {
      string ID2 = "";
      if (ID == null || ID.ToString() == "" || ID == DBNull.Value)
      {
        ID2 = "-1";
      }
      else
      {
        ID2 = ID.ToString();
      }
      return ID2;
    }
    private DateTime TarihBossaMinTarihVer(Object Tarih)
    {
      DateTime Tarihh;
      if (DateTime.TryParse(Tarih.ToString(), out Tarihh) == false)
        Tarihh = DateTime.MinValue;

      return Tarihh;
    }
    private void CariGetir(SqlConnection Baglanti, SqlTransaction Tr, int CariID)
    {
      using (cmdGenel = new SqlCommand())
      {
        cmdGenel.Connection = Baglanti;
        cmdGenel.Transaction = Tr;
        cmdGenel.CommandText = @"SELECT CariID, Aktif, CariKod, CariTanim, OzelKod1, OzelKod2, OzelKod3, VergiDairesi, VergiNumarasi, SektorID, AltSektorID, CariGrupID,CariAltGrupID, WebSayfasi, Aciklama, SilindiMi, KaydedenID, KayitTarihi, DegistirenID, DegismeTarihi, iskOrani1, iskOrani2, iskOrani3, CariFiyatTanimID
FROM         dbo.Cari
WHERE     (CariID = @CariID)";
        cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
        using (drGenel = cmdGenel.ExecuteReader())
        {
          drGenel.Read();

          //int eksibir = 0; // burası ne mikim di ?

          _CariID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["CariID"]));
          _CariKod = drGenel["CariKod"].ToString();
          _CariTanim = drGenel["CariTanim"].ToString();
          _OzelKod1 = drGenel["OzelKod1"].ToString();
          _OzelKod2 = drGenel["OzelKod2"].ToString();
          _OzelKod3 = drGenel["OzelKod3"].ToString();
          _VergiDairesi = drGenel["VergiDairesi"].ToString();
          _VergiNumarasi = drGenel["VergiNumarasi"].ToString();
          _SektorID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["SektorID"]));
          _AltSektorID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["AltSektorID"]));
          _CariGrupID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["CariGrupID"]));
          _CariAltGrupID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["CariAltGrupID"]));

          _WebSayfasi = drGenel["WebSayfasi"].ToString();
          _Aciklama = drGenel["Aciklama"].ToString();
          _KaydedenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["KaydedenID"]));
          _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
          _DegistirenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["DegistirenID"]));
          _DegismeTarihi = TarihBossaMinTarihVer(drGenel["DegismeTarihi"]);
          _iskOrani1 = Convert.ToDecimal(drGenel["iskOrani1"]);
          _iskOrani2 = Convert.ToDecimal(drGenel["iskOrani2"]);
          _iskOrani3 = Convert.ToDecimal(drGenel["iskOrani3"]);
          _CariFiyatTanimID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["CariFiyatTanimID"]));


          // burası nasıl çalışıyor amk???
          if (Convert.ToBoolean(drGenel["SilindiMi"].ToString()))
            _SilindiMi = true;
          else
            _SilindiMi = false;

          if (Convert.ToBoolean(drGenel["Aktif"].ToString()))
            _Aktif = true;
          else
            _Aktif = false;
        }
      }
    }
    public string CariInsert(SqlConnection Baglanti, SqlTransaction Tr)
    {
      cmdGenel = new SqlCommand();
      cmdGenel.Connection = Baglanti;
      cmdGenel.CommandType = CommandType.Text;
      cmdGenel.Transaction = Tr;
      cmdGenel.CommandText = @"insert into Cari 
(Aktif, CariKod, CariTanim, OzelKod1, OzelKod2, OzelKod3, VergiDairesi, VergiNumarasi, SektorID, AltSektorID, CariGrupID, CariAltGrupID, WebSayfasi, Aciklama, SilindiMi, KaydedenID, KayitTarihi, CariFiyatTanimID)
values 
(@Aktif, @CariKod, @CariTanim, @OzelKod1, @OzelKod2, @OzelKod3, @VergiDairesi, @VergiNumarasi, @SektorID, @AltSektorID, @CariGrupID, @CariAltGrupID,@WebSayfasi, @Aciklama, @SilindiMi,@KaydedenID, @KayitTarihi, @CariFiyatTanimID)
set @YeniID = SCOPE_IDENTITY()";
      cmdGenel.Parameters.Add("@Aktif", SqlDbType.Bit).Value = _Aktif;
      cmdGenel.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKod;
      cmdGenel.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanim;
      cmdGenel.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
      cmdGenel.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
      cmdGenel.Parameters.Add("@OzelKod3", SqlDbType.NVarChar).Value = _OzelKod3;
      cmdGenel.Parameters.Add("@VergiDairesi", SqlDbType.NVarChar).Value = _VergiDairesi;
      cmdGenel.Parameters.Add("@VergiNumarasi", SqlDbType.NVarChar).Value = _VergiNumarasi;
      cmdGenel.Parameters.Add("@SektorID", SqlDbType.Int).Value = _SektorID;
      cmdGenel.Parameters.Add("@AltSektorID", SqlDbType.Int).Value = _AltSektorID;
      cmdGenel.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = _CariGrupID;
      cmdGenel.Parameters.Add("@CariAltGrupID", SqlDbType.Int).Value = _CariAltGrupID;
      cmdGenel.Parameters.Add("@WebSayfasi", SqlDbType.NVarChar).Value = _WebSayfasi;
      cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
      cmdGenel.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;
      cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;

      cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
      cmdGenel.Parameters.Add("@CariFiyatTanimID", SqlDbType.Int).Value = _CariFiyatTanimID;
      cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
      try
      {
        cmdGenel.ExecuteNonQuery();
        _CariID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
      }
      catch (Exception e)
      {
        if (e is SqlException && ((SqlException)e).Number == 2601)  //Aynı kayıttan var hatasıymışşşşşşşş
          return ((SqlException)e).Number.ToString();
        else
          return e.Message;
      }
      finally
      {
        cmdGenel.Dispose();
      }
      return "OK ," + _CariID.ToString();
    }
    public string CariUpdate(SqlConnection Baglanti, SqlTransaction Tr, string _CariID)
    {
      cmdGenel = new SqlCommand();
      cmdGenel.Connection = Baglanti;
      cmdGenel.CommandText = @"Update Cari set Aktif=@Aktif, CariKod=@CariKod, CariTanim=@CariTanim, OzelKod1=@OzelKod1, OzelKod2=@OzelKod2, OzelKod3=@OzelKod3, VergiDairesi=@VergiDairesi, VergiNumarasi=@VergiNumarasi, SektorID=@SektorID, 
AltSektorID=@AltSektorID, CariGrupID=@CariGrupID, CariAltGrupID=@CariAltGrupID, WebSayfasi=@WebSayfasi, Aciklama=@Aciklama, SilindiMi = @SilindiMi,  DegistirenID = @DegistirenID, DegismeTarihi = @DegismeTarihi, CariFiyatTanimID = @CariFiyatTanimID   
where CariID = @CariID";

      cmdGenel.Parameters.Add("@Aktif", SqlDbType.Bit).Value = _Aktif;
      cmdGenel.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKod;
      cmdGenel.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanim;
      cmdGenel.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
      cmdGenel.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
      cmdGenel.Parameters.Add("@OzelKod3", SqlDbType.NVarChar).Value = _OzelKod3;
      cmdGenel.Parameters.Add("@VergiDairesi", SqlDbType.NVarChar).Value = _VergiDairesi;
      cmdGenel.Parameters.Add("@VergiNumarasi", SqlDbType.NVarChar).Value = _VergiNumarasi;
      cmdGenel.Parameters.Add("@SektorID", SqlDbType.Int).Value = _SektorID;
      cmdGenel.Parameters.Add("@AltSektorID", SqlDbType.Int).Value = _AltSektorID;
      cmdGenel.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = _CariGrupID;
      cmdGenel.Parameters.Add("@CariAltGrupID", SqlDbType.Int).Value = _CariAltGrupID;
      cmdGenel.Parameters.Add("@WebSayfasi", SqlDbType.NVarChar).Value = _WebSayfasi;
      cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
      cmdGenel.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;
      cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
      cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
      cmdGenel.Parameters.Add("@CariFiyatTanimID", SqlDbType.Int).Value = _CariFiyatTanimID;
      cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;

      try
      {
        cmdGenel.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        if (e is SqlException && ((SqlException)e).Number == 2601)
          return ((SqlException)e).Number.ToString();
        else
          return e.Message;
      }
      finally
      {
        cmdGenel.Dispose();
      }
      return "OK ," + _CariID.ToString();
    }
    public string CariDelete(SqlConnection Baglanti, SqlTransaction Tr)
    {
      cmdGenel = new SqlCommand();
      cmdGenel.Connection = Baglanti;
      cmdGenel.Transaction = Tr;
      cmdGenel.CommandText = @"Update Cari Set SilindiMi = 1 where CariID = @CariID";
      cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;
      try
      {
        cmdGenel.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        return e.Message;
      }
      finally
      {
        cmdGenel.Dispose();
      }
      return "Silindi";
    }
    public static DataTable CariListe(SqlConnection Baglanti, SqlTransaction tr, string _CariID, string _Aktif, string _CariTipID, string _CariKod, string _CariTanim, string _OzelKod1, string _OzelKod2, string _OzelKod3, string _VergiDairesi, string _VergiNumarasi, string _SektorID, string _AltSektorID, string _UlkeID, string _SehirID, string _WebSayfasi, string _Aciklama, string _KaydedenID, DateTime _KayitTarihi1, DateTime _KayitTarihi2, string _DegistirenID, DateTime _DegismeTarihi1, DateTime _DegismeTarihi2, bool SilindiMi)
    {
      /*
       * Cariye ait tanımlı adres varsa veya hiç adresi olmayan carileride görmek için sql e Adres ve where cümlelerini ekledik.
       * sql den CariTip tablolarını ve alanları silindi.
       */
      string WhereCumlesi = @"
SELECT   distinct  C.CariID, C.Aktif, C.CariKod, C.CariTanim, C.OzelKod1, C.OzelKod2, C.OzelKod3, C.VergiDairesi, C.SektorID, CS.CariSektor, C.AltSektorID, CAS.CariAltSektor, 
                      C.WebSayfasi, C.Aciklama, C.KaydedenID, C.KayitTarihi, C.DegistirenID, C.DegismeTarihi,
                      C.iskOrani2, C.iskOrani3, C.iskOrani1, C.VergiNumarasi, C.CariFiyatTanimID, CAS.CariAltSektorID
FROM         dbo.Cari AS C LEFT OUTER JOIN
                      dbo.Ulke RIGHT OUTER JOIN
                      dbo.Adres ON dbo.Ulke.UlkeID = dbo.Adres.UlkeID LEFT OUTER JOIN
                      dbo.Sehir AS Sehir_1 ON dbo.Adres.SehirID = Sehir_1.SehirID LEFT OUTER JOIN
                      dbo.Ilce ON dbo.Adres.IlceID = dbo.Ilce.IlceID ON C.CariID = dbo.Adres.CariID LEFT OUTER JOIN
                      dbo.CariAltSektor AS CAS ON C.AltSektorID = CAS.CariAltSektorID LEFT OUTER JOIN
                      dbo.CariSektor AS CS ON C.SektorID = CS.CariSektorID
WHERE     (dbo.Adres.Varsayilan = 1) OR
                      (dbo.Adres.Varsayilan IS NULL)
";

      SqlDataAdapter da = new SqlDataAdapter();
      da.SelectCommand = new SqlCommand();

      if (_CariID != "")
      {
        WhereCumlesi += " AND CariID=@CariID ";
        da.SelectCommand.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
      }

      // buraya bi açıklama yazısı lazım 3 çeşit değer geliyordu 3 olunca bu aramayı yapmıyordu
      if (_Aktif == "0")//aktif
        WhereCumlesi += " AND  Aktif = 1";
      else if (_Aktif == "1") // Pasif
        WhereCumlesi += " AND Aktif = 0 ";

      if (_CariKod != "")
      {
        WhereCumlesi += "  AND CariKod=@CariKod ";
        da.SelectCommand.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKod;
      }
      if (_CariTanim != "")
      {
        WhereCumlesi += "  AND CariTanim=@CariTanim ";
        da.SelectCommand.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanim;
      }

      if (_OzelKod1 != "")
      {
        WhereCumlesi += "  AND OzelKod1=@OzelKod1 ";
        da.SelectCommand.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
      }
      if (_OzelKod2 != "")
      {
        WhereCumlesi += "  AND OzelKod2=@OzelKod2 ";
        da.SelectCommand.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
      }

      if (_OzelKod3 != "")
      {
        WhereCumlesi += "  AND OzelKod3=@OzelKod3 ";
        da.SelectCommand.Parameters.Add("@OzelKod3", SqlDbType.NVarChar).Value = _OzelKod3;
      }

      if (_VergiDairesi != "")
      {
        WhereCumlesi += "  AND VergiDairesi=@VergiDairesi ";
        da.SelectCommand.Parameters.Add("@VergiDairesi", SqlDbType.NVarChar).Value = _VergiDairesi;
      }

      if (_VergiNumarasi != "")
      {
        WhereCumlesi += "  AND VergiNumarasi=@VergiNumarasi ";
        da.SelectCommand.Parameters.Add("@VergiNumarasi", SqlDbType.NVarChar).Value = _VergiNumarasi;
      }

      if (_SektorID != "")
      {
        WhereCumlesi += "  AND SektorID=@SektorID ";
        da.SelectCommand.Parameters.Add("@SektorID", SqlDbType.Int).Value = _SektorID;
      }

      if (_AltSektorID != "")
      {
        WhereCumlesi += "  AND AltSektorID=@AltSektorID ";
        da.SelectCommand.Parameters.Add("@AltSektorID", SqlDbType.Int).Value = _AltSektorID;
      }

      if (_UlkeID != "")
      {
        WhereCumlesi += "  AND UlkeID=@UlkeID ";
        da.SelectCommand.Parameters.Add("@UlkeID", SqlDbType.Int).Value = _UlkeID;
      }

      if (_SehirID != "")
      {
        WhereCumlesi += "  AND SehirID=@SehirID ";
        da.SelectCommand.Parameters.Add("@SehirID", SqlDbType.Int).Value = _SehirID;
      }

      if (_WebSayfasi != "")
      {
        WhereCumlesi += "  AND WebSayfasi=@WebSayfasi ";
        da.SelectCommand.Parameters.Add("@WebSayfasi", SqlDbType.NVarChar).Value = _WebSayfasi;
      }

      if (_Aciklama != "")
      {
        WhereCumlesi += "  AND Aciklama=@Aciklama ";
        da.SelectCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
      }

      if (_KaydedenID != "")
      {
        WhereCumlesi += "  AND KaydedenID=@KaydedenID ";
        da.SelectCommand.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
      }

      if (_DegistirenID != "")
      {
        WhereCumlesi += "  AND DegistirenID=@DegistirenID ";
        da.SelectCommand.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
      }

      //WhereCumlesi += "  AND Convert(Datetime,KayitTarihi,104) between Convert(Datetime,@KayitTarihi1,104) and Convert(Datetime, @KayitTarihi2,104)";

      //WhereCumlesi += "  AND (Convert(Datetime,DegismeTarihi,104) between Convert(Datetime,@DegismeTarihi1,104) and Convert(Datetime,@DegismeTarihi2,104) or DegismeTarihi is NULL)";

      WhereCumlesi += "AND SilindiMi = @SilindiMi";
      da.SelectCommand.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = SilindiMi;


      //da.SelectCommand.Parameters.Add("@KayitTarihi1", SqlDbType.DateTime).Value = _KayitTarihi1;
      //da.SelectCommand.Parameters.Add("@KayitTarihi2", SqlDbType.DateTime).Value = _KayitTarihi2;

      //da.SelectCommand.Parameters.Add("@DegismeTarihi1", SqlDbType.DateTime).Value = _DegismeTarihi1;
      //da.SelectCommand.Parameters.Add("@DegismeTarihi2", SqlDbType.DateTime).Value = _DegismeTarihi2;


      da.SelectCommand.CommandText = WhereCumlesi;
      da.SelectCommand.Connection = Baglanti;
      da.SelectCommand.Transaction = tr;

      DataTable dt = new DataTable();
      da.Fill(dt);
      return dt;
    }
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
