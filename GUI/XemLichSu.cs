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
    public partial class XemLichSu : Form
    {
        khachhangdto kh = new khachhangdto();
        public XemLichSu(khachhangdto kh)
        {
            InitializeComponent();
            this.kh = kh;
            UpdateDataGridView();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }


        public void UpdateDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in new hoadonbandao().findByCondition(kh.Mkh))
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["maHD"].Value = item.Mhdb;
                string a = item.Tongtien.ToString("#,##0");
                dataGridView1.Rows[rowIndex].Cells["Sum"].Value = a;
                dataGridView1.Rows[rowIndex].Cells["date"].Value = item.Ngaytao.ToString("dd/MM/yyyy hh:mm:ss");
                if (item.Trangthai == 0) dataGridView1.Rows[rowIndex].Cells["trangthai"].Value = "Chưa thanh toán";
                else dataGridView1.Rows[rowIndex].Cells["trangthai"].Value = "Đã thanh toán";
                dataGridView1.Rows[rowIndex].Cells["check"].Value = "Xem";
                dataGridView1.Rows[rowIndex].Cells["huy"].Value = "Hủy";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int choise = dataGridView1.Columns["check"].Index;
            int delete = dataGridView1.Columns["huy"].Index;

            // Kiểm tra nếu người dùng nhấn vào cột "Tăng"
            if (e.ColumnIndex == choise && e.RowIndex >= 0)
            {
                string mahd = dataGridView1.Rows[e.RowIndex].Cells["maHD"].Value.ToString();
                ChiTiet form = new ChiTiet(mahd);
                form.Show();
            }
            if (e.ColumnIndex == delete && e.RowIndex >= 0)
            {
                string mahd = dataGridView1.Rows[e.RowIndex].Cells["maHD"].Value.ToString();
                DateTime ngaytao = new hoadonbanbus().getNgayTao(mahd);
                if (CheckNgay(ngaytao))
                {
                    if (new hoadonbanbus().delete(mahd))
                    {
                        MessageBox.Show("Hủy đơn đặt hàng thành công");
                        UpdateDataGridView();
                    }
                }
                else MessageBox.Show("Đơn hàng của bàng không thể hủy vì đã quá ngày cho phép hủy đơn");
            }
        }

        public bool CheckNgay(DateTime ngaytao)
        {

            DateTime currentDateTime = DateTime.Now;

            TimeSpan difference = currentDateTime - ngaytao;


            if (difference.TotalDays < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}


