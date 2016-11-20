using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraGrid;

namespace Aresv2.cs
{
  class csGridLayout : IDisposable
  {
    public static MemoryStream GetLayout(int UsersID, string FormName, string GridName, SqlConnection Baglanti, SqlTransaction trGenel)
    {
      MemoryStream ms = new MemoryStream();
      using (SqlCommand cmd = new SqlCommand("select GridLayout from GridLayout where UsersID=@UsersID and FormName=@FormName AND GridName=@GridName ", Baglanti, trGenel))
      {
        cmd.Parameters.Add("@UsersID", SqlDbType.Int).Value = UsersID;
        cmd.Parameters.Add("@FormName", SqlDbType.NVarChar).Value = FormName;
        cmd.Parameters.Add("@GridName", SqlDbType.NVarChar).Value = GridName;
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
          if (dr.Read())
          {
            string data = dr["GridLayout"].ToString();
            byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
            ms.Write(buffer, 0, buffer.Length);
            ms.Seek(0, SeekOrigin.Begin);
          }
        }
      }
      return ms;
    }
    
    public static bool InsertLayout(int UsersID, string FormName, string GridName, string GridLayout, SqlConnection Baglanti, SqlTransaction trGenel)
    {
      bool cevap = false;
      string GridLayoutID = "-1";
      
      try
      {
        using (SqlCommand cmd = new SqlCommand("Select GridLayoutID From GridLayout Where UsersID=@UsersID AND FormName=@FormName AND GridName=@GridName", Baglanti, trGenel))
        {
          cmd.Parameters.Add("@UsersID", SqlDbType.Int).Value = UsersID;
          cmd.Parameters.Add("@FormName", SqlDbType.NVarChar).Value = FormName;
          cmd.Parameters.Add("@GridName", SqlDbType.NVarChar).Value = GridName;
          using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            if (dr.Read())
              GridLayoutID = dr["GridLayoutID"].ToString();
        }
        if (GridLayoutID != "-1")
        {
          using (SqlCommand cmd = new SqlCommand("Update GridLayout SET GridLayout=@GridLayout  Where UsersID=@UsersID AND FormName=@FormName AND GridName=@GridName", Baglanti, trGenel))
          {
            cmd.Parameters.Add("@GridLayout", SqlDbType.NVarChar).Value = GridLayout;

            cmd.Parameters.Add("@UsersID", SqlDbType.Int).Value = UsersID;
            cmd.Parameters.Add("@FormName", SqlDbType.NVarChar).Value = FormName;
            cmd.Parameters.Add("@GridName", SqlDbType.NVarChar).Value = GridName;
            cmd.ExecuteNonQuery();
          }
        }
        else
        {
          using (SqlCommand cmd = new SqlCommand("Insert Into GridLayout(UsersID,FormName,GridName,GridLayout) Values(@UsersID,@FormName,@GridName,@GridLayout)", Baglanti, trGenel))
          {
            cmd.Parameters.Add("@UsersID", SqlDbType.Int).Value = UsersID;
            cmd.Parameters.Add("@FormName", SqlDbType.NVarChar).Value = FormName;
            cmd.Parameters.Add("@GridName", SqlDbType.NVarChar).Value = GridName;
            cmd.Parameters.Add("@GridLayout", SqlDbType.NVarChar).Value = GridLayout;
            cmd.ExecuteNonQuery();
          }
        }
        return cevap;
      }
      catch (Exception hata)
      {
        return false;
        throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
      }
    }


    public static bool InsertLayout(int UsersID, string FormName,  GridView Grid , SqlConnection Baglanti, SqlTransaction trGenel)
    {
      bool cevap = false;
      string GridLayoutID = "-1";
      Grid.OptionsLayout.Columns.StoreAllOptions = true;
      Grid.OptionsLayout.StoreAllOptions = true;
      Grid.OptionsLayout.StoreDataSettings = true;
      Grid.OptionsLayout.StoreVisualOptions = true;
      try
      {

        string Layout = "";
        using (var ms = new MemoryStream())
        {
          Grid.SaveLayoutToStream(ms);
          ms.Position = 0;
          using (var reader = new StreamReader(ms))
            Layout = reader.ReadToEnd();
        }

        using (SqlCommand cmd = new SqlCommand("Select GridLayoutID From GridLayout Where UsersID=@UsersID AND FormName=@FormName AND GridName=@GridName", Baglanti, trGenel))
        {
          cmd.Parameters.Add("@UsersID", SqlDbType.Int).Value = UsersID;
          cmd.Parameters.Add("@FormName", SqlDbType.NVarChar).Value = FormName;
          cmd.Parameters.Add("@GridName", SqlDbType.NVarChar).Value = Grid.Name;
          using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            if (dr.Read())
              GridLayoutID = dr["GridLayoutID"].ToString();
        }
        if (GridLayoutID != "-1")
        {
          using (SqlCommand cmd = new SqlCommand("Update GridLayout SET GridLayout=@GridLayout  Where UsersID=@UsersID AND FormName=@FormName AND GridName=@GridName", Baglanti, trGenel))
          {
            cmd.Parameters.Add("@GridLayout", SqlDbType.NVarChar).Value = Layout;

            cmd.Parameters.Add("@UsersID", SqlDbType.Int).Value = UsersID;
            cmd.Parameters.Add("@FormName", SqlDbType.NVarChar).Value = FormName;
            cmd.Parameters.Add("@GridName", SqlDbType.NVarChar).Value = Grid.Name;
            cmd.ExecuteNonQuery();
          }
        }
        else
        {
          using (SqlCommand cmd = new SqlCommand("Insert Into GridLayout(UsersID,FormName,GridName,GridLayout) Values(@UsersID,@FormName,@GridName,@GridLayout)", Baglanti, trGenel))
          {
            cmd.Parameters.Add("@UsersID", SqlDbType.Int).Value = UsersID;
            cmd.Parameters.Add("@FormName", SqlDbType.NVarChar).Value = FormName;
            cmd.Parameters.Add("@GridName", SqlDbType.NVarChar).Value = Grid.Name;
            cmd.Parameters.Add("@GridLayout", SqlDbType.NVarChar).Value = Layout;
            cmd.ExecuteNonQuery();
          }
        }
        return cevap;
      }
      catch (Exception hata)
      {
        return false;
        throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
      }
    }
    
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
