using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;
using System.Net.Mail;
using System.Net;

namespace RJCodeAdvance
{
    public partial class FrmChangePassword : Form
    {
        BUS_NhanVien busNV = new BUS_QuanLy.BUS_NhanVien();

        public FrmChangePassword()
        {
            InitializeComponent();
        }


        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text.Trim().Length == 0) // kiểm tra phải nhập data
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Focus();
                return;
            }
            if (txtMatKhauMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            if (txtNhapLaiMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNhapLaiMatKhau.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật mật khẩu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string matKhauMoi = busNV.encryption(txtMatKhauMoi.Text);
                    string matKhauCu = busNV.encryption(txtMatKhauCu.Text);
                    if (busNV.NhanVienDoiMatKhau(txtEmail.Text, matKhauCu, matKhauMoi))
                    {
                        BUS_SendGmail.SendMail(txtEmail.Text, "Bạn đã cập nhật thành công mật khẩu", $"Mật khẩu mới của bạn là:${txtMatKhauMoi.Text}");
                        MessageBox.Show("Cập nhật mật khẩu thành công, bạn phải đăng nhập lại");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng, cập nhật mật khẩu không thành công");
                        txtMatKhauCu.Text = null;
                        txtMatKhauMoi.Text = null;
                        txtNhapLaiMatKhau.Text = null;
                    }
                }
                else
                {
                    txtMatKhauCu.Text = null;
                    txtMatKhauMoi.Text = null;
                    txtNhapLaiMatKhau.Text = null;
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Gửi Email
        }
}
