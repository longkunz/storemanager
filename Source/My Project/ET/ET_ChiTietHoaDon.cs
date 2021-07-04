using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ET
{
    public class ET_ChiTietHoaDon
    {
        string maHD;
        string maSP;
        int soLuong;
        DateTime ngaySX;
        string error;

        public string MaHD
        {
            get
            {
                return maHD;
            }

            set
            {
                maHD = value;
            }
        }

        public string MaSP
        {
            get
            {
                return maSP;
            }

            set
            {
                maSP = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public DateTime NgaySX
        {
            get
            {
                return ngaySX;
            }

            set
            {
                ngaySX = value;
            }
        }

        public string Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }

        public ET_ChiTietHoaDon(string maHD,string maSP,int soLuong,DateTime ngaySX)
        {
            this.maHD = maHD;
            this.MaSP = maSP;
            this.soLuong = soLuong;
            this.ngaySX = ngaySX;
        }
    }
}
