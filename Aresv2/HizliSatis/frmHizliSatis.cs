using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.HizliSatis
{
    public partial class frmHizliSatis : DevExpress.XtraEditors.XtraForm
    {
        public frmHizliSatis()
        {
            InitializeComponent();
        }

        DataTable dtButon;

        SqlDataAdapter da;
        Point ilkkonum;

        bool Suruklenme = false;

        private void frmHizliSatis_Load(object sender, EventArgs e)
        {
            try
            {
                if (SqlConnections.GetBaglanti().State == ConnectionState.Closed)
                    SqlConnections.GetBaglanti().Open();

                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select * from HizliSatisButon", SqlConnections.GetBaglanti());
                dtButon = new DataTable();
                da.Fill(dtButon);
                VeriTabanindanButonlariAl();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void VeriTabanindanButonlariAl()
        {
            for (int i = 0; i < dtButon.Rows.Count; i++)
            {
                SimpleButton sbtn = new SimpleButton();
                sbtn.Name = dtButon.Rows[i]["ButonAdi"].ToString();
                sbtn.Text = dtButon.Rows[i]["ButonAdi"].ToString();

                sbtn.Tag = dtButon.Rows[i]["YapacagiIslem"].ToString();
                sbtn.Left = Convert.ToInt32(dtButon.Rows[i]["ButonLeft"]);
                sbtn.Top = Convert.ToInt32(dtButon.Rows[i]["ButonTop"]);
                sbtn.Width = Convert.ToInt32(dtButon.Rows[i]["ButonWidth"]);
                sbtn.Height = Convert.ToInt32(dtButon.Rows[i]["ButonHeith"]);

                sbtn.Click += CariButonlari_Click;

                sbtn.MouseDown += HareketliButonlar_MouseDown;
                sbtn.MouseMove += HareketliButonlar_MouseMove;
                sbtn.MouseUp += HareketliButonlar_MouseUp;

                pcCariButonlari.Controls.Add(sbtn);
            }
        }

        private void sbtnYeniButton_Click(object sender, EventArgs e)
        {
            frmCariListe frm = new frmCariListe();
            frm._CariIDVer = ButonlaraCariAtanirkenkiDelege;
            frm.ShowDialog();
        }

        clsTablolar.cari.csCariv2 Cari;
        SqlTransaction Trgenel;


        private void ButonlaraCariAtanirkenkiDelege(int CariID)
        {
          Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
          Cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), Trgenel, CariID);


            if (dtButon.Select("YapacagiIslem = " + CariID.ToString()).Length > 0)
            {
                MessageBox.Show("Bu buton daha önce eklenmiş");
                return;
            }
            dtButon.Rows.Add(dtButon.NewRow());

            SimpleButton sbtn = new SimpleButton();

            sbtn.MouseDown += HareketliButonlar_MouseDown;
            sbtn.MouseMove += HareketliButonlar_MouseMove;
            sbtn.MouseUp += HareketliButonlar_MouseUp;


            sbtn.Tag = CariID;
            sbtn.Name = Cari.CariTanim;
            sbtn.Text = Cari.CariTanim;

            dtButon.Rows[dtButon.Rows.Count - 1]["ButonAdi"] = Cari.CariTanim ;
            dtButon.Rows[dtButon.Rows.Count - 1]["YapacagiIslem"] = CariID;

            pcCariButonlari.Controls.Add(sbtn);
            Trgenel.Commit();

        }

        private void CariButonlari_Click(object sender, EventArgs e)
        {
            if (ButonDuzenleme == true)
            {
                if ((sender as SimpleButton).ImageIndex == 0) // yani Buton Sil düğmesine basılmış buton sil de bu image a icon yerleştirmişse
                {
                    pcCariButonlari.Controls.Remove((sender as SimpleButton));
                    dtButon.Select("YapacagiIslem = " + (sender as SimpleButton).Tag.ToString())[0].Delete();

                }
            }
            else
            {
                Cari.frmCariDetay frm = new Cari.frmCariDetay(Convert.ToInt32((sender as SimpleButton).Tag.ToString()));
                frm.ShowDialog();
            }
        }

        bool ButonDuzenleme = false;

        void DesingModee(bool TrueFalse)
        {
            ButonDuzenleme = TrueFalse;
            gcStokHareket.Enabled = !TrueFalse;
            panelControl1.Visible = TrueFalse;
        }

        private void btnDesionMode_Click(object sender, EventArgs e)
        {
            SimpleButton sbtn;
            if (ButonDuzenleme == false)
            {
                DesingModee(true);

                foreach (SimpleButton CariButonlari in pcCariButonlari.Controls) //("CariButonlari", true))
                {
                    CariButonlari.Appearance.BackColor = Color.Black;
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < pcCariButonlari.Controls.Count; i++)
                    {
                        //if (panel3.Controls[i].GetType().Name.ToString() == "SimpleButton" && panel3.Controls[i].Name.StartsWith("CariButonu"))
                        {
                            dtButon.Select("YapacagiIslem = " + pcCariButonlari.Controls[i].Tag.ToString())[0]["ButonLeft"] = (pcCariButonlari.Controls[i] as SimpleButton).Left;
                            dtButon.Select("YapacagiIslem = " + pcCariButonlari.Controls[i].Tag.ToString())[0]["ButonTop"] = (pcCariButonlari.Controls[i] as SimpleButton).Top;
                            dtButon.Select("YapacagiIslem = " + pcCariButonlari.Controls[i].Tag.ToString())[0]["ButonWidth"] = (pcCariButonlari.Controls[i] as SimpleButton).Width;
                            dtButon.Select("YapacagiIslem = " + pcCariButonlari.Controls[i].Tag.ToString())[0]["ButonHeith"] = (pcCariButonlari.Controls[i] as SimpleButton).Height;

                            dtButon.Select("YapacagiIslem = " + pcCariButonlari.Controls[i].Tag.ToString())[0]["ButonHeith"] = (pcCariButonlari.Controls[i] as SimpleButton).Height;
                            dtButon.Select("YapacagiIslem = " + pcCariButonlari.Controls[i].Tag.ToString())[0]["ButonAdi"] = (pcCariButonlari.Controls[i] as SimpleButton).Name;
                            //(panel3.Controls[i] as SimpleButton).
                        }
                    }
                    da.UpdateCommand = new SqlCommand(@"Update HizliSatisButon SET ButonAdi=@ButonAdi, ButonTop=@ButonTop, ButonLeft=@ButonLeft, 
ButonWidth=@ButonWidth, ButonHeith=@ButonHeith, YapacagiIslem=@YapacagiIslem Where HizliSatisButonID=@HizliSatisButonID", SqlConnections.GetBaglanti());
                    da.UpdateCommand.Parameters.Add("@ButonAdi", SqlDbType.NVarChar, 50, "ButonAdi");
                    da.UpdateCommand.Parameters.Add("@ButonTop", SqlDbType.NVarChar, 50, "ButonTop");
                    da.UpdateCommand.Parameters.Add("@ButonLeft", SqlDbType.NVarChar, 50, "ButonLeft");
                    da.UpdateCommand.Parameters.Add("@ButonWidth", SqlDbType.NVarChar, 50, "ButonWidth");
                    da.UpdateCommand.Parameters.Add("@ButonHeith", SqlDbType.NVarChar, 50, "ButonHeith");
                    da.UpdateCommand.Parameters.Add("@YapacagiIslem", SqlDbType.NVarChar, 50, "YapacagiIslem");
                    da.UpdateCommand.Parameters.Add("@HizliSatisButonID", SqlDbType.NVarChar, 50, "HizliSatisButonID");

                    da.InsertCommand = new SqlCommand(@"Insert Into HizliSatisButon(ButonAdi, ButonTop, ButonLeft, ButonWidth, ButonHeith, YapacagiIslem)
Values(@ButonAdi, @ButonTop, @ButonLeft, @ButonWidth, @ButonHeith, @YapacagiIslem)", SqlConnections.GetBaglanti());
                    da.InsertCommand.Parameters.Add("@ButonAdi", SqlDbType.NVarChar, 50, "ButonAdi");
                    da.InsertCommand.Parameters.Add("@ButonTop", SqlDbType.NVarChar, 50, "ButonTop");
                    da.InsertCommand.Parameters.Add("@ButonLeft", SqlDbType.NVarChar, 50, "ButonLeft");
                    da.InsertCommand.Parameters.Add("@ButonWidth", SqlDbType.NVarChar, 50, "ButonWidth");
                    da.InsertCommand.Parameters.Add("@ButonHeith", SqlDbType.NVarChar, 50, "ButonHeith");
                    da.InsertCommand.Parameters.Add("@YapacagiIslem", SqlDbType.NVarChar, 50, "YapacagiIslem");

                    da.DeleteCommand = new SqlCommand(@"Delete HizliSatisButon where HizliSatisButonID = @HizliSatisButonID", SqlConnections.GetBaglanti());
                    da.DeleteCommand.Parameters.Add("@HizliSatisButonID", SqlDbType.Int, 0, "HizliSatisButonID");



                    da.Update(dtButon);

                    DesingModee(false);
                }
                catch (Exception hata)
                {
                    frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                    frmHataBildir.ShowDialog();
                }
            }
        }

        #region Butonları Hareket Ettiren olaylar

        private void HareketliButonlar_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            if (ButonDuzenleme == true)
            {
                Suruklenme = true;
                SimpleButton btn = (SimpleButton)sender;
                btn.Left = panel1.Width - e.X;
                ilkkonum = e.Location;
            }
        }

        private void HareketliButonlar_MouseMove(object sender, MouseEventArgs e)
        {
            if (Suruklenme == true)
            {
                SimpleButton btn = (SimpleButton)sender;
                btn.Left = e.X + btn.Left - (ilkkonum.X);
                btn.Top = e.Y + btn.Top - (ilkkonum.Y);
            }
        }

        private void HareketliButonlar_MouseUp(object sender, MouseEventArgs e)
        {
            Suruklenme = false;
        }

        #endregion

        private void btnButonSil_Click(object sender, EventArgs e)
        {

        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (SimpleButton CariButonlari in pcCariButonlari.Controls)
            {
                if (cbtnButonSil.Checked == false)
                    CariButonlari.ImageIndex = -1;
                else
                {
                    CariButonlari.ImageList = imageCollection1;
                    CariButonlari.ImageIndex = 0;
                }
            }
        }
    }
}