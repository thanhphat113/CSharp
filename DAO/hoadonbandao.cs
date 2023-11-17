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
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            /*connect.connect cn = new connect.connect();*/
            //Cái này để connect tới connect của Toàn nhé
            connectToan cn = new connectToan();
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
        public void insert(hoadonbandto hd)
        {
            try
            {
                using (SqlConnection conn = new connectToan().connection())
                {
                    string query = "insert into HoaDonBan values(@maHD,@maNV,@maKH,@maKM,@Tong,@ngayTao)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maHD", hd.Mhdb);
                    cmd.Parameters.AddWithValue("@maNV", hd.Mnv);
                    cmd.Parameters.AddWithValue("@maKH", hd.Mkh);
                    cmd.Parameters.AddWithValue("@maKM", hd.Mkm);
                    cmd.Parameters.AddWithValue("@Tong", hd.Tongtien);
                    cmd.Parameters.AddWithValue("@ngayTao", hd.Ngaytao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
