using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class DAL_ChiTietHoaDon
    {
        //Phương thức hiển thị chi tiết hóa đơn
        public static DataTable loadDSChiTietHoaDon()
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectChiTietHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
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
        //Phương thức thêm chi tiết hóa đơn mới
        public static bool themChiTietHoaDon(ET_ChiTietHoaDon cthd)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertChiTietHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaHD = new SqlParameter("@maHD", cthd.MaHD);
                cmd.Parameters.Add(paraMaHD);

                SqlParameter paraMaSP = new SqlParameter("@maSP", cthd.MaSP);
                cmd.Parameters.Add(paraMaSP);

                SqlParameter paraSoLuong = new SqlParameter("@soLuong", cthd.SoLuong);
                cmd.Parameters.Add(paraSoLuong);

                SqlParameter paraNgaySX = new SqlParameter("@ngaySX", cthd.NgaySX);
                cmd.Parameters.Add(paraNgaySX);

                
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                cthd.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return result;
        }
        //Phương thức xóa chi tiết hóa đơn
        public static bool xoaChiTietHoaDon(string cthd)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_DeleteChiTietHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaHD = new SqlParameter("@maHD", cthd);
                cmd.Parameters.Add(paraMaHD);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
            return result;
        }
        //Phương thức sửa chi tiết hóa đơn
        public static bool suaChiTietHoaDon(ET_ChiTietHoaDon cthd)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UpdateChiTietHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaHD = new SqlParameter("@maHD", cthd.MaHD.ToUpper());
                cmd.Parameters.Add(paraMaHD);

                SqlParameter paraMaSP = new SqlParameter("@maSP", cthd.MaSP.ToUpper());
                cmd.Parameters.Add(paraMaSP);

                SqlParameter paraSoLuong = new SqlParameter("@soLuong", cthd.SoLuong);
                cmd.Parameters.Add(paraSoLuong);

                SqlParameter paraNgaySX = new SqlParameter("@ngaySX", cthd.NgaySX);
                cmd.Parameters.Add(paraNgaySX);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
            return result;
        }
    }
}
