using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProjectDLL.List
{
    public class City
    {
        public int City_ID { get; set; }

        public string City_Name { get; set; }

        public City() { }

        public City(int city_ID, string city_Name)
        {
            City_ID = city_ID;
            City_Name = city_Name;
        }
    }
}
