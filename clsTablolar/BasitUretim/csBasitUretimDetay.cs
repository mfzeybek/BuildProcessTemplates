using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.BasitUretim
{
    public class csBasitUretimDetay : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;


        public void getir(SqlConnection baglanti, SqlTransaction Tr, int BasitUretimID)
        {
            da = new SqlDataAdapter("select * from BasitUretimDetay where BasitUretimID = @BasitUretimID", baglanti);
            da.SelectCommand.Transaction = Tr;
            da.SelectCommand.Parameters.Add("@BasitUretimID", SqlDbType.Int).Value = BasitUretimID;

            dt = new DataTable();
            da.Fill(dt);
            da.RowUpdated += Da_RowUpdated;
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int BasitUretimID)
        {

            da.UpdateCommand = new SqlCommand(@"update BasitUretimDetay set SiraNo = @SiraNo, MalzemeStokID = @MalzemeStokID, 
MaliyetFiyatTanimID = @MaliyetFiyatTanimID, Maliyet = @Maliyet, GerekliMiktar = @GerekliMiktar
, MaliyetTutari = @MaliyetTutari, Aciklama = @Aciklama, BasitUretimID = @BasitUretimID , MalzemeStokKodu = @MalzemeStokKodu, MalzemeStokAdi = @MalzemeStokAdi
where BasitUreDetID = @BasitUreDetID", Baglanti, Tr);

            da.UpdateCommand.Parameters.Add("@SiraNo", SqlDbType.Int, 0, "SiraNo");
            da.UpdateCommand.Parameters.Add("@MalzemeStokID", SqlDbType.Int, 0, "MalzemeStokID");
            da.UpdateCommand.Parameters.Add("@MaliyetFiyatTanimID", SqlDbType.Int, 0, "MaliyetFiyatTanimID");
            da.UpdateCommand.Parameters.Add("@Maliyet", SqlDbType.Decimal, 0, "Maliyet");
            da.UpdateCommand.Parameters.Add("@GerekliMiktar", SqlDbType.Decimal, 0, "GerekliMiktar");


            da.UpdateCommand.Parameters.Add("@MaliyetTutari", SqlDbType.Decimal, 0, "MaliyetTutari");
            da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 0, "Aciklama");
            da.UpdateCommand.Parameters.Add("@BasitUreDetID", SqlDbType.Int, 0, "BasitUreDetID");
            da.UpdateCommand.Parameters.Add("@MalzemeStokKodu", SqlDbType.NVarChar, 0, "MalzemeStokKodu");
            da.UpdateCommand.Parameters.Add("@MalzemeStokAdi", SqlDbType.NVarChar, 0, "MalzemeStokAdi");




            da.UpdateCommand.Parameters.Add("@BasitUretimID", SqlDbType.Int).Value = BasitUretimID;

            da.InsertCommand = new SqlCommand(@"
insert into BasitUretimDetay 
(SiraNo, MalzemeStokID, MaliyetFiyatTanimID, Maliyet, GerekliMiktar, MaliyetTutari, Aciklama, BasitUretimID, 
MalzemeStokKodu, MalzemeStokAdi)
values
(@SiraNo, @MalzemeStokID, @MaliyetFiyatTanimID, @Maliyet, @GerekliMiktar,  @MaliyetTutari, @Aciklama, @BasitUretimID, 
@MalzemeStokKodu, @MalzemeStokAdi) 
 set @YeniID = SCOPE_IDENTITY() ", Baglanti, Tr);

            da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;


            da.InsertCommand.Parameters.Add("@SiraNo", SqlDbType.Int, 0, "SiraNo");
            da.InsertCommand.Parameters.Add("@MalzemeStokID", SqlDbType.Int, 0, "MalzemeStokID");
            da.InsertCommand.Parameters.Add("@MaliyetFiyatTanimID", SqlDbType.Int, 0, "MaliyetFiyatTanimID");
            da.InsertCommand.Parameters.Add("@Maliyet", SqlDbType.Decimal, 0, "Maliyet");
            da.InsertCommand.Parameters.Add("@GerekliMiktar", SqlDbType.Decimal, 0, "GerekliMiktar");


            da.InsertCommand.Parameters.Add("@MaliyetTutari", SqlDbType.Decimal, 0, "MaliyetTutari");
            da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 0, "Aciklama");
            //da.InsertCommand.Parameters.Add("@BasitUretimDetayID", SqlDbType.Int, 0, "BasitUretimDetayID");

            da.InsertCommand.Parameters.Add("@MalzemeStokKodu", SqlDbType.NVarChar, 0, "MalzemeStokKodu");
            da.InsertCommand.Parameters.Add("@MalzemeStokAdi", SqlDbType.NVarChar, 0, "MalzemeStokAdi");

            da.InsertCommand.Parameters.Add("@BasitUretimID", SqlDbType.Int).Value = BasitUretimID;



            da.Update(dt);
        }

        private void Da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["BasitUreDetID"] = e.Command.Parameters["@YeniID"].Value;
        }
    }
}