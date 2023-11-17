using Doanqlchdt.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.BUS
{
    internal class taikhoanbus
    {
        taikhoandao tkdao = new taikhoandao();

        public taikhoanbus()
        {
        }
        public ArrayList getds()
        {
            return tkdao.getds();
        }
        public Boolean checkt(String tk, String mk)
        {
            return tkdao.checkttk(tk, mk);
        }

        public ArrayList getdsquyen(int quyen)
        {
            return tkdao.getdsquyen(quyen);
        }

        public int GetQuyen(string tk, string mk)
        {
            return tkdao.GetQuyen(tk, mk);
        }
    }
}
