using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAL_NhanVien
    {
        //Phương thức hiển thị nhân viên
        public static DataTable loadDSNhanVien()
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectNhanVien";
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
        //Phương thức thêm mới nhân viên
        public static bool themNhanVien(ET_NhanVien nv)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaNV = new SqlParameter("@maNV", nv.MaNV.ToUpper());
                cmd.Parameters.Add(paraMaNV);

                SqlParameter paraTenNV = new SqlParameter("@tenNV", nv.TenNV);
                cmd.Parameters.Add(paraTenNV);

                SqlParameter paraDiaChi = new SqlParameter("@diaChi", nv.DiaChi);
                cmd.Parameters.Add(paraDiaChi);

                SqlParameter paraSDT = new SqlParameter("@sDT", nv.SDT);
                cmd.Parameters.Add(paraSDT);

                SqlParameter paraChucVu = new SqlParameter("@chucVu", nv.ChucVu);
                cmd.Parameters.Add(paraChucVu);

                SqlParameter paramatkhau = new SqlParameter("@matKhau", nv.MatKhau);
                cmd.Parameters.Add(paramatkhau);

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
        //Phương thức xóa nhân viên
        public static bool xoaNhanVien(string nv)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_DeleteNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaNV = new SqlParameter("@maNV", nv);
                cmd.Parameters.Add(paraMaNV);
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
        //Phương thức sửa nhân viên
        public static bool suaNhanVien(ET_NhanVien nv)
        {
            bool result = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UpdateNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaNV = new SqlParameter("@maNV", nv.MaNV);
                cmd.Parameters.Add(paraMaNV);

                SqlParameter paraTenNV = new SqlParameter("@tenNV", nv.TenNV);
                cmd.Parameters.Add(paraTenNV);

                SqlParameter paraDiaChi = new SqlParameter("@diaChi", nv.DiaChi);
                cmd.Parameters.Add(paraDiaChi);

                SqlParameter paraSDT = new SqlParameter("@sDT", nv.SDT);
                cmd.Parameters.Add(paraSDT);

                SqlParameter paraChucVu = new SqlParameter("@chucVu", nv.ChucVu);
                cmd.Parameters.Add(paraChucVu);

                SqlParameter paramatkhau = new SqlParameter("@matKhau", nv.MatKhau);
                cmd.Parameters.Add(paramatkhau);
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
        //Phương thức đăng nhạp tài khoản
        public static DataTable login(string user, string pass)
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Login";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter paraMaNV = new SqlParameter("@maNV", user);
                cmd.Parameters.Add(paraMaNV);
                     
                SqlParameter paramatkhau = new SqlParameter("@matKhau", pass);
                cmd.Parameters.Add(paramatkhau);

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
