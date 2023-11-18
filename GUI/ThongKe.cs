using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doanqlchdt.DTO;
using Doanqlchdt.BUS;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Doanqlchdt.DAO;
using System.Data.SqlClient;

namespace Doanqlchdt.GUI
{
    public partial class ThongKe : Form
    {
        ThongKeBUS thongKeBUS = new ThongKeBUS();

        private string namLoc;

        public ThongKe()
        {
            InitializeComponent();
            ShowQuantity();
            loadCombobox();
            loadChartPie();
        }

        public void loadChartPie()
        {
            chartPie.Titles.Add("Pie Chart");
            chartPie.Series["s1"].Points.AddXY("Tổng tiền bán", "50");
            chartPie.Series["s1"].Points.AddXY("Tổng tiền nhập", "50");
        }

        public void loadCombobox()
        {
            ArrayList arrayList = thongKeBUS.GetDSNam();

            cbbYear.Items.Clear();
            cbbYear.Items.AddRange(arrayList.ToArray());
            cbbYear.SelectedIndex = 0;

            namLoc = cbbYear.SelectedItem.ToString();
            fillChart(namLoc);
        }

        public void ShowQuantity()
        {
            ArrayList hoaDonBan = new ArrayList();
            hoaDonBan = thongKeBUS.GetSoLuongHoaDonBan();
            int soLuongDonHang = hoaDonBan.Count;

            ArrayList khachHang = new ArrayList();
            khachHang = thongKeBUS.GetSoLuongKhachHang();
            int soLuongKhachHang = khachHang.Count;

            int soLuongBan = thongKeBUS.SoLuongSanPhamBan();

            lbDonHang.Text = soLuongDonHang.ToString();
            lbKhachHang.Text = soLuongKhachHang.ToString();
            lbSoLuongBan.Text = soLuongBan.ToString();  
        }

        public void fillChart(string year)
        {

            try
            {
                var dataTable = thongKeBUS.LayTongTienTheoNam(year);
                chartBan.DataSource = dataTable;

                dataTable.Columns.Add("ThangNam", typeof(string), "Thang + '/' + Nam");
                chartBan.Series["Tổng tiền bán"].XValueMember = "ThangNam";
                chartBan.Series["Tổng tiền bán"].YValueMembers = "TongTienThang";
                chartBan.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi điền dữ liệu vào biểu đồ: " + ex.Message);
            }
        }

        private void btnLocNam_Click(object sender, EventArgs e)
        {
            if(cbbYear.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn năm để lọc dữ liệu!!!");
            } 
            else
            {
                namLoc = cbbYear.SelectedItem.ToString();
                fillChart(namLoc);
            }
        }
    }
}
