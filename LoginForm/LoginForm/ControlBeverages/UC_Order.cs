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
        public static int idEmployee = 1;
        BUS_tables bus_table = new BUS_tables();
        BUS_Bill_Detail bus_bill_detail = new BUS_Bill_Detail();
        BUS_Bill bus_bill = new BUS_Bill();
        BUS_Menu bus_menu = new BUS_Menu();
        BUS_TypesOfBeverage bus_beverageType = new BUS_TypesOfBeverage();
        BUS_Beverage bus_beverage = new BUS_Beverage();
        BUS_Customer bus_customer = new BUS_Customer();

        public UC_Order()
        {
            InitializeComponent();
            loadBeverageType();
            nbSoLuong.Maximum = 99;
            nbSoLuong.Minimum = -99;
            nbDiem.Maximum = 999999;
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
        
        // load lại 1 bàn
        private void LoadStatusTable(int idTable)
        {
            DTO_tables table = bus_table.getTable(idTable);

            foreach(Guna2Button btn in flpTables.Controls)
            {
                DTO_tables btn_table = btn.Tag as DTO_tables;
                if(table.Id == btn_table.Id)
                {
                    btn.Text = table.Name + Environment.NewLine + table.status;
                    if (table.status == "Có người")
                    {
                        btn.FillColor = Color.BlueViolet;
                    }
                    else
                    {
                        btn.FillColor = Color.FromArgb(94, 148, 255);
                    }
                          
                }
            }
        }

        private void LoadTable()
        {
            flpTables.Controls.Clear();
            List<DTO_tables> tableList = bus_table.getTableList();

            foreach(DTO_tables table in tableList)
            {
                Guna2Button btn = new Guna2Button();
                btn.Click += Btn_Click;
                btn.Tag = table;
                btn.BorderRadius = 3;               
                
                btn.Size = new System.Drawing.Size(75, 75);
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
            dgv.Columns[4].HeaderText = "Giảm giá";

            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            txbTongTien.Text = bus_bill.getSumPrice(id).ToString("c");

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Guna2Button).Tag as DTO_tables).Id;
            ShowBill(tableId);
            dgv.Tag = (sender as Guna2Button).Tag;

            foreach(Guna2Button btn in flpTables.Controls)
            {
                btn.Checked = false;
            }

            (sender as Guna2Button).Checked = true;
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
            DTO_tables table = dgv.Tag as DTO_tables;

            int idbill = bus_bill.GetUncheckBill(table.Id);

            if (idbill == -1)
            {
                bus_bill.InsertBill(table.Id, idEmployee);
                DTO_Bill_Detail billDetail = new DTO_Bill_Detail();
                billDetail.ID_Bill = bus_bill.getMaxId();
                billDetail.Id_Beverage = (cbBeverage.SelectedItem as DTO_QuanLyDoUong).Id_Beverage;
                billDetail.Quantity = (int)nbSoLuong.Value;
                billDetail.sale = 0;
                bus_bill_detail.InsertBillDetail(billDetail);
            }
            else
            {
                DTO_Bill_Detail billDetail = new DTO_Bill_Detail();
                billDetail.ID_Bill = idbill;
                billDetail.Id_Beverage = (cbBeverage.SelectedItem as DTO_QuanLyDoUong).Id_Beverage;
                billDetail.Quantity = (int)nbSoLuong.Value;
                billDetail.sale = 0;
                bus_bill_detail.InsertBillDetail(billDetail);
            }

            ShowBill(table.Id);
            LoadStatusTable(table.Id);
        }

        private void cbBeverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            nbSoLuong.Value = 1;
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            DTO_tables table = dgv.Tag as DTO_tables;

            int idBill = bus_bill.GetUncheckBill(table.Id);
            int idcustomer = bus_customer.getIdCustomer(txbEmail.Text);

            // them khach hang
            if (!String.IsNullOrEmpty(txbEmail.Text))
            {
                if (String.IsNullOrEmpty(txbName.Text))
                {
                    MessageBox.Show("Chưa nhập đủ thông tin");
                    return;
                }
                else
                {
                    if (idcustomer == 0)
                    {
                        string gender = "Nam";
                        if (rdNu.Checked)
                            gender = "Nữ";
                        DTO_Customer cus = new DTO_Customer(txbName.Text, txbEmail.Text, gender);
                        bus_customer.CreateCustomer(cus);
                        idcustomer = bus_customer.getMaxIdCustomer();
                    }

                    if(idBill != -1)
                    {
                        bus_bill.addCustomer(idcustomer, idBill);
                        long point = bus_bill.getTotalPriceBill(idBill);
                        point /= 1000;
                        bus_customer.ChangeReward(idcustomer, (int)point);

                        if(Properties.Settings.Default.TurnOnSale)
                        {
                            int reward = bus_customer.getRewardCustomer(idcustomer);
                            int rewardRequest = Properties.Settings.Default.rewards;
                            int id_voucherType = Properties.Settings.Default.voucherType;
                            int Name_voucherType = Properties.Settings.Default.voucheTypeName;
                            if (reward >= rewardRequest)
                            {
                                BUS_Vouchers bus_voucher = new BUS_Vouchers();
                                string ma_voucher = bus_voucher.getVoucherSendMail(id_voucherType);
                                if(ma_voucher!=null)
                                {
                                    string subject = "Bạn đã nhận được voucher khuyến mãi " + Name_voucherType + "% của shop META <3";
                                    string body = $"Vocher:{ma_voucher}";
                                    if (BUS_SendGmail.SendMail(txbEmail.Text, subject, body))
                                    {
                                        bus_voucher.UpdateVoucherForSend(ma_voucher);
                                        bus_customer.ChangeReward(idcustomer, -rewardRequest);
                                    }
                                }
                            }
                        }
                        txbEmail.Text = "";
                        resetControlCustomer();
                    }
                }
            }

            if (idBill != -1)
            {
                bus_bill.CheckOut(idBill);
                ShowBill(table.Id);
            }
            LoadStatusTable(table.Id);
        }

        private void txbEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if(!String.IsNullOrEmpty(txbEmail.Text))
            {
                if(IsValidEmail.ValidEmail(txbEmail.Text))
                {
                    DTO_Customer cus = bus_customer.FindCustomerByEmail(txbEmail.Text);
                    if(cus!=null)
                    {
                        txbName.Text = cus.Name;
                        if (cus.Gender == "Nữ")
                            rdNu.Checked = true;
                        else
                            rdNam.Checked = true;
                        nbDiem.Value = cus.Reward;

                        rdNam.Enabled = false;
                        rdNu.Enabled = false;
                        txbName.Enabled = false;
                    }
                    else
                    {
                        resetControlCustomer();
                    }
                }
                else
                {
                    resetControlCustomer();
                }
            }
            else
            {
                resetControlCustomer();
            }
        }

        void resetControlCustomer()
        {
            rdNu.Checked = true;
            txbName.Text = "";
            nbDiem.Value = 0;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
            txbName.Enabled = true;
        }
    }
}
