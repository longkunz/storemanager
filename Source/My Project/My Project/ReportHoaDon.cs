using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace My_Project
{
    public partial class ReportHoaDon : Form
    {
        DateTime ngayBatDau = new DateTime(), ngayKetThuc = new DateTime();

        private void ReportHoaDon_Load(object sender, EventArgs e)
        {
            BUS_HoaDon HD = new BUS_HoaDon();
            HoaDon inHD = new HoaDon();
            inHD.SetDataSource(HD.layHoaDonTheoNgay(ngayBatDau,ngayKetThuc));
            crrInRaHoaDon.ReportSource = inHD;
            crrInRaHoaDon.Refresh();
        }

        public ReportHoaDon(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            InitializeComponent();
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
    }
}
