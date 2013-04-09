using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingMallData;

namespace ShoppingMallDb
{
    public class DbInteraction
    {
        static string passwordCurrent = "technicise";
        static string dbmsCurrent = "shoppingdb";

        private static MySql.Data.MySqlClient.MySqlConnection OpenDbConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

            //open the connection
            if (msqlConnection.State != System.Data.ConnectionState.Open)
                msqlConnection.Open();

            return msqlConnection;
        }


        #region FeedBack
        #region Insert FeedBack
        public static int DoEnterFeedback(FeedbackInfo NewFeedback)
        {
            return DoRegisterNewFeedbackindb(NewFeedback);
        }

        private static int DoRegisterNewFeedbackindb(FeedbackInfo NewFeedback)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO feedback(id,feedDate,name,address,mobileno,email,type,feedback) "
                                    + "VALUES(@id,@feedDate,@name,@address,@mobileno,@email,@type,@feedback)";

                msqlCommand.Parameters.AddWithValue("@id", NewFeedback.id);
                msqlCommand.Parameters.AddWithValue("@feedDate", NewFeedback.feedDate);
                msqlCommand.Parameters.AddWithValue("@name", NewFeedback.name);
                msqlCommand.Parameters.AddWithValue("@address", NewFeedback.address);
                msqlCommand.Parameters.AddWithValue("@mobileno", NewFeedback.mobileno);
                msqlCommand.Parameters.AddWithValue("@email", NewFeedback.email);
                msqlCommand.Parameters.AddWithValue("@type", NewFeedback.type);
                msqlCommand.Parameters.AddWithValue("@feedback", NewFeedback.feedback);
                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }
        #endregion
        #region Display Feedback

        public static List<FeedbackInfo> GetAllFeedbackList()
        {
            return QueryAllFeedbackList();
        }

        private static List<FeedbackInfo> QueryAllFeedbackList()
        {
            List<FeedbackInfo> FeedbackList = new List<FeedbackInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From feedback;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    FeedbackInfo Feedback = new FeedbackInfo();

                    Feedback.feedDate = msqlReader.GetDateTime("feedDate");
                    Feedback.name = msqlReader.GetString("name");
                    Feedback.address = msqlReader.GetString("address");
                    Feedback.mobileno = msqlReader.GetString("mobileno");
                    Feedback.email = msqlReader.GetString("email");
                    Feedback.type = msqlReader.GetString("type");
                    Feedback.feedback = msqlReader.GetString("feedback");

                    FeedbackList.Add(Feedback);
                }
            }

            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return FeedbackList;

        }
        #endregion
        #endregion
    }
}
