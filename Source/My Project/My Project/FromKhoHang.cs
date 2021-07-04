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
using System.Data.SqlClient;

namespace My_Project
{
    public partial class frmKhoHang : Form
    {
        public frmKhoHang()
        {
            InitializeComponent();
        }
        //KHởi tạo BUS kho hàng
        BUS_KhoHang busKho = new BUS_KhoHang();
        //Phương thức lấy toàn bộ sản phẩm trong kho hàng
        void loadKho()
        {
            dgvKhoHang.DataSource = busKho.layDSKho();
        }
        //Phương thức lấy toàn bộ danh mục
        void loadDanhMuc()
        {
            BUS_DanhMuc busDM = new BUS_DanhMuc();
            cbbLoaiHang.DataSource = busDM.layDSDanhMuc();
            cbbLoaiHang.DisplayMember = "tenDanhMuc";
            cbbLoaiHang.ValueMember = "maDanhMuc";
        }
        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            loadKho();
            loadDanhMuc();
        }
        //Sự kiện khi click vào datagribview
        private void dgvKhoHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvKhoHang.CurrentCell.RowIndex;
            txtMaSP.Text = dgvKhoHang.Rows[row].Cells[0].Value.ToString();
            txtTenSP.Text = dgvKhoHang.Rows[row].Cells[1].Value.ToString();
            txtNhaSX.Text = dgvKhoHang.Rows[row].Cells[2].Value.ToString();
            dtpHanDung.Text = dgvKhoHang.Rows[row].Cells[3].Value.ToString();
            cbbLoaiHang.SelectedValue = dgvKhoHang.Rows[row].Cells[4].Value.ToString();
            txtDonVi.Text = dgvKhoHang.Rows[row].Cells[5].Value.ToString();
            txtDonGia.Text = dgvKhoHang.Rows[row].Cells[6].Value.ToString();
            txtSoLuong.Text = dgvKhoHang.Rows[row].Cells[7].Value.ToString();
            dtpNgayNhap.Text = dgvKhoHang.Rows[row].Cells[8].Value.ToString();
        }

        //Sự kiện khi click vào nút nhập
        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text.Length!=0 && txtDonGia.Text.Length != 0 && txtDonVi.Text.Length != 0 && txtNhaSX.Text.Length != 0
                && txtSoLuong.Text.Length != 0 && txtTenSP.Text.Length != 0)
            {
                ET_KhoHang hanghoa = new ET_KhoHang(txtMaSP.Text.ToUpper(), txtTenSP.Text, txtNhaSX.Text, dtpHanDung.Value,
                      int.Parse(cbbLoaiHang.SelectedValue.ToString()), txtDonVi.Text, float.Parse(txtDonGia.Text), int.Parse(txtSoLuong.Text), dtpNgayNhap.Value);
                if (MessageBox.Show("Bạn có muốn nhập kho hay không?", "Thêm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busKho.nhapHangHoa(hanghoa))
                    {
                        MessageBox.Show("Nhập hàng thành công", "Thêm");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xảy ra \n" + hanghoa.Error, "Thông báo !");
                    }
                }

            }
            else
            {
                MessageBox.Show("Không được để trống!", "Thông báo");
            }

            loadKho();
        }
        //Sự kiện khi click vào nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text.Length == 0 && txtDonGia.Text.Length == 0 && txtDonVi.Text.Length == 0 && txtNhaSX.Text.Length == 0
                && txtSoLuong.Text.Length == 0 && txtTenSP.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                ET_KhoHang hanghoa = new ET_KhoHang(txtMaSP.Text.ToUpper(), txtTenSP.Text, txtNhaSX.Text, dtpHanDung.Value,
                    int.Parse(cbbLoaiHang.SelectedValue.ToString()), txtDonVi.Text, float.Parse(txtDonGia.Text), int.Parse(txtSoLuong.Text), dtpNgayNhap.Value);
                if (MessageBox.Show("Bạn có muốn lưu lại hay không?", "Sửa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busKho.suaHangHoa(hanghoa))
                    {
                        MessageBox.Show("Lưu dữ liệu thành công", "Sửa");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xảy ra \n" + hanghoa.Error, "Thông báo !");
                    }
                }
            }
            loadKho();
        }
        //Sự kiện khi click vào nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text.Length != 0 && txtDonGia.Text.Length != 0 && txtDonVi.Text.Length != 0 && txtNhaSX.Text.Length != 0
                && txtSoLuong.Text.Length != 0 && txtTenSP.Text.Length != 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa sản phẩm " + txtTenSP.Text + " hay không?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busKho.xoaHangHoa(txtMaSP.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Xóa");
                        txtMaSP.Clear();
                        txtTenSP.Clear();
                        txtDonGia.Clear();
                        txtDonVi.Clear();
                        txtNhaSX.Clear();
                        txtSoLuong.Clear();
                        cbbLoaiHang.SelectedText = null;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xảy ra", "Thông báo");
                    }
                }
            }
            loadKho();
        }
        //Sự kiện khi click vào nút clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtDonVi.Clear();
            txtMaSP.Clear();
            txtNhaSX.Clear();
            txtSoLuong.Clear();
            txtTenSP.Clear();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Form f = new ReportKho();
            f.Show();
        }
    }
}
