using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ET
{
    public class ET_SanPham
    {
        /// <summary>
        /// Fields
        /// </summary>
        string maSP;
        string tenSP;
        string nhaSX;
        int loaiHang;
        string donViTinh;
        float donGia;
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

        public ET_SanPham(string maSP,
        string tenSP,
        string nhaSX,
        int loaiHang,
        string donViTinh,
        float donGia)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.nhaSX = nhaSX;
            this.loaiHang = loaiHang;
            this.donViTinh = donViTinh;
            this.donGia = donGia;         
        }
    }
}
