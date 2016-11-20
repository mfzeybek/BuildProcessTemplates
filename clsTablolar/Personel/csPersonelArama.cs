using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel
{
    public class csPersonelArama : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private int _PersonelID;
        private int _CariID;
        private string _CariTanim;
        private string _Aciklama;

        public int PersonelID
        {
            get { return _PersonelID; }
            set { _PersonelID = value; }
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
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }

        public csPersonelArama()
        {
            PersonelID = -1;
            CariID = -1;
            CariTanim = "";
            Aciklama = "";
        }
        SqlDataAdapter da = new SqlDataAdapter();
public         DataTable dt_PersonelListesi = new DataTable();

        public void PersonelDoldur(SqlConnection Baglanti)
        {
            da = new SqlDataAdapter(@"select Personel.PersonelID, Personel.CariID, Cari.CariTanim, Cari.Aciklama  from Personel
inner join Cari on cari.CariID = Personel.CariID where 1=1 ", Baglanti);
            if (_CariTanim != "")
            {
                da.SelectCommand.CommandText += " and CariTanim = @CariTanim ";
                da.SelectCommand.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanim;
            }
            if (_Aciklama != "")
            {
                da.SelectCommand.CommandText += " and Aciklama = @Aciklama ";
                da.SelectCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
            }

            dt_PersonelListesi = new DataTable();
            da.Fill(dt_PersonelListesi);
        }





        
    }
}
