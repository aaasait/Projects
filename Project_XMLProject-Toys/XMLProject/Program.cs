using System.Xml.Serialization;
using XMLProject;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Schema;
using System;
using System.Reflection.PortableExecutable;
using System.Diagnostics;
using System.Xml.Linq;


public class XMLWrite  
{  
  
   static void Main(string[] args)  
    {
        
        Console.WriteLine("***** WELCOME TO XML *****");
        string _path = @"C:\Users\Z004PTKX\source\repos\xc.xml"; // XML Data path

        SerilizeDeserilize sd=new SerilizeDeserilize();

        // XML Arama işlemlerinde XQuery kullanılır. NOT

        /// <summary>
        /// Enter Data and main page(include process kind)
        /// </summary>

        try
        {
            while (true)

            {
                Console.WriteLine("SELECT PROCESS\n" +
                    "1) XML Write\n" +
                    "2) XML Read\n"+
                    "3) XML Search\n");
                Console.WriteLine("Do you want to XML Data Process (y/n) ");
                string s = Console.ReadLine();
                if (s.Equals("y") || s.Equals("Y"))
                {
                    Console.WriteLine("Please Enter Process Kind (1/2/3) : ");
                    int data = Convert.ToInt32(Console.ReadLine());
                    switch (data)
                    {

                        case 1:
                            Console.WriteLine("Please Enter Data Count : ");
                            int dataCount = Convert.ToInt32(Console.ReadLine());
                            sd.XMLSerilize(_path,dataCount);
                            break;
                        case 2:
                            sd.XMLDeserilize(_path);
                            break;
                        case 3:
                            Console.WriteLine("Enter Search Id : ");
                            string search_id = Console.ReadLine();
                            sd.XMLSearch(_path, search_id);
                            break;
                        default:
                            Console.WriteLine("INVALID OPERATION..");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("EXIT..");
                    break;
                }


            }
        }
        catch (Exception e)
        {

            Console.WriteLine("ERROR MESSAGE : " + e.Message);
        }
        finally
        {
            Console.ReadKey();
        }
    }



}
