using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Navigation;
using System.Data.SqlTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.Contacts;
using System.Windows;
using System.Runtime.Remoting.Messaging;
using System.Collections.ObjectModel;
using ModernWpf.Controls;
using Windows.Storage.Streams;

namespace WPFNwdProject
{
    public class OrderDAL
    {
        int orderId;
        String customerID;
        int employyeID;
        DateTime OrderDate;
        DateTime RequiredDate;
        DateTime ShippedDate;
        int shipvia;
        decimal dcFreight;
        string sName;
        string sAddress;
        string sCity;
        string sRegion;
        string sPostalCode;
        string sCountry;




        string sql = string.Empty;
        // SqlConnection conn = new SqlConnection(Connection.GetConnectionString);
        // SqlCommand cmd;
        bool result;
        public bool Add(string customID, int employeeID, DateTime dt1, DateTime dt2, DateTime dt3, int shipID,
            decimal fr, string name, string address, string city, string region, string postalcode, string country)
        {
            sql = "INSERT INTO Orders VALUES('" + customID + "','" + employeeID + "','" +
                dt1 + "','" + dt2 + "','" + dt3 + "','" + shipID + "','" + fr +
                 "','" + name + "','" + address + "','" + city + "','" + region + "','" + postalcode + "','" + country + "')";

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
                        int sonuc = cmd.ExecuteNonQuery();
                        if (sonuc > 0)
                        {
                            result = true;
                        }
                    }


                }
            }
            catch
            {
                throw;
            }

            return result;
        }




        public bool Update(int id, string customID, int employeeID, DateTime dt1, DateTime dt2, DateTime dt3, int shipID,
            decimal fr, string name, string address, string city, string region, string postalcode, string country)
        {
            sql = "UPDATE Orders SET CustomerID = '" + customID + "', EmployeeID = '" + employeeID +
                "', OrderDate = '" + dt1 + "', RequiredDate = '" + dt2 + "', ShippedDate = '" + dt3 +
                "', ShipVia = '" + shipID + "', Freight = '" + fr +
               "', ShipName = '" + name + "', ShipAddress = '" + address +
                "', ShipCity = '" + city + "', ShipRegion = '" + region +
                 "', ShipPostalCode = '" + postalcode + "', ShipCountry = '" + country + "' WHERE OrderID = " + id;

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
                        int sonuc = cmd.ExecuteNonQuery();
                        if (sonuc > 0)
                        {
                            result = true;
                        }
                    }
                }

            }
            catch
            {
                throw;
            }

            return result;
        }


        public bool Delete(int id)
        {
            sql = "DELETE FROM Orders WHERE OrderID = " + id;

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
                        int sonuc = cmd.ExecuteNonQuery();
                        if (sonuc > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }

        public bool DeleteDetail(int id)
        {
            sql = "DELETE FROM OrderDetails WHERE OrderID = " + id;

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
                        int sonuc = cmd.ExecuteNonQuery();
                        if (sonuc > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }




        public List<Order> GetOrders()
        {
            sql = "SELECT OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry FROM Orders";

            List<Order> orders = new List<Order>();

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
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            var order1 = new Order
                            {

                                OrderID = dr.GetInt32(dr.GetOrdinal("OrderID")),
                                CustomerID = dr.GetString(dr.GetOrdinal("CustomerID")),
                                EmployeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID")),
                                OrderDate = dr.GetDateTime(dr.GetOrdinal("OrderDate")),
                                RequiredDate = dr.GetDateTime(dr.GetOrdinal("RequiredDate")),
                                ShippedDate = dr.GetDateTime(dr.GetOrdinal("ShippedDate")),
                                ShipVia = dr.GetInt32(dr.GetOrdinal("ShipVia")),
                                Freight = dr.GetDecimal(dr.GetOrdinal("Freight")),
                                ShipName = dr.GetString(dr.GetOrdinal("ShipName")),
                                ShipAddress = dr.GetString(dr.GetOrdinal("ShipAddress")),
                                ShipCity = dr.GetString(dr.GetOrdinal("ShipCity")),
                                ShipRegion = dr.GetString(dr.GetOrdinal("ShipRegion")),
                                ShipPostalCode = dr.GetString(dr.GetOrdinal("ShipPostalCode")),
                                ShipCountry = dr.GetString(dr.GetOrdinal("ShipCountry")),

                            };

                            orders.Add(order1);

                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return orders;
        }


        // Return Listview for Get 2  Between Date
        public List<Order> OrderSelectDate(DateTime date1, DateTime date2)
        {


            List<Order> dateListOrder = new List<Order>();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.GetConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from Orders where OrderDate BETWEEN '" + date1 + "' and '" + date2 + "'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                var order1 = new Order
                                {

                                    OrderID = dr.GetInt32(dr.GetOrdinal("OrderID")),
                                    CustomerID = dr.GetString(dr.GetOrdinal("CustomerID")),
                                    EmployeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID")),
                                    OrderDate = dr.GetDateTime(dr.GetOrdinal("OrderDate")),
                                    RequiredDate = dr.GetDateTime(dr.GetOrdinal("RequiredDate")),
                                    ShippedDate = dr.GetDateTime(dr.GetOrdinal("ShippedDate")),
                                    ShipVia = dr.GetInt32(dr.GetOrdinal("ShipVia")),
                                    Freight = dr.GetDecimal(dr.GetOrdinal("Freight")),
                                    ShipName = dr.GetString(dr.GetOrdinal("ShipName")),
                                    ShipAddress = dr.GetString(dr.GetOrdinal("ShipAddress")),
                                    ShipCity = dr.GetString(dr.GetOrdinal("ShipCity")),
                                    ShipRegion = dr.GetString(dr.GetOrdinal("ShipRegion")),
                                    ShipPostalCode = dr.GetString(dr.GetOrdinal("ShipPostalCode")),
                                    ShipCountry = dr.GetString(dr.GetOrdinal("ShipCountry")),

                                };

                                dateListOrder.Add(order1);
                            }
                        }
                    }
                }
                return dateListOrder;
            }
            catch (Exception)
            {

                throw;
            }
        }




        public bool UpdateGridview(int id, string customID, int employeeID, DateTime dt1, DateTime dt2, DateTime dt3, int shipID,
             decimal fr, string name, string address, string city, string region, string postalcode, string country)
        {
            sql = "UPDATE Orders SET CustomerID = '" + customID + "', EmployeeID = '" + employeeID +
                "', OrderDate = '" + dt1 + "', RequiredDate = '" + dt2 + "', ShippedDate = '" + dt3 +
                "', ShipVia = '" + shipID + "', Freight = '" + fr +
               "', ShipName = '" + name + "', ShipAddress = '" + address +
                "', ShipCity = '" + city + "', ShipRegion = '" + region +
                 "', ShipPostalCode = '" + postalcode + "', ShipCountry = '" + country + "' WHERE OrderID = " + id;


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
                        int sonuc = cmd.ExecuteNonQuery();
                        if (sonuc > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }

    }
}
