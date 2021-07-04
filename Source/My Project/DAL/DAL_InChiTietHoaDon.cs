using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET;

namespace DAL
{
    public class DAL_InChiTietHoaDon
    {
        //Phương thức hiển thị chi tiết hóa đơn theo mã
        public static DataTable LayDSChiTietHoaDon(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InChiTietHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaHD = new SqlParameter("@maHD", ma);
                cmd.Parameters.Add(paraMaHD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
            return dt;
        }
        //Phương thức hiển thị chi tiết hóa đơn theo mã nhưng ít thông tin hơn
        public static DataTable LayChiTietHoaDon(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectChiTietHoaDonByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaHD = new SqlParameter("@maHD", ma);
                cmd.Parameters.Add(paraMaHD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
            return dt;
        }
    }
}
