using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;



namespace XMLProject
{
    public class Toy
    {
        private int _id;
        private string _name;
        private int _price;
        private int _suitableAge;

        public Toy(int id,string name, int price, int suitableAge)
        {
            _id = id;
            _name = name;
            _price = price;
            _suitableAge = suitableAge;
        }

        public Toy()
        {
            _id = -1;
            _name = "";
            _price = -1;
            _suitableAge = -1;
        }

        [XmlElement("id")]
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        [XmlElement("name")]
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

        [XmlElement("price")]
        public int Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        [XmlElement("suitableAge")]
        public int SuitableAge
        {
            get
            {
                return _suitableAge;
            }

            set
            {
                _suitableAge = value;
            }
        }
    }
}
