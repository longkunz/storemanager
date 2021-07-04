using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;
using ET;

namespace My_Project
{
    public partial class frmDanhMuc : Form
    {
        public frmDanhMuc()
        {
            InitializeComponent();
        }
        //Ham cập nhật dữ liệu cho datagribview - lấy danh sách danh mục
        void loadDanhMuc()
        {
            dgvDanhMuc.DataSource = busDanhMuc.layDSDanhMuc();
        }
        //Khởi tạo bus danh mục
        BUS_DanhMuc busDanhMuc = new BUS_DanhMuc();
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            loadDanhMuc();
        }
        //Sự kiện khi click vào nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text.Length == 0 || txtTenDanhMuc.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                ET_DanhMuc etdm = new ET_DanhMuc(int.Parse(txtMaDanhMuc.Text), txtTenDanhMuc.Text);
                if (busDanhMuc.themDanhMuc(etdm))
                {
                    MessageBox.Show("Thêm thành công", "Thêm");
                    txtMaDanhMuc.Clear();
                    txtTenDanhMuc.Clear();                    
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi \n" + etdm.Error, "Thông báo !");
                }
            }
            dgvDanhMuc.DataSource = busDanhMuc.layDSDanhMuc();
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();

        }
        //Sự kiện kiểm tra mã danh mục
        private void txtMaDanhMuc_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < txtMaDanhMuc.Text.Length; i++)
            {
                if (!char.IsDigit(txtMaDanhMuc.Text[i]))
                {
                    errorProvider1.SetError((Control)sender, "Mã danh mục phải là số");
                    txtMaDanhMuc.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }
        //Sự kiện khi click vào nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text.Length == 0 || txtTenDanhMuc.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busDanhMuc.xoaDanhMuc(int.Parse(txtMaDanhMuc.Text)))
                    {
                        MessageBox.Show("Xóa thành công!", "Xóa");
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi liên quan đến ràng buộc cơ sở dữ liệu", "Thông báo !");
                    }
                }
            }

            loadDanhMuc();
        }
        //Sự kiện khi click vào nội dung trong danh sách danh mục
        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvDanhMuc.CurrentRow.Index;
            txtMaDanhMuc.Text = dgvDanhMuc.Rows[row].Cells[0].Value.ToString();
            txtTenDanhMuc.Text = dgvDanhMuc.Rows[row].Cells[1].Value.ToString();
        }
        //Sự kiện khi click vào nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDanhMuc.Text.Length == 0 || txtTenDanhMuc.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn lưu thay đổi hay không?", "Sửa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (txtMaDanhMuc.Text.Length == 0 || txtTenDanhMuc.Text.Length == 0)
                    {
                        MessageBox.Show("Không được để trống dữ liệu", "Thông báo !");
                    }
                    else
                    {
                        ET_DanhMuc etdm = new ET_DanhMuc(int.Parse(txtMaDanhMuc.Text), txtTenDanhMuc.Text);
                        if (busDanhMuc.suaDanhMuc(etdm))
                        {
                            MessageBox.Show("Sửa thành công", "Sửa");
                        }
                        else
                        {
                            MessageBox.Show(etdm.Error);
                        }
                    }
                }
            }
            loadDanhMuc();
        }
        //Sự kiện khi click vào nút clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
        }
    }
}
