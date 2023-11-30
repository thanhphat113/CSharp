﻿using Doanqlchdt.DTO;
using Doanqlchdt.GUI.Messageboxshow;
using System;
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
    public partial class Themdbh : Form
    {
        private donbaohanhbus bus = new donbaohanhbus();
        int so = 0;
        public Themdbh()
        {
            InitializeComponent();
            so=bus.getcount();
            txtMadbh.Text = kiemtrathemma(so);
            Hienthi();
            mousehover();

        }
        public String kiemtrathemma(int kiemtra)
        {
            String trave = "";
            if (kiemtra > 0)
            {
                if (kiemtra < 10)
                {
                    kiemtra++;
                    trave = "DBH00" + kiemtra;
                }
                else if (kiemtra >= 10 && kiemtra < 100)
                {
                    kiemtra++;
                    trave = "DBH0" + kiemtra;
                }
                else if (kiemtra >= 100 && kiemtra < 1000)
                {
                    kiemtra++;
                    trave = "DBH" + kiemtra;
                }
            }
            return trave;
        }
        public void Hienthi()
        {
            DataTable dtnv = bus.getnv();
            DataTable dtkh = bus.getkh();
            DataTable dtsp = bus.getsp();
            cbbtenmanv.DataSource = dtnv;
            cbbtenmanv.DisplayMember = "HoTen";
            cbbtenmanv.ValueMember = "MaNV";
            comboBoxmkh.DataSource = dtkh;
            comboBoxmkh.DisplayMember = "HoTen";
            comboBoxmkh.ValueMember = "MaKH";
            comboBoxmsp.DataSource = dtsp;
            comboBoxmsp.DisplayMember = "TenSP";
            comboBoxmsp.ValueMember = "MaSP";
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
        }
        private void buttonminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            donbaohanhdto dbhdto = new donbaohanhdto();
            dbhdto.Madonbaohanh = txtMadbh.Text.Trim();
            dbhdto.Manv = cbbtenmanv.SelectedValue.ToString();
            dbhdto.Masp = comboBoxmsp.SelectedValue.ToString();
            dbhdto.Makh = comboBoxmkh.SelectedValue.ToString();
            dbhdto.Ngaytao = dateTimePickerngaytao.Value;
            dbhdto.Ngaytra = dtpNgaytra.Value;
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn lưu không");
            yon.ShowDialog();
            if (yon.Comfirm == true)
            {
                bus.them(dbhdto);
                Comfrimupdate cfm = new Comfrimupdate("Bạn đã lưu thông tin thành công");
                cfm.ShowDialog();
                cbbtenmanv.SelectedIndex = 0;
                comboBoxmkh.SelectedIndex = 0;
                comboBoxmsp.SelectedIndex = 0;
                dateTimePickerngaytao.Value = DateTime.Now;
                dtpNgaytra.Value = DateTime.Now;
                so = bus.getcount();
                txtMadbh.Text = kiemtrathemma(so);
            }


        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn hủy không");
            yon.ShowDialog();
            if (yon.Comfirm == true)
            {
                Comfrimupdate cfm = new Comfrimupdate("Bạn hủy thành công");
                cfm.ShowDialog();
                this.Close();
            }
        }

    }
}
