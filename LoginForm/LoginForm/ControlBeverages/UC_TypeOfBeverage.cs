﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;

namespace RJCodeAdvance.ControlBeverages
{
    public partial class UC_TypeOfBeverage : UserControl
    {
        public UC_TypeOfBeverage()
        {
            InitializeComponent();
        }
        BUS_TypesOfBeverage BUS_TypesOfBeverage = new BUS_TypesOfBeverage();
         void   loadDGV()
        {
            dgvLoaiDoUong.DataSource = BUS_TypesOfBeverage.getBeverage(); 
            dgvLoaiDoUong.Columns[0].HeaderText = "Id_Type";
            dgvLoaiDoUong.Columns[1].HeaderText = "Name";
            dgvLoaiDoUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void UC_TypeOfBeverage_Load(object sender, EventArgs e)
        {
            loadDGV();
            ResetValue();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = txtSearchDoUong.Text;
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

        private void txtSearchLoai_TextChanged(object sender, EventArgs e)
        {

        }
        void ResetValue()
        {
            txtLoaiDoUong.Text = "";
            txtLoaiDoUong.Enabled = false;
            txtSearchDoUong.Text = "";
            btXoa.Enabled = false; 
            btSua.Enabled = false;
            btLuu.Enabled = false;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtLoaiDoUong.Enabled = true;
            btLuu.Enabled = true;
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
        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (check())
                {
                    string name = txtLoaiDoUong.Text;
                    if (BUS_TypesOfBeverage.InsertDoUong(name))
                    {
                        MessageBox.Show("Thành công");
                        loadDGV();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btSua_Click(object sender, EventArgs e)
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

        private void btXoa_Click(object sender, EventArgs e)
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

        private void btBoQua_Click(object sender, EventArgs e)
        {
            loadDGV();
            ResetValue();
        }

        private void dgvLoaiDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLoaiDoUong.Rows.Count > 1)
                {
                    btLuu.Enabled = false;
                    btXoa.Enabled = true;
                    btSua.Enabled = true;
                    txtLoaiDoUong.Enabled = true;
                    txtLoaiDoUong.Text = dgvLoaiDoUong.CurrentRow.Cells["Name"].Value.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }
    }
}
