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
        class Window4
        {

            public Window4()
            {
                initControls();
            }

            public Window win = new Window();



            private void initControls()
            {

            win.Height = 470;
            win.Width = 703;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.ResizeMode = ResizeMode.NoResize;
            win.Title = "Автор";
            win.Background = new SolidColorBrush(Colors.LightGray);

            Grid myGrid = new Grid();
            myGrid.Height = 470;
            myGrid.Width = 703;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;

          

            Button btn = new Button();
            btn.Margin = new Thickness(150, 398, 150, 0);
            btn.Height = 30;
            btn.Click += Return_Click;
            btn.VerticalAlignment = VerticalAlignment.Top;

            btn.Content = "Вихід";
            btn.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
            btn.FontSize = 16;
            myGrid.Children.Add(btn);


       
            Border bord = new Border();
            bord.Background = new SolidColorBrush(Colors.White);
            bord.Margin = new Thickness(114, 0, 114, 0);
            bord.Height = 273;
            bord.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(bord);

            Label text = new Label();
            text.Content = "Розробник";
            text.Margin = new Thickness(114, 69, 114, 347);
            text.Background = new SolidColorBrush(Colors.MediumVioletRed);
            text.Foreground = new SolidColorBrush(Colors.White);
            text.HorizontalContentAlignment = HorizontalAlignment.Center;
            text.FontSize = 25;
            myGrid.Children.Add(text);

            Label text1 = new Label();
            text1.Content = "Жолобіцька Анастасія Ярославівна";
            text1.Margin = new Thickness(130, 166, 133, 150);
            text1.HorizontalContentAlignment = HorizontalAlignment.Center;
            text1.FontSize = 25;
            myGrid.Children.Add(text1);
            Label text2 = new Label();
            text2.Content = "група кп-11";
            text2.Margin = new Thickness(248, 217, 248, 150);
            text2.HorizontalContentAlignment = HorizontalAlignment.Center;
            text2.FontSize = 25;
            myGrid.Children.Add(text2);

            Label text3 = new Label();
            text3.Content = "2022";
            text3.Margin = new Thickness(248, 282, 268, 150);
            text3.HorizontalContentAlignment = HorizontalAlignment.Center;
            text3.FontSize = 16;
            myGrid.Children.Add(text3);


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
        }
    }

