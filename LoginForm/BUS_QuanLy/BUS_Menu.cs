using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_Menu
    {
        DAL_Menu dal = new DAL_Menu();
        public DataTable getListMenu(int id_table)
        {
            return dal.getListMenu(id_table); 
        }
    }
}
