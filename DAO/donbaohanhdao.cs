using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class donbaohanhdao
    {
        public donbaohanhdao() { }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh,manv,makh,masp,ngaytao,ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(donbaohanhdto dbhdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into DonBaoHanh values(N'" + dbhdto.Madonbaohanh + "',N'" + dbhdto.Manv + "',N'" + dbhdto.Makh + "',N'" + dbhdto.Masp + "','" + dbhdto.Ngaytao + "','" + dbhdto.Ngaytra + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            return kq;
        }
        public int update(donbaohanhdto dbhdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update DonBaoHanh set MaNV= N'" + dbhdto.Manv + "',MaKH= N'" + dbhdto.Makh + "' ,MaSP= N'" + dbhdto.Masp + "',NgayTao='" + dbhdto.Ngaytao + "',NgayTra='"+dbhdto.Ngaytra+"' where MaDBH='" + dbhdto.Madonbaohanh + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            return kq;
        }
        public ArrayList getdsmadon(String madon)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh MaDBH LIKE '"+madon+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
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
            sqlcommand.CommandText = "select * from DonBaoHanh MaNV LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmakh(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh MaKH LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
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
            sqlcommand.CommandText = "select * from DonBaoHanh MaSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngaytao(DateTime ngay)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh NgayTao LIKE '" + ngay + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngaytra(DateTime ngay)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh NgayTra LIKE '" + ngay + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
