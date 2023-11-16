using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class chitietdonbandto
    {
        private String mahdb;
        private String masp;
        private int dongia;
        private int soluong;
        private int tongtien;

        public chitietdonbandto(string mahdb, string masp, int dongia, int soluong, int tongtien)
        {
            this.Mahdb = mahdb;
            this.Masp = masp;
            this.Dongia = dongia;
            this.Soluong = soluong;
            this.Tongtien = tongtien;
        }

        public string Mahdb { get => mahdb; set => mahdb = value; }
        public string Masp { get => masp; set => masp = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
    }
}
