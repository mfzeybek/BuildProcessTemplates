using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Sayim
{
    public class csSayimDetay : IDisposable
    {
        public DataTable dt_SayimDetay;
        SqlDataAdapter da;
        public csSayimDetay(SqlConnection Baglanti, SqlTransaction Tr, int SayimID)
        {
            if (SayimID == -1)
            {
                dt_SayimDetay = new DataTable();

                // bunlar neden böyle sayimdetayID de lazım değil mi?
                // değiştirdim

                dt_SayimDetay.Columns.Add("SayimDetayID");
                dt_SayimDetay.Columns["SayimDetayID"].DataType = System.Type.GetType("System.Int32");
                dt_SayimDetay.Columns[0].AutoIncrement = true;
                //dt_SayimDetay.Columns[0].AutoIncrementSeed = 1;
                //dt_SayimDetay.Columns[0].AutoIncrementStep = 1;
                dt_SayimDetay.Columns[0].ReadOnly = true;

                dt_SayimDetay.Columns.Add("SayimID");
                dt_SayimDetay.Columns["SayimID"].DataType = System.Type.GetType("System.Int32");

                dt_SayimDetay.Columns.Add("StokID");
                dt_SayimDetay.Columns["StokID"].DataType = System.Type.GetType("System.Int32");
                dt_SayimDetay.Columns.Add("StokAdi");
                dt_SayimDetay.Columns["StokAdi"].DataType = System.Type.GetType("System.String");

                dt_SayimDetay.Columns.Add("Birim1ID");
                dt_SayimDetay.Columns["Birim1ID"].DataType = System.Type.GetType("System.Int32");
                dt_SayimDetay.Columns.Add("Birim1");
                dt_SayimDetay.Columns["Birim1"].DataType = System.Type.GetType("System.String");

                dt_SayimDetay.Columns.Add("Miktar1");
                dt_SayimDetay.Columns["Miktar1"].DataType = System.Type.GetType("System.Decimal");

                dt_SayimDetay.Columns.Add("Birim2ID");
                dt_SayimDetay.Columns["Birim2ID"].DataType = System.Type.GetType("System.Int32");

                dt_SayimDetay.Columns.Add("Katsayi");
                dt_SayimDetay.Columns["Katsayi"].DataType = System.Type.GetType("System.Decimal");

                dt_SayimDetay.Columns.Add("Miktar2");
                dt_SayimDetay.Columns["Miktar2"].DataType = System.Type.GetType("System.Decimal");


                dt_SayimDetay.Columns.Add("MinumumMiktar"); // bu alan veri tabanında yok kaydetmeye de gerek yok sadece o anki işlemlerde kullanılsın diye var
                dt_SayimDetay.Columns["MinumumMiktar"].DataType = System.Type.GetType("System.Decimal");

                dt_SayimDetay.Columns.Add("OlmasiGerekenMiktar"); // bu alan veri tabanında yok kaydetmeye de gerek yok sadece o anki işlemlerde kullanılsın diye var
                dt_SayimDetay.Columns["OlmasiGerekenMiktar"].DataType = System.Type.GetType("System.Decimal");

                // bu veri tabanınına kaydedilmez (Zaten böyle bir alan da yok) sadece o anki (form da) işlemlerde kulanmak amacı ile
                // buraya stok un o anki miktarları atılır.
                dt_SayimDetay.Columns.Add("StokMiktari");
                dt_SayimDetay.Columns["StokMiktari"].DataType = System.Type.GetType("System.Decimal");
            }
            else
            {
                SayimDetayDoldur(Baglanti, Tr, SayimID);
            }

            //dt_SayimDetay.ColumnChanging += new DataColumnChangeEventHandler(dt_SayimDetay_ColumnChanging);
        }
        private void SayimDetayDoldur(SqlConnection Baglanti, SqlTransaction Tr, int SayimID)
        {
            using (da = new SqlDataAdapter())
            {// StokMiktarı 0 getiriyor // sebebi işte öyle programdan daha sonra güncel miktarları getirttiriyorsun

                da.SelectCommand = new SqlCommand(@"SELECT dbo.SayimDetay.SayimDetayID, dbo.SayimDetay.SayimID, dbo.SayimDetay.StokID, dbo.SayimDetay.Birim1ID, dbo.SayimDetay.Miktar1, dbo.SayimDetay.Birim2ID, dbo.SayimDetay.Miktar2, 
                      dbo.Stok.StokAdi, stok.RafYeriAciklama ,dbo.Stok.MinumumMiktar, Stok.OlmasiGerekenMiktar , dbo.StokBirim.BirimAdi AS Birim1,dbo.SayimDetay.Katsayi, CONVERT(DECIMAL(18,8) ,0) as StokMiktari
FROM         dbo.SayimDetay INNER JOIN
                      dbo.Stok ON dbo.SayimDetay.StokID = dbo.Stok.StokID LEFT JOIN
                      dbo.StokBirim ON dbo.SayimDetay.Birim1ID = dbo.StokBirim.BirimID
WHERE     (dbo.SayimDetay.SayimID = @SayimID)", Baglanti, Tr);
                da.SelectCommand.Parameters.Add("@SayimID", SqlDbType.Int).Value = SayimID;
                using (dt_SayimDetay = new DataTable())
                {
                    da.Fill(dt_SayimDetay);
                }
            }
        }

        public void SayimDetayGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int SayimID)
        {
            da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(@"insert into SayimDetay (SayimID, StokID, Birim1ID, Miktar1, Birim2ID,Katsayi, Miktar2) 
values (@SayimID, @StokID, @Birim1ID, @Miktar1, @Birim2ID, @Katsayi,@Miktar2)", Baglanti, Tr);
            da.InsertCommand.Parameters.Add("@SayimID", SqlDbType.Int, 0).Value = SayimID;
            da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
            da.InsertCommand.Parameters.Add("@Birim1ID", SqlDbType.Int, 0, "Birim1ID");
            da.InsertCommand.Parameters.Add("@Miktar1", SqlDbType.Decimal, 100, "Miktar1");
            da.InsertCommand.Parameters.Add("@Birim2ID", SqlDbType.Int, 0, "Birim2ID");
            da.InsertCommand.Parameters.Add("@Katsayi", SqlDbType.Decimal, 100, "Katsayi");
            da.InsertCommand.Parameters.Add("@Miktar2", SqlDbType.Decimal, 100, "Miktar2");

            da.UpdateCommand = new SqlCommand(@"
update  SayimDetay set SayimID=@SayimID, StokID=@StokID, Birim1ID=@Birim1ID, Miktar1=@Miktar1, Birim2ID=@Birim2ID,Katsayi=@Katsayi, Miktar2=@Miktar2
where SayimDetayID=@SayimDetayID", Baglanti, Tr);
            // 
            da.UpdateCommand.Parameters.Add("@SayimID", SqlDbType.Int, 0).Value = SayimID;
            da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
            da.UpdateCommand.Parameters.Add("@Birim1ID", SqlDbType.Int, 0, "Birim1ID");
            da.UpdateCommand.Parameters.Add("@Miktar1", SqlDbType.Decimal, 100, "Miktar1");
            da.UpdateCommand.Parameters.Add("@Birim2ID", SqlDbType.Int, 0, "Birim2ID");
            da.UpdateCommand.Parameters.Add("@Katsayi", SqlDbType.Decimal, 100, "Katsayi");
            da.UpdateCommand.Parameters.Add("@Miktar2", SqlDbType.Decimal, 100, "Miktar2");
            da.UpdateCommand.Parameters.Add("@SayimDetayID", SqlDbType.Int, 0, "SayimDetayID");

            da.DeleteCommand = new SqlCommand(@"delete from SayimDetay where SayimDetayID = @SayimDetayID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@SayimDetayID", SqlDbType.Int, 0, "SayimDetayID");

            try
            {
                da.Update(dt_SayimDetay);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable dt_SayimGrubu;

        public DataTable SayimGrubunuGetir(SqlConnection Baglanti, SqlTransaction Tr, int SayimGrubu)
        {
            using (da = new SqlDataAdapter(@"select * from stok
inner join
StokSayimGrubu on StokSayimGrubu.StokSayimGrubuID = Stok.StokSayimGrubuID  and Stok.StokSayimGrubuID = 1", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                using (dt_SayimGrubu = new DataTable())
                {
                    da.Fill(dt_SayimGrubu);
                    return dt_SayimGrubu;
                }
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
