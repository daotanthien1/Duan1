using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance.ControlBeverages
{
    public partial class UC_Beverages2 : UserControl
    {
        public UC_Beverages2()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FrmTypeOfBeverage2 frm = new FrmTypeOfBeverage2();
            frm.ShowDialog();
        }
    }
}
