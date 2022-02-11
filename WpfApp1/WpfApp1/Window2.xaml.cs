using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            foreach (UIElement el in aaa.Children)
            {
                if (el is Button)
                    ((Button)el).Click += Button_Click;
            }
        }
  
        public string elem1 = "", elem2 = "";
        public int count = 0, ind, zn;
        public double res;

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
                if ((str == "+" || str == "-"|| str =="*" || str == "/")&& count!=1)
                {
                    elem1 = text.Text;
                    zn = str[0];
                    ind = text.Text.Length;
                    count++;

                }
                text.Text += str;
            }
        }


        private void ExitClick(object sender, RoutedEventArgs e)
        {
            MainWindow nwc = new MainWindow();
            Hide();
            nwc.Show();
        }
    }
}
