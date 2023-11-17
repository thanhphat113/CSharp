using Doanqlchdt.Cart;
using Doanqlchdt.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class UserGui : Form
    {
        private CartBean shop;
        public UserGui()
        {
            InitializeComponent();
            InitializeImageList();
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        public void InitializeImageList()
        {
            List<sanphamdto> list = new sanphamdao().getds();
            update(list);
            cbChoise.SelectedIndex = 0;
        }

        public void update(List<sanphamdto> list)
        {
            listView2.Clear();
            foreach (sanphamdto sp in list)
            {
                String tenSP = sp.Tensp;
                String gia = sp.Giaban.ToString();
                byte[] imageData = sp.Hinhanh;
                string maSP = sp.Masp;
                Image img = ByteArrayToImage(imageData);
                ListViewItem item = new ListViewItem();
                item.Name = maSP;
                item.Text = tenSP + "\n" + "Giá bán: " + gia + " vnđ";
                item.ImageIndex = ImagesList.Images.Count; // Sử dụng index của hình ảnh trong ImageList
                listView2.Items.Add(item);
                ImagesList.Images.Add(img);
            }
            listView2.LargeImageList = ImagesList;
        }


        

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                // Lấy ListViewItem được chọn
                ListViewItem selectedItem = listView2.SelectedItems[0];

                // Lấy thông tin từ ListViewItem
                sanphamdto sp = new sanphamdao().findByID(selectedItem.Name);
                // Hiển thị thông tin trong TextBox
                lbMaSP.Text = sp.Masp;
                txtName.Text = sp.Tensp;
                txtPrice.Text = sp.Giaban.ToString()+" vnđ";
                txtStyle.Text = sp.Maloai;
                txtInfor.Text = sp.Mota;
                txtQuan.Text = sp.Soluong.ToString();
                if (sp.Soluong > 0)
                {
                    txtStatus.Text = "Còn hàng";
                    btAddCart.Enabled = true;
                }
                else
                {
                    txtStatus.Text = "Mặt hàng đã hết";
                    btAddCart.Enabled = false;
                }
                // Hiển thị hình ảnh trong PictureBox
                if (selectedItem.ImageIndex >= 0 && selectedItem.ImageIndex < ImagesList.Images.Count)
                {
                    Image selectedImage = ImagesList.Images[selectedItem.ImageIndex];
                    picItem.Image = selectedImage;
                }
            }
        }




        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string condition =txtSearch.Text;
            string dk=cbChoise.SelectedItem.ToString();
            string dau = null;
            string price=null;
            if (string.Equals(dk, "--Tất cả--"))
            {
                price = "0";
                dau = ">";
            }
            else if (string.Equals(dk, "--dưới 5.000.000đ--"))
            {
                price = "5000000";
                dau = "<";
            }
            else if (string.Equals(dk, "--dưới 10.000.000đ--"))
            {
                price = "10000000";
                dau = "<";
            }
            else if (string.Equals(dk, "--dưới 20.000.000đ--"))
            {
                price = "20000000";
                dau = "<";
            }
            else if (string.Equals(dk, "--trên 20.000.000đ--"))
            {
                price = "20000000";
                dau = ">";
            }
                List<sanphamdto> list = new sanphamdao().findByCondition(condition, price,dau);
                update(list);
            }

        private void btReturn_Click(object sender, EventArgs e)
        {
            reset();
        }

        public void reset()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuan.Text = "";
            txtStatus.Text = "";
            txtInfor.Text = "";
            lbMaSP.Text = null;
            txtStyle.Text = "";
            picItem.Image = null;
        }

        private void btAddCart_Click(object sender, EventArgs e)
        {
            if (shop == null)
            {
                shop = new CartBean();
            }
            if (lbMaSP.Text != "")
            {
                sanphamdto sp = new sanphamdao().findByID(lbMaSP.Text);
                addToCart product = new addToCart(sp);
                shop.addSanPham(product);
                if (shop[lbMaSP.Text].Quantity == sp.Soluong) btAddCart.Enabled = false;
                UpdateDataGridView();
            }
            else MessageBox.Show("Vui lòng chọn sản phẩm");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xác định cột "Tăng"
            int tangColumnIndex = dataGridView1.Columns["btTang"].Index;

            // Xác định cột "Giảm"
            int giamColumnIndex = dataGridView1.Columns["btGiam"].Index;

            // Kiểm tra nếu người dùng nhấn vào cột "Tăng"
            if (e.ColumnIndex == tangColumnIndex)
            {
                // Thực hiện chức năng tăng số lượng
                // Lấy giá trị hiện tại từ ô "Tên SP" trong hàng đã nhấn nút
                string maSP = dataGridView1.Rows[e.RowIndex].Cells["maSP"].Value.ToString();

                // Thực hiện tăng số lượng trong Cart 
                if (shop.ContainsKey(maSP))
                {
                    sanphamdto sp = new sanphamdao().findByID(maSP);
                    if (shop[maSP].Quantity < sp.Soluong) shop[maSP].Quantity++;
                    else MessageBox.Show("Quá số lượng mặt hàng có trong kho");
                }

                // Cập nhật lại DataGridView
                UpdateDataGridView();
            }

            // Kiểm tra nếu người dùng nhấn vào cột "Giảm"
            else if (e.ColumnIndex == giamColumnIndex)
            {
                // Thực hiện chức năng giảm số lượng
                // Lấy giá trị hiện tại từ ô "Tên SP" trong hàng đã nhấn nút
                string maSP = dataGridView1.Rows[e.RowIndex].Cells["maSP"].Value.ToString();

                // Thực hiện giảm số lượng trong Cart (giả sử shop là đối tượng Cart của bạn)
                if (shop.ContainsKey(maSP) && shop[maSP].Quantity > 0)
                {
                    shop[maSP].Quantity--;
                }
                sanphamdto sp = new sanphamdao().findByID(maSP);
                if (shop[maSP].Quantity < sp.Soluong)
                {
                    btAddCart.Enabled = true;
                    reset();
                }
                if (shop[maSP].Quantity == 0) shop.removeSanPham(maSP);

                // Cập nhật lại DataGridView
                UpdateDataGridView();
            }
        }

            public void UpdateDataGridView()
        {
            // Xóa dữ liệu hiện tại trong DataGridView
            dataGridView1.Rows.Clear();
            foreach (var item in shop.Values)
            {

                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["maSP"].Value = item.Sanpham.Masp;
                dataGridView1.Rows[rowIndex].Cells["txtNameCart"].Value = item.Sanpham.Tensp;
                dataGridView1.Rows[rowIndex].Cells["txtGia"].Value = item.Sanpham.Giaban;
                dataGridView1.Rows[rowIndex].Cells["txtQuantity"].Value = item.Quantity;
                dataGridView1.Rows[rowIndex].Cells["txtSum"].Value = (item.Quantity * item.Sanpham.Giaban);
                dataGridView1.Rows[rowIndex].Cells["btTang"].Value = "+";
                dataGridView1.Rows[rowIndex].Cells["btGiam"].Value = "-";
            }
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shop = new CartBean();
            UpdateDataGridView();
        }
    }
}
  
