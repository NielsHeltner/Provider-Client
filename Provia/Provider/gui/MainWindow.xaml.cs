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
using System.Windows.Media.Animation;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Frontpage frontpage = new Frontpage();
        LogIn login;
        
        public MainWindow()
        {  
            InitializeComponent();
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            SetVisibilityToHidden();
            List<Button> buttonList = new List<Button>();
            buttonList.Add(button);
            buttonList.Add(button2);
            buttonList.Add(button1);
            buttonList.Add(logout);
            login = new LogIn(frame, frontpage, buttonList, logged_in, searchText, SearchTermTextBox);
            frame.Content = login;
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
            frame.Content = login;
            SetVisibilityToHidden();
        }

        private void SetVisibilityToHidden()
        {
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            logout.Visibility = Visibility.Hidden;
            logged_in.Visibility = Visibility.Hidden;
            searchText.Visibility = Visibility.Hidden;
            SearchTermTextBox.Visibility = Visibility.Hidden;
        }
    }
}
