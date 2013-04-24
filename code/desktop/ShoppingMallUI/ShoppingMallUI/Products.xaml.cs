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
//using Microsoft.Windows.Controls;
using ShoppingMallData;
using System.Collections.ObjectModel;
using ShoppingMallDb;

namespace ShoppingMall
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        ObservableCollection<ProductInfo> _productsCollection = new ObservableCollection<ProductInfo>();


        public ObservableCollection<ProductInfo> productsCollection
        {
            get
            {
                return _productsCollection;
            }
        }


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

        private void fetchProductData()
        {
            List<ProductInfo> products = DbInteraction.GetAllProductList();

            _productsCollection.Clear();

            foreach (ProductInfo product in products)
            {
                _productsCollection.Add(product);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            fetchProductData();
        }

        private void productDetailsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ProductInfo productInfoObj = _productsCollection.ElementAt(productDetailsList.SelectedIndex);

             List<ProductInfo> products = DbInteraction.GetSelectedProductList(productInfoObj);

             productNameTb.Text = productInfoObj.name;
            productDetailsTBlock.Text = productInfoObj.description;
        }

        private void prdfdbckbtn_Click(object sender, RoutedEventArgs e)
        {
            if (!nameTb.Text.Equals("") && !mailTb.Text.Equals("") && !ratingTb.Text.Equals("") && !feedbackTb.Text.Equals(""))
            {
            
            ShoppingMallData.FeedbackInfo newFeedback = new ShoppingMallData.FeedbackInfo();

            newFeedback.id = GenerateId();

            newFeedback.item = productNameTb.Text;
            newFeedback.feedDate = feedDateDp.SelectedDate.Value;
            newFeedback.name = nameTb.Text;
            newFeedback.email = mailTb.Text;
            newFeedback.rate = ratingTb.Text;
            newFeedback.feedback = feedbackTb.Text;



            ShoppingMallDb.DbInteraction.DoEnterFeedback(newFeedback);
            
            //fetchFeedBackData();
            clearProductfeedbackFields();
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

        private void clearProductfeedbackFields()
        {
            nameTb.Text = mailTb.Text = ratingTb.Text = feedbackTb.Text = "";
        }
        private void clearProductfeedbackBtn_Click(object sender, RoutedEventArgs e)
        {
            clearProductfeedbackFields();
        }

        private void goProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (productNameSrchCB.Text == "")
                fetchProductData();
            else
            {
                ProductInfo prodctInfo = new ProductInfo();
                prodctInfo.name = productNameSrchCB.Text;


                List<ProductInfo> products = DbInteraction.searchProductList(prodctInfo);

                _productsCollection.Clear();

                foreach (ProductInfo product in products)
                {
                    _productsCollection.Add(product);
                }
            }
        }

        private void refreshProductBtn_Click(object sender, RoutedEventArgs e)
        {
            fetchProductData();
        }



        }
        }



     
    


