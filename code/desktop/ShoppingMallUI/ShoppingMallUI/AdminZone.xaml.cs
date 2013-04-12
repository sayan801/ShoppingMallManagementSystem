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



            ShoppingMallDb.DbInteraction.DoEnterProduct(newProduct);
            clearProductFields();
            fetchProductData();
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
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

        ObservableCollection<FeedbackInfo> _feedbackCollection = new ObservableCollection<FeedbackInfo>();


        public ObservableCollection<FeedbackInfo> feedbackCollection
        {
            get
            {
                return _feedbackCollection;
            }
        }
       

        private void fetchFeedBackData()
        {
            List<FeedbackInfo> feedbacks = DbInteraction.GetAllFeedbackList();

            _feedbackCollection.Clear();

            foreach (FeedbackInfo feedback in feedbacks)
            {
                _feedbackCollection.Add(feedback);
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

        private FeedbackInfo GetSelectedFeedbackItem()
        {
            FeedbackInfo feedbackToDelete = null;
            if (feedbackView.SelectedIndex == -1)
                MessageBox.Show("please select an item");
            else
            {
                FeedbackInfo i = (FeedbackInfo)feedbackView.SelectedItem;
                feedbackToDelete = _feedbackCollection.Where(item => item.id.Equals(i.id)).First();
            }
            return feedbackToDelete;
        }

        private void deleteFeedbackBtn_Click(object sender, RoutedEventArgs e)
        {
            FeedbackInfo feedbackToDelete = GetSelectedFeedbackItem();
            if (feedbackToDelete != null)
            {
                feedbackCollection.Remove(feedbackToDelete);
                ShoppingMallDb.DbInteraction.DeleteFeedback(feedbackToDelete.id);
            }
        }
        #endregion
        
    }
}

