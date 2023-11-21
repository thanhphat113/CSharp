using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class chitietdonbandto
    {
        private double Tong;
        private String mahdb;
        private String masp;
        private string tensp;
        private double dongia;
        private int soluong;
        private int tongtien;
        DateTime ngay;

        public chitietdonbandto(string tensp, double dongia, int soluong,int tongtien,DateTime ngay,double Tong)
        {
            this.Tensp = tensp;
            this.dongia = dongia;
            this.soluong = soluong;
            this.tongtien  = tongtien;
            this.Ngay=ngay;
            this.Tong=Tong;
        }
        public chitietdonbandto(string mahdb, string masp, int dongia, int soluong, int tongtien)
        {
            this.Mahdb = mahdb;
            this.Masp = masp;
            this.Dongia = dongia;
            this.Soluong = soluong;
            this.Tongtien = tongtien;
        }
        public chitietdonbandto() { }

        public string Mahdb { get => mahdb; set => mahdb = value; }
        public string Masp { get => masp; set => masp = value; }
        public double Dongia { get => dongia; set => dongia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
        public double Tong1 { get => Tong; set => Tong = value; }
    }
}
