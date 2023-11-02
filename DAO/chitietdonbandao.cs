using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class chitietdonbandao
    {
        public chitietdonbandao()
        {
        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonBan";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto=new chitietdonbandto(mhdb,masp,dongia,soluong,tongtien);
                ds.Add(ctdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(chitietdonbandto ctdbdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into ChiTietDonBan values(N'" + ctdbdto.Mahdb + "',N'" + ctdbdto.Masp + "','" + ctdbdto.Dongia + "','" + ctdbdto.Soluong + "','" + ctdbdto.Tongtien + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(chitietdonbandto ctdbdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "updateChiTietDonBan set MaSP= N'" + ctdbdto.Masp + "',DonGia= '" + ctdbdto.Dongia + "' ,SoLuong= '" + ctdbdto.Soluong + "',TongTien='" + ctdbdto.Tongtien + "' where MaHDB='" + ctdbdto.Mahdb + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmahd(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonBan  MaHDB LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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
            sqlcommand.CommandText = "select * from ChiTietDonBan  MaSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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
            sqlcommand.CommandText = "select * from ChiTietDonBan  DonGia LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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
            sqlcommand.CommandText = "select * from ChiTietDonBan  SoLuong LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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
            sqlcommand.CommandText = "select * from ChiTietDonBan TongTien LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
