using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlConnectionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Student
    {
        public string Studentid;
        public string Firstname;
        public string Lastname;
        public string Address;
        public string Postcode;
        public string Telephone;
    }

    public partial class MainWindow : Window
    {
        //BitmapImage bitmap;

        string sqlQuery;
        string server = "localhost", username = "root", password = "", database = "stucon";

        MySqlConnection sqlConn = new();
        MySqlCommand sqlCmd = new();
        DataTable sqlDt = new();
        DataSet sqlDs = new();
        MySqlDataReader sqlRd;
        MySqlDataAdapter dtA = new();

        public MainWindow()
        {
            InitializeComponent();
            UpLoadData();
        }

        private void UpLoadData()
        {
            sqlDt.Clear();
            sqlConn.ConnectionString = "server=" + server + ";" 
                                    + "username=" + username + ";" 
                                    + "password=" + password + ";" 
                                    + "database=" + database + ";";
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "SELECT * FROM stucon.stucon;";

            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView.ItemsSource = null;
            dataGridView.ItemsSource = sqlDt.AsDataView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.ConnectionString = "server=" + server + ";"
                                    + "username=" + username + ";"
                                    + "password=" + password + ";"
                                    + "database=" + database + ";";
            try
            {
                sqlConn.Open();

                sqlQuery = $"INSERT INTO `stucon` (`Studentid`, `Firstname`, `Lastname`, `Address`, `Postcode`, `Telephone`) " +
                            $"VALUES ('{studentID.Text}', '{firstname.Text}', '{surname.Text}', " +
                            $"'{address.Text}', '{postCode.Text}', '{telephone.Text}');";

                sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlRd = sqlCmd.ExecuteReader();

                sqlConn.Close();
                ClearInputTextBoxes();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            
            UpLoadData();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgBoxResult;

            msgBoxResult = MessageBox.Show(
                "Confirm if you want to exit app!", 
                "MySql Connector", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question
                );

            if (msgBoxResult == MessageBoxResult.Yes)
                App.Current.Shutdown();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.ConnectionString = "server=" + server + ";"
                                    + "username=" + username + ";"
                                    + "password=" + password + ";"
                                    + "database=" + database + ";";
            sqlConn.Open();

            try
            {
                sqlCmd.Connection = sqlConn;

                sqlCmd.CommandText = "UPDATE stucon.stucon SET Studentid=@Studentid, Firstname=@Firstname, " +
                    "Lastname=@Surname, Address=@Address, Postcode=@Postcode, Telephone=@Telephone" +
                    " WHERE Studentid = @Studentid;";

                sqlCmd.CommandType = CommandType.Text;

                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@Studentid", studentID.Text);
                sqlCmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                sqlCmd.Parameters.AddWithValue("@Surname", surname.Text);
                sqlCmd.Parameters.AddWithValue("@Address", address.Text);
                sqlCmd.Parameters.AddWithValue("@Postcode", postCode.Text);
                sqlCmd.Parameters.AddWithValue("@Telephone", telephone.Text);

                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                UpLoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView student = dataGridView.SelectedItem as DataRowView;

                studentID.Text = student.Row.ItemArray[0].ToString();
                firstname.Text = student.Row.ItemArray[1].ToString();
                surname.Text = student.Row.ItemArray[2].ToString();
                address.Text = student.Row.ItemArray[3].ToString();
                postCode.Text = student.Row.ItemArray[4].ToString();
                telephone.Text = student.Row.ItemArray[5].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearInputTextBoxes();
                txtSearch.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearInputTextBoxes()
        {
            foreach (TextBox txtBox in userInputGrid.Children.OfType<TextBox>())
                txtBox.Clear();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    double height = dataGridView.Height;
            //    dataGridView.Height = dataGridView.Items.Count * dataGridView.ActualHeight;
            //}
            //catch ()
            //{

            //}

            MessageBox.Show("No i po co to klikasz???", "MySql Connector", MessageBoxButton.OK, MessageBoxImage.Question);
        }
    }
}
