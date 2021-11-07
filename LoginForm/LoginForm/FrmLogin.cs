using BUS_QuanLy;
using DTO_QuanLy;
using RJCodeAdvance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
            }
           
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if(txtUserName.Text == "User Name")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "User Name";
                txtUserName.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
            }
        }
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private void btLogin_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.email = txtUserName.Text;
            nv.password = txtPassword.Text;
            if (busNhanVien.NhanVienDangNhap(nv)) // khi đăng nhập thành công
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Close();
                FrmMain frmMain = new FrmMain();
                frmMain.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công, kiểm tra lại email hoặc mật khẩu");
                txtUserName.Text = null;
                txtPassword.Text = null;
                txtUserName.Focus();
            }
        }
    }
}
