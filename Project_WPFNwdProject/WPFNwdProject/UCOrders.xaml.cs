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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFNwdProject.List;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using Windows.Devices.Radios;


namespace WPFNwdProject
{

    public partial class UCOrders : UserControl
    {
        public OrderDAL ordarDl = new OrderDAL();
        public UCOrders()
        {
            InitializeComponent();



            btnSaveOrders.Click += BtnSaveOrders_Click;

            this.Loaded += UCOrders_Loaded;

            cmbCustomer.SelectionChanged += CmbCustomer_SelectionChanged;
            cmbEmployee.SelectionChanged += CmbEmployee_SelectionChanged;
            cmbShipper.SelectionChanged += CmbShipper_SelectionChanged;
        }

        int selectedItemShippersID;
        private void CmbShipper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItemShippers;
            if (cmbShipper.SelectedIndex > 0)
            {
                selectedItemShippers = cmbShipper.SelectedValue.ToString();
                selectedItemShippersID = Convert.ToInt32(selectedItemShippers);
                // MessageBox.Show("Shippers ID : " + selectedItemShippers);
            }
        }

        int selectedItemEmployeeID;
        private void CmbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItemEmployee;
            if (cmbEmployee.SelectedIndex > 0)
            {
                selectedItemEmployee = cmbEmployee.SelectedValue.ToString();
                selectedItemEmployeeID = Convert.ToInt32(selectedItemEmployee);
                //  MessageBox.Show("Employee ID : " + selectedItemEmployee);
            }
        }

        string selectedItemCustomer; // ID STRING TÜRÜNDEDİR 
        public void CmbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmbCustomer.SelectedIndex > 0)
            {
                selectedItemCustomer = cmbCustomer.SelectedValue.ToString();

                // MessageBox.Show("Customer ID : " + selectedItemCustomer);
            }
        }

        private void UCOrders_Loaded(object sender, RoutedEventArgs e)
        {
            GetCustomers();
            GetEmployee();
            GetShippers();

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

        public void OrderAdd()
        {
            try
            {
                freight = txtFreight.Text;
                shipName = txtShipName.Text;
                shipAddress = txtShipAddress.Text;
                shipCity = txtShipCity.Text;
                shipRegion = txtShipRegion.Text;
                postalCode = txtPostalCode.Text;
                shipCountry = txtShipCountry.Text;

                string Customer = selectedItemCustomer.Trim();

                decimal c_fr = Convert.ToDecimal(freight);
                bool result = ordarDl.Add(Customer,
                    selectedItemEmployeeID, DateTime.Today, DateTime.Today, DateTime.Today, selectedItemShippersID,
                    c_fr, shipName, shipAddress, shipCity, shipRegion, postalCode, shipCountry);

                if (result)
                {
                    MessageBox.Show("Add İşlem başarılı.");
                }
                else
                {
                    MessageBox.Show("Add İşlem başarısız.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public void OrderDelete()
        {
            try
            {
                int id = Convert.ToInt32(txtOrderID.Text);

                bool result = ordarDl.Delete(id);

                if (result)
                {
                    MessageBox.Show("Delete İşlem başarılı.");
                }
                else
                {
                    MessageBox.Show("Delete İşlem başarısız.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public void OrderDeleteDetail()
        {
            try
            {
                int id = Convert.ToInt32(txtOrderID.Text);

                bool result = ordarDl.DeleteDetail(id);

                if (result)
                {
                    MessageBox.Show("Delete Detail İşlem başarılı.");
                }
                else
                {
                    MessageBox.Show("Delete  Detail İşlem başarısız.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public string orderUpdeteID;
        public void OrderUpdate()
        {
            try
            {
                orderUpdeteID = txtOrderID.Text;
                int orderid = Convert.ToInt32(orderUpdeteID);

                freight = txtFreight.Text;
                shipName = txtShipName.Text;
                shipAddress = txtShipAddress.Text;
                shipCity = txtShipCity.Text;
                shipRegion = txtShipRegion.Text;
                postalCode = txtPostalCode.Text;
                shipCountry = txtShipCountry.Text;

                string Customer = selectedItemCustomer.Trim();

                decimal c_fr = Convert.ToDecimal(freight);
                bool result = ordarDl.Update(orderid, Customer,
                    selectedItemEmployeeID, DateTime.Today, DateTime.Today, DateTime.Today, selectedItemShippersID,
                    c_fr, shipName, shipAddress, shipCity, shipRegion, postalCode, shipCountry);

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

        private void BtnSaveOrders_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (radioAdd.IsChecked == true)
                {
                    if (txtFreight.Text == string.Empty || txtPostalCode.Text == string.Empty || txtShipAddress.Text == string.Empty || txtShipCity.Text == string.Empty || txtShipCountry.Text == string.Empty || txtShipName.Text == string.Empty || txtShipRegion.Text == string.Empty || cmbCustomer.SelectedIndex == -1 || cmbEmployee.SelectedIndex == -1 || cmbShipper.SelectedIndex == -1)
                    {
                        MessageBox.Show("no empty value", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    else
                    {
                        OrderAdd();
                    }


                }
                if (radioUpdate.IsChecked == true)
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
                if (radioDelete.IsChecked == true)
                {

                    if (txtOrderID.Text == string.Empty)
                    {
                        MessageBox.Show("no empty value", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        OrderDeleteDetail();
                        OrderDelete();

                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

       
        public List<Customer> GetCustomerList()
        {
            sql = "SELECT CustomerID, CompanyName FROM Customers";
            List<Customer> _customer = new List<Customer>();
           
            try
            {
                using(SqlConnection conn = new SqlConnection(Connection.GetConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (conn.State != System.Data.ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            _customer.Add(new Customer((int)dr["CustomerID"], dr["CompanyName"].ToString()));
                        }
                    }
                }
                    
               
            }
            catch
            {
                throw;
            }
       
            return _customer;

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

       
        // Fill Combobox Shipper
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
