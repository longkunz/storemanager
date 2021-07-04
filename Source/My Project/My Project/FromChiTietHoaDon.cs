using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using ET;

namespace My_Project
{
    public partial class frmChiTietHoaDon : Form
    {
        //Tạo bus chitiethoadon
        BUS_ChiTietHoaDon busChiTietHoaDon = new BUS_ChiTietHoaDon();
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }
        //Tham số mã hóa đơn truyền vào để lấy chi tiết hóa đơn
        string maHD;
        //KHởi tạo frmChiTietHoaDon
        public frmChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }
        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            BUS_InChiTietHoaDon chiTietHD = new BUS_InChiTietHoaDon();
            inHoaDon inHD = new inHoaDon();
            inHD.SetDataSource(chiTietHD.LayDSChiTietHoaDon(maHD));
            crrInRaHoaDon.ReportSource = inHD;
            crrInRaHoaDon.Refresh();

        }
             
    }
}
