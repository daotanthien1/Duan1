using BUS_QuanLy;
using DTO_QuanLy;
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

namespace RJCodeAdvance.ControlBeverages
{
    public partial class UC_Order : UserControl
    {
        BUS_tables bus_table = new BUS_tables();
        public UC_Order()
        {
            InitializeComponent();
        }

        private void LoadTable()
        {
            List<DTO_tables> tableList = bus_table.getTableList();


            foreach(DTO_tables table in tableList)
            {
                Guna2Button btn = new Guna2Button();
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
    }
}
