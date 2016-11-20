using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Irsaliye
{
	public class csIrsaliyeArama : IDisposable
	{
		private int _IrsaliyeAramaID;
		private string _CariTanimi;
		private int _GrubuID;
		private int _IrsaliyeTipi;

		public int IrsaliyeAramaID
		{
			get { return _IrsaliyeAramaID; }
			set { _IrsaliyeAramaID = value; }
		}
		public string CariTanimi
		{
			get { return _CariTanimi; }
			set { _CariTanimi = value; }
		}
		public int GrubuID
		{
			get { return _GrubuID; }
			set { _GrubuID = value; }
		}
		public int IrsaliyeTipi
		{
			get { return _IrsaliyeTipi; }
			set { _IrsaliyeTipi = value; }
		}

		DataTable dt_IrsaliyeListesi;
		SqlDataAdapter da_IrsaliyeListesi;

		public csIrsaliyeArama(SqlConnection Baglanti, SqlTransaction Tr, int IrsaliyeAramaID)
		{
			if (IrsaliyeAramaID == -1)
			{
				_CariTanimi = ""; // string alanlar için "" (boş) gelmişse oralarda arama yapmayacak
				_GrubuID = -1; // int için olan alanlar yani ID gerektiren alanlarda -1 gelmişse oralarda arama yapmaycak
				_IrsaliyeTipi = -1;
			}
		}
		public DataTable IrsaliyeAraListe(SqlConnection Baglanti, SqlTransaction Tr)
		{
			try
			{
				da_IrsaliyeListesi = new SqlDataAdapter();
				string WhereCumlesi =
					@"
SELECT    
CASE 
WHEN Faturalandi = 1 THEN 'F' ELSE '' END as F,

dbo.Irsaliye.IrsaliyeID, dbo.Irsaliye.IrsaliyeNo, 
CASE 
WHEN IrsaliyeTipi = 1 THEN 'SATIŞ İRSALİYESİ' 
WHEN IrsaliyeTipi = 2 THEN 'ALIŞ İRSALİYESİ' 
WHEN IrsaliyeTipi = 3 THEN 'SATIŞTAN İADE İRSALİYESİ' 
WHEN IrsaliyeTipi = 4 THEN 'ALIŞTAN İADE İRSALİYESİ' 
WHEN IrsaliyeTipi = 6 THEN 'SATIŞ İRSALİYESİ' 
WHEN IrsaliyeTipi = 7 THEN 'ALIŞ İRSALİYESİ' 
WHEN IrsaliyeTipi = 8 THEN 'SATIŞ İADE İRSALİYESİ' 
WHEN IrsaliyeTipi = 9 THEN 'ALIŞ İADE İRSALİYESİ' 
END AS IrsaliyeTipi_, dbo.Irsaliye.IrsaliyeTipi, dbo.Irsaliye.CariID, dbo.Cari.CariKod, dbo.Cari.CariTanim, dbo.Irsaliye.IrsaliyeTarihi, dbo.Irsaliye.DuzenlemeTarihi, dbo.Irsaliye.ToplamIndirim, 
  dbo.Irsaliye.ToplamKdv, dbo.Irsaliye.Toplam, dbo.Irsaliye.NetToplam, dbo.Irsaliye.Vadesi,
CASE WHEN dbo.Irsaliye.Iptal =1 THEN 'İPTAL EDİLDİ' ELSE '' end AS Iptal , CASE WHEN dbo.Irsaliye.SilindiMi =1 THEN 'SİLİNDİ' ELSE '' END AS SilindiMi, dbo.Irsaliye.Aciklama
FROM  dbo.Irsaliye INNER JOIN  dbo.Cari ON dbo.Irsaliye.CariID = dbo.Cari.CariID
WHERE     (1 = 1)
";

				da_IrsaliyeListesi.SelectCommand = new SqlCommand("", Baglanti, Tr);

				if (_CariTanimi != "")
				{
					WhereCumlesi += " and CariTanimi like @CariTanimi";
					da_IrsaliyeListesi.SelectCommand.Parameters.Add("@CariTanimi", SqlDbType.NVarChar).Value = _CariTanimi + "%";
				}
				if (_GrubuID != -1)
				{
					WhereCumlesi += " and GrubuID = @GrubuID";
					da_IrsaliyeListesi.SelectCommand.Parameters.Add("@GrubuID", SqlDbType.Int).Value = _GrubuID;
				}
				if (_IrsaliyeTipi != -1)
				{
					WhereCumlesi += " and IrsaliyeTipi = @IrsaliyeTipi";
					da_IrsaliyeListesi.SelectCommand.Parameters.Add("@IrsaliyeTipi", SqlDbType.Int).Value = _IrsaliyeTipi;
				}
				da_IrsaliyeListesi.SelectCommand.CommandText = WhereCumlesi;
				dt_IrsaliyeListesi = new DataTable();
				da_IrsaliyeListesi.Fill(dt_IrsaliyeListesi);
				dt_IrsaliyeListesi.Columns.Add("Secim", typeof(System.Boolean));
				return dt_IrsaliyeListesi;
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
