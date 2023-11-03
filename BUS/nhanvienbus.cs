using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doanqlchdt.DAO;
using Doanqlchdt.DTO;

namespace Doanqlchdt.BUS
{
    internal class nhanvienbus {
        private nhanviendao employeeDAO = new nhanviendao();
        public List<nhanviendto> GetNhanVien()
        {
            return employeeDAO.GetNhanVien();
        }

        public void AddEmployee(nhanviendto employee)
        {
            employeeDAO.AddEmployee(employee);
        }

        public void UpdateEmployee(nhanviendto employee)
        {
            employeeDAO.UpdateEmployee(employee);
        }

        public ArrayList SearchEmployee(string keyword)
        {
            return employeeDAO.SearchEmployee(keyword);
        }
    }
}
