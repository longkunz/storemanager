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
    public partial class ReportKho : Form
    {
        public ReportKho()
        {
            InitializeComponent();
        }

        private void ReportKho_Load(object sender, EventArgs e)
        {
            BUS_KhoHang kho = new BUS_KhoHang();
            inKhoHang inKho = new inKhoHang();
            inKho.SetDataSource(kho.layDSKho());
            crrInRaHoaDon.ReportSource = inKho;
            crrInRaHoaDon.Refresh();
        }
    }
}
