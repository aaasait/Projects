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
using System.Data;
using System.Data.SqlClient;

namespace WPFNwdProject
{
    /// <summary>
    /// Interaction logic for LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        public LoginWin()
        {
            InitializeComponent();

            btnLogin.Click += BtnLogin_Click;
            btnMinimize.Click += BtnMinimize_Click;
            btnClose.Click += BtnClose_Click;
        }
     
        SqlDataReader dr;
       
        int userID;
        

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUser.Text == string.Empty)
                {
                    MessageBox.Show("FirstName no null value");
                }
                if (txtPass.Password == string.Empty)
                {
                    MessageBox.Show("LastName no null value");
                }

                else if(txtUser.Text != string.Empty && txtPass.Password != string.Empty)
                {
                    string userName = txtUser.Text;
                    string password = txtPass.Password;
                    string sql = "SELECT * FROM Employees where FirstName='" + txtUser.Text + "' AND LastName='" + txtPass.Password + "'";
                    using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            
                            dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                conn.Close();
                                conn.Open();

                                string query = "SELECT EmployeeID from Employees where FirstName='" + txtUser.Text + "'";
                                SqlCommand cmd_id = new SqlCommand(query, conn);

                                int result_id = (int)cmd_id.ExecuteScalar();
                                conn.Close();
                                userID = Convert.ToInt32(result_id);
                              

                                MainWindow MainWin = new MainWindow();
                                MainWin.Show();
                                this.Close();


                            }

                            else
                            {

                                MessageBox.Show(" Error FirstName or LastName ! ");

                            }
                        }
                        conn.Close();

                    }

                }
                else
                {
                    MessageBox.Show(" Error Not Null.. ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        
            
       
        }

      
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


    
    }
}
