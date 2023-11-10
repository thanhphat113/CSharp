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

namespace Doanqlchdt.GUI
{
    public partial class ThongKe : Form
    {
        hoadonbandto hoadonbanDTO = new hoadonbandto();
        hoadonbanbus hoadonbanBus = new hoadonbanbus();

        khachhangdto khachhangDTO = new khachhangdto();
        khachhangbus khachhangBus = new khachhangbus();
        public ThongKe()
        {
            InitializeComponent();
            ShowQuantity();
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

        
    }
}
