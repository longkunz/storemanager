using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET
{
    public class ET_InChiTietHoaDon
    {
        private string maHD;

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
        public ET_InChiTietHoaDon(string maHD)
        {
            this.maHD = maHD;
        }
    }
}
