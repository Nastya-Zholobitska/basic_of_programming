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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
   
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {

        public Window4()
        {
            InitializeComponent();
        }

        List<Students> students = new List<Students>();

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nwc = new MainWindow();
            Hide();
            nwc.Show();
            this.Close();
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


       static string path2 = @"C:\Users\user\OneDrive\Робочий стіл\фф.txt";
     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
           StreamReader Stud = new StreamReader(path2);
            string list = Stud.ReadToEnd();
            if (list != "")
            {
                string[] line = list.Split('\n');
                for (int i = 0; i < line.Length-1; i++)
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
            string name = Name.Text;
            string number = Number.Text;
            string course = Course.Text;
            students.Add(new Students(name, number, course));

            foreach (Students stu in students)
            {
                stu.PrintStud(Result1);
            }
            Result1.Close();
            MessageBox.Show("запис виконано успішно");
            Name.Text="";
            Number.Text="";
            Course.Text="";
           
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
