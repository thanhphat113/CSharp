using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.BUS
{
    internal class khachhangbus
    {
        khachhangdao khdao=new khachhangdao();
        public khachhangbus() { }
        public ArrayList getds()
        {
            return khdao.findAll();
        }
        public int insert(khachhangdto khdto)
        {
            return khdao.insert(khdto);
        }
    }
}
