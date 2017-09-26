using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public class csStokGrupV2 : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DataTable dt;
        SqlDataAdapter da;

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            try
            {
                da.InsertCommand = new SqlCommand("insert into StokGrupV2 (StokID, StokGrupID) values (@StokID, @StokGrupID) set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);
                da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                da.InsertCommand.Parameters.Add("@StokGrupID", SqlDbType.Int, 0, "StokGrupID");
                da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;


                //da.RowUpdated += Da_RowUpdated1;

                da.UpdateCommand = new SqlCommand("update StokGrupV2 set StokID = @StokID, StokGrupID = @StokGrupID where ID = @ID ", Baglanti, Tr);

                da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                da.UpdateCommand.Parameters.Add("@StokGrupID", SqlDbType.Int, 0, "StokGrupID");
                da.UpdateCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");


                da.DeleteCommand = new SqlCommand("delete from StokGrupV2 where ID = @ID ", Baglanti, Tr);
                da.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");



                da.Update(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Da_RowUpdated1(object sender, SqlRowUpdatedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["ID"] = e.Command.Parameters["@YeniID"].Value;
        }

        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (da = new SqlDataAdapter(@"select Stokgrupv2.ID, StokID, StokGrupV2.StokGrupID, StokGrup.StokGrupAdi ,StokGrup.UstGrupID from StokGrupV2
inner join StokGrup on StokGrupV2.StokGrupID = StokGrup.StokGrupID
where Stokgrupv2.StokID = @StokID", Baglanti))
            {
                da.RowUpdated += Da_RowUpdated;

                da.SelectCommand.Transaction = Tr;

                da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

                using (dt = new DataTable())
                {

                    try
                    {
                        da.Fill(dt);
                        dt.PrimaryKey = new DataColumn[] { dt.Columns["StokGrupID"] };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    
                }
            }
        }
    }
}
