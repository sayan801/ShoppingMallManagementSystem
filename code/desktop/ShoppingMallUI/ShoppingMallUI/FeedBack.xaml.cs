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
    /// Interaction logic for FeedBack.xaml
    /// </summary>
    public partial class FeedBack : UserControl
    {
        public FeedBack()
        {
            InitializeComponent();
        }
        #region insert FeedBack
        private void submitFdBckBtn_Click(object sender, RoutedEventArgs e)
        {
            ShoppingMallData.FeedbackInfo newFeedback = new ShoppingMallData.FeedbackInfo();

            newFeedback.id = GenerateId();

            newFeedback.feedDate = feedDateDp.SelectedDate.Value;
            newFeedback.name = nameTB.Text;
            newFeedback.address = addressTB.Text;
            newFeedback.mobileno = mobilenoTB.Text;
            newFeedback.email = emailTB.Text;
            newFeedback.type = typeCB.Text;
            newFeedback.feedback = feedbackTB.Text;



            ShoppingMallDb.DbInteraction.DoEnterFeedback(newFeedback);
            clearFeedBackFields();
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
            nameTB.Text = addressTB.Text = mobilenoTB.Text = emailTB.Text = typeCB.Text= feedbackTB.Text = "";
        }

        #endregion

        ObservableCollection<FeedbackInfo> _feedbackCollection = new ObservableCollection<FeedbackInfo>();


        public ObservableCollection<FeedbackInfo> feedbackCollection
        {
            get
            {
                return _feedbackCollection;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchFeedBackData();
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
    }
}
