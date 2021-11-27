using BUS_QuanLy;
using DTO_QuanLy;
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

namespace RJCodeAdvance
{
    public partial class FrmAddIngredient : Form
    {
        DTO_NguyenLieu ingredients;
        UC_Input_Ingredient a;
        public FrmAddIngredient(DTO_NguyenLieu ingredient, UC_Input_Ingredient A)
        {
            InitializeComponent();
            ingredients = ingredient;
            this.a = A;
        }

        private void FrmAddIngredient_Load(object sender, EventArgs e)
        {
            lblBeverageName.Text = ingredients.Name;
            lblPrice.Text = ingredients.Price + "đ";
            ptbImg.Image = Image.FromFile(Application.StartupPath + "\\" + ingredients.Images);
            txbTongTien.Text = ingredients.Price.ToString();
            dt.Columns.Add("Nguyên liệu", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Giá", typeof(string));
            dt.Columns.Add("Thành tiền", typeof(int));
        }

        private void nbSoLuong_ValueChanged(object sender, EventArgs e)
        {
            txbTongTien.Text = (ingredients.Price * int.Parse(nbSoLuong.Value.ToString())).ToString();
        }
        public DataTable dt = new DataTable();
        private void btnThem_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt.Rows.Add(lblBeverageName.Text, int.Parse(nbSoLuong.Value.ToString()), lblPrice.Text, int.Parse(txbTongTien.Text));
            foreach (DataRow item in dt.Rows)
            {
                a.guna2DataGridView1.Rows.Add(item[0].ToString(), int.Parse(item[1].ToString()), item[2].ToString(), int.Parse(item[3].ToString()));
            }
            this.Close();
        }
    }
}
