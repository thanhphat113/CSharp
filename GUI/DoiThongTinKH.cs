using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class DoiThongTinKH : Form
    {
        khachhangdto cus=new khachhangdto();
        public DoiThongTinKH(khachhangdto kh)
        {
            InitializeComponent();
            loadData(kh);
            this.cus = kh;
        }

        public void loadData(khachhangdto kh) {
            textBox1.Text = kh.Hoten;
            textBox3.Text = kh.Sdt;
            textBox2.Text = kh.Email;
            dateTimePicker1.Value=kh.Ngaysinh;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string sdt = textBox2.Text;
            string email = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            khachhangdto kh=new khachhangdto(cus.Mkh,name,sdt,email,dateTimePicker1.Value,cus.Username);
            if (new khachhangdao().update(kh)) MessageBox.Show("Đã thay đổi thông tin thành công");
            else MessageBox.Show("Thay đổi thất bại!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
