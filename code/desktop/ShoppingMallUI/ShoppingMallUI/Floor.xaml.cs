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
using System.Collections.ObjectModel;
using ShoppingMallData;
using ShoppingMallDb;
namespace ShoppingMall
{
    /// <summary>
    /// Interaction logic for Floor.xaml
    /// </summary>
    public partial class Floor : UserControl
    {
        public Floor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetSelectedGroundFloorItem();
            //GetSelectedFirstFloorItem();
            //GetSelectedSecondFloorItem();
        }

        #region Get Groundfloor Shop
        ObservableCollection<ShopInfo> _shopsCollection = new ObservableCollection<ShopInfo>();


        public ObservableCollection<ShopInfo> shopsCollection
        {
            get
            {
                return _shopsCollection;
            }
        }

        ObservableCollection<FeedbackInfo> _shopFeedbackCollection = new ObservableCollection<FeedbackInfo>();


        public ObservableCollection<FeedbackInfo> shopFeedbackCollection
        {
            get
            {
                return _shopFeedbackCollection;
            }
        }

        private void GetSelectedGroundFloorItem()
        {

            ShopInfo shopInfo = new ShopInfo();
            shopInfo.name = "Ground Floor";


            List<ShopInfo> shops = DbInteraction.getGroundfloorShopList(shopInfo);

            _shopsCollection.Clear();

            foreach (ShopInfo shop in shops)
            {
                _shopsCollection.Add(shop);
            }
        }
        #endregion

        #region Get First Floor Shop
        ObservableCollection<ShopInfo> _frstfloorshopsCollection = new ObservableCollection<ShopInfo>();


        public ObservableCollection<ShopInfo> frstfloorshopsCollection
        {
            get
            {
                return _frstfloorshopsCollection;
            }
        }

        private void GetSelectedFirstFloorItem()
        {

            ShopInfo shopInfo = new ShopInfo();
            shopInfo.name = "First Floor";


            List<ShopInfo> shops = DbInteraction.getFirstFloorShopList(shopInfo);

            _frstfloorshopsCollection.Clear();

            foreach (ShopInfo shop in shops)
            {
                _frstfloorshopsCollection.Add(shop);
            }
        }
        #endregion

        #region Get Second Floor Shop
        ObservableCollection<ShopInfo> _secondfloorshopsCollection = new ObservableCollection<ShopInfo>();


        public ObservableCollection<ShopInfo> secondfloorshopsCollection
        {
            get
            {
                return _secondfloorshopsCollection;
            }
        }

        private void GetSelectedSecondFloorItem()
        {

            ShopInfo shopInfo = new ShopInfo();
            shopInfo.name = "Second Floor";


            List<ShopInfo> shops = DbInteraction.getSecondFloorShopList(shopInfo);

            _secondfloorshopsCollection.Clear();

            foreach (ShopInfo shop in shops)
            {
                _secondfloorshopsCollection.Add(shop);
            }
        }
        #endregion

        private void refreshgroundShopBtn_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedGroundFloorItem();
        }

        private void refreshfirstflrShopBtn_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedFirstFloorItem();
        }

        private void refreshsecondflrShopBtn_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedSecondFloorItem();
        }

        private void ListView_GroundFloorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (shopDetailsList.SelectedIndex != -1)
            {
                ShopInfo shopInfoObj = _shopsCollection.ElementAt(shopDetailsList.SelectedIndex);
            List<ShopInfo> shops = DbInteraction.GetSelectedShopList(shopInfoObj);
            grndflrshopNameTb.Text = shopInfoObj.name;
            grndflrshopdetailsTBlock.Text = shopInfoObj.description;
            availableGroundProductsTBlock.Text = shopInfoObj.availableProduct;

            GetSelectedshopfeedbackGrndflrItem();
            }
            else
                MessageBox.Show("SelectedIndex equals -1");

        }

        private void ListView_FirstFloorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstflrDetailsList.SelectedIndex != -1)
            {
                ShopInfo shopInfoObj = _shopsCollection.ElementAt(firstflrDetailsList.SelectedIndex);
            List<ShopInfo> shops = DbInteraction.GetSelectedShopList(shopInfoObj);
            firstflrshopNameTb.Text = shopInfoObj.name;
            firstflrshopdetailsTBlock.Text = shopInfoObj.description;
            availableFirstProductsTBlock.Text = shopInfoObj.availableProduct;

            GetSelectedshopfeedbackfrstflrItem();
            }
            else
                MessageBox.Show("SelectedIndex equals -1");
        }
        private void ListView_SecondFloorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (secondflrDetailsList.SelectedIndex != -1)
            {
                ShopInfo shopInfoObj = _shopsCollection.ElementAt(secondflrDetailsList.SelectedIndex);
            List<ShopInfo> shops = DbInteraction.GetSelectedShopList(shopInfoObj);
            secondflrshopNameTb.Text = shopInfoObj.name;
            secondflrshopdetailsTBlock.Text = shopInfoObj.description;
            availableSecondProductsTBlock.Text = shopInfoObj.availableProduct;

            GetSelectedshopfeedbackSecondflrItem();
            }
            else
                MessageBox.Show("SelectedIndex equals -1");
        }

        private void GetSelectedshopfeedbackGrndflrItem()
        {
            FeedbackInfo shopInfo = new FeedbackInfo();
            shopInfo.name = grndflrshopNameTb.Text;


            List<FeedbackInfo> shops = DbInteraction.getshopFeedbackList(shopInfo);

            _shopFeedbackCollection.Clear();

            foreach (FeedbackInfo shop in shops)
            {
                _shopFeedbackCollection.Add(shop);
            }
        }

        private void GetSelectedshopfeedbackfrstflrItem()
        {
            FeedbackInfo shopInfo = new FeedbackInfo();
            shopInfo.name = firstflrshopNameTb.Text;


            List<FeedbackInfo> shops = DbInteraction.getshopFeedbackList(shopInfo);

            _shopFeedbackCollection.Clear();

            foreach (FeedbackInfo shop in shops)
            {
                _shopFeedbackCollection.Add(shop);
            }
        }

        private void GetSelectedshopfeedbackSecondflrItem()
        {
            FeedbackInfo shopInfo = new FeedbackInfo();
            shopInfo.name = secondflrshopNameTb.Text;


            List<FeedbackInfo> shops = DbInteraction.getshopFeedbackList(shopInfo);

            _shopFeedbackCollection.Clear();

            foreach (FeedbackInfo shop in shops)
            {
                _shopFeedbackCollection.Add(shop);
            }
        }

        private void availableProducts_MouseDown(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Go To Product");
        }
    }
}
