using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class khachhangdto
    {

        private String mkh;
        private String hoten;
        private String sdt;
        private String email;
        private DateTime ngaysinh;
        private int matk;

        public string Mkh { get => mkh; set => mkh = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public int Matk { get => matk; set => matk = value; }

        public khachhangdto(string mkh, string hoten, string sdt, string email, DateTime ngaysinh, int matk)
        {
            this.Mkh = mkh;
            this.Hoten = hoten;
            this.Sdt = sdt;
            this.Email = email;
            this.Ngaysinh = ngaysinh;
            this.Matk = matk;
        }

        public khachhangdto() { }

    }
}
