using Doanqlchdt.GUI.Manager;
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
           Application.Run(new GUI.Login());
           // Application.Run(new GUI.Thêm.Themsanpham());
=======
            Application.Run(new GUI.Login());
            Application.Run(new GUI.KhuyenMai());
            // Application.Run(new GUI.Thêm.Themsanpham());
>>>>>>> 28e3c420b034514e4c6ca31096e03644583cdec7
        }
    }
}
