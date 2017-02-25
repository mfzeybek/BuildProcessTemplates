﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Aresv2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AyarlarHemeAl.frmHAStok());
            Application.Run(new frmKullaniciGiris());
        }
    }
}
