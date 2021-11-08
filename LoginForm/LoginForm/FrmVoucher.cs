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
    public partial class FrmVoucher : Form
    {
        public FrmVoucher()
        {
            InitializeComponent();
        }
        private void moveImage(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imageSlide.Location = new Point(b.Location.X + 150, b.Location.Y - 31);
            imageSlide.SendToBack();
        }
        private void bt1_CheckedChanged(object sender, EventArgs e)
        {
            moveImage(sender);
            if (bt1.Checked)
            {
                uC_Voucher1.BringToFront();
            }
            if (bt2.Checked)
            {
                uC_TypeOfVoucher1.BringToFront();
            }
            if (bt3.Checked)
            {
                uC_sale1.BringToFront();
            }
        }

        private void FrmVoucher_Load(object sender, EventArgs e)
        {

        }
    }
}
