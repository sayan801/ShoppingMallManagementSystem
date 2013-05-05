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
using System.IO;

namespace ImageInsertion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void submitbutton1_Click(object sender, RoutedEventArgs e)
        {
            DoRegisterNewContactusindb(pathTextBox.Text);
        }

        string passwordCurrent = "technicise";
        string dbmsCurrent = "photodb";

        private MySql.Data.MySqlClient.MySqlConnection OpenDbConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

            //open the connection
            if (msqlConnection.State != System.Data.ConnectionState.Open)
                msqlConnection.Open();

            return msqlConnection;
        }


        public int DoRegisterNewContactusindb(string path)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference

                MySql.Data.MySqlClient.MySqlCommand msqlcommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object

                msqlcommand.Connection = msqlConnection;

                //define the command text

                msqlcommand.CommandText = "insert into photos(size,img, description)" + "values( @size,@img, @description)";

                //add values provided by user

                byte[] imgbytes = File.ReadAllBytes(path);

                msqlcommand.Parameters.AddWithValue("@size", imgbytes.Length);

                msqlcommand.Parameters.AddWithValue("@img", imgbytes);

                msqlcommand.Parameters.AddWithValue("@description", "This file is taken from " + path);

                msqlcommand.ExecuteNonQuery();

                //close the connection

                msqlConnection.Close();
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();
            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select img,size From photos where idphotos = "+idtextBox1.Text+ " ;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {

                    //MemoryStream ms;

                    int fileSize = msqlReader.GetInt32("size");
                    byte[] rawData = new byte[fileSize];
                    msqlReader.GetBytes(msqlReader.GetOrdinal("img"), 0, rawData, 0, (Int32)fileSize);

                    File.WriteAllBytes("d:\\test" + DateTime.Now.ToOADate().ToString() + ".jpg", rawData);

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
        }
    }



}
