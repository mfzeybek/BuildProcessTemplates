using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csCariBakiye : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    private decimal _AlacakToplami;
    private decimal _BorcToplami;
    private decimal _Bakiye;
    private CariHr.HareketYonu _BakiyeTuru;


    public decimal AlacakToplami
    {
      get { return _AlacakToplami; }
      set { _AlacakToplami = value; }
    }
    public decimal BorcToplami
    {
      get { return _BorcToplami; }
      set { _BorcToplami = value; }
    }
    public decimal Bakiye
    {
      get { return _Bakiye; }
      set { _Bakiye = value; }
    }
    public CariHr.HareketYonu BakiyeTuru
    {
      get { return _BakiyeTuru; }
      set { _BakiyeTuru = value; }
    }



    SqlCommand cmd;
    SqlDataReader dr;
    public void BakiyeVer(SqlConnection Baglanti, SqlTransaction Tr, int CariID)
    {
      using (cmd = new SqlCommand(@"declare @AlacakToplami decimal(18,2) , @BorcToplami decimal(18,2)
                                  set @AlacakToplami = 
                                  (select SUM(Tutar) from CariHr where AlacakMiBorcMu = 2 and SilindiMi = 0 and Carihr.CariID = @CariID)
                                  set @BorcToplami = (select SUM(Tutar) from CariHr where AlacakMiBorcMu = 3 and SilindiMi = 0 and CariID = @CariID)
                                  select isnull(@AlacakToplami, 0) as 'AlacakToplami', ISNULL (@BorcToplami, 0) as 'BorcToplami'", Baglanti, Tr))
      {
        cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;

        using (dr = cmd.ExecuteReader())
        {

          if (dr.Read())
          {
            _AlacakToplami = Convert.ToDecimal(dr["AlacakToplami"]);
            _BorcToplami = Convert.ToDecimal(dr["BorcToplami"]);
            if (_AlacakToplami > _BorcToplami)
            {
              _Bakiye = _AlacakToplami - _BorcToplami;
              _BakiyeTuru = CariHr.HareketYonu.Alacak;
            }
            else
            {
              _Bakiye = _BorcToplami - _AlacakToplami;
              _BakiyeTuru = CariHr.HareketYonu.Borc;
            }
          }
        }
      }
    }

  }
}
