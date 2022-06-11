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
    /// Interaction logic for Один_рік.xaml
    /// </summary>
    public partial class Один_рік : Window
    {
        public Один_рік()
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
            string sqlq = "SELECT IDReader as Чит_квиток, Surname AS Прізвище, Registration AS Реєстрація " +
                "FROM Readers " +
                "WHERE Registration<CONVERT(DATE, DATEADD(YEAR, -1, GETDATE()))";
            command = new SqlCommand(sqlq, connection);
            adapter = new SqlDataAdapter(command);
            Table = new DataTable();
            adapter.Fill(Table);
            OneYear.ItemsSource = Table.DefaultView;

            connection.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Добавити_читача inform = new Добавити_читача();
            Hide();
            inform.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Читачі_книги window = new Читачі_книги();
            Hide();
            window.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Операції_книги window = new Операції_книги();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string sqlq = "DELETE FROM Readers WHERE IDReader = (" +
                "SELECT IDReader WHERE Registration < " +
                "CONVERT(DATE, DATEADD(YEAR, -1, GETDATE())))";
            command = new SqlCommand(sqlq, connection);
            command.ExecuteNonQuery();
            OneYear.ItemsSource = Table.DefaultView;
            connection.Close();
            Refresh();
            MessageBox.Show("Видалення виконано успішно");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Перереєстрація window = new Перереєстрація();
            Hide();
            window.Show();
            this.Close();
        }
    }
}
