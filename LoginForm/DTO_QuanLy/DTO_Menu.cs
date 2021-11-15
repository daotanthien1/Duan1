using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Menu
    {
        public DTO_Menu(DataRow rows)
        {
            this.beverageName = rows["name"].ToString();
            this.quantity = (int)rows["quantity"];
            this.price = (int)Convert.ToDouble(rows["Price"].ToString());
            this.totalPrice = (int)Convert.ToDouble(rows["totalPrice"].ToString()); 
        }
        public DTO_Menu(string beverageName, int quantity, float price, float totalPrice = 0)
        {
            this.beverageName = beverageName;
            this.quantity = quantity;
            this.price = price;
            this.totalPrice = totalPrice;
        }

        public string beverageName {get;set;}
        public int quantity { get; set; }
        public float price { get; set; }
        public float totalPrice { get; set; }
    }
}
