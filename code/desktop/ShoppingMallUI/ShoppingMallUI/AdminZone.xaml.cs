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
using ShoppingMallData;
using ShoppingMallDb;
using System.Collections.ObjectModel;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchProductData();
            fetchShopData();
        }

        private void adminloginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (adminUserNameTB.Text.Equals("") && adminUserPassPb.Password.Equals(""))
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
        private void clearProductFields()
        {
            nameTB.Text = BrandTB.Text = productdescriptionTB.Text = "";
            ProductypeCB.SelectedIndex = 1; 
        }
        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            clearProductFields();
        }

        private void submitproductkBtn_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMallData.ProductInfo newProduct = new ShoppingMallData.ProductInfo();

            newProduct.id = GenerateId();

            newProduct.name = nameTB.Text;
            newProduct.brand = BrandTB.Text;
            newProduct.type = ProductypeCB.Text;
            newProduct.description = productdescriptionTB.Text;



            ShoppingMallDb.DbInteraction.DoEnterProduct(newProduct);
            clearProductFields();
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        ObservableCollection<ProductInfo> _productsCollection = new ObservableCollection<ProductInfo>();


        public ObservableCollection<ProductInfo> productsCollection
        {
            get
            {
                return _productsCollection;
            }
        }
      

        private void fetchProductData()
        {
            List<ProductInfo> products = DbInteraction.GetAllProductList();

            _productsCollection.Clear();

            foreach (ProductInfo product in products)
            {
                _productsCollection.Add(product);
            }
        }

        private void submitkShopmangBtn_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMallData.ShopInfo newShop = new ShoppingMallData.ShopInfo();

            newShop.id = GenerateId();

            newShop.name = shopnameTB.Text;
            newShop.tag = shopTagTB.Text;
            newShop.type = shopTypeCB.Text;
            newShop.rating = shopRateTB.Text;
            newShop.description = shopDescriptionTB.Text;

            ShoppingMallDb.DbInteraction.DoEnterShop(newShop);
            
        }

        ObservableCollection<ShopInfo> _shopsCollection = new ObservableCollection<ShopInfo>();


        public ObservableCollection<ShopInfo> shopsCollection
        {
            get
            {
                return _shopsCollection;
            }
        }


        private void fetchShopData()
        {
            List<ShopInfo> shops = DbInteraction.GetAllShopList();

            _shopsCollection.Clear();

            foreach (ShopInfo shop in shops)
            {
                _shopsCollection.Add(shop);
            }
        }

       
    }
}
