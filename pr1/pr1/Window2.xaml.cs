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
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace pr1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }


        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nwc = new MainWindow();
            Hide();
            nwc.Show();
            this.Close();
        }
        public int counter = 0, counter2 = 0;
        public Stopwatch stopwatch = new Stopwatch();
        public List<TimeSpan> mass = new List<TimeSpan>();
        public List<double> ident = new List<double>();
        public List<double> ident2 = new List<double>();
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
                stat();

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
                    s2 += Math.Pow(mass[k].TotalSeconds - m, 2) / (mass.Count - 2);
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
            m = summ / mass.Count;
            for (int j = 0; j < mass.Count; j++)
            {
                s2 += Math.Pow(mass[j].TotalSeconds - m, 2) / (mass.Count - 2);
            }
            ident.Add(m);
            ident.Add(s2);
            mass.Clear();
            return check;
        }

        public void stat ()
        {
            int  neodn = 0, odn = 0;
            double s2_1, s2_2, m_1, m_2, s, t_p, p=0, p1, p2;
            
            StreamReader etalon = new StreamReader(path2);
            string etalon_zn = etalon.ReadToEnd();
            string[] line = etalon_zn.Split('\n');
            for (int i = 0; i < line.Length; i++)
            {
                string[] elem = line[i].Split(' ');
                foreach (string elemm in elem)
                {
                    if (elemm!="")
                    ident2.Add(Convert.ToDouble(elemm));
                }
            }
            int r = 0, n1=0, k = ident2.Count / 2;
            for (int i = 0; i < ident.Count; i=i+2) 
            {
                m_2 = ident[i];
                s2_2 = ident[i + 1];
                for (int j = 0; j < ident2.Count; j = j + 2)
                {
                    m_1 = ident2[j];
                    s2_1 = ident2[j + 1];
                    double s2max = Math.Max(s2_2, s2_1);
                    double s2min = Math.Min(s2_2, s2_1);
                    double f = s2max / s2min;
                    if (f > 3.44)
                        neodn++;
                    else odn++;
                    s = Math.Sqrt((s2_1+s2_2)*(VerifField.Text.Length-2)/(2*( VerifField.Text.Length-1) - 1));
                    double sqr = Math.Sqrt(2.0 /( VerifField.Text.Length - 1));
                    t_p = Math.Abs(m_1 - m_2) / (s * sqr);
                    if (t_p <= 2.57)
                        r++;
                    else n1++;
                }
            
            }
            if (neodn > odn)
                Disper.Content = "неоднорідні";
            else
                Disper.Content = "однорідні";
            p = Math.Round(((double)r * 100) / ((double)k* (ident.Count / 2)));
            coef_P.Content = p+"%";
            p1=Math.Round( n1 / ((double)k * (ident.Count / 2)), 2);
            if (Box.IsChecked == true)
            {
                P1.Content = p1;
                P2.Content = "-";
            }
            else
            {
                P1.Content = "-";
                P2.Content = p1;
            }

        }
    }
    }


