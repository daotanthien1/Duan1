﻿using System;
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
using DAL_QuanLy;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace RJCodeAdvance.ControlBeverages
{
    public partial class UC_beverages : UserControl
    {
        public UC_beverages()
        {
            InitializeComponent();
        }

        private void UC_beverages_Load(object sender, EventArgs e)
        {
            ResetValue();
            loadComBoBox();
            loadDGV();
        }
        BUS_Beverage busBe = new BUS_Beverage();
        void ResetValue()
        {
            txtTenDoUong.Enabled = false;
            txtTenDoUong.Text = "";
            cbDoUong.Enabled = false;
            cbDoUong.Text = "";
            txtGia.Enabled = false;
            txtGia.Text = "";
            txtHinh.Enabled = false;
            txtHinh.Text = "";
            btFile.Enabled = false;
            txtSearchDoUong.Text = "";
            btXoa.Enabled = false; ;
            btSua.Enabled = false;
            btLuu.Enabled = false;
        }
        bool checkTextBox()
        {
            if (string.IsNullOrEmpty(txtTenDoUong.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                txtTenDoUong.Text = "";
                txtTenDoUong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                txtGia.Text = "";
                txtGia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbDoUong.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                cbDoUong.Text = "";
                cbDoUong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbDoUong.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                cbDoUong.Text = "";
                cbDoUong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHinh.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                txtHinh.Text = "";
                txtHinh.Focus();
                return false;
            }
            return true;
        }
        void loadDGV()
        {
            dgvBeverage.DataSource = busBe.getBeverage(); 
            dgvBeverage.Columns[0].HeaderText = "Name";
            dgvBeverage.Columns[1].HeaderText = "Price";
            dgvBeverage.Columns[2].HeaderText = "Id_Type";
            dgvBeverage.Columns[3].HeaderText = "Id_beverage";
            dgvBeverage.Columns[4].HeaderText = "Image";
            dgvBeverage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtTenDoUong.Enabled = true;
            cbDoUong.Enabled = true;
            txtGia.Enabled = true;
            txtHinh.Enabled = true;
            btLuu.Enabled = true;
            btFile.Enabled = true;
        }
        void loadComBoBox()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString))
            {
                cbDoUong.Items.Clear();
                string query = "select id_type, Name from typesofbeverage";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "typesofbeverage");
                cbDoUong.DisplayMember = "Name";
                cbDoUong.ValueMember = "id_type";
                cbDoUong.DataSource = ds.Tables["typesofbeverage"];
            }

           

        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkTextBox())
                {
                    DTO_QuanLyDoUong dtoBe = new DTO_QuanLyDoUong(txtTenDoUong.Text, 
                        float.Parse(txtGia.Text),Convert.ToInt32(cbDoUong.SelectedValue), "Images\\" + fileName);
                    if (busBe.InsertDoUong(dtoBe))
                    {
                        if (txtHinh.Text != checkUrlImage)
                        {
                            File.Copy(fileAddress, fileSavePath, true);//copy file hinh
                        }
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

        private void dgvBeverage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBeverage.Rows.Count > 1)
                {
                    btLuu.Enabled = false;
                    btXoa.Enabled = true;
                    btSua.Enabled = true;
                    btBoqua.Enabled = true;
                    txtTenDoUong.Enabled = true;
                    cbDoUong.Enabled = true;
                    txtGia.Enabled = true;
                    txtHinh.Enabled = true;
                    btFile.Enabled = true;
                    txtTenDoUong.Text = dgvBeverage.CurrentRow.Cells["Name"].Value.ToString();
                    txtGia.Text = dgvBeverage.CurrentRow.Cells["Price"].Value.ToString();
                    cbDoUong.Text = dgvBeverage.CurrentRow.Cells["Id_Type"].Value.ToString();
                    txtHinh.Text = dgvBeverage.CurrentRow.Cells["Image"].Value.ToString();
                    checkUrlImage = txtHinh.Text;
                    picHinh.Image = Image.FromFile(dgvBeverage.CurrentRow.Cells["Image"].Value.ToString());
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
        string checkUrlImage;// kiểm tra hình khi cập nhật
        string fileName;//tên file
        string fileSavePath;//url store image
        string fileAddress;// url load images
        private void btFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|.bmp|JPEG(*.jpg)|*.jpg|GIF(*.fig)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                picHinh.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                fileSavePath = "Images\\" + fileName;//combine with file name
                txtHinh.Text = "Images\\" + fileName;
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkTextBox())
                {
                    DTO_QuanLyDoUong dtoBe = new DTO_QuanLyDoUong(txtTenDoUong.Text, 
                        float.Parse(txtGia.Text), Convert.ToInt32(cbDoUong.SelectedValue),
                        Convert.ToInt32(dgvBeverage.CurrentRow.Cells["Id_beverage"].Value.ToString()), "Images\\" + fileName);
                    if (busBe.UpdateDoUong(dtoBe))
                    {
                        if (txtHinh.Text != checkUrlImage)
                        {
                            File.Copy(fileAddress, fileSavePath, true);//copy file hinh
                        }
                        MessageBox.Show("Thành công");
                        loadDGV();
                        ResetValue();
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
            int id = Convert.ToInt32(dgvBeverage.CurrentRow.Cells["Id_beverage"].Value.ToString());
            if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busBe.DeleteDoUong(id))
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

        private void btBoqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            loadDGV();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = txtSearchDoUong.Text;
            DataTable ds = busBe.SearchDoUong(tenHang);
            if (ds.Rows.Count > 0)
            {
                dgvBeverage.DataSource = ds;
                dgvBeverage.Columns[0].HeaderText = "Name";
                dgvBeverage.Columns[1].HeaderText = "Price";
                dgvBeverage.Columns[2].HeaderText = "Id_Type";
                dgvBeverage.Columns[3].HeaderText = "Id_beverage";
                dgvBeverage.Columns[4].HeaderText = "Image";
                dgvBeverage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ResetValue();
        }
    }
}
