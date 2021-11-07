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
    public partial class FrmIngredient : Form
    {
        public FrmIngredient()
        {
            InitializeComponent();
        }
        private void moveImage(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imageSlide.Location = new Point(b.Location.X + 149, b.Location.Y - 31);
            imageSlide.SendToBack();
        }
        private void bt1_CheckedChanged(object sender, EventArgs e)
        {
            moveImage(sender);
            if (bt1.Checked)
            {
                uC_Input_Ingredient1.BringToFront();
            }
            if (bt2.Checked)
            {
                uC_ingredient1.BringToFront();
            }
            if (bt3.Checked)
            {
                uC_typeOfIngredient1.BringToFront();
            }
            if (bt4.Checked)
            {
                uC_Unit1.BringToFront();
            }
            if (bt5.Checked)
            {
                uC_Supplier1.BringToFront();
            }
        }
    }
}
