using Doanqlchdt.Cart;
using Doanqlchdt.connect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.DTO
{
    internal class hoadonbandao
    {
        public hoadonbandao()
        {

        }
        public List<hoadonbandto> findByCondition(string condition)
        {
            List<hoadonbandto> list = new List<hoadonbandto>();
           using(SqlConnection conn = new connectToan().connection())
            {
                string query = "select * from HoaDonBan where MaKH=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id",condition);
                SqlDataReader reader= cmd.ExecuteReader();
                while(reader.Read())
                {
                    String mhdb = (String)reader["MaHDB"];
                    String makh = reader.GetString(3);
                    String makm = reader.GetString(4);
                    double tongtien = reader.GetDouble(5);
                    DateTime ngaytao = reader.GetDateTime(6);
                    hoadonbandto hd = new hoadonbandto(mhdb, "", makh, makm, tongtien, ngaytao);
                    list.Add(hd);
                }
            }
            return list;
        }
        public int getSTT()
        {
            int stt = 0;
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "select isNull(max(STT),0) max from HoaDonBan ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    stt = (int)reader["max"];
                }
            }
            return (stt + 1);
        }

        public Boolean insert(CartBean shop, int stt, string maKH, string maKM, int tong)
        {
            string maHD ="HD"+ stt;
            try
            {
                using (SqlConnection conn = new connectToan().connection())
                {
                    string query = "insert into HoaDonBan(STT,MaHDB,MaNV,MaKH,MaKM,TongTien,NgayTao) values(@stt,@maHD,null,@maKH,@maKM,@Tong,GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@stt", stt);
                    cmd.Parameters.AddWithValue("@maHD", maHD);
                    cmd.Parameters.AddWithValue("@maKH", maKH);
                    cmd.Parameters.AddWithValue("@maKM", maKM);
                    cmd.Parameters.AddWithValue("@Tong", tong);
                    cmd.ExecuteNonQuery();
                }
                foreach (var items in shop.Values)
                {
                    string maSP = items.Sanpham.Masp;
                    int gia =items.Sanpham.Giaban;
                    int soluong = items.Quantity;
                    int price=soluong*gia;
                    chitietdonbandto chitiet = new chitietdonbandto(maHD, maSP, gia, soluong, price);
                    new chitietdonbandao().insert(chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public int update(hoadonbandto hd)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update HoaDonBan set MaNV= N'" + hd.Mnv + "',MaKH= N'" + hd.Mkh + "' ,MaKM= N'" + hd.Mkm + "',TongTien='" + hd.Tongtien + "',NgayTao='" + hd.Ngaytao + "' where MaHDB='" + hd.Mhdb + "' ";
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
            sqlcommand.CommandText = "select * from HoaDonBan MaHDB LIKE '" + ma + "%'";
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
                hoadonbandto hd = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hd);
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
                hoadonbandto hd = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hd);
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
                hoadonbandto hd = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hd);
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
                hoadonbandto hd = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hd);
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
                hoadonbandto hd = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hd);
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
                hoadonbandto hd = new hoadonbandto(mhdb, manv, makh, makm, tongtien, ngaytao);
                ds.Add(hd);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

    }
}
