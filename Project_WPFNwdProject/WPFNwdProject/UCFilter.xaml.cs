using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Windows.System;

namespace WPFNwdProject
{
    /// <summary>
    /// Interaction logic for UCFilter.xaml
    /// </summary>
    public partial class UCFilter : UserControl
    {
        OrderDAL OrderDAL = new OrderDAL();
        public UCFilter()
        {
            InitializeComponent();

            this.Loaded += UCFilter_Loaded;

            cmbFilterQuery.ItemsSource = typeof(Order).GetProperties().Select((o) => o.Name);
            QueryList.Items.Filter = nameFilter;
            QueryList.ItemsSource = OrderDAL.GetOrders();
            btnDate.Click += BtnDate_Click;
        }

        private void BtnDate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DateTime d1 = (DateTime)datestart.SelectedDate;
                DateTime d2 = (DateTime)datefinish.SelectedDate;
                QueryList.ItemsSource = OrderDAL.OrderSelectDate(d1, d2);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UCFilter_Loaded(object sender, RoutedEventArgs e)
        {


        }



        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                QueryList.Items.Filter = GetFilter();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Filter Search
        public Predicate<object> GetFilter()
        {
            try
            {
                switch (cmbFilterQuery.SelectedItem as string)
                {

                    case "OrderID":
                        return orderIDFilter;
                    case "CustomerID":
                        return customerIDFilter;
                    case "EmployeeID":
                        return employeeIDFilter;
                    case "ShipVia":
                        return shipViaFilter;
                    case "Freight":
                        return freightFilter;
                    case "ShipName":
                        return nameFilter;
                    case "ShipAddress":
                        return addressFilter;
                    case "ShipCity":
                        return cityFilter;
                    case "ShipRegion":
                        return regionFilter;
                    case "ShipPostalCode":
                        return postalcodeFilter;
                    case "ShipCountry":
                        return countryFilter;
                    case "OrderDate":
                        return orderDateFilter;
                    case "RequiredDate":
                        return requiredDateFilter;
                    case "ShippedDate":
                        return shippedDateFilter;
                    case "":
                        return nameFilter;


                }
                return nameFilter;
            }
            catch (Exception) { throw; }
        }


        private bool orderDateFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.OrderDate.ToString().Contains(txtFilter.Text);
            }
            catch (Exception) { throw; }
        }
        private bool requiredDateFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.RequiredDate.ToString().Contains(txtFilter.Text);

            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool shippedDateFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.ShippedDate.ToString().Contains(txtFilter.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
        //******
        private bool orderIDFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.OrderID.ToString().Contains(txtFilter.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool customerIDFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.CustomerID.Contains(txtFilter.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool employeeIDFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.EmployeeID.ToString().Contains(txtFilter.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool shipViaFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.ShipVia.ToString().Contains(txtFilter.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool freightFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.Freight.ToString().Contains(txtFilter.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool nameFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.ShipName.Contains(txtFilter.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool countryFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.ShipCountry.Contains(txtFilter.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool cityFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.ShipCity.Contains(txtFilter.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool addressFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.ShipAddress.Contains(txtFilter.Text);

            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool regionFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.ShipRegion.Contains(txtFilter.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool postalcodeFilter(object obj)
        {
            try
            {
                var filterObj = obj as Order;
                return filterObj.ShipPostalCode.Contains(txtFilter.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (txtFilter.Text == null)
                {
                    QueryList.Items.Filter = null;
                }
                else
                {
                    QueryList.Items.Filter = GetFilter();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void QueryList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }


    }
}
