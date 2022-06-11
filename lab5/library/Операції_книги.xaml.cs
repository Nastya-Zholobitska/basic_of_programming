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
    /// Interaction logic for Операції_книги.xaml
    /// </summary>
    public partial class Операції_книги : Window
    {
        public Операції_книги()
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
            string sqlq = $"UPDATE Halls_Books SET Number = Number+ {Convert.ToInt32(count.Text)} " +
                $"WHERE IDBook = {IDbook.Text} AND IDHall = {hall.Text}";
            command = new SqlCommand(sqlq, connection);
            command.ExecuteNonQuery();
            count.Text = "";
            IDbook.Text = "";
            hall.Text = "";
            MessageBox.Show("Примірник(и) успішно додано");
            connection.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string sqlq = $"UPDATE Halls_Books SET Number = Number-1 " +
                $"WHERE IDBook = {IDbook1.Text} AND IDHall = {hall1.Text}";
            command = new SqlCommand(sqlq, connection);
            command.ExecuteNonQuery();
            IDbook1.Text = "";
            hall1.Text = "";
            MessageBox.Show("Примірник успішно видалено");
            connection.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string sqlq = $"DELETE FROM Books WHERE IDBook={IDbook2.Text}";
            command = new SqlCommand(sqlq, connection);
            command.ExecuteNonQuery();
            IDbook2.Text = "";
            MessageBox.Show("Книги успішно видалено");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string sqlq = "";
            sqlq = $"INSERT INTO Books (Book_Name, Year_Publ) VALUES ('{bname.Text}', '{year.Text}') " +
                $"SELECT SCOPE_IDENTITY()";
            command = new SqlCommand(sqlq, connection);
            string id = command.ExecuteScalar().ToString();

            string[] authors = author.Text.Split(',');
            for (int i = 0; i < authors.Length; i++)
            {
                authors[i] = authors[i].Trim();
                sqlq = $"IF  (SELECT COUNT(*) FROM Author WHERE A_Name = '{author.Text}')=0 " +
                    $"BEGIN INSERT INTO Author(A_Name) VALUES('{author.Text}')" +
                    $" INSERT INTO Author_Book(IDAuthor, IDBook) VALUES(SCOPE_IDENTITY(), '{id}') " +
                    $"END ELSE INSERT INTO Author_Book(IDAuthor, IDBook) VALUES " +
                   $"((SELECT IDAuthor FROM Author WHERE A_Name = '{author.Text}'), '{id}')";
                command = new SqlCommand(sqlq, connection);
                command.ExecuteNonQuery();
            }

            sqlq = $"IF (SELECT COUNT(*) FROM Publishing_House WHERE PH_Name = '{publ.Text}')=0 " +
                $"BEGIN INSERT INTO Publishing_House(PH_Name) VALUES('{publ.Text}') " +
                $"INSERT INTO PH_Book(IDPh, IDBook) VALUES(SCOPE_IDENTITY(), '{id}') END " +
                $"ELSE INSERT INTO PH_Book(IDPh, IDBook) VALUES" +
                $"((SELECT IDPh FROM Publishing_House WHERE PH_Name = '{publ.Text}'), '{id}')";
            command = new SqlCommand(sqlq, connection);
            command.ExecuteNonQuery();

            sqlq = $"INSERT INTO Halls_Books (IDHall, IDBook, Number) " +
                $" VALUES (1, {id}, {hall1c.Text}), (2, {id}, {hall2c.Text}), (3, {id}, {hall3c.Text})";
            command = new SqlCommand(sqlq, connection);
            command.ExecuteNonQuery();
            bname.Text = "";
            author.Text = "";
            year.Text = "";
            publ.Text = "";
            hall1c.Text = "";
            hall2c.Text = "";
            hall3c.Text = "";
            MessageBox.Show("Книги успішно додано. Їх шифр - "+id);

            connection.Close();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Перереєстрація window = new Перереєстрація();
            Hide();
            window.Show();
            this.Close();
        }
    }
}

