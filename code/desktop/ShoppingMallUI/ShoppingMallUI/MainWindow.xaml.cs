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
            
            product.IsEnabled = false;
            shop.IsEnabled = true;
            floor.IsEnabled = true;
            contactusBtn.IsEnabled = true;
            adminZoneobjHL.IsEnabled = true;

            var bc = new BrushConverter();
            product.Background = (Brush)bc.ConvertFrom("#FFDFEBF2");
            product.Foreground = (Brush)bc.ConvertFrom("#FF0966DF");
        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMall.Shops shopobj = new ShoppingMall.Shops();
            infodocP.Children.Clear();
            infodocP.Children.Add(shopobj);
            
            product.IsEnabled = true;
            shop.IsEnabled = false;
            floor.IsEnabled = true;
            contactusBtn.IsEnabled = true;
            adminZoneobjHL.IsEnabled = true;
        }


        private void contactusBtn_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMall.ContactUs ContactUsobj = new ShoppingMall.ContactUs();
            infodocP.Children.Clear();
            infodocP.Children.Add(ContactUsobj);

            product.IsEnabled = true;
            shop.IsEnabled = true;
            floor.IsEnabled = true;
            contactusBtn.IsEnabled = false;
            adminZoneobjHL.IsEnabled = true;
        }
        private void adminZoneobjHL_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMall.AdminZone AdminZoneobj = new ShoppingMall.AdminZone();
            infodocP.Children.Clear();
            infodocP.Children.Add(AdminZoneobj);

            product.IsEnabled = true;
            shop.IsEnabled = true;
            floor.IsEnabled = true;
            contactusBtn.IsEnabled = true;
            adminZoneobjHL.IsEnabled = false;
        }

        private void clearshopfeedbackFields()
        {
            
        }

        private void floor_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMall.Floor Floorobj = new ShoppingMall.Floor();
            infodocP.Children.Clear();
            infodocP.Children.Add(Floorobj);

            product.IsEnabled = true;
            shop.IsEnabled = true;
            floor.IsEnabled = false;
            contactusBtn.IsEnabled = true;
            adminZoneobjHL.IsEnabled = true;
        }
    }
}
