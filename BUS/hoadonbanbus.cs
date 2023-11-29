using System;


namespace Doanqlchdt.DTO
{
    internal class hoadonbanbus
    {
        hoadonbandao hoadonbanDao = new hoadonbandao();

        public Boolean delete(string maHD)
        {
            return hoadonbanDao.delete(maHD);
        }

        public DateTime getNgayTao(string maHD)
        {
            return hoadonbanDao.getNgayTao(maHD);
        }
    }
}
