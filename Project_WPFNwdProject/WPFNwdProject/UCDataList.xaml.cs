using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Windows.ApplicationModel.Chat;

namespace WPFNwdProject
{
    /// <summary>
    /// Interaction logic for UCDataList.xaml
    /// </summary>
    public partial class UCDataList : UserControl
    {
        public UCDataList()
        {
            InitializeComponent();


            this.Loaded += UCDataList_Loaded;
            gridList.MouseDoubleClick += GridList_MouseDoubleClick;
        }


        public static int emp;
        public static int shipV;
        UpdateWin updateWin;
        private async void GridList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                updateWin = new UpdateWin();

                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        DataRowView dr = (DataRowView)dgr.Item;

                        String OrderID = dr[0].ToString();
                        String CustomerID = dr[1].ToString();
                        String EmployeeID = dr[2].ToString();
                        String OrderDate = dr[3].ToString();
                        String RequiredDate = dr[4].ToString();
                        String ShippedDate = dr[5].ToString();
                        String ShipVia = dr[6].ToString();
                        String Freigh = dr[7].ToString();
                        String ShipName = dr[8].ToString();
                        String ShipAddress = dr[9].ToString();
                        String ShipCity = dr[10].ToString();
                        String ShipRegion = dr[11].ToString();
                        String shipPostalCode = dr[12].ToString();
                        String ShipCountry = dr[13].ToString();

                        emp = Convert.ToInt32(EmployeeID) - 1;
                        shipV = Convert.ToInt32(ShipVia) - 1;
                        updateWin.txtOrderID.Text = OrderID;
                        updateWin.cmbCustomer.SelectedValue = Convert.ToString(CustomerID);
                        updateWin.cmbEmployee.SelectedValue = Convert.ToInt32(EmployeeID);
                        updateWin.dateOrder.SelectedDate = Convert.ToDateTime(OrderDate);
                        updateWin.dateRequire.SelectedDate = Convert.ToDateTime(RequiredDate);
                        updateWin.dateShipped.SelectedDate = Convert.ToDateTime(ShippedDate);
                        updateWin.cmbShipper.SelectedValue = Convert.ToInt32(ShipVia);

                        updateWin.txtFreight.Text = Freigh;
                        updateWin.txtShipName.Text = ShipName;
                        updateWin.txtShipAddress.Text = ShipAddress;
                        updateWin.txtShipCity.Text = ShipCity;
                        updateWin.txtShipRegion.Text = ShipRegion;
                        updateWin.txtPostalCode.Text = shipPostalCode;
                        updateWin.txtShipCountry.Text = ShipCountry;
                        int customerCompanyName = await GetCompanyNameByCustomerId(CustomerID);

                        ComboGetValue.employeeID = emp;
                        ComboGetValue.shipViaID = shipV;
                        ComboGetValue.customerID = customerCompanyName - 1;
                        updateWin.Show();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        public async Task<int> GetCompanyNameByCustomerId(string CustomerID)
        {
            // Find sql row number 
            string sql = "SELECT sira from (SELECT ROW_NUMBER() OVER(ORDER BY CompanyName ASC) AS sira,CustomerID,CompanyName FROM Customers) AS t WHERE CustomerID= '" + CustomerID + "'";
            int companyNameIndex;

            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (conn.State != System.Data.ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        companyNameIndex = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

            }
            catch
            {
                throw;
            }

            return await Task.FromResult(companyNameIndex);
        }


        private void UCDataList_Loaded(object sender, RoutedEventArgs e)
        {

            // gridFill("Select * from Orders ORDER BY OrderID desc");
            gridFill("sp_getOrders");
        }

        public async void gridFill(string query)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection.GetConnectionString);
                DataTable DataTable = new DataTable();
                adapter.Fill(DataTable);
                gridList.ItemsSource = await Task.FromResult(DataTable.DefaultView);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
