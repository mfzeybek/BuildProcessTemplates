using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
  public class csStokHr : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }



    private int _StokHrID;
    private int _StokID;
    private DateTime _Tarih;
    private decimal _Miktar;
    private int _Entegrasyon;
    private string _EvrakNo;
    private string _Aciklama;
    private int _CariID;
    private int _KaydedenID;
    private DateTime _KayitTarihi;
    private int _DegistirenID;
    private DateTime _DegistirmeTarihi;

    public int StokHrID
    {
      get { return _StokHrID; }
      set { _StokHrID = value; }
    }
    public int StokID
    {
      get { return _StokID; }
      set { _StokID = value; }
    }
    public DateTime Tarih
    {
      get { return _Tarih; }
      set { _Tarih = value; }
    }
    public decimal Miktar
    {
      get { return _Miktar; }
      set { _Miktar = value; }
    }
    public int Entegrasyon
    {
      get { return _Entegrasyon; }
      set { _Entegrasyon = value; }
    }
    public string EvrakNo
    {
      get { return _EvrakNo; }
      set { _EvrakNo = value; }
    }
    public string Aciklama
    {
      get { return _Aciklama; }
      set { _Aciklama = value; }
    }
    public int CariID
    {
      get { return _CariID; }
      set { _CariID = value; }
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
    public DateTime DegistirmeTarihi
    {
      get { return _DegistirmeTarihi; }
      set { _DegistirmeTarihi = value; }
    }


    SqlCommand cmd;
    SqlDataReader dr;


    //  ENTEGRASYON

    //1 Devir Girişi
    //2 Stok girişi
    //3 Stok çıkışı
    //4 Alış faturası
    //5 Satış faturası
    //6 Alıştan iade
    //7 Satıştan iade


    public csStokHr(SqlConnection Baglanti, SqlTransaction Tr, int StokHrID)
    {
      if (StokHrID == -1)
      {
        _StokHrID = -1;
        _StokID = -1;
        _Tarih = DateTime.Now;
        _Miktar = 0;
        _Entegrasyon = -1;
        _EvrakNo = "";
        _Aciklama = "";
        _CariID = -1;
        _KaydedenID = -1;
        _KayitTarihi = DateTime.Now;
        _DegistirenID = -1;
        _DegistirmeTarihi = DateTime.Now;
      }
      else
      {
        using (cmd = new SqlCommand("select * from StokHr where StokHrID = @StokHrID", Baglanti, Tr))
        {
          cmd.Parameters.Add("@StokHrID", SqlDbType.Int).Value = StokHrID;

          dr = cmd.ExecuteReader();

          if (dr.Read())
          {
            _StokHrID = Convert.ToInt32(dr["StokHrID"]);
            _StokID = Convert.ToInt32(dr["StokID "]);
            _Tarih = Convert.ToDateTime(dr["Tarih"]);
            _Miktar = Convert.ToDecimal(dr["Miktar"]);
            _Entegrasyon = Convert.ToInt16(dr["Entegrasyon"]);
            _EvrakNo = dr["EvrakNo"].ToString();
            _Aciklama = dr["Aciklama"].ToString();
            _CariID = Convert.ToInt32(dr["CariID"]);
          }
        }
      }




    }

    public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int StokHrID)
    {
      if (StokHrID == -1)
      {
        using (cmd = new SqlCommand(@"insert into StokHr 
        ( StokID, Tarih, Miktar, Entegrasyon, EvrakNo, Aciklama, CariID, KaydedenID, KayitTarihi, DegistirenID, DegistirmeTarihi ) 
        values ( @StokID, @Tarih, @Miktar, @Entegrasyon, @EvrakNo, @Aciklama, @CariID ) 
        set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr))
        {
          cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

          cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = _StokID;
          cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = _Tarih;
          cmd.Parameters.Add("@Miktar", SqlDbType.Decimal).Value = _Miktar;
          cmd.Parameters.Add("@Entegrasyon", SqlDbType.TinyInt).Value = _Entegrasyon;
          cmd.Parameters.Add("@EvrakNo", SqlDbType.TinyInt).Value = _EvrakNo;

          cmd.Parameters.Add("@Aciklama", SqlDbType.TinyInt).Value = _Aciklama;
          cmd.Parameters.Add("@CariID", SqlDbType.TinyInt).Value = _CariID;



          cmd.ExecuteNonQuery();
          if (_StokHrID == -1)
            _StokHrID = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);
        }
      }
      else
      {
        using (cmd = new SqlCommand(@"update StokHr set StokHrID = @StokHrID, StokID = @StokID, Tarih = @Tarih, Miktar = @Miktar, Entegrasyon = @Entegrasyon, EvrakNo = @EvrakNo, Aciklama = @Aciklama, CariID = @CariID where StokHrID = @StokHrID ", Baglanti, Tr))
        {
          cmd.Parameters.Add("@StokHrID", SqlDbType.Int).Value = StokHrID;
          cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = _StokID;
          cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = _Tarih;
          cmd.Parameters.Add("@Miktar", SqlDbType.Decimal).Value = _Miktar;
          cmd.Parameters.Add("@Entegrasyon", SqlDbType.TinyInt).Value = _Entegrasyon;
          cmd.Parameters.Add("@EvrakNo", SqlDbType.TinyInt).Value = _EvrakNo;

          cmd.Parameters.Add("@Aciklama", SqlDbType.TinyInt).Value = _Aciklama;
          cmd.Parameters.Add("@CariID", SqlDbType.TinyInt).Value = _CariID;

          cmd.ExecuteNonQuery();
        }
      }
    }

    public void Sil(SqlConnection Baglanti, SqlTransaction Tr, int StokHrID)
    {
      using (cmd = new SqlCommand("delete from  StokHr where StokHrID = @StokHrID ", Baglanti, Tr))
      {
        cmd.Parameters.Add("@StokHrID", SqlDbType.Int).Value = StokHrID;

        cmd.ExecuteNonQuery();
      }
    }


    // burası düzeltilecek
    public decimal StokIDver_MiktarAl(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
    {
      using (cmd = new SqlCommand(@"declare @ArtiMiktar decimal(18,0), @EksiMiktar decimal(18,0)

set @ArtiMiktar = (select sum (StokHr.Miktar) from StokHr where StokHr.Entegrasyon = 1 and StokHr.StokID = @StokID)
set @EksiMiktar = (select sum (StokHr.Miktar) from StokHr where StokHr.Entegrasyon = 3 and StokHr.StokID = @StokID)

select isnull(@ArtiMiktar, 0) - isnull(@EksiMiktar ,0) as Miktar", Baglanti, Tr))
      {

        cmd.Parameters.Add("StokID", SqlDbType.Int).Value = StokID;
        return Convert.ToDecimal(cmd.ExecuteScalar());
      }
    }

  }
}
