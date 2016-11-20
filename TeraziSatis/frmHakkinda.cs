using System;
using DevExpress.XtraSplashScreen;
using System.Data;
using System.Data.SqlClient;

namespace TeraziSatis
{
    public partial class frmHakkinda : SplashScreen
    {
        public frmHakkinda()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void frmHakkinda_Load(object sender, EventArgs e)
        {
            labelControl5.Text = "Ver. : " + frmTerazi.VersiyonNo;

            using (SqlCommand cmd = new SqlCommand("select TeraziAdi from Teraziler with(nolock) where TeraziID = @TeraziID", SqlConnections.GetBaglanti()))
            {
                cmd.Parameters.Add("@TeraziID", SqlDbType.Int, 0).Value = TeraziSatis.Properties.Settings.Default.TeraziID;
                labelControl3.Text = "Terazi Numarası " + cmd.ExecuteScalar().ToString();
                labelControl4.Text = "Terazi Bağlantı noktası : " + TeraziSatis.Properties.Settings.Default.TeraziBagNok;
                labelControl7.Text = "TeraziSatis Model Nu.: " + TeraziSatis.Properties.Settings.Default.TeraziModel;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}