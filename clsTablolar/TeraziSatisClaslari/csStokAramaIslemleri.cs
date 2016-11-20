using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Drawing;
using System.IO;

namespace clsTablolar.TeraziSatisClaslari
{
    public class csStokAramaIslemleri : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlCommand cmd;
        SqlDataReader dr;

        void ResetExceptionState()
        {


        }


        public class csTeraziStokButonGrupOzellikleri : IDisposable
        {
            public SimpleButton Btn { get; set; }
            public int StokButonGrupID { get; set; }
            public string KisayolTusu { get; set; }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }


        public List<csTeraziStokButonGrupOzellikleri> StokButonGruplariListesi;

        public void StokButonGruplariniGetir(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            using (cmd = new SqlCommand(@"select TeraziStokGrupTanimlari.TeraziStokGrupTanimID, TeraziStokGrupTanimlari.TeraziStokButonGrupTanimAdi
 from TeraziStokGruplariIliskileri with(nolock)
inner join TeraziStokGrupTanimlari with(nolock) on TeraziStokGrupTanimlari.TeraziStokGrupTanimID = TeraziStokGruplariIliskileri.TeraziStokGrupTanimID
where TeraziStokGruplariIliskileri.TeraziID = @TeraziID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@TeraziID", SqlDbType.Int).Value = TeraziID;

                using (dr = cmd.ExecuteReader())
                {
                    StokButonGruplariListesi = new List<csTeraziStokButonGrupOzellikleri>();
                    // burada birçok şey türetiliyor ve isimler birbirine yakın olduğu için karıştırılabiliyor düzgün bir açıklama lazım
                    int i = 0;
                    while (dr.Read())
                    {
                        DevExpress.XtraEditors.SimpleButton StokGrupButonu = new DevExpress.XtraEditors.SimpleButton();
                        StokGrupButonu.Text = dr["TeraziStokButonGrupTanimAdi"].ToString();
                        StokGrupButonu.Width = 100;
                        StokGrupButonu.Height = 100;

                        StokGrupButonu.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;

                        StokGrupButonu.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        StokGrupButonu.Appearance.Options.UseTextOptions = true;
                        StokGrupButonu.Tag = i;
                        i++;



                        csTeraziStokButonGrupOzellikleri StokGrupButonuOzellikhamisina = new csTeraziStokButonGrupOzellikleri();
                        StokGrupButonuOzellikhamisina.Btn = StokGrupButonu;
                        StokGrupButonuOzellikhamisina.KisayolTusu = ""; // buraya kisayol tuşu eklenecek veri tabanında oluşturulmadı sanırım daha
                        StokGrupButonuOzellikhamisina.StokButonGrupID = (int)dr["TeraziStokGrupTanimID"];


                        // ya stokbutonGrup mu?
                        // Stok Grup Buton mu ulan farklı isimlendirmeler yapmasana amk 2 tane beyin hücren ver 20 tane şey düşünüyorsun

                        StokButonGruplariListesi.Add(StokGrupButonuOzellikhamisina);


                    }
                }
            }
        }

        public class StokButonOzellikleri : IDisposable
        {
            public SimpleButton StokButonu { get; set; }
            public int StokID { get; set; }
            public string KisayolTusu { get; set; }
            public int TeraziStokGrupTanimID { get; set; }
            public clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi BTipi { get; set; }
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public List<StokButonOzellikleri> StokButonlariListesi;

        // stoklari getirecek Butonlari Getiriyor yani hamısına TeraziID ye gerek yok
        public void StokButonlariniGetir(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            using (cmd = new SqlCommand(@"TeraziStokButonlariniGetir", Baglanti, Tr))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TeraziID", SqlDbType.Int).Value = (Int32)TeraziID;

                using (dr = cmd.ExecuteReader())
                {

                    StokButonlariListesi = new List<StokButonOzellikleri>();

                    while (dr.Read())
                    {
                        DevExpress.XtraEditors.SimpleButton StokButonu = new DevExpress.XtraEditors.SimpleButton();
                        StokButonu.Text = dr["Adi"].ToString(); // stok un adı;

                        //csStokButonlari class i simple butonu, buton adını, kısayol tuşunu bu klas tutuyor

                        StokButonOzellikleri Butonhamisina = new StokButonOzellikleri();
                        //Butonhamisina.StokID = (int)dr["StokID"];

                        Butonhamisina.BTipi = (clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi)Convert.ToInt32(dr["ButonTipi"]);

                        Butonhamisina.StokID = (int)dr["ID"]; // StokID ... Artık sadece StokID Değil Duruma göre paketID veya StokID atıyor
                        //Butonhamisina.KisayolTusu = dr["KisayolTusu"].ToString(); //StokButonlari un kisayoltusu
                        Butonhamisina.StokButonu = StokButonu; // Buda buton hamısına

                        Butonhamisina.TeraziStokGrupTanimID = (int)dr["TeraziStokGrupTanimID"];
                        if (dr["Resim"] != DBNull.Value)
                        {
                            StokButonu.Image = byteArrayToImage((byte[])dr["Resim"]);
                            StokButonu.ImageLocation = ImageLocation.TopCenter;
                        }

                        StokButonlariListesi.Add(Butonhamisina);
                        StokButonu.Tag = StokButonlariListesi.Count - 1;// burada index atmış gibi bişi olduk
                        StokButonu.Height = 100;
                        StokButonu.Width = 100;
                        StokButonu.Appearance.Options.UseTextOptions = true;
                        StokButonu.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;

                        StokButonu.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        StokButonu.Appearance.Options.UseTextOptions = true;
                        StokButonu.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        StokButonu.LookAndFeel.UseDefaultLookAndFeel = false;
                        //StokButonu.BackColor = Color.White;
                        StokButonu.Appearance.BackColor = Color.White;
                    }
                }
            }
        }
    }
}
