using System;
using System.Data;
using System.Data.SqlClient;

namespace Aresv2.Ayarlar
{
	public partial class frmAyarlarVOIP : DevExpress.XtraEditors.XtraForm
	{
		public frmAyarlarVOIP(string AyarlarVOIPID)
		{
			InitializeComponent();
			_AyarlarVOIPID = AyarlarVOIPID;
		}
		string _AyarlarVOIPID = "-1";

		private void frmAyarlarVOIP_Load(object sender, EventArgs e)
		{
			try
			{
				if (_AyarlarVOIPID != "-1")
				{
					#region FORM GÜNCELLEME İÇİN AÇILMIŞSA
					using (SqlCommand cmd = new SqlCommand(@"SELECT VOIPTanim, DisplayName, UserName, RegisterName, RegisterPassword, DomainServerHost, DomainServerPort, GelenAramaKontrolu, NotPenceresiAcilsin FROM dbo.AyarlarVOIP", SqlConnections.GetBaglanti()))
					{
						using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
						{
							if (dr.Read())
							{
								txtVOIPTanim.Text = dr["VOIPTanim"].ToString();
								ceAmaKontroluYapilsin.Checked = (bool)dr["GelenAramaKontrolu"];
								ceNotPenceresiAcilsin.Checked = (bool)dr["NotPenceresiAcilsin"];
								txtDisplayName.Text = dr["DisplayName"].ToString();
								txtUserName.Text = dr["UserName"].ToString();
								txtRegisterName.Text = dr["RegisterName"].ToString();
								txtPassword.Text = dr["RegisterPassword"].ToString();
								txtServerHost.Text = dr["DomainServerHost"].ToString();
								txtServerPort.Text = dr["DomainServerPort"].ToString();
							}
						}
					} 
					#endregion
				}
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
		private void btnKaydet_Click(object sender, EventArgs e)
		{
			try
			{
				#region AyarlarVOIP tablosunda kayıt var mı kontrolu
				using (SqlCommand cmd = new SqlCommand(@"
IF EXISTS (Select AyarlarVOIPID From AyarlarVOIP)
BEGIN
	UPDATE AyarlarVOIP SET 
	VOIPTanim=@VOIPTanim, DisplayName=@DisplayName, UserName=@UserName, RegisterName=@RegisterName, RegisterPassword=@RegisterPassword, DomainServerHost=@DomainServerHost, 
	DomainServerPort=@DomainServerPort, GelenAramaKontrolu=@GelenAramaKontrolu, NotPenceresiAcilsin=@NotPenceresiAcilsin
END
ELSE
BEGIN
	INSERT INTO AyarlarVOIP(VOIPTanim, DisplayName, UserName, RegisterName, RegisterPassword, DomainServerHost, DomainServerPort, GelenAramaKontrolu, NotPenceresiAcilsin) 
	VALUES(@VOIPTanim, @DisplayName, @UserName, @RegisterName, @RegisterPassword, @DomainServerHost, @DomainServerPort, @GelenAramaKontrolu, @NotPenceresiAcilsin)
END
", SqlConnections.GetBaglanti()))
				{
					cmd.Parameters.Add("@VOIPTanim", SqlDbType.NVarChar).Value = txtVOIPTanim.Text;
					cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = txtDisplayName.Text;
					cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = txtUserName.Text;
					cmd.Parameters.Add("@RegisterName", SqlDbType.NVarChar).Value = txtRegisterName.Text;
					cmd.Parameters.Add("@RegisterPassword", SqlDbType.NVarChar).Value = txtRegisterName.Text;
					cmd.Parameters.Add("@DomainServerHost", SqlDbType.NVarChar).Value = txtServerHost.Text;
					cmd.Parameters.Add("@DomainServerPort", SqlDbType.NVarChar).Value = txtServerPort.Text;
					cmd.Parameters.Add("@GelenAramaKontrolu", SqlDbType.Bit).Value = ceAmaKontroluYapilsin.Checked;
					cmd.Parameters.Add("@NotPenceresiAcilsin", SqlDbType.Bit).Value = ceNotPenceresiAcilsin.Checked;

					cmd.ExecuteNonQuery();
				}

				#endregion

				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
			catch (Exception hata)
			{
				frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
				frmHataBildir.ShowDialog();
			}
		}
	}
}