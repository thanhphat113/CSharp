using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class loaisanphamdao
    {
        public loaisanphamdao()
        {
        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from Loaisanpham";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mlsp = reader.GetString(0);
                String tenlsp = reader.GetString(1);
                loaisanphamdto loai = new loaisanphamdto(mlsp,tenlsp);
                ds.Add(loai);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(loaisanphamdto loaispdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into Loaisanpham values(N'" + loaispdto.Maloai + "',N'" + loaispdto.Tenloai + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(loaisanphamdto loaispdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update Loaisanpham set TenLoai= N'" + loaispdto.Tenloai + "' where MaLoai='" + loaispdto.Maloai + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmaloai(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from Loaisanpham MaLoai LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mlsp = reader.GetString(0);
                String tenlsp = reader.GetString(1);
                loaisanphamdto loai = new loaisanphamdto(mlsp, tenlsp);
                ds.Add(loai);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstenloai(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from Loaisanpham TenLoai LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mlsp = reader.GetString(0);
                String tenlsp = reader.GetString(1);
                loaisanphamdto loai = new loaisanphamdto(mlsp, tenlsp);
                ds.Add(loai);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
