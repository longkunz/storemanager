using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using DAL;
using System.Data;
namespace BUS
{
    public class BUS_NhanVien
    {
        //Phương thức hiển thị nhân viên
        public DataTable loadNhanVien()
        {
            return DAL_NhanVien.loadDSNhanVien();
        }
        //Phương thức thêm mới nhân viên
        public bool themNhanVien(ET_NhanVien nv)
        {
            return DAL_NhanVien.themNhanVien(nv);
        }
        //Phương thức sửa nhân viên
        public bool suaNhanVien(ET_NhanVien nv)
        {
            return DAL_NhanVien.suaNhanVien(nv);
        }      
        //Phương thức xóa nhân viên
        public bool xoaNhanVien(string nv)
        {
            return DAL_NhanVien.xoaNhanVien(nv);
        }
        //Phương thức đăng nhạp tài khoản
        public DataTable login(string user, string pass)
        {
            return DAL_NhanVien.login(user, pass);
        }
    }
}
