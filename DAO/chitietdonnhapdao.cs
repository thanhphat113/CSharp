using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class chitietdonnhapdao
    {
        public chitietdonnhapdao()
        {
        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonNhap";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
              chitietdonnhapdto ctdndto=new chitietdonnhapdto(mhdn,masp,dongia,soluong,tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(chitietdonnhapdto ctdndto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into ChiTietDonBan values(N'" + ctdndto.Mahdn + "',N'" + ctdndto.Masp + "','" + ctdndto.Dongia + "','" + ctdndto.Soluong + "','" + ctdndto.Tongtien + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(chitietdonnhapdto ctdndto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "updateChiTietDonBan set MaSP= N'" + ctdndto.Masp + "',DonGia= '" + ctdndto.Dongia + "' ,SoLuong= '" + ctdndto.Soluong + "',TongTien='" + ctdndto.Tongtien + "' where MaHDB='" + ctdndto.Mahdn + "' ";
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
            sqlcommand.CommandText = "select * from ChiTietDonNhap MaHDN LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmasp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonNhap MaSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsdongia(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonNhap DonGia LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdssoluong(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonNhap SoLuong LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
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
            sqlcommand.CommandText = "select * from ChiTietDonNhap TongTien LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
