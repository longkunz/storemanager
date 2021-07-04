using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ET;
namespace DAL
{
    public class DAL_SanPham
    {
        //Phương thức lấy danh sách sản phẩm trong kho
        public static DataTable layDSSanPham()
        {

            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectSanPham";
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
        //Lấy giá tiền từ id sản phẩm
        public static string giaTienByID(string id)
        {
            string tien = "";
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_LayGiaSPByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;

                SqlParameter masp = new SqlParameter("@maSP", id);
                cmd.Parameters.Add(masp);

                tien = (string)cmd.ExecuteScalar();
            }
            catch(Exception)
            {

            }
            finally
            {
                Connection.con.Close();
            }
            return tien;
        }
        //Phương thức chỉnh sửa thông tin sản phẩm
        public static bool suaSanPham(ET_SanPham sp)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UpdateSanPham";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;

                SqlParameter masp = new SqlParameter("maSP", sp.MaSP);
                cmd.Parameters.Add(masp);

                SqlParameter tensp = new SqlParameter("tenSP", sp.TenSP);
                cmd.Parameters.Add(tensp);

                SqlParameter nhasx = new SqlParameter("nhaSX", sp.NhaSX);
                cmd.Parameters.Add(nhasx);

                SqlParameter loaihang = new SqlParameter("loaiHang", sp.LoaiHang);
                cmd.Parameters.Add(loaihang);

                SqlParameter donvitinh = new SqlParameter("donViTinh", sp.DonViTinh);
                cmd.Parameters.Add(donvitinh);

                SqlParameter dongia = new SqlParameter("donGia", sp.DonGia);
                cmd.Parameters.Add(dongia);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    result = true;
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
        //Phương thức lấy danh sách sản phẩm còn trong kho
        public static DataTable laySanPhamCon()
        {

            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectSanPhamCon";
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
    }
}
