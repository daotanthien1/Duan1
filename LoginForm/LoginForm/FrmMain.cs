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
        public FrmBeverageCP()
        {
            InitializeComponent();
            uC_Order2.BringToFront();
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
        }
        BUS_Vouchers vouchers = new BUS_Vouchers();
        BUS_Customer customer = new BUS_Customer();
        void sendVoucher()
        {
            //if (Properties.Settings.Default.rewards == "")
            //{
            //    Properties.Settings.Default.rewards = "9999";
            //}
            //if (Properties.Settings.Default.voucherType == "")
            //{
            //    Properties.Settings.Default.voucherType = "3";
            //}
            DataTable dt = vouchers.getEmailSendVoucher(int.Parse(Properties.Settings.Default.rewards.ToString()));
            int row = 0;
            string id_voucher;
            string email;
            //DataTable voucher = vouchers.getVoucherSendMail(int.Parse(Properties.Settings.Default.voucherType.ToString()));
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                //dataGridView2.DataSource = voucher;
                do
                {
                    email = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    id_voucher = dataGridView2.Rows[row].Cells[0].Value.ToString();
                    DTO_Vouchers dto = new DTO_Vouchers(id_voucher);
                    DTO_Customer DTO = new DTO_Customer(email);
                    string subject = "Bạn đã nhận được voucher khuyến mãi " + FrmConfigurationSale.Sale + "% của shop META <3";
                    string body = $"Vocher:{id_voucher}";
                    if (BUS_SendGmail.SendMail(email, subject, body))
                    {
                        //vouchers.UpdateVoucherForSend(dto);
                        customer.UpdateCustomerAfterSendVoucher(DTO);
                        row += 1;
                    }
                } while (row == dt.Rows.Count - 1);
            }
        }
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            sendVoucher();
        }

        private void uC_Beverages21_Load(object sender, EventArgs e)
        {

        }
    }
}
