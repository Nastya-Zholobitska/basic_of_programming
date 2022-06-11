using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace library
{
    /// <summary>
    /// Interaction logic for Загальна_інформація.xaml
    /// </summary>
    public partial class Загальна_інформація : Window
    {
        public Загальна_інформація()
        {
            InitializeComponent();
            Refresh();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        public DataTable dT;


        private void Refresh()
        {
            connection.Open();
            string sqlq = "SELECT COUNT (*) FROM Readers;";
            command = new SqlCommand(sqlq, connection);
            double allc, c1, c2, c3, c4;
            string count = command.ExecuteScalar().ToString();
            allc = Convert.ToInt32(count);
            Count.Text = count;
            sqlq = "SELECT COUNT (*) FROM Readers WHERE Birthday> CONVERT(DATE, DATEADD(YEAR, -20, GETDATE()))";
            command = new SqlCommand(sqlq, connection);
            count = command.ExecuteScalar().ToString();
            Over20.Text = count;

            sqlq = "SELECT COUNT (*) FROM Readers WHERE IDEducation=1;";
            command = new SqlCommand(sqlq, connection);
            c1 = Convert.ToInt32(command.ExecuteScalar().ToString());

            sqlq = "SELECT COUNT (*) FROM Readers WHERE IDEducation=2;";
            command = new SqlCommand(sqlq, connection);
            c2 = Convert.ToInt32(command.ExecuteScalar().ToString());

            sqlq = "SELECT COUNT (*) FROM Readers WHERE IDEducation=3;";
            command = new SqlCommand(sqlq, connection);
            c3 = Convert.ToInt32(command.ExecuteScalar().ToString());

            sqlq = "SELECT COUNT (*) FROM Readers WHERE Degree='є';";
            command = new SqlCommand(sqlq, connection);
            c4 = Convert.ToInt32(command.ExecuteScalar().ToString());

            c1 = Math.Round(c1 / allc * 100, 2);
            c2 = Math.Round(c2 / allc * 100, 2);
            c3 = Math.Round(c3 / allc * 100, 2);
            c4 = Math.Round(c4 / allc * 100, 2);
            count1.Text = c1 + "%";
            count2.Text = c2 + "%";
            count3.Text = c3 + "%";
            count4.Text = c4 + "%";



            connection.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Інформація_про_книги inform = new Інформація_про_книги();
            Hide();
            inform.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Книги__що_закріплені_за_читачем window = new Книги__що_закріплені_за_читачем();
            Hide();
            window.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Читачі__що_взяли_книгу_місяць_тому window = new Читачі__що_взяли_книгу_місяць_тому();
            Hide();
            window.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Коли_книгу_було_закріплено window = new Коли_книгу_було_закріплено();
            Hide();
            window.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Hide();
            window.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
