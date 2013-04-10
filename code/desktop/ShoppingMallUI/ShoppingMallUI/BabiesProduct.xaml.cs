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
    /// Interaction logic for BabiesProduct.xaml
    /// </summary>
    public partial class BabiesProduct : UserControl
    {
        public BabiesProduct()
        {
            InitializeComponent();
        }


        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Label).ContextMenu.IsEnabled = true;
            (sender as Label).ContextMenu.PlacementTarget = (sender as Label);
            (sender as Label).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Label).ContextMenu.IsOpen = true;
       
        }

        private void Label_MouseEnter_1(object sender, MouseEventArgs e)
        {
            (sender as Label).ContextMenu.IsEnabled = true;
            (sender as Label).ContextMenu.PlacementTarget = (sender as Label);
            (sender as Label).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Label).ContextMenu.IsOpen = true;
       
        }

      

       
    }
}
