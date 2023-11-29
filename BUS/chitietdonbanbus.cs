using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class chitietdonbanbus
    {
        chitietdonbandao chitiet=new chitietdonbandao();

        public Boolean delete(String id)
        {
            return chitiet.delete(id);
        }
    }
}
