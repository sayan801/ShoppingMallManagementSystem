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
using Microsoft.Windows.Controls;

namespace ShoppingMall
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        public Products()
        {
            InitializeComponent();
        }

        //private void babiesproduct_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    ShoppingMall.BabiesProduct bobj = new BabiesProduct();
        //    upinfo.Children.Clear();
        //    upinfo.Children.Add(bobj);

        //}
        private void Slider_ValueChanged(
    object sender,
    RoutedPropertyChangedEventArgs<double> e)
{
    var slider = sender as Slider;
    var tick = slider.Ticks
        .Where(xx => Math.Abs(e.NewValue - xx) < slider.LargeChange);
    if (tick.Any())
    {
        var newValue = tick.First();
        if (e.NewValue != newValue)
        {
            //DispatcherInvoke(() => slider.Value = newValue);
        }
    }
}

    }
}
