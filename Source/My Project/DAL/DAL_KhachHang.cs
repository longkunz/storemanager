using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET;
namespace DAL
{
    public class DAL_KhachHang
    {
        //Phương thức lấy danh sách khách hàng
        public static DataTable layDanhSachKhachHang()
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectKhachHang";
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
        //Phương thức thêm khách hàng mới
        public static bool themKhachHang(ET_KhachHang kh)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertKhachHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maKH = new SqlParameter("maKH", kh.MaKH);
                cmd.Parameters.Add(maKH);
                SqlParameter tenKH = new SqlParameter("tenKH", kh.TenKH);
                cmd.Parameters.Add(tenKH);
                SqlParameter diachi = new SqlParameter("diaChi", kh.DiaChi);
                cmd.Parameters.Add(diachi);
                SqlParameter sdt = new SqlParameter("sDT", kh.SDT);
                cmd.Parameters.Add(sdt);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                kh.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return kq;
        }
        //Phương thức xóa khách hàng
        public static bool xoaKhachHang(string ma)
        {
            bool kq  = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_DeleteKhachHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maHD = new SqlParameter("maKH", ma);
                cmd.Parameters.Add(maHD);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    kq = true;
                }
                else
                {
                    kq = false;
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
            return kq;
        }
        //Phương thức sửa khách hàng
        public static bool suaKhachHang(ET_KhachHang kh)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UpdateKhachHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maKH = new SqlParameter("maKH", kh.MaKH);
                cmd.Parameters.Add(maKH);
                SqlParameter tenKH = new SqlParameter("tenKH", kh.TenKH);
                cmd.Parameters.Add(tenKH);
                SqlParameter diachi = new SqlParameter("diaChi", kh.DiaChi);
                cmd.Parameters.Add(diachi);
                SqlParameter sdt = new SqlParameter("sDT", kh.SDT);
                cmd.Parameters.Add(sdt);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                kh.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return kq;
        }
        //Phương thức lấy khách hàng bằng mã khách hàng
        public static DataTable layKHByID(string ma)
        {

            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectKhachHangByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;

                SqlParameter maKH = new SqlParameter("maKH", ma);
                cmd.Parameters.Add(maKH);
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
