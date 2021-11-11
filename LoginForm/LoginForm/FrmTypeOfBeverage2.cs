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

namespace RJCodeAdvance
{
    public partial class FrmTypeOfBeverage2 : Form
    {
        public FrmTypeOfBeverage2()
        {
            InitializeComponent();
        }
        BUS_TypesOfBeverage BUS_TypesOfBeverage = new BUS_TypesOfBeverage();
        void loadDGV()
        {
            dgvLoaiDoUong.DataSource = BUS_TypesOfBeverage.getBeverage(); 
            dgvLoaiDoUong.Columns[0].HeaderText = "Id_Type";
            dgvLoaiDoUong.Columns[1].HeaderText = "Name";
            dgvLoaiDoUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmTypeOfBeverage2_Load(object sender, EventArgs e)
        {
            loadDGV();
            ResetValue();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = TxtTimKiem.Text;
            DataTable ds = BUS_TypesOfBeverage.SearchLoaiDoUong(tenHang);
            if (ds.Rows.Count > 0)
            {
                dgvLoaiDoUong.DataSource = ds;
                dgvLoaiDoUong.Columns[0].HeaderText = "Id_Type";
                dgvLoaiDoUong.Columns[1].HeaderText = "Name";
                dgvLoaiDoUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ResetValue();
        }

        void ResetValue()
        {
            txtLoaiDoUong.Text = "";
            txtLoaiDoUong.Enabled = false;
            TxtTimKiem.Text = "";
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            BtnLuu.Enabled = false;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtLoaiDoUong.Enabled = true;
            BtnLuu.Enabled = true;
        }


        bool check()
        {
            if (string.IsNullOrEmpty(txtLoaiDoUong.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                txtLoaiDoUong.Text = "";
                txtLoaiDoUong.Focus();
                return false;
            }
            return true;
        }

        private void btXoa(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvLoaiDoUong.CurrentRow.Cells["Id_Type"].Value.ToString());
            if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (BUS_TypesOfBeverage.DeleteDoUong(id))
                {
                    MessageBox.Show("Xoá dữ liệu thành công");
                    ResetValue();
                    loadDGV();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công");
                }
            }
            else
            {
                ResetValue();
            }
        }

        private void btSua(object sender, EventArgs e)
        {
            try
            {
                if (check())
                {
                    string loaiDoUong = txtLoaiDoUong.Text.ToString();
                    DTO_TypesOfBeverage name = new DTO_TypesOfBeverage(Convert.ToInt32(dgvLoaiDoUong.CurrentRow.Cells["Id_Type"].Value.ToString()), loaiDoUong);
                    if (BUS_TypesOfBeverage.UpdateDoUong(name))
                    {
                        MessageBox.Show("Thành công");
                        loadDGV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btLuu(object sender, EventArgs e)
        {

        }

        private void btThoat(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
