using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_Bill_Detail:DBConnect
    {
        public DataTable GetListBillDetail(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getListBillDetail";
                cmd.Parameters.AddWithValue("IDBill", id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
