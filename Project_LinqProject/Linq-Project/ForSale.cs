using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Linq_Project.List;


namespace Linq_Project
{


    //[Serializable]
    //[XmlRoot("ForSale")]
    //[XmlType(TypeName = "ForSale")]
    public class ForSale: IProduct
    {

        private int ID;
        private string Name;
        private string Description;
        private double Price;
        private DateTime PublishDate;
        private ProductCategory Category;
        private List<Address> Address;
        private bool Swaps;


       // [XmlAttribute("ProductID")]
        [XmlElement(ElementName = "ProductID", Type = typeof(int))]
        public int Product_ID 
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        // [XmlAttribute("ProductName")]
        [XmlElement(elementName: "ProductName")]
        public string Product_Name 
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        // [XmlAttribute("ProductDescription")]
        [XmlElement(elementName: "ProductDescription")]
        public string Product_Description 
        {
            get
            {
                return Description;
            }
            set
            {
                Description = value;
            }
        }

        //[XmlAttribute("ProductPrice")]
        [XmlElement(elementName: "ProductPrice")]

        public double Product_Price
        {
            get
            {
                return Price;
            }
            set
            {
                Price = value;
            }
        }

        //[XmlAttribute("ProductPublishDate")]
        //[XmlAttribute("ProductPublishDate", Type = typeof(DateTime))]
        [XmlElement(elementName: "ProductPublishDate", Type = typeof(DateTime))]
        public DateTime Product_PublishDate
        {
            get
            {
                return PublishDate;
            }
            set
            {
                PublishDate = value;
            }
        }


        //[XmlAttribute("ProductCategory", Type = typeof(ProductCategory))]
        [XmlElement(elementName: "ProductCategory", Type = typeof(ProductCategory))]
        public ProductCategory Product_Category
        {
            get
            {
                return Category;
            }
            set
            {
                Category = value;
            }
        }

        // [XmlAttribute("ProductAddress", Type = typeof(List<Address>))]
        [XmlElement(elementName: "ProductAddress",Type = typeof(List<Address>))]
        public List<Address> Product_Address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
            }
        }


        // [XmlAttribute("ProductSwap")]
        [XmlElement(elementName: "ProductSwap", Type = typeof(bool))]
        public bool Swap
        {
            get
            {
                return Swaps;
            }
            set
            {
                Swaps = value;
            }
        }




        public ForSale()
        {

        }

        public ForSale(int product_ID, string product_Name, string product_Description, double product_Price, DateTime product_PublishDate, ProductCategory product_Category, List<Address> product_Address, bool swap)
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
