using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ET
{
    public class ET_KhoHang
    {
        /// <summary>
        /// Fields
        /// </summary>
        string maSP;
        string tenSP;
        string nhaSX;
        DateTime hanDung;
        int loaiHang;
        string donViTinh;
        float donGia;
        int soLuong;
        DateTime ngayNhap;
        string error;
        /// <summary>
        /// Properties
        /// </summary>
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

        public string TenSP
        {
            get
            {
                return tenSP;
            }

            set
            {
                tenSP = value;
            }
        }

        public string NhaSX
        {
            get
            {
                return nhaSX;
            }

            set
            {
                nhaSX = value;
            }
        }

        public DateTime HanDung
        {
            get
            {
                return hanDung;
            }

            set
            {
                hanDung = value;
            }
        }

        public int LoaiHang
        {
            get
            {
                return loaiHang;
            }

            set
            {
                loaiHang = value;
            }
        }

        public string DonViTinh
        {
            get
            {
                return donViTinh;
            }

            set
            {
                donViTinh = value;
            }
        }

        public float DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
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

        public DateTime NgayNhap
        {
            get
            {
                return ngayNhap;
            }

            set
            {
                ngayNhap = value;
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

        public ET_KhoHang(string maSP,
        string tenSP,
        string nhaSX,
        DateTime hanDung,
        int loaiHang,
        string donViTinh,
        float donGia,
        int soLuong,
        DateTime ngayNhap)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.nhaSX = nhaSX;
            this.hanDung = hanDung;
            this.loaiHang = loaiHang;
            this.donViTinh = donViTinh;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.ngayNhap = ngayNhap;
        }
    }
}
