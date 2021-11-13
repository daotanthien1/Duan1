using BUS_QuanLy;
using DTO_QuanLy;
using RJCodeAdvance.ControlVouchers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance
{
    public partial class FrmLogin : Form
    {
        BUS_NhanVien busNV = new BUS_NhanVien();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string mail = txtEmail.Text;
            UC_Voucher.mail = mail;
            FrmSchedule.mail = mail;
            FrmBeverageCP frm = new FrmBeverageCP();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btGuiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                if (busNV.NhanVienQuenMatKhau(txtEmail.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(RandomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    string matkhaumoi = busNV.encryption(builder.ToString());
                    busNV.TaoMatKhauMoi(txtEmail.Text, matkhaumoi);
                    string subject = "Bạn đã dùng chức năng quên Mật Khẩu";
                    string body = $"Mật khẩu mới của bạn là:{builder.ToString()}";
                    if (BUS_SendGmail.SendMail(txtEmail.Text, subject, body))
                    {
                        MessageBox.Show("mật khẩu mới đã được gửi đến Gmail của bạn");
                    }
                    else
                    {
                        MessageBox.Show("không thể gửi");
                    }
                }
                else
                {
                    MessageBox.Show("Email không tồn tại, vui lòng nhập lại email! ");
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập lại email nhận thông tin phục hồi mật khẩu!");
                txtEmail.Focus();
            }
        }
        //Tạo chuỗi ngẫu nhiên
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        //Tạo số ngẫu nhiên
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.email = txtEmail.Text;
            nv.password = busNV.encryption(txtPassword.Text);
            nv.password = txtPassword.Text;
            if (busNV.NhanVienDangNhap(nv)) // khi đăng nhập thành công
            {
                this.Hide();
                FrmBeverageCP frmMain = new FrmBeverageCP();
                frmMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công, kiểm tra lại email hoặc mật khẩu");
                txtPassword.Text = null;
                txtPassword.Focus();
            }
        }

        private void LoginNew_Load(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
