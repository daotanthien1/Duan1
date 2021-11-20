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
        public static int sale = 0;
        BUS_tables bus_table = new BUS_tables();
        BUS_Bill_Detail bus_bill_detail = new BUS_Bill_Detail();
        BUS_Bill bus_bill = new BUS_Bill();
        BUS_Menu bus_menu = new BUS_Menu();
        BUS_TypesOfBeverage bus_beverageType = new BUS_TypesOfBeverage();
        BUS_Beverage bus_beverage = new BUS_Beverage();
        BUS_Customer bus_customer = new BUS_Customer();
        BUS_Vouchers bus_voucher = new BUS_Vouchers();

        public UC_Order()
        {
            InitializeComponent();
            loadBeverageType();
            loadCbTable(cbChuyenBan);
            suggestEmail();
            nbSoLuong.Maximum = 99;
            nbSoLuong.Minimum = -99;
            nbDiem.Maximum = 999999;
        }

        void suggestEmail()
        {
            txbEmail.AutoCompleteMode = AutoCompleteMode.Append;
            txbEmail.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbEmail.AutoCompleteCustomSource = bus_customer.autoEmail();
        }
        void TurnOffInputControl()
        {
            btnThem.Enabled = false;
            btThanhToan.Enabled = false;
            btChuyenBan.Enabled = false;
            btChuyenBan.Enabled = false;
            btNhap.Enabled = false;
        }

        void TurnOnInputControl()
        {
            btnThem.Enabled = true;
            btThanhToan.Enabled = true;
            btChuyenBan.Enabled = true;
            btChuyenBan.Enabled = true;
            btNhap.Enabled = true;
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
            txbVoucher.Text = "";
            txbVoucher.Enabled = true;
            sale = 0;
            TurnOnInputControl();
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

        private void UC_Order_Load(object sender, EventArgs e)
        {
            LoadTable();
            TurnOffInputControl();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_tables table = dgv.Tag as DTO_tables;

            int idbill = bus_bill.GetUncheckBill(table.Id);
            if(txbVoucher.Text.Length == 6 && sale == 0)
            {
                if(MessageBox.Show("bạn chưa xác nhận voucher, vẫn muốn tiếp tục thêm đồ uống?",
                    "thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            if (idbill == -1)
            {
                bus_bill.InsertBill(table.Id, idEmployee);
                DTO_Bill_Detail billDetail = new DTO_Bill_Detail();
                billDetail.ID_Bill = bus_bill.getMaxId();
                billDetail.Id_Beverage = (cbBeverage.SelectedItem as DTO_QuanLyDoUong).Id_Beverage;
                billDetail.Quantity = (int)nbSoLuong.Value;
                billDetail.sale = sale;
                bus_bill_detail.InsertBillDetail(billDetail);
            }
            else
            {
                DTO_Bill_Detail billDetail = new DTO_Bill_Detail();
                billDetail.ID_Bill = idbill;
                billDetail.Id_Beverage = (cbBeverage.SelectedItem as DTO_QuanLyDoUong).Id_Beverage;
                billDetail.Quantity = (int)nbSoLuong.Value;
                billDetail.sale = sale;
                bus_bill_detail.InsertBillDetail(billDetail);
            }

            ShowBill(table.Id);
            LoadStatusTable(table.Id);
            if(sale != 0)
            {
                bus_voucher.deleteVoucher(txbVoucher.Text);
                sale = 0;
                txbVoucher.Text = "";
                nbSoLuong.Maximum = 99;
            }
            txbVoucher.Enabled = true;
        }

        private void cbBeverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            nbSoLuong.Value = 1;
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            DTO_tables table = dgv.Tag as DTO_tables;

            int idBill = bus_bill.GetUncheckBill(table.Id);

            // them khach hang
            if (!String.IsNullOrEmpty(txbEmail.Text))
            {
                int idcustomer = bus_customer.getIdCustomer(txbEmail.Text);

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
                    double point = bus_bill.getTotalPriceBill(idBill);
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
                            DTO_Vouchers voucher = bus_voucher.getVoucherSendMail(id_voucherType);
                            if(voucher !=null)
                            {
                                string subject = "Bạn đã nhận được voucher khuyến mãi " + Name_voucherType + "% của shop META <3";
                                string body = $"Mã voucher của bạn là:{voucher.id_vouchers} dùng đến ngày {voucher.dayend}";
                                if (BUS_SendGmail.SendMail(txbEmail.Text, subject, body))
                                {
                                    bus_voucher.UpdateVoucherForSend(voucher.id_vouchers);
                                    bus_customer.ChangeReward(idcustomer, -rewardRequest);
                                }
                            }
                            else
                            {
                                MessageBox.Show("đã hết voucher");
                                Properties.Settings.Default.TurnOnSale = false;
                            }
                        }
                    }
                    if (sale != 0)
                    {
                        sale = 0;
                        txbVoucher.Text = "";
                        nbSoLuong.Maximum = 99;
                        txbVoucher.Enabled = true;
                    }
                    txbEmail.Text = "";
                    resetControlCustomer();
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

        private void beverageType_selectIndexChange(object sender, EventArgs e)
        {
            int id = 0;
            Guna2ComboBox cb = sender as Guna2ComboBox;
            if (cb.SelectedItem == null)
                return;
            DTO_TypesOfBeverage selected = cb.SelectedItem as DTO_TypesOfBeverage;
            id = selected.ID_Type;
            loadBeverage(id);
        }

        private void btNhap_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txbVoucher.Text))
            {
                int typeVoucher = bus_voucher.getTypeVoucherById(txbVoucher.Text);
                if (typeVoucher == -1)
                {
                    MessageBox.Show("voucher này đã hết hạn");
                    txbVoucher.Text = "";
                }else if(typeVoucher == 0)
                {
                    MessageBox.Show("Voucher sai vui lòng kiểm tra lại");
                    txbVoucher.Text = "";
                } else
                {
                    MessageBox.Show($"giảm giá {typeVoucher}% đã được áp dụng");
                    txbVoucher.Enabled = false;
                    sale = typeVoucher;
                    nbSoLuong.Value = 1;
                    nbSoLuong.Maximum = 1;
                }
            }
        }

        void loadCbTable(Guna2ComboBox cb)
        {
            cb.DataSource = bus_table.getTableList();
            cb.DisplayMember = "name";
            //cb.ValueMember = "Id_table";
        }

        private void pbChangePass_Click_1(object sender, EventArgs e)
        {
            FrmChangePassword Frm = new FrmChangePassword();
            Frm.ShowDialog();
        }

        private void btChuyenBan_Click(object sender, EventArgs e)
        {
            int idTable1 = (dgv.Tag as DTO_tables).Id;
            int idTable2 = (cbChuyenBan.SelectedItem as DTO_tables).Id;

            bus_table.SwitchTable(idTable1, idTable2, idEmployee);
            LoadStatusTable(idTable1);
            LoadStatusTable(idTable2);
            ShowBill(idTable1);
        }
    }
}
