using Linq_Project.List;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Linq_Project.List;

namespace Linq_Project
{
    [XmlRoot("ForSale")]
    public class ForSale2
    {

        [XmlAttribute("ProductID")]
        public int Product_ID { get; set; }

        [XmlElement("ProductName")]
        public string Product_Name { get; set; }

        [XmlElement("ProductDescription")]
        public string Product_Description { get; set; }

        [XmlElement("ProductPrice")]
        public double Product_Price { get; set; }

        //[XmlIgnore]
        [XmlElement("ProductPublishDate")]     
        public DateTime Product_PublishDate { get; set; }


        [XmlElement("ProductCategory")]
        public ProductCategory Product_Category { get; set; }

        [XmlArray("ProductAddresses")]
        [XmlArrayItem("ProductAddress")]
        public List<Address> Product_Address { get; set; }

        [XmlElement("Swap")]
        public bool Swap { get; set; }




        public ForSale2()
        {

        }

        public ForSale2(int product_ID, string product_Name, string product_Description, double product_Price, DateTime product_PublishDate, ProductCategory product_Category, List<Address> product_Address, bool swap)
        {
            Product_ID = product_ID;
            Product_Name = product_Name;
            Product_Description = product_Description;
            Product_Price = product_Price;
            Product_PublishDate = product_PublishDate;
            Product_Category = product_Category;
            Product_Address = product_Address;
            Swap = swap;
        }
    }
}
