using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AresUrunTanitim
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      DevExpress.UserSkins.BonusSkins.Register();
      //DevExpress.UserSkins.OfficeSkins.Register();
      DevExpress.Skins.SkinManager.EnableFormSkins(); 
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      if (args.Length == 0)
        Application.Run(new frmAnaFormParametre());
      else
      {
        string strParam = "";
        for (int i = 0; i < args.Length; i++)
          strParam += args[i];
        if (strParam == "INFO")
          Application.Run(new frmAnaFormParametre());
        else
          Application.Run(new frmAnaForm());
      }
    }
  }
}
