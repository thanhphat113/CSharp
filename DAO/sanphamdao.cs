using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class sanphamdao
    {
        public sanphamdao() { }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(sanphamdto spdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into SanPham values(N'" + spdto.Masp + "',N'" + spdto.Tensp + "',N'" + spdto.Maloai + "','" + spdto.Gianhap + "','" + spdto.Giaban + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(sanphamdto spdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update SanPham set TenSP= N'" + spdto.Tensp + "',MaLoai= N'" + spdto.Maloai + "' ,GiaNhap= '" + spdto.Gianhap + "',GiaBan='" +spdto.Giaban + "' where MaSP='" + spdto.Masp + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmasp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham MaSP LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstensp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham TenSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmaloaisp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham MaLoai LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsgianhap(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham GiaNhap LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsgiaban(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham GiaBan LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
