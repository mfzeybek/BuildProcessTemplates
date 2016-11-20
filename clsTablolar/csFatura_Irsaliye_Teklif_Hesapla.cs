using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace clsTablolar
{
    public class csFatura_Irsaliye_Teklif_Hesapla : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public csFatura_Irsaliye_Teklif_Hesapla()
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
        }

        /* Fatura, İrsaliye, Sipariş, Teklif gibi modüllerin hesaplama işlemlerini hep buradan yaptırıcam
         * böylece biri için bir güncelleme yaptığımda her biri için ayrı ayrı hepsine uygulamam gerekmiyecek
         * burada yapılan önemli bir değişiklik için veri tabanı kontrol edilmeli
         * ör: bir hesaplama şeklini değiştirdin mesela veri tabanındaki eski kayıtlar yanlış hesaplanabilir
         * 
         * hesaplama yapması için verilen tabledaki olması gereken alanları yaz
     
         * Mutlaka olması gereken alanlar
         * SatirNo
         * Toplam
         * Miktar => AnaBirimMiktar olarak güncellenmesi lazım
         * AnaBirimFiyat
         * AltBirimMiktar => Eklenecek ... (eklendi faturaharekete)
         * Birim2Fiyat => AltBirimFiyat olarak güncellenmesi lazım
         * KatSayi => AltBirimKatSayi olarak güncellenmesi laızm
         * 
         * (iskonto ile ilgili alanlar)
         * StokIskonto1Tutari
         * StokIskonto1
         * StokIskonto1SonrasiTutar
         * StokIskonto2Tutari
         * StokIskonto2
         * StokIskonto2SonrasiTutar
         * StokIskonto3Tutari
         * StokIskonto3
         * 
         * CariIskonto1Tutari
         * CariIskonto1
         * CariIskonto1SonrasiTutar
         * CariIskonto2Tutari
         * CariIskonto2
         * CariIskonto2SonrasiTutar
         * CariIskonto3Tutari
         * CariIskonto3
         * 
         * StokToplamIskonto
         * CariToplamIskonto
         * ToplamIskonto
         * 
         * IskontoluFiyat
         * SatirIndirimliToplam
         * KdvTutari
         * Kdv
         */


        frmMiktarGir MiktarGirisi = new frmMiktarGir(0);

        public DataTable _dt_HareketDetay;
        public DevExpress.XtraGrid.Views.Grid.GridView _gvFaturaHareket;




        public decimal Toplam_Iskontosuz_Kdvsiz; // Toplam = AnaBirimFiyat * Miktar

        public decimal CariIskontoToplami1nci; // (StokIskonto1 * AnaBirimFiyat /100);
        public decimal CariIskontoToplami2nci;
        public decimal CariIskontoToplami3ncu;
        public decimal CariIskontoToplami;

        public decimal StokIskontoToplami1nci;
        public decimal StokIskontoToplami2nci;
        public decimal StokIskontoToplami3ncu;
        public decimal StokIskontoToplami; // StokToplamIskonto = (StokIskonto1 * AnaBirimFiyat /100) + (StokIskonto2 * AnaBirimFiyat /100) + (StokIskonto3 * AnaBirimFiyat /100)

        public decimal ToplamIndirim; //ToplamIskonto = StokToplamIskonto + CariToplamIskonto
        public decimal ToplamKdv;
        public decimal IskontoluToplam; // AraToplam
        public decimal FaturaTutari;


        public decimal ToplamKdvDahilIndirimMiktari; // Yani Hiç indirim yapılmamış kdv dahil fatura tutarı ile indirim yapılmış kdv dahil fatura tutarı arasındaki fark
        public decimal ToplamKdvDahilIndirimsizSatisTutari;
        public decimal ToplamOrtalamIndirimYuzdesi;

        public delegate void dlg_AltToplamlarDegisti();
        public dlg_AltToplamlarDegisti AltToplamlarDegisti; // Alt Toplamlar değiştiğinde bu delegeyi çalıştır.

        /// <summary>
        /// _dt_HareketDetay daki veriler değiştikçe otomatik olarak hesaplar
        /// </summary>
        private bool _OtomatikHesapla = true; //

        public bool OtomatikHesapla(bool True_False)
        {
            //if (True_False == true)
            //  _dt_HareketDetay.ColumnChanged += dt_HareketDetay_ColumnChanged;
            //else
            //  _dt_HareketDetay.ColumnChanged -= dt_HareketDetay_ColumnChanged;

            //_OtomatikHesapla = True_False;
            return _OtomatikHesapla;
        }


        public csFatura_Irsaliye_Teklif_Hesapla(DataTable dt_HareketDetay, DevExpress.XtraGrid.Views.Grid.GridView Hareket)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            _dt_HareketDetay = dt_HareketDetay;
            _gvFaturaHareket = Hareket;

            _gvFaturaHareket.CellValueChanged += _gvFaturaHareket_CellValueChanged;

            //TODO: Kdv Tablosuna Teraziden satışta ihtiyaç yok o yüzden buraya bir koşul koy ihtiyaç yoksa kdv tablosunu oluşturmasın
            KdvTablosunuOlustur();
            IskontoDetayTablosunuOlustur();
        }


        // bunun işleme sırasını yaz
        /// <summary>
        /// gvFaturaHareket ten set etmek için sadece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _gvFaturaHareket_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            //int datarowIndex = _gvFaturaHareket.GetDataSourceRowIndex(e.RowHandle); 
            int datarowIndex = _dt_HareketDetay.Rows.IndexOf(_gvFaturaHareket.GetDataRow(e.RowHandle)); // en doğrusu bu böyle silinen satırları da doğru veriryor falan filan

            //_gvFaturaHareket.UpdateCurrentRow();

            #region Sira Numarasi
            if (e.Column.Caption == "SatirNo") // eğer satır numarası değiştiriliyorsa numarayı vermiş şimdi de değiştiriyoruz demektir
            { // Bu çok zor oldu 
                // buranın işleme sırasını yaz 
                int YeniSiraNumarasi = Convert.ToInt32(_dt_HareketDetay.Rows[datarowIndex]["SatirNo"]);
                int EskiSiraNumarasi = _gvFaturaHareket.GetVisibleIndex(e.RowHandle) + 1;

                //_dt_HareketDetay.Rows[datarowIndex]["SatirNo"]


                if (YeniSiraNumarasi > EskiSiraNumarasi)
                {
                    DataRow[] dr = _dt_HareketDetay.Select("SatirNo >= " + YeniSiraNumarasi.ToString() + " and SatirNo <= " + EskiSiraNumarasi.ToString(), "SatirNo", DataViewRowState.CurrentRows);

                    for (int i = 0; i < dr.Count(); i++)
                    {
                        if (_dt_HareketDetay.Rows.IndexOf(dr[i]) != datarowIndex)
                        {
                            dr[i]["SatirNo"] = Convert.ToInt32(dr[i]["SatirNo"]) - 1;
                        }
                    }
                }
                else if (EskiSiraNumarasi > YeniSiraNumarasi) // bulunduğu satırdan daha küçük bir satır numarası verilmişse - 
                { // verilen satır numarası önceden kime aitse o satırdan itibaren Eski satir numarasi (Eski satır numarasi dahil) na kadar 1 arttırıyoruz
                    // mevcut satır numarası yani 

                    DataRow[] dr = _dt_HareketDetay.Select("SatirNo >= " + YeniSiraNumarasi.ToString() + " and SatirNo <= " + EskiSiraNumarasi.ToString(), "SatirNo", DataViewRowState.CurrentRows);

                    for (int i = 0; i < dr.Count(); i++)
                    {

                        if (Convert.ToInt32(_dt_HareketDetay.Rows.IndexOf(dr[i])) != datarowIndex)
                        {
                            dr[i]["SatirNo"] = Convert.ToInt32(dr[i]["SatirNo"]) + 1;
                        }
                    }
                }

                for (int i = 0, snu = 1; i < _dt_HareketDetay.Rows.Count; i++, snu++)
                {

                    //int SiraNu = _gvFaturaHareket.GetVisibleIndex(i) + 1;

                    //if (datarowIndex != i)
                    //  _dt_HareketDetay.Rows[i]["SatirNo"] = SiraNu;

                    //if (snu == MevcutSiraNumarasi && i != datarowIndex) // eğer verilecek sıra numarası
                    //{
                    //  snu++;
                    //}

                    //if (snu != MevcutSiraNumarasi && i != datarowIndex)
                    //{
                    //  _gvFaturaHareket.GetVisibleIndex(i);

                    //  _dt_HareketDetay.Rows[i]["SatirNo"] = snu;
                    //}
                    //else
                    //{
                    //  //i++;
                    //  //snu++;
                    //}
                }
            }

            #endregion

            //            if (e.Column == "KdvDahilFiyat")
            //            {
            ////_dt_HareketDetay.Rows[datarowIndex]["AnaBirimFiyat"] = Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["AltBirimMiktar"]) AnaBirimFiyat + ((Kdv * AnaBirimFiyat)/ 100)
            //            }

            bool IslemYapilanKolonlardanBiriDegisti = false;
            //özellik terazide falan filan
            if (e.Column.Caption == "Miktar" || e.Column.FieldName.StartsWith("StokIskonto") || e.Column.FieldName.StartsWith("CariIskonto") || e.Column.FieldName == "AltBirimMiktar"
                || e.Column.Caption == "Iskonto %" || e.Column.Caption == "FireMiktari" || e.Column.Caption == "Kdv") // iskonto yüzde sadece terazide kullanılıyor aslında değiştirilmesi lazım stokiskonto1 den alıyor
            {
                IslemYapilanKolonlardanBiriDegisti = true;
            }

            if (e.Column.Caption == "AltBirimMiktar")
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["Miktar"] = Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["AltBirimMiktar"]) * Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["KatSayi"]);
            }

            else if (e.Column.Caption == "Toplam")
            {
                if (MessageBox.Show("Yes e basarsan miktarı\nhayır a basarsan fiyatı değiştitir", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    IslemYapilanKolonlardanBiriDegisti = true;
                    _dt_HareketDetay.Rows[datarowIndex]["Miktar"] = Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["Toplam"]) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["AnaBirimFiyat"]);
                }
                else
                {
                    IslemYapilanKolonlardanBiriDegisti = true;
                    _dt_HareketDetay.Rows[datarowIndex]["AnaBirimFiyat"] = Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["Toplam"]) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["Miktar"]);
                }
            }

            else if (e.Column.Caption == "AnaBirimFiyat")
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["Birim2Fiyat"] = Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["AnaBirimFiyat"]) * Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["KatSayi"]);
            }

            else if (e.Column.FieldName == "Birim2Fiyat")
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["AnaBirimFiyat"] = Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["Birim2Fiyat"]) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["KatSayi"]);
            }


            else if (e.Column.FieldName == "StokIskonto1Tutari") // buradan verilern tutardan yüzde bulup yüzdeyi yazıcaz çünkü satirhesaplamasında Yüzdeden hesaplıyor
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["StokIskonto1"] = (Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["StokIskonto1Tutari"]) * 100) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["Toplam"]);
            }
            else if (e.Column.FieldName == "StokIskonto2Tutari") // buradan verilern tutardan yüzde bulup yüzdeyi yazıcaz çünkü satirhesaplamasında Yüzdeden hesaplıyor
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["StokIskonto2"] = (Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["StokIskonto2Tutari"]) * 100) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["StokIskonto1SonrasiTutar"]);
            }
            else if (e.Column.FieldName == "StokIskonto3Tutari") // buradan verilern tutardan yüzde bulup yüzdeyi yazıcaz çünkü satirhesaplamasında Yüzdeden hesaplıyor
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["StokIskonto3"] = (Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["StokIskonto3Tutari"]) * 100) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["StokIskonto2SonrasiTutar"]);
            }
            else if (e.Column.FieldName == "CariIskonto1Tutari") // buradan verilern tutardan yüzde bulup yüzdeyi yazıcaz çünkü satirhesaplamasında Yüzdeden hesaplıyor
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["CariIskonto1"] = (Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["CariIskonto1Tutari"]) * 100) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["Toplam"]);
            }
            else if (e.Column.FieldName == "CariIskonto2Tutari") // buradan verilern tutardan yüzde bulup yüzdeyi yazıcaz çünkü satirhesaplamasında Yüzdeden hesaplıyor
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["CariIskonto2"] = (Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["CariIskonto2Tutari"]) * 100) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["CariIskonto1SonrasiTutar"]);
            }
            else if (e.Column.FieldName == "CariIskonto3Tutari") // buradan verilern tutardan yüzde bulup yüzdeyi yazıcaz çünkü satirhesaplamasında Yüzdeden hesaplıyor
            {
                IslemYapilanKolonlardanBiriDegisti = true;
                _dt_HareketDetay.Rows[datarowIndex]["CariIskonto3"] = (Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["CariIskonto3Tutari"]) * 100) / Convert.ToDecimal(_dt_HareketDetay.Rows[datarowIndex]["CariIskonto2SonrasiTutar"]);
            }

            if (IslemYapilanKolonlardanBiriDegisti == true)
                SatirHesaplamasi(_gvFaturaHareket.GetDataRow(e.RowHandle));
        }

        public DataTable dt_kdv;
        private void KdvTablosunuOlustur()
        {
            dt_kdv = new DataTable("Kdv Detayları");
            dt_kdv.Columns.Add("Kdv", System.Type.GetType("System.Decimal"));
            dt_kdv.Columns.Add("KdvTutari", System.Type.GetType("System.Decimal"));
        }

        private DataTable KdvDetayHesapla()
        {
            try
            {
                var categories =
            from row in _dt_HareketDetay.AsEnumerable()
            where row.RowState != DataRowState.Deleted && (int)row["StokID"] != -1 // Silinen Satırı ve Birleşik Ürunun Detaylarını kdv hesaplamasında kullanma (Stok IDsi -1 olanlar birleşik ürün oluyor.)
            group row by row["Kdv"] into g
            select new { Kdv = g.Key, KdvTutari = g.Sum(p => Convert.ToDecimal((p["KdvTutari"]).ToString())) };

                dt_kdv.Rows.Clear();

                foreach (var item in categories)
                {
                    //categories.
                    //if (
                    //if (((DataRow)item).RowState != DataRowState.Deleted)
                    {
                        dt_kdv.Rows.Add(dt_kdv.NewRow());
                        dt_kdv.Rows[dt_kdv.Rows.Count - 1]["KdvTutari"] = item.KdvTutari;
                        dt_kdv.Rows[dt_kdv.Rows.Count - 1]["Kdv"] = item.Kdv;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("kdv hesaplamasında hata hamısına");
            }
            return dt_kdv;
        }

        public void SatirHesaplamasi(DataRow Dr) // burası sadece AnaBirimFiyat ve Miktar ı baz alarak hesaplıyor bunların dışında bir kolon da değişiklik yapılırsa burada işe yaramaz
        {
            try
            {
                //if ((int)Dr["StokID"] == -2)
                //{
                if (Dr == null || Dr.RowState == DataRowState.Deleted)
                    return;

                //    return;
                //}
                _gvFaturaHareket.RefreshRow(_gvFaturaHareket.FocusedRowHandle);// niye burada refresh yapıyoruz?? açıklama yaz

                // Miktar veya fiyat 0 gelirse Toplam da sıfır olur bölme işlemlerinde hataya neden olabiliryor

                Dr["Toplam"] = Convert.ToDecimal(Dr["AnaBirimFiyat"]) * Convert.ToDecimal(Dr["Miktar"]);
                Dr["Birim2Fiyat"] = Convert.ToDecimal(Dr["AnaBirimFiyat"]) * Convert.ToDecimal(Dr["KatSayi"]);
                Dr["AltBirimMiktar"] = Convert.ToDecimal(Dr["Miktar"]) / Convert.ToDecimal(Dr["KatSayi"]);

                // bu hesaplama ile ilgili açıklama lazım
                decimal StokiskontoTutari1 = ((Convert.ToDecimal(Dr["StokIskonto1"]) * Convert.ToDecimal(Dr["Toplam"])) / 100);
                decimal StokiskontoTutari1SonrasiTutar = Convert.ToDecimal(Dr["Toplam"]) - StokiskontoTutari1;
                decimal StokIskonto1Miktari = (Convert.ToDecimal(Dr["AnaBirimFiyat"]) * Convert.ToDecimal(Dr["StokIskonto1"]) / 100); // 10 lira normal fiyatı olan bir ürüne % 10 iskonto uygulandığında fiyatı 9 li ra olur => iskontomiktarı ise 1 liradır. // bu alan veribananında kayıtlı değil
                decimal StokIskoto1SonrasiFiyat = Convert.ToDecimal(Dr["AnaBirimFiyat"]) - StokIskonto1Miktari; // bu alan veritabnında kayıtlı değil

                decimal StokiskontoTutari2 = ((Convert.ToDecimal(Dr["StokIskonto2"]) * StokiskontoTutari1SonrasiTutar) / 100);
                decimal StokiskontoTutari2SonrasiTutar = StokiskontoTutari1SonrasiTutar - StokiskontoTutari2;
                decimal StokIskonto2Miktari = StokIskoto1SonrasiFiyat * Convert.ToDecimal(Dr["StokIskonto2"]) / 100; // 10 lira normal fiyatı olan bir ürüne % 10 iskonto uygulandığında fiyatı 9 li ra olur => iskontomiktarı ise 1 liradır.
                decimal StokIskoto2SonrasiFiyat = StokIskoto1SonrasiFiyat - StokIskonto2Miktari; // bu alan veri tabanını da kayıtlı değil


                decimal StokiskontoTutari3 = ((Convert.ToDecimal(Dr["StokIskonto3"]) * StokiskontoTutari2SonrasiTutar) / 100);
                decimal StokiskontoTutari3SonrasiTutar = StokiskontoTutari2SonrasiTutar - StokiskontoTutari3;
                decimal StokIskonto3Miktari = StokIskoto2SonrasiFiyat * Convert.ToDecimal(Dr["StokIskonto3"]) / 100; // 10 lira normal fiyatı olan bir ürüne % 10 iskonto uygulandığında fiyatı 9 li ra olur => iskontomiktarı ise 1 liradır.
                decimal StokIskoto3SonrasiFiyat = StokIskoto2SonrasiFiyat - StokIskonto3Miktari; // bu alan veri tabanını da kayıtlı değil


                decimal CariiskontoTutari1 = ((Convert.ToDecimal(Dr["CariIskonto1"]) * Convert.ToDecimal(Dr["Toplam"])) / 100);
                decimal CariiskontoTutari1SonrasiTutar = Convert.ToDecimal(Dr["Toplam"]) - CariiskontoTutari1;
                decimal CariIskonto1Miktari = (Convert.ToDecimal(Dr["AnaBirimFiyat"]) * Convert.ToDecimal(Dr["CariIskonto1"]) / 100); // 10 lira normal fiyatı olan bir ürüne % 10 iskonto uygulandığında fiyatı 9 li ra olur => iskontomiktarı ise 1 liradır.
                decimal CariIskoto1SonrasiFiyat = Convert.ToDecimal(Dr["AnaBirimFiyat"]) - CariIskonto1Miktari; // bu alan veri tabanını da kayıtlı değil

                decimal CariiskontoTutari2 = ((Convert.ToDecimal(Dr["CariIskonto2"]) * CariiskontoTutari1SonrasiTutar) / 100);
                decimal CariiskontoTutari2SonrasiTutar = CariiskontoTutari1SonrasiTutar - CariiskontoTutari2;
                decimal CariIskonto2Miktari = CariIskoto1SonrasiFiyat * Convert.ToDecimal(Dr["CariIskonto2"]) / 100; // 10 lira normal fiyatı olan bir ürüne % 10 iskonto uygulandığında fiyatı 9 li ra olur => iskontomiktarı ise 1 liradır.
                decimal CariIskonto2SonrasiFiyat = CariIskoto1SonrasiFiyat - CariIskonto2Miktari; // bu alan veri tabanını da kayıtlı değil

                decimal CariiskontoTutari3 = ((Convert.ToDecimal(Dr["CariIskonto3"]) * CariiskontoTutari2SonrasiTutar) / 100);
                decimal CariiskontoTutari3SonrasiTutar = CariiskontoTutari2SonrasiTutar - CariiskontoTutari3;
                decimal CariIskonto3Miktari = CariIskonto2SonrasiFiyat * Convert.ToDecimal(Dr["CariIskonto3"]) / 100; // 10 lira normal fiyatı olan bir ürüne % 10 iskonto uygulandığında fiyatı 9 li ra olur => iskontomiktarı ise 1 liradır.
                decimal CariISkonto3SonrasiFiyat = CariIskonto2SonrasiFiyat - CariIskonto3Miktari; // bu alan veri tabanını da kayıtlı değil

                Dr["StokIskonto1SonrasiTutar"] = StokiskontoTutari1SonrasiTutar;
                Dr["StokIskonto2SonrasiTutar"] = StokiskontoTutari2SonrasiTutar;
                Dr["StokIskonto3SonrasiTutar"] = StokiskontoTutari3SonrasiTutar;
                Dr["CariIskonto1SonrasiTutar"] = CariiskontoTutari1SonrasiTutar;
                Dr["CariIskonto2SonrasiTutar"] = CariiskontoTutari2SonrasiTutar;
                Dr["CariIskonto3SonrasiTutar"] = CariiskontoTutari3SonrasiTutar;

                Dr["StokIskonto1Tutari"] = StokiskontoTutari1;
                Dr["StokIskonto2Tutari"] = StokiskontoTutari2;
                Dr["StokIskonto3Tutari"] = StokiskontoTutari3;
                Dr["CariIskonto1Tutari"] = CariiskontoTutari1;
                Dr["CariIskonto2Tutari"] = CariiskontoTutari2;
                Dr["CariIskonto3Tutari"] = CariiskontoTutari3;





                Dr["StokToplamIskonto"] = StokiskontoTutari1 + StokiskontoTutari2 + StokiskontoTutari3;
                Dr["CariToplamIskonto"] = CariiskontoTutari1 + CariiskontoTutari2 + CariiskontoTutari3;
                Dr["ToplamIskonto"] = Convert.ToDecimal(Dr["CariToplamIskonto"]) + Convert.ToDecimal(Dr["StokToplamIskonto"]);

                // burada miktar 0 gelirse 0  a bölünemediğinden hata verebilir.
                //if (Convert.ToDecimal(Dr["Miktar"]) == 0)
                //{
                Dr["IskontoluFiyat"] = Convert.ToDecimal(Dr["AnaBirimFiyat"]) - StokIskonto1Miktari - StokIskonto2Miktari - StokIskonto3Miktari - CariIskonto1Miktari - CariIskonto2Miktari - CariIskonto3Miktari;
                //}
                //else
                //{
                //    Dr["IskontoluFiyat"] = Convert.ToDecimal(Dr["AnaBirimFiyat"]) - (Convert.ToDecimal(Dr["ToplamIskonto"]) / Convert.ToDecimal(Dr["Miktar"]));
                //}
                Dr["SatirIndirimliToplam"] = Convert.ToDecimal(Dr["IskontoluFiyat"]) * Convert.ToDecimal(Dr["Miktar"]);
                Dr["KdvTutari"] = Convert.ToDecimal(Dr["Miktar"]) * Convert.ToDecimal(Dr["Kdv"]) * Convert.ToDecimal(Dr["IskontoluFiyat"]) / 100;

                //Dr["KdvDahilFiyat"] = Convert.ToDecimal(Dr["AnaBirimFiyat"]) + ((Convert.ToDecimal(Dr["Kdv"]) * Convert.ToDecimal(Dr["AnaBirimFiyat"])) / 100);
                //Dr["KdvDahilToplam"] = Convert.ToDecimal(Dr["Toplam"]) + Convert.ToDecimal(Dr["KdvTutari"]);

                //IskontoDetayHesapla();

                //KdvDetayHesapla();

                //TODO: Test aşamasında burası ve burada kaldın
                if (_dt_HareketDetay.Columns.Contains("BirlesikUrunHareketID"))
                {
                    if (Convert.ToDecimal(Dr["BirlesikUrunHareketID"]) > 0) // eğer hesaplanan satır bir BirleşikÜrünün Alt ürünleriyse  --------   -2 ise Normal satır, -1 ise birleşik ürün, ID varsa Birleşik ürünün alt ürünü
                    {
                        decimal BirlesikUrunTutari = BirlesikUrununTutariniHesapla(Convert.ToInt32(Dr["BirlesikUrunHareketID"]));
                        _dt_HareketDetay.Select("FaturaHareketID = " + Dr["BirlesikUrunHareketID"].ToString())[0]["AnaBirimFiyat"] = BirlesikUrunTutari;
                        //_dt_HareketDetay.Select("FaturaHareketID = " + Dr["BirlesikUrunHareketID"].ToString())[0]["AnaBirimFiyat"] = ff;

                        SatirHesaplamasi(_dt_HareketDetay.Select("FaturaHareketID = " + Dr["BirlesikUrunHareketID"].ToString())[0]);  // Birleşik satırın satır hesaplamasını yeniden yapıyoruz
                    }
                    if (Convert.ToDecimal(Dr["BirlesikUrunHareketID"]) != -1)
                    {

                    }
                }
                AltToplamlariHesapla();
                //Kaydet_Vazgec_Sil_Enable(true);
            }
            catch (Exception hata)
            {
                //Tr.Rollback();
                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                //frmHataBildir.ShowDialog();
                MessageBox.Show("Satır hesaplamasında Hata oldu hamısına");
            }
        }

        public void AltToplamlariHesapla()
        {
            KdvDetayHesapla();
            IskontoDetayHesapla();

            Toplam_Iskontosuz_Kdvsiz = KolonVerTopliyim("Toplam"); // kdv ve iskonto hariç toplam

            CariIskontoToplami = KolonVerTopliyim("CariToplamIskonto");
            StokIskontoToplami = KolonVerTopliyim("StokToplamIskonto");
            ToplamIndirim = CariIskontoToplami + StokIskontoToplami;

            ToplamKdv = KolonVerTopliyim("KdvTutari");
            IskontoluToplam = Toplam_Iskontosuz_Kdvsiz - ToplamIndirim;

            FaturaTutari = ToplamKdv + IskontoluToplam;

            ToplamKdvDahilIndirimMiktari = KolonVerTopliyim("KdvDahilStokIskonto1IndirimMiktari");
            ToplamKdvDahilIndirimsizSatisTutari = ToplamKdvDahilIndirimMiktari + FaturaTutari;
            if (ToplamKdvDahilIndirimsizSatisTutari != 0)
                ToplamOrtalamIndirimYuzdesi = (1 - (FaturaTutari / ToplamKdvDahilIndirimsizSatisTutari));
            else
                ToplamOrtalamIndirimYuzdesi = 0;
            //colKdvDetay_KdvTutari

            if (AltToplamlarDegisti != null)
                AltToplamlarDegisti();
        }

        //        decimal KdvDahilIndirimUygulanmamisFaturaTutari()
        //        {
        //            decimal TumSatirlarinToplam_KdvDahilIndirimUygulanmamis = 0;
        //            decimal ToplamMiktar = 0;
        //            for (int i = 0; i < _gvFaturaHareket.RowCount; i++)
        //            {
        //                TumSatirlarinToplam_KdvDahilIndirimUygulanmamis +=
        //(Convert.ToDecimal(_gvFaturaHareket.GetRowCellValue(i, "AnaBirimFiyat")) +
        //(Convert.ToDecimal(_gvFaturaHareket.GetRowCellValue(i, "AnaBirimFiyat")) * Convert.ToDecimal(_gvFaturaHareket.GetRowCellValue(i, "Kdv")) / 100)) * Convert.ToDecimal(_gvFaturaHareket.GetRowCellValue(i, "Miktar"));

        //                ToplamMiktar += Convert.ToDecimal(_gvFaturaHareket.GetRowCellValue(i, "Miktar"));
        //            }

        //            return TumSatirlarinToplam_KdvDahilIndirimUygulanmamis;
        //        }

        private decimal KolonVerTopliyim(string KolonAdi) // alt toplamları hesaplarken buradan faydalandım
        {
            decimal Toplam = 0;
            if (_dt_HareketDetay.Columns.Contains("BirlesikUrunHareketID")) // eğer 
            {
                foreach (var item in _dt_HareketDetay.AsEnumerable().Where(s => s.RowState != DataRowState.Deleted))
                {
                    if (Convert.ToInt32(item["BirlesikUrunHareketID"]) != -1)
                        Toplam += Convert.ToDecimal(item[KolonAdi]);
                }
            }
            else
            {
                foreach (var item in _dt_HareketDetay.AsEnumerable().Where(s => s.RowState != DataRowState.Deleted))
                {
                    Toplam += Convert.ToDecimal(item[KolonAdi]);
                }
            }

            //for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
            //{
            //    try
            //    {
            //        if
            //            (_dt_HareketDetay.Rows[i].RowState != DataRowState.Deleted && Convert.ToInt32(_dt_HareketDetay.Rows[i]["BirlesikUrunHareketID"]) != -1) // Birleşik Urun detaylarını eklemiyoruz hamısına (BirleşikUrunHareketID si 0 dan büyükse birleşik ürünün Alt detayıdır alt detayı toplama katmıyoruz)
            //            Toplam += Convert.ToDecimal(_dt_HareketDetay.Rows[i][KolonAdi]);
            //    }
            //    catch (Exception)
            //    {


            //    }

            //}
            return Toplam;
        }

        public decimal BirlesikUrununTutariniHesapla(int BirlesikUrunHareketID)
        {
            try
            {
                decimal BirlesikUrununTutari = 0;
                for (int i = 0; i < _dt_HareketDetay.Select("BirlesikUrunHareketID = " + BirlesikUrunHareketID).Length; i++)
                {
                    BirlesikUrununTutari += Convert.ToDecimal(_dt_HareketDetay.Select("BirlesikUrunHareketID = " + BirlesikUrunHareketID.ToString())[i]["KdvDahilToplam"]);
                }
                return BirlesikUrununTutari;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        #region IskontoIslemleri

        /// <summary>
        /// Bir Kolonun Tüm Satırlarına bir decimal değer girmek içinde kullanılabilir.
        /// Bütün iskonto yüzde kolonları için kullanılabilir kolon adı verilerek
        /// </summary>
        /// <param name="IskontoOrani"></param>
        /// <param name="Kolonadi"></param>
        public void IskontoUgula(string Kolonadi)
        {
            try
            {
                if (_dt_HareketDetay.Rows.Count > 0)
                {
                    MiktarGirisi.textEdit1.EditValue = 0; //= new frmMiktarGir(0);
                    MiktarGirisi.labelControl1.Text = "Birinci Stok İskonto yüzdesini girin";
                    if (MiktarGirisi.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                        {
                            _gvFaturaHareket.SetRowCellValue(i, Kolonadi, Convert.ToDecimal(MiktarGirisi.textEdit1.Text));
                        }
                    }
                }
                else
                    MessageBox.Show("Hiç Stok Kaydı yok");
            }
            catch (Exception hata)
            {
                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                //frmHataBildir.ShowDialog();

                MessageBox.Show("Iskonto Uygulada hata var hamısına" + hata.Message);
            }
        }

        public void IskontoOranUygula(decimal IskontoOrani, string Kolonadi, bool KDVdahilFiyataMi)
        {
            try
            {
                if (_dt_HareketDetay.Rows.Count > 0)
                {
                    MiktarGirisi.textEdit1.EditValue = 0; //= new frmMiktarGir(0);
                    MiktarGirisi.labelControl1.Text = "Birinci Stok İskonto yüzdesini girin";
                    if (MiktarGirisi.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                        {
                            _gvFaturaHareket.SetRowCellValue(i, Kolonadi, Convert.ToDecimal(MiktarGirisi.textEdit1.Text));
                        }
                    }
                }
                else
                    MessageBox.Show("Hiç Stok Kaydı yok");
            }
            catch (Exception hata)
            {
                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                //frmHataBildir.ShowDialog();

                MessageBox.Show("Iskonto Uygulada hata var hamısına" + hata.Message);
            }
        }

        public void IskontoTutarUygula(decimal IskontoTutari, string Kolonadi)
        {
            try
            {
                if (_dt_HareketDetay.Rows.Count > 0)
                {
                    MiktarGirisi.textEdit1.EditValue = 0; //= new frmMiktarGir(0);
                    MiktarGirisi.labelControl1.Text = "Birinci Stok İskonto yüzdesini girin";
                    if (MiktarGirisi.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                        {
                            _gvFaturaHareket.SetRowCellValue(i, Kolonadi, Convert.ToDecimal(MiktarGirisi.textEdit1.Text));
                        }
                    }
                }
                else
                    MessageBox.Show("Hiç Stok Kaydı yok");
            }
            catch (Exception hata)
            {
                //frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                //frmHataBildir.ShowDialog();

                MessageBox.Show("Iskonto Uygulada hata var hamısına" + hata.Message);
            }
        }

        public DataTable dt_IskontoDetay;

        private void IskontoDetayTablosunuOlustur()
        {
            dt_IskontoDetay = new DataTable("İskonto Detayları");

            dt_IskontoDetay.Columns.Add("StokIskonto1");
            dt_IskontoDetay.Columns.Add("StokIskonto2");
            dt_IskontoDetay.Columns.Add("StokIskonto3");
            dt_IskontoDetay.Columns.Add("CariIskonto1");
            dt_IskontoDetay.Columns.Add("CariIskonto2");
            dt_IskontoDetay.Columns.Add("CariIskonto3");
            dt_IskontoDetay.Columns.Add("StokIskontoTutari");
            dt_IskontoDetay.Columns.Add("CariToplamIskonto");
            dt_IskontoDetay.Columns.Add("ToplamIskonto");
        }



        private void IskontoDetayHesapla()
        {
            var categories =
                      from row in _dt_HareketDetay.AsEnumerable()
                      where row.RowState != DataRowState.Deleted && row["BirlesikUrunHareketID"] == "" // Silinen Satırları ve Birleşik Ürünlerin alt detaylarını hesaba katmıyoruz
                      group row by new
                      {
                          StokIskonto1 = row["StokIskonto1"],
                          StokIskonto2 = row["StokIskonto2"],
                          StokIskonto3 = row["StokIskonto3"],
                          CariIskonto1 = row["CariIskonto1"],
                          CariIskonto2 = row["CariIskonto2"],
                          CariIskonto3 = row["CariIskonto3"]
                      } into g
                      select new
                      {
                          StokIskonto1 = g.Key.StokIskonto1,
                          StokIskonto2 = g.Key.StokIskonto2,
                          StokIskonto3 = g.Key.StokIskonto3,
                          CariIskonto1 = g.Key.CariIskonto1,
                          CariIskonto2 = g.Key.CariIskonto2,
                          CariIskonto3 = g.Key.CariIskonto3,
                          //CariToplamIskonto
                          StokIskontoTutari = g.Sum(p => Convert.ToDecimal(p["StokToplamIskonto"].ToString())),
                          CariToplamIskonto = g.Sum(p => Convert.ToDecimal((p["CariToplamIskonto"]).ToString())),
                          ToplamIskonto = g.Sum(p => Convert.ToDecimal((p["ToplamIskonto"]).ToString()))
                      };

            dt_IskontoDetay.Rows.Clear();
            foreach (var item in categories)
            {
                dt_IskontoDetay.Rows.Add(dt_IskontoDetay.NewRow());
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["StokIskonto1"] = item.StokIskonto1;
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["StokIskonto2"] = item.StokIskonto2;
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["StokIskonto3"] = item.StokIskonto3;
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["CariIskonto1"] = item.CariIskonto1;
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["CariIskonto2"] = item.CariIskonto2;
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["CariIskonto3"] = item.CariIskonto3;
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["StokIskontoTutari"] = item.StokIskontoTutari;
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["CariToplamIskonto"] = item.CariToplamIskonto;
                dt_IskontoDetay.Rows[dt_IskontoDetay.Rows.Count - 1]["ToplamIskonto"] = item.ToplamIskonto;
            }
        }

        public void StokIskonto1TutarGir()
        {
            if (_dt_HareketDetay.Rows.Count > 0)
            {
                frmMiktarGir frm = new frmMiktarGir(0, frmMiktarGir.SayiCinsi.Ondalikli);
                frm.labelControl1.Text = "Birinci Stok İskonto Tutarını girin";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal iskontoYuzdesi = (100 * Convert.ToDecimal(frm.textEdit1.Text)) / KolonVerTopliyim("Toplam");
                    for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                    {
                        _gvFaturaHareket.SetRowCellValue(i, "StokIskonto1", iskontoYuzdesi);
                    }
                }
            }
        }

        public void StokIskonto2TutarGir()
        {
            if (_dt_HareketDetay.Rows.Count > 0)
            {
                frmMiktarGir frm = new frmMiktarGir(0, frmMiktarGir.SayiCinsi.Ondalikli);
                frm.labelControl1.Text = "ikinci Stok İskonto Tutarını girin";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal iskontoYuzdesi = (100 * Convert.ToDecimal(frm.textEdit1.Text)) / KolonVerTopliyim("StokIskonto1SonrasiTutar");
                    for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                    {
                        _gvFaturaHareket.SetRowCellValue(i, "StokIskonto2", iskontoYuzdesi);
                    }
                }
            }
        }

        public void StokIskonto3TutarGir()
        {
            if (_dt_HareketDetay.Rows.Count > 0)
            {
                frmMiktarGir frm = new frmMiktarGir(0, frmMiktarGir.SayiCinsi.Ondalikli);
                frm.labelControl1.Text = "Üçüncü Stok İskonto Tutarını girin";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal iskontoYuzdesi = (100 * Convert.ToDecimal(frm.textEdit1.Text)) / KolonVerTopliyim("StokIskonto2SonrasiTutar");
                    for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                    {
                        _gvFaturaHareket.SetRowCellValue(i, "StokIskonto3", iskontoYuzdesi);
                    }
                }
            }
        }

        public void CariIskonto1TutarGir()
        {
            if (_dt_HareketDetay.Rows.Count > 0)
            {
                frmMiktarGir frm = new frmMiktarGir(0, frmMiktarGir.SayiCinsi.Ondalikli);
                frm.labelControl1.Text = "Birinci Cari İskonto Tutarını girin";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal iskontoYuzdesi = (100 * Convert.ToDecimal(frm.textEdit1.Text)) / KolonVerTopliyim("Toplam");
                    for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                    {
                        _gvFaturaHareket.SetRowCellValue(i, "CariIskonto1", iskontoYuzdesi);
                    }
                }
            }
        }

        public void CariIskonto2TutarGir()
        {
            if (_dt_HareketDetay.Rows.Count > 0)
            {
                frmMiktarGir frm = new frmMiktarGir(0, frmMiktarGir.SayiCinsi.Ondalikli);
                frm.labelControl1.Text = "Birinci Cari İskonto Tutarını girin";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal iskontoYuzdesi = (100 * Convert.ToDecimal(frm.textEdit1.Text)) / KolonVerTopliyim("CariIskonto1SonrasiTutar");
                    for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                    {
                        _gvFaturaHareket.SetRowCellValue(i, "CariIskonto2", iskontoYuzdesi);
                    }
                }
            }
        }

        public void CariIskonto3TutarGir()
        {
            if (_dt_HareketDetay.Rows.Count > 0)
            {
                frmMiktarGir frm = new frmMiktarGir(0, frmMiktarGir.SayiCinsi.Ondalikli);
                frm.labelControl1.Text = "Birinci Cari İskonto Tutarını girin";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal iskontoYuzdesi = (100 * Convert.ToDecimal(frm.textEdit1.Text)) / KolonVerTopliyim("CariIskonto2SonrasiTutar");
                    for (int i = 0; i < _dt_HareketDetay.Rows.Count; i++)
                    {
                        _gvFaturaHareket.SetRowCellValue(i, "CariIskonto3", iskontoYuzdesi);
                    }
                }
            }
        }


        public void ToplamFaturaTutariGirerekISkontoUygula(Form frm)
        {
            using (clsTablolar.frmMiktarGir frmMiktar = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
            {
                frmMiktar.labelControl1.Text = "Aktif satışın Istenilen Satis Tutarına ulaşması için indirim uygula \nDaha Sonra eklenen Stokları etkilemez.\n0 Girilirse Tüm Ürünlere %100 iskonto uygulanmış olur\n";
                if (frm.ShowDialog(frm) == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal TumSatirlarinToplam_KdvDahilIndirimUygulanmamis = ToplamKdvDahilIndirimsizSatisTutari;

                    decimal IndirimYuzdesi = ((100 * (TumSatirlarinToplam_KdvDahilIndirimUygulanmamis - Convert.ToDecimal(frmMiktar.textEdit1.EditValue))) / TumSatirlarinToplam_KdvDahilIndirimUygulanmamis);
                    for (int i = 0; i < _gvFaturaHareket.RowCount; i++)
                    {
                        _gvFaturaHareket.SetRowCellValue(i, "StokIskonto1", IndirimYuzdesi);
                    }
                }
            }
        }

        #endregion


        #region Fiyat ( Yukselt, Dusur, ), Kdv Çıkar, Kdv Değiştir
        public void FiyattanKdvCikar(DataRow dr)
        {
            decimal KdvSizFiyat = Convert.ToDecimal(dr["AnaBirimFiyat"]) / ((100 + Convert.ToDecimal(dr["Kdv"])) / 100);
            {
                if (MessageBox.Show(dr["AnaBirimFiyat"].ToString() + " Fiyattan \n " + dr["Kdv"] + " oranı Çıkacak\n" + KdvSizFiyat.ToString() + " yazılacak", "Kdv yi Çıkart ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dr["AnaBirimFiyat"] = KdvSizFiyat;
                    _gvFaturaHareket.EditingValue = KdvSizFiyat;
                    SatirHesaplamasi(dr);
                }
            }
        }

        public void FiyatYukselt()
        {
            MiktarGirisi.textEdit1.EditValue = 0;
            MiktarGirisi.labelControl1.Text = "Yazılan Yüzde kadar Fiyatı Yükseltir.";
            if (DialogResult.Yes == MiktarGirisi.ShowDialog())
            {
                for (int i = 0; i < _gvFaturaHareket.RowCount; i++)
                {
                    decimal EskiFiyat = (decimal)_gvFaturaHareket.GetRowCellValue(i, "AnaBirimFiyat");
                    decimal YeniFiyat = EskiFiyat + (EskiFiyat * Convert.ToDecimal(MiktarGirisi.textEdit1.EditValue) / 100);
                    _gvFaturaHareket.SetRowCellValue(i, "AnaBirimFiyat", YeniFiyat);
                }
            }
        }

        public void FiyatDusur()
        {
            MiktarGirisi.textEdit1.EditValue = 0;
            MiktarGirisi.labelControl1.Text = "Yazılan Yüzde kadar Fiyatı Düşürür.";
            if (DialogResult.Yes == MiktarGirisi.ShowDialog())
            {
                for (int i = 0; i < _gvFaturaHareket.RowCount; i++)
                {
                    decimal EskiFiyat = (decimal)_gvFaturaHareket.GetRowCellValue(i, "AnaBirimFiyat");
                    decimal YeniFiyat = EskiFiyat - (EskiFiyat * Convert.ToDecimal(MiktarGirisi.textEdit1.EditValue) / 100);
                    _gvFaturaHareket.SetRowCellValue(i, "AnaBirimFiyat", YeniFiyat);
                }
            }
        }

        public void KDVDegistir()
        {
            MiktarGirisi.textEdit1.EditValue = 0;
            MiktarGirisi.labelControl1.Text = "KDV yüzdesini değiştirir.";
            if (DialogResult.Yes == MiktarGirisi.ShowDialog())
            {
                for (int i = 0; i < _gvFaturaHareket.RowCount; i++)
                {
                    _gvFaturaHareket.SetRowCellValue(i, "Kdv", Convert.ToDecimal(MiktarGirisi.textEdit1.EditValue));
                }
            }
        }

        #endregion

    }
}
