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
    /// Interaction logic for Uproduct.xaml
    /// </summary>
    public partial class Uproduct : UserControl
    {
        public Uproduct()
        {
            InitializeComponent();
        }

        private void babiesproduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WpfApplication1.BabiesProduct bpobj = new BabiesProduct();
            upinfo.Children.Clear();
            upinfo.Children.Add(bpobj);
        }

       
    }

}
