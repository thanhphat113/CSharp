using Doanqlchdt.connect;
using Doanqlchdt.DTO.nhanviendto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Doanqlchdt.DAO
{
    internal class nhanviendao
    {
        private connect connect = new connect();
        public nhanviendao() { }
        public List<nhanviendto> GetNhanVien()
        {
            List<nhanviendto> employees = new List<nhanviendto>;
            using (SqlConnection connection = connectObj.connection())
            {
                string query = "SELECT * FROM NhanVien";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nhanviendto employee = new nhanviendto();
                    employee.MaNV = reader["MaNV"].ToString();
                    employee.HoTen = reader["HoTen"].ToString();
                    employee.SDT = reader["SDT"].ToString();
                    employee.Email = reader["Email"].ToString();
                    employee.TrangThai = Convert.ToInt32(reader["TrangThai"]);
                    employee.NgaySinh = Convert.ToDateTime(reader["ngaysinh"]);
                    employee.MaTK = Convert.ToInt32(reader["maTK"]);

                    employees.Add(employee);
                }

                connection.Close();
            }
            return employees;
        }
    }
}
