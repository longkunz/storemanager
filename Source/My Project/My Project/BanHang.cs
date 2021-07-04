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
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }
        //Khai báo biến stt để dùng làm stt hiển thị trong listview
        int stt = 1;
        BUS_HoaDon hd = new BUS_HoaDon();
        //KHi form chạy
        private void BanHang_Load(object sender, EventArgs e)
        {
            //Tự tạo mã hóa đơn không trùng
            txtMaHD.Text = creatHoaDon();
            //Lấy danh sách nhân viên
            loadDSNhanVien();
            //Lấy danh sách khách hàng
            loadDSKhachHang();
            //Lấy thời gian hiện tại
            txtNgayBanHang.Text = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            //Chức năng nhập hàng hóa tạm thời bị khóa do chưa có hóa đơn
            grBMain.Enabled = false;
            //Lấy danh sách sản phẩm
            layDSSP();
            //Nút hủy chưa hoạt động do chưa tạo hóa đơn
            btnHuy.Enabled = false;
        }
        //Hàm tự động tạo mã hóa đơn
        string creatHoaDon()
        {
            return hd.taoMaHD();
        }
        //Hàm hiển thị danh sách nhân viên
        void loadDSNhanVien()
        {
            BUS_NhanVien nv = new BUS_NhanVien();
            cbbNhanVien.DataSource = nv.loadNhanVien();
            cbbNhanVien.DisplayMember = "tenNV";
            cbbNhanVien.ValueMember = "maNV";
        }
        //Hàm hiển thị danh sách khách hàng
        void loadDSKhachHang()
        {
            BUS_KhachHang kh = new BUS_KhachHang();
            cbbKhachHang.DataSource = kh.layDanhSachKhachHang();
            cbbKhachHang.DisplayMember = "tenKH";
            cbbKhachHang.ValueMember = "maKH";
        }
        //Sự kiện khi click vào nút tạo hóa đơn
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            //KHởi tạo các lớp cần dùng
            BUS_HoaDon hd = new BUS_HoaDon();
            DateTime t = new DateTime();
            /*Định dạng ngày là MM/dd/yyyy mới chịu 
            (mặc dù trong SQL SERVER đã set DATEFORMAT dmy)*/
            DateTime.TryParse(txtNgayBanHang.Text, out t);
            ET_HoaDon et_hd = new ET_HoaDon(txtMaHD.Text, cbbKhachHang.SelectedValue.ToString(), cbbNhanVien.SelectedValue.ToString(), t);
            //Thêm hóa đơn thành công thì chức năng nhập hàng vào hóa đơn được mở khóa, không thì báo lỗi
            if (hd.themHoaDon(et_hd))
            {
                grBMain.Enabled = true;
                btnHuy.Enabled = true;
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi (Mã hóa đơn này đã được tạo)", "Thông báo !");
            }


        }
        //Sự kiện khi click vào nút hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            /*KHi bấm nút hủy nghĩa là không muốn mua hàng nữa chứ không phải là BOOM hàng,
             lúc này ta phải xóa cái hóa đơn mới tạo đi
             */
            BUS_HoaDon hd = new BUS_HoaDon();
            if (hd.xoaHoaDon(txtMaHD.Text))
            {
                MessageBox.Show("Hủy thành công", "Thông báo !");
            }
            else
            {
                MessageBox.Show("Hủy thất bại", "Thông báo !");
            }
            this.Close();

        }
        //Lấy danh sách sản phẩm
        void layDSSP()
        {
            BUS_SanPham sp = new BUS_SanPham();
            cbbSanPham.DataSource = sp.laySanPhamCon();
            cbbSanPham.DisplayMember = "tenSP";
            cbbSanPham.ValueMember = "maSP";
        }
        //Sự kiện khi thay đổi select trong combobox sản phẩm
        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS_SanPham sp = new BUS_SanPham();
            //Khi có mã sản phẩm thì gọi phương thức lấy giá theo ID
            if (cbbSanPham.SelectedValue.ToString().Length == 4)
            {
                txtGiaTien.Text = Convert.ToString(sp.giaTienByID(cbbSanPham.SelectedValue.ToString()));
                txtTenHang.Text = cbbSanPham.Text;
            }
            //Khi load-form thì chưa có value(cbb chỉ có text), lúc này lấy giá trị index mặc định là sản phẩm đầu tiên
            else
            {
                txtGiaTien.Text = Convert.ToString(sp.giaTienByID("SP01"));
                txtTenHang.Text = cbbSanPham.SelectedItem.ToString();
                cbbSanPham.SelectedIndex = 0;
                txtTenHang.Text = cbbSanPham.Text;
            }
        }
        //Sự kiện khi kiểm tra hàng hóa trong kho khi nhập số lượng
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Kiểm tra form số lượng, nếu không nhập số thì phải báo lỗi liền
            for (int i = 0; i < txtSoLuong.TextLength; i++)
            {
                if (!char.IsDigit(txtSoLuong.Text[i]))
                {
                    errorProvider1.SetError((Control)sender, "Phải nhập số!");
                    txtSoLuong.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }
        //Sự kiện khi click vào nút addCart (thêm hàng vào danh sách)
        private void btnAddCart_Click(object sender, EventArgs e)
        {
            BUS_KhoHang kho = new BUS_KhoHang();
            //Kiểm tra xem có nhập số lượng hay không
            if (txtSoLuong.TextLength == 0||int.Parse(txtSoLuong.Text)<0)
            {
                MessageBox.Show("Phải nhập số lượng và số lượng phải > 0","Thông báo");
            }
            else
            {
                //Kiểm tra sản phẩm thêm vào giỏ có đủ hàng trong kho hay không
                if (int.Parse(kho.laySoLuongHang(cbbSanPham.SelectedValue.ToString())) < int.Parse(txtSoLuong.Text))
                {
                    MessageBox.Show("Sản phẩm " + cbbSanPham.Text + " không đủ hàng trong kho","Thông báo");
                    txtSoLuong.Focus();
                }
                else
                {
                    /*Khi bấm add cart thì thông tin sản phẩm bao gồm:
                     Stt, mã sp, tên sp, giá tiền, số lượng, tổng tiền của sản phẩm
                     được thêm vào listview để hiển thị tổng quan*/
                    //KHởi tạo listviewitem
                    ListViewItem item = new ListViewItem(stt + "");
                    //Thêm 4 subitems
                    item.SubItems.Add(cbbSanPham.SelectedValue.ToString());
                    item.SubItems.Add(cbbSanPham.Text);
                    item.SubItems.Add(txtSoLuong.Text);
                    item.SubItems.Add(txtGiaTien.Text);
                    //Tính tổng tiền của sản phẩm
                    float tien = int.Parse(txtSoLuong.Text) * float.Parse(txtGiaTien.Text);
                    item.SubItems.Add(tien + "");
                    //Cho tăng stt
                    stt++;
                    //Add zô listview
                    lvGioHang.Items.Add(item);

                }
            }
            if (lvGioHang.Items.Count > 1)
            {

                for (int i = 0; i < lvGioHang.Items.Count - 1; i++)
                {
                    if (lvGioHang.Items[i].SubItems[1].Text == cbbSanPham.SelectedValue.ToString())
                    {
                        lvGioHang.Items.Remove(lvGioHang.Items[i]);
                        MessageBox.Show("Đã phẩm đã được cập nhật số lượng mới rồi nhé!", "Thông báo");
                        break;
                    }
                }
            }
            //Hiển thị tổng tiền ở textbox tổng tiền
            float tongtien = 0;
            foreach (ListViewItem it in lvGioHang.Items)
            {
                tongtien += float.Parse(it.SubItems[5].Text);
            }
            txtTongTien.Text = tongtien + "";
            //Xóa cái số lượng đi
            txtSoLuong.Clear();


        }
        //Sự kiện khi click vào nút thanh toán
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            BUS_ChiTietHoaDon cthd = new BUS_ChiTietHoaDon();
            foreach (ListViewItem item in lvGioHang.Items)
            {
                ET_ChiTietHoaDon et = new ET_ChiTietHoaDon(txtMaHD.Text, item.SubItems[1].Text, int.Parse(item.SubItems[3].Text), DateTime.Parse(txtNgayBanHang.Text));
                if (!cthd.themChiTietHoaDon(et))
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi thêm hàng vào hóa đơn", "Thông báo !");
                    break;
                }
                BUS_KhoHang kho = new BUS_KhoHang();
                if (!kho.xuatHangHoa(item.SubItems[1].Text, int.Parse(item.SubItems[3].Text)))
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi xuất hàng", "Thông báo !");
                    break;
                }
            }

            Form f = new inRaHoaDon(txtMaHD.Text);
            this.Close();
            f.Show();
        }
    }
}
