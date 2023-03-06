using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LinqWPFProject
{
    public class IProduct
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
    }
}
