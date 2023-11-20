using Doanqlchdt.connect;
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
        public ArrayList findAll()
        {
            ArrayList ds = new System.Collections.ArrayList();
            /*connect.connect cn = new connect.connect();*/
            connectToan cn = new connectToan();
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
                string mtk = reader.GetString(5);
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
            sqlcommand.CommandText = "insert into KhachHang values(N'" + khdto.Mkh + "',N'" + khdto.Hoten + "',N'" + khdto.Sdt + "',N'" + khdto.Email + "','" + khdto.Ngaysinh + "','"+khdto.Username+"')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public Boolean update(khachhangdto khdto)
        {
            if (khdto.Mkh != null)
            {
                using(SqlConnection conn= new connectToan().connection())
                {
                    string query = "update KhachHang set HoTen=@ten,SDT=@sdt,Email=@email,NgaySinh=@ngaysinh where MaKH=@makh";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", khdto.Hoten);
                    cmd.Parameters.AddWithValue("@sdt", khdto.Sdt);
                    cmd.Parameters.AddWithValue("@email", khdto.Email);
                    cmd.Parameters.AddWithValue("@ngaysinh", khdto.Ngaysinh.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@makh", khdto.Mkh);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            return false;
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
                string mtk = reader.GetString(5);
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
                string mtk = reader.GetString(5);
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
                string mtk = reader.GetString(5);
                khachhangdto kh = new khachhangdto(mkh, name, sdtt, email, ngaysinh,mtk );
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
                string mtk = reader.GetString(5);
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
                string mtk = reader.GetString(5);
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
                string mtk = reader.GetString(5);
                khachhangdto kh = new khachhangdto(mkh, name, sdt, email, ngaysinh, mtk);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public khachhangdto findByID(string id)
        {
            khachhangdto kh = new khachhangdto();
            using(SqlConnection conn=new connectToan().connection())
            {
                string query = "select * from KhachHang where MaKH=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string tenKH = (String)reader["HoTen"];
                    string email = (String)reader["Email"];
                    string sdt = (String)reader["SDT"];
                    DateTime ngaysinh = (DateTime)reader["NgaySinh"];
                    string username= (String)reader["Username"];
                    kh = new khachhangdto(id,tenKH,email,sdt,ngaysinh,username);
                }
            }
            return kh;
        } 

    }
}
