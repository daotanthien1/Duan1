using RJCodeAdvance.ControlIngredient;
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
    public partial class UC_ItemIngredientAdd : UserControl
    {
        public int BeverageId;
        public UC_ItemIngredientAdd()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            ShowFrmIngredient();
        }

        private void UC_ItemIngredientAdd_Click(object sender, EventArgs e)
        {
            ShowFrmIngredient();
        }
        void ShowFrmIngredient()
        {
            UC_ingredient frm = new UC_ingredient();
            frm.ShowDialog();
            // load loại danh sách nguyên liệu
        }
    }
}
