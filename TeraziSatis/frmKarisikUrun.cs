using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace TeraziSatis
{
    public partial class frmKarisikUrun : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// HareketID ne içinde onu yaz
        /// </summary>
        /// <param name="OncekiTeraziFormu"></param>
        /// <param name="HareketID"></param>
        public frmKarisikUrun(frmTerazi OncekiTeraziFormu, int HareketID)
        {
            HarID = HareketID;
            this.OncekiTeraziFormu = OncekiTeraziFormu;
            InitializeComponent();
        }


        frmTerazi OncekiTeraziFormu;
        //csStokAramaIslemleri GrupButonlari;
        clsTablolar.TeraziSatisClaslari.csStok Stok = new clsTablolar.TeraziSatisClaslari.csStok();

        SqlTransaction TrGenel;

        int HarID;
        public int BirlesikUrunDatarowIndex;
        public FormState formState = new FormState();
        private void frmKarisikUrun_Load(object sender, EventArgs e)
        {
            formState.Maximize(this);

            //this.flpGrupButonlari = OncekiTeraziFormu.flpGrupButonlari.cont;
            OncekiTeraziFormu.KarisikUrunFormuAcik = true;
            OncekiTeraziFormu.gvSatisHareketleri.ActiveFilterEnabled = false;


            gridControl1.DataSource = OncekiTeraziFormu.gvSatisHareketleri.DataSource;

            gridView1.CellValueChanged += OncekiTeraziFormu.Hesapla._gvFaturaHareket_CellValueChanged;
            //GrupButonlari = new csStokButonGruplari();
            //GrupButonlari.StokButonGruplariniGetir(SqlConnections.GetBaglanti(), TrGenel, TeraziSatis.Properties.Settings.Default.TeraziID);

            //flpGrupButonlari.Controls.Clear();

            //foreach (var item in GrupButonlari.StokButonGruplariListesi)
            //{
            //    flpGrupButonlari.Controls.Add(item.Btn);
            //    item.Btn.Click += GrupButon_Click; // buraya tıklandığında o gruba ait olan stokButonlari Gelecek
            //}

            gridView1.Columns["BirlesikUrunHareketID"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            DevExpress.Data.Filtering.CriteriaOperatorCollection kriter = new DevExpress.Data.Filtering.CriteriaOperatorCollection();


            if (HarID == -1) // -1 ise yeni bir hareket ekleyip bu hareketi kaydedip
            {
                OncekiTeraziFormu.StokEkle(-1);
                OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows.Count - 1, "Miktar", 1);
                OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows.Count - 1, "FaturaHareketStokAdi", "Birleşik Ürün");
                OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows.Count - 1, "BirlesikUrunHareketID", -1);

                //OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows.Count - 1, "Miktar", 1);
                HarID = (int)OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows[OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["FaturaHareketID"];

                // burada doğru bir atama yapabildiğimden emin olamadım
                BirlesikUrunDatarowIndex = (int)gridView1.GetDataSourceRowIndex(OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows.Count - 1);
            }
            else
            {
                //OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Select("");
                //BirlesikUrunDatarowIndex = (int)OncekiTeraziFormu.gvSatisHareketleri.GetFocusedDataSourceRowIndex();
            }

            gridView1.ActiveFilterEnabled = true;
            gridView1.ActiveFilterString = "[BirlesikUrunHareketID] = " + HarID;

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            //this.stokButonGrupVeStokButonlari1 = OncekiTeraziFormu.stokButonGrupVeStokButonlari1;

            stokButonGrupVeStokButonlari1.AhandaBudur(SqlConnections.GetBaglanti(), TrGenel, Properties.Settings.Default.TeraziID);
            stokButonGrupVeStokButonlari1.StokButonuTikildatiginda = StokButonu_Click;

            OncekiTeraziFormu.txtTerazidekiMiktari.EditValueChanged += txtTerazidekiMiktari_EditValueChanged;
            //OncekiTeraziFormu.txtTerazidenGelenSabitMiktar.EditValueChanged += txtTerazidenGelenSabitMiktar_EditValueChanged;
            OncekiTeraziFormu.cbtnTerazidekiSabitMiktariStokaAktar.CheckedChanged += onveciTEraziFormu_cbtnTerazidekiSabitMiktariStokaAktar_CheckedChanged;
            OncekiTeraziFormu.txtDaraMiktari.EditValueChanged += onveciTEraziFormu_txtDaraMiktari_EditValueChanged;
            //OncekiTeraziFormu.gvSatisHareketleri.CellValueChanged += gvSatisHareketleri_CellValueChanged;

            TrGenel.Commit();

            txtTerazidekiMiktari_EditValueChanged(null, null);
            txtTerazidenGelenSabitMiktar_EditValueChanged(null, null);
            // eğer verilen hareket ID -1 ise yeni bir hareket ekleyip bu hareketi kaydedip bu hareketin ID sine göre filtreleme yapmalı


            //Bu birleşik ürün hareketini ekliyor





            txtBirlesikUrunAdi.EditValue = OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows[BirlesikUrunDatarowIndex]["FaturaHareketStokAdi"];

            txtBirlesikUrununToplamFiyati.EditValue
                = Convert.ToDecimal(OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Select("FaturaHareketID = " + HarID)[0]["KdvDahilToplam"]);

            BinleHamisina();
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged; // bunun burada olması lazım
            gridView1_FocusedRowChanged(null, null);

            OncekiTeraziFormu.Hesapla.AltToplamlarDegisti += Alttoplam;
            Alttoplam();
        }

        void Alttoplam()
        {
            txtBirlesikUrununToplamFiyati.EditValue = OncekiTeraziFormu.Hesapla.BirlesikUrununTutariniHesapla(HarID);

            KarisikUrununToplamMiktariniVer();
        }

        private void onveciTEraziFormu_txtDaraMiktari_EditValueChanged(object sender, EventArgs e)
        {
            txtDaraMiktari.EditValue = OncekiTeraziFormu.txtDaraMiktari.EditValue;
        }

        void txtDaraMiktari_EditValueChanged(object sender, EventArgs e)
        {

        }

        void BinleHamisina()
        {
            txtStokAdi.DataBindings.Clear();
            txtMiktari.DataBindings.Clear();
            txtKdvDahilFiyati.DataBindings.Clear();
            txtTutari.DataBindings.Clear();
            txtFireMiktari.DataBindings.Clear();

            txtStokAdi.DataBindings.Add("EditValue", gridControl1.DataSource, "FaturaHareketStokAdi");
            txtMiktari.DataBindings.Add("EditValue", gridControl1.DataSource, "Miktar", false, DataSourceUpdateMode.OnPropertyChanged);
            txtKdvDahilFiyati.DataBindings.Add("EditValue", gridControl1.DataSource, "KdvDahilFiyat");
            txtTutari.DataBindings.Add("EditValue", gridControl1.DataSource, "KdvDahilToplam");
            txtFireMiktari.DataBindings.Add("EditValue", gridControl1.DataSource, "FireMiktari");



            //txtBirlesikUrununToplamFiyati.DataBindings.Add("EditValue", ((DataTable)(OncekiTeraziFormu.gcSatisHareketleri.DataSource)).Rows[BirlesikUrunDatarowIndex], "KdvDahilToplam");
        }



        void txtTerazidenGelenSabitMiktar_EditValueChanged(object sender, EventArgs e)
        {
            //txtTerazidenGelenSabitMiktar.EditValue = OncekiTeraziFormu.txtTerazidenGelenSabitMiktar.EditValue;
        }

        void txtTerazidekiMiktari_EditValueChanged(object sender, EventArgs e)
        {
            txtTerazidekiMiktari.EditValue = OncekiTeraziFormu.txtTerazidekiMiktari.EditValue;
        }


        // dinamik oluşturulan stok butonunun yapacağı işler hamısına
        //Birleşik Ürünün Alt hareketleri

        void StokButonu_Click(clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi BTipi, int StokID)
        {
            if (BTipi != clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari.ButonTipi.StokButonu)
            {
                return;
            }
            int SatirSayisi = OncekiTeraziFormu.gvSatisHareketleri.RowCount; // Eğer düzgün bir şelkilde ürün bulunup eklenirse gridteki miktarın 1 artması gerekmekte tabi başka bilgisayarlardan yapılan müdahaleleri önlemek için nu ekran açılırken satislardaki thread i durdurmak lazım
            OncekiTeraziFormu.StokEkle(StokID);

            if (SatirSayisi == OncekiTeraziFormu.gvSatisHareketleri.RowCount - 1)// Eğer düzgün bir şelkilde ürün bulunup eklenirse gridteki miktarın 1 artması gerekmekte
            {
                OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.gvSatisHareketleri.RowCount - 1, colMiktar, txtTerazidenGelenSabitMiktar.EditValue);
                OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.gvSatisHareketleri.RowCount - 1, colBirlesikUrunHareketID, HarID);
            }
            if (checkEdit4.Checked == true && Convert.ToDecimal(txtTerazidenGelenSabitMiktar.EditValue) != Convert.ToDecimal(0))
            {
                btnDaraAl_Click(null, null);
            }

            gridView1.Focus();
            gridView1.MoveLast();
            gridView1_FocusedRowChanged(null, null);
            //OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows[OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["BirlesikUrunHareketID"] = HarID;

            //gridView1.SetFocusedRowCellValue(colBirlesikUrunHareketID, HarID);
            //gridView1.SetRowCellValue(gridView1.RowCount - 1, colBirlesikUrunHareketID, HarID);



            //gridView1.SetRowCellValue(gridView1.RowCount - 1, colMiktar, Convert.ToDecimal(txtTerazidenGelenSabitMiktar.EditValue));
            //gridView1.SetFocusedRowCellValue(colMiktar, Convert.ToDecimal(txtTerazidenGelenSabitMiktar.EditValue));
            //OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows[OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Rows.Count - 1]["Miktar"] = txtTerazidenGelenSabitMiktar.EditValue;
            //OncekiTeraziFormu.Hesapla.SatirHesaplamasi(gridView1.GetFocusedDataRow());
        }


        private void btnStoklarinToplamFiyatiniBelirle_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0)
            {
                clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0);
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    try
                    {
                        if (!gridView1.IsMultiSelect) // grid de multi select aktif değilse tüm satırlara uygula işlemi
                        {
                            gridView1.OptionsSelection.MultiSelect = true;
                            gridView1.SelectAll();
                        }
                        decimal UrunlerinKiloFiyatToplamlari = 0;
                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            UrunlerinKiloFiyatToplamlari += (decimal)gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colKdvDahilFiyat);
                        }

                        // TO DO: Burada bir hata var formdan direk toplam miktarı alıyor ama toplam miktarı bu aşamada almaması lazım
                        //txtBirlesikUrununToplamFiyati.EditValue = frm.textEdit1.EditValue; // burada girilen değer decimal olmalı bunun kontrolünü yaptır
                        decimal UrunlerinMiktarlari = Convert.ToDecimal(frm.textEdit1.EditValue) / UrunlerinKiloFiyatToplamlari; // girilen toplam fiyat a toplam kilo fiyatlarını bölüyoruz

                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            int sourceindex = gridView1.GetDataSourceRowIndex(gridView1.GetSelectedRows()[i]);
                            OncekiTeraziFormu.KaydedileBilirMi = false;
                            OncekiTeraziFormu.MiktarGir(sourceindex, UrunlerinMiktarlari, false);
                            gridView1.UpdateCurrentRow();
                        }
                        if (gridView1.IsMultiSelect && cbtnCokluSecim.Checked == false) // grid de multi select aktif değilse tüm satırlara uygula işlemi
                        {
                            gridView1.OptionsSelection.MultiSelect = false;
                            lblSeciliHareketMiktari.Text = gridView1.SelectedRowsCount.ToString() + " adet Seçili";
                        }
                        KarisikUrununToplamMiktariniVer();
                    }
                    catch (Exception hata)
                    {
                        throw;
                    }
                    finally
                    {
                        OncekiTeraziFormu.KaydedileBilirMi = true;
                        OncekiTeraziFormu.btnKaydet_Click(null, null);
                    }
                }
            }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            //string BirlesikUrununAdi = "";
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{

            //}

            if (gridView1.RowCount == 0) // Eğer hiç satış ta bişi yoksa birleşik ürünü silsin
            {
                OncekiTeraziFormu.gvSatisHareketleri.DeleteRow(OncekiTeraziFormu.gvSatisHareketleri.GetRowHandle(BirlesikUrunDatarowIndex));
                OncekiTeraziFormu.Hesapla.AltToplamlariHesapla();
            }
            else
                OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.gvSatisHareketleri.GetRowHandle(BirlesikUrunDatarowIndex), "FaturaHareketStokAdi", "Özel Karışım");

            Close();
        }

        private void btnMiktarGir_Click(object sender, EventArgs e)
        {
            OncekiTeraziFormu.btnMiktarGir_Click(null, null);
        }

        private void btnTutarGir_Click(object sender, EventArgs e)
        {
            OncekiTeraziFormu.btnTutarGir_Click(null, null);
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //OncekiTeraziFormu.gvSatisHareketleri

            //OncekiTeraziFormu.btnKaydet.Enabled = true;
            //OncekiTeraziFormu.gvSatisHareketleri.UpdateCurrentRow();
            //OncekiTeraziFormu.gvSatislar_CellValueChanged(null, null);
            //decimal BirlesikUrununTutari = 0;
            //for (int i = 0; i < OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Select("BirlesikUrunHareketID = " + HarID).Length; i++)
            //{
            //    //BirlesikUrununTutari += Convert.ToDecimal(OncekiTeraziFormu.Hareketler.dt_FaturaHareketleri.Select("BirlesikUrunHareketID = " + HarID.ToString())[i]["SatirIndirimliToplam"]);
            //}
            //((DataRow)gridView1.GetRow(gridView1.GetRowHandle(BirlesikUrunDatarowIndex)))["AnaBirimFiyat"] = BirlesikUrununTutari;
            //return BirlesikUrununTutari;
            if (e.Column == colMiktar)
            {
                //KarisikUrununToplamMiktariniVer();
            }
        }

        private void frmKarisikUrun_FormClosed(object sender, FormClosedEventArgs e)
        {
            OncekiTeraziFormu.gvSatisHareketleri.ActiveFilterEnabled = true;
            OncekiTeraziFormu.KarisikUrunFormuAcik = false;
        }

        private void btnStoklarinToplamMiktariniBelirle_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount != 0)
                {
                    clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0);

                    if (DialogResult.Yes == frm.ShowDialog())
                    {
                        if (!gridView1.IsMultiSelect) // grid de multi select aktif değilse tüm satırlara uygula işlemi
                        {
                            gridView1.OptionsSelection.MultiSelect = true;
                            gridView1.SelectAll();
                        }
                        decimal TekUruneDusenMiktar = Convert.ToDecimal(frm.textEdit1.EditValue) / Convert.ToDecimal(gridView1.SelectedRowsCount);


                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            int sourceindex = gridView1.GetDataSourceRowIndex(gridView1.GetSelectedRows()[i]); // Seçili satırın rowhandle ından source index ini bulduk
                            int handle = OncekiTeraziFormu.gvSatisHareketleri.GetRowHandle(sourceindex);
                            OncekiTeraziFormu.KaydedileBilirMi = false;
                            OncekiTeraziFormu.MiktarGir(handle, TekUruneDusenMiktar, false);
                            gridView1.UpdateCurrentRow();
                        }
                        if (gridView1.OptionsSelection.MultiSelect == true && cbtnCokluSecim.Checked == false)
                        {
                            gridView1.OptionsSelection.MultiSelect = false;
                            lblSeciliHareketMiktari.Text = gridView1.SelectedRowsCount.ToString() + " adet Seçili";
                        }
                        gridView1.UpdateCurrentRow();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Toplam Miktar da hata var mk");
            }
            finally
            {
                OncekiTeraziFormu.KaydedileBilirMi = true;
                OncekiTeraziFormu.btnKaydet_Click(null, null);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int datarowindexx = gridView1.GetFocusedDataSourceRowIndex();
            int rowhandlee = OncekiTeraziFormu.gvSatisHareketleri.GetRowHandle(datarowindexx);
            OncekiTeraziFormu.gvSatisHareketleri.FocusedRowHandle = rowhandlee;

            KarisikUrununToplamMiktariniVer();
        }

        private void cbtnCokluSecim_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtnCokluSecim.Checked == true)
            {
                gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                gridView1.OptionsSelection.MultiSelect = true;
                btnStoklarinToplamMiktariniBelirle.Text = "Seçili Ürünlerin Toplam Miktarlarını Belirle";
                btnStoklarinToplanFiyatiniBelirle.Text = "Seçili Ürünlerin Toplam Fiyatını Belirle";
            }
            else
            {
                gridView1.OptionsSelection.MultiSelect = false;
                lblSeciliHareketMiktari.Text = gridView1.SelectedRowsCount.ToString() + " adet Seçili";
                btnStoklarinToplamMiktariniBelirle.Text = "Listedeki Tüm Ürünlerin Toplam Miktarını Belirle";
                btnStoklarinToplanFiyatiniBelirle.Text = "Listedeki Tüm Ürünlerin Toplam Fiyatını Belirle";
            }

        }

        private void btnUrunuCikart_Click(object sender, EventArgs e)
        {
            // aslında bütün işlemler diğer ekranda yapılıyor yani hamısına
            if (gridView1.IsMultiSelect)
            {
                MessageBox.Show("Çoklu seçimdeyken silme");
                return;
            }
            if (gridView1.RowCount != 0)
                OncekiTeraziFormu.btnUrunCikar_Click(null, null);
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            lblSeciliHareketMiktari.Text = gridView1.SelectedRowsCount.ToString() + " adet Seçili";
            KarisikUrununToplamMiktariniVer();
        }

        private void btnDaraAl_Click(object sender, EventArgs e)
        {
            OncekiTeraziFormu.btnDaraAl_Click(null, null);
        }

        private void btnDaraIptal_Click(object sender, EventArgs e)
        {
            OncekiTeraziFormu.btnDaraIptal_Click(null, null);
        }

        private void btnUrunAra_Click(object sender, EventArgs e)
        {
            if (txtBarkodu.Text.StartsWith(clsTablolar.TeraziSatisClaslari.csTeraziAyarlari.FaturaBarkodIcinKullanilacakOnEk))
            {
                MessageBox.Show("Müşterininin Fişi Bu ekranda iken okutulamaz");
                return;
            }

            OncekiTeraziFormu.txtBarkodu.EditValue = txtBarkodu.EditValue;

            int SatirSaysisi = OncekiTeraziFormu.gvSatisHareketleri.RowCount;
            OncekiTeraziFormu.btnUrunMusteriAra_Click(null, null);
            if (SatirSaysisi == OncekiTeraziFormu.gvSatisHareketleri.RowCount - 1) // satır eklenmişse
            {
                OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.gvSatisHareketleri.RowCount - 1, colMiktar, txtTerazidenGelenSabitMiktar.EditValue);
                OncekiTeraziFormu.gvSatisHareketleri.SetRowCellValue(OncekiTeraziFormu.gvSatisHareketleri.RowCount - 1, colBirlesikUrunHareketID, HarID);
                txtBarkodu.Text = "";
            }
            txtBarkodu.Text = "";
        }

        private void frmKarisikUrun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                txtBarkodu.Focus();
            }
            else if (txtBarkodu.ContainsFocus == false)
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
        (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
        e.KeyCode == Keys.Decimal)
                {
                    txtBarkodu.Focus();
                    txtBarkodu.Select(txtBarkodu.Text.Length, 0);
                    switch (e.KeyCode)
                    {
                        case Keys.NumPad0:
                            txtBarkodu.Text = txtBarkodu.Text + "0";
                            break;
                        case Keys.NumPad1:
                            txtBarkodu.Text = txtBarkodu.Text + "1";
                            break;
                        case Keys.NumPad2:
                            txtBarkodu.Text = txtBarkodu.Text + "2";
                            break;
                        case Keys.NumPad3:
                            txtBarkodu.Text = txtBarkodu.Text + "3";
                            break;
                        case Keys.NumPad4:
                            txtBarkodu.Text = txtBarkodu.Text + "4";
                            break;
                        case Keys.NumPad5:
                            txtBarkodu.Text = txtBarkodu.Text + "5";
                            break;
                        case Keys.NumPad6:
                            txtBarkodu.Text = txtBarkodu.Text + "6";
                            break;
                        case Keys.NumPad7:
                            txtBarkodu.Text = txtBarkodu.Text + "7";
                            break;
                        case Keys.NumPad8:
                            txtBarkodu.Text = txtBarkodu.Text + "8";
                            break;
                        case Keys.NumPad9:
                            txtBarkodu.Text = txtBarkodu.Text + "9";
                            break;
                        default:
                            txtBarkodu.Text = txtBarkodu.Text + Convert.ToChar((int)e.KeyValue).ToString();
                            break;
                    }
                    txtBarkodu.Select(txtBarkodu.Text.Length, 0);
                }
        }

        private void txtBarkodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnUrunAra_Click(null, null);
        }

        // Listenin toplam fiyatı sabit kalacak seçili ürünlerin fiyatı değiştirilecek dolayısıyla seçili olmayan ürünlerin de miktarı değişmiş olacak
        private void btnToplamFiyatSabitKalsinSeciliUrununMiktariniDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0);
                if (DialogResult.Yes == frm.ShowDialog())
                {
                    decimal ListeninToplamFiyati = 0;

                    decimal SecilenUrunlerinKiloFiyatToplamlari = 0;
                    decimal SecilmeyenUrunlerinKiloFiyatlariToplami = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {// Seçilen Ürünlerin toplam Kilo fiyatlarını alıyoruz.
                        ListeninToplamFiyati += (decimal)gridView1.GetRowCellValue(i, colKdvDahilFiyat);
                        if (gridView1.IsRowSelected(i))
                            SecilenUrunlerinKiloFiyatToplamlari += (decimal)gridView1.GetRowCellValue(i, colKdvDahilFiyat);
                        else
                            SecilenUrunlerinKiloFiyatToplamlari += (decimal)gridView1.GetRowCellValue(i, colKdvDahilFiyat);
                    }
                    decimal SecilenUrunlerIcinIstenenFiyat = Convert.ToDecimal(frm.textEdit1.EditValue);
                    decimal SecilmeyenUrunlerIcinIstenenFiyat = ListeninToplamFiyati - SecilenUrunlerIcinIstenenFiyat;
                    // Ürünlerin
                    decimal SecilenUrunlerinMiktarlari = SecilenUrunlerinKiloFiyatToplamlari / SecilenUrunlerIcinIstenenFiyat;
                    decimal SecilmeyenUrunlerinMiktarlari = SecilmeyenUrunlerinKiloFiyatlariToplami / SecilmeyenUrunlerIcinIstenenFiyat;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {// Seçilen Ürünlerin Miktarlarını Giriyoruz 
                        int sourceindex = gridView1.GetDataSourceRowIndex(i);
                        try
                        {
                            if (gridView1.IsRowSelected(i))
                                OncekiTeraziFormu.MiktarGir(sourceindex, SecilenUrunlerinMiktarlari, false);
                            else
                                OncekiTeraziFormu.MiktarGir(sourceindex, SecilmeyenUrunlerinMiktarlari, false);

                            gridView1.UpdateCurrentRow();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            OncekiTeraziFormu.KaydedileBilirMi = true;
                            OncekiTeraziFormu.btnKaydet_Click(null, null);
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.StackTrace);
            }


        }

        private void onveciTEraziFormu_cbtnTerazidekiSabitMiktariStokaAktar_CheckedChanged(object sender, EventArgs e)
        {
            cbtnTerazidekiSabitMiktariStokaAktar.Checked = OncekiTeraziFormu.cbtnTerazidekiSabitMiktariStokaAktar.Checked;
        }

        private void cbtnTerazidekiSabitMiktariStokaAktar_CheckedChanged(object sender, EventArgs e)
        {
            OncekiTeraziFormu.cbtnTerazidekiSabitMiktariStokaAktar.Checked = cbtnTerazidekiSabitMiktariStokaAktar.Checked;
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            OncekiTeraziFormu.checkEdit2.Checked = checkEdit3.Checked;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridView1.IsLastRow)
                gridView1.MoveFirst();
            else
                gridView1.MoveNext();

            if (Convert.ToDecimal(txtTerazidenGelenSabitMiktar.EditValue) != Convert.ToDecimal(0))
                btnDaraAl_Click(null, null);
            cbtnTerazidekiSabitMiktariStokaAktar.Checked = true;
        }

        void KarisikUrununToplamMiktariniVer()
        {
            decimal ButunUrunlerinToplamMiktariToplamMiktar = 0;
            decimal SeciliUrunlerinToplamMiktari = 0;
            decimal SeciliOlmayanUrunlerinToplamMiktari = 0;
            decimal ButunUrunlarinToplamFireMiktari = 0;

            decimal ButunUrunlerinToplamTutari = 0;
            decimal SeciliUrunlerinToplamTutari = 0;
            decimal SeciliOlmayanUrunlerinToplamTutari = 0;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                ButunUrunlerinToplamMiktariToplamMiktar += Convert.ToDecimal(gridView1.GetRowCellValue(i, colMiktar));
                ButunUrunlerinToplamTutari += Convert.ToDecimal(gridView1.GetRowCellValue(i, colKdvDahilToplam));
                ButunUrunlarinToplamFireMiktari += Convert.ToDecimal(gridView1.GetRowCellValue(i, colFireMiktari));
                if (gridView1.IsRowSelected(i))
                {
                    SeciliUrunlerinToplamMiktari += Convert.ToDecimal(gridView1.GetRowCellValue(i, colMiktar));
                    SeciliUrunlerinToplamTutari += Convert.ToDecimal(gridView1.GetRowCellValue(i, colKdvDahilToplam));
                }
                else
                {
                    SeciliOlmayanUrunlerinToplamMiktari += Convert.ToDecimal(gridView1.GetRowCellValue(i, colMiktar));
                    SeciliOlmayanUrunlerinToplamTutari += Convert.ToDecimal(gridView1.GetRowCellValue(i, colKdvDahilToplam));
                }
            }
            txtButunUrunlerinToplamMiktari.EditValue = ButunUrunlerinToplamMiktariToplamMiktar;
            txtSeciliOlmayanUrunlarinToplamMiktari.EditValue = SeciliOlmayanUrunlerinToplamMiktari;
            txtSeciliUrunlerinToplamMiktari.EditValue = SeciliUrunlerinToplamMiktari;
            txtSeciliUrunlerinToplamTutari.EditValue = SeciliUrunlerinToplamTutari;
            txtSeciliOlmayanUrunlerinToplamTutari.EditValue = SeciliOlmayanUrunlerinToplamTutari;
            txtButunUrunlerinToplamTutari.EditValue = ButunUrunlerinToplamTutari;
            txtToplamFireMiktari.EditValue = ButunUrunlarinToplamFireMiktari;
        }


        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSeciliOlmayanUrunlarinToplamMiktari_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtButunUrunlerinToplamTutari_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSeciliUrunlerHaricDigerUrunlerinMiktariniDarayaAktar_Click(object sender, EventArgs e)
        {
            decimal IstenenDara = OncekiTeraziFormu.MiktarAl.OkunanSabitMiktar - Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colMiktar));
            OncekiTeraziFormu.DaraAl(IstenenDara);
        }
    }
}