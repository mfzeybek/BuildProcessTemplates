using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aresv2.cs
{
  public partial class frmHesapMak : Form
  {
    public frmHesapMak()
    {
      InitializeComponent();
    }

    decimal Carp(decimal Sayi1, decimal Sayi2)
    {
      return Sayi1 * Sayi2;
    }
    decimal Bol(decimal Sayi1, decimal Sayi2)
    {
      return Sayi1 / Sayi2;
    }
    decimal Cikar(decimal Sayi1, decimal Sayi2)
    {
      return Sayi1 - Sayi2;
    }
    decimal Topla(decimal Sayi1, decimal Sayi2)
    {
      return Sayi1 + Sayi2;
    }

    public decimal Sonuc = 0;

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      decimal Sayi1 = 0;
      decimal Sayi2 = 0;
      
      char[] Islemler = { '/', '*', '+', '-' };

      string[] Sayilar = textEdit1.Text.Split(Islemler);

      int sds = textEdit1.Text.IndexOfAny(Islemler);

      string SirasiIleIslemler = "";
      foreach (char item in textEdit1.Text)
      {
        if (item == '/' || item == '*' || item == '+' || item == '-')
          SirasiIleIslemler += item;
      }

      for (int i = 0; i < SirasiIleIslemler.Length; i++)
      {
        char item = SirasiIleIslemler[i];
        switch (item)
        {
          case '/': Sonuc = Convert.ToDecimal(Sayilar[i]) / Convert.ToDecimal(Sayilar[i + 1]);
            break;
          case '*': Sonuc = Convert.ToDecimal(Sayilar[i]) * Convert.ToDecimal(Sayilar[i + 1]);
            break;
          case '+': Sonuc = Convert.ToDecimal(Sayilar[i]) + Convert.ToDecimal(Sayilar[i + 1]);
            break;
          case '-': Sonuc = Convert.ToDecimal(Sayilar[i]) - Convert.ToDecimal(Sayilar[i + 1]);
            break;
          default:
            break;
        }
      }
      textEdit1.Text = Sonuc.ToString();
    }

    public char SirasiIleIslemler { get; set; }
  }
}
