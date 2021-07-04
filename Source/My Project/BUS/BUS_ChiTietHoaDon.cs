using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ET;
using DAL;
using System.Data;
namespace BUS
{
    public class BUS_ChiTietHoaDon
    {
        public DataTable loadChiTietHoaDon()
        {
            return DAL_ChiTietHoaDon.loadDSChiTietHoaDon();
        }
        public bool themChiTietHoaDon(ET_ChiTietHoaDon cthd)
        {
            return DAL_ChiTietHoaDon.themChiTietHoaDon(cthd);
        }
        public bool suaChiTietHoaDon(ET_ChiTietHoaDon cthd)
        {
            return DAL_ChiTietHoaDon.suaChiTietHoaDon(cthd);
        }
        public bool xoaChiTietHoaDon(string cthd)
        {
            return DAL_ChiTietHoaDon.xoaChiTietHoaDon(cthd);
        }
    }
}
