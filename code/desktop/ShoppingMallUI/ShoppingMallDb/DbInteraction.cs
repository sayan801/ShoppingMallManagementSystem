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

                    Feedback.id = msqlReader.GetString("id");
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
        #region Delete Feedback

        public static void DeleteFeedback(string feedbackToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM feedback WHERE id=@feedbackToDelete";
                msqlCommand.Parameters.AddWithValue("@feedbackToDelete", feedbackToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion
        #endregion

        #region Product
        #region Insert Product

        public static int DoEnterProduct(ProductInfo NewProduct)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO product(id,name,brand,type,description) "
                                    + "VALUES(@id,@name,@brand,@type,@description)";

                msqlCommand.Parameters.AddWithValue("@id", NewProduct.id);
                msqlCommand.Parameters.AddWithValue("@name", NewProduct.name);
                msqlCommand.Parameters.AddWithValue("@brand", NewProduct.brand);
                msqlCommand.Parameters.AddWithValue("@type", NewProduct.type);
                msqlCommand.Parameters.AddWithValue("@description", NewProduct.description);
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
        #region Display Product

        public static List<ProductInfo> GetAllProductList()
        {
            return QueryAllProductList();
        }

        private static List<ProductInfo> QueryAllProductList()
        {
            List<ProductInfo> ProductList = new List<ProductInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From product;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ProductInfo Product = new ProductInfo();

                    Product.id = msqlReader.GetString("id");
                    Product.name = msqlReader.GetString("name");
                    Product.brand = msqlReader.GetString("brand");
                    Product.type = msqlReader.GetString("type");
                    Product.description = msqlReader.GetString("description");

                    ProductList.Add(Product);
                }
            }

            catch (Exception er)
            {
            }
            finally
            {
              
                msqlConnection.Close();
            }

            return ProductList;

        }
        #endregion
        #region Delete Product

        public static void DeleteProduct(string productToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM product WHERE id=@productToDelete";
                msqlCommand.Parameters.AddWithValue("@productToDelete", productToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion
        #endregion

        
        #region Insert Shop

        public static int DoEnterShop(ShopInfo NewShop)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO shop(id,name,tag,type,rating,description) "
                                    + "VALUES(@id,@name,@tag,@type,@rating,@description)";

                msqlCommand.Parameters.AddWithValue("@id", NewShop.id);
                msqlCommand.Parameters.AddWithValue("@name", NewShop.name);
                msqlCommand.Parameters.AddWithValue("@tag", NewShop.tag);
                msqlCommand.Parameters.AddWithValue("@type", NewShop.type);
                msqlCommand.Parameters.AddWithValue("@rating", NewShop.rating);
                msqlCommand.Parameters.AddWithValue("@description", NewShop.description);
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

        #region Display Shop

        public static List<ShopInfo> GetAllShopList()
        {
            return QueryAllShopList();
        }

        private static List<ShopInfo> QueryAllShopList()
        {
            List<ShopInfo> ShopList = new List<ShopInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From shop;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ShopInfo Shop = new ShopInfo();

                    Shop.id = msqlReader.GetString("id");
                    Shop.name = msqlReader.GetString("name");
                    Shop.tag = msqlReader.GetString("tag");
                    Shop.type = msqlReader.GetString("type");
                    Shop.type = msqlReader.GetString("rating");
                    Shop.description = msqlReader.GetString("description");

                    ShopList.Add(Shop);
                }
            }

            catch (Exception er)
            {
            }
            finally
            {

                msqlConnection.Close();
            }

            return ShopList;

        }
        #endregion

        #region Delete Shop

        public static void DeleteShop(string shopToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM shop WHERE id=@shopToDelete";
                msqlCommand.Parameters.AddWithValue("@shopToDelete", shopToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion
    }
}
