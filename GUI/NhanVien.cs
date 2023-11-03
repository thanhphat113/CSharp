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

namespace Doanqlchdt.GUI
{
    public partial class NhanVien : Form
    {
        static nhanvienbus employeeBUS = new nhanvienbus();
        List<nhanviendto> employees = employeeBUS.GetNhanVien();

        public NhanVien()
        {
            InitializeComponent();
            ColumnListView();
            LoadDataToGUI();
        }
        private void LoadDataToGUI()
        {
            listView1.Items.Clear();
            foreach (nhanviendto employee in employees)
            {
                string[] row = { employee.MaNV, employee.HoTen, employee.SDT, employee.Email, employee.TrangThai.ToString(), employee.NgaySinh.ToString(), employee.MaTK.ToString() };
                listView1.Items.Add(new ListViewItem(row));
            }
        }

        private void ColumnListView()
        {
            listView1.FullRowSelect = true;
            listView1.View = View.Details; // Đảm bảo rằng ListView sẽ hiển thị dưới dạng Details
            listView1.Columns.Add("Mã NV", 100, HorizontalAlignment.Left); // Thêm các cột vào ListView
            listView1.Columns.Add("Họ Tên", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Số Điện Thoại", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Trạng Thái", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Ngày Sinh", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Mã Tài Khoản", 100, HorizontalAlignment.Left);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMaNV = listView1.SelectedItems[0].SubItems[0].Text;
                // Tìm kiếm thông tin nhân viên theo mã
                nhanviendto selectedEmployee = employees.FirstOrDefault(employee => employee.MaNV == selectedMaNV);
                if (selectedEmployee != null)
                {
                    // Truyền thông tin nhân viên được chọn qua form sửa nhân viên
                    SuaNhanVien suaNhanVienForm = new SuaNhanVien(selectedEmployee);
                    suaNhanVienForm.StartPosition = FormStartPosition.CenterParent;
                    suaNhanVienForm.ShowDialog();
                    // Tự động làm mới dữ liệu sau khi cập nhật                              
                    employees = employeeBUS.GetNhanVien();
                    LoadDataToGUI();
                }
            }
        }
    }
}
