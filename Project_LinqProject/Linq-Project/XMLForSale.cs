using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Linq_Project
{
    public class XMLForSale
    {
        private string _name;
        private List<ForSale> _forSales;

        public XMLForSale(string name)
        {
            _name = name;
            _forSales = new List<ForSale> { };
        }

        public XMLForSale()
        {
            _name = "";
            _forSales = new List<ForSale> { };
        }

        [XmlAttribute("name")]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        [XmlArray("forSales")]
        [XmlArrayItem("ForSale")]
        public List<ForSale> ForSales
        {
            get
            {
                return _forSales;
            }

            set
            {
                _forSales = value;
            }
        }

    }
}
