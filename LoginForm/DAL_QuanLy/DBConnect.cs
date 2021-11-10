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
<<<<<<< HEAD
        //protected SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString);

        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-KDN9D6V\SQLEXPRESS01;Initial Catalog=DuAnMot;Integrated Security=True");
=======

        protected SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString);

>>>>>>> 49b0d67c16c887fadd380e3d24ea1751a8ec9b9e
    }
}
