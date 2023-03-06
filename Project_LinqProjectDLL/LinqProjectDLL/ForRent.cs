using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LinqProjectDLL.List;


namespace LinqProjectDLL
{
 
        public enum RentKind
        {
            Day = 0,
            Week = 1,
            Month = 2,
        }


        public class ForRent : IProduct
        {
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public string Product_Description { get; set; }
            public double Product_Price { get; set; }
            public DateTime Product_PublishDate { get; set; }
            public ProductCategory Product_Category { get; set; }
            public List<Address> Product_Address { get; set; }

            public RentKind rentKind { get; set; }

            public ForRent() { }

            public ForRent(int product_ID, string product_Name, string product_Description, double product_Price, DateTime product_PublishDate, ProductCategory product_Category, List<Address> product_Address, RentKind rentKind)
            {
                Product_ID = product_ID;
                Product_Name = product_Name;
                Product_Description = product_Description;
                Product_Price = product_Price;
                Product_PublishDate = product_PublishDate;
                Product_Category = product_Category;
                Product_Address = product_Address;
                this.rentKind = rentKind;
            }
        }
    
}
