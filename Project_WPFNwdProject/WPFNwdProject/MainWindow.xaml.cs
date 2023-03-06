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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WPFNwdProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            
        public MainWindow()
        {
            InitializeComponent();


            btnLists.Click += BtnLists_Click;
            btnOrders.Click += BtnOrders_Click;
            btnSearch.Click += BtnSearch_Click;
            btnExit.Click += BtnExit_Click;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlCall.UCCall(ucGet, new UCDataList());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
         
            UserControlCall.UCCall(ucGet, new UCFilter());
           
        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            UserControlCall.UCCall(ucGet, new UCOrders());
           
        }

        private void BtnLists_Click(object sender, RoutedEventArgs e)
        {
            UserControlCall.UCCall(ucGet, new UCDataList());
            
        }
   

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ClickCount == 2)
                {
                    if (IsMaximized)
                    {
                        this.WindowState = WindowState.Normal;
                        this.Width = 1280;
                        this.Height = 780;

                        IsMaximized = false;
                    }
                    else
                    {
                        this.WindowState = WindowState.Maximized;
                        IsMaximized = true;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
