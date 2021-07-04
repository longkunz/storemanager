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
    public partial class FrmNhanVien : Form
    {
        //Fields
        string maNV = null;
        public FrmNhanVien(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }
        //Khởi tạo bus nhân viên
        BUS_NhanVien busNhanVien;
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            busNhanVien = new BUS_NhanVien();
            dgvNhanVien.DataSource = busNhanVien.loadNhanVien();
        }
        //Sự kiện khi click vào nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {

            Control ctr = (Control)sender;
            ET_NhanVien NhanVien = new ET_NhanVien(txtMaNhanVien.Text, txtTenNhanVien.Text, txtDiaChi.Text, txtSDT.Text, txtChucVu.Text, txtPass.Text);
            if (txtMaNhanVien.Text.Length != 0 && txtTenNhanVien.Text.Length != 0 &&
                txtDiaChi.Text.Length != 0 && txtSDT.Text.Length != 0 && txtChucVu.Text.Length != 0 && txtPass.Text.Length != 0)
            {
                if (busNhanVien.themNhanVien(NhanVien))
                {
                    MessageBox.Show("Thêm nhân viên thành công !", "Thêm");
                    txtMaNhanVien.Clear();
                    txtTenNhanVien.Clear();
                    txtDiaChi.Clear();
                    txtSDT.Clear();
                    txtChucVu.Clear();
                    errorProvider1.Clear();
                    dgvNhanVien.DataSource = busNhanVien.loadNhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại !", "Thêm");
                }
            }
            else
            {

                errorProvider1.SetError(ctr, "Không được để trống !");
            }
        }
        //Sự kiện khi click vào danh sách nhân viên
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNhanVien.Text = dgvNhanVien.Rows[row].Cells[0].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.Rows[row].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[row].Cells[2].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[row].Cells[3].Value.ToString();
            txtChucVu.Text = dgvNhanVien.Rows[row].Cells[4].Value.ToString();
            txtPass.Text = dgvNhanVien.Rows[row].Cells[5].Value.ToString();
        }
        //Sự kiện khi click vào nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {

            Control ctr = (Control)sender;
            ET_NhanVien NhanVien = new ET_NhanVien(txtMaNhanVien.Text, txtTenNhanVien.Text, txtDiaChi.Text, txtSDT.Text, txtChucVu.Text, txtPass.Text);
            busNhanVien.suaNhanVien(NhanVien);
            if (txtMaNhanVien.Text.Length != 0 && txtTenNhanVien.Text.Length != 0 &&
                txtDiaChi.Text.Length != 0 && txtSDT.Text.Length != 0 && txtChucVu.Text.Length != 0 && txtPass.Text.Length != 0)
            {
                dgvNhanVien.DataSource = busNhanVien.loadNhanVien();
                txtMaNhanVien.Clear();
                txtTenNhanVien.Clear();
                txtDiaChi.Clear();
                txtSDT.Clear();
                txtChucVu.Clear();
                errorProvider1.Clear();
                MessageBox.Show("Sửa nhân viên thành công !", "Sửa");
            }
            else
            {
                errorProvider1.SetError(ctr, "Vui lòng chọn nhân viên muốn sửa !");
            }
        }
        //Sự kiện khi nhập số điện thoại
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                errorProvider1.SetError(ctr, "Vui lòng nhập số điện thoại !");
                e.Handled = true;
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        //Sự kiện khi click vào nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Length == 0 && txtTenNhanVien.Text.Length == 0 &&
                txtDiaChi.Text.Length == 0 && txtSDT.Text.Length == 0 && txtChucVu.Text.Length == 0 && txtPass.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                busNhanVien = new BUS_NhanVien();
                DialogResult r = MessageBox.Show("Bạn có muốn xóa không ?", "Xóa ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (maNV.Equals(txtMaNhanVien.Text))
                    {
                        MessageBox.Show("Không thể xóa user" + maNV + " do đang đăng nhập!", "Lỗi");
                    }
                    else
                    {
                        if (busNhanVien.xoaNhanVien(txtMaNhanVien.Text) == true)
                        {
                            MessageBox.Show("Xóa thành công !", "Xóa");
                            //Không xóa được Row 1 với 2
                            dgvNhanVien.DataSource = busNhanVien.loadNhanVien();
                        }
                    }
                }
            }
        }
        //Sự kiện kiểm tra số điện thoại phải có 10 số
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            for (int i = 0; i < txtSDT.Text.Length; i++)
            {
                if (txtSDT.Text.Length > 10)
                {
                    txtSDT.TabStop.ToString();
                }
            }
        }
       
    }
}
