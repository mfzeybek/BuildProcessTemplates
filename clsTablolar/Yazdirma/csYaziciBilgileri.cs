using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Data.SQLite.EF6;

namespace clsTablolar.Yazdirma
{
    public class csYaziciBilgileri : IDisposable
    {
        public void Dispose()
        {
            //da.Dispose();
            GC.SuppressFinalize(this);
        }


        public void csYaziciBilgileriniGetir(int ModulID)
        {
            VeriTabaniniOlustur();

            using (da = new System.Data.SQLite.SQLiteDataAdapter("select * from YaziciAyarlari where ModulID = @ModulID", sqlKonneksin))
            {
                if (sqlKonneksin.State == ConnectionState.Closed)
                    sqlKonneksin.Open();
                da.SelectCommand.Parameters.Add("@ModulID", System.Data.DbType.Int32).Value = ModulID;
                dt = new DataTable();
                da.Fill(dt);
            }
        }


        public string VarsayilanYaziciAdi { get; set; }
        public Int16 VarsayilanYaziciIndex { get; set; }

        public void VarsayilanBilgileriGetir(int RaporDizaynID)
        {
            VeriTabaniniOlustur();
            using (SQLiteCommand cmd = new SQLiteCommand("select * from YaziciAyarlari where RaporDizaynID = @RaporDizaynID ", sqlKonneksin))
            {
                cmd.Parameters.Add("@RaporDizaynID", DbType.Int32).Value = RaporDizaynID;
                if (sqlKonneksin.State == ConnectionState.Closed || sqlKonneksin.State == ConnectionState.Broken)
                    sqlKonneksin.Open();
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        VarsayilanYaziciAdi = dr["YaziciAdi"].ToString();
                        if (dr["KagitKaynagiIndex"] != DBNull.Value)
                            VarsayilanYaziciIndex = Convert.ToInt16(dr["KagitKaynagiIndex"]);
                    }
                }
                sqlKonneksin.Close();
            }
        }

        public void YaziciBilgileriniKaydet(int ModulID, DataTable dtYaziciBil)
        {
            using (da = new System.Data.SQLite.SQLiteDataAdapter("select * from YaziciAyarlari where ModulID = @ModulID", sqlKonneksin))
            {
                da.InsertCommand = new System.Data.SQLite.SQLiteCommand(@"insert into YaziciAyarlari 
                    (RaporDizaynID, ModulID, YaziciAdi, KagitKaynagi, KagitKaynagiIndex
--, RenkliMi, KagitTipi, CiftTarafliMi
, Aciklama) values (@RaporDizaynID, @ModulID, @YaziciAdi, @KagitKaynagi, @KagitKaynagiIndex
--, @RenkliMi, @KagitTipi, @CiftTarafliMi
, @Aciklama)", sqlKonneksin);
                da.InsertCommand.Parameters.Add("@ModulID", System.Data.DbType.Int16).Value = ModulID;
                da.InsertCommand.Parameters.Add("@RaporDizaynID", System.Data.DbType.String, 0, "RaporDizaynID");
                da.InsertCommand.Parameters.Add("@YaziciAdi", System.Data.DbType.String, 0, "YaziciAdi");
                da.InsertCommand.Parameters.Add("@KagitKaynagi", System.Data.DbType.String, 0, "KagitKaynagi");
                da.InsertCommand.Parameters.Add("@KagitKaynagiIndex", System.Data.DbType.Int16, 0, "KagitKaynagiIndex");
                //da.InsertCommand.Parameters.Add("@RenkliMi", System.Data.DbType.Boolean, 0, "RenkliMi");
                //da.InsertCommand.Parameters.Add("@KagitTipi", System.Data.DbType.String, 0, "KagitTipi");
                //da.InsertCommand.Parameters.Add("@CiftTarafliMi", System.Data.DbType.Int16, 0, "CiftTarafliMi");
                da.InsertCommand.Parameters.Add("@Aciklama", System.Data.DbType.String, 0, "Aciklama");


                da.UpdateCommand = new System.Data.SQLite.SQLiteCommand(@"update YaziciAyarlari set 
RaporDizaynID = @RaporDizaynID, ModulID = @ModulID, YaziciAdi = @YaziciAdi, 
KagitKaynagi = @KagitKaynagi, KagitKaynagiIndex = @KagitKaynagiIndex
--, RenkliMi = @RenkliMi, KagitTipi = @KagitTipi, CiftTarafliMi = @CiftTarafliMi
, Aciklama = @Aciklama where RaporDizaynID = @RaporDizaynID", sqlKonneksin);

                da.UpdateCommand.Parameters.Add("@ID", System.Data.DbType.Int32, 0, "ID");
                da.UpdateCommand.Parameters.Add("@ModulID", System.Data.DbType.Int16).Value = ModulID;
                da.UpdateCommand.Parameters.Add("@RaporDizaynID", System.Data.DbType.String, 0, "RaporDizaynID");
                da.UpdateCommand.Parameters.Add("@YaziciAdi", System.Data.DbType.String, 0, "YaziciAdi");
                da.UpdateCommand.Parameters.Add("@KagitKaynagi", System.Data.DbType.String, 0, "KagitKaynagi");
                da.UpdateCommand.Parameters.Add("@KagitKaynagiIndex", System.Data.DbType.Int16, 0, "KagitKaynagiIndex");
                //da.UpdateCommand.Parameters.Add("@RenkliMi", System.Data.DbType.Boolean, 0, "RenkliMi");
                //da.UpdateCommand.Parameters.Add("@KagitTipi", System.Data.DbType.String, 0, "KagitTipi");
                //da.UpdateCommand.Parameters.Add("@CiftTarafliMi", System.Data.DbType.Int16, 0, "CiftTarafliMi");
                da.UpdateCommand.Parameters.Add("@Aciklama", System.Data.DbType.String, 0, "Aciklama");

                da.DeleteCommand = new System.Data.SQLite.SQLiteCommand("delete from YaziciAyarlari where RaporDizaynID = @RaporDizaynID", sqlKonneksin);
                da.DeleteCommand.Parameters.Add("@RaporDizaynID", System.Data.DbType.Int32, 0, "RaporDizaynID");

                da.Update(dtYaziciBil);
            }
        }
        System.Data.SQLite.SQLiteConnection sqlKonneksin;
        System.Data.SQLite.SQLiteDataAdapter da;
        public DataTable dt;

        private void VeriTabaniniOlustur()
        {
            if (!Directory.Exists(Application.StartupPath + @"\Yazdirma"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Yazdirma");
            }

            string DbDosya = Application.StartupPath + @"\Yazdirma\YaziciAyarlari.sqlite";


            System.Data.SQLite.SQLiteConnectionStringBuilder connectStr =
            new System.Data.SQLite.SQLiteConnectionStringBuilder();
            connectStr.DataSource = DbDosya;
            connectStr.UseUTF16Encoding = true;

            try
            {
                sqlKonneksin =
                new System.Data.SQLite.SQLiteConnection(connectStr.ConnectionString);
                {
                    // bu çalıştığında Dosya yoksa Oluşturuyor;

                    using (System.Data.SQLite.SQLiteCommand sqlCommand =
                    new System.Data.SQLite.SQLiteCommand(sqlKonneksin))
                    {
                        // Veritabanı dosyasının varlğının kontrol&uuml;
                        if (!File.Exists(DbDosya))
                        {
                            System.Data.SQLite.SQLiteConnection.CreateFile(DbDosya);


                            sqlKonneksin.Open();
                            sqlCommand.CommandText = @"--Table: Logs

--DROP TABLE Logs;

CREATE TABLE YaziciAyarlari (
ID     integer NOT NULL PRIMARY KEY AUTOINCREMENT,
RaporDizaynID INT, 
ModulID integer,
YaziciAdi nvarchar(500),
KagitKaynagi nvarchar(50),
KagitKaynagiIndex integer,
RenkliMi bit,
KagitTipi integer,
CiftTarafliMi integer,
Aciklama nvarchar(500)
)";
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
        }



    }
}
