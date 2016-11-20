using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace Aresv2.InsanKaynaklari
{
    public partial class frmBasvuruKarti : DevExpress.XtraEditors.XtraForm
    {
        public frmBasvuruKarti(int IsBasvuruID)
        {
            _IsBasvuruID = IsBasvuruID;
            InitializeComponent();
        }
        int _IsBasvuruID;

        clsTablolar.IsBasvurulari.csIsBasvurulari Basvuru;
        clsTablolar.IsBasvurulari.csIsBasvurulariGrup Grubu = new clsTablolar.IsBasvurulari.csIsBasvurulariGrup();


        SqlTransaction TrGenel;
        private void frmBasvuruKarti_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Basvuru = new clsTablolar.IsBasvurulari.csIsBasvurulari(SqlConnections.GetBaglanti(), TrGenel, _IsBasvuruID);

                gcIsBasvuruDosya.DataSource = Basvuru.dt_IsbasvuruDosya;

                lkpGrubu.Properties.DataSource = Grubu.IsBasvurulariGrupGetir(SqlConnections.GetBaglanti(), TrGenel);
                lkpGrubu.Properties.DisplayMember = "GrupAdi";
                lkpGrubu.Properties.ValueMember = "IsBasvurulariGrupID";
                lkpGrubu.Properties.PopulateColumns();
                lkpGrubu.Properties.Columns["IsBasvurulariGrupID"].Visible = false;


                TrGenel.Commit();

                Cinsiyeti_MedeniHali_AskerlikDurumu_YUKLE();
                BasvuruBinle();

                if (checkEdit1.CheckState == CheckState.Unchecked)
                {
                    labelControl1.Visible = false;
                    deMulakatTarihi.Visible = false;
                }

                KaydetMedenCikilmasin(false);
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }

        }

        void BasvuruBinle()
        {
            deFormTarihi.DataBindings.Add("EditValue", Basvuru, "FormTarihi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAdi.DataBindings.Add("EditValue", Basvuru, "Adi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoyadi.DataBindings.Add("EditValue", Basvuru, "Soyadi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDogumYeri.DataBindings.Add("EditValue", Basvuru, "DogumYeri", false, DataSourceUpdateMode.OnPropertyChanged);
            deDugumTarihi.DataBindings.Add("EditValue", Basvuru, "DogumTarihi", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpCinsiyeti.DataBindings.Add("EditValue", Basvuru, "Cinsiyeti", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbSigaraIciyormu.DataBindings.Add("EditValue", Basvuru, "SigaraIciyormu", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpMedeniHali.DataBindings.Add("EditValue", Basvuru, "MedeniHali", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpAskerlikDurumu.DataBindings.Add("EditValue", Basvuru, "AskerlikDurumu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtEvTelefonu.DataBindings.Add("EditValue", Basvuru, "EvTelefonu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCepTelefonu.DataBindings.Add("EditValue", Basvuru, "CepTelefonu", false, DataSourceUpdateMode.OnPropertyChanged);
            memoEdit_EvAdresi.DataBindings.Add("EditValue", Basvuru, "EvAdresi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtEPosta.DataBindings.Add("EditValue", Basvuru, "EPosta", false, DataSourceUpdateMode.OnPropertyChanged);
            deMulakatTarihi.DataBindings.Add("EditValue", Basvuru, "MulakatTarihi", false, DataSourceUpdateMode.OnPropertyChanged);


            memoEdit_IsTecrubeleri.DataBindings.Add("EditValue", Basvuru, "IsTecrubeleri", false, DataSourceUpdateMode.OnPropertyChanged);
            memoEdit_OgrenimBilgileri.DataBindings.Add("EditValue", Basvuru, "OgrenimDurumu", false, DataSourceUpdateMode.OnPropertyChanged);
            memoEdit_EklemekIstedikleri.DataBindings.Add("EditValue", Basvuru, "EklemekIstedikleri", false, DataSourceUpdateMode.OnPropertyChanged);
            memoEdit_Aciklama.DataBindings.Add("EditValue", Basvuru, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
            memoEdit_MulakatNotlari.DataBindings.Add("EditValue", Basvuru, "MulakatNotlari", false, DataSourceUpdateMode.OnPropertyChanged);

            pictureEdit1.DataBindings.Add("EditValue", gcIsBasvuruDosya.DataSource, "Dosya", false, DataSourceUpdateMode.OnPropertyChanged);

            checkEdit1.DataBindings.Add("Checked", Basvuru, "MulakatYapilacakmi", false, DataSourceUpdateMode.OnPropertyChanged);
            lkpGrubu.DataBindings.Add("EditValue", Basvuru, "IsBasvurulariGrupID", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        void KaydetMedenCikilmasin(bool true_false)
        {
            btnKaydet.Enabled = true_false;
            btnVazgec.Enabled = true_false;
            btnSil.Enabled = !true_false;
        }

        void Cinsiyeti_MedeniHali_AskerlikDurumu_YUKLE()
        {
            lkpAskerlikDurumu.Properties.DataSource = Basvuru.dt_AskerlikDurumuYukle();
            lkpAskerlikDurumu.Properties.DisplayMember = "AskerlikDurumuAdi";
            lkpAskerlikDurumu.Properties.ValueMember = "AskerlikDurumuKodu";

            lkpMedeniHali.Properties.DataSource = Basvuru.dt_MedeniHali();
            lkpMedeniHali.Properties.DisplayMember = "MedeniHaliAdi";
            lkpMedeniHali.Properties.ValueMember = "MedeniHaliKodu";

            lkpCinsiyeti.Properties.DataSource = Basvuru.dt_Cinsiyeti();
            lkpCinsiyeti.Properties.DisplayMember = "CinsiyetiAdi";
            lkpCinsiyeti.Properties.ValueMember = "CinsiyetiKodu";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            if (checkEdit1.CheckState == CheckState.Unchecked)
                Basvuru.MulakatTarihi = DateTime.MinValue;

            Basvuru.Guncelle(SqlConnections.GetBaglanti(), TrGenel, Basvuru.IsBasvuruID);
            TrGenel.Commit();
            KaydetMedenCikilmasin(false);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Silmek İstediğinize Eminmisiniz", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Basvuru.Sil(SqlConnections.GetBaglanti(), TrGenel, Basvuru.IsBasvuruID);
                TrGenel.Commit();
                Close();
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnFotoEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDial = new OpenFileDialog();
            fDial.InitialDirectory = @"\\192.168.2.3\Users\Senoz\Desktop\Debug\AresDosya";
            fDial.Title = "Foto Seç Hamısına";

            if (fDial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                    fDial.InitialDirectory = @"\\192.168.2.3\Users\Senoz\Desktop\Debug\AresDosya";
                    fDial.Title = "Foto Seç Hamısına";

                    FileStream fs = new FileStream(fDial.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] resim = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    Basvuru.dt_IsbasvuruDosya.Rows.Add(Basvuru.dt_IsbasvuruDosya.NewRow());

                    Basvuru.dt_IsbasvuruDosya.Rows[Basvuru.dt_IsbasvuruDosya.Rows.Count - 1]["Dosya"] = resim;

                    if (Basvuru.dt_IsbasvuruDosya.Rows.Count == 1) // eğer yeni ve ilk defa foto ekleniyors varsayilanını true yapıyor
                        Basvuru.dt_IsbasvuruDosya.Rows[0]["VarsayilanMi"] = true;
                    else
                        Basvuru.dt_IsbasvuruDosya.Rows[Basvuru.dt_IsbasvuruDosya.Rows.Count - 1]["VarsayilanMi"] = false;
                }
                catch (Exception)
                {

                    throw;
                }
                System.IO.File.Delete(fDial.FileName);
            }


        }

        private void btnFotoSil_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Seçili foyosilinsin mi hamısına", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                gvIsBasvuruDosya.DeleteSelectedRows();
            }

        }

        private void ButunTextler_EditValueChanged(object sender, EventArgs e)
        {
            KaydetMedenCikilmasin(true);
        }

        private void GridlerIcin_EditValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            KaydetMedenCikilmasin(true);
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            KaydetMedenCikilmasin(false);
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.CheckState == CheckState.Checked)
            {
                deMulakatTarihi.Visible = true;
                labelControl1.Visible = true;
                if (Basvuru.MulakatTarihi == DateTime.MinValue)
                    Basvuru.MulakatTarihi = DateTime.Now;
            }
            else
            {
                //Basvuru.MulakatTarihi = DateTime.MinValue;
                labelControl1.Visible = false;
                deMulakatTarihi.Visible = false;
            }
        }

        private void frmBasvuruKarti_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: Close();
                    break;
                //case Keys.Escape: Close();
                //  break;
            }
        }

        private void frmBasvuruKarti_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                MessageBox.Show("Kayıt Tamamlanmadı");
                e.Cancel = true;
            }
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            frmBuyukFoto buyuk = new frmBuyukFoto((byte[])pictureEdit1.EditValue);
            buyuk.ShowDialog();
        }

        private void lookUpEdit1_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void lookUpEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                lkpGrubu.EditValue = -1;
            }
        }
    }
}