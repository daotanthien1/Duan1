﻿using Guna.UI2.WinForms;
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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        private void moveImage(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imageSlide.Location = new Point(b.Location.X + 150, b.Location.Y - 31);
            imageSlide.SendToBack();
        }
        private void bt1_CheckedChanged(object sender, EventArgs e)
        {
            moveImage(sender);
            if (bt1.Checked)
            {
                uC_Customer1.BringToFront();
            }
            if (bt2.Checked)
            {
                uC_Table1.BringToFront();
            }
        }
    }
}