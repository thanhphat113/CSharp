using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class sanphamgui : Form
    {
        public sanphamgui()
        {
            InitializeComponent();
        }
        public Image ByteArraytoimage(byte[]b)
        {
            MemoryStream m=new MemoryStream(b);
            return Image.FromStream(m);

        }
    }
}
