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
            nbDiemYeuCau.Maximum = 9999999;
            nbDiemYeuCau.Minimum = 0;

        }
        BUS_Vouchers vouchers = new BUS_Vouchers();
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                Properties.Settings.Default.rewards = Convert.ToInt32(nbDiemYeuCau.Value);
                Properties.Settings.Default.voucherType = Convert.ToInt32(cbSale.SelectedValue.ToString());
                Properties.Settings.Default.voucheTypeName = Convert.ToInt16(cbSale.Text); 
                Properties.Settings.Default.TurnOnSale = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.rewards = 0;
                Properties.Settings.Default.voucherType = 0;
                Properties.Settings.Default.voucheTypeName = 0;
                Properties.Settings.Default.TurnOnSale = false;
                Properties.Settings.Default.Save();
            }
        }
        public static string Sale;
        private void FrmConfigurationSale_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TurnOnSale)
            {
                guna2ToggleSwitch1.Checked = true;
                nbDiemYeuCau.Value = Properties.Settings.Default.rewards;
                cbSale.Text = Properties.Settings.Default.voucheTypeName.ToString();
                loadData();
                loadSale();
            }
            else
            {
                guna2ToggleSwitch1.Checked = false;
                nbDiemYeuCau.Value = 0;
                cbSale.ResetText();
            }
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
            cbSale.DataSource = vouchers.getConfigurationSale(Properties.Settings.Default.voucherType);
        }

        private void cbSale_Click(object sender, EventArgs e)
        {
            cbSale.DisplayMember = "Sale";
            cbSale.ValueMember = "ID_Type";
            cbSale.DataSource = vouchers.getConfigurationSale(0);
        }
    }
}
