using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class hoadonnhapdao
    {
        public hoadonnhapdao()
        {
        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn,manv,ncc,tongtien,ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(hoadonnhapdto hdndto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into HoaDonNhap values(N'" + hdndto.Mahdn + "',N'" +hdndto.Manv + "',N'" + hdndto.Ncc + "','" + hdndto.Tongtien + "','" + hdndto.Ngaytao + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close() ;
            return kq;
        }
        public int update(hoadonnhapdto hdndto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update HoaDonNhap set MaNV= N'" + hdndto.Manv + "',NhaCungCap= N'" + hdndto.Ncc + "',TongTien='" + hdndto.Tongtien + "',NgayTao='" + hdndto.Ngaytao + "' where MaHDN='" + hdndto.Mahdn + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmhdn(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap MaHDN LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmanv(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap MaNV LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsncc(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap NhaCungCap LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstongtien(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap TongTien LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngaytao(DateTime ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap NgayTao LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
