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
    /// Interaction logic for У_кого_книги_яких_менше_двох.xaml
    /// </summary>
    public partial class У_кого_книги_яких_менше_двох : Window
    {
        public У_кого_книги_яких_менше_двох()
        {
            InitializeComponent();
            Refresh();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable Table;

        private void Refresh()
        {
            connection.Open();
            string sqlq = "SELECT Surname, Book_Name FROM Reader_Book as id " +
                "JOIN Readers ON id.IDReader = Readers.IDReader JOIN Books " +
                "ON Books.IDBook = id.IDBook " +
                "WHERE Return_Book IS NULL AND EXISTS " +
                "(SELECT IDBook, SUM(Number) summ FROM Halls_Books " +
                "GROUP BY IDBook HAVING SUM(Number) < 3 AND IDBook = id.IDBook)";
            command = new SqlCommand(sqlq, connection);
            adapter = new SqlDataAdapter(command);
            Table = new DataTable();
            adapter.Fill(Table);
            tabl.ItemsSource = Table.DefaultView;

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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
}
