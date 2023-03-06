using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Project.List
{
    public class Country
    {
        public int Country_ID { get; set; }

        public string Country_Name { get; set; }

        public Country() { }

        public Country(int country_ID, string country_Name)
        {
            Country_ID = country_ID;
            Country_Name = country_Name;
        }
    }
}
