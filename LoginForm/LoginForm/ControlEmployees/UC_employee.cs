﻿using BUS_QuanLy;
using DTO_QuanLy;
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

namespace RJCodeAdvance.ControlEmployees
{
    public partial class UC_employee : UserControl
    {
        BUS_NhanVien busNV = new BUS_QuanLy.BUS_NhanVien();
        public UC_employee()
        {
            InitializeComponent();
        }

      
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FrmVaiTro frm = new FrmVaiTro();
            frm.ShowDialog();
        }

        private void UC_employee_Load(object sender, EventArgs e)
        {
            ResetValue();
            ShowData_GridViewNhanVien();
            ThemVaiTro();
        }

        private void btnThemVaitro_Click(object sender, EventArgs e)
        {
            FrmVaiTro frm = new FrmVaiTro();
            frm.ShowDialog();
            this.Refresh();
            ThemVaiTro();
        }

        private void btThem_Click_1(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = null;
            txtLuong.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            txtEmail.Enabled = true;
            txtLuong.Enabled = true;
            txtTenNhanVien.Enabled = true;
            txtDiaChi.Enabled = true;
            cbVaiTro.Enabled = true;
            dtNgaySinh.Enabled = true;
            rbNam.Enabled = true;
            rbNu.Enabled = true;
            btnThemVaitro.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int gioitinh = 0;
            int vaitro = 0;
            vaitro = cbVaiTro.SelectedIndex + 1;

            if (rbNam.Checked)
                gioitinh = 1;
            else
                gioitinh = 0;

            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            //else if (!IsValid(txtEmail.Text.Trim()))
            //{
            //    MessageBox.Show("Bạn phải nhập đúng định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtEmail.Focus();
            //    return;
            //}
            else if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            else if (txtLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lương nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuong.Focus();
                return;
            }

            if (rbNam.Checked == false && rbNu.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
            if (cbVaiTro.Items.Contains(""))
            {
                MessageBox.Show("Bạn phải chọn vai trò nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }

            else
            {
                DTO_NhanVien nv = new DTO_NhanVien(vaitro, txtTenNhanVien.Text, gioitinh, txtEmail.Text, txtDiaChi.Text, dtNgaySinh.Value.ToString(), float.Parse(txtLuong.Text));
                if (busNV.InsertNhanVien(nv))
                {
                    ResetValue();
                    ShowData_GridViewNhanVien();
                    //SendMail(nv.email);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                if (busNV.DeleteNhanVien(txtEmail.Text))
                {
                    ResetValue();
                    ShowData_GridViewNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            else
            {
                ResetValue();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int gioitinh = 0;
            int vaitro = 0;
            vaitro = cbVaiTro.SelectedIndex + 1;

            if (rbNam.Checked)
                gioitinh = 1;
            else
                gioitinh = 0;

            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            else if (txtLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lương nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuong.Focus();
                return;
            }
            else
            {
                DTO_NhanVien nv = new DTO_NhanVien(vaitro, txtTenNhanVien.Text, gioitinh, txtEmail.Text, txtDiaChi.Text, dtNgaySinh.Value.ToString(), float.Parse(txtLuong.Text));
                if (busNV.UpdateNhanVien(nv))
                {
                    ResetValue();
                    ShowData_GridViewNhanVien();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        public void ResetValue()
        {
            txtTimKiem.Text = "Nhập tên nhân viên cần tìm";
            txtTenNhanVien.Text = null;
            txtLuong.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            txtEmail.Enabled = false;
            txtLuong.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtDiaChi.Enabled = false;
            cbVaiTro.Enabled = false;
            dtNgaySinh.Enabled = false;
            rbNam.Enabled = false;
            rbNu.Enabled = false;
            btnThemVaitro.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        //Hiển thị dữ liệu nhân viên
        public void ShowData_GridViewNhanVien()
        {
            dgv_NhanVien.DataSource = busNV.HienThiDuLieuNhanVien();
            dgv_NhanVien.Columns[0].HeaderText = "Vai trò";
            dgv_NhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgv_NhanVien.Columns[2].HeaderText = "Giới tính";
            dgv_NhanVien.Columns[3].HeaderText = "Email";
            dgv_NhanVien.Columns[4].HeaderText = "Địa chỉ";
            dgv_NhanVien.Columns[5].HeaderText = "Ngày sinh";
            dgv_NhanVien.Columns[6].HeaderText = "Lương";
        }

        //Kiểm tra định dạng email
        public bool IsValid(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //Gửi mail
        public void SendMail(string email)
        {
            try
            {
                //Now we must create a Smtp client to send our mail
                SmtpClient client = new SmtpClient("stmp.gmail.com", 25);  //smtp.gmail.com // For gmail
                //Authentication
                //This is where the valid email account comes into play. You must have a valid email
                //Account(with password) to give our program a place to send the mail from.
                NetworkCredential cred = new NetworkCredential("daotanthien1405@gmail.com", "sang0903987105");
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("daotanthien1405@gmail.com");//Nothing but above Credentials or your credentials(****@gmail.com)
                //Recipient e-mail address.
                Msg.To.Add(email);
                //Assign the subject of our message
                Msg.Subject = "Chào mừng thành viên mới";
                //Create the content(body) of our message
                Msg.Body = "Chào anh/chị.Mật khẩu cập nhật là 1234. Anh chị vui lòng đăng nhập vào phần mềm để đổi mật khẩu";
                //Send our account login details to the client.
                client.Credentials = cred;
                //Enabling SSL(Secure Sockets Layer, encryption) is reqiured by most email providers to send mail
                client.EnableSsl = true;
                client.Send(Msg); // Send our email
                //Confirmation After click the Button
                MessageBox.Show("Một email đã gửi tới bạn!");
            }
            catch (Exception ex)
            {
                //If mail doesn't send error message will be displayed
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string name = txtTimKiem.Text;
            DataTable ds = busNV.SearchNhanVien(name);
            if (ds.Rows.Count > 0)
            {
                dgv_NhanVien.DataSource = ds;
                dgv_NhanVien.Columns[0].HeaderText = "Vai trò";
                dgv_NhanVien.Columns[1].HeaderText = "Tên nhân viên";
                dgv_NhanVien.Columns[2].HeaderText = "Giới tính";
                dgv_NhanVien.Columns[3].HeaderText = "Email";
                dgv_NhanVien.Columns[4].HeaderText = "Địa chỉ";
                dgv_NhanVien.Columns[5].HeaderText = "Ngày sinh";
                dgv_NhanVien.Columns[6].HeaderText = "Lương";
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTimKiem.Text = "Nhập tên nhân viên cần tìm";
            txtTimKiem.BackColor = Color.LightGray;
            ResetValue();
        }

        public void ThemVaiTro()
        {
            cbVaiTro.DataSource = busNV.ThemVaiTro();
            cbVaiTro.DisplayMember = "Name";
            cbVaiTro.ValueMember = "Id_role";
        }

        private void dgv_NhanVien_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_NhanVien.Rows.Count > 1)
            {
                try
                {
                    btnLuu.Enabled = false;
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                    txtEmail.Enabled = true;
                    txtLuong.Enabled = true;
                    txtTenNhanVien.Enabled = true;
                    txtDiaChi.Enabled = true;
                    cbVaiTro.Enabled = true;
                    dtNgaySinh.Enabled = true;
                    rbNam.Enabled = true;
                    rbNu.Enabled = true;
                    btnThemVaitro.Enabled = true;
                    txtEmail.Text = dgv_NhanVien.CurrentRow.Cells["Email"].Value.ToString();
                    txtTenNhanVien.Text = dgv_NhanVien.CurrentRow.Cells["Name"].Value.ToString();
                    txtDiaChi.Text = dgv_NhanVien.CurrentRow.Cells["Address"].Value.ToString();
                    txtLuong.Text = dgv_NhanVien.CurrentRow.Cells["Salary"].Value.ToString();
                    if (int.Parse(dgv_NhanVien.CurrentRow.Cells["Id_role"].Value.ToString()) == 1)
                        cbVaiTro.Text = "Quản lý";
                    else
                        cbVaiTro.Text = "Nhân viên";
                    if (int.Parse(dgv_NhanVien.CurrentRow.Cells["Gender"].Value.ToString()) == 1)
                        rbNam.Checked = true;
                    else
                        rbNu.Checked = true;
                }
                catch
                {
                    ResetValue();
                    MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
