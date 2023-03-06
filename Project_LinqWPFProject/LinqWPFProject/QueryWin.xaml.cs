using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LinqWPFProject
{
    /// <summary>
    /// Interaction logic for QueryWin.xaml
    /// </summary>
    public partial class QueryWin : Window
    {
        public QueryWin()
        {
            InitializeComponent();

            btnGetQuery.Click += BtnGetQuery_Click;
        }


        public List<ForSale> listSaleQuery = new List<ForSale>();
        public List<ForRent> listRentQuery = new List<ForRent>();

        int _filterID;
        private void BtnGetQuery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtQueryList.Items.Clear();


                string queryID = FilterQuery.SelectedValue.ToString();
                _filterID = Convert.ToInt32(queryID);

                #region LINQ QUERY 1 => Sale-True-Swap Satılık Takas Durumu Kontrol

                if (_filterID == 1)
                {
                    var q1 = listSaleQuery.Where(x => (x.Swap == true));

                    foreach (var item in q1)
                    {

                        txtQueryList.Items.Add(" Product Name : " + item.Product_Name + " - " + " Price : " + item.Product_Price + "$" + " - " + " Swap State :" + item.Swap);

                    }
                }

                #endregion

                #region LINQ QUERY 2 => RentKind-(Enum) Kiralık Türü(Day-Week-Month) Durumu Kontrol


                if (_filterID == 2)
                {
                    var q2 = listRentQuery.Select(r =>
                                             new
                                             {
                                                 Rent_ID = r.Product_ID,
                                                 ProductNameDescription = r.Product_Name + " / " + r.Product_Description,
                                                 RentKinds = r.rentKind
                                             });

                    foreach (var item in q2)
                    {

                        txtQueryList.Items.Add(item.Rent_ID + " / " + item.ProductNameDescription + " / " + item.RentKinds);
                    }
                }


                #endregion

                #region LINQ QUERY 3 =>  Join Birleştirme

                if (_filterID == 3)
                {
                    var q3 = from sales1 in listSaleQuery
                             join rents1 in listRentQuery
                                 on sales1.Product_ID equals rents1.Product_ID
                             select new
                             {
                                 Sales_Name = sales1.Product_Name,
                                 Rent_Kind = rents1.rentKind
                             };
                    foreach (var item in q3)
                    {


                        txtQueryList.Items.Add("Sales Name: " + item.Sales_Name + " Rent Kind: " + item.Rent_Kind);

                    }
                }

                #endregion

                #region LINQ QUERY 4 => Sort OrderBy Query - Sıralama ASC ARTAN

                if (_filterID == 4)
                {
                    var sortedByDate = listRentQuery.OrderBy(prices => prices.Product_PublishDate);

                    foreach (var item in sortedByDate)
                    {

                        txtQueryList.Items.Add("Product Name : " + item.Product_Name + " / " + "Sorted Date : " + item.Product_PublishDate);

                    }
                }

                #endregion

                #region LINQ QUERY 5 => Search in Product Name Query with CONTAINS 

                if (_filterID == 5)
                {

                    var rentSearchName = listRentQuery.Where(search => search.Product_Name.Contains("Table"));


                    foreach (var item in rentSearchName)
                    {

                        txtQueryList.Items.Add("ID : " + item.Product_ID + " - NAME " + item.Product_Name + " - PRICE " + item.Product_Price + " - RENT KIND : " + item.rentKind);

                    }
                }

                #endregion

                #region LINQ QUERY 6 => Rounding  (Math Round) Fiyat Yuvarlama

                if (_filterID == 6)
                {


                    var q6 = listRentQuery.Select(s => new
                    {
                        ID = s.Product_ID,
                        Name = s.Product_Name,
                        RoundUpperPrice = Math.Round(s.Product_Price)
                    })
          .OrderByDescending(x => x.ID)
          .Take(listRentQuery.Count)
          .OrderBy(x => x.RoundUpperPrice);


                    foreach (var item in q6)
                    {

                        txtQueryList.Items.Add("ID : " + item.ID + " //  Rent Price Rounded Upper : " + item.RoundUpperPrice);

                    }
                }

                #endregion

                #region LINQ QUERY 7 => Cross Join Çapraz Birleştirme

                if (_filterID == 7)
                {
                    var q7 = listSaleQuery.Join(listRentQuery, sales1 => sales1.Product_ID, rents1 => rents1.Product_ID, (sales1, rents1) => new {

                        SalesID = sales1.Product_ID,
                        SalesName = sales1.Product_Name,
                        SalesSwap = sales1.Swap,
                        RentsKind = rents1.rentKind

                    });

                    foreach (var item in q7)
                    {

                        txtQueryList.Items.Add("ID = " + item.SalesID + " Sales Name = " + item.SalesName + " Sales Swap = " + item.SalesSwap + " Rent Kind = " + item.RentsKind);

                    }
                }



                #endregion

                #region LINQ QUERY 8 => SkipWhile 3 e bölünebilen ilk elemandan başlayarak tüm elemanları yazdırır

                if (_filterID == 8)
                {
                    var q8 = listRentQuery.SkipWhile(n => n.Product_ID % 3 != 0);
                    foreach (var item in q8)
                    {

                        txtQueryList.Items.Add("ID : " + item.Product_ID + " / " + " Rents Name : " + item.Product_Name);


                    }
                }



                #endregion

                #region LINQ QUERY 9 => Sum Toplam 
                if (_filterID == 9)
                {
                    var q9 = listSaleQuery.Sum(sums => (sums.Product_Price));
                    txtQueryList.Items.Add("Sum Price : " + q9);
                }


                #endregion

                #region LINQ QUERY 10 => Count Toplam  Sayısı İlgili kategorideki ilan sayısı

                //var q10 = listRentQuery.Count(n => n.Product_Category.Category_ID == 6);
                //Console.WriteLine("Count in Car Category : " + q10);

                if (_filterID == 10)
                {
                    var q10_List = listRentQuery.Where(n => n.Product_Category.Category_ID == 6);
                    foreach (var item in q10_List)
                    {

                        txtQueryList.Items.Add("ID :" + item.Product_ID + " - Name : " + item.Product_Name);
                    }

                }

                #endregion

                #region LINQ QUERY 11 => Distinct Kategori (ID-NAME) Listeleme İlgili 

                if (_filterID == 11)
                {
                    var q11 = (listSaleQuery.Select(prod => prod.Product_Category)).Distinct();

                    foreach (var item in q11)
                    {

                        txtQueryList.Items.Add("Category ID :" + item.Category_ID + " - Category Name : " + item.Category_Name);

                    }
                }

                #endregion

                #region LINQ QUERY 12 => Convert Dictionary 

                if (_filterID == 12)
                {

                    var q12 = listRentQuery.ToDictionary(key => key.Product_ID, value => value.Product_Name);


                    foreach (var item in q12)
                    {

                        txtQueryList.Items.Add("KEY : " + item.Key + " - VALUE : " + item.Value + item);
                    }
                }
                #endregion

                #region LINQ QUERY 13 => Sales Average Price 

                if (_filterID == 13)
                {
                    var q13 = listSaleQuery.Average(avg => avg.Product_Price);

                    txtQueryList.Items.Add("Average Age of Sales : " + q13);

                }

                #endregion

                #region LINQ QUERY 14 => Sales Max Price  
                if (_filterID == 14)
                {

                    var q14 = listSaleQuery.Max(s => (s.Product_Price));

                    txtQueryList.Items.Add("Sales Max Price : " + q14);

                }


                #endregion

                #region LINQ QUERY 15 => Rents Query ANY Result (True/False)

                if (_filterID == 15)
                {

                    var q15 = listRentQuery.Any(s => s.Product_Price < 1000.0 && s.rentKind == RentKind.Day);

                    txtQueryList.Items.Add(q15);
                }

                #endregion

                #region LINQ QUERY 16 => Rents Dictionary ID-KEY  NAME-VALUE

                if (_filterID == 16)
                {
                    IDictionary<int, ForRent> rentDict =
                                         listRentQuery.ToDictionary<ForRent, int>(s => s.Product_ID);
                    foreach (var key in rentDict.Keys)
                        txtQueryList.Items.Add("Key: {0}, Value: {1}" +
                                                    key + (rentDict[key] as ForRent).Product_Name);

                }


                #endregion

                #region LINQ QUERY 17 => Sales Take() 

                if (_filterID == 17)
                {
                    var q17 = listSaleQuery.Take(2);

                    foreach (var str in q17)
                        txtQueryList.Items.Add(str.Product_ID + " " + str.Product_Name);
                }

                #endregion

                #region LINQ QUERY 18 => Sales TakeWhile(Name.Length > i) Ad uzunluğu dizinin eleman sayısından büyük olana kadar listeleme 


                if (_filterID == 18)
                {

                    var q18 = listSaleQuery.TakeWhile((s, i) => s.Product_Name.Length > i);

                    foreach (var str in q18)
                        txtQueryList.Items.Add(str.Product_ID + " " + str.Product_Name);
                }

                #endregion

                #region LINQ QUERY 19 => Sales  - ToLookup Query

                if (_filterID == 19)
                {

                    var q19 = listSaleQuery.ToLookup(s => s.Product_Price);


                    foreach (var tolookup in q19)
                    {
                        txtQueryList.Items.Add("Price Group: " + tolookup.Key);  //Each group has a key 

                        foreach (ForSale s in tolookup)  //Each group has a inner collection  
                            txtQueryList.Items.Add("Sales Product Name: " + s.Product_Name);
                    }
                }

                #endregion

                #region LINQ QUERY 20 => SALES at ForSale2 Class by XML File Quary Price==850

                if (_filterID == 20)
                {


                    XDocument x = XDocument.Load(@"C:\Users\Z004PTKX\source\repos\LinqWPFProject\LinqWPFProject\bin\Debug\net7.0-windows\forSales.xml");

                    var ctg_result = x.Element("ArrayOfForSale").Elements("ForSale").Where(E => E.Element("ProductPrice").Value == "850");

                    foreach (var item in ctg_result)
                    {
                        txtQueryList.Items.Add("NAME : " + item.Element("ProductName").Value + " DATE : " + item.Element("ProductPublishDate").Value);
                    }
                }



                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void FilterQuery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
        }

        private void txtQueryList_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
