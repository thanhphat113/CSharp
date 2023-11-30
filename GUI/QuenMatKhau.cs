using Doanqlchdt.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doanqlchdt.RJ;
using Doanqlchdt.GUI.Messageboxshow;
using Doanqlchdt.DAO;
namespace Doanqlchdt.GUI
{
    public partial class QuenMatKhau : Form
    {

        QuenMatKhauBUS quenMatKhauBUS = new QuenMatKhauBUS();

        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtSoDienThoai.Text))
            {
                Comfrimupdate comfrimupdate = new Comfrimupdate("Hãy điền đầy đủ thông tin");
                comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                comfrimupdate.ShowDialog();
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    txtUsername.Focus();
                }
                else if (txtSoDienThoai.Text == "") 
                {
                    txtSoDienThoai.Focus();
                }
            }
            else
            {
                string username = txtUsername.Text;
                string phoneNumber = txtSoDienThoai.Text;
                DateTime dateWithNoonTime = DateTime.Today.AddHours(24);
                dtNgaySinh.Value = dateWithNoonTime;
                DateTime dateTime1 = dtNgaySinh.Value;
                string dateTime = dateTime1.ToString();
                // Gọi phương thức từ BUS để lấy thông tin người dùng
                List<UserInfo> userInfoList = quenMatKhauBUS.GetUserName(username);

                // Kiểm tra xem danh sách thông tin người dùng có trống không
                if (userInfoList != null && userInfoList.Count > 0)
                {
                    foreach (UserInfo userInfo in userInfoList)
                    {
                        if (phoneNumber == userInfo.PhoneNumber && dateTime == userInfo.Birthday)
                        {
                            MessageBox.Show("hehe");
                        } 
                        else if(phoneNumber == userInfo.PhoneNumber && dateTime != userInfo.Birthday)
                        {
                            Comfrimupdate comfrimupdate = new Comfrimupdate(dateTime + "       " + userInfo.Birthday);
                            comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                            comfrimupdate.ShowDialog();
                        }
                        else if(phoneNumber != userInfo.PhoneNumber && dateTime == userInfo.Birthday)
                        {
                            Comfrimupdate comfrimupdate = new Comfrimupdate("Số Điện Thoại Không Đúng!");
                            comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                            comfrimupdate.ShowDialog();
                        }
                        else
                        {
                            Comfrimupdate comfrimupdate = new Comfrimupdate("Số Điện Thoại Và Ngày Sinh Không Đúng!");
                            comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                            comfrimupdate.ShowDialog();
                        }

                    }
                }
                else
                {
                    // Không tìm thấy dữ liệu
                    Comfrimupdate confirmUpdate = new Comfrimupdate("Không tìm thấy Username");
                    confirmUpdate.StartPosition = FormStartPosition.CenterScreen;
                    confirmUpdate.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Visible = true;
            Close();
        }
    }
}
