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
            fetchFeedBackData();
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
        #region Insert Product
        private void submitproductkBtn_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMallData.ProductInfo newProduct = new ShoppingMallData.ProductInfo();

            newProduct.id = GenerateId();

            newProduct.name = nameTB.Text;
            newProduct.brand = BrandTB.Text;
            newProduct.type = ProductypeCB.Text;
            newProduct.description = productdescriptionTB.Text;
            //newProduct.image = shopimgPhoto.BitmapImage;



            ShoppingMallDb.DbInteraction.DoEnterProduct(newProduct);
            clearProductFields();
            fetchProductData();
            takepic();
            
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
        private void takepic()
        {

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost; user id=root;password=technicise;database=shoppingdb;persist security info=false");



            if (msqlConnection.State != System.Data.ConnectionState.Open)

                msqlConnection.Open();



            MySql.Data.MySqlClient.MySqlCommand msqlcommand = new MySql.Data.MySqlClient.MySqlCommand();



            msqlcommand.Connection = msqlConnection;



            msqlcommand.CommandText = "insert into product(image)" + "values(@image)";



            msqlcommand.Parameters.AddWithValue("@image", prdctimgPhoto);

            msqlcommand.ExecuteNonQuery();



            msqlConnection.Close();



            MessageBox.Show("Info Added");


        }
        #endregion

        #region Get Product
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

        #endregion

        #region Insert Shop
        private void clearShopFields()
        {
            shopnameTB.Text = shopTagTB.Text = shopRateTB.Text = shopDescriptionTB.Text = "";
            shopTypeCB.SelectedIndex = 1;
        }
        private void resetShopmangBtn_Click(object sender, RoutedEventArgs e)
        {
            clearShopFields();
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
            clearShopFields();
            fetchShopData();
        }
        #endregion

        #region Get Shop
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
        #endregion

        #region Get FeedBack

        ObservableCollection<ContactusInfo> _contactusCollection = new ObservableCollection<ContactusInfo>();


        public ObservableCollection<ContactusInfo> contactusCollection
        {
            get
            {
                return _contactusCollection;
            }
        }
       

        private void fetchFeedBackData()
        {
            List<ContactusInfo> contactuss = DbInteraction.GetAllContactusList();

            _contactusCollection.Clear();

            foreach (ContactusInfo contactus in contactuss)
            {
                _contactusCollection.Add(contactus);
            }
        }
        #endregion

        #region Delete Product
        private ProductInfo GetSelectedProductItem()
        {

            ProductInfo productToDelete = null;

            if (productsView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                ProductInfo i = (ProductInfo)productsView.SelectedItem;

                productToDelete = _productsCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return productToDelete;
        }

        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductInfo productToDelete = GetSelectedProductItem();
            if (productToDelete != null)
            {
                productsCollection.Remove(productToDelete);
                ShoppingMallDb.DbInteraction.DeleteProduct(productToDelete.id);
                fetchProductData();
            }
        }
        #endregion

        #region Delete Shop
        private ShopInfo GetSelectedShopItem()
        {

            ShopInfo shopToDelete = null;

            if (shopsView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                ShopInfo i = (ShopInfo)shopsView.SelectedItem;

                shopToDelete = _shopsCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return shopToDelete;
        }

        private void deleteShop_Click(object sender, RoutedEventArgs e)
        {
            ShopInfo shopToDelete = GetSelectedShopItem();
            if (shopToDelete != null)
            {
                shopsCollection.Remove(shopToDelete);
                ShoppingMallDb.DbInteraction.DeleteShop(shopToDelete.id);
                fetchShopData();
            }
        }
        #endregion

        #region Delete FeedBack

        private ContactusInfo GetSelectedContactusItem()
        {
            ContactusInfo contactusToDelete = null;
            if (contactusView.SelectedIndex == -1)
                MessageBox.Show("please select an item");
            else
            {
                ContactusInfo i = (ContactusInfo)contactusView.SelectedItem;
                contactusToDelete = _contactusCollection.Where(item => item.id.Equals(i.id)).First();
            }
            return contactusToDelete;
        }

        private void deleteContactusBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactusInfo contactusToDelete = GetSelectedContactusItem();
            if (contactusToDelete != null)
            {
                contactusCollection.Remove(contactusToDelete);
                ShoppingMallDb.DbInteraction.DeleteContactus(contactusToDelete.id);
            }
        }
        #endregion

        #region Edit Product
        private void editProductBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductInfo productToEdit = GetSelectedProductItem();
            if (productToEdit != null)
            {
                nameTB.Text = productToEdit.name;
                BrandTB.Text = productToEdit.brand;
                ProductypeCB.Text = productToEdit.type;
                productdescriptionTB.Text = productToEdit.description;
            }
            editProductkBtn.Visibility = Visibility.Visible;
            submitproductkBtn.Visibility = Visibility.Collapsed;
        }

        private void editProductkBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductInfo productToEdit = GetSelectedProductItem();

            productToEdit.name = nameTB.Text;
            productToEdit.brand = BrandTB.Text;
            productToEdit.type = ProductypeCB.Text;
            productToEdit.description = productdescriptionTB.Text;



            ShoppingMallDb.DbInteraction.EditProduct(productToEdit);

            clearProductFields();
            editProductkBtn.Visibility = Visibility.Collapsed;
            submitproductkBtn.Visibility = Visibility.Visible;
            fetchProductData();
        }
        #endregion

        #region Edit Shop
        private void editShopBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopInfo shopToEdit = GetSelectedShopItem();
            if (shopToEdit != null)
            {
                shopnameTB.Text = shopToEdit.name;
                shopTagTB.Text = shopToEdit.tag;
                shopTypeCB.Text = shopToEdit.type;
                shopRateTB.Text = shopToEdit.rating;
                shopDescriptionTB.Text = shopToEdit.description;
            }
            UpdateShopmangBtn.Visibility = Visibility.Visible;
            submitkShopmangBtn.Visibility = Visibility.Collapsed;
        }

        private void UpdateShopmangBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopInfo shopToEdit = GetSelectedShopItem();
                        
            shopToEdit.name = shopnameTB.Text;
            shopToEdit.tag = shopTagTB.Text;
            shopToEdit.type = shopTypeCB.Text;
            shopToEdit.rating = shopRateTB.Text;
            shopToEdit.description = shopDescriptionTB.Text;


            ShoppingMallDb.DbInteraction.EditShop(shopToEdit);
            
            clearShopFields();
            UpdateShopmangBtn.Visibility = Visibility.Collapsed;
            submitkShopmangBtn.Visibility = Visibility.Visible;
            fetchShopData();
        }
        #endregion

        private void prdctbrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            var fd = new Microsoft.Win32.OpenFileDialog();
            fd.Filter = "All image formats (*.jpg; *.jpeg; *.bmp; *.png; *.gif)|*.jpg;*.jpeg;*.bmp;*.png;*.gif";
            var ret = fd.ShowDialog();

            if (ret.GetValueOrDefault())
            {
                prdctimagelinkTB.Text = fd.FileName;

                try
                {
                    BitmapImage bmp = new BitmapImage(new Uri(fd.FileName, UriKind.Absolute));
                    prdctimgPhoto.Source = bmp;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid image file.", "Browse", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
        private void shopbrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            var fd = new Microsoft.Win32.OpenFileDialog();
            fd.Filter = "All image formats (*.jpg; *.jpeg; *.bmp; *.png; *.gif)|*.jpg;*.jpeg;*.bmp;*.png;*.gif";
            var ret = fd.ShowDialog();

            if (ret.GetValueOrDefault())
            {
                shopimagelinkTB.Text = fd.FileName;

                try
                {
                    BitmapImage bmp = new BitmapImage(new Uri(fd.FileName, UriKind.Absolute));
                    shopimgPhoto.Source = bmp;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid image file.", "Browse", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }


    }
}

