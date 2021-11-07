using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_NhanVien : DBConnect
    {
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LOGIN";
                cmd.Parameters.AddWithValue("EMAIL", nv.email);
                cmd.Parameters.AddWithValue("PASSWORD", nv.password);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
