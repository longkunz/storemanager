using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using ET;
namespace BUS
{
    public class BUS_KhachHang
    {
        //Phương thức lấy danh sách khách hàng
        public DataTable layDanhSachKhachHang()
        {
            return DAL_KhachHang.layDanhSachKhachHang();
        }
        //Phương thức thêm khách hàng mới
        public bool themKhachHang(ET_KhachHang hd)
        {
            return DAL_KhachHang.themKhachHang(hd);
        }
        //Phương thức xóa khách hàng
        public bool xoaKhachHang(string maHD)
        {
            return DAL_KhachHang.xoaKhachHang(maHD);
        }
        //Phương thức sửa khách hàng
        public bool suaKhachHang(ET_KhachHang hd)
        {
            return DAL_KhachHang.suaKhachHang(hd);
        }
        //Phương thức lấy khách hàng bằng maKH
        public DataTable layKHByID(string maKH)
        {
            return DAL_KhachHang.layKHByID(maKH);
        }
    }
}
