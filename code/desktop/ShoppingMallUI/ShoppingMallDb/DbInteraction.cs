using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingMallData;

namespace ShoppingMallDb
{
    public class DbInteraction
    {
        static string passwordCurrent = "";
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


        #region Contactus
        #region Insert Contactus
        public static int DoEnterContactus(ContactusInfo NewContactus)
        {
            return DoRegisterNewContactusindb(NewContactus);
        }

        private static int DoRegisterNewContactusindb(ContactusInfo NewContactus)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO contactus(id,feedDate,name,address,mobileno,email,type,feedback) "
                                    + "VALUES(@id,@feedDate,@name,@address,@mobileno,@email,@type,@feedback)";

                msqlCommand.Parameters.AddWithValue("@id", NewContactus.id);
                msqlCommand.Parameters.AddWithValue("@feedDate", NewContactus.feedDate);
                msqlCommand.Parameters.AddWithValue("@name", NewContactus.name);
                msqlCommand.Parameters.AddWithValue("@address", NewContactus.address);
                msqlCommand.Parameters.AddWithValue("@mobileno", NewContactus.mobileno);
                msqlCommand.Parameters.AddWithValue("@email", NewContactus.email);
                msqlCommand.Parameters.AddWithValue("@type", NewContactus.type);
                msqlCommand.Parameters.AddWithValue("@feedback", NewContactus.feedback);
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
        #region Display Contactus

        public static List<ContactusInfo> GetAllContactusList()
        {
            return QueryAllContactusList();
        }

        private static List<ContactusInfo> QueryAllContactusList()
        {
            List<ContactusInfo> ContactusList = new List<ContactusInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From contactus;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ContactusInfo Contactus = new ContactusInfo();

                    Contactus.id = msqlReader.GetString("id");
                    Contactus.feedDate = msqlReader.GetDateTime("feedDate");
                    Contactus.name = msqlReader.GetString("name");
                    Contactus.address = msqlReader.GetString("address");
                    Contactus.mobileno = msqlReader.GetString("mobileno");
                    Contactus.email = msqlReader.GetString("email");
                    Contactus.type = msqlReader.GetString("type");
                    Contactus.feedback = msqlReader.GetString("feedback");

                    ContactusList.Add(Contactus);
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

            return ContactusList;

        }
        #endregion
        #region Delete Contactus

        public static void DeleteContactus(string contactusToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM contactus WHERE id=@contactusToDelete";
                msqlCommand.Parameters.AddWithValue("@contactusToDelete", contactusToDelete);

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

                msqlCommand.CommandText = "INSERT INTO product(id,name,brand,type,description,availableinshop) "
                                    + "VALUES(@id,@name,@brand,@type,@description,@availableinshop)";

                msqlCommand.Parameters.AddWithValue("@id", NewProduct.id);
                msqlCommand.Parameters.AddWithValue("@name", NewProduct.name);
                msqlCommand.Parameters.AddWithValue("@brand", NewProduct.brand);
                msqlCommand.Parameters.AddWithValue("@type", NewProduct.type);
                msqlCommand.Parameters.AddWithValue("@description", NewProduct.description);
                msqlCommand.Parameters.AddWithValue("@availableinshop", NewProduct.availableinshop);
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
                    Product.availableinshop = msqlReader.GetString("availableinshop");

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
        #region Edit Product

        public static void EditProduct(ProductInfo newUpdateProduct)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE product SET name=@name,brand=@brand,type=@type,description=@description  WHERE id=@id";


                msqlCommand.Parameters.AddWithValue("@name", newUpdateProduct.name);
                msqlCommand.Parameters.AddWithValue("@brand", newUpdateProduct.brand);
                msqlCommand.Parameters.AddWithValue("@type", newUpdateProduct.type);
                msqlCommand.Parameters.AddWithValue("@description", newUpdateProduct.description);
                msqlCommand.Parameters.AddWithValue("@id", newUpdateProduct.id);

               

                msqlCommand.ExecuteNonQuery();


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
        #region Search Admin Product

        public static List<ProductInfo> searchProductList(ProductInfo productinfo)
        {
            return searchAllProductList(productinfo);
        }

        private static List<ProductInfo> searchAllProductList(ProductInfo productinfo)
        {
            List<ProductInfo> ProductList = new List<ProductInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From product where id = @input or name = @input or brand = @input or type = @input or description = @input ; ";

                msqlCommand.Parameters.AddWithValue("@input", productinfo.name);
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
                //always close the connection
                msqlConnection.Close();
            }

            return ProductList;
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

                msqlCommand.CommandText = "INSERT INTO shop(id,name,tag,type,availableinfloor,rating,description,availableProduct) "
                                    + "VALUES(@id,@name,@tag,@type,@availableinfloor,@rating,@description,@availableProduct)";

                msqlCommand.Parameters.AddWithValue("@id", NewShop.id);
                msqlCommand.Parameters.AddWithValue("@name", NewShop.name);
                msqlCommand.Parameters.AddWithValue("@tag", NewShop.tag);
                msqlCommand.Parameters.AddWithValue("@type", NewShop.type);
                msqlCommand.Parameters.AddWithValue("@availableinfloor", NewShop.@availableinfloor);
                msqlCommand.Parameters.AddWithValue("@rating", NewShop.rating);
                msqlCommand.Parameters.AddWithValue("@description", NewShop.description);
                msqlCommand.Parameters.AddWithValue("@availableProduct", NewShop.availableProduct);
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
                    Shop.availableinfloor = msqlReader.GetString("availableinfloor");
                    Shop.rating = msqlReader.GetString("rating");
                    Shop.description = msqlReader.GetString("description");
                    Shop.availableProduct = msqlReader.GetString("availableProduct");

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

        #region Edit Shop

        public static void EditShop(ShopInfo newUpdateShop)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE shop SET name=@name,tag=@tag,type=@type,availableinfloor=@availableinfloor,rating=@rating,description=@description  WHERE id=@id";

                               
                
                msqlCommand.Parameters.AddWithValue("@name", newUpdateShop.name);
                msqlCommand.Parameters.AddWithValue("@tag", newUpdateShop.tag);
                msqlCommand.Parameters.AddWithValue("@type", newUpdateShop.type);
                msqlCommand.Parameters.AddWithValue("@availableinfloor", newUpdateShop.availableinfloor);
                msqlCommand.Parameters.AddWithValue("@rating", newUpdateShop.rating);
                msqlCommand.Parameters.AddWithValue("@description", newUpdateShop.description);
                msqlCommand.Parameters.AddWithValue("@id", newUpdateShop.id);

                msqlCommand.ExecuteNonQuery();


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

        #region Search Admin Shop

        public static List<ShopInfo> searchShopList(ShopInfo shopinfo)
        {
            return searchAllShopList(shopinfo);
        }

        private static List<ShopInfo> searchAllShopList(ShopInfo shopinfo)
        {
            List<ShopInfo> ShopList = new List<ShopInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From shop where id = @input or name = @input or tag = @input or type = @input or rating = @input or description = @input ; ";

                msqlCommand.Parameters.AddWithValue("@input", shopinfo.name);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ShopInfo Shop = new ShopInfo();

                    Shop.id = msqlReader.GetString("id");
                    Shop.name = msqlReader.GetString("name");
                    Shop.tag = msqlReader.GetString("tag");
                    Shop.type = msqlReader.GetString("type");
                    Shop.availableinfloor = msqlReader.GetString("availableinfloor");
                    Shop.rating = msqlReader.GetString("rating");
                    Shop.description = msqlReader.GetString("description");

                    ShopList.Add(Shop);
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

            return ShopList;
        }

        #endregion

        public static List<ProductInfo> GetSelectedProductList(ProductInfo productInfoObj)
        {
            List<ProductInfo> ProductList = new List<ProductInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From product where name = @name;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ProductInfo Product = new ProductInfo();
                    msqlCommand.Parameters.AddWithValue("@name", Product.name);
                   

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

        public static List<ShopInfo> GetSelectedShopList(ShopInfo shopInfoObj)
        {
            List<ShopInfo> ShopList = new List<ShopInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From shop where name = @name;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ShopInfo Shop = new ShopInfo();
                    msqlCommand.Parameters.AddWithValue("@name", Shop.name);


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


        #region Insert Feedback
        public static int DoEnterFeedback(FeedbackInfo NewFeedback)
        {
            return DoRegisterFeedbackindb(NewFeedback);
        }

        private static int DoRegisterFeedbackindb(FeedbackInfo NewFeedback)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO feedback(id,feedDate,item,name,email,rate,feedback) "
                                    + "VALUES(@id,@feedDate,@item,@name,@email,@rate,@feedback)";

                msqlCommand.Parameters.AddWithValue("@id", NewFeedback.id);
                msqlCommand.Parameters.AddWithValue("@feedDate", NewFeedback.feedDate);
                msqlCommand.Parameters.AddWithValue("@item", NewFeedback.item);
                msqlCommand.Parameters.AddWithValue("@name", NewFeedback.name);
                msqlCommand.Parameters.AddWithValue("@email", NewFeedback.email);
                msqlCommand.Parameters.AddWithValue("@rate", NewFeedback.rate);
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

        #region Get Ground Floor Shop

        public static List<ShopInfo> getGroundfloorShopList(ShopInfo shopinfo)
        {
            return getGroundfloorAllShopList(shopinfo);
        }

        private static List<ShopInfo> getGroundfloorAllShopList(ShopInfo shopinfo)
        {
            List<ShopInfo> ShopList = new List<ShopInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From shop where availableinfloor = @input ; ";

                msqlCommand.Parameters.AddWithValue("@input", shopinfo.name);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ShopInfo Shop = new ShopInfo();


                    Shop.id = msqlReader.GetString("id");
                    Shop.name = msqlReader.GetString("name");
                    Shop.tag = msqlReader.GetString("tag");
                    Shop.type = msqlReader.GetString("type");
                    Shop.availableinfloor = msqlReader.GetString("availableinfloor");
                    Shop.rating = msqlReader.GetString("rating");
                    Shop.description = msqlReader.GetString("description");
                    

                    ShopList.Add(Shop);
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

            return ShopList;
        }

        #endregion

        #region Get First Floor Shop

        public static List<ShopInfo> getFirstFloorShopList(ShopInfo shopinfo)
        {
            return getFirstfloorAllShopList(shopinfo);
        }

        private static List<ShopInfo> getFirstfloorAllShopList(ShopInfo shopinfo)
        {
            List<ShopInfo> ShopList = new List<ShopInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From shop where availableinfloor = @input ; ";

                msqlCommand.Parameters.AddWithValue("@input", shopinfo.name);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ShopInfo Shop = new ShopInfo();


                    Shop.id = msqlReader.GetString("id");
                    Shop.name = msqlReader.GetString("name");
                    Shop.tag = msqlReader.GetString("tag");
                    Shop.type = msqlReader.GetString("type");
                    Shop.availableinfloor = msqlReader.GetString("availableinfloor");
                    Shop.rating = msqlReader.GetString("rating");
                    Shop.description = msqlReader.GetString("description");


                    ShopList.Add(Shop);
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

            return ShopList;
        }

        #endregion
        
        #region Get First Floor Shop

        public static List<ShopInfo> getSecondFloorShopList(ShopInfo shopinfo)
        {
            return getSecondfloorAllShopList(shopinfo);
        }

        private static List<ShopInfo> getSecondfloorAllShopList(ShopInfo shopinfo)
        {
            List<ShopInfo> ShopList = new List<ShopInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From shop where availableinfloor = @input ; ";

                msqlCommand.Parameters.AddWithValue("@input", shopinfo.name);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ShopInfo Shop = new ShopInfo();


                    Shop.id = msqlReader.GetString("id");
                    Shop.name = msqlReader.GetString("name");
                    Shop.tag = msqlReader.GetString("tag");
                    Shop.type = msqlReader.GetString("type");
                    Shop.availableinfloor = msqlReader.GetString("availableinfloor");
                    Shop.rating = msqlReader.GetString("rating");
                    Shop.description = msqlReader.GetString("description");


                    ShopList.Add(Shop);
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

            return ShopList;
        }

        #endregion


        //#region Display Shop FeedBack

        //public static List<FeedbackInfo> GetAllshopFeedbackCollectionList()
        //{
        //    return QueryshopFeedbackList();
        //}

        //private static List<FeedbackInfo> QueryshopFeedbackList()
        //{
        //    List<FeedbackInfo> shopFeedbackList = new List<FeedbackInfo>();
        //    MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

        //    try
        //    {   //define the command reference
        //        MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
        //        msqlCommand.Connection = msqlConnection;



        //        msqlCommand.CommandText = "Select * From feedback;";
        //        MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

        //        while (msqlReader.Read())
        //        {
        //            FeedbackInfo shopFeedbacks = new FeedbackInfo();


        //            shopFeedbacks.feedDate = msqlReader.GetDateTime("feedDate");
        //            shopFeedbacks.name = msqlReader.GetString("name");
        //            shopFeedbacks.email = msqlReader.GetString("email");
        //            shopFeedbacks.rate = msqlReader.GetString("rate");
        //            shopFeedbacks.feedback = msqlReader.GetString("feedback");

        //            shopFeedbackList.Add(shopFeedbacks);
        //        }
        //    }

        //    catch (Exception er)
        //    {
        //    }
        //    finally
        //    {
        //        //always close the connection
        //        msqlConnection.Close();
        //    }

        //    return shopFeedbackList;

        //}
        //#endregion



        #region Display only selected product Feedback

        public static List<FeedbackInfo> getproductFeedbackList(FeedbackInfo feedbackinfo)
        {
            return getAllproductFeedbackList(feedbackinfo);
        }

        private static List<FeedbackInfo> getAllproductFeedbackList(FeedbackInfo feedbackinfo)
        {
            List<FeedbackInfo> productFeedbackList = new List<FeedbackInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From feedback where item = @input ; ";

                msqlCommand.Parameters.AddWithValue("@input", feedbackinfo.name);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    FeedbackInfo productFeedback = new FeedbackInfo();

                    productFeedback.feedDate = msqlReader.GetDateTime("feedDate");
                    productFeedback.name = msqlReader.GetString("name");
                    productFeedback.email = msqlReader.GetString("email");
                    productFeedback.rate = msqlReader.GetString("rate");
                    productFeedback.feedback = msqlReader.GetString("feedback");


                    productFeedbackList.Add(productFeedback);
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

            return productFeedbackList;
        }

        #endregion

        #region Display only selected shop Feedback

        public static List<FeedbackInfo> getshopFeedbackList(FeedbackInfo feedbackinfo)
        {
            return getAllshopFeedbackList(feedbackinfo);
        }

        private static List<FeedbackInfo> getAllshopFeedbackList(FeedbackInfo feedbackinfo)
        {
            List<FeedbackInfo> shopFeedbackList = new List<FeedbackInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From feedback where item = @input ; ";

                msqlCommand.Parameters.AddWithValue("@input", feedbackinfo.name);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    FeedbackInfo shopFeedback = new FeedbackInfo();

                    shopFeedback.feedDate = msqlReader.GetDateTime("feedDate");
                    shopFeedback.name = msqlReader.GetString("name");
                    shopFeedback.email = msqlReader.GetString("email");
                    shopFeedback.rate = msqlReader.GetString("rate");
                    shopFeedback.feedback = msqlReader.GetString("feedback");


                    shopFeedbackList.Add(shopFeedback);
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

            return shopFeedbackList;
        }

        #endregion
    }
}
