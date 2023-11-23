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
    internal class taikhoandao
    {
        public taikhoandao()
        {

        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyen = reader.GetInt32(2);
                int trangthai = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyen, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(taikhoandto tk)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into TaiKhoan values(N'" + tk.Username + "',N'" + tk.Password + "','" + tk.Quyen + "','" + tk.Trangthai + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public Boolean checkttk(String tk, String mk)
        {
            Boolean flag = false;
            /*connect.connect cn = new connect.connect();  */
            connectToan cn = new connectToan();
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = cn.connection();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from TaiKhoan where Username='" + tk + "' and MatKhau='" + mk + "'";
            cmd.Connection = connection;
            SqlDataReader read = cmd.ExecuteReader();
            flag = read.Read();
            read.Close();
            cmd.Connection.Close();
            connection.Close();
            return flag;
        }
        public int update(taikhoandto tk)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "Update TaiKhoan set MatKhau=N'" + tk.Password + "',Quyen='" + tk.Quyen + "',TrangThai='" + tk.Trangthai + "' where Username='" + tk.Username + "'";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }

        public int GetQuyen(string tk, string mk)
        {
            int quyen = 0; // Giá trị mặc định hoặc giá trị không hợp lệ

            /*connect.connect cn = new connect.connect();*/
            connectToan cn = new connectToan();
            SqlConnection connection = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select Quyen from TaiKhoan where Username = '" + tk + "' and MatKhau =  '" + mk + "'";
            sqlcommand.Connection = connection;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            if (reader.Read())
            {
                quyen = Convert.ToInt32(reader["Quyen"]);
            }

            return quyen;
        }

        public ArrayList getdsquyen(int quyen)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan where Quyen like '" + quyen + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyenn = reader.GetInt32(2);
                int trangthai = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyenn, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstk(String user)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan where Username like '" + user + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyenn = reader.GetInt32(2);
                int trangthai = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyenn, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmtk(String matk)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan where MaTK like '" + matk + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {

                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyenn = reader.GetInt32(2);
                int trangthai = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyenn, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstrangthai(int trangthai)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan where TrangThai like '" + trangthai + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyenn = reader.GetInt32(2);
                int trangthaii = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyenn, trangthaii);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public khachhangdto getKhachHang(string username)
        {
            khachhangdto kh = new khachhangdto();
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "select * from TaiKhoan tk join KhachHang kh on tk.UserID=kh.MaTK where tk.Username=@user";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    String mkh = (string)reader["MaKH"];
                    String name = (string)reader["HoTen"];
                    String sdt = (String)reader["SDT"];
                    String email = (string)reader["Email"];
                    String gioitinh = (string)reader["GioiTinh"];
                    DateTime ngaysinh = (DateTime)reader["Ngaysinh"];
                    string user = (string)reader["Username"];
                    kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, user);
                }
            }
            return kh;
        }

        public Boolean changePW(string id, string pass)
        {
            if (id != null)
            {
                using (SqlConnection conn = new connectToan().connection())
                {
                    string query = "Update TaiKhoan set MatKhau=@pass where Username=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            return false;
        }

        public Boolean checkOldPass(string id,String oldPass)
        {
            string a=null;
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "select MatKhau from TaiKhoan where Username=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader= cmd.ExecuteReader();
                if (reader.Read())
                {
                    a = reader.GetString(0);
                }
            }
            return String.Equals(a, oldPass);
        }
    }
}
