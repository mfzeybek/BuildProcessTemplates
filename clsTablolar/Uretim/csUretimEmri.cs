using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Uretim
{
	public class csUretimEmri : IDisposable
	{
		#region Alanlar
		private int _UretimEmriID;
		private string _PartiNo;
		private DateTime _UretimTarihi;
		private string _OzelKod1;
		private string _OzelKod2;
		private int _CariID;
		private int _SarfAmbarID;
		private int _UretimdenGirisAmbarID;
		private int _ReceteMasterID;
		private decimal _UretimMiktari;
		private DateTime _BaslangicTarihi;
		private DateTime _BitisTarihi;
		private DateTime _TeslimTarihi;
		private string _UretimAciklama;
		private bool _Durum;
		private int _KaydedenID;
		private DateTime _KayitTarihi;
		private int _GuncelleyenID;
		private DateTime _GuncellemeTarihi;
		private string _CariKod;
		private string _CariTanim;
		private string _ReceteKod;
		#endregion
		#region property ler
		public int UretimEmriID
		{
			get { return _UretimEmriID; }
			set { _UretimEmriID = value; }
		}
		public string PartiNo
		{
			get { return _PartiNo; }
			set { _PartiNo = value; }
		}
		public DateTime UretimTarihi
		{
			get { return _UretimTarihi; }
			set { _UretimTarihi = value; }
		}
		public string OzelKod1
		{
			get { return _OzelKod1; }
			set { _OzelKod1 = value; }
		}
		public string OzelKod2
		{
			get { return _OzelKod2; }
			set { _OzelKod2 = value; }
		}
		public int CariID
		{
			get { return _CariID; }
			set { _CariID = value; }
		}
		public int SarfAmbarID
		{
			get { return _SarfAmbarID; }
			set { _SarfAmbarID = value; }
		}
		public int UretimdenGirisAmbarID
		{
			get { return _UretimdenGirisAmbarID; }
			set { _UretimdenGirisAmbarID = value; }
		}
		public int ReceteMasterID
		{
			get { return _ReceteMasterID; }
			set { _ReceteMasterID = value; }
		}
		public decimal UretimMiktari
		{
			get { return _UretimMiktari; }
			set { _UretimMiktari = value; }
		}
		public DateTime BaslangicTarihi
		{
			get { return _BaslangicTarihi; }
			set { _BaslangicTarihi = value; }
		}
		public DateTime BitisTarihi
		{
			get { return _BitisTarihi; }
			set { _BitisTarihi = value; }
		}
		public DateTime TeslimTarihi
		{
			get { return _TeslimTarihi; }
			set { _TeslimTarihi = value; }
		}
		public string UretimAciklama
		{
			get { return _UretimAciklama; }
			set { _UretimAciklama = value; }
		}
		public bool Durum
		{
			get { return _Durum; }
			set { _Durum = value; }
		}
		public int KaydedenID
		{
			get { return _KaydedenID; }
			set { _KaydedenID = value; }
		}
		public DateTime KayitTarihi
		{
			get { return _KayitTarihi; }
			set { _KayitTarihi = value; }
		}
		public int GuncelleyenID
		{
			get { return _GuncelleyenID; }
			set { _GuncelleyenID = value; }
		}
		public DateTime GuncellemeTarihi
		{
			get { return _GuncellemeTarihi; }
			set { _GuncellemeTarihi = value; }
		}
		public string CariKod
		{
			get { return _CariKod; }
			set { _CariKod = value; }
		}
		public string CariTanim
		{
			get { return _CariTanim; }
			set { _CariTanim = value; }
		}
		public string ReceteKod
		{
			get { return _ReceteKod; }
			set { _ReceteKod = value; }
		}
		#endregion
		#region Genel Tanımlar
		SqlCommand cmdGenel;
		SqlDataReader drGenel;
		#endregion

		public csUretimEmri(SqlConnection Baglanti, SqlTransaction trGenel, int uretimEmriID)
		{
			if (uretimEmriID == -1)
			{
				_UretimEmriID = -1;
				_PartiNo = "";
				_UretimTarihi = Convert.ToDateTime("01.01.1888"); ;
				_OzelKod1 = ""; ;
				_OzelKod2 = ""; ;
				_CariID = -1; ;
				_SarfAmbarID = -1; ;
				_UretimdenGirisAmbarID = -1; ;
				_ReceteMasterID = -1; ;
				_UretimMiktari = 0;
				_BaslangicTarihi = Convert.ToDateTime("01.01.1888"); ;
				_BitisTarihi = Convert.ToDateTime("01.01.1888"); ;
				_TeslimTarihi = Convert.ToDateTime("01.01.1888"); ;
				_UretimAciklama = "";
				_Durum = false;
				_KayitTarihi = Convert.ToDateTime("01.01.1888");
				_GuncelleyenID = -1;
				_GuncellemeTarihi = Convert.ToDateTime("01.01.1888");
			}
			else
				UretimEmriGetir(Baglanti, trGenel, uretimEmriID);
		}
		private void UretimEmriGetir(SqlConnection Baglanti, SqlTransaction trGenel, int uretimEmriID)
		{
			using (cmdGenel = new SqlCommand(@"
SELECT     dbo.UretimEmri.PartiNo, dbo.UretimEmri.UretimTarihi, dbo.UretimEmri.OzelKod1, dbo.UretimEmri.OzelKod2, dbo.UretimEmri.CariID, dbo.UretimEmri.SarfAmbarID, 
                      dbo.UretimEmri.UretimdenGirisAmbarID, dbo.UretimEmri.ReceteMasterID, dbo.UretimEmri.UretimMiktari, dbo.UretimEmri.BaslangicTarihi, dbo.UretimEmri.BitisTarihi, 
                      dbo.UretimEmri.TeslimTarihi, dbo.UretimEmri.UretimAciklama, dbo.UretimEmri.Durum, dbo.UretimEmri.KaydedenID, dbo.UretimEmri.KayitTarihi, 
                      dbo.UretimEmri.GuncelleyenID, dbo.UretimEmri.GuncellemeTarihi, dbo.Cari.CariKod, dbo.Cari.CariTanim, dbo.ReceteMaster.ReceteKod
FROM         dbo.UretimEmri LEFT OUTER JOIN
                      dbo.ReceteMaster ON dbo.UretimEmri.ReceteMasterID = dbo.ReceteMaster.ReceteMasterID LEFT OUTER JOIN
                      dbo.Cari ON dbo.UretimEmri.CariID = dbo.Cari.CariID
WHERE     (dbo.UretimEmri.UretimEmriID = @UretimEmriID)
				", Baglanti, trGenel))
			{
				cmdGenel.Parameters.Add("@UretimEmriID", SqlDbType.Int).Value = uretimEmriID;
				using (drGenel = cmdGenel.ExecuteReader())
				{
					if (drGenel.Read())
					{
						_PartiNo = drGenel["PartiNo"].ToString();
						_UretimTarihi = Convert.ToDateTime(drGenel["UretimTarihi"].ToString());
						_OzelKod1 = drGenel["OzelKod1"].ToString();
						_OzelKod2 = drGenel["OzelKod2"].ToString();
						_CariID = Convert.ToInt32(drGenel["CariID"].ToString());
						_SarfAmbarID = Convert.ToInt32(drGenel["SarfAmbarID"].ToString());
						_UretimdenGirisAmbarID = Convert.ToInt32(drGenel["UretimdenGirisAmbarID"].ToString());
						_ReceteMasterID = Convert.ToInt32(drGenel["ReceteMasterID"].ToString());

						_UretimMiktari = Convert.ToDecimal(drGenel["UretimMiktari"].ToString());
						_BaslangicTarihi = Convert.ToDateTime(drGenel["BaslangicTarihi"].ToString());
						_BitisTarihi = Convert.ToDateTime(drGenel["BitisTarihi"].ToString());
						_TeslimTarihi = Convert.ToDateTime(drGenel["TeslimTarihi"].ToString());
						_UretimAciklama = drGenel["UretimAciklama"].ToString();
						_Durum = Convert.ToBoolean(drGenel["Durum"].ToString());

						CariKod = drGenel["CariKod"].ToString();
						CariTanim = drGenel["CariTanim"].ToString();
						ReceteKod = drGenel["ReceteKod"].ToString();
					}
				}
			}
		}
		public string UretimEmriInsert(SqlConnection baglanti, SqlTransaction trGenel)
		{
			try
			{
				cmdGenel = new SqlCommand(@"Insert Into UretimEmri ( PartiNo, UretimTarihi, OzelKod1, OzelKod2, CariID, SarfAmbarID, UretimdenGirisAmbarID, 
ReceteMasterID, UretimMiktari, BaslangicTarihi, BitisTarihi, TeslimTarihi, UretimAciklama, Durum, KaydedenID, KayitTarihi) 
Values (@PartiNo, @UretimTarihi, @OzelKod1, @OzelKod2, @CariID, @SarfAmbarID, @UretimdenGirisAmbarID, @ReceteMasterID, @UretimMiktari, 
@BaslangicTarihi, @BitisTarihi, @TeslimTarihi, @UretimAciklama, @Durum,@KaydedenID,@KayitTarihi) SET @SonKayitID = SCOPE_IDENTITY()  ", baglanti,trGenel);

				cmdGenel.Parameters.Add("@PartiNo", SqlDbType.NVarChar).Value = _PartiNo;
				cmdGenel.Parameters.Add("@UretimTarihi", SqlDbType.DateTime).Value = _UretimTarihi;
				cmdGenel.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
				cmdGenel.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
				cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
				cmdGenel.Parameters.Add("@SarfAmbarID", SqlDbType.Int).Value = _SarfAmbarID;
				cmdGenel.Parameters.Add("@UretimdenGirisAmbarID", SqlDbType.Int).Value = _UretimdenGirisAmbarID;

				cmdGenel.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = _ReceteMasterID;
				cmdGenel.Parameters.Add("@UretimMiktari", SqlDbType.Decimal).Value = _UretimMiktari;
				cmdGenel.Parameters.Add("@BaslangicTarihi", SqlDbType.DateTime).Value = _BaslangicTarihi;
				cmdGenel.Parameters.Add("@BitisTarihi", SqlDbType.DateTime).Value = _BitisTarihi;
				cmdGenel.Parameters.Add("@TeslimTarihi", SqlDbType.DateTime).Value = _TeslimTarihi;
				cmdGenel.Parameters.Add("@UretimAciklama", SqlDbType.NVarChar).Value = _UretimAciklama;
				cmdGenel.Parameters.Add("@Durum", SqlDbType.Bit).Value = _Durum;
				cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
				cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
				cmdGenel.Parameters.Add("@SonKayitID", SqlDbType.Int).Direction = ParameterDirection.Output;

				cmdGenel.ExecuteNonQuery();
				return cmdGenel.Parameters["@SonKayitID"].Value.ToString();
			}
			catch (Exception hata)
			{
				throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
			}
		}
		public void UretimEmriUpdate(SqlConnection baglanti, SqlTransaction trGenel)
		{
			try
			{
				cmdGenel = new SqlCommand(@"Update UretimEmri SET 
PartiNo=@PartiNo, UretimTarihi=@UretimTarihi, OzelKod1=@OzelKod1, OzelKod2=@OzelKod2, CariID=@CariID, SarfAmbarID=@SarfAmbarID, UretimdenGirisAmbarID=@UretimdenGirisAmbarID, ReceteMasterID=@ReceteMasterID, UretimMiktari=@UretimMiktari, 
BaslangicTarihi=@BaslangicTarihi, BitisTarihi=@BitisTarihi, TeslimTarihi=@TeslimTarihi, UretimAciklama=@UretimAciklama, Durum=@Durum,
GuncelleyenID=@GuncelleyenID, GuncellemeTarihi=@GuncellemeTarihi  Where UretimEmriID=@UretimEmriID  ", baglanti, trGenel);

				cmdGenel.Parameters.Add("@PartiNo", SqlDbType.NVarChar).Value = _PartiNo;
				cmdGenel.Parameters.Add("@UretimTarihi", SqlDbType.DateTime).Value = _UretimTarihi;
				cmdGenel.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
				cmdGenel.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
				cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
				cmdGenel.Parameters.Add("@SarfAmbarID", SqlDbType.Int).Value = _SarfAmbarID;
				cmdGenel.Parameters.Add("@UretimdenGirisAmbarID", SqlDbType.Int).Value = _UretimdenGirisAmbarID;

				cmdGenel.Parameters.Add("@ReceteMasterID", SqlDbType.Int).Value = _ReceteMasterID;
				cmdGenel.Parameters.Add("@UretimMiktari", SqlDbType.Decimal).Value = _UretimMiktari;
				cmdGenel.Parameters.Add("@BaslangicTarihi", SqlDbType.DateTime).Value = _BaslangicTarihi;
				cmdGenel.Parameters.Add("@BitisTarihi", SqlDbType.DateTime).Value = _BitisTarihi;
				cmdGenel.Parameters.Add("@TeslimTarihi", SqlDbType.DateTime).Value = _TeslimTarihi;
				cmdGenel.Parameters.Add("@UretimAciklama", SqlDbType.NVarChar).Value = _UretimAciklama;
				cmdGenel.Parameters.Add("@Durum", SqlDbType.Bit).Value = _Durum;
				cmdGenel.Parameters.Add("@GuncelleyenID", SqlDbType.Int).Value = _KaydedenID;
				cmdGenel.Parameters.Add("@GuncellemeTarihi", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();

				cmdGenel.Parameters.Add("@UretimEmriID", SqlDbType.Int).Value = _UretimEmriID;
				cmdGenel.ExecuteNonQuery();
			}
			catch (Exception hata)
			{
				throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
			}
		}
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
