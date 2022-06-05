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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        SqlDataAdapter adapter;
        static int counter = 1;
        public DataTable dT;
        DataTable Table;
        public static int index = 0;
        string log;

        public Window2()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow administration = new MainWindow();
            Hide();
            administration.Show();
            this.Close();
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            log = Login.Text;
            String strQ = "SELECT * FROM MainTable WHERE Login='" + Login.Text + "';";
            adapter = new SqlDataAdapter(strQ, connection);
            dT = new DataTable();
            adapter.Fill(dT);
            connection.Close();
            if (dT.Rows.Count != 0)
            {

                bool Status = Convert.ToBoolean(dT.Rows[0][4]);
                if (!Status)
                {
                    Password.Text = "";
                    Login.Text = "";
                    MessageBox.Show("Користувач заблокований  Адміністратором системи!");
                }

                else if (Password.Text == dT.Rows[0][3].ToString())
                {
                    Login.Text = "";
                    Password.Text = "";
                    Name1.IsEnabled = true;
                    Name1.Text = dT.Rows[0][0].ToString();
                    Surname1.IsEnabled = true;
                    Surname1.Text = dT.Rows[0][1].ToString();
                    New_Pass.IsEnabled = true;
                    New_Pass2.IsEnabled = true;
                    Update.IsEnabled = true;
                    Close.IsEnabled = true;
                    Logouut.IsEnabled = true;
                    passReg.IsEnabled = false;
                    pass2Reg.IsEnabled = false;
                    loginReg.IsEnabled = false;
                    NameReg.IsEnabled = false;
                    SurnameReg.IsEnabled = false;
                    Registr.IsEnabled = false;
                    MessageBox.Show("Авторизація пройшла успішно");
                    
                    counter = 0;
                }
                else
                {
                    if (counter != 3)
                    {
                        counter++;
                        Password.Text = "";
                        MessageBox.Show("Пароль невірний. Спроба №" + counter);
                    }
                    else
                    {
                        Password.Text = "";
                        MessageBox.Show("Спроби вичерпано");
                        Application.Current.Shutdown();
                    }

                }
            }
            else
            {
                MessageBox.Show("Такого користувача не існує");
                Login.Text = "";

            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            if (New_Pass.Text == New_Pass2.Text && New_Pass.Text!="")
            {
                bool Status = Convert.ToBoolean(dT.Rows[0][5]);
                if (Status)
                {
                    bool flag = RestrictionFunc(New_Pass.Text);
                    if (flag!=true)
                    {
                        MessageBox.Show("У паролі немає літер верхнього" +
                            " та нижнього регістрів, а також знаків арифметичних операцій! Спробуйте знову!");
                        connection.Close();
                        return;
                    }
                }
                string strQ = "UPDATE MainTable SET Name='" + Name1.Text + "', ";
                strQ += "Surname='" + Surname1.Text + "', ";
                strQ += "Password='" + New_Pass.Text + "' ";
                strQ += "WHERE Login='" + log + "';";
                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
                Name1.Text = "";
                Surname1.Text = "";
                New_Pass.Text = "";
                New_Pass2.Text = "";
                MessageBox.Show("Дані успішно оновлено!");
            }
            connection.Close();
        }

        private void Logouut_Click(object sender, RoutedEventArgs e)
        {
            Name1.IsEnabled = false;
            Name1.Text = "";
            Surname1.IsEnabled = false;
            Surname1.Text = "";
            New_Pass.IsEnabled = false;
            New_Pass2.IsEnabled = false;
            Update.IsEnabled = false;
            passReg.IsEnabled=true;
            Logouut.IsEnabled = false;
            pass2Reg.IsEnabled = true;
            loginReg.IsEnabled = true;
            NameReg.IsEnabled = true;
            SurnameReg.IsEnabled = true;
            Registr.IsEnabled = true;
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
           
            if ((passReg.Text == pass2Reg.Text) && (loginReg.Text != "")
                && (passReg.Text != "") && Registration(loginReg.Text))
            {
                connection.Open();
                string strQ = "INSERT INTO MainTable ";
                strQ += "VALUES ('" + NameReg.Text + "', '" + SurnameReg.Text + "', '"
                    + loginReg.Text + "', '" + passReg.Text + "', 'True', 'False'); ";

                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("користувач успішно зареєстрований");
            }
            connection.Close();
            passReg.Text = "";
            pass2Reg.Text = "";
            loginReg.Text = "";
            NameReg.Text = "";
            SurnameReg.Text = "";
        }

        private bool Registration(string loginn)
        {
            connection.Open();
            String strQ = "SELECT * FROM MainTable WHERE Login='" + loginn + "';";
            adapter = new SqlDataAdapter(strQ, connection);
            dT = new DataTable();
            adapter.Fill(dT);
            connection.Close();

            if (dT.Rows.Count > 0)
                return false;
            else return true;
            
        }

       private Boolean RestrictionFunc(String Pass)
        {
            Byte Count1, Count2, Count3;
            Byte LenPass = (Byte)Pass.Length;
            Count1 = Count2 = Count3 = 0;
            for (Byte i = 0; i < LenPass; i++)
            {
                if ((Convert.ToInt32(Pass[i]) >= 65) &&

                (Convert.ToInt32(Pass[i]) <= 65 + 25))

                    Count1++;
                if ((Convert.ToInt32(Pass[i]) >= 97) &&

                (Convert.ToInt32(Pass[i]) <= 97 + 25))

                    Count2++;
                if ((Pass[i] == '+') || (Pass[i] == '-') || (Pass[i] == '*') ||

                (Pass[i] == '/'))

                    Count3++;
            }
            return (Count1 * Count2 * Count3 != 0);
        }
    }
}
