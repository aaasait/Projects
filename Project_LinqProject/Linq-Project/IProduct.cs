using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq_Project.List;

namespace Linq_Project
{
    public interface IProduct
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }

        public string Product_Description { get; set; }

        public double Product_Price { get; set; }

        public ProductCategory Product_Category { get; set; }

        public List<Address> Product_Address { get; set; }

        public DateTime Product_PublishDate { get; set; }

    }
}
