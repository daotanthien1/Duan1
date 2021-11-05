using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DBConnect
    {
        //static string constr = ConfigurationManager.ConnectionStrings["QLBH"].ToString();
        //protected SqlConnection _conn = new SqlConnection(constr);
        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-KDN9D6V\SQLEXPRESS01;Initial Catalog=DuAn1;Integrated Security=True");
    }
}
