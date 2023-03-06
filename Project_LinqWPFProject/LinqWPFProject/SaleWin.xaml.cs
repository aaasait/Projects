using System;
using System.Collections;
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

namespace LinqWPFProject
{
    /// <summary>
    /// Interaction logic for SaleWin.xaml
    /// </summary>
    public partial class SaleWin : Window
    {

       
        public SaleWin()
        {
            InitializeComponent();
            MainWindow mains= new MainWindow();
           // SaleList.ItemsSource = mains.Sales;

        }

        private void FilterTextBoxSale_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FilterSale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
