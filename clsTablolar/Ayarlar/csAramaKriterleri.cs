using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Xml;


namespace clsTablolar.Ayarlar
{
    public class csAramaKriterleri : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void ahaha()
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


            XDocument xdoc = new XDocument();
            //xmld
            XmlDocument xmldoc = new XmlDocument();

            xmldoc.LoadXml(cmd.ExecuteScalar().ToString());
        }

        public string ToXml(DataTable table, int metaIndex = 0)
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

        public void ahaaaaa()
        {
            //DataTable youdatatable = GetData();
            //System.IO.StringWriter writer = new System.IO.StringWriter();
            //youdatatable.WriteXml(writer, XmlWriteMode.WriteSchema, true);
            //PrintOutput(writer);
            //return "sdfsdf";
        }

        public enum AramaTipi
        {
            StokListe = 1,
            StokHareket = 2,
            CariListe = 3,
            CariHareket = 4
        }


        public void xmlivtYeKaydet(SqlConnection Baglanti, SqlTransaction Tr, int ID, string xml, AramaTipi tipi, string Aciklama)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                if (ID == -1)
                {
                    cmd.CommandText = "insert into AramaKriterleri (Xml, AramaID, Aciklama) (@Xml, @AramaID, @Aciklama) set @YeniID = SCOPE_IDENTITY()";
                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                }
                else
                {
                    cmd.CommandText = "update  AramaKriterleri set Xml = @Xml, AramaID = @AramaID, Aciklama = @Aciklama where ID = @ID";
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                }

                cmd.Parameters.Add("@Xml", SqlDbType.NVarChar).Value = xml;
                cmd.Parameters.Add("@AramaID", SqlDbType.TinyInt).Value = (Int16)tipi;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;

                cmd.ExecuteNonQuery();

                if (ID == -1)
                {

                }
            }
        }


        XmlDocument xmlDoc;
        XmlNode rootNode;

        private void xmlKriterOlustur()
        {
            xmlDoc = new XmlDocument();

        }

        public void xmlolustur(string FiltrelemeKriteri, string Deger)
        {
            try
            {

                if (xmlDoc == null)
                {
                    xmlKriterOlustur();
                    rootNode = xmlDoc.CreateElement("AramaKriterleri");
                    xmlDoc.AppendChild(rootNode);
                }

                XmlNode KriterNode = xmlDoc.CreateElement(FiltrelemeKriteri);
                KriterNode.InnerText = Deger;
                rootNode.AppendChild(KriterNode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
