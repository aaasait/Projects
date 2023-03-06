using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNwdProject.List
{
    public class Customer
    {

        public int CustomerID { get; set; }

        public string CompanyName { get; set; }

        public Customer(int customerID, string companyName)
        {
            CustomerID = customerID;
            CompanyName = companyName;
        }
    }
}
