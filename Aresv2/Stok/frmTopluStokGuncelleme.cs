using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.Stok
{
    public partial class frmTopluStokGuncelleme : DevExpress.XtraEditors.XtraForm
    {
        public frmTopluStokGuncelleme(frmStokListesi StokListesi)
        {


            Liste = StokListesi;
            InitializeComponent();
        }

        frmStokListesi Liste;

        //seçili satırları toplu olarak günceller


        SqlTransaction Trgenel;
        clsTablolar.Stok.csStok StokBilgileri;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Dikkat değişiklikler Uygulanacak", "!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }
            if (DialogResult.No == MessageBox.Show(@"Dikkat değişiklikler Uygulanacak", "!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            try
            {
                Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
                StokBilgileri = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), Trgenel, -1);

                if (Liste.gcStokListesi.MainView == Liste.gvStokListesi)
                {
                    for (int i = 0; i < Liste.gvStokListesi.SelectedRowsCount; i++)
                    {
                        StokYenile(Convert.ToInt32(Liste.gvStokListesi.GetRowCellValue(Liste.gvStokListesi.GetSelectedRows()[i], "StokID")));
                    }
                }
                else
                {
                    for (int i = 0; i < Liste.layoutView1.SelectedRowsCount; i++)
                    {
                        StokYenile(Convert.ToInt32(Liste.layoutView1.GetRowCellValue(Liste.layoutView1.GetSelectedRows()[i], "StokID")));
                    }
                }
                Trgenel.Commit();
            }
            catch (Exception hata)
            {
                Trgenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }


        void StokYenile(int StokID)
        {
            StokBilgileri.StokGetir(SqlConnections.GetBaglanti(), Trgenel, StokID);
            if (checkEdit_TanitimAlani.CheckState == CheckState.Checked)
                StokBilgileri.UrunTanitimdaGoster = Convert.ToBoolean(checkEdit_UrunTanitimdaGosterilsinMi.EditValue);
            if (checkEdit_GrubuAlani.CheckState == CheckState.Checked)
                StokBilgileri.StokGrupID = Convert.ToInt32(lkpGrubu.EditValue);
            if (checkEdit_AlisKdvAlani.CheckState == CheckState.Checked)
                StokBilgileri.AlisKdv = Convert.ToDecimal(txtAlisKdv.EditValue);
            if (checkEdit_SatisKdvAlani.CheckState == CheckState.Checked)
                StokBilgileri.SatisKdv = Convert.ToDecimal(txtSatisKdv.EditValue);
            if (checkEdit_WebteGosterilsin.CheckState == CheckState.Checked)
                StokBilgileri.EMagazaErisimi = Convert.ToBoolean(checkEdit_WebteGosterilsinAlani.EditValue);
            if (checkEdit_webKategoriDegistir.CheckState == CheckState.Checked)
                StokBilgileri.HemenAlKategoriID = Convert.ToInt32(lkpWebKategori.EditValue);
            if (checkEdit_AnahtarKelime.CheckState == CheckState.Checked)
                StokBilgileri.HemenAlAnahtarKelime = memoEdit_anahtarKelime.EditValue.ToString();
            if (checkEdit_RafYeriAciklama.CheckState == CheckState.Checked)
                StokBilgileri.RafYeriAciklama = txtRafYeriAcikalama.EditValue.ToString();
            if (checkEdit_ETicaretStokVarsaDurumu.CheckState == CheckState.Checked)
                StokBilgileri.EticaretStokDurumID_StoktaVarsa = Convert.ToInt32(lkpEticaretStoktaVarsaDurumTanimi.EditValue);
            if (checkEdit_ETicaretStokYoksaDurumu.CheckState == CheckState.Checked)
                StokBilgileri.EticaretStokDurumID_StoktaYoksa = Convert.ToInt32(lkpEticaretStoktaYoksaDurumTanimi.EditValue);
            if (checkEdit_HemenalSiraNu.CheckState == CheckState.Checked)
                StokBilgileri.HemenAlSira = Convert.ToInt32(txtHemeAlSiraNu.EditValue);

            StokBilgileri.StokGuncelle(SqlConnections.GetBaglanti(), Trgenel);
            //Stok.StokUrunTanitimGuncelle(SqlConnections.GetBaglanti(), Trgenel, Convert.ToBoolean(checkEdit_UrunTanitimdaGosterilsinMi.EditValue), Convert.ToInt32(Liste.gvStokListesi.GetRowCellValue(i, "StokID")));
        }

        clsTablolar.Stok.csStokGrup StokGrup;
        private void frmTopluStokGuncelleme_Load(object sender, EventArgs e)
        {
            if (Liste.gcStokListesi.MainView == Liste.gvStokListesi)
            {
                if (Liste.gvStokListesi.SelectedRowsCount < 2)
                {
                    XtraMessageBox.Show("çoklu seçim ile en az 2 öğe seçilmeli");
                    this.Close();
                }
            }
            else
            {
                if (Liste.layoutView1.SelectedRowsCount < 2)
                {
                    XtraMessageBox.Show("çoklu seçim ile en az 2 öğe seçilmeli");
                    this.Close();
                }
            }



            Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
            StokGrup = new clsTablolar.Stok.csStokGrup(SqlConnections.GetBaglanti(), Trgenel, -1);
            lkpGrubu.Properties.DataSource = StokGrup.StokGrupDoldur(SqlConnections.GetBaglanti(), Trgenel);



            lkpGrubu.Properties.DisplayMember = "StokGrupAdi";
            lkpGrubu.Properties.ValueMember = "StokGrupID";


            clsTablolar.HemenAl.csHemenAlKategori kategori = new clsTablolar.HemenAl.csHemenAlKategori();
            kategori.KategoriGetir(SqlConnections.GetBaglanti(), Trgenel);
            lkpWebKategori.Properties.DataSource = kategori.dt_Kategoriler;
            lkpWebKategori.Properties.ValueMember = "HemanAlKategoriID";
            lkpWebKategori.Properties.DisplayMember = "KategoriAdi";


            clsTablolar.HemenAl.csEticaretDurumTanimlari stokdurumu = new clsTablolar.HemenAl.csEticaretDurumTanimlari();
            stokdurumu.Getir(SqlConnections.GetBaglanti(), Trgenel);
            lkpEticaretStoktaVarsaDurumTanimi.Properties.DataSource = stokdurumu.dt;
            lkpEticaretStoktaVarsaDurumTanimi.Properties.DisplayMember = "Aciklama";
            lkpEticaretStoktaVarsaDurumTanimi.Properties.ValueMember = "ID";

            lkpEticaretStoktaYoksaDurumTanimi.Properties.DataSource = stokdurumu.dt;
            lkpEticaretStoktaYoksaDurumTanimi.Properties.DisplayMember = "Aciklama";
            lkpEticaretStoktaYoksaDurumTanimi.Properties.ValueMember = "ID";


            Trgenel.Commit();
        }


        #region Değiştirilecek alanların checkedbox lar la ayarlanması

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_TanitimAlani.CheckState == CheckState.Checked)
                checkEdit_UrunTanitimdaGosterilsinMi.Enabled = true;
            else
                checkEdit_UrunTanitimdaGosterilsinMi.Enabled = false;
        }

        private void checkEdit_GrubuAlani_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_GrubuAlani.CheckState == CheckState.Checked)
                lkpGrubu.Enabled = true;
            else
                lkpGrubu.Enabled = false;
        }

        private void checkEdit_WebteGosterilsinAlani_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_WebteGosterilsinAlani.CheckState == CheckState.Checked)
                checkEdit_WebteGosterilsin.Enabled = true;
            else
                checkEdit_WebteGosterilsin.Enabled = false;
        }

        #endregion

        private void checkEdit_AlisKdvAlani_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_AlisKdvAlani.CheckState == CheckState.Checked)
                txtAlisKdv.Enabled = true;
            else
                txtAlisKdv.Enabled = false;
        }

        private void checkEdit_SatisKdvAlani_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_SatisKdvAlani.CheckState == CheckState.Checked)
                txtSatisKdv.Enabled = true;
            else
                txtSatisKdv.Enabled = false;
        }

        private void checkEdit_webKategoriDegistir_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_webKategoriDegistir.CheckState == CheckState.Checked)
                txtSatisKdv.Enabled = true;
            else
                txtSatisKdv.Enabled = false;
        }

        private void checkEdit_AnahtarKelime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_webKategoriDegistir.CheckState == CheckState.Checked)
                memoEdit_anahtarKelime.Enabled = true;
            else
                memoEdit_anahtarKelime.Enabled = false;
        }

        private void checkEdit_RafYeriAciklama_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_RafYeriAciklama.CheckState == CheckState.Checked)
                memoEdit_anahtarKelime.Enabled = true;
            else
                memoEdit_anahtarKelime.Enabled = false;
        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkEdit_ETicaretStokVarsaDurumu.CheckState == CheckState.Checked)
                lkpEticaretStoktaVarsaDurumTanimi.Enabled = true;
            else
                lkpEticaretStoktaVarsaDurumTanimi.Enabled = false;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_ETicaretStokYoksaDurumu.CheckState == CheckState.Checked)
                lkpEticaretStoktaYoksaDurumTanimi.Enabled = true;
            else
                lkpEticaretStoktaYoksaDurumTanimi.Enabled = false;
        }


    }
}