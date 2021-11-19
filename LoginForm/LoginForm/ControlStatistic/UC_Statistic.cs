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

namespace RJCodeAdvance.ControlStatistic
{
    public partial class UC_Statistic : UserControl
    {
        BUS_Static bUS_Static = new BUS_Static();
        public UC_Statistic()
        {
            InitializeComponent();
        }

        private void UC_Statistic_Load(object sender, EventArgs e)
        {
            loadPill();
            LoadBillInput();
            LoadDanhThu();
        }
        void loadPill()
        {
            DataTable dt = bUS_Static.getDataBillDetail();
            guna2DataGridView1.DataSource = dt;
            guna2DataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            guna2DataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            guna2DataGridView1.Columns[2].HeaderText = "Mã bill";
            guna2DataGridView1.Columns[3].HeaderText = "Mã bàn";
            guna2DataGridView1.Columns[4].HeaderText = "Tổng tiền";
            guna2DataGridView1.Columns[5].HeaderText = "Ngày tạo";
            guna2DataGridView1.Columns[6].HeaderText = "Ngày xuất";
            foreach(DataRow item in dt.Rows)
            {
                if(item[1].ToString() == "")
                {
                    item[1] = "0";
                }
            }
            DataTable dt1 = bUS_Static.getPrice();
            foreach(DataRow item in dt1.Rows)
            {
                txtTongTien.Text = item[0].ToString()+" VND";
            }
        }
        //click vào thống kê hóa đơn
        private void btThongKe_Click(object sender, EventArgs e)
        {
            string dayStar = dayStart.Text;
            string dayend = dayEnd.Text;
            DataTable dt = bUS_Static.getDataBillDetailDate(dayStar, dayend);
            guna2DataGridView1.DataSource = dt;
            foreach (DataRow item in dt.Rows)
            {
                if (item[1].ToString() == "")
                {
                    item[1] = "0";
                }
            }
            DataTable dt1 = bUS_Static.SumPriceDateTime(dayStar, dayend);
            foreach(DataRow item in dt1.Rows)
            {
                txtTongTien.Text = item[0].ToString();
            }
        }
        DateTime dayNow = DateTime.Now;
        //Click bt tuần hóa đơn
        private void btTuan_Click(object sender, EventArgs e)
        {
            int dem;
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            if (date.DayOfWeek != DayOfWeek.Monday)
            {
                dem = date.DayOfWeek - DayOfWeek.Monday;
                DataTable dt = bUS_Static.getDataBillDetailDayOfWeek(date.AddDays(-dem).ToString("yyyy-MM-dd 00:00:00"), time);
                guna2DataGridView1.DataSource = dt;
                foreach (DataRow item in dt.Rows)
                {
                    if (item[1].ToString() == "")
                    {
                        item[1] = "0";
                    }
                }
                DataTable dt1 = bUS_Static.SumPriceDateTime(date.AddDays(-dem).ToString("yyyy-MM-dd 00:00:00"), time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = date.AddDays(-dem).ToString("yyyy-MM-dd");
                dayEnd.Text = time;
            }
            else
            {
                DataTable dt = bUS_Static.getDataBillDetailDayOfWeek(time1, time);
                guna2DataGridView1.DataSource = dt;
                foreach (DataRow item in dt.Rows)
                {
                    if (item[1].ToString() == "")
                    {
                        item[1] = "0";
                    }
                }
                DataTable dt1 = bUS_Static.SumPriceDateTime(time1, time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = time1;
                dayEnd.Text = time;
            }
        }
        //Click bt tháng hóa đơn
        private void btThang_Click(object sender, EventArgs e)
        {
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            if (date.Day != 1)
            {
                DataTable dt = bUS_Static.getDataBillDetailDayOfWeek(date.ToString("yyyy-MM-01 00:00:00"), time);
                guna2DataGridView1.DataSource = dt;
                foreach (DataRow item in dt.Rows)
                {
                    if (item[1].ToString() == "")
                    {
                        item[1] = "0";
                    }
                }
                DataTable dt1 = bUS_Static.SumPriceDateTime(date.ToString("yyyy-MM-01 00:00:00"), time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = date.ToString("yyyy-MM-01");
                dayEnd.Text = time;
            }
            else
            {
                DataTable dt = bUS_Static.getDataBillDetailDayOfWeek(time1, time);
                guna2DataGridView1.DataSource = dt;
                foreach (DataRow item in dt.Rows)
                {
                    if (item[1].ToString() == "")
                    {
                        item[1] = "0";
                    }
                }
                DataTable dt1 = bUS_Static.SumPriceDateTime(time1, time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = time1;
                dayEnd.Text = time;
            }
        }
        // click bt năm hóa đơn
        private void btNam_Click(object sender, EventArgs e)
        {
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            DataTable dt = bUS_Static.getDataBillDetailDayOfWeek(date.ToString("yyyy-01-01 00:00:00"), time);
            guna2DataGridView1.DataSource = dt;
            foreach (DataRow item in dt.Rows)
            {
                if (item[1].ToString() == "")
                {
                    item[1] = "0";
                }
            }
            DataTable dt1 = bUS_Static.SumPriceDateTime(date.ToString("yyyy-01-01 00:00:00"), time);
            foreach (DataRow item in dt1.Rows)
            {
                txtTongTien.Text = item[0].ToString();
            }
            dayStart.Text = date.ToString("yyyy-01-01");
            dayEnd.Text = time;
        }
        //load danh sách bill nhập nguyên liệu
        void LoadBillInput()
        {
            DataTable dt = bUS_Static.getAllBillInput();
            guna2DataGridView2.DataSource = dt;
            guna2DataGridView2.Columns[0].HeaderText = "Mã bill";
            guna2DataGridView2.Columns[1].HeaderText = "Ngày xuất bill";
            guna2DataGridView2.Columns[2].HeaderText = "Mã nhân viên";
            guna2DataGridView2.Columns[3].HeaderText = "Tổng tiền";
            DataTable dt1 = bUS_Static.getSumPriceBillInput();
            foreach (DataRow item in dt1.Rows)
            {
                txtTongTien1.Text = item[0].ToString() + " VND";
            }
        }
        // thống kê bill nhập ngyên liệu trong khoảng thời gian
        private void btThongKe1_Click(object sender, EventArgs e)
        {
            string dayStar = dayStar1.Text;
            string dayend = dayEnd1.Text;
            DataTable dt = bUS_Static.getBillInputBetween(dayStar, dayend);
            guna2DataGridView2.DataSource = dt;
            DataTable dt1 = bUS_Static.SumPriceBillInputBetween(dayStar, dayend);
            foreach (DataRow item in dt1.Rows)
            {
                txtTongTien1.Text = item[0].ToString();
            }
        }
        // click bt tuần bill nhập nguyên liệu
        private void btTuan1_Click(object sender, EventArgs e)
        {
            int dem;
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            if (date.DayOfWeek != DayOfWeek.Monday)
            {
                dem = date.DayOfWeek - DayOfWeek.Monday;
                DataTable dt = bUS_Static.getBillInputBetween(date.AddDays(-dem).ToString("yyyy-MM-dd 00:00:00"), time);
                guna2DataGridView2.DataSource = dt;
                DataTable dt1 = bUS_Static.SumPriceBillInputBetween(date.AddDays(-dem).ToString("yyyy-MM-dd 00:00:00"), time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien1.Text = item[0].ToString();
                }
                dayStar1.Text = date.AddDays(-dem).ToString("yyyy-MM-dd");
                dayEnd1.Text = time;
            }
            else
            {
                DataTable dt = bUS_Static.getBillInputBetween(time1, time);
                guna2DataGridView2.DataSource = dt;
                DataTable dt1 = bUS_Static.SumPriceBillInputBetween(time1, time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien1.Text = item[0].ToString();
                }
                dayStar1.Text = time1;
                dayEnd1.Text = time;
            }
        }
        // click bt tháng bill nhập nguyên liệu
        private void btThang1_Click(object sender, EventArgs e)
        {
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            if (date.Day != 1)
            {
                DataTable dt = bUS_Static.getBillInputBetween(date.ToString("yyyy-MM-01 00:00:00"), time);
                guna2DataGridView2.DataSource = dt;
                DataTable dt1 = bUS_Static.SumPriceBillInputBetween(date.ToString("yyyy-MM-01 00:00:00"), time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien1.Text = item[0].ToString();
                }
                dayStar1.Text = date.ToString("yyyy-MM-01");
                dayEnd1.Text = time;
            }
            else
            {
                DataTable dt = bUS_Static.getBillInputBetween(time1, time);
                guna2DataGridView2.DataSource = dt;
                DataTable dt1 = bUS_Static.SumPriceBillInputBetween(time1, time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien1.Text = item[0].ToString();
                }
                dayStar1.Text = time1;
                dayEnd1.Text = time;
            }
        }
        // click bt năm bill nhập nguyên liệu
        private void btNam1_Click(object sender, EventArgs e)
        {
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            DataTable dt = bUS_Static.getBillInputBetween(date.ToString("yyyy-01-01 00:00:00"), time);
            guna2DataGridView2.DataSource = dt;
            DataTable dt1 = bUS_Static.SumPriceBillInputBetween(date.ToString("yyyy-01-01 00:00:00"), time);
            foreach (DataRow item in dt1.Rows)
            {
                txtTongTien1.Text = item[0].ToString();
            }
            dayStar1.Text = date.ToString("yyyy-01-01");
            dayEnd1.Text = time;
        }
        // load danh thu tất cả 
        void LoadDanhThu()
        {
            DataTable dt = bUS_Static.getPrice();
            foreach (DataRow item in dt.Rows)
            {
                txtTienHoaDon.Text = item[0].ToString();
            }
            DataTable dt1 = bUS_Static.getSumPriceBillInput();
            foreach (DataRow item in dt1.Rows)
            {
                txtTienIngredient.Text = item[0].ToString();
            }
            foreach (DataRow item in dt.Rows)
            {
                foreach (DataRow item1 in dt1.Rows)
                {
                    txtDanhThu.Text = "" + (float.Parse(item[0].ToString()) - float.Parse(item1[0].ToString()));
                }
            }
        }
    }
}
