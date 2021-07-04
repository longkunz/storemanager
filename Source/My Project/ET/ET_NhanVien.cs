using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ET
{
    public class ET_NhanVien
    {
        private string maNV;
        private string tenNV;
        private string diaChi;
        private string sDT;
        private string chucVu;
        private string matKhau;

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

        public string TenNV
        {
            get
            {
                return tenNV;
            }

            set
            {
                tenNV = value;
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

        public string ChucVu
        {
            get
            {
                return chucVu;
            }

            set
            {
                chucVu = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }

        public ET_NhanVien(string maNV,string tenNV, string diaChi, string sDT, string chucVu,string matKhau)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.chucVu = chucVu;
            this.matKhau = matKhau;
        }
    }
}
