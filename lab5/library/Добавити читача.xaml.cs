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
    /// Interaction logic for Добавити_читача.xaml
    /// </summary>
    public partial class Добавити_читача : Window
    {
        public Добавити_читача()
        {
            InitializeComponent();

            Registr.Text = DateTime.Today.ToShortDateString();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        public DataTable dT;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            try
            {

                int educ = 0;
                DateTime data1 = Convert.ToDateTime(Birthday.Text);
                DateTime data2 = Convert.ToDateTime(Registr.Text);
                if (Ed.Text == "початкова")
                    educ = 1;
                else if (Ed.Text == "середня")
                    educ = 2;
                else if (Ed.Text == "вища")
                    educ = 3;

                string sqlq = $"DECLARE @message NVARCHAR(50) = 'у читальному залі немає вільних місць' " +
                    $"IF (SELECT COUNT(*) FROM Readers WHERE IDHall=3)<(SELECT Capacity FROM Halls WHERE IDHall=3) " +
                    $" BEGIN INSERT INTO Readers (Surname, Passport, Birthday, " +
                     $"Adress, Telephone, IDEducation, Degree, IDHall, Registration) " +
                     $"VALUES('{Surname.Text}', '{Passport.Text}', '{data1:s}',  " +
                     $"'{Adres.Text}', '{Teleph.Text}', {educ}, '{Dg.Text}', {Hall.Text}, '{data2:s}') SELECT SCOPE_IDENTITY() END " +
                     $"ELSE SELECT @message";
                command = new SqlCommand(sqlq, connection);
                string id = command.ExecuteScalar().ToString();
                connection.Close();
                if (id== "у читальному залі немає вільних місць")
                    MessageBox.Show(id);
               else MessageBox.Show($"Читача добавлено, номер його читацького квитка - {id}");
                Surname.Text = "";
                Passport.Text = "";
                Birthday.Text = "";
                Adres.Text = "";
                Teleph.Text = "";
                Hall.Text = "";
                Registr.Text = "";
            }
            catch
            {
                MessageBox.Show("Перевірте введені дані");
            }
            connection.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string sqlq = "DELETE FROM Readers " +
                $"WHERE IDReader = {idid.Text}";
            command = new SqlCommand(sqlq, connection);
            command.ExecuteNonQuery();
            idid.Text = "";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Перереєстрація window = new Перереєстрація();
            Hide();
            window.Show();
            this.Close();
        }
    }
}
