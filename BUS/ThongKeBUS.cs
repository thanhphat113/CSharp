using Doanqlchdt.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.BUS
{
    internal class ThongKeBUS
    {
        ThongKeDAO thongKeDao = new ThongKeDAO();   
        public DataTable LayTongTienTheoNam()
        {
            return thongKeDao.LayTongTienTheoThangNam();
        }
    }
}
