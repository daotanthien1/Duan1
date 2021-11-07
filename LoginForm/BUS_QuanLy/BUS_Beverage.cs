﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_Beverage
    {
        DAL_QuanLyDoUong quanLyDoUong = new DAL_QuanLyDoUong();
        public bool InsertDoUong(DTO_QuanLyDoUong ql)
        {
            return quanLyDoUong.InsertDoUong(ql);
        }
        public bool UpdateDoUong(DTO_QuanLyDoUong ql)
        {
            return quanLyDoUong.UpdateDoUong(ql);
        }
        public bool DeleteDoUong(string name)
        {
            return quanLyDoUong.DeleteDoUong(name);
        }
        public DataTable SearchDoUong(string name)
        {
            return quanLyDoUong.SearchDoUong(name);
        }
    }
}
