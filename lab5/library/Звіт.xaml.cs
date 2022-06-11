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
    /// Interaction logic for Звіт.xaml
    /// </summary>
    public partial class Звіт : Window
    {
        public Звіт()
        {
            InitializeComponent();
            Refresh();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        SqlDataAdapter adapter;
        public DataTable dT;
        DataTable Table;

        private void Refresh()
        {
            connection.Open();
            string sqlq = "SELECT COUNT (*) FROM Readers;";
            command = new SqlCommand(sqlq, connection);
            string count = command.ExecuteScalar().ToString();
            countofresders.Text = count;
            sqlq = "SELECT SUM(Number) FROM Halls_Books;";
            command = new SqlCommand(sqlq, connection);
            count = command.ExecuteScalar().ToString();
            countofbooks.Text= count;
            sqlq = "SELECT A.IDHall, count1 as Книг, Numb as Читачів " +
                "FROM " +
                "(SELECT IDHall, sum(Number) AS count1 " +
                "FROM Halls_Books " +
                "GROUP BY IDHall) AS A " +
                "JOIN " +
                "(SELECT IDHall, Count(IDReader) AS Numb " +
                "FROM Readers GROUP BY IDHall) AS B " +
                "ON A.IDHall = B.IDHall";
            command = new SqlCommand(sqlq, connection);
            adapter = new SqlDataAdapter(command);
            Table = new DataTable("");
            adapter.Fill(Table);
           Stat.ItemsSource = Table.DefaultView;
            connection.Close();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string Month = month.Text;
            string Year = year.Text;
            string sqlq = $"SELECT COUNT(*) FROM Readers" +
                $"   Where DATENAME(month, Registration) = '{Month}' AND" +
                $"   DATENAME(year, Registration) = '{Year}'";
            command = new SqlCommand(sqlq, connection);
            string count = command.ExecuteScalar().ToString();
            regread.Text = count;

            sqlq = $"SELECT Books.Book_Name AS 'Назва книги', COUNT(Reader_Book.IDBook) AS 'Скільки разів брали' " +
                $"FROM Books JOIN Reader_Book " +
                $"ON BOOKS.IDBook = Reader_Book.IDBook " +
                $"WHERE DATENAME(month, Receiving)= '{Month}' " +
                $"AND DATENAME(year, Receiving)= '{Year}' " +
                $"Group BY Book_Name";
            command = new SqlCommand(sqlq, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table1 = new DataTable("");
            adapter.Fill(Table1);
            books.ItemsSource = Table1.DefaultView;

            sqlq = $"SELECT Surname  AS 'Прізвище', IDReader FROM Readers " +
                $"WHERE(SELECT COUNT(*) FROM Reader_Book " +
                $" WHERE DATENAME(month, Receiving) = '{Month}' " +
                $"AND DATENAME(year, Receiving) = '{Year}' AND " +
                $"Readers.IDReader = Reader_Book.IDReader) = 0";
            command = new SqlCommand(sqlq, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table2 = new DataTable("");
            adapter.Fill(Table2);
            read.ItemsSource= Table2.DefaultView;
            connection.Close();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            К_сть_книг_автора window = new К_сть_книг_автора();
            Hide();
            window.Show();
            this.Close();
        }
    }
}
