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
using Provider.gui;

namespace Provider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void fillTextField(object sender, RoutedEventArgs e)
        {
            if (frame.Content.GetType() == typeof(Antonio))
            {
                Nils n = new Nils();
                frame.Content = n;
            }
            else
            {
                Antonio a = new Antonio();

                frame.Content = a;
            }
        }
    }
}