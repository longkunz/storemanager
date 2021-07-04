using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using ET;
namespace BUS
{
    public class BUS_KhoHang
    {
        //Phương thức lấy danh sách sản phẩm có trong kho hàng
        public DataTable layDSKho()
        {
            return DAL_KhoHang.layDSKhoHang();
        }
        //Phương thức nhập hàng hóa vào kho
        public bool nhapHangHoa(ET_KhoHang hanghoa)
        {
            return DAL_KhoHang.nhapHang(hanghoa);
        }
        //Phương thức xóa hàng hóa khỏi kho
        public bool xoaHangHoa(string maSP)
        {
            return DAL_KhoHang.xoaHang(maSP);
        }
        //Phương thức sửa hàng hóa trong kho
        public bool suaHangHoa(ET_KhoHang hanghoa)
        {
            return DAL_KhoHang.suaKhoHang(hanghoa);
        }
        //Phương thức xuất hàng hóa trong kho
        public bool xuatHangHoa(string maSP, int soLuong)
        {
            return DAL_KhoHang.xuatHang(maSP, soLuong);
        }
        //Phương thức kiểm tra số lượng hàng trong kho
        public string laySoLuongHang(string ma)
        {
            return DAL_KhoHang.laySoLuongHang(ma);
        }
    }
}
