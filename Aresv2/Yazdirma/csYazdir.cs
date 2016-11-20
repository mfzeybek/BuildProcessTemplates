using System;
using System.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace Aresv2.cs
{
    public class csYazdir : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public enum Nasil { dizayn, Goster, Yazdir };


        XtraReport Rapor;
        public DataSet ds;


        /* Aşağıdakiler yazdırma alanı ile ilgili ds yi ortaya çıkartmaya çalışır   */

        public csYazdir()
        {
            ds = new DataSet("Veriler");
        }

        public void Yazdirr(string DosyaAdi, Nasil NasilAcsin)
        {
            try
            {
                Rapor = new XtraReport();
                Rapor.LoadLayout(DosyaAdi);
                Rapor.DataSource = ds;

                switch (NasilAcsin)
                {
                    case Nasil.dizayn:
                        XRDesignFormEx XrDesigner = new XRDesignFormEx() { FileName = DosyaAdi };
                        XrDesigner.OpenReport(Rapor);
                        XrDesigner.Show();
                        break;
                    case Nasil.Goster: Rapor.ShowPreview();
                        break;
                    case Nasil.Yazdir: Rapor.Print();
                        break;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        public void dt_ekle(DataTable dt)
        {
            ds.Tables.Add(dt);
        }
        public void dt_ekle(string tabloismi)
        {
            ds.Tables.Add(tabloismi);
        }
        public void dt_yeAlanEkle(string Tabloismi, string Kolonadi)
        {
            ds.Tables[Tabloismi].Columns.Add(Kolonadi);
        }

        /// <summary>
        /// Datatble ın son satırına veri ekler
        /// </summary>
        /// <param name="Tabloismi"></param>
        /// <param name="Kolonadi"></param>
        /// <param name="Deger"></param>
        /// <param name="Tipi"></param>
        public void dtAlanEkleVeriEkle(string Tabloismi, string Kolonadi, object Deger, Type Tipi)
        {
            try
            {
                if (ds.Tables[Tabloismi].Rows.Count == 0)
                {
                    DtyaYeniSatirEkle(Tabloismi);
                }
                ds.Tables[Tabloismi].Columns.Add(Kolonadi, Tipi);
                ds.Tables[Tabloismi].Rows[ds.Tables[Tabloismi].Rows.Count - 1][Kolonadi] = Deger;
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        /// <summary>
        /// datatable oluşturulmuşsa önce buradan satır eklenmesi gerekir
        /// </summary>
        /// <param name="tableAdi"></param>
        public void DtyaYeniSatirEkle(string tableAdi)
        {
            ds.Tables[tableAdi].Rows.Add(ds.Tables[tableAdi].NewRow());
        }


        /// <summary>
        /// fatura vb yerlerde kullanmak için
        /// </summary>
        /// <param name="tutar"></param>
        /// <returns></returns>
        public string yaziyaCevir(decimal tutar)
        {
            string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için                
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı    
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2); string yazi = ""; string[] birler = { "", "BİR", "İKİ", "Üç", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" }; string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" }; string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.     
            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)                     
            //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.     
            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.                         
            string grupDegeri;
            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.    
            {
                grupDegeri = "";
                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                         
                if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.            
                    grupDegeri = "YÜZ";
                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar         
                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                         
                if (grupDegeri != "") //binler            
                    grupDegeri += binler[i / 3];
                if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.            
                    grupDegeri = "BİN"; yazi += grupDegeri;
            }
            if (yazi != "") yazi += " TL "; int yaziUzunlugu = yazi.Length;
            if (kurus.Substring(0, 1) != "0")
                //kuruş onlar        
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];
            if (kurus.Substring(1, 1) != "0") //kuruş birler        
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];
            if (yazi.Length > yaziUzunlugu)
                yazi += " Kr.";
            else yazi += "SIFIR Kr."; return yazi;
        }

        int ListedenYazdir_YazdırilaninID;
        clsTablolar.csRaporDizayn.RaporModul ListedenYazdirilanin_Modulu;
    }
}
