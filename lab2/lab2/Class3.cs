using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab2
{
    class Window3
    {

        public Window3()
        {
            initControls();
        }
        public Random rnd = new Random();

        public Window win = new Window();
        public Grid myGrid = new Grid();
        public TextBox Name = new TextBox();
        public TextBox Course = new TextBox();
        public TextBox Number = new TextBox();
        public TextBox text1 = new TextBox();
        public string elem1 = "", elem2 = "";
      

        static string path2 = @"C:\Users\user\OneDrive\Робочий стіл\фф.txt";
        List<Students> students = new List<Students>();


        private void initControls()
        {
            BrushConverter bc = new BrushConverter();
            win.Height = 455;
            win.Width = 647;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.ResizeMode = ResizeMode.NoResize;
            win.Title = "Реєстрація";
            win.Background = (Brush)bc.ConvertFromString("#E6E7F2");


            myGrid.Height = 455;
            myGrid.Width = 647;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;


            Button btn = new Button();
            btn.Margin = new Thickness(387, 310, 84, 0);
            btn.Height = 30;
            btn.Click += Return_Click;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Content = "Вихід";
            btn.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
            btn.Background = (Brush)bc.ConvertFromString("#E6E7F2");
            btn.FontSize = 16;
            myGrid.Children.Add(btn);

            DropShadowEffect shadow = new DropShadowEffect();
            shadow.BlurRadius = 30;
            shadow.Color = Colors.LightGray;
            Border bord = new Border();
            bord.Background = new SolidColorBrush(Colors.White); 
            bord.Margin= new Thickness(24, 69, 340, 0);
            bord.Height = 273;
            bord.VerticalAlignment = VerticalAlignment.Top;
            bord.Effect = shadow;
            myGrid.Children.Add(bord);

            Border bord2 = new Border();
            bord2.Background = new SolidColorBrush(Colors.White);
            bord2.Margin = new Thickness(332, 69, 29, 0);
            bord2.Height = 193;
            bord2.VerticalAlignment = VerticalAlignment.Top;
            bord2.Effect = shadow;
            myGrid.Children.Add(bord2);

            Label text = new Label();
            text.Content = "Добавити";
            text.Margin = new Thickness(24, 69, 340, 347);
            text.Background= new SolidColorBrush(Colors.MediumVioletRed);
            text.Foreground = new SolidColorBrush(Colors.White);
            text.HorizontalContentAlignment = HorizontalAlignment.Center;
            text.FontSize = 20;
            myGrid.Children.Add(text);


            Label text2 = new Label();
            text2.Content = "Видалити";
            text2.Margin = new Thickness(332, 69, 28, 347);
            text2.Background = new SolidColorBrush(Colors.MediumVioletRed);
            text2.Foreground = new SolidColorBrush(Colors.White);
            text2.HorizontalContentAlignment = HorizontalAlignment.Center;
            text2.FontSize = 20;
            myGrid.Children.Add(text2);

            Label vv = new Label();
            vv.Margin = new Thickness(37, 116, 382, 289);
            vv.FontSize = 14;
            vv.Content = "Введіть:";
            myGrid.Children.Add(vv);

            Label vv2 = new Label();
            vv2.Margin = new Thickness(344, 116, 75, 288);
            vv2.FontSize = 14;
            vv2.Content = "Введіть:";
            myGrid.Children.Add(vv2);

            Label PIP = new Label();
            PIP.Content = "ПІП:";
            PIP.Margin = new Thickness(39, 150, 482, 245);
            PIP.FontSize = 20;
            myGrid.Children.Add(PIP);

            Label num = new Label();
            num.Content = "Номер ЗК:";
            num.Margin = new Thickness(37, 194, 484, 201);
            num.FontSize = 20;
            myGrid.Children.Add(num);

            Label num2 = new Label();
            num2.Content = "Номер ЗК:";
            num2.Margin = new Thickness(342, 157, 179, 237);
            num2.FontSize = 20;
            myGrid.Children.Add(num2);

            Label c = new Label();
            c.Content = "Курс";
            c.Margin = new Thickness(39, 242, 482, 153);
            c.FontSize = 20;
            myGrid.Children.Add(c);

            Name.Margin = new Thickness(102, 154, 357, 265);
            Name.FontSize = 16;
            myGrid.Children.Add(Name);

            Number.Margin = new Thickness(148, 198, 357, 220);
            Number.FontSize = 16;
            myGrid.Children.Add(Number);

            Course.Margin = new Thickness(113, 246, 357, 172);
            Course.FontSize = 16;
            myGrid.Children.Add(Course);

            text1.Margin = new Thickness(468, 158, 41, 259);
            text1.FontSize = 16;
            myGrid.Children.Add(text1);

            Button btn2 = new Button();
            btn2.Margin = new Thickness(108, 300, 422, 115);
            btn2.Background = new SolidColorBrush(Colors.MediumVioletRed); 
            btn2.Foreground = new SolidColorBrush(Colors.White);
            btn2.VerticalAlignment = VerticalAlignment.Top;
            btn2.Content = "Готово";
            btn2.FontSize = 16;
            btn2.Click += Button_Click;
            myGrid.Children.Add(btn2);

            Button btn3 = new Button();
            btn3.Margin = new Thickness(416, 230, 113, 0);
            btn3.VerticalAlignment = VerticalAlignment.Top;
            btn3.Background = new SolidColorBrush(Colors.MediumVioletRed);
            btn3.Foreground = new SolidColorBrush(Colors.White);
            btn3.Content = "Готово";
            btn3.FontSize = 16;
            btn3.Click += Button_Click2;
            myGrid.Children.Add(btn3);

           


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

        struct Students
        {
            private string Name;
            private string Number;
            private string Course;
            public Students(string Name, string Number, string Course)
            {
                this.Name = Name;
                this.Number = Number;
                this.Course = Course;
            }
            public string getName() => Name;
            public string getNumber() => Number;
            public string getCourse() => Course;
            public void PrintStud(StreamWriter Result1)
            {
                Result1.Write($"{Name}" + $"\t{Number}" + $"\t{Course}\n");
            }
        }


      


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StreamReader Stud = new StreamReader(path2);
            string list = Stud.ReadToEnd();
            if (list != "")
            {
                string[] line = list.Split('\n');
                for (int i = 0; i < line.Length - 1; i++)
                {
                    string[] elem = line[i].Split('\t');
                    if ((students.Where(x => x.getNumber() == elem[1])).Count() == 0)
                    {
                        students.Add(new Students(elem[0], elem[1], elem[2]));
                    }

                }
            }
            Stud.Close();
            students.Add(new Students(Name.Text, Number.Text, Course.Text));
            StreamWriter Result1 = new StreamWriter(path2, append: false);

            foreach (Students stu in students)
            {
                stu.PrintStud(Result1);
            }
            Result1.Close();

            MessageBox.Show("запис виконано успішно");

            Name.Text = "";
            Number.Text = "";
            Course.Text = "";
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            StreamReader Stud = new StreamReader(path2);
            string list = Stud.ReadToEnd();
            if (list != "")
            {
                string[] line = list.Split('\n');
                for (int i = 0; i < line.Length - 1; i++)
                {
                    string[] elem = line[i].Split('\t');
                    if ((students.Where(x => x.getNumber() == elem[1])).Count() == 0)
                    {
                        students.Add(new Students(elem[0], elem[1], elem[2]));
                    }

                }
            }
            Stud.Close();

            StreamWriter Result1 = new StreamWriter(path2, append: false);
            foreach (Students stu in students)
            {
                if (stu.getNumber() == text1.Text)
                {
                    students.Remove(stu);
                    break;
                }
            }
            foreach (Students stu in students)
            {
                stu.PrintStud(Result1);
            }
            Result1.Close();
            MessageBox.Show("видалення виконано успішно");
            text1.Text = "";

        }

    }
}
