using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace XMLProject
{
    public class SerilizeDeserilize
    {
        /// <summary>
        /// This -> XMLDeserilize Method is Read XML file for entered data 
        /// </summary>
        /// <param name="path"></param>
        public void XMLDeserilize(string path)
        {
            try
            {
                string data = File.ReadAllText(path);
                XmlSerializer x = new XmlSerializer(typeof(ToyStore));
                ToyStore toyStore = (ToyStore)x.Deserialize(new StringReader(data));

                Console.WriteLine("Name: {0}", toyStore.Name);

                foreach (Toy toy in toyStore.Toys)
                {
                    Console.WriteLine(toy.Name);
                    Console.WriteLine("Id: {0}", toy.Id);
                    Console.WriteLine(new string('=', toy.Name.Length));
                    Console.WriteLine("Price: {0}", toy.Price);
                    Console.WriteLine("Suitable Age: {0}", toy.SuitableAge);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR MESSAGE : " + e.Message);
            }
        }

        /// <summary>
        /// This -> XMLSerilize Method is Create XML file for entered data 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dataCount"></param>
        public void XMLSerilize(string path,int dataCount)
        {
            try
            {
                ToyStore toyStore = new ToyStore("Toys R Us");

                
                for (int i = 0; i < dataCount; i++)
                {
                    Console.WriteLine("Toy Number "+(i+1)+" ");
                    int id = i + 1;
                    Console.WriteLine("Toy Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Toy Price ");
                    int price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Toy Suitable Age : ");
                    int suitableAge = Convert.ToInt32(Console.ReadLine());
                    toyStore.Toys.Add(new Toy(id,name, price, suitableAge));
                }

                
              
                XmlSerializer x = new XmlSerializer(typeof(ToyStore));
                //FileStream fs = new FileStream(path, FileMode.Append);
                FileStream fs = new FileStream(path, FileMode.Create);
                x.Serialize(fs, toyStore);
                fs.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR MESSAGE : " + e.Message);
            }
        }

        /// <summary>
        ///  This -> XMLSearch Method is Search XML file for entered data id
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id"></param>
        public void XMLSearch(string path,string id)
        {
            try
            {
                XDocument X = XDocument.Load(path);
                var searchID = X.Element("toyStore").Element("toys").Elements("toy").Where(E => E.Element("id").Value == id);

                foreach (var item in searchID)
                {
                    Console.WriteLine(String.Format("Name : {0}, Price : {1}, Suitable Age : {2} ", item.Element("name").Value, item.Element("price").Value, item.Element("suitableAge").Value));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR MESSAGE : " + e.Message);
            }
        }
    }
}
