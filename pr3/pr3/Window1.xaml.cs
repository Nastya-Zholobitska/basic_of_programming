using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace pr3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        SqlDataAdapter adapter;
        public DataTable dT;
        DataTable Table;
        public static int index = 0;

        public Window1()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlq = "SELECT Name, Surname, Login, Status, Restriction FROM MainTable";
            command = new SqlCommand(sqlq, connection);
            adapter = new SqlDataAdapter(command);
            Table = new DataTable("Користувачі системи");
            adapter.Fill(Table);
            Information.ItemsSource = Table.DefaultView;
            connection.Close();

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow administration = new MainWindow();
            Hide();
            administration.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            connection.Open();

            String strQ = "SELECT * FROM MainTable WHERE Login='ADMIN" + "';";
            adapter = new SqlDataAdapter(strQ, connection);
            dT = new DataTable();
            adapter.Fill(dT);
            connection.Close();

            if (Password.Text == dT.Rows[0][3].ToString())
            {
                GetData();
                Password.Text = "";
                Old_Password.IsEnabled = true;
                New_Password.IsEnabled = true;
                New_Password2.IsEnabled = true;
                Update.IsEnabled = true;
                User_Name.IsEnabled = true;
                Surname.IsEnabled = true;
                Login.IsEnabled = true;
                Obm.IsEnabled = true;
                Status.IsEnabled = true;
                Prev.IsEnabled = true;
                Next.IsEnabled = true;
                Login_Inp.IsEnabled = true;
                Add.IsEnabled = true;
                UserLogins.IsEnabled = true;
                Activity.IsEnabled = true;
                Obmezh.IsEnabled = true;
                Login_Inp.IsEnabled = true;
                Logouut.IsEnabled = true;
                UserLogins.SelectedValuePath = "Login";
                UserLogins.DisplayMemberPath = "Login";
                UserLogins.SelectedValuePath = "Login";
                UserLogins.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source =Table});
            }
            else
            {
                MessageBox.Show("Пароль невірний");
                Password.Text = "";
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            if (Old_Password.Text == dT.Rows[0][3].ToString())
            {
                if (New_Password.Text != Old_Password.Text && New_Password.Text == New_Password2.Text)
                {
                    string strQ = "UPDATE MainTable SET Password ='" + New_Password.Text + "' WHERE Login = 'ADMIN'; ";
                    command = new SqlCommand(strQ, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пароль успішно змінено");

                }

            }
            else MessageBox.Show("перевірте правильність введених даних");
            Old_Password.Text = "";
            New_Password.Text = "";
            New_Password2.Text = "";
            connection.Close();
        }

        private void Logouut_Click(object sender, RoutedEventArgs e)
        {
            dT.Clear();
            Information.ItemsSource = dT.DefaultView;
            Old_Password.IsEnabled = false;
            New_Password.IsEnabled = false;
            New_Password2.IsEnabled = false;
            Update.IsEnabled = false;
            User_Name.IsEnabled = false;
            Surname.IsEnabled = false;
            Login.IsEnabled = false;
            Obm.IsEnabled = false;
            Status.IsEnabled = false;
            Prev.IsEnabled = false;
            Next.IsEnabled = false;
            Login_Inp.IsEnabled = false;
            Add.IsEnabled = false;
            UserLogins.IsEnabled = false;
            Activity.IsEnabled = false;
            Obmezh.IsEnabled = false;
            Login_Inp.IsEnabled = false;
            Logouut.IsEnabled = false;
        }


        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                User_Name.Text = Table.Rows[index][0].ToString();
                Surname.Text = Table.Rows[index][1].ToString();
                Login.Text = Table.Rows[index][2].ToString();
                Status.Text = Table.Rows[index][3].ToString();
                Obm.Text = Table.Rows[index][4].ToString();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (index < Table.Rows.Count-1)
            {
                index++;
                User_Name.Text = Table.Rows[index][0].ToString();
                Surname.Text = Table.Rows[index][1].ToString();
                Login.Text = Table.Rows[index][2].ToString();
                Status.Text = Table.Rows[index][3].ToString();
                Obm.Text = Table.Rows[index][4].ToString();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            String strQ;
            String UserLogin = Login_Inp.Text;
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    strQ = "INSERT INTO MainTable (Name, Surname, Login, Password, Status, Restriction) values('', '', '" + UserLogin + "', '', 1, 0); ";
                
                  command = new SqlCommand(strQ, connection);
                    command.ExecuteNonQuery();
                }
                GetData();
                UserLogins.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = Table });
                MessageBox.Show("користувача успішно зареєстровано");
            }
            catch
            {
                MessageBox.Show("Користувача не додано! Можливо такий в базі вже є!");
            }
            connection.Close();
            Login_Inp.Text = "";
        }

        private void Activity_Click(object sender, RoutedEventArgs e)
        {

            connection.Open();
            String strQ;
            bool UserStatus = (bool)Change_Active.IsChecked;
            if (connection.State == System.Data.ConnectionState.Open)
            {
                strQ = "UPDATE MainTable SET Status ='" + UserStatus + "' WHERE Login='" +
                UserLogins.Text + "';";
                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
            GetData();
            MessageBox.Show("Статус користувача успішно змінено");
        }

        private void UserLogins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            connection.Open();
            String strQ;
            bool status, obmezh;
            
                DataRowView row = (DataRowView)UserLogins.SelectedItem;
            string text = row[2].ToString();
            strQ = "SELECT * FROM MainTable WHERE Login='" + text + "';";
            DataTable d = new DataTable();
            adapter = new SqlDataAdapter(strQ, connection);
            adapter.Fill(d);

           
            bool Status = Convert.ToBoolean(d.Rows[0][4]);
            Change_Active.IsChecked = Status;
            bool Obm = Convert.ToBoolean(d.Rows[0][5]);
            Obm_Par.IsChecked = Obm;

            connection.Close();
        }

        private void Obmezh_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            String strQ;
            bool Restriction = (bool)Obm_Par.IsChecked;
            if (connection.State == System.Data.ConnectionState.Open)
            {
                strQ = "UPDATE MainTable SET Restriction ='" + Restriction + "' WHERE Login='" +
                UserLogins.Text + "';";
                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
            GetData();
            MessageBox.Show("Обмеження на пароль успішно змінено");
        }
    }
}
