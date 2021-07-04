using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using ET;
namespace BUS
{
    public class BUS_SanPham
    {
        //Phương thức lấy danh sách sản phẩm còn từ kho
        public DataTable laySanPhamCon()
        {
            return DAL_SanPham.laySanPhamCon();
        }
        //Phương thức lấy danh sách sản phẩm từ kho
        public DataTable laySanPham()
        {
            return DAL_SanPham.layDSSanPham();
        }
        //Phương thức lấy giá tiền sản phẩm khi có mã sản phẩm
        public string giaTienByID(string id)
        {
            return DAL_SanPham.giaTienByID(id);
        }
        //Phương thức sửa sản phẩm
        public bool suaSanPham(ET_SanPham sp)
        {
            return DAL_SanPham.suaSanPham(sp);
        }
    }
}
