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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        //Khởi tạo bus sản phẩm
        BUS_SanPham busSP = new BUS_SanPham();
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            loadDanhMuc();
            dgvSanPham.DataSource = busSP.laySanPham();
        }
        //Lấy danh sách danh mục
        void loadDanhMuc()
        {
            BUS_DanhMuc busDanhMuc = new BUS_DanhMuc();
            cbbLoaiHang.DataSource = busDanhMuc.layDSDanhMuc();
            cbbLoaiHang.DisplayMember = "tenDanhMuc";
            cbbLoaiHang.ValueMember = "maDanhMuc";
        }
        //Sự kiện khi click vào nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text.Length == 0 || txtDonGia.Text.Length == 0 || txtNhaSanXuat.Text.Length == 0 || txtTenSanPham.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                BUS_SanPham busSp = new BUS_SanPham();

                if (txtMaSanPham.Text.Length != 0 && txtDonGia.Text.Length != 0 && txtNhaSanXuat.Text.Length != 0 && txtTenSanPham.Text.Length != 0)
                {
                    ET_SanPham sp = new ET_SanPham(txtMaSanPham.Text.ToUpper(), txtTenSanPham.Text, txtNhaSanXuat.Text, int.Parse(cbbLoaiHang.SelectedValue.ToString()), txtDonViTinh.Text, float.Parse(txtDonGia.Text));
                    if (busSP.suaSanPham(sp))
                    {
                        MessageBox.Show("Sửa thông tin sản phẩm thành công!", "Sửa");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin không thành công!", "Sửa");
                    }
                }
                loadDanhMuc();
                dgvSanPham.DataSource = busSP.laySanPham();
            }
        }
        //Sự kiện khi click vào danh sách sản phẩm
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvSanPham.CurrentCell.RowIndex;
            txtMaSanPham.Text = dgvSanPham.Rows[row].Cells[0].Value.ToString();
            txtTenSanPham.Text = dgvSanPham.Rows[row].Cells[1].Value.ToString();
            txtNhaSanXuat.Text = dgvSanPham.Rows[row].Cells[2].Value.ToString();
            cbbLoaiHang.SelectedValue = dgvSanPham.Rows[row].Cells[3].Value.ToString();
            txtDonViTinh.Text = dgvSanPham.Rows[row].Cells[4].Value.ToString();
            txtDonGia.Text = dgvSanPham.Rows[row].Cells[5].Value.ToString();
        }
        //Sự kiện khi click vào nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chọn chức năng kho hàng để nhập hàng","Thêm");
        }
    }
}
