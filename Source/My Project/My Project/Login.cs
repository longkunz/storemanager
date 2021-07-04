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
    public partial class Login : Form
    {
        BUS_NhanVien N = new BUS_NhanVien();
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BUS_NhanVien nv = new BUS_NhanVien();
                DataTable dt = new DataTable();
                 dt=nv.login(txtUser.Text.ToUpper(), txtPass.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công !", "Thông báo !",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    HomePage home = new HomePage(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString());
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng tài khoản !","Thông báo !");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.con.Close();
            }
            
        }
    }
}
