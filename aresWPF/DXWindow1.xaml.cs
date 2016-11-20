using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using System.Data.SqlClient;




namespace aresWPF
{
    /// <summary>
    /// Interaction logic for DXWindow1.xaml
    /// </summary>
    public partial class DXWindow1 : DevExpress.Xpf.Core.DXWindow
    {
        public DXWindow1()
        {
            InitializeComponent();
        }
        clsTablolar.Stok.csStokArama Arama = new clsTablolar.Stok.csStokArama();
        SqlTransaction Trgenel;


        private void DXTabbedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnections sqlll = new SqlConnections();


            //frmAnaForm.pro
            //frmAnaForm.

        }

        private void simpleButton_Click(object sender, RoutedEventArgs e)
        {
            Arama.Barkod = txtBarkod.Text;
            Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
            Arama.StokListeGetir(SqlConnections.GetBaglanti(), Trgenel);
            Trgenel.Commit();
            //gcStokListesi.ItemsSource = Arama.dt_StokListesi;
            gcfalanfilan.ItemsSource = Arama.dt_StokListesi;

            clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama bArama = new clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama();
            bArama.StokBarkodundanStokIDVer(SqlConnections.GetBaglanti(), Trgenel, txtBarkod.Text);

        }

        private void frmAnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                simpleButton_Click(null, null);
            }
        }
    }
}
