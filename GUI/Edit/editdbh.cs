using Doanqlchdt.BUS;
using Doanqlchdt.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI.Edit
{
    public partial class editdbh : Form
    {
        static donbaohanhbus bus=new donbaohanhbus();
        private int borderWidth = 5;
        private DTO.donbaohanhdto selecteddto;
        public editdbh(donbaohanhdto dbhdto)
        {
            selecteddto = dbhdto;
            InitializeComponent();
        }
    }
}
