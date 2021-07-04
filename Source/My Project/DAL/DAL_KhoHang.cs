using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ET;
namespace DAL
{
    public class DAL_KhoHang
    {
        //Phương thức lấy danh sách sản phẩm trong kho hàng
        public static DataTable layDSKhoHang()
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_SelectKhoHang";
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
        //Phương thức nhập hàng vào kho
        public static bool nhapHang(ET_KhoHang kho)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InsertKhoHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter masp = new SqlParameter("maSP", kho.MaSP);
                cmd.Parameters.Add(masp);
                SqlParameter tensp = new SqlParameter("tenSP", kho.TenSP);
                cmd.Parameters.Add(tensp);
                SqlParameter nsx = new SqlParameter("nhaSX", kho.NhaSX);
                cmd.Parameters.Add(nsx);
                SqlParameter handung = new SqlParameter("hanDung", kho.HanDung);
                cmd.Parameters.Add(handung);
                SqlParameter loaihang = new SqlParameter("loaiHang", kho.LoaiHang);
                cmd.Parameters.Add(loaihang);
                SqlParameter donvi = new SqlParameter("donViTinh", kho.DonViTinh);
                cmd.Parameters.Add(donvi);
                SqlParameter dongia = new SqlParameter("donGia", kho.DonGia);
                cmd.Parameters.Add(dongia);
                SqlParameter soluong = new SqlParameter("soLuong", kho.SoLuong);
                cmd.Parameters.Add(soluong);
                SqlParameter ngaynhap = new SqlParameter("ngayNhap", kho.NgayNhap);
                cmd.Parameters.Add(ngaynhap);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                kho.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return kq;
        }
        //Phương thức xóa hàng khỏi kho (vì một lý do nào đó)
        public static bool xoaHang(string ma)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_DeleteKhoHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maHang = new SqlParameter("maSP", ma);
                cmd.Parameters.Add(maHang);

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
        //Phương thức xuất hàng hóa khi bán
        public static bool xuatHang(string ma, int soLuong)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_XuatKhoHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maHang = new SqlParameter("maSP", ma);
                cmd.Parameters.Add(maHang);
                SqlParameter soluong = new SqlParameter("soLuongBan", soLuong);
                cmd.Parameters.Add(soluong);

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
        //Phương thức sửa sản phẩm trong kho hàng
        public static bool suaKhoHang(ET_KhoHang kho)
        {
            bool kq = false;
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_UpdateKhoHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter masp = new SqlParameter("maSP", kho.MaSP);
                cmd.Parameters.Add(masp);
                SqlParameter tensp = new SqlParameter("tenSP", kho.TenSP);
                cmd.Parameters.Add(tensp);
                SqlParameter nsx = new SqlParameter("nhaSX", kho.NhaSX);
                cmd.Parameters.Add(nsx);
                SqlParameter handung = new SqlParameter("hanDung", kho.HanDung);
                cmd.Parameters.Add(handung);
                SqlParameter loaihang = new SqlParameter("loaiHang", kho.LoaiHang);
                cmd.Parameters.Add(loaihang);
                SqlParameter donvi = new SqlParameter("donViTinh", kho.DonViTinh);
                cmd.Parameters.Add(donvi);
                SqlParameter dongia = new SqlParameter("donGia", kho.DonGia);
                cmd.Parameters.Add(dongia);
                SqlParameter soluong = new SqlParameter("soLuong", kho.SoLuong);
                cmd.Parameters.Add(soluong);
                SqlParameter ngaynhap = new SqlParameter("ngayNhap", kho.NgayNhap);
                cmd.Parameters.Add(ngaynhap);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                kho.Error = ex.Message;
            }
            finally
            {
                Connection.con.Close();
            }
            return kq;
        }
        //Phương thức kiểm tra số lượng hàng còn trong kho
        public static string laySoLuongHang(string ma)
        {
            string kq = "";
            try
            {
                Connection.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_checkSoLuong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.con;
                SqlParameter maHang = new SqlParameter("maSP", ma);
                cmd.Parameters.Add(maHang);

                kq = (string)cmd.ExecuteScalar();
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
    }
}
