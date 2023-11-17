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
            taikhoanbus = new taikhoanbus();
            String tk = textBox1.Text;
            String mk = textBox2.Text;
            if (taikhoanbus.checkt(tk, mk))
            {
                MessageBox.Show("Đúng rồi");
                int checkQuyen = taikhoanbus.GetQuyen(tk, mk);
                MessageBox.Show(checkQuyen.ToString());
                if (checkQuyen == 1)
                {
                    MessageBox.Show("Bạn đang đăng nhập dưới dạng ADMIN");
                    Menu frmMenu = new Menu();
                    frmMenu.ShowDialog();
                    Close();
                }
                else if (checkQuyen == 2)
                {
                    MessageBox.Show("Bạn đang đăng nhập dưới dạng Nhân Viên");
                }
                else if (checkQuyen == 3)
                {
                    MessageBox.Show("Cảm ơn vì đã sử dụng dịch vụ của chúng tôi!");
                    UserGui userGui = new UserGui();
                    userGui.ShowDialog();
                    Close();
                }
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
