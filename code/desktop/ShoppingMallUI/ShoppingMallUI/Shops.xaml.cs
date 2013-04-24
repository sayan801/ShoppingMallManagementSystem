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
    /// Interaction logic for Shops.xaml
    /// </summary>
    public partial class Shops : UserControl
    {
        ObservableCollection<ShopInfo> _shopsCollection = new ObservableCollection<ShopInfo>();


        public ObservableCollection<ShopInfo> shopsCollection
        {
            get
            {
                return _shopsCollection;
            }
        }

        public Shops()
        {
            InitializeComponent();
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            fetchShopData();

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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShopInfo shopInfoObj = _shopsCollection.ElementAt(shopDetailsList.SelectedIndex);
            List<ShopInfo> shops = DbInteraction.GetSelectedShopList(shopInfoObj);
            shopNameTb.Text = shopInfoObj.name;
            shopdetailsTBlock.Text = shopInfoObj.description;
        }

        private void submitshopBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (!nameTb.Text.Equals("") && !mailTb.Text.Equals("") && !ratingTb.Text.Equals("") && !feedbackTb.Text.Equals(""))
            {
            ShoppingMallData.FeedbackInfo newFeedback = new ShoppingMallData.FeedbackInfo();

            newFeedback.id = GenerateId();

            newFeedback.item = shopNameTb.Text;
            newFeedback.feedDate = feedDateDp.SelectedDate.Value;
            newFeedback.name = nameTb.Text;
            newFeedback.email = mailTb.Text;
            newFeedback.rate = ratingTb.Text;
            newFeedback.feedback = feedbackTb.Text;



            ShoppingMallDb.DbInteraction.DoEnterFeedback(newFeedback);
            clearshopfeedbackFields();
            //fetchFeedBackData();
            }
            else
            {
                MessageBox.Show("Please Insert Info Properly");
            }
        }
        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void clearshopfeedbackFields()
        {
            nameTb.Text = mailTb.Text = ratingTb.Text = feedbackTb.Text = "";
        }
        private void resetshopFeedback_Click(object sender, RoutedEventArgs e)
        {
            clearshopfeedbackFields();
        }
       
    }
}
