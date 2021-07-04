using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using DAL;
using System.Data;
namespace BUS
{
    public class BUS_HoaDon
    {
        //Phương thức lấy danh sách hóa đơn
        public DataTable loadHoaDon()
        {
            return DAL_HoaDon.loadDSHoaDon();
        }
        //Phương thức thêm hóa đơn mới
        public bool themHoaDon(ET_HoaDon hd)
        {
            return DAL_HoaDon.themHoaDon(hd);
        }
        //Phương thức sửa hóa đơn
        public bool suaHoaDon(ET_HoaDon hd)
        {
            return DAL_HoaDon.suaHoaDon(hd);
        }
        //Phương thức xóa hóa đơn
        public bool xoaHoaDon(string hd)
        {
            return DAL_HoaDon.xoaHoaDon(hd);
        }
        //Phương thức tạo mã hóa đơn tự động
        public string taoMaHD()
        {
            return DAL_HoaDon.taoMaHD();
        }
        //Phương thức lấy danh sách hóa đơn theo ngày
        public DataTable layHoaDonTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return DAL_HoaDon.layHoaDonTheoNgay(ngayBatDau, ngayKetThuc);
        }
    }
}
