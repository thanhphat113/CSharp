﻿using Doanqlchdt.GUI.Manager;
using Doanqlchdt.GUI.Thêm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new GUI.Login());
            //Application.Run(new GUI.KhuyenMai());
            //Application.Run(new GUI.Thêm.Themsanpham());
            Application.Run(new Manager());

        }
    }
}
