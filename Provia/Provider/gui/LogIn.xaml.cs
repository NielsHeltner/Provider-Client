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
            //usernameBox.Text = "Provia";
            //passwordBox.Password = "123";
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
                DoubleAnimationUsingKeyFrames daukf = new DoubleAnimationUsingKeyFrames();
                //daukf.RepeatBehavior = new RepeatBehavior(3);
                EasingDoubleKeyFrame frame1 = new EasingDoubleKeyFrame(40, new TimeSpan(0, 0, 0, 0, 50));
                EasingDoubleKeyFrame frame2 = new EasingDoubleKeyFrame(70, new TimeSpan(0, 0, 0, 0, 100));
                EasingDoubleKeyFrame frame3 = new EasingDoubleKeyFrame(40, new TimeSpan(0, 0, 0, 0, 150));
                EasingDoubleKeyFrame frame4 = new EasingDoubleKeyFrame(70, new TimeSpan(0, 0, 0, 0, 200));
                EasingDoubleKeyFrame frame5 = new EasingDoubleKeyFrame(40, new TimeSpan(0, 0, 0, 0, 250));
                EasingDoubleKeyFrame frame6 = new EasingDoubleKeyFrame(56, new TimeSpan(0, 0, 0, 0, 300));
                DoubleKeyFrameCollection frameCollection = new DoubleKeyFrameCollection();
                frameCollection.Add(frame1);
                frameCollection.Add(frame2);
                frameCollection.Add(frame3);
                frameCollection.Add(frame4);
                frameCollection.Add(frame5);
                frameCollection.Add(frame6);
                daukf.KeyFrames = frameCollection;
                usernameBox.BeginAnimation(Canvas.LeftProperty, daukf);
                usernameText.BeginAnimation(Canvas.LeftProperty, daukf);
                passwordBox.BeginAnimation(Canvas.LeftProperty, daukf);
                passwordText.BeginAnimation(Canvas.LeftProperty, daukf);
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
