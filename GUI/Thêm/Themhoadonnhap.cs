using Doanqlchdt.DTO;
using Doanqlchdt.GUI.Messageboxshow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI.Thêm
{
    public partial class Themhoadonnhap : Form
    {
        private sanphambus spbus = new sanphambus();
        private hoadonnhapbus bus = new hoadonnhapbus();
        private ArrayList dssp = new ArrayList();
        private ArrayList dscthdn = new ArrayList();
        private int previousValue = 0;
        int so = 0;
        public Themhoadonnhap(String mnv)
        {
            InitializeComponent();
            so = bus.getcount();
            txtMa.Text = kiemtrathemma(so);
            mousehover();
            textBoxmnv.Text = mnv;
            Hienthi();
            hienthisp();
            previousValue = int.Parse(txttongtien.Text);
            String msp = comboBoxtensp.SelectedValue.ToString();
            sanphamdto spdto = bus.getdsgianhap(msp);
            if (spdto != null)
            {
                MessageBox.Show("ne");
                textBoxgianhap.Text = spdto.Gianhap.ToString();
                numericUpDownsoluong.Value = 0;
                txttongtien.Text = "0";
            }

            dateTimePickerngaytao.Value= DateTime.Now;
        }
        public void mousehover()
        {
            btnthem.MouseEnter += (sender, e) =>
            {
                btnthem.BackColor = Color.DodgerBlue;
                btnthem.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnthem.MouseLeave += (sender, e) =>
            {
                btnthem.BackColor = System.Drawing.SystemColors.Window;
                btnthem.ForeColor = System.Drawing.SystemColors.HotTrack;
            };
            btnHuy.MouseEnter += (sender, e) =>
            {
                btnHuy.BackColor = System.Drawing.Color.OrangeRed;
                btnHuy.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnHuy.MouseLeave += (sender, e) =>
            {
                btnHuy.BackColor = System.Drawing.SystemColors.Window;
                btnHuy.ForeColor = System.Drawing.Color.OrangeRed;
            };
            buttonthem.MouseEnter += (sender, e) =>
            {
                buttonthem.BackColor = Color.DodgerBlue;
                buttonthem.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            buttonthem.MouseLeave += (sender, e) =>
            {
                buttonthem.BackColor = System.Drawing.SystemColors.Window;
                buttonthem.ForeColor = System.Drawing.SystemColors.HotTrack;
            };
        }
        public String kiemtrathemma(int kiemtra)
        {
            String trave = "";
            if (kiemtra > 0)
            {
                if (kiemtra < 10)
                {
                    kiemtra++;
                    trave = "HDN00" + kiemtra;
                }
                else if (kiemtra >= 10 && kiemtra < 100)
                {
                    kiemtra++;
                    trave = "HDNP0" + kiemtra;
                }
                else if (kiemtra >= 100 && kiemtra < 1000)
                {
                    kiemtra++;
                    trave = "HDN" + kiemtra;
                }
            }
            return trave;
        }
        public void Hienthi()
        {
            DataTable dt = bus.gettenncc();
            comboBoxmancc.DataSource = dt;
            comboBoxmancc.DisplayMember = "TenNCC";
            comboBoxmancc.ValueMember = "MaNCC";
        }
        public void hienthisp()
        {
            DataTable dt = bus.gettensp();
            comboBoxtensp.DataSource = dt;
            comboBoxtensp.DisplayMember = "TenSP";
            comboBoxtensp.ValueMember = "MaSP";
            comboBoxtensp.SelectedIndex = 0;
        }

        private void comboBoxtensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxtensp!=null)
            {
                String msp = comboBoxtensp.SelectedValue.ToString();
                MessageBox.Show(msp);
                sanphamdto spdto = bus.getdsgianhap(msp);
                if(spdto!=null)
                {
                    textBoxgianhap.Text = spdto.Gianhap.ToString();
                    numericUpDownsoluong.Value = 0;
                    txttongtien.Text = previousValue.ToString();
                }

            }
        }

        private void numericUpDownsoluong_ValueChanged(object sender, EventArgs e)
        {

            if(textBoxgianhap!=null)
            {
                int gianhap=int.Parse(textBoxgianhap.Text);
                int sluong=Convert.ToInt32(numericUpDownsoluong.Value);
                int tien = gianhap * sluong;
                int tongtien = previousValue + tien;
                txttongtien.Text=tongtien.ToString();
            }
        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            sanphamdto sanpham=new sanphamdto();
            sanpham.Gianhap = Convert.ToInt32(textBoxgianhap.Text);
            sanpham.Masp = comboBoxtensp.SelectedValue.ToString();
            sanpham.Soluong=Convert.ToInt32(numericUpDownsoluong.Value);
            dssp.Add(sanpham);
            chitietdonnhapdto ctdn = new chitietdonnhapdto();
            ctdn.Mahdn=txtMa.Text;
            ctdn.Masp= comboBoxtensp.SelectedValue.ToString();
            ctdn.Dongia = Convert.ToInt32(textBoxgianhap.Text);
            ctdn.Soluong= Convert.ToInt32(numericUpDownsoluong.Value);
            int total=ctdn.Dongia*ctdn.Soluong;
            ctdn.Tongtien = total;
            dscthdn.Add(ctdn);

            btnthem.Enabled = true;
            Comfrimupdate cfm = new Comfrimupdate("Bạn đã thêm thành công");
            previousValue = int.Parse(txttongtien.Text);
            numericUpDownsoluong.Value = 0;
            cfm.ShowDialog();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(dscthdn !=null)
            {
                dscthdn.Clear();
            }
            if(dssp!=null)
            {
                dssp.Clear();
            }
            Comfrimupdate cfm = new Comfrimupdate("Bạn đã hủy thành công");
            cfm.ShowDialog();
            comboBoxmancc.SelectedIndex = 0;
            comboBoxtensp.SelectedIndex = 0;
            numericUpDownsoluong.Value = 0;
            txttongtien.Text = "0";
            btnthem.Enabled = false;
            String msp = comboBoxtensp.SelectedValue.ToString();
            sanphamdto sphdto = bus.getdsgianhap(msp);
            if (sphdto != null)
            {
                MessageBox.Show("ne");
                textBoxgianhap.Text = sphdto.Gianhap.ToString();
                numericUpDownsoluong.Value = 0;
                txttongtien.Text = "0";
                previousValue = int.Parse(txttongtien.Text);
            }

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            hoadonnhapdto hdndto=new hoadonnhapdto();
            hdndto.Mahdn = txtMa.Text;
            hdndto.Manv = textBoxmnv.Text;
            hdndto.Ncc = comboBoxmancc.SelectedValue.ToString();
            hdndto.Tongtien = Convert.ToInt32(txttongtien.Text);
            hdndto.Ngaytao = dateTimePickerngaytao.Value;
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn lưu không");
            yon.ShowDialog();
            if(yon.Comfirm == true)
            {
                bus.them(hdndto);
                foreach (chitietdonnhapdto cthdndto in dscthdn)
                {
                    bus.themcthdn(cthdndto);
                }
                foreach (sanphamdto spdto in dssp)
                {
                    spbus.UPDATEsoluong(spdto);
                }
                Comfrimupdate cfm = new Comfrimupdate("Bạn đã lưu thông tin thành công");
                cfm.ShowDialog();
                so = bus.getcount();
                txtMa.Text = kiemtrathemma(so);
                comboBoxmancc.SelectedIndex = 0;
                comboBoxtensp.SelectedIndex = 0;
                numericUpDownsoluong.Value = 0;
                txttongtien.Text = "0";
                btnthem.Enabled = false;
                String msp = comboBoxtensp.SelectedValue.ToString();
                sanphamdto sphdto = bus.getdsgianhap(msp);
                if (sphdto != null)
                {

                    textBoxgianhap.Text = sphdto.Gianhap.ToString();
                    numericUpDownsoluong.Value = 0;
                    txttongtien.Text = "0";
                    previousValue = int.Parse(txttongtien.Text);
                }

            }
        

        }

        private void buttonminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
