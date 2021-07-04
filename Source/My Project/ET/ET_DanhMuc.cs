using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ET
{
    public class ET_DanhMuc
    {
        /// <summary>
        /// Fields
        /// </summary>
        int maDanhMuc;
        string tenDanhMuc;
        string error;
        /// <summary>
        /// Properties
        /// </summary>
        public int MaDanhMuc
        {
            get
            {
                return maDanhMuc;
            }

            set
            {
                maDanhMuc = value;
            }
        }

        public string TenDanhMuc
        {
            get
            {
                return tenDanhMuc;
            }

            set
            {
                tenDanhMuc = value;
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

        public ET_DanhMuc(int maDanhMuc, string tenDanhMuc)
        {
            this.maDanhMuc = maDanhMuc;
            this.tenDanhMuc = tenDanhMuc;
        }
    }
}
