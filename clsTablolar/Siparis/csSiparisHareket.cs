using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Siparis
{
    public class csSiparisHareket : IDisposable
    {
        public DataTable dt_SiparisHareketleri = new DataTable();
        private SqlDataAdapter da_SiparisHareketleri = new SqlDataAdapter();

        public csSiparisHareket(SqlConnection Baglanti, SqlTransaction trGenel, int SiparisID)
        {
            if (SiparisID == -1)
                SiparisHareketleriniGetir(Baglanti, trGenel, SiparisID);
            else
                SiparisHareketleriniGetir(Baglanti, trGenel, SiparisID);

            da_SiparisHareketleri.RowUpdated += da_SiparisHareketleri_RowUpdated;
        }

        void da_SiparisHareketleri_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["SiparisHareketID"] = e.Command.Parameters["@YeniID"].Value;
        }

        public void SiparisHareketleriniKaydet(SqlConnection Baglanti, SqlTransaction trGenel, int SiparisID)
        {
            try
            {
                da_SiparisHareketleri.InsertCommand = new SqlCommand(@"
insert into SiparisHareket 
( SiparisID, SatirNo, StokID, SiparisHareketStokAdi, Miktar, StokAnaBirimID, AnaBirimFiyat, Birim2ID, 
KatSayi, Birim2Fiyat, Kdv, Toplam, 
StokIskonto1, StokIskonto1Tutari, StokIskonto1SonrasiTutar, 
StokIskonto2, StokIskonto2Tutari, StokIskonto2SonrasiTutar, 
StokIskonto3, StokIskonto3Tutari, StokIskonto3SonrasiTutar, 
CariIskonto1, CariIskonto1Tutari, CariIskonto1SonrasiTutar, 
CariIskonto2, CariIskonto2Tutari, CariIskonto2SonrasiTutar, 
CariIskonto3, CariIskonto3Tutari, CariIskonto3SonrasiTutar, 
IskontoluFiyat, SatirIndirimliToplam, SatirAciklama, DepoID, 
StokToplamIskonto, CariToplamIskonto, ToplamIskonto, KdvTutari, AltBirimMiktar, FireMiktari, BirlesikUrunHareketID ) 
values 
(  @SiparisID, @SatirNo, @StokID, @SiparisHareketStokAdi, @Miktar, @StokAnaBirimID, @AnaBirimFiyat, @Birim2ID, 
@KatSayi, @Birim2Fiyat, @Kdv, @Toplam, 
@StokIskonto1, @StokIskonto1Tutari, @StokIskonto1SonrasiTutar, 
@StokIskonto2, @StokIskonto2Tutari, @StokIskonto2SonrasiTutar, 
@StokIskonto3, @StokIskonto3Tutari, @StokIskonto3SonrasiTutar, 
@CariIskonto1, @CariIskonto1Tutari, @CariIskonto1SonrasiTutar, 
@CariIskonto2, @CariIskonto2Tutari, @CariIskonto2SonrasiTutar, 
@CariIskonto3, @CariIskonto3Tutari, @CariIskonto3SonrasiTutar, 
@IskontoluFiyat, @SatirIndirimliToplam, @SatirAciklama, @DepoID, 
@StokToplamIskonto, @CariToplamIskonto, @ToplamIskonto, @KdvTutari, @AltBirimMiktar, @FireMiktari, @BirlesikUrunHareketID ) set @YeniID = SCOPE_IDENTITY()  "
        , Baglanti, trGenel);
                #region İNSERT PARAMETRELERİ
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;


                da_SiparisHareketleri.InsertCommand.Parameters.Add("@SiparisID", SqlDbType.Int).Value = SiparisID;
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@SatirNo", SqlDbType.Int, 0, "SatirNo");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@SiparisHareketStokAdi", SqlDbType.NVarChar, 250, "SiparisHareketStokAdi");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokAnaBirimID", SqlDbType.Int, 0, "StokAnaBirimID");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@AnaBirimFiyat", SqlDbType.Decimal, 0, "AnaBirimFiyat");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@Birim2ID", SqlDbType.Int, 0, "Birim2ID");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@Birim2Fiyat", SqlDbType.Decimal, 0, "Birim2Fiyat");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@Kdv", SqlDbType.Decimal, 0, "Kdv");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@Toplam", SqlDbType.Decimal, 0, "Toplam");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto1", SqlDbType.Decimal, 0, "StokIskonto1");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto1Tutari", SqlDbType.Decimal, 0, "StokIskonto1Tutari");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto1SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto1SonrasiTutar");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto2", SqlDbType.Decimal, 0, "StokIskonto2");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto2Tutari", SqlDbType.Decimal, 0, "StokIskonto2Tutari");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto2SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto2SonrasiTutar");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto3", SqlDbType.Decimal, 0, "StokIskonto3");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto3Tutari", SqlDbType.Decimal, 0, "StokIskonto3Tutari");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokIskonto3SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto3SonrasiTutar");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto1", SqlDbType.Decimal, 0, "CariIskonto1");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto1Tutari", SqlDbType.Decimal, 0, "CariIskonto1Tutari");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto1SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto1SonrasiTutar");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto2", SqlDbType.Decimal, 0, "CariIskonto2");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto2Tutari", SqlDbType.Decimal, 0, "CariIskonto2Tutari");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto2SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto2SonrasiTutar");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto3", SqlDbType.Decimal, 0, "CariIskonto3");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto3Tutari", SqlDbType.Decimal, 0, "CariIskonto3Tutari");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariIskonto3SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto3SonrasiTutar");

                da_SiparisHareketleri.InsertCommand.Parameters.Add("@SatirIndirimliToplam", SqlDbType.Decimal, 0, "SatirIndirimliToplam");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@SatirAciklama", SqlDbType.NVarChar, 250, "SatirAciklama");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@StokToplamIskonto", SqlDbType.Decimal, 0, "StokToplamIskonto");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@CariToplamIskonto", SqlDbType.Decimal, 0, "CariToplamIskonto");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@DepoID", SqlDbType.Int, 0, "DepoID");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@ToplamIskonto", SqlDbType.Decimal, 0, "ToplamIskonto");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@KdvTutari", SqlDbType.Decimal, 0, "KdvTutari");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@IskontoluFiyat", SqlDbType.Decimal, 0, "IskontoluFiyat");


                da_SiparisHareketleri.InsertCommand.Parameters.Add("@AltBirimMiktar", SqlDbType.Decimal, 0, "AltBirimMiktar");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@FireMiktari", SqlDbType.Decimal, 0, "FireMiktari");
                da_SiparisHareketleri.InsertCommand.Parameters.Add("@BirlesikUrunHareketID", SqlDbType.Int, 0, "BirlesikUrunHareketID");
                #endregion

                da_SiparisHareketleri.UpdateCommand = new SqlCommand(@"update SiparisHareket set 
SiparisID = @SiparisID, SatirNo = @SatirNo, StokID = @StokID, SiparisHareketStokAdi = @SiparisHareketStokAdi, 
Miktar = @Miktar, StokAnaBirimID = @StokAnaBirimID, AnaBirimFiyat = @AnaBirimFiyat, Birim2ID = @Birim2ID, 
KatSayi = @KatSayi, Birim2Fiyat = @Birim2Fiyat, Kdv = @Kdv, Toplam = @Toplam, 
StokIskonto1 = @StokIskonto1, StokIskonto1Tutari = @StokIskonto1Tutari, StokIskonto1SonrasiTutar = @StokIskonto1SonrasiTutar, 
StokIskonto2 = @StokIskonto2, StokIskonto2Tutari = @StokIskonto2Tutari, StokIskonto2SonrasiTutar = @StokIskonto2SonrasiTutar, 
StokIskonto3 = @StokIskonto3, StokIskonto3Tutari = @StokIskonto3Tutari, StokIskonto3SonrasiTutar = @StokIskonto3SonrasiTutar, 
CariIskonto1 = @CariIskonto1, CariIskonto1Tutari = @CariIskonto1Tutari, CariIskonto1SonrasiTutar = @CariIskonto1SonrasiTutar, 
CariIskonto2 = @CariIskonto2, CariIskonto2Tutari = @CariIskonto2Tutari, CariIskonto2SonrasiTutar = @CariIskonto2SonrasiTutar, 
CariIskonto3 = @CariIskonto3, CariIskonto3Tutari = @CariIskonto3Tutari, CariIskonto3SonrasiTutar = @CariIskonto3SonrasiTutar, 
IskontoluFiyat = @IskontoluFiyat, SatirIndirimliToplam = @SatirIndirimliToplam, SatirAciklama = @SatirAciklama, 
DepoID = @DepoID, StokToplamIskonto = @StokToplamIskonto, CariToplamIskonto = @CariToplamIskonto, ToplamIskonto = @ToplamIskonto, AltBirimMiktar = @AltBirimMiktar, FireMiktari = @FireMiktari, BirlesikUrunHareketID = @BirlesikUrunHareketID,
KdvTutari = @KdvTutari  where SiparisHareketID = @SiparisHareketID  ", Baglanti, trGenel);
                #region UPDATE PARAMETRELERİ
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@SiparisHareketID", SqlDbType.Int, 15, "SiparisHareketID");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@SiparisID", SqlDbType.Int).Value = SiparisID;
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@SatirNo", SqlDbType.Int, 0, "SatirNo");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");

                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@SiparisHareketStokAdi", SqlDbType.NVarChar, 250, "SiparisHareketStokAdi");

                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokAnaBirimID", SqlDbType.Int, 0, "StokAnaBirimID");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@AnaBirimFiyat", SqlDbType.Decimal, 0, "AnaBirimFiyat");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@Birim2ID", SqlDbType.Int, 0, "Birim2ID");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@Birim2Fiyat", SqlDbType.Decimal, 0, "Birim2Fiyat");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@Kdv", SqlDbType.Decimal, 0, "Kdv");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@Toplam", SqlDbType.Decimal, 0, "Toplam");

                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto1", SqlDbType.Decimal, 0, "StokIskonto1");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto1Tutari", SqlDbType.Decimal, 0, "StokIskonto1Tutari");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto1SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto1SonrasiTutar");

                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto2", SqlDbType.Decimal, 0, "StokIskonto2");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto2Tutari", SqlDbType.Decimal, 0, "StokIskonto2Tutari");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto2SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto2SonrasiTutar");

                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto3", SqlDbType.Decimal, 0, "StokIskonto3");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto3Tutari", SqlDbType.Decimal, 0, "StokIskonto3Tutari");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokIskonto3SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto3SonrasiTutar");

                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto1", SqlDbType.Decimal, 0, "CariIskonto1");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto1Tutari", SqlDbType.Decimal, 0, "CariIskonto1Tutari");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto1SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto1SonrasiTutar");

                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto2", SqlDbType.Decimal, 0, "CariIskonto2");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto2Tutari", SqlDbType.Decimal, 0, "CariIskonto2Tutari");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto2SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto2SonrasiTutar");

                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto3", SqlDbType.Decimal, 0, "CariIskonto3");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto3Tutari", SqlDbType.Decimal, 0, "CariIskonto3Tutari");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariIskonto3SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto3SonrasiTutar");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@SatirIndirimliToplam", SqlDbType.Decimal, 0, "SatirIndirimliToplam");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@SatirAciklama", SqlDbType.NVarChar, 250, "SatirAciklama");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@StokToplamIskonto", SqlDbType.Decimal, 0, "StokToplamIskonto");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@CariToplamIskonto", SqlDbType.Decimal, 0, "CariToplamIskonto");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@DepoID", SqlDbType.Int, 0, "DepoID");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@ToplamIskonto", SqlDbType.Decimal, 0, "ToplamIskonto");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@KdvTutari", SqlDbType.Decimal, 0, "KdvTutari");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@IskontoluFiyat", SqlDbType.Decimal, 0, "IskontoluFiyat");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@AltBirimMiktar", SqlDbType.Decimal, 0, "AltBirimMiktar");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@FireMiktari", SqlDbType.Decimal, 0, "FireMiktari");
                da_SiparisHareketleri.UpdateCommand.Parameters.Add("@BirlesikUrunHareketID", SqlDbType.Int, 0, "BirlesikUrunHareketID");


                #endregion

                da_SiparisHareketleri.DeleteCommand = new SqlCommand("delete SiparisHareket where SiparisHareketID = @SiparisHareketID", Baglanti, trGenel);
                da_SiparisHareketleri.DeleteCommand.Parameters.Add("@SiparisHareketID", SqlDbType.Int, 20, "SiparisHareketID");




                da_SiparisHareketleri.InsertCommand.Transaction = trGenel;
                da_SiparisHareketleri.UpdateCommand.Transaction = trGenel;
                da_SiparisHareketleri.DeleteCommand.Transaction = trGenel;


                da_SiparisHareketleri.Update(dt_SiparisHareketleri);


            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }

        private void SiparisHareketleriniGetir(SqlConnection Baglanti, SqlTransaction trGenel, int SiparisID)
        {
            try
            {
                da_SiparisHareketleri.SelectCommand = new SqlCommand(@"
--declare @SiparisID int = 30
declare @SiparisMiFaturaMi tinyint = 0

if ( select Top 1 EvrakIsliski.IrsaliyeID from EvrakIsliski where SiparisID = @SiparisID) is not null 
begin
set @SiparisMiFaturaMi = 1
end
else if ( select Top 1 EvrakIsliski.FaturaID from EvrakIsliski where SiparisID = @SiparisID) is not null 
begin
set @SiparisMiFaturaMi = 2
end

select SiparisHareketID, SiparisHareket.SiparisID, SatirNo, StokID, SiparisHareketStokAdi, Miktar, 

case when @SiparisMiFaturaMi = 2
then (
select sum(FaturaHareket.Miktar) from EvrakIsliski
inner join FaturaHareket on FaturaHareket.FaturaID = EvrakIsliski.FaturaID and SiparisHareket.SiparisID = EvrakIsliski.SiparisID and FaturaHareket.StokID = SiparisHareket.StokID
inner join Fatura on Fatura.FaturaID = EvrakIsliski.FaturaID and  Fatura.SilindiMi = 0
group by FaturaHareket.StokID
)
end  as 'Teslim Miktar',

StokAnaBirimID, AnaBirimFiyat, Birim2ID, StokBirim.BirimAdi as StokAltBirimAdi, 
AltBirimMiktar, KatSayi, Birim2Fiyat, 
Kdv, Toplam, StokIskonto1, StokIskonto1Tutari, StokIskonto1SonrasiTutar, StokIskonto2, StokIskonto2Tutari, StokIskonto2SonrasiTutar, StokIskonto3, StokIskonto3Tutari, 
StokIskonto3SonrasiTutar, CariIskonto1, CariIskonto1Tutari, CariIskonto1SonrasiTutar, CariIskonto2, CariIskonto2Tutari, CariIskonto2SonrasiTutar, CariIskonto3, CariIskonto3Tutari, 
CariIskonto3SonrasiTutar, IskontoluFiyat, SatirIndirimliToplam, SatirAciklama, DepoID, StokToplamIskonto, CariToplamIskonto, ToplamIskonto, KdvTutari, AltBirimMiktar, FireMiktari, BirlesikUrunHareketID

from SiparisHareket
left join StokBirim on StokBirim.BirimID = SiparisHareket.Birim2ID


WHERE     (SiparisHareket.SiparisID = @SiparisID)", Baglanti, trGenel);

                da_SiparisHareketleri.SelectCommand.Parameters.Add("@SiparisID", SqlDbType.Int).Value = SiparisID;

                using (dt_SiparisHareketleri = new DataTable())
                {
                    da_SiparisHareketleri.Fill(dt_SiparisHareketleri);

                    if (dt_SiparisHareketleri.Columns[dt_SiparisHareketleri.Columns.Count - 1].ColumnName != "KdvDahilToplam") // şimdilik bu eğeri yazdım (çünkü aynı kolonları birer defa daha eklemesin diye) sonra 
                    {
                        dt_SiparisHareketleri.Columns.Add("KdvDahilFiyat", Type.GetType("System.Decimal")).Expression = "IskontoluFiyat + ((Kdv * IskontoluFiyat)/ 100)";


                        dt_SiparisHareketleri.Columns.Add("AltBirimKdvDahilFiyat", Type.GetType("System.Decimal")).Expression = "(IskontoluFiyat * KatSayi) + ((Kdv * (IskontoluFiyat * KatSayi))/ 100)";
                        dt_SiparisHareketleri.Columns.Add("AltBirimKdvDahilToplam", Type.GetType("System.Decimal")).Expression = "SatirIndirimliToplam + KdvTutari";

                        dt_SiparisHareketleri.Columns.Add("KdvDahilToplam", Type.GetType("System.Decimal")).Expression = "SatirIndirimliToplam + KdvTutari";






                        dt_SiparisHareketleri.Columns.Add("AltBirimKdvDahilIndirimHaricFiyat", Type.GetType("System.Decimal")).Expression = "(AnaBirimFiyat * KatSayi) + ((Kdv * (AnaBirimFiyat * KatSayi))/ 100)";


                        dt_SiparisHareketleri.Columns.Add("KdvDahilStokIskonto1IndirimMiktari", Type.GetType("System.Decimal")).Expression = "(AltBirimKdvDahilIndirimHaricFiyat * AltBirimMiktar) - SatirIndirimliToplam - KdvTutari ";


                        //dt_FaturaHareketleri.Columns.Add("KdvDahilToplamIndirim", Type.GetType("System.Decimal")).Expression = "SatirIndirimliToplam + KdvTutari";
                        //dt_FaturaHareketleri.Columns.Add("KdvDahilToplamIndirim", Type.GetType("System.Decimal")).Expression = "SatirIndirimliToplam + KdvTutari";
                    }
                }
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
