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
    /// Interaction logic for AdminZone.xaml
    /// </summary>
    public partial class AdminZone : UserControl
    {
        public AdminZone()
        {
            InitializeComponent();
        }

        private void adminloginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (adminUserNameTB.Text.Equals("1") && adminUserPassPb.Password.Equals("1"))
            {
                manageadminUG.Visibility = Visibility.Visible;
                loginUG.Visibility = Visibility.Collapsed;
                adminlogoutBtn.Visibility = Visibility.Visible;
                clearSecurityFields();
            }
        }

        private void adminlogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            manageadminUG.Visibility = Visibility.Collapsed;
            loginUG.Visibility = Visibility.Visible;
            adminlogoutBtn.Visibility = Visibility.Collapsed;
            clearSecurityFields();
        }

        private void clearSecurityFields()
        {
            adminUserNameTB.Text = adminUserPassPb.Password = "";
        }

        private void adminresetBtn_Click(object sender, RoutedEventArgs e)
        {
            clearSecurityFields();
        }
    }
}
