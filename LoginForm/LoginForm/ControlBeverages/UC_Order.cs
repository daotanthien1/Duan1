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
        BUS_Bill bus_bill = new BUS_Bill();
        BUS_Menu bus_menu = new BUS_Menu();
        BUS_Customer bus_customer = new BUS_Customer();

        public UC_Order()
        {
            InitializeComponent();
            loadCbTable(cbChuyenBan);
            suggestEmail();
        }

        void suggestEmail()
        {
            txbEmail.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txbEmail.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txbEmail.AutoCompleteCustomSource = bus_customer.autoEmail();
        }
        void TurnOffInputControl()
        {
            btThem.Enabled = false;
            btXoa.Enabled = false;
            btSua.Enabled = false;
            btThanhToan.Enabled = false;
            btChuyenBan.Enabled = false;
            btnGop.Enabled = false;
            txbDoUong.Enabled = false;
            txbEmail.Enabled = false;
            nbSoLuong.Enabled = false;
            cbChuyenBan.Enabled = false;
            cbGopBan.Enabled = false;
        }

        void TurnOnInputControl()
        {
            btThem.Enabled = true;
            btThanhToan.Enabled = true;
            btChuyenBan.Enabled = true;
            btnGop.Enabled = true;
            txbEmail.Enabled = true;
            cbChuyenBan.Enabled = true;
            cbGopBan.Enabled = true;
        }

        // load lại 1 bàn
        private void LoadStatusTable(int idTable)
        {
            DTO_tables table = bus_table.getTable(idTable);

            for (int i = 0; i < flpTables.Controls.Count - 1; i++)
            {
                Guna2Button btn = flpTables.Controls[i] as Guna2Button;
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
              
                btn.Size = new System.Drawing.Size(80, 80);
                btn.Text = table.Name + Environment.NewLine + table.status;
                if(table.status == "Có người")
                {
                    btn.FillColor = Color.BlueViolet;
                }
                flpTables.Controls.Add(btn);
            }

            Guna2PictureBox ptb = new Guna2PictureBox();
            ptb.Image = Image.FromFile(Application.StartupPath + @"\icons\add_100px.png");
            ptb.Size = new System.Drawing.Size(80, 80);
            ptb.SizeMode = PictureBoxSizeMode.Zoom;
            ptb.Click += Ptb_Click;
            flpTables.Controls.Add(ptb);
        }

        private void Ptb_Click(object sender, EventArgs e)
        {
            FrmTable frm = new FrmTable();
            frm.ShowDialog();
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
            txbTongThanhTien.Text = bus_bill.getSumPrice(id).ToString("c");

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            TurnOnInputControl();
            int tableId = ((sender as Guna2Button).Tag as DTO_tables).Id;
            ShowBill(tableId);
            dgv.Tag = (sender as Guna2Button).Tag;

            for(int i = 0; i < flpTables.Controls.Count - 1;i++)
            {
                Guna2Button btn = flpTables.Controls[i] as Guna2Button;
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
                    FrmAddCustomer frm = new FrmAddCustomer(txbEmail.Text);
                    frm.ShowDialog();
                    return;
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
                    txbEmail.Text = "";
                }
            }

            if (idBill != -1)
            {
                bus_bill.CheckOut(idBill);
                ShowBill(table.Id);
            }
            LoadStatusTable(table.Id);
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

        private void btThem_Click(object sender, EventArgs e)
        {
            int idTable = (dgv.Tag as DTO_tables).Id;
            FrmOrderDetail frm = new FrmOrderDetail(idTable, idEmployee);
            frm.ShowDialog();
            ShowBill(idTable);
            LoadStatusTable(idTable);
        }

        private void txbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txbEmail.Text))
                {
                    if (IsValidEmail.ValidEmail(txbEmail.Text))
                    {
                        DTO_Customer cus = bus_customer.FindCustomerByEmail(txbEmail.Text);
                        if (cus != null)
                        {
                            
                        }
                        else
                        {
                            FrmAddCustomer frm = new FrmAddCustomer(txbEmail.Text);
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }
    }
}
