﻿using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_tables
    {
        DAL_tables Dal_tables = new DAL_tables();

        public List<DTO_tables> getTableList()
        {
            List<DTO_tables> tablelist = new List<DTO_tables>();

            DataTable data = Dal_tables.getData();
            foreach(DataRow row in data.Rows)
            {
                DTO_tables table = new DTO_tables(row);
                tablelist.Add(table);
            }

            return tablelist;
        }

        public DataTable getData()
        {
            return Dal_tables.getData();
        }
        public bool InsertDataTable(DTO_tables Tables)
        {
            return Dal_tables.InsertDataTable(Tables);
        }
        public bool UpdateDataTable(DTO_tables Tables)
        {
            return Dal_tables.UpdateDataTable(Tables);
        }
        public bool DeleteDataTable(int id)
        {
            return Dal_tables.DeleteDataTable(id);
        }
        public DataTable SearchTable(string name)
        {
            return Dal_tables.SearchTable(name);
        }
    }
}
