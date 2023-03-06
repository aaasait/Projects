using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using LinqWPFProject.List;

namespace LinqWPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SaleWin saleWin;
        public RentWin rentWin;
        public QueryWin queryWin;
        public MainWindow()
        {
            InitializeComponent();
            btnSaveAddress.Click += BtnSaveAddress_Click;
            btnSaveProduct.Click += BtnSaveProduct_Click;
            this.Loaded += MainWindow_Loaded;
            btnSaleView.Click += BtnSaleView_Click;
            btnRentView.Click += BtnRentView_Click;
            btnQueryView.Click += BtnQueryView_Click;
        }

        private void BtnQueryView_Click(object sender, RoutedEventArgs e)
        {

            queryWin = new QueryWin();
            queryWin.Owner = this;

            queryWin.FilterQuery.ItemsSource = GetQuery();
            queryWin.FilterQuery.DisplayMemberPath = "QueryName";
            queryWin.FilterQuery.SelectedValuePath = "QueryID";
            // List Equals
            queryWin.listSaleQuery = defaultSaleList;
            queryWin.listRentQuery = defaultRentList;

            queryWin.Show();
        }

        public List<QueryList> Queries = new List<QueryList>();
        public List<QueryList> GetQuery()
        {
            List<QueryList> Queries = new List<QueryList>();
            Queries.Add(new QueryList(1, "Query-1 : Get Sales Swap(true) "));
            Queries.Add(new QueryList(2, "Query-2 : RentKind-(Enum) Kiralık Türü(Day-Week-Month)"));
            Queries.Add(new QueryList(3, "Query-3 : Sales Name and Rent Kind (JOIN)"));
            Queries.Add(new QueryList(4, "Query-4 : Rents - With Date (ORDER BY) ASC ARTAN"));
            Queries.Add(new QueryList(5, "Query-5 : Rents - Search in Product Name (CONTAINS) - (Table)"));
            Queries.Add(new QueryList(6, "Query-6 : Rents - Rounding  (Math Round)"));
            Queries.Add(new QueryList(7, "Query-7 : Sales  - Cross Join  (Cross Join)"));
            Queries.Add(new QueryList(8, "Query-8 : Rents - ID with Mod2 - Skip While (SkipWhile)"));
            Queries.Add(new QueryList(9, "Query-9 : Sales - Price with Category - Sum (SUM)"));
            Queries.Add(new QueryList(10, "Query-10 : Rent - List Category Count - Car - Count (COUNT)"));
            Queries.Add(new QueryList(11, "Query-11 : Sales - List - Category Name - Distinct (DISTINCT)"));
            Queries.Add(new QueryList(12, "Query-12 : Rents - Convert Dictionary - Dictionary (DICTIONARY)"));
            Queries.Add(new QueryList(13, "Query-13 : Sales - Sales Average Price (AVERAGE)"));
            Queries.Add(new QueryList(14, "Query-14 : Sales - Sales Max Price (MAX)"));
            Queries.Add(new QueryList(15, "Query-15 : Rents - Rents All Do You Have (ANY)"));
            Queries.Add(new QueryList(16, "Query-16 : Rents - Dictionary(ID,NAME) - (Dictionary)"));
            Queries.Add(new QueryList(17, "Query-17 : Sales - Take(2) List - (TAKE)"));
            Queries.Add(new QueryList(18, "Query-18 : Sales - Take While List (Name.Length > 10) - (TAKEWHILE)"));
            Queries.Add(new QueryList(19, "Query-19 : Sales - ToLookup Query by Price - (ToLookup)"));
            Queries.Add(new QueryList(20, "Query-20 : Sales - XML File Quary (bin\\Debug\\forSales.xml) - (ToLookup)"));
            return Queries;

        }
        private void BtnRentView_Click(object sender, RoutedEventArgs e)
        {
            rentWin = new RentWin();
            rentWin.Owner = this;
            rentWin.RentList.ItemsSource = RentSave();
            rentWin.FilterRent.ItemsSource = typeof(ForRent).GetProperties().Select((o) => o.Name);

            rentWin.Show();
        }

        private void BtnSaleView_Click(object sender, RoutedEventArgs e)
        {
            saleWin = new SaleWin();
            saleWin.Owner = this;
            saleWin.SaleList.ItemsSource = SaleSave();

            saleWin.FilterSale.ItemsSource = typeof(ForSale).GetProperties().Select((o) => o.Name);

            saleWin.Show();
        }

        
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCountry.ItemsSource = GetCountry();
            cmbCountry.DisplayMemberPath = "Country_Name";
            cmbCountry.SelectedValuePath = "Country_ID";

            cmbCity.ItemsSource = GetCity();
            cmbCity.DisplayMemberPath = "City_Name";
            cmbCity.SelectedValuePath = "City_ID";

            cmbCategory.ItemsSource = GetProductCategory();
            cmbCategory.DisplayMemberPath = "Category_Name";
            cmbCategory.SelectedValuePath = "Category_ID";
           
        }

        public List<Country> Countries = new List<Country>();
        public List<Country> GetCountry()
        {
            List<Country> Countries = new List<Country>();
            Countries.Add(new Country(1, "Turkey"));
            Countries.Add(new Country(2, "Germany"));

            return Countries;
        }

        public List<City> Cities = new List<City>();
        public List<City> GetCity()
        {
            List<City> Cities = new List<City>();
            Cities.Add(new City(34, "Istanbul"));
            Cities.Add(new City(35, "Izmir"));
            Cities.Add(new City(1, "Adana"));
            Cities.Add(new City(6, "Ankara"));
            Cities.Add(new City(7, "Antalya"));
            return Cities;

        }

        public List<Address> GetCreateAddress()
        {
            List<Address> Address1 = new List<Address>();
            Address1.Add(new Address(1, "Home", GetCountry()[0], GetCity()[1], "Kartal"));
            // Address1.Add(new Address(2, "Work", Countries[0], Cities[2], "Kadikoy"));

            return Address1;

        }

        public List<ProductCategory> Categories = new List<ProductCategory>();

        public List<ProductCategory> GetProductCategory()
        {

            Categories.Add(new ProductCategory(1, "Home", "Home"));
            Categories.Add(new ProductCategory(2, "Garden", "Garden"));
            Categories.Add(new ProductCategory(3, "Kitchen", "Kitchen"));
            Categories.Add(new ProductCategory(4, "Electronic", "Electronic"));
            Categories.Add(new ProductCategory(5, "Textile", "Textile"));
            Categories.Add(new ProductCategory(6, "Car", "Car"));
            return Categories;
        }

        public List<ForSale> Sales = new List<ForSale>();
        public List<ForRent> Rents = new List<ForRent>();
        string name, description, getPrice;
        double price;
        int SaleID = 12;
        int RentID = 12;
        int CategoriID, _addressIDs;
        public DateTime date1 = new DateTime();
        public bool checkSwaps = false;
        bool radioRentKind = false;
        public RentKind rentKd;

        private void BtnSaveProduct_Click(object sender, RoutedEventArgs e)
        {

            if (radioSale.IsChecked == true)
            {
                SaleSave();
                MessageBox.Show("Successfully SALE");
                
                #region Serialize SUCCESSFULLY
                // Bin/ Debug Serialize  oldu.
                var serializer = new XmlSerializer(typeof(List<ForSale>));
                using (var writer = new StreamWriter("forSales.xml"))
                {
                    serializer.Serialize(writer, defaultSaleList);
                }

                #endregion
                
            }
            if (radioRent.IsChecked == true)
            {
                RentSave();
                MessageBox.Show("Successfully RENT");
            }

           
        }


        int ClickCountRent = 0;
        public List<ForRent> defaultRentList = new List<ForRent>();

        public List<ForRent> RentSave()
        {
            RentID += 1;
            name = txtName.Text;
            description = txtDescription.Text;
            getPrice = txtPrice.Text;
            price = Convert.ToDouble(getPrice);

           // price = 1111.1;

            string categoryID = cmbCategory.SelectedValue.ToString();
            CategoriID = Convert.ToInt32(categoryID);
            string addressIDs = cmbCategory.SelectedValue.ToString();
            _addressIDs = Convert.ToInt32(addressIDs);

            ClickCountRent += 1;


            if (radioDay.IsChecked == true)
            {
                rentKd = RentKind.Day;
            }
            if (radioWeek.IsChecked == true)
            {
                rentKd = RentKind.Month;
            }
            if (radioMonth.IsChecked == true)
            {
                rentKd = RentKind.Month;
            }

            if(ClickCountRent < 2)
            {
                GetClickDefaultRentList();
                defaultRentList.Add(new ForRent(RentID, name, description, price, DateTime.Today, GetCategory(), GetAddress(), rentKd));

            }
            if (ClickCountRent > 2)
            {
                ClickCountRent = 1;
                RentID -= 1;
                defaultRentList.Add(new ForRent(RentID, name, description, price, DateTime.Today, GetCategory(), GetAddress(), rentKd));

            }


             return defaultRentList;
        }


        int ClickCountSale = 0;
        public List<ForSale> defaultSaleList = new List<ForSale>();
       
        public List<ForSale> SaleSave()
        {
            SaleID += 1;
            name = txtName.Text;
            description = txtDescription.Text;
            getPrice = txtPrice.Text;
            price = Convert.ToDouble(getPrice);
            //price = 1111.1;

            string categoryID = cmbCategory.SelectedValue.ToString();
            CategoriID = Convert.ToInt32(categoryID);
            string addressIDs = cmbCategory.SelectedValue.ToString();
            _addressIDs = Convert.ToInt32(addressIDs);

            if (chckSwap.IsChecked == true)
            {
                checkSwaps = true;
            }
            if (chckSwap.IsChecked == false)
            {
                checkSwaps = false;
            }

            ClickCountSale += 1;
            bool ClickControl = false;
            if (ClickCountSale < 2)
            {
               
                GetClickDefaultSaleList();
     
                // Sales.Add(new ForSale(SaleID, name, description, price, DateTime.Today, GetCategory(), GetAddress(), checkSwaps));
                defaultSaleList.Add(new ForSale(SaleID, name, description, price, DateTime.Today, GetCategory(), GetAddress(), checkSwaps));
                
            }
             if (ClickCountSale > 2) // 1000 Max Value After
            {
                ClickCountSale = 1;
                SaleID -= 1;
                // Sales.Add(new ForSale(SaleID, name, description, price, DateTime.Today, GetCategory(), GetAddress(), checkSwaps));
                defaultSaleList.Add(new ForSale(SaleID, name, description, price, DateTime.Today, GetCategory(), GetAddress(), checkSwaps));
               
            }
            return defaultSaleList;


            //-------------------------------

        }

        public void GetClickDefaultSaleList() // SALE
        {
            defaultSaleList.Add(new ForSale(1, "Telephone IPHONE", "Clean phone 16 GB ", 850.0, new DateTime(2010, 1, 2), Categories[3], GetCreateAddress(), true));
            defaultSaleList.Add(new ForSale(2, "Home Table ENGLİSH HOME", "6 personality ", 500.9, new DateTime(2011, 2, 12), Categories[0], GetCreateAddress(), false));
            defaultSaleList.Add(new ForSale(3, "Kitchen Carpet MERINOS", "Area(cm) 200x200 ", 149.8, new DateTime(2020, 9, 3), Categories[2], GetCreateAddress(), false));
            defaultSaleList.Add(new ForSale(4, "T-Shirt Lacoste", " New Small Size ", 850.0, new DateTime(2020, 11, 25), Categories[4], GetCreateAddress(), false));
            defaultSaleList.Add(new ForSale(5, "TV Samsung", "Very Clean + Netflix ", 1200.0, new DateTime(2021, 5, 23), Categories[3], GetCreateAddress(), true));
            defaultSaleList.Add(new ForSale(6, "HP Laptop", "16 GB Ram 500 GB SSD  ", 1600.0, new DateTime(2022, 1, 27), Categories[3], GetCreateAddress(), true));
            defaultSaleList.Add(new ForSale(7, "Honda CRV Suv", "120000 Km + Navigation  ", 7500.1, new DateTime(2019, 6, 7), Categories[5], GetCreateAddress(), true));
            defaultSaleList.Add(new ForSale(8, "Tablecloth Pierre Cardin", "200x300 cm Rectangle ", 75.9, new DateTime(2017, 3, 20), Categories[2], GetCreateAddress(), false));
            defaultSaleList.Add(new ForSale(9, "Towel Pink", "Big Size ", 29.9, new DateTime(2023, 1, 1), Categories[4], GetCreateAddress(), false));
            defaultSaleList.Add(new ForSale(10, "Toyota Corolla", "2020 Model 13000 Mile ", 11550.2, new DateTime(2021, 9, 11), Categories[5], GetCreateAddress(), false));
            defaultSaleList.Add(new ForSale(11, "Plastation 4", "Gift 2 Games ", 999.0, new DateTime(2022, 9, 13), Categories[3], GetCreateAddress(), false));
            defaultSaleList.Add(new ForSale(12, "Garden Armchair", "4 piece ", 255.0, new DateTime(2023, 1, 10), Categories[1], GetCreateAddress(), false));

        }

        
        public void GetClickDefaultRentList() //  RENT
        {
            defaultRentList.Add(new ForRent(1, "Telephone HUAWEI", "Clean phone 32 GB ", 110.0, new DateTime(2010, 1, 2), Categories[3], GetCreateAddress(), RentKind.Week));
            defaultRentList.Add(new ForRent(2, "Home Table IKEA", "4 personality ", 269.9, new DateTime(2011, 2, 12), Categories[0], GetCreateAddress(), RentKind.Week));
            defaultRentList.Add(new ForRent(3, "Kitchen Carpet BAHOUSE", "Area(cm) 550x300 ", 49.8, new DateTime(2020, 9, 3), Categories[2], GetCreateAddress(), RentKind.Day));
            defaultRentList.Add(new ForRent(4, "T-Shirt Polo", " New XL Size ", 7.0, new DateTime(2020, 11, 25), Categories[4], GetCreateAddress(), RentKind.Day));
            defaultRentList.Add(new ForRent(5, "TV Apple", "Very Clean + Disney ", 459.2, new DateTime(2021, 5, 23), Categories[3], GetCreateAddress(), RentKind.Week));
            defaultRentList.Add(new ForRent(6, "Casper Laptop", "8 GB Ram 125 GB SSD  ", 101.0, new DateTime(2022, 1, 27), Categories[3], GetCreateAddress(), RentKind.Month));
            defaultRentList.Add(new ForRent(7, "Dodge Challenger 3.5 Turbo", "33000 Km + Carplay  ", 500.0, new DateTime(2019, 6, 7), Categories[5], GetCreateAddress(), RentKind.Day));
            defaultRentList.Add(new ForRent(8, "Tablecloth H&M", "200x300 cm Circle ", 5.9, new DateTime(2017, 3, 20), Categories[2], GetCreateAddress(), RentKind.Week));
            defaultRentList.Add(new ForRent(9, "Towel Black", "SmallX Size ", 9.9, new DateTime(2023, 1, 1), Categories[4], GetCreateAddress(), RentKind.Week));
            defaultRentList.Add(new ForRent(10, "Lexus LXC ", "2017 Models 12600 Mile ", 950.2, new DateTime(2021, 9, 11), Categories[5], GetCreateAddress(), RentKind.Month));
            defaultRentList.Add(new ForRent(11, "XBOX 3", "Gift 2 Cinema Ticket ", 250.0, new DateTime(2022, 9, 13), Categories[3], GetCreateAddress(), RentKind.Week));
            defaultRentList.Add(new ForRent(12, "Garden Stone", "18 piece ", 25.0, new DateTime(2023, 1, 10), Categories[1], GetCreateAddress(), RentKind.Day));

        }
        private void BtnSaveAddress_Click(object sender, RoutedEventArgs e)
        {
            cmbAddress.ItemsSource = GetAddress();
            cmbAddress.DisplayMemberPath = "Address_Name";
            cmbAddress.SelectedValuePath = "Address_ID";

            MessageBox.Show(ciID.ToString());
        }

        string addressName, address;
        int addresssID = 0;
        int coID;
        int ciID;
        public List<Address> Addresses = new List<Address>();
        public List<Address> GetAddress()
        {
            addresssID += 1;
            addressName=txtAddressName.Text;
            string countryID = cmbCountry.SelectedValue.ToString();
            coID=Convert.ToInt32(countryID);
            string cityID = cmbCity.SelectedValue.ToString();
            ciID = Convert.ToInt32(cityID);
            address = txtAddress.Text;

            
            Addresses.Add(new Address(addresssID, addressName, GetCountryAddress(), GetCityAddress(), address));
            return Addresses;
        }

        int id_country;
        string country;
        public Country GetCountryAddress()
        {
            
           
            foreach (var item in Countries)
            {
                if (item.Country_ID == coID)
                {
                    id_country = item.Country_ID;
                    country= item.Country_Name;
                }
            }
            Country country1= new Country(id_country, country);
            return country1;
        }

        int id_city;
        string city;
        public City GetCityAddress()
        {


            foreach (var item in Cities)
            {
                if (item.City_ID == ciID)
                {
                    id_city = item.City_ID;
                    city = item.City_Name;
                }
            }
            City city1 = new City(id_city, city);
            return city1;
        }

        int id_Ctg;
        string CtgName, CtgDescription;
        public ProductCategory GetCategory()
        {


            foreach (var item in GetProductCategory())
            {
                if (item.Category_ID == CategoriID)
                {
                    id_Ctg = item.Category_ID;
                    CtgName = item.Category_Name;
                    CtgDescription= item.Category_Description;
                }
            }
            ProductCategory productCtg1 = new ProductCategory(id_Ctg, CtgName, CtgDescription);
            return productCtg1;
        }
    }
}
