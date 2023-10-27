using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DAO
{
    internal class khachhangdao
    {
        public khachhangdao() { }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh=reader.GetString(0);
                String name=reader.GetString(1);
                String sdt=reader.GetString(2);
                String email=reader.GetString(3);
                DateTime ngaysinh= reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                khachhangdto kh=new khachhangdto(mkh,name,sdt,email,ngaysinh,mtk);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(khachhangdto khdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into KhachHang values(N'" + khdto.Mkh + "',N'" + khdto.Hoten + "',N'" + khdto.Sdt + "',N'" + khdto.Email + "','" + khdto.Ngaysinh + "','"+khdto.Matk+"')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            return kq;
        }
    }
}
