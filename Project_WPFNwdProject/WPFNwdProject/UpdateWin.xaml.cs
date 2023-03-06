using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using WPFNwdProject.List;

namespace WPFNwdProject
{
    /// <summary>
    /// Interaction logic for UpdateWin.xaml
    /// </summary>
    public partial class UpdateWin : Window
    {
        public OrderDAL ordarDl = new OrderDAL();

        SqlConnection conn = new SqlConnection(Connection.GetConnectionString);
        public UpdateWin()
        {
            InitializeComponent();

            this.Loaded += UpdateWin_Loaded;
            cmbCustomer.SelectionChanged += CmbCustomer_SelectionChanged; ;
            cmbEmployee.SelectionChanged += CmbEmployee_SelectionChanged; ;
            cmbShipper.SelectionChanged += CmbShipper_SelectionChanged; ;

            btnUpdateOrders.Click += BtnUpdateOrders_Click;
        }

        private void BtnUpdateOrders_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtOrderID.Text == string.Empty || txtFreight.Text == string.Empty || txtPostalCode.Text == string.Empty || txtShipAddress.Text == string.Empty || txtShipCity.Text == string.Empty || txtShipCountry.Text == string.Empty || txtShipName.Text == string.Empty || txtShipRegion.Text == string.Empty || cmbCustomer.SelectedIndex == -1 || cmbEmployee.SelectedIndex == -1 || cmbShipper.SelectedIndex == -1)
                {
                    MessageBox.Show("no empty value", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    OrderUpdate();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        int selectedItemShippersID;
        private void CmbShipper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedItemShippers;
                if (cmbShipper.SelectedIndex > 0)
                {
                    selectedItemShippers = cmbShipper.SelectedValue.ToString();
                    selectedItemShippersID = Convert.ToInt32(selectedItemShippers);
                    // MessageBox.Show("Shippers ID : " + selectedItemShippers);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        int selectedItemEmployeeID;
        private void CmbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedItemEmployee;
                if (cmbEmployee.SelectedIndex > 0)
                {
                    selectedItemEmployee = cmbEmployee.SelectedValue.ToString();
                    selectedItemEmployeeID = Convert.ToInt32(selectedItemEmployee);
                    //   MessageBox.Show("Employee ID : " + selectedItemEmployee);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        string selectedItemCustomer;
        private void CmbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbCustomer.SelectedIndex > 0)
                {
                    selectedItemCustomer = cmbCustomer.SelectedValue.ToString();

                    // MessageBox.Show("Customer ID : " + selectedItemCustomer);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateWin_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GetCustomers();
                GetShippers();
                GetEmployee();


                cmbEmployee.SelectedIndex = ComboGetValue.employeeID;
                cmbShipper.SelectedIndex = ComboGetValue.shipViaID;
                cmbCustomer.SelectedIndex = ComboGetValue.customerID;
            }
            catch (Exception) { throw; }
        }

        string sql = string.Empty;

        bool result;

        string freight;
        string shipName;
        string shipAddress;
        string shipCity;
        string shipRegion;
        string postalCode;
        string shipCountry;

        public string orderUpdeteID;
        public void OrderUpdate()
        {

            try
            {


                int OrderID = Convert.ToInt32(txtOrderID.Text);
                string CustomerID = Convert.ToString(cmbCustomer.SelectedValue);
                int EmployeeID = Convert.ToInt32(cmbEmployee.SelectedValue);
                DateTime DateOrder = (DateTime)dateOrder.SelectedDate;
                DateTime DateRequired = (DateTime)dateRequire.SelectedDate;
                DateTime DateShipped = (DateTime)dateShipped.SelectedDate;
                int shipVia = Convert.ToInt32(cmbShipper.SelectedValue);
                decimal shipFreight = Convert.ToDecimal(txtFreight.Text);
                string shipName = txtShipName.Text;
                string shipAddress = txtShipAddress.Text;
                string shipCity = txtShipCity.Text;
                string shipRegion = txtShipRegion.Text;
                string shipCountry = txtShipCountry.Text;
                string ShipPostalCode = txtPostalCode.Text;


                this.Close();

                string Customer = selectedItemCustomer.Trim();

                decimal c_fr = Convert.ToDecimal(freight);

                bool result = ordarDl.UpdateGridview(OrderID, Customer, EmployeeID, DateOrder, DateRequired, DateShipped,
                    shipVia, c_fr, shipName, shipAddress, shipCity, shipRegion, postalCode, shipCountry);

                if (result)
                {
                    MessageBox.Show("Update İşlem başarılı.");
                }
                else
                {
                    MessageBox.Show("Update İşlem başarısız.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        // Fill Combobox Customer
        public void GetCustomers()
        {


            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString))
                {
                    DataTable dt = new DataTable();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CustomerID, CompanyName FROM Customers", conn);

                    dt.Load(cmd.ExecuteReader());

                    cmbCustomer.ItemsSource = dt.DefaultView;
                    cmbCustomer.DisplayMemberPath = "CompanyName";
                    cmbCustomer.SelectedValuePath = "CustomerID";

                }

            }
            catch (Exception)
            {
                throw;
            }

        }


        // Fill Combobox Shipped
        public void GetShippers()
        {

            try
            {

                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString))
                {
                    DataTable dt = new DataTable();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ShipperID, CompanyName FROM Shippers", conn);

                    dt.Load(cmd.ExecuteReader());

                    cmbShipper.ItemsSource = dt.DefaultView;
                    cmbShipper.DisplayMemberPath = "CompanyName";
                    cmbShipper.SelectedValuePath = "ShipperID";

                }


            }
            catch (Exception)
            {
                throw;
            }

        }



        // Fill Combobox Employee
        public void GetEmployee()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString))
                {

                    DataTable dt = new DataTable();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT EmployeeID, FirstName FROM Employees", conn);

                    dt.Load(cmd.ExecuteReader());

                    cmbEmployee.ItemsSource = dt.DefaultView;
                    cmbEmployee.DisplayMemberPath = "FirstName";
                    cmbEmployee.SelectedValuePath = "EmployeeID";

                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
