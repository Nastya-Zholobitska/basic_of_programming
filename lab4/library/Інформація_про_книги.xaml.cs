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
    /// Interaction logic for Інформація_про_книги.xaml
    /// </summary>
    public partial class Інформація_про_книги : Window
    {
        public Інформація_про_книги()
        {
            InitializeComponent();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        SqlDataAdapter adapter;
        public DataTable dT;
        DataTable Table;

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string shifr = BookShr.Text;
            string sqlq = "Select Book_Name FROM Books WHERE IDBook = " + shifr + ";";
            command = new SqlCommand(sqlq, connection);
            if (command.ExecuteScalar() == null)
                Result2.Text = "Книгу з таким шифром не знайдено";

            else Result2.Text = command.ExecuteScalar().ToString();
            connection.Close();
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string name = BookName.Text;
            string sqlq = "SELECT IDBook FROM Books WHERE Book_Name = '" + name + "';";
            command = new SqlCommand(sqlq, connection);
            if (command.ExecuteScalar() == null)
                Result1.Text = "Книгу з такою назвою не знайдено";

            else Result1.Text = command.ExecuteScalar().ToString();
            connection.Close();
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Коли_книгу_було_закріплено window = new Коли_книгу_було_закріплено();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BookName.Text = "";
            Result1.Text = "";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            BookShr.Text = "";
            Result2.Text = "";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Hide();
            window.Show();
            this.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
