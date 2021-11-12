using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance.ControlCustomers
{
    public partial class UC_Customer : UserControl
    {
        public UC_Customer()
        {
            InitializeComponent();
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FrmTable frm = new FrmTable();
            frm.ShowDialog();
        }
    }
}
