using LinqProjectDLL.List;
using LinqProjectDLL;
using System;
using System.Xml.Serialization;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        #region Category 

        List<ProductCategory> ProductCategories = new List<ProductCategory>() {
        new ProductCategory{Category_ID=1,Category_Name="Home",Category_Description="Home"},
        new ProductCategory{Category_ID=2,Category_Name="Garden",Category_Description="Garden"},
        new ProductCategory{Category_ID=3,Category_Name="Kitchen",Category_Description="Kitchen"},
        new ProductCategory{Category_ID=4,Category_Name="Electronic",Category_Description="Electronic"},
        new ProductCategory{Category_ID=5,Category_Name="Textile",Category_Description="Textile"},
        new ProductCategory{Category_ID=6,Category_Name="Car",Category_Description="Car"}
        };

        #endregion

        #region Address (Country- City)
        // Country List
        List<Country> Countries = new List<Country>() {
        new Country{Country_ID=1,Country_Name="Türkiye"},
        new Country{Country_ID=2,Country_Name="Germany"}
        };
        // City List
        List<City> Cities = new List<City>() {
        new City{City_ID=1,City_Name="Adana"},
        new City{City_ID=2,City_Name="Adıyaman"},
        new City{City_ID=7,City_Name="Antalya"},
        new City{City_ID=34,City_Name="Istanbul"},
        new City{City_ID=35,City_Name="Izmir"},
        new City{City_ID=6,City_Name="Ankara"},
        new City{City_ID=23,City_Name="Elazığ"},
        new City{City_ID=16,City_Name="Bursa"},
        new City{City_ID=32,City_Name="Afyon"},
        new City{City_ID=44,City_Name="Malatya"}
        };

        List<Address> Addresses1 = new List<Address>() {
         new Address{Address_ID=1,Address_Name="Office",Address_Country=Countries[0], Address_City=Cities[3] ,Address1="Bayram Street No:23"},
         new Address{Address_ID=2,Address_Name="Home",Address_Country=Countries[0], Address_City=Cities[3] ,Address1="Londra Street No:44"},

        };
        List<Address> Addresses2 = new List<Address>() {
         new Address{Address_ID=1,Address_Name="Office",Address_Country=Countries[0], Address_City=Cities[2] ,Address1="Ordu Street No:16"},
         new Address{Address_ID=2,Address_Name="Home",Address_Country=Countries[0], Address_City=Cities[2] ,Address1="PiyalePaşa Street No:55"},
        };

        List<Address> Addresses3 = new List<Address>() {
         new Address{Address_ID=1,Address_Name="Office",Address_Country=Countries[0], Address_City=Cities[3] ,Address1="Topkapi Street No:205"},
         new Address{Address_ID=2,Address_Name="Home",Address_Country=Countries[0], Address_City=Cities[3] ,Address1="Nurtepe Street No:77"},
        };
        #endregion

        #region  Sales DATA 1  

        List<ForSale> Sales = new List<ForSale>() {
        new ForSale{Product_ID=1,Product_Name="Telephone IPHONE",Product_Description="Clean phone 16 GB ",Product_Price=850.0,Product_PublishDate=new DateTime(2010,1,2),Product_Category=ProductCategories[3],Product_Address=Addresses1,Swap= true},
        new ForSale{Product_ID=2,Product_Name="Home Table ENGLİSH HOME",Product_Description=" 6 personality ",Product_Price=500.9,Product_PublishDate=new DateTime(2011,2,12),Product_Category=ProductCategories[0],Product_Address=Addresses1,Swap= false},
        new ForSale{Product_ID=3,Product_Name="Kitchen Carpet MERINOS",Product_Description=" Area(cm) 200x200 ",Product_Price=149.8,Product_PublishDate=new DateTime(2020,9,3),Product_Category=ProductCategories[2],Product_Address=Addresses1,Swap= false},
        new ForSale{Product_ID=4,Product_Name="T-Shirt Lacoste",Product_Description=" New Small Size",Product_Price=850.0,Product_PublishDate=new DateTime(2020,11,25),Product_Category=ProductCategories[4],Product_Address=Addresses1,Swap= false},
        new ForSale{Product_ID=5,Product_Name="TV Samsung",Product_Description=" Very Clean + Netflix  ",Product_Price=1200.0,Product_PublishDate=new DateTime(2021,5,23),Product_Category=ProductCategories[3],Product_Address=Addresses1,Swap= true},
        new ForSale{Product_ID=6,Product_Name="HP Laptop",Product_Description=" 16 GB Ram 500 GB SSD ",Product_Price=1600.0,Product_PublishDate=new DateTime(2022,1,27),Product_Category=ProductCategories[3],Product_Address=Addresses1,Swap= true},

        new ForSale{Product_ID=7,Product_Name="Honda CRV Suv",Product_Description=" 120000 Km + Navigation ",Product_Price=7500.1,Product_PublishDate=new DateTime(2019,6,7),Product_Category=ProductCategories[5],Product_Address=Addresses1,Swap= true},
        new ForSale{Product_ID=8,Product_Name="Tablecloth Pierre Cardin",Product_Description=" 200x300 cm Rectangle  ",Product_Price=75.9,Product_PublishDate=new DateTime(2017,3,20),Product_Category=ProductCategories[2],Product_Address=Addresses1,Swap= false},
        new ForSale{Product_ID=9,Product_Name="Towel Pink",Product_Description=" Big Size ",Product_Price=29.9,Product_PublishDate=new DateTime(2023,1,1),Product_Category=ProductCategories[4],Product_Address=Addresses1,Swap= false},
        new ForSale{Product_ID=10,Product_Name="Toyota Corolla",Product_Description=" 2020 Model 13000 Mile ",Product_Price=11550.2,Product_PublishDate=new DateTime(2021,9,11),Product_Category=ProductCategories[5],Product_Address=Addresses1,Swap= false},
        new ForSale{Product_ID=11,Product_Name="Plastation 4 ",Product_Description=" Gift 2 Games ",Product_Price=999.0,Product_PublishDate=new DateTime(2022,9,13),Product_Category=ProductCategories[3],Product_Address=Addresses1,Swap= false},
        new ForSale{Product_ID=12,Product_Name=" Garden Armchair ",Product_Description=" 4 piece ",Product_Price=255.0,Product_PublishDate=new DateTime(2023,1,10),Product_Category=ProductCategories[1],Product_Address=Addresses1,Swap= false},

        };

        #endregion

        #region  Rent DATA 1

        List<ForRent> Rents = new List<ForRent>() {
        new ForRent{Product_ID=1,Product_Name="Telephone HUAWEI",Product_Description="Clean phone 16 GB ",Product_Price=110.0,Product_PublishDate=new DateTime(2010,1,2),Product_Category=ProductCategories[3],Product_Address=Addresses1,rentKind=RentKind.Week},
        new ForRent{Product_ID=2,Product_Name="Home Table IKEA",Product_Description=" 6 personality ",Product_Price=269.9,Product_PublishDate=new DateTime(2011,2,12),Product_Category=ProductCategories[0],Product_Address=Addresses1,rentKind=RentKind.Week},
        new ForRent{Product_ID=3,Product_Name="Kitchen Carpet BAHOUSE",Product_Description=" Area(cm) 200x200 ",Product_Price=49.8,Product_PublishDate=new DateTime(2020,9,3),Product_Category=ProductCategories[2],Product_Address=Addresses1,rentKind=RentKind.Day},
        new ForRent{Product_ID=4,Product_Name="T-Shirt Polo",Product_Description=" New Small Size",Product_Price=7.0,Product_PublishDate=new DateTime(2020,11,25),Product_Category=ProductCategories[4],Product_Address=Addresses1,rentKind=RentKind.Day},
        new ForRent{Product_ID=5,Product_Name="TV Apple",Product_Description=" Very Clean + Disney+  ",Product_Price=459.2,Product_PublishDate=new DateTime(2021,5,23),Product_Category=ProductCategories[3],Product_Address=Addresses1,rentKind=RentKind.Week},
        new ForRent{Product_ID=6,Product_Name="Casper Laptop",Product_Description=" 16 GB Ram 500 GB SSD ",Product_Price=101.0,Product_PublishDate=new DateTime(2022,1,27),Product_Category=ProductCategories[3],Product_Address=Addresses1,rentKind=RentKind.Month},

        new ForRent{Product_ID=7,Product_Name="Dodge Challenger 3.5 Turbo",Product_Description=" 89000 Km + Carplay ",Product_Price=500.0,Product_PublishDate=new DateTime(2019,6,7),Product_Category=ProductCategories[5],Product_Address=Addresses1,rentKind=RentKind.Day},
        new ForRent{Product_ID=8,Product_Name="Tablecloth H&M ",Product_Description=" 350x350 cm Square  ",Product_Price=5.9,Product_PublishDate=new DateTime(2017,3,20),Product_Category=ProductCategories[2],Product_Address=Addresses1,rentKind=RentKind.Week},
        new ForRent{Product_ID=9,Product_Name="Towel Black",Product_Description=" Medium Size ",Product_Price=9.9,Product_PublishDate=new DateTime(2023,1,1),Product_Category=ProductCategories[4],Product_Address=Addresses1,rentKind=RentKind.Week},
        new ForRent{Product_ID=10,Product_Name="Lexus LXC ",Product_Description=" 2013 Model 18000 Mile ",Product_Price=950.2,Product_PublishDate=new DateTime(2021,9,11),Product_Category=ProductCategories[5],Product_Address=Addresses1,rentKind=RentKind.Month},
        new ForRent{Product_ID=11,Product_Name="XBOX 3 ",Product_Description=" Gift 4 Games ",Product_Price=250.0,Product_PublishDate=new DateTime(2022,9,13),Product_Category=ProductCategories[3],Product_Address=Addresses1,rentKind=RentKind.Week},
        new ForRent{Product_ID=12,Product_Name=" Garden Stone ",Product_Description=" 10 piece stone ",Product_Price=25.0,Product_PublishDate=new DateTime(2023,1,10),Product_Category=ProductCategories[1],Product_Address=Addresses1,rentKind=RentKind.Day},

        };


        #endregion

        #region Serialize SUCCESSFULLY
        // Bin/ Debug Serialize  oldu.
        var serializer = new XmlSerializer(typeof(List<ForSale>));
        using (var writer = new StreamWriter("forSales.xml"))
        {
            serializer.Serialize(writer, Sales);
        }


        Console.WriteLine("/*/*/*/*/*/*/*/*/*/*/*--SUCCESSFULLY--/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*//*");


        #endregion

        #region LINQ QUERY 1 => Sale-True Satılık Durumu Kontrol

        Console.WriteLine("---LINQ QUERY 1------");

        var q1 = Sales.Where(x => (x.Swap == true));
        foreach (var item in q1)
        {
            Console.WriteLine(" Product Name : " + item.Product_Name + " - " + " Price : " + item.Product_Price + "$" + " - " + " Swap State :" + item.Swap);
        }

        #endregion

        #region LINQ QUERY 2 => RentKind-(Enum) Kiralık Türü(Day-Week-Month) Durumu Kontrol

        Console.WriteLine("---LINQ QUERY 2------");

        var q2 = Rents.Select(r =>
                                      new
                                      {
                                          Rent_ID = r.Product_ID,
                                          ProductNameDescription = r.Product_Name + " / " + r.Product_Description,
                                          RentKinds = r.rentKind
                                      });

        foreach (var item in q2)
        {
            Console.WriteLine(item.Rent_ID + " / " + item.ProductNameDescription + " / " + item.RentKinds);
        }

        #endregion

        #region LINQ QUERY 3 =>  Join Birleştirme

        Console.WriteLine("---LINQ QUERY 3------");
        Console.WriteLine("Sales Name and Rent Kind (JOIN) ");
        var q3 = from sales1 in Sales
                 join rents1 in Rents
                     on sales1.Product_ID equals rents1.Product_ID
                 select new
                 {
                     Sales_Name = sales1.Product_Name,
                     Rent_Kind = rents1.rentKind
                 };
        foreach (var item in q3)
        {
            Console.WriteLine("Sales Name: {0} Rent Kind: {1}", item.Sales_Name, item.Rent_Kind);
        }

        #endregion

        #region LINQ QUERY 4 => Sort OrderBy Query - Sıralama ASC ARTAN

        Console.WriteLine("---LINQ QUERY 4------");
        Console.WriteLine("With Date (ORDER BY) ");

        var sortedByDate = Rents.OrderBy(prices => prices.Product_PublishDate);

        foreach (var item in sortedByDate)
        {
            Console.WriteLine("Product Name : " + item.Product_Name + " / " + "Sorted Date : " + item.Product_PublishDate);
        }

        #endregion

        #region LINQ QUERY 5 => Search in Product Name Query with CONTAINS 

        Console.WriteLine("---LINQ QUERY 5------");
        Console.WriteLine("Rent - Search in Product Name  (CONTAINS) - (Table) ");

        var rentSearchName = Rents.Where(search => search.Product_Name.Contains("Table"));


        foreach (var item in rentSearchName)
        {
            Console.WriteLine("ID : " + item.Product_ID + " - NAME " + item.Product_Name + " - PRICE " + item.Product_Price + " - RENT KIND : " + item.rentKind);
        }

        #endregion

        #region LINQ QUERY 6 => Rounding  (Math Round) Fiyat Yuvarlama

        Console.WriteLine("---LINQ QUERY 6------");
        Console.WriteLine(" Rent - Rounding  (Math Round)");

        var q6 = Rents.Select(s => new
        {
            ID = s.Product_ID,
            Name = s.Product_Name,
            RoundUpperPrice = Math.Round(s.Product_Price)
        })
  .OrderByDescending(x => x.ID)
  .Take(Rents.Count)
  .OrderBy(x => x.RoundUpperPrice);


        foreach (var item in q6)
        {
            Console.WriteLine("ID : " + item.ID + " //  Rent Price Rounded Upper : " + item.RoundUpperPrice);
        }
        #endregion

        #region LINQ QUERY 7 => Cross Join Çapraz Birleştirme


        Console.WriteLine("---LINQ QUERY 7------");
        Console.WriteLine(" Sales  - Cross Join  (Cross Join)");

        var q7 = Sales.Join(Rents, sales1 => sales1.Product_ID, rents1 => rents1.Product_ID, (sales1, rents1) => new {

            SalesID = sales1.Product_ID,
            SalesName = sales1.Product_Name,
            SalesSwap = sales1.Swap,
            RentsKind = rents1.rentKind

        });

        foreach (var item in q7)
        {
            Console.WriteLine("ID = {0}, Sales Name = {1}, Sales Swap = {2}, Rent Kind = {3}", item.SalesID, item.SalesName, item.SalesSwap, item.RentsKind);
        }


        #endregion

        #region LINQ QUERY 8 => SkipWhile 3 e bölünebilen ilk elemandan başlayarak tüm elemanları yazdırır


        Console.WriteLine("---LINQ QUERY 8------");
        Console.WriteLine("Rents - ID with Mod2  - Skip While (SkipWhile)");

        var q8 = Rents.SkipWhile(n => n.Product_ID % 3 != 0);
        foreach (var item in q8)
        {
            Console.WriteLine("ID : " + item.Product_ID + " / " + " Rents Name : " + item.Product_Name);
        }

        #endregion

        #region LINQ QUERY 9 => Sum Toplam 


        Console.WriteLine("---LINQ QUERY 9------");
        Console.WriteLine("Sales - Price with Category - Sum (SUM)");

        var q9 = Sales.Sum(sums => (sums.Product_Price));
        Console.WriteLine("Sum Price : " + q9);


        #endregion

        #region LINQ QUERY 10 => Count Toplam  Sayısı İlgili kategorideki ilan sayısı


        Console.WriteLine("---LINQ QUERY 10------");
        Console.WriteLine("Rent - List Category Count - Car - Count (COUNT)");

        var q10 = Rents.Count(n => n.Product_Category.Category_ID == 6);
        Console.WriteLine("Count in Car Category : " + q10);
        var q10_List = Rents.Where(n => n.Product_Category.Category_ID == 6);
        foreach (var item in q10_List)
        {
            Console.WriteLine("ID :" + item.Product_ID + " - Name : " + item.Product_Name);
        }
        #endregion

        #region LINQ QUERY 11 => Distinct Kategori (ID-NAME) Listeleme İlgili 


        Console.WriteLine("---LINQ QUERY 11------");
        Console.WriteLine("Sales - List - Category Name - Distinct (DISTINCT)");

        var q11 = (Sales.Select(prod => prod.Product_Category)).Distinct();

        foreach (var item in q11)
        {
            Console.WriteLine("Category ID :" + item.Category_ID + " - Category Name : " + item.Category_Name);
        }
        #endregion

        #region LINQ QUERY 12 => Convert Dictionary 


        Console.WriteLine("---LINQ QUERY 12------");
        Console.WriteLine("Rents -  Convert Dictionary  - Dictionary (DICTIONARY)");

        var q12 = Rents.ToDictionary(key => key.Product_ID, value => value.Product_Name);


        foreach (var item in q12)
        {
            Console.WriteLine("KEY : " + item.Key + " - VALUE : " + item.Value + item);
        }
        #endregion

        #region LINQ QUERY 13 => Sales Average Price 


        Console.WriteLine("---LINQ QUERY 13------");
        Console.WriteLine("Sales - Sales Average Price  (AVERAGE)");

        var q13 = Sales.Average(avg => avg.Product_Price);

        Console.WriteLine("Average Age of Sales : {0}", q13);

        #endregion

        #region LINQ QUERY 14 => Sales Max Price  


        Console.WriteLine("---LINQ QUERY 14------");
        Console.WriteLine("Sales -  Sales Max Price   (MAX)");

        var q14 = Sales.Max(s => (s.Product_Price));

        Console.WriteLine("Max Price : {0} ", q14);

        #endregion

        #region LINQ QUERY 15 => Rents Query ANY Result (True/False)


        Console.WriteLine("---LINQ QUERY 15------");
        Console.WriteLine("Rents - Rents All Do You Have (ANY)");

        var q15 = Rents.Any(s => s.Product_Price < 1000.0 && s.rentKind == RentKind.Day);

        Console.WriteLine(q15);

        #endregion

        #region LINQ QUERY 16 => Rents Dictionary ID-KEY  NAME-VALUE


        Console.WriteLine("---LINQ QUERY 16------");
        Console.WriteLine("Rents - Dictionary(ID,NAME) - (Dictionary)");

        IDictionary<int, ForRent> rentDict =
                               Rents.ToDictionary<ForRent, int>(s => s.Product_ID);
        foreach (var key in rentDict.Keys)
            Console.WriteLine("Key: {0}, Value: {1}",
                                        key, (rentDict[key] as ForRent).Product_Name);

        #endregion

        #region LINQ QUERY 17 => Sales Take() 


        Console.WriteLine("---LINQ QUERY 17------");
        Console.WriteLine("Sales -  Take(2) List  - (TAKE)");

        var q17 = Sales.Take(2);

        foreach (var str in q17)
            Console.WriteLine(str.Product_ID + " " + str.Product_Name);
        #endregion

        #region LINQ QUERY 18 => Sales TakeWhile(Name.Length > i) Ad uzunluğu dizinin eleman sayısından büyük olana kadar listeleme 


        Console.WriteLine("---LINQ QUERY 18------");
        Console.WriteLine("Sales -  Take While List (Name.Length > 10) - (TAKEWHILE)");

        var q18 = Sales.TakeWhile((s, i) => s.Product_Name.Length > i);

        foreach (var str in q18)
            Console.WriteLine(str.Product_ID + " " + str.Product_Name);
        #endregion

        #region LINQ QUERY 19 => Sales  - ToLookup Query


        Console.WriteLine("---LINQ QUERY 19------");
        Console.WriteLine("Sales -  ToLookup Query by Price - (ToLookup)");

        var q19 = Sales.ToLookup(s => s.Product_Price);


        foreach (var tolookup in q19)
        {
            Console.WriteLine("Price Group: {0}", tolookup.Key);  //Each group has a key 

            foreach (ForSale s in tolookup)  //Each group has a inner collection  
                Console.WriteLine("Sales Product Name: {0}", s.Product_Name);
        }

        #endregion

        #region LINQ QUERY 20 => SALES at ForSale2 Class by XML File Quary Price==850


        Console.WriteLine("---LINQ QUERY 20------");
        Console.WriteLine("Sales - XML File Quary (bin\\Debug\\forSales.xml) - (ToLookup)");

        XDocument x = XDocument.Load(@"C:\Users\Z004PTKX\source\repos\Linq-Project\Linq-Project\bin\Debug\net7.0\forSales.xml");

        var ctg_result = x.Element("ArrayOfForSale2").Elements("ForSale2").Where(E => E.Element("ProductPrice").Value == "850");

        foreach (var item in ctg_result)
        {
            Console.WriteLine(String.Format("NAME : {0}, DATE : {1}", item.Element("ProductName").Value, item.Element("ProductPublishDate").Value));
        }
        #endregion


    }
}