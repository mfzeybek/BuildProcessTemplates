using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.n11
{
    public class csN11KategoriOzellikleri : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        SqlDataAdapter da;
        DataTable dt;

        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int n11KategoriID)
        {
            da = new SqlDataAdapter("select * from n11KategoriOzellikleri where 1 = 2", Baglanti);
            dt = new DataTable();
            da.Fill(dt);
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da.InsertCommand = new SqlCommand("insert into n11KategoriOzellikleri (n11attributeDataID, n11attributeDataName, n11attributeDataMandatory, n11attributeDataMultipleSelect, n11attributeDataNamen11KategoriID) values " +
                "(@n11attributeDataID, @n11attributeDataName, @n11attributeDataMandatory, @n11attributeDataMultipleSelect, @n11attributeDataNamen11KategoriID)", Baglanti, Tr);
            da.InsertCommand.Parameters.Add("@n11attributeDataID", SqlDbType.Int, 0, "n11attributeDataID");
            da.InsertCommand.Parameters.Add("@n11attributeDataName", SqlDbType.NVarChar, 0, "n11attributeDataName");
            da.InsertCommand.Parameters.Add("@n11attributeDataMandatory", SqlDbType.Bit, 0, "n11attributeDataMandatory");
            da.InsertCommand.Parameters.Add("@n11attributeDataMultipleSelect", SqlDbType.Bit, 0, "n11attributeDataMultipleSelect");
            da.InsertCommand.Parameters.Add("@n11attributeDataNamen11KategoriID", SqlDbType.Int, 0, "n11attributeDataNamen11KategoriID");

            da.Update(dt);
        }


    }
}
