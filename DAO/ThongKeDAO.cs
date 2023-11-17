using Doanqlchdt.connect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DAO
{
    internal class ThongKeDAO
    {
        connectToan cn = new connectToan();

        public ThongKeDAO()
        {
        }

        public DataTable LayTongTienTheoThangNam()
        {
            DataTable result = new DataTable();
            using (SqlConnection connection = cn.connection())
            {

                //SELECT MONTH(NgayTao) AS Thang, YEAR(NgayTao) AS Nam, SUM(TongTien) AS TongTienThang FROM HoaDonBan GROUP BY MONTH(NgayTao), YEAR(NgayTao) ORDER BY Nam, Thang
                SqlCommand sqlCommand = new SqlCommand("WITH AllMonths AS (SELECT DISTINCT Thang, Nam FROM" +
                                                        "(SELECT 1 AS Thang UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12) AS Thang, (SELECT DISTINCT YEAR(NgayTao) AS Nam FROM HoaDonBan) AS Nam)" +
                                                        "SELECT AllMonths.Thang, AllMonths.Nam, COALESCE(SUM(HoaDonBan.TongTien), 0) AS TongTienThang FROM AllMonths LEFT JOIN HoaDonBan ON MONTH(HoaDonBan.NgayTao) = AllMonths.Thang AND YEAR(HoaDonBan.NgayTao) = AllMonths.Nam GROUP BY AllMonths.Thang, AllMonths.Nam ORDER BY AllMonths.Nam, AllMonths.Thang;" , connection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(result);
            }
            return result;
        }
    }
}
