using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.Terazi
{
    public class csTeraziStokGrupTanimlari : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;

        public void GruplariGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            try
            {
                using (da = new SqlDataAdapter("select * from TeraziStokGrupTanimlari", Baglanti))
                {
                    da.SelectCommand.Transaction = Tr;

                    using (dt = new DataTable())
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da.RowUpdated += da_RowUpdated;
            da.InsertCommand = new SqlCommand("insert into TeraziStokGrupTanimlari (TeraziStokButonGrupTanimAdi, TeraziStokButonGrupTanimAciklama) values (@TeraziStokButonGrupTanimAdi, @TeraziStokButonGrupTanimAciklama)  set @YeniID = SCOPE_IDENTITY() ", Baglanti, Tr);

            da.InsertCommand.Parameters.Add("@TeraziStokButonGrupTanimAdi", SqlDbType.NVarChar, 150, "TeraziStokButonGrupTanimAdi");
            da.InsertCommand.Parameters.Add("@TeraziStokButonGrupTanimAciklama", SqlDbType.NVarChar, 250, "TeraziStokButonGrupTanimAciklama");
            da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

            da.UpdateCommand = new SqlCommand("update TeraziStokGrupTanimlari set TeraziStokButonGrupTanimAdi = @TeraziStokButonGrupTanimAdi, TeraziStokButonGrupTanimAciklama = @TeraziStokButonGrupTanimAciklama where TeraziStokGrupTanimID = @TeraziStokGrupTanimID", Baglanti, Tr);

            da.UpdateCommand.Parameters.Add("@TeraziStokButonGrupTanimAdi", SqlDbType.NVarChar, 150, "TeraziStokButonGrupTanimAdi");
            da.UpdateCommand.Parameters.Add("@TeraziStokButonGrupTanimAciklama", SqlDbType.NVarChar, 250, "TeraziStokButonGrupTanimAciklama");

            da.UpdateCommand.Parameters.Add("@TeraziStokGrupTanimID", SqlDbType.Int, 0, "TeraziStokGrupTanimID");

            da.Update(dt);
        }

        void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["TeraziStokGrupTanimID"] = e.Command.Parameters["@YeniID"].Value;
        }


    }
}
