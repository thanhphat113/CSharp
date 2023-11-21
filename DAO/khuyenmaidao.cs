using Doanqlchdt.connect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class khuyenmaidao
    {
        public Boolean checkKM(string makh,string makm)
        {
            int a = 0;
            using(SqlConnection conn = new connectToan().connection())
            {
                string query = "select * from SuDungKM where MaKH=@makh and MaKM=@makm";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makh",makh);
                cmd.Parameters.AddWithValue("@makm", makm);
                SqlDataReader reader= cmd.ExecuteReader();
                if (reader.Read())
                {
                    a = (int)reader["trangthai"];
                }
                else return false;
            }
            if(a==0) return true; 
            return false;
        }
        public double getTiLe(string id)
        {
            double tile=1;
            using (SqlConnection conn=new connectToan().connection())
            {
                string query = "select * from KhuyenMai where MaKM=@id";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tile = (double)reader["TiLeKM"];
                }
            }
            return tile;
        }

        public void updateTrangthai(string makh,string makm)
        {
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "update SuDungKM set trangthai = '1' where MaKH=@makh and MaKM=@makm";
                SqlCommand cmd=new SqlCommand  (query, conn);
                cmd.Parameters.AddWithValue("@makh", makh);
                cmd.Parameters.AddWithValue("@makm", makm);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
