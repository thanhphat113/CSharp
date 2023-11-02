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
            connect.Close();
            return kq;
        }
        public int update(khachhangdto khdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update KhachHang set HoTen= N'"+khdto.Hoten +"',SDT= N'"+khdto.Sdt+"' ,Email= N'"+khdto.Email+"',Ngaysinh='"+khdto.Ngaysinh+"' where MaKH='"+khdto.Mkh+"' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmakh(String mkh)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang WHERE MaKH='"+mkh+"'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh1 = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                khachhangdto kh = new khachhangdto(mkh1, name, sdt, email, ngaysinh, mtk);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdshoten(String hoten)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang HoTen LIKE '"+hoten+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                khachhangdto kh = new khachhangdto(mkh, name, sdt, email, ngaysinh, mtk);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdssdt(String sdt)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang SDT LIKE '" + sdt + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdtt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                khachhangdto kh = new khachhangdto(mkh, name, sdtt, email, ngaysinh, mtk);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsemail(String email)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang Email LIKE '" + email + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String emaill = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                khachhangdto kh = new khachhangdto(mkh, name, sdt, emaill, ngaysinh, mtk);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngaysinh(DateTime ngaysinh)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang NgaySinh LIKE '" + ngaysinh + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinhh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                khachhangdto kh = new khachhangdto(mkh, name, sdt, email, ngaysinhh, mtk);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmatk(String matk)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang MaTK LIKE '" + matk + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                khachhangdto kh = new khachhangdto(mkh, name, sdt, email, ngaysinh, mtk);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

    }
}
