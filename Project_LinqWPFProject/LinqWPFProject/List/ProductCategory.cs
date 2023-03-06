using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWPFProject.List
{
    public class ProductCategory : ICategory
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }

        public string Category_Description { get; set; }

        public ProductCategory() { }
        public ProductCategory(int category_ID, string category_Name, string category_Description)
        {
            Category_ID = category_ID;
            Category_Name = category_Name;
            Category_Description = category_Description;
        }
    }
}
