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

namespace phonebook
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost; user id=root;password=technicise;database=test;persist security info=false");

//open the connection

if (msqlConnection.State != System.Data.ConnectionState.Open)

msqlConnection.Open();

//define the command reference

MySql.Data.MySqlClient.MySqlCommand msqlcommand = new MySql.Data.MySqlClient.MySqlCommand();

//define the connection used by the command object

msqlcommand.Connection = msqlConnection;

//define the command text

msqlcommand.CommandText = "insert into phonebook(id,name,mobileno)" + "values(@id,@name,@mobileno)";

//add values provided by user

msqlcommand.Parameters.AddWithValue("@id",id.Text);

msqlcommand.Parameters.AddWithValue("@name", name.Text);
msqlcommand.Parameters.AddWithValue("@mobileno", mobileno.Text);

msqlcommand.ExecuteNonQuery();

//close the connection

msqlConnection.Close();

//empty the text boxes

id.Text = null;

name.Text = null;
mobileno.Text = null;

MessageBox.Show("Info Added");

 
        }
    }
}
