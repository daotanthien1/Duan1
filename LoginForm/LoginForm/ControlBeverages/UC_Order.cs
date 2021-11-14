using BUS_QuanLy;
using DTO_QuanLy;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance.ControlBeverages
{
    public partial class UC_Order : UserControl
    {
        BUS_tables bus_table = new BUS_tables();
        BUS_Bill_Detail bus_bill_detail = new BUS_Bill_Detail();
        BUS_Bill bus_bill = new BUS_Bill();
        BUS_Menu bus_menu = new BUS_Menu();
        BUS_TypesOfBeverage bus_beverageType = new BUS_TypesOfBeverage();
        BUS_Beverage bus_beverage = new BUS_Beverage();
        public UC_Order()
        {
            InitializeComponent();
            loadBeverageType();
        }

        void loadBeverageType()
        {
            List<DTO_TypesOfBeverage> listType = bus_beverageType.listBeverageType();
            cbType.DataSource = listType;
            cbType.DisplayMember = "Name";
        }

        void loadBeverage(int id)
        {
            List<DTO_QuanLyDoUong> listBeverage = bus_beverage.listBeverageType(id);
            cbBeverage.DataSource = listBeverage;
            cbBeverage.DisplayMember = "Name";
        }

        private void LoadTable()
        {
            List<DTO_tables> tableList = bus_table.getTableList();

            foreach(DTO_tables table in tableList)
            {
                Guna2Button btn = new Guna2Button();
                btn.Click += Btn_Click;
                btn.Tag = table;
                btn.BorderRadius = 3;               
                btn.Size = new System.Drawing.Size(70, 70);
                btn.Text = table.Name + Environment.NewLine + table.status;
                if(table.status == "Có người")
                {
                    btn.FillColor = Color.BlueViolet;
                }
                flpTables.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            dgv.DataSource = bus_menu.getListMenu(id);
            dgv.Columns[0].HeaderText = "Đồ uống";
            dgv.Columns[1].HeaderText = "Số lượng";
            dgv.Columns[2].HeaderText = "Giá";
            dgv.Columns[3].HeaderText = "Thành tiền";

            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            txbTongTien.Text = bus_bill.getSumPrice(id).ToString("c");
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Guna2Button).Tag as DTO_tables).Id;
            ShowBill(tableId);
            dgv.Tag = (sender as Guna2Button).Tag;
        }

        private void pbSetting_Click(object sender, EventArgs e)
        {
            FrmConfigurationSale frm = new FrmConfigurationSale();
            frm.ShowDialog();
        }

        private void pbScheme_Click(object sender, EventArgs e)
        {
            FrmSchedule Frm = new FrmSchedule();
            Frm.ShowDialog();
        }

        private void pbChangePass_Click(object sender, EventArgs e)
        {
            FrmChangePassword Frm = new FrmChangePassword();
            Frm.ShowDialog();
        }

        private void UC_Order_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            Guna2ComboBox cb = sender as Guna2ComboBox;
            if (cb.SelectedItem == null)
                return;
            DTO_TypesOfBeverage selected = cb.SelectedItem as DTO_TypesOfBeverage;
            id = selected.ID_Type;
            loadBeverage(id);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
