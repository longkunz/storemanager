using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ET
{
    public class ET_KhachHang
    {
        /// <summary>
        /// Fields
        /// </summary>
        string maKH;
        string tenKH;
        string diaChi;
        string sDT;
        string error;
        /// <summary>
        /// Properties
        /// </summary>
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

        public string TenKH
        {
            get
            {
                return tenKH;
            }

            set
            {
                tenKH = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string SDT
        {
            get
            {
                return sDT;
            }

            set
            {
                sDT = value;
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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maKH"></param>
        /// <param name="tenKH"></param>
        /// <param name="diaChi"></param>
        /// <param name="sDT"></param>
        public ET_KhachHang(string maKH,string tenKH,string diaChi,string sDT)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.diaChi = diaChi;
            this.sDT = sDT;
        }
    }
}
