using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using CrystalDecisions.Shared;

namespace My_Project
{
    public partial class inRaHoaDon : Form
    {
        string maHD;     
        public inRaHoaDon(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;  
        }

        private void inRaHoaDon_Load(object sender, EventArgs e)
        {
            BUS_InChiTietHoaDon chiTietHD = new BUS_InChiTietHoaDon();
            inHoaDon inHD = new inHoaDon();
            inHD.SetDataSource(chiTietHD.LayDSChiTietHoaDon(maHD));
            crrInRaHoaDon.ReportSource = inHD;
            crrInRaHoaDon.Refresh();
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            this.Close();           
        }
    }
}
