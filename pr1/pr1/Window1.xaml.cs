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
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;


namespace pr1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            SymbolCount.Content = Text.Text.Length;
        }

        

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nwc = new MainWindow();
            Hide();
            nwc.Show();
            this.Close();
        }
        public int counter = 0, counter2=0;
        public Stopwatch stopwatch = new Stopwatch();
        public List<TimeSpan> mass = new List<TimeSpan>();

        static string path2 = @"C:\Users\user\OneDrive\Робочий стіл\еталонні значення.txt";

        private void Text_KeyDown(object sender, KeyEventArgs e)
        {

            ComboBoxItem item = (ComboBoxItem)CountProtection.SelectedItem;
            if (counter < Convert.ToInt16(item.Content))
            {
                if (counter2 == 0)
                {
                    stopwatch.Start();
                    counter2++;
                }
                else if (counter2 < 9)
                {
                    mass.Add(stopwatch.Elapsed);
                    counter2++;
                    stopwatch.Restart();
                }               
            }
            else
            {
                MessageBox.Show("Спроби використано!");
                Text.IsEnabled = false;
            }
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            SymbolCount.Content = counter2;
            ComboBoxItem item = (ComboBoxItem)CountProtection.SelectedItem;

            if (counter2 == 9 && Text.Text != "")
            {
                if (Text.Text == VerifField.Text)
                {
                   bool b = Check();
                   
                    if (!b)
                    {
                        Text.Text = "";
                        counter2 = 0;
                        SymbolCount.Content = counter2;
                    }
                    else if ((int)SymbolCount.Content >= VerifField.Text.Length)
                    {
                        Text.Text = "";
                        counter2 = 0;
                        SymbolCount.Content = counter2;
                        counter++;
                        if (counter < Convert.ToInt16(item.Content))
                        MessageBox.Show($"спроба {counter + 1}!");
                    }
                }
                else
                {
                    MessageBox.Show("спробу забраковано");
                    Text.Text = "";
                    counter2 = 0;
                    mass.Clear();
                    stopwatch.Reset();
                    SymbolCount.Content = counter2;
                }
               
            }
            
        }

        private bool Check()
        {
         
            bool check = true;
            counter2 = 0;
            stopwatch.Reset();
            double summ = 0;
            double m;
            double s2 = 0, s;
            double zn = 0;
            double coef;
            for (int j = 0; j < mass.Count; j++)
            {
                summ += mass[j].TotalSeconds;
            }
            for (int i = 0; i < mass.Count; i++)
            {
                m = (summ - mass[i].TotalSeconds) / (mass.Count - 1);
                for (int k = 0; k < mass.Count; k++)
                {
                    if (k == i) continue;
                    s2 += Math.Pow((mass[k].TotalSeconds - m), 2) / (mass.Count - 2);
                }
                s = Math.Sqrt(s2);
                coef = Math.Abs((mass[i].TotalSeconds - m) / s / Math.Sqrt(mass.Count - 1));
                if (coef > 2.57)
                {
                    MessageBox.Show("наявний незначущий елемент, введіть слово заново");
                    check = false;
                    mass.Clear();
                    return check;
                }
                else
                    s2 = 0;
            }

            StreamWriter Result1 = new StreamWriter(path2, append: true);
            m = summ / mass.Count;
            for (int j = 0; j < mass.Count; j++)
            {
                s2 += Math.Pow(mass[j].TotalSeconds - m, 2) / (mass.Count - 2);
            }
            Result1.WriteLine($"{ m} { s2}");

            Result1.Close();
            mass.Clear();
            return check;
        }


        }

   
}
