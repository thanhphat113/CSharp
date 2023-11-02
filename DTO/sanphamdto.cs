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
        private String gianhap;
        private String giaban;

        public sanphamdto(string masp, string tensp, string maloai, string gianhap, string giaban)
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
        public string Gianhap { get => gianhap; set => gianhap = value; }
        public string Giaban { get => giaban; set => giaban = value; }
    }
}
