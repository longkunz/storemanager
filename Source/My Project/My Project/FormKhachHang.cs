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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        //Khoi tao BUS
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        //Phương thức load danh sách khách hàng
        void loadKhachHang()
        {
            dgvKhachHang.DataSource = busKhachHang.layDanhSachKhachHang();
        }      
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            loadKhachHang();
        }
        //Sự kiện cho buttonThem
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length == 0 || txtTenKH.Text.Length == 0 || txtDiaChi.Text.Length == 0 || txtSTD.Text.Length == 0)
            {
                MessageBox.Show("Phải điền đầy đủ thông tin", "Thông báo !");
            }
            else
            {
                ET_KhachHang et_kh = new ET_KhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSTD.Text);
                if (busKhachHang.themKhachHang(et_kh))
                {
                    MessageBox.Show("Thêm thành công!", "Thêm");
                    txtMaKH.Clear();
                    txtTenKH.Clear();
                    txtDiaChi.Clear();
                    txtSTD.Clear();
                    dgvKhachHang.DataSource = busKhachHang.layDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Lỗi" + et_kh.Error, "Thông báo !");
                }
            }
        }
        //Sự kiện cho buttonSua
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length == 0 || txtTenKH.Text.Length == 0 || txtDiaChi.Text.Length == 0 || txtSTD.Text.Length == 0)
            {
                MessageBox.Show("Phải điền đầy đủ thông tin", "Thông báo !");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn lưu dữ liệu mới không? ", "Sửa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (txtMaKH.Text.Length == 0 || txtTenKH.Text.Length == 0 || txtDiaChi.Text.Length == 0 || txtSTD.Text.Length == 0)
                    {
                        MessageBox.Show("Điền đầy đủ thông tin mới chịu", "Thông báo !");
                    }
                    else
                    {
                        ET_KhachHang et_kh = new ET_KhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSTD.Text);
                        if (busKhachHang.suaKhachHang(et_kh))
                        {
                            MessageBox.Show("Sửa thành công", "Sửa");
                        }
                        else
                        {
                            MessageBox.Show(et_kh.Error, "Thông báo !");
                        }
                    }
                }
            }
            loadKhachHang();
        }
        //Sự kiện khi click vào nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length == 0 || txtTenKH.Text.Length == 0 || txtDiaChi.Text.Length == 0 || txtSTD.Text.Length == 0)
            {
                MessageBox.Show("Phải điền đầy đủ thông tin", "Thông báo !");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không? ", "Xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (busKhachHang.xoaKhachHang(txtMaKH.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Xóa");
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi", "Thông báo !");
                    }
                }
            }
            
            loadKhachHang();
        }
        //Sự kiện chọn vào datagribview
        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvKhachHang.CurrentRow.Index;
            txtMaKH.Text = dgvKhachHang.Rows[row].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[row].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[row].Cells[2].Value.ToString();
            txtSTD.Text = dgvKhachHang.Rows[row].Cells[3].Value.ToString();
        }
        //Sự kiện khi click vào nút clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDiaChi.Clear();
            txtMaKH.Clear();
            txtSTD.Clear();
            txtTenKH.Clear();
        }
    }
}
