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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        //Khởi tạo bus hóa đơn
        BUS_HoaDon busHoaDon = new BUS_HoaDon();

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            loadHoaDon();
            layDSNV();
            layDSKH();
        }
        //Phương thức lấy danh sách hóa đơn
        void loadHoaDon()
        {
            dgvHoaDon.DataSource = busHoaDon.loadHoaDon();
        }
        //Phương thức lấy danh sách nhân viên
        void layDSNV()
        {
            BUS_NhanVien nv = new BUS_NhanVien();
            cbbNhanVien.DataSource = nv.loadNhanVien();
            cbbNhanVien.DisplayMember = "tenNV";
            cbbNhanVien.ValueMember = "maNV";
        }
        //Phương thức lấy danh sách khách hàng
        void layDSKH()
        {
            BUS_KhachHang kh = new BUS_KhachHang();
            cbbKhachHang.DataSource = kh.layDanhSachKhachHang();
            cbbKhachHang.DisplayMember = "tenKH";
            cbbKhachHang.ValueMember = "maKH";
        }
        //Sự kiện khi click vào nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text.Length == 0 && dtpNgayLapHoaDon.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                Control ctr = (Control)sender;
                ET_HoaDon HoaDon = new ET_HoaDon(txtMaHoaDon.Text, cbbKhachHang.SelectedValue.ToString(), cbbNhanVien.SelectedValue.ToString(), DateTime.Parse(dtpNgayLapHoaDon.Text));
                if (txtMaHoaDon.Text.Length != 0 || dtpNgayLapHoaDon.Text.Length != 0)
                {
                    if (busHoaDon.themHoaDon(HoaDon))
                    {
                        MessageBox.Show("Thêm hóa đơn thành công !", "Thêm");
                        txtMaHoaDon.Text = busHoaDon.taoMaHD();
                        dgvHoaDon.DataSource = busHoaDon.loadHoaDon();
                        layDSNV();
                        layDSKH();
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn thất bại !\n" + HoaDon.Error, "Thêm");
                    }
                }
                else
                {

                    errorProvider1.SetError(ctr, "Không được để trống !");
                }
            }
        }
        //Sự kiện khi click vào danh sách hóa đơn
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvHoaDon.CurrentCell.RowIndex;
            txtMaHoaDon.Text = dgvHoaDon.Rows[row].Cells[0].Value.ToString();
            cbbKhachHang.SelectedValue = dgvHoaDon.Rows[row].Cells[1].Value.ToString();
            cbbNhanVien.SelectedValue = dgvHoaDon.Rows[row].Cells[2].Value.ToString();
            dtpNgayLapHoaDon.Text = dgvHoaDon.Rows[row].Cells[3].Value.ToString();
        }
        //Sự kiện khi click vào nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text.Length == 0 || dtpNgayLapHoaDon.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                busHoaDon = new BUS_HoaDon();
                DialogResult r = MessageBox.Show("Bạn có muốn xóa không ?", "Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (busHoaDon.xoaHoaDon(txtMaHoaDon.Text))
                    {
                        MessageBox.Show("Xóa thành công !", "Xóa");
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa hóa đơn này do có chứa chi tiết hóa đơn @@", "Thông báo !");
                    }
                }
            }
            loadHoaDon();
            layDSKH();
            layDSNV();
        }
        //Sự kiện khi click vào nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text.Length == 0 || dtpNgayLapHoaDon.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                Control ctr = (Control)sender;
                ET_HoaDon HoaDon = new ET_HoaDon(txtMaHoaDon.Text.ToUpper(), cbbKhachHang.SelectedValue.ToString(), cbbNhanVien.SelectedValue.ToString(), DateTime.Parse(dtpNgayLapHoaDon.Text));
                if (txtMaHoaDon.Text.Length != 0)
                {
                    if (busHoaDon.suaHoaDon(HoaDon))
                    {
                        MessageBox.Show("Sửa hóa đơn thành công !", "Sửa");
                    }
                    else
                    {
                        MessageBox.Show("Sửa hóa đơn thất bại !", "Sửa");
                    }
                }
                else
                {
                    errorProvider1.SetError(ctr, "Không được để trống !");
                }
            }
            loadHoaDon();
            layDSNV();
            layDSKH();
        }
        //Sự kiện khi click vào nút xem
        private void btnXem_Click(object sender, EventArgs e)
        {
            Form f = new frmChiTietHoaDon(txtMaHoaDon.Text);
            f.ShowDialog();
        }

        private void btnInReportHoaDon_Click(object sender, EventArgs e)
        {
            if (dtpNgayBatDau.Value <= dtpNgayKetThuc.Value)
            {
                Form f = new ReportHoaDon(dtpNgayBatDau.Value, dtpNgayKetThuc.Value);
                f.Show();

            }
            else
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông báo");
            }
        }
    }
}
