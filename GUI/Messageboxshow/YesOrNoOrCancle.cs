using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI.Messageboxshow
{
    public partial class YesOrNoOrCancle : Form
    {
        private Boolean comfirmxn = false;
        private Boolean comfirmhuy = false;
        private Boolean comfirmexit = false;
        public YesOrNoOrCancle(String thongbao)
        {
            InitializeComponent();
            labelluu.Text = thongbao;
        }

        public bool Comfirmxn { get => comfirmxn; set => comfirmxn = value; }
        public bool Comfirmhuy { get => comfirmhuy; set => comfirmhuy = value; }
        public bool Comfirmexit { get => comfirmexit; set => comfirmexit = value; }

        public void mousehover()
        {
            btnco.MouseEnter += (sender, e) =>
            {
                btnco.BackColor = Color.DodgerBlue;
                btnco.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnco.MouseLeave += (sender, e) =>
            {
                btnco.BackColor = System.Drawing.SystemColors.Window;
                btnco.ForeColor = System.Drawing.SystemColors.HotTrack;
            };
            btnkhong.MouseEnter += (sender, e) =>
            {
                btnkhong.BackColor = System.Drawing.Color.OrangeRed;
                btnkhong.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnkhong.MouseLeave += (sender, e) =>
            {
                btnkhong.BackColor = System.Drawing.SystemColors.Window;
                btnkhong.ForeColor = System.Drawing.Color.OrangeRed;
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnco_Click(object sender, EventArgs e)
        {
            comfirmxn = true;
            comfirmhuy = false;
            comfirmexit = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comfirmxn = false;
            comfirmhuy = true;
            comfirmexit = false;
            this.Close();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            comfirmxn = false;
            comfirmhuy = false;
            comfirmexit = true;
            this.Close();
        }
    }
}
