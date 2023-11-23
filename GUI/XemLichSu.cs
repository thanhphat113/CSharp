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
            foreach (var item in new hoadonbandao().findByCondition(kh.Mkh))
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["maHD"].Value = item.Mhdb;
                string a = item.Tongtien.ToString("#,##0");
                dataGridView1.Rows[rowIndex].Cells["Sum"].Value = a;
                dataGridView1.Rows[rowIndex].Cells["date"].Value = item.Ngaytao.ToString("dd/MM/yyyy");
                dataGridView1.Rows[rowIndex].Cells["check"].Value = "Xem";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int choise = dataGridView1.Columns["check"].Index;

            // Kiểm tra nếu người dùng nhấn vào cột "Tăng"
            if (e.ColumnIndex == choise && e.RowIndex >= 0)
            {
                string maSP = dataGridView1.Rows[e.RowIndex].Cells["maHD"].Value.ToString();
                ChiTiet form = new ChiTiet(maSP);
                form.Show();
            }
        }
    }
}


