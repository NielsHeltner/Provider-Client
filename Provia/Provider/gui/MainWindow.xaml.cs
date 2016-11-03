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
using Provider.gui;
using Provider.domain;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Frontpage frontpage = new Frontpage();
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frame.Content = frontpage;
        }

        private void goToFrontpage(object sender, RoutedEventArgs e)
        {
            frame.Content = frontpage;
        }

        private void fillTextField(object sender, RoutedEventArgs e)
        {
                SupplierList a = new SupplierList(frame);
                frame.Content = a;
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            Controller.Instance.LogOut();
            frame.Content = null;
        }
    }
}
