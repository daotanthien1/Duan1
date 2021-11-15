using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance.ControlIngredient
{
    public partial class UC_Input_Ingredient : UserControl
    {
        public UC_Input_Ingredient()
        {
            InitializeComponent();
        }
        BUS_InputIngredients input = new BUS_InputIngredients();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FrmUnit frm = new FrmUnit();
            frm.ShowDialog();
        }
        DateTime today = DateTime.Now;
        private void UC_Input_Ingredient_Load(object sender, EventArgs e)
        {
            loadData();
            LoadDatagridview();
            txtSoLuong.Text = "0";
            guna2Button3.Enabled = false;
            guna2Button3.Enabled = false;
        }
        // load data to combobox
        void loadData()
        {
            cbLoaiNguyenLieu.DisplayMember = "Name";
            cbLoaiNguyenLieu.ValueMember = "Id_type";
            cbLoaiNguyenLieu.DataSource = input.getTypeIngredientForInputBillDetail();

            cbName.DisplayMember = "Name";
            cbName.ValueMember = "Id_ingredient";
            cbName.DataSource = input.getNameIngredientForInputBillDetail(int.Parse(cbLoaiNguyenLieu.SelectedValue.ToString()));
        }
        private DataTable dt = new DataTable();
        //load data bill to datafridview
        void LoadDatagridview()
        {
            dt.Columns.Add("Loại nguyên liệu", typeof(string));
            dt.Columns.Add("Tên nguyên liệu", typeof(string));
            dt.Columns.Add("Số lượng", typeof(string));
            dt.Columns.Add("Thành tiền", typeof(string));
            guna2DataGridView1.DataSource = dt;
        }
        int sumPrice;
        // thêm nguyên liệu
        private void btThemNguyenLieu_Click(object sender, EventArgs e)
        {
            loadPrice();
            sumPrice += int.Parse(txtThanhTien.Text);
            txtTongTien.Text = sumPrice.ToString();
            bool kt = true;
            foreach (DataRow item in dt.Rows)
            {
                if(item[0].ToString() == cbLoaiNguyenLieu.Text && item[1].ToString() == cbName.Text)
                {
                    kt = false;
                    item[2] = (int.Parse(item[2].ToString()) + int.Parse(txtSoLuong.Text)).ToString();
                    item[3] = (int.Parse(item[3].ToString()) + int.Parse(txtThanhTien.Text)).ToString();
                    guna2DataGridView1.DataSource = dt;
                    break;
                }
            }
            if (kt)
            {
                dt.Rows.Add(cbLoaiNguyenLieu.Text, cbName.Text, txtSoLuong.Text, txtThanhTien.Text);
                guna2DataGridView1.DataSource = dt;
            }
        }
        // click vào combobox thì load lại data
        private void cbLoaiNguyenLieu_Click_1(object sender, EventArgs e)
        {
            cbLoaiNguyenLieu.DisplayMember = "Name";
            cbLoaiNguyenLieu.ValueMember = "Id_type";
            cbLoaiNguyenLieu.DataSource = input.getTypeIngredientForInputBillDetail();
            loadPrice();
        }
        // click vào combobox thì load lại data
        private void cbName_Click_1(object sender, EventArgs e)
        {
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "Id_ingredient";
            cbName.DataSource = input.getNameIngredientForInputBillDetail(int.Parse(cbLoaiNguyenLieu.SelectedValue.ToString()));
            loadPrice();
        }
        // click vào txtSoLuong thì load thành tiền
        private void txtSoLuong_Click_2(object sender, EventArgs e)
        {
            loadPrice();
        }
        //load giá tiền
        void loadPrice()
        {
            DataTable price = input.PriceInputBill(int.Parse(cbName.SelectedValue.ToString()), int.Parse(txtSoLuong.Text));
            dataGridView1.DataSource = price;
            txtThanhTien.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
        }
        BUS_InputBills bill = new BUS_InputBills();
        public static string mail = "a";
        // thanh toán
        private void btThanhToan_Click(object sender, EventArgs e)
        {
            string time = today.ToString("yyyy-MM-dd hh:mm:ss.fff");
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có mặc hàng nào cần thanh toán");
            }
            else
            {
                // tạo insert vào inputBill
                DTO_InputBills dTO_InputBills = new DTO_InputBills(time, mail, float.Parse(txtTongTien.Text));
                if (bill.insertBillIngredient(dTO_InputBills))
                {
                    //vằng lặp lấy giá trị trong datagridview để insert vào inputBillsDetails
                    for (int i = 0; i < guna2DataGridView1.Rows.Count - 1; i++)
                    {
                        string nameType = guna2DataGridView1.Rows[i].Cells[1].Value.ToString();
                        string soLuong = guna2DataGridView1.Rows[i].Cells[2].Value.ToString();
                        DTO_InputIngredients dTO_InputIngredients = new DTO_InputIngredients(soLuong, nameType, time);
                        if (input.insertBillDetailIngredient(dTO_InputIngredients))
                        {
                        }
                    }
                    dt.Rows.Clear();
                    guna2DataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Thao tác chậm lại :)))");
                }
            }

        }
        // click vào backgroud để load lại giá
        private void UC_Input_Ingredient_Click(object sender, EventArgs e)
        {
            loadPrice();
        }
        //click datagridview
        int rows;
        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            guna2Button3.Enabled = true;
            guna2Button3.Enabled = true;
            cbLoaiNguyenLieu.Enabled = false;
            cbName.Enabled = false;
            if (guna2DataGridView1.Rows.Count > 0)
            {
                rows = guna2DataGridView1.CurrentRow.Index;
            }
        }
        //xóa mặc hàng đã chọn
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            dt.Rows[rows].Delete();
            guna2DataGridView1.DataSource = dt;
            cbLoaiNguyenLieu.Enabled = true;
            cbName.Enabled = true;
            guna2Button3.Enabled = false;
            guna2Button3.Enabled = false;
        }
        // sửa số lượng mặc hàng
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
