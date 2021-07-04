using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class DAL_HoaDon
    {
        //Phương thức lấy danh sách hóa đơn
        public static DataTable loadDSHoaDon()
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectHoaDon";
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
        //Phương thức thêm hóa đơn
        public static bool themHoaDon(ET_HoaDon hd)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaHD = new SqlParameter("@maHD", hd.MaHD);
                cmd.Parameters.Add(paraMaHD);

                SqlParameter paraMaKH = new SqlParameter("@maKH", hd.MaKH);
                cmd.Parameters.Add(paraMaKH);

                SqlParameter paraMaNV = new SqlParameter("@maNV", hd.MaNV);
                cmd.Parameters.Add(paraMaNV);

                SqlParameter paraNgayLapHD = new SqlParameter("@ngayLapHD", hd.NgayLapHoaDon);
                cmd.Parameters.Add(paraNgayLapHD);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }               
            }
            catch (Exception ex)
            {
                hd.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return result;
        }
        //Phương thức xóa hóa đơn
        public static bool xoaHoaDon(string hd)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_DeleteHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaHD = new SqlParameter("@maHD", hd);
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
        //Phương thức tạo mã hóa đơn tự động
        public static string taoMaHD()
        {
            string result = null;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_TaoMaHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                result = (string)cmd.ExecuteScalar();
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
        //Phương thức sửa hóa đơn
        public static bool suaHoaDon(ET_HoaDon hd)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UpdateleHoaDon";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;

                SqlParameter mahd = new SqlParameter("maHD", hd.MaHD);
                cmd.Parameters.Add(mahd);

                SqlParameter makh = new SqlParameter("maKH", hd.MaKH);
                cmd.Parameters.Add(makh);

                SqlParameter manv = new SqlParameter("maNV", hd.MaNV);
                cmd.Parameters.Add(manv);

                SqlParameter ngaytao = new SqlParameter("ngayLapHD", hd.NgayLapHoaDon);
                cmd.Parameters.Add(ngaytao);

                if(cmd.ExecuteNonQuery()!=0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                hd.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return result;
        }
        //Phương thức lấy danh sách hóa đơn có giới hạn ngày tháng
        public static DataTable layHoaDonTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InHoaDonTheoThoiGian";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;

                SqlParameter ngaybd = new SqlParameter("@ngayBatDau", ngayBatDau);
                cmd.Parameters.Add(ngaybd);

                SqlParameter ngaykt = new SqlParameter("@ngayKetThuc", ngayKetThuc);
                cmd.Parameters.Add(ngaykt);

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
