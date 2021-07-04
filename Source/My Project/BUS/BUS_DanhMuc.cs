using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using ET;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class BUS_DanhMuc
    {
        //Phuong thức lấy tất cả danh mục
        public DataTable layDSDanhMuc()
        {
            return DAL_DanhMuc.layDSDanhMuc();
        }
        //Phương thức thêm một danh mục mới
        public bool themDanhMuc(ET_DanhMuc dm)
        {
            return DAL_DanhMuc.themDanhMuc(dm);
        }
        //Phương thức xóa danh mục
        public bool xoaDanhMuc(int maDM)
        {
            return DAL_DanhMuc.xoaDanhMuc(maDM);
        }
        //Phương thức sửa danh mục
        public bool suaDanhMuc(ET_DanhMuc dm)
        {
            return DAL_DanhMuc.suaDanhMuc(dm);
        }
    }
}
