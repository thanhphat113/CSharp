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
            Application.Run(new Manager());
            //Application.Run(new GUI.Login());
            // Application.Run(new GUI.Thêm.Themsanpham());
=======
           Application.Run(new GUI.KhuyenMai());
           // Application.Run(new GUI.Thêm.Themsanpham());
>>>>>>> 96b956debde8dab8b738a7af299f75486ef9c388
        }
    }
}
