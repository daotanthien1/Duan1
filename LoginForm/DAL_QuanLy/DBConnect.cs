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
        //protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-2V5F3CA\TUNGNH230802;Initial Catalog=D:\database\DUAN1.MDF;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-K814DG0\NHATVINH;Initial Catalog=DuAn1;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
        //Data Source=DESKTOP-2V5F3CA\TUNGNH230802;Initial Catalog=D:\database\DUAN1.MDF;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False
    }
}
