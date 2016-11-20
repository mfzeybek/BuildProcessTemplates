using System;
using System.Windows.Forms;

namespace TeraziSatis
{
    public partial class frmIkinciEkran : DevExpress.XtraEditors.XtraForm
    {
        public frmIkinciEkran(frmTerazi TeraziFormu)
        {
            _TeraziFormu = TeraziFormu;
            InitializeComponent();
        }

        frmTerazi _TeraziFormu;

        public FormState formState2nciekran = new FormState();


        private void frmIkinciEkran_Load(object sender, EventArgs e)
        {
            //this.Size.Width =
            try
            {
                this.ShowInTaskbar = false;
                CheckForIllegalCrossThreadCalls = false;
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

                this.Location = Screen.AllScreens[1].Bounds.Location;
                this.StartPosition = FormStartPosition.Manual;
                this.WindowState = FormWindowState.Maximized;
                //formState2nciekran.Maximize(this);

                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.RectangleToScreen(Screen.AllScreens[TeraziSatis.Properties.Settings.Default.IkinciEkranNo].WorkingArea);

                _TeraziFormu.txtTerazidekiMiktari.EditValueChanged += txtTerazidekiMiktari_EditValueChanged;
                _TeraziFormu.txtStokAdi.EditValueChanged += txtStokAdi_EditValueChanged;
                _TeraziFormu.txtMiktari.EditValueChanged += txtMiktari_EditValueChanged;
                _TeraziFormu.txtKdvDahilFiyati.EditValueChanged += txtKdvDahilFiyati_EditValueChanged;
                _TeraziFormu.txtTutari.EditValueChanged += txtTutari_EditValueChanged;
                _TeraziFormu.txtFaturaTutari.EditValueChanged += txtFaturaTutari_EditValueChanged;


                //gcSatisHareketleri.DataSource = _TeraziFormu.gcSatisHareketleri.DataSource;
                gcSatisHareketleri.DataSource = _TeraziFormu.Hareketler.dt_FaturaHareketleri;

                //axWindowsMediaPlayer1.settings.autoStart = false;
                //axWindowsMediaPlayer1.settings.setMode("loop", true);
                //axWindowsMediaPlayer1.Ctlcontrols.play();
                
            }
            catch (Exception)
            {
                MessageBox.Show(_TeraziFormu, "İkinci Ekran Açılırken hata");
            }
        }



        void txtFaturaTutari_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamTutar.EditValue = _TeraziFormu.txtFaturaTutari.EditValue;
            }
            catch (Exception)
            {
                MessageBox.Show(_TeraziFormu, "İkinci Ekranda Hata");
            }
        }

        void txtTutari_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTutari.EditValue = _TeraziFormu.txtTutari.EditValue;
            }
            catch (Exception)
            {
                MessageBox.Show(_TeraziFormu, "İkinci Ekranda Hata");
            }
        }

        void txtKdvDahilFiyati_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtKdvDahilFiyati.EditValue = _TeraziFormu.txtKdvDahilFiyati.EditValue;
            }
            catch (Exception)
            {
                MessageBox.Show(_TeraziFormu, "İkinci Ekranda Hata");
            }
        }

        void txtMiktari_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtMiktari.EditValue = _TeraziFormu.txtMiktari.EditValue;
            }
            catch (Exception)
            {
                MessageBox.Show(_TeraziFormu, "İkinci Ekranda Hata");
            }
        }

        void txtStokAdi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                memoUrunAdi.EditValue = _TeraziFormu.txtStokAdi.EditValue;
            }
            catch (Exception)
            {
                MessageBox.Show(_TeraziFormu, "İkinci Ekranda Hata");
            }
        }

        void txtTerazidekiMiktari_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                digitalGauge1.Text = _TeraziFormu.txtTerazidekiMiktari.Text;
            }
            catch (Exception)
            {
                MessageBox.Show(_TeraziFormu, "İkinci Ekranda Hata");
            }
        }
    }
}