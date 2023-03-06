using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProjectDLL.List
{
    public class Address
    {
        public int Address_ID { get; set; }
        public string Address_Name { get; set; }

        public Country Address_Country { get; set; }
        public City Address_City { get; set; }
        public string Address1 { get; set; }
        public Address() { }

        public Address(int address_ID, string address_Name, Country address_Country, City address_City, string address1)
        {
            Address_ID = address_ID;
            Address_Name = address_Name;
            Address_Country = address_Country;
            Address_City = address_City;
            Address1 = address1;
        }
    }
}
