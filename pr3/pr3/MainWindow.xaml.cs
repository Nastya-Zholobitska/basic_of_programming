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

namespace pr3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            Window1 administration = new Window1();
            Hide();
            administration.Show();
            this.Close();
        }
      
        private void Close2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void UserMode_Click(object sender, RoutedEventArgs e)
        {
            Window2 user = new Window2();
            Hide();
            user.Show();
            this.Close();
        }

        private void AboutDev_Click(object sender, RoutedEventArgs e)
        {
            Window3 author = new Window3();
            Hide();
            author.Show();
            this.Close();
        }
    }
}
