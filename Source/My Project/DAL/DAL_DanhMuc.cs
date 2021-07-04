using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_DanhMuc
    {
        //Phuong thuc lay danh sach tat ca danh muc
        public static DataTable layDSDanhMuc()
        {
            DataTable dt=new DataTable();
            try{
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectDanhMuc";
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
        //Phương thức thêm một danh mục mới
        public static bool themDanhMuc(ET_DanhMuc dm)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertDanhMuc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maDM = new SqlParameter("maDanhMuc", dm.MaDanhMuc);
                cmd.Parameters.Add(maDM);
                SqlParameter tenDM = new SqlParameter("tenDanhMuc", dm.TenDanhMuc);
                cmd.Parameters.Add(tenDM);
                if(cmd.ExecuteNonQuery()!=0)
                {
                    kq = true;
                }
                
            }
            catch (Exception ex)
            {
                dm.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return kq;
        }
        //Phương thức xóa một danh mục
        public static bool xoaDanhMuc(int ma)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_DeleteDanhMuc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maDM = new SqlParameter("maDanhMuc", ma);
                cmd.Parameters.Add(maDM);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    kq = true;
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
        //Phương thức sửa danh mục
        public static bool suaDanhMuc(ET_DanhMuc dm)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UpdateDanhMuc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maDM = new SqlParameter("maDanhMuc", dm.MaDanhMuc);
                cmd.Parameters.Add(maDM);
                SqlParameter tenDM = new SqlParameter("tenDanhMuc", dm.TenDanhMuc);
                cmd.Parameters.Add(tenDM);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    kq = true;
                }

            }
            catch (Exception ex)
            {
                dm.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return kq;
        }
    }
}
