using Doanqlchdt.GUI.Manager;
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
<<<<<<< HEAD
            //Application.Run(new GUI.Login());
            //Application.Run(new GUI.KhuyenMai());
            //Application.Run(new GUI.Thêm.Themsanpham());
            Application.Run(new Hoadonbanxacnhan());
=======
           Application.Run(new GUI.Login());
           // Application.Run(new GUI.Thêm.Themsanpham());

>>>>>>> a35ba19779971fa640f25630591eba398462d0b0
        }
    }
}
