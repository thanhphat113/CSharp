using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class hoadonbandao
    {
        public hoadonbandao()
        {

        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonBan";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh= reader.GetString(2);
                String makm = reader.GetString(3);
                int tongtien = reader.GetInt32(4);
                DateTime ngaytao=reader.GetDateTime(5);
                hoadonbandto hdbdto=new hoadonbandto(mhdb,manv,makh,makm,tongtien,ngaytao );
                ds.Add(hdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(hoadonbandto hdbdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into HoaDonBan values(N'" + hdbdto.Mhdb + "',N'" + hdbdto.Mnv + "',N'" + hdbdto.Mkh + "',N'" + hdbdto.Mkm + "','" + hdbdto.Tongtien + "','"+hdbdto.Ngaytao+"')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(hoadonbandto hdbdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update HoaDonBan set MaNV= N'" + hdbdto.Mnv + "',MaKH= N'" + hdbdto.Mkh + "' ,MaKM= N'" + hdbdto.Mkm + "',TongTien='" + hdbdto.Tongtien + "',NgayTao='"+hdbdto.Ngaytao+"' where MaHDB='" + hdbdto.Mhdb + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmhdb(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonBan MaHDB LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String makm = reader.GetString(3);
                int tongtien = reader.GetInt32(4);
                DateTime ngaytao = reader.GetDateTime(5);
                hoadonbandto hdbdto = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmnv(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonBan MaNV LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String makm = reader.GetString(3);
                int tongtien = reader.GetInt32(4);
                DateTime ngaytao = reader.GetDateTime(5);
                hoadonbandto hdbdto = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmkh(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonBan MaKH LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String makm = reader.GetString(3);
                int tongtien = reader.GetInt32(4);
                DateTime ngaytao = reader.GetDateTime(5);
                hoadonbandto hdbdto = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmkm(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonBan MaKM LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String makm = reader.GetString(3);
                int tongtien = reader.GetInt32(4);
                DateTime ngaytao = reader.GetDateTime(5);
                hoadonbandto hdbdto = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hdbdto);
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
            sqlcommand.CommandText = "select * from HoaDonBan TongTien LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String makm = reader.GetString(3);
                int tongtien = reader.GetInt32(4);
                DateTime ngaytao = reader.GetDateTime(5);
                hoadonbandto hdbdto = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngay(DateTime ngay)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonBan NgayTao LIKE '" + ngay + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String makm = reader.GetString(3);
                int tongtien = reader.GetInt32(4);
                DateTime ngaytao = reader.GetDateTime(5);
                hoadonbandto hdbdto = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
