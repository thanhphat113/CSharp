using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class sanphambus
    {
        private sanphamdao dao=new sanphamdao();
        public sanphambus() { }
        public int getcount()
        {
            return dao.selectcount();
        }
        public DataTable gettenloaisp()
        {
            return dao.Layloaisanpham();
        }
        public int themsp(sanphamdto spdto)
        {
            return dao.themsanpham(spdto);
        }
    }
}
