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
                string query = "SELECT * FROM SuDungKM WHERE MaKH = @makh AND MaKM COLLATE SQL_Latin1_General_CP1_CS_AS = @makm;";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makh",makh);
                cmd.Parameters.AddWithValue("@makm", makm);
                SqlDataReader reader= cmd.ExecuteReader();
                if (reader.Read())
                {
                    a = 1;
                }
                else return false;
            }
            if(a==1) return true; 
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
                string query = "delete from SuDungKM where MaKM=@makm and MaKH=@makh";
                SqlCommand cmd=new SqlCommand  (query, conn);
                cmd.Parameters.AddWithValue("@makh", makh);
                cmd.Parameters.AddWithValue("@makm", makm);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
