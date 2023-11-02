using Doanqlchdt.BUS;
using Doanqlchdt.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class Login : Form
    {
        taikhoanbus taikhoanbus;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taikhoanbus=new taikhoanbus();
            String tk = textBox1.Text;
            String mk=textBox2.Text;
            if(taikhoanbus.checkt(tk,mk))
            {
                MessageBox.Show("Đúng rồi");
            }
            else
            {
                MessageBox.Show("Sai rồi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
