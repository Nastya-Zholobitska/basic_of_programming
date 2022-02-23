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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Random;


namespace lab2
{
    class Window2
    {

        public Window2()
        {
            initControls();
        }
        public Random rnd = new Random();

        public Window win = new Window();
        public Button[,] ArrBtn = new Button[5, 4];
        public Grid myGrid = new Grid();
        public TextBlock text = new TextBlock();
        public string elem1 = "", elem2 = "";
        public int count = 0, ind, zn;
        public double res;



        private void initControls()
        {
           
            win.Height = 350;
            win.Width = 250;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            win.ResizeMode = ResizeMode.NoResize;
            win.Title = "Калькулятор";
            win.Background = new SolidColorBrush(Colors.LightGray);


            myGrid.Height = 300;
            myGrid.Width = 235;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;


            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                {
                    ArrBtn[i, j] = new Button();
                    ArrBtn[i, j].Content = "";
                    ArrBtn[i, j].Foreground = new SolidColorBrush(Colors.DarkSlateGray);
                    ArrBtn[i, j].Background = new SolidColorBrush(Colors.White);
                    ArrBtn[i, j].BorderBrush = new SolidColorBrush(Colors.White);
                    ArrBtn[i, j].FontSize = 20;
                    ArrBtn[i, j].Click += Button_Click;
                }

            RowDefinition[] rows = new RowDefinition[6];
            ColumnDefinition[] cols = new ColumnDefinition[4];
            for (int i = 0; i < 6; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            for (int i = 1; i < 6; i++)
                for (int j = 0; j < 4; j++)
                {
                    Grid.SetRow(ArrBtn[i-1, j], i);
                    Grid.SetColumn(ArrBtn[i - 1, j], j);
                }

            ArrBtn[0, 0].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[4, 0].Click += Return_Click;
            ArrBtn[4, 0].Content = "Вихід";
            ArrBtn[4, 0].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[4, 0].Foreground = new SolidColorBrush(Colors.White);
            ArrBtn[4, 1].Content = "0";
            ArrBtn[4, 2].Content = ",";
            ArrBtn[4, 2].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[4, 2].Foreground = new SolidColorBrush(Colors.White);
            ArrBtn[4, 3].Content = "+";
            ArrBtn[4, 3].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[4, 3].Foreground = new SolidColorBrush(Colors.White);

            ArrBtn[3, 0].Content = "1";
            ArrBtn[3, 1].Content = "2";
            ArrBtn[3, 2].Content = "3";
            ArrBtn[3, 3].Content = "-";
            ArrBtn[3, 3].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[3, 3].Foreground = new SolidColorBrush(Colors.White);

            ArrBtn[2, 0].Content = "4";
            ArrBtn[2, 1].Content = "5";
            ArrBtn[2, 2].Content = "6";
            ArrBtn[2, 3].Content = "*";
            ArrBtn[2, 3].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[2, 3].Foreground = new SolidColorBrush(Colors.White);

            ArrBtn[1, 0].Content = "7";
            ArrBtn[1, 1].Content = "8";
            ArrBtn[1, 2].Content = "9";
            ArrBtn[1, 3].Content = "/";
            ArrBtn[1, 3].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[1, 3].Foreground = new SolidColorBrush(Colors.White);

            ArrBtn[0, 1].Content = "=";
            ArrBtn[0, 1].Background= new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[0, 1].Foreground = new SolidColorBrush(Colors.White);
            ArrBtn[0, 2].Content = "С";
            ArrBtn[0, 2].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[0, 2].Foreground = new SolidColorBrush(Colors.White);
            ArrBtn[0, 3].Content = "del";
            ArrBtn[0, 3].Background = new SolidColorBrush(Colors.MediumVioletRed);
            ArrBtn[0, 3].Foreground = new SolidColorBrush(Colors.White);



            for (int i = 1; i < 6; i++)
                for (int j = 0; j < 4; j++)
                    myGrid.Children.Add(ArrBtn[i - 1, j]);

          
            text.Background= new SolidColorBrush(Colors.White);
            text.FontSize = 20;
            Grid.SetColumn(text, 0);
            Grid.SetRow(text, 0);
            Grid.SetColumnSpan(text, 6);
            myGrid.Children.Add(text);

            win.Content = myGrid;
            win.Show();

        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nwc = new MainWindow();
            win.Hide();
            nwc.Show();
            win.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = Convert.ToString(((Button)e.OriginalSource).Content);

            if (str == "С")
                text.Text = "";
            else if (str == "del")
            {
                text.Text = text.Text.Remove(text.Text.Length - 1, 1);
            }

            else if (str == "=")
            {
                text.Text += str;
                for (int j = ind + 1; j < text.Text.Length; j++)
                {
                    if ((char.IsNumber(text.Text[j]) || text.Text[j] == ',') && j != text.Text.Length - 1)
                    {
                        elem2 += text.Text[j];
                    }
                    else
                    {
                        if (zn == '+')
                            elem1 = Convert.ToString(Convert.ToDouble(elem1) + Convert.ToDouble(elem2));
                        else if (zn == '-')
                            elem1 = Convert.ToString(Convert.ToDouble(elem1) - Convert.ToDouble(elem2));
                        else if (zn == '*')
                            elem1 = Convert.ToString(Convert.ToDouble(elem1) * Convert.ToDouble(elem2));
                        else
                            elem1 = Convert.ToString(Convert.ToDouble(elem1) / Convert.ToDouble(elem2));
                        zn = text.Text[j];
                        elem2 = "";
                    }

                }
                res = Convert.ToDouble(elem1);
                text.Text = Convert.ToString(res);
                count = 0;
                elem1 = "";

            }

            else
            {
                if ((str == "+" || str == "-" || str == "*" || str == "/") && count != 1)
                {
                    elem1 = text.Text;
                    zn = str[0];
                    ind = text.Text.Length;
                    count++;

                }
                text.Text += str;
            }
        }
    }
}
