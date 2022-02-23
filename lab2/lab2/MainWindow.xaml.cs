﻿using lab2;
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

namespace lab2
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

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            Window1 nwc = new Window1();
            Hide();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            this.Close();
        }

        private void kalk_Click(object sender, RoutedEventArgs e)
        {
            Window2 nwc = new Window2();
            Hide();
            this.Close();
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {
            Window4 nwc = new Window4();
            Hide();
            this.Close();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Window3 nwc = new Window3();
            Hide();
            this.Close();
        }
    }


}
