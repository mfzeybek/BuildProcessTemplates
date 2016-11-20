using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public class csIlgiliStok : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt_IlgiliStok;

        public void IlgiliStoklariGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (da = new SqlDataAdapter(@"select IlgiliStok.IlgiliStokID, IlgiliStok.StokID1, IlgiliStok.StokID2, IlgiliStok.Aciklama , IlgiliStok2.StokAdi, 5 , 'Stok Karti' Entegrasyon  from IlgiliStok -- entegrasyonu stok kartı (5)
inner join Stok as IlgiliStok2 on IlgiliStok2.StokID = IlgiliStok.StokID2
where IlgiliStok.StokID1 = @StokID1 or IlgiliStok.StokID2 = @StokID1
union

select BasitUretimRecetesi.BUReceteID, BasitUretimRecetesi.UretilenStokID, -1, BasitUretimRecetesi.Aciklama, IlgiliStok2.StokAdi, 26, 'Uretilen Stok' from BasitUretimRecetesi -- -- entegrasyonu stok kartı (26)
inner join Stok as IlgiliStok2 on IlgiliStok2.StokID = BasitUretimRecetesi.UretilenStokID
where BasitUretimRecetesi.UretilenStokID = @StokID1 
union 

select BasitUretimReceteDetayi.BUReceteID, BasitUretimReceteDetayi.MalzemeStokID,-1 ,BasitUretimReceteDetayi.Aciklama,IlgiliStok2.StokAdi ,26, 'Hammadde Olarak Kullanılan Stok' from BasitUretimReceteDetayi
inner join BasitUretimRecetesi on BasitUretimRecetesi.BUReceteID = BasitUretimReceteDetayi.BUReceteID
inner join Stok as IlgiliStok2 on IlgiliStok2.StokID = BasitUretimReceteDetayi.MalzemeStokID
where BasitUretimReceteDetayi.MalzemeStokID = @StokID1 ", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@StokID1", SqlDbType.Int).Value = StokID;

                using (dt_IlgiliStok = new DataTable())
                {
                    da.Fill(dt_IlgiliStok);
                }
            }
        }

        /// <summary>
        /// I know need add a description here
        /// </summary>
        /// <returns></returns>
        //    public DataTable StokunEklendigiIlgiliStoklariGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        //    {
        //      using (da = new SqlDataAdapter(@"select IlgiliStok.*, IlgiliStok1.StokAdi from IlgiliStok
        //inner join Stok as IlgiliStok1 on IlgiliStok1.StokID = IlgiliStok.StokID1
        // where IlgiliStok.StokID2 = @StokID2 ", Baglanti))
        //      {
        //        da.SelectCommand.Transaction = Tr;

        //        da.SelectCommand.Parameters.Add("@StokID2", SqlDbType.Int).Value = StokID;

        //        using (DataTable Dt_hamisina = new DataTable())
        //        {
        //          da.Fill(Dt_hamisina);
        //          return Dt_hamisina;
        //        }
        //      }
        //    }

        public void IlgiliStoklariGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            da.UpdateCommand = new SqlCommand(@"update IlgiliStok set  StokID1 = @StokID1, StokID2 = @StokID2, Aciklama = @Aciklama
where IlgiliStokID = @IlgiliStokID", Baglanti, Tr);
            da.UpdateCommand.Parameters.Add("@StokID1", SqlDbType.Int).Value = StokID;
            da.UpdateCommand.Parameters.Add("@StokID2", SqlDbType.Int, 0, "StokID2");
            da.UpdateCommand.Parameters.Add("@IlgiliStokID", SqlDbType.Int, 0, "IlgiliStokID");
            da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.VarChar, 200, "Aciklama");


            da.InsertCommand = new SqlCommand(@"insert into IlgiliStok (StokID1, StokID2, Aciklama) values (@StokID1, @StokID2, @Aciklama)", Baglanti, Tr);
            da.InsertCommand.Parameters.Add("@StokID1", SqlDbType.Int).Value = StokID;
            da.InsertCommand.Parameters.Add("@StokID2", SqlDbType.Int, 0, "StokID2");
            da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.VarChar, 200, "Aciklama");

            da.DeleteCommand = new SqlCommand("delete from IlgiliStok where IlgiliStokID = @IlgiliStokID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@IlgiliStokID", SqlDbType.Int, 0, "IlgiliStokID");

            da.Update(dt_IlgiliStok);
        }


    }
}
