using BUS_QuanLy;
using DTO_QuanLy;
using Guna.UI2.WinForms;
using RJCodeAdvance.ControlBeverages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance.ControlIngredient
{
    public partial class UC_Input_Ingredient : UserControl
    {
        public UC_Input_Ingredient()
        {
            InitializeComponent();
        }
        BUS_InputIngredients input = new BUS_InputIngredients();
        BUS_NguyenLieu BUS_NguyenLieu = new BUS_NguyenLieu();
        DateTime today = DateTime.Now;
        List<DTO_NguyenLieu> ListNl;
        public void UC_Input_Ingredient_Load(object sender, EventArgs e)
        {
            ListNl = BUS_NguyenLieu.getListIngredient();
            RenderBeverage(ListNl);
            nbSoLuong.Enabled = false;
        }
        void RenderBeverage(List<DTO_NguyenLieu> nl)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (DTO_NguyenLieu item in nl)
            {
                UC_IngeredientItem ingredients = new UC_IngeredientItem();

                ingredients.IngredientName = item.Name;
                ingredients.IngredientNPrice = item.Price.ToString() + "vnđ";

                if (File.Exists(Application.StartupPath + "\\" + item.Images))
                {
                    ingredients.IngredientNImage = Image.FromFile(Application.StartupPath + "\\" + item.Images);
                }
                else
                {
                    ingredients.IngredientNImage = default;
                }

                ingredients.btThem.Tag = item;
                ingredients.btThem.Click += BtThem_Click;
                flowLayoutPanel1.Controls.Add(ingredients);
            }

            UC_ItemIngredientAdd b = new UC_ItemIngredientAdd(this);
            flowLayoutPanel1.Controls.Add(b);
        }
        DataTable a = new DataTable();

        private void BtThem_Click(object sender, EventArgs e)
        {
            DTO_NguyenLieu Ingredients = (DTO_NguyenLieu)(sender as Guna2Button).Tag;
            FrmAddIngredient frm = new FrmAddIngredient(Ingredients,this);
            frm.ShowDialog();
            for(int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
            {
                string tmp = guna2DataGridView1.Rows[i].Cells[0].Value.ToString();
                for (int j = guna2DataGridView1.Rows.Count - 1; j > i; j--)
                {
                    if (guna2DataGridView1.Rows[j].IsNewRow) continue;
                    if (tmp == guna2DataGridView1.Rows[j].Cells[0].Value.ToString())
                    {
                        guna2DataGridView1.Rows[i].Cells[1].Value = (int.Parse(guna2DataGridView1.Rows[i].Cells[1].Value.ToString()) + int.Parse(guna2DataGridView1.Rows[j].Cells[1].Value.ToString()));
                        guna2DataGridView1.Rows[i].Cells[3].Value = (int.Parse(guna2DataGridView1.Rows[i].Cells[3].Value.ToString()) + int.Parse(guna2DataGridView1.Rows[j].Cells[3].Value.ToString()));
                        guna2DataGridView1.Rows.RemoveAt(j);
                    }
                }
            }
            int money = 0;
            
            for(int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
            {
                money += int.Parse(guna2DataGridView1.Rows[i].Cells[3].Value.ToString());
                txtTongTien.Text = " " + money;
            }
        }
        BUS_InputBills bill = new BUS_InputBills();
        public static string mail = "tungdz0001@gmail.com";
        private void UC_Input_Ingredient_Click(object sender, EventArgs e)
        {
        }
        //click datagridview
        int rows;
        int donGia;
        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            btSua.Enabled = true;
            nbSoLuong.Enabled = true;
            if (guna2DataGridView1.Rows.Count > 0)
            {
                rows = guna2DataGridView1.CurrentRow.Index;
                txtName.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                nbSoLuong.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtThanhTien.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
                rows = guna2DataGridView1.CurrentRow.Index;
                donGia = int.Parse(guna2DataGridView1.CurrentRow.Cells[3].Value.ToString()) / int.Parse(guna2DataGridView1.CurrentRow.Cells[1].Value.ToString());
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.RemoveAt(rows);
            int money = 0;

            for (int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
            {
                money += int.Parse(guna2DataGridView1.Rows[i].Cells[3].Value.ToString());
                txtTongTien.Text = " " + money;
            }
            txtName.Text = null;
            txtThanhTien.Text = null;
            nbSoLuong.Text = "" + 0;
        }

        private void btThanhToan_Click_1(object sender, EventArgs e)
        {
            string time = today.ToString("yyyy-MM-dd hh:mm:ss.fff");
            if (guna2DataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Không có mặc hàng nào cần thanh toán");
            }
            else
            {
                // tạo insert vào inputBill
                DTO_InputBills dTO_InputBills = new DTO_InputBills(time, mail, float.Parse(txtTongTien.Text));
                if (bill.insertBillIngredient(dTO_InputBills))
                {
                    //vằng lặp lấy giá trị trong datagridview để insert vào inputBillsDetails
                    for (int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
                    {
                        string nameType = guna2DataGridView1.Rows[i].Cells[0].Value.ToString();
                        string soLuong = guna2DataGridView1.Rows[i].Cells[1].Value.ToString();
                        DTO_InputIngredients dTO_InputIngredients = new DTO_InputIngredients(soLuong, nameType, time);
                        if (input.insertBillDetailIngredient(dTO_InputIngredients))
                        {
                        }
                    }
                    // để t push lên, rồi m pull về có bị lỗi ghi đè dall ko
                    guna2DataGridView1.Rows.Clear();
                    txtName.Text = null;
                    txtThanhTien.Text = "" + 0;
                    txtTongTien.Text = "" + 0;
                    nbSoLuong.Text = "" + 0;
                }
                else
                {
                    MessageBox.Show("Thao tác chậm lại :)))");
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows[rows].Cells[1].Value = int.Parse(nbSoLuong.Value.ToString());
            guna2DataGridView1.Rows[rows].Cells[3].Value = int.Parse(nbSoLuong.Value.ToString())*donGia;
            int money = 0;

            for (int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
            {
                money += int.Parse(guna2DataGridView1.Rows[i].Cells[3].Value.ToString());
                txtTongTien.Text = " " + money;
            }
            txtName.Text = null;
            txtThanhTien.Text = null;
            nbSoLuong.Text = ""+0;
        }
    }
}
