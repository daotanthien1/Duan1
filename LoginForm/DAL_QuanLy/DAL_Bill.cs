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
    /// <summary>
    /// thành công: bill id
    /// thất bại:-1
    /// </summary>
    public class DAL_Bill:DBConnect
    {
        public int GetUncheckBill(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getUncheckBill";
                cmd.Parameters.AddWithValue("ID_table", id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                if(dt.Rows.Count >0)
                {
                    DTO_Bill bill = new DTO_Bill(dt.Rows[0]);
                    return bill.Id;
                }
                else
                {
                    return -1;
                }
            }
            finally
            {
                _conn.Close();
            }
        }

        public double getSumPrice(int id_table)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getSumprice";
                cmd.Parameters.AddWithValue("ID_table", id_table);
                return Convert.ToDouble(cmd.ExecuteScalar());      
            }
            catch
            {
                return 0;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
