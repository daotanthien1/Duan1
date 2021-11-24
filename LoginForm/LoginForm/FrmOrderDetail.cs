using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;
using Guna.UI2.WinForms;
using RJCodeAdvance.ControlBeverages;

namespace RJCodeAdvance
{
    public partial class FrmOrderDetail : Form
    {
        public int Id_table;
        public int Id_Empoyee;
        BUS_Beverage bus_beverage = new BUS_Beverage();
        public FrmOrderDetail(int id_table, int id_employee)
        {
            InitializeComponent();
            Id_table = id_table;
            Id_Empoyee = id_employee;
        }

        private void beverageItem22_Load(object sender, EventArgs e)
        {

        }

        private void FrmOrderDetail_Load(object sender, EventArgs e)
        {
            List<DTO_QuanLyDoUong> listBeverage = bus_beverage.listBeverage();

            foreach(DTO_QuanLyDoUong item in listBeverage)
            {
                UC_ItemBeverage beverage = new UC_ItemBeverage();
            
                beverage.BeverageId = item.Id_Beverage;
                beverage.BeverageName = item.Name;
                beverage.BeveragePrice = item.Price.ToString() + "đ";
                beverage.BeverageImage = Image.FromFile(Application.StartupPath + "\\" + item.Image);

                beverage.btThem.Tag = item;
                beverage.btThem.Click += BtThem_Click;
                flowLayoutPanel1.Controls.Add(beverage);
            }

            UC_ItemBeverageAdd beverageAdd = new UC_ItemBeverageAdd();
            flowLayoutPanel1.Controls.Add(beverageAdd);
        }

        private void BtThem_Click(object sender, EventArgs e)
        {
            DTO_QuanLyDoUong beverage = (DTO_QuanLyDoUong)(sender as Guna2Button).Tag;
            
            FrmAddBeverage frm = new FrmAddBeverage(Id_table, beverage, Id_Empoyee);
            frm.ShowDialog();
        }
    }
}
