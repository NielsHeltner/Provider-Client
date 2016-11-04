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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Provider.domain;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        private Frame frame;
        private MainWindow mainwindow;
        private Frontpage frontpage;

        public LogIn(Frame frame, MainWindow mainwindow, Frontpage frontpage)
        {
            InitializeComponent();
            this.frame = frame;
            this.mainwindow = mainwindow;
            this.frontpage = frontpage;
            wrongUsernameOrPassword.Visibility = Visibility.Hidden;
        }

        private void LogUserIn(object sender, RoutedEventArgs e)
        {
            if (Controller.instance.LogIn(usernameBox.Text, passwordBox.Password))
            {
                wrongUsernameOrPassword.Visibility = Visibility.Hidden;
                mainwindow.AnimateHeaderLogin();
                frame.Content = frontpage;
                mainwindow.loggedIn.Content = Controller.instance.GetLoggedInUser() + " logget ind";
            }
            else
            {
                wrongUsernameOrPassword.Visibility = Visibility.Visible;
            }
        }

        private void UsernameGotFocus(object sender, RoutedEventArgs e)
        {
            usernameText.Visibility = Visibility.Hidden;
        }

        private void UsernameLostFocus(object sender, RoutedEventArgs e)
        {
            if(usernameBox.Text.Length == 0)
            {
                usernameText.Visibility = Visibility.Visible;
            }
        }

        private void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
            passwordText.Visibility = Visibility.Hidden;
        }

        private void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length == 0)
            {
                passwordText.Visibility = Visibility.Visible;
            }
        }

        private void submitForm(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LogUserIn(sender, e);
            }
        }
    }
}
