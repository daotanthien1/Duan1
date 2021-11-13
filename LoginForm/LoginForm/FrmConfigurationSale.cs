using BUS_QuanLy;
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
    public partial class FrmConfigurationSale : Form
    {
        public FrmConfigurationSale()
        {
            InitializeComponent();
        }
        BUS_Vouchers vouchers = new BUS_Vouchers();
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                Properties.Settings.Default.rewards = txtLuong.Text;
                Properties.Settings.Default.vouchers = cbSale.SelectedValue.ToString();
                Properties.Settings.Default.Save();
                MessageBox.Show("Kích hoạt thành công\nĐiểm tích lũy: " + Properties.Settings.Default.rewards.ToString() + "\nNhận voucher : " + cbSale.Text);
            }
            else
            {
                Properties.Settings.Default.rewards = "99999";
                Properties.Settings.Default.vouchers = "0";
                Properties.Settings.Default.Save();
                MessageBox.Show("Bỏ kích hoạt điểm voucher");
            }
        }
        public static string Sale;
        private void FrmConfigurationSale_Load(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                txtLuong.Text = Properties.Settings.Default.rewards.ToString();
                cbSale.Text = Properties.Settings.Default.vouchers.ToString();
                loadData();
                loadSale();
            }
            else
            {
                txtLuong.Text = "";
                cbSale.ResetText();
            }
            
            Sale = cbSale.Text;
        }
        void loadData()
        {
            cbSale.DataSource = vouchers.getSale();
            cbSale.DisplayMember = "Sale";
            cbSale.ValueMember = "ID_Type";
        }
        void loadSale()
        {
            cbSale.DisplayMember = "Sale";
            cbSale.ValueMember = "ID_Type";
            cbSale.DataSource = vouchers.getConfigurationSale(int.Parse(Properties.Settings.Default.vouchers));
        }

        private void cbSale_Click(object sender, EventArgs e)
        {
            cbSale.DisplayMember = "Sale";
            cbSale.ValueMember = "ID_Type";
            cbSale.DataSource = vouchers.getConfigurationSale(0);
        }
    }
}
