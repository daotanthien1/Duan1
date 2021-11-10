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

        //protected SqlConnection _conn = new SqlConnection(
        //@"Data Source = LAPTOP-1IIUP3CK\TANTHIEN; Initial Catalog = QLBANHANG ; Integrated Security = True");
        protected SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH"].ConnectionString);

    }
}
