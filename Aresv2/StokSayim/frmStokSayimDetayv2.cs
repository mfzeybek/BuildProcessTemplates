using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Drawing;

namespace Aresv2.Stok
{
    public partial class frmStokSayimDetayv2 : DevExpress.XtraEditors.XtraForm
    {
        public frmStokSayimDetayv2(int SayimID)
        {
            InitializeComponent();
            _SayimID = SayimID;
        }
        int _SayimID = -1;
        SqlTransaction trGenel;
        clsTablolar.Sayim.csSayim SayimBaslik;
        clsTablolar.Sayim.csSayimDetay SayimDetay;
        clsTablolar.csDepo Depo;
        clsTablolar.Stok.csStok YeniStok;

        Siparis.frmSiparisDetay Siparis;

        private void frmStokSayimDetayv2_Load(object sender, EventArgs e)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                #region lkpDepo
                Depo = new clsTablolar.csDepo(SqlConnections.GetBaglanti(), trGenel);

                lkpDepo.Properties.DataSource = Depo.dt_Depo;
                lkpDepo.Properties.PopulateColumns();
                lkpDepo.Properties.ValueMember = "DepoID";
                lkpDepo.Properties.DisplayMember = "DepoAdi";
                lkpDepo.Properties.ShowHeader = false;
                lkpDepo.EditValue = 1; // todo Bu ayarlardan gelicek daha sonra (varsayılan depo diye)
                #endregion
                deSayimTarih.DateTime = DateTime.Now;

                SayimBaslik = new clsTablolar.Sayim.csSayim(SqlConnections.GetBaglanti(), trGenel, _SayimID);
                gcSayim_Doldur();
                NesneleriBindleHamisina();

                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void lkpBirim1_Doldur()
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select BirimID, Birim From Birim", SqlConnections.GetBaglanti()))
                {
                    da.SelectCommand.Transaction = trGenel;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //lkpBirim1.Properties.DataSource = dt;
                    //lkpBirim1.Properties.PopulateColumns();
                    //lkpBirim1.Properties.Columns["Birim"].Caption = "Birim";
                    //lkpBirim1.Properties.Columns["BirimID"].Visible = false;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void lkpBirim2_Doldur(string stokID)
        {
            try
            {
                //csStok üstünde sen güncelleme yaptığın için şimdilik buraya yazıyorum. birleştirirken, istersek class a taşıyabiliriz.
                using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT     SB.BirimID, SB.BirimAdi FROM         dbo.StokBirimCevrim AS SBC 
INNER JOIN dbo.Stok AS S ON SBC.StokID = S.StokID 
INNER JOIN dbo.StokBirim AS SB ON SBC.BirimID = SB.BirimID
WHERE  (S.StokID = @StokID)", SqlConnections.GetBaglanti())
                    )
                {
                    da.SelectCommand.Transaction = trGenel;
                    da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = stokID;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //lkpBirim2.Properties.DataSource = dt;
                    //lkpBirim2.Properties.PopulateColumns();
                    //lkpBirim2.Properties.ValueMember = "BirimID";
                    //lkpBirim2.Properties.DisplayMember = "BirimAdi";
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void gcSayim_Doldur()
        {
            SayimDetay = new clsTablolar.Sayim.csSayimDetay(SqlConnections.GetBaglanti(), trGenel, _SayimID);
            gcSayim.DataSource = SayimDetay.dt_SayimDetay;
        }
        private void NesneleriBindleHamisina()
        {
            deSayimTarih.DataBindings.Add("EditValue", SayimBaslik, "SayimTarihi");
            lkpDepo.DataBindings.Add("EditValue", SayimBaslik, "DepoID");
            txtSayimKodu.DataBindings.Add("EditValue", SayimBaslik, "SayimKodu");
            memoAciklama.DataBindings.Add("EditValue", SayimBaslik, "Aciklama");
            SayimBaslik.KaydedenID = -1;
            SayimBaslik.GuncelleyenID = -1;
        }
        private void txtStok_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmStokListesi frm = new frmStokListesi(true);
            frm.Stok_Sec = StokDegistir;
            frm.ShowDialog();
        }
        private void txtBirim2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gvSayim.GetFocusedRowCellValue(colMiktar1).ToString() == "")
                {
                    XtraMessageBox.Show("Miktar 1 Alanına değer giriniz", "Aresv2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Stok.frmCevrimBirimListesi frmCevrimBirimListesi = new frmCevrimBirimListesi(gvSayim.GetFocusedRowCellValue("StokID").ToString());
                if (frmCevrimBirimListesi.ShowDialog() == DialogResult.OK)
                {
                    gvSayim.SetFocusedRowCellValue(colBirim2ID, Stok.frmCevrimBirimListesi.AltBirim);
                    gvSayim.SetFocusedRowCellValue(colKatsayi, Stok.frmCevrimBirimListesi.AltBirimKatsayi);

                    gvSayim.SetFocusedRowCellValue(colMiktar2, Convert.ToDecimal(Stok.frmCevrimBirimListesi.AltBirimKatsayi) * Convert.ToDecimal(gvSayim.GetFocusedRowCellValue(colMiktar1).ToString()));
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void frmStokSayimDetayv2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
                btnStokEkle_Click(null, null);
        }


        cs.csGridLayout GridLayout = new cs.csGridLayout();
        private void btnGridArayuzKaydet_Click(object sender, EventArgs e)
        {

        }

        private void barbtnExceleAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExceleAktar frmExceleAktar = new frmExceleAktar(gcSayim);
            frmExceleAktar.Show();
        }

        private void barBtnIhtiyacListesineGonder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                clsTablolar.csStokIhtiyac StokIhtiyac = new clsTablolar.csStokIhtiyac(SqlConnections.GetBaglanti(), trGenel);

                foreach (DataRow Roww in SayimDetay.dt_SayimDetay.AsEnumerable())
                {
                    if (StokIhtiyac.dt_StokIhtiyac.Select("StokID = " + Roww["StokID"].ToString()).Length > 0)
                    {
                        MessageBox.Show(Roww["StokAdi"].ToString() + "\nAdlı Stok zaten ekli");
                    }
                    else
                    {
                        StokIhtiyac.dt_StokIhtiyac.Rows.Add(StokIhtiyac.dt_StokIhtiyac.NewRow());
                        StokIhtiyac.dt_StokIhtiyac.Rows[StokIhtiyac.dt_StokIhtiyac.Rows.Count - 1]["StokID"] = Roww["StokID"];

                        StokIhtiyac.dt_StokIhtiyac.Rows[StokIhtiyac.dt_StokIhtiyac.Rows.Count - 1]["StokIhtiyacMiktari"] = Convert.ToDecimal(Roww["MinumumMiktar"]) - Convert.ToDecimal(Roww["Miktar1"]);
                    }
                }
                StokIhtiyac.StokIhtiyacGuncele(SqlConnections.GetBaglanti(), trGenel);



                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                #region BOŞ ALAN KONTROLÜ
                if (lkpDepo.Text == "")
                {
                    XtraMessageBox.Show("Sayım yapılan depo bilgisini giriniz.", "Aresv2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lkpDepo.Focus();
                    return;
                }
                //if (txtSayimKodu.Text == "")
                //{
                //    XtraMessageBox.Show("Sayım Kodu bilgisini giriniz.", "Aresv2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtSayimKodu.Focus();
                //    return;
                //}
                //if (gvSayim.DataRowCount < 1)
                //{
                //    XtraMessageBox.Show("Sayım bilgisi giriniz.", "Aresv2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                #endregion

                this.BindingContext[gcSayim.DataSource].EndCurrentEdit();
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();


                _SayimID = Convert.ToInt32(SayimBaslik.SayimGuncelle(SqlConnections.GetBaglanti(), trGenel));

                SayimDetay.SayimDetayGuncelle(SqlConnections.GetBaglanti(), trGenel, _SayimID);

                trGenel.Commit();
                XtraMessageBox.Show("Sayım işlemi kaydedildi.", "Aresv2", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        #region StokEkle - StokSil - Değiştir - Kartını Aç

        frmStokListesi StokArama;

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            StokArama = new frmStokListesi(true);
            StokArama.Stok_Sec = StokEkle;
            StokArama.ShowDialog();
        }
        private void btnStokSil_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(gvSayim.GetFocusedRowCellValue(colStokAdi).ToString() + "\nSeçilen satırı silmek istediğinize emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            gvSayim.DeleteSelectedRows();

            //gvSayim.BeginInit();




            //this.BindingContext[gvSayim.DataSource]k.EndCurrentEdit();
            //gvSayim.PostEditor();
            //gvSayim.EndInit();
            //SayimDetay.dt_SayimDetay.GetChanges();

            //SayimDetay.dt_SayimDetay.AcceptChanges();
            //SayimDetay.dt_SayimDetay.GetChanges();
            //SayimDetay.dt_SayimDetay.BeginInit();
            //this.BindingContext[gvSayim.DataSource].EndCurrentEdit();
            //gvSayim.PostEditor();
            //gvSayim.BeginUpdate();
            //gvSayim.BeginDataUpdate();
            //gvSayim.EndDataUpdate();
            //gvSayim.BeginInit();
            //gvSayim.EndInit();
            //gvSayim.BeginUpdate();
            //gvSayim.EndUpdate();
            //gvSayim.DeleteRow(gvSayim.FocusedRowHandle);
        }
        clsTablolar.Stok.csStokMiktar MevcutStokMiktari = new clsTablolar.Stok.csStokMiktar();

        private void StokEkle(int StokID, decimal Miktar)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, StokID);
                if (SayimDetay.dt_SayimDetay.Select("StokID = " + StokID.ToString()).Length > 0) // eğer aynı stok daha önce eklenmişse
                {
                    SayimDetay.dt_SayimDetay.Select("StokID = " + StokID.ToString())[0]["Miktar1"] = (Convert.ToDecimal(SayimDetay.dt_SayimDetay.Select("StokID = " + StokID.ToString())[0]["Miktar1"]) + Miktar).ToString();
                    SayimDetay.dt_SayimDetay.Select("StokID = " + StokID.ToString())[0]["StokMiktari"] = MevcutStokMiktari.StokMiktariGetir(SqlConnections.GetBaglanti(), trGenel, StokID);

                    StokArama.GeriDonenAciklamaYazisi = YeniStok.StokAdi + " " + Miktar + " Eklendi Yeni Miktar " + SayimDetay.dt_SayimDetay.Select("StokID = " + StokID.ToString())[0]["Miktar1"].ToString() + " Oldu";
                    StokArama.lblAciklama.Text = StokArama.GeriDonenAciklamaYazisi;

                    for (int i = 0; i < SayimDetay.dt_SayimDetay.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(gvSayim.GetRowCellValue(i, colStokID)) == StokID)
                        {
                            gvSayim.FocusedRowHandle = i;
                        }
                    }
                }
                else // Aynı Stok Daha önce eklenmemişse
                {
                    SayimDetay.dt_SayimDetay.Rows.Add(SayimDetay.dt_SayimDetay.NewRow());

                    SayimDetay.dt_SayimDetay.Rows[SayimDetay.dt_SayimDetay.Rows.Count - 1]["StokID"] = YeniStok.StokID;
                    SayimDetay.dt_SayimDetay.Rows[SayimDetay.dt_SayimDetay.Rows.Count - 1]["Birim1ID"] = YeniStok.StokBirimID;
                    SayimDetay.dt_SayimDetay.Rows[SayimDetay.dt_SayimDetay.Rows.Count - 1]["StokAdi"] = YeniStok.StokAdi;
                    //SayimDetay.dt_SayimDetay.Rows[SayimDetay.dt_SayimDetay.Rows.Count - 1]["Birim1"] = YeniStok.;

                    SayimDetay.dt_SayimDetay.Rows[SayimDetay.dt_SayimDetay.Rows.Count - 1]["StokMiktari"] = MevcutStokMiktari.StokMiktariGetir(SqlConnections.GetBaglanti(), trGenel, StokID);
                    SayimDetay.dt_SayimDetay.Rows[SayimDetay.dt_SayimDetay.Rows.Count - 1]["Miktar1"] = Miktar;

                    StokArama.GeriDonenAciklamaYazisi = YeniStok.StokAdi + " " + Miktar + " Eklendi";
                    StokArama.lblAciklama.Text = StokArama.GeriDonenAciklamaYazisi;

                    gvSayim.FocusedRowHandle = SayimDetay.dt_SayimDetay.Rows.Count - 1;
                }
                trGenel.Commit();
                SayimAltToplamlari();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnKartiAc_Click(object sender, EventArgs e)
        {
            frmStokDetay frm = new frmStokDetay(Convert.ToInt32(gvSayim.GetFocusedRowCellValue(colStokID)));
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void StokDegistir(int StokID, decimal Miktar)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, StokID);

                SayimDetay.dt_SayimDetay.Rows[gvSayim.FocusedRowHandle]["StokID"] = YeniStok.StokID;
                SayimDetay.dt_SayimDetay.Rows[gvSayim.FocusedRowHandle]["Birim1ID"] = YeniStok.StokBirimID;
                SayimDetay.dt_SayimDetay.Rows[gvSayim.FocusedRowHandle]["StokAdi"] = YeniStok.StokAdi;
                //SayimDetay.dt_SayimDetay.Rows[gvSayim.FocusedRowHandle]["Birim1"] = Stok["BirimAdi"];

                SayimDetay.dt_SayimDetay.Rows[gvSayim.FocusedRowHandle]["Miktar1"] = Miktar;
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }


        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                SayimDetay.SayimGrubunuGetir(SqlConnections.GetBaglanti(), trGenel, 1);
                trGenel.Commit();
                for (int i = 0; i < SayimDetay.dt_SayimGrubu.Rows.Count; i++)
                {
                    StokEkle(Convert.ToInt32(SayimDetay.dt_SayimGrubu.Rows[i]["StokID"]), 0);
                }
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }

        }

        private void Karsilastir()
        {// Miktar1 Sayim Miktarı oli
            var MevcutMiktardanFazlaOlanlar =
        from row in SayimDetay.dt_SayimDetay.AsEnumerable().Where(dataRow => dataRow.RowState != DataRowState.Deleted)
        where Convert.ToDecimal(row["StokMiktari"]) < Convert.ToDecimal(row["Miktar1"])
        select new
        {
            SayimDetayID = row["SayimDetayID"],
            SayimID = row["SayimID"],
            StokID = row["StokID"],
            Birim1ID = row["Birim1ID"],
            Miktar1 = row["Miktar1"],
            //Birim2ID = row["Birim2ID"],
            //Miktar2 = row["Miktar2"],
            StokAdi = row["StokAdi"],
            //RafYeriAciklama = row["RafYeriAciklama"],
            MinumumMiktar = row["MinumumMiktar"],
            Birim1 = row["Birim1"],
            //Katsayi = row["Katsayi"],
            StokMiktari = row["StokMiktari"]
        };

            var MevcutMiktardanEksikOlanlar =
                from row in SayimDetay.dt_SayimDetay.AsEnumerable().Where(dataRow => dataRow.RowState != DataRowState.Deleted)
                where Convert.ToDecimal(row["StokMiktari"]) > Convert.ToDecimal(row["Miktar1"])
                select new
                {
                    SayimDetayID = row["SayimDetayID"],
                    SayimID = row["SayimID"],
                    StokID = row["StokID"],
                    Birim1ID = row["Birim1ID"],
                    Miktar1 = row["Miktar1"],
                    //Birim2ID = row["Birim2ID"],
                    //Miktar2 = Convert.ToDecimal(row["Miktar2"]),
                    StokAdi = row["StokAdi"],
                    //RafYeriAciklama = row["RafYeriAciklama"],
                    MinumumMiktar = row["MinumumMiktar"],
                    Birim1 = row["Birim1"],
                    //Katsayi = Convert.ToDecimal(row["Katsayi"]),
                    StokMiktari = Convert.ToDecimal(row["StokMiktari"])
                };

            var MinumumMiktardanEksikOlanlar =
          from row in SayimDetay.dt_SayimDetay.AsEnumerable().Where(dataRow => dataRow.RowState != DataRowState.Deleted)
          where Convert.ToDecimal(row["Miktar1"]) < Convert.ToDecimal(row["MinumumMiktar"])
          select new
          {
              SayimDetayID = row["SayimDetayID"],
              SayimID = row["SayimID"],
              StokID = row["StokID"],
              Birim1ID = row["Birim1ID"],
              Miktar1 = row["Miktar1"],
              //Birim2ID = row["Birim2ID"],
              //Miktar2 = row["Miktar2"],
              StokAdi = row["StokAdi"],
              //RafYeriAciklama = row["RafYeriAciklama"],
              MinumumMiktar = row["MinumumMiktar"],
              Birim1 = row["Birim1"],
              //Katsayi = row["Katsayi"],
              StokMiktari = row["StokMiktari"]
          };
            var OlmasiGerekenMiktardanAzOlanlar =
        from row in SayimDetay.dt_SayimDetay.AsEnumerable().Where(dataRow => dataRow.RowState != DataRowState.Deleted)
        where Convert.ToDecimal(row["Miktar1"]) < Convert.ToDecimal(row["OlmasiGerekenMiktar"])
        select new
        {
            SayimDetayID = row["SayimDetayID"],
            SayimID = row["SayimID"],
            StokID = row["StokID"],
            Birim1ID = row["Birim1ID"],
            Miktar1 = row["Miktar1"],
            //Birim2ID = row["Birim2ID"],
            //Miktar2 = row["Miktar2"],
            StokAdi = row["StokAdi"],
            //RafYeriAciklama = row["RafYeriAciklama"],
            MinumumMiktar = row["MinumumMiktar"],
            Birim1 = row["Birim1"],
            //Katsayi = Convert.ToDecimal(row["Katsayi"]),
            StokMiktari = Convert.ToDecimal(row["StokMiktari"]),
            OlmasiGerekenMiktar = Convert.ToDecimal(row["OlmasiGerekenMiktar"])
        };

            gridControl1.DataSource = MinumumMiktardanEksikOlanlar;
            gridControl2.DataSource = MevcutMiktardanEksikOlanlar;
            gridControl3.DataSource = MevcutMiktardanFazlaOlanlar;
            gridControl4.DataSource = OlmasiGerekenMiktardanAzOlanlar;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Karsilastir();
        }



        private void simpleButton3_Click(object sender, EventArgs e)
        {

            // To do : ayarlardan perakende satış carisi seçilebildiğinde burada da perakende satış için olan carinin Id si veriecek
            Fatura.frmFaturaDetay fatura = new Fatura.frmFaturaDetay(clsTablolar.IslemTipi.AlisFaturasi, -1);
            fatura.MdiParent = this.MdiParent;
            fatura.Show();

            for (int i = 0; i < gridView3.RowCount; i++)
            {
                fatura.StokEkle(Convert.ToInt32(gridView3.GetRowCellValue(i, "StokID")), Convert.ToInt32(gridView3.GetRowCellValue(i, "Miktar1")));
            }
        }

        private void btnMevcutMiktarGetir_Click(object sender, EventArgs e)
        {
            decimal Mik;
            for (int i = 0; i < gvSayim.RowCount; i++)
            {
                Mik = MevcutStokMiktari.StokMiktariGetir(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(gvSayim.GetRowCellValue(i, "StokID")));
                SayimDetay.dt_SayimDetay.Rows[gvSayim.GetDataSourceRowIndex(i)]["StokMiktari"] = Mik;
            }
            for (int i = 0; i < gvSayim.RowCount; i++)
            {
                Mik = MevcutStokMiktari.MinimumMiktarGetir(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(gvSayim.GetRowCellValue(i, "StokID")));
                //gvSayim.SetRowCellValue(i, "MinumumMiktar", Mik);
                SayimDetay.dt_SayimDetay.Rows[gvSayim.GetDataSourceRowIndex(i)]["MinumumMiktar"] = Mik;
            }
            for (int i = 0; i < gvSayim.RowCount; i++)
            {
                Mik = MevcutStokMiktari.OlmasiGerekenMiktariGetir(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(gvSayim.GetRowCellValue(i, "StokID")));
                SayimDetay.dt_SayimDetay.Rows[gvSayim.GetDataSourceRowIndex(i)]["OlmasiGerekenMiktar"] = Mik;
                //gvSayim.SetRowCellValue(i, "OlmasiGerekenMiktar", Mik);
            }
        }


        void SayimAltToplamlari() // Toplam miktar, Toplam çeşit
        {
            labelControl6.Text =
            SayimDetay.dt_SayimDetay.AsEnumerable().Where(dataRow => dataRow.RowState != DataRowState.Deleted).Sum(x => x.Field<decimal?>("Miktar1")).ToString();
            //Sum(x => x.Field<decimal?>("Miktar1"))
            //decimal TotalPrice = SayimDetay.dt_SayimDetay.AsEnumerable().Sum(q => q.number * q.price);
            //.Select(c => c.Field<>("Miktar1").).ToString();


            //var TotalPrice = from q in SayimDetay.dt_SayimDetay.AsEnumerable()
            //                     //let y = Convert.ToInt32(q["number"]) * Convert.ToInt32(q["price"])
            //                 let y = Convert.ToDecimal(q["Miktar1"])
            //                 select  y;

            //decimal totalPrice = TotalPrice.Sum();
            //labelControl6.Text = totalPrice.ToString();
        }


        clsTablolar.Yazdirma.csYazdir Yazdir;
        clsTablolar.Rapor.csRaporVarsayilanYolu VarsayilanYol;
        private void YazdirmakIcinVerileriHazirla()

        {
            using (Yazdir = new clsTablolar.Yazdirma.csYazdir())
            {
                Yazdir.dt_ekle("Stok Sayım");
                Yazdir.DtyaYeniSatirEkle("Stok Sayım");
                Yazdir.dtAlanEkleVeriEkle("Stok Sayım", "Sayım Kodu", SayimBaslik.SayimKodu, System.Type.GetType("System.String"));
                Yazdir.dtAlanEkleVeriEkle("Stok Sayım", "Sayım Tarihi", SayimBaslik.SayimTarihi, System.Type.GetType("System.DateTime"));
                Yazdir.dtAlanEkleVeriEkle("Stok Sayım", "Aciklama", SayimBaslik.Aciklama, System.Type.GetType("System.String"));
                Yazdir.dtAlanEkleVeriEkle("Stok Sayım", "Sayım Depo", lkpDepo.Text, System.Type.GetType("System.String"));
                using (DataTable dt = SayimDetay.dt_SayimDetay.Copy())
                {
                    Yazdir.dt_ekle(dt);
                }
            }
        }

        private void barBtn_Yazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakIcinVerileriHazirla();
            using (VarsayilanYol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                Yazdir.Yazdirr(VarsayilanYol.RaporVarsayilan(SqlConnections.GetBaglanti(), clsTablolar.csRaporDizayn.RaporModul.StokSayim), clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir);
            }
        }

        private void barbtnOnizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakIcinVerileriHazirla();
            using (VarsayilanYol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                Yazdir.Yazdirr(VarsayilanYol.RaporVarsayilan(SqlConnections.GetBaglanti(), clsTablolar.csRaporDizayn.RaporModul.StokSayim), clsTablolar.Yazdirma.csYazdir.Nasil.Goster);
            }
        }

        private void barbtnFormSecerekYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakIcinVerileriHazirla();
            frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(Yazdir, clsTablolar.csRaporDizayn.RaporModul.StokSayim);
            frm.ShowDialog();
        }

        private void btnMiktarDegistir_Click(object sender, EventArgs e)
        {
            frmMiktarGir MiktarGir = new frmMiktarGir(1);
            MiktarGir.labelControl1.Text = "Bütün Hepsinin Miktarını Değiştir";

            if (MiktarGir.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < gvSayim.RowCount; i++)
                {
                    gvSayim.SetRowCellValue(i, colMiktar1, Convert.ToInt32(MiktarGir.textEdit1.EditValue));
                }
            }

        }


        private void gridControl1_Click(object sender, EventArgs e)
        {

        }



        #region Siparişe Gönder Butonları



        private void btnSayimiSipariseGonder_Click(object sender, EventArgs e)
        {
            Siparis = new Siparis.frmSiparisDetay(clsTablolar.Siparis.csSiparis.SiparisTip.VerilenSiparis, -1);

            Siparis.MdiParent = this.MdiParent;
            Siparis.Show();
            for (int i = 0; i < gvSayim.RowCount; i++)
            {
                decimal SiparisMiktari = Convert.ToDecimal(gvSayim.GetRowCellValue(i, "Miktar1"));
                Siparis.StokEkle((int)(gvSayim.GetRowCellValue(i, "StokID")), SiparisMiktari);
            }
        }


        private void btnSipariseGonder_Click(object sender, EventArgs e)
        {
            Siparis = new Siparis.frmSiparisDetay(clsTablolar.Siparis.csSiparis.SiparisTip.VerilenSiparis, -1);

            Siparis.MdiParent = this.MdiParent;
            Siparis.Show();
            for (int i = 0; i < gridView4.RowCount; i++)
            {
                decimal SiparisMiktari = Convert.ToDecimal(gridView4.GetRowCellValue(i, "OlmasiGerekenMiktar")) - Convert.ToDecimal(gridView4.GetRowCellValue(i, "Miktar1"));
                Siparis.StokEkle((int)(gridView4.GetRowCellValue(i, "StokID")), SiparisMiktari);
            }
        }

        private void SipariseGonder()
        {


        }

        #endregion

        private void btnHareketCikisiFaturaIleYap_Click(object sender, EventArgs e)
        {
            try
            {
                Fatura.frmFaturaDetay frm = new Fatura.frmFaturaDetay(clsTablolar.IslemTipi.SatisFaturasi, 2);
                frm.MdiParent = this.MdiParent;
                frm.Show();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    frm.StokEkle(Convert.ToInt32(gridView2.GetRowCellValue(i, "StokID")), Convert.ToDecimal(gridView2.GetRowCellValue(i, "StokMiktari")) - Convert.ToDecimal(gridView2.GetRowCellValue(i, "Miktar1")));
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnFarklıSatirlardakiAyniUrunleriBirlestir_Click(object sender, EventArgs e)
        {
            FarkliSatirlardakiAyniUrunleriBirlestir("StokID", SayimDetay.dt_SayimDetay, "Miktar1");
        }

        void FarkliSatirlardakiAyniUrunleriBirlestir(string ID_KolonuAdi, DataTable dt, string MiktarKolunuAdi)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].RowState != DataRowState.Deleted)
                {
                    for (int y = i + 1; y < dt.Rows.Count; y++)
                    {
                        if (dt.Rows[y].RowState != DataRowState.Deleted)
                            if (Convert.ToInt32(dt.Rows[i][ID_KolonuAdi]) == Convert.ToInt32(dt.Rows[y][ID_KolonuAdi]))
                            {
                                dt.Rows[i][MiktarKolunuAdi] = Convert.ToDecimal(dt.Rows[i][MiktarKolunuAdi]) + Convert.ToDecimal(dt.Rows[y][MiktarKolunuAdi]);
                                dt.Rows[y].Delete();
                            }
                    }
                }
            }
        }

        private void gvSayim_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Miktar1")
                SayimAltToplamlari();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Dokunmatigeayarla();
        }



        private void gvSayim_RowCountChanged(object sender, EventArgs e)
        {
        }

        private void gvSayim_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SayimAltToplamlari();
        }

        private void gvSayim_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {

        }

        private void gvSayim_ColumnChanged(object sender, EventArgs e)
        {

        }

        private void gvSayim_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void gvSayim_RowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            SayimAltToplamlari();
        }

        private void gvSayim_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton1.Checked == true)
            {
                Dokunmatigeayarla();
            }
            else
            {
                MasaUstuKullanımınaGoreAyarla();
            }
        }
        void Dokunmatigeayarla()
        {
            //this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.True;

            panelControl3.Width = panelControl3.Width + 20;
            btnStokEkle.Width += 20;
            btnStokEkle.Height += 20;
            btnStokSil.Top += 20;
            btnStokSil.Width += 20;
            btnStokSil.Height += 20;
            btnKartiAc.Top += 40;
            btnKartiAc.Width += 20;
            btnKartiAc.Height += 20;
            btnMiktarDegistir.Top += 60;
            btnMiktarDegistir.Width += 20;
            btnMiktarDegistir.Height += 20;
            gvSayim.Appearance.Row.Font = new System.Drawing.Font("Arial", 15.5F, GraphicsUnit.Pixel);
        }
        void MasaUstuKullanımınaGoreAyarla()
        {
            this.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            panelControl3.Width = panelControl3.Width - 20;

            btnStokEkle.Width -= 20;
            btnStokEkle.Height -= 20;
            btnStokSil.Top -= 20;
            btnStokSil.Width -= 20;
            btnStokSil.Height -= 20;

            btnKartiAc.Top -= 40;
            btnKartiAc.Width -= 20;
            btnKartiAc.Height -= 20;
            btnMiktarDegistir.Top -= 60;
            btnMiktarDegistir.Width -= 20;
            btnMiktarDegistir.Height -= 20;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Silmek İstediğinden emin misin", " silerim haaa", MessageBoxButtons.YesNo))
            {
                SayimBaslik.SayimiDetaylariIleBirlikteSil(SqlConnections.GetBaglanti(), trGenel, SayimBaslik.SayimID);
                this.Close();
            }
        }

        private void btnStokSil_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(gvSayim.GetFocusedRowCellValue(colStokAdi).ToString() + " Silmek İstediğinden emin misin", " silerim haaa", MessageBoxButtons.YesNo))
            {
                gvSayim.DeleteSelectedRows();
            }
        }
        /*Miktar1 = Sayım Miktarı  */
    }
}
