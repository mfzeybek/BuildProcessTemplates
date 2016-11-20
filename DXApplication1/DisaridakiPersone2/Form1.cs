using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DisaridakiPersone2
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.Color.White;

            //this.TransparencyKey = System.Drawing.Color.Transparent;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.TopMost = true;
            con.Open();

            getir();
            gridControl1.DataSource = dt;

            timer1.Start();
        }


        SqlConnection con = new SqlConnection("Data Source=192.168.2.71;Initial Catalog=PDKS;User ID=sa;Password=1");

        SqlDataAdapter da;
        DataTable dt;
        SqlTransaction TR;

        void getir()
        {
            da = new SqlDataAdapter(@"select * 
, 
case
when 
(select top 1 Hareketler.Tur from hareketler where Hareketler.PersonelID = Personel.PersonelID order by hareketler.Zaman desc) = 3
then 'ÇIKIŞ'
when
(select top 1 Hareketler.Tur from hareketler where Hareketler.PersonelID = Personel.PersonelID order by hareketler.Zaman desc) = 2
then 'GİRİŞ'
when
(select top 1 Hareketler.Tur from hareketler where Hareketler.PersonelID = Personel.PersonelID order by hareketler.Zaman desc) = 1
then
'MESAİ BAŞLANGICI'
end as Turu
,
(select top 1 Hareketler.Zaman from hareketler where Hareketler.PersonelID = Personel.PersonelID order by hareketler.Zaman desc)

as Zamani
,
(select top 1 Yerler.YerAdi  from hareketler 
inner join Yerler on Yerler.YerID = Hareketler.YerID
where Hareketler.PersonelID = Personel.PersonelID and
 zaman between DATEADD(day, 0,CONVERT(nvarchar(50),GETDATE(),106)) and DATEADD(day, 1,CONVERT(nvarchar(50),GETDATE(),106))
 order by hareketler.Zaman desc
) as Yer
from personel
where PersonelAktif = 1 
order by Zamani desc", con);

            dt = new DataTable();
            da.Fill(dt);

            gridControl1.DataSource = dt;
        }

        bool suruklesin = false;
        Point IlkKonum;


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            suruklesin = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            suruklesin = true;
            IlkKonum = e.Location;
        }

        private void gridControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (suruklesin)
            {
                this.Left = e.X + this.Left - (IlkKonum.X);
                this.Top = e.Y + this.Top - (IlkKonum.Y);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getir();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle >= 0)
            {
                if (View.GetRowCellValue(e.RowHandle, View.Columns["Turu"]).ToString() == "ÇIKIŞ")
                {
                    e.HighPriority = true;
                    //e.Appearance.BackColor = System.Drawing.Color.PeachPuff;
                    //e.Appearance.BackColor = System.Drawing.Color.White;
                    e.Appearance.ForeColor = System.Drawing.Color.Red;

                    e.Appearance.Options.UseBackColor = false;
                }
                else
                {

                }
            }
            //e.Appearance.Options.UseBackColor = true;
            //e.Appearance.Options.UseForeColor = true;
        }
    }
}
