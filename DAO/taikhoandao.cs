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
                int mtk = reader.GetInt32(0);
                String username = reader.GetString(1);
                String password = reader.GetString(2);
                int quyen = reader.GetInt32(3);
                int trangthai = reader.GetInt32(4);
                taikhoandto tk=new taikhoandto(mtk,username,password,quyen,trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(taikhoandto tk)
        {
            connect.connect cn=new connect.connect();          
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType=System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into TaiKhoan values('" + tk.Matk + "',N'" + tk.Username + "',N'" + tk.Password + "','" + tk.Quyen + "','" + tk.Trangthai + "')";
            SqlConnection connect = cn.connection();
            int kq=sqlcommand.ExecuteNonQuery();
            return kq;
        }
        public Boolean checkttk(String tk,String mk)
        {
            Boolean flag=false;
            connect.connect cn = new connect.connect();    
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = cn.connection();
            cmd.CommandType= System.Data.CommandType.Text;
            cmd.CommandText = "Select * from TaiKhoan where Username='"+tk+"' and MatKhau='"+mk+"'";
            cmd.Connection = connection;
            SqlDataReader read=cmd.ExecuteReader();
            flag=read.Read();
            read.Close();
            cmd.Connection.Close();
            connection.Close();
            return flag;
        }
    }
}
