  using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Irsaliye
{
	public class csIrsaliye : IDisposable
	{
		#region Değişkenler
		private int _IrsaliyeID;
		private int _IrsaliyeTipi; // Alışmı satış mı iademi ne mikim se işte integer tipinde ve mesela 1 alış 2 satış gibi olacak
		private DateTime _IrsaliyeTarihi;
		private DateTime _DuzenlemeTarihi;
		private string _IrsaliyeNo;
		private int _CariID;
		private string _CariTanim;
		private string _CariKod;
		private string _VergiDairesi;
		private string _VergiNo;
		private string _Adres;
		private string _Il;
		private string _Ilce;
		private decimal _ToplamIndirim;
		private decimal _ToplamKdv;
		private decimal _Toplam;
		private decimal _NetToplam;

		private DateTime _Vadesi;
		private bool _Iptal;
		private bool _SilindiMi;
		private DateTime _KayitTarihi;
		private int _KaydedenID;
		private DateTime _DegistirmeTarihi;
		private int _DegistirenID;
		private string _Aciklama;
		private int _DepoID;
		private int _SatisElemaniID;
		private bool _Faturalandi;
		#endregion

		#region Methodlar
		public int IrsaliyeID
		{
			get { return _IrsaliyeID; }
			set { _IrsaliyeID = value; }
		}
		public int IrsaliyeTipi
		{
			get { return _IrsaliyeTipi; }
			set { _IrsaliyeTipi = value; }
		}
		public int CariID
		{
			get { return _CariID; }
			set { _CariID = value; }
		}
		public string CariTanim
		{
			get { return _CariTanim; }
			set { _CariTanim = value; }
		}
		public string CariKod
		{
			get { return _CariKod; }
			set { _CariKod = value; }
		}
		public string VergiDairesi
		{
			get { return _VergiDairesi; }
			set { _VergiDairesi = value; }
		}
		public string VergiNo
		{
			get { return _VergiNo; }
			set { _VergiNo = value; }
		}
		public string Adres
		{
			get { return _Adres; }
			set { _Adres = value; }
		}
		public string Il
		{
			get { return _Il; }
			set { _Il = value; }
		}
		public string Ilce
		{
			get { return _Ilce; }
			set { _Ilce = value; }
		}
		public decimal ToplamIndirim
		{
			get { return _ToplamIndirim; }
			set { _ToplamIndirim = value; }
		}
		public decimal ToplamKdv
		{
			get { return _ToplamKdv; }
			set { _ToplamKdv = value; }
		}
		public decimal Toplam
		{
			get { return _Toplam; }
			set { _Toplam = value; }
		}
		public decimal NetToplam
		{
			get { return _NetToplam; }
			set { _NetToplam = value; }
		}
		public string IrsaliyeNo
		{
			get { return _IrsaliyeNo; }
			set { _IrsaliyeNo = value; }
		}
		public DateTime IrsaliyeTarihi
		{
			get { return _IrsaliyeTarihi; }
			set { _IrsaliyeTarihi = value; }
		}
		public DateTime DuzenlemeTarihi
		{
			get { return _DuzenlemeTarihi; }
			set { _DuzenlemeTarihi = value; }
		}
		public DateTime Vadesi
		{
			get { return _Vadesi; }
			set { _Vadesi = value; }
		}
		public bool Iptal
		{
			get { return _Iptal; }
			set { _Iptal = value; }
		}
		public bool SilindiMi
		{
			get { return _SilindiMi; }
			set { _SilindiMi = value; }
		}
		public DateTime KayitTarihi
		{
			get { return _KayitTarihi; }
			set { _KayitTarihi = value; }
		}
		public int KaydedenID
		{
			get { return _KaydedenID; }
			set { _KaydedenID = value; }
		}
		public DateTime DegistirmeTarihi
		{
			get { return _DegistirmeTarihi; }
			set { _DegistirmeTarihi = value; }
		}
		public int DegistirenID
		{
			get { return _DegistirenID; }
			set { _DegistirenID = value; }
		}
		public string Aciklama
		{
			get { return _Aciklama; }
			set { _Aciklama = value; }
		}
		public int DepoID
		{
			get { return _DepoID; }
			set { _DepoID = value; }
		}
		public int SatisElemaniID
		{
			get { return _SatisElemaniID; }
			set { _SatisElemaniID = value; }
		}
		public bool Faturalandi
		{
			get { return _Faturalandi; }
			set { _Faturalandi = value; }
		}
		#endregion

		#region Genel DeğişkEnler
		SqlCommand cmdGenel;
		SqlDataReader drGenel;
		#endregion

		cari.csCariv2 Cari;
		/// <summary>
		/// Burada SAdece IrsaliyeID yi gir sana Irsaliyeyı getirsin hamısına koyim...
		/// </summary>
		/// <param name="Baglanti"></param>
		/// <param name="Tr"></param>
		/// <param name="IrsaliyeID"></param>
		public csIrsaliye(SqlConnection Baglanti, SqlTransaction Tr, int IrsaliyeID)
		{
			IrsaliyeGetir(Baglanti, Tr, IrsaliyeID);
		}
		/// <summary>
		/// Yani Irsaliye oluşturuyorsa sadece Irsaliye Tipi Ve Cari ID lazım
		/// </summary>
		/// <param name="Baglanti"></param>
		/// <param name="Tr"></param>
		/// <param name="IrsaliyeTipi"></param>
		/// <param name="CariID"></param>
		public csIrsaliye(SqlConnection Baglanti, SqlTransaction Tr, int IrsaliyeTipi, int CariID)
		{
			_IrsaliyeID = -1;
			_IrsaliyeTipi = IrsaliyeTipi;
			Cari = new cari.csCariv2(Baglanti, Tr, CariID);
			_CariID = Cari.CariID;
			_CariTanim = "";
			_CariKod = "";
			_IrsaliyeTarihi = DateTime.Now;
			_Vadesi = DateTime.Now;
			_DuzenlemeTarihi = DateTime.Now;
			_Iptal = false;
			_SilindiMi = false;
			_KayitTarihi = DateTime.Now;
			_KaydedenID = -1;
			_Aciklama = "";
			_VergiDairesi = "";
			_VergiNo = "";
			_Adres = "";
			_DepoID = -1;
			_SatisElemaniID = -1;
		}
		/// <summary>
		/// İlk değerleri atamaz sadece IrsaliyeListeGetir için kullanılır! hamısına
		/// </summary>
		public csIrsaliye()
		{

		}
		private void IrsaliyeGetir(SqlConnection Baglanti, SqlTransaction Tr, int IrsaliyeID)
		{
			try
			{
				using (cmdGenel = new SqlCommand())
				{
					cmdGenel.Connection = Baglanti;
					cmdGenel.Transaction = Tr;
					cmdGenel.CommandText = @"
SELECT     dbo.Irsaliye.IrsaliyeID, dbo.Irsaliye.IrsaliyeTipi, dbo.Irsaliye.CariID, dbo.Irsaliye.CariKod, dbo.Irsaliye.VergiDairesi, dbo.Irsaliye.VergiNo, dbo.Irsaliye.Adres, dbo.Irsaliye.Il, dbo.Irsaliye.Ilce, 
                      dbo.Irsaliye.IrsaliyeNo, dbo.Irsaliye.IrsaliyeTarihi, dbo.Irsaliye.Vadesi, dbo.Irsaliye.Iptal, dbo.Irsaliye.SilindiMi, dbo.Irsaliye.KayitTarihi, dbo.Irsaliye.KaydedenID, 
                      dbo.Irsaliye.DegismeTarihi, dbo.Irsaliye.DegistirenID, dbo.Irsaliye.Aciklama, dbo.Cari.CariTanim, dbo.Irsaliye.ToplamIndirim, dbo.Irsaliye.ToplamKdv, 
                      dbo.Irsaliye.Toplam, dbo.Irsaliye.NetToplam, dbo.Irsaliye.DuzenlemeTarihi, dbo.Irsaliye.DepoID, dbo.Irsaliye.SatisElemaniID
FROM         dbo.Irsaliye INNER JOIN
                      dbo.Cari ON dbo.Irsaliye.CariID = dbo.Cari.CariID
WHERE     (dbo.Irsaliye.IrsaliyeID = @IrsaliyeID)";
					cmdGenel.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = IrsaliyeID;
					using (drGenel = cmdGenel.ExecuteReader())
					{
						drGenel.Read();

						_IrsaliyeID = Convert.ToInt32(drGenel["IrsaliyeID"]);
						_IrsaliyeTipi = Convert.ToInt32(drGenel["IrsaliyeTipi"]);
						_CariTanim = drGenel["CariTanim"].ToString();
						_CariID = Convert.ToInt32(drGenel["CariID"]);
						_CariKod = drGenel["CariKod"].ToString();
						_VergiDairesi = drGenel["VergiDairesi"].ToString();
						_VergiNo = drGenel["VergiNo"].ToString();
						_Adres = drGenel["Adres"].ToString();
						_Il = drGenel["Il"].ToString();
						_Ilce = drGenel["Ilce"].ToString();
						_IrsaliyeNo = drGenel["IrsaliyeNo"].ToString();
						_IrsaliyeTarihi = Convert.ToDateTime(drGenel["IrsaliyeTarihi"]);
						_DuzenlemeTarihi = Convert.ToDateTime(drGenel["DuzenlemeTarihi"]);
						_Vadesi = Convert.ToDateTime(drGenel["Vadesi"]);
						_Iptal = Convert.ToBoolean(drGenel["Iptal"]);
						_SilindiMi = Convert.ToBoolean(drGenel["SilindiMi"]);
						_KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"]);
						_KaydedenID = Convert.ToInt32(drGenel["KaydedenID"]);
						_Aciklama = drGenel["Aciklama"].ToString();
						if (drGenel["DepoID"].ToString() != "")
							_DepoID = Convert.ToInt32(drGenel["DepoID"]);
						if (drGenel["SatisElemaniID"].ToString() != "")
							_SatisElemaniID = Convert.ToInt32(drGenel["SatisElemaniID"]);

						_ToplamIndirim = Convert.ToDecimal(drGenel["ToplamIndirim"]);
						_ToplamKdv = Convert.ToDecimal(drGenel["ToplamKdv"]);
						_Toplam = Convert.ToDecimal(drGenel["Toplam"]);
						_NetToplam = Convert.ToDecimal(drGenel["NetToplam"]);
					}
				}
			}
			catch (Exception hata)
			{
				throw new Exception(hata.Message);
			}
		}
		public void IrsaliyeKAydet(SqlConnection Baglanti, SqlTransaction Tr)
		{
			if (_IrsaliyeID == -1)
			{
				cmdGenel = new SqlCommand(@"insert into Irsaliye 
(IrsaliyeTipi, IrsaliyeTarihi, DuzenlemeTarihi, IrsaliyeNo, CariID, CariKod, VergiDairesi, VergiNo, Adres, Il, Ilce, 
ToplamIndirim, ToplamKdv, Toplam, NetToplam, Vadesi, Iptal, SilindiMi, Aciklama, KaydedenID, KayitTarihi,DepoID,SatisElemaniID,Faturalandi) 
  
values (@IrsaliyeTipi, @IrsaliyeTarihi, @DuzenlemeTarihi, @IrsaliyeNo, @CariID, @CariKod, @VergiDairesi, @VergiNo, @Adres, @Il, @Ilce,
@ToplamIndirim, @ToplamKdv, @Toplam, @NetToplam,  @Vadesi, @Iptal, @SilindiMi, @Aciklama, @KaydedenID, @KayitTarihi,@DepoID,@SatisElemaniID, 0) 
set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);

				// bu iki parametre sadece insertte var.
				cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
				cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
				cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
			}
			else
			{
				cmdGenel = new SqlCommand(@"update Irsaliye set 
IrsaliyeTipi=@IrsaliyeTipi, IrsaliyeTarihi=@IrsaliyeTarihi, DuzenlemeTarihi=@DuzenlemeTarihi, IrsaliyeNo=@IrsaliyeNo, CariID=@CariID, CariKod=@CariKod,
VergiDairesi=@VergiDairesi, VergiNo=@VergiNo, Adres=@Adres, Il=@Il, Ilce=@Ilce, 
ToplamIndirim=@ToplamIndirim, ToplamKdv=@ToplamKdv, Toplam=@Toplam, NetToplam=@NetToplam, 
Vadesi=@Vadesi, Iptal=@Iptal, SilindiMi=@SilindiMi, Aciklama=@Aciklama, DegistirenID=@DegistirenID, DegismeTarihi=@DegismeTarihi,DepoID=@DepoID,SatisElemaniID=@SatisElemaniID
where IrsaliyeID = @IrsaliyeID", Baglanti, Tr);

				// bu üç parametre sadece Update te var.
				cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
				cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
				cmdGenel.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = _IrsaliyeID;
			}

			cmdGenel.Parameters.Add("@IrsaliyeTipi", SqlDbType.Int).Value = _IrsaliyeTipi;
			cmdGenel.Parameters.Add("@IrsaliyeTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(_IrsaliyeTarihi);
			cmdGenel.Parameters.Add("@DuzenlemeTarihi", SqlDbType.DateTime).Value = Convert.ToDateTime(_DuzenlemeTarihi);
			cmdGenel.Parameters.Add("@IrsaliyeNo", SqlDbType.NVarChar).Value = _IrsaliyeNo;
			cmdGenel.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
			cmdGenel.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKod;
			cmdGenel.Parameters.Add("@VergiDairesi", SqlDbType.NVarChar).Value = _VergiDairesi;
			cmdGenel.Parameters.Add("@VergiNo", SqlDbType.NVarChar).Value = _VergiNo;
			cmdGenel.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = _Adres;
			cmdGenel.Parameters.Add("@Il", SqlDbType.NVarChar).Value = _Il;
			cmdGenel.Parameters.Add("@Ilce", SqlDbType.NVarChar).Value = _Ilce;
			cmdGenel.Parameters.Add("@ToplamIndirim", SqlDbType.Decimal).Value = _ToplamIndirim;
			cmdGenel.Parameters.Add("@ToplamKdv", SqlDbType.Decimal).Value = _ToplamKdv;
			cmdGenel.Parameters.Add("@Toplam", SqlDbType.Decimal).Value = _Toplam;
			cmdGenel.Parameters.Add("@NetToplam", SqlDbType.Decimal).Value = _NetToplam;
			cmdGenel.Parameters.Add("@Vadesi", SqlDbType.DateTime).Value = Convert.ToDateTime(_Vadesi);
			cmdGenel.Parameters.Add("@Iptal", SqlDbType.Bit).Value = _Iptal;
			cmdGenel.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;
			cmdGenel.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
			cmdGenel.Parameters.Add("@DepoID", SqlDbType.Int).Value = _DepoID;
			cmdGenel.Parameters.Add("@SatisElemaniID", SqlDbType.Int).Value = _SatisElemaniID;
			try
			{
				cmdGenel.ExecuteNonQuery();
				if (_IrsaliyeID == -1)
					_IrsaliyeID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
			}
			catch (Exception hata)
			{
				throw new Exception(hata.Message);
			}
		}
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
