using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Doanqlchdt.Cart;
using Doanqlchdt.connect;

namespace Doanqlchdt.DTO
{
    internal class sanphamdao
    {
        public sanphamdao() { }
        public List<sanphamdto> getds()
        {
            List<sanphamdto> ds = new List<sanphamdto>();
            using (SqlConnection connection = new connectToan().connection())
            {
                string query = "SELECT * FROM SanPham";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    String msp = reader.GetString(0);
                    String tensp = reader.GetString(1);
                    String maloai = reader.GetString(2);
                    int gianhap = reader.GetInt32(3);
                    int giaban = (int)reader["GiaBan"];
                    byte[] hinhanh = (byte[])reader["HinhAnh"];
                    string mota = (string)reader["MoTa"];
                    int soluong = (int)reader["SoLuong"];
                    sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                    ds.Add(spdto);
                }
                reader.Close();
            }
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
            sqlcommand.CommandText = "update SanPham set TenSP= N'" + spdto.Tensp + "',MaLoai= N'" + spdto.Maloai + "' ,GiaNhap= '" + spdto.Gianhap + "',GiaBan='" + spdto.Giaban + "' where MaSP='" + spdto.Masp + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }

        public Boolean updateQuantity(CartBean shop)
        {
            if (shop != null)
            {
                using (SqlConnection conn = new connectToan().connection())
                {
                    foreach (var item in shop.Values)
                    {
                        string query = "update SanPham set SoLuong = SoLuong - @quantity where maSP= @maSP";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@maSP", item.Sanpham.Masp);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            return false;
        }
        public ArrayList getdsmasp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham MaSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
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
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
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
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
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
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
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
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public sanphamdto findByID(string id)
        {
            sanphamdto sp = new sanphamdto();
            using (SqlConnection connection = new connectToan().connection())
            {
                string query = "select * from SanPham sp join Loaisanpham lsp on sp.MaLoai=lsp.MaLoai where MaSP=@id";
                SqlCommand sqlcommand = new SqlCommand(query, connection);
                sqlcommand.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                if (reader.Read())
                {
                    String msp = reader.GetString(0);
                    String tensp = reader.GetString(1);
                    String maloai = (string)reader["TenLoai"];
                    int gianhap = reader.GetInt32(3);
                    int giaban = (int)reader["GiaBan"];
                    byte[] hinhanh = (byte[])reader["HinhAnh"];
                    string mota = (string)reader["MoTa"];
                    int soluong = (int)reader["SoLuong"];
                    sp = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                }
            }
            return sp;
        }

        public List<sanphamdto> findByCondition(string condition, string price, string dau)
        {

            List<sanphamdto> sp = new List<sanphamdto>();
            using (SqlConnection connection = new connectToan().connection())
            {
                string query = "select * from SanPham sp join Loaisanpham lsp on sp.MaLoai=lsp.MaLoai where TenSP like @id and GiaBan" + dau + " @price";

                SqlCommand sqlcommand = new SqlCommand(query, connection);
                sqlcommand.Parameters.AddWithValue("@id", "%" + condition + "%");
                sqlcommand.Parameters.AddWithValue("@price", price);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    String msp = reader.GetString(0);
                    String tensp = reader.GetString(1);
                    String maloai = (string)reader["TenLoai"];
                    int gianhap = reader.GetInt32(3);
                    int giaban = (int)reader["GiaBan"];
                    byte[] hinhanh = (byte[])reader["HinhAnh"];
                    string mota = (string)reader["MoTa"];
                    int soluong = (int)reader["SoLuong"];
                    sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                    sp.Add(spdto);
                }
            }
            return sp;
        }


    }
}
