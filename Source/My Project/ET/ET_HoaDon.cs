using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ET
{
    public class ET_HoaDon
    {
        private string maHD;
        private string maKH;
        private string maNV;
        private DateTime ngayLapHoaDon;
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

        public string MaKH
        {
            get
            {
                return maKH;
            }

            set
            {
                maKH = value;
            }
        }

        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }

        public DateTime NgayLapHoaDon
        {
            get
            {
                return ngayLapHoaDon;
            }

            set
            {
                ngayLapHoaDon = value;
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

        public ET_HoaDon(string maHD,string maKH,string maNV,DateTime ngayLapHoaDon)
        {
            this.maHD = maHD;
            this.maKH = maKH;
            this.maNV = maNV;
            this.ngayLapHoaDon = ngayLapHoaDon;
        }
    }
}
