using System;
using System.Data;
using DevExpress.XtraReports.UI;
//using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.UserDesigner;
using System.Drawing.Printing;

namespace clsTablolar.Yazdirma
{
    public class csYazdir : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public enum Nasil { dizayn, Goster, Yazdir, YazdirmaDiyalogu };


        XtraReport Rapor;
        public DataSet ds;


        public int NumberOfCopy = 1;
        public string YaziciAdi = string.Empty;
        public bool RenkliMi = true;
        public bool CiftTarafliMi = false;
        public string KagitKaynagi = string.Empty;
        public int KagitKaynagiIndex;

        /* Aşağıdakiler yazdırma alanı ile ilgili ds yi ortaya çıkartmaya çalışır   */

        public csYazdir()
        {
            ds = new DataSet("Veriler");
        }

        void YaziciAyarlari()
        {
            PrinterSettings ayarlar = new PrinterSettings();
            //ayarlar.
        }

        public void Yazdirr(Nasil NasilAcsin)
        {
            //Rapor.DataAdapter = ds;
            //ds = new DataSet();
            Rapor.DataSource = ds;


            switch (NasilAcsin)
            {
                case Nasil.Goster:
                    Rapor.ShowPreviewDialog();
                    break;
                case Nasil.Yazdir:
                    Rapor.Print();
                    break;
                case Nasil.YazdirmaDiyalogu:
                    Rapor.PrintDialog();
                    break;
            }
        }
        void hazirla()
        {

        }

        public void YaziciSecimi()
        {



        }

        public void Yazdirr(string DosyaAdi, Nasil NasilAcsin)
        {
            try
            {
                Rapor = new XtraReport();
                Rapor.LoadLayout(DosyaAdi);
                Rapor.DataSource = ds;
                ReportPrintTool pt = new ReportPrintTool(Rapor);

                //Rapor.PrintingSystem.ShowMarginsWarning = false;
                //pt.PrintingSystem.ShowMarginsWarning = false;
                //pt.PrintingSystem.StartPrint += PrintingSystem_StartPrint;



                pt.PrinterSettings.Copies = (Int16)NumberOfCopy;
                if (!string.IsNullOrEmpty(YaziciAdi))
                {
                    pt.PrinterSettings.PrinterName = YaziciAdi;
                    try
                    {
                        pt.PrinterSettings.DefaultPageSettings.PaperSource = pt.PrinterSettings.PaperSources[KagitKaynagiIndex];
                    }
                    catch (Exception) { }
                }


                //Rapor.prin
                switch (NasilAcsin)
                {
                    case Nasil.dizayn:
                        XRDesignFormEx XrDesigner = new XRDesignFormEx();
                        XrDesigner.FileName = DosyaAdi;
                        XrDesigner.OpenReport(Rapor);
                        XrDesigner.Show();
                        break;
                    case Nasil.Goster:
                        pt.ShowPreviewDialog();
                        break;
                    case Nasil.Yazdir:
                        pt.Print();
                        break;
                    case Nasil.YazdirmaDiyalogu:
                        pt.PrintDialog();
                        break;
                }
            }
            catch (Exception hata)
            {
                throw hata;
                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                //frmHataBildir.ShowDialog();
            }
        }

        /// <summary>
        /// Hepaynı form dizaynı ile ard arda hızlı bişiler yazırmak istiyorsan form a bunu at.
        /// </summary>
        public static XtraReport ArabellektekiRapor;
        public void DosyayaiArabellegeAl(string DosyaAdi)
        {
            ArabellektekiRapor = new XtraReport();
            ArabellektekiRapor.LoadLayout(DosyaAdi);
            ArabellektekiRapor.DataSource = ds;
            ArabellektekiRapor.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DosyaAdi"></param>
        /// <param name="NasilAcsin"></param>
        /// <param name="YaziciAdi">boş verilirse varsayılan yazıcıdan yazdırır</param>
        public void Yazdirr(string DosyaAdi, Nasil NasilAcsin, string YaziciAdi)
        {
            try
            {
                Rapor = new XtraReport();
                Rapor.LoadLayout(DosyaAdi);
                Rapor.DataSource = ds;
                Rapor.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
                switch (NasilAcsin)
                {
                    case Nasil.dizayn:
                        XRDesignFormEx XrDesigner = new XRDesignFormEx();
                        XrDesigner.FileName = DosyaAdi;
                        XrDesigner.OpenReport(Rapor);
                        XrDesigner.Show();
                        break;
                    case Nasil.Goster:
                        Rapor.ShowPreviewDialog();
                        break;
                    case Nasil.Yazdir:
                        if (YaziciAdi != string.Empty)
                            Rapor.PrinterName = YaziciAdi;
                        Rapor.Print();
                        break;
                    case Nasil.YazdirmaDiyalogu:
                        Rapor.PrintDialog();
                        break;
                }
            }
            catch (Exception hata)
            {
                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                //frmHataBildir.ShowDialog();
            }
        }


        /// <summary>
        /// Bunda Dizeyn Yok,, Ara belleğe alınan Dosyayı Ywzdırır sürekli ayrnı formdan yazdırma işlemi yapılacaksa hızx açısından bu daha hızlı olur bunu kullan hamısına
        /// </summary>
        /// <param name="DosyaAdi"></param>
        /// <param name="NasilAcsin"></param>
        /// <param name="YaziciAdi"></param>
        public void Yazdirr(Nasil NasilAcsin, string YaziciAdi, int CopyaSayisi)
        {
            try
            {
                ArabellektekiRapor.CreateDocument(true);
                NumberOfCopy = CopyaSayisi;
                //ArabellektekiRapor.DataSource = ds;

                switch (NasilAcsin)
                {
                    case Nasil.dizayn:
                        XRDesignFormEx XrDesigner = new XRDesignFormEx();
                        //XrDesigner.FileName = DosyaAdiE;
                        XrDesigner.OpenReport(ArabellektekiRapor);
                        XrDesigner.Show();
                        break;
                    case Nasil.Goster:
                        ArabellektekiRapor.ShowPreviewDialog();
                        break;
                    case Nasil.Yazdir:
                        if (YaziciAdi != string.Empty)
                            ArabellektekiRapor.PrinterName = YaziciAdi;
                        ArabellektekiRapor.Print();

                        break;
                    case Nasil.YazdirmaDiyalogu:
                        ArabellektekiRapor.PrintDialog();
                        break;
                }
            }
            catch (Exception hata)
            {
                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                //frmHataBildir.ShowDialog();
            }
            finally
            {
            }
        }



        private void PrintingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            try
            {
                //for (int i = 0; i < e.PrintDocument.PrinterSettings.PaperSources.Count; i++)
                //    if (e.PrintDocument.PrinterSettings.PaperSources[i].==
                //        PaperSourceKind.Cassette)
                //    {
                //        e.PrintDocument.DefaultPageSettings.PaperSource =
                //            e.PrintDocument.PrinterSettings.PaperSources[i];
                //        break;
                //    }

                //if (e.PrintDocument.PrinterSettings.CanDuplex == true)
                //{
                //    e.PrintDocument.PrinterSettings.Duplex = Duplex.Default;
                //}



                //e.PrintDocument.

                //e.PrintDocument.PrinterSettings.PrinterName = YaziciAdi;
                //e.PrintDocument.PrinterSettings.Copies = (Int16)NumberOfCopy;
                //e.PrintDocument.DefaultPageSettings.PaperSource = e.PrintDocument.PrinterSettings.PaperSources[KagitKaynagiIndex];

                //e.PrintDocument.DefaultPageSettings.
            }
            catch (Exception exep)
            {
                throw;
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
        public void dt_yeAlanEkle(string Tabloismi, string Kolonadi, Type Tipi)
        {
            ds.Tables[Tabloismi].Columns.Add(Kolonadi, Tipi);
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
                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                //frmHataBildir.ShowDialog();
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

        public void TepsiSecenekleriniGetir()
        {
            //Rapor.PrintDialog();
            Rapor.ShowPageSetupDialog();


            //PrintDocument prnter = new PrintDocument();
            //prnter.PrinterSettings.PaperSources
        }
    }
}
