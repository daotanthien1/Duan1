using System;
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

        private void UC_Bill_Load(object sender, EventArgs e)
        {
            if (rdoDoUong.Checked == true)
            {
                loadDGVDoUong();
            }
            else
            {
                loadDGVNL();
            }
            cbbFilterCol.Items.Clear();
            
            dgvBillsDetail.Refresh();
            cbbFilterCol.Items.Add("Id_Employee");
            cbbFilterCol.Items.Add("Id_Bill");
            cbbFilterCol.Items.Add("Id_Customer");
            cbbFilterCol.Items.Add("Id_Table");
            cbbFilterCol.Items.Add("DateCheckIn");
            cbbFilterCol.Items.Add("DateCheckOut");
            cbbFilterCol.Items.Add("Status");
            cbbFilterCol.SelectedIndex = 0;
        }
        void loadDGVDoUong()
        {
            dgvBill.DataSource = BUS_Bill.getBillDoUong();
            dgvBill.Columns[0].HeaderText = "Id_employee";
            dgvBill.Columns[1].HeaderText = "Id_bill";
            dgvBill.Columns[2].HeaderText = "Id_customer";
            dgvBill.Columns[3].HeaderText = "Id_table";
            dgvBill.Columns[4].HeaderText = "DateCheckIn";
            dgvBill.Columns[5].HeaderText = "DateCheckOut";
            dgvBill.Columns[6].HeaderText = "status";
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void loadDGVNL()
        {
            dgvBill.DataSource = BUS_Bill.getBillNL();
            dgvBill.Columns[0].HeaderText = "ID_Bill";
            dgvBill.Columns[1].HeaderText = "DateCheckIn";
            dgvBill.Columns[2].HeaderText = "ID_employee";
            dgvBill.Columns[3].HeaderText = "SumPrice";
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void loadBillDetail(int id)
        {
            dgvBillsDetail.DataSource = BUS_Bill.getBillDetailDoUong(id);
            dgvBillsDetail.Columns[0].HeaderText = "ID_BillDetail";
            dgvBillsDetail.Columns[1].HeaderText = "ID_Bill";
            dgvBillsDetail.Columns[2].HeaderText = "Quantity";
            dgvBillsDetail.Columns[3].HeaderText = "ID_beverage";
            dgvBillsDetail.Columns[4].HeaderText = "Total_price";
            dgvBillsDetail.Columns[5].HeaderText = "Sale";
            dgvBillsDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void loadBillDetailNL(int id)
        {
            dgvBillsDetail.DataSource = BUS_Bill.getBillDetailNL(id);
            dgvBillsDetail.Columns[0].HeaderText = "ID_BillDetail";
            dgvBillsDetail.Columns[1].HeaderText = "Quantity";
            dgvBillsDetail.Columns[2].HeaderText = "Id_Ingredient";
            dgvBillsDetail.Columns[3].HeaderText = "ID_Bill";
            dgvBillsDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void rdoDoUong_Click(object sender, EventArgs e)
        {

        }

        private void rdoDoUong_CheckedChanged(object sender, EventArgs e)
        {
            cbbFilterCol.Items.Clear();
            loadDGVDoUong();
            dgvBillsDetail.Refresh();
            cbbFilterCol.Items.Add("Id_Employee");
            cbbFilterCol.Items.Add("Id_Bill");
            cbbFilterCol.Items.Add("Id_Customer");
            cbbFilterCol.Items.Add("Id_Table");
            cbbFilterCol.Items.Add("DateCheckIn");
            cbbFilterCol.Items.Add("DateCheckOut");
            cbbFilterCol.Items.Add("Status");
            cbbFilterCol.SelectedIndex = 0;
        }

        private void rdoNguyenLieu_CheckedChanged(object sender, EventArgs e)
        {
            cbbFilterCol.Items.Clear();
            loadDGVNL();
            dgvBillsDetail.Refresh();
            dgvBillsDetail.Refresh();
            cbbFilterCol.Items.Add("ID_Bill");
            cbbFilterCol.Items.Add("DateCheckIn");
            cbbFilterCol.Items.Add("Id_Employee");
            cbbFilterCol.Items.Add("SumPrice");
            cbbFilterCol.SelectedIndex = 0;
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBill.Rows.Count > 1)
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
                            loadBillDetail(id2);
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

        private void btnXoaBillsDetail_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["ID_Bill"].Value.ToString());

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
                    int id2 = Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["ID_Bill"].Value.ToString());
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
                            int idtemp = int.Parse(dgvBill.CurrentRow.Cells["Id_bill"].Value.ToString());
                            loadBillDetail(idtemp);
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

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {


                if (rdoDoUong.Checked == true)
                {
                    int id = Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["ID_Bill"].Value.ToString());


                    DTO_Bill_Detail dto = new DTO_Bill_Detail(Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["ID_Bill"].Value.ToString()), Convert.ToInt32(nbSoLuong.Text));
                    if (BUS_Bill.UpdateBillsDetailDoUong(dto))
                    {
                        MessageBox.Show("Success");
                        int idtemp = int.Parse(dgvBill.CurrentRow.Cells["Id_bill"].Value.ToString());
                        loadBillDetail(idtemp);
                    }
                    
                }
                else
                {
                    
                        int id2 = Convert.ToInt32(dgvBillsDetail.CurrentRow.Cells["ID_Bill"].Value.ToString());
                        if (BUS_Bill.UpdateBillsDetailNL(Convert.ToInt32(nbSoLuong.Text), id2))
                        {
                            MessageBox.Show("Success");
                        int idtemp = int.Parse(dgvBill.CurrentRow.Cells["Id_bill"].Value.ToString());
                        loadBillDetail(idtemp);
                    }
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = txtSearchDoUong.Text;
            string tenCot = cbbFilterCol.Text;
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

        private void txtSearchDoUong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btTimKiem_Click(sender, e);
            }
        }

        private void btDanhSach_Click(object sender, EventArgs e)
        {
            if (rdoDoUong.Checked == true)
            {
                loadDGVDoUong();
            }
            else
            {
                loadDGVNL();
            }
            cbbFilterCol.Items.Clear();

            dgvBillsDetail.Refresh();
            cbbFilterCol.Items.Add("Id_Employee");
            cbbFilterCol.Items.Add("Id_Bill");
            cbbFilterCol.Items.Add("Id_Customer");
            cbbFilterCol.Items.Add("Id_Table");
            cbbFilterCol.Items.Add("DateCheckIn");
            cbbFilterCol.Items.Add("DateCheckOut");
            cbbFilterCol.Items.Add("Status");
            cbbFilterCol.SelectedIndex = 0;
        }
    }
}
