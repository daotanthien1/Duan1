using BUS_QuanLy;
using DTO_QuanLy;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance
{
    public partial class FrmBeverageCP : Form
    {
        public static int session = 0;  // kiểm tra tình trạng login
        FrmLogin dn;
        public FrmBeverageCP()
        {
            InitializeComponent();
            uC_Order2.BringToFront();
        }

        private void FrmBeverageCP_Load(object sender, EventArgs e)
        {
            PhanQuyen();
        }
        private void moveImage(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imageSlide.Location = new Point(b.Location.X + 150, b.Location.Y - 31);
            imageSlide.SendToBack();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGoiDoUong_Click(object sender, EventArgs e)
        {
            moveImage(sender);
            if (btnGoiDoUong.Checked)
                uC_Order2.BringToFront();
            if (btnNhanVien.Checked)
                uC_employee1.BringToFront();
            if (btnKhachHang.Checked)
                uC_Customer1.BringToFront();
            if (btnNhapNL.Checked)
                uC_Input_Ingredient1.BringToFront();
            if (btnVoucher.Checked)
                uC_Voucher1.BringToFront();
            if (btnThongKe.Checked)
                uC_Statistic1.BringToFront();
            if (btHoaDon.Checked)
            {
                uC_Bill1.BringToFront();
                uC_Bill1.UC_Bill_Load(this, new EventArgs());
            }
        }

        private void Employee_permission()
        {

        }

        private void PhanQuyen()
        {
            if (session == 1)
            {
                if(int.Parse(dn.vaitro) == 1)
                {
                    btnKhachHang.Enabled = true;
                    btnNhanVien.Enabled = true;
                    btnNhapNL.Enabled = true;
                    btnThongKe.Enabled = true;
                    btnVoucher.Enabled = true;
                    btHoaDon.Enabled = true;
                    btnGoiDoUong.Enabled = true;
                }
                else
                {
                    btnKhachHang.Enabled = false;
                    btnNhanVien.Enabled = false;
                    btnNhapNL.Enabled = false;
                    btnThongKe.Enabled = false;
                    btnVoucher.Enabled = false;
                    btHoaDon.Enabled = false;
                    btnGoiDoUong.Enabled = true;
                }
            }
            else
            {
                btnGoiDoUong.Enabled = false;
                btnKhachHang.Enabled = false;
                btnNhanVien.Enabled = false;
                btnNhapNL.Enabled = false;
                btnThongKe.Enabled = false;
                btnVoucher.Enabled = false;
                btHoaDon.Enabled = false;
            }
        }
    }
}
