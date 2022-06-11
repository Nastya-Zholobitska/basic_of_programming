using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace library
{
    /// <summary>
    /// Interaction logic for К_сть_книг_автора.xaml
    /// </summary>
    public partial class К_сть_книг_автора : Window
    {


        public К_сть_книг_автора()
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
            string sqlq = "SELECT Author_Book.IDAuthor, A_Name as Імена, Count(*) as Кількість FROM Author_Book  " +
                "JOIN Author ON Author.IDAuthor = Author_Book.IDAuthor " +
                "GROUP BY Author_Book.IDAuthor, A_Name";
            command = new SqlCommand(sqlq, connection);
            adapter = new SqlDataAdapter(command);
            Table = new DataTable();
            adapter.Fill(Table);
            INFOR.ItemsSource = Table.DefaultView;
            connection.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string sqlq =  "SELECT COUNT(*) FROM Author_Book " +
                $"WHERE IDAuthor = (SELECT IDAuthor FROM Author WHERE A_Name = '{AName.Text}')";
            command = new SqlCommand(sqlq, connection);
            string count = command.ExecuteScalar().ToString();
            Result.Text = count;
            connection.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Звіт window = new Звіт();
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
