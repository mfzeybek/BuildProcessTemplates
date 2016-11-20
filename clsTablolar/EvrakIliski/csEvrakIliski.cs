using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.EvrakIliski
{
    public class csEvrakIliski : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;

        public csEvrakIliski()
        {
            dt = new DataTable();
            dt.Columns.Add("EvrakIliskiID", Type.GetType("System.Int32"));
            dt.Columns.Add("TeklifID", Type.GetType("System.Int32"));
            dt.Columns.Add("SiparisID", Type.GetType("System.Int32"));
            dt.Columns.Add("IrsaliyeID", Type.GetType("System.Int32"));
            dt.Columns.Add("FaturaID", Type.GetType("System.Int32"));

        }
        public void FaturadanEvrakIliskiGetir(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            using (da = new SqlDataAdapter("SELECT * FROM EvrakIsliski where FaturaID = @FaturaID ", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@FaturaID", SqlDbType.Int, 0).Value = FaturaID;
                dt = new DataTable();
                da.Fill(dt);
                da.RowUpdated += da_RowUpdated;
            }
        }
        public void FaturaEvrakIlıski_BosSatirEkle()
        {
            dt.Rows.Add(dt.NewRow());
        }

        void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["EvrakIliskiID"] = e.Command.Parameters["@YeniID"].Value;
        }


        public void FaturaIcinEvrakIliskiKaydet(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            using (da = new SqlDataAdapter())
            {
                da.InsertCommand = new SqlCommand(@"
      insert into EvrakIsliski 
      (TeklifID, SiparisID, IrsaliyeID, FaturaID) 
      values 
      (@TeklifID, @SiparisID, @IrsaliyeID, @FaturaID) set @YeniID = SCOPE_IDENTITY() ", Baglanti, Tr);

                da.InsertCommand.Parameters.Add("@TeklifID", SqlDbType.Int, 0, "TeklifID");
                da.InsertCommand.Parameters.Add("@SiparisID", SqlDbType.Int, 0, "SiparisID");
                da.InsertCommand.Parameters.Add("@IrsaliyeID", SqlDbType.Int, 0, "IrsaliyeID");
                da.InsertCommand.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;

                da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;


                da.UpdateCommand = new SqlCommand(@"
      update EvrakIsliski set TeklifID = @TeklifID, SiparisID = @SiparisID, IrsaliyeID = @IrsaliyeID, FaturaID = @FaturaID where EvrakIliskiID = @EvrakIliskiID", Baglanti, Tr);

                da.UpdateCommand.Parameters.Add("@TeklifID", SqlDbType.Int, 0, "TeklifID");
                da.UpdateCommand.Parameters.Add("@SiparisID", SqlDbType.Int, 0, "SiparisID");
                da.UpdateCommand.Parameters.Add("@IrsaliyeID", SqlDbType.Int, 0, "IrsaliyeID");
                da.UpdateCommand.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
                da.UpdateCommand.Parameters.Add("@EvrakIliskiID", SqlDbType.Int, 0, "EvrakIliskiID");

                da.Update(dt);
            }
        }


        public enum SiparisinFaturayaAktarilmaDurumu
        {
            Faturalandi = 1,
            Faturalanmadi = 2,
            FaturalandiAmaFaturaSilinmis = 3
        }

        public SiparisinFaturayaAktarilmaDurumu SiparisFaturayaAktarilmisMi(SqlConnection Baglanti, SqlTransaction Tr, int SiparisID)
        {
            using (SqlCommand cmd = new SqlCommand(@"select dbo.SiparisMuhasebelendiMi(" + SiparisID + ")", Baglanti, Tr))
            {
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@siparisID", SqlDbType.Int, 0).Value = SiparisID;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {// dönen ilk satırdaki ilk değer 1 ise Faturalandı, 2 ise Faturalanmadı
                        switch (Convert.ToInt32(dr[0]))
                        {
                            case 1: return SiparisinFaturayaAktarilmaDurumu.Faturalandi;
                            case 2:
                                return SiparisinFaturayaAktarilmaDurumu.Faturalanmadi;
                            case 3: return SiparisinFaturayaAktarilmaDurumu.FaturalandiAmaFaturaSilinmis;
                            default:
                                return SiparisinFaturayaAktarilmaDurumu.Faturalanmadi;
                        }
                    }
                    else
                        return SiparisinFaturayaAktarilmaDurumu.Faturalanmadi;
                }
            }
        }

        public void IrsaliyedenEvrakIliskiGetir(SqlConnection Baglanti, SqlTransaction Tr, int IrsaliyeID)
        {
            //using (da = new SqlDataAdapter("SELECT * FROM EvrakIsliski where SiparisID = @SiparisID ", Baglanti))
            //{
            //    da.SelectCommand.Transaction = Tr;
            //    da.SelectCommand.Parameters.Add("@SiparisID", SqlDbType.Int, 0).Value = SiparisID;
            //    dt = new DataTable();
            //    da.Fill(dt);
            //    da.RowUpdated += da_RowUpdated;
            //}
        }
        public void SiparistenEvrakIliskiGetir(SqlConnection Baglanti, SqlTransaction Tr, int SiparisID)
        {
            using (da = new SqlDataAdapter(@"SELECT EvrakIsliski.*, Fatura.CariTanim, FaturaTarihi, FaturaTutari FROM EvrakIsliski
left join Fatura on fatura.FaturaID = EvrakIsliski.FaturaID and Fatura.SilindiMi = 0
where EvrakIsliski.SiparisID = @SiparisID", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@SiparisID", SqlDbType.Int, 0).Value = SiparisID;
                dt = new DataTable();
                da.Fill(dt);
                da.RowUpdated += da_RowUpdated;
            }
        }
    }
}

