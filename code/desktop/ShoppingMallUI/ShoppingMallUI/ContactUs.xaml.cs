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
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUs : UserControl
    {
        public ContactUs()
        {
            InitializeComponent();
        }
        #region insert FeedBack
        private void submitFdBckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!nameTB.Text.Equals("") && !addressTB.Text.Equals("") && !mobilenoTB.Text.Equals("") && !emailTB.Text.Equals("") && !typeCB.Text.Equals("") && !contactusTB.Text.Equals(""))
            {
            
            ShoppingMallData.ContactusInfo newContactus = new ShoppingMallData.ContactusInfo();

            newContactus.id = GenerateId();

            newContactus.feedDate = feedDateDp.SelectedDate.Value;
            newContactus.name = nameTB.Text;
            newContactus.address = addressTB.Text;
            newContactus.mobileno = mobilenoTB.Text;
            newContactus.email = emailTB.Text;
            newContactus.type = typeCB.Text;
            newContactus.feedback = contactusTB.Text;



            ShoppingMallDb.DbInteraction.DoEnterContactus(newContactus);
            clearFeedBackFields();
            fetchFeedBackData();

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

        private void resetFdbckBtn_Click(object sender, RoutedEventArgs e)
        {
            clearFeedBackFields();
        }
        private void clearFeedBackFields()
        {
            nameTB.Text = addressTB.Text = mobilenoTB.Text = emailTB.Text = typeCB.Text= contactusTB.Text = "";
        }

        #endregion

        ObservableCollection<ContactusInfo> _contactusCollection = new ObservableCollection<ContactusInfo>();


        public ObservableCollection<ContactusInfo> contactusCollection
        {
            get
            {
                return _contactusCollection;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchFeedBackData();
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
    }
}
