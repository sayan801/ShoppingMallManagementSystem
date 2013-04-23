using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoppingMall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void product_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMall.Products productobj = new ShoppingMall.Products();
            infodocP.Children.Clear();
            infodocP.Children.Add(productobj);
            product.Background = Brushes.Blue;
        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMall.Shops shopobj = new ShoppingMall.Shops();
            infodocP.Children.Clear();
            infodocP.Children.Add(shopobj);
            shop.Background = Brushes.Blue;
        }


        private void contactusBtn_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMall.ContactUs ContactUsobj = new ShoppingMall.ContactUs();
            infodocP.Children.Clear();
            infodocP.Children.Add(ContactUsobj);
            contactusBtn.Background = Brushes.Blue;
        }
        private void adminZoneobjHL_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMall.AdminZone AdminZoneobj = new ShoppingMall.AdminZone();
            infodocP.Children.Clear();
            infodocP.Children.Add(AdminZoneobj);
        }

        private void clearshopfeedbackFields()
        {
            
        }
    }
}
