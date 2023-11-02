using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class sanphamdto
    {
        private String masp;
        private String tensp;
        private String maloai;
        private int  gianhap;
        private int giaban;

        public sanphamdto(string masp, string tensp, string maloai, int gianhap, int giaban)
        {
            this.Masp = masp;
            this.Tensp = tensp;
            this.Maloai = maloai;
            this.Gianhap = gianhap;
            this.Giaban = giaban;
        }

        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Maloai { get => maloai; set => maloai = value; }
        public int Gianhap { get => gianhap; set => gianhap = value; }
        public int Giaban { get => giaban; set => giaban = value; }
    }
}
