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
    /// Interaction logic for Книги__що_закріплені_за_читачем.xaml
    /// </summary>
    public partial class Книги__що_закріплені_за_читачем : Window
    {
        public Книги__що_закріплені_за_читачем()
        {
            InitializeComponent();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        SqlDataAdapter adapter;
        public DataTable dT;

        private void Find(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string sqlq = "SELECT Surname AS Прізвище, Book_Name AS Назва_книги, Receiving AS Дата_отримання " +
                "FROM Books JOIN Reader_Book ON Books.IDBook = Reader_Book.IDBook " +
                "JOIN Readers ON Readers.IDReader = Reader_Book.IDReader " +
                "WHERE Return_Book IS NULL AND Reader_Book.IDReader = " + Number.Text;
            try
            {
                command = new SqlCommand(sqlq, connection);
                adapter = new SqlDataAdapter(command);
                DataTable tabl = new DataTable();
                adapter.Fill(tabl);
                ReaderBooks.ItemsSource = tabl.DefaultView;
            }
            catch
            {
                MessageBox.Show("Такого користувача не знайдено");
            }
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Інформація_про_книги inform = new Інформація_про_книги();
            Hide();
            inform.Show();
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
