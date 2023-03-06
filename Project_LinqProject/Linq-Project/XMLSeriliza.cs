using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Linq_Project.List;

namespace Linq_Project
{
    public class XMLSeriliza
    {
       public XMLSeriliza() { }
       public void XMLSerilize(ForSale sale)
        {

            XMLForSale forXML = new XMLForSale();
     
            forXML.ForSales.Add(sale);


            string path = @"C:\Users\Z004PTKX\source\repos\xmlLinq.xml"; // XML Data path
            FileStream fs = new FileStream(path, FileMode.Append);
            XmlSerializer x = new XmlSerializer(typeof(XMLForSale));
            //FileStream fs = new FileStream(path, FileMode.Append);
            x.Serialize(fs, forXML);
            fs.Close();

            Console.WriteLine("Xml Successfully......");

        }

       
    }
}

