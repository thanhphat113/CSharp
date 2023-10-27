    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class taikhoandto
    {
        private int matk;
        private String username;
        private String password;
        private int quyen;
        private int trangthai;

        public taikhoandto()
        {
        }

        public taikhoandto(int matk, string username, string password, int quyen, int trangthai)
        {
            this.matk = matk;
            this.username = username;
            this.password = password;
            this.quyen = quyen;
            this.trangthai = trangthai;
        }

        public int Matk { get => matk; set => matk = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Quyen { get => quyen; set => quyen = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}
