using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_Bill
    {
        DAL_Bill dal_bill = new DAL_Bill();
        public int GetUncheckBill(int id)
        {
            return dal_bill.GetUncheckBill(id);
        }
        public double getSumPrice(int id_table)
        {
            return dal_bill.getSumPrice(id_table);
        }
    }
}
