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
        public FrmBeverageCP()
        {
            InitializeComponent();
            uC_Order1.BringToFront();
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

        private void btnGoiDoUong_Click_1(object sender, EventArgs e)
        {
            moveImage(sender);
            if (btnDoUong.Checked) 
                uC_Beverages21.BringToFront();
            if (btnGoiDoUong.Checked) 
                uC_Order1.BringToFront();
            if (btnNhanVien.Checked) 
                uC_employee1.BringToFront();
            if (btnKhachHang.Checked)
                uC_Customer1.BringToFront();
            if (btnNhapNL.Checked)
                uC_Input_Ingredient1.BringToFront();
            if (btnNguyenLieu.Checked)
                uC_ingredient1.BringToFront();
            if (btnVoucher.Checked)
                uC_Voucher1.BringToFront();
            if (btnThongKe.Checked) 
                uC_Statistic1.BringToFront();
        }
    }
}
