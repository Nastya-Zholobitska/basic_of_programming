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
    /// Interaction logic for Читачі__що_взяли_книгу_місяць_тому.xaml
    /// </summary>
    public partial class Читачі__що_взяли_книгу_місяць_тому : Window
    {
        public Читачі__що_взяли_книгу_місяць_тому()
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
            string sqlq = "SELECT Surname AS Прізвище, Book_Name AS Назва_книги " +
                "FROM Books JOIN Reader_Book ON Books.IDBook = Reader_Book.IDBook " +
                "JOIN Readers ON Readers.IDReader = Reader_Book.IDReader " +
                "WHERE Receiving<CONVERT(DATE, DATEADD(month, -1, GETDATE())) AND Return_Book IS NULL " +
                "ORDER BY Receiving;";
            command = new SqlCommand(sqlq, connection);
            adapter = new SqlDataAdapter(command);
            Table = new DataTable("Читачі, що взяли книгу більше 2 місяців тому");
            adapter.Fill(Table);
            TwoMonth.ItemsSource = Table.DefaultView;
        
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
