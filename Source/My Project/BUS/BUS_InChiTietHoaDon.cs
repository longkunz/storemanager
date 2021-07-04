using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using DAL;
using System.Data;

namespace BUS
{
    public class BUS_InChiTietHoaDon
    {
        //Phương thức lấy hóa đơn có trong chi tiết hóa đơn
        public DataTable LayDSChiTietHoaDon(string ma)
        {
            return DAL_InChiTietHoaDon.LayDSChiTietHoaDon(ma);
        }
        //Phương thức lấy hóa đơn có trong chi tiết hóa đơn nhưng ít thông tin hơn
        public DataTable LayChiTietHoaDon(string ma)
        {
            return DAL_InChiTietHoaDon.LayChiTietHoaDon(ma);
        }
    }
}
