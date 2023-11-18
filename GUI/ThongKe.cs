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

        hoadonbandto hoadonbanDTO = new hoadonbandto();
        hoadonbanbus hoadonbanBus = new hoadonbanbus();

          


        khachhangdto khachhangDTO = new khachhangdto();
        khachhangbus khachhangBus = new khachhangbus();

        public ThongKe()
        {
            InitializeComponent();
            ShowQuantity();
            fillChart();
        }

        public void ShowQuantity()
        {
            int soLuongDonHang = 0;
            int soLuongKhachHang = 0;
            ArrayList hoaDonBan = new ArrayList();
            hoaDonBan = hoadonbanBus.getds();
            ArrayList khachHang = new ArrayList();
            khachHang = khachhangBus.getds();
            foreach (hoadonbandto hoadon in hoaDonBan)
            {
                soLuongDonHang++;
            }

            foreach (khachhangdto khachhang in khachHang)
            {
                soLuongKhachHang++;
            }

            lbDonHang.Text = soLuongDonHang.ToString();
            lbKhachHang.Text = soLuongKhachHang.ToString();
        }

        public void fillChart()
        {
            try
            {
                var dataTable = thongKeBUS.LayTongTienTheoNam();
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


        private void chartBan_Click_1(object sender, EventArgs e)
        {

        }
    }
}
