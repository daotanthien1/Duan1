using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance.ControlIngredient
{
    public partial class UC_ingredient : UserControl
    {
        public UC_ingredient()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FrmIngredientType frm = new FrmIngredientType();
            frm.ShowDialog(); 
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FrmSupplier frm = new FrmSupplier();
            frm.ShowDialog();
        }
    }
}
