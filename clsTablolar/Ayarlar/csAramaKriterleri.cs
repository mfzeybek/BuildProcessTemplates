using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.SqlClient;


namespace clsTablolar.Ayarlar
{
    public class csAramaKriterleri : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void ahaha ()
        {
            DataTable dt = new DataTable();

            //dt.To

        }
        DataTable ahanda;
        

        public void Getir(SqlConnection baglanti, SqlTransaction Tr, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from AramaKriterleri where ID = @ID";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            cmd.exe

        }

        public string ToXml(this DataTable table, int metaIndex = 0)
        {

            //public string ahandaToXml(this DataTable table, int metaIndex = 0)
            {
                XDocument xdoc = new XDocument(
                    new XElement(table.TableName,
                        from column in table.Columns.Cast<DataColumn>()
                        where column != table.Columns[metaIndex]
                        select new XElement(column.ColumnName,
                            from row in table.AsEnumerable()
                            select new XElement(row.Field<string>(metaIndex), row[column])
                            )
                        )
                    );

                return xdoc.ToString();
            }
        }

        public string ahanda ()
        {
            DataTable youdatatable = GetData();
            System.IO.StringWriter writer = new System.IO.StringWriter();
            youdatatable.WriteXml(writer, XmlWriteMode.WriteSchema, true);
            PrintOutput(writer);
        }


    }
}
