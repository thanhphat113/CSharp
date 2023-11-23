using Doanqlchdt.connect;
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


        public List<chitietdonbandto> findByCondition(string id)
        {
            List<chitietdonbandto> list = new List<chitietdonbandto>();
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "select sp.TenSP,sp.GiaBan,ct.SoLuong,ct.TongTien,hd.NgayTao,hd.TongTien as Tong \r\nfrom ChiTietDonban ct join SanPham sp on ct.MaSP=sp.MaSP  join HoaDonBan hd on hd.MaHDB=ct.MaHDB\r\nwhere ct.MaHDB=@id";
                SqlCommand cmd=new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tenSP = (string)reader["TenSP"];
                    int gia = (int)reader["GiaBan"];
                    int soluong = (int)reader["SoLuong"];
                    int tong = (int)reader["TongTien"];
                    DateTime ngay= (DateTime)reader["NgayTao"];
                    double Tongtien = (double)reader["Tong"];
                    chitietdonbandto ct = new chitietdonbandto(tenSP, gia, soluong, tong, ngay,Tongtien);
                    list.Add(ct);
                }      
            }
            return list;
        }
        public void insert(chitietdonbandto ctdbdto)
        {
            using(SqlConnection conn=new connectToan().connection())
            {
                string query = "insert into ChiTietDonBan values(@maHDB,@maSP,@gia,@soluong,@tong)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHDB", ctdbdto.Mahdb);
                cmd.Parameters.AddWithValue("@maSP", ctdbdto.Masp);
                cmd.Parameters.AddWithValue("@gia", ctdbdto.Dongia);
                cmd.Parameters.AddWithValue("@soluong", ctdbdto.Soluong);
                cmd.Parameters.AddWithValue("@tong", ctdbdto.Tongtien);
                cmd.ExecuteNonQuery();
            }
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
