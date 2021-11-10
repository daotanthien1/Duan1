using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RJCodeAdvance.ControlVouchers
{
    public partial class UC_Voucher : UserControl
    {
        BUS_Vouchers vouchers = new BUS_Vouchers();
        public UC_Voucher()
        {
            InitializeComponent();
        }
        public static string mail;
        private void btThem_Click(object sender, EventArgs e)
        {
        }

        private void UC_Voucher_Load(object sender, EventArgs e)
        {
            loadData();
        }
        // load data
        void loadData()
        {
            guna2DataGridView1.DataSource = vouchers.getData();
            guna2DataGridView1.Columns[0].HeaderText = "Mã voucher";
            guna2DataGridView1.Columns[1].HeaderText = "Ngày bắt đầu";
            guna2DataGridView1.Columns[2].HeaderText = "Ngày kết thúc";
            guna2DataGridView1.Columns[3].HeaderText = "Khuyến mãi";

            cbSale.DataSource = vouchers.getSale();
            cbSale.DisplayMember = "Sale";
            cbSale.ValueMember = "ID_Type";

            cbSearch.DataSource = vouchers.getSale();
            cbSearch.DisplayMember = "Sale";
            cbSearch.ValueMember = "ID_Type";
            label6.Hide();
        }
        //bt insert data
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if(txtThem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng voucher muốn thêm");
            }
            else
            {
                int id = int.Parse(cbSale.SelectedValue.ToString());
                int number = int.Parse(txtThem.Text);
                do
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(2, false));
                    builder.Append(RandomString(1, true));
                    builder.Append(RandomString(1, false));
                    builder.Append(RandomString(2, true));
                    string id_vouchers = builder.ToString();
                    DTO_Vouchers voucher = new DTO_Vouchers(id_vouchers, dayStart.Text, dayEnd.Text, mail, id, 0);
                    if (vouchers.InsertDatevoucher(voucher))
                    {
                        loadData();
                        number = number - 1;
                    }
                    else
                    {
                        return;
                    }
                } while (number > 0);
            }
        }
        // tạo mã voucher ngẫu nhiên
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(cbSearch.SelectedValue.ToString());
            DataTable voucher = vouchers.searchDataVoucher(id);
            if(voucher.Rows.Count > 0)
            {
                guna2DataGridView1.DataSource = voucher;
                guna2DataGridView1.Columns[0].HeaderText = "Mã voucher";
                guna2DataGridView1.Columns[1].HeaderText = "Ngày bắt đầu";
                guna2DataGridView1.Columns[2].HeaderText = "Ngày kết thúc";
                guna2DataGridView1.Columns[3].HeaderText = "Khuyến mãi";
            }
            else
            {
                MessageBox.Show("Chưa có khuyến mãi " + cbSearch.Text + "%");
                loadData();
            }
            DataTable counts = vouchers.getCountSaleVoucher(id);
            txtSoLuong.Text = counts.Rows[0][0].ToString();
        }
        // load data when click datagridview
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                guna2Button3.Enabled = true;
                guna2Button5.Enabled = false;

                cbSearch.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
                label6.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }
        // xóa
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (vouchers.deleteVoucher(label6.Text))
            {
                MessageBox.Show("Delete thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            else
            {
                MessageBox.Show("Delete không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
