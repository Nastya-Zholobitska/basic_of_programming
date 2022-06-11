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
    /// Interaction logic for Перереєстрація.xaml
    /// </summary>
    public partial class Перереєстрація : Window
    {
        public Перереєстрація()
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
                string sqlq = "INSERT INTO Readers (Surname, Passport, Birthday, Adress, Telephone, " +
                    "IDEducation, Degree, IDHall, Registration) " +
                    "SELECT Surname, Passport, Birthday, Adress, Telephone, " +
                    "IDEducation, Degree, IDHall, GETDATE() " +
                    $"FROM Readers WHERE IDReader = {idR.Text} " +
                    $"UPDATE Reader_Book SET IDReader = SCOPE_IDENTITY() WHERE IDReader = {idR.Text} " +
                    $"DELETE FROM Readers WHERE IDReader = {idR.Text} SELECT SCOPE_IDENTITY()";
                command = new SqlCommand(sqlq, connection);
                string id = command.ExecuteScalar().ToString();
                idR.Text = "";
                if (id == "")
                    MessageBox.Show("Такого читача не існує");
                else
                    MessageBox.Show("Новий номер чит. квитка - " + id);
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
                string sqlq = $"INSERT INTO Books(Book_Name, Year_Publ) " +
                    $"SELECT Book_Name, Year_Publ FROM Books WHERE IDBook = {idB.Text} " +
                    $"UPDATE Reader_Book SET IDBook = SCOPE_IDENTITY() WHERE IDBook = {idB.Text} " +
                    $" UPDATE Halls_Books SET IDBook = SCOPE_IDENTITY() WHERE IDBook = {idB.Text} " +
                    $" UPDATE Author_Book SET IDBook = SCOPE_IDENTITY() WHERE IDBook = {idB.Text}" +
                    $" UPDATE PH_Book SET IDBook = SCOPE_IDENTITY() WHERE IDBook = {idB.Text} " +
                    $"     DELETE FROM Books WHERE IDBook = {idB.Text} SELECT SCOPE_IDENTITY()";
                command = new SqlCommand(sqlq, connection);
                string id = command.ExecuteScalar().ToString();
                idB.Text = "";
                if (id == "")
                    MessageBox.Show("ТакоЇ книги не існує");
                else
                    MessageBox.Show("Новий шифр книги - " + id);
            }
            catch
            {
                MessageBox.Show("Перевірте правильність введених даних");
            }
            connection.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Читачі_книги window = new Читачі_книги();
            Hide();
            window.Show();
            this.Close();
        }
    }
}

