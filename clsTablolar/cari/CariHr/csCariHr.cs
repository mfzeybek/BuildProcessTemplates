using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari.CariHr
{
    public class csCariHr : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private int _CariHrID;
        private int _CariID;
        private DateTime _Tarih;
        private HareketYonu _AlacakMiBorcMu;
        private string _Aciklama;
        private string _EvrakNo;
        private decimal _Tutar;
        private CariHrEntegrasyon _Entegrasyon;
        private int _EntegrasyonID;
        private bool _Devirmi;
        private bool _SilindiMi;
        private int _KasaID;
        private int _KasaHrID;

        public int _FaturaID { get; set; }

        public bool SilindiMi
        {
            get { return _SilindiMi; }
            set { _SilindiMi = value; }
        }


        public bool Devirmi
        {
            get { return _Devirmi; }
            set { _Devirmi = value; }
        }



        public int CariHrID
        {
            get { return _CariHrID; }
            set { _CariHrID = value; }
        }
        public int CariID
        {
            get { return _CariID; }
            set { _CariID = value; }
        }
        public DateTime Tarih
        {
            get { return _Tarih; }
            set { _Tarih = value; }
        }
        public HareketYonu AlacakMiBorcMu
        {
            get { return _AlacakMiBorcMu; }
            set { _AlacakMiBorcMu = value; }
        }
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }
        public string EvrakNo
        {
            get { return _EvrakNo; }
            set { _EvrakNo = value; }
        }
        public decimal Tutar
        {
            get { return _Tutar; }
            set { _Tutar = value; }
        }
        public CariHrEntegrasyon Entegrasyon
        {
            get { return _Entegrasyon; }
            set { _Entegrasyon = value; }
        }
        public int EntegrasyonID
        {
            get { return _EntegrasyonID; }
            set { _EntegrasyonID = value; }
        }

        public int KasaHrID
        {
            get
            {
                return _KasaHrID;
            }

            set
            {
                _KasaHrID = value;
            }
        }

        public int KasaID
        {
            get
            {
                return _KasaID;
            }

            set
            {
                _KasaID = value;
            }
        }

        SqlCommand cmd;
        SqlDataReader dr;


        /// <summary>
        /// Hareket kartını açarken
        /// 
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="CariHrID"></param>
        public csCariHr(SqlConnection Baglanti, SqlTransaction Tr, int CariHrID)
        {
            if (CariHrID == -1)
            {
                _CariHrID = -1;
                _CariID = -1;
                _Tarih = DateTime.Now;
                _AlacakMiBorcMu = HareketYonu.Alacak;
                _Aciklama = "";
                _EvrakNo = "";
                _Tutar = 0;
                _Entegrasyon = CariHrEntegrasyon.CariKartHareketi;
                _EntegrasyonID = -1; // Eğer CariKart Hareketi ise bu aslında bi entegrasyon değildir.
                _Devirmi = false;
                _SilindiMi = false;
                _FaturaID = -1;
                _KasaHrID = -1;
            }
            else
            {
                HareketiGetir(Baglanti, Tr, CariHrID);
            }
        }

        public csCariHr() { }

        public void CariHrKaydet(SqlConnection Baglanti, SqlTransaction Tr, CariHrEntegrasyon Entegrasyonn, int EntegrasyonID)
        {
            cmd = new SqlCommand(@"

if (select CariHr.Entegrasyon from CariHr where CariHr.EntegrasyonID = @EntegrasyonID and CariHr.Entegrasyon = @Entegrasyon) = @Entegrasyon
begin
update CariHr set 
                 CariID = @CariID, Tarih = @Tarih, AlacakMiBorcMu = @AlacakMiBorcMu, Aciklama = @Aciklama,
                 EvrakNo = @EvrakNo, Tutar = @Tutar, Entegrasyon = @Entegrasyon, EntegrasyonID = @EntegrasyonID, Devirmi = @Devirmi, SilindiMi = @SilindiMi, CariHr.FaturaID = @FaturaID
where CariHr.EntegrasyonID = @EntegrasyonID and CariHr.Entegrasyon = @Entegrasyon
end
else
begin
insert into CariHr 
                                    ( CariID, Tarih, AlacakMiBorcMu, Aciklama, EvrakNo, Tutar, Entegrasyon, EntegrasyonID, Devirmi, SilindiMi, FaturaID, KasaID, KasaHrID ) 
                                    values 
                                    ( @CariID, @Tarih, @AlacakMiBorcMu, @Aciklama, @EvrakNo, @Tutar, @Entegrasyon, @EntegrasyonID, @Devirmi, @SilindiMi , @FaturaID)
end", Baglanti, Tr);

            cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
            cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = _Tarih;
            cmd.Parameters.Add("@AlacakMiBorcMu", SqlDbType.TinyInt).Value = Convert.ToInt32(_AlacakMiBorcMu);
            cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
            cmd.Parameters.Add("@EvrakNo", SqlDbType.NVarChar).Value = _EvrakNo;
            cmd.Parameters.Add("@Tutar", SqlDbType.Decimal).Value = _Tutar;
            cmd.Parameters.Add("@Entegrasyon", SqlDbType.TinyInt).Value = Convert.ToInt32(Entegrasyonn);
            cmd.Parameters.Add("@EntegrasyonID", SqlDbType.Int).Value = EntegrasyonID;
            cmd.Parameters.Add("@Devirmi", SqlDbType.Bit).Value = _Devirmi;
            cmd.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;
            cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = _FaturaID;
            cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = _KasaID;
            cmd.Parameters.Add("@KasaHrID", SqlDbType.Int).Value = _KasaHrID;

            cmd.ExecuteNonQuery();
        }

        private void HareketiGetir(SqlConnection Baglanti, SqlTransaction Tr, int CariHrID)
        {
            using (cmd = new SqlCommand("select * from CariHr where CariHrID = @CariHrID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@CariHrID", SqlDbType.Int).Value = CariHrID;
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) // (IslemTipi)Enum.Parse(typeof(IslemTipi), drGenel["FaturaTipi"].ToString());
                    {
                        _CariHrID = Convert.ToInt32(dr["CariHrID"]);
                        _CariID = Convert.ToInt32(dr["CariID"]);
                        _Tarih = Convert.ToDateTime(dr["Tarih"]);
                        _AlacakMiBorcMu = (HareketYonu)(Convert.ToInt32(dr["AlacakMiBorcMu"]));
                        _Aciklama = dr["Aciklama"].ToString();
                        _EvrakNo = dr["EvrakNo"].ToString();
                        _Tutar = Convert.ToDecimal(dr["Tutar"]);
                        _Entegrasyon = (CariHrEntegrasyon)Convert.ToInt32(dr["Entegrasyon"]);
                        _EntegrasyonID = Convert.ToInt32(dr["EntegrasyonID"]); // Eğer CariKart Hareketi ise bu aslında bi entegrasyon değildir.
                        _Devirmi = Convert.ToBoolean(dr["Devirmi"]);
                    }
                }

            }
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            if (_CariHrID == -1)
            {
                using (cmd = new SqlCommand(@"insert into CariHr 
                                    ( CariID, Tarih, AlacakMiBorcMu, Aciklama, EvrakNo, Tutar, Entegrasyon, EntegrasyonID, Devirmi, SilindiMi, FaturaID ) 
                                    values 
                                    ( @CariID, @Tarih, @AlacakMiBorcMu, @Aciklama, @EvrakNo, @Tutar, @Entegrasyon, @EntegrasyonID, @Devirmi, @SilindiMi , @FaturaID) set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr))
                {
                    cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
                    cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = _Tarih;
                    cmd.Parameters.Add("@AlacakMiBorcMu", SqlDbType.TinyInt).Value = Convert.ToInt32(_AlacakMiBorcMu);
                    cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
                    cmd.Parameters.Add("@EvrakNo", SqlDbType.NVarChar).Value = _EvrakNo;
                    cmd.Parameters.Add("@Tutar", SqlDbType.Decimal).Value = _Tutar;
                    cmd.Parameters.Add("@Entegrasyon", SqlDbType.TinyInt).Value = Convert.ToInt32(_Entegrasyon);
                    cmd.Parameters.Add("@EntegrasyonID", SqlDbType.Int).Value = _EntegrasyonID;
                    cmd.Parameters.Add("@Devirmi", SqlDbType.Bit).Value = _Devirmi;
                    cmd.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;
                    cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = _FaturaID;


                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();

                    _CariHrID = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);
                }
            }
            else
            {
                using (cmd = new SqlCommand(@"update CariHr set 
                          CariID = @CariID, Tarih = @Tarih, AlacakMiBorcMu = @AlacakMiBorcMu, Aciklama = @Aciklama,
                          EvrakNo = @EvrakNo, Tutar = @Tutar, Entegrasyon = @Entegrasyon, EntegrasyonID = @EntegrasyonID, Devirmi = @Devirmi, SilindiMi = @SilindiMi, FaturaID = @FaturaID where CariHrID = @CariHrID", Baglanti, Tr))
                {
                    cmd.Parameters.Add("@CariHrID", SqlDbType.Int).Value = _CariHrID;

                    cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = _CariID;
                    cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = _Tarih;
                    cmd.Parameters.Add("@AlacakMiBorcMu", SqlDbType.TinyInt).Value = Convert.ToInt32(_AlacakMiBorcMu);
                    cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
                    cmd.Parameters.Add("@EvrakNo", SqlDbType.NVarChar).Value = _EvrakNo;
                    cmd.Parameters.Add("@Tutar", SqlDbType.Decimal).Value = _Tutar;
                    cmd.Parameters.Add("@Entegrasyon", SqlDbType.TinyInt).Value = Convert.ToInt32(_Entegrasyon);
                    cmd.Parameters.Add("@EntegrasyonID", SqlDbType.Int).Value = _EntegrasyonID;
                    cmd.Parameters.Add("@SilindiMi", SqlDbType.Bit).Value = _SilindiMi;
                    cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = _FaturaID;

                    cmd.Parameters.Add("@Devirmi", SqlDbType.Bit).Value = _Devirmi;

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public DataTable FaturaninOdemeleriniGetir(SqlConnection Baglanti, SqlTransaction Tr, int FaturaninIDsi)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select * from CariHr where FaturaID = @FaturaID ", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaninIDsi;
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
