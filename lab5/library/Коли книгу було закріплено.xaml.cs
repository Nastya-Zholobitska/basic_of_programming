using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace library
{
    /// <summary>
    /// Interaction logic for Коли_книгу_було_закріплено.xaml
    /// </summary>
    public partial class Коли_книгу_було_закріплено : Window
    {
        public Коли_книгу_було_закріплено()
        {
            InitializeComponent();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;

 


        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string sqlq = "SELECT Receiving FROM Reader_Book WHERE Reader_Book.IDReader = " + Reader.Text +
                " AND Reader_Book.IDBook = " + Book.Text;
            connection.Open();
            command = new SqlCommand(sqlq, connection);
            if (command.ExecuteScalar() == null)
                Result.Text = "Читач не брав цю книгу";

            else Result.Text = Convert.ToDateTime(command.ExecuteScalar()).ToShortDateString();
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
            У_кого_книги_яких_менше_двох window = new У_кого_книги_яких_менше_двох();
            Hide();
            window.Show();
            this.Close();
        }

       

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Загальна_інформація window = new Загальна_інформація();
            Hide();
            window.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Hide();
            window.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
