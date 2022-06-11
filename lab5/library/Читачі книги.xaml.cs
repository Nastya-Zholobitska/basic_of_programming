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
    /// Interaction logic for Читачі_книги.xaml
    /// </summary>
    public partial class Читачі_книги : Window
    {
        public Читачі_книги()
        {
            InitializeComponent();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Добавити_читача inform = new Добавити_читача();
            Hide();
            inform.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Один_рік window = new Один_рік();
            Hide();
            window.Show();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            connection.Open();
            try
            {
                string sqlq = "DECLARE @pmessage NVARCHAR(50) IF (SELECT COUNT(*) " +
                  $"FROM Reader_Book WHERE IDBook = {IDB.Text} AND IDReader = {IDR.Text} AND Return_Book IS NULL) = 0  " +
                    $" IF(SELECT COUNT(*) From Reader_Book WHERE IDBook = {IDB.Text} AND Return_Book IS NULL) <" +
                    "(SELECT Number FROM Halls_Books JOIN Readers ON Readers.IDHall = Halls_Books.IDHall" +
                    $" WHERE IDReader = {IDR.Text} AND IDBook = {IDB.Text}) BEGIN INSERT INTO " +
                    $"Reader_Book(IDReader, IDBook, Receiving) VALUES({IDR.Text}, {IDB.Text}, GETDATE()) " +
                    "SET @pmessage = 'Книгу видано успішно, дата видачі - ' + CONVERT(NVARCHAR, GETDATE(), 104) " +
                    "END ELSE SET @pmessage = 'Книгу не було видано, оскільки всі екземпляри розібрали читачі' " +
                    "ELSE SET @pmessage = 'Книгу не було видано, оскільки в читача вже є така на даний момент' " +
                    "SELECT @pmessage";

                command = new SqlCommand(sqlq, connection);
                string str = command.ExecuteScalar().ToString();
                MessageBox.Show(str);
                IDB.Text = "";
                IDR.Text = "";
            }
            catch
            {
                MessageBox.Show("Перевірте правильність введених даних");
            }
            connection.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            connection.Open();
            try
            {
                string sqlq = $"UPDATE Reader_Book SET Return_Book = GETDATE() WHERE IDReader = {IDR_Copy.Text} AND IDBook = {IDB_Copy.Text} AND Return_Book IS NULL";
                command = new SqlCommand(sqlq, connection);
                command.ExecuteNonQuery();
                IDB_Copy.Text = "";
                IDR_Copy.Text = "";
                MessageBox.Show("Книгу успішно здано");
            }
            catch
            {
                MessageBox.Show("Перевірте правильність введених даних");
            }
            connection.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Перереєстрація window = new Перереєстрація();
            Hide();
            window.Show();
            this.Close();
        }
    }
}
