using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Random;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Button[,] Buttons = new Button[5, 5];

        public int counter = 0;
        public Random rnd = new Random();
        public Window1()
        {
            InitializeComponent();
            make_mass(Buttons);
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nwc = new MainWindow();
            Hide();
            nwc.Show();
            this.Close();
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

                b = check(Buttons, zn, zn2);
                if (b)
                {
                    foreach (Button bat in Buttons)
                    {
                        if (bat.Content == "")
                            res = false;
                    }
                    if (res) MessageBox.Show("Нічия!");
                }

                if (b && !res)
                {
                    intellekt(Buttons, zn);
                    b = check(Buttons, zn2, zn);
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
                }

                if (count == 4)
                {
                    MessageBox.Show($"{zn} Winner!");
                    b = false;
                    return b;
                }
                count = 0; count2 = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Buttons[j, i].Content == zn)
                        count++;
                }
                if (count == 4)
                {
                    MessageBox.Show($"{zn} Winner!");
                    b = false;
                    return b;
                }
                count = 0; count2 = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                if (Buttons[i, i].Content == zn)
                    count++;
            }
            if (count == 4)
            {
                MessageBox.Show($"{zn} Winner!");
                b = false;
                return b;
            }
            count = 0; count2 = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Buttons[i, 4 - i].Content == zn)
                    count++;
            }

            if (count == 4)
            {
                MessageBox.Show($"{zn} Winner!");
                b = false;
                return b;
            }

            count = 0; count2 = 0;
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
        }



        private UIElement GetElementInGridPosition(int row, int column)
            {
                foreach (UIElement element in this.Gridn.Children)
                {
                    if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                        return element;
                }
                return null;
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                foreach (Button bat in Buttons)
                {
                    bat.Content = "";
                }
            }
        }
    }

    


