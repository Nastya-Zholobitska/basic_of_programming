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
    class Window1
    {

        public Random rnd = new Random();


        public Window1()
        {
            initControls();
        }
        public Window wn = new Window();
        public Button[,] ArrBtn = new Button[5, 5];
        public Grid myGrid = new Grid();

        private void initControls()
        {
            wn.ResizeMode = ResizeMode.NoResize;
            wn.Height = 580;
            wn.Width = 500;
            wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            wn.Title = "Хрестики-нулики";
            wn.Background= new SolidColorBrush(Colors.LightGray);


            myGrid.Height = 590;
            myGrid.Width = 500;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
           
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    ArrBtn[i, j] = new Button();
                    ArrBtn[i, j].Click += Button_Click;
                    ArrBtn[i, j].Content = "";
                    ArrBtn[i, j].Foreground = new SolidColorBrush(Colors.DarkSlateGray);
                    ArrBtn[i, j].Background = new SolidColorBrush(Colors.White);
                    ArrBtn[i,j].BorderBrush = new SolidColorBrush(Colors.MediumVioletRed);
                    ArrBtn[i, j].FontSize = 50;
                }

            RowDefinition[] rows = new RowDefinition[7];
            ColumnDefinition[] cols = new ColumnDefinition[7];
            for (int i = 0; i < 7; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < 7; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                {
                    Grid.SetRow(ArrBtn[i-1, j-1], i);
                    Grid.SetColumn(ArrBtn[i-1, j-1], j);
                }
            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                    myGrid.Children.Add(ArrBtn[i-1, j-1]);
            Button btn = new Button();
            btn.Background = new SolidColorBrush(Colors.MediumVioletRed);
            btn.Width = 100;
            btn.Height = 30;
            btn.Content = "Вихід";
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.FontSize = 17;
            btn.Foreground = new SolidColorBrush(Colors.White);
            btn.Click += Return_Click;

            Button btn2 = new Button();
            btn2.Background = new SolidColorBrush(Colors.MediumVioletRed);
            btn2.Width = 100;
            btn2.Height = 30;
            btn2.Content = "Спочатку";
            btn2.VerticalAlignment = VerticalAlignment.Center;
            btn2.FontSize = 17;
            btn2.Foreground = new SolidColorBrush(Colors.White);
            btn2.Click += Button_Click_1;


            Grid.SetRow(btn, 6);
            Grid.SetColumnSpan(btn, 2);
            Grid.SetColumn(btn, 1);

            Grid.SetRow(btn2, 6);
            Grid.SetColumnSpan(btn2, 2);
            Grid.SetColumn(btn2, 4);

            myGrid.Children.Add(btn);
            myGrid.Children.Add(btn2);

            wn.Content = myGrid;
            wn.Show();

        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nwc = new MainWindow();
            wn.Hide();
            nwc.Show();
            wn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool b = true;
            string zn = "", zn2 = "";
            bool res = true;


            string str = ((Button)e.OriginalSource).Content.ToString();
            if (str == "")
            {
                zn = "X";
                zn2 = "O";
                ((Button)e.OriginalSource).Content = "X";

                b = check(ArrBtn, zn, zn2);
                if (b)
                {
                    foreach (Button bat in ArrBtn)
                    {
                        if (bat.Content == "")
                            res = false;
                    }
                    if (res) MessageBox.Show("Нічия!");
                }

                if (b && !res)
                {
                    intellekt(ArrBtn, zn);
                    b = check(ArrBtn, zn2, zn);
                }

            }

        }

        private void make_mass(Button[,] Buttons)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Buttons[i, j] = (Button)this.GetElementInGridPosition(i + 1, j + 1);
                }
            }
        }

        private bool check(Button[,] Buttons, string zn, string zn2)
        {
            bool b = true;
            int count = 0, count2 = 0;
            int id1, id2;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Buttons[i, j].Content == zn)
                        count++;
                    else if ((Buttons[j, i].Content == zn2 || Buttons[j, i].Content == "") && j != 0)
                        break;
                }

                if (count == 4)
                {
                    MessageBox.Show($"{zn} Winner!");
                    b = false;
                    return b;
                }
                count = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Buttons[j, i].Content == zn)
                        count++;
                    else if ((Buttons[j, i].Content == zn2 || Buttons[j, i].Content == "") && j != 0)
                        break;
                }
                if (count == 4)
                {
                    MessageBox.Show($"{zn} Winner!");
                    b = false;
                    return b;
                }
                count = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                if (Buttons[i, i].Content == zn)
                    count++;
                else if ((Buttons[i, i].Content == zn2 || Buttons[i, i].Content == "") && i != 0)
                {
                    count2++;
                    break;
                }
            }
            if (count == 4)
            {
                MessageBox.Show($"{zn} Winner!");
                b = false;
                return b;
            }
            count = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Buttons[i, 4 - i].Content == zn)
                    count++;
                else if ((Buttons[i, 4 - i].Content == zn2 || Buttons[i, 4 - i].Content == "") && i != 0)
                {
                    count2++;
                    break;
                }
            }

            if (count == 4)
            {
                MessageBox.Show($"{zn} Winner!");
                b = false;
                return b;
            }
            count = 0;

            for (int i = 1; i < 5; i++)
            {
                if (Buttons[i, i - 1].Content == zn)
                    count++;
            }

            if (count == 4)
            {
                MessageBox.Show($"{zn} Winner!");
                b = false;
                return b;
            }
            count = 0;

            for (int i = 0; i < 4; i++)
            {
                if (Buttons[i, i + 1].Content == zn)
                    count++;
            }

            if (count == 4)
            {
                MessageBox.Show($"{zn} Winner!");
                b = false;
                return b;
            }
            count = 0;

            for (int i = 0; i < 4; i++)
            {
                if (Buttons[i, 4 - i - 1].Content == zn)
                    count++;
            }

            if (count == 4)
            {
                MessageBox.Show($"{zn} Winner!");
                b = false;
                return b;
            }
            count = 0;

            for (int i = 1; i < 5; i++)
            {
                if (Buttons[i, 5 - i].Content == zn)
                    count++;
            }

            if (count == 4)
            {
                MessageBox.Show($"{zn} Winner!");
                b = false;
                return b;
            }


            count = 0;
            return b;
        }


        private void intellekt(Button[,] Buttons, string zn)
        {
            bool b = false;
            int count = 0, count2 = 0;
            int id1 = 0, id2 = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Buttons[i, j].Content == zn)
                        count++;
                    else
                    {
                        count2++;
                        if (count2 > 1 && Buttons[i, 0].Content == "X" || (Buttons[i, j].Content == "O" && j != 0)) break;
                        id1 = i; id2 = j;
                    }
                }
                if ((count == 3 || count == 4) && Buttons[id1, id2].Content != "O")
                {
                    Buttons[id1, id2].Content = "O";
                    return;
                }
                else
                {
                    count = 0; count2 = 0;
                }

            }

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Buttons[i, j].Content == zn)
                        count++;
                    else
                    {
                        count2++;
                        if (count2 > 1 && Buttons[0, j].Content == "X" || (Buttons[i, j].Content == "O" && i != 0)) break;
                        id1 = i; id2 = j;
                    }
                }
                if ((count == 3 || count == 4) && Buttons[id1, id2].Content != "O")
                {
                    Buttons[id1, id2].Content = "O";
                    return;
                }
                else
                {
                    count = 0; count2 = 0;
                }
            }

            for (int i = 0; i < 5; i++)
            {

                if (Buttons[i, i].Content == zn)
                    count++;
                else
                {
                    count2++;
                    if (count2 > 1 && Buttons[0, 0].Content == "X" || (Buttons[0, 0].Content == "O" && i != 0)) break;

                    id1 = i; id2 = i;
                }
            }
            if ((count == 3 || count == 4) && Buttons[id1, id2].Content != "O")
            {
                Buttons[id1, id2].Content = "O";
                return;
            }
            else
            {
                count = 0; count2 = 0;
            }

            for (int i = 0; i < 5; i++)
            {

                if (Buttons[i, 4 - i].Content == zn)
                    count++;
                else
                {
                    count2++;
                    if (count2 > 1 && Buttons[0, 4].Content == "X" || (Buttons[0, 4].Content == "O" && i != 0)) break;

                    id1 = i; id2 = 4 - i;
                }
            }
            if ((count == 3 || count == 4) && Buttons[id1, id2].Content != "O")
            {
                Buttons[id1, id2].Content = "O";
                return;
            }
            else
            {
                count = 0; count2 = 0;
            }

            while (!b)
            {
                id1 = rnd.Next(0, 5);
                id2 = rnd.Next(0, 5);
                if (Buttons[id1, id2].Content == "X" || Buttons[id1, id2].Content == "O")
                    b = false;
                else
                {
                    Buttons[id1, id2].Content = "O";
                    b = true;

                }
            }
        }




        private UIElement GetElementInGridPosition(int row, int column)
        {
            foreach (UIElement element in this.myGrid.Children)
            {
                if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                    return element;
            }
            return null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Button bat in ArrBtn)
            {
                bat.Content = "";
            }
        }
    }
}
