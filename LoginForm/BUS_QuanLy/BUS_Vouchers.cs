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
    public class BUS_Vouchers
    {
        DAL_Vouchers vouchers = new DAL_Vouchers();
        public DataTable getSale()
        {
            return vouchers.getSale();
        }
        public DataTable getData()
        {
            return vouchers.getData();
        }
        public bool InsertDatevoucher(DTO_Vouchers voucher)
        {
            return vouchers.InsertDatevoucher(voucher);
        }
        public DataTable searchDataVoucher(int id)
        {
            return vouchers.searchDataVoucher(id);
        }
        public DataTable getCountSaleVoucher(int id)
        {
            return vouchers.getCountSaleVoucher(id);
        }
        public bool deleteVoucher(string id)
        {
            return vouchers.deleteVoucher(id);
        }
    }
}
