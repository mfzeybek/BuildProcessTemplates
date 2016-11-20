using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
  public class csNumaraVer : IDisposable
  {

    /* Burasının Mantığı ve Sipariş Fatura vb. yerlerde nasıl numara verilecek*/



    /* Sipariş Fatura vb. yerlerde nasıl numara verilecek 
     
     Örnek Siparişte : Sipariş İlk açıldığında genel ayarlardaki ayarlara (açılışta otomatik varsayilan sipariş numarası versin mi?) 
     * göre Sipariş numarası verilir ve Verilen sipariş numrasının NumaraSablonID si kenara yazılır ve sipariş numarası olarak 
     * verilen numara gözükür ancak en son kayıt yapılırken tekrar bu NumaraSablonID ye göre tekrar numara verilir 
     * ve numara şablon tablosuna verilen numaranın bir büyüğü yazılır.
     */




    /// <summary>
    /// bunun farkı şu
    /// yukarıda verilen numaraya kullanılırsa en son keydet e bastığında burada yeni kullanılacak numara kaydediliyor
    /// örnek :
    /// yeni stok kartı oluşturuldu buradan numarayı aldı sonra kaydet e bastı kullanıcı 
    /// 
    /// 
    /// fatura irsaliye sipariş kaydete basıldığında kullanılır
    /// </summary>
    /// <param name="ModulID">Kullanılacak Kayıt Deseni Adı: 
    /// ( 1 : SATIŞ FATURASI ) - 
    /// ( 2 : ALIŞ FATURASI )  - 
    /// ( 3 : SATIŞ İADE FATURASI )  - 
    /// ( 4 : ALIŞ İADE FATURASI )  -
    /// ( 5 : STOK KARTI )  -
    /// ( 6 : SATIŞ İRSALİYESİ )  -
    /// ( 7 : ALIŞ İRSALİYESİ )  -
    /// ( 8 : SATIŞ İADE İRSALİYESİ )  -
    /// ( 9 : ALIŞ İADE İRSALİYESİ )  -
    /// ( 10: VERİLEN SİPARİŞ )  -
    /// ( 11: ALINAN SİPARİŞ )  -
    /// ( 12: CARİ KARTI )</param> 
    public string VarsayilanNumaraVer_ve_Kaydet(SqlConnection Baglanti, SqlTransaction trGenel, IslemTipi ModulID) // Burada bi hata verebilir aynı anda aynı müşteriye 2 farklı numara vermez inşallah
    {
      using (SqlCommand cmd = new SqlCommand(@"
select IlkKarakter + RIGHT('0000000000000000000000000000'+Numara,KarakterSayisi) from NumaraSablon where Varsayilan = 1 and ModulID = @ModulID
update NumaraSablon set Numara= Numara +1 where Varsayilan = 1 and ModulID = @ModulID", Baglanti, trGenel))
      {
        cmd.Parameters.Add("@ModulID", SqlDbType.Int).Value = Convert.ToInt32(ModulID);
        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
          if (dr.Read())
          {
            return dr[0].ToString();
          }
          else
            return "";
        }
      }
    }

    
    /// <summary>
    /// Fatura, sipariş gibi
    /// Kart ilk açıldığında kaydedilecek numarayı gösterir
    /// ama fatura kaydedilirken tekrar numarayı kontrol ederek kaydeder bu da NumaraVer_ve_Kaydet ile olur
    /// </summary>
    /// <returns></returns>
    public string VarsayilanNumaraVer(IslemTipi Islem, SqlConnection Baglanti, SqlTransaction trGenel)
    {
      using (SqlCommand cmd = new SqlCommand(@"
select IlkKarakter + RIGHT('0000000000000000000000000000'+Numara,KarakterSayisi) 
from NumaraSablon where Varsayilan = 1 and ModulID = @ModulID", Baglanti, trGenel))
      {
        cmd.Parameters.Add("@ModulID", SqlDbType.Int).Value = Convert.ToInt32(Islem);
        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
          if (dr.Read())
          {
            return dr[0].ToString();
          }
          else
            return "";
        }
      }
    }

    public string NumaraVerveKaydet(int NumaraSablonID, SqlConnection Baglanti, SqlTransaction TrGenel)
    {// aşağıdaki sqlden with(nolock) ı kaldırdık
      using (SqlCommand cmd = new SqlCommand(@"
select IlkKarakter + RIGHT('0000000000000000000000000000'+Numara,KarakterSayisi) from NumaraSablon where NumaraSablonID = @NumaraSablonID
update NumaraSablon set Numara= Numara +1 where NumaraSablonID = @NumaraSablonID ", Baglanti, TrGenel))
      {
        cmd.Parameters.Add("@NumaraSablonID", SqlDbType.Int).Value = Convert.ToInt32(NumaraSablonID);
        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
          if (dr.Read())
          {
            return dr[0].ToString();
          }
          else
            return "";
        }
      }
    }

    /// <summary>
    /// bunun yerine Islem tipli olanı kullanmaya çalış bunu ilerde silicen
    /// </summary>
    /// <param name="Baglanti"></param>
    /// <param name="trGenel"></param>
    /// <param name="ModulID"></param>
    /// <returns></returns>
    public string NumaraVer_ve_Kaydet(SqlConnection Baglanti, SqlTransaction trGenel, int ModulID) // bunu ilerde silicen
    {
      using (SqlCommand cmd = new SqlCommand(@"
select IlkKarakter + RIGHT('0000000000000000000000000000'+Numara,KarakterSayisi) from NumaraSablon where Varsayilan = 1 and ModulID = @ModulID
update NumaraSablon set Numara= Numara +1 where Varsayilan = 1 and ModulID = @ModulID", Baglanti, trGenel))
      {
        cmd.Parameters.Add("@ModulID", SqlDbType.Int).Value = Convert.ToInt32(ModulID);
        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
          if (dr.Read())
          {
            return dr[0].ToString();
          }
          else
            return "";
        }
      }
    }
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
