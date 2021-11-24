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
            guna2DataGridView3.SendToBack();
            guna2DataGridView4.SendToBack();
            //btTuan3.SendToBack();
            //btTuan4.SendToBack();
            btThang3.SendToBack();
            btThang4.SendToBack();
            btNam3.SendToBack();
            btNam4.SendToBack();
            btEx1.SendToBack();
            btEx2.SendToBack();
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
            foreach (DataRow item in dt1.Rows)
            {
                txtTongTien.Text = item[0].ToString();
            }
        }
        DateTime dayNow = DateTime.Now;
        //Click bt tuần hóa đơn
        private void btTuan_Click(object sender, EventArgs e)
        {
            guna2DataGridView3.SendToBack();
            guna2DataGridView4.SendToBack();
            int dem;
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            //MessageBox.Show("" + date.AddDays(-6).ToString("yyyy-MM-dd 00:00:00"));
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                DataTable dt2 = bUS_Static.getDataBillDetailDayOfWeek(date.AddDays(-6).ToString("yyyy-MM-dd 00:00:01"), time);
                guna2DataGridView1.DataSource = dt2;
                foreach (DataRow item in dt2.Rows)
                {
                    if (item[1].ToString() == "")
                    {
                        item[1] = "0";
                    }
                }
                DataTable dt3 = bUS_Static.SumPriceDateTime(date.AddDays(-6).ToString("yyyy-MM-dd 00:00:00"), time);
                foreach (DataRow item in dt3.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = date.AddDays(-6).ToString("yyyy-MM-dd");
                dayEnd.Text = time;
            }
            if (date.DayOfWeek != DayOfWeek.Monday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                dem = date.DayOfWeek - DayOfWeek.Monday;
                DataTable dt = bUS_Static.getDataBillDetailDayOfWeek(date.AddDays(-dem).ToString("yyyy-MM-dd 00:00:01"), time);
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
            if (date.DayOfWeek == DayOfWeek.Monday)
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
            guna2DataGridView3.SendToBack();
            guna2DataGridView4.SendToBack();
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
            guna2DataGridView3.SendToBack();
            guna2DataGridView4.SendToBack();
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
        // thồng kê nhân viên, khách hàng
        bool perform1 = false;
        private void btTK_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.SendToBack();
            //btEx.SendToBack();
            if (perform1 == false)
            {
                //btTuan.SendToBack();
                //btTuan4.SendToBack();
                btThang.SendToBack();
                btThang4.SendToBack();
                btNam.SendToBack();
                btNam4.SendToBack();
                guna2DataGridView4.SendToBack();
                btEx2.SendToBack();
                DataTable dt = bUS_Static.StaticEmployee();
                guna2DataGridView3.DataSource = dt;
                guna2DataGridView3.Columns[0].HeaderText = "Mã nhân viên";
                guna2DataGridView3.Columns[1].HeaderText = "Số lượng hóa đơn";
                guna2DataGridView3.Columns[2].HeaderText = "Tổng tiền hóa đơn";
                btTK.Text = "Nhân viên";
                perform1 = true;
            }
            else
            {
                //btTuan.SendToBack();
                //btTuan3.SendToBack();
                btThang.SendToBack();
                btThang3.SendToBack();
                btNam.SendToBack();
                btNam3.SendToBack();
                guna2DataGridView3.SendToBack();
                btEx1.SendToBack();
                DataTable dt = bUS_Static.StaticCustomer();
                guna2DataGridView4.DataSource = dt;
                guna2DataGridView4.Columns[0].HeaderText = "Mã khách hàng";
                guna2DataGridView4.Columns[1].HeaderText = "Số lượng sản phẩm";
                guna2DataGridView4.Columns[2].HeaderText = "Tổng tiền hóa đơn";
                btTK.Text = "Khách hàng";
                perform1 = false;
            }
            DataTable dt1 = bUS_Static.getPrice();
            foreach (DataRow item in dt1.Rows)
            {
                txtTongTien.Text = item[0].ToString() + " VND";
            }
        }
        // thống kê nhân viên theo tháng
        private void btThang3_Click(object sender, EventArgs e)
        {
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            if (date.Day != 1)
            {
                DataTable dt = bUS_Static.StaticEmployeeWeek(date.ToString("yyyy-MM-01 00:00:00"), time);
                guna2DataGridView3.DataSource = dt;
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
                DataTable dt = bUS_Static.StaticEmployeeWeek(time1, time);
                guna2DataGridView3.DataSource = dt;
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
        // thống kê khách hàng theo tháng
        private void btThang4_Click(object sender, EventArgs e)
        {
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            if (date.Day != 1)
            {
                DataTable dt = bUS_Static.StaticCustomerWeek(date.ToString("yyyy-MM-01 00:00:00"), time);
                guna2DataGridView4.DataSource = dt;
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
                DataTable dt = bUS_Static.StaticCustomerWeek(time1, time);
                guna2DataGridView4.DataSource = dt;
                DataTable dt1 = bUS_Static.SumPriceDateTime(time1, time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = time1;
                dayEnd.Text = time;
            }
        }
        // thống kê nhân viên theo năm
        private void btNam3_Click(object sender, EventArgs e)
        {
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            DataTable dt = bUS_Static.StaticEmployeeWeek(date.ToString("yyyy-01-01 00:00:00"), time);
            guna2DataGridView3.DataSource = dt;
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
        // thống kê khách hàng theo năm
        private void btNam4_Click(object sender, EventArgs e)
        {
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            DataTable dt = bUS_Static.StaticCustomerWeek(date.ToString("yyyy-01-01 00:00:00"), time);
            guna2DataGridView4.DataSource = dt;
            DataTable dt1 = bUS_Static.SumPriceDateTime(date.ToString("yyyy-01-01 00:00:00"), time);
            foreach (DataRow item in dt1.Rows)
            {
                txtTongTien.Text = item[0].ToString();
            }
            dayStart.Text = date.ToString("yyyy-01-01");
            dayEnd.Text = time;
        }
        // thống kê nhân viên theo tuần
        private void btTuan3_Click_1(object sender, EventArgs e)
        {
            int dem;
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            MessageBox.Show("" + date.AddDays(-6).ToString("yyyy-MM-dd 00:00:00"));
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                DataTable dt2 = bUS_Static.StaticEmployeeWeek(date.AddDays(-6).ToString("yyyy-MM-dd 00:00:01"), time);
                guna2DataGridView3.DataSource = dt2;
                foreach (DataRow item in dt2.Rows)
                {
                    if (item[1].ToString() == "")
                    {
                        item[1] = "0";
                    }
                }
                DataTable dt3 = bUS_Static.SumPriceDateTime(date.AddDays(-6).ToString("yyyy-MM-dd 00:00:00"), time);
                foreach (DataRow item in dt3.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = date.AddDays(-6).ToString("yyyy-MM-dd");
                dayEnd.Text = time;
            }
            if (date.DayOfWeek != DayOfWeek.Monday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                dem = date.DayOfWeek - DayOfWeek.Monday;
                DataTable dt = bUS_Static.StaticEmployeeWeek(date.AddDays(-dem).ToString("yyyy-MM-dd 00:00:01"), time);
                guna2DataGridView3.DataSource = dt;
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
            if (date.DayOfWeek == DayOfWeek.Monday)
            {
                DataTable dt = bUS_Static.StaticEmployeeWeek(time1, time);
                guna2DataGridView3.DataSource = dt;
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
        // thống kê khách hàng theo tuần
        private void btTuan4_Click_1(object sender, EventArgs e)
        {
            int dem;
            string time = dayNow.ToString("yyyy-MM-dd 23:59:59");
            string time1 = dayNow.ToString("yyyy-MM-dd 00:00:00");
            DateTime date = new DateTime(DateTime.Parse(time).Year, DateTime.Parse(time).Month, DateTime.Parse(time).Day);
            //MessageBox.Show("" + date.AddDays(-6).ToString("yyyy-MM-dd 00:00:00"));
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                DataTable dt2 = bUS_Static.StaticCustomerWeek(date.AddDays(-6).ToString("yyyy-MM-dd 00:00:01"), time);
                guna2DataGridView4.DataSource = dt2;
                DataTable dt3 = bUS_Static.SumPriceDateTime(date.AddDays(-6).ToString("yyyy-MM-dd 00:00:00"), time);
                foreach (DataRow item in dt3.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = date.AddDays(-6).ToString("yyyy-MM-dd");
                dayEnd.Text = time;
            }
            if (date.DayOfWeek != DayOfWeek.Monday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                dem = date.DayOfWeek - DayOfWeek.Monday;
                DataTable dt = bUS_Static.StaticCustomerWeek(date.AddDays(-dem).ToString("yyyy-MM-dd 00:00:01"), time);
                guna2DataGridView4.DataSource = dt;
                DataTable dt1 = bUS_Static.SumPriceDateTime(date.AddDays(-dem).ToString("yyyy-MM-dd 00:00:00"), time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = date.AddDays(-dem).ToString("yyyy-MM-dd");
                dayEnd.Text = time;
            }
            if (date.DayOfWeek == DayOfWeek.Monday)
            {
                DataTable dt = bUS_Static.StaticCustomerWeek(time1, time);
                guna2DataGridView4.DataSource = dt;
                DataTable dt1 = bUS_Static.SumPriceDateTime(time1, time);
                foreach (DataRow item in dt1.Rows)
                {
                    txtTongTien.Text = item[0].ToString();
                }
                dayStart.Text = time1;
                dayEnd.Text = time;
            }
        }
        // Xuất excel hóa đơn chi tiết
        private void btEx_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)guna2DataGridView1.DataSource;
            Export(dt, "Danh sach", "DANH SÁCH HÓA ĐƠN");
        }
        // xuất excel hóa đơn theo khách hàng
        private void btEx2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)guna2DataGridView4.DataSource;
            Export2(dt, "Danh sach", "DANH SÁCH HÓA ĐƠN THEO KHÁCH HÀNG");
        }
        // xuất excel hóa đơn theo nhân viên
        private void btEx1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)guna2DataGridView3.DataSource;
            Export1(dt, "Danh sach", "DANH SÁCH HÓA ĐƠN THEO NHÂN VIÊN");
        }
        public void Export(DataTable dt, string sheetName, string title)
        {

            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "18";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã nhân viên";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã khách hàng";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Mã bill";

            cl3.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Mã bàn";

            cl4.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Tổng tiền";

            cl5.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Ngày tạo";

            cl6.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Ngày xuất";

            cl7.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "G3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int r = 0; r < dt.Rows.Count; r++)

            {

                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;

            int columnEnd = dt.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        public void Export1(DataTable dt, string sheetName, string title)
        {

            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "18";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã nhân viên";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Số lượng hóa đơn";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Tổng tiền hóa đơn";

            cl3.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "C3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int r = 0; r < dt.Rows.Count; r++)

            {

                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;

            int columnEnd = dt.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        public void Export2(DataTable dt, string sheetName, string title)
        {

            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "18";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã khách hàng";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Số lượng sản phẩm";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Tổng tiền hóa đơn";

            cl3.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "C3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int r = 0; r < dt.Rows.Count; r++)

            {

                DataRow dr = dt.Rows[r];

                for (int c = 0; c < dt.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;

            int columnEnd = dt.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
    }
}
