using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;
using System.Collections;


namespace RJCodeAdvance.ControlBills
{
    public partial class UC_Bill : UserControl
    {
        BUS_Bill BUS_Bill = new BUS_Bill();
        public UC_Bill()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Hashtable hash;
        BindingSource bindingSource;
        public void UC_Bill_Load(object sender, EventArgs e)
        {
            if (rdoDoUong.Checked == true)
            {
                loadDGVDoUong();
                label2.Text = "Tên đồ uống";
            }
            else
            {
                loadDGVNL();
                label2.Text = "Tên nguyên liệu";
            }
            hash = new Hashtable();
            hash.Add("Id_Employee", "Tên nhân viên");
            hash.Add("Id_table", "Tên bàn");
            hash.Add("DateCheckOut", "Ngày xuất hoá đơn");
            cbbFilterCol.DataSource = null;
            cbbFilterCol.Items.Clear();
            dgvBillsDetail.Refresh();
            bindingSource = new BindingSource(hash,null);
            
            cbbFilterCol.DataSource = bindingSource ;
            cbbFilterCol.ValueMember = "Key";
            cbbFilterCol.DisplayMember = "Value";
            cbbFilterCol.SelectedIndex = 2;
            

        }
        //load dgv cua do uong
        void loadDGVDoUong()
        {
            dgvBill.DataSource = BUS_Bill.getBillDoUong();
            dgvBill.Columns[0].HeaderText = "Tên nhân viên";
            dgvBill.Columns[1].HeaderText = "Tên bàn";
            dgvBill.Columns[2].HeaderText = "Ngày xuất hoá đơn";
            dgvBill.Columns[3].HeaderText = "Id_bill";
            dgvBill.Columns[3].Visible = false;
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load dgv cua nguyen lieu
        void loadDGVNL()
        {
            dgvBill.DataSource = BUS_Bill.getBillNL();
            dgvBill.Columns[0].HeaderText = "Tên nhân viên";
            dgvBill.Columns[1].HeaderText = "Ngày nhập hoá đơn";
            dgvBill.Columns[2].HeaderText = "Tổng giá";
            dgvBill.Columns[3].HeaderText = "ID_Bill";
            dgvBill.Columns[3].Visible = false;
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load dgv cua do uong nhung detail
        void loadBillDetail(int id)
        {
            dgvBillsDetail.DataSource = BUS_Bill.getBillDetailDoUong(id);
            dgvBillsDetail.Columns[0].HeaderText = "Tên đồ uống";
            dgvBillsDetail.Columns[1].HeaderText = "Số lượng";
            dgvBillsDetail.Columns[2].HeaderText = "Id_bill_detaill";
            dgvBillsDetail.Columns[2].Visible = true ;
            
            dgvBillsDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load dgv cua nguyen lieu nhung detail
        void loadBillDetailNL(int id)
        {
            dgvBillsDetail.DataSource = BUS_Bill.getBillDetailNL(id);
            dgvBillsDetail.Columns[0].HeaderText = "Tên nguyên liệu";
            dgvBillsDetail.Columns[1].HeaderText = "Số lượng";
            dgvBillsDetail.Columns[2].HeaderText = "Id_BillDetaill";
            dgvBillsDetail.Columns[2].Visible = false;
            dgvBillsDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void rdoDoUong_Click(object sender, EventArgs e)
        {

        }

        private void rdoDoUong_CheckedChanged(object sender, EventArgs e)
        {
            cbbFilterCol.DataSource = null;
            cbbFilterCol.Items.Clear();
            loadDGVDoUong();
            dgvBillsDetail.Refresh();
            bindingSource = new BindingSource(hash, null);
            
            cbbFilterCol.DataSource = bindingSource;
            cbbFilterCol.ValueMember = "Key";
            cbbFilterCol.DisplayMember = "Value";
            cbbFilterCol.SelectedIndex = 2;
            label2.Text = "Tên đồ uống";
        }

        private void rdoNguyenLieu_CheckedChanged(object sender, EventArgs e)
        {
            cbbFilterCol.DataSource = null;
            cbbFilterCol.Items.Clear();
            loadDGVNL();
            dgvBillsDetail.Refresh();
            Hashtable h2 = new Hashtable();
            h2.Add("ID_employee", "Tên nhân viên");
            h2.Add("SumPrice", "Tổng giá");
            h2.Add("DateCheckIn", "Ngày nhập hoá đơn");
            cbbFilterCol.Items.Clear();
            dgvBillsDetail.Refresh();
            BindingSource b2 = new BindingSource(h2, null);
            
            cbbFilterCol.DataSource = b2;
            cbbFilterCol.ValueMember = "Key";
            cbbFilterCol.DisplayMember = "Value";
            cbbFilterCol.SelectedIndex = 2;
            //cbbFilterCol.Items.Add("Tên nhân viên");
            //cbbFilterCol.Items.Add("Ngày nhập hoá đơn");
            //cbbFilterCol.Items.Add("Tổng giá");
            //cbbFilterCol.SelectedIndex = 0;
            label2.Text = "Tên nguyên liệu";
        }
        //click vao dgv
        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBill.Rows.Count > 0 )
                {
                    if (rdoDoUong.Checked == true)
                    {
                        int id = int.Parse(dgvBill.CurrentRow.Cells["Id_bill"].Value.ToString());
                        loadBillDetail(id);
                    }
                    else
                    {
                        int id = int.Parse(dgvBill.CurrentRow.Cells["ID_Bill"].Value.ToString());
                        loadBillDetailNL(id);
                    }
                    btXoa.Enabled = true;
                    btSua.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //click nut xoa
        private void btXoa_Click(object sender, EventArgs e)
        {

            try
            {
                if (rdoDoUong.Checked == true)
                {
                    int id = Convert.ToInt32(dgvBill.CurrentRow.Cells["Id_bill"].Value.ToString());
                    if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (BUS_Bill.DeleteBillsDoUong(id))
                        {
                            if (rdoDoUong.Checked == true)
                            {
                                loadDGVDoUong();
                            }
                            else
                            {
                                loadDGVNL();
                            }
                            loadBillDetail(id);
                        }
                        else
                        {
                            MessageBox.Show("Xoá không thành công");
                        }
                    }
                }
                else
                {
                    int id2 = int.Parse(dgvBill.CurrentRow.Cells["ID_Bill"].Value.ToString());
                    if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (BUS_Bill.DeleteBillsNL(id2))
                        {
                            if (rdoDoUong.Checked == true)
                            {
                                loadDGVDoUong();
                            }
                            else
                            {
                                loadDGVNL();
                            }
                            loadBillDetailNL(id2);
                        }
                        else
                        {
                            MessageBox.Show("Xoá không thành công");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //click nut xoa nhung ben detail
        private void btnXoaBillsDetail_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["Id_bill_detaill"].Value.ToString());

                if (rdoDoUong.Checked == true)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (BUS_Bill.DeleteBillsDetailDoUong(id))
                        {
                            if (rdoDoUong.Checked == true)
                            {
                                loadDGVDoUong();
                            }
                            else
                            {
                                loadDGVNL();
                            }
                            int idtemp = int.Parse(dgvBill.CurrentRow.Cells["Id_bill"].Value.ToString());
                            loadBillDetail(idtemp);
                        }
                        else
                        {
                            MessageBox.Show("Xoá không thành công");
                        }
                    }
                }
                else
                {
                    int id2 = Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["Id_BillDetaill"].Value.ToString());
                    if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (BUS_Bill.DeleteBillsDetailNL(id2))
                        {
                            if (rdoDoUong.Checked == true)
                            {
                                loadDGVDoUong();
                            }
                            else
                            {
                                loadDGVNL();
                            }
                            int idtemp = int.Parse(dgvBill.CurrentRow.Cells["ID_Bill"].Value.ToString());
                            loadBillDetailNL(idtemp);
                        }
                        else
                        {
                            MessageBox.Show("Xoá không thành công");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //click nut sua
        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoDoUong.Checked == true)
                {
                    
                    DTO_Bill_Detail dto = new DTO_Bill_Detail(Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["Id_bill_detaill"].Value.ToString()), Convert.ToInt32(nbSoLuong.Text));
                    if (BUS_Bill.UpdateBillsDetailDoUong(dto))
                    {
                        MessageBox.Show("Success");
                        int idtemp = int.Parse(dgvBill.CurrentRow.Cells["Id_bill"].Value.ToString());
                        loadBillDetail(idtemp);
                    }

                }
                else
                {

                    int id2 = Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["Id_BillDetaill"].Value.ToString());
                    if (BUS_Bill.UpdateBillsDetailNL(Convert.ToInt32(nbSoLuong.Text), id2))
                    {
                        MessageBox.Show("Success");
                        int idtemp = int.Parse(dgvBill.CurrentRow.Cells["ID_Bill"].Value.ToString());
                        loadBillDetailNL(idtemp);
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //click nut tim kiem
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = txtSearchDoUong.Text;
            string tenCot = cbbFilterCol.SelectedValue.ToString() ;
            if (rdoDoUong.Checked == true)
            {
                DataTable ds = BUS_Bill.BillsDetailSearch(tenHang, tenCot);
                if (ds.Rows.Count > 0)
                {
                    dgvBill.DataSource = ds;
                    dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DataTable ds = BUS_Bill.InputBillsDetailSearch(tenHang, tenCot);
                if (ds.Rows.Count > 0)
                {
                    dgvBill.DataSource = ds;
                    dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //thay vi click nut tim kiem thi minh an enter cho nhanh
        private void txtSearchDoUong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btTimKiem_Click(sender, e);
            }
        }
        //click vao dgv nhung ben detail
        private void dgvBillsDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBill.Rows.Count > 0 || dgvBillsDetail.Rows.Count > 0)
                {
                    if (rdoDoUong.Checked == true)
                    {
                        
                            txtDoUong.Text = dgvBillsDetail.CurrentRow.Cells[0].Value.ToString();
                        

                    }
                    else
                    {
                        
                            txtDoUong.Text = dgvBillsDetail.CurrentRow.Cells[0].Value.ToString();


                    }
                    btXoa.Enabled = true;
                    btSua.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //khong biet la gi nhung tren mang chi vay la click vao header khong dc
        private void dgvBill_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        //chon cai combobox se doi placeholder cua txt search cho vui
        private void cbbFilterCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdoDoUong.Checked == true)
            {
                if (cbbFilterCol.SelectedIndex == 0)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập ID nhân viên cần tìm";
                }
                if (cbbFilterCol.SelectedIndex == 1)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập ID Bill cần tìm";
                }
                if (cbbFilterCol.SelectedIndex == 2)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập ID khách cần tìm";
                }
                if (cbbFilterCol.SelectedIndex == 3)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập ID bàn cần tìm";
                }
                if (cbbFilterCol.SelectedIndex == 4)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập DateCheckIn cần tìm";
                }
                if (cbbFilterCol.SelectedIndex == 5)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập DateCheckOut cần tìm";
                }
                if (cbbFilterCol.SelectedIndex == 6)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập trạng thái cần tìm";
                }
            }
            else
            {
                if (cbbFilterCol.SelectedIndex == 0)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập ID Bill cần tìm";
                }
                if (cbbFilterCol.SelectedIndex == 1)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập DateCheckIn cần tìm";
                }
                if (cbbFilterCol.SelectedIndex == 2)
                {
                    txtSearchDoUong.PlaceholderText = "Nhập SumPrice cần tìm";
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if(label8.ForeColor == Color.FromArgb(0, 118, 212))
            {
                label8.ForeColor = Color.FromArgb(255, 0, 0);
            }
            else if(label8.ForeColor == Color.FromArgb(255, 0, 0))
            {
                label8.ForeColor = Color.FromArgb(124, 252, 0);
            }else if(label8.ForeColor == Color.FromArgb(124, 252, 0))
            {
                label8.ForeColor = Color.FromArgb(0, 118, 212);
            }
        }
    }
}