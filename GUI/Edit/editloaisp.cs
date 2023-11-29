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
    public partial class editloaisp : Form
    {
        static loaisanphambus bus = new loaisanphambus();
        private int borderWidth = 5;
        private DTO.loaisanphamdto selecteddto;
        public editloaisp(loaisanphamdto dto)
        {
            selecteddto = dto;
            InitializeComponent();
        }
    }
}
