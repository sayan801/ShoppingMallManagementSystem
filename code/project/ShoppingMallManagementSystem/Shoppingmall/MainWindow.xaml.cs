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

namespace WpfApplication1
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

        //private void Hyperlink_Click1(object sender, RoutedEventArgs e)
        //{
        //    WpfApplication1.Groundfloor obj = new Groundfloor();
        //    obj.Show();
            
             
        //}

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void thrdflrHprlnk_Click(object sender, RoutedEventArgs e)
        {
            WpfApplication1.firstfloor obj1 = new firstfloor();
            obj1.Show();
        }

        private void Hyperlink_click(object sender, MouseEventArgs e)
        {
            WpfApplication1.Groundfloor obj = new Groundfloor();
               obj.Show();
        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void floor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void feed_back_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void product_Click(object sender, RoutedEventArgs e)
        //{
        // WpfApplication1.Uproduct obj=new Uproduct;
        //    Uproduct.Show();
        //}

       
       
       
    }
}
