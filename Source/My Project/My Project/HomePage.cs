using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace My_Project
{
    //Khai báo fields khởi tạo thông tin đăng nhập
    public partial class HomePage : Form
    {
        string maNV = "", tenNV = "", chucvu = "", matKhau = "";
        public HomePage(string maNV, string tenNV, string chucvu, string matKhau)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.matKhau = matKhau;
            this.chucvu = chucvu;
        }
        //Kiểm tra nếu không phải chức vụ là admin thì tắt các chức năng không được phép sử dụng
        void checkPermisstion()
        {
            if(chucvu!="admin")
            {
                btnDanhMuc.Enabled = false;
                btnKhoHang.Enabled = false;
                btnTaiKhoan.Enabled = false;
            }
        }
        //Phương thức kiểm tra form đã kích hoạt hay chưa, nếu đã chạy trả về true, chưa trả về false
        public bool checkFormRun(Form f)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == f.Name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        //Kiêm tra form, nếu đã chạy thì active lên chứ không chạy thêm form mới
        public void activeForm(Form f)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == f.Name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            Form f = new frmKhoHang();
            if (checkFormRun(f) == false)
            {
                f.Show();
                f.MdiParent = this;
            }
            else
            {
                activeForm(f);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            Form f = new frmSanPham();
            if (checkFormRun(f) == false)
            {
                f.Show();
                f.MdiParent = this;
            }
            else
            {
                activeForm(f);
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            Form f = new frmKhachHang();
            if (checkFormRun(f) == false)
            {
                f.Show();
                f.MdiParent = this;
            }
            else
            {
                activeForm(f);
            }
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            Form f = new frmDanhMuc();
            if (checkFormRun(f) == false)
            {
                f.Show();
                f.MdiParent = this;
            }
            else
            {
                activeForm(f);
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            checkPermisstion();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            Form f = new frmHoaDon();
            if (checkFormRun(f) == false)
            {
                f.Show();
                f.MdiParent = this;
            }
            else
            {
                activeForm(f);
            }
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            Form f = new BanHang();
            if (checkFormRun(f) == false)
            {
                f.Show();
                f.MdiParent = this;
            }
            else
            {
                activeForm(f);
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            Form f = new FrmNhanVien(maNV);
            if (checkFormRun(f) == false)
            {
                f.Show();
                f.MdiParent = this;
            }
            else
            {
                activeForm(f);
            }
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?","Thông báo",MessageBoxButtons.OKCancel)!=DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
