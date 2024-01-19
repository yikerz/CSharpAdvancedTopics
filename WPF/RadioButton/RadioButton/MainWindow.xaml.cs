﻿using System;
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

namespace RadioButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Maybe.IsChecked = true;

        }

        private void YesButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you!");
        }

        private void NoButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please say yes!");
        }
        private void MaybeButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Really?");
        }
    }
}