using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLProject;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLProject
{
    [XmlRoot("toyStore")]
    public class ToyStore
    {
        private string _name;
        private List<Toy> _toys;

        public ToyStore(string name)
        {
            _name = name;
            _toys = new List<Toy> { };
        }

        public ToyStore()
        {
            _name = "";
            _toys = new List<Toy> { };
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

        [XmlArray("toys")]
        [XmlArrayItem("toy")]
        public List<Toy> Toys
        {
            get
            {
                return _toys;
            }

            set
            {
                _toys = value;
            }
        }
    }
}
